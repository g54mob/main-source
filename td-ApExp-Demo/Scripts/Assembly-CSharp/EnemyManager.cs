using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private EnemyWave currentWave;

	private List<EnemySpawn> currentWaveSpawns;

	[SerializeField]
	private List<EnemyBase> enemies = new List<EnemyBase>();

	[SerializeField]
	private int maxEnemies = 10;

	private float timer;

	[SerializeField]
	private float timeBetweenWaves = 10f;

	private bool isThisWaveFlipped;

	[SerializeField]
	private float firstWaveDelay = 5f;

	[NonSerialized]
	private float firstWaveTimer;

	[SerializeField]
	public Transform trailsContainer;

	private bool levelPlaying;

	[Header("Scramble Handler")]
	[SerializeField]
	private float minScrambleInterval;

	[SerializeField]
	private float maxScrambleInterval;

	[NonSerialized]
	public bool scramblerHacked;

	[NonSerialized]
	public List<EnemyBase> scramblersAlive;

	private int medicSquadIterator;

	private int randomDamageCounter = 2;

	public static EnemyManager Instance { get; private set; }

	public float EnemyMissileSpeedMult { get; set; } = 1f;

	public IReadOnlyList<EnemyBase> Enemies => enemies;

	public float WaveTimer { get; set; }

	[field: SerializeField]
	public GameObject ExplodedPartPrefab { get; private set; }

	[field: SerializeField]
	public GameObject ExplosionPrefab { get; private set; }

	[field: SerializeField]
	public SerializedDictionary<EnemyTypes, GameObject> EnemyPrefabs { get; private set; }

	[field: SerializeField]
	public GameObject StunPsPrefab { get; private set; }

	public float BossDmgMult { get; set; } = 1f;

	[field: NonSerialized]
	public bool IsScrambling { get; private set; }

	public event Action<EnemyBase> EnemySpawned;

	public event Action<EnemyBase> EnemyEMPd;

	public event Action<EnemyBase> EnemyDestroyed;

	public event Action<EnemyBase> EnemyDespawned;

	public event Action<iMainBossController> OnBossSpawned;

	public event Action CentipedeDestroyed;

	public event Action DualBossDestroyed;

	public event Action BirdTrioDestroyed;

	public event Action WarlordDestroyed;

	public event Action OnWaweSpawned;

	public event Action<Vector2> OnScramble;

	public event Action OnUnscramble;

	public void OnEnemySpawned(EnemyBase enemy)
	{
		this.EnemySpawned(enemy);
	}

	public void OnCentipedeDestroyed()
	{
		this.CentipedeDestroyed?.Invoke();
	}

	public void OnDualBossDestroyed()
	{
		this.DualBossDestroyed?.Invoke();
	}

	public void OnBirdTrioDestroyed()
	{
		this.BirdTrioDestroyed?.Invoke();
	}

	public void OnWarlordDestroyed()
	{
		this.WarlordDestroyed?.Invoke();
	}

	private void Awake()
	{
		Instance = this;
		scramblersAlive = new List<EnemyBase>();
	}

	private void Start()
	{
		OnWaweSpawned += SpawnAdditionalEnemies;
		LevelManager.Instance.NextLevelSelected += OnNextLevelSelected;
		LevelManager.Instance.LevelCompleted += OnLevelCompleted;
		ZoneManager.Instance.OnNewZone += delegate
		{
			foreach (EnemyBase enemy in enemies)
			{
				UnityEngine.Object.Destroy(enemy.gameObject);
			}
		};
	}

	private void OnLevelCompleted()
	{
		levelPlaying = false;
		if (scramblersAlive.Count == 0)
		{
			Unscramble();
		}
	}

	public void RegisterEnemy(EnemyBase enemy)
	{
		if (!(enemy is EnemyComponent) && !enemies.Contains(enemy))
		{
			enemies.Add(enemy);
		}
	}

	public void UnregisterEnemy(EnemyBase enemy)
	{
		if (!(enemy is EnemyComponent) && enemies.Contains(enemy))
		{
			enemies.Remove(enemy);
		}
	}

	public void PlayUpdate()
	{
		firstWaveTimer -= Time.deltaTime;
		if (firstWaveTimer > 0f || Enemies.Count >= maxEnemies)
		{
			return;
		}
		if (currentWave == null)
		{
			NextWave();
		}
		timer += Time.deltaTime;
		if (currentWaveSpawns == null || currentWaveSpawns.Count == 0)
		{
			UIManager.Instance.HUD.UpdateWaveTimerText();
			WaveTimer -= Time.deltaTime;
			if (WaveTimer <= 0f)
			{
				NextWave();
			}
		}
		else
		{
			if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index <= 3)
			{
				return;
			}
			if (currentWave.TimeBetweenSpawns != -1f)
			{
				float num = 0f;
				EnemySpawn enemySpawn = currentWaveSpawns[0];
				num = ((enemySpawn.SpawnTime == -1f) ? currentWave.TimeBetweenSpawns : enemySpawn.SpawnTime);
				if (!(timer < num))
				{
					timer = 0f;
					SpawnEnemy(currentWaveSpawns[0]);
					currentWaveSpawns.RemoveAt(0);
					if (currentWaveSpawns.Count == 0)
					{
						this.OnWaweSpawned?.Invoke();
					}
				}
			}
			else
			{
				SpawnWave();
			}
		}
	}

	private void SpawnWave()
	{
		for (int i = 0; i < currentWaveSpawns.Count; i++)
		{
			EnemySpawn enemySpawn = currentWaveSpawns[i];
			if (timer >= enemySpawn.SpawnTime)
			{
				SpawnEnemy(enemySpawn);
				currentWaveSpawns.Remove(enemySpawn);
			}
		}
		if (currentWaveSpawns.Count == 0)
		{
			this.OnWaweSpawned?.Invoke();
		}
	}

	public void ForceSpawnWave(EnemyWave wave)
	{
		List<EnemySpawn> spawns = wave.Spawns;
		for (int i = 0; i < spawns.Count; i++)
		{
			EnemySpawn spawn = spawns[i];
			SpawnEnemy(spawn);
		}
		this.OnWaweSpawned?.Invoke();
	}

	private void SpawnAdditionalEnemies()
	{
		if (!(DifficultyManager.Instance.additionalEnemies > 0f))
		{
			return;
		}
		for (int i = 0; (float)i < DifficultyManager.Instance.additionalEnemies; i++)
		{
			List<GameObject> list = new List<GameObject>();
			SerializedDictionary<GameObject, float> serializedDictionary = DifficultyManager.Instance.EnemyWhitelists[ZoneManager.Instance.CurrentZoneIndex - 1];
			foreach (GameObject key in serializedDictionary.Keys)
			{
				if (key.gameObject.GetComponent<EnemyBase>().UnlockColumn <= LevelManager.Instance.CurrentLevel.Column)
				{
					list.Add(key);
				}
			}
			float[] array = new float[list.Count];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = serializedDictionary[list[j]];
			}
			int weightedIndex = LootUtils.GetWeightedIndex(array);
			SpawnEnemy(list[weightedIndex]);
		}
	}

	private void NextWave()
	{
		isThisWaveFlipped = false;
		int levelDifficulty = LevelManager.Instance.CurrentLevel.Column;
		System.Random random = new System.Random();
		IOrderedEnumerable<EnemyWave> source = ZoneManager.Instance.Waves.OrderBy((EnemyWave w) => random.Next());
		EnemyWave enemyWave = source.Where((EnemyWave w) => (currentWave == null || w.Id != currentWave.Id) && w.MinDifficulty <= (float)levelDifficulty && AreWaveEnemiesUnlockedYet(w)).FirstOrDefault();
		if (!enemyWave)
		{
			enemyWave = (from w in ZoneManager.Instance.Waves
				orderby random.Next()
				where (currentWave == null || w.Id != currentWave.Id) && w.MinDifficulty <= (float)levelDifficulty && AreWaveEnemiesUnlockedYet(w)
				select w).FirstOrDefault();
		}
		if (!enemyWave)
		{
			enemyWave = source.FirstOrDefault();
		}
		if (!enemyWave)
		{
			Debug.LogError("EnemyManager Error: Enemy waves list is empty.");
			timer = 0f;
			WaveTimer = timeBetweenWaves + timeBetweenWaves * DifficultyManager.Instance.waveSpawnModifier;
			return;
		}
		currentWave = UnityEngine.Object.Instantiate(enemyWave);
		currentWaveSpawns = currentWave.Spawns;
		if (currentWave.VerticalSymmetry && UnityEngine.Random.Range(0, 2) == 0)
		{
			isThisWaveFlipped = true;
		}
		timer = 0f;
		WaveTimer = timeBetweenWaves + timeBetweenWaves * DifficultyManager.Instance.waveSpawnModifier;
	}

	public bool AreWaveEnemiesUnlockedYet(EnemyWave wave)
	{
		for (int i = 0; i < wave.Spawns.Count; i++)
		{
			EnemySpawn enemySpawn = wave.Spawns[i];
			if (EnemyPrefabs.TryGetValue(enemySpawn.EnemyType, out var value) && value.GetComponent<EnemyBase>().UnlockColumn > LevelManager.Instance.CurrentLevel.Column)
			{
				return false;
			}
		}
		return true;
	}

	public GameObject SpawnEnemy(EnemySpawn spawn)
	{
		if (!EnemyPrefabs.TryGetValue(spawn.EnemyType, out var value))
		{
			return null;
		}
		Vector3 zero = Vector3.zero;
		float num = 0f;
		if (currentWave != null && currentWave.RandomAnglesOverride)
		{
			UnityEngine.Random.Range(0, 100);
			_ = 50;
			num = UnityEngine.Random.Range(0f, 359f);
		}
		else
		{
			num = spawn.SpawnAngle;
			num += UnityEngine.Random.Range((0f - spawn.AngleVariance) / 2f, spawn.AngleVariance / 2f);
			if (isThisWaveFlipped)
			{
				num = (num + 180f) % 360f;
			}
		}
		num = AdjustAngle(value, num);
		zero = EnemyWave.SpawnPosFromAngle(num);
		GameObject gameObject = UnityEngine.Object.Instantiate(value, zero, Quaternion.identity, base.transform);
		EnemyBase component = gameObject.GetComponent<EnemyBase>();
		if (component is E2_3MedicSquad e2_3MedicSquad)
		{
			foreach (E2_3Medic medic in e2_3MedicSquad.Medics)
			{
				this.EnemySpawned?.Invoke(medic);
			}
		}
		else
		{
			this.EnemySpawned?.Invoke(component);
		}
		if (scramblerHacked && !component.IsHacked)
		{
			component.HealthComponent.ApplyWeaken(999f);
		}
		return gameObject;
	}

	public GameObject SpawnEnemy(GameObject enemyPrefab, EnemyBase.EnemyPositionOnScreen? position = null, Vector3? spawnPos = null, Quaternion? rotation = null, bool isArmored = false)
	{
		Vector3 zero = Vector3.zero;
		if (spawnPos.HasValue)
		{
			zero = spawnPos.Value;
		}
		else
		{
			zero = EnemyWave.SpawnPosFromAngle(AdjustAngle(enemyPrefab, UnityEngine.Random.Range(0f, 360f)));
			if (position.HasValue)
			{
				if (position == EnemyBase.EnemyPositionOnScreen.TopOfScreen)
				{
					zero.y = Mathf.Abs(zero.y);
				}
				else if (position == EnemyBase.EnemyPositionOnScreen.BottomOfScreen)
				{
					zero.y = 0f - Mathf.Abs(zero.y);
				}
			}
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(enemyPrefab, zero, rotation ?? Quaternion.identity, base.transform);
		EnemyBase component = gameObject.GetComponent<EnemyBase>();
		if (component is E2_3MedicSquad e2_3MedicSquad)
		{
			foreach (E2_3Medic medic in e2_3MedicSquad.Medics)
			{
				this.EnemySpawned?.Invoke(medic);
			}
		}
		else
		{
			this.EnemySpawned?.Invoke(component);
		}
		if (scramblerHacked && !component.IsHacked)
		{
			component.HealthComponent.ApplyWeaken(999f);
		}
		return gameObject;
	}

	private float AdjustAngle(GameObject enemyPrefab, float angle)
	{
		if (enemyPrefab.TryGetComponent<EnemyBase>(out var component))
		{
			if (component.PrefferedSpawnPos != ScreenPositions.None)
			{
				angle = GetPrefferedAngle(component.PrefferedSpawnPos);
			}
			if (!component.IsGrounded)
			{
				return angle;
			}
		}
		return AdjustAngle(angle);
	}

	private float AdjustAngle(float angle)
	{
		if (angle < 0f)
		{
			angle = 360f - angle;
		}
		if (angle > 45f && angle < 135f)
		{
			if (angle < 90f)
			{
				return 45f;
			}
			return 135f;
		}
		return angle;
	}

	private float GetPrefferedAngle(ScreenPositions pos)
	{
		switch (pos)
		{
		case ScreenPositions.None:
			return UnityEngine.Random.Range(0f, 360f);
		case ScreenPositions.Back:
			return UnityEngine.Random.Range(180f, 360f);
		case ScreenPositions.Front:
			return UnityEngine.Random.Range(0f, 180f);
		case ScreenPositions.Center:
			if (!(UnityEngine.Random.Range(0f, 1f) > 0.5f))
			{
				return UnityEngine.Random.Range(135f, 225f);
			}
			return UnityEngine.Random.Range(-45f, 45f);
		case ScreenPositions.Left:
			return UnityEngine.Random.Range(-90f, 90f);
		case ScreenPositions.Right:
			return UnityEngine.Random.Range(90f, 270f);
		default:
			return UnityEngine.Random.Range(0f, 360f);
		}
	}

	public void DamageRandomEnemy()
	{
		if (Enemies.Count != 0)
		{
			randomDamageCounter++;
			int index = UnityEngine.Random.Range(0, Enemies.Count);
			float num = UnityEngine.Random.Range(50f, 60f);
			if (randomDamageCounter == 3)
			{
				randomDamageCounter = 0;
				UnityEngine.Object.Instantiate(ExplosionPrefab, Enemies[index].transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.5f, 0f);
				CameraController.Instance.Shake(0.25f, 0.5f, force: true);
			}
			HealthChangeInfo info = new HealthChangeInfo(this, Enemies[index].HealthComponent, 0f - num, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
			Enemies[index].HealthComponent.ChangeHealthWithInfo(info);
		}
	}

	public void InstakillAllEnemies()
	{
		StartCoroutine(KillAllEnemyChildrenCoroutine());
	}

	private IEnumerator KillAllEnemyChildrenCoroutine()
	{
		do
		{
			foreach (EnemyBase enemy in Enemies)
			{
				HealthChangeInfo info = new HealthChangeInfo(this, enemy.HealthComponent, -100f, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
				enemy.HealthComponent.SetHealthWithInfo(info);
			}
			foreach (Transform item in base.transform)
			{
				if (item.TryGetComponent<EnemyBase>(out var component))
				{
					HealthChangeInfo info2 = new HealthChangeInfo(this, component.HealthComponent, -100f, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
					component.HealthComponent.SetHealthWithInfo(info2);
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
		while ((Enemies.Count > 0 || base.transform.childCount > 0) && !levelPlaying);
	}

	public void ForceEnemyTotalClear()
	{
		foreach (KeyValuePair<Unit, EnemyUI> enemyUi in UIManager.Instance.EnemyHealthbarsDisplay.enemyUis)
		{
			if (enemyUi.Value != null)
			{
				UnityEngine.Object.Destroy(enemyUi.Value.gameObject);
			}
		}
		foreach (Transform item in base.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in trailsContainer)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
	}

	public void SpawnBoss()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(ZoneManager.Instance.BossPrefab, new Vector2(-5f, 0f), Quaternion.identity);
		this.OnBossSpawned?.Invoke(gameObject.GetComponent<iMainBossController>());
	}

	public void OnEnemyDestroyed(EnemyBase enemy)
	{
		this.EnemyDestroyed?.Invoke(enemy);
	}

	public void OnEnemyDespawned(EnemyBase enemy)
	{
		this.EnemyDespawned?.Invoke(enemy);
	}

	public void OnEnemyEMPd(EnemyBase enemy)
	{
		this.EnemyEMPd?.Invoke(enemy);
	}

	private void OnNextLevelSelected(Level nextLevel)
	{
		currentWave = null;
		firstWaveTimer = firstWaveDelay;
		levelPlaying = true;
	}

	public EnemyBase[] GetEnemiesInRadius(Unit target, float radius, bool includeDead = false)
	{
		Vector3 position = target.gameObject.transform.position;
		List<EnemyBase> list = new List<EnemyBase>();
		foreach (EnemyBase enemy in Enemies)
		{
			if (enemy.IsEnemy != target.IsEnemy && (includeDead || !enemy.HealthComponent.IsDead) && !(enemy.transform.position.y * position.y < 0f) && Vector3.Distance(position, enemy.transform.position) <= radius)
			{
				list.Add(enemy);
			}
		}
		return list.ToArray();
	}

	public void Scramble()
	{
		IsScrambling = true;
		this.OnScramble?.Invoke(new Vector2(minScrambleInterval, maxScrambleInterval));
	}

	public void Unscramble()
	{
		IsScrambling = false;
		this.OnUnscramble?.Invoke();
	}

	public int GetMedicSquadIterator()
	{
		int result = medicSquadIterator;
		medicSquadIterator++;
		if (medicSquadIterator > 4)
		{
			medicSquadIterator = 0;
		}
		return result;
	}
}
