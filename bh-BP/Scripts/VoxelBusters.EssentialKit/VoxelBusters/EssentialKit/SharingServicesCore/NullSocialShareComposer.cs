using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public sealed class NullSocialShareComposer : NativeSocialShareComposerBase, INativeSocialShareComposer, INativeObject, IDisposable
	{
		public NullSocialShareComposer(SocialShareComposerType composerType)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override void SetText(string value)
		{
		}

		public override void AddScreenshot()
		{
		}

		public override void AddImage(byte[] imageData)
		{
		}

		public override void AddURL(URLString url)
		{
		}

		public override void Show(Vector2 screenPosition)
		{
		}
	}
}
