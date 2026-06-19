using System.Xml.Serialization;

namespace Origin.Data
{
	public enum ChatStateT
	{
		[XmlEnum("USER_WRITING_START")]
		USER_WRITING_START = 0,
		[XmlEnum("USER_WRITING_END")]
		USER_WRITING_END = 1
	}
}
