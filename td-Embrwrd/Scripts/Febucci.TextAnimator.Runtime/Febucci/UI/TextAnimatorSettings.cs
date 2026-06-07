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
				enabled = false;
				this.openingSymbol = '\0';
				this.closingSymbol = '\0';
			}
		}

		public const string expectedName = "TextAnimatorSettings";

		private static TextAnimatorSettings instance;

		[Header("Default info")]
		public Category<AnimationsDatabase> behaviors;

		public Category<AnimationsDatabase> appearances;

		public Category<ActionDatabase> actions;

		public static TextAnimatorSettings Instance => null;

		public static void LoadSettings()
		{
		}

		public static void UnloadSettings()
		{
		}

		public static void SetAllEffectsActive(bool enabled)
		{
		}

		public static void SetAppearancesActive(bool enabled)
		{
		}

		public static void SetBehaviorsActive(bool enabled)
		{
		}
	}
}
