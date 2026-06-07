using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using UnityEngine;

public class Spider : Enemy
{
	public ScrollTexture scrollText;

	public bool primaryCreature;

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

	public Transform ventTarget;

	public Transform chaseTarget;

	public bool checkingVent;

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

	private bool justDetectedPlayer;

	public Animator spiderAnim;

	public List<PlayerManager> playerMans;

	public float[] detectionOfEachPlayer;

	private float timeChasingObject;

	public float timeChasingBeforeGivingUp;

	public bool alreadyCheckedVent;

	private bool justFoundVent;

	public bool annoyed;

	public GameObject annoyedSFXObject;

	public AudioSource leaveSFX;

	public Hittable hittable;

	private bool beingHit;

	public bool oneCreature;

	private ClientPlayer thisPlayer;

	public EnemyHolder enemyHolder;

	public bool fastPacing;

	public Material headMaterial;

	public Material bodyMaterial;

	public bool chasingPlayer;

	public PlayerManager chasingPlayerTarg;

	public float timeChasingPlayer;

	public bool shootingProj;

	public float timeShootingProj;

	public GameObject silkEgg;

	public GameObject silkProjectile;

	private bool alreadyLeft;

	private bool shotProj;

	private bool justCheckedVents;

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
		ChangeHittableHealthRpc(hittable.health + (float)(num * 500));
	}

	[ClientRpc]
	private void ChangeHittableHealthRpc(float health)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(health);
		SendRPCInternal("System.Void Spider::ChangeHittableHealthRpc(System.Single)", 46456633, writer, 0, includeOwner: true);
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
		bodyMaterial.SetFloat("_Cutoff", 0f);
		headMaterial.SetFloat("_Cutoff", 0f);
		playerMans = StoreManager.Instance.playerMans;
		Invoke("UpdatePlayerLists", 1f);
		checkingVent = false;
		chasingTarget = false;
		breakingBarricade = false;
		leaving = false;
		annoyed = false;
		annoyedSFXObject.SetActive(value: false);
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
		CancelInvoke("CheckIfNearVent");
		CancelInvoke("DetectPlayers");
		CancelInvoke("StartNextPathway");
	}

	public void CheckEnemiesLeft(float timeUntilCheck)
	{
		if (thisPlayer.isServer)
		{
			HuntManager.Instance.CancelInvoke("EnemyDied");
			HuntManager.Instance.Invoke("EnemyDied", timeUntilCheck);
		}
	}

	public override void Leave()
	{
		ChangeSilkEgg(on: false);
		shootingProj = false;
		hittable.health = 200000000f;
		if (!alreadyLeft)
		{
			alreadyLeft = true;
			if (ClientPlayer.Instance.isServer)
			{
				LeaveRpc();
			}
			else
			{
				LeaveCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void LeaveCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Spider::LeaveCmd()", 1386477823, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void LeaveRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Spider::LeaveRpc()", 174399916, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void FixedUpdate()
	{
		if (alreadyLeft)
		{
			for (int i = 0; i < scrollText.materials.Length; i++)
			{
				scrollText.materials[i].color = Color.Lerp(scrollText.materials[i].color, Color.black, Time.deltaTime * 50f);
			}
		}
		else
		{
			for (int j = 0; j < scrollText.materials.Length; j++)
			{
				scrollText.materials[j].color = Color.Lerp(scrollText.materials[j].color, new Color(1f, 0f, 0f, 1f - hittable.health / hittable.maxHealth), Time.deltaTime * 100f);
			}
		}
		if (leaving)
		{
			pathfinder.maxSpeed = runSpeed + 10f;
			Leaving();
		}
		else if (checkingVent)
		{
			justStartedPatrol = true;
			GoToCheckVent();
		}
		else if (breakingBarricade)
		{
			chasingPlayer = false;
			justStartedPatrol = true;
			GoToBreakBarricade();
		}
		else if (shootingProj)
		{
			ShootingProj();
		}
		else if (chasingPlayer)
		{
			shotProj = false;
			timeChasingPlayer -= Time.deltaTime;
			if (timeChasingPlayer < 0f)
			{
				timeChasingPlayer = 8f;
				timeShootingProj = 0.9f;
				shootingProj = true;
			}
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

	private void ChangeSilkEgg(bool on)
	{
		if (base.isServer)
		{
			ChangeSilkEggRpc(on);
		}
		else
		{
			ChangeSilkEggCmd(on);
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeSilkEggCmd(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendCommandInternal("System.Void Spider::ChangeSilkEggCmd(System.Boolean)", -2094275279, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeSilkEggRpc(bool on)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(on);
		SendRPCInternal("System.Void Spider::ChangeSilkEggRpc(System.Boolean)", -24681034, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ShootingProj()
	{
		if (!shotProj)
		{
			ChangeSilkEgg(on: true);
		}
		timeShootingProj -= Time.deltaTime;
		pathfinder.maxSpeed = 0f;
		Vector3 forward = chasingPlayerTarg.transform.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 7f);
		if (timeShootingProj < 0f && !shotProj)
		{
			shotProj = true;
			ShootProj();
		}
	}

	public void ShootProj()
	{
		ChangeSilkEgg(on: false);
		GameObject obj = Object.Instantiate(silkProjectile, silkEgg.transform.position, silkEgg.transform.rotation);
		NetworkServer.Spawn(obj);
		obj.GetComponent<Rigidbody>().velocity = silkEgg.transform.forward * 20f;
		obj.GetComponent<Rigidbody>().velocity += base.transform.up * 1.3f;
		timeChasingPlayer = 2.2f;
		Invoke("DoneShootingProj", 0.3f);
	}

	public void DoneShootingProj()
	{
		shootingProj = false;
		ChangeSilkEgg(on: false);
	}

	public void Leaving()
	{
		seeker.target = leaveLocation;
		if (Vector3.Distance(new Vector3(base.transform.position.x, 0f, base.transform.position.z), new Vector3(leaveLocation.position.x, 0f, leaveLocation.position.z)) < 5f)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void BecomeAnnoyed()
	{
		if (!annoyed)
		{
			AnnoyedRpc();
		}
	}

	[ClientRpc]
	private void AnnoyedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Spider::AnnoyedRpc()", 1082671123, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void AnnoyedHint()
	{
		StoreManager.Instance.AddHint("The Entity is irritated and will now SEARCH VENTS");
		StoreManager.Instance.NextHint();
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
		SendCommandInternal("System.Void Spider::ChaseNonPlayerTargetCmd(UnityEngine.Vector3)", 900750748, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChaseNonPlayerTargetRpc(Vector3 targPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(targPosition);
		SendRPCInternal("System.Void Spider::ChaseNonPlayerTargetRpc(UnityEngine.Vector3)", -1256688031, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CheckIfNearVent()
	{
		if (justCheckedVents)
		{
			return;
		}
		justCheckedVents = true;
		CancelInvoke("CheckVentCooldown");
		Invoke("CheckVentCooldown", 0.2f);
		bool flag = false;
		Transform[] allVents = huntMan.allVents;
		foreach (Transform transform in allVents)
		{
			if (Vector3.Distance(transform.position, base.transform.position) < 4f && !transform.GetComponent<Vent>().checkedRecently)
			{
				if (justFoundVent)
				{
					justFoundVent = false;
					alreadyStartedNextPathway = false;
				}
				checkingVent = true;
				flag = true;
				ventTarget = transform;
				seeker.target = ventTarget;
				return;
			}
		}
		if (!flag)
		{
			if (!alreadyStartedNextPathway)
			{
				StartNextPathway();
				alreadyStartedNextPathway = true;
			}
			justFoundVent = true;
			alreadyCheckedVent = false;
			checkingVent = false;
		}
	}

	private void CheckVentCooldown()
	{
		justCheckedVents = false;
	}

	private void GoToCheckVent()
	{
		seeker.target = ventTarget;
		pathfinder.maxSpeed = 0f;
		Vector3 forward = ventTarget.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		if (Quaternion.Angle(base.transform.rotation, b) > 5f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 2f * Time.deltaTime);
		}
		else if (!alreadyCheckedVent)
		{
			alreadyCheckedVent = true;
			spiderAnim.SetTrigger("Attack");
			attackAudio.Play();
			ventTarget.GetComponent<Vent>().Checked();
		}
	}

	public void Hit()
	{
		for (int i = 0; i < scrollText.materials.Length; i++)
		{
			scrollText.materials[0].color = new Color(1f, 0f, 0f, 1f);
		}
		if (!leaving)
		{
			beingHit = true;
			pathfinder.maxSpeed = 0f;
			CancelInvoke("FinishHit");
			Invoke("FinishHit", 0.1f);
		}
	}

	private void FinishHit()
	{
		beingHit = false;
		pathfinder.maxSpeed = runSpeed;
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
			spiderAnim.SetTrigger("Attack");
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
		if (canAttack && !chasingNonPlayerObject && playerScentTarget.GetComponent<PlayerManager>() != null)
		{
			spiderAnim.SetTrigger("Attack");
			attackAudio.Play();
			playerScentTarget.GetComponent<PlayerManager>().TakeDamage(25f, significantAnim: true);
			canAttack = false;
			Invoke("CanAttack", 1.3f);
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

	private void CanAttack()
	{
		canAttack = true;
	}

	private void GoToPatrol()
	{
		if (walkTarget == null)
		{
			StartNextPathway();
		}
		if (!(Vector3.Distance(base.transform.position, walkTarget.position) > 5f))
		{
			Vector3 forward = walkTarget.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			if (Quaternion.Angle(base.transform.rotation, b) > 5f)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 5f * Time.deltaTime);
			}
			else if (annoyed)
			{
				StartNextPathway();
			}
			else if (waitingAtPatrolTime > timeAtPatrol)
			{
				StartNextPathway();
			}
			else
			{
				waitingAtPatrolTime += Time.deltaTime;
			}
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
			float num2;
			if (playerMan.fpsScript.volume > playerMan.scent)
			{
				if (playerMan.insideVent)
				{
					playerMan.ChangeTimeDetected(-0.2f, num);
					continue;
				}
				num2 = playerMan.fpsScript.volume;
			}
			else
			{
				if (playerMan.insideVent)
				{
					playerMan.ChangeTimeDetected(-0.2f, num);
					continue;
				}
				num2 = playerMan.scent;
			}
			if (num2 > 0.93f)
			{
				playerMan.ChangeTimeDetected(0.2f, num);
			}
			else if (num2 > 0.8f && Vector3.Distance(playerMan.transform.position, base.transform.position) < 11.5f)
			{
				playerMan.ChangeTimeDetected(0.2f, num);
			}
			else if (num2 > 0.5f && Vector3.Distance(playerMan.transform.position, base.transform.position) < 8.5f)
			{
				playerMan.ChangeTimeDetected(0.2f, num);
			}
			else if (Vector3.Distance(playerMan.transform.position, base.transform.position) < 4f && !playerMan.insideVent)
			{
				playerMan.ChangeTimeDetected(0.2f, num);
			}
			else
			{
				playerMan.ChangeTimeDetected(-0.2f, num);
			}
			if (playerMan.timeDetected[num] >= 1.9f || playerMan.timeSpentOutside >= 1.9f)
			{
				playerMan.CallAlertedCreature();
				flag = true;
				list.Add(playerMan.transform);
			}
		}
		Transform transform2 = null;
		float num3 = float.PositiveInfinity;
		foreach (Transform item in list)
		{
			float num4 = Vector3.Distance(item.position, base.transform.position);
			if (transform2 == null || num3 > num4)
			{
				num3 = num4;
				playerScentTarget = item.transform;
				transform2 = item;
			}
		}
		transform = transform2;
		if (transform2 != null && flag && !breakingBarricade)
		{
			if (justDetectedPlayer)
			{
				timeChasingObject = 0f;
				timeChasingPlayer = 0.7f;
				chasingPlayer = false;
				justDetectedPlayer = false;
				PlayRoarRpc();
			}
			if (num3 > 4f)
			{
				chasingPlayerTarg = transform2.GetComponent<PlayerManager>();
				chasingPlayer = true;
			}
			else
			{
				timeChasingPlayer = 0.7f;
				chasingPlayer = false;
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
			timeChasingPlayer = 0.7f;
			chasingPlayer = false;
		}
		else
		{
			timeChasingPlayer = 0.7f;
			chasingPlayer = false;
		}
	}

	[ClientRpc]
	private void PlayRoarRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Spider::PlayRoarRpc()", 1674275481, writer, 0, includeOwner: true);
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
			((Spider)obj).UserCode_ChangeHittableHealthRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_LeaveCmd()
	{
		LeaveRpc();
	}

	protected static void InvokeUserCode_LeaveCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command LeaveCmd called on client.");
		}
		else
		{
			((Spider)obj).UserCode_LeaveCmd();
		}
	}

	protected void UserCode_LeaveRpc()
	{
		Barricade[] array = Object.FindObjectsOfType<Barricade>(includeInactive: true);
		foreach (Barricade barricade in array)
		{
			if (barricade.hittable.gameObject.activeInHierarchy)
			{
				barricade.hittable.Die();
			}
		}
		ChangeSilkEgg(on: false);
		shootingProj = false;
		hittable.health = 200000000f;
		leaveSFX.Play();
		leaving = true;
		pathfinder.maxSpeed = runSpeed + 10f;
	}

	protected static void InvokeUserCode_LeaveRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC LeaveRpc called on server.");
		}
		else
		{
			((Spider)obj).UserCode_LeaveRpc();
		}
	}

	protected void UserCode_ChangeSilkEggCmd__Boolean(bool on)
	{
		ChangeSilkEggRpc(on);
	}

	protected static void InvokeUserCode_ChangeSilkEggCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeSilkEggCmd called on client.");
		}
		else
		{
			((Spider)obj).UserCode_ChangeSilkEggCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_ChangeSilkEggRpc__Boolean(bool on)
	{
		silkEgg.SetActive(on);
	}

	protected static void InvokeUserCode_ChangeSilkEggRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeSilkEggRpc called on server.");
		}
		else
		{
			((Spider)obj).UserCode_ChangeSilkEggRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_AnnoyedRpc()
	{
		InvokeRepeating("CheckIfNearVent", 0f, 0.25f);
		annoyed = true;
		annoyedSFXObject.SetActive(value: true);
		Invoke("AnnoyedHint", 2f);
		curSpeed = annoyedSpeed;
	}

	protected static void InvokeUserCode_AnnoyedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AnnoyedRpc called on server.");
		}
		else
		{
			((Spider)obj).UserCode_AnnoyedRpc();
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
			((Spider)obj).UserCode_ChaseNonPlayerTargetCmd__Vector3(reader.ReadVector3());
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
			((Spider)obj).UserCode_ChaseNonPlayerTargetRpc__Vector3(reader.ReadVector3());
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
			((Spider)obj).UserCode_PlayRoarRpc();
		}
	}

	static Spider()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Spider), "System.Void Spider::LeaveCmd()", InvokeUserCode_LeaveCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Spider), "System.Void Spider::ChangeSilkEggCmd(System.Boolean)", InvokeUserCode_ChangeSilkEggCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Spider), "System.Void Spider::ChaseNonPlayerTargetCmd(UnityEngine.Vector3)", InvokeUserCode_ChaseNonPlayerTargetCmd__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::ChangeHittableHealthRpc(System.Single)", InvokeUserCode_ChangeHittableHealthRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::LeaveRpc()", InvokeUserCode_LeaveRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::ChangeSilkEggRpc(System.Boolean)", InvokeUserCode_ChangeSilkEggRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::AnnoyedRpc()", InvokeUserCode_AnnoyedRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::ChaseNonPlayerTargetRpc(UnityEngine.Vector3)", InvokeUserCode_ChaseNonPlayerTargetRpc__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(Spider), "System.Void Spider::PlayRoarRpc()", InvokeUserCode_PlayRoarRpc);
	}
}
