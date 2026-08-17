using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Framework;

public class LimitBreakManager
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WeightedLimitBreak randomWeapon;

		internal unsafe bool _003CGetLimitBreakBonuses_003Eb__0(WeightedLimitBreak lbd)
		{
			//IL_0164: Expected I4, but got O
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected Ref, but got Unknown
			//IL_011d: Expected I8, but got I4
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected Ref, but got Unknown
			if (lbd != null)
			{
				WeightedLimitBreak weightedLimitBreak = randomWeapon;
				if (randomWeapon != null)
				{
					string id = lbd.Id;
					string id2 = weightedLimitBreak.Id;
					if ((object)lbd.Id != weightedLimitBreak.Id)
					{
						if (lbd.Id != null && weightedLimitBreak.Id != null && id._stringLength == id2._stringLength)
						{
							ref byte second = ref *(byte*)(weightedLimitBreak.Id + 20);
							ulong length = (ulong)(id._stringLength + id._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(lbd.Id + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public float r;

		internal bool _003CGetRandomWeightedWeapon_003Eb__0(WeightedLimitBreak item)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (item != null)
			{
				bool flag = (float)item.Weight < r;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private GameSessionData _gameSessionData;

	private DataManager _dataManager;

	private List<WeaponType> _excludedWeapons;

	private const int LevelUpOptions = 3;

	private const string PropNameMax = "max";

	private const string PropNameRarity = "rarity";

	public unsafe List<WeightedLimitBreak> GetLimitBreakBonuses()
	{
		//IL_01c4: Expected O, but got F4
		//IL_002f: Invalid comparison between O and F4
		//IL_004d: Invalid comparison between F4 and I4
		//IL_0076: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0092: Expected O, but got I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		List<WeightedLimitBreak> list = new List<WeightedLimitBreak>();
		object obj = UnityEngine.Random.value;
		GameSessionData gameSessionData = _gameSessionData;
		float num = gameSessionData._activeCharacter.PLuck();
		object obj2 = default(object);
		float num2 = 1f / (float)obj2;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
		float num3 = (float)obj2 - num2;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		object obj4 = obj3 + 3;
		object obj5 = 0;
		while (list._size < (nint)obj4 && (nint)obj5 < 4)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_0();
			obj5++;
			WeightedLimitBreak randomWeightedWeapon = GetRandomWeightedWeapon();
			CS_0024_003C_003E8__locals6.randomWeapon = randomWeightedWeapon;
			if (CS_0024_003C_003E8__locals6.randomWeapon == null)
			{
				continue;
			}
			WeightedLimitBreak randomWeapon = CS_0024_003C_003E8__locals6.randomWeapon;
			if (randomWeapon.WeaponType == WeaponType.VOID)
			{
				continue;
			}
			Predicate<WeightedLimitBreak> match = delegate(WeightedLimitBreak lbd)
			{
				//IL_0164: Expected I4, but got O
				//IL_0101: Unknown result type (might be due to invalid IL or missing references)
				//IL_0106: Expected Ref, but got Unknown
				//IL_011d: Expected I8, but got I4
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Expected Ref, but got Unknown
				if (lbd != null)
				{
					WeightedLimitBreak randomWeapon2 = CS_0024_003C_003E8__locals6.randomWeapon;
					if (CS_0024_003C_003E8__locals6.randomWeapon != null)
					{
						string id = lbd.Id;
						string id2 = randomWeapon2.Id;
						if ((object)lbd.Id != randomWeapon2.Id)
						{
							if (lbd.Id != null && randomWeapon2.Id != null && id._stringLength == id2._stringLength)
							{
								ref byte second = ref *(byte*)(randomWeapon2.Id + 20);
								ulong length = (ulong)(id._stringLength + id._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(lbd.Id + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			};
			WeightedLimitBreak weightedLimitBreak = list.Find(match);
			if (weightedLimitBreak == null)
			{
				WeightedLimitBreak weightedLimitBreak2 = list.Find((Predicate<WeightedLimitBreak>)(object)CS_0024_003C_003E8__locals6.randomWeapon);
			}
		}
		return list;
	}

	public unsafe WeightedLimitBreak GetRandomWeightedWeapon()
	{
		//IL_00ef: Expected I4, but got O
		//IL_0d4e: Expected O, but got Ref
		//IL_00f9: Expected I, but got O
		//IL_00fe: Expected I, but got O
		//IL_023d: Expected O, but got I4
		//IL_0e23: Expected O, but got F4
		//IL_03be: Expected I, but got O
		//IL_0bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected O, but got Unknown
		//IL_04fc: Expected I, but got O
		//IL_0501: Expected I, but got O
		//IL_0509: Expected I4, but got O
		//IL_0530: Expected O, but got I4
		//IL_0e88: Expected O, but got I
		//IL_0e90: Expected O, but got I4
		//IL_0ea0: Expected I4, but got O
		//IL_053d: Expected I, but got O
		//IL_05e4: Expected I, but got O
		//IL_0baa: Expected O, but got I4
		//IL_0637: Expected O, but got Ref
		//IL_063c: Expected I, but got O
		//IL_065b: Expected I4, but got O
		//IL_0ac5: Expected I, but got O
		//IL_0ad5: Expected I4, but got O
		//IL_06ae: Expected I4, but got O
		//IL_06b2: Expected O, but got I4
		//IL_06e4: Expected O, but got I
		//IL_084f: Expected O, but got I
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Expected Ref, but got Unknown
		//IL_07f2: Expected I8, but got I
		//IL_0814: Expected O, but got Ref
		//IL_0829: Expected O, but got Ref
		//IL_09d8: Expected O, but got I
		//IL_092f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Expected Ref, but got Unknown
		//IL_0951: Expected I8, but got I
		//IL_0973: Expected O, but got Ref
		//IL_0988: Expected O, but got Ref
		//IL_0a22: Expected O, but got I
		//IL_0d9d: Expected I, but got O
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass7_0();
		List<WeightedLimitBreak> list = new List<WeightedLimitBreak>();
		List<Weapon> list2 = new List<Weapon>();
		GameSessionData gameSessionData = _gameSessionData;
		bool flag = _gameSessionData == null;
		List<Weapon> list3 = list2;
		if (!flag)
		{
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			bool flag2 = (object)gameSessionData._activeCharacter == null;
			list3 = list2;
			if (!flag2)
			{
				CharacterWeaponsManager weaponsManager = activeCharacter._weaponsManager;
				bool flag3 = (object)activeCharacter._weaponsManager == null;
				list3 = list2;
				if (!flag3)
				{
					bool flag4 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
					list3 = list2;
					if (!flag4)
					{
						int num = (int)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
						List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
						while (enumerator.MoveNext())
						{
							nint num2 = unchecked((nint)null);
							nint num3 = unchecked((nint)null);
						}
						bool flag5 = list2 == null;
						list3 = (List<Weapon>)(&enumerator);
						if (!flag5)
						{
							List<Weapon> list4 = null;
							List<Weapon> list5 = null;
							List<Weapon> list6 = null;
							object obj = 1;
							nint num5 = default(nint);
							object obj5 = default(object);
							IEnumerable<JToken> value = default(IEnumerable<JToken>);
							IntPtr intPtr = default(IntPtr);
							object arg = default(object);
							object arg2 = default(object);
							uint limitBreakDataIndex = default(uint);
							string id = default(string);
							while (true)
							{
								nint num6;
								int num7;
								if ((nint)list4 < list2._size)
								{
									if ((nint)list4 < list2._size)
									{
										Weapon[] items = list2._items;
										bool flag6 = list2._items == null;
										list3 = list4;
										if (flag6)
										{
											break;
										}
										bool flag7 = (nint)list4 >= items.Length;
										list3 = list4;
										if (!flag7)
										{
											Weapon weapon = items[(object)list4];
											bool flag8 = (object)items[(object)list4] == null;
											list3 = list4;
											if (flag8)
											{
												break;
											}
											JObject jObject = JObject.FromObject(weapon._currentWeaponData);
											list3 = (List<Weapon>)(object)_excludedWeapons;
											if (_excludedWeapons == null)
											{
												break;
											}
											nint num3;
											if (list3._size != 0)
											{
												num = list3._size;
												list3 = (List<Weapon>)(object)list3._items;
												int num4 = ((Dictionary<WeaponType, JArray>)(object)list3._items).FindEntry(((Equipment)weapon)._equipmentType);
												bool flag9 = num4 != -1;
												num5 = 0;
												num6 = 0;
												num3 = unchecked((nint)null);
												num7 = list3._size;
												if (flag9)
												{
													goto IL_0bc4;
												}
											}
											DataManager dataManager = _dataManager;
											if (_dataManager == null)
											{
												break;
											}
											bool flag10 = dataManager._003CAllLimitBreakData_003Ek__BackingField == null;
											if (flag10)
											{
												break;
											}
											int num8 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField).FindEntry((System.Int32Enum)((Equipment)weapon)._equipmentType);
											num6 = num5;
											num3 = 0;
											num7 = num;
											if (!flag10)
											{
												object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField).get_Item((System.Int32Enum)((Equipment)weapon)._equipmentType);
												bool flag11 = obj2 == null;
												num6 = num5;
												num3 = 0;
												num7 = num;
												if (!flag11)
												{
													int count = ((JContainer)obj2).Count;
													bool flag12 = count == 0;
													num6 = num5;
													num3 = 0;
													num7 = num;
													if (!flag12)
													{
														nint num9 = (nint)list5;
														nint num10 = unchecked((nint)null);
														int num11 = (int)list6;
														object obj3 = obj2;
														Weapon weapon2 = items[(object)list4];
														num3 = 0;
														LimitBreakData limitBreakData = (LimitBreakData)num;
														while (true)
														{
															int count2 = ((JContainer)obj3).Count;
															bool flag13 = num10 >= count2;
															list5 = (List<Weapon>)num9;
															list6 = (List<Weapon>)num11;
															num6 = num5;
															num7 = (int)limitBreakData;
															if (flag13)
															{
																break;
															}
															nint num12 = (nint)obj3;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1751 @ r8_v26 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
															object obj4 = obj5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1754 @ r8_v28+210]");
															num3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1754 @ r8_v28+208] (should have been resolved before IL gen)");
															object obj6 = Extensions.Value<object>(value);
															if (obj6 != null)
															{
																object obj7 = ((JToken)obj6).ToObject<object>();
																if (obj7 != null)
																{
																	bool flag14 = ((JObject)obj6).ContainsKey("max");
																	bool flag15 = !flag14;
																	num3 = unchecked((nint)null);
																	nint num13;
																	object obj9;
																	if (!flag15)
																	{
																		JToken jToken = ((JObject)obj6).get_Item("max");
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																		IEnumerable<JProperty> enumerable = ((JObject)obj6).Properties();
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																		object obj8 = (object)(&intPtr);
																		num13 = unchecked((nint)null);
																		obj9 = null;
																		list3 = null;
																		while (true)
																		{
																			if (intPtr != (IntPtr)0)
																			{
																				if (((Dictionary<WeaponType, JArray>)null).FindEntry((WeaponType)typeof(IEnumerator)) == 0)
																				{
																					break;
																				}
																				bool flag16 = intPtr == (IntPtr)0;
																				list3 = null;
																				if (!flag16)
																				{
																					WeightedLimitBreak weightedLimitBreak = (WeightedLimitBreak)((Dictionary<WeaponType, JArray>)null).FindEntry((WeaponType)typeof(IEnumerator));
																					bool flag17 = weightedLimitBreak == null;
																					list3 = null;
																					if (!flag17)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																						object obj10 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																						bool flag18 = (nint)0 == 0;
																						list3 = null;
																						if (!flag18)
																						{
																							object obj11 = "max";
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																							bool flag19 = 0 == unchecked((nint)"max");
																							list3 = null;
																							if (flag19)
																							{
																								continue;
																							}
																							bool flag20 = "max" == null;
																							LimitBreakData limitBreakData2 = limitBreakData;
																							List<Weapon> list7 = null;
																							bool flag21 = flag13;
																							if (!flag20)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ r8_v42+10]");
																								nint num14 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rdx_v53+10]");
																								flag21 = num14 != 0;
																								limitBreakData2 = limitBreakData;
																								list7 = null;
																								if (!flag21)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																									ref byte reference = ref *(byte*)((nint)0 + (nint)20);
																									ref byte second = ref *(byte*)("max" + 20);
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ r8_v42+10]");
																									nint num15 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ r8_v42+10]");
																									ulong length = (ulong)(num15 + 0);
																									bool flag22 = System.SpanHelpers.SequenceEqual(ref reference, ref second, length);
																									limitBreakData2 = null;
																									list7 = (List<Weapon>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
																									flag21 = flag22;
																									limitBreakData = null;
																									list3 = (List<Weapon>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
																									flag13 = flag22;
																									if (flag22)
																									{
																										continue;
																									}
																								}
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																							object obj12 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																							bool flag23 = (nint)0 == 0;
																							list3 = list7;
																							if (!flag23)
																							{
																								object obj13 = "rarity";
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																								bool flag24 = 0 == unchecked((nint)"rarity");
																								limitBreakData = limitBreakData2;
																								list3 = list7;
																								flag13 = flag21;
																								if (flag24)
																								{
																									continue;
																								}
																								if ("rarity" != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ r8_v44+10]");
																									nint num16 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1892 @ rdx_v55+10]");
																									flag21 = num16 != 0;
																									if (!flag21)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																										ref byte reference2 = ref *(byte*)((nint)0 + (nint)20);
																										ref byte second2 = ref *(byte*)("rarity" + 20);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ r8_v44+10]");
																										nint num17 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ r8_v44+10]");
																										ulong length2 = (ulong)(num17 + 0);
																										bool flag25 = System.SpanHelpers.SequenceEqual(ref reference2, ref second2, length2);
																										limitBreakData2 = null;
																										list7 = (List<Weapon>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2);
																										flag21 = flag25;
																										limitBreakData = null;
																										list3 = (List<Weapon>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2);
																										flag13 = flag25;
																										if (flag25)
																										{
																											continue;
																										}
																									}
																								}
																								bool flag26 = jObject == null;
																								list3 = list7;
																								if (!flag26)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																									bool flag27 = jObject.ContainsKey((string)0);
																									bool flag28 = !flag27;
																									limitBreakData = limitBreakData2;
																									list3 = (List<Weapon>)(object)jObject;
																									flag13 = flag21;
																									if (flag28)
																									{
																										continue;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (VampireSurvivors.Framework.WeightedLimitBreak)+60]");
																									JToken jToken2 = jObject.get_Item((string)0);
																									bool flag29 = jToken2 == null;
																									limitBreakData = limitBreakData2;
																									list3 = (List<Weapon>)(object)jObject;
																									flag13 = flag21;
																									if (!flag29)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																										List<Equipment> list8 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
																										List<Equipment> list9 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
																										flag13 = System.Runtime.CompilerServices.Unsafe.As<List<Equipment>, UIntPtr>(ref list8) < System.Runtime.CompilerServices.Unsafe.As<List<Equipment>, UIntPtr>(ref list9);
																										if (!flag13)
																										{
																											obj9 = obj;
																										}
																										num13 = (nint)obj9;
																										limitBreakData = limitBreakData2;
																										list3 = (List<Weapon>)(object)jToken2;
																									}
																									continue;
																								}
																								throw new NullReferenceException();
																							}
																							throw new NullReferenceException();
																						}
																						throw new NullReferenceException();
																					}
																					throw new NullReferenceException();
																				}
																				throw new NullReferenceException();
																			}
																			throw new NullReferenceException();
																		}
																		bool flag30 = obj8 == null;
																		num3 = intPtr;
																		if (!flag30)
																		{
																			num3 = (nint)obj8;
																			int num18 = ((Dictionary<WeaponType, JArray>)null).FindEntry((WeaponType)typeof(IDisposable));
																		}
																		bool flag31 = obj9 == null;
																		num9 = intPtr;
																		if (!flag31)
																		{
																			num9 = intPtr;
																			goto IL_0ddb;
																		}
																	}
																	int num19 = num11;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1774 @ rax_v75 (System.Object)+10]");
																	int num20 = (int)((nint)num19 + (nint)0);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																	string text = $"{arg}-{arg2}";
																	WeightedLimitBreak weightedLimitBreak2 = new WeightedLimitBreak(((Equipment)weapon2)._equipmentType, num20, (LimitBreakData)obj7, limitBreakDataIndex, id);
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A70");
																	num13 = num10;
																	obj9 = obj7;
																	num11 = num20;
																	num5 = num10;
																	weapon2 = items[(object)list4];
																	obj = 1;
																	num3 = num20;
																	limitBreakData = (LimitBreakData)obj7;
																}
															}
															goto IL_0ddb;
															IL_0ddb:
															num10++;
															obj3 = obj2;
														}
													}
												}
											}
											goto IL_0bc4;
										}
									}
									else
									{
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									}
									throw new IndexOutOfRangeException();
								}
								object obj14 = UnityEngine.Random.value;
								if (CS_0024_003C_003E8__locals3 == null)
								{
									break;
								}
								float r = (float)list6 * (float)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
								CS_0024_003C_003E8__locals3.r = r;
								Predicate<WeightedLimitBreak> match = delegate(WeightedLimitBreak item)
								{
									//IL_0050: Expected I4, but got O
									//IL_002c: Invalid comparison between I4 and F4
									if (item == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									bool flag32 = (float)item.Weight < CS_0024_003C_003E8__locals3.r;
									return !flag32;
								};
								if (list == null)
								{
									break;
								}
								return list.Find(match);
								IL_0bc4:
								list4 = (List<Weapon>)(list4 + 1);
								num5 = num6;
								num = num7;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe bool HasLimitBreaks()
	{
		//IL_0044: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_0b8d: Expected O, but got I4
		//IL_0b96: Expected O, but got I4
		//IL_0ba0: Expected O, but got Ref
		//IL_0bad: Expected O, but got Ref
		//IL_00b1: Expected O, but got I4
		//IL_0bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Expected O, but got Unknown
		//IL_0497: Expected O, but got I4
		//IL_04a4: Expected I, but got O
		//IL_04eb: Expected O, but got I
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5e: Expected O, but got Unknown
		//IL_05d9: Expected O, but got Ref
		//IL_0668: Expected O, but got I
		//IL_07d3: Expected O, but got I
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected Ref, but got Unknown
		//IL_0776: Expected I8, but got I
		//IL_0798: Expected O, but got Ref
		//IL_07ad: Expected O, but got Ref
		//IL_095c: Expected O, but got I
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Expected Ref, but got Unknown
		//IL_08d5: Expected I8, but got I
		//IL_08f7: Expected O, but got Ref
		//IL_090c: Expected O, but got Ref
		List<Weapon> list = new List<Weapon>();
		JObject gameSessionData = (JObject)(object)_gameSessionData;
		if (_gameSessionData != null)
		{
			gameSessionData = (JObject)((JToken)gameSessionData)._parent;
			if (((JToken)gameSessionData)._parent != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v25 (Newtonsoft.Json.Linq.JObject)+C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v25 (Newtonsoft.Json.Linq.JObject)+C0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v11+28]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v11+28]");
						JToken jToken = (JToken)0;
						List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
						while (enumerator.MoveNext())
						{
							object obj2 = 0;
						}
						bool flag = list == null;
						object obj3 = 0;
						object obj4 = 0;
						JObject jObject = (JObject)(&enumerator);
						LimitBreakManager limitBreakManager = this;
						gameSessionData = (JObject)(&enumerator);
						if (!flag)
						{
							object obj5 = default(object);
							nint num = default(nint);
							nint num2 = default(nint);
							object obj8 = default(object);
							IEnumerable<JToken> value = default(IEnumerable<JToken>);
							object obj13 = default(object);
							Dictionary<System.Int32Enum, object> dictionary = default(Dictionary<System.Int32Enum, object>);
							bool result = default(bool);
							while (true)
							{
								nint num3;
								nint num4;
								JToken jToken2;
								if ((nint)obj3 < list._size)
								{
									if ((nint)obj3 < list._size)
									{
										Weapon[] items = list._items;
										bool flag2 = list._items == null;
										gameSessionData = jObject;
										if (flag2)
										{
											break;
										}
										bool flag3 = (nint)obj3 >= items.Length;
										gameSessionData = jObject;
										if (!flag3)
										{
											Weapon weapon = items[obj3];
											bool flag4 = (object)items[obj3] == null;
											gameSessionData = jObject;
											if (flag4)
											{
												break;
											}
											JObject jObject2 = JObject.FromObject(weapon._currentWeaponData);
											gameSessionData = (JObject)(object)limitBreakManager._excludedWeapons;
											if (limitBreakManager._excludedWeapons == null)
											{
												break;
											}
											if (((JToken)gameSessionData)._previous != null)
											{
												jToken = ((JToken)gameSessionData)._previous;
												gameSessionData = (JObject)((JToken)gameSessionData)._parent;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
												bool flag5 = (nint)obj5 != -1;
												num = 0;
												num2 = 0;
												num3 = 0;
												num4 = 0;
												jToken2 = ((JToken)gameSessionData)._previous;
												jObject = (JObject)((JToken)gameSessionData)._parent;
												if (flag5)
												{
													goto IL_0bd0;
												}
											}
											DataManager dataManager = limitBreakManager._dataManager;
											if (limitBreakManager._dataManager == null)
											{
												break;
											}
											bool flag6 = dataManager._003CAllLimitBreakData_003Ek__BackingField == null;
											if (flag6)
											{
												break;
											}
											int num5 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField).FindEntry((System.Int32Enum)((Equipment)weapon)._equipmentType);
											jObject = (JObject)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField;
											if (!flag6)
											{
												object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField).get_Item((System.Int32Enum)((Equipment)weapon)._equipmentType);
												bool flag7 = obj6 == null;
												jObject = (JObject)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField;
												if (!flag7)
												{
													int count = ((JContainer)obj6).Count;
													bool flag8 = count == 0;
													jObject = (JObject)obj6;
													if (!flag8)
													{
														object obj7 = 0;
														while (true)
														{
															int count2 = ((JContainer)obj6).Count;
															bool flag9 = (nint)obj7 >= count2;
															jObject = (JObject)obj6;
															if (flag9)
															{
																break;
															}
															nint num6 = (nint)obj6;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1297 @ r8_v22 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
															bool flag10 = obj8 == null;
															gameSessionData = (JObject)obj6;
															if (flag10)
															{
																goto end_IL_01d0;
															}
															object obj9 = obj8;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ r8_v24+208]");
															jToken = (JToken)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1299 @ r8_v24+208] (should have been resolved before IL gen)");
															object obj10 = Extensions.Value<object>(value);
															if (obj10 == null)
															{
																goto IL_0a50;
															}
															object obj11 = ((JToken)obj10).ToObject<object>();
															if (obj11 == null)
															{
																goto IL_0a50;
															}
															object obj12;
															if (((JObject)obj10).ContainsKey("max"))
															{
																JToken jToken3 = ((JObject)obj10).get_Item("max");
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																IEnumerable<JProperty> enumerable = ((JObject)obj10).Properties();
																bool flag11 = enumerable == null;
																gameSessionData = (JObject)obj10;
																if (flag11)
																{
																	goto end_IL_01d0;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																obj12 = (object)(&obj4);
																gameSessionData = null;
																while (true)
																{
																	if (obj4 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																		if (obj13 == null)
																		{
																			break;
																		}
																		bool flag12 = obj4 == null;
																		gameSessionData = null;
																		if (!flag12)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2430");
																			bool flag13 = dictionary == null;
																			gameSessionData = null;
																			if (!flag13)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																				object obj14 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																				bool flag14 = (nint)0 == 0;
																				gameSessionData = null;
																				if (!flag14)
																				{
																					object obj15 = "max";
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																					bool flag15 = 0 == unchecked((nint)"max");
																					gameSessionData = null;
																					if (flag15)
																					{
																						continue;
																					}
																					bool flag16 = "max" == null;
																					JToken jToken4 = jToken;
																					JObject jObject3 = null;
																					bool flag17 = flag9;
																					if (!flag16)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v36+10]");
																						nint num7 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rdx_v40+10]");
																						flag17 = num7 != 0;
																						jToken4 = jToken;
																						jObject3 = null;
																						if (!flag17)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																							ref byte reference = ref *(byte*)((nint)0 + (nint)20);
																							ref byte second = ref *(byte*)("max" + 20);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v36+10]");
																							nint num8 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v36+10]");
																							ulong length = (ulong)(num8 + 0);
																							bool flag18 = System.SpanHelpers.SequenceEqual(ref reference, ref second, length);
																							jToken4 = null;
																							jObject3 = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
																							flag17 = flag18;
																							jToken = null;
																							gameSessionData = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
																							flag9 = flag18;
																							if (flag18)
																							{
																								continue;
																							}
																						}
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																					object obj16 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																					bool flag19 = (nint)0 == 0;
																					gameSessionData = jObject3;
																					if (!flag19)
																					{
																						object obj17 = "rarity";
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																						bool flag20 = 0 == unchecked((nint)"rarity");
																						jToken = jToken4;
																						gameSessionData = jObject3;
																						flag9 = flag17;
																						if (flag20)
																						{
																							continue;
																						}
																						if ("rarity" != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r8_v38+10]");
																							nint num9 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1392 @ rdx_v42+10]");
																							flag17 = num9 != 0;
																							if (!flag17)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																								ref byte reference2 = ref *(byte*)((nint)0 + (nint)20);
																								ref byte second2 = ref *(byte*)("rarity" + 20);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r8_v38+10]");
																								nint num10 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ r8_v38+10]");
																								ulong length2 = (ulong)(num10 + 0);
																								bool flag21 = System.SpanHelpers.SequenceEqual(ref reference2, ref second2, length2);
																								jToken4 = null;
																								jObject3 = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2);
																								flag17 = flag21;
																								jToken = null;
																								gameSessionData = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2);
																								flag9 = flag21;
																								if (flag21)
																								{
																									continue;
																								}
																							}
																						}
																						bool flag22 = jObject2 == null;
																						gameSessionData = jObject3;
																						if (!flag22)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v66 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+60]");
																							JToken jToken5 = jObject2.get_Item((string)0);
																							bool flag23 = jToken5 == null;
																							jToken = jToken4;
																							gameSessionData = jObject2;
																							flag9 = flag17;
																							if (flag23)
																							{
																								continue;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v11+28]");
																							nint num11 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r9_v11+28]");
																							flag9 = num11 <= 0;
																							jToken = jToken4;
																							gameSessionData = (JObject)jToken5;
																							if (flag9)
																							{
																								continue;
																							}
																							goto IL_09de;
																						}
																						throw new NullReferenceException();
																					}
																					throw new NullReferenceException();
																				}
																				throw new NullReferenceException();
																			}
																			throw new NullReferenceException();
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																if (obj12 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
																}
																goto IL_0a50;
															}
															goto IL_0a42;
															IL_0a42:
															return true;
															IL_09de:
															if (obj12 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
															}
															goto IL_0a42;
															IL_0a50:
															obj7++;
														}
													}
												}
											}
											num3 = num;
											num4 = num2;
											jToken2 = jToken;
											limitBreakManager = this;
											goto IL_0bd0;
										}
										throw new IndexOutOfRangeException();
									}
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									return result;
								}
								return false;
								IL_0bd0:
								obj3++;
								num = num3;
								num2 = num4;
								jToken = jToken2;
								continue;
								end_IL_01d0:
								break;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private int GetLevelUpOptions()
	{
		//IL_0092: Expected O, but got F4
		//IL_002f: Invalid comparison between O and F4
		//IL_004d: Invalid comparison between F4 and I4
		//IL_0076: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected I4, but got Unknown
		object obj = UnityEngine.Random.value;
		GameSessionData gameSessionData = _gameSessionData;
		float num = gameSessionData._activeCharacter.PLuck();
		object obj2 = default(object);
		float num2 = 1f / (float)obj2;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
		float num3 = (float)obj2 - num2;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		return obj3 + 3;
	}

	public LimitBreakManager()
	{
		List<WeaponType> excludedWeapons = new List<WeaponType>();
		_excludedWeapons = excludedWeapons;
	}
}
