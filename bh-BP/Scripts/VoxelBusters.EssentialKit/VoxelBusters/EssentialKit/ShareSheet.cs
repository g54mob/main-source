using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.SharingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public sealed class ShareSheet : NativeFeatureBehaviour
	{
		private INativeShareSheet m_nativeComposer;

		private EventCallback<ShareSheetResult> m_callback;

		public static ShareSheet CreateInstance()
		{
			return null;
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

		public void AddText(string value)
		{
		}

		public void AddScreenshot()
		{
		}

		public void AddImage(Texture2D image, TextureEncodingFormat textureEncodingFormat = TextureEncodingFormat.JPG)
		{
		}

		public void AddImage(byte[] imageData, string mimeType)
		{
		}

		public void AddURL(URLString url)
		{
		}

		public void AddAttachment(byte[] data, string mimeType, string filename)
		{
		}

		public void SetCompletionCallback(EventCallback<ShareSheetResult> callback)
		{
		}

		public void Show()
		{
		}

		public void Show(Vector2 screenPosition)
		{
		}

		private void HandleOnClose(ShareSheetResultCode resultCode, Error error)
		{
		}
	}
}
