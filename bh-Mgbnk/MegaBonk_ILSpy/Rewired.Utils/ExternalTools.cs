using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired.Internal;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Platforms.Windows;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Rewired.Utils;

public class ExternalTools : IExternalTools
{
	private static Func<object> _getPlatformInitializerDelegate;

	private bool _isEditorPaused;

	private Action<bool> _EditorPausedStateChangedEvent;

	private Action<uint, bool> m_XboxOneInput_OnGamepadStateChange;

	public static Func<object> getPlatformInitializerDelegate
	{
		get
		{
			return _getPlatformInitializerDelegate;
		}
		set
		{
			_getPlatformInitializerDelegate = value;
		}
	}

	public bool isEditorPaused => _isEditorPaused;

	public bool UnityInput_IsTouchPressureSupported => UnityEngine.Input.touchPressureSupported;

	public event Action<bool> EditorPausedStateChangedEvent
	{
		add
		{
			//IL_0094: Expected I, but got O
			//IL_006c: Expected I, but got O
			Delegate obj = Delegate.Combine(_EditorPausedStateChangedEvent, value);
			if ((object)obj == null)
			{
				_EditorPausedStateChangedEvent = (Action<bool>)obj;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action != null)
			{
				_EditorPausedStateChangedEvent = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag = obj2 == null;
				nint num = (nint)typeof(Action<bool>);
				if (!flag)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num = (nint)typeof(Action<bool>);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_0094: Expected I, but got O
			//IL_006c: Expected I, but got O
			Delegate obj = Delegate.Remove(_EditorPausedStateChangedEvent, value);
			if ((object)obj == null)
			{
				_EditorPausedStateChangedEvent = (Action<bool>)obj;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action != null)
			{
				_EditorPausedStateChangedEvent = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag = obj2 == null;
				nint num = (nint)typeof(Action<bool>);
				if (!flag)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num = (nint)typeof(Action<bool>);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}

	public event Action<uint, bool> XboxOneInput_OnGamepadStateChange
	{
		add
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			Delegate obj = this.m_XboxOneInput_OnGamepadStateChange;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = obj2;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag2 = (object)obj5 != obj;
				obj = obj5;
				if (!flag2)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			Delegate obj = this.m_XboxOneInput_OnGamepadStateChange;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = obj2;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag2 = (object)obj5 != obj;
				obj = obj5;
				if (!flag2)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}

	public void Destroy()
	{
	}

	public object GetPlatformInitializer()
	{
		return Main.GetPlatformInitializer();
	}

	public string GetFocusedEditorWindowTitle()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1+B8]");
		return (string)0;
	}

	public bool IsEditorSceneViewFocused()
	{
		return false;
	}

	public bool LinuxInput_IsJoystickPreconfigured(string name)
	{
		return false;
	}

	public int XboxOneInput_GetUserIdForGamepad(uint id)
	{
		return 0;
	}

	public ulong XboxOneInput_GetControllerId(uint unityJoystickId)
	{
		//IL_0006: Expected I8, but got I4
		return 0uL;
	}

	public bool XboxOneInput_IsGamepadActive(uint unityJoystickId)
	{
		return false;
	}

	public string XboxOneInput_GetControllerType(ulong xboxControllerId)
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1+B8]");
		return (string)0;
	}

	public uint XboxOneInput_GetJoystickId(ulong xboxControllerId)
	{
		return 0u;
	}

	public void XboxOne_Gamepad_UpdatePlugin()
	{
	}

	public bool XboxOne_Gamepad_SetGamepadVibration(ulong xboxOneJoystickId, float leftMotor, float rightMotor, float leftTriggerLevel, float rightTriggerLevel)
	{
		return false;
	}

	public void XboxOne_Gamepad_PulseVibrateMotor(ulong xboxOneJoystickId, int motorInt, float startLevel, float endLevel, ulong durationMS)
	{
	}

	public unsafe void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids)
	{
		List<int> list = new List<int>();
		ref List<int> reference = ref *(List<int>*)list;
		List<int> list2 = new List<int>();
		ref List<int> reference2 = ref *(List<int>*)list2;
	}

	public int GetAndroidAPILevel()
	{
		//IL_000a: Expected I4, but got I8
		return -1;
	}

	public void WindowsStandalone_ForwardRawInput(IntPtr rawInputHeaderIndices, IntPtr rawInputDataIndices, uint indicesCount, IntPtr rawInputData, uint rawInputDataSize)
	{
		IntPtr rawInputData2 = default(IntPtr);
		UnityEngine.Windows.Input.ForwardRawInput(rawInputHeaderIndices, rawInputDataIndices, indicesCount, rawInputData2, (uint)(nint)rawInputData);
	}

	public bool UnityUI_Graphic_GetRaycastTarget(object graphic)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00b6: Expected O, but got I4
		//IL_0200: Expected I4, but got O
		//IL_0106: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_011e: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_024b: Expected I, but got O
		UnityEngine.Object obj;
		if (graphic == null)
		{
			obj = null;
			goto IL_0205;
		}
		nint num = (nint)typeof(Graphic);
		nint num2 = (nint)graphic;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v5 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		UnityEngine.Object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v5 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v19+FFFFFFF8+v60 @ rax_v15*8]");
			bool flag = 0 == (nint)typeof(Graphic);
			obj4 = (UnityEngine.Object)1;
			if (flag)
			{
				goto IL_0221;
			}
		}
		obj4 = null;
		goto IL_0221;
		IL_0221:
		bool flag2 = (object)obj4 == null;
		obj = null;
		if (!flag2)
		{
			obj = (UnityEngine.Object)graphic;
		}
		goto IL_0205;
		IL_0205:
		if (obj != null)
		{
			if (graphic != null)
			{
				nint num4 = (nint)typeof(Graphic);
				nint num5 = (nint)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r9_v2 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v4 (Il2CppClass<System.Object>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r9_v2 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v4 (Il2CppClass<System.Object>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v9+FFFFFFF8+v167 @ rax_v8*8]");
					if (0 == (nint)typeof(Graphic))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r9_v2 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v9+FFFFFFF8+v211 @ r8_v3*8]");
						object obj8 = 0 - typeof(Graphic);
						bool flag3 = obj8 == null;
						bool flag4 = !flag3;
						object obj9 = null;
						if (!flag4)
						{
							obj9 = graphic;
						}
						nint num7 = (nint)obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v257 @ rax_v12 (Il2CppClass<System.Object>)+2B8] (should have been resolved before IL gen)");
						bool result = default(bool);
						return result;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00b6: Expected O, but got I4
		//IL_00e9: Expected I, but got O
		//IL_00f1: Expected I, but got O
		//IL_0101: Expected O, but got I
		//IL_013d: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0222: Expected I, but got O
		UnityEngine.Object obj;
		if (graphic == null)
		{
			obj = null;
			goto IL_01db;
		}
		nint num = (nint)typeof(Graphic);
		nint num2 = (nint)graphic;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v8 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v7 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v8 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		UnityEngine.Object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v7 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v19+FFFFFFF8+v63 @ rax_v15*8]");
			bool flag = 0 == (nint)typeof(Graphic);
			obj4 = (UnityEngine.Object)1;
			if (flag)
			{
				goto IL_01f7;
			}
		}
		obj4 = null;
		goto IL_01f7;
		IL_01f7:
		bool flag2 = (object)obj4 == null;
		obj = null;
		if (!flag2)
		{
			obj = (UnityEngine.Object)graphic;
		}
		goto IL_01db;
		IL_01db:
		if (!(obj != null))
		{
			return;
		}
		nint num4 = (nint)typeof(Graphic);
		nint num5 = (nint)graphic;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v5 (Il2CppClass<System.Object>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v5 (Il2CppClass<System.Object>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v9+FFFFFFF8+v203 @ rax_v8*8]");
			if (0 == (nint)typeof(Graphic))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v3 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v9+FFFFFFF8+v263 @ r8_v4*8]");
				object obj8 = 0 - typeof(Graphic);
				bool flag3 = obj8 == null;
				bool flag4 = !flag3;
				object obj9 = null;
				if (!flag4)
				{
					obj9 = graphic;
				}
				nint num7 = (nint)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ rax_v12 (Il2CppClass<System.Object>)+2C8] (should have been resolved before IL gen)");
				return;
			}
		}
		throw new NullReferenceException();
	}

	public float UnityInput_GetTouchPressure(ref Touch touch)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C5B0");
		float result = default(float);
		return result;
	}

	public float UnityInput_GetTouchMaximumPossiblePressure(ref Touch touch)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C570");
		float result = default(float);
		return result;
	}

	public unsafe IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload)
	{
		//IL_0012: Expected O, but got Ref
		object obj = default(object);
		return ControllerTemplateFactory.Create((Guid)(&obj), payload);
	}

	public Type[] GetControllerTemplateTypes()
	{
		return ControllerTemplateFactory._defaultTemplateTypes;
	}

	public Type[] GetControllerTemplateInterfaceTypes()
	{
		return ControllerTemplateFactory._defaultTemplateInterfaceTypes;
	}
}
