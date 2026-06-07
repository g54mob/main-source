using System;
using UnityEngine;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class UIAnimations : ScriptableObject
	{
		private const string FILE_NAME = "_UIAnimations";

		public const string DEFAULT_DATABASE_NAME = "Uncategorized";

		public const string DEFAULT_PRESET_NAME = "Default";

		private static UIAnimations s_instance;

		public UIAnimationsDatabase Show;

		public UIAnimationsDatabase Hide;

		public UIAnimationsDatabase Loop;

		public UIAnimationsDatabase Punch;

		public UIAnimationsDatabase State;

		public static UIAnimations Instance => null;

		public UIAnimationDatabase CreateDatabase(AnimationType databaseType, string newPresetCategory, bool saveAssets = false)
		{
			return null;
		}

		public UIAnimationsDatabase Get(AnimationType databaseType)
		{
			return null;
		}

		public UIAnimationData Get(AnimationType databaseType, string databaseName, string animationName)
		{
			return null;
		}

		public UIAnimationDatabase Get(AnimationType databaseType, string databaseName)
		{
			return null;
		}

		public void Initialize()
		{
		}

		public void SearchForUnregisteredDatabases(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public static UIAnimation LoadPreset(AnimationType animationType, string presetCategory, string presetName)
		{
			return null;
		}
	}
}
