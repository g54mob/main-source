using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine;

public class GameEventMessage : Message
{
	private const string NO_GAME_EVENT = "None";

	private bool _003CIsSystemEvent_003Ek__BackingField;

	public readonly string EventName;

	public GameObject Source;

	public UnityEngine.Object CustomObject;

	public bool HasCustomObject
	{
		get
		{
			UnityEngine.Object customObject = CustomObject;
			if ((object)CustomObject != null)
			{
				bool flag = customObject.m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public unsafe bool HasGameEvent
	{
		get
		{
			//IL_011d: Expected I4, but got O
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected Ref, but got Unknown
			//IL_00cb: Expected I8, but got I4
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899805DA]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string eventName = EventName;
			if (EventName != null)
			{
				object obj = "None";
				if ((object)EventName != "None")
				{
					if ("None" != null)
					{
						int stringLength = eventName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("None" + 20);
							ulong length = (ulong)(eventName._stringLength + eventName._stringLength);
							bool flag = System.SpanHelpers.SequenceEqual(ref *(byte*)(EventName + 20), ref second, length);
							return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
						}
					}
					return true;
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasSource
	{
		get
		{
			GameObject source = Source;
			if ((object)Source != null)
			{
				bool flag = ((UnityEngine.Object)source).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public bool IsSystemEvent
	{
		get
		{
			return _003CIsSystemEvent_003Ek__BackingField;
		}
		private set
		{
			_003CIsSystemEvent_003Ek__BackingField = value;
		}
	}

	public unsafe GameEventMessage(SystemGameEvent systemGameEvent)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string eventName = ((Enum)(&obj)).ToString();
		EventName = eventName;
		Source = null;
		CustomObject = null;
		_003CIsSystemEvent_003Ek__BackingField = true;
	}

	public GameEventMessage(string gameEvent)
	{
		EventName = gameEvent;
		Source = null;
		CustomObject = null;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public GameEventMessage(GameObject source)
	{
		EventName = "None";
		Source = source;
		CustomObject = null;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public unsafe GameEventMessage(SystemGameEvent systemGameEvent, GameObject source, UnityEngine.Object customObject = null)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string eventName = ((Enum)(&obj)).ToString();
		EventName = eventName;
		Source = source;
		CustomObject = customObject;
		_003CIsSystemEvent_003Ek__BackingField = true;
	}

	public GameEventMessage(string gameEvent, GameObject source)
	{
		EventName = gameEvent;
		Source = source;
		CustomObject = null;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public GameEventMessage(GameObject source, UnityEngine.Object customObject)
	{
		EventName = "None";
		Source = source;
		CustomObject = customObject;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public GameEventMessage(string gameEvent, UnityEngine.Object customObject)
	{
		EventName = gameEvent;
		Source = null;
		CustomObject = customObject;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public GameEventMessage(string gameEvent, GameObject source, UnityEngine.Object customObject)
	{
		EventName = gameEvent;
		Source = source;
		CustomObject = customObject;
		_003CIsSystemEvent_003Ek__BackingField = false;
	}

	public unsafe static void SendEvent(SystemGameEvent systemGameEvent)
	{
		//IL_000e: Expected O, but got Ref
		GameEventMessage gameEventMessage = null;
		object obj = default(object);
		string eventName = ((Enum)(&obj)).ToString();
		gameEventMessage.EventName = eventName;
		gameEventMessage.Source = null;
		gameEventMessage.CustomObject = null;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = true;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(string gameEvent)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = gameEvent;
		gameEventMessage.Source = null;
		gameEventMessage.CustomObject = null;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(GameObject source)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = "None";
		gameEventMessage.Source = source;
		gameEventMessage.CustomObject = null;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public unsafe static void SendEvent(SystemGameEvent systemGameEvent, GameObject source)
	{
		//IL_000e: Expected O, but got Ref
		GameEventMessage gameEventMessage = null;
		object obj = default(object);
		string eventName = ((Enum)(&obj)).ToString();
		gameEventMessage.EventName = eventName;
		gameEventMessage.Source = source;
		gameEventMessage.CustomObject = null;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = true;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(string gameEvent, GameObject source)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = gameEvent;
		gameEventMessage.Source = source;
		gameEventMessage.CustomObject = null;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(string gameEvent, UnityEngine.Object customObject)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = gameEvent;
		gameEventMessage.Source = null;
		gameEventMessage.CustomObject = customObject;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(GameObject source, UnityEngine.Object customObject)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = "None";
		gameEventMessage.Source = source;
		gameEventMessage.CustomObject = customObject;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public static void SendEvent(string gameEvent, GameObject source, UnityEngine.Object customObject)
	{
		GameEventMessage gameEventMessage = null;
		gameEventMessage.EventName = gameEvent;
		gameEventMessage.Source = source;
		gameEventMessage.CustomObject = customObject;
		gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
		SendEvent(gameEventMessage);
	}

	public static void SendEvents(List<string> gameEvents, GameObject source = null, UnityEngine.Object customObject = null)
	{
		if (gameEvents != null && gameEvents._size != 0)
		{
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			UnityEngine.Object customObject2 = default(UnityEngine.Object);
			while (enumerator.MoveNext())
			{
				GameEventMessage gameEventMessage = null;
				gameEventMessage.EventName = null;
				gameEventMessage.Source = source;
				gameEventMessage.CustomObject = customObject2;
				gameEventMessage._003CIsSystemEvent_003Ek__BackingField = false;
				SendEvent(gameEventMessage);
			}
		}
	}

	private static void SendEvent(GameEventMessage gameEventMessage)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		GameEventManager.ProcessGameEvent(gameEventMessage);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		string text = default(string);
		if (obj3 != null)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v260 @ rdx_v8+168] (should have been resolved before IL gen)");
		}
		else
		{
			text = null;
		}
		string messageName = text + gameEventMessage.EventName;
		Message.SendMessage<GameEventMessage>(messageName, gameEventMessage);
		Message.Send(gameEventMessage);
	}
}
