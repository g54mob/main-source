using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes;

public class WaitNode : Node
{
	public enum WaitType
	{
		Time,
		GameEvent,
		SceneLoad,
		SceneUnload,
		ActiveSceneChange,
		UIView,
		UIButton,
		UIDrawer
	}

	private const WaitType DEFAULT_WAIT_TYPE = WaitType.Time;

	private const bool DEFAULT_ANY_VALUE = false;

	private const bool DEFAULT_IGNORE_UNITY_TIMESCALE = true;

	private const bool DEFAULT_RANDOM_DURATION = false;

	private const float DEFAULT_DURATION = 1f;

	private const float DEFAULT_DURATION_MAX = 1f;

	private const float DEFAULT_DURATION_MIN = 0f;

	private const string DEFAULT_GAME_EVENT = "";

	public GetSceneBy GetSceneBy;

	public WaitType WaitFor;

	public bool AnyValue;

	public bool IgnoreUnityTimescale = true;

	public bool RandomDuration;

	public float Duration = 1f;

	public float DurationMax = 1f;

	public float DurationMin;

	public int SceneBuildIndex;

	public string GameEvent = "";

	public string SceneName;

	public UIViewBehaviorType UIViewTriggerAction = UIViewBehaviorType.Show;

	public string ViewCategory;

	public string ViewName;

	public UIButtonBehaviorType UIButtonTriggerAction;

	public string ButtonCategory;

	public string ButtonName;

	public UIDrawerBehaviorType UIDrawerTriggerAction;

	public string DrawerName;

	public bool CustomDrawerName;

	[NonSerialized]
	public float CurrentDuration;

	[NonSerialized]
	private bool m_timerIsActive;

	[NonSerialized]
	private double m_timerStart;

	[NonSerialized]
	private float m_timeDelay;

