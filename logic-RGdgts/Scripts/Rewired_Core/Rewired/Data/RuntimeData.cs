using System.Collections.Generic;
using Rewired.Platforms;
using UnityEngine;

namespace Rewired.Data
{
	public class RuntimeData : ScriptableObject
	{
		[CustomObfuscation]
		public Platform platform;

		[CustomObfuscation]
		public WebplayerPlatform webplayerPlatform;

		[CustomObfuscation]
		public EditorPlatform editorPlatform;

		[CustomObfuscation]
		public List<TextAsset> libraries;

		public void SetPlatform(Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform, List<TextAsset> libraries)
		{
		}
	}
}
