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

		[CustomObfuscation]
		public Platform windowsStandalone;

		[CustomObfuscation]
		public Platform windowsStore;

		[CustomObfuscation]
		public Platform osxStandalone;

		[CustomObfuscation]
		public Platform linuxStandalone;

		[CustomObfuscation]
		public Platform webplayer;

		[CustomObfuscation]
		public Platform fallback;

		public TextAsset[] GetLibraries(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			return null;
		}

		public Platform GetPlatform(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			return null;
		}
	}
}
