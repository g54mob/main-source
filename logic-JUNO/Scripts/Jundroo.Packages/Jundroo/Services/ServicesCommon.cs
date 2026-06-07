using System.Threading.Tasks;
using Jundroo.Services.Ads;
using Jundroo.Services.Analytics;
using Jundroo.Services.Purchasing;
using Jundroo.Services.Unity;
using UnityEngine;

namespace Jundroo.Services
{
	public static class ServicesCommon
	{
		private static bool _dialogBasedServicesInitialized;

		private static PurchasingService.InitializationParameters _initiParamsPurchasing;

		private static AdsService.InitializationParameters _initParamsAds;

		private static AnalyticsService.InitializationParameters _initParamsAnalytics;

		private static bool _startupServicesInitialized;

		public static void ConfigureAdsService(AdsService.InitializationParameters initParams)
		{
			_initParamsAds = initParams;
		}

		public static void ConfigureAnalyticsService(AnalyticsService.InitializationParameters initParams)
		{
			_initParamsAnalytics = initParams;
		}

		public static void ConfigurePurchasingService(PurchasingService.InitializationParameters initParams)
		{
			_initiParamsPurchasing = initParams;
		}

		public static async Task InitializeDialogBasedServicesIfNecessary()
		{
			if (!_dialogBasedServicesInitialized)
			{
				_dialogBasedServicesInitialized = true;
				await AdsService.Initialize(_initParamsAds);
				await AnalyticsService.Initialize(_initParamsAnalytics);
			}
		}

		public static async Task InitializeStartupServices(string environment)
		{
			if (_startupServicesInitialized)
			{
				Debug.LogError("Startup services already initialized.");
				return;
			}
			_startupServicesInitialized = true;
			await UnityServices.Initialize(environment);
			await PurchasingService.Initialize(_initiParamsPurchasing);
		}
	}
}
