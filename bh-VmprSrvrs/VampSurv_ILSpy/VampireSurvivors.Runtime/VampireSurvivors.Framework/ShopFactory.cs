using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Framework;

public class ShopFactory
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public WeaponType t;

		internal bool _003CDoesPlayerAlreadyHaveWeapon_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private List<WeaponType> _availableWeapons;

	private List<ItemType> _availableItems;

	public List<WeaponType> AvailableWeapons => _availableWeapons;

	public List<ItemType> AvailableItems => _availableItems;

	public void GenerateShopInventory(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		List<WeaponType> availableWeapons = _availableWeapons;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<ItemType> availableItems = _availableItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			PickupCustomMerchant pickupCustomMerchant = core._003CCurrentCustomMerchant_003Ek__BackingField;
			if ((object)core._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				if (core2._003CMerchantInventory_003Ek__BackingField == MerchantInventoryType.ADVENTURES)
				{
					List<System.Int32Enum> availableWeapons2 = (List<System.Int32Enum>)(object)_availableWeapons;
					PickupCustomMerchant pickupCustomMerchant2 = core2._003CCurrentCustomMerchant_003Ek__BackingField;
					CustomMerchantData customMerchantData = pickupCustomMerchant2._customMerchantData;
					List<WeaponType> validAdventureWeaponsForMerchant = GetValidAdventureWeaponsForMerchant(customMerchantData._003CMerchantInventory_003Ek__BackingField, _playerOptions);
					List<WeaponType> availableWeapons3 = _availableWeapons;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					((List<System.Int32Enum>)(object)availableWeapons3).InsertRange(0, (IEnumerable<System.Int32Enum>)validAdventureWeaponsForMerchant);
					return;
				}
			}
		}
		GameManager core3 = GM.Core;
		if (core3._003CMerchantInventory_003Ek__BackingField != MerchantInventoryType.CUSTOM)
		{
			VampireSurvivors.Objects.Characters.CharacterController player2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			if (core3._003CMerchantInventory_003Ek__BackingField != MerchantInventoryType.EGGSONLY)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config._003CSelectedInverse_003Ek__BackingField)
				{
					MakeArcanaInventory();
				}
				MakeStandardInventory(player2);
			}
			else
			{
				MakeEggsInventory(player2);
			}
		}
		else
		{
			MakeCustomInventory();
		}
	}

	public void InjectRemoteShop(List<WeaponType> weapons, List<ItemType> items)
	{
		_availableWeapons = weapons;
		_availableItems = items;
	}

	public static List<WeaponType> GetValidAdventureWeaponsForMerchant(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
	{
		//IL_0068: Expected O, but got I
		//IL_014e: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		List<WeaponType> result = new List<WeaponType>();
		if (merchantInventory != null)
		{
			object obj2 = default(object);
			object obj3 = default(object);
			object obj4 = default(object);
			object obj7 = default(object);
			while (true)
			{
				object obj = obj2;
				while (true)
				{
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
						if (obj4 == null)
						{
							object obj5 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+18]");
							if ((nint)obj5 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+10]");
								object obj6 = 0;
								obj++;
								PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
								List<WeaponType> list = mainGameConfig._003CUnlockedWeapons_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if ((nint)0 == 0)
								{
									continue;
								}
								goto IL_00c9;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				break;
				IL_00c9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				bool flag = (nint)obj7 == -1;
				obj2 = obj;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					obj2 = obj;
				}
			}
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
				if (obj4 == null)
				{
					goto IL_019a;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				object obj8 = 0;
			}
			throw new NullReferenceException();
		}
		goto IL_019a;
		IL_019a:
		return result;
	}

	public static List<WeaponType> GetValidCustomMerchantWeapons(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
	{
		//IL_020a: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_011e: Expected I4, but got O
		List<WeaponType> result = new List<WeaponType>();
		if (merchantInventory != null)
		{
			object obj = null;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			object obj8 = default(object);
			object obj10 = default(object);
			object message = default(object);
			while (true)
			{
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
					if (obj3 != null)
					{
						break;
					}
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+10]");
					object obj6 = 0;
					object obj7 = obj5 + 1;
					PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
					List<WeaponType> list = mainGameConfig._003CUnlockedWeapons_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						if ((nint)obj8 != -1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							obj5 = obj7;
							continue;
						}
					}
					object obj9 = (WeaponType)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					Debug.LogWarning(message);
					obj5 = obj7;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag = obj2 == null;
			obj = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-28_v3+1C]");
				if (obj3 == null)
				{
					goto IL_01d3;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
		goto IL_01d3;
		IL_01d3:
		return result;
	}

	public static List<ItemType> GetValidCustomMerchantItems(List<ItemType> merchantInventoryItems, PlayerOptions playerOptions)
	{
		//IL_025a: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0157: Expected I4, but got O
		List<ItemType> result = new List<ItemType>();
		if (merchantInventoryItems != null)
		{
			object obj = null;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			object obj8 = default(object);
			object obj9 = default(object);
			object obj11 = default(object);
			object message = default(object);
			while (true)
			{
				object obj7;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+1C]");
					if (obj3 != null)
					{
						break;
					}
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+10]");
					object obj6 = 0;
					obj7 = obj5 + 1;
					PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					if (obj8 == null)
					{
						PlayerOptionsData config = playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
						if (obj9 == null)
						{
							goto IL_0185;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v8+20+v269 @ stack_-30_v2*4]");
					if ((nint)0 != 100)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v8+20+v269 @ stack_-30_v2*4]");
						if ((nint)0 != 400)
						{
							object obj10 = (ItemType)obj11;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
							Debug.LogWarning(message);
							obj5 = obj7;
							continue;
						}
					}
					goto IL_0185;
				}
				throw new NullReferenceException();
				IL_0185:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				obj5 = obj7;
			}
			bool flag = obj2 == null;
			obj = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-38_v3+1C]");
				if (obj3 == null)
				{
					goto IL_0223;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
		goto IL_0223;
		IL_0223:
		return result;
	}

	public unsafe bool DoesPlayerAlreadyHaveWeapon(WeaponType t)
	{
		//IL_007a: Expected O, but got I4
		//IL_0082: Expected O, but got Ref
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass13_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.t = t;
			List<Equipment> source = new List<Equipment>();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<object> list = (List<object>)(&enumerator);
					throw new NullReferenceException();
				}
				Func<Equipment, bool> predicate = delegate(Equipment x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj2 = x._equipmentType - CS_0024_003C_003E8__locals3.t;
					return obj2 == null;
				};
				return Enumerable.Any(source, predicate);
			}
		}
		throw new NullReferenceException();
	}

	private void MakeCustomInventory()
	{
		//IL_0427: Expected O, but got I
		//IL_0210: Expected O, but got I
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0255: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_02ce: Expected O, but got I
		GameManager core = GM.Core;
		PickupCustomMerchant pickupCustomMerchant = core._003CCurrentCustomMerchant_003Ek__BackingField;
		if ((object)core._003CCurrentCustomMerchant_003Ek__BackingField != null && ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant2 = core2._003CCurrentCustomMerchant_003Ek__BackingField;
			CustomMerchantData customMerchantData = pickupCustomMerchant2._customMerchantData;
			if (pickupCustomMerchant2._customMerchantData == null || customMerchantData._003CMerchantInventory_003Ek__BackingField == null)
			{
				GameManager core3 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant3 = core3._003CCurrentCustomMerchant_003Ek__BackingField;
				if (pickupCustomMerchant3.CustomActionInventoryItems == null)
				{
					GameManager core4 = GM.Core;
					PickupCustomMerchant pickupCustomMerchant4 = core4._003CCurrentCustomMerchant_003Ek__BackingField;
					CustomMerchantData customMerchantData2 = pickupCustomMerchant4._customMerchantData;
					if (customMerchantData2._003CMerchantInventoryItems_003Ek__BackingField == null)
					{
						Debug.LogError("Custom Merchant has no valid inventory data");
						return;
					}
				}
			}
			GameManager core5 = GM.Core;
			PickupCustomMerchant pickupCustomMerchant5 = core5._003CCurrentCustomMerchant_003Ek__BackingField;
			if (!pickupCustomMerchant5._003CSkipValidWeaponCheck_003Ek__BackingField)
			{
				GameManager core6 = GM.Core;
				PickupCustomMerchant pickupCustomMerchant6 = core6._003CCurrentCustomMerchant_003Ek__BackingField;
				CustomMerchantData customMerchantData3 = pickupCustomMerchant6._customMerchantData;
				List<WeaponType> validCustomMerchantWeapons = GetValidCustomMerchantWeapons(customMerchantData3._003CMerchantInventory_003Ek__BackingField, _playerOptions);
			}
			List<System.Int32Enum> list = null;
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-28_v11+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-28_v11+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-28_v11+10]");
							object obj5 = 0;
							object obj6 = obj4 + 1;
							list = (List<System.Int32Enum>)(object)_availableWeapons;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r8_v17+18]");
							if (num >= 0)
							{
								List<System.Int32Enum> list2 = list;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v27+20+v273 @ stack_-20_v10*4]");
								list2.AddWithResize((System.Int32Enum)0);
								obj4 = obj6;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
								object obj9 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v27+20+v273 @ stack_-20_v10*4]");
								_ = 0;
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
			bool flag = obj == null;
			list = (List<System.Int32Enum>)0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-28_v11+1C]");
				if (obj2 == null)
				{
					List<System.Int32Enum> availableItems = (List<System.Int32Enum>)(object)_availableItems;
					GameManager core7 = GM.Core;
					PickupCustomMerchant pickupCustomMerchant7 = core7._003CCurrentCustomMerchant_003Ek__BackingField;
					CustomMerchantData customMerchantData4 = pickupCustomMerchant7._customMerchantData;
					List<ItemType> validCustomMerchantItems = GetValidCustomMerchantItems(customMerchantData4._003CMerchantInventoryItems_003Ek__BackingField, _playerOptions);
					List<ItemType> availableItems2 = _availableItems;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdi_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					((List<System.Int32Enum>)(object)availableItems2).InsertRange(0, (IEnumerable<System.Int32Enum>)validCustomMerchantItems);
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list = null;
			}
			throw new NullReferenceException();
		}
		Debug.LogError("Custom Merchant is null");
	}

	private void MakeStandardInventory(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_006a: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_0116: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_021f: Expected O, but got I
		//IL_0279: Expected O, but got I
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		object obj = default(object);
		bool flag = (nint)obj < 0;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)stageModifiers._003CEndCycles_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 == null)
		{
			if (player._characterType != CharacterType.SIGMA)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		else
		{
			List<System.Int32Enum> availableItems = (List<System.Int32Enum>)(object)_availableItems;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v64 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v64 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v64 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r8_v37+18]");
			if (num >= 0)
			{
				availableItems.AddWithResize((System.Int32Enum)52);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v64 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj6 = (nint)0 + (nint)1;
				_ = 52;
			}
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				goto IL_028e;
			}
		}
		List<System.Int32Enum> availableItems2 = (List<System.Int32Enum>)(object)_availableItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v61 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v61 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v61 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v22+18]");
		if (num2 >= 0)
		{
			availableItems2.AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v61 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 26;
		}
		goto IL_028e;
		IL_028e:
		PlayerOptionsData config2 = _playerOptions.Config;
		List<CharacterType> list2 = config2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj10 = default(object);
			if ((nint)obj10 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.BONE))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		List<CharacterType> list3 = config3._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj11 = default(object);
			if ((nint)obj11 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.CHERRY))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		List<CharacterType> list4 = config4._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj12 = default(object);
			if ((nint)obj12 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.CART2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config5 = _playerOptions.Config;
		List<CharacterType> list5 = config5._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj13 = default(object);
			if ((nint)obj13 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.FLOWER))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config6 = _playerOptions.Config;
		List<CharacterType> list6 = config6._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj14 = default(object);
			if ((nint)obj14 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.ROBBA))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config7 = _playerOptions.Config;
		List<CharacterType> list7 = config7._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj15 = default(object);
			if ((nint)obj15 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.BUBBLES))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config8 = _playerOptions.Config;
		List<CharacterType> list8 = config8._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj16 = default(object);
			if ((nint)obj16 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.PARTY))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
		PlayerOptionsData config9 = _playerOptions.Config;
		List<CharacterType> list9 = config9._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj17 = default(object);
			if ((nint)obj17 != -1 && !DoesPlayerAlreadyHaveWeapon(WeaponType.C1_HATCOLLECTION1))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			}
		}
	}

	private void MakeArcanaInventory()
	{
		//IL_0103: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_027d: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedMazzo_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			List<ArcanaType> list = config2._003CUnlockedArcanas_003Ek__BackingField;
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<ArcanaType> list2 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if (num > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
			}
		}
		List<System.Int32Enum> availableItems = (List<System.Int32Enum>)(object)_availableItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v3+18]");
		if (num2 >= 0)
		{
			availableItems.AddWithResize((System.Int32Enum)33);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 33;
		}
		List<System.Int32Enum> availableItems2 = (List<System.Int32Enum>)(object)_availableItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v5+18]");
		if (num3 >= 0)
		{
			availableItems2.AddWithResize((System.Int32Enum)32);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 32;
		}
		List<System.Int32Enum> availableItems3 = (List<System.Int32Enum>)(object)_availableItems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v7+18]");
		if (num4 >= 0)
		{
			availableItems3.AddWithResize((System.Int32Enum)34);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj6 = (nint)0 + (nint)1;
		_ = 34;
	}

	private void MakeEggsInventory(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0184: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_0141: Expected O, but got I
		if (player._characterType != CharacterType.SIGMA)
		{
			List<System.Int32Enum> availableItems = (List<System.Int32Enum>)(object)_availableItems;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v6+18]");
			if (num >= 0)
			{
				availableItems.AddWithResize((System.Int32Enum)27);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 27;
			}
			List<System.Int32Enum> availableItems2 = (List<System.Int32Enum>)(object)_availableItems;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r8_v8+18]");
			if (num2 >= 0)
			{
				availableItems2.AddWithResize((System.Int32Enum)55);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 55;
		}
		else
		{
			List<System.Int32Enum> availableWeapons = (List<System.Int32Enum>)(object)_availableWeapons;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v3+18]");
			if (num3 >= 0)
			{
				availableWeapons.AddWithResize((System.Int32Enum)88);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 88;
		}
	}

	public ShopFactory()
	{
		List<WeaponType> availableWeapons = new List<WeaponType>();
		_availableWeapons = availableWeapons;
		List<ItemType> availableItems = new List<ItemType>();
		_availableItems = availableItems;
	}
}
