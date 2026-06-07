using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts._Data;
using Inventory__Items__Pickups.Xp_and_Levels;

public class PlayerInventory
{
	public PlayerStatsNew playerStats;

	public CharacterData characterData;

	public ItemInventory itemInventory;

	public WeaponInventory weaponInventory;

	public PlayerXp playerXp;

	public PlayerStatusEffects statusEffects;

	public PlayerHealth playerHealth;

	public TomeInventory tomeInventory;

	public StatInventory statInventory;

	public PassiveAbility passiveAbility;

	public ActiveAbility activeAbility;

	public static int maxGoldPerFrame;

	public static int goldThisFrame;

	private bool hasHitGoldCap;

	public int banishes;

	public int refreshes;

	public int skips;

	public static Action<PlayerInventory, int> A_GoldChange;

	public bool pause;

	private int pendingXp;

	public int skipsUsed;

	public int refreshesUsed;

	public int banishesUsed;

	public float gold { get; private set; }

	public int goldInt { get; private set; }

	public PlayerInventory(CharacterData characterData, bool ignoreShopItems = false)
	{
	}

	public void PhysicsTick()
	{
	}

	public void Update()
	{
	}

	public void AddUpgrade(IUpgradable upgradable, List<StatModifier> upgradeOffer, ERarity rarity)
	{
	}

	public void ChangeGold(int amount)
	{
	}

	public void AddXp(int amount)
	{
	}

	public void LateUpdate()
	{
	}

	public void AddSilver(int amount)
	{
	}

	public void AddLevel()
	{
	}

	public int GetCharacterLevel()
	{
		return 0;
	}

	public bool HasPassive(EPassive passive)
	{
		return false;
	}

	private void InitSkipRefreshBanish()
	{
	}

	public void Cleanup()
	{
	}
}
