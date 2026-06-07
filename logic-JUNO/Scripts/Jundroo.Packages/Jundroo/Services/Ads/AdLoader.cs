using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Jundroo.Services.Ads
{
	public static class AdLoader
	{
		public static Task<IInterstitialAd> LoadInterstitialAdAsync(string adUnitId, ICollection<string> keywords = null, IDictionary<string, string> extras = null)
		{
			Debug.LogError("Attempting to load an interstitial ad when advertising has been disabled in the build.");
			return Task.FromResult<IInterstitialAd>(null);
		}
	}
}
