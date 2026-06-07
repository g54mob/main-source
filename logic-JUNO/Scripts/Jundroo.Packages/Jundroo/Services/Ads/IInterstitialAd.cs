using System;
using System.Threading.Tasks;
using Jundroo.Services.Ads.Events;

namespace Jundroo.Services.Ads
{
	public interface IInterstitialAd : IAd
	{
		event EventHandler<InterstitialAdEventArgs> AdClicked;

		event EventHandler<InterstitialAdEventArgs> AdClosed;

		event EventHandler<InterstitialAdErrorEventArgs> AdFailed;

		event EventHandler<InterstitialAdEventArgs> AdImpression;

		event EventHandler<InterstitialAdEventArgs> AdOpened;

		event EventHandler<InterstitialAdPaidEventArgs> AdPaid;

		Task ShowAsync();
	}
}
