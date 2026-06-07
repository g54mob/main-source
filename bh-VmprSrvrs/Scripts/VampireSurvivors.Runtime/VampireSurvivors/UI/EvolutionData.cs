using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class EvolutionData
	{
		public WeaponType weapon;

		public List<WeaponType> evolvesFrom;

		public List<WeaponType> requires;

		public List<WeaponType> requiresMax;

		public List<WeaponType> evolutionLine;
	}
}
