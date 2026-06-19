using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetWalletBalanceT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Currency;
	}
}
