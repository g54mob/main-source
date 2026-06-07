using System;

namespace Tabletop.GameWorld
{
	public static class ProductTypeExtension
	{
		public static EProductType ParseString(string s)
		{
			if (s.Contains("figbox", StringComparison.OrdinalIgnoreCase))
			{
				return EProductType.MINIATURE_BOX;
			}
			if (s.Contains("game", StringComparison.OrdinalIgnoreCase))
			{
				return EProductType.GAME;
			}
			if (s.Contains("merch", StringComparison.OrdinalIgnoreCase))
			{
				return EProductType.MERCH;
			}
			if (s.Contains("tool", StringComparison.OrdinalIgnoreCase))
			{
				return EProductType.TOOL;
			}
			return EProductType.MINIATURE;
		}
	}
}
