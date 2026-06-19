using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryOffersResponseT
	{
		[XmlElement(ElementName = "Offer")]
		public List<OfferT> Offers;
	}
}
