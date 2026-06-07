using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class StoreBrowseBehaviour : NetworkBehaviour
{
	public string killedIDString;

	public bool isDoppelganger;

	public bool inCar;

	public MaterialFader[] matFaders;

	public Transform target;

	public float speed;

	public AIDestinationSetter seeker;

	public AIPath pathfinder;

	public Hittable hittable;

	public bool useShelfGoals;

	public int[] goals;

	public List<int> generatedGoals;

	public int index;

	public bool overrideDefaultTransactionItems;

	public int[] transactionItems;

	public Animator anim;

	public string idleAnim;

	public string walkAnim;

	public string grabAnim;

	public string runAnim;

	public string damageAnim;

	public string deathAnim;

	public string curAnim;

	public Transform playerLookTarget;

	public Transform head;

	public string idDatabaseName;

	public bool canNeverInteract;

	public DialogueInteractable dialogueInteractable;

	public bool takenDamage;

	public GameObject dropBloodParticles;

	public GameObject hitParticles;

	public float runSpeed = 3f;

	public UnityEvent transactionCompleteEvent;

	public bool hasTransactionCompleteEvent;

	public bool forceTalkAtVeryStart;

	public bool addToReport;

	public bool leaving;

	[SyncVar]
	public bool wanderAroundAimlessly;

	public float timeStoppedWhileWandering;

	public bool isThief;

	public bool hasStolenItems = true;

	public bool doesntGiveBackItems;

	private PlayerManager targPlayerMan;

	public int damageToPlayer = 40;

	private bool attacking;

	public Coroutine exitCoroutine;

	private bool chasingPlayer;

	private bool startedFadingAway;

	private bool hasGivenFine;

	private bool hasTransacted;

	public bool NetworkwanderAroundAimlessly
	{
		get
		{
			return wanderAroundAimlessly;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref wanderAroundAimlessly, 1uL, null);
		}
	}

	private void OnEnable()
	{
		Invoke("DelayedStart", 0.1f);
		generatedGoals.Add(Random.Range(2, 22));
		if (ReviewsManager.Instance.hygieneBar.value < 0.61f)
		{
			generatedGoals.Add(Random.Range(2, 22));
		}
		if (ReviewsManager.Instance.hygieneBar.value < 0.31f)
		{
			generatedGoals.Add(Random.Range(2, 22));
		}
	}

	private void DelayedStart()
	{
		if (!base.isServer)
		{
			base.enabled = false;
			return;
		}
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = speed;
		}
		RpcTrigger(walkAnim);
		if (forceTalkAtVeryStart)
		{
			target = ClientPlayer.Instance.transform;
			seeker.target = target;
			StartCoroutine(GoToPlayerForcedTalk());
		}
		else
		{
			seeker.target = target;
			StartNextPathway();
		}
	}

	private IEnumerator GoToPlayerForcedTalk()
	{
		if (takenDamage)
		{
			StopCoroutine(GoToPlayerForcedTalk());
			yield break;
		}
		while (Vector3.Distance(base.transform.position, target.position) > 1.5f)
		{
			yield return null;
		}
		if (hittable.die)
		{
			StopCoroutine(GoToPlayerForcedTalk());
			yield break;
		}
		if (!takenDamage)
		{
			if (base.isServer)
			{
				RpcTrigger(walkAnim);
			}
			else
			{
				CmdTrigger(walkAnim);
			}
		}
		curAnim = idleAnim;
		dialogueInteractable.ForceTalkToPlayer();
		yield return new WaitForSeconds(0.1f);
		Invoke("IdleAnim", 0.9f);
	}

	public void FinishedStartForceTalk()
	{
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = speed;
		}
		if (base.isServer)
		{
			RpcTrigger(walkAnim);
		}
		else
		{
			CmdTrigger(walkAnim);
		}
		seeker.target = target;
		StartNextPathway();
	}

	public void ChangeHasStolenItems(bool change)
	{
		if (base.isServer)
		{
			ChangeHasStolenItemsRpc(change);
		}
		else
		{
			ChangeHasStolenItemsCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeHasStolenItemsCmd(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendCommandInternal("System.Void StoreBrowseBehaviour::ChangeHasStolenItemsCmd(System.Boolean)", 1186323091, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void ChangeHasStolenItemsRpc(bool change)
	{
		hasStolenItems = change;
	}

	private void FixedUpdate()
	{
		if (chasingPlayer)
		{
			Vector3 vector = target.position - base.transform.position;
			vector.y = 0f;
			if (vector.sqrMagnitude < 4f && !attacking)
			{
				Attack();
			}
		}
	}

	private void Attack()
	{
		anim.SetTrigger("Zombie Attack");
		attacking = true;
		Invoke("FinishAttack", 1f);
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = 2f;
		}
		if ((bool)target.GetComponent<PlayerManager>())
		{
			targPlayerMan = target.GetComponent<PlayerManager>();
			Invoke("DealDamageToPlayer", 0.23f);
		}
	}

	private void DealDamageToPlayer()
	{
		targPlayerMan.TakeDamage(damageToPlayer, significantAnim: true);
	}

	private void FinishAttack()
	{
		attacking = false;
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = runSpeed;
		}
		anim.SetTrigger("Standard Run");
	}

	private void StartNextPathway()
	{
		if (takenDamage)
		{
			return;
		}
		if (!takenDamage)
		{
			if (base.isServer)
			{
				RpcTrigger(walkAnim);
			}
			else
			{
				CmdTrigger(walkAnim);
			}
			curAnim = walkAnim;
		}
		bool flag = false;
		if ((!useShelfGoals) ? (index == generatedGoals.Count) : (index == goals.Length))
		{
			if (wanderAroundAimlessly)
			{
				target = StoreManager.Instance.aimlessPatrolPoints[Random.Range(0, StoreManager.Instance.aimlessPatrolPoints.Length)];
				seeker.target = target;
				StartCoroutine(GoToNextShelf());
			}
			else if (isThief)
			{
				target = StoreTravelPoints.Instance.exitPoint;
				seeker.target = target;
				ChangeHasStolenItems(change: true);
				if (!canNeverInteract)
				{
					if (base.isServer)
					{
						dialogueInteractable.ChangeInteractableStatusRpc(change: true);
					}
					else
					{
						dialogueInteractable.ChangeInteractableStatusCmd(change: true);
					}
				}
				if (exitCoroutine != null)
				{
					StopCoroutine(exitCoroutine);
				}
				exitCoroutine = StartCoroutine(GoToExit());
			}
			else
			{
				target = StoreTravelPoints.Instance.checkoutPoint;
				seeker.target = target;
				StartCoroutine(GoToRegister());
			}
		}
		else if (wanderAroundAimlessly)
		{
			target = StoreManager.Instance.aimlessPatrolPoints[Random.Range(0, StoreManager.Instance.aimlessPatrolPoints.Length)];
			seeker.target = target;
			StartCoroutine(GoToNextShelf());
		}
		else
		{
			if (useShelfGoals)
			{
				target = StoreTravelPoints.Instance.targPoints[goals[index]];
			}
			else
			{
				target = StoreTravelPoints.Instance.targPoints[generatedGoals[index]];
			}
			seeker.target = target;
			index++;
			StartCoroutine(GoToNextShelf());
		}
	}

	public void FinishTransaction()
	{
		if (hasTransactionCompleteEvent)
		{
			transactionCompleteEvent.Invoke();
		}
		target = StoreTravelPoints.Instance.exitPoint;
		seeker.target = target;
		if (exitCoroutine != null)
		{
			StopCoroutine(exitCoroutine);
		}
		exitCoroutine = StartCoroutine(GoToExit());
	}

	public void TookDamage()
	{
		if ((bool)dropBloodParticles)
		{
			dropBloodParticles.SetActive(value: true);
		}
		target = StoreTravelPoints.Instance.exitPoint;
		if ((bool)seeker)
		{
			seeker.target = target;
		}
		if ((bool)hitParticles)
		{
			Object.Instantiate(hitParticles, base.transform.position, Quaternion.identity);
		}
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = 0f;
		}
		takenDamage = true;
		Invoke("StartRunning", 0.5f);
		if ((bool)dialogueInteractable)
		{
			dialogueInteractable.faceNearestPlayerAfterTalking = false;
			dialogueInteractable.faceNearestPlayer = false;
		}
	}

	public void RunToPlayer()
	{
		CancelInvoke("StartNextPathway");
		StopCoroutine(GoToRegister());
		StopCoroutine(GoToNextShelf());
		InvokeRepeating("FindNearestPlayer", 0f, 2f);
		if ((bool)dropBloodParticles)
		{
			dropBloodParticles.SetActive(value: true);
		}
		chasingPlayer = true;
		seeker.target = target;
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = 0f;
		}
		takenDamage = true;
		Invoke("StartRunning", 0.5f);
	}

	private void FindNearestPlayer()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject gameObject = null;
		float num = float.PositiveInfinity;
		Vector3 position = base.transform.position;
		GameObject[] array2 = array;
		foreach (GameObject gameObject2 in array2)
		{
			if (!gameObject2.GetComponent<PlayerManager>().dead && !gameObject2.GetComponent<PlayerManager>().downed)
			{
				float num2 = Vector3.Distance(position, gameObject2.transform.position);
				if (num2 < num)
				{
					num = num2;
					gameObject = gameObject2;
				}
			}
		}
		if ((bool)gameObject)
		{
			target = gameObject.transform;
			seeker.target = target;
		}
	}

	private void StartRunning()
	{
		speed = runSpeed;
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = runSpeed;
		}
		if (base.isServer)
		{
			RpcTrigger(runAnim);
		}
		else
		{
			CmdTrigger(runAnim);
		}
		if (!chasingPlayer)
		{
			if (exitCoroutine != null)
			{
				StopCoroutine(exitCoroutine);
			}
			exitCoroutine = StartCoroutine(GoToExit());
		}
	}

	private IEnumerator GoToNextShelf()
	{
		while (Vector3.Distance(base.transform.position, target.position) > 1.8f)
		{
			yield return null;
		}
		if (hittable.die)
		{
			yield break;
		}
		if (!takenDamage)
		{
			if (base.isServer)
			{
				RpcTrigger(idleAnim);
			}
			else
			{
				CmdTrigger(idleAnim);
			}
		}
		curAnim = idleAnim;
		if (wanderAroundAimlessly)
		{
			curAnim = idleAnim;
			RegularAnim();
			Invoke("StartNextPathway", timeStoppedWhileWandering);
			yield break;
		}
		Vector3 forward = target.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		while (Quaternion.Angle(base.transform.rotation, b) > 1f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 5f * Time.deltaTime);
			yield return null;
			forward = target.position - base.transform.position;
			forward.y = 0f;
			b = Quaternion.LookRotation(forward);
		}
		float num = Random.Range(1.5f, 3f);
		if (num > 1f)
		{
			yield return new WaitForSeconds(num - 1f);
			if (hittable.die)
			{
				StopCoroutine(GoToNextShelf());
				yield break;
			}
			if (!takenDamage)
			{
				if (base.isServer)
				{
					RpcTrigger(grabAnim);
				}
				else
				{
					CmdTrigger(grabAnim);
				}
			}
			yield return new WaitForSeconds(1f);
		}
		else
		{
			yield return new WaitForSeconds(num);
		}
		if (hittable.die)
		{
			StopCoroutine(GoToNextShelf());
			yield break;
		}
		if (useShelfGoals)
		{
			Shelves.Instance.restockShelves[goals[index - 1]].shelfMan.RemoveRandomItems(Random.Range(1, 6));
		}
		else
		{
			Shelves.Instance.restockShelves[generatedGoals[index - 1]].shelfMan.RemoveRandomItems(Random.Range(1, 6));
		}
		StartNextPathway();
	}

	private IEnumerator GoToRegister()
	{
		if (wanderAroundAimlessly)
		{
			StartNextPathway();
		}
		else
		{
			if (takenDamage)
			{
				yield break;
			}
			while (Vector3.Distance(base.transform.position, target.position) > 1.5f)
			{
				yield return null;
			}
			if (hittable.die)
			{
				StopCoroutine(GoToRegister());
				yield break;
			}
			if (!takenDamage)
			{
				if (base.isServer)
				{
					RpcTrigger(idleAnim);
				}
				else
				{
					CmdTrigger(idleAnim);
				}
			}
			Vector3 forward = target.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			while (Quaternion.Angle(base.transform.rotation, b) > 10f)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 15f * Time.deltaTime);
				yield return null;
				forward = target.position - base.transform.position;
				forward.y = 0f;
				b = Quaternion.LookRotation(forward);
			}
			if (hittable.die)
			{
				StopCoroutine(GoToRegister());
				yield break;
			}
			if (!takenDamage)
			{
				if (base.isServer)
				{
					RpcTrigger(grabAnim);
				}
				else
				{
					CmdTrigger(grabAnim);
				}
			}
			yield return new WaitForSeconds(0.1f);
			hasTransacted = true;
			if (overrideDefaultTransactionItems)
			{
				TransactionManager.Instance.StartTransaction(idDatabaseName, new List<int>(transactionItems), this);
				if (transactionItems.Length == 0)
				{
					TransactionManager.Instance.registerScript.canCompleteTransaction = true;
				}
			}
			else
			{
				int num = Mathf.RoundToInt(ReviewsManager.Instance.overallRating * 3f);
				if (ReviewsManager.Instance.decorPoints > 100f)
				{
					num++;
				}
				if (ReviewsManager.Instance.decorPoints > 200f)
				{
					num++;
				}
				if (Random.Range(0, 10) < 3)
				{
					num++;
				}
				if (num <= 0)
				{
					num = 1;
				}
				List<int> list = new List<int>();
				for (int i = 0; i < num; i++)
				{
					list.Add(Random.Range(0, 14));
				}
				TransactionManager.Instance.StartTransaction(idDatabaseName, list, this);
			}
			Invoke("IdleAnim", 0.9f);
		}
	}

	private void IdleAnim()
	{
		if (!takenDamage)
		{
			if (base.isServer)
			{
				RpcTrigger(idleAnim);
			}
			else
			{
				CmdTrigger(idleAnim);
			}
			curAnim = idleAnim;
		}
	}

	public void TriggerAnim(string triggerName)
	{
		if (base.isServer)
		{
			RpcTrigger(triggerName);
		}
		else
		{
			CmdTrigger(triggerName);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdTrigger(string triggerName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(triggerName);
		SendCommandInternal("System.Void StoreBrowseBehaviour::CmdTrigger(System.String)", 2074020669, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcTrigger(string triggerName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(triggerName);
		SendRPCInternal("System.Void StoreBrowseBehaviour::RpcTrigger(System.String)", -944624398, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void TurnOffInteractable()
	{
		if ((bool)dialogueInteractable)
		{
			if (base.isServer)
			{
				dialogueInteractable.ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				dialogueInteractable.ChangeInteractableStatusCmd(change: false);
			}
		}
	}

	private IEnumerator GoToExit()
	{
		if (!isThief)
		{
			TurnOffInteractable();
		}
		leaving = true;
		if (hittable.die)
		{
			StopCoroutine(GoToExit());
			if (exitCoroutine != null)
			{
				StopCoroutine(exitCoroutine);
			}
			yield break;
		}
		if (!takenDamage)
		{
			curAnim = walkAnim;
			hittable.cancelSpawnNextNpc = true;
			if (base.isServer)
			{
				RpcTrigger(walkAnim);
			}
			else
			{
				CmdTrigger(walkAnim);
			}
		}
		while (Vector3.Distance(base.transform.position, target.position) > 4f)
		{
			curAnim = walkAnim;
			if (!isThief)
			{
				TurnOffInteractable();
			}
			yield return null;
		}
		if (!isThief)
		{
			TurnOffInteractable();
		}
		if (takenDamage)
		{
			TransactionManager.Instance.CancelTransaction();
			TransactionManager.Instance.Invoke("CancelTransaction", 0.5f);
			TransactionManager.Instance.Invoke("CancelTransaction", 1f);
			TransactionManager.Instance.Invoke("CancelTransaction", 3f);
		}
		if (!startedFadingAway)
		{
			MaterialFader[] array = matFaders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PlayFadeOut(1f);
			}
			startedFadingAway = true;
		}
		yield return new WaitForSeconds(1f);
		if (!isThief)
		{
			TurnOffInteractable();
		}
		if (!hittable.cancelSpawnNextNpc)
		{
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 3f);
		}
		if (base.isServer && isThief && hasStolenItems && !hasGivenFine)
		{
			hasGivenFine = true;
		}
		Object.Destroy(base.gameObject);
	}

	public void BreakFrontDoorBarricade()
	{
		StoreManager.Instance.DestroyFrontBarricade();
	}

	public void RegularAnim()
	{
		if (!takenDamage)
		{
			if (base.isServer)
			{
				RpcTrigger(curAnim);
			}
			else
			{
				CmdTrigger(curAnim);
			}
		}
	}

	public void Die()
	{
		if (!startedFadingAway)
		{
			MaterialFader[] array = matFaders;
			foreach (MaterialFader materialFader in array)
			{
				if ((bool)materialFader)
				{
					materialFader.PlayFadeOut(0.2f);
				}
			}
			startedFadingAway = true;
		}
		if (killedIDString != "" && !isDoppelganger)
		{
			SaveManager.Instance.npcsKilledTemp.Add(killedIDString);
		}
		if (addToReport)
		{
			EODReportValues.Instance.npcKilledID.Add(int.Parse(dialogueInteractable.dialogueId));
		}
		if (isThief && hasStolenItems)
		{
			StoreManager.Instance.Invoke("ThiefCaught", 1f);
		}
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = 0f;
		}
	}

	public void ChangeSpeed(float newSpeed)
	{
		if (base.isServer)
		{
			ChangeSpeedRpc(newSpeed);
		}
		else
		{
			ChangeSpeedCmd(newSpeed);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeSpeedCmd(float newSpeed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newSpeed);
		SendCommandInternal("System.Void StoreBrowseBehaviour::ChangeSpeedCmd(System.Single)", 762033013, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeSpeedRpc(float newSpeed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newSpeed);
		SendRPCInternal("System.Void StoreBrowseBehaviour::ChangeSpeedRpc(System.Single)", 1988240552, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void RevertToCurSpeed()
	{
		if ((bool)pathfinder)
		{
			if (base.isServer)
			{
				RevertToCurSpeedRpc();
			}
			else
			{
				RevertToCurSpeedCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void RevertToCurSpeedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void StoreBrowseBehaviour::RevertToCurSpeedCmd()", 329811707, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RevertToCurSpeedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StoreBrowseBehaviour::RevertToCurSpeedRpc()", -321009608, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EntryDoor"))
		{
			other.gameObject.GetComponent<EntryDoor>().Enter();
		}
		else if (isThief && other.CompareTag("SecurityScanner") && hasStolenItems)
		{
			other.gameObject.GetComponent<Interactable>().Interact(ClientPlayer.Instance.playerMan);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeHasStolenItemsCmd__Boolean(bool change)
	{
		ChangeHasStolenItemsRpc(change);
	}

	protected static void InvokeUserCode_ChangeHasStolenItemsCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeHasStolenItemsCmd called on client.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_ChangeHasStolenItemsCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdTrigger__String(string triggerName)
	{
		RpcTrigger(triggerName);
	}

	protected static void InvokeUserCode_CmdTrigger__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTrigger called on client.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_CmdTrigger__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcTrigger__String(string triggerName)
	{
		if ((bool)anim)
		{
			anim.SetTrigger(triggerName);
		}
	}

	protected static void InvokeUserCode_RpcTrigger__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTrigger called on server.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_RpcTrigger__String(reader.ReadString());
		}
	}

	protected void UserCode_ChangeSpeedCmd__Single(float newSpeed)
	{
		ChangeSpeedRpc(newSpeed);
	}

	protected static void InvokeUserCode_ChangeSpeedCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeSpeedCmd called on client.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_ChangeSpeedCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeSpeedRpc__Single(float newSpeed)
	{
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = newSpeed;
		}
	}

	protected static void InvokeUserCode_ChangeSpeedRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeSpeedRpc called on server.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_ChangeSpeedRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_RevertToCurSpeedCmd()
	{
		RevertToCurSpeedRpc();
	}

	protected static void InvokeUserCode_RevertToCurSpeedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RevertToCurSpeedCmd called on client.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_RevertToCurSpeedCmd();
		}
	}

	protected void UserCode_RevertToCurSpeedRpc()
	{
		if ((bool)pathfinder)
		{
			pathfinder.maxSpeed = speed;
		}
	}

	protected static void InvokeUserCode_RevertToCurSpeedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RevertToCurSpeedRpc called on server.");
		}
		else
		{
			((StoreBrowseBehaviour)obj).UserCode_RevertToCurSpeedRpc();
		}
	}

	static StoreBrowseBehaviour()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::ChangeHasStolenItemsCmd(System.Boolean)", InvokeUserCode_ChangeHasStolenItemsCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::CmdTrigger(System.String)", InvokeUserCode_CmdTrigger__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::ChangeSpeedCmd(System.Single)", InvokeUserCode_ChangeSpeedCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::RevertToCurSpeedCmd()", InvokeUserCode_RevertToCurSpeedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::RpcTrigger(System.String)", InvokeUserCode_RpcTrigger__String);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::ChangeSpeedRpc(System.Single)", InvokeUserCode_ChangeSpeedRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(StoreBrowseBehaviour), "System.Void StoreBrowseBehaviour::RevertToCurSpeedRpc()", InvokeUserCode_RevertToCurSpeedRpc);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(wanderAroundAimlessly);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(wanderAroundAimlessly);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref wanderAroundAimlessly, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref wanderAroundAimlessly, null, reader.ReadBool());
		}
	}
}
