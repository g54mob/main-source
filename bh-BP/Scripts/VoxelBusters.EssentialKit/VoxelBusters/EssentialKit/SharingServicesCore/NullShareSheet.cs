using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public sealed class NullShareSheet : NativeShareSheetBase, INativeShareSheet, INativeObject, IDisposable
	{
		private static void LogNotSupported()
		{
		}

		public override void AddText(string text)
		{
		}

		public override void AddScreenshot()
		{
		}

		public override void AddImage(byte[] imageData, string mimeType)
		{
		}

		public override void AddURL(URLString url)
		{
		}

		public override void AddAttachment(byte[] data, string mimeType, string filename)
		{
		}

		public override void Show(Vector2 screenPosition)
		{
		}
	}
}
