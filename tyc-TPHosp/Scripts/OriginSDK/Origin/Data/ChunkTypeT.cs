using System.Xml.Serialization;

namespace Origin.Data
{
	public enum ChunkTypeT
	{
		[XmlEnum("UNKNOWN")]
		UNKNOWN = 0,
		[XmlEnum("REQUIRED")]
		REQUIRED = 1,
		[XmlEnum("RECOMMENDED")]
		RECOMMENDED = 2,
		[XmlEnum("NORMAL")]
		NORMAL = 3,
		[XmlEnum("ONDEMAND")]
		ONDEMAND = 4
	}
}
