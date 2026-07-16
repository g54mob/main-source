using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using UnityEngine;

public class CentipedeController : MonoBehaviour, iMainBossController, iBossController
{
	private StateMachine sm;

	private int phase = 1;

	[Header("Centipede Settings")]
	[Tooltip("How many parts should be active per attack run?")]
	public int activePartCount;

	[Tooltip("The segment distance between leg animation loops.")]
	public int legTiming = 6;

	[Tooltip("Duration in seconds of how long a combat phase should last, i.e. how long activePartCount segments are open and firing for before they close and the centipede repositions.")]
	public float timeBetweenArmamentSwaps;

	[SerializeField]
	private Transform retinaTf;

	[SerializeField]
	public int coresToDrop;

	[Header("Movement Settings")]
	public float moveSpeed = 1f;

	[Tooltip("Higher values increase the frequency of turns when slithering.")]
	public float slitherFrequency = 2.5f;

	[SerializeField]
	private float slitherAmplitude = 2.5f;

	[SerializeField]
	private float speedMult = 5f;

	[Header("Prefabs")]
	public GameObject explosionPrefab;

	public GameObject bodyPrefab;

	public GameObject[] armamentPrefabs;

	public GameObject[] carapaceRustPrefabs;

	[SerializeField]
	private Animator[] antennaeAnims;

	[NonSerialized]
	[HideInInspector]
	public CentipedeSegment[] segments;

	[NonSerialized]
	[HideInInspector]
	public EnemyCentipede[] enemies;

	[NonSerialized]
	[HideInInspector]
	public List<EnemyCentipede> enemiesAlive;

	[NonSerialized]
	[HideInInspector]
	public List<EnemyCentipede> enemiesActive;

	[NonSerialized]
	[HideInInspector]
	public CentipedeLegs[] legs;

	[NonSerialized]
	[HideInInspector]
	public float xOffset;

	[NonSerialized]
	[HideInInspector]
	public bool offScreen;

	[NonSerialized]
	[HideInInspector]
	public float offscreenTimeOffset;

	[NonSerialized]
	[HideInInspector]
	public float yOffsetSide;

	[NonSerialized]
	[HideInInspector]
	public float trainFrontX;

	[NonSerialized]
	[HideInInspector]
	public Animator eyeAnim;

	[NonSerialized]
	[HideInInspector]
	public bool IsFullyDead;

	[Header("SFX")]
	[SerializeField]
	protected SoundData deathSFX;

	[SerializeField]
	protected SoundData roarSFX;

	public float minRoarWaitTime = 15f;

	public float maxRoarWaitTime = 25f;

	[SerializeField]
	protected SoundData engineSound;

	[SerializeField]
	protected SoundData shootSound;

	protected SoundBuilder soundBuilder;

	private float totalMaxHealth;

	[field: SerializeField]
	[field: Tooltip("How many parts should the centipede randomly spawn for itself upon spawning. Does not include the head, so if you want 9 parts plus the head this should be 9.")]
	public int PartCount { get; private set; }

	[field: SerializeField]
	public Sprite[] InsidesSpritesBody { get; private set; }

	[field: SerializeField]
	public Sprite[] InsidesSpritesLegs { get; private set; }

	public event Action ControllerDied;

