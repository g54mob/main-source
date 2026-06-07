using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Marionette : Enemy
{
	public Transform spiderSpawn;

	public Animator anim;

	public HuntManager huntMan;

	public List<PlayerManager> playerMans;

	public Hittable hittable;

	public EnemyHolder enemyHolder;

	public Transform nearestPlayer;

	public MaterialFader matFader;

	public float maxHealth;

	public bool justFadeIn;

	public bool justFadeOut;

	public Transform wallDetect;

	public LayerMask wallLayerMask;

	public bool isHitting;

	private float timeUntilAttack;

	[ClientRpc]
	private void ChangeHittableHealthRpc(float health)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(health);
		SendRPCInternal("System.Void Marionette::ChangeHittableHealthRpc(System.Single)", 422516768, writer, 0, includeOwner: true);
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

	public void TakeDamage()
	{
		anim.SetTrigger("TakeDamage");
	}

	private void Start()
	{
		huntMan = HuntManager.Instance;
		if (base.isServer)
		{
			int num = 0;
			foreach (PlayerManager playerMan in StoreManager.Instance.playerMans)
			{
				if ((bool)playerMan)
				{
					num++;
				}
			}
			float health = hittable.health + (float)(num * 400);
			ChangeHittableHealthRpc(health);
			maxHealth = health;
		}
		huntMan.allEnemies.Add(this);
	}

	private void OnEnable()
	{
		playerMans = StoreManager.Instance.playerMans;
		Invoke("UpdatePlayerLists", 0.1f);
		CancelInvoke("DetectPlayers");
		InvokeRepeating("DetectPlayers", 0.15f, 0.2f);
	}

	private void OnDisable()
	{
		if (ClientPlayer.Instance.isServer)
		{
			CancelInvoke("CheckIfNearBarricade");
			CancelInvoke("DetectPlayers");
			CancelInvoke("StartNextPathway");
		}
	}

	public void CheckEnemiesLeft(float timeUntilCheck)
	{
		if (ClientPlayer.Instance.isServer)
		{
			HuntManager.Instance.CancelInvoke("EnemyDied");
			HuntManager.Instance.Invoke("EnemyDied", timeUntilCheck);
		}
	}

	private void FixedUpdate()
	{
		GoToTarget();
		isHitting = Physics.Raycast(wallDetect.position, wallDetect.forward, 2f, wallLayerMask);
		if (isHitting && !justFadeOut)
		{
			justFadeIn = false;
			justFadeOut = true;
			matFader.PlayFadeOut(0.3f);
		}
		if (!isHitting && !justFadeIn)
		{
			justFadeOut = false;
			justFadeIn = true;
			matFader.PlayFadeIn(0.6f);
		}
	}

	private void GoToTarget()
	{
		if (!base.isServer)
		{
			return;
		}
		float num = Vector3.Distance(new Vector3(base.transform.position.x, 0f, base.transform.position.z), new Vector3(nearestPlayer.position.x, 0f, nearestPlayer.position.z));
		Vector3 forward = nearestPlayer.position - base.transform.position;
		forward.y = 0f;
		Quaternion rotation = Quaternion.LookRotation(forward);
		base.transform.rotation = rotation;
		float num2 = 0.04f + (1f - hittable.health / maxHealth) * 0.06f;
		if (num < 3f)
		{
			num2 += 0.015f;
			if (num < 2f)
			{
				anim.SetBool("Attacking", value: true);
				if (num < 1.5f)
				{
					timeUntilAttack -= Time.deltaTime;
					if (timeUntilAttack < 0f)
					{
						nearestPlayer.gameObject.GetComponent<PlayerManager>().TakeDamage(5f, significantAnim: false);
						timeUntilAttack = 0.5f;
					}
				}
			}
			else
			{
				anim.SetBool("Attacking", value: false);
			}
			Invoke("CanAttack", 0.8f);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, nearestPlayer.position.y - 0.5f, base.transform.position.z), Time.deltaTime);
		}
		else
		{
			anim.SetBool("Attacking", value: false);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, 1f, base.transform.position.z), Time.deltaTime);
		}
		num2 = Mathf.Clamp(num2, 0.03f, 0.11f);
		base.transform.position += base.transform.forward * num2;
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
			if (!playerMan.downed && !playerMan.dead)
			{
				float num2 = Vector3.Distance(playerMan.transform.position, base.transform.position);
				if (transform == null || num > num2)
				{
					num = num2;
					transform = playerMan.transform;
					nearestPlayer = playerMan.transform;
				}
			}
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
			((Marionette)obj).UserCode_ChangeHittableHealthRpc__Single(reader.ReadFloat());
		}
	}

	static Marionette()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(Marionette), "System.Void Marionette::ChangeHittableHealthRpc(System.Single)", InvokeUserCode_ChangeHittableHealthRpc__Single);
	}
}
