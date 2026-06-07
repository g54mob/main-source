using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public interface INativeShareSheet : INativeObject, IDisposable
	{
		event ShareSheetClosedInternalCallback OnClose;

		void AddText(string text);

		void AddScreenshot();

		void AddImage(byte[] imageData, string mimeType);

		void AddAttachment(byte[] data, string mimeType, string filename);

		void AddURL(URLString url);

		void Show(Vector2 screenPosition);
	}
}
