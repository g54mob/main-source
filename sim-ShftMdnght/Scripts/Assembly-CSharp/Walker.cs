using System.Collections.Generic;
using Mirror;
using Pathfinding;
using UnityEngine;

public class Walker : Enemy
{
	public Transform spiderSpawn;

	public Transform[] patrolAreas;

	public HuntManager huntMan;

	public AIDestinationSetter seeker;

	public AIPath pathfinder;

	public float normalSpeed;

	public float runSpeed = 7f;

	public float timeAtPatrol;

	private float curSpeed;

	public Transform walkTarget;

	public Transform barricadeTarget;

	public Transform scentTarget;

	public Transform playerScentTarget;

	public Transform ventTarget;

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

	public Animator anim;

	public List<PlayerManager> playerMans;

	public float[] detectionOfEachPlayer;

	public bool annoyed;

	public GameObject annoyedSFXObject;

	public new Transform leaveLocation;

	public new bool leaving;

	public AudioSource leaveSFX;

	public Hittable hittable;

	public EnemyHolder enemyHolder;

	private void Start()
	{
		huntMan = HuntManager.Instance;
	}

	private void OnEnable()
	{
		annoyed = false;
		base.transform.position = spiderSpawn.position;
		InvokeRepeating("CheckIfNearBarricade", 0f, 0.2f);
		InvokeRepeating("DetectPlayers", 0f, 0.2f);
		playerMans = StoreManager.Instance.playerMans;
		foreach (PlayerManager playerMan in playerMans)
		{
			if (playerMan != null)
			{
				playerMan.AddToEnemiesList(enemyHolder.GetComponent<NetworkIdentity>());
			}
		}
		StartNextPathway();
		curSpeed = normalSpeed;
		anim.SetTrigger("Slow Walking");
		pathfinder.maxSpeed = curSpeed;
	}

	private void OnDisable()
	{
		CancelInvoke("TryLayEgg");
		CancelInvoke("FinishLayingEgg");
		CancelInvoke("CheckIfNearBarricade");
		CancelInvoke("DetectPlayers");
		CancelInvoke("StartNextPathway");
	}

	public override void Leave()
	{
		hittable.health = 10000f;
		leaveSFX.Play();
		leaving = true;
		pathfinder.maxSpeed = runSpeed;
		anim.SetTrigger("Standard Run");
	}

	private void FixedUpdate()
	{
		if (leaving)
		{
			Leaving();
			return;
		}
		if (breakingBarricade)
		{
			justStartedPatrol = true;
			GoToBreakBarricade();
			return;
		}
		if (chasingTarget)
		{
			justStartedPatrol = true;
			GoToTarget();
			return;
		}
		if (justStartedPatrol)
		{
			Invoke("StartNextPathway", Random.Range(1, 6));
			justStartedPatrol = false;
		}
		GoToPatrol();
	}

