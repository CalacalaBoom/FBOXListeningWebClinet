namespace Client.Models
{
    public class box_groups
    {
        /// <summary>
        /// 盒子组别Uid
        ///</summary>
        public long uid { get; set; }
        /// <summary>
        /// 盒子组别名
        ///</summary>
        public string? name { get; set; }
    }
    public class box
    {
        /// <summary>
        /// 盒子编号 
        ///</summary>
        public string? boxNo { get; set; }
        /// <summary>
        /// 盒子名称 
        ///</summary>
        public string? alias { get; set; }
        /// <summary>
        /// 盒子状态 
        ///</summary>
        public string? connectionState { get; set; }
        /// <summary>
        /// 盒子类型 
        ///</summary>
        public string? boxType { get; set; }
        /// <summary>
        /// 当前网络类型 
        ///</summary>
        public string? networkType { get; set; }
        /// <summary>
        /// 盒子组别UID 
        ///</summary>
        public long? uid { get; set; }
        /// <summary>
        /// 盒子组别名称 
        ///</summary>
        public string? name { get; set; }
    }
    public class dmon
    {
        /// <summary>
        /// 监控点名称 
        ///</summary>
        public string? Dmondtov2Name { get; set; }
        /// <summary>
        /// 小数位 
        ///</summary>
        public string? FractionalDigits { get; set; }
        /// <summary>
        /// 监控点分组ID 
        ///</summary>
        public long? GroupId { get; set; }
        /// <summary>
        /// 监控点分组名称 
        ///</summary>
        public string? GroupName { get; set; }
        /// <summary>
        /// 单位 
        ///</summary>
        public string? Unit { get; set; }
        /// <summary>
        /// 读写模式 
        ///</summary>
        public string? Privilege { get; set; }
        /// <summary>
        /// 省流量模式 
        ///</summary>
        public int? TrafficSaving { get; set; }
        /// <summary>
        /// 死区值 
        ///</summary>
        public decimal? DeadValue { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
        public string? Memo { get; set; }
        /// <summary>
        /// 编码方式 
        ///</summary>
        public string? Encoding { get; set; }
        /// <summary>
        /// 字节序 
        ///</summary>
        public string? StringByteOrder { get; set; }
        /// <summary>
        /// 字符个数 
        ///</summary>
        public int? CharCount { get; set; }
        /// <summary>
        /// 监控点Id 
        ///</summary>
        public long? Id { get; set; }
        /// <summary>
        /// 设备是否移除 
        ///</summary>
        public int? IsDeviceChanged { get; set; }
        /// <summary>
        /// 条目状态 
        ///</summary>
        public string? TaskState { get; set; }
        /// <summary>
        /// 值
        ///</summary>
        public string? Value { get; set; }
        /// <summary>
        /// 代理主键
        ///</summary>
        public int? This_id { get; set; }
    }
    public class dmon_group
    {
        /// <summary>
        /// 监控点分组ID 
        ///</summary>
        public long? GroupId { get; set; }
        /// <summary>
        /// 监控点分组名称 
        ///</summary>
        public string? GroupName { get; set; }
        /// <summary>
        /// 盒子编号 
        ///</summary>
        public string? BoxNo { get; set; }
    }
}
