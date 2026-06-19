using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class CheckoutT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Currency;

		[XmlElement]
		public List<string> Offers;
	}
}
