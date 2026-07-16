using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_B_Warlord : EnemyBase, iMainBossController, iBossController
{
	[SerializeField]
	protected float xVariation = 1f;

	[SerializeField]
	protected float ySpeedMult = 10f;

	[Header("Warlord Fields")]
	[SerializeField]
	private int coreDropAmount;

	[SerializeField]
	private List<EnemyWave> waves;

	[SerializeField]
	private List<EnemySpawn> servants;

	[SerializeField]
	private float servantTimer;

	[SerializeField]
	private Animator headAnim;

	[SerializeField]
	private Animator handsAnim;

	[SerializeField]
	private SpriteRenderer drumsSr;

	[SerializeField]
	private Sprite regularDrums;

	[SerializeField]
	private Sprite aggressiveDrums;

	[SerializeField]
	private Sprite armoredDrums;

	[SerializeField]
	private Sprite firebornDrums;

	[SerializeField]
	private Sprite healerDrums;

	private WarlordsSongs currentSong;

	[NonSerialized]
	public bool IsWaveDead;

	private List<int> songsInCycle;

	private E4_B_Servant topServant;

	private E4_B_Servant bottomServant;

	private List<EnemySpawn> availableServants;

	private float topServantTimer;

	private float bottomServantTimer;

	[NonSerialized]
	public bool IsVulnerable;

	[field: SerializeField]
	public SpriteRenderer HeadSr { get; private set; }

	[field: SerializeField]
	public float PercentDamageOnWaveCleared { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 99f)]
	public float StartingDamageReductionPercent { get; private set; }

	[field: SerializeField]
	public float VulnerabilityDuration { get; private set; }

	[field: SerializeField]
	public float ArmorApplicationInterval { get; private set; }

	[field: SerializeField]
	public float AggressiveDamageIncrease { get; private set; }

	[field: SerializeField]
	public float AggressiveRofIncrease { get; private set; }

	[field: SerializeField]
	public int FirebornStackAmount { get; private set; }

	[field: SerializeField]
	public float FirebornBurnChance { get; private set; }

	[field: SerializeField]
	public float HealerInterval { get; private set; }

	[field: SerializeField]
	public float HealerHealPercent { get; private set; }

	[field: SerializeField]
	public ParticleSystem AggressivePs { get; private set; }

	[field: SerializeField]
	public ParticleSystem ArmoredPs { get; private set; }

	[field: SerializeField]
	public ParticleSystem FirebornPs { get; private set; }

	[field: SerializeField]
	public ParticleSystem HealerPs { get; private set; }

	[field: SerializeField]
	public GameObject ShieldGo { get; private set; }

	public event Action ControllerDied;

	private new void Awake()
	{
		base.Awake();
		CombatManager.Instance.EnemyKilled += TrackEnemiesKilled;
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[6]
		{
			new E4_B_Idle(sm, this),
			new E4_B_Armored(sm, this),
			new E4_B_Aggressive(sm, this),
			new E4_B_Fireborn(sm, this),
			new E4_B_Healer(sm, this),
			new E4_B_Vulnerable(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		songsInCycle = new List<int>();
		songsInCycle.Add(0);
		songsInCycle.Add(1);
		songsInCycle.Add(2);
		songsInCycle.Add(3);
		availableServants = new List<EnemySpawn>();
		availableServants.AddRange(servants);
	}

	private new void Start()
	{
		base.Start();
		base.transform.position = new Vector3(3f, 0f);
		Target();
		StartCoroutine(SpawnServants());
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	public override void Move()
	{
		Vector3 vector = new Vector3(1.5f, 0f);
		float num = (float)enemyPos;
		float num2 = Train.Instance.Wagons[0].transform.position.y * num;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float b2 = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if ((num == 1f && position.y < minY) || (num == -1f && position.y > minY))
		{
			position.y = minY;
		}
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		base.Move();
		IsInPosition = position.x < vector.x + xVariation && position.x > vector.x - xVariation && position.y * num > minY && position.y * num < maxY;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
	}

	public override void Aim()
	{
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = timeBetweenShots;
			soundBuilder.Play(shootSound);
		}
	}

	public void SpawnWave()
	{
		int index = UnityEngine.Random.Range(0, waves.Count);
		IsWaveDead = false;
		EnemyManager.Instance.ForceSpawnWave(waves[index]);
	}

	private IEnumerator SpawnServants()
	{
		SpawnTopServant();
		yield return new WaitForSeconds(1f);
		SpawnBottomServant();
	}

	private void SpawnTopServant()
	{
		if (topServant == null)
		{
			int index = UnityEngine.Random.Range(0, availableServants.Count);
			topServant = EnemyManager.Instance.SpawnEnemy(availableServants[index]).GetComponent<E4_B_Servant>();
			topServant.SetupServant(EnemyPositionOnScreen.TopOfScreen, this);
			availableServants.RemoveAt(index);
		}
		if (availableServants.Count == 0)
		{
			availableServants.AddRange(servants);
		}
	}

	private void SpawnBottomServant()
	{
		if (bottomServant == null)
		{
			int index = UnityEngine.Random.Range(0, availableServants.Count);
			bottomServant = EnemyManager.Instance.SpawnEnemy(availableServants[index]).GetComponent<E4_B_Servant>();
			bottomServant.SetupServant(EnemyPositionOnScreen.BottomOfScreen, this);
			availableServants.RemoveAt(index);
		}
		if (availableServants.Count == 0)
		{
			availableServants.AddRange(servants);
		}
	}

	public void ServantDied(EnemyPositionOnScreen position)
	{
		switch (position)
		{
		case EnemyPositionOnScreen.TopOfScreen:
			StartCoroutine(StartTopServantTimer());
			break;
		case EnemyPositionOnScreen.BottomOfScreen:
			StartCoroutine(StartBottomServantTimer());
			break;
		}
	}

	private IEnumerator StartTopServantTimer()
	{
		yield return new WaitForSeconds(servantTimer);
		SpawnTopServant();
	}

	private IEnumerator StartBottomServantTimer()
	{
		yield return new WaitForSeconds(servantTimer);
		SpawnBottomServant();
	}

	public void ChooseSong()
	{
		int index = UnityEngine.Random.Range(0, songsInCycle.Count);
		int num = songsInCycle[index];
		switch (num)
		{
		case 0:
			currentSong = WarlordsSongs.Armored;
			break;
		case 1:
			currentSong = WarlordsSongs.Aggressive;
			break;
		case 2:
			currentSong = WarlordsSongs.Fireborn;
			break;
		case 3:
			currentSong = WarlordsSongs.Healer;
			break;
		}
		songsInCycle.Remove(num);
		if (songsInCycle.Count == 0)
		{
			songsInCycle.Add(0);
			songsInCycle.Add(1);
			songsInCycle.Add(2);
			songsInCycle.Add(3);
		}
	}

	public void PrepareNextSong()
	{
		handsAnim.Play("WarlordHandsBang");
	}

	public void PlayNextSong()
	{
		switch (currentSong)
		{
		case WarlordsSongs.Armored:
			PlayArmoredSong();
			break;
		case WarlordsSongs.Aggressive:
			PlayAggresiveSong();
			break;
		case WarlordsSongs.Fireborn:
			PlayFirebornSong();
			break;
		case WarlordsSongs.Healer:
			PlayHealerSong();
			break;
		}
	}

	private void PlayArmoredSong()
	{
		sm.ForceState(sm.states["Armored"]);
		drumsSr.sprite = armoredDrums;
		CameraController.Instance.Shake(0.5f, 0.25f, force: true);
	}

	private void PlayAggresiveSong()
	{
		sm.ForceState(sm.states["Aggressive"]);
		drumsSr.sprite = aggressiveDrums;
		CameraController.Instance.Shake(0.5f, 0.25f, force: true);
	}

	private void PlayFirebornSong()
	{
		sm.ForceState(sm.states["Fireborn"]);
		drumsSr.sprite = firebornDrums;
		CameraController.Instance.Shake(0.5f, 0.25f, force: true);
	}

	private void PlayHealerSong()
	{
		sm.ForceState(sm.states["Healer"]);
		drumsSr.sprite = healerDrums;
		CameraController.Instance.Shake(0.5f, 0.25f, force: true);
	}

	private void TrackEnemiesKilled(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		bool isWaveDead = true;
		foreach (EnemyBase enemy2 in EnemyManager.Instance.Enemies)
		{
			if (!enemy2.IsBoss && !enemy2.IsPet && !enemy2.IsEnemyGadget && enemy2 != enemy)
			{
				isWaveDead = false;
				break;
			}
		}
		IsWaveDead = isWaveDead;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		EnemyManager.Instance.OnWarlordDestroyed();
		HUB.Instance.hubElements["Difficulty"].gameObject.GetComponent<FixDifficultyStation>().UnlockStation();
		this.ControllerDied?.Invoke();
		LevelManager.Instance.HandleBossBeaten(coreDropAmount);
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public float GetCurrentTotalHealth()
	{
		return base.HealthComponent.HealthCurrent;
	}

	public float GetTotalMaxHealth()
	{
		return base.HealthComponent.HealthMax;
	}

	public void PlayIdleAnim()
	{
		base.Anim.Play("WarlordVehicleIdle");
		headAnim.Play("WarlordHeadIdle");
		handsAnim.Play("WarlordHandsIdle");
		drumsSr.sprite = regularDrums;
	}

	public void PlayStunnedAnim()
	{
		base.Anim.Play("WarlordVehicleStunned");
		headAnim.Play("WarlordHeadStunned");
		handsAnim.Play("WarlordHandsStunned");
		drumsSr.sprite = regularDrums;
	}

	public void PlayCurrentSong()
	{
		switch (currentSong)
		{
		case WarlordsSongs.Armored:
			handsAnim.Play("WarlordHandSong 3");
			break;
		case WarlordsSongs.Aggressive:
			handsAnim.Play("WarlordHandSong1");
			break;
		case WarlordsSongs.Fireborn:
			handsAnim.Play("WarlordHandSong 2");
			break;
		case WarlordsSongs.Healer:
			handsAnim.Play("WarlordHandSong 4");
			break;
		}
	}

	protected override void OnHealthChanged(HealthChangeInfo info)
	{
		if (info.HealthChange > 0f)
		{
			SpawnHealParticles(info.HealthChange);
		}
		else if ((bool)flashEffect && !info.RemoveHitEffect)
		{
			if (info.IsImmune)
			{
				flashEffect.Flash(FlashTypes.Invulnerability);
			}
			else if (info.IsCrit)
			{
				flashEffect.Flash(FlashTypes.Crit);
			}
			else if (!IsVulnerable)
			{
				flashEffect.Flash(FlashTypes.Invulnerability);
			}
			else
			{
				flashEffect.Flash();
			}
		}
	}
}
