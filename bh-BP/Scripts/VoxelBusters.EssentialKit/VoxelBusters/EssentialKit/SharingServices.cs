using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.SharingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class SharingServices
	{
		[ClearOnReload]
		private static INativeSharingInterface s_nativeInterface;

		public static SharingServicesUnitySettings UnitySettings { get; private set; }

		internal static INativeSharingInterface NativeInterface => null;

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(SharingServicesUnitySettings settings)
		{
		}

		public static void ShowMailComposer(string[] toRecipients = null, string[] ccRecipients = null, string[] bccRecipients = null, string subject = null, string body = null, bool isHtmlBody = false, EventCallback<MailComposerResult> callback = null, params ShareItem[] shareItems)
		{
		}

		public static void ShowMessageComposer(string[] recipients = null, string subject = null, string body = null, EventCallback<MessageComposerResult> callback = null, params ShareItem[] shareItems)
		{
		}

		public static void ShowShareSheet(EventCallback<ShareSheetResult> callback = null, params ShareItem[] shareItems)
		{
		}

		public static void ShowSocialShareComposer(SocialShareComposerType composerType, EventCallback<SocialShareComposerResult> callback = null, params ShareItem[] shareItems)
		{
		}

		public static void ConvertGifToShareItem(string filePath, SuccessCallback<ShareItem> onSuccess, ErrorCallback onError)
		{
		}
	}
}
