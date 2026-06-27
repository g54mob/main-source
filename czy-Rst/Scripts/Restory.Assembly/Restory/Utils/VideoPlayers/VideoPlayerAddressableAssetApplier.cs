using System.Collections;
using Restory.AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Video;
using Zenject;

namespace Restory.Utils.VideoPlayers
{
	public class VideoPlayerAddressableAssetApplier : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer videoPlayer;

		[SerializeField]
		private AssetReference videoClipRef;

		private IAssetProvider assetProvider;

		[Inject]
		private void Construct(IAssetProvider assetProvider)
		{
			this.assetProvider = assetProvider;
		}

		private void OnEnable()
		{
			if (assetProvider == null)
			{
				StartCoroutine(DelayedInitialization());
			}
			else
			{
				Initialize();
			}
		}

		private IEnumerator DelayedInitialization()
		{
			yield return new WaitUntil(() => assetProvider != null);
			Initialize();
		}

		private async void Initialize()
		{
			VideoPlayer videoPlayer = this.videoPlayer;
			videoPlayer.clip = await assetProvider.Load<VideoClip>(videoClipRef, preserved: false);
			this.videoPlayer.Play();
		}
	}
}
