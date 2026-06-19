using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetWalletBalanceResponseT
	{
		[XmlAttribute]
		public long Balance;
	}
}
