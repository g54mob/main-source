using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

public class UIDrawerListener : MonoBehaviour
{
	public bool DebugMode;

	public string DrawerName;

	public bool CustomDrawerName;

	public UIDrawerEvent Event;

	public bool ListenForAllUIDrawers;

	public UIDrawerBehaviorType TriggerAction;

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DrawerName = "Unnamed";
		ListenForAllUIDrawers = false;
		TriggerAction = UIDrawerBehaviorType.Open;
		UIDrawerEvent uIDrawerEvent = (UIDrawerEvent)new UnityEventBase();
		_ = 0;
		Event = uIDrawerEvent;
	}

	private void OnEnable()
	{
		Action<UIDrawerMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Started listening for UIDrawer actions";
			DDebug.Log(message, this);
		}
	}

	private void OnDisable()
	{
		Action<UIDrawerMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIDrawer actions";
			DDebug.Log(message, this);
		}
	}

	private void RegisterListener()
	{
		Action<UIDrawerMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Started listening for UIDrawer actions";
			DDebug.Log(message, this);
		}
	}

	private void UnregisterListener()
	{
		Action<UIDrawerMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (DebugMode)
		{
			string text = GetName();
			string message = "[" + text + "] Stopped listening for UIDrawer actions";
			DDebug.Log(message, this);
		}
	}

	private unsafe void OnMessage(UIDrawerMessage message)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Ref, but got Unknown
		//IL_00e2: Expected I8, but got I4
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Ref, but got Unknown
		//IL_01cf: Expected O, but got Ref
		if (!ListenForAllUIDrawers)
		{
			UIDrawer drawer = message.Drawer;
			string drawerName = drawer.DrawerName;
			string drawerName2 = DrawerName;
			if ((object)drawer.DrawerName != DrawerName)
			{
				if (DrawerName == null || drawerName._stringLength != drawerName2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(DrawerName + 20);
				ulong length = (ulong)(drawerName._stringLength + drawerName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(drawer.DrawerName + 20), ref second, length))
				{
					return;
				}
			}
		}
		if (Event != null && TriggerAction == message.Type)
		{
			((UnityEvent<object>)(object)Event).Invoke((object)message.Drawer);
			if (DebugMode)
			{
				string[] array = new string[6];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text = GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text2 = ((Enum)(&obj)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				UIDrawer drawer2 = message.Drawer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message2 = string.Concat(array);
				DDebug.Log(message2, this);
			}
		}
	}

	private unsafe void InvokeEvent(UIDrawerMessage message)
	{
		//IL_00ac: Expected O, but got Ref
		if (Event != null && TriggerAction == message.Type)
		{
			((UnityEvent<object>)(object)Event).Invoke((object)message.Drawer);
			if (DebugMode)
			{
				string[] array = new string[6];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text = GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text2 = ((Enum)(&obj)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				UIDrawer drawer = message.Drawer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message2 = string.Concat(array);
				DDebug.Log(message2, this);
			}
		}
	}

	private static UIDrawerListener AddToScene(bool selectGameObjectAfterCreation = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182BAD190\"");
		UIDrawerListener result = default(UIDrawerListener);
		return result;
	}

	private static UIDrawerListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
	{
		UIDrawerListener uIDrawerListener = DoozyUtils.AddToScene<UIDrawerListener>("UIDrawer Listener", isSingleton: false, selectGameObjectAfterCreation);
		if ((object)uIDrawerListener != null)
		{
			Transform transform = uIDrawerListener.transform;
			if ((object)transform != null)
			{
				Transform root = transform.root;
				if ((object)root != null)
				{
					RectTransform component = root.GetComponent<RectTransform>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return uIDrawerListener;
					}
					GameObject gameObject = uIDrawerListener.gameObject;
					if ((object)gameObject != null)
					{
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						RectTransform component2 = uIDrawerListener.GetComponent<RectTransform>();
						bool flag = (object)component2 == null;
						bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
						return uIDrawerListener;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public UIDrawerListener()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