	public void Leaving()
	{
		seeker.target = leaveLocation;
		if (Vector3.Distance(new Vector3(base.transform.position.x, 0f, base.transform.position.z), new Vector3(leaveLocation.position.x, 0f, leaveLocation.position.z)) < 5f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public new void ChaseNonPlayerTarget(Vector3 targPosition)
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

	public void Hit()
	{
		anim.SetTrigger("Take Damage");
		pathfinder.maxSpeed = 0f;
		CancelInvoke("FinishHit");
		Invoke("FinishHit", 0.6f);
	}

	private void FinishHit()
	{
		pathfinder.maxSpeed = runSpeed;
		anim.SetTrigger("Standard Run");
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
			anim.SetTrigger("Zombie Attack");
			attackAudio.Play();
			barricadeTarget.GetComponent<Hittable>().Hit(10f, base.transform.position);
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
			pathfinder.maxSpeed = curSpeed;
			anim.SetTrigger("Slow Walking");
			if (num > 5f)
			{
				return;
			}
		}
		else
		{
			pathfinder.maxSpeed = runSpeed;
			anim.SetTrigger("Standard Run");
			if (num > 2f)
			{
				return;
			}
		}
		if (canAttack && !chasingNonPlayerObject && playerScentTarget.GetComponent<PlayerManager>() != null)
		{
			anim.SetTrigger("Zombie Attack");
			attackAudio.Play();
			playerScentTarget.GetComponent<PlayerManager>().TakeDamage(1f, significantAnim: false);
			canAttack = false;
			Invoke("CanAttack", 1.1f);
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

	public void Death()
	{
		foreach (PlayerManager playerMan in playerMans)
		{
			int index = playerMan.enemiesList.IndexOf(base.gameObject);
			playerMan.ChangeTimeDetected(-2f, index);
		}
	}

	private void CanAttack()
	{
		canAttack = true;
	}

	private void GoToPatrol()
	{
		anim.SetTrigger("Slow Walking");
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
		List<Transform> list = new List<Transform>();
		bool flag = false;
		Transform transform = null;
		foreach (PlayerManager playerMan in playerMans)
		{
			int num = playerMan.enemiesList.IndexOf(base.gameObject);
			if (playerMan.insideVent)
			{
				playerMan.timeDetected[num] -= 0.2f;
				continue;
			}
			float volume = playerMan.fpsScript.volume;
			if (volume > 0.95f)
			{
				playerMan.timeDetected[num] += 0.2f;
			}
			else if (volume > 0.8f && Vector3.Distance(playerMan.transform.position, base.transform.position) < 9f)
			{
				playerMan.timeDetected[num] += 0.2f;
			}
			else if (volume > 0.5f && Vector3.Distance(playerMan.transform.position, base.transform.position) < 7f)
			{
				playerMan.timeDetected[num] += 0.2f;
			}
			else if (Vector3.Distance(playerMan.transform.position, base.transform.position) < 3f)
			{
				playerMan.timeDetected[num] += 0.2f;
			}
			else
			{
				playerMan.timeDetected[num] -= 0.2f;
			}
			if (playerMan.timeDetected[num] < 0f)
			{
				playerMan.timeDetected[num] = 0f;
			}
			if (playerMan.timeDetected[num] >= 2f || playerMan.timeSpentOutside == 2f)
			{
				playerMan.timeDetected[num] = 2f;
				playerMan.alertedTheCreatureWarning.SetTrigger("Alert");
				flag = true;
				list.Add(playerMan.transform);
			}
		}
		Transform transform2 = null;
		foreach (Transform item in list)
		{
			if (transform2 == null || Vector3.Distance(transform2.position, base.transform.position) > Vector3.Distance(item.position, base.transform.position))
			{
				playerScentTarget = item.transform;
				transform2 = item;
			}
		}
		transform = transform2;
		if (transform2 != null && flag && !breakingBarricade)
		{
			if (justDetectedPlayer)
			{
				justDetectedPlayer = false;
				roarAudio.Play();
			}
			chasingTarget = true;
			scentTarget.position = transform.position;
			seeker.target = scentTarget;
			pathfinder.maxSpeed = runSpeed;
			anim.SetTrigger("Standard Run");
		}
		else if (!chasingNonPlayerObject)
		{
			justDetectedPlayer = true;
			chasingTarget = false;
		}
	}

	public new void CheckIfNearBarricade()
	{
		bool flag = false;
		GameObject[] allBarricades = huntMan.allBarricades;
		foreach (GameObject gameObject in allBarricades)
		{
			if (gameObject.activeInHierarchy && Vector3.Distance(gameObject.transform.position, base.transform.position) < 2f)
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
		waitingAtPatrolTime = 0f;
		pathfinder.maxSpeed = curSpeed;
		anim.SetTrigger("Slow Walking");
		int num = Random.Range(0, patrolAreas.Length - 1);
		walkTarget = patrolAreas[num];
		seeker.target = walkTarget;
	}

	public override bool Weaved()
	{
		return true;
	}
}
