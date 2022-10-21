using AntDesign;
using Blazor.ECharts.Options;
using Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using L = Blazor.ECharts.Options.Series.Line;
using Blazor.ECharts.Options.Enum;

namespace Client.Codes
{
    public class recordModel
    {
        public string value { get; set; }
        public string time { get; set; }
    }
    public class DmonPageBase : ComponentBase
    {
        [Inject]
        private HttpClient? httpClient { get; set; }

        private string? _dmon_group_groupid;
        [Parameter]
        public string dmon_group_groupid
        {
            get => _dmon_group_groupid;
            set
            {
                _dmon_group_groupid = value;
                Data = Caches.dmons.Where(w => w.GroupId.ToString() == dmon_group_groupid).ToList();
                InvokeAsync(StateHasChanged);
            }
        }
        public bool visible = false;
        public string drawTitle { get; set; }
        public ListGridType grid = new ListGridType { Gutter = 16, Column = 4 };
        public List<dmon> Data = new List<dmon>();
        public EChartsOption<L.Line> Option = new() { YAxis = new() { new() { Type = AxisType.Value } }, XAxis = new() { new() { Type = AxisType.Category, Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" } } }, Series = new() { new L.Line() { Type = "line", Data = new[] { 820, 932, 901, 934, 1290, 1330, 1320 }, Smooth = true } } };
        public string placement = "bottom";
        double[] linearr = new double[6] { 0, 0, 0, 0, 0, 0 };
        private string _cachevalue = "NULL";
        public string cachevalue
        {
            get => _cachevalue;
            set
            {
                _cachevalue = value;
                for (int i = 0; i < 5; i++)
                {
                    linearr[i] = linearr[i + 1];
                }
                try { linearr[5] = Convert.ToDouble(value); }catch(Exception) { linearr[5] = 0; }
                Console.WriteLine(value);
                Option = new()
                {
                    YAxis = new()
                    {
                        new()
                        {
                            Type = AxisType.Value,
                            Scale=true
                        }
                    },
                    XAxis = new()
                    {
                        new()
                        {
                            Type = AxisType.Category,
                            Data = new[]
                            {
                                DateTime.Now.AddSeconds(-6).ToLongTimeString(),
                                DateTime.Now.AddSeconds(-5).ToLongTimeString(),
                                DateTime.Now.AddSeconds(-4).ToLongTimeString(),
                                DateTime.Now.AddSeconds(-3).ToLongTimeString(),
                                DateTime.Now.AddSeconds(-2).ToLongTimeString(),
                                DateTime.Now.AddSeconds(-1).ToLongTimeString(),
                                DateTime.Now.ToLongTimeString()
                            }
                        }
                    },
                    Series = new()
                    {
                        new L.Line()
                        {
                            Type="line",
                            Data=linearr,
                            Smooth=true
                        }
                    }
                };
                record.Add(new recordModel()
                {
                    value = value,
                    time = DateTime.Now.ToString()
                });
                InvokeAsync(StateHasChanged);
            }
        }
        public List<recordModel> record = new List<recordModel>();
        public Timer timer { get; set; }
        public async Task open(dmon dmonmodel)
        {
            drawTitle = dmonmodel.Dmondtov2Name;
            record = new List<recordModel>();
            linearr = new double[6] { 0, 0, 0, 0, 0, 0 };
            Option = new() { YAxis = new() { new() { Type = AxisType.Value } }, XAxis = new() { new() { Type = AxisType.Category, Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" } } }, Series = new() { new L.Line() { Type = "line", Data = new[] { 820, 932, 901, 934, 1290, 1330, 1320 }, Smooth = true } } };
            int num = 0;
            timer = new Timer(async (object? stateInfo) =>
                {
                    var url = "server/getcache?id=" + dmonmodel.Id.ToString();
                    cachevalue = await httpClient.GetStringAsync(url) ?? "NULL";
                    if (cachevalue == "") cachevalue = "NULL";
                }, new AutoResetEvent(false), 1000, 1000);

            this.visible = true;
        }
        public void close()
        {
            this.visible = false;
            timer.Dispose();
        }
    }
}
