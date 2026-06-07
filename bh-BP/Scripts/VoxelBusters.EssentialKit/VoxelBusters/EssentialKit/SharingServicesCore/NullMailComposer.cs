using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public sealed class NullMailComposer : NativeMailComposerBase, INativeMailComposer, INativeObject, IDisposable
	{
		private static void LogNotSupported()
		{
		}

		public override void SetToRecipients(params string[] values)
		{
		}

		public override void SetCcRecipients(params string[] values)
		{
		}

		public override void SetBccRecipients(params string[] values)
		{
		}

		public override void SetSubject(string value)
		{
		}

		public override void SetBody(string value, bool isHtml)
		{
		}

		public override void AddScreenshot(string fileName)
		{
		}

		public override void AddAttachmentData(byte[] data, string mimeType, string fileName)
		{
		}

		public override void Show()
		{
		}
	}
}
