using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using UnityEngine;

public class WeepingAngel : Enemy
{
	public Transform spiderSpawn;

	public Animator anim;

	public HuntManager huntMan;

	public AIDestinationSetter seeker;

	public AIPath pathfinder;

	public float normalSpeed = 10f;

	private float curSpeed = 10f;

	public Transform barricadeTarget;

	public Transform chaseTarget;

	public bool chasingTarget;

	public bool breakingBarricade;

	private bool justAttackedBarricade;

	private float attackBarricadeCooldown;

	private bool canAttack = true;

	public AudioSource attackAudio;

	public List<PlayerManager> playerMans;

	public float[] detectionOfEachPlayer;

	public Hittable hittable;

	private bool beingHit;

	private ClientPlayer thisPlayer;

	public EnemyHolder enemyHolder;

	public PlayerManager chasingPlayerTarg;

	public Transform middleOfBody;

	public AudioSource crackingBonesSfx;

	private int detectsBeforeLookForJumpPoint;

	public int playersLookingAt;

	private void Start()
	{
		anim.SetTrigger("MutantRun");
		ClientPlayer.Instance.playerMan.weepingAngels.Add(this);
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
		ChangeHittableHealthRpc(hittable.health + (float)(num * 100));
	}

	[ClientRpc]
	private void ChangeHittableHealthRpc(float health)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(health);
		SendRPCInternal("System.Void WeepingAngel::ChangeHittableHealthRpc(System.Single)", -730200568, writer, 0, includeOwner: true);
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
		curSpeed = normalSpeed;
		pathfinder.maxSpeed = normalSpeed;
	}

	private void OnDisable()
	{
		ClientPlayer.Instance.playerMan.weepingAngels.Remove(this);
		if (thisPlayer.isServer)
		{
			CancelInvoke("CheckIfNearBarricade");
			CancelInvoke("DetectPlayers");
			CancelInvoke("StartNextPathway");
		}
	}

	public void CheckEnemiesLeft(float timeUntilCheck)
	{
		if (thisPlayer.isServer)
		{
			HuntManager.Instance.CancelInvoke("EnemyDied");
			HuntManager.Instance.Invoke("EnemyDied", timeUntilCheck);
		}
	}

	private void FixedUpdate()
	{
		if (breakingBarricade)
		{
			GoToBreakBarricade();
		}
		else
		{
			GoToTarget();
		}
	}

	private void GoToBreakBarricade()
	{
		if (!hittable.invincibleToHits)
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
	}

	private void GoToTarget()
	{
		seeker.target = chaseTarget;
		Vector3.Distance(new Vector3(base.transform.position.x, 0f, base.transform.position.z), new Vector3(chaseTarget.position.x, 0f, chaseTarget.position.z));
		Vector3 forward = chaseTarget.position - base.transform.position;
		forward.y = 0f;
		Quaternion.LookRotation(forward);
		if ((bool)chasingPlayerTarg && canAttack && !hittable.invincibleToHits && Vector3.Distance(chasingPlayerTarg.transform.position, base.transform.position) < 1.8f)
		{
			chasingPlayerTarg.TakeDamage(40f, significantAnim: true);
			Invoke("CanAttack", 0.8f);
			canAttack = false;
		}
	}

	private void CanAttack()
	{
		canAttack = true;
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
		Transform transform = null;
		float num = float.PositiveInfinity;
		foreach (PlayerManager playerMan in playerMans)
		{
			float num2 = Vector3.Distance(playerMan.transform.position, base.transform.position);
			if (transform == null || num > num2)
			{
				num = num2;
				chaseTarget = playerMan.transform;
				transform = playerMan.transform;
				chasingPlayerTarg = playerMan;
			}
		}
	}

	public void TogglePlayerLookAt(bool lookingAt)
	{
		if (base.isServer)
		{
			TogglePlayerLookAtRpc(lookingAt);
		}
		else
		{
			TogglePlayerLookAtCmd(lookingAt);
		}
	}

	[Command(requiresAuthority = false)]
	private void TogglePlayerLookAtCmd(bool lookingAt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(lookingAt);
		SendCommandInternal("System.Void WeepingAngel::TogglePlayerLookAtCmd(System.Boolean)", -1393043073, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TogglePlayerLookAtRpc(bool lookingAt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(lookingAt);
		SendRPCInternal("System.Void WeepingAngel::TogglePlayerLookAtRpc(System.Boolean)", 948642568, writer, 0, includeOwner: true);
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
			breakingBarricade = false;
			pathfinder.maxSpeed = curSpeed;
		}
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
			((WeepingAngel)obj).UserCode_ChangeHittableHealthRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_TogglePlayerLookAtCmd__Boolean(bool lookingAt)
	{
		TogglePlayerLookAtRpc(lookingAt);
	}

	protected static void InvokeUserCode_TogglePlayerLookAtCmd__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command TogglePlayerLookAtCmd called on client.");
		}
		else
		{
			((WeepingAngel)obj).UserCode_TogglePlayerLookAtCmd__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_TogglePlayerLookAtRpc__Boolean(bool lookingAt)
	{
		if (lookingAt)
		{
			playersLookingAt++;
		}
		else
		{
			playersLookingAt--;
		}
		if (playersLookingAt <= 0)
		{
			hittable.invincibleToHits = false;
			crackingBonesSfx.volume = 0.7f;
			playersLookingAt = 0;
			anim.speed = 1f;
			curSpeed = normalSpeed;
			pathfinder.maxSpeed = normalSpeed;
		}
		else
		{
			hittable.invincibleToHits = true;
			crackingBonesSfx.volume = 0f;
			anim.speed = 0f;
			curSpeed = 0f;
			pathfinder.maxSpeed = 0f;
		}
	}

	protected static void InvokeUserCode_TogglePlayerLookAtRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TogglePlayerLookAtRpc called on server.");
		}
		else
		{
			((WeepingAngel)obj).UserCode_TogglePlayerLookAtRpc__Boolean(reader.ReadBool());
		}
	}

	static WeepingAngel()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(WeepingAngel), "System.Void WeepingAngel::TogglePlayerLookAtCmd(System.Boolean)", InvokeUserCode_TogglePlayerLookAtCmd__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(WeepingAngel), "System.Void WeepingAngel::ChangeHittableHealthRpc(System.Single)", InvokeUserCode_ChangeHittableHealthRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(WeepingAngel), "System.Void WeepingAngel::TogglePlayerLookAtRpc(System.Boolean)", InvokeUserCode_TogglePlayerLookAtRpc__Boolean);
	}
}
