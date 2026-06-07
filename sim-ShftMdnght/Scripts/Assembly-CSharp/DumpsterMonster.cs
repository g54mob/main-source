using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class DumpsterMonster : Hittable
{
	public Transform monster;

	public Animator anim;

	public Transform[] positions;

	public int curPosition = -1;

	public GameObject insideDumpsterMonster;

	public bool doneInsideBit;

	public Collider hitCollider;

	private bool alreadyHit;

	public static DumpsterMonster Instance { get; private set; }

	private void Start()
	{
		alreadyHit = false;
		hitCollider.enabled = true;
		anim.SetTrigger("Bored Idle");
	}

	public void SetPosition(int pos)
	{
		if (ClientPlayer.Instance.isServer)
		{
			SetPositionRpc(pos);
		}
		else
		{
			SetPositionCmd(pos);
		}
	}

	[Command(requiresAuthority = false)]
	private void SetPositionCmd(int pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(pos);
		SendCommandInternal("System.Void DumpsterMonster::SetPositionCmd(System.Int32)", 827381051, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SetPositionRpc(int pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(pos);
		SendRPCInternal("System.Void DumpsterMonster::SetPositionRpc(System.Int32)", -288241336, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override void Hit(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction = false)
	{
		if (!alreadyHit)
		{
			alreadyHit = true;
			hitCollider.enabled = false;
			if (ClientPlayer.Instance.isServer)
			{
				RunToSideRpc();
			}
			else
			{
				RunToSideCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void RunToSideCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DumpsterMonster::RunToSideCmd()", -1361126510, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RunToSideRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DumpsterMonster::RunToSideRpc()", 1429052501, writer, 0, includeOwner: true);
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

	protected void UserCode_SetPositionCmd__Int32(int pos)
	{
		SetPositionRpc(pos);
	}

	protected static void InvokeUserCode_SetPositionCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetPositionCmd called on client.");
		}
		else
		{
			((DumpsterMonster)obj).UserCode_SetPositionCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetPositionRpc__Int32(int pos)
	{
		alreadyHit = false;
		hitCollider.enabled = true;
		if (pos < positions.Length)
		{
			monster.position = positions[pos].position;
		}
		else if (!doneInsideBit)
		{
			doneInsideBit = true;
			insideDumpsterMonster.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
		anim.SetTrigger("Bored Idle");
	}

	protected static void InvokeUserCode_SetPositionRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetPositionRpc called on server.");
		}
		else
		{
			((DumpsterMonster)obj).UserCode_SetPositionRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RunToSideCmd()
	{
		RunToSideRpc();
	}

	protected static void InvokeUserCode_RunToSideCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RunToSideCmd called on client.");
		}
		else
		{
			((DumpsterMonster)obj).UserCode_RunToSideCmd();
		}
	}

	protected void UserCode_RunToSideRpc()
	{
		alreadyHit = true;
		hitCollider.enabled = false;
		anim.SetTrigger("RunToSide");
	}

	protected static void InvokeUserCode_RunToSideRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RunToSideRpc called on server.");
		}
		else
		{
			((DumpsterMonster)obj).UserCode_RunToSideRpc();
		}
	}

	static DumpsterMonster()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DumpsterMonster), "System.Void DumpsterMonster::SetPositionCmd(System.Int32)", InvokeUserCode_SetPositionCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DumpsterMonster), "System.Void DumpsterMonster::RunToSideCmd()", InvokeUserCode_RunToSideCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DumpsterMonster), "System.Void DumpsterMonster::SetPositionRpc(System.Int32)", InvokeUserCode_SetPositionRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(DumpsterMonster), "System.Void DumpsterMonster::RunToSideRpc()", InvokeUserCode_RunToSideRpc);
	}
}
