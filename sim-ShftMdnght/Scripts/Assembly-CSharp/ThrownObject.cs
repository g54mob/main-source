using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class ThrownObject : NetworkBehaviour
{
	public GameObject gfx;

	public GameObject breakParticles;

	public Rigidbody rb;

	public MonsterCheckEvent monsterCheckEvent;

	public float damage = 5f;

	public float damageWhenHitPlayer = 30f;

	public bool dealDamageToPlayer;

	public bool alreadyHitSomething;

	public bool makesPlayerStuck;

	public bool spawnsExtraObjectOnHit;

	public GameObject extraObjectToSpawnOnHit;

	public GameObject canHitPlayersCollider;

	public bool dontDestroyOnHit;

	public PlayerManager playerManThrowing;

	private bool alreadyDecidedWhetherToEnablePlayerHitCollider;

	public bool significantDamageAnim;

	public UnityEvent initialHitSomethingEvent;

	public bool onlyDamageOnce = true;

	public bool hitSomething;

	private void Update()
	{
		if (hitSomething && damage > 0f)
		{
			damage -= Time.deltaTime * 3f;
			damageWhenHitPlayer -= Time.deltaTime * 2f;
		}
		if (!alreadyDecidedWhetherToEnablePlayerHitCollider && (bool)playerManThrowing)
		{
			if (playerManThrowing != ClientPlayer.Instance.playerMan && (bool)canHitPlayersCollider)
			{
				canHitPlayersCollider.SetActive(value: true);
			}
			alreadyDecidedWhetherToEnablePlayerHitCollider = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (alreadyHitSomething && onlyDamageOnce)
		{
			return;
		}
		hitSomething = true;
		if (alreadyHitSomething)
		{
			damage -= 10f;
			damageWhenHitPlayer -= 10f;
			if (damage <= 0f)
			{
				return;
			}
			if (damageWhenHitPlayer <= 0f)
			{
				dealDamageToPlayer = false;
			}
		}
		else
		{
			initialHitSomethingEvent.Invoke();
		}
		if (collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Hittable") || collision.gameObject.CompareTag("Head"))
		{
			if ((bool)playerManThrowing && playerManThrowing != ClientPlayer.Instance.playerMan)
			{
				return;
			}
			collision.gameObject.GetComponentInParent<Hittable>().Hit(damage, base.transform.position);
		}
		if (collision.gameObject.CompareTag("Player") && dealDamageToPlayer)
		{
			if (collision.gameObject.GetComponent<PlayerManager>() != ClientPlayer.Instance.playerMan)
			{
				return;
			}
			if (makesPlayerStuck)
			{
				collision.gameObject.GetComponent<PlayerManager>().GetStuck(5f);
			}
			else
			{
				collision.gameObject.GetComponent<PlayerManager>().TakeDamage(damageWhenHitPlayer, significantDamageAnim);
			}
		}
		if (spawnsExtraObjectOnHit && !alreadyHitSomething)
		{
			if (!base.isServer)
			{
				return;
			}
			ContactPoint contactPoint = collision.contacts[0];
			NetworkServer.Spawn(Object.Instantiate(extraObjectToSpawnOnHit, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)));
		}
		alreadyHitSomething = true;
		if (base.isServer)
		{
			ThrowCompleteRpc();
		}
		else
		{
			ThrowCompleteCmd();
		}
	}

	[Command(requiresAuthority = false)]
	public void ThrowCompleteCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ThrownObject::ThrowCompleteCmd()", -478977325, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ThrowCompleteRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ThrownObject::ThrowCompleteRpc()", 534859712, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void MolotovHit()
	{
		for (int i = 0; i < 13; i++)
		{
			if (base.isServer)
			{
				StoreManager.Instance.ServerThrowObject(0, base.transform.position, Random.rotation, Random.onUnitSphere, base.gameObject, 5f);
			}
			else
			{
				StoreManager.Instance.NetworkThrowObject(0, base.transform.position, Random.rotation, Random.onUnitSphere, base.gameObject, 5f);
			}
		}
	}

	public void SetPlayerManThrowing(GameObject playerObj)
	{
		StartCoroutine(WaitForSpawnAndSet(playerObj));
	}

	private IEnumerator WaitForSpawnAndSet(GameObject playerObj)
	{
		while (!base.isServer && !base.isClient)
		{
			yield return null;
		}
		while (!base.isServer && !NetworkClient.spawned.ContainsValue(GetComponent<NetworkIdentity>()))
		{
			yield return null;
		}
		while (base.netId == 0)
		{
			yield return null;
		}
		if (ClientPlayer.Instance.isServer)
		{
			SetPlayerManThrowingRpc(playerObj);
		}
		else
		{
			SetPlayerManThrowingCmd(playerObj);
		}
	}

	[Command(requiresAuthority = false)]
	public void SetPlayerManThrowingCmd(GameObject playerObj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(playerObj);
		SendCommandInternal("System.Void ThrownObject::SetPlayerManThrowingCmd(UnityEngine.GameObject)", -464401217, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetPlayerManThrowingRpc(GameObject playerObj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(playerObj);
		SendRPCInternal("System.Void ThrownObject::SetPlayerManThrowingRpc(UnityEngine.GameObject)", -1908908496, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ThrowCompleteCmd()
	{
		ThrowCompleteRpc();
	}

	protected static void InvokeUserCode_ThrowCompleteCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ThrowCompleteCmd called on client.");
		}
		else
		{
			((ThrownObject)obj).UserCode_ThrowCompleteCmd();
		}
	}

	protected void UserCode_ThrowCompleteRpc()
	{
		if ((bool)monsterCheckEvent)
		{
			monsterCheckEvent.CauseDistraction();
		}
		if (!dontDestroyOnHit)
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			Object.Destroy(rb);
			gfx.SetActive(value: false);
		}
		if ((bool)breakParticles)
		{
			breakParticles.SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_ThrowCompleteRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ThrowCompleteRpc called on server.");
		}
		else
		{
			((ThrownObject)obj).UserCode_ThrowCompleteRpc();
		}
	}

	protected void UserCode_SetPlayerManThrowingCmd__GameObject(GameObject playerObj)
	{
		if (base.isServer)
		{
			if (!base.isServer || base.netId == 0)
			{
				Debug.LogWarning("[" + base.name + "] Tried to SetPlayerManThrowingCmd before spawn.");
			}
			else
			{
				SetPlayerManThrowingRpc(playerObj);
			}
		}
	}

	protected static void InvokeUserCode_SetPlayerManThrowingCmd__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetPlayerManThrowingCmd called on client.");
		}
		else
		{
			((ThrownObject)obj).UserCode_SetPlayerManThrowingCmd__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_SetPlayerManThrowingRpc__GameObject(GameObject playerObj)
	{
		if (playerObj == null)
		{
			Debug.LogWarning("PlayerObj null in SetPlayerManThrowingRpc");
			return;
		}
		playerManThrowing = playerObj.GetComponent<PlayerManager>();
		if (playerManThrowing != null)
		{
			Debug.Log("Set the guy to be " + playerManThrowing.name);
		}
		else
		{
			Debug.LogWarning("PlayerManager not found on object!");
		}
	}

	protected static void InvokeUserCode_SetPlayerManThrowingRpc__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetPlayerManThrowingRpc called on server.");
		}
		else
		{
			((ThrownObject)obj).UserCode_SetPlayerManThrowingRpc__GameObject(reader.ReadGameObject());
		}
	}

	static ThrownObject()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ThrownObject), "System.Void ThrownObject::ThrowCompleteCmd()", InvokeUserCode_ThrowCompleteCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ThrownObject), "System.Void ThrownObject::SetPlayerManThrowingCmd(UnityEngine.GameObject)", InvokeUserCode_SetPlayerManThrowingCmd__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ThrownObject), "System.Void ThrownObject::ThrowCompleteRpc()", InvokeUserCode_ThrowCompleteRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ThrownObject), "System.Void ThrownObject::SetPlayerManThrowingRpc(UnityEngine.GameObject)", InvokeUserCode_SetPlayerManThrowingRpc__GameObject);
	}
}
