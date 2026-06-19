using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "MarketPurchaseAttempt", "DealOffers", "InitialTimer", "Timer", "ItemsToDispense" })]
	public class ES3UserType_MagicMarket : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MagicMarket()
			: base(null)
		{
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
		}
	}
}
