using System;
using Cpp2ILInjected;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.Settings;
using Doozy.Engine.UI.Input;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine;

public class GameEventManager : MonoBehaviour
{
	private static GameEventManager s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	public static GameEventManager Instance
	{
		get
		{
			GameEventManager gameEventManager = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)gameEventManager).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				GameEventManager gameEventManager2 = UnityEngine.Object.FindObjectOfType<GameEventManager>();
				s_instance = gameEventManager2;
				GameEventManager gameEventManager3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)gameEventManager3).m_CachedPtr == (IntPtr)0)
				{
					GameEventManager gameEventManager4 = DoozyUtils.AddToScene<GameEventManager>("Game Event Manager", isSingleton: true);
					if ((object)gameEventManager4 == null)
					{
						return (GameEventManager)(object)new NullReferenceException();
					}
					GameObject target = gameEventManager4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	private static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugGameEventManager;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected GameEventManager()
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
		_003CApplicationIsQuitting_003Ek__BackingField = false;
	}

	private void Awake()
	{
		//IL_01fb: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		GameEventManager gameEventManager = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)gameEventManager).m_CachedPtr != (IntPtr)0)
		{
			GameEventManager gameEventManager2 = s_instance;
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
					flag4 = ((UnityEngine.Object)gameEventManager2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = default(object);
					object obj4 = obj5 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					string text;
					string text2 = default(string);
					if (obj6 != null)
					{
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v600 @ rdx_v12+168] (should have been resolved before IL gen)");
						text = "There cannot be two ";
					}
					else
					{
						text = "There cannot be two ";
						text2 = null;
					}
					string message = text + text2 + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj8 = base.gameObject;
					UnityEngine.Object.Destroy(obj8, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	public static GameEventManager AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<GameEventManager>("Game Event Manager", isSingleton: true, selectGameObjectAfterCreation);
	}

	public unsafe static void ProcessGameEvent(GameEventMessage message, bool debug = false)
	{
		//IL_0358: Expected I, but got O
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0167: Expected O, but got I
		//IL_0179: Expected I, but got O
		//IL_019e: Expected I, but got O
		//IL_0230: Expected O, but got Ref
		//IL_02a6: Expected O, but got I
		if (message == null)
		{
			return;
		}
		GameEventManager instance = Instance;
		if ((object)instance != null)
		{
			DoozySettings instance2 = DoozySettings.Instance;
			if ((object)instance2 != null)
			{
				if (!instance2.DebugGameEventManager)
				{
					if (!debug)
					{
						goto IL_00f0;
					}
					if (message._003CIsSystemEvent_003Ek__BackingField)
					{
						goto IL_034a;
					}
				}
				string message2 = "Received '" + message.EventName + "' game event.";
				GameEventManager instance3 = Instance;
				DDebug.Log(message2, instance3);
				goto IL_00f0;
			}
		}
		goto IL_031e;
		IL_035d:
		throw new InvalidCastException();
		IL_034a:
		nint num = (nint)typeof(SystemGameEvent);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = Enum.Parse((Type)num, message.EventName, ignoreCase: false);
		nint num2 = (nint)typeof(SystemGameEvent);
		if (obj3 != null)
		{
			nint num3 = (nint)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v9 (Il2CppClass<System.Object>)+40]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ r8_v7 (Il2CppClass<Doozy.Engine.SystemGameEvent>)+40]");
			if (num4 != 0)
			{
				goto IL_035d;
			}
			GameEventManager instance4 = Instance;
			if ((object)instance4 != null)
			{
				DoozySettings instance5 = DoozySettings.Instance;
				bool flag = (object)instance5 == null;
				if (!flag)
				{
					if (!flag)
					{
						object obj4 = default(object);
						string text = ((Enum)(&obj4)).ToString();
						string message3 = "Received '" + text + "' system game event.";
						GameEventManager instance6 = Instance;
						DDebug.Log(message3, instance6);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v14 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					if (flag2)
					{
						SceneLoader.ActivateLoadedScenes();
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v14 (System.Object)+10]");
					object obj5 = -1;
					if (flag2)
					{
						Application.Quit();
						return;
					}
					if ((nint)obj5 != 1)
					{
						return;
					}
					BackButton instance7 = BackButton.Instance;
					if ((object)instance7 != null)
					{
						instance7.Execute();
						return;
					}
				}
			}
		}
		goto IL_031e;
		IL_00f0:
		if (message._003CIsSystemEvent_003Ek__BackingField)
		{
			goto IL_034a;
		}
		return;
		IL_031e:
		NullReferenceException ex = new NullReferenceException();
		goto IL_035d;
	}
}
