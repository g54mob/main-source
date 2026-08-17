using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Framework;

public class WeaponsFacade : IInitializable, IDisposable
{
	private WeaponFactory _weaponFactory;

	private SignalBus _signalBus;

	private LevelUpFactory _levelUpFactory;

	private PlayerOptions _playerOptions;

	private ArcanaManager _arcanaManager;

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public unsafe Weapon AddWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController character, bool removeFromStore = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0552: Expected O, but got Ref
		//IL_0560: Expected I4, but got O
		//IL_0638: Expected O, but got Ref
		//IL_020a: Expected O, but got Ref
		//IL_0218: Expected O, but got Ref
		//IL_02d5: Expected O, but got I4
		//IL_0392: Expected O, but got I
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_06c2: Expected O, but got Ref
		//IL_06e5: Expected I, but got O
		//IL_0707: Expected O, but got I
		//IL_0707: Expected O, but got I
		//IL_0717: Expected O, but got I
		//IL_047d: Expected O, but got I
		//IL_0435: Expected O, but got I
		//IL_053a: Expected O, but got I
		//IL_025a->IL0586: Incompatible stack heights: 1 vs 0
		//IL_0289->IL0586: Incompatible stack heights: 1 vs 0
		//IL_0667->IL0586: Incompatible stack heights: 1 vs 0
		//IL_06af->IL0586: Incompatible stack heights: 1 vs 0
		//IL_045a->IL0586: Incompatible stack heights: 1 vs 0
		//IL_041b->IL0586: Incompatible stack heights: 1 vs 0
		//IL_0524->IL0586: Incompatible stack heights: 1 vs 0
		//IL_0544->IL068b: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		if (weaponType == WeaponType.VOID)
		{
			goto IL_0144;
		}
		Weapon weapon;
		if ((object)character != null && (object)character._weaponsManager != null)
		{
			Weapon weaponByType = character._weaponsManager.GetWeaponByType(weaponType);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				if (!weaponByType.LevelUp())
				{
					if (_playerOptions == null)
					{
						goto IL_0586;
					}
					float num = _playerOptions.AddCoins(10f, character);
				}
				if (removeFromStore)
				{
					if (_levelUpFactory == null)
					{
						goto IL_0586;
					}
					_levelUpFactory.RemoveFromStore(weaponType, character);
				}
				goto IL_0144;
			}
			if ((object)_weaponFactory != null)
			{
				Weapon weaponPrefab = _weaponFactory.GetWeaponPrefab(weaponType, out System.Runtime.CompilerServices.Unsafe.As<object, WeaponType>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103)));
				if ((object)weaponPrefab == null || ((UnityEngine.Object)weaponPrefab).m_CachedPtr == (IntPtr)0)
				{
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					object obj4 = (WeaponType)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					object message = default(object);
					Debug.LogError(message);
					goto IL_0144;
				}
				Transform transform = character.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj5);
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
					_ = Quaternion.identityQuaternion;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-31]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-29]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
					Component component = default(Component);
					if ((object)component != null)
					{
						weapon = component.GetComponent<Weapon>();
						if ((object)character._weaponsManager != null)
						{
							character._weaponsManager.AddEquipment(weapon);
							if (character._startingWeaponType != WeaponType.CANDYBOX)
							{
								object obj8 = character._startingWeaponType - 1407;
								if ((nint)obj8 > 3 && character._startingWeaponType != WeaponType.TP_SPECTRALSWORD && character._startingWeaponType != WeaponType.EME_SELECTOR)
								{
									goto IL_064f;
								}
							}
							character._startingWeaponType = weaponType;
							goto IL_064f;
						}
					}
				}
			}
		}
		goto IL_0586;
		IL_064f:
		if ((object)weapon != null)
		{
			weapon.InitWeapon(character, weaponType);
			_ = _signalBus;
			_ = 0;
			_ = 0;
			_ = weapon._currentWeaponData;
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-59]");
				object obj9 = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-61]");
				_ = 0;
				_ = weapon._currentWeaponData;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj11 = default(object);
				object obj10 = obj11 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num2 = intPtr;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-11]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-1]");
				_ = 0;
				object signal = (IntPtr)obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-41]");
				bool requireDeclaration = default(bool);
				((SignalBus)0).InternalFire((Type)num2, signal, (object)null, requireDeclaration);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5F]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+77]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+20]");
						((LevelUpFactory)0).CalculateWeights(character);
						goto IL_0482;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+20]");
						((LevelUpFactory)0).RemoveFromStore(((Equipment)weapon)._equipmentType, character);
						goto IL_0482;
					}
				}
			}
		}
		goto IL_0586;
		IL_0482:
		weapon.OnWeaponAdded();
		if (character._PlayerIndex < 0)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			if (character._deficiencyControl == null || deficiencyControl._003CLevelupType_003Ek__BackingField != LevelupType.ManualSelection)
			{
				goto IL_068b;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+30]");
		if ((nint)0 == 0)
		{
			goto IL_0586;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v13+30]");
		((ArcanaManager)0).CheckSilent();
		goto IL_068b;
		IL_068b:
		return weapon;
		IL_0586:
		throw new NullReferenceException();
		IL_0144:
		weapon = null;
		goto IL_068b;
	}

	public unsafe Weapon CreateDetachedWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_014c: Expected O, but got Ref
		//IL_011e->IL01de: Incompatible stack heights: 6 vs 1
		if (weaponType != WeaponType.VOID)
		{
			bool flag = (object)_weaponFactory == null;
			Weapon weaponPrefab = _weaponFactory.GetWeaponPrefab(weaponType, out var forcedWeaponType);
			Weapon weapon;
			if ((object)weaponPrefab != null && ((UnityEngine.Object)weaponPrefab).m_CachedPtr != (IntPtr)0)
			{
				bool flag2 = (object)characterController == null;
				Transform transform = characterController.transform;
				bool flag3 = (object)transform == null;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
				Component component = default(Component);
				bool flag5 = (object)component == null;
				weapon = component.GetComponent<Weapon>();
				bool flag6 = (object)weapon == null;
				weapon.InitWeapon(characterController, weaponType);
				weapon.OnWeaponAdded();
			}
			else
			{
				object arg = forcedWeaponType;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Weapon prefab is NULL for type {0}. Adam has likely not generated this weapon yet... Come on Adam...", (System.ParamsArray)(&obj));
				Debug.LogError(message);
				weapon = null;
			}
			return weapon;
		}
		return null;
	}

	public Weapon RemoveWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController characterController, bool notifyRemove = true)
	{
		Weapon weapon;
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			if ((object)characterController._weaponsManager != null)
			{
				weapon = characterController._weaponsManager.GetWeaponByType(weaponType);
				if ((object)weapon == null || ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0140;
				}
				if (!notifyRemove)
				{
					weapon.Cleanup();
					goto IL_01a1;
				}
				if ((object)characterController._weaponsManager != null)
				{
					characterController._weaponsManager.RemoveEquipment(weapon);
					weapon.Cleanup();
					if (_signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4B60");
						goto IL_01a1;
					}
				}
			}
			return (Weapon)(object)new NullReferenceException();
		}
		goto IL_0140;
		IL_01a1:
		return weapon;
		IL_0140:
		weapon = null;
		goto IL_01a1;
	}

	public Equipment RemoveEquipment(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController characterController, bool notifyRemove = true)
	{
		Weapon result;
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			if ((object)characterController._weaponsManager != null)
			{
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(weaponType);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					if (!notifyRemove)
					{
						weaponByType.Cleanup();
						result = weaponByType;
						goto IL_013a;
					}
					if ((object)characterController._weaponsManager != null)
					{
						characterController._weaponsManager.RemoveEquipment(weaponByType);
						weaponByType.Cleanup();
						if (_signalBus != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4B60");
							result = weaponByType;
							goto IL_013a;
						}
					}
				}
				else if ((object)characterController._accessoriesManager != null)
				{
					Accessory accessoryByType = characterController._accessoriesManager.GetAccessoryByType(weaponType);
					if ((object)accessoryByType == null || ((UnityEngine.Object)accessoryByType).m_CachedPtr == (IntPtr)0)
					{
						return null;
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._accessoriesFacade != null)
					{
						core._accessoriesFacade.RemoveAccessory(weaponType, characterController);
						result = (Weapon)(object)accessoryByType;
						goto IL_013a;
					}
				}
			}
			return (Equipment)(object)new NullReferenceException();
		}
		return null;
		IL_013a:
		return result;
	}

	public unsafe Weapon AddHiddenWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController characterController, bool removeFromStore = true, bool allowDuplicates = false)
	{
		//IL_00ae: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_00c6: Expected O, but got I
		//IL_0146: Expected O, but got I4
		//IL_0102: Expected O, but got I
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected Ref, but got Unknown
		//IL_0138: Expected O, but got I4
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04e2: Expected I4, but got O
		//IL_0380: Expected I, but got O
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected O, but got Unknown
		//IL_03fb: Expected O, but got I
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Expected O, but got Unknown
		//IL_0683: Expected I, but got O
		//IL_0341->IL050d: Incompatible stack heights: 1 vs 0
		//IL_0373->IL050d: Incompatible stack heights: 1 vs 0
		//IL_0378->IL0378: Incompatible stack heights: 1 vs 0
		_ = 0;
		_ = 0;
		Equipment equipmentByType;
		object obj3;
		Weapon weapon;
		object obj4 = default(object);
		if ((object)characterController != null && (object)characterController._weaponsManager != null)
		{
			equipmentByType = characterController._weaponsManager.GetEquipmentByType(weaponType, searchHidden: true);
			if ((object)equipmentByType != null && ((UnityEngine.Object)equipmentByType).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+50]");
				if ((nint)0 == 0)
				{
					nint num = (nint)typeof(Weapon);
					nint num2 = (nint)equipmentByType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v102+FFFFFFF8+v575 @ rax_v97*8]");
						if (0 == (nint)typeof(Weapon))
						{
							obj3 = 1;
							goto IL_055f;
						}
					}
					obj3 = 0;
					goto IL_055f;
				}
			}
			if ((object)characterController._weaponsManager != null)
			{
				Equipment removedHiddenEquipment = characterController._weaponsManager.GetRemovedHiddenEquipment(weaponType);
				if ((object)removedHiddenEquipment != null && ((UnityEngine.Object)removedHiddenEquipment).m_CachedPtr != (IntPtr)0)
				{
					Weapon component = removedHiddenEquipment.GetComponent<Weapon>();
					if ((object)component != null)
					{
						GameObject gameObject = component.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							weapon = component;
							goto IL_0378;
						}
					}
				}
				else if ((object)_weaponFactory != null)
				{
					Weapon weaponPrefab = _weaponFactory.GetWeaponPrefab(weaponType, out *(WeaponType*)(obj4 + 64));
					if ((object)weaponPrefab == null || ((UnityEngine.Object)weaponPrefab).m_CachedPtr == (IntPtr)0)
					{
						object obj5 = obj4 + 64;
						object obj6 = (WeaponType)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						object message = default(object);
						Debug.LogError(message);
						return null;
					}
					Transform transform = characterController.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj7 = obj4 - 80;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj7);
						object obj8 = obj4 - 32;
						object obj9 = obj4 - 64;
						_ = Quaternion.identityQuaternion;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
						Component component2 = default(Component);
						if ((object)component2 != null)
						{
							Weapon component3 = component2.GetComponent<Weapon>();
							bool flag2 = (object)component3 == null;
							weapon = component3;
							if (!flag2)
							{
								goto IL_0378;
							}
						}
					}
				}
			}
		}
		goto IL_050d;
		IL_050d:
		throw new NullReferenceException();
		IL_0378:
		nint num4 = (nint)weapon;
		weapon.InitWeapon(characterController, weaponType);
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		if ((object)characterController._weaponsManager != null && ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
			_ = 0;
			if (_signalBus != null)
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-28]");
				object obj10 = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r14_v8 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ r14_v9 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj12 = default(object);
				object obj11 = obj12 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Equipment equipment = default(Equipment);
				Equipment signalType = equipment;
				object obj13 = obj4 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
				_ = 0;
				object signal = (IntPtr)obj13;
				bool requireDeclaration = default(bool);
				_signalBus.InternalFire((Type)(object)signalType, signal, (object)null, requireDeclaration);
				weapon.OnWeaponAdded();
				return weapon;
			}
		}
		goto IL_050d;
		IL_055f:
		bool flag3 = obj3 == null;
		Equipment result = null;
		if (!flag3)
		{
			result = equipmentByType;
		}
		return (Weapon)result;
	}

	public void RemoveHiddenWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0150: Expected O, but got I4
		//IL_0150: Expected O, but got I
		//IL_0162: Expected O, but got I4
		//IL_01dc: Expected I, but got O
		//IL_01f8: Expected O, but got I
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(weaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj = default(object);
			if (obj != null)
			{
				GameObject gameObject = weaponByType.gameObject;
				gameObject.SetActive(value: false);
				bool flag = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).Remove((object)weaponByType);
				bool flag2 = ((EquipmentManager)weaponsManager)._003CRemovedHiddenEquipment_003Ek__BackingField.Remove(weaponByType);
			}
			weaponByType.Cleanup();
			nint num = 0;
			bool flag3 = ((List<Equipment>)0).Remove((Equipment)1);
			object obj2 = (flag3 ? 1 : 0) + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	public void RemoveThisHiddenWeapon(Weapon weapon, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0065: Expected I, but got O
		//IL_0080: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_0159: Expected I, but got O
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		bool flag = (object)characterController._weaponsManager == null;
		nint num = (nint)typeof(UnityEngine.Object);
		if (!flag)
		{
			num = (nint)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField;
			if (((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
				CharacterWeaponsManager weaponsManager2 = characterController._weaponsManager;
				if ((object)characterController._weaponsManager != null)
				{
					bool flag2 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField == null;
					num = (nint)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField;
					if (!flag2)
					{
						bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).Remove((object)weapon);
						bool flag4 = (object)weapon == null;
						num = (nint)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField;
						if (!flag4)
						{
							weapon.Cleanup();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
