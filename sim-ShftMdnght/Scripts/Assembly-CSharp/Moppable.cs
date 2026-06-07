using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Moppable : NetworkBehaviour
{
	public GameObject spawnObj;

	public Collider col;

	public string mopReason;

	public float mopRevenue;

	public bool roach;

	private void Start()
	{
		ReviewsManager.Instance.UpdateHygienePenalty(1);
	}

	[Command(requiresAuthority = false)]
	public void Clean()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Moppable::Clean()", -194634174, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActuallyClean()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Moppable::ActuallyClean()", 181546085, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ServerActuallyClean()
	{
		Object.Destroy(col);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_Clean()
	{
		ActuallyClean();
		ServerActuallyClean();
	}

	protected static void InvokeUserCode_Clean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command Clean called on client.");
		}
		else
		{
			((Moppable)obj).UserCode_Clean();
		}
	}

	protected void UserCode_ActuallyClean()
	{
		ReviewsManager.Instance.UpdateHygienePenalty(-1);
		Object.Destroy(col);
		if (base.isServer)
		{
			StoreManager.Instance.ChangeRevenue(mopReason, mopRevenue);
			GameObject obj = Object.Instantiate(spawnObj, base.transform.position, base.transform.rotation);
			obj.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			NetworkServer.Spawn(obj);
			NetworkServer.Destroy(base.gameObject);
		}
		if (roach)
		{
			RoachCountdown.Instance.GotARoach();
		}
	}

	protected static void InvokeUserCode_ActuallyClean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyClean called on server.");
		}
		else
		{
			((Moppable)obj).UserCode_ActuallyClean();
		}
	}

	static Moppable()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Moppable), "System.Void Moppable::Clean()", InvokeUserCode_Clean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Moppable), "System.Void Moppable::ActuallyClean()", InvokeUserCode_ActuallyClean);
	}
}
