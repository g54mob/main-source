using System;

namespace Motorways.Themes
{
	public static class ThemedMaterialTypeExtensions
	{
		private static readonly string[] EnumNames = Enum.GetNames(typeof(ThemedMaterialType));

		public static bool TryParse(this string parseString, out ThemedMaterialType result)
		{
			for (int i = 0; i < EnumNames.Length; i++)
			{
				if (EnumNames[i] == parseString)
				{
					result = (ThemedMaterialType)i;
					return true;
				}
			}
			result = ThemedMaterialType.Light;
			return false;
		}
	}
}
