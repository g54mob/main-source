using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class EntryDoor : NetworkBehaviour
{
	public AudioSource sfx;

	public Animator anim;

	private bool doNoise = true;

	public Transform monsterCheckPosition;

	public bool canEnter;

	private bool causesMonstersToCheck = true;

	[Command(requiresAuthority = false)]
	public void Enter()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void EntryDoor::Enter()", -1048029479, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ActuallyEnter()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EntryDoor::ActuallyEnter()", -512642078, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void MonstersCanCheck()
	{
		causesMonstersToCheck = true;
	}

	private float GetXZDistance(Transform a, Transform b)
	{
		Vector3 position = a.position;
		Vector3 position2 = b.position;
		position.y = 0f;
		position2.y = 0f;
		return Vector3.Distance(position, position2);
	}

	public void AllowEnter()
	{
		canEnter = true;
	}

	private void DoNoise()
	{
		doNoise = true;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_Enter()
	{
		ActuallyEnter();
	}

	protected static void InvokeUserCode_Enter(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command Enter called on client.");
		}
		else
		{
			((EntryDoor)obj).UserCode_Enter();
		}
	}

	protected void UserCode_ActuallyEnter()
	{
		if (!canEnter)
		{
			return;
		}
		anim.SetTrigger("Open");
		if ((bool)HuntManager.Instance && StoreManager.Instance.inHunt && causesMonstersToCheck)
		{
			foreach (Enemy allEnemy in HuntManager.Instance.allEnemies)
			{
				if (GetXZDistance(allEnemy.transform, monsterCheckPosition) < 13f)
				{
					allEnemy.ChaseNonPlayerTarget(monsterCheckPosition.position);
				}
			}
			causesMonstersToCheck = false;
			Invoke("MonstersCanCheck", 15f);
		}
		if (doNoise)
		{
			sfx.Play();
		}
		doNoise = false;
		CancelInvoke("DoNoise");
		Invoke("DoNoise", 3f);
	}

	protected static void InvokeUserCode_ActuallyEnter(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyEnter called on server.");
		}
		else
		{
			((EntryDoor)obj).UserCode_ActuallyEnter();
		}
	}

	static EntryDoor()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EntryDoor), "System.Void EntryDoor::Enter()", InvokeUserCode_Enter, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(EntryDoor), "System.Void EntryDoor::ActuallyEnter()", InvokeUserCode_ActuallyEnter);
	}
}
