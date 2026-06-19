using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryOffersT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlElement]
		public List<string> FilterCategories;

		[XmlElement]
		public List<string> FilterMasterTitleIds;

		[XmlElement]
		public List<string> FilterOffers;
	}
}
