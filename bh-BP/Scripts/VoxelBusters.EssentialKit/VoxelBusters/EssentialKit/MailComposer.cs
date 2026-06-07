using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.SharingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public sealed class MailComposer : NativeFeatureBehaviour
	{
		private INativeMailComposer m_nativeComposer;

		private EventCallback<MailComposerResult> m_callback;

		public static MailComposer CreateInstance()
		{
			return null;
		}

		public static bool CanSendMail()
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

		public void SetToRecipients(params string[] values)
		{
		}

		public void SetCcRecipients(params string[] values)
		{
		}

		public void SetBccRecipients(params string[] values)
		{
		}

		public void SetSubject(string value)
		{
		}

		public void SetBody(string value, bool isHtml = false)
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

		public void SetCompletionCallback(EventCallback<MailComposerResult> callback)
		{
		}

		public void Show()
		{
		}

		private void HandleComposerCloseInternalCallback(MailComposerResultCode resultCode, Error error)
		{
		}
	}
}
