using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using UnityEngine;

public class BabyDoll : Enemy
{
	public Transform spiderSpawn;

	public Transform[] patrolAreas;

	public HuntManager huntMan;

	public AIDestinationSetter seeker;

	public AIPath pathfinder;

	public float normalSpeed;

	public float runSpeed = 7f;

	public float annoyedSpeed;

	public float rampageSpeed;

	public float timeAtPatrol;

	private float curSpeed;

	public Transform walkTarget;

	public Transform barricadeTarget;

	public Transform scentTarget;

	public Transform playerScentTarget;

	public Transform chaseTarget;

	public bool chasingTarget;

	public bool breakingBarricade;

	private bool justAttackedBarricade;

	private float attackBarricadeCooldown;

	private float waitingAtPatrolTime;

	private bool alreadyStartedNextPathway;

	private bool justStartedPatrol;

	private bool canAttack = true;

	public bool chasingNonPlayerObject;

	public AudioSource attackAudio;

	public AudioSource roarAudio;

	public AudioSource interestedAudio;

	public AudioSource jumpAudio;

	private bool justDetectedPlayer;

	public Animator dollAnim;

	public List<PlayerManager> playerMans;

	public float[] detectionOfEachPlayer;

	private float timeChasingObject;

	public float timeChasingBeforeGivingUp;

	public Hittable hittable;

	private bool beingHit;

	public bool oneCreature;

	private ClientPlayer thisPlayer;

	public EnemyHolder enemyHolder;

	public bool fastPacing;

	public bool chasingPlayer;

	public PlayerManager chasingPlayerTarg;

	public bool jumpingAtPlayer;

	private bool justStartedTelegraph;

	private bool actuallyJumping;

	private float timeJumping;

	private bool dealtDamage;

	private bool shotProj;

	public LayerMask jumpObstacles;

	public Collider collider;

	public Rigidbody rb;

	public Transform lookAtPlayer;

	public GameObject disappearParticle;

	public Transform lookAtTransform;

	private int detectsBeforeLookForJumpPoint;

	private bool fastPacingButDontChasePlayer;

	private void Start()
	{
		thisPlayer = ClientPlayer.Instance;
		huntMan = HuntManager.Instance;
		if (!base.isServer)
		{
			return;
		}
		int num = 0;
		foreach (PlayerManager playerMan in StoreManager.Instance.playerMans)
		{
			if ((bool)playerMan)
			{
				num++;
			}
		}
		ChangeHittableHealthRpc(hittable.health + (float)(num * 90));
	}

