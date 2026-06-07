using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public sealed class NullMessageComposer : NativeMessageComposerBase, INativeMessageComposer, INativeObject, IDisposable
	{
		private static void LogNotSupported()
		{
		}

		public override void SetRecipients(params string[] values)
		{
		}

		public override void SetSubject(string value)
		{
		}

		public override void SetBody(string value)
		{
		}

		public override void AddScreenshot(string fileName)
		{
		}

		public override void AddImage(Texture2D image, string fileName)
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
