using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
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

	private float _003Cgold_003Ek__BackingField;

	public static int maxGoldPerFrame = 10000;

	public static int goldThisFrame = 0;

	private bool hasHitGoldCap;

	private int _003CgoldInt_003Ek__BackingField;

	public int banishes;

	public int refreshes;

	public int skips;

	public static Action<PlayerInventory, int> A_GoldChange;

	public bool pause;

	private int pendingXp;

	public int skipsUsed;

	public int refreshesUsed;

	public int banishesUsed;

	public float gold
	{
		get
		{
			return _003Cgold_003Ek__BackingField;
		}
		private set
		{
			_003Cgold_003Ek__BackingField = value;
		}
	}

	public int goldInt
	{
		get
		{
			return _003CgoldInt_003Ek__BackingField;
		}
		private set
		{
			_003CgoldInt_003Ek__BackingField = value;
		}
	}

	public PlayerInventory(CharacterData characterData, bool ignoreShopItems = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		this.characterData = characterData;
		InitSkipRefreshBanish();
		PlayerXp playerXp = new PlayerXp();
		this.playerXp = playerXp;
		ItemInventory itemInventory = new ItemInventory();
		this.itemInventory = itemInventory;
		WeaponInventory weaponInventory = new WeaponInventory();
		this.weaponInventory = weaponInventory;
		PlayerStatusEffects playerStatusEffects = new PlayerStatusEffects();
		statusEffects = playerStatusEffects;
		TomeInventory tomeInventory = new TomeInventory();
		this.tomeInventory = tomeInventory;
		StatInventory statInventory = new StatInventory();
		this.statInventory = statInventory;
		PlayerStatsNew playerStatsNew = new PlayerStatsNew(this, ignoreShopItems);
		playerStats = playerStatsNew;
		PlayerHealth playerHealth = new PlayerHealth(playerStats);
		this.playerHealth = playerHealth;
		PassiveAbility passiveAbility = PassiveAbilityFactory.CreatePassiveAbility(characterData.passive);
		this.passiveAbility = passiveAbility;
		this.passiveAbility.Init();
		ProjectileScythe.nextHitIsBig = false;
		ActiveAbility activeAbility = ActiveAbilityFactory.CreateAbility(EAbiltiyActive.Dash);
		this.activeAbility = activeAbility;
		if (this.activeAbility != null)
		{
			this.activeAbility.Init();
		}
		if (!ignoreShopItems)
		{
			this.weaponInventory.AddWeapon(characterData.weapon, null);
		}
	}

	public void PhysicsTick()
	{
		if (!pause)
		{
			weaponInventory.Tick();
			itemInventory.Tick();
			playerStats.Tick();
			statusEffects.Tick();
			playerHealth.Tick();
			statInventory.Tick();
			passiveAbility.Tick();
			if (activeAbility != null)
			{
				activeAbility.Tick();
			}
		}
	}

	public void Update()
	{
		hasHitGoldCap = false;
		goldThisFrame = 0;
	}

	public void AddUpgrade(IUpgradable upgradable, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		//IL_016b: Expected I, but got O
		//IL_0173: Expected I4, but got O
		//IL_0183: Expected O, but got I
		//IL_0088: Expected I, but got O
		//IL_0090: Expected I4, but got O
		//IL_00a0: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_00ea: Expected O, but got I
		bool flag = upgradable == null;
		List<StatModifier> list = upgradeOffer;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TomeData));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B65E0");
			object obj = default(object);
			if (obj == null)
			{
				bool flag2 = weaponInventory == null;
				list = null;
				if (flag2)
				{
					goto IL_0220;
				}
				nint num = (nint)typeof(WeaponData);
				ERarity eRarity = (ERarity)upgradable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v7 (Il2CppClass<WeaponData>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r9_v2 (Assets.Scripts.Inventory__Items__Pickups.ERarity)+130]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v7 (Il2CppClass<WeaponData>)+130]");
				bool flag3 = num2 < 0;
				list = (List<StatModifier>)(object)typeof(WeaponData);
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r9_v2 (Assets.Scripts.Inventory__Items__Pickups.ERarity)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v16+FFFFFFF8+v137 @ rax_v15*8]");
					bool flag4 = 0 != (nint)typeof(WeaponData);
					list = (List<StatModifier>)(object)typeof(WeaponData);
					if (!flag4)
					{
						weaponInventory.AddWeapon((WeaponData)upgradable, upgradeOffer);
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				ERarity eRarity2 = eRarity;
			}
			else
			{
				bool flag5 = tomeInventory == null;
				list = null;
				if (flag5)
				{
					goto IL_0220;
				}
				nint num3 = (nint)typeof(TomeData);
				ERarity eRarity2 = (ERarity)upgradable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v5 (Il2CppClass<TomeData>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r9_v1 (Assets.Scripts.Inventory__Items__Pickups.ERarity)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v5 (Il2CppClass<TomeData>)+130]");
				bool flag6 = num4 < 0;
				list = (List<StatModifier>)(object)typeof(TomeData);
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r9_v1 (Assets.Scripts.Inventory__Items__Pickups.ERarity)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v13+FFFFFFF8+v198 @ rax_v12*8]");
					bool flag7 = 0 != (nint)typeof(TomeData);
					list = (List<StatModifier>)(object)typeof(TomeData);
					if (!flag7)
					{
						ERarity eRarity = default(ERarity);
						tomeInventory.AddTome((TomeData)upgradable, upgradeOffer, eRarity);
						return;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			return;
		}
		goto IL_0220;
		IL_0220:
		throw new NullReferenceException();
	}

	public unsafe void ChangeGold(int amount)
	{
		//IL_0050: Expected I4, but got F4
		//IL_02f5: Expected I, but got O
		//IL_0280: Expected I4, but got F8
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_0184: Expected I4, but got F8
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0129: Expected I4, but got F8
		//IL_03b9: Invalid comparison between F8 and I4
		//IL_0156: Expected I4, but got F8
		//IL_0313: Expected O, but got I4
		//IL_0412: Expected I4, but got F8
		if (hasHitGoldCap)
		{
			return;
		}
		int num3;
		int num = default(int);
		if (num > 0)
		{
			float stat = playerStats.GetStat(EStat.GoldIncreaseMultiplier);
			float num2 = stat * (float)num;
			num3 = (int)num2;
			int num4 = num;
			num = 31;
		}
		else
		{
			num3 = num;
		}
		if (num3 <= 0)
		{
			goto IL_0365;
		}
		nint num5 = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v13 (Il2CppClass<System.Math>)+E4]");
		double num6;
		double num7 = default(double);
		double num8;
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804E008Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v13 (Il2CppClass<System.Math>)+E4]");
			int num4;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
				num6 = Math.Floor(0.0);
				num4 = 0;
				goto IL_023a;
			}
			object obj = num7 & 1;
			bool flag = obj == null;
			num8 = num7;
			num4 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [18262EC98h]\"");
				num8 = num7;
				num4 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804E00C4h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v13 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
				num6 = Math.Ceiling(0.0);
				goto IL_023a;
			}
			object obj2 = num7 & 1;
			bool flag2 = obj2 == null;
			num8 = num7;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC98h]\"");
				num8 = num7;
			}
		}
		goto IL_03a0;
		IL_023a:
		num8 = num6;
		goto IL_03a0;
		IL_03a0:
		double num9 = num8 + (double)goldThisFrame;
		bool flag3 = !(num9 > (double)maxGoldPerFrame);
		num = (int)(&num7);
		if (!flag3)
		{
			hasHitGoldCap = true;
			object obj3 = maxGoldPerFrame - goldThisFrame;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331010");
			int num10 = default(int);
			num3 = num10;
			num = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		double num11 = Math.Floor(0.0);
		double num12 = num11 + (double)goldThisFrame;
		goldThisFrame = (int)num12;
		goto IL_0365;
		IL_0365:
		if ((_003Cgold_003Ek__BackingField = (float)num3 + _003Cgold_003Ek__BackingField) > 2.1474836E+09f)
		{
			_003Cgold_003Ek__BackingField = 2.1474836E+09f;
		}
		double num13 = Math.Floor(_003Cgold_003Ek__BackingField);
		_003CgoldInt_003Ek__BackingField = (int)num13;
		Action<PlayerInventory, int> a_GoldChange = A_GoldChange;
		if (A_GoldChange != null)
		{
			double num14 = num13 - (double)_003CgoldInt_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ r10_v2 (System.Action`2<PlayerInventory, System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	public void AddXp(int amount)
	{
		if (!ChallengesTracker.HasChallengeModifier("no_xp") && !playerHealth.IsDead())
		{
			int num = pendingXp + amount;
			pendingXp = num;
		}
	}

	public void LateUpdate()
	{
		if (pendingXp > 0)
		{
			playerXp.AddXp(pendingXp);
			pendingXp = 0;
		}
	}

	public void AddSilver(int amount)
	{
		if (!playerHealth.IsDead())
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			saveManager.progression.AddSilver(amount);
		}
	}

	public void AddLevel()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerXp playerXp = inventory.playerXp;
		int num = XpUtility.XpToNextLevelTotal(playerXp.xp);
		if (!ChallengesTracker.HasChallengeModifier("no_xp") && !playerHealth.IsDead())
		{
			int num2 = pendingXp + num;
			pendingXp = num2;
		}
	}

	public int GetCharacterLevel()
	{
		//IL_0041: Expected I4, but got O
		PlayerXp playerXp = this.playerXp;
		if (this.playerXp != null)
		{
			return playerXp.level;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public bool HasPassive(EPassive passive)
	{
		//IL_005d: Expected I4, but got O
		//IL_003b: Expected O, but got I4
		if (passiveAbility != null)
		{
			EPassive passiveType = passiveAbility.GetPassiveType();
			object obj = passiveType - passive;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void InitSkipRefreshBanish()
	{
		//IL_00aa: Expected O, but got Ref
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		if (cfGameSettings.pege_mode != 1)
		{
			ShopItemData shopItemData = DataManager.Instance.GetShopItemData(EShopItem.Refresh);
			ShopItemData shopItemData2 = DataManager.Instance.GetShopItemData(EShopItem.Skip);
			ShopItemData shopItemData3 = DataManager.Instance.GetShopItemData(EShopItem.Banish);
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			float stat = MyStats.GetStat(text);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = text - 3;
			object obj2 = text ^ 3;
			object obj3 = (object)text ^ obj;
			object obj4 = obj2 & obj3;
			bool flag = (nint)obj4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = flag2 == flag;
			object obj5 = text - 6;
			object obj6 = text ^ 6;
			object obj7 = (object)text ^ obj5;
			object obj8 = obj6 & obj7;
			bool flag4 = (nint)obj8 < 0;
			bool flag5 = (nint)obj5 < 0;
			bool flag6 = flag5 == flag4;
			object obj9 = text - 9;
			object obj10 = text ^ 9;
			object obj11 = (object)text ^ obj9;
			object obj12 = obj10 & obj11;
			bool flag7 = (nint)obj12 < 0;
			bool flag8 = (nint)obj9 < 0;
			bool flag9 = flag8 == flag7;
			int level = shopItemData.GetLevel();
			int num = shopItemData.GetMaxLevel();
			if (level < num)
			{
				num = level;
			}
			int num2 = num + (flag6 ? 1 : 0);
			refreshes = num2;
			int level2 = shopItemData2.GetLevel();
			int num3 = shopItemData2.GetMaxLevel();
			if (level2 < num3)
			{
				num3 = level2;
			}
			int num4 = num3 + (flag3 ? 1 : 0);
			skips = num4;
			int level3 = shopItemData3.GetLevel();
			int num5 = shopItemData3.GetMaxLevel();
			if (level3 < num5)
			{
				num5 = level3;
			}
			int num6 = num5 + (flag9 ? 1 : 0);
			banishes = num6;
			skipsUsed = 0;
			banishesUsed = 0;
		}
		else
		{
			refreshes = 0;
			banishes = 0;
		}
	}

	public void Cleanup()
	{
		itemInventory.Cleanup();
		weaponInventory.Cleanup();
		statusEffects.OnDestroy();
		playerStats.OnDestroy();
		playerHealth.OnDestroy();
		passiveAbility.Cleanup();
	}
}
