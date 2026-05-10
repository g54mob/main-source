using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_StoreStock : ES3UserType_BBTStock
	{
		public static ES3Type StoreStockInstance;

		public ES3UserType_StoreStock()
			: base(typeof(StoreStock))
		{
			StoreStockInstance = this;
			priority = 1;
		}
	}
}
