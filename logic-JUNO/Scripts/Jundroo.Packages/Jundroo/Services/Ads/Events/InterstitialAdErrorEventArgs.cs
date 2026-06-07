using System;

namespace Jundroo.Services.Ads.Events
{
	public class InterstitialAdErrorEventArgs : EventArgs
	{
		public IInterstitialAd Ad { get; }

		public string Error { get; }

		public InterstitialAdErrorEventArgs(IInterstitialAd ad, string error)
		{
			Ad = ad;
			Error = error;
		}
	}
}
