using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryEntitlementsT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Group;

		[XmlAttribute]
		public bool includeChildGroups;

		[XmlElement]
		public List<string> FilterCategories;

		[XmlElement]
		public List<string> FilterOffers;

		[XmlElement]
		public List<string> FilterItems;

		[XmlElement]
		public List<string> FilterGroups;
	}
}