	private void Awake()
	{
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[5]
		{
			new E1_B_ControllerInitialize(sm, this),
			new E1_B_ControllerBehind(sm, this),
			new E1_B_ControllerCombat(sm, this),
			new E1_B_ControllerRetreat(sm, this),
			new E1_B_ControllerDeath(sm, this)
		});
	}

	private void Start()
	{
		yOffsetSide = ((UnityEngine.Random.Range(0, 2) == 0) ? 0.75f : (-0.75f));
		(sm.states["Init"] as E1_B_ControllerInitialize).OnStart();
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
		soundBuilder.Play(roarSFX);
		StartCoroutine(PlaySoundWithDelay());
		soundBuilder.Play(engineSound);
	}

	private void Update()
	{
		sm.UpdateStates();
		if (Time.timeScale != 0f && !IsFullyDead)
		{
			Movement();
			EyeMovement();
		}
	}

	public void SetSpeeds(float speed)
	{
		for (int i = 0; i < legs.Length; i++)
		{
			if (legs[i] != null)
			{
				legs[i].SetSpeed(speed * speedMult);
			}
		}
		Animator[] array = antennaeAnims;
		foreach (Animator animator in array)
		{
			if (animator != null)
			{
				animator.SetFloat("AntennaeSpeed", speed);
			}
		}
	}

	private void Movement()
	{
		float num = 0f;
		for (int i = 0; i < segments.Length; i++)
		{
			if (!(segments[i] == null))
			{
				float num2 = slitherAmplitude;
				float num3 = Mathf.Sin((Train.Instance.LevelDistance + segments[0].transform.position.x) * (slitherFrequency * 0.5f) + (float)i) * num2 / 100f;
				segments[i].transform.position = Vector3.right * (xOffset + num) + Vector3.up * num3 + new Vector3(0f, Train.Instance.Wagons[0].transform.position.y + yOffsetSide);
				Quaternion rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(1f, 0f, 0f));
				if (i > 0)
				{
					Vector3 normalized = (segments[i - 1].transform.position - segments[i].transform.position).normalized;
					rotation = Quaternion.LookRotation(Vector3.forward, normalized);
				}
				else if (segments[i + 3] != null)
				{
					rotation = segments[i + 3].transform.rotation;
				}
				segments[i].transform.rotation = rotation;
				if (i + 1 <= segments.Length - 1 && !(segments[i + 1] == null))
				{
					float num4 = segments[i].padding + ((i < segments.Length - 1) ? segments[i + 1].padding : 0f);
					num += num4;
				}
			}
		}
	}

	private void EyeMovement()
	{
		Vector3 vector = Train.Instance.transform.position - retinaTf.parent.position;
		retinaTf.parent.rotation = Quaternion.LookRotation(Vector3.forward, vector);
		retinaTf.rotation = Quaternion.LookRotation(Vector3.forward, -vector);
	}

	public void Phase(int phase)
	{
		switch (phase)
		{
		case 1:
			eyeAnim.Play("Green");
			break;
		case 2:
			eyeAnim.Play("Yellow");
			break;
		case 3:
			eyeAnim.Play("Red");
			break;
		}
	}

	public void SetLegTimings()
	{
		for (int i = 0; i < legs.Length; i++)
		{
			legs[i].Play(i, legTiming);
		}
	}

	public void OnEnemyDeath(EnemyCentipede enemy)
	{
		enemiesAlive.Remove(enemy);
		enemiesActive.Remove(enemy);
		if (enemiesAlive.Count <= 0)
		{
			if (GameManager.Instance.isOverfillStationConditionMet)
			{
				HUB.Instance.hubElements["Overfilling"].gameObject.GetComponent<FixOverfillingStation>().UnlockStation();
			}
			HUB.Instance.hubElements["Toolbox"].gameObject.GetComponent<FixToolbox>().UnlockStation();
			this.ControllerDied?.Invoke();
			sm.ForceState("Death");
		}
		phase = 4 - Mathf.CeilToInt((float)enemiesAlive.Count / 3f);
		Phase(phase);
	}

	public float GetCurrentTotalHealth()
	{
		float num = 0f;
		for (int i = 0; i < enemiesAlive.Count; i++)
		{
			num += enemiesAlive[i].HealthComponent.HealthCurrent;
		}
		return num;
	}

	public float GetTotalMaxHealth()
	{
		if (totalMaxHealth > 0f)
		{
			return totalMaxHealth;
		}
		for (int i = 0; i < enemiesAlive.Count; i++)
		{
			totalMaxHealth += enemiesAlive[i].HealthComponent.HealthMax;
		}
		return totalMaxHealth;
	}

	private IEnumerator PlaySoundWithDelay()
	{
		while (enemiesAlive.Count > 0)
		{
			float seconds = UnityEngine.Random.Range(minRoarWaitTime, maxRoarWaitTime);
			yield return new WaitForSeconds(seconds);
			soundBuilder.Play(roarSFX);
		}
	}

	public void DestroySelf()
	{
		Debug.Log("Centipede Dead");
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public List<iBossController> GetAllControllers()
	{
		return new List<iBossController> { this };
	}
}
