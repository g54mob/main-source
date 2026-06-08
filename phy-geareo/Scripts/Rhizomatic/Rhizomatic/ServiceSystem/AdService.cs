using System;

namespace Rhizomatic.ServiceSystem
{
	public abstract class AdService : Service
	{
		public void LoadRewarded(string key, Action<ServiceAd> onSucceed, Action<ServiceAdError> onFailed)
		{
		}

		public void ShowRewarded(ServiceAd ad, Action<ServiceAdReward> onReward, Action onClosed, Action<ServiceAdError> onFailed)
		{
		}

		public void ShowRewarded(string key, Action<ServiceAdReward> onReward, Action onClosed, Action<ServiceAdError> onFailed)
		{
		}

		protected abstract void DoLoadRewarded(string key, Action<ServiceAd> onSuccess, Action<ServiceAdError> onFailed);

		protected abstract void DoShowRewarded(ServiceAd ad, Action<ServiceAdReward> onReward, Action onClosed, Action<ServiceAdError> onFailed);
	}
}
