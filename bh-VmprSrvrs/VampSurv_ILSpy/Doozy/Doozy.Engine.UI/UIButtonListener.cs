using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

public class UIButtonListener : MonoBehaviour
{
	public string ButtonCategory;

	public string ButtonName;

	public bool DebugMode;

	public UIButtonEvent Event;

	public bool ListenForAllUIButtons;

	public UIButtonBehaviorType TriggerAction;

	private bool m_listeningForBackButton;

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonName = "Unnamed";
		ListenForAllUIButtons = false;
		TriggerAction = UIButtonBehaviorType.OnClick;
		UIButtonEvent uIButtonEvent = (UIButtonEvent)new UnityEventBase();
		_ = 0;
		Event = uIButtonEvent;
	}

	private void OnEnable()
	{
		RegisterListener();
	}

	private void OnDisable()
	{
		Action<UIButtonMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIButton actions";
			DDebug.Log(message, this);
		}
	}

	private unsafe void RegisterListener()
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Ref, but got Unknown
		//IL_00e0: Expected I8, but got I4
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Ref, but got Unknown
		Action<UIButtonMessage> callback = OnMessage;
		Message.AddListener(callback);
		string buttonName = ButtonName;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = "Back";
		bool listeningForBackButton;
		if ((object)ButtonName != "Back")
		{
			if ("Back" != null)
			{
				int stringLength = buttonName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v3+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(ButtonName + 20);
					ulong length = (ulong)(buttonName._stringLength + buttonName._stringLength);
					listeningForBackButton = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Back" + 20), length);
					goto IL_017f;
				}
			}
			listeningForBackButton = false;
		}
		else
		{
			listeningForBackButton = true;
		}
		goto IL_017f;
		IL_017f:
		bool flag = !DebugMode;
		m_listeningForBackButton = listeningForBackButton;
		if (!flag)
		{
			string text = GetName();
			string message = "[" + text + "] Started listening for UIButton actions";
			DDebug.Log(message, this);
		}
	}

	private void UnregisterListener()
	{
		Action<UIButtonMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIButton actions";
			DDebug.Log(message, this);
		}
	}

	private unsafe void OnMessage(UIButtonMessage message)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Ref, but got Unknown
		//IL_00e0: Expected I8, but got I4
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Ref, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected Ref, but got Unknown
		//IL_02a0: Expected I8, but got I4
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected Ref, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected Ref, but got Unknown
		//IL_03a1: Expected I8, but got I4
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected Ref, but got Unknown
		if (m_listeningForBackButton)
		{
			string buttonName = message.ButtonName;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj = "Back";
			if ((object)message.ButtonName == "Back")
			{
				goto IL_03e2;
			}
			if ("Back" != null)
			{
				int stringLength = buttonName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v11+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(message.ButtonName + 20);
					ulong length = (ulong)(buttonName._stringLength + buttonName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Back" + 20), length))
					{
						goto IL_03e2;
					}
				}
			}
			UIButton button = message.Button;
			if ((object)message.Button != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdi_v8 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0 && message.Button.IsBackButton)
				{
					goto IL_03e2;
				}
			}
		}
		if (!ListenForAllUIButtons)
		{
			UIButton button2 = message.Button;
			if ((object)message.Button == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v6 (Doozy.Engine.UI.UIButton)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			UIButton button3 = message.Button;
			string buttonCategory = button3.ButtonCategory;
			string buttonCategory2 = ButtonCategory;
			if ((object)button3.ButtonCategory != ButtonCategory)
			{
				if (ButtonCategory == null || buttonCategory._stringLength != buttonCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ButtonCategory + 20);
				ulong length2 = (ulong)(buttonCategory._stringLength + buttonCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button3.ButtonCategory + 20), ref second, length2))
				{
					return;
				}
			}
			UIButton button4 = message.Button;
			string buttonName2 = button4.ButtonName;
			string buttonName3 = ButtonName;
			if ((object)button4.ButtonName != ButtonName)
			{
				if (ButtonName == null || buttonName2._stringLength != buttonName3._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ButtonName + 20);
				ulong length3 = (ulong)(buttonName2._stringLength + buttonName2._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button4.ButtonName + 20), ref second2, length3))
				{
					return;
				}
			}
		}
		goto IL_03e2;
		IL_03e2:
		InvokeEvent(message);
	}

	private unsafe void InvokeEvent(UIButtonMessage message)
	{
		//IL_00ac: Expected O, but got Ref
		if (Event == null || TriggerAction != message.Type)
		{
			return;
		}
		((UnityEvent<object>)(object)Event).Invoke((object)message.Button);
		if (!DebugMode)
		{
			return;
		}
		string[] array = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string text = GetName();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj = default(object);
		string text2 = ((Enum)(&obj)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		UIButton button = message.Button;
		string text3;
		if ((object)message.Button != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbp_v5 (Doozy.Engine.UI.UIButton)+10]");
			if ((nint)0 != 0)
			{
				UIButton button2 = message.Button;
				text3 = button2.ButtonCategory + " - " + button2.ButtonName;
				goto IL_019e;
			}
		}
		text3 = message.ButtonName;
		goto IL_019e;
		IL_019e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string message2 = string.Concat(array);
		DDebug.Log(message2, this);
	}

	private static UIButtonListener AddToScene(bool selectGameObjectAfterCreation = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182B9F3F0\"");
		UIButtonListener result = default(UIButtonListener);
		return result;
	}

	private static UIButtonListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
	{
		UIButtonListener uIButtonListener = DoozyUtils.AddToScene<UIButtonListener>("UIButton Listener", isSingleton: false, selectGameObjectAfterCreation);
		if ((object)uIButtonListener != null)
		{
			Transform transform = uIButtonListener.transform;
			if ((object)transform != null)
			{
				Transform root = transform.root;
				if ((object)root != null)
				{
					RectTransform component = root.GetComponent<RectTransform>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return uIButtonListener;
					}
					GameObject gameObject = uIButtonListener.gameObject;
					if ((object)gameObject != null)
					{
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						RectTransform component2 = uIButtonListener.GetComponent<RectTransform>();
						bool flag = (object)component2 == null;
						bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
						return uIButtonListener;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public UIButtonListener()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
