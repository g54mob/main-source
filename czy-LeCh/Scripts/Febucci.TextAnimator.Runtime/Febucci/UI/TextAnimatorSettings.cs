using System;
using Febucci.UI.Actions;
using Febucci.UI.Effects;
using UnityEngine;

namespace Febucci.UI
{
	[Serializable]
	[CreateAssetMenu(fileName = "Text Animator Settings", menuName = "Text Animator/Settings", order = 100)]
	public sealed class TextAnimatorSettings : ScriptableObject
	{
		[Serializable]
		public struct Category<T> where T : ScriptableObject
		{
			public T defaultDatabase;

			public bool enabled;

			public char openingSymbol;

			public char closingSymbol;

			public Category(char openingSymbol, char closingSymbol)
			{
				defaultDatabase = null;
				enabled = true;
				this.openingSymbol = openingSymbol;
				this.closingSymbol = closingSymbol;
			}
		}

		public const string expectedName = "TextAnimatorSettings";

		private static TextAnimatorSettings instance;

		[Header("Default info")]
		public Category<AnimationsDatabase> behaviors = new Category<AnimationsDatabase>('<', '>');

		public Category<AnimationsDatabase> appearances = new Category<AnimationsDatabase>('{', '}');

		public Category<ActionDatabase> actions = new Category<ActionDatabase>('<', '>');

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

		public static void SetAllEffectsActive(bool enabled)
		{
			SetAppearancesActive(enabled);
			SetBehaviorsActive(enabled);
		}

		public static void SetAppearancesActive(bool enabled)
		{
			if ((bool)Instance)
			{
				Instance.appearances.enabled = enabled;
			}
		}

		public static void SetBehaviorsActive(bool enabled)
		{
			if ((bool)Instance)
			{
				Instance.behaviors.enabled = enabled;
			}
		}
	}
}
