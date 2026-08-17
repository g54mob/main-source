using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI;

public class EvolutionData
{
	public WeaponType weapon;

	public List<WeaponType> evolvesFrom;

	public List<WeaponType> requires;

	public List<WeaponType> requiresMax;

	public List<WeaponType> evolutionLine;

	public EvolutionData()
	{
		List<WeaponType> list = new List<WeaponType>();
		evolvesFrom = list;
		List<WeaponType> list2 = new List<WeaponType>();
		requires = list2;
		List<WeaponType> list3 = new List<WeaponType>();
		requiresMax = list3;
	}
}
