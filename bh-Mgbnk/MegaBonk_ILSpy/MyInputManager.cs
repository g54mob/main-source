using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using Rewired;
using Rewired.Integration.UnityUI;
using UnityEngine;

public class MyInputManager : MonoBehaviour
{
	public UserDataStore_FileCustom userDataStore;

	public RewiredStandaloneInputModule rewiredEventSystem;

	private static Controller _003CcurrentController_003Ek__BackingField;

	private static Player player;

	private static bool isSpaceNavigationActive = true;

	private static bool isHorizontalNavigationDuringChestActive = false;

	public static Action<Controller> A_SetCurrentController;

	public static string Jump = "Jump";

	public static string JumpBhop = "Jump Bhop";

	public static string Slide = "Slide";

	public static string Aim = "Aim";

	public static string Interact = "Interact";

	public static string QuickReset = "QuickReset";

	public static string MapOverlay = "MapOverlay";

	public static string Wallrun = "Wallrun";

	public static string MoveHorizontal = "Move Horizontal";

	public static string MoveVertical = "Move Vertical";

	public static string LookHorizontal = "Look Horizontal";

	public static string LookVertical = "Look Vertical";

	public static string UIHorizontal = "UIHorizontal";

	public static string UIVertical = "UIVertical";

	public static string UISubmit = "UISubmit";

	public static string UICancel = "UICancel";

	public static string UIAbort = "UIAbort";

	public static string UIShoulderLeft = "UIShoulderLeft";

	public static string UIShoulderRight = "UIShoulderRight";

	private static double mouseLastActiveTime;

	private bool isVerticalEnabled;

	private float vertUiInputDeadzoneEnter = 0.2f;

	private float vertUiInputDeadzoneExit = 0.2f;

	private float stoppedInputAtTime;

	private float resumeInputDelay = 4f;

