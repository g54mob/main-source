using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Achievements;

public static class AchivementManagerSupport
{
	public static bool HasAlreadyUnlocked(AchievementType t, PlayerOptionsData config)
	{
		//IL_0044: Expected I4, but got O
		if (config != null && config._003CAchievements_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static int GetPlayerWeaponLevel(CharacterController character, WeaponType t, bool checkRemovedEquipment = true, bool checkHiddenEquipment = false)
	{
		//IL_05c7: Expected O, but got Ref
		//IL_0074: Expected O, but got I4
		//IL_007c: Expected O, but got Ref
		//IL_00de: Expected O, but got Ref
		//IL_0626: Expected O, but got Ref
		//IL_00fa: Expected O, but got I4
		//IL_0102: Expected O, but got Ref
		//IL_0171: Expected O, but got Ref
		//IL_019b: Expected O, but got Ref
		//IL_051e: Expected I4, but got I8
		//IL_0407: Expected I, but got O
		//IL_0415: Expected I, but got O
		//IL_0425: Expected O, but got I
		//IL_04a5: Expected O, but got I4
		//IL_0461: Expected O, but got I
		//IL_069b: Expected O, but got Ref
		//IL_01b7: Expected O, but got I4
		//IL_01bf: Expected O, but got Ref
		//IL_0497: Expected O, but got I4
		//IL_0757: Expected O, but got Ref
		//IL_02f2: Expected O, but got I4
		//IL_02fa: Expected O, but got Ref
		//IL_0221: Expected O, but got Ref
		//IL_035c: Expected O, but got Ref
		//IL_028e: Expected O, but got Ref
		//IL_023d: Expected O, but got I4
		//IL_0245: Expected O, but got Ref
		//IL_0378: Expected O, but got I4
		//IL_0380: Expected O, but got Ref
		CharacterController characterController = default(CharacterController);
		bool flag = (object)characterController == null;
		CharacterController characterController2 = characterController;
		List<Equipment>.Enumerator enumerator2;
		if (!flag)
		{
			CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
			bool flag2 = (object)characterController._weaponsManager == null;
			characterController2 = characterController;
			if (!flag2)
			{
				bool flag3 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
				characterController2 = characterController;
				if (!flag3)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj = 0;
						enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
					bool flag4 = (object)characterController._accessoriesManager == null;
					characterController2 = (CharacterController)(&enumerator);
					if (!flag4)
					{
						bool flag5 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
						characterController2 = (CharacterController)(&enumerator);
						if (!flag5)
						{
							List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
							if (enumerator3.MoveNext())
							{
								object obj2 = 0;
								List<Equipment>.Enumerator enumerator4 = (List<Equipment>.Enumerator)(&enumerator3);
								throw new NullReferenceException();
							}
							bool flag6 = !checkRemovedEquipment;
							characterController2 = (CharacterController)(&enumerator3);
							if (flag6)
							{
								goto IL_06df;
							}
							CharacterWeaponsManager weaponsManager2 = characterController._weaponsManager;
							bool flag7 = (object)characterController._weaponsManager == null;
							characterController2 = (CharacterController)(&enumerator3);
							if (!flag7)
							{
								bool flag8 = ((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField == null;
								characterController2 = (CharacterController)(&enumerator3);
								if (!flag8)
								{
									List<Equipment>.Enumerator enumerator5 = default(List<Equipment>.Enumerator);
									if (enumerator5.MoveNext())
									{
										object obj3 = 0;
										List<Equipment>.Enumerator enumerator6 = (List<Equipment>.Enumerator)(&enumerator5);
										throw new NullReferenceException();
									}
									CharacterAccessoriesManager accessoriesManager2 = characterController._accessoriesManager;
									bool flag9 = (object)characterController._accessoriesManager == null;
									characterController2 = (CharacterController)(&enumerator5);
									if (!flag9)
									{
										bool flag10 = ((EquipmentManager)accessoriesManager2)._003CRemovedEquipment_003Ek__BackingField == null;
										characterController2 = (CharacterController)(&enumerator5);
										if (!flag10)
										{
											List<Equipment>.Enumerator enumerator7 = default(List<Equipment>.Enumerator);
											if (enumerator7.MoveNext())
											{
												object obj4 = 0;
												List<Equipment>.Enumerator enumerator8 = (List<Equipment>.Enumerator)(&enumerator7);
												throw new NullReferenceException();
											}
											characterController2 = (CharacterController)(&enumerator7);
											goto IL_06df;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_051e;
		IL_079b:
		bool flag11 = (object)characterController._weaponsManager == null;
		characterController2 = (CharacterController)(object)characterController._weaponsManager;
		if (flag11)
		{
			goto IL_051e;
		}
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.TP_ALUCARDSHIELD);
		if ((object)weaponByType == null)
		{
			goto IL_0514;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(TP_AlucardShield_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1198 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardShield_Weapon>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1198 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardShield_Weapon>)+130]");
		object obj7;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1282 @ rcx_v25+FFFFFFF8+v1199 @ rcx_v20*8]");
			if (0 == (nint)typeof(TP_AlucardShield_Weapon))
			{
				obj7 = 1;
				goto IL_07ca;
			}
		}
		obj7 = 0;
		goto IL_07ca;
		IL_0514:
		return -1;
		IL_06df:
		if (checkHiddenEquipment)
		{
			CharacterWeaponsManager weaponsManager3 = characterController._weaponsManager;
			if ((object)characterController._weaponsManager != null && ((EquipmentManager)weaponsManager3)._003CHiddenEquipment_003Ek__BackingField != null)
			{
				List<Equipment>.Enumerator enumerator9 = default(List<Equipment>.Enumerator);
				if (enumerator9.MoveNext())
				{
					object obj8 = 0;
					List<Equipment>.Enumerator enumerator10 = (List<Equipment>.Enumerator)(&enumerator9);
					throw new NullReferenceException();
				}
				CharacterAccessoriesManager accessoriesManager3 = characterController._accessoriesManager;
				bool flag12 = (object)characterController._accessoriesManager == null;
				characterController2 = (CharacterController)(&enumerator9);
				if (!flag12)
				{
					bool flag13 = ((EquipmentManager)accessoriesManager3)._003CHiddenEquipment_003Ek__BackingField == null;
					characterController2 = (CharacterController)(&enumerator9);
					if (!flag13)
					{
						List<Equipment>.Enumerator enumerator11 = default(List<Equipment>.Enumerator);
						if (enumerator11.MoveNext())
						{
							object obj9 = 0;
							List<Equipment>.Enumerator enumerator12 = (List<Equipment>.Enumerator)(&enumerator11);
							throw new NullReferenceException();
						}
						goto IL_079b;
					}
				}
			}
			goto IL_051e;
		}
		goto IL_079b;
		IL_051e:
		enumerator2 = (List<Equipment>.Enumerator)characterController2;
		throw new NullReferenceException();
		IL_07ca:
		bool flag14 = obj7 == null;
		Weapon weapon = null;
		if (!flag14)
		{
			weapon = weaponByType;
		}
		if ((object)weapon == null || !((TP_AlucardShield_Weapon)weapon).TryGetWeaponHiddenByShield(t, out Equipment weapon2))
		{
			goto IL_0514;
		}
		bool flag15 = (object)weapon2 == null;
		characterController2 = (CharacterController)(object)weapon;
		if (!flag15)
		{
			return weapon2._003CLevel_003Ek__BackingField;
		}
		goto IL_051e;
	}

	public static int CalcualteNewCollectionCount(DataManager _dataManager, PlayerOptions _playerOptions)
	{
		//IL_0851: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_0280: Expected O, but got I
		//IL_07a8: Expected I, but got O
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0459: Expected O, but got I
		//IL_07f3: Expected I, but got O
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		PlayerOptionsData config = _playerOptions.Config;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_-F8_v28+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_-F8_v28+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_-F8_v28+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						bool flag = convertedWeapons == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdi_v37+20+v360 @ stack_-F0_v27*4]");
						int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
						obj4 = obj6;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdi_v37+20+v778 @ rcx_v88*4]");
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
							List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdi_v37+20+v778 @ rcx_v88*4]");
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
							List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj8).get_Item(WeaponType.VOID);
							list2._items = null;
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		PlayerOptions playerOptions = (PlayerOptions)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_-F8_v28+1C]");
			if (obj2 == null)
			{
				if (_playerOptions._onlineClientWithRunDataConfig == null && _playerOptions._hostGameConfig == null && _playerOptions._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = _playerOptions._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
					}
				}
				object obj9 = default(object);
				object obj10 = default(object);
				object obj12 = default(object);
				while (true)
				{
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-130_v29+1C]");
						if (obj10 == null)
						{
							object obj11 = obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-130_v29+18]");
							if ((nint)obj11 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-130_v29+10]");
								object obj13 = 0;
								object obj14 = obj12 + 1;
								bool flag3 = _dataManager._003CAllItems_003Ek__BackingField == null;
								Dictionary<ItemType, ItemData> dictionary = _dataManager._003CAllItems_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rdx_v60+20+v1160 @ stack_-128_v27*4]");
								int num2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
								obj12 = obj14;
								if (!flag3)
								{
									Dictionary<ItemType, ItemData> dictionary2 = _dataManager._003CAllItems_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rdx_v60+20+v1326 @ rcx_v79*4]");
									object obj15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
									_ = 1;
									obj12 = obj14;
								}
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag4 = obj9 == null;
				nint num3 = 0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-130_v29+1C]");
					if (obj10 == null)
					{
						if (_playerOptions._onlineClientWithRunDataConfig == null)
						{
							if (_playerOptions._hostGameConfig == null)
							{
								PlayerOptionsData currentAdventureSaveData2;
								if (_playerOptions._currentAdventureSaveData != null)
								{
									currentAdventureSaveData2 = _playerOptions._currentAdventureSaveData;
									if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_08c1;
									}
								}
								currentAdventureSaveData2 = _playerOptions._mainGameConfig;
							}
							else
							{
								PlayerOptionsData currentAdventureSaveData2 = _playerOptions._hostGameConfig;
							}
						}
						else
						{
							PlayerOptionsData currentAdventureSaveData2 = _playerOptions._onlineClientWithRunDataConfig;
						}
						goto IL_08c1;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num3 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			playerOptions = null;
		}
		throw new NullReferenceException();
		IL_08c1:
		object obj16 = default(object);
		object obj17 = default(object);
		object obj19 = default(object);
		while (true)
		{
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-118_v29+1C]");
				if (obj17 == null)
				{
					object obj18 = obj19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-118_v29+18]");
					if ((nint)obj18 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-118_v29+10]");
						object obj20 = 0;
						object obj21 = obj19 + 1;
						bool flag5 = _dataManager._003CAllArcanas_003Ek__BackingField == null;
						Dictionary<ArcanaType, ArcanaData> dictionary3 = _dataManager._003CAllArcanas_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1757 @ rdx_v55+20+v1731 @ stack_-110_v27*4]");
						int num4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary3).FindEntry((System.Int32Enum)0);
						obj19 = obj21;
						if (!flag5)
						{
							Dictionary<ArcanaType, ArcanaData> dictionary4 = _dataManager._003CAllArcanas_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1757 @ rdx_v55+20+v1976 @ rcx_v70*4]");
							object obj22 = ((Dictionary<System.Int32Enum, object>)(object)dictionary4).get_Item((System.Int32Enum)0);
							_ = 1;
							obj19 = obj21;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag6 = obj16 == null;
		nint num5 = 0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-118_v29+1C]");
			if (obj17 == null)
			{
				int num6 = 0;
				Dictionary<ItemType, ItemData>.Enumerator enumerator = default(Dictionary<ItemType, ItemData>.Enumerator);
				object obj23 = default(object);
				while (enumerator.MoveNext())
				{
					if (obj23 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2864 @ stack_-C8+55]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2864 @ stack_-C8+56]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2864 @ stack_-C8+51]");
							bool flag7 = (nint)0 == 0;
							bool flag8 = !flag7;
							num6 += (flag8 ? 1 : 0);
						}
					}
				}
				Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
				object obj24 = default(object);
				IntPtr intPtr = default(IntPtr);
				while (enumerator2.MoveNext())
				{
					if (obj24 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (intPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ rax_v121 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>+Enumerator<VampireSurvivors.Data.ArcanaType>>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ rax_v121 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>+Enumerator<VampireSurvivors.Data.ArcanaType>>)+11]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ rax_v121 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>+Enumerator<VampireSurvivors.Data.ArcanaType>>)+E0]");
								bool flag9 = (nint)0 == 0;
								bool flag10 = !flag9;
								num6 += (flag10 ? 1 : 0);
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator3 = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
				object obj25 = default(object);
				while (enumerator3.MoveNext())
				{
					if (obj25 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3147 @ stack_-78+4B]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3147 @ stack_-78+4A]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3147 @ stack_-78+49]");
							bool flag11 = (nint)0 == 0;
							bool flag12 = !flag11;
							num6 += (flag12 ? 1 : 0);
						}
					}
				}
				return num6;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num5 = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	public unsafe static Equipment GetPlayerEquipment(CharacterController character, WeaponType t, bool checkRemovedEquipment = false)
	{
		//IL_02f1: Expected O, but got Ref
		//IL_0078: Expected O, but got Ref
		//IL_00cc: Expected O, but got Ref
		//IL_00ec: Expected O, but got Ref
		//IL_014d: Expected O, but got Ref
		//IL_0177: Expected O, but got Ref
		//IL_03ad: Expected O, but got Ref
		//IL_0197: Expected O, but got Ref
		//IL_01eb: Expected O, but got Ref
		//IL_020b: Expected O, but got Ref
		CharacterController characterController = default(CharacterController);
		bool flag = (object)characterController == null;
		CharacterController characterController2 = characterController;
		List<Equipment>.Enumerator enumerator2;
		if (!flag)
		{
			CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
			bool flag2 = (object)characterController._weaponsManager == null;
			characterController2 = characterController;
			if (!flag2)
			{
				bool flag3 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
				characterController2 = characterController;
				if (!flag3)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					if (enumerator.MoveNext())
					{
						Equipment equipment = null;
						enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
					bool flag4 = (object)characterController._accessoriesManager == null;
					characterController2 = (CharacterController)(&enumerator);
					if (!flag4)
					{
						bool flag5 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
						characterController2 = (CharacterController)(&enumerator);
						if (!flag5)
						{
							List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
							if (enumerator3.MoveNext())
							{
								Equipment equipment2 = null;
								List<Equipment>.Enumerator enumerator4 = (List<Equipment>.Enumerator)(&enumerator3);
								throw new NullReferenceException();
							}
							if (!checkRemovedEquipment)
							{
								goto IL_0243;
							}
							CharacterWeaponsManager weaponsManager2 = characterController._weaponsManager;
							bool flag6 = (object)characterController._weaponsManager == null;
							characterController2 = (CharacterController)(&enumerator3);
							if (!flag6)
							{
								bool flag7 = ((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField == null;
								characterController2 = (CharacterController)(&enumerator3);
								if (!flag7)
								{
									List<Equipment>.Enumerator enumerator5 = default(List<Equipment>.Enumerator);
									if (enumerator5.MoveNext())
									{
										Equipment equipment3 = null;
										List<Equipment>.Enumerator enumerator6 = (List<Equipment>.Enumerator)(&enumerator5);
										throw new NullReferenceException();
									}
									CharacterAccessoriesManager accessoriesManager2 = characterController._accessoriesManager;
									bool flag8 = (object)characterController._accessoriesManager == null;
									characterController2 = (CharacterController)(&enumerator5);
									if (!flag8)
									{
										bool flag9 = ((EquipmentManager)accessoriesManager2)._003CRemovedEquipment_003Ek__BackingField == null;
										characterController2 = (CharacterController)(&enumerator5);
										if (!flag9)
										{
											List<Equipment>.Enumerator enumerator7 = default(List<Equipment>.Enumerator);
											if (enumerator7.MoveNext())
											{
												Equipment equipment4 = null;
												List<Equipment>.Enumerator enumerator8 = (List<Equipment>.Enumerator)(&enumerator7);
												throw new NullReferenceException();
											}
											goto IL_0243;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		enumerator2 = (List<Equipment>.Enumerator)characterController2;
		throw new NullReferenceException();
		IL_0243:
		return null;
	}
}
