using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class StunMine : NetworkBehaviour
{
	public Animator trapAnim;

	public MonsterCheckEvent monsterCheckScript;

	public bool caught;

	public GameObject cantPlaceRadius;

	public GameObject curCantPlaceRadius;

	public Transform radiusPos;

	public Interactable interactable;

	public SaveSnapshotObject saveSnapshotObject;

	public GameObject stunWave;

	public AudioSource beep;

	public void EnableRadius()
	{
		interactable.interactable = false;
		if ((bool)curCantPlaceRadius)
		{
			curCantPlaceRadius.SetActive(value: true);
		}
	}

	public void DisableRadius()
	{
		interactable.interactable = true;
		if ((bool)curCantPlaceRadius)
		{
			curCantPlaceRadius.SetActive(value: false);
		}
	}

	private void Start()
	{
		curCantPlaceRadius = Object.Instantiate(cantPlaceRadius, radiusPos.position, Quaternion.identity);
		curCantPlaceRadius.SetActive(value: false);
	}

	private void OnDisable()
	{
		Object.Destroy(curCantPlaceRadius);
	}

	public void Trap()
	{
		if (ClientPlayer.Instance.playerMan.isServer)
		{
			TrapRpc();
		}
		else
		{
			TrapCmd();
		}
		interactable.ChangeInteractableStatus(change: true);
	}

	[Command(requiresAuthority = false)]
	private void TrapCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StunMine::TrapCmd()", -963272401, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TrapRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StunMine::TrapRpc()", -668399076, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SpawnExplosion()
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(stunWave, base.transform.position, Quaternion.identity));
		}
		monsterCheckScript.CauseDistraction();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TrapCmd()
	{
		TrapRpc();
	}

	protected static void InvokeUserCode_TrapCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TrapCmd called on client.");
		}
		else
		{
			((StunMine)obj).UserCode_TrapCmd();
		}
	}

	protected void UserCode_TrapRpc()
	{
		Invoke("SpawnExplosion", 0.2f);
		beep.Play();
		trapAnim.SetTrigger("Catch");
		base.gameObject.SetActive(value: false);
		caught = true;
	}

	protected static void InvokeUserCode_TrapRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TrapRpc called on server.");
		}
		else
		{
			((StunMine)obj).UserCode_TrapRpc();
		}
	}

	static StunMine()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(StunMine), "System.Void StunMine::TrapCmd()", InvokeUserCode_TrapCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(StunMine), "System.Void StunMine::TrapRpc()", InvokeUserCode_TrapRpc);
	}
}
