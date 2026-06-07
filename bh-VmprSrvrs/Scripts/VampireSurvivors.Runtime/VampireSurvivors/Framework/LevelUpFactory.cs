using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class LevelUpFactory : IInitializable, IDisposable
	{
		private float _defaultXPFactor;

		private float _currentXpFactor;

		private float _previousXpFactor;

		private float _chanceForExistingPowerUp;

		private int _levelUpOptions;

		private int _accumulatedWeight;

		private bool _useDebugLog;

		private static LinkedList<WeaponType> _weaponStore;

		private static LinkedList<WeaponType> _excludedWeapons;

		private static LinkedList<WeaponType> _specialWeapons;

		private static LinkedList<WeaponType> _banishedWeapons;

		private static List<WeightedWeapon> _weightedStore;

		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private DataManager _data;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private CoopConfig _coopConfig;

		private List<WeaponType> _unlockedWeapons;

		private List<CharacterController> _cachedPlayerList;

		private List<bool> _coopAmuletBag;

		public float XpRequiredToLevelUp => 0f;

		public float PreviousXpRequiredToLevelUp => 0f;

		public List<WeightedWeapon> WeightedStore => null;

		public LinkedList<WeaponType> WeaponStore => null;

		public LinkedList<WeaponType> ExcludedWeapons => null;

		public LinkedList<WeaponType> BanishedWeapons => null;

		public LinkedList<WeaponType> SpecialWeapons => null;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Init()
		{
		}

		public void CalculateXpFactor()
		{
		}

		public void ForceExclude(WeaponType t)
		{
		}

		public void Banish(WeaponType t)
		{
		}

		public bool IsBanished(WeaponType t)
		{
			return false;
		}

		public bool IsBlockedDueToCoop(WeaponType t, CharacterController character)
		{
			return false;
		}

		public LinkedList<WeaponType> GetBanishedWeapons()
		{
			return null;
		}

		public Dictionary<WeaponType, List<WeaponData>> GetWeapons()
		{
			return null;
		}

		public List<WeaponType> GetExistingNotMaxedWeapons(CharacterController character)
		{
			return null;
		}

		public void AddLateWeapon(WeaponType weapon, CharacterController character)
		{
		}

		public List<WeaponType> RerollLevelUpPowerUps(List<WeaponType> excludedWeapons, CharacterController character)
		{
			return null;
		}

		private void CalculateWeightsWithExclusions(List<WeaponType> exclusions, CharacterController character)
		{
		}

		public WeaponType GetSpecialWeapon(WeaponType weapon)
		{
			return default(WeaponType);
		}

		public bool HasPowerupsInStore(CharacterController character)
		{
			return false;
		}

		public void ValidatePurchasedPassiveFromMerchant(WeaponType weaponType)
		{
		}

		public WeaponType PullRemainingPowerUp(CharacterController character)
		{
			return default(WeaponType);
		}

		public WeaponType PullRemainingExistingWeapon(CharacterController character, bool includePowerUps = true)
		{
			return default(WeaponType);
		}

		public WeaponType PullNewWeapon(CharacterController character, bool includePowerUps = true)
		{
			return default(WeaponType);
		}

		public WeaponType PullExisting(WeaponType weapontype)
		{
			return default(WeaponType);
		}

		private List<Equipment> GetAvailableEquipmentForEvolution(CharacterController character)
		{
			return null;
		}

		public bool HasPotentialEvolution(CharacterController character)
		{
			return false;
		}

		public WeaponType PullEvolution(CharacterController character)
		{
			return default(WeaponType);
		}

		private bool HasEvolutionRequirements(WeaponData data, List<Equipment> held, CharacterController characterController)
		{
			return false;
		}

		public static bool CheckUniqueRequirements(WeaponData data, List<Equipment> held, CharacterController characterController)
		{
			return false;
		}

		private static bool AlucardShieldUniqueRequirements(List<Equipment> held)
		{
			return false;
		}

		private static bool CalamityRingUniqueRequirements(List<Equipment> held)
		{
			return false;
		}

		private static bool SaboteurWeaponsUniqueRequirements(WeaponType currentWeaponType, List<Equipment> held, CharacterController characterController)
		{
			return false;
		}

		public void InitialiseWeights()
		{
		}

		public void CalculateWeights(CharacterController character)
		{
		}

		public List<WeaponType> GetLevelUpPowerups(CharacterController character)
		{
			return null;
		}

		public List<ItemType> GetLevelUpItems()
		{
			return null;
		}

		private bool HasEnoughCoinBag2Pickups(PlayerOptionsData config)
		{
			return false;
		}

		public void RemoveFromStore(WeaponType weapon, CharacterController character)
		{
		}

		public void RemoveFromSpecialWeapons(WeaponType weapon)
		{
		}

		public WeaponType GetRandomExistingWeapon(CharacterController character)
		{
			return default(WeaponType);
		}

		public bool DoesWeaponStoreContainWeaponType(WeaponType weaponType)
		{
			return false;
		}

		public void RemoveFromExcluded(GameplaySignals.RemoveWeaponFromExcluded signal)
		{
		}

		public void RemoveFromExcluded(WeaponType type)
		{
		}

		public void BanishedSealedWeapons()
		{
		}

		public List<WeaponType> GetRemainingPowerupsAndWeapons()
		{
			return null;
		}

		public List<CharacterController> FindFriendshipAmuletTargets(bool checkAmuletBag)
		{
			return null;
		}

		private void InitializeWeaponStores()
		{
		}

		private void ApplyUnlocks()
		{
		}

		private void ProcessBaseWeaponData()
		{
		}

		public void ExcludeNonOwnedLockedWeapons(List<CharacterController> allPlayers)
		{
		}

		private static WeaponType TryParseType(string type)
		{
			return default(WeaponType);
		}

		private List<WeaponType> GetRemainingNotMaxedWeapons()
		{
			return null;
		}

		private static WeaponType GetWeaponFromWeightedStore(List<WeightedWeapon> store, double value)
		{
			return default(WeaponType);
		}

		private WeaponType GetRandomWeightedWeaponOrPowerUp()
		{
			return default(WeaponType);
		}

		private WeaponType GetRandomWeightedWeapon(CharacterController character)
		{
			return default(WeaponType);
		}

		private int GetLevelUpOptions()
		{
			return 0;
		}

		private float ChanceForExistingPowerUp()
		{
			return 0f;
		}

		private void InitAmuletBag()
		{
		}
	}
}
