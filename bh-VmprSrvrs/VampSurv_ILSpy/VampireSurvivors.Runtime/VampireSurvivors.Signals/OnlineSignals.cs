using System.Collections.Generic;
using System.Runtime.InteropServices;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Signals;

public static class OnlineSignals
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineLevelUpReRollRequested
	{
	}

	public struct OnlineLevelUpReRoll
	{
		public List<WeaponType> ChosenWeapons;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RequestOnlineLevelUpPass
	{
	}

	public struct OnlineLevelUpPass
	{
		public bool ShowStats;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineLevelUpSkip
	{
	}

	public struct OnlineLevelUpWithItem
	{
		public ItemType ItemType;

		public CharacterController ReceivingCharacter;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineLevelUpWithFriendshipAmulet
	{
	}

	public struct OnlineLevelUpWithLimitBreak
	{
		public int ChosenLimitBreakIndex;

		public bool AlwaysRandomLimitBreak;

		public CharacterController ReceivingCharacter;
	}

	public struct OnlinePurchase
	{
		public WeaponType Weapon;

		public ItemType Item;

		public int Index;

		public int Price;

		public CharacterController PurchasingPlayer;
	}

	public struct OnlineCloseItemFoundPage
	{
		public bool Discard;
	}

	public struct OnlineSelectedArcana
	{
		public int Arcana;
	}

	public struct OnlineSelectedCharacterCard
	{
		public int Arcana;

		public int Edition;

		public int SubCardType;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineReRolledArcanas
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineReRolledCharacterCards
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineBoosterSurvarots
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct OnlineSkipTreasureAnim
	{
	}

	public struct SelectCandyBoxWeapon
	{
		public WeaponType Weapon;
	}

	public struct SelectTPWeapon
	{
		public WeaponType Weapon;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SkipTpWeapon
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SkipCandyBox
	{
	}

	public struct SelectLevelUpBonus
	{
		public PowerUpType LevelUpBonus;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SkipLevelBonus
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct SuccessfulPianoSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ExitPianoSignal
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RightCoffinOpened
	{
	}

	public struct TouchedPianoKeySignal
	{
		public int Key;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct RevealCharacter
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CollectCharacter
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct DirecterTooEasy
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct DirecterTooHard
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct DirecterOkayButton
	{
	}

	public struct OnDirecterStageSwitch
	{
		public int Stage;
	}

	public struct CharacterDisconnected
	{
		public CharacterController DisconnectedPlayer;
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ForceCloseUi
	{
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ArcanaModeTransition
	{
	}

	public struct MadMoonSpin
	{
		public string result;
	}

	public struct WestwoodsSpin
	{
		public int _seed;
	}
}
