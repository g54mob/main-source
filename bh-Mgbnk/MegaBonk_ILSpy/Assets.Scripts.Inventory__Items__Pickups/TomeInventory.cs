using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class TomeInventory
{
	private bool isMaxed;

	public static Action<ETome, EStat> A_TomeUpgrade;

	public Dictionary<ETome, int> tomeLevels;

	public Dictionary<EStat, HashSet<ETome>> statToTomes;

	public Dictionary<ETome, StatModifier> tomeUpgrade;

	public unsafe void AddTome(TomeData tomeData, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		//IL_0120: Expected O, but got Ref
		//IL_071a: Expected O, but got Ref
		//IL_039e: Expected O, but got I
		//IL_054f: Expected O, but got I
		bool flag = (object)tomeData == null;
		Dictionary<ETome, int> dictionary = (Dictionary<ETome, int>)(object)this;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		if (!flag)
		{
			dictionary = tomeLevels;
			if (tomeLevels != null)
			{
				if (!tomeLevels.ContainsKey(tomeData.eTome))
				{
					bool flag2 = tomeLevels == null;
					dictionary = tomeLevels;
					if (flag2)
					{
						goto IL_0656;
					}
					((Dictionary<System.Int32Enum, int>)(object)tomeLevels).Add((System.Int32Enum)tomeData.eTome, 0);
				}
				bool flag3 = tomeLevels == null;
				dictionary = tomeLevels;
				if (!flag3)
				{
					int num = tomeLevels.get_Item(tomeData.eTome);
					int maxLevel = tomeData.GetMaxLevel();
					if (num >= maxLevel)
					{
						ETome eTome = tomeData.eTome;
						string text = ((Enum)(&enumerator)).ToString();
						string text2 = "Tried to upgrade tome: " + text + " but it's already maxed!";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						dictionary = (Dictionary<ETome, int>)(object)text2;
					}
					else
					{
						bool flag4 = tomeLevels == null;
						dictionary = (Dictionary<ETome, int>)(object)tomeData;
						if (flag4)
						{
							goto IL_0656;
						}
						int num2 = tomeLevels.get_Item(tomeData.eTome);
						int value = num2 + 1;
						((Dictionary<System.Int32Enum, int>)(object)tomeLevels).set_Item((System.Int32Enum)tomeData.eTome, value);
						dictionary = tomeLevels;
					}
					StatModifier statModifier = tomeData.statModifier;
					if (tomeData.statModifier != null)
					{
						bool flag5 = statToTomes == null;
						dictionary = (Dictionary<ETome, int>)(object)statToTomes;
						if (!flag5)
						{
							if (((Dictionary<System.Int32Enum, object>)(object)statToTomes).ContainsKey((System.Int32Enum)statModifier.stat))
							{
								goto IL_02d9;
							}
							StatModifier statModifier2 = tomeData.statModifier;
							bool flag6 = tomeData.statModifier == null;
							dictionary = (Dictionary<ETome, int>)(object)statToTomes;
							if (!flag6)
							{
								HashSet<ETome> hashSet = (HashSet<ETome>)(object)new HashSet<System.Int32Enum>();
								bool flag7 = statToTomes == null;
								dictionary = (Dictionary<ETome, int>)(object)hashSet;
								if (!flag7)
								{
									((Dictionary<System.Int32Enum, object>)(object)statToTomes).Add((System.Int32Enum)statModifier2.stat, (object)hashSet);
									goto IL_02d9;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0656;
		IL_02d9:
		bool flag8 = tomeUpgrade == null;
		dictionary = (Dictionary<ETome, int>)(object)tomeUpgrade;
		if (!flag8)
		{
			bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)tomeUpgrade).ContainsKey((System.Int32Enum)tomeData.eTome);
			dictionary = (Dictionary<ETome, int>)(object)tomeUpgrade;
			if (flag9)
			{
				goto IL_0487;
			}
			StatModifier statModifier3 = new StatModifier();
			dictionary = (Dictionary<ETome, int>)(object)tomeData.statModifier;
			if (tomeData.statModifier != null && statModifier3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v5 (System.Collections.Generic.Dictionary`2<Assets.Scripts._Data.Tomes.ETome, System.Int32>)+10]");
				dictionary = (Dictionary<ETome, int>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v5 (System.Collections.Generic.Dictionary`2<Assets.Scripts._Data.Tomes.ETome, System.Int32>)+10]");
				statModifier3.stat = EStat.MaxHealth;
				StatModifier statModifier4 = tomeData.statModifier;
				if (tomeData.statModifier != null)
				{
					statModifier3.modifyType = statModifier4.modifyType;
					statModifier3.modification = 0f;
					StatModifier statModifier5 = tomeData.statModifier;
					if (tomeData.statModifier != null)
					{
						if (statModifier5.modifyType == EStatModifyType.Multiplication)
						{
							statModifier3.modification = 1f;
						}
						if (tomeUpgrade != null)
						{
							((Dictionary<System.Int32Enum, object>)(object)tomeUpgrade).Add((System.Int32Enum)tomeData.eTome, (object)statModifier3);
							goto IL_0487;
						}
					}
				}
			}
		}
		goto IL_0656;
		IL_0487:
		if (upgradeOffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator2 = enumerator;
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			while (enumerator3.MoveNext())
			{
				if (tomeUpgrade != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)tomeUpgrade).get_Item((System.Int32Enum)tomeData.eTome);
					if (obj != null)
					{
						if (tomeData.eTome != ETome.Damage)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v48 (Assets.Scripts._Data.Tomes.ETome)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v34 (System.Object)+18]");
							enumerator2 = (List<object>.Enumerator)(num3 + 0);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<StatModifier>.Enumerator*)(&enumerator3))->Dispose();
			StatModifier statModifier6 = tomeData.statModifier;
			bool flag10 = tomeData.statModifier == null;
			dictionary = (Dictionary<ETome, int>)(&enumerator3);
			if (!flag10 && statToTomes != null)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)statToTomes).get_Item((System.Int32Enum)statModifier6.stat);
				if (obj2 != null)
				{
					bool flag11 = ((HashSet<ETome>)obj2).Add(tomeData.eTome);
					CheckMaxed();
					TomeUtility.CheckSpecialTomes(tomeData, rarity);
					Action<ETome, EStat> a_TomeUpgrade = A_TomeUpgrade;
					if (A_TomeUpgrade == null)
					{
						return;
					}
					StatModifier statModifier7 = tomeData.statModifier;
					if (tomeData.statModifier != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v152 @ rax_v30 (System.Action`2<Assets.Scripts._Data.Tomes.ETome, Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		goto IL_0656;
		IL_0656:
		throw new NullReferenceException();
	}

	public void AddMaxedTome(TomeData tomeData)
	{
		int maxLevel = tomeData.GetMaxLevel();
		((Dictionary<System.Int32Enum, int>)(object)tomeLevels).set_Item((System.Int32Enum)tomeData.eTome, maxLevel);
		StatModifier statModifier = tomeData.statModifier;
		if (!((Dictionary<System.Int32Enum, object>)(object)statToTomes).ContainsKey((System.Int32Enum)statModifier.stat))
		{
			StatModifier statModifier2 = tomeData.statModifier;
			HashSet<ETome> value = (HashSet<ETome>)(object)new HashSet<System.Int32Enum>();
			((Dictionary<System.Int32Enum, object>)(object)statToTomes).Add((System.Int32Enum)statModifier2.stat, (object)value);
		}
		StatModifier statModifier3 = tomeData.statModifier;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)statToTomes).get_Item((System.Int32Enum)statModifier3.stat);
		bool flag = ((HashSet<ETome>)obj).Add(tomeData.eTome);
		Action<ETome, EStat> a_TomeUpgrade = A_TomeUpgrade;
		if (A_TomeUpgrade != null)
		{
			StatModifier statModifier4 = tomeData.statModifier;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v86 @ rax_v11 (System.Action`2<Assets.Scripts._Data.Tomes.ETome, Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
		}
	}

	public int GetTomeLevel(ETome tome)
	{
		//IL_0071: Expected I4, but got O
		if (tomeLevels != null)
		{
			if (!tomeLevels.ContainsKey(tome))
			{
				return 0;
			}
			if (tomeLevels != null)
			{
				return tomeLevels.get_Item(tome);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetNumTomes()
	{
		//IL_0027: Expected I4, but got O
		if (tomeLevels != null)
		{
			return tomeLevels.Count;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void CheckMaxed()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D878F0");
		Dictionary<ETome, int>.Enumerator enumerator = default(Dictionary<ETome, int>.Enumerator);
		ETome eTome = default(ETome);
		bool flag;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (!IsMaxLevel(eTome))
				{
					enumerator.Dispose();
					flag = false;
					break;
				}
				continue;
			}
			enumerator.Dispose();
			flag = true;
			break;
		}
		isMaxed = flag;
	}

	private bool IsMaxLevel(ETome eTome)
	{
		//IL_0136: Expected I4, but got O
		//IL_00ca: Expected O, but got I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected I4, but got Unknown
		if (tomeLevels != null)
		{
			if (!tomeLevels.ContainsKey(eTome))
			{
				return false;
			}
			if (tomeLevels != null)
			{
				int num = tomeLevels.get_Item(eTome);
				if ((object)DataManager.Instance != null)
				{
					TomeData tome = DataManager.Instance.GetTome(eTome);
					if ((object)tome != null)
					{
						int maxLevel = tome.GetMaxLevel();
						object obj = num - maxLevel;
						int num2 = num ^ maxLevel;
						int num3 = num ^ obj;
						int num4 = num2 & num3;
						bool flag = num4 < 0;
						bool flag2 = (nint)obj < 0;
						return flag2 == flag;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsMaxed()
	{
		if (tomeLevels != null)
		{
			int count = tomeLevels.Count;
			int numAvailableTomeSlots = InventoryUtility.GetNumAvailableTomeSlots();
			if (count < numAvailableTomeSlots)
			{
				return false;
			}
			bool flag = tomeLevels == null;
			Dictionary<ETome, int> dictionary = null;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D878F0");
				Dictionary<ETome, int>.Enumerator enumerator = default(Dictionary<ETome, int>.Enumerator);
				ETome eTome = default(ETome);
				while (enumerator.MoveNext())
				{
					if (!IsMaxLevel(eTome))
					{
						enumerator.Dispose();
						return false;
					}
				}
				enumerator.Dispose();
				return true;
			}
		}
		throw new NullReferenceException();
	}

	public bool HasTome(ETome eTome)
	{
		//IL_002b: Expected I4, but got O
		if (tomeLevels != null)
		{
			return tomeLevels.ContainsKey(eTome);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public TomeInventory()
	{
		Dictionary<ETome, int> dictionary = new Dictionary<ETome, int>();
		tomeLevels = dictionary;
		Dictionary<EStat, HashSet<ETome>> dictionary2 = new Dictionary<EStat, HashSet<ETome>>();
		statToTomes = dictionary2;
		Dictionary<ETome, StatModifier> dictionary3 = new Dictionary<ETome, StatModifier>();
		tomeUpgrade = dictionary3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
