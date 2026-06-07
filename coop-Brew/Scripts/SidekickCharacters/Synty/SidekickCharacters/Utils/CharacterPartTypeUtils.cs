using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Utils
{
	public static class CharacterPartTypeUtils
	{
		public static PartGroup GetPartGroup(this CharacterPartType basePartType)
		{
			return default(PartGroup);
		}

		public static bool IsSpeciesSpecificPartType(this CharacterPartType partType)
		{
			return false;
		}

		public static string GetTypeNameFromShortcode(string shortCode)
		{
			return null;
		}

		public static string GetPartTypeString(CharacterPartType type)
		{
			return null;
		}

		public static string GetTooltipForPartType(this CharacterPartType partType)
		{
			return null;
		}
	}
}
