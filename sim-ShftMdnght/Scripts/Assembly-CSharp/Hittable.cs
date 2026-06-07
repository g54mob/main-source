using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : NetworkBehaviour
{
	public bool isEntity;

	public float health;

	public float maxHealth;

	public UnityEvent deathEvent;

	public UnityEvent hitEvent;

	public GameObject deathObj;

	public GameObject hitObj;

	public bool killingCancelsTransaction;

	public StoreBrowseBehaviour browseScript;

	public DialogueInteractable dialogueScript;

	public Collider col;

	public GameObject[] fleshSpawns;

	public Transform[] fleshSpawnPoints;

	public Material headMaterial;

	public Material bodyMaterial;

	public AIPath path;

	public bool cancelSpawnNextNpc;

	public bool die;

	public Enemy enemy;

	public ChaseWhenNear chaseScript;

	public bool ChasePlayerAfterHit;

	public bool startHuntAfterHit;

	public GameObject gameDone;

	public bool dontTurnToPlayer;

	public bool dontDestroyOnDeath;

	public bool makeEventOccurAtXHealth;

	public float xHealth;

	public UnityEvent eventAtXHealth;

	public bool affectsTimeRemaining;

	public bool dontPunishForKilling;

	public bool returnMoneyIfKilledWhenLeaving;

	public bool returnMoneyIfKilledAnyway;

	public int moneyToReturn;

	public string returnMoneyString = "Money Returned";

	public bool ignoreRunAwayEvent;

	public bool invincibleToHits;

	public bool causeHitMarker = true;

	public bool alreadySaidShotDialogue;

	public bool onlyTriggerDamageAnimOnce;

	private bool triggeredDamageAnim;

	private bool triggeredDamageAnim_;

	public float damageBeforeReaction = 50f;

	public float explosionDamage;

	public float fleshVelAmount = 6f;

	public bool shootFleshInRandomDir;

	private void Start()
	{
		maxHealth = health;
		if (bodyMaterial != null)
		{
			bodyMaterial.SetFloat("_Cutoff", 0f);
			headMaterial.SetFloat("_Cutoff", 0f);
		}
	}

	private void OnEnable()
	{
		die = false;
		Invoke("HealFullHealth", 0.1f);
	}

	private void HealFullHealth()
	{
		health = maxHealth;
	}

	public virtual void Hit(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction = false)
	{
		if (base.isServer)
		{
			HitRpc(damage, hitFrom, alwaysTriggerDamageReaction);
		}
		else
		{
			HitCmd(damage, hitFrom, alwaysTriggerDamageReaction);
		}
	}

	[Command(requiresAuthority = false)]
	private void HitCmd(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damage);
		writer.WriteVector3(hitFrom);
		writer.WriteBool(alwaysTriggerDamageReaction);
		SendCommandInternal("System.Void Hittable::HitCmd(System.Single,UnityEngine.Vector3,System.Boolean)", 6563434, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void HitRpc(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damage);
		writer.WriteVector3(hitFrom);
		writer.WriteBool(alwaysTriggerDamageReaction);
		SendRPCInternal("System.Void Hittable::HitRpc(System.Single,UnityEngine.Vector3,System.Boolean)", 1399061213, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChangeHealth(float newHP)
	{
		if (base.isServer)
		{
			ChangeHealthRpc(newHP);
		}
		else
		{
			ChangeHealthCmd(newHP);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeHealthCmd(float newHP)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newHP);
		SendCommandInternal("System.Void Hittable::ChangeHealthCmd(System.Single)", -1761659671, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeHealthRpc(float newHP)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newHP);
		SendRPCInternal("System.Void Hittable::ChangeHealthRpc(System.Single)", 25534668, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnObj(string type)
	{
		if (base.isServer)
		{
			SpawnObjRpc(type);
		}
		else
		{
			SpawnObjCmd(type);
		}
	}

	[Command(requiresAuthority = false)]
	private void SpawnObjCmd(string type)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(type);
		SendCommandInternal("System.Void Hittable::SpawnObjCmd(System.String)", 1553769408, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SpawnObjRpc(string type)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(type);
		SendRPCInternal("System.Void Hittable::SpawnObjRpc(System.String)", 1355982557, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void GotARat()
	{
		if ((bool)RatCountdown.Instance)
		{
			RatCountdown.Instance.GotARat();
		}
	}

	public void Explosion(float explosionRadius)
	{
		ClientPlayer.Instance.playerMan.camShake.intensity = 0.2f;
		Hittable[] array = Object.FindObjectsOfType<Hittable>();
		foreach (Hittable hittable in array)
		{
			if (Vector3.Distance(hittable.transform.position, base.transform.position) < explosionRadius && hittable.isEntity)
			{
				hittable.Hit(explosionDamage, base.transform.position, alwaysTriggerDamageReaction: true);
			}
		}
	}

	public void Die()
	{
		if (!die)
		{
			die = true;
			if (base.isServer)
			{
				DieRpc();
			}
			else
			{
				DieCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void DieCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Hittable::DieCmd()", -813099006, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void DieRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Hittable::DieRpc()", -823077947, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Delete()
	{
		NetworkServer.Destroy(base.gameObject);
		Object.Destroy(base.gameObject, 1f);
	}

	private void DoHint()
	{
		StoreManager.Instance.AddHint("Remember to clean your messes.");
		StoreManager.Instance.AddHint("Mopping blood and throwing trash will increase your revenue.");
		StoreManager.Instance.NextHint();
	}

	private IEnumerator LerpAlphaClipping()
	{
		yield return null;
	}

	public void SpawnFlesh()
	{
		for (int i = 0; i < fleshSpawns.Length; i++)
		{
			Rigidbody component = Object.Instantiate(fleshSpawns[i], fleshSpawnPoints[i].position, fleshSpawnPoints[i].rotation).GetComponent<Rigidbody>();
			NetworkServer.Spawn(component.gameObject);
			if (shootFleshInRandomDir)
			{
				component.velocity = Random.onUnitSphere * Random.Range(fleshVelAmount - 6f, fleshVelAmount);
			}
			else
			{
				component.velocity = -component.transform.forward * Random.Range(fleshVelAmount - 6f, fleshVelAmount);
			}
		}
	}

	private void Update()
	{
		if (die)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 5f);
			if ((bool)browseScript)
			{
				browseScript.TriggerAnim(browseScript.deathAnim);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_HitCmd__Single__Vector3__Boolean(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction)
	{
		HitRpc(damage, hitFrom, alwaysTriggerDamageReaction);
	}

	protected static void InvokeUserCode_HitCmd__Single__Vector3__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command HitCmd called on client.");
		}
		else
		{
			((Hittable)obj).UserCode_HitCmd__Single__Vector3__Boolean(reader.ReadFloat(), reader.ReadVector3(), reader.ReadBool());
		}
	}

	protected void UserCode_HitRpc__Single__Vector3__Boolean(float damage, Vector3 hitFrom, bool alwaysTriggerDamageReaction)
	{
		if (invincibleToHits)
		{
			return;
		}
		if ((bool)chaseScript && !chaseScript.chasing)
		{
			chaseScript.StartChasing();
		}
		if ((bool)browseScript)
		{
			if (!onlyTriggerDamageAnimOnce)
			{
				triggeredDamageAnim = true;
				browseScript.TriggerAnim(browseScript.damageAnim);
				browseScript.CancelInvoke("RegularAnim");
				browseScript.Invoke("RegularAnim", 1f);
			}
			else if (!triggeredDamageAnim)
			{
				triggeredDamageAnim = true;
				browseScript.TriggerAnim(browseScript.damageAnim);
				browseScript.CancelInvoke("RegularAnim");
				browseScript.Invoke("RegularAnim", 1f);
			}
		}
		health -= damage;
		if (makeEventOccurAtXHealth && health <= xHealth)
		{
			eventAtXHealth.Invoke();
		}
		Vector3 forward = hitFrom - base.transform.position;
		forward.y = 0f;
		if (!dontTurnToPlayer && forward.sqrMagnitude > 0.01f)
		{
			Quaternion quaternion = Quaternion.LookRotation(forward);
			base.transform.rotation = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
		}
		if (health <= 0f && base.isServer)
		{
			Die();
		}
		if ((health <= maxHealth - damageBeforeReaction && !ignoreRunAwayEvent) || (alwaysTriggerDamageReaction && !ignoreRunAwayEvent))
		{
			if (killingCancelsTransaction)
			{
				killingCancelsTransaction = false;
				TransactionManager.Instance.CancelTransaction();
				TransactionManager.Instance.Invoke("CancelTransaction", 1f);
			}
			if (startHuntAfterHit)
			{
				TransactionManager.Instance.CancelTransaction();
				TransactionManager.Instance.Invoke("CancelTransaction", 1f);
				StoreManager.Instance.StartHazardLights();
				col.enabled = false;
				Object.Destroy(base.gameObject);
			}
			if ((bool)dialogueScript && !alreadySaidShotDialogue && health > 0f)
			{
				dialogueScript.faceNearestPlayer = false;
				alreadySaidShotDialogue = true;
				if (dialogueScript.isServer)
				{
					if ((bool)browseScript && !browseScript.inCar)
					{
						SpeakingManager.Instance.AddChatLogNode(SpeakingManager.Instance.GetDialogueText(dialogueScript.dialogueId, "Name", usesKeyIndex: false), SpeakingManager.Instance.GetDialogueText(dialogueScript.dialogueId, "Injured", usesKeyIndex: false), 0);
					}
					dialogueScript.ChangeInteractableStatusRpc(change: false);
				}
				else
				{
					dialogueScript.ChangeInteractableStatusCmd(change: false);
				}
			}
			if ((bool)browseScript)
			{
				if (ChasePlayerAfterHit)
				{
					if (!onlyTriggerDamageAnimOnce)
					{
						triggeredDamageAnim_ = true;
						browseScript.RunToPlayer();
					}
					else
					{
						if (!triggeredDamageAnim_)
						{
							triggeredDamageAnim_ = true;
							browseScript.RunToPlayer();
						}
						Object.Instantiate(browseScript.hitParticles, base.transform.position, Quaternion.identity);
					}
				}
				else if (!onlyTriggerDamageAnimOnce)
				{
					triggeredDamageAnim_ = true;
					browseScript.TookDamage();
				}
				else if (!triggeredDamageAnim_)
				{
					triggeredDamageAnim_ = true;
					browseScript.TookDamage();
				}
				browseScript.dialogueInteractable.faceNearestPlayer = false;
			}
		}
		hitEvent.Invoke();
		if (hitObj != null)
		{
			SpawnObj("hitObj");
		}
	}

	protected static void InvokeUserCode_HitRpc__Single__Vector3__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC HitRpc called on server.");
		}
		else
		{
			((Hittable)obj).UserCode_HitRpc__Single__Vector3__Boolean(reader.ReadFloat(), reader.ReadVector3(), reader.ReadBool());
		}
	}

	protected void UserCode_ChangeHealthCmd__Single(float newHP)
	{
		ChangeHealthRpc(newHP);
	}

	protected static void InvokeUserCode_ChangeHealthCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeHealthCmd called on client.");
		}
		else
		{
			((Hittable)obj).UserCode_ChangeHealthCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeHealthRpc__Single(float newHP)
	{
		health = newHP;
	}

	protected static void InvokeUserCode_ChangeHealthRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeHealthRpc called on server.");
		}
		else
		{
			((Hittable)obj).UserCode_ChangeHealthRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_SpawnObjCmd__String(string type)
	{
		SpawnObjRpc(type);
	}

	protected static void InvokeUserCode_SpawnObjCmd__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpawnObjCmd called on client.");
		}
		else
		{
			((Hittable)obj).UserCode_SpawnObjCmd__String(reader.ReadString());
		}
	}

	protected void UserCode_SpawnObjRpc__String(string type)
	{
		if (!(type == "hitObj"))
		{
			if (type == "deathObj")
			{
				Object.Instantiate(deathObj, base.transform.position, Quaternion.identity);
			}
		}
		else
		{
			Object.Instantiate(hitObj, base.transform.position, Quaternion.identity);
		}
	}

	protected static void InvokeUserCode_SpawnObjRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnObjRpc called on server.");
		}
		else
		{
			((Hittable)obj).UserCode_SpawnObjRpc__String(reader.ReadString());
		}
	}

	protected void UserCode_DieCmd()
	{
		DieRpc();
	}

	protected static void InvokeUserCode_DieCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DieCmd called on client.");
		}
		else
		{
			((Hittable)obj).UserCode_DieCmd();
		}
	}

	protected void UserCode_DieRpc()
	{
		die = true;
		deathEvent.Invoke();
		if (!cancelSpawnNextNpc && base.isServer)
		{
			cancelSpawnNextNpc = true;
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 3f);
		}
		if (PlayerPrefs.GetInt("KillHint__") != 1)
		{
			Invoke("DoHint", 1f);
			PlayerPrefs.SetInt("KillHint__", 1);
		}
		if ((bool)browseScript)
		{
			if (!browseScript.isDoppelganger)
			{
				if (base.isServer && !dontPunishForKilling)
				{
					StoreManager.Instance.ChangeRevenue("Human Killed", -15f);
				}
				if (base.isServer && returnMoneyIfKilledWhenLeaving && browseScript.leaving)
				{
					StoreManager.Instance.ChangeRevenue(returnMoneyString, moneyToReturn);
				}
				else if (base.isServer && returnMoneyIfKilledAnyway)
				{
					StoreManager.Instance.ChangeRevenue(returnMoneyString, moneyToReturn);
				}
			}
			browseScript.Die();
		}
		if ((bool)dialogueScript)
		{
			SpeakingManager.Instance.CancelAllDialogue();
			dialogueScript.ExitDialogue();
			dialogueScript.ExitDialogue();
			dialogueScript.ExitDialogue();
			dialogueScript.ExitDialogue();
			dialogueScript.ExitDialogue();
			dialogueScript.interactable = false;
			if (dialogueScript.isServer)
			{
				dialogueScript.ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				dialogueScript.ChangeInteractableStatusCmd(change: false);
			}
		}
		if (col != null)
		{
			col.enabled = false;
		}
		if (path != null)
		{
			path.enabled = false;
		}
		if (bodyMaterial != null)
		{
			StartCoroutine(LerpAlphaClipping());
		}
		if (base.isServer)
		{
			Invoke("SpawnFlesh", 0.01f);
			if ((bool)deathObj)
			{
				SpawnObj("deathObj");
			}
		}
		if (!dontDestroyOnDeath)
		{
			if (base.isServer)
			{
				Invoke("Delete", 0.3f);
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_DieRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC DieRpc called on server.");
		}
		else
		{
			((Hittable)obj).UserCode_DieRpc();
		}
	}

	static Hittable()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Hittable), "System.Void Hittable::HitCmd(System.Single,UnityEngine.Vector3,System.Boolean)", InvokeUserCode_HitCmd__Single__Vector3__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Hittable), "System.Void Hittable::ChangeHealthCmd(System.Single)", InvokeUserCode_ChangeHealthCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Hittable), "System.Void Hittable::SpawnObjCmd(System.String)", InvokeUserCode_SpawnObjCmd__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Hittable), "System.Void Hittable::DieCmd()", InvokeUserCode_DieCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Hittable), "System.Void Hittable::HitRpc(System.Single,UnityEngine.Vector3,System.Boolean)", InvokeUserCode_HitRpc__Single__Vector3__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(Hittable), "System.Void Hittable::ChangeHealthRpc(System.Single)", InvokeUserCode_ChangeHealthRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(Hittable), "System.Void Hittable::SpawnObjRpc(System.String)", InvokeUserCode_SpawnObjRpc__String);
		RemoteProcedureCalls.RegisterRpc(typeof(Hittable), "System.Void Hittable::DieRpc()", InvokeUserCode_DieRpc);
	}
}
