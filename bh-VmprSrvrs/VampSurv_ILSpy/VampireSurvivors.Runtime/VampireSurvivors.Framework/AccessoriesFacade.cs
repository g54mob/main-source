using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework;

public class AccessoriesFacade : IInitializable, IDisposable
{
	private AccessoriesFactory _accessoriesFactory;

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

	public unsafe void AddAccessory(WeaponType accessoryType, VampireSurvivors.Objects.Characters.CharacterController characterController, bool removeFromStore = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_054c: Expected O, but got Ref
		//IL_055a: Expected I4, but got O
		//IL_056c: Expected O, but got Ref
		//IL_0580: Expected native int or pointer, but got O
		//IL_0598: Expected O, but got Ref
		//IL_0684: Expected O, but got Ref
		//IL_022b: Expected O, but got Ref
		//IL_0239: Expected O, but got Ref
		//IL_02e2: Expected O, but got Ref
		//IL_03ac: Expected O, but got I
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0729: Expected O, but got Ref
		//IL_074c: Expected I, but got O
		//IL_076e: Expected O, but got I
		//IL_076e: Expected O, but got I
		//IL_077e: Expected O, but got I
		//IL_048b: Expected O, but got I4
		//IL_0449: Expected O, but got I4
		//IL_027b->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_02a5->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_0317->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_035c->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_06d3->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_0716->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_046b->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_0432->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_0526->IL05d8: Incompatible stack heights: 1 vs 0
		//IL_04df->IL0180: Incompatible stack heights: 1 vs 0
		//IL_053e->IL0180: Incompatible stack heights: 1 vs 0
		//IL_0504->IL0180: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if ((object)characterController != null && (object)characterController._accessoriesManager != null)
		{
			Accessory accessoryByType = characterController._accessoriesManager.GetAccessoryByType(accessoryType);
			if ((object)accessoryByType == null || ((UnityEngine.Object)accessoryByType).m_CachedPtr == (IntPtr)0)
			{
				goto IL_0181;
			}
			WeaponData weaponData = accessoryByType._003CCurrentAccessoryData_003Ek__BackingField;
			if (accessoryByType._003CCurrentAccessoryData_003Ek__BackingField != null)
			{
				if (weaponData._003CallowDuplicates_003Ek__BackingField)
				{
					goto IL_0181;
				}
				if (!accessoryByType.LevelUp())
				{
					if (_playerOptions == null)
					{
						goto IL_05d8;
					}
					float num = _playerOptions.AddCoins(10f, characterController);
				}
				if (!removeFromStore)
				{
					return;
				}
				if (_levelUpFactory != null)
				{
					_levelUpFactory.RemoveFromStore(accessoryType, characterController);
					return;
				}
			}
		}
		goto IL_05d8;
		IL_0490:
		if (characterController._PlayerIndex < 0)
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			if (characterController._deficiencyControl == null || deficiencyControl._003CLevelupType_003Ek__BackingField != LevelupType.ManualSelection)
			{
				return;
			}
		}
		Accessory accessory;
		if (((Equipment)accessory)._currentJsonDataObject != null)
		{
			((ArcanaManager)(object)((Equipment)accessory)._currentJsonDataObject).CheckSilent();
			return;
		}
		goto IL_05d8;
		IL_05d8:
		throw new NullReferenceException();
		IL_0181:
		if ((object)_accessoriesFactory != null)
		{
			Accessory accessoryPrefab = _accessoriesFactory.GetAccessoryPrefab(accessoryType);
			if ((object)accessoryPrefab == null || ((UnityEngine.Object)accessoryPrefab).m_CachedPtr == (IntPtr)0)
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				object arg = (WeaponType)obj3;
				System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
				System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-21]");
				_ = 0;
				string message = string.FormatHelper((IFormatProvider)null, "Accessory prefab is NULL for type {0}. Likely not generated a prefab for this yet...", args);
				Debug.LogError(message);
				return;
			}
			Transform transform = characterController.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj4);
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
				_ = Quaternion.identityQuaternion;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-61]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
				Component component = default(Component);
				if ((object)component != null)
				{
					Accessory component2 = component.GetComponent<Accessory>();
					if ((object)component2 != null)
					{
						((Equipment)component2).FakeConstruct();
						((Equipment)component2)._003COwner_003Ek__BackingField = characterController;
						((Equipment)component2)._equipmentType = accessoryType;
						GameObject gameObject = component2.gameObject;
						_ = typeof(WeaponType);
						Enum obj7 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
						_ = -1;
						string name = obj7.ToString();
						if ((object)gameObject != null)
						{
							((UnityEngine.Object)gameObject).SetName(name);
							component2.MakeLevelOne();
							Accessory accessoriesManager = (Accessory)(object)characterController._accessoriesManager;
							if ((object)characterController._accessoriesManager != null && ((Equipment)accessoriesManager)._dataManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B2E0");
								component2.OnAccessoryAddedToEquipment();
								_ = _signalBus;
								_ = 0;
								_ = 0;
								_ = component2._003CCurrentAccessoryData_003Ek__BackingField;
								if (_signalBus != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-49]");
									object obj8 = (nint)0 >> 32;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-51]");
									_ = 0;
									_ = component2._003CCurrentAccessoryData_003Ek__BackingField;
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
									object obj10 = default(object);
									object obj9 = obj10 + 32;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
									IntPtr intPtr = default(IntPtr);
									num2 = intPtr;
									object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-31]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-21]");
									_ = 0;
									object signal = (IntPtr)obj11;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+6F]");
									bool requireDeclaration = default(bool);
									((SignalBus)0).InternalFire((Type)num2, signal, (object)null, requireDeclaration);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5F]");
									accessory = (Accessory)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+77]");
									if ((nint)0 == 0)
									{
										if (((GameMonoBehaviour)accessory)._onPauseSent)
										{
											((LevelUpFactory)((GameMonoBehaviour)accessory)._onPauseSent).CalculateWeights(characterController);
											goto IL_0490;
										}
									}
									else if (((GameMonoBehaviour)accessory)._onPauseSent)
									{
										((LevelUpFactory)((GameMonoBehaviour)accessory)._onPauseSent).RemoveFromStore(((Equipment)component2)._equipmentType, characterController);
										goto IL_0490;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05d8;
	}

	public void RemoveAccessory(WeaponType accessoryType, VampireSurvivors.Objects.Characters.CharacterController characterController, bool notifyRemove = true)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_019f: Expected I, but got O
		//IL_01bb: Expected O, but got I
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Accessory accessoryByType = characterController._accessoriesManager.GetAccessoryByType(accessoryType);
		if ((object)accessoryByType != null && ((UnityEngine.Object)accessoryByType).m_CachedPtr != (IntPtr)0)
		{
			bool flag = !notifyRemove;
			bool flag2 = false;
			if (!flag)
			{
				characterController._accessoriesManager.RemoveEquipment(accessoryByType);
				flag2 = false;
			}
			accessoryByType.OnAccessoryRemovedFromEquipment();
			accessoryByType.Cleanup();
			if (notifyRemove)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				object obj3 = default(object);
				object signal = (IntPtr)obj3;
				bool requireDeclaration = default(bool);
				_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
			}
		}
	}
}
