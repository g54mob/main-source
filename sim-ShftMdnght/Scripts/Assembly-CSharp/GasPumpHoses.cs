using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class GasPumpHoses : NetworkBehaviour
{
	public Transform[] transformsToFollow;

	public Transform[] target;

	public HosePump[] hosePump;

	public Transform upPoint;

	public int index;

	public static GasPumpHoses Instance { get; private set; }

	private void FixedUpdate()
	{
		for (int i = 0; i < transformsToFollow.Length; i++)
		{
			if (transformsToFollow[i] == null)
			{
				target[i].position = Vector3.Lerp(target[i].position, upPoint.position, Time.deltaTime * 25f);
			}
			else
			{
				target[i].position = Vector3.Lerp(target[i].position, transformsToFollow[i].position, Time.deltaTime * 25f);
			}
		}
	}

	public void ChangeRopeBulge(Transform transformToFollow, bool bulgeOn)
	{
		if (base.isServer)
		{
			ChangeRopeBulgeRpc(transformToFollow, bulgeOn);
		}
		else
		{
			ChangeRopeBulgeCmd(transformToFollow, bulgeOn);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeRopeBulgeCmd(Transform transformToFollow, bool bulgeOn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		writer.WriteBool(bulgeOn);
		SendCommandInternal("System.Void GasPumpHoses::ChangeRopeBulgeCmd(UnityEngine.Transform,System.Boolean)", -1675576215, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeRopeBulgeRpc(Transform transformToFollow, bool bulgeOn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		writer.WriteBool(bulgeOn);
		SendRPCInternal("System.Void GasPumpHoses::ChangeRopeBulgeRpc(UnityEngine.Transform,System.Boolean)", -601047738, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ConnectRope(Transform transformToFollow)
	{
		if (base.isServer)
		{
			ConnectRopeRpc(transformToFollow);
		}
		else
		{
			ConnectRopeCmd(transformToFollow);
		}
	}

	[Command(requiresAuthority = false)]
	public void ConnectRopeCmd(Transform transformToFollow)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		SendCommandInternal("System.Void GasPumpHoses::ConnectRopeCmd(UnityEngine.Transform)", 1802949703, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ConnectRopeRpc(Transform transformToFollow)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		SendRPCInternal("System.Void GasPumpHoses::ConnectRopeRpc(UnityEngine.Transform)", 1897836658, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void DisconnectRope(Transform transformToFollow)
	{
		if (base.isServer)
		{
			DisconnectRopeRpc(transformToFollow);
		}
		else
		{
			DisconnectRopeCmd(transformToFollow);
		}
	}

	[Command(requiresAuthority = false)]
	public void DisconnectRopeCmd(Transform transformToFollow)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		SendCommandInternal("System.Void GasPumpHoses::DisconnectRopeCmd(UnityEngine.Transform)", -190969663, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void DisconnectRopeRpc(Transform transformToFollow)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(transformToFollow);
		SendRPCInternal("System.Void GasPumpHoses::DisconnectRopeRpc(UnityEngine.Transform)", 1258662296, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeRopeBulgeCmd__Transform__Boolean(Transform transformToFollow, bool bulgeOn)
	{
		ChangeRopeBulgeRpc(transformToFollow, bulgeOn);
	}

	protected static void InvokeUserCode_ChangeRopeBulgeCmd__Transform__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeRopeBulgeCmd called on client.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_ChangeRopeBulgeCmd__Transform__Boolean(reader.ReadTransform(), reader.ReadBool());
		}
	}

	protected void UserCode_ChangeRopeBulgeRpc__Transform__Boolean(Transform transformToFollow, bool bulgeOn)
	{
		for (int i = 0; i < transformsToFollow.Length; i++)
		{
			if ((bool)transformsToFollow[i] && transformToFollow.GetComponent<InventoryManager>().thirdPersonGasPump == transformsToFollow[i])
			{
				if (bulgeOn)
				{
					hosePump[i].bulgeThicknessTarg = 0.06f;
				}
				else
				{
					hosePump[i].bulgeThicknessTarg = 0.03f;
				}
			}
		}
	}

	protected static void InvokeUserCode_ChangeRopeBulgeRpc__Transform__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeRopeBulgeRpc called on server.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_ChangeRopeBulgeRpc__Transform__Boolean(reader.ReadTransform(), reader.ReadBool());
		}
	}

	protected void UserCode_ConnectRopeCmd__Transform(Transform transformToFollow)
	{
		ConnectRopeRpc(transformToFollow);
	}

	protected static void InvokeUserCode_ConnectRopeCmd__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ConnectRopeCmd called on client.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_ConnectRopeCmd__Transform(reader.ReadTransform());
		}
	}

	protected void UserCode_ConnectRopeRpc__Transform(Transform transformToFollow)
	{
		transformsToFollow[index] = transformToFollow.GetComponent<InventoryManager>().thirdPersonGasPump;
		index++;
		if (index >= transformsToFollow.Length)
		{
			index = 0;
		}
	}

	protected static void InvokeUserCode_ConnectRopeRpc__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ConnectRopeRpc called on server.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_ConnectRopeRpc__Transform(reader.ReadTransform());
		}
	}

	protected void UserCode_DisconnectRopeCmd__Transform(Transform transformToFollow)
	{
		DisconnectRopeRpc(transformToFollow);
	}

	protected static void InvokeUserCode_DisconnectRopeCmd__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DisconnectRopeCmd called on client.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_DisconnectRopeCmd__Transform(reader.ReadTransform());
		}
	}

	protected void UserCode_DisconnectRopeRpc__Transform(Transform transformToFollow)
	{
		for (int i = 0; i < transformsToFollow.Length; i++)
		{
			if ((bool)transformsToFollow[i] && transformToFollow.GetComponent<InventoryManager>().thirdPersonGasPump == transformsToFollow[i])
			{
				transformsToFollow[i] = null;
			}
		}
	}

	protected static void InvokeUserCode_DisconnectRopeRpc__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DisconnectRopeRpc called on server.");
		}
		else
		{
			((GasPumpHoses)obj).UserCode_DisconnectRopeRpc__Transform(reader.ReadTransform());
		}
	}

	static GasPumpHoses()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GasPumpHoses), "System.Void GasPumpHoses::ChangeRopeBulgeCmd(UnityEngine.Transform,System.Boolean)", InvokeUserCode_ChangeRopeBulgeCmd__Transform__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GasPumpHoses), "System.Void GasPumpHoses::ConnectRopeCmd(UnityEngine.Transform)", InvokeUserCode_ConnectRopeCmd__Transform, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GasPumpHoses), "System.Void GasPumpHoses::DisconnectRopeCmd(UnityEngine.Transform)", InvokeUserCode_DisconnectRopeCmd__Transform, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(GasPumpHoses), "System.Void GasPumpHoses::ChangeRopeBulgeRpc(UnityEngine.Transform,System.Boolean)", InvokeUserCode_ChangeRopeBulgeRpc__Transform__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(GasPumpHoses), "System.Void GasPumpHoses::ConnectRopeRpc(UnityEngine.Transform)", InvokeUserCode_ConnectRopeRpc__Transform);
		RemoteProcedureCalls.RegisterRpc(typeof(GasPumpHoses), "System.Void GasPumpHoses::DisconnectRopeRpc(UnityEngine.Transform)", InvokeUserCode_DisconnectRopeRpc__Transform);
	}
}
