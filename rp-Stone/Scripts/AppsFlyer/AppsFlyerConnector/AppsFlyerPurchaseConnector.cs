using UnityEngine;

namespace AppsFlyerConnector
{
	public class AppsFlyerPurchaseConnector : MonoBehaviour
	{
		public static readonly string kAppsFlyerPurchaseConnectorVersion = "2.0.0";

		public static void init(MonoBehaviour unityObject, Store s)
		{
		}

		public static void build()
		{
		}

		public static void startObservingTransactions()
		{
		}

		public static void stopObservingTransactions()
		{
		}

		public static void setIsSandbox(bool isSandbox)
		{
		}

		public static void setPurchaseRevenueValidationListeners(bool enableCallbacks)
		{
		}

		public static void setAutoLogPurchaseRevenue(params AppsFlyerAutoLogPurchaseRevenueOptions[] autoLogPurchaseRevenueOptions)
		{
		}

		private static int mapStoreToInt(Store s)
		{
			if (s == Store.GOOGLE)
			{
				return 0;
			}
			return -1;
		}
	}
}
