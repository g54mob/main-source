using System.Xml.Serialization;

namespace Origin.Data
{
	public enum IGOStateT
	{
		[XmlEnum("DOWN")]
		DOWN = 0,
		[XmlEnum("UP")]
		UP = 1
	}
}
