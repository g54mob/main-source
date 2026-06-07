using System.Collections.Generic;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class LimitBreakManager
	{
		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private DataManager _dataManager;

		private List<WeaponType> _excludedWeapons;

		private const int LevelUpOptions = 3;

		private const string PropNameMax = "max";

		private const string PropNameRarity = "rarity";

		public List<WeightedLimitBreak> GetLimitBreakBonuses()
		{
			return null;
		}

		public WeightedLimitBreak GetRandomWeightedWeapon()
		{
			return null;
		}

		public bool HasLimitBreaks()
		{
			return false;
		}

		private int GetLevelUpOptions()
		{
			return 0;
		}
	}
}
