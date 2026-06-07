using System;
using Rewired.Platforms;
using UnityEngine;

namespace Rewired.Data
{
	public class EditorPlatformData : ScriptableObject
	{
		[Serializable]
		public class Platform
		{
			public TextAsset[] libraries;
		}

		[CustomObfuscation(rename = false)]
		public Platform windowsStandalone;

		[CustomObfuscation(rename = false)]
		public Platform windowsStore;

		[CustomObfuscation(rename = false)]
		public Platform osxStandalone;

		[CustomObfuscation(rename = false)]
		public Platform linuxStandalone;

		[CustomObfuscation(rename = false)]
		public Platform webplayer;

		[CustomObfuscation(rename = false)]
		public Platform fallback;

		public TextAsset[] GetLibraries(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			return GetPlatform(platform, webplayerPlatform, editorPlatform).libraries;
		}

		public Platform GetPlatform(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			if (webplayerPlatform != WebplayerPlatform.None)
			{
				return webplayer;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
				return windowsStandalone;
			case Rewired.Platforms.Platform.OSX:
				return osxStandalone;
			case Rewired.Platforms.Platform.Linux:
				return linuxStandalone;
			case Rewired.Platforms.Platform.WindowsAppStore:
				return windowsStore;
			default:
				return fallback;
			}
		}
	}
}
