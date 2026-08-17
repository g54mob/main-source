using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;

public class ControllerShaker : MonoBehaviour
{
	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnPlayerTakeDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
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
				obj4 = 0;
				goto IL_020d;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<float> b2 = OnPlayerLanded;
		Delegate obj6 = Delegate.Combine(PlayerMovement.A_Landed, b2);
		if ((object)obj6 == null)
		{
			PlayerMovement.A_Landed = (Action<float>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<float> action2 = default(Action<float>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<float>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerMovement.A_Landed = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<float>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnPlayerTakeDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
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
				obj4 = 0;
				goto IL_020d;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<float> value2 = OnPlayerLanded;
		Delegate obj6 = Delegate.Remove(PlayerMovement.A_Landed, value2);
		if ((object)obj6 == null)
		{
			PlayerMovement.A_Landed = (Action<float>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<float> action2 = default(Action<float>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<float>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerMovement.A_Landed = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<float>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private void OnPlayerTakeDamage(PlayerHealth ph, DamageContainer dc, bool isShield)
	{
		if (!ph.IsDead())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 33 Invalid \"Jump target not found in method: 0x1804C3BB0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 38 Invalid \"Jump target not found in method: 0x1804C3BB0\"");
		throw new NullReferenceException();
	}

	private void OnPlayerLanded(float speed)
	{
		if (speed > 25f)
		{
			Shake(1, 0.08f, 0.15f);
		}
	}

	public static void Shake(int motor, float intensity, float duration)
	{
		//IL_0038: Expected I, but got O
		//IL_0046: Expected I, but got O
		//IL_0056: Expected O, but got I
		//IL_0092: Expected O, but got I
		if (!CanShake())
		{
			return;
		}
		Controller lastActiveController = MyInputManager.GetLastActiveController();
		if (lastActiveController == null)
		{
			return;
		}
		nint num = (nint)lastActiveController;
		nint num2 = (nint)typeof(Joystick);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v7 (Il2CppClass<Rewired.Joystick>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r8_v3 (Il2CppClass<Rewired.Controller>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v7 (Il2CppClass<Rewired.Joystick>)+130]");
		if (num3 < 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r8_v3 (Il2CppClass<Rewired.Controller>)+C8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v8+FFFFFFF8+v162 @ rcx_v7*8]");
		if (0 != (nint)typeof(Joystick))
		{
			return;
		}
		int vibrationMotorCount = ((Joystick)lastActiveController).vibrationMotorCount;
		if (vibrationMotorCount <= 0)
		{
			return;
		}
		bool flag = motor <= 0;
		int motorIndex = motor;
		if (!flag)
		{
			int vibrationMotorCount2 = ((Joystick)lastActiveController).vibrationMotorCount;
			bool flag2 = vibrationMotorCount2 <= 1;
			int num4 = 0;
			if (!flag2)
			{
				num4 = motor;
			}
			motorIndex = num4;
		}
		Player player = MyInputManager.GetPlayer();
		player.SetVibration(motorIndex, intensity, duration);
	}

	public static void StopShakes()
	{
		if (CanShake())
		{
			Player player = MyInputManager.GetPlayer();
			player.StopVibration();
		}
	}

	private static bool CanShake()
	{
		//IL_01db: Expected I4, but got O
		//IL_009d: Invalid comparison between I4 and F4
		//IL_011a: Expected I, but got O
		//IL_0122: Expected I, but got O
		//IL_0132: Expected O, but got I
		//IL_016e: Expected O, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFControlSettings cfControlSettings = config.cfControlSettings;
				if (config.cfControlSettings != null)
				{
					if (0f < cfControlSettings.controller_vibration)
					{
						Controller lastActiveController = MyInputManager.GetLastActiveController();
						if (lastActiveController != null)
						{
							ControllerType type = lastActiveController.type;
							if (type == ControllerType.Joystick)
							{
								nint num = (nint)typeof(Joystick);
								nint num2 = (nint)lastActiveController;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v3 (Il2CppClass<Rewired.Joystick>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v16 (Il2CppClass<Rewired.Controller>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v3 (Il2CppClass<Rewired.Joystick>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v16 (Il2CppClass<Rewired.Controller>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v17+FFFFFFF8+v218 @ rcx_v13*8]");
									if (0 == (nint)typeof(Joystick) && ((Joystick)lastActiveController).supportsVibration)
									{
										return true;
									}
								}
							}
						}
					}
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static float GetGlobalIntensity()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFControlSettings cfControlSettings = config.cfControlSettings;
		return cfControlSettings.controller_vibration;
	}
}
