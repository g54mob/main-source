using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public interface INativeMailComposer : INativeObject, IDisposable
	{
		event MailComposerClosedInternalCallback OnClose;

		void SetToRecipients(params string[] values);

		void SetCcRecipients(params string[] values);

		void SetBccRecipients(params string[] values);

		void SetSubject(string value);

		void SetBody(string value, bool isHtml);

		void AddScreenshot(string fileName);

		void AddAttachmentData(byte[] data, string mimeType, string fileName);

		void Show();
	}
}
