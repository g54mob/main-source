using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Internal;

namespace Doozy.Engine.UI.Input;

public class BackButton : MonoBehaviour
{
	private static BackButton s_instance;

	public const bool DEFAULT_ENABLE_ALTERNATE_INPUTS = false;

	public const float BACK_BUTTON_DETECTION_DISABLE_INTERVAL = 0.2f;

	public const InputMode DEFAULT_INPUT_MODE = InputMode.VirtualButton;

	public const KeyCode DEFAULT_BACK_BUTTON_KEY_CODE = KeyCode.Escape;

	public const KeyCode DEFAULT_BACK_BUTTON_KEY_CODE_ALT = KeyCode.Backspace;

	public const string DEFAULT_BACK_BUTTON_VIRTUAL_BUTTON_NAME = "Cancel";

	public const string DEFAULT_BACK_BUTTON_VIRTUAL_BUTTON_NAME_ALT = "Cancel";

	public const string NAME = "Back";

	private static bool s_applicationIsQuitting;

	private static bool s_initialized;

	public InputData BackButtonInputData;

	public bool DebugMode;

	private int m_backButtonDisableLevel;

	private double m_lastBackButtonPressTime;

	public static BackButton Instance
	{
		get
		{
			BackButton backButton = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)backButton).m_CachedPtr == (IntPtr)0)
			{
				if (s_applicationIsQuitting)
				{
					return null;
				}
				BackButton backButton2 = UnityEngine.Object.FindObjectOfType<BackButton>();
				s_instance = backButton2;
				BackButton backButton3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)backButton3).m_CachedPtr == (IntPtr)0)
				{
					BackButton backButton4 = DoozyUtils.AddToScene<BackButton>("Back Button", isSingleton: true);
					if ((object)backButton4 == null)
					{
						return (BackButton)(object)new NullReferenceException();
					}
					GameObject target = backButton4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	public bool BackButtonDisabled
	{
		get
		{
			bool flag = m_backButtonDisableLevel < 0;
			bool flag2 = m_backButtonDisableLevel == 0;
			if (m_backButtonDisableLevel < 0)
			{
				m_backButtonDisableLevel = 0;
				flag = m_backButtonDisableLevel < 0;
				flag2 = m_backButtonDisableLevel == 0;
			}
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	public bool CanExecuteBackButton
	{
		get
		{
			//IL_001b: Expected O, but got F4
			bool flag = (nint)0 < (nint)0;
			object obj = Time.realtimeSinceStartup;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+30h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,qword ptr [188A10638h]\"");
			return !flag;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugBackButton;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected BackButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private static void RunOnStart()
	{
		s_applicationIsQuitting = false;
		s_initialized = false;
	}

	private void Reset()
	{
		InputData backButtonInputData = GetBackButtonInputData();
		BackButtonInputData = backButtonInputData;
	}

	private void Awake()
	{
		//IL_0259: Expected O, but got F4
		//IL_0215: Expected O, but got I4
		//IL_022f: Expected O, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		BackButton backButton = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)backButton).m_CachedPtr != (IntPtr)0)
		{
			BackButton backButton2 = s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)backButton2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					object obj4 = this + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					object obj5 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v669 @ rdx_v11+1B8] (should have been resolved before IL gen)");
					string text = default(string);
					string message = "There cannot be two '" + text + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj7 = base.gameObject;
					UnityEngine.Object.Destroy(obj7, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
		if (BackButtonInputData == null)
		{
			InputData backButtonInputData = GetBackButtonInputData();
			BackButtonInputData = backButtonInputData;
		}
		object obj8 = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_lastBackButtonPressTime = 0.0;
		s_initialized = true;
	}

	private unsafe void Update()
	{
		//IL_0351: Expected O, but got I
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_03e7: Expected O, but got F4
		//IL_041e: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		//IL_0206: Expected O, but got Ref
		object obj = (nint)0 ^ (nint)0;
		object obj2 = 0 & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (nint)0 < (nint)0;
		object obj3 = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rdi+30h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,qword ptr [188A10638h]\"");
		bool flag3 = flag2 == flag;
		object obj4 = !flag3;
		if (obj4 != null)
		{
			return;
		}
		int num = m_backButtonDisableLevel ^ m_backButtonDisableLevel;
		int num2 = m_backButtonDisableLevel & num;
		bool flag4 = num2 < 0;
		bool flag5 = m_backButtonDisableLevel < 0;
		bool flag6 = m_backButtonDisableLevel == 0;
		if (m_backButtonDisableLevel < 0)
		{
			m_backButtonDisableLevel = 0;
			int num3 = m_backButtonDisableLevel ^ m_backButtonDisableLevel;
			int num4 = m_backButtonDisableLevel & num3;
			flag4 = num4 < 0;
			flag5 = m_backButtonDisableLevel < 0;
			flag6 = m_backButtonDisableLevel == 0;
		}
		bool flag7 = flag5 == flag4;
		object obj5 = !flag6;
		object obj6 = flag7 & obj5;
		if (obj6 != null)
		{
			return;
		}
		InputData backButtonInputData = BackButtonInputData;
		if (backButtonInputData.InputMode == InputMode.None)
		{
			return;
		}
		string text2;
		string text3;
		if (backButtonInputData.InputMode == InputMode.KeyCode)
		{
			if (!UnityEngine.Input.GetKeyDownInt(backButtonInputData.KeyCode))
			{
				InputData backButtonInputData2 = BackButtonInputData;
				if (!backButtonInputData2.EnableAlternateInputs || !UnityEngine.Input.GetKeyDownInt(backButtonInputData2.KeyCodeAlt))
				{
					return;
				}
			}
			if (!DebugMode)
			{
				DoozySettings instance = DoozySettings.Instance;
				if (!instance.DebugBackButton)
				{
					goto IL_033d;
				}
			}
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			text2 = text;
			text3 = "Back button detected via KeyCode: ";
		}
		else
		{
			if (backButtonInputData.InputMode != InputMode.VirtualButton)
			{
				return;
			}
			if (!UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(backButtonInputData.VirtualButtonName))
			{
				InputData backButtonInputData3 = BackButtonInputData;
				if (!backButtonInputData3.EnableAlternateInputs || !UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(backButtonInputData3.VirtualButtonNameAlt))
				{
					return;
				}
			}
			if (!DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if (!instance2.DebugBackButton)
				{
					goto IL_033d;
				}
			}
			InputData backButtonInputData4 = BackButtonInputData;
			text2 = backButtonInputData4.VirtualButtonName;
			text3 = "Back button detected via Virtual Button: ";
		}
		string message = text3 + text2;
		BackButton instance3 = Instance;
		DDebug.Log(message, instance3);
		goto IL_033d;
		IL_033d:
		Execute();
	}

	private void OnApplicationQuit()
	{
		s_applicationIsQuitting = true;
	}

	public void Execute()
	{
		//IL_0390: Expected O, but got I4
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03c7: Expected I4, but got O
		//IL_0193: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_01e5: Expected O, but got I
		//IL_01fa: Expected O, but got I
		DoozySettings instance = DoozySettings.Instance;
		if (!instance.UseBackButton || !CanExecuteBackButton)
		{
			return;
		}
		int num = m_backButtonDisableLevel ^ m_backButtonDisableLevel;
		int num2 = m_backButtonDisableLevel & num;
		bool flag = num2 < 0;
		bool flag2 = m_backButtonDisableLevel < 0;
		bool flag3 = m_backButtonDisableLevel == 0;
		if (m_backButtonDisableLevel < 0)
		{
			m_backButtonDisableLevel = 0;
			int num3 = m_backButtonDisableLevel ^ m_backButtonDisableLevel;
			int num4 = m_backButtonDisableLevel & num3;
			flag = num4 < 0;
			flag2 = m_backButtonDisableLevel < 0;
			flag3 = m_backButtonDisableLevel == 0;
		}
		bool flag4 = flag2 == flag;
		object obj = !flag3;
		object obj2 = flag4 & obj;
		if (obj2 != null)
		{
			return;
		}
		bool anyPopupVisible = UIPopup.AnyPopupVisible;
		bool flag5 = !anyPopupVisible;
		bool flag6 = false;
		if (!flag5)
		{
			List<UIPopup> visiblePopups = UIPopup.VisiblePopups;
			if (visiblePopups._size <= 0)
			{
				throw new NullReferenceException();
			}
			flag6 = (byte)(int)UIPopup.VisiblePopups != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v6 (System.Boolean)+18]");
			object obj3 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v6 (System.Boolean)+18]");
			if ((nint)obj3 >= 0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v6 (System.Boolean)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v6 (System.Boolean)+18]");
			object obj5 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v50+20+v312 @ rbx_v10*8]");
			UIPopup uIPopup = (UIPopup)0;
			if (uIPopup.HideOnBackButton)
			{
				uIPopup.Hide();
				flag6 = false;
			}
			if (uIPopup.BlockBackButton)
			{
				return;
			}
		}
		if (UIDrawer.AnyDrawerOpened)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
			UIDrawer uIDrawer = default(UIDrawer);
			if (uIDrawer.HideOnBackButton)
			{
				uIDrawer.Close();
			}
			if (uIDrawer.BlockBackButton)
			{
				return;
			}
		}
		UIButtonMessage uIButtonMessage = null;
		uIButtonMessage.ButtonName = "Back";
		uIButtonMessage.Button = null;
		uIButtonMessage.Type = UIButtonBehaviorType.OnClick;
		Message.Send(uIButtonMessage);
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_lastBackButtonPressTime = 0.0;
	}

	public static BackButton AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<BackButton>("Back Button", isSingleton: true, selectGameObjectAfterCreation);
	}

	public static void Disable()
	{
		BackButton instance = Instance;
		int backButtonDisableLevel = instance.m_backButtonDisableLevel + 1;
		instance.m_backButtonDisableLevel = backButtonDisableLevel;
	}

	public static void Enable()
	{
		BackButton instance = Instance;
		int backButtonDisableLevel = instance.m_backButtonDisableLevel - 1;
		instance.m_backButtonDisableLevel = backButtonDisableLevel;
		BackButton instance2 = Instance;
		if (instance2.m_backButtonDisableLevel < 0)
		{
			BackButton instance3 = Instance;
			instance3.m_backButtonDisableLevel = 0;
		}
	}

	public static void EnableByForce()
	{
		BackButton instance = Instance;
		instance.m_backButtonDisableLevel = 0;
	}

	public static void Init()
	{
		if (!s_initialized)
		{
			BackButton backButton = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)backButton).m_CachedPtr == (IntPtr)0)
			{
				BackButton instance = Instance;
				s_instance = instance;
			}
		}
	}

	private static InputData GetBackButtonInputData()
	{
		InputData inputData = new InputData();
		if (inputData != null)
		{
			inputData.InputMode = InputMode.VirtualButton;
			inputData.KeyCode = KeyCode.Escape;
			inputData.KeyCodeAlt = KeyCode.Backspace;
			inputData.EnableAlternateInputs = false;
			inputData.VirtualButtonName = "Cancel";
			inputData.VirtualButtonNameAlt = "Cancel";
			return inputData;
		}
		return (InputData)(object)new NullReferenceException();
	}
}
