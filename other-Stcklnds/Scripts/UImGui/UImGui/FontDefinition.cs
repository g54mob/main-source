using System;
using UnityEngine;

namespace UImGui
{
	[Serializable]
	internal struct FontDefinition
	{
		[SerializeField]
		private UnityEngine.Object _fontAsset;

		[Tooltip("Path relative to Application.streamingAssetsPath.")]
		public string Path;

		public FontConfig Config;
	}
}
