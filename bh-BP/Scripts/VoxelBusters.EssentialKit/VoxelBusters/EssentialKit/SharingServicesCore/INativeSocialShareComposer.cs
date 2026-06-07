using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public interface INativeSocialShareComposer : INativeObject, IDisposable
	{
		event SocialShareComposerClosedInternalCallback OnClose;

		void SetText(string value);

		void AddScreenshot();

		void AddImage(byte[] imageData);

		void AddURL(URLString url);

		void Show(Vector2 screenPosition);
	}
}
