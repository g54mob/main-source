using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class WeaponBase
{
	private float usedWeaponAtTime;

	public WeaponData weaponData;

	public int level;

	private Dictionary<EStat, float> weaponStats;

	private List<List<StatModifier>> upgrades;

	private WeaponPassive passive;

	public static Action<EStat, EWeapon> A_WeaponStatUpdate;

	private bool _003Cenabled_003Ek__BackingField;

	public bool enabled
	{
		get
		{
			return _003Cenabled_003Ek__BackingField;
		}
		private set
		{
			_003Cenabled_003Ek__BackingField = value;
		}
	}

	public WeaponBase(WeaponData data)
	{
		Dictionary<EStat, float> dictionary = new Dictionary<EStat, float>();
		weaponStats = dictionary;
		_003Cenabled_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		level = 1;
		this.weaponData = data;
		List<List<StatModifier>> list = new List<List<StatModifier>>();
		upgrades = list;
		WeaponData weaponData = this.weaponData;
		WeaponPassiveBloodMagic weaponPassiveBloodMagic2;
		if (weaponData.eWeapon == EWeapon.BloodMagic)
		{
			WeaponPassiveBloodMagic weaponPassiveBloodMagic = (WeaponPassiveBloodMagic)new WeaponPassive(this)
			{
				stackChance = 0.05f
			};
			float rollCooldown = WeaponPassiveBloodMagic.maxRollsUpgradesPerMinute / 60f;
			weaponPassiveBloodMagic.rollCooldown = rollCooldown;
			weaponPassiveBloodMagic2 = weaponPassiveBloodMagic;
		}
		else if (weaponData.eWeapon == EWeapon.Dice)
		{
			WeaponPassiveDice weaponPassiveDice = (WeaponPassiveDice)new WeaponPassive(this)
			{
				critPer6 = 0.005f,
				movingStatName = "DiceCritChance"
			};
			float rollCooldown2 = WeaponPassiveDice.maxRollsUpgradesPerMinute / 60f;
			weaponPassiveDice.rollCooldown = rollCooldown2;
			weaponPassiveBloodMagic2 = (WeaponPassiveBloodMagic)(object)weaponPassiveDice;
		}
		else
		{
			weaponPassiveBloodMagic2 = null;
		}
		passive = weaponPassiveBloodMagic2;
		if (passive != null)
		{
			passive.Init();
		}
		WeaponData weaponData2 = this.weaponData;
		Dictionary<EStat, float>.KeyCollection keys = weaponData2.baseStats.Keys;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
		Dictionary<EStat, float>.KeyCollection.Enumerator enumerator = default(Dictionary<EStat, float>.KeyCollection.Enumerator);
		EStat stat = default(EStat);
		while (enumerator.MoveNext())
		{
			UpdateStat(stat);
		}
		enumerator.Dispose();
	}

	public void Cleanup()
	{
		if (passive != null)
		{
			passive.Cleanup();
		}
	}

	public void Disable()
	{
		_003Cenabled_003Ek__BackingField = false;
	}

	public void Enable()
	{
		_003Cenabled_003Ek__BackingField = true;
	}

	public void Use()
	{
		if (_003Cenabled_003Ek__BackingField)
		{
			float weaponCooldown = WeaponUtility.GetWeaponCooldown(this);
			float num = weaponCooldown + usedWeaponAtTime;
			if (num < MyTime.time)
			{
				WeaponUtility.WeaponAttack(this);
				usedWeaponAtTime = MyTime.time;
			}
		}
	}

	public unsafe void Upgrade(List<StatModifier> upgradeOffer)
	{
		//IL_016f: Expected O, but got Ref
		if (upgradeOffer != null && upgradeOffer._size > 0)
		{
			List<object> list = (List<object>)(object)upgrades;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)upgradeOffer);
				int num = level + 1;
				level = num;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				int num2 = default(int);
				items[num2] = upgradeOffer;
				int num3 = level + 1;
				level = num3;
			}
		}
		else
		{
			int num4 = level + 1;
			level = num4;
			if (upgradeOffer == null)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-30+10]");
				UpdateStat(EStat.MaxHealth);
				continue;
			}
			((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateStat(EStat stat)
	{
		//IL_0097: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00c6: Expected O, but got Ref
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_02fe: Expected O, but got Ref
		//IL_01b5: Expected O, but got F4
		//IL_01bd: Expected F4, but got O
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_040a: Expected O, but got F4
		//IL_0412: Expected F4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317277E]");
		bool flag = (nint)0 != 0;
		if ((object)this.weaponData != null)
		{
			float baseStat = this.weaponData.GetBaseStat(stat);
			if (upgrades != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				StatModifier statModifier2 = default(StatModifier);
				StatModifier statModifier = statModifier2;
				float num = 1f;
				List<object>.Enumerator enumerator = (List<object>.Enumerator)0;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)0;
				List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator3 = enumerator4;
				List<object>.Enumerator enumerator5 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator6 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator7 = default(List<object>.Enumerator);
				StatModifier statModifier4 = default(StatModifier);
				while (enumerator5.MoveNext())
				{
					bool flag2 = statModifier2 == null;
					StatModifier statModifier3 = (StatModifier)(&enumerator5);
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						enumerator3 = enumerator6;
						while (enumerator7.MoveNext())
						{
							if (statModifier4 != null)
							{
								if (statModifier4.stat != stat)
								{
									continue;
								}
								if (statModifier4.modifyType != EStatModifyType.Flat)
								{
									if (statModifier4.modifyType != EStatModifyType.Addition)
									{
										if (statModifier4.modifyType == EStatModifyType.Multiplication)
										{
											float modificationTotal = statModifier4.GetModificationTotal(1);
											enumerator3 = (List<object>.Enumerator)(modificationTotal * num);
											num = (float)enumerator3;
										}
									}
									else
									{
										float modificationTotal2 = statModifier4.GetModificationTotal(1);
										enumerator3 = (List<object>.Enumerator)(modificationTotal2 + enumerator);
										enumerator = enumerator3;
									}
								}
								else
								{
									float modificationTotal3 = statModifier4.GetModificationTotal(1);
									enumerator3 = (List<object>.Enumerator)(modificationTotal3 + enumerator2);
									enumerator2 = enumerator3;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						((List<StatModifier>.Enumerator*)(&enumerator7))->Dispose();
						statModifier = statModifier4;
						continue;
					}
					throw new NullReferenceException();
				}
				((List<List<StatModifier>>.Enumerator*)(&enumerator5))->Dispose();
				if (passive != null)
				{
					WeaponPassive weaponPassive = passive;
					if (weaponPassive.statModifiers == null)
					{
						goto IL_0569;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
					List<object>.Enumerator enumerator8 = default(List<object>.Enumerator);
					enumerator3 = enumerator8;
					Dictionary<EStat, StatModifiersContainer>.Enumerator enumerator9 = default(Dictionary<EStat, StatModifiersContainer>.Enumerator);
					StatModifiersContainer statModifiersContainer = default(StatModifiersContainer);
					IntPtr intPtr = default(IntPtr);
					object obj2 = default(object);
					StatModifier statModifier5 = default(StatModifier);
					while (enumerator9.MoveNext())
					{
						if ((nint)statModifier4 != (nint)stat)
						{
							continue;
						}
						if (statModifiersContainer != null)
						{
							IEnumerable<StatModifier> modifiers = statModifiersContainer.GetModifiers();
							if (modifiers != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								object obj = (object)(&intPtr);
								StatModifier statModifier3 = null;
								while (true)
								{
									if (intPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										if (obj2 == null)
										{
											break;
										}
										bool flag3 = intPtr == (IntPtr)0;
										statModifier3 = null;
										if (!flag3)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
											bool flag4 = statModifier5 == null;
											statModifier3 = null;
											if (!flag4)
											{
												if (statModifier5.modifyType != EStatModifyType.Flat)
												{
													if (statModifier5.modifyType != EStatModifyType.Addition)
													{
														bool flag5 = statModifier5.modifyType != EStatModifyType.Multiplication;
														statModifier3 = null;
														if (!flag5)
														{
															float modificationTotal4 = statModifier5.GetModificationTotal(1);
															enumerator3 = (List<object>.Enumerator)(modificationTotal4 * num);
															num = (float)enumerator3;
														}
													}
													else
													{
														float modificationTotal5 = statModifier5.GetModificationTotal(1);
														enumerator3 = (List<object>.Enumerator)(modificationTotal5 + enumerator);
														enumerator = enumerator3;
													}
												}
												else
												{
													float modificationTotal6 = statModifier5.GetModificationTotal(1);
													enumerator3 = (List<object>.Enumerator)(modificationTotal6 + enumerator2);
													enumerator2 = enumerator3;
												}
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					enumerator9.Dispose();
					statModifier = statModifier4;
				}
				if (weaponStats != null)
				{
					float num2 = baseStat + (float)enumerator2;
					float num3 = (float)enumerator + 1f;
					float num4 = num2 * num3;
					float value = num4 * num;
					((Dictionary<System.Int32Enum, float>)(object)weaponStats).set_Item((System.Int32Enum)stat, value);
					Action<EStat, EWeapon> a_WeaponStatUpdate = A_WeaponStatUpdate;
					if (A_WeaponStatUpdate == null)
					{
						return;
					}
					WeaponData weaponData = this.weaponData;
					if ((object)this.weaponData != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rax_v32 (System.Action`2<Assets.Scripts.Menu.Shop.EStat, EWeapon>)+18] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		goto IL_0569;
		IL_0569:
		throw new NullReferenceException();
	}

	public unsafe float GetTestUpdateStat(EStat stat, StatModifier testUpgrade)
	{
		//IL_0644: Expected F4, but got I4
		//IL_0097: Expected F4, but got I4
		//IL_00a1: Expected F4, but got I4
		//IL_00a9: Expected F4, but got O
		//IL_00cb: Expected O, but got Ref
		//IL_00eb: Expected F4, but got O
		//IL_0234: Expected I, but got O
		//IL_0201: Expected I, but got O
		//IL_0319: Expected O, but got Ref
		//IL_01ce: Expected I, but got O
		//IL_04bd: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317277F]");
		bool flag = (nint)0 != 0;
		bool flag2 = (object)weaponData == null;
		float num = 0f;
		if (!flag2)
		{
			float baseStat = weaponData.GetBaseStat(stat);
			bool flag3 = upgrades == null;
			num = baseStat;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				float num2 = 1f;
				float num3 = 0f;
				float num4 = 0f;
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				num = (float)enumerator;
				nint num5 = 0;
				List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
				object obj = default(object);
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
				StatModifier statModifier2 = default(StatModifier);
				while (enumerator2.MoveNext())
				{
					bool flag4 = obj == null;
					StatModifier statModifier = (StatModifier)(&enumerator2);
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						num = (float)enumerator3;
						num5 = 0;
						while (enumerator4.MoveNext())
						{
							if (statModifier2 != null)
							{
								if (statModifier2.stat != stat)
								{
									continue;
								}
								if (statModifier2.modifyType != EStatModifyType.Flat)
								{
									if (statModifier2.modifyType != EStatModifyType.Addition)
									{
										if (statModifier2.modifyType == EStatModifyType.Multiplication)
										{
											float modificationTotal = statModifier2.GetModificationTotal(1);
											num = modificationTotal * num2;
											num2 = num;
											num5 = unchecked((nint)null);
										}
									}
									else
									{
										float modificationTotal2 = statModifier2.GetModificationTotal(1);
										num = modificationTotal2 + num3;
										num3 = num;
										num5 = unchecked((nint)null);
									}
								}
								else
								{
									float modificationTotal3 = statModifier2.GetModificationTotal(1);
									num = modificationTotal3 + num4;
									num4 = num;
									num5 = unchecked((nint)null);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				if (passive != null)
				{
					WeaponPassive weaponPassive = passive;
					if (weaponPassive.statModifiers == null)
					{
						goto IL_05d4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
					float num6 = default(float);
					num = num6;
					nint num7 = 0;
					Dictionary<EStat, StatModifiersContainer>.Enumerator enumerator5 = default(Dictionary<EStat, StatModifiersContainer>.Enumerator);
					StatModifiersContainer statModifiersContainer = default(StatModifiersContainer);
					IntPtr intPtr = default(IntPtr);
					object obj3 = default(object);
					StatModifier statModifier3 = default(StatModifier);
					while (enumerator5.MoveNext())
					{
						if ((nint)statModifier2 != (nint)stat)
						{
							continue;
						}
						if (statModifiersContainer != null)
						{
							IEnumerable<StatModifier> modifiers = statModifiersContainer.GetModifiers();
							if (modifiers != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								object obj2 = (object)(&intPtr);
								StatModifier statModifier = null;
								while (true)
								{
									if (intPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										if (obj3 == null)
										{
											break;
										}
										bool flag5 = intPtr == (IntPtr)0;
										statModifier = null;
										if (!flag5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
											bool flag6 = statModifier3 == null;
											statModifier = null;
											if (!flag6)
											{
												if (statModifier3.modifyType != EStatModifyType.Flat)
												{
													if (statModifier3.modifyType != EStatModifyType.Addition)
													{
														bool flag7 = statModifier3.modifyType != EStatModifyType.Multiplication;
														statModifier = null;
														if (!flag7)
														{
															float modificationTotal4 = statModifier3.GetModificationTotal(1);
															num = modificationTotal4 * num2;
															num2 = num;
														}
													}
													else
													{
														float modificationTotal5 = statModifier3.GetModificationTotal(1);
														num = modificationTotal5 + num3;
														num3 = num;
													}
												}
												else
												{
													float modificationTotal6 = statModifier3.GetModificationTotal(1);
													num = modificationTotal6 + num4;
													num4 = num;
												}
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								bool flag8 = obj2 == null;
								num7 = intPtr;
								if (!flag8)
								{
									num7 = (nint)obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				}
				if (testUpgrade != null)
				{
					if (testUpgrade.modifyType != EStatModifyType.Flat)
					{
						if (testUpgrade.modifyType != EStatModifyType.Addition)
						{
							if (testUpgrade.modifyType == EStatModifyType.Multiplication)
							{
								float modificationTotal7 = testUpgrade.GetModificationTotal(1);
								float num8 = modificationTotal7 * num2;
								num2 = num8;
							}
						}
						else
						{
							float modificationTotal8 = testUpgrade.GetModificationTotal(1);
							float num9 = modificationTotal8 + num3;
							num3 = num9;
						}
					}
					else
					{
						float modificationTotal9 = testUpgrade.GetModificationTotal(1);
						float num10 = modificationTotal9 + num4;
						num4 = num10;
					}
					float num11 = baseStat + num4;
					float num12 = num3 + 1f;
					float num13 = num11 * num12;
					return num13 * num2;
				}
			}
		}
		goto IL_05d4;
		IL_05d4:
		throw new NullReferenceException();
	}

	public float GetValue(EStat stat)
	{
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponStats).get_Item((System.Int32Enum)stat);
		if (stat == EStat.AttackSpeed)
		{
			bool flag = !(0.01f < num);
			float num2 = 0.01f;
			if (!flag)
			{
				num2 = num;
			}
			num = num2;
		}
		return num;
	}

	public void WeaponPassiveChanged(EStat stat)
	{
		UpdateStat(stat);
	}

	private float GetBaseValue(EStat stat)
	{
		return weaponData.GetBaseStat(stat);
	}

	private unsafe void ApplyStatModifier(StatModifier modifier, int amount, ref float flatValues, ref float additionValues, ref float multiplicationValues)
	{
		//IL_00b1: Expected O, but got F4
		//IL_00df: Expected Ref, but got F4
		//IL_009f: Expected O, but got F4
		//IL_0091: Expected O, but got F4
		object obj2;
		if (modifier.modifyType != EStatModifyType.Flat)
		{
			if (modifier.modifyType != EStatModifyType.Addition)
			{
				if (modifier.modifyType == EStatModifyType.Multiplication)
				{
					float modificationTotal = modifier.GetModificationTotal(amount);
					object obj = default(object);
					float num = modificationTotal * (float)obj;
					obj = num;
				}
				return;
			}
			ref float reference = default(ref float);
			obj2 = reference;
		}
		else
		{
			obj2 = flatValues;
		}
		float modificationTotal2 = modifier.GetModificationTotal(amount);
		float num2 = modificationTotal2 + (float)obj2;
		ref float reference2 = ref *(float*)num2;
	}

	private bool IsCooldown()
	{
		float weaponCooldown = WeaponUtility.GetWeaponCooldown(this);
		float num = weaponCooldown + usedWeaponAtTime;
		bool flag = num < MyTime.time;
		return !flag;
	}

	private float GetCooldown()
	{
		return WeaponUtility.GetWeaponCooldown(this);
	}
}
