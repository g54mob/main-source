using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

public class UIViewListener : MonoBehaviour
{
	public bool DebugMode;

	public UIViewEvent Event;

	public bool ListenForAllUIViews;

	public UIViewBehaviorType TriggerAction;

	public string ViewCategory;

	public string ViewName;

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998077A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewName = "Unnamed";
		ListenForAllUIViews = false;
		TriggerAction = UIViewBehaviorType.Show;
		UIViewEvent uIViewEvent = (UIViewEvent)new UnityEventBase();
		_ = 0;
		Event = uIViewEvent;
	}

	private void OnEnable()
	{
		Action<UIViewMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Started listening for UIView actions";
			DDebug.Log(message, this);
		}
	}

	private void OnDisable()
	{
		Action<UIViewMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIView actions";
			DDebug.Log(message, this);
		}
	}

	private void RegisterListener()
	{
		Action<UIViewMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Started listening for UIView actions";
			DDebug.Log(message, this);
		}
	}

	private void UnregisterListener()
	{
		Action<UIViewMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIView actions";
			DDebug.Log(message, this);
		}
	}

	private unsafe void OnMessage(UIViewMessage message)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Ref, but got Unknown
		//IL_00e2: Expected I8, but got I4
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Ref, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected Ref, but got Unknown
		//IL_01e3: Expected I8, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Ref, but got Unknown
		if (!ListenForAllUIViews)
		{
			UIView view = message.View;
			string viewCategory = view.ViewCategory;
			string viewCategory2 = ViewCategory;
			if ((object)view.ViewCategory != ViewCategory)
			{
				if (ViewCategory == null || viewCategory._stringLength != viewCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ViewCategory + 20);
				ulong length = (ulong)(viewCategory._stringLength + viewCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view.ViewCategory + 20), ref second, length))
				{
					return;
				}
			}
			UIView view2 = message.View;
			string viewName = view2.ViewName;
			string viewName2 = ViewName;
			if ((object)view2.ViewName != ViewName)
			{
				if (ViewName == null || viewName._stringLength != viewName2._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ViewName + 20);
				ulong length2 = (ulong)(viewName._stringLength + viewName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view2.ViewName + 20), ref second2, length2))
				{
					return;
				}
			}
		}
		InvokeEvent(message);
	}

	private unsafe void InvokeEvent(UIViewMessage message)
	{
		//IL_00ac: Expected O, but got Ref
		if (Event != null && TriggerAction == message.Type)
		{
			((UnityEvent<object>)(object)Event).Invoke((object)message.View);
			if (DebugMode)
			{
				string[] array = new string[8];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text = GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text2 = ((Enum)(&obj)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				UIView view = message.View;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				UIView view2 = message.View;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message2 = string.Concat(array);
				DDebug.Log(message2, this);
			}
		}
	}

	private static UIViewListener AddToScene(bool selectGameObjectAfterCreation = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182BCC210\"");
		UIViewListener result = default(UIViewListener);
		return result;
	}

	private static UIViewListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
	{
		UIViewListener uIViewListener = DoozyUtils.AddToScene<UIViewListener>("UIView Listener", isSingleton: false, selectGameObjectAfterCreation);
		if ((object)uIViewListener != null)
		{
			Transform transform = uIViewListener.transform;
			if ((object)transform != null)
			{
				Transform root = transform.root;
				if ((object)root != null)
				{
					RectTransform component = root.GetComponent<RectTransform>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return uIViewListener;
					}
					GameObject gameObject = uIViewListener.gameObject;
					if ((object)gameObject != null)
					{
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						RectTransform component2 = uIViewListener.GetComponent<RectTransform>();
						bool flag = (object)component2 == null;
						bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
						return uIViewListener;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public UIViewListener()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
