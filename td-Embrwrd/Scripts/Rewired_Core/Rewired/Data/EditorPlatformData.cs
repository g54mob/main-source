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
			return null;
		}

		public Platform GetPlatform(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			return null;
		}
	}
}
