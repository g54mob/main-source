using System.Xml.Serialization;

namespace Origin.Data
{
	public enum GroupTypeT
	{
		[XmlEnum("PUBLIC")]
		PUBLIC = 0,
		[XmlEnum("PRIVATE")]
		PRIVATE = 1
	}
}
