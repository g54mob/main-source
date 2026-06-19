using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryMuteStateResponseT
	{
		[XmlElement(ElementName = "MuteState")]
		public List<MuteStateT> MuteStateArray;
	}
}
