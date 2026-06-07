using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.SharingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public sealed class SocialShareComposer : NativeFeatureBehaviour
	{
		private INativeSocialShareComposer m_nativeComposer;

		private EventCallback<SocialShareComposerResult> m_callback;

		public static SocialShareComposer CreateInstance(SocialShareComposerType composerType)
		{
			return null;
		}

		public static bool IsComposerAvailable(SocialShareComposerType composerType)
		{
			return false;
		}

		protected override void AwakeInternal(object[] args)
		{
		}

		protected override void DestroyInternal()
		{
		}

		public override bool IsAvailable()
		{
			return false;
		}

		protected override string GetFeatureName()
		{
			return null;
		}

		public void SetText(string value)
		{
		}

		public void AddScreenshot()
		{
		}

		public void AddImage(Texture2D image, TextureEncodingFormat textureEncodingFormat = TextureEncodingFormat.JPG)
		{
		}

		public void AddImage(byte[] imageData)
		{
		}

		public void AddURL(URLString url)
		{
		}

		public void SetCompletionCallback(EventCallback<SocialShareComposerResult> callback)
		{
		}

		public void Show()
		{
		}

		public void Show(Vector2 screenPosition)
		{
		}

		private void HandleOnClose(SocialShareComposerResultCode resultCode, Error error)
		{
		}
	}
}
