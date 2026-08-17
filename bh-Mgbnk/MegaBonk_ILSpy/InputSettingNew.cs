using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Rewired;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class InputSettingNew : BetterSetting
{
	private class Hostage
	{
		public ActionElementMap actionElementMap;

		public Controller controller;

		public int elementIdentifierId;

		public Hostage(ActionElementMap actionElementMap)
		{
			this.actionElementMap = actionElementMap;
			Controller controller = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
			this.controller = controller;
			elementIdentifierId = actionElementMap._elementIdentifierId;
		}
	}

	public struct InputKey : IEquatable<InputKey>
	{
		public int elementId;

		public ControllerType controllerType;

		public int controllerId;

		public bool Equals(InputKey other)
		{
			//IL_0060: Expected O, but got I4
			if (elementId == other.elementId && controllerType == other.controllerType)
			{
				object obj = other.controllerId - controllerId;
				return obj == null;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			//IL_0013: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_00f1: Expected O, but got I
			if (obj != null)
			{
				nint num = (nint)typeof(InputKey);
				bool flag = (object)obj.GetType() != typeof(InputKey);
				object obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if (obj2 != null)
				{
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v3 (Il2CppClass<System.Object>)+40]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<InputSettingNew+InputKey>)+40]");
					if (num3 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object obj3 = default(object);
					if (elementId == (nint)obj3)
					{
						ControllerType num4 = controllerType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v8+4]");
						if ((nint)num4 == (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v8+8]");
							object obj4 = -controllerId;
							return obj4 == null;
						}
					}
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B3B960");
			(int, System.Int32Enum, int) tuple = default((int, System.Int32Enum, int));
			return tuple.GetHashCode();
		}
	}

	public MyGlyphDisplay[] glyphContainers;

	public MyButtonSetting b_settingButton;

	private Controller currentController;

	private bool isController;

	private int actionId;

	private bool isInitialized;

	private static int selectedIndex = 0;

	private static Dictionary<InputKey, int> elementToGlyphPosition;

	private Hostage hostage;

	private ActionElementMap aemKeyboard;

	private ActionElementMap aemMouse;

	private ActionElementMap aemController;

	public static Action A_MappingUpdated;

	private new void Awake()
	{
		//IL_04ab: Expected I, but got O
		//IL_04d6: Expected I, but got O
		//IL_04df: Expected O, but got I4
		//IL_006d: Expected I, but got O
		//IL_0123: Expected O, but got I4
		//IL_0509: Expected I, but got O
		//IL_0512: Expected O, but got I4
		//IL_0525: Expected I, but got O
		//IL_0559: Expected O, but got I4
		//IL_0774: Expected I, but got O
		//IL_0584: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_0283: Expected I, but got O
		//IL_02c4: Expected O, but got I4
		//IL_02d7: Expected I, but got O
		//IL_0615: Expected O, but got I4
		//IL_0625: Expected I, but got O
		//IL_0633: Expected I, but got O
		//IL_0661: Expected O, but got I4
		//IL_0677: Expected I, but got O
		//IL_07b4: Expected I, but got O
		//IL_06d6: Expected O, but got I4
		//IL_06ec: Expected I, but got O
		//IL_071f: Expected I, but got O
		//IL_0728: Expected O, but got I4
		base.Awake();
		MyButtonSetting myButtonSetting = b_settingButton;
		bool flag = (object)b_settingButton == null;
		nint num = unchecked((nint)null);
		nint num3;
		Delegate obj6;
		Action action3;
		Action action2;
		Delegate a_StartHover;
		Action typeFromHandle;
		nint num2;
		nint num4;
		if (!flag)
		{
			a_StartHover = myButtonSetting.A_StartHover;
			Action action = StartHover;
			Delegate obj = Delegate.Combine(myButtonSetting.A_StartHover, action);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				myButtonSetting.A_StartHover = null;
				num = unchecked((nint)null);
			}
			else
			{
				bool flag2 = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag2)
				{
					obj2 = obj;
				}
				bool flag3 = (object)obj2 == null;
				num2 = (nint)typeof(Action);
				obj3 = 0;
				obj4 = null;
				if (flag3)
				{
					goto IL_073e;
				}
				myButtonSetting.A_StartHover = (Action)obj2;
				bool flag4 = (object)obj.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag4)
				{
					obj5 = obj;
				}
				bool flag5 = (object)obj5 == null;
				num = (nint)obj5;
				obj3 = 0;
				obj4 = null;
				num3 = (nint)typeof(Action);
				if (flag5)
				{
					goto IL_0749;
				}
			}
			MyButtonSetting myButtonSetting2 = b_settingButton;
			bool flag6 = (object)b_settingButton == null;
			action2 = action;
			obj3 = 0;
			obj4 = null;
			if (!flag6)
			{
				Action b = StopHover;
				obj6 = Delegate.Combine(myButtonSetting2.A_StopHover, b);
				if ((object)obj6 == null)
				{
					myButtonSetting2.A_StopHover = null;
				}
				else
				{
					bool flag7 = (object)obj6.GetType() != typeof(Action);
					Delegate obj7 = null;
					if (!flag7)
					{
						obj7 = obj6;
					}
					bool flag8 = (object)obj7 == null;
					typeFromHandle = (Action)(object)typeof(Action);
					obj3 = 0;
					obj4 = null;
					if (flag8)
					{
						goto IL_0761;
					}
					myButtonSetting2.A_StopHover = (Action)obj7;
					bool flag9 = (object)obj6.GetType() != typeof(Action);
					Delegate obj8 = null;
					if (!flag9)
					{
						obj8 = obj6;
					}
					bool flag10 = (object)obj8 == null;
					obj3 = 0;
					obj4 = null;
					action3 = (Action)(object)typeof(Action);
					if (flag10)
					{
						goto IL_0779;
					}
				}
				Action<Controller> b2 = RefreshController;
				Delegate obj9 = Delegate.Combine(MyInputManager.A_SetCurrentController, b2);
				if ((object)obj9 == null)
				{
					MyInputManager.A_SetCurrentController = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<Controller> action4 = default(Action<Controller>);
					bool flag11 = action4 == null;
					action2 = (Action)obj9;
					obj3 = 0;
					obj4 = null;
					num4 = (nint)typeof(Action<Controller>);
					if (flag11)
					{
						goto IL_05cd;
					}
					MyInputManager.A_SetCurrentController = action4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj10 = default(object);
					bool flag12 = obj10 == null;
					action2 = (Action)obj9;
					obj3 = 0;
					obj4 = null;
					num4 = (nint)typeof(Action<Controller>);
					if (flag12)
					{
						goto IL_05e5;
					}
				}
				a_StartHover = Settings.A_ResetRewiredControls;
				Action action5 = OnControlsReset;
				Delegate obj11 = Delegate.Combine(Settings.A_ResetRewiredControls, action5);
				if ((object)obj11 == null)
				{
					Settings.A_ResetRewiredControls = null;
				}
				else
				{
					bool flag13 = (object)obj11.GetType() != typeof(Action);
					Delegate obj12 = null;
					if (!flag13)
					{
						obj12 = obj11;
					}
					bool flag14 = (object)obj12 == null;
					action2 = action5;
					obj3 = 0;
					obj4 = obj11;
					num4 = (nint)a_StartHover;
					nint num5 = (nint)typeof(Action);
					if (flag14)
					{
						goto IL_0791;
					}
					Settings.A_ResetRewiredControls = (Action)obj12;
					bool flag15 = (object)obj11.GetType() != typeof(Action);
					Delegate obj13 = null;
					if (!flag15)
					{
						obj13 = obj11;
					}
					bool flag16 = (object)obj13 == null;
					action2 = action5;
					obj3 = 0;
					obj4 = obj11;
					nint num6 = (nint)typeof(Action);
					if (flag16)
					{
						goto IL_07a1;
					}
				}
				a_StartHover = A_MappingUpdated;
				Action action6 = OnMappingUpdated;
				Delegate obj14 = Delegate.Combine(A_MappingUpdated, action6);
				if ((object)obj14 == null)
				{
					A_MappingUpdated = null;
					return;
				}
				bool flag17 = (object)obj14.GetType() != typeof(Action);
				Delegate obj15 = null;
				if (!flag17)
				{
					obj15 = obj14;
				}
				bool flag18 = (object)obj15 == null;
				action2 = action6;
				obj3 = 0;
				obj4 = obj14;
				nint num7 = (nint)typeof(Action);
				if (!flag18)
				{
					A_MappingUpdated = (Action)obj15;
					bool flag19 = (object)obj14.GetType() != typeof(Action);
					Delegate obj16 = null;
					if (!flag19)
					{
						obj16 = obj14;
					}
					bool flag20 = (object)obj16 == null;
					action2 = action6;
					num = (nint)typeof(Action);
					obj3 = 0;
					obj4 = obj14;
					if (!flag20)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				goto IL_07a1;
			}
		}
		throw new NullReferenceException();
		IL_05cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		action3 = action2;
		goto IL_0779;
		IL_05e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05cd;
		IL_073e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0779:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		typeFromHandle = action3;
		goto IL_0761;
		IL_0749:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num3;
		goto IL_073e;
		IL_0791:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05e5;
		IL_0761:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num3 = (nint)obj6;
		goto IL_0749;
		IL_07a1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = (nint)a_StartHover;
		goto IL_0791;
	}

	private new void OnDestroy()
	{
		//IL_058e: Expected I, but got O
		//IL_059f: Expected O, but got I4
		//IL_0039: Expected I, but got O
		//IL_0095: Expected I, but got O
		//IL_00a3: Expected I, but got O
		//IL_00b4: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0113: Expected I, but got O
		//IL_061a: Expected I, but got O
		//IL_0623: Expected O, but got I4
		//IL_021f: Expected O, but got I4
		//IL_08fe: Expected I, but got O
		//IL_0656: Expected O, but got I4
		//IL_0669: Expected I, but got O
		//IL_0693: Expected I, but got O
		//IL_06b2: Expected O, but got I4
		//IL_06e1: Expected I, but got O
		//IL_06f2: Expected O, but got I4
		//IL_0369: Expected I, but got O
		//IL_037a: Expected O, but got I4
		//IL_03bd: Expected I, but got O
		//IL_03ce: Expected O, but got I4
		//IL_03ea: Expected I, but got O
		//IL_0783: Expected O, but got I4
		//IL_0799: Expected I, but got O
		//IL_07f4: Expected I, but got O
		//IL_07c7: Expected O, but got I4
		//IL_07dd: Expected I, but got O
		//IL_083c: Expected O, but got I4
		//IL_0852: Expected I, but got O
		//IL_0880: Expected O, but got I4
		//IL_0896: Expected I, but got O
		Action<Locale> action = base.OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= action;
		Action<string, object, object> action2 = base.OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, action2);
		nint num2;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			num = (nint)CurrentSettings.A_SettingUpdated;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			if (action3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0953;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<string, object, object>);
			nint num3 = (nint)typeof(Action<string, object, object>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		MyButtonSetting myButtonSetting = b_settingButton;
		bool flag2 = (object)b_settingButton == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = null;
		nint num5;
		Delegate obj9 = default(Delegate);
		Delegate obj12;
		Delegate typeFromHandle;
		nint num4;
		if (!flag2)
		{
			num = (nint)myButtonSetting.A_StartHover;
			Action action4 = StartHover;
			Delegate obj6 = Delegate.Combine(myButtonSetting.A_StartHover, action4);
			if ((object)obj6 == null)
			{
				myButtonSetting.A_StartHover = null;
			}
			else
			{
				bool flag3 = (object)obj6.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag3)
				{
					obj7 = obj6;
				}
				bool flag4 = (object)obj7 == null;
				obj2 = action4;
				num4 = (nint)typeof(Action);
				obj3 = 0;
				obj4 = null;
				if (flag4)
				{
					goto IL_08c3;
				}
				myButtonSetting.A_StartHover = (Action)obj7;
				bool flag5 = (object)obj6.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag5)
				{
					obj8 = obj6;
				}
				bool flag6 = (object)obj8 == null;
				obj2 = action4;
				obj3 = 0;
				obj4 = null;
				num5 = (nint)typeof(Action);
				if (flag6)
				{
					goto IL_08d3;
				}
			}
			MyButtonSetting myButtonSetting2 = b_settingButton;
			bool flag7 = (object)b_settingButton == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = null;
			if (!flag7)
			{
				Action action5 = StopHover;
				obj9 = Delegate.Combine(myButtonSetting2.A_StopHover, action5);
				if ((object)obj9 == null)
				{
					myButtonSetting2.A_StopHover = null;
				}
				else
				{
					bool flag8 = (object)obj9.GetType() != typeof(Action);
					Delegate obj10 = null;
					if (!flag8)
					{
						obj10 = obj9;
					}
					bool flag9 = (object)obj10 == null;
					num = (nint)myButtonSetting2.A_StopHover;
					obj2 = action5;
					typeFromHandle = (Delegate)(object)typeof(Action);
					obj3 = 0;
					obj4 = null;
					if (flag9)
					{
						goto IL_08eb;
					}
					myButtonSetting2.A_StopHover = (Action)obj10;
					bool flag10 = (object)obj9.GetType() != typeof(Action);
					Delegate obj11 = null;
					if (!flag10)
					{
						obj11 = obj9;
					}
					bool flag11 = (object)obj11 == null;
					num2 = (nint)myButtonSetting2.A_StopHover;
					obj2 = action5;
					obj3 = 0;
					obj4 = null;
					obj12 = (Delegate)(object)typeof(Action);
					if (flag11)
					{
						goto IL_0903;
					}
				}
				Action<Controller> action6 = RefreshController;
				Delegate obj13 = Delegate.Remove(MyInputManager.A_SetCurrentController, action6);
				if ((object)obj13 == null)
				{
					MyInputManager.A_SetCurrentController = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<Controller> action7 = default(Action<Controller>);
					bool flag12 = action7 == null;
					num2 = (nint)typeof(Action<Controller>);
					obj2 = obj13;
					obj3 = 0;
					obj4 = null;
					if (flag12)
					{
						goto IL_073b;
					}
					MyInputManager.A_SetCurrentController = action7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj14 = default(object);
					bool flag13 = obj14 == null;
					num2 = (nint)typeof(Action<Controller>);
					obj2 = obj13;
					obj3 = 0;
					obj4 = null;
					if (flag13)
					{
						goto IL_0753;
					}
				}
				num2 = (nint)Settings.A_ResetRewiredControls;
				Action action8 = OnControlsReset;
				Delegate obj15 = Delegate.Remove(Settings.A_ResetRewiredControls, action8);
				if ((object)obj15 == null)
				{
					Settings.A_ResetRewiredControls = null;
				}
				else
				{
					bool flag14 = (object)obj15.GetType() != typeof(Action);
					Delegate obj16 = null;
					if (!flag14)
					{
						obj16 = obj15;
					}
					bool flag15 = (object)obj16 == null;
					obj2 = action8;
					obj3 = 0;
					obj4 = obj15;
					nint num6 = (nint)typeof(Action);
					if (flag15)
					{
						goto IL_0923;
					}
					Settings.A_ResetRewiredControls = (Action)obj16;
					bool flag16 = (object)obj15.GetType() != typeof(Action);
					Delegate obj17 = null;
					if (!flag16)
					{
						obj17 = obj15;
					}
					bool flag17 = (object)obj17 == null;
					obj2 = action8;
					obj3 = 0;
					obj4 = obj15;
					nint num7 = (nint)typeof(Action);
					if (flag17)
					{
						goto IL_0933;
					}
				}
				num2 = (nint)A_MappingUpdated;
				Action action9 = OnMappingUpdated;
				Delegate obj18 = Delegate.Remove(A_MappingUpdated, action9);
				if ((object)obj18 == null)
				{
					A_MappingUpdated = null;
					return;
				}
				bool flag18 = (object)obj18.GetType() != typeof(Action);
				Delegate obj19 = null;
				if (!flag18)
				{
					obj19 = obj18;
				}
				bool flag19 = (object)obj19 == null;
				obj2 = action9;
				obj3 = 0;
				obj4 = obj18;
				nint num8 = (nint)typeof(Action);
				if (flag19)
				{
					goto IL_0943;
				}
				A_MappingUpdated = (Action)obj19;
				bool flag20 = (object)obj18.GetType() != typeof(Action);
				Delegate obj20 = null;
				if (!flag20)
				{
					obj20 = obj18;
				}
				bool flag21 = (object)obj20 == null;
				obj2 = action9;
				obj3 = 0;
				obj4 = obj18;
				nint num9 = (nint)typeof(Action);
				if (!flag21)
				{
					return;
				}
				goto IL_0953;
			}
		}
		goto IL_05e1;
		IL_0753:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_073b;
		IL_0903:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		typeFromHandle = obj12;
		goto IL_08eb;
		IL_0953:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0943;
		IL_0943:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0933;
		IL_08d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = num5;
		goto IL_08c3;
		IL_08eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num5 = (nint)obj9;
		goto IL_08d3;
		IL_0933:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0923;
		IL_073b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj12 = obj2;
		goto IL_0903;
		IL_05e1:
		throw new NullReferenceException();
		IL_0923:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0753;
		IL_08c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05e1;
	}

	private void OnMappingUpdated()
	{
		ShowValue();
	}

	private void OnEnable()
	{
		if (MyInputManager._003CcurrentController_003Ek__BackingField != currentController)
		{
			currentController = MyInputManager._003CcurrentController_003Ek__BackingField;
			ShowValue();
		}
		CheckController();
	}

	private void CheckController()
	{
		if (isController)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			int joystickCount = controllers.joystickCount;
			int num = joystickCount ^ joystickCount;
			int num2 = joystickCount & num;
			bool flag = num2 < 0;
			bool flag2 = joystickCount < 0;
			bool flag3 = joystickCount == 0;
			bool flag4 = flag2 != flag;
			bool active = flag4 | flag3;
			disabledOverlay.SetActive(active);
		}
	}

	private void StartHover()
	{
		MyGlyphDisplay[] array = glyphContainers;
		int num = selectedIndex;
		MyGlyphDisplay myGlyphDisplay = array[num];
		myGlyphDisplay.hoverOverlay.SetActive(value: true);
	}

	private void StopHover()
	{
		MyGlyphDisplay[] array = glyphContainers;
		int num = selectedIndex;
		MyGlyphDisplay myGlyphDisplay = array[num];
		myGlyphDisplay.hoverOverlay.SetActive(value: false);
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
		MyGlyphDisplay[] array = glyphContainers;
		int num = selectedIndex;
		int num2;
		if (dir >= 0)
		{
			num2 = array.Length - 1;
			if (dir > num2)
			{
				goto IL_0116;
			}
		}
		bool flag = dir >= 0;
		num2 = dir;
		if (!flag)
		{
			num2 = 0;
		}
		goto IL_0116;
		IL_0116:
		selectedIndex = num2;
		if (selectedIndex != selectedIndex)
		{
			MyGlyphDisplay[] array2 = glyphContainers;
			MyGlyphDisplay myGlyphDisplay = array2[num];
			myGlyphDisplay.hoverOverlay.SetActive(value: false);
			MyGlyphDisplay[] array3 = glyphContainers;
			int num3 = selectedIndex;
			MyGlyphDisplay myGlyphDisplay2 = array3[num3];
			myGlyphDisplay2.hoverOverlay.SetActive(value: true);
		}
	}

	private ControllerMap GetControllerMap()
	{
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(0);
			if (player != null)
			{
				Player.ControllerHelper controllers = player.controllers;
				if (player.controllers != null && controllers.maps != null)
				{
					return controllers.maps.GetMap(currentController, "Default", "Default");
				}
			}
		}
		return (ControllerMap)(object)new NullReferenceException();
	}

	private ControllerMap GetKeyboardMap()
	{
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(0);
			if (player != null)
			{
				Player.ControllerHelper controllers = player.controllers;
				string layoutName = default(string);
				if (player.controllers != null && controllers.maps != null)
				{
					return controllers.maps.GetMap(ControllerType.Keyboard, 0, "Default", layoutName);
				}
			}
		}
		return (ControllerMap)(object)new NullReferenceException();
	}

	private ControllerMap GetMouseMap()
	{
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(0);
			if (player != null)
			{
				Player.ControllerHelper controllers = player.controllers;
				string layoutName = default(string);
				if (player.controllers != null && controllers.maps != null)
				{
					return controllers.maps.GetMap(ControllerType.Mouse, 0, "Default", layoutName);
				}
			}
		}
		return (ControllerMap)(object)new NullReferenceException();
	}

	public void StartListening()
	{
		if (!disabledOverlay.activeSelf)
		{
			hostage = null;
			List<InputMapper.Context> contexts = (isController ? GetContextController() : GetContextKeyboardAndMouse());
			KeyListener.Instance.StartListening(this, contexts);
		}
	}

	public void ForceListen(int index)
	{
		selectedIndex = index;
		if (!disabledOverlay.activeSelf)
		{
			hostage = null;
			List<InputMapper.Context> contexts = (isController ? GetContextController() : GetContextKeyboardAndMouse());
			KeyListener.Instance.StartListening(this, contexts);
		}
	}

	private unsafe List<InputMapper.Context> GetContextController()
	{
		//IL_00c6: Expected O, but got Ref
		//IL_0205: Expected O, but got Ref
		//IL_0242: Expected O, but got Ref
		InputMapper.Context context = new InputMapper.Context();
		ControllerMap controllerMap = GetControllerMap();
		if (context != null)
		{
			context.controllerMap = controllerMap;
			context.actionId = actionId;
			context.actionRange = AxisRange.Full;
			ModifyContext(context);
			if (context.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb != null)
			{
				IList<ActionElementMap> elementMaps = context.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb.ElementMaps;
				if (elementMaps != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					object obj2 = default(object);
					object obj = (object)(&obj2);
					InputSettingNew inputSettingNew = null;
					object obj3 = default(object);
					ActionElementMap actionElementMap = default(ActionElementMap);
					int num = default(int);
					int num3 = default(int);
					while (true)
					{
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj3 != null)
							{
								bool flag = obj2 == null;
								inputSettingNew = null;
								if (!flag)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									if (IsElementMapFilteredOut(actionElementMap))
									{
										continue;
									}
									if (actionElementMap != null)
									{
										if (actionElementMap._actionId != actionId)
										{
											continue;
										}
										if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
										{
											ControllerType controllerType = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
											if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
											{
												int controllerId = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
												if (elementToGlyphPosition != null)
												{
													bool flag2 = elementToGlyphPosition.ContainsKey((InputKey)(&num));
													bool flag3 = !flag2;
													int elementIdentifierId = actionElementMap._elementIdentifierId;
													if (flag3)
													{
														continue;
													}
													if (elementToGlyphPosition != null)
													{
														int num2 = elementToGlyphPosition.get_Item((InputKey)(&num3));
														bool flag4 = num2 != selectedIndex;
														elementIdentifierId = actionElementMap._elementIdentifierId;
														inputSettingNew = (InputSettingNew)(object)typeof(InputSettingNew);
														if (flag4)
														{
															continue;
														}
														context.actionElementMapToReplace = actionElementMap;
														Hostage hostage = new Hostage(null);
														hostage.actionElementMap = actionElementMap;
														if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
														{
															Controller controller = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
															hostage.controller = controller;
															hostage.elementIdentifierId = actionElementMap._elementIdentifierId;
															this.hostage = hostage;
															if (obj != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
															}
															break;
														}
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
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
							}
							break;
						}
						throw new NullReferenceException();
					}
					List<InputMapper.Context> list = new List<InputMapper.Context>();
					if (list != null)
					{
						list.Add(context);
						return list;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe List<InputMapper.Context> GetContextKeyboardAndMouse()
	{
		//IL_0445: Expected O, but got Ref
		//IL_0476: Expected O, but got Ref
		InputMapper.Context context = new InputMapper.Context();
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(0);
			if (player != null)
			{
				Player.ControllerHelper controllers = player.controllers;
				if (player.controllers != null && controllers.maps != null)
				{
					string layoutName = default(string);
					ControllerMap map = controllers.maps.GetMap(ControllerType.Keyboard, 0, "Default", layoutName);
					if (context != null)
					{
						context.controllerMap = map;
						context.actionId = actionId;
						context.actionRange = AxisRange.Full;
						InputMapper.Context context2 = new InputMapper.Context();
						ReInput.PlayerHelper players2 = ReInput.players;
						if (players2 != null)
						{
							Player player2 = players2.GetPlayer(0);
							if (player2 != null)
							{
								Player.ControllerHelper controllers2 = player2.controllers;
								if (player2.controllers != null && controllers2.maps != null)
								{
									ControllerMap map2 = controllers2.maps.GetMap(ControllerType.Mouse, 0, "Default", layoutName);
									if (context2 != null)
									{
										context2.controllerMap = map2;
										context2.actionId = actionId;
										context2.actionRange = AxisRange.Positive;
										ModifyContext(context);
										ModifyContext(context2);
										List<ActionElementMap> list = new List<ActionElementMap>();
										if (context.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb != null)
										{
											IList<ActionElementMap> elementMaps = context.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb.ElementMaps;
											List<object> collection = Enumerable.ToList((IEnumerable<object>)elementMaps);
											if (list != null)
											{
												((List<object>)(object)list).AddRange((IEnumerable<object>)collection);
												if (context2.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb != null)
												{
													IList<ActionElementMap> elementMaps2 = context2.EuVCvuVSiUfwUBHIIFxRGpjsmUXcb.ElementMaps;
													List<object> collection2 = Enumerable.ToList((IEnumerable<object>)elementMaps2);
													((List<object>)(object)list).AddRange((IEnumerable<object>)collection2);
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
													List<object>.Enumerator enumerator = default(List<object>.Enumerator);
													ActionElementMap actionElementMap = default(ActionElementMap);
													List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
													List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
													InputMapper.Context item;
													while (true)
													{
														if (enumerator.MoveNext())
														{
															if (IsElementMapFilteredOut(actionElementMap))
															{
																continue;
															}
															bool flag = actionElementMap == null;
															ControllerMap controllerMap = (ControllerMap)(object)this;
															if (!flag)
															{
																if (actionElementMap._actionId != actionId)
																{
																	continue;
																}
																controllerMap = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe;
																if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																{
																	ControllerType controllerType = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
																	controllerMap = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe;
																	if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																	{
																		int controllerId = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
																		bool flag2 = elementToGlyphPosition == null;
																		controllerMap = (ControllerMap)(object)elementToGlyphPosition;
																		if (!flag2)
																		{
																			if (!elementToGlyphPosition.ContainsKey((InputKey)(&enumerator2)))
																			{
																				continue;
																			}
																			bool flag3 = elementToGlyphPosition == null;
																			controllerMap = (ControllerMap)(object)elementToGlyphPosition;
																			if (!flag3)
																			{
																				int num = elementToGlyphPosition.get_Item((InputKey)(&enumerator3));
																				if (num != selectedIndex)
																				{
																					continue;
																				}
																				controllerMap = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe;
																				if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																				{
																					if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType != ControllerType.Keyboard)
																					{
																						controllerMap = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe;
																						if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																						{
																							ControllerType controllerType2 = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
																							if (controllerType2 == ControllerType.Mouse)
																							{
																								context2.actionElementMapToReplace = actionElementMap;
																								Hostage hostage = new Hostage(null);
																								hostage.actionElementMap = actionElementMap;
																								if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																								{
																									Controller controller = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
																									hostage.controller = controller;
																									hostage.elementIdentifierId = actionElementMap._elementIdentifierId;
																									this.hostage = hostage;
																									((List<ActionElementMap>.Enumerator*)(&enumerator))->Dispose();
																									item = context2;
																									break;
																								}
																								throw new NullReferenceException();
																							}
																							continue;
																						}
																						throw new NullReferenceException();
																					}
																					context.actionElementMapToReplace = actionElementMap;
																					Hostage hostage2 = new Hostage(null);
																					hostage2.actionElementMap = actionElementMap;
																					if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
																					{
																						Controller controller2 = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
																						hostage2.controller = controller2;
																						hostage2.elementIdentifierId = actionElementMap._elementIdentifierId;
																						this.hostage = hostage2;
																						((List<ActionElementMap>.Enumerator*)(&enumerator))->Dispose();
																						item = context2;
																						break;
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
															throw new NullReferenceException();
														}
														((List<ActionElementMap>.Enumerator*)(&enumerator))->Dispose();
														item = context2;
														break;
													}
													List<InputMapper.Context> list2 = new List<InputMapper.Context>();
													if (list2 != null)
													{
														list2.Add(context);
														list2.Add(item);
														return list2;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void TryInit()
	{
		//IL_00c3: Expected O, but got I
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF || isInitialized)
		{
			return;
		}
		isInitialized = true;
		ReInput.MappingHelper mapping = ReInput.mapping;
		bool flag = mapping == null;
		string text = null;
		NullReferenceException ex;
		if (!flag)
		{
			text = (string)_settingValue;
			bool flag2 = _settingValue == null;
			string text2 = null;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				ex = (NullReferenceException)0;
				string text3 = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				bool flag3 = text3 != null;
				text2 = null;
				if (!flag3)
				{
					text2 = (string)_settingValue;
				}
				if (text2 == null)
				{
					goto IL_01b2;
				}
			}
			int num = mapping.GetActionId(text2);
			text = _settingName;
			actionId = num;
			if (_settingName != null)
			{
				bool flag4 = _settingName.Contains("controller");
				isController = flag4;
				currentController = MyInputManager._003CcurrentController_003Ek__BackingField;
				return;
			}
		}
		ex = new NullReferenceException();
		goto IL_01b2;
		IL_01b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected unsafe override void ShowValue()
	{
		//IL_00cb: Expected O, but got I
		//IL_030d: Expected O, but got Ref
		//IL_05a5: Expected O, but got Ref
		//IL_0495: Expected O, but got I4
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_072c: Expected O, but got I4
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected O, but got Unknown
		string text;
		NullReferenceException ex;
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF && !isInitialized)
		{
			isInitialized = true;
			ReInput.MappingHelper mapping = ReInput.mapping;
			bool flag = mapping == null;
			ReInput.MappingHelper mappingHelper = mapping;
			text = null;
			if (!flag)
			{
				text = (string)_settingValue;
				bool flag2 = _settingValue == null;
				string text2 = null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					ex = (NullReferenceException)0;
					string text3 = text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					bool flag3 = text3 != null;
					text2 = null;
					if (!flag3)
					{
						text2 = (string)_settingValue;
					}
					bool flag4 = text2 == null;
					mappingHelper = mapping;
					if (flag4)
					{
						goto IL_092b;
					}
				}
				int num = mapping.GetActionId(text2);
				actionId = num;
				text = _settingName;
				bool flag5 = _settingName == null;
				IEnumerator<ControllerMap> enumerator = null;
				mappingHelper = mapping;
				if (!flag5)
				{
					bool flag6 = _settingName.Contains("controller");
					isController = flag6;
					currentController = MyInputManager._003CcurrentController_003Ek__BackingField;
					enumerator = null;
					mappingHelper = mapping;
					goto IL_0878;
				}
			}
			goto IL_07dd;
		}
		goto IL_0878;
		IL_091b:
		IList<ControllerMap> maps;
		ShowMapBindings(maps);
		return;
		IL_0878:
		CheckController();
		ReInput.PlayerHelper players = ReInput.players;
		bool flag7 = players == null;
		text = null;
		if (!flag7)
		{
			Player player = players.GetPlayer(0);
			if (!isController)
			{
				List<ControllerMap> list = new List<ControllerMap>();
				bool flag8 = player == null;
				IEnumerator<ControllerMap> enumerator = null;
				text = (string)(object)list;
				if (!flag8)
				{
					Player.ControllerHelper controllers = player.controllers;
					bool flag9 = player.controllers == null;
					enumerator = null;
					text = (string)(object)list;
					if (!flag9)
					{
						Keyboard keyboard = player.controllers.Keyboard;
						bool flag10 = controllers.maps == null;
						enumerator = null;
						text = (string)(object)player.controllers;
						if (!flag10)
						{
							IList<ControllerMap> maps2 = controllers.maps.GetMaps(keyboard);
							bool flag11 = maps2 == null;
							enumerator = null;
							text = (string)(object)controllers.maps;
							if (!flag11)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								IEnumerator<ControllerMap> enumerator2 = default(IEnumerator<ControllerMap>);
								object obj = (object)(&enumerator2);
								text = null;
								object obj2 = default(object);
								while (true)
								{
									if (enumerator2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										if (obj2 == null)
										{
											break;
										}
										bool flag12 = enumerator2 == null;
										text = null;
										if (!flag12)
										{
											ControllerMap current = enumerator2.Current;
											bool flag13 = list == null;
											text = (string)(object)enumerator2;
											if (!flag13)
											{
												int version = list._version + 1;
												list._version = version;
												text = (string)(object)list._items;
												if (list._items != null)
												{
													int size = list._size;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rcx_v71 (System.String)+18]");
													if ((nint)size >= (nint)0)
													{
														((List<object>)(object)list).AddWithResize((object)current);
														ReInput.MappingHelper mappingHelper = (ReInput.MappingHelper)(object)current;
														text = (string)(object)list;
														continue;
													}
													int size2 = list._size + 1;
													list._size = size2;
													int size3 = list._size;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rcx_v71 (System.String)+18]");
													if ((nint)size3 < (nint)0)
													{
														object obj3 = list._size * 8;
														object obj4 = (object)list._items + obj3;
														text = (string)(obj4 + 32);
														ReInput.MappingHelper mappingHelper = (ReInput.MappingHelper)(object)current;
														continue;
													}
													goto IL_08ab;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								bool flag14 = obj == null;
								enumerator = enumerator2;
								text = null;
								if (!flag14)
								{
									enumerator = (IEnumerator<ControllerMap>)obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
									text = null;
								}
								Player.ControllerHelper controllers2 = player.controllers;
								if (player.controllers != null)
								{
									Mouse mouse = player.controllers.Mouse;
									bool flag15 = controllers2.maps == null;
									text = (string)(object)player.controllers;
									if (!flag15)
									{
										IList<ControllerMap> maps3 = controllers2.maps.GetMaps(mouse);
										bool flag16 = maps3 == null;
										enumerator = null;
										text = (string)(object)controllers2.maps;
										if (!flag16)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
											IEnumerator enumerator3 = default(IEnumerator);
											object obj5 = (object)(&enumerator3);
											text = null;
											while (true)
											{
												if (enumerator3 != null)
												{
													if (!enumerator3.MoveNext())
													{
														break;
													}
													bool flag17 = enumerator3 == null;
													text = (string)(object)enumerator3;
													if (!flag17)
													{
														ControllerMap current2 = ((IEnumerator<ControllerMap>)enumerator3).Current;
														bool flag18 = list == null;
														text = (string)(object)enumerator3;
														if (!flag18)
														{
															int version2 = list._version + 1;
															list._version = version2;
															text = (string)(object)list._items;
															if (list._items != null)
															{
																int size4 = list._size;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rcx_v71 (System.String)+18]");
																if ((nint)size4 >= (nint)0)
																{
																	((List<object>)(object)list).AddWithResize((object)current2);
																	text = (string)(object)list;
																	continue;
																}
																int size5 = list._size + 1;
																list._size = size5;
																int size6 = list._size;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rcx_v71 (System.String)+18]");
																if ((nint)size6 < (nint)0)
																{
																	object obj6 = list._size * 8;
																	object obj7 = (object)list._items + obj6;
																	text = (string)(obj7 + 32);
																	continue;
																}
																throw new IndexOutOfRangeException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											if (obj5 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
											}
											maps = list;
											goto IL_091b;
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				List<ControllerMap> list2 = new List<ControllerMap>();
				ControllerMap controllerMap = GetControllerMap();
				bool flag19 = list2 == null;
				IEnumerator<ControllerMap> enumerator = null;
				text = (string)(object)this;
				if (!flag19)
				{
					list2.Add(controllerMap);
					maps = list2;
					goto IL_091b;
				}
			}
		}
		goto IL_07dd;
		IL_07dd:
		ex = new NullReferenceException();
		goto IL_092b;
		IL_08ab:
		throw new IndexOutOfRangeException();
		IL_092b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ab;
	}

	private unsafe void ShowMapBindings(IList<ControllerMap> maps)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_005c: Expected O, but got Ref
		//IL_0070: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0199: Expected O, but got Ref
		//IL_02f0: Expected O, but got Ref
		//IL_0332: Expected O, but got Ref
		//IL_03e4: Expected O, but got I4
		MyGlyphDisplay[] array = glyphContainers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].Set(null);
			obj++;
			obj2 = obj;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		object obj4 = default(object);
		object obj3 = (object)(&obj4);
		int num = 0;
		object obj5 = array.Length;
		ReInput.MappingHelper mappingHelper = null;
		object obj6 = default(object);
		ControllerMap controllerMap = default(ControllerMap);
		object obj8 = default(object);
		object obj9 = default(object);
		ActionElementMap actionElementMap = default(ActionElementMap);
		int elementIdentifierId = default(int);
		int elementIdentifierId2 = default(int);
		while (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			if (obj6 != null)
			{
				bool flag = obj4 == null;
				mappingHelper = null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					bool flag2 = controllerMap == null;
					mappingHelper = null;
					if (flag2)
					{
						continue;
					}
					int categoryId = controllerMap.categoryId;
					ReInput.MappingHelper mapping = ReInput.mapping;
					bool flag3 = mapping == null;
					mappingHelper = null;
					if (!flag3)
					{
						int mapCategoryId = mapping.GetMapCategoryId("Default");
						if (categoryId != mapCategoryId)
						{
							continue;
						}
						IList<ActionElementMap> elementMaps = controllerMap.ElementMaps;
						if (elementMaps != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							object obj7 = (object)(&obj8);
							while (true)
							{
								if (obj8 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									if (obj9 == null)
									{
										break;
									}
									bool flag4 = obj8 == null;
									mappingHelper = null;
									if (!flag4)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										if (IsElementMapFilteredOut(actionElementMap))
										{
											continue;
										}
										if (num >= (nint)obj5)
										{
											break;
										}
										if (actionElementMap != null)
										{
											if (actionElementMap._actionId == actionId)
											{
												if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe == null)
												{
													throw new NullReferenceException();
												}
												ControllerType controllerType = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
												if (actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe == null)
												{
													throw new NullReferenceException();
												}
												int controllerId = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
												if (elementToGlyphPosition == null)
												{
													throw new NullReferenceException();
												}
												if (!elementToGlyphPosition.ContainsKey((InputKey)(&elementIdentifierId)))
												{
													TryAddInputKey(actionElementMap, num);
												}
												MyGlyphDisplay[] array2 = glyphContainers;
												if (elementToGlyphPosition == null)
												{
													throw new NullReferenceException();
												}
												int num2 = elementToGlyphPosition.get_Item((InputKey)(&elementIdentifierId2));
												if (glyphContainers == null)
												{
													throw new NullReferenceException();
												}
												if (num2 >= array2.Length)
												{
													throw new IndexOutOfRangeException();
												}
												if ((object)array2[num2] == null)
												{
													throw new NullReferenceException();
												}
												array2[num2].Set(actionElementMap);
												num++;
												elementIdentifierId2 = actionElementMap._elementIdentifierId;
												elementIdentifierId = actionElementMap._elementIdentifierId;
												obj5 = array.Length;
											}
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							if (obj7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								mappingHelper = null;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
			}
			return;
		}
		throw new NullReferenceException();
	}

	private bool IsElementMapFilteredOut(ActionElementMap actionElementMap)
	{
		//IL_014f: Expected I4, but got O
		//IL_00d4: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720B8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_settingName != "keyboard_move_forward" && _settingName != "keyboard_move_right")
		{
			if (_settingName != "keyboard_move_backward" && !(_settingName == "keyboard_move_left"))
			{
				goto IL_0135;
			}
			if (actionElementMap != null)
			{
				object obj = actionElementMap._axisContribution - 1;
				bool flag = obj == null;
				return !flag;
			}
		}
		else if (actionElementMap != null)
		{
			if (actionElementMap._axisContribution == Pole.Positive)
			{
				goto IL_0135;
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0135:
		return false;
	}

	private void ModifyContext(InputMapper.Context context)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720B9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_settingName != "keyboard_move_forward" && _settingName != "keyboard_move_right")
		{
			if (!(_settingName != "keyboard_move_backward") || _settingName == "keyboard_move_left")
			{
				context.actionRange = AxisRange.Negative;
			}
		}
		else
		{
			context.actionRange = AxisRange.Positive;
		}
	}

	private void ClearGlyphs()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		MyGlyphDisplay[] array = glyphContainers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].Set(null);
			obj2++;
			obj = obj2;
		}
	}

	private void RefreshController(Controller c)
	{
		if (c != currentController)
		{
			currentController = c;
			ShowValue();
		}
	}

	private void OnControlsReset()
	{
		elementToGlyphPosition.Clear();
		selectedIndex = 0;
		ShowValue();
	}

	public unsafe void UpdateMapping(bool result, ActionElementMap newActionElementMap)
	{
		//IL_00cf: Expected O, but got Ref
		if (result && newActionElementMap != null)
		{
			if (this.hostage != null)
			{
				Hostage hostage = this.hostage;
				if (hostage.actionElementMap != null)
				{
					ActionElementMap actionElementMap = hostage.actionElementMap;
					ControllerType controllerType = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
					Hostage hostage2 = this.hostage;
					ActionElementMap actionElementMap2 = hostage2.actionElementMap;
					int controllerId = actionElementMap2.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
					int num = default(int);
					TryRemoveInputKey((InputKey)(&num));
					Controller controller = newActionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
					string text = controller.name;
					Hostage hostage3 = this.hostage;
					string text2 = hostage3.controller.name;
					if (text != text2)
					{
						Hostage hostage4 = this.hostage;
						ActionElementMap actionElementMap3 = hostage4.actionElementMap;
						ActionElementMap actionElementMap4 = hostage4.actionElementMap;
						bool flag = actionElementMap3.VZbcOnbGHkbQCctumTLcvpEpIcLe.DeleteElementMap(actionElementMap4.nhahTzMMoVhwYeqkXRELLTHoCNHkA);
					}
				}
			}
			TryAddInputKey(newActionElementMap, selectedIndex);
		}
		ShowValue();
		Action a_MappingUpdated = A_MappingUpdated;
		if (A_MappingUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v132.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe void TryRemoveInputKey(ActionElementMap aem)
	{
		//IL_0034: Expected O, but got Ref
		ControllerType controllerType = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
		int controllerId = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
		int num = default(int);
		TryRemoveInputKey((InputKey)(&num));
	}

	private unsafe void TryRemoveInputKey(InputKey key)
	{
		//IL_0014: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		int num = default(int);
		if (elementToGlyphPosition.ContainsKey((InputKey)(&num)))
		{
			bool flag = elementToGlyphPosition.Remove((InputKey)(&num));
		}
	}

	private unsafe void TryAddInputKey(ActionElementMap aem, int index)
	{
		//IL_0045: Expected O, but got Ref
		ControllerType controllerType = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
		int controllerId = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
		object obj = default(object);
		elementToGlyphPosition.set_Item((InputKey)(&obj), index);
	}

	public unsafe InputKey GetNewInputKey(ActionElementMap aem)
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_0046: Expected native int or pointer, but got O
		//IL_0087: Expected native int or pointer, but got O
		//IL_00c8: Expected native int or pointer, but got O
		InputKey inputKey = default(InputKey);
		((InputKey*)(nint)inputKey)->elementId = 0;
		((InputKey*)(nint)inputKey)->controllerId = 0;
		if (aem != null)
		{
			((InputKey*)(nint)inputKey)->elementId = aem._elementIdentifierId;
			if (aem.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
			{
				ControllerType controllerType = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerType;
				((InputKey*)(nint)inputKey)->controllerType = controllerType;
				if (aem.VZbcOnbGHkbQCctumTLcvpEpIcLe != null)
				{
					int controllerId = aem.VZbcOnbGHkbQCctumTLcvpEpIcLe.controllerId;
					((InputKey*)(nint)inputKey)->controllerId = controllerId;
					return inputKey;
				}
			}
		}
		return (InputKey)new NullReferenceException();
	}

	private void OnInputMapped(InputMapper.InputMappedEventData obj)
	{
		ActionElementMap actionElementMap = obj.actionElementMap;
		if (actionElementMap._actionId == actionId)
		{
			ShowValue();
		}
	}

	static InputSettingNew()
	{
		Dictionary<InputKey, int> dictionary = new Dictionary<InputKey, int>();
		elementToGlyphPosition = dictionary;
	}
}
