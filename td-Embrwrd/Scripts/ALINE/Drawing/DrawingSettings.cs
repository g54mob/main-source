using System;
using UnityEngine;

namespace Drawing
{
	public class DrawingSettings : ScriptableObject
	{
		[Serializable]
		public class Settings
		{
			public float lineOpacity;

			public float solidOpacity;

			public float textOpacity;

			public float lineOpacityBehindObjects;

			public float solidOpacityBehindObjects;

			public float textOpacityBehindObjects;

			public float curveResolution;
		}

		public const string SettingsPathCompatibility = "Assets/Settings/ALINE.asset";

		public const string SettingsName = "ALINE";

		public const string SettingsPath = "Assets/Settings/Resources/ALINE.asset";

		[SerializeField]
		private int version;

		public Settings settings;

		public static Settings DefaultSettings => null;

		public static DrawingSettings GetSettingsAsset()
		{
			return null;
		}
	}
}
