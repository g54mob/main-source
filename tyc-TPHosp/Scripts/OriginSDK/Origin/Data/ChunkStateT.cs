using System.Xml.Serialization;

namespace Origin.Data
{
	public enum ChunkStateT
	{
		[XmlEnum("UNKNOWN")]
		UNKNOWN = 0,
		[XmlEnum("PAUSED")]
		PAUSED = 1,
		[XmlEnum("QUEUED")]
		QUEUED = 2,
		[XmlEnum("ERROR")]
		ERROR = 3,
		[XmlEnum("DOWNLOADING")]
		DOWNLOADING = 4,
		[XmlEnum("INSTALLING")]
		INSTALLING = 5,
		[XmlEnum("INSTALLED")]
		INSTALLED = 6,
		[XmlEnum("BUSY")]
		BUSY = 7
	}
}
