using System.Collections;
using Pathfinding;
using UnityEngine;

public class ChaseWhenNear : MonoBehaviour
{
	public AIDestinationSetter seeker;

	public AIPath pathfinder;

	public Transform chaser;

	public Transform target;

	public bool chasing;

	public float range;

	public float attackRange;

	public float runSpeed;

	public Animator anim;

	public AudioSource catchAudio;

	public GameObject finishTrigger;

	public Material headMaterial;

	public Material bodyMaterial;

	public Collider bodyCollider;

	public GameObject finishCanvas;

	private bool attacking;

	public AudioSource chaseAudio;

	public AudioSource footstepAudio;

	public AudioSource footstepAudio_;

	private bool stopChase;

	private bool endedChase;

	private bool ended;

	public GameObject nathan;

	public Animator nathanAnim;

	public CarBrokenDownNetwork networkScript;

	public StoreManager storeMan;

	private bool alreadyStoppedChase;

	public PlayerManager closestPlayer;

	public Telephone telephone;

	public GameObject phoneRingingSfx;

	public GameObject carBrokenDownHolder;

	public int damageToPlayer = 40;

	private void Start()
	{
		bodyMaterial.SetFloat("_Cutoff", 0f);
		headMaterial.SetFloat("_Cutoff", 0f);
		storeMan = StoreManager.Instance;
		target = ClientPlayer.Instance.transform;
		anim.SetTrigger("Drunk Idle");
	}

	public void StartChasing()
	{
		ClientPlayer.Instance.inventoryMan.GunJam();
		nathan.SetActive(value: true);
		nathanAnim.GetComponent<Animator>().SetTrigger("Zombie Scream");
		chasing = true;
		finishTrigger.SetActive(value: true);
		StoreManager.Instance.FinishObjective();
	}

	private void FixedUpdate()
	{
		float num = 10000f;
		if (ClientPlayer.Instance.isServer)
		{
			foreach (PlayerManager playerMan in storeMan.playerMans)
			{
				if (!playerMan.downed && !playerMan.dead && !playerMan.inside)
				{
					Transform transform = playerMan.transform;
					float num2 = Vector3.Distance(base.transform.position, transform.position);
					if (num2 < num)
					{
						num = num2;
						target = transform;
					}
				}
			}
		}
		if (!chasing)
		{
			if (Vector3.Distance(base.transform.position, target.position) < range)
			{
				networkScript.StartChasing();
			}
			return;
		}
		if (!alreadyStoppedChase && storeMan.playerMans.Count != 0)
		{
			bool flag = true;
			foreach (PlayerManager playerMan2 in storeMan.playerMans)
			{
				if (!playerMan2.downed && !playerMan2.dead && !playerMan2.inside)
				{
					flag = false;
				}
			}
			if (flag)
			{
				networkScript.EndChasing();
				alreadyStoppedChase = true;
			}
		}
		if (Vector3.Distance(chaser.position, target.position) < attackRange && !attacking && !ended)
		{
			closestPlayer = target.GetComponent<PlayerManager>();
			Attack();
		}
		if (stopChase)
		{
			chaseAudio.volume = Mathf.Lerp(chaseAudio.volume, 0f, Time.deltaTime);
			footstepAudio.volume = Mathf.Lerp(footstepAudio.volume, 0f, Time.deltaTime);
			footstepAudio_.volume = Mathf.Lerp(footstepAudio_.volume, 0f, Time.deltaTime);
		}
		else
		{
			chaseAudio.volume = Mathf.Lerp(chaseAudio.volume, 0.27f, Time.deltaTime * 1f);
			footstepAudio.volume = Mathf.Lerp(footstepAudio.volume, 0.3f, Time.deltaTime);
			footstepAudio_.volume = Mathf.Lerp(footstepAudio_.volume, 0.3f, Time.deltaTime);
		}
	}

	private void Attack()
	{
		anim.SetTrigger("Zombie Attack");
		attacking = true;
		Invoke("FinishAttack", 1f);
		pathfinder.maxSpeed = 2f;
		if (closestPlayer == ClientPlayer.Instance.playerMan)
		{
			Invoke("DealDamageToPlayer", 0.23f);
		}
	}

	private void DealDamageToPlayer()
	{
		if (closestPlayer == ClientPlayer.Instance.playerMan)
		{
			closestPlayer.TakeDamage(damageToPlayer, significantAnim: true);
		}
	}

	private void FinishAttack()
	{
		attacking = false;
		pathfinder.maxSpeed = runSpeed;
		anim.SetTrigger("Standard Run");
	}

	public void StartActualChasing()
	{
		phoneRingingSfx.SetActive(value: false);
		seeker.target = target;
		pathfinder.enabled = true;
		pathfinder.maxSpeed = runSpeed;
		anim.SetTrigger("Standard Run");
		Invoke("Idk", 0.1f);
		Invoke("Idk", 0.2f);
		Invoke("Idk", 0.3f);
		Invoke("Idk", 0.4f);
		Invoke("Idk", 0.5f);
		Invoke("Idk", 0.6f);
		Invoke("Idk", 0.7f);
	}

	private void Idk()
	{
		phoneRingingSfx.SetActive(value: false);
		seeker.target = target;
		pathfinder.enabled = true;
		pathfinder.maxSpeed = runSpeed;
		anim.SetTrigger("Standard Run");
	}

	public void EndChase()
	{
		if (!ended)
		{
			ClientPlayer.Instance.inventoryMan.GunUnjam();
			phoneRingingSfx.SetActive(value: false);
			telephone.telephoneDone = true;
			ended = true;
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 9f);
			StartCoroutine(LerpAlphaClipping());
			bodyCollider.enabled = false;
			finishCanvas.SetActive(value: true);
			StoreManager.Instance.FinishObjective();
			Invoke("TurnOffChaser", 1.5f);
			Invoke("TurnOff", 18f);
			Invoke("PlayerSpeak", 12f);
			Invoke("TurnOffMusic", 4f);
		}
	}

	private void TurnOff()
	{
		carBrokenDownHolder.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}

	private void TurnOffChaser()
	{
		chaser.gameObject.SetActive(value: false);
		finishTrigger.gameObject.SetActive(value: false);
	}

	private void TurnOffMusic()
	{
		stopChase = true;
	}

	private void PlayerSpeak()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SpeakingManager.Instance.AddChatLogNode(JSONAccess.Instance.GetMiscText("UI Text 4", "You"), JSONAccess.Instance.GetMiscText("UI Text 4", "What the hell was that?"), 0);
		}
	}

	private IEnumerator LerpAlphaClipping()
	{
		float elapsedTime = 0f;
		bodyMaterial.SetFloat("_Cutoff", 0f);
		headMaterial.SetFloat("_Cutoff", 0f);
		while (elapsedTime < 1f)
		{
			float value = Mathf.Lerp(0f, 1f, elapsedTime * 1.5f);
			bodyMaterial.SetFloat("_Cutoff", value);
			headMaterial.SetFloat("_Cutoff", value);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		headMaterial.SetFloat("_Cutoff", 1f);
		bodyMaterial.SetFloat("_Cutoff", 1f);
		Debug.Log("Alpha clipping threshold lerp complete!");
	}
}
