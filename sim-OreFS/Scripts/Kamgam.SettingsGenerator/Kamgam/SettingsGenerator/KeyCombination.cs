using System;
using Kamgam.UGUIComponentsForSettings;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public struct KeyCombination
	{
		public UniversalKeyCode Key;

		public UniversalKeyCode ModifierKey;

		public KeyCombination(UniversalKeyCode key)
		{
			Key = key;
			ModifierKey = UniversalKeyCode.None;
		}

		public KeyCombination(UniversalKeyCode key, UniversalKeyCode modifierKey)
		{
			Key = key;
			ModifierKey = modifierKey;
		}

		public bool Equals(KeyCombination combination)
		{
			if (Key == combination.Key)
			{
				return ModifierKey == combination.ModifierKey;
			}
			return false;
		}

		public override string ToString()
		{
			return $"KeyCombination: (mod: {ModifierKey}, key: {Key})";
		}
	}
}
