using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Profiling;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects
{
	[UsedImplicitly]
	public class PlayerOptions : IInitializable, IDisposable
	{
		public delegate void OnValueChanged();

		public delegate void OnInitialized();

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private DataManager _dataManager;

		[Inject]
		private PlayerStats _playerStats;

		[Inject]
		private AdventureManager _adventureManager;

		private PlayerOptionsData _mainGameConfig;

		private PlayerOptionsData _hostGameConfig;

		private PlayerOptionsData _hostGameConfigAtRunStart;

		private PlayerOptionsData _onlineClientWithRunDataConfig;

		public const string USER_OPTIONS = "USER_OPTIONS";

		private static readonly ProfilerMarker MarkerSave;

		private PlayerOptionsData _currentAdventureSaveData;

		private List<DlcType> XanthiaDLCList;

		public DataManager dataManager => null;

		public PlayerOptionsData MainGameConfig => null;

		public bool IsConfigReady => false;

		public PlayerOptionsData ConfigDuringRun => null;

		public PlayerOptionsData Config => null;

		public PlayerStats PlayerStats => null;

		public bool JustGotTrumpet { get; set; }

		public bool JustGotMirror { get; set; }

		public bool JustGotJubilee { get; set; }

		public bool IsInitialized { get; set; }

		public bool IsInvertedWithVisuals => false;

		public PlayerOptionsData CurrentAdventureSaveData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static event OnValueChanged GoldUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnValueChanged RunGoldUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnValueChanged PowerUpPurchased
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnValueChanged PowerUpsRefunded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event OnValueChanged AdventureStarsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnInitialized PlayerOptionsInitialized
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void AutoSelectStage()
		{
		}

		public void ClearSaveData(bool deleteAdventureData = false)
		{
		}

		public void ApplyClientConfigWithRunProgress()
		{
		}

		public void ApplyConfig(PlayerOptionsData config, bool adventureMode = false, bool hostConfig = false, bool onlineClientWithRunData = false)
		{
		}

		private void FixCoinOverflow()
		{
		}

		public void FixPlayerOptionsData()
		{
		}

		private SkinType FixSkinMapping(CharacterType characterType, SkinType id)
		{
			return default(SkinType);
		}

		private void TouchPlatform()
		{
		}

		public void ApplyUnlocksToData()
		{
		}

		public void ApplyLoadedOptions()
		{
		}

		public void AddRunHunger(int amount)
		{
		}

		public void SetShowGuides(bool b)
		{
		}

		public void SetShowPickups(bool b)
		{
		}

		public int GetMaxSeals()
		{
			return 0;
		}

		public int GetUsedSeals()
		{
			return 0;
		}

		public int GetPowerUpMaxRank(PowerUpType type)
		{
			return 0;
		}

		public void AddHeal(float value)
		{
		}

		public void TrackEnemyKill(EnemyType enemyType)
		{
		}

		public void TrackEnemyKill(EnemyType enemyType, PlayerOptionsData config)
		{
		}

		public void TrackItemPickup(ItemType itemType, PlayerOptionsData config, bool trackRunPickup = true)
		{
		}

		public void TrackItemPickup(ItemType itemType, bool trackRunPickup = true)
		{
		}

		public void IncreaseDestroyedPropCount(PropType propType)
		{
		}

		public void ResetDestroyedPropCount(PropType propType)
		{
		}

		public void UnlockArcana(ArcanaType arcanaType, PlayerOptionsData config)
		{
		}

		public void UnlockArcana(ArcanaType arcanaType)
		{
		}

		public void UnlockSkin(CharacterType c, SkinType t, PlayerOptionsData config = null)
		{
		}

		public void ClearRunData()
		{
		}

		public HashSet<AchievementType> GetUnlockedAchievements()
		{
			return null;
		}

		public Dictionary<PowerUpType, PowerUpLevel> GetBoughtPowerUps()
		{
			return null;
		}

		public void Save(bool commitImmediately = true, bool createBackup = false)
		{
		}

		public void BuildHostPlayerConfig(HostPlayerOptions hostPlayerOptions)
		{
		}

		public PlayerOptionsData GetClientPlayerOptionsWithRunDataApplied()
		{
			return null;
		}

		public void RemoveOnlineClientRunDataConfig()
		{
		}

		public void DestroyOnlineConfigs()
		{
		}

		public bool IsBought(CharacterType characterType, bool ignoreSkins, PlayerOptionsData config)
		{
			return false;
		}

		public bool IsBought(CharacterType characterType, bool ignoreSkins = false)
		{
			return false;
		}

		public bool IsUnlocked(CharacterType characterType, PlayerOptionsData config)
		{
			return false;
		}

		public bool IsUnlocked(CharacterType characterType)
		{
			return false;
		}

		public void UnlockCharacter(CharacterType characterType, PlayerOptionsData config)
		{
		}

		public void UnlockCharacter(CharacterType characterType)
		{
		}

		public void RegisterCoffinOpen(CharacterType characterType)
		{
		}

		public void BuyCharacter(CharacterType characterType, PlayerOptionsData config)
		{
		}

		public void BuyCharacter(CharacterType characterType)
		{
		}

		public void BuySkin(SkinType skinType, PlayerOptionsData config)
		{
		}

		public void BuySkin(SkinType skinType)
		{
		}

		public void RevealCharacter(CharacterType characterType, PlayerOptionsData config)
		{
		}

		public void RevealCharacter(CharacterType characterType)
		{
		}

		public void AddGoldenEggToCharacter(CharacterType character, string attribute, float value)
		{
		}

		public SkinType GetSkinTypeForCharacter(CharacterType characterType)
		{
			return default(SkinType);
		}

		public Skin GetSkinForCharacter(CharacterType characterType)
		{
			return null;
		}

		public Skin GetSkinForCharacter(CharacterType characterType, SkinType id)
		{
			return null;
		}

		public bool HasUnlockedSkin(CharacterType characterType, SkinType skinType)
		{
			return false;
		}

		public void ClearEggsOnSigma()
		{
		}

		public List<CharacterType> GetCustomMerchantCharacters()
		{
			return null;
		}

		public void UnlockWeapon(WeaponType weaponType, PlayerOptionsData config)
		{
		}

		public void UnlockWeapon(WeaponType weaponType)
		{
		}

		public void UnlockStage(StageType stageType, PlayerOptionsData config)
		{
		}

		public void UnlockStage(StageType stageType)
		{
		}

		public void UnlockHyper(StageType stageType, PlayerOptionsData config)
		{
		}

		public void UnlockHyper(StageType stageType)
		{
		}

		public void UnlockItem(ItemType itemType, PlayerOptionsData config)
		{
		}

		public void UnlockItem(ItemType itemType)
		{
		}

		public void UnlockPowerUp(PowerUpType powerUpType, PlayerOptionsData config)
		{
		}

		public void UnlockPowerUp(PowerUpType powerUpType)
		{
		}

		public void AddDisabledPowerUp(PowerUpType type)
		{
		}

		public void RemoveDisabledPowerup(PowerUpType type)
		{
		}

		public void RestoreUnlockablePowerups()
		{
		}

		public bool UnlockSecret(SecretType secretType, PlayerOptionsData config)
		{
			return false;
		}

		public bool UnlockSecret(SecretType secretType)
		{
			return false;
		}

		public bool UnlockSecretInBaseGame(SecretType secretType)
		{
			return false;
		}

		public static void AddCoinsFlat(float value, PlayerOptionsData config)
		{
		}

		public void AddCoinsFlat(float value)
		{
		}

		public void AddCoinsNoRun(float value, CharacterController player = null)
		{
		}

		public float RemoveCoinsFlat(float value)
		{
			return 0f;
		}

		public float AddCoins(float value, CharacterController player = null)
		{
			return 0f;
		}

		public void RemoveCoins(int value, bool removeFromLifetime, PlayerOptionsData config)
		{
		}

		public void RemoveCoins(int value, bool removeFromLifetime = false)
		{
		}

		public void RemoveCoins(float value, bool removeFromLifetime = false)
		{
		}

		public void AwardAdventureStar()
		{
		}

		private void InitSession()
		{
		}

		private void UnlockCharacter(UISignals.CharacterUnlockedSignal sig)
		{
		}

		private void BuyCharacter(UISignals.CharacterBoughtSignal sig)
		{
		}

		private void BuySkin(UISignals.SkinBoughtSignal sig)
		{
		}

		private void UnlockStage(UISignals.StageUnlockedSignal sig)
		{
		}

		private void UnlockWeapon(UISignals.WeaponUnlockedSignal sig)
		{
		}

		private void LanguageSelected(UISignals.LanguageSelectedSignal sig)
		{
		}

		private void FullScreenChanged(UISignals.SetFullscreenSignal sig)
		{
		}

		private void BuyPowerUp(UISignals.BuyPowerUpSignal sig)
		{
		}

		private void OnCharacterSelectionUpdated(UISignals.ConfirmCharacterSignal signal)
		{
		}

		private void OnStageSelectionChanged(UISignals.ConfirmStageSelectionSignal signal)
		{
		}

		private void ApplySoundsVolume(UISignals.SetSFXVolumeSignal sig)
		{
		}

		private void ApplyMusicVolume(UISignals.SetMusicVolumeSignal sig)
		{
		}

		private void ApplyDamageNumbers(UISignals.SetDamageNumbersSignal sig)
		{
		}

		private void ApplyGlimmerCarousel(UISignals.SetGlimmerCarouselSignal sig)
		{
		}

		private void ApplyVisibleJoysticks(UISignals.SetVisibleJoysticksSignal sig)
		{
		}

		private void RefundPowerups(UISignals.RefundPowerUpsSignal sig)
		{
		}

		private void ApplyFlashingVFX(UISignals.SetFlashingVFXSignal sig)
		{
		}

		private void ApplyHideStageProgression(UISignals.ToggleStageProgressionSignal sig)
		{
		}

		private void ToggleMovingBackground(UISignals.ToggleMovingBackgroundSignal sig)
		{
		}

		private void ApplyHideXpBar(UISignals.ToggleXPBarSignal sig)
		{
		}

		private void ApplyStreamerSafeMusic(UISignals.SetStreamerSafeMusicSignal signal)
		{
		}

		private void ApplyPixelFontDefault()
		{
		}
	}
}
