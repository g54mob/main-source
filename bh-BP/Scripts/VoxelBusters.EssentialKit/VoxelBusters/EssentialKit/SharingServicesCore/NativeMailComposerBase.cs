using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public abstract class NativeMailComposerBase : NativeObjectBase, INativeMailComposer, INativeObject, IDisposable
	{
		public event MailComposerClosedInternalCallback OnClose
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void SetToRecipients(params string[] values);

		public abstract void SetCcRecipients(params string[] values);

		public abstract void SetBccRecipients(params string[] values);

		public abstract void SetSubject(string value);

		public abstract void SetBody(string value, bool isHtml);

		public abstract void AddScreenshot(string fileName);

		public abstract void AddAttachmentData(byte[] data, string mimeType, string fileName);

		public abstract void Show();

		protected void SendCloseEvent(MailComposerResultCode resultCode, Error error)
		{
		}
	}
}
