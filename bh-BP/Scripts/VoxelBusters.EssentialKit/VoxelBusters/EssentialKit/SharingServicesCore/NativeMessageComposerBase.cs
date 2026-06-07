using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public abstract class NativeMessageComposerBase : NativeObjectBase, INativeMessageComposer, INativeObject, IDisposable
	{
		public event MessageComposerClosedInternalCallback OnClose
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

		public abstract void SetRecipients(params string[] values);

		public abstract void SetSubject(string value);

		public abstract void SetBody(string value);

		public abstract void AddScreenshot(string fileName);

		public abstract void AddImage(Texture2D image, string fileName);

		public abstract void AddAttachmentData(byte[] data, string mimeType, string fileName);

		public abstract void Show();

		protected void SendCloseEvent(MessageComposerResultCode resultCode, Error error)
		{
		}
	}
}
