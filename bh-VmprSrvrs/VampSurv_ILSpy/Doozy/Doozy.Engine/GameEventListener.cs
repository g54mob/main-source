using System;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine;

public class GameEventListener : MonoBehaviour
{
	public bool DebugMode;

	public StringEvent Event;

	public string GameEvent;

	public bool ListenForAllGameEvents;

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
				return instance.DebugGameEventListener;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Reset()
	{
		//IL_002f: Expected O, but got I
		//IL_003f: Expected O, but got I
		ListenForAllGameEvents = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2+B8]");
		object gameEvent = 0;
		GameEvent = (string)gameEvent;
		StringEvent stringEvent = new StringEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		Event = stringEvent;
	}

	private void Awake()
	{
		string gameEvent = GameEvent.TrimWhiteSpaceHelper(string.TrimType.Both);
		GameEvent = gameEvent;
	}

	private void OnEnable()
	{
		Action<GameEventMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message = "[" + text + "] Started listening for GameEvents";
		DDebug.Log(message, this);
	}

	private void OnDisable()
	{
		Action<GameEventMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message = "[" + text + "] Stopped listening for GameEvents";
		DDebug.Log(message, this);
	}

	private void RegisterListener()
	{
		Action<GameEventMessage> callback = OnMessage;
		Message.AddListener(callback);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message = "[" + text + "] Started listening for GameEvents";
		DDebug.Log(message, this);
	}

	private void UnregisterListener()
	{
		Action<GameEventMessage> callback = OnMessage;
		Message.RemoveListener(callback);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message = "[" + text + "] Stopped listening for GameEvents";
		DDebug.Log(message, this);
	}

	private unsafe void OnMessage(GameEventMessage message)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Ref, but got Unknown
		//IL_00d6: Expected I8, but got I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Ref, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected Ref, but got Unknown
		//IL_01e7: Expected I8, but got I4
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Ref, but got Unknown
		if (!ListenForAllGameEvents)
		{
			string gameEvent = GameEvent;
			string eventName = message.EventName;
			if ((object)GameEvent != message.EventName)
			{
				if (message.EventName == null || gameEvent._stringLength != eventName._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(message.EventName + 20);
				ulong length = (ulong)(gameEvent._stringLength + gameEvent._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(GameEvent + 20), ref second, length))
				{
					return;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899805DA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string eventName2 = message.EventName;
		object obj = "None";
		if ((object)message.EventName == "None")
		{
			return;
		}
		if ("None" != null)
		{
			int stringLength = eventName2._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second2 = ref *(byte*)("None" + 20);
				ulong length2 = (ulong)(eventName2._stringLength + eventName2._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(message.EventName + 20), ref second2, length2))
				{
					return;
				}
			}
		}
		if (Event == null)
		{
			return;
		}
		((UnityEvent<object>)(object)Event).Invoke((object)message.EventName);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message2 = "[" + text + "] Triggered Event: " + message.EventName;
		DDebug.Log(message2, this);
	}

	private unsafe void InvokeEvent(GameEventMessage message)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Ref, but got Unknown
		//IL_00d3: Expected I8, but got I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899805DA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string eventName = message.EventName;
		object obj = "None";
		if ((object)message.EventName == "None")
		{
			return;
		}
		if ("None" != null)
		{
			int stringLength = eventName._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v2+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("None" + 20);
				ulong length = (ulong)(eventName._stringLength + eventName._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(message.EventName + 20), ref second, length))
				{
					return;
				}
			}
		}
		if (Event == null)
		{
			return;
		}
		((UnityEvent<object>)(object)Event).Invoke((object)message.EventName);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGameEventListener)
			{
				return;
			}
		}
		string text = GetName();
		string message2 = "[" + text + "] Triggered Event: " + message.EventName;
		DDebug.Log(message2, this);
	}

	private static GameEventListener AddToScene(bool selectGameObjectAfterCreation = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182B828E0\"");
		GameEventListener result = default(GameEventListener);
		return result;
	}

	private static GameEventListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
	{
		GameEventListener gameEventListener = DoozyUtils.AddToScene<GameEventListener>("Game Event Listener", isSingleton: false, selectGameObjectAfterCreation);
		if ((object)gameEventListener != null)
		{
			Transform transform = gameEventListener.transform;
			if ((object)transform != null)
			{
				Transform root = transform.root;
				if ((object)root != null)
				{
					RectTransform component = root.GetComponent<RectTransform>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return gameEventListener;
					}
					GameObject gameObject = gameEventListener.gameObject;
					if ((object)gameObject != null)
					{
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						RectTransform component2 = gameEventListener.GetComponent<RectTransform>();
						bool flag = (object)component2 == null;
						bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
						return gameEventListener;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public GameEventListener()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
