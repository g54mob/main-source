using System;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public interface INativeMessageComposer : INativeObject, IDisposable
	{
		event MessageComposerClosedInternalCallback OnClose;

		void SetRecipients(params string[] values);

		void SetSubject(string value);

		void SetBody(string value);

		void AddScreenshot(string fileName);

		void AddImage(Texture2D image, string fileName);

		void AddAttachmentData(byte[] data, string mimeType, string fileName);

		void Show();
	}
}