	[ClientRpc]
	private void ChangeHittableHealthRpc(float health)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(health);
		SendRPCInternal("System.Void BabyDoll::ChangeHittableHealthRpc(System.Single)", 1600506581, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void UpdatePlayerLists()
	{
		foreach (PlayerManager playerMan in playerMans)
		{
			if (playerMan != null)
			{
				playerMan.AddToEnemiesList(enemyHolder.GetComponent<NetworkIdentity>());
			}
		}
	}

	private void OnEnable()
	{
		playerMans = StoreManager.Instance.playerMans;
		Invoke("UpdatePlayerLists", 1f);
		chasingTarget = false;
		breakingBarricade = false;
		CancelInvoke("CheckIfNearBarricade");
		CancelInvoke("DetectPlayers");
		InvokeRepeating("CheckIfNearBarricade", 2f, 0.2f);
		InvokeRepeating("DetectPlayers", 2f, 0.2f);
		StartNextPathway();
		curSpeed = normalSpeed;
		if (!beingHit)
		{
			pathfinder.maxSpeed = curSpeed;
		}
	}

	private void OnDisable()
	{
		if (!thisPlayer.isServer)
		{
			return;
		}
		foreach (PlayerManager playerMan in playerMans)
		{
			if (playerMan != null)
			{
				playerMan.ChangeTimeDetected(-10f, playerMan.enemiesList.IndexOf(base.gameObject));
			}
		}
		CancelInvoke("CheckIfNearBarricade");
		CancelInvoke("DetectPlayers");
		CancelInvoke("StartNextPathway");
	}

	public void CheckEnemiesLeft(float timeUntilCheck)
	{
		if (thisPlayer.isServer)
		{
			ChangePlayerLookAtState(chasingPlayerTarg, lookAt: false);
			HuntManager.Instance.CancelInvoke("EnemyDied");
			HuntManager.Instance.Invoke("EnemyDied", timeUntilCheck);
		}
	}

	private void FixedUpdate()
	{
		if (breakingBarricade)
		{
			chasingPlayer = false;
			justStartedPatrol = true;
			GoToBreakBarricade();
		}
		else if (jumpingAtPlayer)
		{
			pathfinder.maxSpeed = 0f;
			if (chasingPlayerTarg == null)
			{
				return;
			}
			Vector3 forward = chasingPlayerTarg.transform.position - base.transform.position;
			forward.y = 0f;
			if (forward.sqrMagnitude == 0f)
			{
				return;
			}
			base.transform.rotation = Quaternion.LookRotation(forward);
			if (justStartedTelegraph)
			{
				if (base.isServer)
				{
					PlayRoarRpc();
					ChangePlayerLookAtState(chasingPlayerTarg, lookAt: true);
				}
				dollAnim.SetBool("Crawling", value: false);
				Invoke("JumpAtPlayer", 0.5f);
				justStartedTelegraph = false;
				timeJumping = 0f;
			}
			if (actuallyJumping)
			{
				if (!dealtDamage && base.isServer && Vector3.Distance(chasingPlayerTarg.transform.position, base.transform.position) < 0.72f)
				{
					chasingPlayerTarg.TakeDamage(15f, significantAnim: true);
					dealtDamage = true;
				}
				rb.velocity += Vector3.up * Physics.gravity.y * 3f * Time.fixedDeltaTime;
				timeJumping += Time.deltaTime;
				if (timeJumping > 0.6f)
				{
					actuallyJumping = false;
					dollAnim.SetBool("Crawling", value: true);
					dollAnim.SetBool("MidAir", value: false);
					collider.enabled = false;
					rb.isKinematic = true;
					rb.useGravity = false;
					pathfinder.enabled = true;
					TPToRandomPatrolPoint();
					jumpingAtPlayer = false;
				}
			}
		}
		else if (chasingPlayer)
		{
			pathfinder.gravity = new Vector3(float.NaN, float.NaN, float.NaN);
		}
		else if (chasingTarget)
		{
			justStartedPatrol = true;
			GoToTarget();
		}
		else
		{
			if (justStartedPatrol)
			{
				Invoke("StartNextPathway", Random.Range(1, 6));
				justStartedPatrol = false;
			}
			GoToPatrol();
		}
	}

	public void TPToRandomPatrolPoint()
	{
		SpawnDisappearParticleRpc(base.transform.position);
		foreach (PlayerManager playerMan in playerMans)
		{
			int index = playerMan.enemiesList.IndexOf(base.gameObject);
			playerMan.ChangeTimeDetected(-5f, index);
		}
		pathfinder.maxSpeed = normalSpeed;
		if (!chasingPlayerTarg)
		{
			return;
		}
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < patrolAreas.Length; i++)
		{
			float num3 = Vector3.Distance(patrolAreas[i].position, chasingPlayerTarg.transform.position);
			if (num3 > num)
			{
				num2 = i;
				num = num3;
			}
		}
		base.transform.position = patrolAreas[num2].position;
		SpawnDisappearParticleRpc(base.transform.position);
	}

