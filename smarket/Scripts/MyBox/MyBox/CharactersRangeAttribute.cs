using UnityEngine;

namespace MyBox
{
	public class CharactersRangeAttribute : PropertyAttribute
	{
		public readonly string Characters;

		public readonly CharacterRangeMode Mode;

		public readonly bool IgnoreCase;

		public CharactersRangeAttribute(string characters, CharacterRangeMode mode = CharacterRangeMode.Allow, bool ignoreCase = true)
		{
		}
	}
}
