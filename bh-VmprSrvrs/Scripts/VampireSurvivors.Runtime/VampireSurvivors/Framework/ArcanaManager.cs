using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class ArcanaManager : GameTickable, IInitializable, IDisposable
	{
		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private WeaponsFacade _weaponsFacade;

		[Inject]
		private DataManager _dataManager;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private GameManager _gameManager;

		[Inject]
		private LootManager _lootManager;

		private SarabandeWeapon _sarabandeWeapon;

		private FireExplosionWeapon _fireExplosionWeapon;

		private ColdExplosionWeapon _coldExplosionWeapon;

		private GemCannonWeapon _gemCannonWeapon;

		private DivineBloodlineWeapon _divineBloodlineWeapon;

		private WickedSeason _wickedSeason;

		private BloodAstronomiaWeapon _bloodAstronomiaWeapon;

		private JetBlackWeapon _jetBlackWeapon;

		private MadMoonWeapon _madMoonWeapon;

		private bool _hasWickedSeason;

		private bool _hasSilentSanctuary;

		private bool _hasAstronomia;

		private bool _hasSapphireMist;

		private bool _hasBreadAnathema;

		private bool _hasMoonlightBolero;

		private bool _hasHailFromTheFuture;

		private bool _hasJetBlackWeapon;

		private bool _hasCrystalCries;

		private bool _hasMadMoon;

		private bool _hasVictorianHorror;

		private float _heartOfFireStartingPower;

		private readonly Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<WeaponType>> _beginning;

		public static float CritMul;

		public static float ThornsValue;

		private List<Destructible> m_newDestructibles;

		private ArcanaManager_VFX arcanaManager_VFX;

		private ArcanaManager_Support arcanaManager_Support;

		public SarabandeWeapon SarabandeWeapon => null;

		public float SilentCooldown { get; private set; }

		public float SilentMight { get; private set; }

		public ArcanaManager_Support ArcaneManagerSupport => null;

		public List<ArcanaType> ActiveArcanas { get; private set; }

		private bool HealOnCoins { get; set; }

		public bool CoinFever { get; private set; }

		public bool MadGroove { get; private set; }

		private bool CanGather { get; set; }

		public List<WeaponType> HeartOfFireWeapons { get; private set; }

		public FireExplosionWeapon FireExplosionWeapon => null;

		private VampireSurvivors.Objects.Characters.CharacterController ActivePlayer => null;

		public WickedSeason WickedSeason => null;

		public float XpMultiplier { get; set; }

		public float DivineBloodlineHpBonusUnit { get; set; }

		public bool HasDivineBloodline { get; set; }

		public bool HasAstronomia => false;

		public bool HasMoonlightBolero => false;

		public bool HasHailFromTheFuture => false;

		public bool HasSapphireMist => false;

		public bool HasCrystalCries => false;

		public bool HasBreadAnathema => false;

		public bool HasMadMoon => false;

		public bool HasVictorianHorror => false;

		public int MinTreasureChestLevel { get; set; }

		public bool PewPew { get; set; }

		public int MaxArcanasPerRun { get; set; }

		public List<WeaponType> Beginning(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			return null;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		protected override void OnTick()
		{
		}

		public void OnGameManagerInitialization()
		{
		}

		public void InitializeVFX()
		{
		}

		public void InitializeSupportObjects()
		{
		}

		public void TriggerArcana(ArcanaType arcanaType)
		{
		}

		public void CheckSilent()
		{
		}

		public void TriggerAwake(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void TriggerSarabande(float damage, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void TriggerFireExplosion(Vector2 pos)
		{
		}

		public void TriggerColdExplosion(Vector2 pos)
		{
		}

		public void TriggerGemCannon(float damage, string frameName, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void TriggerAstronomia(Weapon weapon)
		{
		}

		public bool HasRandomazzoEnabled()
		{
			return false;
		}

		public bool HasSurvarotsEnabled()
		{
			return false;
		}

		public void OnWeaponFired(Weapon weapon)
		{
		}

		public void OnFoodPickedUp(VampireSurvivors.Objects.Characters.CharacterController character, ItemType itemType, float value)
		{
		}

		public void OnPlayerLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void OnPlayerHPRecovery(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
		{
		}

		public void OnPlayerHPDamage(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
		{
		}

		public void OnPlayerLastBreath(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
		{
		}

		public void OnPlayerCriticalHPTreshold(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
		{
		}

		public void OnPlayerHPRecovery(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue, float actualRecovery)
		{
		}

		public void AddHeartOfFireWeapon(Weapon weapon, float newWeaponPower)
		{
		}

		public void UpdateHeartOfFirePower(float newWeaponPower)
		{
		}

		private void ActivateSpeedSineBonus()
		{
		}

		private void ActivateDurationSineBonus()
		{
		}

		private void ActivateAreaSineBonus()
		{
		}

		private void ActivateHeartOfFireRetaliation()
		{
		}

		private void CheckOnAllWeapons()
		{
		}

		private void PickedUpCoin(GameplaySignals.OnAfterCoinsAddedSignal signal)
		{
		}

		private void ActivateLevelUpBonus(string property, float value)
		{
		}

		public void IncreaseBloodlineBonus(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void Cleanup()
		{
		}

		private void GatherAllStageItems()
		{
		}

		private List<Pickup> GetSubset(List<Pickup> items, int playerIndex, int playerCount)
		{
			return null;
		}

		private void GatherStageItemsForPosition(float2 playerPos, List<Pickup> items, List<Pickup> others, List<Pickup> coins, List<Pickup> gems, float destructiblesProportion)
		{
		}

		private void GatherAllDestructibles(float2 playerPos, float radius4, float proportionOfMax)
		{
		}
	}
}
