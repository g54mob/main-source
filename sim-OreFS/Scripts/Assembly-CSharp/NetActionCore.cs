using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime.VisualScripting;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

[AddComponentMenu("Network Action Core Component")]
public class NetActionCore : NetworkBehaviour
{
	public void NotifyActionFired(BaseActions actionInstance)
	{
		if (!base.isOwned)
		{
			return;
		}
		if (!actionInstance)
		{
			Debug.LogWarning("[NetActionCore] actionInstance is null");
			return;
		}
		string text = BuildIndexPath(base.transform, actionInstance.transform);
		if (text == null)
		{
			Debug.LogWarning("[NetActionCore] Target Actions is not under this Player root.");
			return;
		}
		int componentIndexOnGameObject = GetComponentIndexOnGameObject(actionInstance.gameObject, actionInstance);
		if (componentIndexOnGameObject < 0)
		{
			Debug.LogWarning("[NetActionCore] Could not resolve BaseActions index on the target GameObject.");
		}
		else if (base.isServer)
		{
			RunOnThisPeer(text, componentIndexOnGameObject);
			RpcRunOnPeers(text, componentIndexOnGameObject);
		}
		else
		{
			CmdRunOnServer(text, componentIndexOnGameObject);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRunOnServer(string relPath, int compIndex)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRunOnServer__String__Int32(relPath, compIndex);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(relPath);
		writer.WriteVarInt(compIndex);
		SendCommandInternal("System.Void NetActionCore::CmdRunOnServer(System.String,System.Int32)", 1509599335, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc(includeOwner = false)]
	private void RpcRunOnPeers(string relPath, int compIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(relPath);
		writer.WriteVarInt(compIndex);
		SendRPCInternal("System.Void NetActionCore::RpcRunOnPeers(System.String,System.Int32)", 446055062, writer, 0, includeOwner: false);
		NetworkWriterPool.Return(writer);
	}

	private void RunOnThisPeer(string relPath, int compIndex)
	{
		Transform transform = ResolveIndexPath(base.transform, relPath);
		if (!transform)
		{
			Debug.LogWarning("[NetActionCore] ResolveIndexPath failed for path '" + relPath + "'");
			return;
		}
		GameObject gameObject = transform.gameObject;
		BaseActions[] components = gameObject.GetComponents<BaseActions>();
		if (components == null || components.Length == 0)
		{
			Debug.LogWarning("[NetActionCore] No BaseActions components found on resolved target GameObject.");
			return;
		}
		if (compIndex < 0 || compIndex >= components.Length)
		{
			Debug.LogWarning($"[NetActionCore] Invalid component index {compIndex} (len={components.Length})");
			return;
		}
		BaseActions baseActions = components[compIndex];
		if (!baseActions)
		{
			Debug.LogWarning("[NetActionCore] Resolved BaseActions reference is null.");
		}
		else
		{
			(baseActions as Actions)?.Invoke(gameObject);
		}
	}

	private static string BuildIndexPath(Transform root, Transform target)
	{
		if (!root || !target)
		{
			return null;
		}
		if (target == root)
		{
			return string.Empty;
		}
		if (!target.IsChildOf(root))
		{
			return null;
		}
		Stack<int> stack = new Stack<int>();
		Transform transform = target;
		while ((bool)transform && transform != root)
		{
			Transform parent = transform.parent;
			if (!parent)
			{
				return null;
			}
			stack.Push(transform.GetSiblingIndex());
			transform = parent;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (int item in stack)
		{
			if (!flag)
			{
				stringBuilder.Append('/');
			}
			stringBuilder.Append(item);
			flag = false;
		}
		return stringBuilder.ToString();
	}

	private static Transform ResolveIndexPath(Transform root, string relPath)
	{
		if (!root)
		{
			return null;
		}
		if (string.IsNullOrEmpty(relPath))
		{
			return root;
		}
		string[] array = relPath.Split('/');
		Transform transform = root;
		for (int i = 0; i < array.Length; i++)
		{
			if (!int.TryParse(array[i], out var result))
			{
				return null;
			}
			if (result < 0 || result >= transform.childCount)
			{
				return null;
			}
			transform = transform.GetChild(result);
		}
		return transform;
	}

	private static int GetComponentIndexOnGameObject(GameObject go, BaseActions instance)
	{
		BaseActions[] components = go.GetComponents<BaseActions>();
		for (int i = 0; i < components.Length; i++)
		{
			if ((object)components[i] == instance)
			{
				return i;
			}
		}
		return -1;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRunOnServer__String__Int32(string relPath, int compIndex)
	{
		if (base.connectionToClient != base.netIdentity.connectionToClient)
		{
			Debug.LogWarning("[NetActionCore] Cmd rejected: caller is not the owner of this Player.");
		}
		else
		{
			RpcRunOnPeers(relPath, compIndex);
		}
	}

	protected static void InvokeUserCode_CmdRunOnServer__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRunOnServer called on client.");
		}
		else
		{
			((NetActionCore)obj).UserCode_CmdRunOnServer__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcRunOnPeers__String__Int32(string relPath, int compIndex)
	{
		RunOnThisPeer(relPath, compIndex);
	}

	protected static void InvokeUserCode_RpcRunOnPeers__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRunOnPeers called on server.");
		}
		else
		{
			((NetActionCore)obj).UserCode_RpcRunOnPeers__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	static NetActionCore()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetActionCore), "System.Void NetActionCore::CmdRunOnServer(System.String,System.Int32)", InvokeUserCode_CmdRunOnServer__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetActionCore), "System.Void NetActionCore::RpcRunOnPeers(System.String,System.Int32)", InvokeUserCode_RpcRunOnPeers__String__Int32);
	}
}
