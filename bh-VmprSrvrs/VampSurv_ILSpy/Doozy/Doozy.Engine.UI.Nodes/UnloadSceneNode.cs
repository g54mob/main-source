using System;
using System.Collections.Generic;
using System.Reflection;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes;

public class UnloadSceneNode : Node
{
	public GetSceneBy GetSceneBy;

	public int SceneBuildIndex;

	public string SceneName;

	public bool WaitForSceneToUnload;

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.UnloadSceneNodeName;
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
		//IL_00ec: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_00bc: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(UnloadSceneNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UnloadSceneNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UnloadSceneNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(UnloadSceneNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				GetSceneBy = GetSceneBy.Name;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+84]");
				SceneBuildIndex = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				SceneName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				WaitForSceneToUnload = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph == null || ((UnityEngine.Object)activeGraph).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (WaitForSceneToUnload)
		{
			SceneDirector instance = SceneDirector.Instance;
			UnityAction<Scene> unityAction = null;
			((UnloadSceneNode)(object)unityAction).SceneUnloaded((Scene)this);
			((UnloadSceneNode)(object)instance.OnSceneUnloaded).SceneUnloaded((Scene)unityAction);
		}
		UnloadScene();
		if (!WaitForSceneToUnload)
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
	}

	public override void OnExit(Node nextActiveNode, Connection connection)
	{
		//IL_00d4: Expected O, but got I
		//IL_00d4: Expected O, but got I
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
		if (WaitForSceneToUnload)
		{
			SceneDirector instance = SceneDirector.Instance;
			SceneUnloadedEvent onSceneUnloaded = instance.OnSceneUnloaded;
			UnityAction<Scene> unityAction = null;
			((UnloadSceneNode)(object)unityAction).SceneUnloaded((Scene)this);
			MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v3 (Doozy.Engine.SceneManagement.SceneUnloadedEvent)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v8 (UnityEngine.Events.UnityAction`1<UnityEngine.SceneManagement.Scene>)+20]");
			((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		}
	}

	private void UnloadScene()
	{
		if (GetSceneBy == GetSceneBy.Name)
		{
			SceneDirector instance = SceneDirector.Instance;
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if (!instance2.DebugSceneDirector)
				{
					goto IL_00b5;
				}
			}
			string message = "UnloadSceneAsync - sceneName: " + SceneName;
			SceneDirector instance3 = SceneDirector.Instance;
			DDebug.Log(message, instance3);
			goto IL_00b5;
		}
		if (GetSceneBy != GetSceneBy.BuildIndex)
		{
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}
		SceneDirector instance4 = SceneDirector.Instance;
		if (!instance4.DebugMode)
		{
			DoozySettings instance5 = DoozySettings.Instance;
			if (!instance5.DebugSceneDirector)
			{
				goto IL_018a;
			}
		}
		int num = default(int);
		string text = num.ToString();
		string message2 = "UnloadSceneAsync - sceneBuildIndex: " + text;
		SceneDirector instance6 = SceneDirector.Instance;
		DDebug.Log(message2, instance6);
		goto IL_018a;
		IL_00b5:
		AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(SceneName);
		return;
		IL_018a:
		ref bool outSuccess = default(ref bool);
		AsyncOperation asyncOperation2 = SceneManager.UnloadSceneNameIndexInternal("", SceneBuildIndex, false, UnloadSceneOptions.None, out outSuccess);
	}

	private unsafe void SceneUnloaded(Scene unloadedScene)
	{
		//IL_000e: Expected I4, but got O
		//IL_010b: Expected I4, but got O
		//IL_012c: Expected I4, but got O
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Ref, but got Unknown
		//IL_00ac: Expected I8, but got I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Ref, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected Ref, but got Unknown
		//IL_01bc: Expected I8, but got I4
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Ref, but got Unknown
		if (GetSceneBy == GetSceneBy.Name)
		{
			string nameInternal = Scene.GetNameInternal((int)unloadedScene);
			string sceneName = SceneName;
			if ((object)nameInternal != SceneName)
			{
				if (SceneName == null || nameInternal._stringLength != sceneName._stringLength)
				{
					return;
				}
				ref byte first = ref *(byte*)(nameInternal + 20);
				ulong length = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(SceneName + 20), length))
				{
					return;
				}
			}
		}
		else if (GetSceneBy == GetSceneBy.BuildIndex)
		{
			string nameInternal2 = Scene.GetNameInternal((int)unloadedScene);
			Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(SceneBuildIndex);
			string nameInternal3 = Scene.GetNameInternal((int)sceneByBuildIndex);
			if ((object)nameInternal2 != nameInternal3)
			{
				if (nameInternal3 == null || nameInternal2._stringLength != nameInternal3._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(nameInternal3 + 20);
				ulong length2 = (ulong)(nameInternal2._stringLength + nameInternal2._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(nameInternal2 + 20), ref second, length2))
				{
					return;
				}
			}
		}
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

	public UnloadSceneNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980848]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SceneName = "";
		((ScriptableObject)this)._002Ector();
	}
}
