using System;
using Febucci.TextAnimatorCore.Settings;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Settings/Global Settings", fileName = "Global Settings for Text Animator")]
	public sealed class TextAnimatorSettings : ScriptableObject, ISettingsProvider<GlobalSettingsBase>
	{
		public const string expectedName = "TextAnimatorSettings";

		private static TextAnimatorSettings instance;

		[SerializeField]
		private UnityGlobalSettings settings;

		public static TextAnimatorSettings Instance
		{
			get
			{
				if ((bool)instance)
				{
					return instance;
				}
				LoadSettings();
				return instance;
			}
		}

		public GlobalSettingsBase Settings => settings;

		public static void LoadSettings()
		{
			if (!instance)
			{
				instance = Resources.Load<TextAnimatorSettings>("TextAnimatorSettings");
			}
		}

		public static void UnloadSettings()
		{
			if ((bool)instance)
			{
				Resources.UnloadAsset(instance);
				instance = null;
			}
		}

		public static void SetEffectsActive(bool enabled)
		{
			if ((bool)Instance)
			{
				Instance.settings.isAnimatingBehaviors = enabled;
			}
		}
	}
}
