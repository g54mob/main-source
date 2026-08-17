using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_Base
{
	public CharacterController LinkedCharacter;

	public int AccumulatedLevels = 1;

	public List<Dictionary<int, ModifierStats>> ModifierStatsMaps;

	public List<CharacterSkillCard_Base> SubCards;

	public ModifierStats OnEveryLevelUp;

	public int Rarity;

	public int AvailableSlots;

	public ModifierStats InitialBonus;

	public ArcanaType Type;

	public SkillCardEdition Edition;

	public float InitialRunEnemies;

	public float InitialRunCoins;

	public float InitialRunRunBossesCount;

	private int currentBonusIndex;

	private int currentExtraStacks;

	private int currentBonusIndex_Gold;

	private int currentExtraStacks_Gold;

	public virtual ArcanaType GalaType
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return ArcanaType.VOID;
		}
	}

	public virtual List<ArcanaType> FoilTypes => CharacterSkillCard_RandomGenerator.SubSkills_Foil;

	protected virtual int[] bonusTresholds => new int[3] { 1000, 5000, 10000 };

	protected virtual int[] bonusTresholds_Gold => new int[3] { 1000, 2000, 3000 };

	public CharacterSkillCard_Base(ArcanaType type)
	{
		List<Dictionary<int, ModifierStats>> modifierStatsMaps = new List<Dictionary<int, ModifierStats>>();
		ModifierStatsMaps = modifierStatsMaps;
		List<CharacterSkillCard_Base> subCards = new List<CharacterSkillCard_Base>();
		SubCards = subCards;
		Rarity = 1;
		AvailableSlots = 6;
		ModifierStats initialBonus = new ModifierStats();
		InitialBonus = initialBonus;
		Type = type;
	}

	public void SetEdition(SkillCardEdition edition, bool activateEdition = true)
	{
		//IL_0031: Expected O, but got I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		Edition = edition;
		bool flag = !activateEdition;
		if (flag)
		{
			return;
		}
		object obj = edition - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				return;
			}
			object obj3 = obj2 - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag)
				{
					if ((nint)obj4 == 1)
					{
						OnActivate_Gala();
					}
				}
				else
				{
					MultiplyAllStats(-0.5f);
				}
			}
			else
			{
				MultiplyAllStats(2f);
			}
		}
		else
		{
			OnActivate_Foil();
		}
	}

	public virtual void SetLinkedCharacter(CharacterController character)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		LinkedCharacter = character;
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < subCards._size)
			{
				List<CharacterSkillCard_Base> subCards2 = SubCards;
				if ((nint)obj >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj].SetLinkedCharacter(character);
				subCards = SubCards;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void InitialActivate()
	{
		//IL_002e: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_038a: Expected F4, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0419: Expected F4, but got I4
		LinkedCharacter.PlayerStatsUpgrade(InitialBonus);
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < subCards._size)
			{
				List<CharacterSkillCard_Base> subCards2 = SubCards;
				if ((nint)obj >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj].InitialActivate();
				subCards = SubCards;
				obj++;
				obj2 = obj;
				continue;
			}
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData playerOptionsData;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_037b;
						}
					}
					playerOptionsData = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_037b;
			IL_03ff:
			AccumulatedLevels = 1;
			PlayerOptionsData playerOptionsData2;
			InitialRunRunBossesCount = playerOptionsData2._003CRunBossesCount_003Ek__BackingField;
			return;
			IL_03bd:
			PlayerOptionsData playerOptionsData3;
			InitialRunCoins = playerOptionsData3._003CRunCoins_003Ek__BackingField;
			GameManager core2 = GM.Core;
			PlayerOptions playerOptions2 = core2._playerOptions;
			if (playerOptions2._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions2._hostGameConfig == null)
				{
					if (playerOptions2._currentAdventureSaveData != null)
					{
						playerOptionsData2 = playerOptions2._currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_03ff;
						}
					}
					playerOptionsData2 = playerOptions2._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions2._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
			}
			goto IL_03ff;
			IL_037b:
			InitialRunEnemies = playerOptionsData._003CRunEnemies_003Ek__BackingField;
			GameManager core3 = GM.Core;
			PlayerOptions playerOptions3 = core3._playerOptions;
			if (playerOptions3._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData3 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_03bd;
						}
					}
					playerOptionsData3 = playerOptions3._mainGameConfig;
				}
				else
				{
					playerOptionsData3 = playerOptions3._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData3 = playerOptions3._onlineClientWithRunDataConfig;
			}
			goto IL_03bd;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe virtual void OnOwnerLevelUp()
	{
		//IL_036d: Expected O, but got I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		bool flag = Edition == SkillCardEdition.Holo;
		object obj = 3;
		if (!flag)
		{
			obj = null;
		}
		IntPtr intPtr = default(IntPtr);
		bool flag3 = default(bool);
		bool flag2 = ((Dictionary<int, ModifierStats>)this).TryGetValue((int)(nint)intPtr, out *(flag3 ? ((ModifierStats*)1) : ((ModifierStats*)null)));
		object obj2 = flag2 + obj;
		object obj3 = null;
		object obj4 = null;
		List<Dictionary<int, ModifierStats>>.Enumerator enumerator = default(List<Dictionary<int, ModifierStats>>.Enumerator);
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			int accumulatedLevels = AccumulatedLevels + 1;
			AccumulatedLevels = accumulatedLevels;
			if (enumerator.MoveNext())
			{
				Dictionary<int, object> dictionary = null;
				throw new NullReferenceException();
			}
			if (OnEveryLevelUp != null)
			{
				LinkedCharacter.PlayerStatsUpgrade(OnEveryLevelUp);
				flag3 = false;
			}
			obj4++;
		}
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj5 = null;
		object obj6 = null;
		while (true)
		{
			if ((nint)obj6 < subCards._size)
			{
				List<CharacterSkillCard_Base> subCards2 = SubCards;
				if ((nint)obj5 >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj5].OnOwnerLevelUp();
				obj5++;
				subCards = SubCards;
				obj6 = obj5;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void Update()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> subCards2 = SubCards;
		while (true)
		{
			if ((nint)obj2 < subCards._size)
			{
				if ((nint)obj >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj].Update();
				subCards2 = SubCards;
				obj++;
				obj2 = obj;
				subCards = SubCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> subCards2 = SubCards;
		while (true)
		{
			if ((nint)obj < subCards._size)
			{
				if ((nint)obj2 >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj2].OnOwnerRevived();
				subCards2 = SubCards;
				obj2++;
				obj = obj2;
				subCards = SubCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void OnOwnerGetDamaged(float damageAmount)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> subCards2 = SubCards;
		while (true)
		{
			if ((nint)obj < subCards._size)
			{
				if ((nint)obj2 >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj2].OnOwnerGetDamaged(damageAmount);
				subCards2 = SubCards;
				obj2++;
				obj = obj2;
				subCards = SubCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void OnOwnerCriticalHPTreshold(float rawValue)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> subCards2 = SubCards;
		while (true)
		{
			if ((nint)obj < subCards._size)
			{
				if ((nint)obj2 >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj2].OnOwnerCriticalHPTreshold(rawValue);
				subCards2 = SubCards;
				obj2++;
				obj = obj2;
				subCards = SubCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void OnOwnerLevelUpSkipped()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		List<CharacterSkillCard_Base> subCards = SubCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> subCards2 = SubCards;
		while (true)
		{
			if ((nint)obj2 < subCards._size)
			{
				if ((nint)obj >= subCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = subCards2._items;
				items[obj].OnOwnerLevelUpSkipped();
				subCards2 = SubCards;
				obj++;
				obj2 = obj;
				subCards = SubCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected virtual void OnEnemiesCountReached()
	{
	}

	protected virtual void OnGoldCountReached()
	{
	}

	protected void Update_CountEnemies()
	{
		//IL_003b: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d8: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int[] array = bonusTresholds;
		object obj = array.Length - 1;
		object obj2 = currentExtraStacks * array[obj];
		int[] array2 = bonusTresholds;
		int num;
		if (currentBonusIndex >= array2.Length)
		{
			int[] array3 = bonusTresholds;
			num = array3.Length - 1;
		}
		else
		{
			num = currentBonusIndex;
		}
		float num2 = (float)config._003CRunEnemies_003Ek__BackingField - InitialRunEnemies;
		int[] array4 = bonusTresholds;
		object obj3 = array4[num] + obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			OnEnemiesCountReached();
			int num3 = ++currentBonusIndex;
			int[] array5 = bonusTresholds;
			if (num3 >= array5.Length)
			{
				int num4 = currentExtraStacks + 1;
				currentExtraStacks = num4;
			}
		}
	}

	protected void Update_CountGold()
	{
		//IL_003b: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d8: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int[] array = bonusTresholds_Gold;
		object obj = array.Length - 1;
		object obj2 = currentExtraStacks_Gold * array[obj];
		int[] array2 = bonusTresholds_Gold;
		int num;
		if (currentBonusIndex_Gold >= array2.Length)
		{
			int[] array3 = bonusTresholds_Gold;
			num = array3.Length - 1;
		}
		else
		{
			num = currentBonusIndex_Gold;
		}
		float num2 = config._003CRunCoins_003Ek__BackingField - InitialRunCoins;
		int[] array4 = bonusTresholds_Gold;
		object obj3 = array4[num] + obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			OnGoldCountReached();
			int num3 = ++currentBonusIndex_Gold;
			int[] array5 = bonusTresholds_Gold;
			if (num3 >= array5.Length)
			{
				int num4 = currentExtraStacks_Gold + 1;
				currentExtraStacks_Gold = num4;
			}
		}
	}

	protected void AddSubCard(ArcanaType type)
	{
		//IL_000d: Expected I, but got O
		CharacterSkillCard_Base cardForArcanaType = CharacterSkillCardsManager.GetCardForArcanaType(type);
		nint num = (nint)cardForArcanaType;
		cardForArcanaType.Edition = Edition;
		cardForArcanaType.SetLinkedCharacter(LinkedCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
	}

	protected void AddSubCard(CharacterSkillCard_Base subCard)
	{
		//IL_001c: Expected I, but got O
		subCard.Edition = Edition;
		nint num = (nint)subCard;
		subCard.SetLinkedCharacter(LinkedCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
	}

	public virtual void SetRarity(int rarity)
	{
		Rarity = rarity;
	}

	private void ActivateSpecialEdition()
	{
		//IL_0010: Expected O, but got I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		object obj = Edition - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 != null)
			{
				return;
			}
			object obj4 = obj3 - 1;
			if (obj2 == null)
			{
				object obj5 = obj4 - 1;
				if (obj2 == null)
				{
					if ((nint)obj5 == 1)
					{
						OnActivate_Gala();
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 27 Invalid \"Jump target not found in method: 0x187572370\"");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x187572370\"");
		}
		OnActivate_Foil();
	}

	private void MultiplyAllStats(float multiplier)
	{
		//IL_0088: Expected O, but got I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0106: Invalid comparison between I4 and F4
		//IL_0163: Invalid comparison between I4 and F4
		//IL_00c6: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_0258: Expected O, but got I4
		//IL_0372: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		ModifierStats initialBonus = InitialBonus * multiplier;
		InitialBonus = initialBonus;
		ModifierStats initialBonus2 = InitialBonus;
		object obj = (object)InitialBonus ^ (object)InitialBonus;
		object obj2 = (object)InitialBonus & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (nint)InitialBonus < 0;
		bool flag3 = InitialBonus == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [rax+48h]\"");
		bool flag4 = flag2 == flag;
		object obj3 = !flag4;
		object obj4 = obj3 | flag3;
		if (obj4 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A115D0h]\"");
			bool flag5 = flag2 == flag;
			object obj5 = !flag5;
			object obj6 = obj5 | flag3;
			if (obj6 == null)
			{
				initialBonus2._003CRevivals_003Ek__BackingField = -1.0;
			}
		}
		if (0f > initialBonus2._003CAmount_003Ek__BackingField && initialBonus2._003CAmount_003Ek__BackingField > -1f)
		{
			initialBonus2._003CAmount_003Ek__BackingField = -1f;
		}
		if (0f > initialBonus2._003CArmor_003Ek__BackingField && initialBonus2._003CArmor_003Ek__BackingField > -1f)
		{
			initialBonus2._003CArmor_003Ek__BackingField = -1f;
		}
		List<Dictionary<int, ModifierStats>> modifierStatsMaps = ModifierStatsMaps;
		if (modifierStatsMaps._size <= 1)
		{
			return;
		}
		if (modifierStatsMaps._size > 1)
		{
			Dictionary<int, ModifierStats>[] items = modifierStatsMaps._items;
			Dictionary<int, ModifierStats> dictionary = items[1];
			Dictionary<int, ModifierStats>.KeyCollection keys = items[1].Keys;
			List<int> list = new List<int>(keys);
			object obj7 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbp_v7 (System.Collections.Generic.Dictionary`2<System.Int32, VampireSurvivors.Objects.ModifierStats>)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbp_v7 (System.Collections.Generic.Dictionary`2<System.Int32, VampireSurvivors.Objects.ModifierStats>)+28]");
				object obj8 = num - 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
				{
					object obj9 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)obj9 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj10 = 0;
					Dictionary<int, ModifierStats> dictionary2 = items[1];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v9+20+v140 @ rsi_v7*4]");
					ModifierStats modifierStats = dictionary2.get_Item(0);
					ModifierStats value = modifierStats * multiplier;
					Dictionary<int, ModifierStats> dictionary3 = items[1];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v9+20+v140 @ rsi_v7*4]");
					bool flag6 = ((Dictionary<int, object>)(object)dictionary3).TryInsert(0, (object)value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					obj7++;
					continue;
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	protected virtual void OnActivate_Foil()
	{
		//IL_0012: Expected I, but got O
		List<ArcanaType> foilTypes = FoilTypes;
		ArcanaType arcanaType = Extensions.PickRnd(foilTypes);
		CharacterSkillCard_Base cardForArcanaType = CharacterSkillCardsManager.GetCardForArcanaType(arcanaType);
		nint num = (nint)cardForArcanaType;
		cardForArcanaType.Edition = Edition;
		cardForArcanaType.SetLinkedCharacter(LinkedCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
	}

	protected virtual void OnActivate_Gala()
	{
		ArcanaType galaType = GalaType;
		if (galaType != ArcanaType.VOID)
		{
			ArcanaType galaType2 = GalaType;
			AddSubCard(galaType2);
			int availableSlots = AvailableSlots - 1;
			AvailableSlots = availableSlots;
		}
	}

	protected float GetBonusMultiplier()
	{
		if (Edition == SkillCardEdition.Poly)
		{
			return 2f;
		}
		if (Edition == SkillCardEdition.Inve)
		{
			return -0.5f;
		}
		return 1f;
	}

	protected void AddRandomProgressiveBonus()
	{
		//IL_0140: Expected O, but got I
		if (AvailableSlots <= 0)
		{
			return;
		}
		List<Dictionary<int, ModifierStats>> modifierStatsMaps = ModifierStatsMaps;
		int version = modifierStatsMaps._version + 1;
		modifierStatsMaps._version = version;
		modifierStatsMaps._size = 0;
		if (modifierStatsMaps._size > 0)
		{
			Array.Clear(modifierStatsMaps._items, 0, modifierStatsMaps._size);
		}
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		List<int> randomLevelProgression = CharacterSkillCard_RandomGenerator.GetRandomLevelProgression();
		ModifierStats modifierStats = new ModifierStats();
		CharacterSkillCard_RandomGenerator.GetRandomModifierStat(modifierStats);
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num3 < (nint)0)
			{
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r10_v6+20+v155 @ rbx_v6 (System.Int32)*4]");
				bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(0, (object)modifierStats, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				num++;
				num2 = num;
				continue;
			}
			int availableSlots = AvailableSlots - 1;
			AvailableSlots = availableSlots;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected void AddRandomInitialBonus()
	{
		//IL_00bb: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0035: Expected I, but got O
		ModifierStats modifierStats = new ModifierStats();
		object obj = UnityEngine.Random.RandomRangeInt(1, 5);
		if ((nint)obj > 0)
		{
			object obj2;
			do
			{
				bool flag = AvailableSlots == 0;
				if (AvailableSlots > 0)
				{
					int availableSlots = AvailableSlots - 1;
					AvailableSlots = availableSlots;
					nint num = (nint)typeof(CharacterSkillCard_RandomGenerator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator>)+E4]");
					flag = (nint)0 == 0;
					CharacterSkillCard_RandomGenerator.GetRandomModifierStat(modifierStats);
				}
				obj2 = !flag;
			}
			while (obj2 != null);
		}
		if ((object)LinkedCharacter != null)
		{
			LinkedCharacter.PlayerStatsUpgrade(modifierStats);
		}
	}

	protected void AddRandomPerLevelBonus()
	{
		//IL_0133: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00a5: Expected I, but got O
		CharacterController linkedCharacter = LinkedCharacter;
		if ((object)LinkedCharacter == null || ((UnityEngine.Object)linkedCharacter).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object obj = UnityEngine.Random.RandomRangeInt(1, 5);
		if ((nint)obj <= 0)
		{
			return;
		}
		object obj2;
		do
		{
			bool flag = AvailableSlots == 0;
			if (AvailableSlots > 0)
			{
				int availableSlots = AvailableSlots - 1;
				AvailableSlots = availableSlots;
				if (OnEveryLevelUp == null)
				{
					ModifierStats onEveryLevelUp = new ModifierStats();
					OnEveryLevelUp = onEveryLevelUp;
				}
				nint num = (nint)typeof(CharacterSkillCard_RandomGenerator);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator>)+E4]");
				flag = (nint)0 == 0;
				CharacterSkillCard_RandomGenerator.GetRandomModifierGrowth(OnEveryLevelUp);
			}
			obj2 = !flag;
		}
		while (obj2 != null);
	}
}
