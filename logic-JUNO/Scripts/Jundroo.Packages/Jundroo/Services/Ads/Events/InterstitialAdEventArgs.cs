using System;

namespace Jundroo.Services.Ads.Events
{
	public class InterstitialAdEventArgs : EventArgs
	{
		public IInterstitialAd Ad { get; }

		public InterstitialAdEventArgs(IInterstitialAd ad)
		{
			Ad = ad;
		}
	}
}