	public static Controller currentController
	{
		get
		{
			return _003CcurrentController_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentController_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_0288: Expected O, but got I4
		//IL_03a7: Expected I, but got O
		//IL_0300: Expected O, but got I4
		//IL_0316: Expected I, but got O
		//IL_0124: Expected I, but got O
		//IL_0135: Expected O, but got I4
		//IL_0178: Expected I, but got O
		//IL_0189: Expected O, but got I4
		//IL_0204: Expected O, but got I4
		//IL_0258: Expected O, but got I4
		Player player = GetPlayer();
		MyInputManager.player = player;
		Delegate obj = SaveManager.A_SavesLoaded;
		Action action = OnSavesLoaded;
		Delegate obj2 = Delegate.Combine(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_03b4;
			}
			SaveManager.A_SavesLoaded = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03c4;
			}
		}
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj7 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_034c;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_035c;
			}
		}
		Action<Window> b2 = OnWindowOpened;
		Delegate obj10 = Delegate.Combine(WindowManager.A_WindowOpened, b2);
		if ((object)obj10 == null)
		{
			WindowManager.A_WindowOpened = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Window> action4 = default(Action<Window>);
		bool flag6 = action4 == null;
		obj = (Delegate)(object)typeof(Action<Window>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (flag6)
		{
			goto IL_0394;
		}
		WindowManager.A_WindowOpened = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		obj = (Delegate)(object)typeof(Action<Window>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (!flag7)
		{
			return;
		}
		goto IL_03b4;
		IL_034c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03c4;
		IL_0394:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_035c;
		IL_03c4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03b4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0394;
		IL_035c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034c;
	}

	private void OnDestroy()
	{
		//IL_026c: Expected O, but got I4
		//IL_035a: Expected I, but got O
		//IL_02b3: Expected O, but got I4
		//IL_02c9: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_015c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		Delegate obj = SaveManager.A_SavesLoaded;
		Action action = OnSavesLoaded;
		Delegate obj2 = Delegate.Remove(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_0367;
			}
			SaveManager.A_SavesLoaded = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03a8;
			}
		}
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj7 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_02ff;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_030f;
			}
		}
		Action<Window> value2 = OnWindowOpened;
		Delegate obj10 = Delegate.Remove(WindowManager.A_WindowOpened, value2);
		if ((object)obj10 == null)
		{
			WindowManager.A_WindowOpened = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Window> action4 = default(Action<Window>);
		bool flag6 = action4 == null;
		obj = (Delegate)(object)typeof(Action<Window>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (flag6)
		{
			goto IL_0347;
		}
		WindowManager.A_WindowOpened = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		obj = (Delegate)(object)typeof(Action<Window>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (!flag7)
		{
			return;
		}
		goto IL_0367;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a8;
		IL_0347:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_030f;
		IL_03a8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0367:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0347;
		IL_030f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02ff;
	}

	private void OnSavesLoaded()
	{
		userDataStore.UpdatePath();
		userDataStore.Load();
		RefreshSpaceNavigation();
	}

	private void Update()
	{
		CheckCurrentController();
		WindowUpdate();
		Vector3 mousePositionDelta = Input.mousePositionDelta;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (mousePositionDelta.x > 2f)
		{
			ReInput.TimeHelper time = ReInput.time;
			double unscaledTime = time.unscaledTime;
			mouseLastActiveTime = unscaledTime;
		}
	}

	public static bool IsUsingController()
	{
		//IL_00df: Expected I4, but got O
		//IL_0097: Expected I, but got O
		//IL_00b7: Expected O, but got I4
		Player player = GetPlayer();
		if (player != null)
		{
			if (player.controllers == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			Controller lastActiveController = player.controllers.GetLastActiveController();
			if (lastActiveController != null)
			{
				double lastTimeActive = lastActiveController.GetLastTimeActive();
				nint num = (nint)typeof(MyInputManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v9 (Il2CppClass<MyInputManager>)+E4]");
				if ((nint)0 <= (nint)0)
				{
					ControllerType type = lastActiveController.type;
					object obj = type - 2;
					return obj == null;
				}
			}
		}
		return false;
	}

	private void CheckCurrentController()
	{
		Controller controller = _003CcurrentController_003Ek__BackingField;
		Player player = GetPlayer();
		int joystickCount = player.controllers.joystickCount;
		if (joystickCount > 0)
		{
			Player player2 = GetPlayer();
			Controller lastActiveController = player2.controllers.GetLastActiveController(ControllerType.Joystick);
			if (lastActiveController != null)
			{
				Player player3 = GetPlayer();
				Controller lastActiveController2 = player3.controllers.GetLastActiveController(ControllerType.Joystick);
				controller = lastActiveController2;
			}
		}
		if (controller != _003CcurrentController_003Ek__BackingField)
		{
			SetController(controller);
		}
		else if (_003CcurrentController_003Ek__BackingField == null && controller == null)
		{
			Player player4 = MyInputManager.player;
			int joystickCount2 = player4.controllers.joystickCount;
			if (joystickCount2 > 0)
			{
				Player player5 = MyInputManager.player;
				IList<Joystick> joysticks = player5.controllers.Joysticks;
				Joystick controller2 = joysticks.get_Item(0);
				SetController(controller2);
			}
		}
	}

	public static Player GetPlayer()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.PlayerHelper players = ReInput.players;
			if (players != null)
			{
				if (MyInputManager.player == null)
				{
					ReInput.PlayerHelper players2 = ReInput.players;
					if (players2 == null)
					{
						return (Player)(object)new NullReferenceException();
					}
					Player player = players2.GetPlayer(0);
					MyInputManager.player = player;
				}
				return MyInputManager.player;
			}
		}
		return null;
	}

	public static Controller GetLastActiveController()
	{
		Player player = MyInputManager.player;
		if (MyInputManager.player != null && player.controllers != null)
		{
			return player.controllers.GetLastActiveController();
		}
		return (Controller)(object)new NullReferenceException();
	}

	public static bool GetButton(string action)
	{
		//IL_000e: Expected I4, but got O
		//IL_007b: Expected I4, but got O
		bool flag = (byte)(int)GetPlayer() != 0;
		if (flag)
		{
			Player player = GetPlayer();
			if (player != null)
			{
				return player.GetButton(action);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return flag;
	}

	public static bool GetButtonDown(string action)
	{
		//IL_000e: Expected I4, but got O
		//IL_007b: Expected I4, but got O
		bool flag = (byte)(int)GetPlayer() != 0;
		if (flag)
		{
			Player player = GetPlayer();
			if (player != null)
			{
				return player.GetButtonDown(action);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return flag;
	}

	public static bool GetButtonUp(string action)
	{
		//IL_000e: Expected I4, but got O
		//IL_007b: Expected I4, but got O
		bool flag = (byte)(int)GetPlayer() != 0;
		if (flag)
		{
			Player player = GetPlayer();
			if (player != null)
			{
				return player.GetButtonUp(action);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return flag;
	}

	public static float GetAxis(string action)
	{
		//IL_005a: Expected F4, but got I4
		Player player = GetPlayer();
		if (player != null)
		{
			Player player2 = GetPlayer();
			return player2.GetAxis(action);
		}
		return 0f;
	}

	private void SetController(Controller c)
	{
		//IL_0096: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_00bf: Expected O, but got I
		if (c != _003CcurrentController_003Ek__BackingField)
		{
			_003CcurrentController_003Ek__BackingField = c;
			Action<Controller> a_SetCurrentController = A_SetCurrentController;
			if (A_SetCurrentController != null)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rbx_v3 (System.Action`1<Rewired.Controller>)+28]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rbx_v3 (System.Action`1<Rewired.Controller>)+40]");
					object obj2 = 0;
					Controller controller = _003CcurrentController_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rbx_v3 (System.Action`1<Rewired.Controller>)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v135 @ rax_v16 (should have been resolved before IL gen)");
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	public unsafe static void RefreshSpaceNavigation()
	{
		//IL_009a: Expected I, but got O
		//IL_010d: Expected I, but got O
		//IL_0145: Expected O, but got I
		//IL_0225: Expected O, but got Ref
		//IL_026a: Expected I, but got O
		//IL_0296: Expected I, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField == null)
		{
			return;
		}
		ConfigSaveFile config = saveManager.config;
		if (saveManager.config == null || config.cfControlSettings == null)
		{
			return;
		}
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v12 (Il2CppClass<SaveManager>)+B8]");
		nint num2 = 0;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config2 = saveManager2.config;
			if (saveManager2.config != null)
			{
				num2 = (nint)config2.cfControlSettings;
				if (config2.cfControlSettings != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rcx_v11 (Il2CppStaticFields<SaveManager>)+C4]");
					object obj = -1;
					bool flag = obj == null;
					if (flag == isSpaceNavigationActive)
					{
						return;
					}
					isSpaceNavigationActive = flag;
					Player player = MyInputManager.player;
					Keyboard keyboard = player.controllers.Keyboard;
					Player player2 = MyInputManager.player;
					Player.ControllerHelper controllers = player2.controllers;
					Player.ControllerHelper.MapHelper maps = controllers.maps;
					if (controllers.maps != null)
					{
						ControllerMap map = controllers.maps.GetMap(keyboard, "UI", "Default");
						if (map == null)
						{
							return;
						}
						IEnumerable<ActionElementMap> enumerable = map.ElementMapsWithAction("UISubmit");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						object obj3 = default(object);
						object obj2 = (object)(&obj3);
						maps = null;
						object obj4 = default(object);
						ActionElementMap actionElementMap = default(ActionElementMap);
						while (true)
						{
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								if (obj4 != null)
								{
									bool flag2 = obj3 == null;
									num2 = unchecked((nint)null);
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										bool flag3 = actionElementMap == null;
										num2 = unchecked((nint)null);
										if (flag3)
										{
											break;
										}
										KeyCode keyCode = actionElementMap.keyCode;
										if (keyCode == KeyCode.Space)
										{
											actionElementMap.sJiZjarByPFOekuKHAIndKOqaLbdb = isSpaceNavigationActive;
										}
										continue;
									}
									throw new NullReferenceException();
								}
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								return;
							}
							throw new NullReferenceException();
						}
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static void RefreshHorizontalNavigationForChests(bool isChestWindowOpen)
	{
		//IL_009a: Expected I, but got O
		//IL_010d: Expected I, but got O
		//IL_0145: Expected O, but got I
		//IL_023d: Expected O, but got Ref
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField == null)
		{
			return;
		}
		ConfigSaveFile config = saveManager.config;
		if (saveManager.config == null || config.cfControlSettings == null)
		{
			return;
		}
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v12 (Il2CppClass<SaveManager>)+B8]");
		nint num2 = 0;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config2 = saveManager2.config;
			if (saveManager2.config != null)
			{
				num2 = (nint)config2.cfControlSettings;
				if (config2.cfControlSettings != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v19 (Il2CppStaticFields<SaveManager>)+C8]");
					object obj = -1;
					bool flag = obj == null;
					bool flag2 = !isChestWindowOpen;
					bool sJiZjarByPFOekuKHAIndKOqaLbdb = true;
					if (!flag2)
					{
						sJiZjarByPFOekuKHAIndKOqaLbdb = flag;
					}
					Player player = MyInputManager.player;
					Keyboard keyboard = player.controllers.Keyboard;
					Player player2 = MyInputManager.player;
					Player.ControllerHelper controllers = player2.controllers;
					if (controllers.maps != null)
					{
						ControllerMap map = controllers.maps.GetMap(keyboard, "UI", "Default");
						if (map == null)
						{
							return;
						}
						IEnumerable<ActionElementMap> enumerable = map.ElementMapsWithAction("UIHorizontal");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						IEnumerator<ActionElementMap> enumerator = default(IEnumerator<ActionElementMap>);
						object obj2 = (object)(&enumerator);
						string text = "Default";
						Player.ControllerHelper.MapHelper mapHelper = null;
						object obj3 = default(object);
						while (true)
						{
							if (enumerator != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								if (obj3 != null)
								{
									if (enumerator != null)
									{
										ActionElementMap current = enumerator.Current;
										if (current == null)
										{
											break;
										}
										KeyCode keyCode = current.keyCode;
										if (keyCode != KeyCode.D)
										{
											KeyCode keyCode2 = current.keyCode;
											bool flag3 = keyCode2 != KeyCode.A;
											text = (string)(object)typeof(IEnumerator<ActionElementMap>);
											if (flag3)
											{
												continue;
											}
										}
										current.sJiZjarByPFOekuKHAIndKOqaLbdb = sJiZjarByPFOekuKHAIndKOqaLbdb;
										text = (string)(object)typeof(IEnumerator<ActionElementMap>);
										continue;
									}
									throw new NullReferenceException();
								}
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								return;
							}
							throw new NullReferenceException();
						}
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	public static bool IsActionBound(string action)
	{
		//IL_00b8: Expected I4, but got O
		Player player = MyInputManager.player;
		if (MyInputManager.player != null)
		{
			Keyboard keyboard = player.controllers.Keyboard;
			Player player2 = MyInputManager.player;
			Player.ControllerHelper controllers = player2.controllers;
			ControllerMap map = controllers.maps.GetMap(keyboard, "Default", "Default");
			if (map != null)
			{
				IEnumerable<ActionElementMap> source = map.ElementMapsWithAction(action);
				return Enumerable.Any(source);
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnSettingUpdated(string settingName, object o1, object o2)
	{
		if (settingName == "space_navigation")
		{
			RefreshSpaceNavigation();
		}
	}

	private void OnWindowOpened(Window window)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0050: Invalid comparison between O and F4
		//IL_007c: Expected O, but got I
		//IL_008c: Expected O, but got I
		if (!GameManager.Instance)
		{
			return;
		}
		float axis = GetAxis(UIVertical);
		if (isVerticalEnabled)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = axis & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)vertUiInputDeadzoneEnter))
			{
				isVerticalEnabled = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v9+B8]");
				object verticalAxis = 0;
				rewiredEventSystem.verticalAxis = (string)verticalAxis;
				float time = Time.time;
				stoppedInputAtTime = time;
			}
		}
	}

	private void WindowUpdate()
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00b8: Invalid comparison between F4 and O
		if (GameManager.Instance != null)
		{
			if (isVerticalEnabled)
			{
				return;
			}
			float time = Time.time;
			float num = resumeInputDelay + stoppedInputAtTime;
			if (time < num && WindowManager.HasOpenWindow())
			{
				float axis = GetAxis(UIVertical);
				if (isVerticalEnabled)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj = axis & 0;
				float num2 = vertUiInputDeadzoneExit;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					return;
				}
			}
		}
		else if (isVerticalEnabled)
		{
			return;
		}
		isVerticalEnabled = true;
		rewiredEventSystem.verticalAxis = UIVertical;
	}

	private void ChangeVerticalUI(bool active)
	{
		//IL_0028: Expected O, but got I
		//IL_0038: Expected O, but got I
		//IL_0013: Expected I, but got O
		//IL_00ab: Expected O, but got I
		isVerticalEnabled = active;
		object verticalAxis;
		if (active)
		{
			nint num = (nint)typeof(MyInputManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v8 (Il2CppClass<MyInputManager>)+B8]");
			verticalAxis = (nint)0 + (nint)136;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+B8]");
			verticalAxis = 0;
		}
		rewiredEventSystem.verticalAxis = (string)verticalAxis;
		if (!active)
		{
			float time = Time.time;
			stoppedInputAtTime = time;
		}
	}
}
