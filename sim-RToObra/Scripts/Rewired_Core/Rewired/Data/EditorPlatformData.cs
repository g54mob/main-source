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
				goto IL_0003;
			}
			Rewired.Platforms.Platform platform2 = platform;
			int num = -991256355;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -991256359)
				{
				case 0:
					break;
				case 2:
					return webplayer;
				case 4:
					switch (platform2)
					{
					case Rewired.Platforms.Platform.Windows:
						goto IL_0069;
					case Rewired.Platforms.Platform.OSX:
						return osxStandalone;
					case Rewired.Platforms.Platform.Linux:
						return linuxStandalone;
					case Rewired.Platforms.Platform.WindowsAppStore:
						return windowsStore;
					case Rewired.Platforms.Platform.WindowsPhone8:
					case Rewired.Platforms.Platform.iOS:
						goto IL_0085;
					}
					goto IL_0062;
				default:
					goto IL_0069;
				case 1:
					goto IL_0085;
					IL_0085:
					return fallback;
					IL_0069:
					return windowsStandalone;
				}
				break;
				IL_0062:
				num = -991256360;
			}
			goto IL_0003;
			IL_0003:
			num = -991256357;
			goto IL_0008;
		}
	}
}