	public float TimerProgress
	{
		get
		{
			//IL_002d: Expected F4, but got I4
			//IL_00a8: Invalid comparison between I4 and F4
			//IL_0061: Expected F4, but got I4
			//IL_006f: Expected O, but got F4
			float num;
			if (!m_timerIsActive)
			{
				num = 0f;
			}
			else
			{
				object obj = Time.realtimeSinceStartup;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+100h]\"");
				num = 0f / m_timeDelay;
			}
			if (!(0f > num))
			{
				if (num > 1f)
				{
					return 1f;
				}
			}
			else
			{
				num = 0f;
			}
			return num;
		}
	}

	public string WaitForInfoTitle
	{
		get
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			WaitType waitFor = WaitFor;
			if (WaitFor <= WaitType.UIDrawer)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v1+2BDCB64+v32 @ rax_v2 (Doozy.Engine.UI.Nodes.WaitNode+WaitType)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v53 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return "---";
		}
	}

	public string WaitForInfoDescription
	{
		get
		{
			//IL_0040: Expected O, but got I8
			//IL_005a: Expected O, but got I8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998084A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			while (true)
			{
				WaitType waitFor = WaitFor;
				if (WaitFor > WaitType.UIDrawer)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v1+2BDCDE8+v32 @ rax_v2 (Doozy.Engine.UI.Nodes.WaitNode+WaitType)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v51 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return "---";
		}
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.WaitNodeName;
		base.m_allowDuplicateNodeName = true;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
	}

	public override void CopyNode(Node original)
	{
		//IL_016a: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_00f2: Expected F4, but got I
		//IL_0104: Expected F4, but got I
		//IL_0116: Expected F4, but got I
		//IL_013a: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_019f: Expected O, but got I
		//IL_0208: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_0231: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(WaitNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.WaitNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.WaitNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(WaitNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				GetSceneBy = GetSceneBy.Name;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+84]");
				WaitFor = WaitType.Time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				AnyValue = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+89]");
				IgnoreUnityTimescale = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+8A]");
				RandomDuration = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+8C]");
				Duration = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				DurationMax = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+94]");
				DurationMin = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+98]");
				SceneBuildIndex = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A0]");
				GameEvent = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A8]");
				SceneName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+B0]");
				UIViewTriggerAction = UIViewBehaviorType.Unknown;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+B8]");
				ViewCategory = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+C0]");
				ViewName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+C8]");
				UIButtonTriggerAction = UIButtonBehaviorType.OnClick;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+D0]");
				ButtonCategory = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+D8]");
				ButtonName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+E0]");
				UIDrawerTriggerAction = UIDrawerBehaviorType.Open;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+E8]");
				DrawerName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+F0]");
				CustomDrawerName = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	protected override void OnEnable()
	{
		if (WaitFor == WaitType.Time)
		{
			UpdateCurrentDuration();
		}
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			StartWait();
		}
	}

	public override void OnUpdate()
	{
		//IL_0078: Expected O, but got F4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_002d: Invalid comparison between O and F4
		//IL_00c2: Expected O, but got F4
		//IL_004a: Invalid comparison between F4 and O
		if (!m_timerIsActive)
		{
			return;
		}
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+100h]\"");
		object obj2 = 0 / m_timeDelay;
		if (0 > (nint)obj2)
		{
			return;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return;
			}
		}
		m_timerIsActive = false;
		object obj3 = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timerStart = 0.0;
		ContinueToNextNode();
	}

	public override void OnExit(Node nextActiveNode, Connection connection)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B54]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base.m_debugMode)
		{
			string message = "Node '" + base.m_name + "': OnExit";
			DDebug.Log(message);
		}
		base._003CPing_003Ek__BackingField = true;
		if (connection != null)
		{
			connection._003CPing_003Ek__BackingField = true;
		}
		EndWait();
	}

	private void UpdateCurrentDuration()
	{
		float num2;
		if (RandomDuration)
		{
			float num = UnityEngine.Random.Range(DurationMin, DurationMax);
			num2 = num;
		}
		else
		{
			num2 = Duration;
		}
		CurrentDuration = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
		double num3 = Math.Round(num2, 2, MidpointRounding.ToEven);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
		CurrentDuration = 0f;
	}

	private void StartWait()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 88 Invalid \"Jump target not found in method: 0x182BDDB49\"");
	}

	private void EndWait()
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		while (true)
		{
			WaitType waitFor = WaitFor;
			if (WaitFor <= WaitType.UIDrawer)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v1+2BDDF98+v32 @ rax_v2 (Doozy.Engine.UI.Nodes.WaitNode+WaitType)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rcx_v3 (should have been resolved before IL gen)");
				continue;
			}
			break;
		}
	}

	private void ActivateTimer()
	{
		//IL_0019: Expected O, but got F4
		m_timerIsActive = true;
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timeDelay = CurrentDuration;
		base.m_useUpdate = true;
		m_timerStart = 0.0;
	}

	private void StopTimer()
	{
		m_timerIsActive = false;
		base.m_useUpdate = false;
	}

	private unsafe void OnGameEventMessage(GameEventMessage message)
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Ref, but got Unknown
		//IL_0192: Expected I8, but got I4
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected Ref, but got Unknown
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		if (base.m_debugMode)
		{
			string message2 = "GameEvent received: " + message.EventName + " // Listening for: " + GameEvent;
			DDebug.Log(message2, this);
		}
		if (!AnyValue)
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
		ContinueToNextNode();
	}

	private unsafe void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		//IL_000e: Expected I4, but got O
		//IL_001b: Expected O, but got Ref
		if (base.m_debugMode)
		{
			string nameInternal = Scene.GetNameInternal((int)scene);
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			string message = "Scene Loaded - Scene: " + nameInternal + " // LoadSceneMode: " + text;
			DDebug.Log(message, this);
		}
		if (AnyValue || IsTargetScene(scene))
		{
			ContinueToNextNode();
		}
	}

	private void SceneUnloaded(Scene unloadedScene)
	{
		//IL_003c: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980853]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base.m_debugMode)
		{
			string nameInternal = Scene.GetNameInternal((int)unloadedScene);
			string message = "Scene Unloaded - Scene: " + nameInternal;
			DDebug.Log(message, this);
		}
		if (AnyValue || IsTargetScene(unloadedScene))
		{
			ContinueToNextNode();
		}
	}

	private void ActiveSceneChanged(Scene current, Scene next)
	{
		//IL_003c: Expected I4, but got O
		//IL_0049: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980854]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base.m_debugMode)
		{
			string nameInternal = Scene.GetNameInternal((int)current);
			string nameInternal2 = Scene.GetNameInternal((int)next);
			string message = "Active Scene Changed - Replaced Scene: " + nameInternal + " // Next Scene: " + nameInternal2;
			DDebug.Log(message, this);
		}
		if (AnyValue || IsTargetScene(next))
		{
			ContinueToNextNode();
		}
	}

	private unsafe bool IsTargetScene(Scene scene)
	{
		//IL_000e: Expected I4, but got O
		//IL_0128: Expected I4, but got O
		//IL_0241: Expected I4, but got O
		//IL_0149: Expected I4, but got O
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Ref, but got Unknown
		//IL_00c4: Expected I8, but got I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Ref, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Ref, but got Unknown
		//IL_01f6: Expected I8, but got I4
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected Ref, but got Unknown
		if (GetSceneBy == GetSceneBy.Name)
		{
			string nameInternal = Scene.GetNameInternal((int)scene);
			if (nameInternal == null)
			{
				goto IL_0233;
			}
			string sceneName = SceneName;
			if ((object)nameInternal == SceneName)
			{
				goto IL_022d;
			}
			if (SceneName != null && nameInternal._stringLength == sceneName._stringLength)
			{
				ref byte first = ref *(byte*)(nameInternal + 20);
				ulong length = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(SceneName + 20), length))
				{
					goto IL_022d;
				}
			}
		}
		else if (GetSceneBy == GetSceneBy.BuildIndex)
		{
			string nameInternal2 = Scene.GetNameInternal((int)scene);
			Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(SceneBuildIndex);
			string nameInternal3 = Scene.GetNameInternal((int)sceneByBuildIndex);
			if (nameInternal2 == null)
			{
				goto IL_0233;
			}
			if ((object)nameInternal2 != nameInternal3)
			{
				if (nameInternal3 != null && nameInternal2._stringLength == nameInternal3._stringLength)
				{
					ref byte second = ref *(byte*)(nameInternal3 + 20);
					ulong length2 = (ulong)(nameInternal2._stringLength + nameInternal2._stringLength);
					bool flag = System.SpanHelpers.SequenceEqual(ref *(byte*)(nameInternal2 + 20), ref second, length2);
					return !flag;
				}
				goto IL_022d;
			}
		}
		return false;
		IL_022d:
		return true;
		IL_0233:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void OnUIViewMessage(UIViewMessage message)
	{
		//IL_00d3: Expected O, but got Ref
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected Ref, but got Unknown
		//IL_02b4: Expected I8, but got I4
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Ref, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected Ref, but got Unknown
		//IL_03b5: Expected I8, but got I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected Ref, but got Unknown
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		if (WaitFor != WaitType.UIView)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[10];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIView view = message.View;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIView view2 = message.View;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type == UIViewBehaviorType.Unknown || message.Type != UIViewTriggerAction)
		{
			return;
		}
		if (!AnyValue)
		{
			UIView view3 = message.View;
			string viewCategory = view3.ViewCategory;
			string viewCategory2 = ViewCategory;
			if ((object)view3.ViewCategory != ViewCategory)
			{
				if (ViewCategory == null || viewCategory._stringLength != viewCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ViewCategory + 20);
				ulong length = (ulong)(viewCategory._stringLength + viewCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view3.ViewCategory + 20), ref second, length))
				{
					return;
				}
			}
			UIView view4 = message.View;
			string viewName = view4.ViewName;
			string viewName2 = ViewName;
			if ((object)view4.ViewName != ViewName)
			{
				if (ViewName == null || viewName._stringLength != viewName2._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ViewName + 20);
				ulong length2 = (ulong)(viewName._stringLength + viewName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view4.ViewName + 20), ref second2, length2))
				{
					return;
				}
			}
		}
		ContinueToNextNode();
	}

	private unsafe void OnUIButtonMessage(UIButtonMessage message)
	{
		//IL_017e: Expected O, but got I
		//IL_00d3: Expected O, but got Ref
		//IL_01b5: Expected O, but got I4
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected Ref, but got Unknown
		//IL_024a: Expected I8, but got I4
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected Ref, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected Ref, but got Unknown
		//IL_033a: Expected I8, but got I4
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected Ref, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected Ref, but got Unknown
		//IL_04fa: Expected I8, but got I4
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected Ref, but got Unknown
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected Ref, but got Unknown
		//IL_05fb: Expected I8, but got I4
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected Ref, but got Unknown
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		if (WaitFor != WaitType.UIButton)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[6];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type != UIButtonTriggerAction)
		{
			return;
		}
		string buttonName = ButtonName;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
		if ((nint)0 == 0)
		{
			_ = 1;
			obj = 1;
		}
		object obj2 = "Back";
		if ((object)ButtonName == "Back")
		{
			goto IL_0287;
		}
		if ("Back" != null)
		{
			int stringLength = buttonName._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte first = ref *(byte*)(ButtonName + 20);
				ulong length = (ulong)(buttonName._stringLength + buttonName._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Back" + 20), length))
				{
					goto IL_0287;
				}
			}
		}
		goto IL_03d2;
		IL_03d2:
		if (!AnyValue)
		{
			UIButton button = message.Button;
			if ((object)message.Button == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rsi_v10 (Doozy.Engine.UI.UIButton)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			UIButton button2 = message.Button;
			string buttonCategory = button2.ButtonCategory;
			string buttonCategory2 = ButtonCategory;
			if ((object)button2.ButtonCategory != ButtonCategory)
			{
				if (ButtonCategory == null || buttonCategory._stringLength != buttonCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ButtonCategory + 20);
				ulong length2 = (ulong)(buttonCategory._stringLength + buttonCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button2.ButtonCategory + 20), ref second, length2))
				{
					return;
				}
			}
			UIButton button3 = message.Button;
			string buttonName2 = button3.ButtonName;
			string buttonName3 = ButtonName;
			if ((object)button3.ButtonName != ButtonName)
			{
				if (ButtonName == null || buttonName2._stringLength != buttonName3._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ButtonName + 20);
				ulong length3 = (ulong)(buttonName2._stringLength + buttonName2._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button3.ButtonName + 20), ref second2, length3))
				{
					return;
				}
			}
		}
		goto IL_063c;
		IL_063c:
		ContinueToNextNode();
		return;
		IL_0287:
		string buttonName4 = message.ButtonName;
		if (obj == null)
		{
			_ = 1;
		}
		object obj3 = "Back";
		if ((object)message.ButtonName != "Back")
		{
			if ("Back" != null)
			{
				int stringLength2 = buttonName4._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rdx_v14+10]");
				if ((nint)stringLength2 == 0)
				{
					ref byte first2 = ref *(byte*)(message.ButtonName + 20);
					ulong length4 = (ulong)(buttonName4._stringLength + buttonName4._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Back" + 20), length4))
					{
						goto IL_063c;
					}
				}
			}
			UIButton button4 = message.Button;
			if ((object)message.Button != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rsi_v12 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0 && message.Button.IsBackButton)
				{
					goto IL_063c;
				}
			}
			goto IL_03d2;
		}
		goto IL_063c;
	}

	private unsafe void OnUIDrawerMessage(UIDrawerMessage message)
	{
		//IL_00d3: Expected O, but got Ref
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Ref, but got Unknown
		//IL_024e: Expected I8, but got I4
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Ref, but got Unknown
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		if (WaitFor != WaitType.UIDrawer)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[6];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIDrawer drawer = message.Drawer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type != UIDrawerTriggerAction)
		{
			return;
		}
		if (!AnyValue)
		{
			UIDrawer drawer2 = message.Drawer;
			string drawerName = drawer2.DrawerName;
			string drawerName2 = DrawerName;
			if ((object)drawer2.DrawerName != DrawerName)
			{
				if (DrawerName == null || drawerName._stringLength != drawerName2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(DrawerName + 20);
				ulong length = (ulong)(drawerName._stringLength + drawerName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(drawer2.DrawerName + 20), ref second, length))
				{
					return;
				}
			}
		}
		ContinueToNextNode();
	}

	private void ContinueToNextNode()
	{
		Socket firstOutputSocket = base.FirstOutputSocket;
		List<Connection> connections = firstOutputSocket.m_connections;
		if (connections._size > 0)
		{
			Socket firstOutputSocket2 = base.FirstOutputSocket;
			Connection firstConnection = firstOutputSocket2.FirstConnection;
			Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
			base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
		}
	}

	public override void CheckForErrors()
	{
	}

	public WaitNode()
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DrawerName = "Unnamed";
		((ScriptableObject)this)._002Ector();
	}
}
