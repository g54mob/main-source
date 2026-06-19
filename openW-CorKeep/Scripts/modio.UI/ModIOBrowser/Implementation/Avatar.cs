using System.Threading.Tasks;
using ModIO;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Avatar : SelfInstancingMonoSingleton<Avatar>
	{
		[SerializeField]
		public Image Avatar_Main;

		[SerializeField]
		public Image AvatarDownloadBar;

		[Header("Platform Avatar Icons")]
		[SerializeField]
		public Image PlatformIcon_Main;

		[SerializeField]
		public Image PlatformIcon_DownloadQueue;

		[SerializeField]
		public Sprite switchAvatar;

		[SerializeField]
		public Sprite SteamAvatar;

		[SerializeField]
		public Sprite XboxAvatar;

		[SerializeField]
		public Sprite PlayStationAvatar;

		private async Task<Sprite> GetSprite(UserPortal currentAuthenticationPortal, UserProfile currentUserProfile)
		{
			switch (currentAuthenticationPortal)
			{
			case UserPortal.Nintendo:
				return switchAvatar;
			case UserPortal.Steam:
				return SteamAvatar;
			case UserPortal.XboxLive:
				return XboxAvatar;
			case UserPortal.PlayStationNetwork:
				return PlayStationAvatar;
			default:
				currentUserProfile = await GetCurrentUser(currentUserProfile);
				return await DownloadSprite(currentUserProfile.avatar_50x50);
			}
		}

		public void SetupUser()
		{
			SetupUser(SelfInstancingMonoSingleton<Authentication>.Instance.currentAuthenticationPortal, SelfInstancingMonoSingleton<Authentication>.Instance.currentUserProfile);
		}

		private async void SetupUser(UserPortal currentAuthenticationPortal, UserProfile currentUserProfile)
		{
			Sprite sprite = await GetSprite(currentAuthenticationPortal, currentUserProfile);
			if (sprite == null)
			{
				ShowDefaultAvatar();
			}
			else if (currentAuthenticationPortal == UserPortal.None)
			{
				PlatformFree(sprite);
			}
			else
			{
				Platform(sprite);
			}
		}

		private void ShowDefaultAvatar()
		{
			Avatar_Main.gameObject.SetActive(value: false);
			SelfInstancingMonoSingleton<DownloadQueue>.Instance.Avatar_DownloadQueue.gameObject.SetActive(value: false);
			PlatformIcon_Main.transform.parent.gameObject.SetActive(value: false);
			PlatformIcon_DownloadQueue.transform.parent.gameObject.SetActive(value: false);
		}

		private void PlatformFree(Sprite sprite)
		{
			Avatar_Main.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<DownloadQueue>.Instance.Avatar_DownloadQueue.gameObject.SetActive(value: true);
			PlatformIcon_Main.transform.parent.gameObject.SetActive(value: false);
			PlatformIcon_DownloadQueue.transform.parent.gameObject.SetActive(value: false);
			Avatar_Main.sprite = sprite;
			SelfInstancingMonoSingleton<DownloadQueue>.Instance.Avatar_DownloadQueue.sprite = sprite;
		}

		private void Platform(Sprite sprite)
		{
			Avatar_Main.gameObject.SetActive(value: false);
			SelfInstancingMonoSingleton<DownloadQueue>.Instance.Avatar_DownloadQueue.gameObject.SetActive(value: false);
			PlatformIcon_Main.transform.parent.gameObject.SetActive(value: true);
			PlatformIcon_DownloadQueue.transform.parent.gameObject.SetActive(value: true);
			PlatformIcon_Main.sprite = sprite;
			PlatformIcon_DownloadQueue.sprite = sprite;
		}

		internal async Task<UserProfile> GetCurrentUser(UserProfile currentUserProfile)
		{
			ResultAnd<UserProfile> resultAnd = await ModIOUnityAsync.GetCurrentUser();
			return resultAnd.result.Succeeded() ? resultAnd.value : currentUserProfile;
		}

		private async Task<Sprite> DownloadSprite(DownloadReference reference)
		{
			ResultAnd<Texture2D> resultAnd = await ModIOUnityAsync.DownloadTexture(reference);
			if (resultAnd.result.Succeeded())
			{
				return Sprite.Create(resultAnd.value, new Rect(0f, 0f, resultAnd.value.width, resultAnd.value.height), Vector2.zero);
			}
			return null;
		}

		internal void UpdateDownloadProgressBar(ProgressHandle handle)
		{
			AvatarDownloadBar.fillAmount = handle?.Progress ?? 0f;
		}
	}
}
