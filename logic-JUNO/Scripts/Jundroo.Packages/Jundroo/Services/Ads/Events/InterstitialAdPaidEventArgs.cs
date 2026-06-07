using System;

namespace Jundroo.Services.Ads.Events
{
	public class InterstitialAdPaidEventArgs : EventArgs
	{
		public IInterstitialAd Ad { get; }

		public AdValue AdValue { get; }

		public InterstitialAdPaidEventArgs(IInterstitialAd ad, AdValue adValue)
		{
			Ad = ad;
			AdValue = adValue;
		}
	}
}
