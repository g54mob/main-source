using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors.Signals;

public static class UISignals
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnEnteredUISignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct LandingScreenCompletedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct IntroAnimCompletedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowOptionsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowAchievementsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowCollectionsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowCreditsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenGameWeaponSelectionSignal
	{
	}

	public struct OpenTPWeaponSelectionSignal
	{
		public VampireSurvivors.Objects.Characters.CharacterController Character;

		public TPWeaponGroup WeaponGroup;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowDLCStoreSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenHealerSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseHealerSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenArcanaSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenSurvarotsSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseArcanaSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowPowerUpsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowTPCreditsSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseTPCreditsSignal
	{
	}

	public struct AddNewCharactersToSelectionPageSignal
	{
		public List<CharacterType> CharactersToAdd;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SpawnMinorDoilieSignal
	{
	}

	public struct SetCharacterSelectionPageVisibility
	{
		public bool Visible;
	}

	public struct SetMainMenuPageVisibility
	{
		public bool Visible;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct StartTPUnlockSequenceSignal
	{
	}

	public struct ForceSelectionOnCharacterSelectionPageSignal
	{
		public CharacterType CharacterToselect;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowSecretsScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct LaunchGameplaySignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowCharacterSelectScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowOnlineScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowOnlineLobbyScreenSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct GoBackOnlineSignal
	{
	}

	public struct ShowOnlineErrorScreenSignal
	{
		public string ErrorTitle;

		public string ErrorMessage;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowAdventuresSelectionViewSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowAdventuresAscensionSignal
	{
	}

	public struct ToggleGuidesSignal
	{
		public bool IsOn;
	}

	public struct TogglePickupsSignal
	{
		public bool IsOn;
	}

	public struct GoldFeverStartedSignal
	{
		public float Duration;

		public bool IsFake;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct GoldFeverEndedSignal
	{
	}

	public struct EmitGoldFeverParticleSignal
	{
		public Vector3 WorldPosition;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct GoldFeverCoinCollectedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseDirectorSignal
	{
	}

	public struct ShowBackButtonSignal
	{
		public bool ShouldAutoSelect;
	}

	public struct ForceBackButtonNavigation
	{
		public Selectable Up;

		public Selectable Down;

		public Selectable Left;

		public Selectable Right;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ResetBackButtonNavigation
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct HideBackButtonSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenDirectorSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenPianoSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ClosePianoSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowFinalFireworksSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseFinalFireworksSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct PianoTuneCompleteSignal
	{
	}

	public struct FadeScreenSignal
	{
		public float From;

		public float To;

		public float Duration;

		public Ease Ease;

		public Action OnComplete;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct BackButtonPressedSignal
	{
	}

	public struct ConfirmCharacterSignal
	{
		private CharacterType _003CSelectedCharacter_003Ek__BackingField;

		public CharacterType SelectedCharacter
		{
			get
			{
				return _003CSelectedCharacter_003Ek__BackingField;
			}
			set
			{
				_003CSelectedCharacter_003Ek__BackingField = value;
			}
		}
	}

	public struct ConfirmStageSelectionSignal
	{
		private StageType _003CSelectedStage_003Ek__BackingField;

		public StageType SelectedStage
		{
			get
			{
				return _003CSelectedStage_003Ek__BackingField;
			}
			set
			{
				_003CSelectedStage_003Ek__BackingField = value;
			}
		}
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SelectOnlineStageSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct StartOnlineGame
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct LockOnlineUI
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct QuickStartGameSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RecapPageCompletedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SkipWeaponSelectionSignal
	{
	}

	public struct SetDamageNumbersSignal
	{
		public bool isOn;
	}

	public struct SetGlimmerCarouselSignal
	{
		public bool isOn;
	}

	public struct ToggleMovingBackgroundSignal
	{
		public bool isOn;
	}

	public struct SetFullscreenSignal
	{
		public bool isOn;
	}

	public struct ToggleStageProgressionSignal
	{
		public bool Hide;
	}

	public struct ToggleHideDebugUISignal
	{
		public bool Hide;
	}

	public struct ToggleHideGameUISignal
	{
		public bool Hide;
	}

	public struct ToggleXPBarSignal
	{
		public bool Hidden;
	}

	public struct ToggleWeaponSlotsSignal
	{
		public bool Hidden;
	}

	public struct FireNewGlimmerTechnique
	{
		public string glimmerText;
	}

	public struct SetVisibleJoysticksSignal
	{
		public bool _IsOn;
	}

	public struct ReceivedNewItemSignal
	{
		public ItemType _Item;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct DiscardNewItemSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenBestiarySignal
	{
	}

	public struct SetFlashingVFXSignal
	{
		public bool isOn;
	}

	public struct SetStreamerSafeMusicSignal
	{
		public bool IsOn;
	}

	public struct SetSFXVolumeSignal
	{
		public float Volume;
	}

	public struct SetMusicVolumeSignal
	{
		public float Volume;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SyncSteamAchievementsSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RefundPowerUpsSignal
	{
	}

	public struct CreateDamageNumberSignal
	{
		public Vector3 WorldPosition;

		public int Damage;
	}

	public struct CreateSpecialDamageNumberSignal
	{
		public Vector3 WorldPosition;

		public int Damage;

		public float Size;

		public bool HasCustomColor;

		public Color32 Color;

		public int FontOffset;

		public bool Randomize;
	}

	public struct CreateImpactVFXSignal
	{
		public HitVfxType type;

		public Vector2 WorldPos;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OpenLanguagePageSignal
	{
	}

	public struct LanguageSelectedSignal
	{
		public string languageCode;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct QuitGameSignal
	{
	}

	public struct CharacterUnlockedSignal
	{
		public CharacterType character;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct WarningShownSignal
	{
	}

	public struct StageUnlockedSignal
	{
		public StageType stage;
	}

	public struct WeaponUnlockedSignal
	{
		public WeaponType weapon;
	}

	public struct CharacterBoughtSignal
	{
		public CharacterType character;
	}

	public struct SkinBoughtSignal
	{
		public SkinType skin;
	}

	public struct BuyPowerUpSignal
	{
		public PowerUpType Powerup;

		public int Price;
	}

	public struct ShowItemFoundScreenSignal
	{
		public WeaponType Type;
	}

	public struct TreasureChestSpawnedSignal
	{
		public GameObject Treasure;
	}

	public struct TreasureChestCollectedSignal
	{
		public GameObject Treasure;
	}

	public struct SpawnOffScreenCursorSignal
	{
		public GameObject Target;

		public CursorData Data;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CharacterCollectedSignal
	{
	}

	public class OpenMerchantSignal
	{
		private readonly VampireSurvivors.Objects.Characters.CharacterController _003CCharacter_003Ek__BackingField;

		public VampireSurvivors.Objects.Characters.CharacterController Character => _003CCharacter_003Ek__BackingField;

		public OpenMerchantSignal(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
			_003CCharacter_003Ek__BackingField = characterController;
		}
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct MerchantClosedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct HideAllCursorsSignal
	{
	}

	public struct ShowCursorSignal
	{
		public GameObject Target;
	}

	public struct HideCursorSignal
	{
		public GameObject Target;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct UnhideCursorsSignal
	{
	}

	public struct RemoveOffScreenCursorSignal
	{
		public GameObject Target;
	}

	public struct ArcanaSelectedSignal
	{
		public ArcanaType Type;
	}

	public struct CharacterCardSelectedSignal
	{
		public CharacterSkillCard_Base Card;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ArcanaSkippedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SurvarotsSkippedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowEndCreditsSignal
	{
	}

	public struct RemoveWeaponFromEquipmentPanel
	{
		public WeaponType Weapon;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowGameOverinoSceneSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowAccountPageSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ShowLevelBonusSelectionSignal
	{
	}

	public struct LevelUpBonusSelectedSignal
	{
		public PowerUpType SelectedBonus;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SkipLevelUpBonusSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CharacterFoundPageClosedSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RefreshCursorsSignal
	{
	}

	public struct BanishWeaponLevelUpSignal
	{
		public WeaponType BanishedWeapon;
	}
}
