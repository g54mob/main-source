using System.Xml.Serialization;

namespace Origin.Data
{
	public enum RestartOptionsT
	{
		[XmlEnum("NORMAL")]
		NORMAL = 0,
		[XmlEnum("FORCE_UPDATE_FOR_GAME")]
		FORCE_UPDATE_FOR_GAME = 1
	}
}
