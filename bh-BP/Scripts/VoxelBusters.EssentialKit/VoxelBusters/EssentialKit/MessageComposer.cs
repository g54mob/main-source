using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.SharingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public sealed class MessageComposer : NativeFeatureBehaviour
	{
		private INativeMessageComposer m_nativeComposer;

		private EventCallback<MessageComposerResult> m_callback;

		public static MessageComposer CreateInstance()
		{
			return null;
		}

		public static bool CanSendText()
		{
			return false;
		}

		public static bool CanSendAttachments()
		{
			return false;
		}

		public static bool CanSendSubject()
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

		public void SetRecipients(params string[] values)
		{
		}

		public void SetSubject(string value)
		{
		}

		public void SetBody(string value)
		{
		}

		public void AddScreenshot(string fileName)
		{
		}

		public void AddImage(Texture2D image, string fileName, TextureEncodingFormat textureEncodingFormat = TextureEncodingFormat.JPG)
		{
		}

		public void AddAttachment(byte[] data, string mimeType, string fileName)
		{
		}

		public void SetCompletionCallback(EventCallback<MessageComposerResult> callback)
		{
		}

		public void Show()
		{
		}

		private void HandleComposerCloseInternalCallback(MessageComposerResultCode resultCode, Error error)
		{
		}
	}
}
