using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public abstract class NativeSocialShareComposerBase : NativeObjectBase, INativeSocialShareComposer, INativeObject, IDisposable
	{
		public event SocialShareComposerClosedInternalCallback OnClose
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

		public abstract void SetText(string value);

		public abstract void AddScreenshot();

		public abstract void AddImage(byte[] imageData);

		public abstract void AddURL(URLString url);

		public abstract void Show(Vector2 screenPosition);

		protected void SendCloseEvent(SocialShareComposerResultCode resultCode, Error error)
		{
		}
	}
}