	[ClientRpc]
	private void SpawnDisappearParticleRpc(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendRPCInternal("System.Void BabyDoll::SpawnDisappearParticleRpc(UnityEngine.Vector3)", 814667450, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangePlayerLookAtState(PlayerManager playerMan, bool lookAt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		writer.WriteBool(lookAt);
		SendRPCInternal("System.Void BabyDoll::ChangePlayerLookAtState(PlayerManager,System.Boolean)", -905167395, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void JumpAtPlayer()
	{
		if ((bool)chasingPlayerTarg && (bool)rb)
		{
			if (base.isServer)
			{
				ChangePlayerLookAtState(chasingPlayerTarg, lookAt: false);
			}
			jumpAudio.Play();
			dealtDamage = false;
			dollAnim.SetBool("MidAir", value: true);
			collider.enabled = true;
			pathfinder.enabled = false;
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			Vector3 position = rb.position;
			Vector3 vector = chasingPlayerTarg.transform.position - position;
			vector.y = 0f;
			if (!(vector.sqrMagnitude < 0.0001f))
			{
				vector.Normalize();
				Vector3 velocity = vector * 20f + Vector3.up * 11f;
				rb.velocity = velocity;
				actuallyJumping = true;
			}
		}
	}

	public override void ChaseNonPlayerTarget(Vector3 targPosition)
	{
		if (base.isServer)
		{
			ChaseNonPlayerTargetRpc(targPosition);
		}
		else
		{
			ChaseNonPlayerTargetCmd(targPosition);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChaseNonPlayerTargetCmd(Vector3 targPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(targPosition);
		SendCommandInternal("System.Void BabyDoll::ChaseNonPlayerTargetCmd(UnityEngine.Vector3)", -76608096, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChaseNonPlayerTargetRpc(Vector3 targPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(targPosition);
		SendRPCInternal("System.Void BabyDoll::ChaseNonPlayerTargetRpc(UnityEngine.Vector3)", 1559011253, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Hit()
	{
	}

	private void GoToBreakBarricade()
	{
		pathfinder.maxSpeed = 0f;
		Vector3 forward = barricadeTarget.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		if (Quaternion.Angle(base.transform.rotation, b) > 5f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 5f * Time.deltaTime);
		}
		else if (attackBarricadeCooldown > 0.5f)
		{
			attackAudio.Play();
			barricadeTarget.GetComponent<Hittable>().Hit(30f, base.transform.position);
			attackBarricadeCooldown = 0f;
		}
		else
		{
			attackBarricadeCooldown += Time.deltaTime;
		}
	}

	private void GoToTarget()
	{
		seeker.target = scentTarget;
		float num = Vector3.Distance(new Vector3(base.transform.position.x, 0f, base.transform.position.z), new Vector3(scentTarget.position.x, 0f, scentTarget.position.z));
		if (chasingNonPlayerObject)
		{
			if (!beingHit)
			{
				pathfinder.maxSpeed = curSpeed;
			}
			if (num > 5f)
			{
				return;
			}
		}
		else
		{
			if (!beingHit)
			{
				pathfinder.maxSpeed = runSpeed;
			}
			if (num > 2f)
			{
				return;
			}
		}
		Vector3 forward = scentTarget.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		if (Quaternion.Angle(base.transform.rotation, b) > 5f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 5f * Time.deltaTime);
			return;
		}
		chasingTarget = false;
		chasingNonPlayerObject = false;
	}

	private void GoToPatrol()
	{
		if (walkTarget == null)
		{
			StartNextPathway();
		}
		if (!(Vector3.Distance(base.transform.position, walkTarget.position) > 5f))
		{
			StartNextPathway();
		}
	}

	private void CompleteHunt()
	{
		CancelInvoke("CheckIfNearBarricade");
		CancelInvoke("StartNextPathway");
	}

	private void DetectPlayers()
	{
		if (!base.isServer)
		{
			return;
		}
		List<Transform> list = new List<Transform>();
		bool flag = false;
		Transform transform = null;
		foreach (PlayerManager playerMan in playerMans)
		{
			int num = playerMan.enemiesList.IndexOf(base.gameObject);
			if (playerMan.downed || playerMan.dead)
			{
				playerMan.ChangeTimeDetected(-0.2f, num);
				continue;
			}
			if (playerMan.insideVent)
			{
				playerMan.ChangeTimeDetected(-0.2f, num);
				continue;
			}
			Vector3 normalized = (playerMan.transform.position - base.transform.position).normalized;
			float maxDistance = Vector3.Distance(base.transform.position, playerMan.transform.position);
			if (Physics.Raycast(base.transform.position, normalized, maxDistance, jumpObstacles))
			{
				playerMan.ChangeTimeDetected(-0.2f, num);
			}
			else if (Vector3.Distance(playerMan.transform.position, base.transform.position) < 15f)
			{
				playerMan.ChangeTimeDetected(0.3f, num);
			}
			if (playerMan.timeDetected[num] >= 1.9f || playerMan.timeSpentOutside >= 1.9f)
			{
				playerMan.CallAlertedCreature();
				flag = true;
				list.Add(playerMan.transform);
			}
		}
		Transform transform2 = null;
		float num2 = float.PositiveInfinity;
		foreach (Transform item in list)
		{
			float num3 = Vector3.Distance(item.position, base.transform.position);
			if (transform2 == null || num2 > num3)
			{
				num2 = num3;
				playerScentTarget = item.transform;
				transform2 = item;
				chasingPlayer = true;
				if (!jumpingAtPlayer && Vector3.Distance(item.position, base.transform.position) < 7f)
				{
					chasingPlayerTarg = transform2.GetComponent<PlayerManager>();
					justStartedTelegraph = true;
					jumpingAtPlayer = true;
					detectsBeforeLookForJumpPoint = 5;
				}
			}
		}
		transform = transform2;
		if (transform2 != null && flag && !breakingBarricade)
		{
			if (justDetectedPlayer)
			{
				timeChasingObject = 0f;
				chasingPlayer = false;
				justDetectedPlayer = false;
			}
			chasingTarget = true;
			scentTarget.position = transform.position;
			seeker.target = scentTarget;
			if (!beingHit)
			{
				pathfinder.maxSpeed = runSpeed;
			}
		}
		else if (!chasingNonPlayerObject)
		{
			justDetectedPlayer = true;
			chasingTarget = false;
			chasingPlayer = false;
		}
		else
		{
			chasingPlayer = false;
		}
	}

	[ClientRpc]
	private void PlayRoarRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BabyDoll::PlayRoarRpc()", -1723751843, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override void CheckIfNearBarricade()
	{
		bool flag = false;
		GameObject[] allBarricades = huntMan.allBarricades;
		foreach (GameObject gameObject in allBarricades)
		{
			if (gameObject.activeInHierarchy && Vector3.Distance(gameObject.transform.position, base.transform.position) < 4f)
			{
				alreadyStartedNextPathway = false;
				breakingBarricade = true;
				flag = true;
				barricadeTarget = gameObject.transform;
				seeker.target = barricadeTarget;
				justAttackedBarricade = true;
				return;
			}
		}
		if (!flag)
		{
			breakingBarricade = false;
			justAttackedBarricade = false;
			if (!alreadyStartedNextPathway)
			{
				StartNextPathway();
				alreadyStartedNextPathway = true;
			}
			breakingBarricade = false;
		}
	}

	private void StartNextPathway()
	{
		if (!ClientPlayer.Instance.isServer)
		{
			return;
		}
		if (!fastPacing)
		{
			waitingAtPatrolTime = 0f;
			if (!beingHit)
			{
				pathfinder.maxSpeed = curSpeed;
			}
			int num = Random.Range(0, patrolAreas.Length - 1);
			walkTarget = patrolAreas[num];
			seeker.target = walkTarget;
			return;
		}
		if (fastPacingButDontChasePlayer)
		{
			waitingAtPatrolTime = 0f;
			if (!beingHit)
			{
				pathfinder.maxSpeed = curSpeed;
			}
			List<PlayerManager> list = StoreManager.Instance.playerMans;
			int index = Random.Range(0, list.Count);
			Transform transform = null;
			float num2 = float.PositiveInfinity;
			Transform[] array = patrolAreas;
			foreach (Transform transform2 in array)
			{
				float num3 = Vector3.Distance(list[index].transform.position, transform2.position);
				if (num3 < num2)
				{
					num2 = num3;
					transform = transform2;
				}
			}
			walkTarget = transform;
			seeker.target = walkTarget;
		}
		else
		{
			waitingAtPatrolTime = 0f;
			if (!beingHit)
			{
				pathfinder.maxSpeed = curSpeed;
			}
			int num4 = Random.Range(0, patrolAreas.Length - 1);
			walkTarget = patrolAreas[num4];
			seeker.target = walkTarget;
		}
		fastPacingButDontChasePlayer = !fastPacingButDontChasePlayer;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeHittableHealthRpc__Single(float health)
	{
		hittable.maxHealth = health;
		hittable.health = health;
	}

	protected static void InvokeUserCode_ChangeHittableHealthRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeHittableHealthRpc called on server.");
		}
		else
		{
			((BabyDoll)obj).UserCode_ChangeHittableHealthRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_SpawnDisappearParticleRpc__Vector3(Vector3 pos)
	{
		Object.Instantiate(disappearParticle, pos, Quaternion.identity);
	}

	protected static void InvokeUserCode_SpawnDisappearParticleRpc__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnDisappearParticleRpc called on server.");
		}
		else
		{
			((BabyDoll)obj).UserCode_SpawnDisappearParticleRpc__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_ChangePlayerLookAtState__PlayerManager__Boolean(PlayerManager playerMan, bool lookAt)
	{
		if (lookAt)
		{
			playerMan.fpsScript.objectToLookAt = lookAtTransform;
			playerMan.fpsScript.lookAtSpeed = 5f;
			playerMan.fpsScript.lookAtState = true;
		}
		else
		{
			playerMan.fpsScript.lookAtState = false;
			playerMan.fpsScript.lookAtSpeed = 1f;
		}
	}

	protected static void InvokeUserCode_ChangePlayerLookAtState__PlayerManager__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangePlayerLookAtState called on server.");
		}
		else
		{
			((BabyDoll)obj).UserCode_ChangePlayerLookAtState__PlayerManager__Boolean(reader.ReadNetworkBehaviour<PlayerManager>(), reader.ReadBool());
		}
	}

	protected void UserCode_ChaseNonPlayerTargetCmd__Vector3(Vector3 targPosition)
	{
		ChaseNonPlayerTargetRpc(targPosition);
	}

	protected static void InvokeUserCode_ChaseNonPlayerTargetCmd__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChaseNonPlayerTargetCmd called on client.");
		}
		else
		{
			((BabyDoll)obj).UserCode_ChaseNonPlayerTargetCmd__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_ChaseNonPlayerTargetRpc__Vector3(Vector3 targPosition)
	{
		if (chasingTarget)
		{
			if (Vector3.Distance(scentTarget.position, base.transform.position) > Vector3.Distance(targPosition, base.transform.position))
			{
				justDetectedPlayer = true;
				interestedAudio.Play();
				chasingNonPlayerObject = true;
				scentTarget.position = targPosition;
				seeker.target = scentTarget;
			}
		}
		else
		{
			justDetectedPlayer = true;
			interestedAudio.Play();
			chasingTarget = true;
			chasingNonPlayerObject = true;
			scentTarget.position = targPosition;
			seeker.target = scentTarget;
		}
	}

	protected static void InvokeUserCode_ChaseNonPlayerTargetRpc__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChaseNonPlayerTargetRpc called on server.");
		}
		else
		{
			((BabyDoll)obj).UserCode_ChaseNonPlayerTargetRpc__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_PlayRoarRpc()
	{
		roarAudio.Play();
	}

	protected static void InvokeUserCode_PlayRoarRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PlayRoarRpc called on server.");
		}
		else
		{
			((BabyDoll)obj).UserCode_PlayRoarRpc();
		}
	}

	static BabyDoll()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BabyDoll), "System.Void BabyDoll::ChaseNonPlayerTargetCmd(UnityEngine.Vector3)", InvokeUserCode_ChaseNonPlayerTargetCmd__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(BabyDoll), "System.Void BabyDoll::ChangeHittableHealthRpc(System.Single)", InvokeUserCode_ChangeHittableHealthRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(BabyDoll), "System.Void BabyDoll::SpawnDisappearParticleRpc(UnityEngine.Vector3)", InvokeUserCode_SpawnDisappearParticleRpc__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(BabyDoll), "System.Void BabyDoll::ChangePlayerLookAtState(PlayerManager,System.Boolean)", InvokeUserCode_ChangePlayerLookAtState__PlayerManager__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(BabyDoll), "System.Void BabyDoll::ChaseNonPlayerTargetRpc(UnityEngine.Vector3)", InvokeUserCode_ChaseNonPlayerTargetRpc__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(BabyDoll), "System.Void BabyDoll::PlayRoarRpc()", InvokeUserCode_PlayRoarRpc);
	}
}
