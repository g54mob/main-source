using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;

namespace Assets.Scripts.Camera;

public class CameraShakerController : MonoBehaviour
{
	public Shaker shaker;

	public ShakePreset damageShake;

	public ShakePreset objectImpactShake;

	public ShakePreset grindShake;

	public ShakePreset pylonSpawnShake;

	private float damageShakeCooldown = 0.25f;

	private float damageNextShakeReadyTime;

	private ShakeInstance grindShakeInstance;

	private void Awake()
	{
		//IL_0464: Expected I, but got O
		//IL_0475: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02f0: Expected I, but got O
		//IL_0301: Expected O, but got I4
		//IL_0344: Expected I, but got O
		//IL_0355: Expected O, but got I4
		//IL_0371: Expected I, but got O
		//IL_053f: Expected O, but got I4
		//IL_0555: Expected I, but got O
		//IL_0583: Expected O, but got I4
		//IL_0599: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_05df;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0484;
			}
		}
		Action<float> b2 = OnObjectImpact;
		Delegate obj6 = Delegate.Combine(SmokeAndShakeObject.A_Impact, b2);
		if ((object)obj6 == null)
		{
			SmokeAndShakeObject.A_Impact = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action2 = default(Action<float>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_048f;
			}
			SmokeAndShakeObject.A_Impact = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_049f;
			}
		}
		Action<string, object, object> b3 = OnSettingUpdated;
		Delegate obj8 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b3);
		if ((object)obj8 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_04d7;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<string, object, object>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_04e7;
			}
		}
		Action<bool> b4 = OnGrindToggle;
		Delegate obj10 = Delegate.Combine(PlayerMovement.A_ToggleGrind, b4);
		if ((object)obj10 == null)
		{
			PlayerMovement.A_ToggleGrind = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action4 = default(Action<bool>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_04ff;
			}
			PlayerMovement.A_ToggleGrind = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_050f;
			}
		}
		num = (nint)FinalFightController.A_PylonsStarted;
		Action action5 = OnPylonsStarted;
		Delegate obj12 = Delegate.Combine(FinalFightController.A_PylonsStarted, action5);
		if ((object)obj12 == null)
		{
			FinalFightController.A_PylonsStarted = null;
			return;
		}
		bool flag8 = (object)obj12.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag8)
		{
			obj13 = obj12;
		}
		bool flag9 = (object)obj13 == null;
		obj2 = action5;
		obj3 = 0;
		obj4 = obj12;
		nint num3 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_05cf;
		}
		FinalFightController.A_PylonsStarted = (Action)obj13;
		bool flag10 = (object)obj12.GetType() != typeof(Action);
		Delegate obj14 = null;
		if (!flag10)
		{
			obj14 = obj12;
		}
		bool flag11 = (object)obj14 == null;
		obj2 = action5;
		obj3 = 0;
		obj4 = obj12;
		nint num4 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_05df;
		IL_04d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049f;
		IL_05cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_050f;
		IL_049f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_048f;
		IL_04ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e7;
		IL_048f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0484;
		IL_0484:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_04d7;
		IL_05df:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05cf;
		IL_050f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ff;
	}

	private void OnDestroy()
	{
		//IL_0464: Expected I, but got O
		//IL_0475: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02f0: Expected I, but got O
		//IL_0301: Expected O, but got I4
		//IL_0344: Expected I, but got O
		//IL_0355: Expected O, but got I4
		//IL_0371: Expected I, but got O
		//IL_053f: Expected O, but got I4
		//IL_0555: Expected I, but got O
		//IL_0583: Expected O, but got I4
		//IL_0599: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_05df;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0484;
			}
		}
		Action<float> value2 = OnObjectImpact;
		Delegate obj6 = Delegate.Remove(SmokeAndShakeObject.A_Impact, value2);
		if ((object)obj6 == null)
		{
			SmokeAndShakeObject.A_Impact = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action2 = default(Action<float>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_048f;
			}
			SmokeAndShakeObject.A_Impact = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_049f;
			}
		}
		Action<string, object, object> value3 = OnSettingUpdated;
		Delegate obj8 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value3);
		if ((object)obj8 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_04d7;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<string, object, object>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_04e7;
			}
		}
		Action<bool> value4 = OnGrindToggle;
		Delegate obj10 = Delegate.Remove(PlayerMovement.A_ToggleGrind, value4);
		if ((object)obj10 == null)
		{
			PlayerMovement.A_ToggleGrind = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action4 = default(Action<bool>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_04ff;
			}
			PlayerMovement.A_ToggleGrind = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_050f;
			}
		}
		num = (nint)FinalFightController.A_PylonsStarted;
		Action action5 = OnPylonsStarted;
		Delegate obj12 = Delegate.Remove(FinalFightController.A_PylonsStarted, action5);
		if ((object)obj12 == null)
		{
			FinalFightController.A_PylonsStarted = null;
			return;
		}
		bool flag8 = (object)obj12.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag8)
		{
			obj13 = obj12;
		}
		bool flag9 = (object)obj13 == null;
		obj2 = action5;
		obj3 = 0;
		obj4 = obj12;
		nint num3 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_05cf;
		}
		FinalFightController.A_PylonsStarted = (Action)obj13;
		bool flag10 = (object)obj12.GetType() != typeof(Action);
		Delegate obj14 = null;
		if (!flag10)
		{
			obj14 = obj12;
		}
		bool flag11 = (object)obj14 == null;
		obj2 = action5;
		obj3 = 0;
		obj4 = obj12;
		nint num4 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_05df;
		IL_04d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049f;
		IL_05cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_050f;
		IL_049f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_048f;
		IL_04ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e7;
		IL_048f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0484;
		IL_0484:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_04d7;
		IL_05df:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05cf;
		IL_050f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ff;
	}

	private void Start()
	{
		//IL_00a2: Expected O, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			object obj = cfGameSettings.camera_shake - 1;
			bool flag = obj == null;
			shaker.enabled = flag;
		}
	}

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
		//IL_0043: Expected O, but got I
		//IL_004b: Expected I, but got O
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B41]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (setting == "camera_shake")
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			object obj = 0;
			nint num = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r8_v4+40]");
			if (num2 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj3 = default(object);
				object obj2 = obj3 - 1;
				bool flag = obj2 == null;
				shaker.enabled = flag;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
		}
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0074: Expected O, but got I4
		if (1f < dc.damage && dc.damageSource != ItemKevin.damageSource && dc.damageSource != "HealthRegen" && !(damageNextShakeReadyTime > MyTime.time))
		{
			float num = MyTime.time + damageShakeCooldown;
			damageNextShakeReadyTime = num;
			ShakeInstance shakeInstance = shaker.Shake(damageShake, (int?)(object)0);
		}
	}

	private void OnObjectImpact(float shakeMultiplier)
	{
		//IL_0046: Expected O, but got I4
		ShakePreset shakePreset = objectImpactShake;
		float strength = shakeMultiplier + shakeMultiplier;
		shakePreset.strength = strength;
		ShakeInstance shakeInstance = shaker.Shake(objectImpactShake, (int?)(object)0);
	}

	private void OnGrindToggle(bool isGrinding)
	{
		//IL_005a: Expected O, but got I4
		if (!isGrinding)
		{
			if (grindShakeInstance != null)
			{
				grindShakeInstance.Stop(0.1f, removeWhenStopped: true);
			}
		}
		else
		{
			ShakeInstance shakeInstance = shaker.Shake(grindShake, (int?)(object)0);
			grindShakeInstance = shakeInstance;
		}
	}

	private void OnPylonsStarted()
	{
		//IL_0016: Expected O, but got I4
		ShakeInstance shakeInstance = shaker.Shake(pylonSpawnShake, (int?)(object)0);
	}
}
