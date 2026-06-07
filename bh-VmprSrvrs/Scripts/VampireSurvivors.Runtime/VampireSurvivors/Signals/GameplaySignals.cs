using System.Runtime.InteropServices;
using Coherence.Connection;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Signals
{
	public static class GameplaySignals
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		public struct InitializeGameSessionSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct PreInitializeGameSessionSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct GameSessionInitializedSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct ResetGameSessionSignal
		{
		}

		public struct TimeStopSignal
		{
			public bool IgnoreMovementFreezeFromTimeStop;

			public bool SkipStandardVFX;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct ChangeSpectateSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct SummonWhiteHandSignal
		{
		}

		public struct GamePausedSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController pausingPlayer;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct ReturnToAppSignal
		{
		}

		public struct ConnectionErrorSignal
		{
			public ConnectionException ConnectionException;
		}

		public struct CharacterDiedSignal
		{
			public bool GoStraightToRecapPage;
		}

		public struct CharacterXpChangedSignal
		{
			public float CurrentXp;

			public float MaxXp;
		}

		public struct CharacterLostShieldSignal
		{
			public float DamageAmount;

			public VampireSurvivors.Objects.Characters.CharacterController Character;
		}

		public struct CharacterReceivedDamageSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;
		}

		public struct SetCharacterInvincibilityForMillisSignal
		{
			public float DurationMillis;
		}

		public struct SetCharacterInvincibilityForMillisNonCumulativeSignal
		{
			public float DurationMillis;
		}

		public struct AddWeaponToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct AddSkillToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;
		}

		public struct WeaponAddedToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;

			public WeaponData Data;
		}

		public struct RemoveWeaponFromCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;

			public bool RemoveFromAnotherCharacterIfNotFound;
		}

		public struct WeaponRemovedFromCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct AddHiddenWeaponToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct HiddenWeaponAddedToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct RemoveHiddenWeaponFromCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct HiddenWeaponRemovedFromCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Weapon;
		}

		public struct AddAccessoryToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Accessory;
		}

		public struct WeaponLevelledUpSignal
		{
			public WeaponType Weapon;

			public int NewLevel;
		}

		public struct AccessoryAddedToCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Accessory;

			public WeaponData Data;
		}

		public struct RemoveAccessoryFromCharacterSignal
		{
			public WeaponType Accessory;
		}

		public struct AccessoryRemovedFromCharacterSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Character;

			public WeaponType Accessory;
		}

		public struct PlayerPickedUpNewItemSignal
		{
			public ItemType Item;

			public WeaponType Weapon;

			public bool IsWeapon;

			public VampireSurvivors.Objects.Characters.CharacterController Character;
		}

		public struct CharacterFoundSignal
		{
			public CharacterType FoundCharacter;

			public VampireSurvivors.Objects.Characters.CharacterController ControllingCharacter;
		}

		public struct ReviveCharacterSignal
		{
			public float RevivePercentage;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct WeaponSelectionSignal
		{
		}

		public struct RemoveEnemyFromStageSignal
		{
			public EnemyController EnemyController;
		}

		public struct EnemyKilledImmediateSignal
		{
			public EnemyController EnemyController;
		}

		public struct DestructibleDestroyed
		{
			public Destructible destructible;
		}

		public struct FireEnemyBulletSignal
		{
			public Vector2 SpawnPos;

			public EnemyType BulletType;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct EnterTheBossi
		{
		}

		public struct OpenTreasureSignal
		{
			public Treasure Data;
		}

		public struct OpenTreasureCompletedSignal
		{
			public int TreasureHeldArcanaCount;

			[FormerlySerializedAs("ArcanaWinner")]
			public VampireSurvivors.Objects.Characters.CharacterController TreasureWinner;
		}

		public struct OnAfterCoinsAddedSignal
		{
			public float Amount;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct KillSoleSolutionTilemapFade
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct LevelUpSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct LevelUpWithoutScreenSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct AutoLevelUpSignal
		{
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct LevelUpCompletedSignal
		{
		}

		public struct SkipLevelUpSignal
		{
			public VampireSurvivors.Objects.Characters.CharacterController Player;
		}

		public struct BanishWeaponSignal
		{
			public WeaponType Weapon;
		}

		public struct RemoveWeaponFromExcluded
		{
			public WeaponType Type;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct ValidatePickupWeapons
		{
		}

		public struct OpenSeasonFanSignal
		{
			public string Color;

			public string FrameName;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct DisableThosePeopleBackground
		{
		}

		public struct SetBackgroundVisible
		{
			public bool Visible;
		}
	}
}
