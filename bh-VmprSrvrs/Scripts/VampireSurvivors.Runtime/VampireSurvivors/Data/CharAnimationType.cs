using System;

namespace VampireSurvivors.Data
{
	[Serializable]
	public enum CharAnimationType
	{
		none = 0,
		walk = 10,
		idle = 20,
		melee = 30,
		melee2 = 40,
		ranged = 50,
		magic = 60,
		special = 70
	}
}
