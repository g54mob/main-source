using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetBlockListResponseT
	{
		[XmlAttribute]
		public string Return;

		[XmlElement]
		public List<UserT> User;
	}
}
