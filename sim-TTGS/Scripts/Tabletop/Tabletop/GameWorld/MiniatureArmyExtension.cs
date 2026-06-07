using System;

namespace Tabletop.GameWorld
{
	public static class MiniatureArmyExtension
	{
		public static EMiniatureArmy ParseString(string s)
		{
			if (s.Contains("undead", StringComparison.OrdinalIgnoreCase))
			{
				return EMiniatureArmy.UNDEAD;
			}
			if (s.Contains("guardians", StringComparison.OrdinalIgnoreCase))
			{
				return EMiniatureArmy.HUMAN;
			}
			if (s.Contains("demons", StringComparison.OrdinalIgnoreCase))
			{
				return EMiniatureArmy.DEMON;
			}
			return EMiniatureArmy.NONE;
		}
	}
}
