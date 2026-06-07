using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public abstract class NativeShareSheetBase : NativeObjectBase, INativeShareSheet, INativeObject, IDisposable
	{
		public event ShareSheetClosedInternalCallback OnClose
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

		public abstract void AddText(string text);

		public abstract void AddScreenshot();

		public abstract void AddImage(byte[] imageData, string mimeType);

		public abstract void AddAttachment(byte[] data, string mimeType, string filename);

		public abstract void AddURL(URLString url);

		public abstract void Show(Vector2 screenPosition);

		protected void SendCloseEvent(ShareSheetResultCode resultCode, Error error)
		{
		}
	}
}
