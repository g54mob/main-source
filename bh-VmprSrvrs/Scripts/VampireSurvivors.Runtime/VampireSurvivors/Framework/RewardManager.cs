using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class RewardManager
	{
		[Inject]
		private DataManager _data;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private GameSessionData _session;

		[Inject]
		private SignalBus _signalBus;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private readonly List<WeaponType> _ownedWeapons;

		private readonly List<WeaponType> _ownedAccessories;

		private readonly List<WeaponType> _availableWeapons;

		private readonly List<WeaponType> _availableAccessories;

		public List<Reward> GetLevelUpRewards(int amount)
		{
			return null;
		}
	}
}
