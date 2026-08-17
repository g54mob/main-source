using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Progress;
using Doozy.Engine.SceneManagement;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes;

public class LoadSceneNode : Node
{
	public GetSceneBy GetSceneBy;

	public LoadSceneMode LoadSceneMode;

	public bool AllowSceneActivation;

	public float SceneActivationDelay;

	public int SceneBuildIndex;

	public string SceneName;

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.LoadSceneNodeName;
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
		//IL_0110: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_00ce: Expected F4, but got I
		//IL_00f2: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(LoadSceneNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.LoadSceneNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.LoadSceneNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(LoadSceneNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				AllowSceneActivation = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				GetSceneBy = GetSceneBy.Name;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+84]");
				LoadSceneMode = LoadSceneMode.Single;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+8C]");
				SceneActivationDelay = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				SceneBuildIndex = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+98]");
				SceneName = (string)0;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			SceneLoader loader = SceneLoader.GetLoader();
			loader.LoadSceneMode = LoadSceneMode;
			loader.GetSceneBy = GetSceneBy;
			loader.SceneName = SceneName;
			loader.SceneBuildIndex = SceneBuildIndex;
			loader.AllowSceneActivation = AllowSceneActivation;
			loader.SceneActivationDelay = SceneActivationDelay;
			loader.SelfDestructAfterSceneLoaded = true;
			if (loader.GetSceneBy == GetSceneBy.Name)
			{
				Progressor progressor = loader.LoadSceneAsync(loader.SceneName, loader.LoadSceneMode);
			}
			else if (loader.GetSceneBy == GetSceneBy.BuildIndex)
			{
				Progressor progressor2 = loader.LoadSceneAsync(loader.SceneBuildIndex, loader.LoadSceneMode);
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
	}

	private void LoadScene()
	{
		SceneLoader loader = SceneLoader.GetLoader();
		loader.LoadSceneMode = LoadSceneMode;
		loader.GetSceneBy = GetSceneBy;
		loader.SceneName = SceneName;
		loader.SceneBuildIndex = SceneBuildIndex;
		loader.AllowSceneActivation = AllowSceneActivation;
		loader.SceneActivationDelay = SceneActivationDelay;
		loader.SelfDestructAfterSceneLoaded = true;
		if (loader.GetSceneBy == GetSceneBy.Name)
		{
			Progressor progressor = loader.LoadSceneAsync(loader.SceneName, loader.LoadSceneMode);
		}
		else if (loader.GetSceneBy == GetSceneBy.BuildIndex)
		{
			Progressor progressor2 = loader.LoadSceneAsync(loader.SceneBuildIndex, loader.LoadSceneMode);
		}
	}

	public override void CheckForErrors()
	{
	}

	public LoadSceneNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980804]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AllowSceneActivation = true;
		SceneActivationDelay = 0.2f;
		SceneName = "";
		((ScriptableObject)this)._002Ector();
	}
}
