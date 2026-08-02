using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AzureSky;

public class ZombieSpawner : NetworkBehaviour
{
	private static readonly HashSet<ZombieController> allActiveZombies = new HashSet<ZombieController>();

	private readonly HashSet<ZombieController> mySpawnedZombies = new HashSet<ZombieController>();

	private readonly HashSet<ZombieController> spawnPointZombies = new HashSet<ZombieController>();

	[Header("═══ MASTER SWITCH ═══")]
	[Tooltip("Kapatılırsa bu spawner hiç zombi doğurmaz (normal spawn + spawn point dahil).")]
	public bool spawningEnabled = true;

	[Space(12f)]
	[Header("═══ BIOME & DATA ═══")]
	public string biomeID = "DefaultBiome";

	public ZombieSpawnData spawnData;

	[Space(12f)]
	[Header("═══ SPAWN PLACEMENT ═══")]
	public LayerMask groundLayer = 1;

	public LayerMask obstacleLayer = -1;

	public float minSpawnDistance = 15f;

	public float maxSpawnDistance = 30f;

	public float spawnInterval = 5f;

	public int maxSpawnAttempts = 20;

	[Tooltip("Zemin raycast'i için yukarıdan ne kadar taranacağı")]
	public float groundCheckDistance = 10f;

	[Tooltip("Bu açıdan dik yamaçlara spawn edilmez")]
	public float slopeCheckAngle = 45f;

	[Space(12f)]
	[Header("═══ EMERGE ANIMATION ═══")]
	[Tooltip("Kapalıyken zombiler yerden çıkma animasyonu/partikülü olmadan anında belirir. Görüş dışında spawn ile birlikte kullanmak için kapalı bırakın.")]
	public bool useEmergeAnimation;

	[Space(12f)]
	[Header("═══ SPAWN OUT OF VIEW ═══")]
	[Tooltip("Açıkken zombiler oyuncunun bakış konisi içinde spawn olmaz; hep görüş dışında (arkada/yanda) doğar.")]
	public bool spawnOutOfPlayerView = true;

	[Tooltip("Bakış konisinin yatay yarı açısı (derece). Aday nokta bu açının içindeyse görünür sayılıp reddedilir. Kamera FOV'undan biraz geniş tutun.")]
	[Range(0f, 180f)]
	public float viewConeHalfAngle = 70f;

	[Tooltip("Oyuncunun göz yüksekliği (pivotundan yukarı). Bakış konisi bu noktadan hesaplanır.")]
	public float viewEyeHeight = 1.6f;

	[Tooltip("Açıkken bakış konisi içinde olsa bile araya engel (duvar/kaya) giriyorsa nokta görünmez sayılır ve spawn'a izin verilir.")]
	public bool useLineOfSightCheck;

	[Space(12f)]
	[Header("═══ TRAIN SPAWN ═══")]
	[Tooltip("Zombie spawn noktası olarak sayılacak tren. Atanmazsa tren hedeflenmez.")]
	public TrainController trainSpawnTarget;

	[Tooltip("Trene göre minimum spawn mesafesi")]
	public float trainMinSpawnDistance = 15f;

	[Tooltip("Trene göre maksimum spawn mesafesi")]
	public float trainMaxSpawnDistance = 30f;

	[Space(12f)]
	[Header("═══ NIGHT RAID ═══")]
	[Tooltip("Ayni gece penceresinde sadece bir raid dalgasi olusturur. Olen zombiler o gece yeniden spawn olmaz.")]
	public bool oneRaidPerNight = true;

	[SerializeField]
	private int nightRaidSpawnQuota;

	[SerializeField]
	private int nightRaidSpawnedCount;

	[SerializeField]
	private bool wasInSpawnWindow;

	[Space(12f)]
	[Header("═══ DAY-BASED LIMITS ═══")]
	public List<ZombieSpawnDayRange> dayRangeSpawnLimits = new List<ZombieSpawnDayRange>();

	public int defaultMaxZombiesPerPlayer = 5;

	[Space(12f)]
	[Header("═══ TIME-BASED LIMITS (Real Play Time) ═══")]
	[Tooltip("Gerçek oyun süresine göre zombi limitleri (dakika cinsinden)")]
	public List<ZombieSpawnTimeRange> timeRangeSpawnLimits = new List<ZombieSpawnTimeRange>();

	public int defaultTimeMaxZombiesPerPlayer;

	[Space(12f)]
	[Header("═══ TIME SETTINGS (Day/Night) ═══")]
	public AzureTimeController azureTimeController;

	public bool spawnOnlyAtNight = true;

	[Range(0f, 24f)]
	public float nightStartHour = 20f;

	[Range(0f, 24f)]
	public float nightEndHour = 6f;

	[Space(12f)]
	[Header("═══ SPAWN POINTS & RUNTIME ═══")]
	[Min(0.1f)]
	public float spawnPointCheckInterval = 0.5f;

	[SerializeField]
	private List<ZombieSpawnPoint> registeredSpawnPoints = new List<ZombieSpawnPoint>();

	[SerializeField]
	private List<TSPlayerController> activePlayers = new List<TSPlayerController>();

	[Space(12f)]
	[Header("═══ CHEAT SPAWN (X = yanına, J = trene) ═══")]
	[Tooltip("Cheat ile spawn olan zombinin oyuncuya min mesafesi")]
	public float cheatMinSpawnDistance = 4f;

	[Tooltip("Cheat ile spawn olan zombinin oyuncuya max mesafesi")]
	public float cheatMaxSpawnDistance = 10f;

	[Tooltip("Cheat zombisi saldırsın mı? false = peaceful")]
	public bool cheatZombieAggressive = true;

	[Tooltip("Cheat ile doğan zombinin canı (test için yüksek tutulur). 0 veya negatif = prefab değerini kullan.")]
	public float cheatZombieHealth = 750f;

	[Space(12f)]
	[Header("═══ TEST MODE ═══")]
	[Tooltip("Açıkken normal spawn loop yerine test loop çalışır: belirli aralıkla oyuncunun yakınında peaceful zombi spawn eder")]
	public bool testMode;

	[Tooltip("Test modunda iki spawn arası saniye (random aralık)")]
	public Vector2 testSpawnIntervalRange = new Vector2(5f, 10f);

	[Tooltip("Oyuncuya göre min/max test spawn mesafesi")]
	public float testMinSpawnDistance = 4f;

	public float testMaxSpawnDistance = 10f;

	[Tooltip("Test zombileri saldırmasın (peaceful)")]
	public bool testPeaceful = true;

	[Tooltip("Test modunda aynı anda max canlı zombi sayısı")]
	public int testMaxZombies = 2;

	[Tooltip("True olduğunda testMaxZombies sınırı yok sayılır — sınırsız test spawn")]
	public bool ignoreTestZombieLimit;

	private Coroutine spawnCoroutine;

	private Coroutine spawnPointCoroutine;

	private Coroutine testSpawnCoroutine;

	public static ZombieSpawner Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogWarning("Multiple ZombieSpawner instances detected!");
		}
	}

	private void Start()
	{
		if (azureTimeController == null)
		{
			azureTimeController = Object.FindObjectOfType<AzureTimeController>();
		}
		if (base.isServer)
		{
			if (!spawningEnabled)
			{
				Debug.Log("[ZombieSpawner " + biomeID + "] spawningEnabled = false, hiç zombi doğmayacak.");
			}
			else if (testMode)
			{
				StartTestSpawning();
			}
			else
			{
				StartSpawning();
			}
		}
	}

	[Server]
	public void StartSpawning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ZombieSpawner::StartSpawning()' called when server was not active");
			return;
		}
		if (spawnCoroutine != null)
		{
			StopCoroutine(spawnCoroutine);
		}
		if (spawnPointCoroutine != null)
		{
			StopCoroutine(spawnPointCoroutine);
		}
		spawnCoroutine = StartCoroutine(SpawnLoop());
		spawnPointCoroutine = StartCoroutine(SpawnPointLoop());
	}

	[Server]
	public void StopSpawning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ZombieSpawner::StopSpawning()' called when server was not active");
			return;
		}
		if (spawnCoroutine != null)
		{
			StopCoroutine(spawnCoroutine);
			spawnCoroutine = null;
		}
		if (spawnPointCoroutine != null)
		{
			StopCoroutine(spawnPointCoroutine);
			spawnPointCoroutine = null;
		}
		if (testSpawnCoroutine != null)
		{
			StopCoroutine(testSpawnCoroutine);
			testSpawnCoroutine = null;
		}
	}

	[Server]
	public void StartTestSpawning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ZombieSpawner::StartTestSpawning()' called when server was not active");
			return;
		}
		if (testSpawnCoroutine != null)
		{
			StopCoroutine(testSpawnCoroutine);
		}
		testSpawnCoroutine = StartCoroutine(TestSpawnLoop());
	}

	private IEnumerator TestSpawnLoop()
	{
		yield return new WaitForSeconds(2f);
		while (true)
		{
			float seconds = Random.Range(testSpawnIntervalRange.x, testSpawnIntervalRange.y);
			yield return new WaitForSeconds(seconds);
			EnsureActivePlayers();
			TSPlayerController randomAwakePlayer = GetRandomAwakePlayer();
			if (randomAwakePlayer == null || (!ignoreTestZombieLimit && GetZombieCountForThisSpawner() >= testMaxZombies))
			{
				continue;
			}
			ZombieSpawnData zombieSpawnData = spawnData;
			if (zombieSpawnData == null)
			{
				Debug.LogWarning("[ZombieSpawner TEST] " + biomeID + ": spawnData atanmamış, spawn atlanıyor");
			}
			else
			{
				if (!GetValidSpawnPosition(randomAwakePlayer.transform.position, out var spawnPosition, testMinSpawnDistance, testMaxSpawnDistance))
				{
					continue;
				}
				GameObject randomZombie = zombieSpawnData.GetRandomZombie();
				if (!(randomZombie == null))
				{
					GameObject obj = Object.Instantiate(randomZombie, spawnPosition, Quaternion.identity);
					obj.transform.SetParent(base.transform);
					ZombieController component = obj.GetComponent<ZombieController>();
					if (component != null)
					{
						mySpawnedZombies.Add(component);
						component.peacefulMode = testPeaceful;
					}
					if (useEmergeAnimation && component != null && component.emergeOnSpawn)
					{
						component.PrepareEmergeUnderground(spawnPosition);
					}
					NetworkServer.Spawn(obj);
					if (useEmergeAnimation && component != null && component.emergeOnSpawn)
					{
						component.StartEmerge(spawnPosition);
					}
				}
			}
		}
	}

	private IEnumerator SpawnLoop()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnInterval);
			EnsureActivePlayers();
			if (!IsSpawnTime())
			{
				wasInSpawnWindow = false;
				continue;
			}
			if (oneRaidPerNight)
			{
				if (!wasInSpawnWindow)
				{
					InitializeNightRaidQuota();
					wasInSpawnWindow = true;
				}
				int num = nightRaidSpawnQuota - nightRaidSpawnedCount;
				if (num <= 0)
				{
					continue;
				}
				for (int i = 0; i < num; i++)
				{
					int awakePlayerCount = GetAwakePlayerCount();
					int trainTargetCount = GetTrainTargetCount();
					int num2 = awakePlayerCount + trainTargetCount;
					if (num2 == 0)
					{
						break;
					}
					bool flag;
					if (awakePlayerCount > 0 && Random.Range(0, num2) < awakePlayerCount)
					{
						TSPlayerController randomAwakePlayer = GetRandomAwakePlayer();
						flag = randomAwakePlayer != null && SpawnZombieForPlayer(randomAwakePlayer);
					}
					else
					{
						flag = SpawnZombieNearTrain();
					}
					if (!flag)
					{
						break;
					}
					nightRaidSpawnedCount++;
				}
				continue;
			}
			int maxZombiesForCurrentDay = GetMaxZombiesForCurrentDay();
			int maxZombiesForPlayedTime = GetMaxZombiesForPlayedTime();
			int num3 = Mathf.Max(maxZombiesForCurrentDay, maxZombiesForPlayedTime);
			int zombieCountForThisSpawner = GetZombieCountForThisSpawner();
			int awakePlayerCount2 = GetAwakePlayerCount();
			int trainTargetCount2 = GetTrainTargetCount();
			int num4 = awakePlayerCount2 + trainTargetCount2;
			int num5 = num3 * awakePlayerCount2;
			if (zombieCountForThisSpawner >= num5 || num4 <= 0)
			{
				continue;
			}
			if (awakePlayerCount2 > 0 && Random.Range(0, num4) < awakePlayerCount2)
			{
				TSPlayerController randomAwakePlayer2 = GetRandomAwakePlayer();
				if (randomAwakePlayer2 != null)
				{
					SpawnZombieForPlayer(randomAwakePlayer2);
				}
			}
			else
			{
				SpawnZombieNearTrain();
			}
		}
	}

	private int GetMaxZombiesForCurrentDay()
	{
		int currentDay = TrainGameManager.Instance.currentDay;
		foreach (ZombieSpawnDayRange dayRangeSpawnLimit in dayRangeSpawnLimits)
		{
			if (currentDay >= dayRangeSpawnLimit.startDay && currentDay <= dayRangeSpawnLimit.endDay)
			{
				return dayRangeSpawnLimit.maxZombiesPerPlayer;
			}
		}
		return defaultMaxZombiesPerPlayer;
	}

	private int GetMaxZombiesForPlayedTime()
	{
		float num = TrainGameManager.Instance.totalPlayedSeconds / 60f;
		foreach (ZombieSpawnTimeRange timeRangeSpawnLimit in timeRangeSpawnLimits)
		{
			bool num2 = num >= timeRangeSpawnLimit.minPlayedMinutes;
			bool flag = timeRangeSpawnLimit.maxPlayedMinutes <= 0f || num <= timeRangeSpawnLimit.maxPlayedMinutes;
			if (num2 && flag)
			{
				return timeRangeSpawnLimit.maxZombiesPerPlayer;
			}
		}
		return defaultTimeMaxZombiesPerPlayer;
	}

	private ZombieSpawnData GetCurrentSpawnData()
	{
		int currentDay = TrainGameManager.Instance.currentDay;
		foreach (ZombieSpawnDayRange dayRangeSpawnLimit in dayRangeSpawnLimits)
		{
			if (currentDay >= dayRangeSpawnLimit.startDay && currentDay <= dayRangeSpawnLimit.endDay)
			{
				if (dayRangeSpawnLimit.overrideSpawnData != null)
				{
					return dayRangeSpawnLimit.overrideSpawnData;
				}
				break;
			}
		}
		float num = TrainGameManager.Instance.totalPlayedSeconds / 60f;
		foreach (ZombieSpawnTimeRange timeRangeSpawnLimit in timeRangeSpawnLimits)
		{
			bool num2 = num >= timeRangeSpawnLimit.minPlayedMinutes;
			bool flag = timeRangeSpawnLimit.maxPlayedMinutes <= 0f || num <= timeRangeSpawnLimit.maxPlayedMinutes;
			if (num2 && flag)
			{
				if (timeRangeSpawnLimit.overrideSpawnData != null)
				{
					return timeRangeSpawnLimit.overrideSpawnData;
				}
				break;
			}
		}
		return spawnData;
	}

	private bool IsSpawnTime()
	{
		if (!spawnOnlyAtNight)
		{
			return true;
		}
		if (azureTimeController == null)
		{
			return false;
		}
		Vector2 timeOfDay = azureTimeController.GetTimeOfDay();
		float num = timeOfDay.x + timeOfDay.y / 60f;
		if (nightStartHour > nightEndHour)
		{
			if (!(num >= nightStartHour))
			{
				return num <= nightEndHour;
			}
			return true;
		}
		if (num >= nightStartHour)
		{
			return num <= nightEndHour;
		}
		return false;
	}

	[Server]
	private bool SpawnZombieForPlayer(TSPlayerController player)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean ZombieSpawner::SpawnZombieForPlayer(TSPlayerController)' called when server was not active");
			return default(bool);
		}
		if (player == null)
		{
			return false;
		}
		ZombieSpawnData currentSpawnData = GetCurrentSpawnData();
		if (currentSpawnData == null)
		{
			Debug.LogWarning("SpawnData is null on " + base.gameObject.name);
			return false;
		}
		if (GetValidSpawnPosition(player.transform.position, out var spawnPosition))
		{
			GameObject randomZombie = currentSpawnData.GetRandomZombie();
			if (randomZombie != null)
			{
				GameObject obj = Object.Instantiate(randomZombie, spawnPosition, Quaternion.identity);
				obj.transform.SetParent(base.transform);
				ZombieController component = obj.GetComponent<ZombieController>();
				if (component != null)
				{
					mySpawnedZombies.Add(component);
				}
				if (useEmergeAnimation && component != null && component.emergeOnSpawn)
				{
					component.PrepareEmergeUnderground(spawnPosition);
				}
				NetworkServer.Spawn(obj);
				if (useEmergeAnimation && component != null && component.emergeOnSpawn)
				{
					component.StartEmerge(spawnPosition);
				}
				return true;
			}
		}
		return false;
	}

	[Server]
	public bool CheatSpawnZombieNear(Vector3 origin)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean ZombieSpawner::CheatSpawnZombieNear(UnityEngine.Vector3)' called when server was not active");
			return default(bool);
		}
		ZombieSpawnData currentSpawnData = GetCurrentSpawnData();
		if (currentSpawnData == null)
		{
			Debug.LogWarning("[ZombieSpawner CHEAT] " + biomeID + ": spawnData null, cheat spawn atlanıyor.");
			return false;
		}
		if (!GetValidSpawnPosition(origin, out var spawnPosition, cheatMinSpawnDistance, cheatMaxSpawnDistance))
		{
			Vector2 vector = Random.insideUnitCircle.normalized * cheatMinSpawnDistance;
			spawnPosition = SnapToGround(origin + new Vector3(vector.x, 0f, vector.y));
		}
		GameObject randomZombie = currentSpawnData.GetRandomZombie();
		if (randomZombie == null)
		{
			return false;
		}
		GameObject obj = Object.Instantiate(randomZombie, spawnPosition, Quaternion.identity);
		obj.transform.SetParent(base.transform);
		ZombieController component = obj.GetComponent<ZombieController>();
		if (component != null)
		{
			mySpawnedZombies.Add(component);
			component.peacefulMode = !cheatZombieAggressive;
			if (cheatZombieHealth > 0f)
			{
				component.maxHp = cheatZombieHealth;
			}
		}
		if (useEmergeAnimation && component != null && component.emergeOnSpawn)
		{
			component.PrepareEmergeUnderground(spawnPosition);
		}
		NetworkServer.Spawn(obj);
		if (useEmergeAnimation && component != null && component.emergeOnSpawn)
		{
			component.StartEmerge(spawnPosition);
		}
		Debug.Log($"[ZombieSpawner CHEAT] Zombi spawn edildi: {spawnPosition}");
		return true;
	}

	public static void RegisterZombie(ZombieController zombie)
	{
		if (zombie != null)
		{
			allActiveZombies.Add(zombie);
		}
	}

	public static void UnregisterZombie(ZombieController zombie)
	{
		if (zombie != null)
		{
			allActiveZombies.Remove(zombie);
		}
	}

	private bool GetValidSpawnPosition(Vector3 playerPosition, out Vector3 spawnPosition)
	{
		return GetValidSpawnPosition(playerPosition, out spawnPosition, minSpawnDistance, maxSpawnDistance);
	}

	private bool GetValidSpawnPosition(Vector3 origin, out Vector3 spawnPosition, float minDist, float maxDist)
	{
		spawnPosition = Vector3.zero;
		for (int i = 0; i < maxSpawnAttempts; i++)
		{
			Vector2 normalized = Random.insideUnitCircle.normalized;
			float num = Random.Range(minDist, maxDist);
			Vector3 position = origin + new Vector3(normalized.x, 0f, normalized.y) * num;
			if (IsValidGroundPosition(ref position) && (!spawnOutOfPlayerView || !IsVisibleToAnyPlayer(position)))
			{
				spawnPosition = position;
				return true;
			}
		}
		return false;
	}

	private bool IsVisibleToAnyPlayer(Vector3 worldPos)
	{
		EnsureActivePlayers();
		foreach (TSPlayerController activePlayer in activePlayers)
		{
			if (!(activePlayer == null) && !activePlayer.isSleeping && IsPositionInPlayerView(activePlayer, worldPos))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsPositionInPlayerView(TSPlayerController player, Vector3 worldPos)
	{
		Vector3 vector = player.transform.position + Vector3.up * viewEyeHeight;
		Camera activeCamera = player.activeCamera;
		Vector3 vector2 = ((!(activeCamera != null) || !activeCamera.isActiveAndEnabled) ? player.transform.forward : activeCamera.transform.forward);
		Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.z);
		Vector3 to = new Vector3(worldPos.x - vector.x, 0f, worldPos.z - vector.z);
		if (vector3.sqrMagnitude < 0.0001f || to.sqrMagnitude < 0.0001f)
		{
			return false;
		}
		if (Vector3.Angle(vector3, to) > viewConeHalfAngle)
		{
			return false;
		}
		if (useLineOfSightCheck)
		{
			Vector3 vector4 = worldPos + Vector3.up * 1f - vector;
			float magnitude = vector4.magnitude;
			if (magnitude > 0.01f && Physics.Raycast(vector, vector4.normalized, magnitude, obstacleLayer))
			{
				return false;
			}
		}
		return true;
	}

	[Server]
	private bool SpawnZombieNearTrain()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean ZombieSpawner::SpawnZombieNearTrain()' called when server was not active");
			return default(bool);
		}
		if (trainSpawnTarget == null)
		{
			return false;
		}
		ZombieSpawnData currentSpawnData = GetCurrentSpawnData();
		if (currentSpawnData == null)
		{
			return false;
		}
		if (GetValidSpawnPosition(trainSpawnTarget.transform.position, out var spawnPosition, trainMinSpawnDistance, trainMaxSpawnDistance))
		{
			GameObject randomZombie = currentSpawnData.GetRandomZombie();
			if (randomZombie != null)
			{
				GameObject obj = Object.Instantiate(randomZombie, spawnPosition, Quaternion.identity);
				obj.transform.SetParent(base.transform);
				ZombieController component = obj.GetComponent<ZombieController>();
				if (component != null)
				{
					mySpawnedZombies.Add(component);
				}
				if (useEmergeAnimation && component != null && component.emergeOnSpawn)
				{
					component.PrepareEmergeUnderground(spawnPosition);
				}
				NetworkServer.Spawn(obj);
				if (useEmergeAnimation && component != null && component.emergeOnSpawn)
				{
					component.StartEmerge(spawnPosition);
				}
				return true;
			}
		}
		return false;
	}

	private Vector3 SnapToGround(Vector3 position)
	{
		if (Physics.Raycast(position + Vector3.up * groundCheckDistance, Vector3.down, out var hitInfo, groundCheckDistance * 2f, groundLayer))
		{
			return hitInfo.point;
		}
		return position;
	}

	private bool IsValidGroundPosition(ref Vector3 position)
	{
		if (Physics.Raycast(position + Vector3.up * groundCheckDistance, Vector3.down, out var hitInfo, groundCheckDistance * 2f, groundLayer) && Vector3.Angle(hitInfo.normal, Vector3.up) <= slopeCheckAngle)
		{
			Vector3 point = hitInfo.point;
			if (!Physics.CheckSphere(point + Vector3.up * 0.5f, 1f, obstacleLayer))
			{
				position = point;
				return true;
			}
		}
		return false;
	}

	private int GetZombieCountForThisSpawner()
	{
		mySpawnedZombies.RemoveWhere((ZombieController z) => z == null || z.isDeath);
		return mySpawnedZombies.Count;
	}

	private int GetTrainTargetCount()
	{
		if (trainSpawnTarget == null)
		{
			return 0;
		}
		if (TrainGameManager.Instance.currentDay <= 1)
		{
			return 0;
		}
		return 1;
	}

	private void InitializeNightRaidQuota()
	{
		nightRaidSpawnedCount = 0;
		int maxZombiesForCurrentDay = GetMaxZombiesForCurrentDay();
		int maxZombiesForPlayedTime = GetMaxZombiesForPlayedTime();
		int num = Mathf.Max(maxZombiesForCurrentDay, maxZombiesForPlayedTime);
		int awakePlayerCount = GetAwakePlayerCount();
		nightRaidSpawnQuota = Mathf.Max(0, num * awakePlayerCount);
	}

	private int GetAwakePlayerCount()
	{
		int num = 0;
		foreach (TSPlayerController activePlayer in activePlayers)
		{
			if (activePlayer != null && !activePlayer.isSleeping)
			{
				num++;
			}
		}
		return num;
	}

	private TSPlayerController GetRandomAwakePlayer()
	{
		int awakePlayerCount = GetAwakePlayerCount();
		if (awakePlayerCount <= 0)
		{
			return null;
		}
		int num = Random.Range(0, awakePlayerCount);
		int num2 = 0;
		foreach (TSPlayerController activePlayer in activePlayers)
		{
			if (!(activePlayer == null) && !activePlayer.isSleeping)
			{
				if (num2 == num)
				{
					return activePlayer;
				}
				num2++;
			}
		}
		return null;
	}

	private void CheckSpawnPoints()
	{
		registeredSpawnPoints.RemoveAll((ZombieSpawnPoint sp) => sp == null);
		if (spawnData == null)
		{
			return;
		}
		foreach (ZombieSpawnPoint registeredSpawnPoint in registeredSpawnPoints)
		{
			if (!(registeredSpawnPoint == null) && !registeredSpawnPoint.HasSpawnedZombie && (!registeredSpawnPoint.spawnOnlyNight || IsSpawnTime()) && CheckPlayerDistanceForSpawnPoint(registeredSpawnPoint))
			{
				SpawnZombieAtSpawnPoint(registeredSpawnPoint);
			}
		}
	}

	private bool CheckPlayerDistanceForSpawnPoint(ZombieSpawnPoint spawnPoint)
	{
		EnsureActivePlayers();
		foreach (TSPlayerController activePlayer in activePlayers)
		{
			if (!(activePlayer == null) && !activePlayer.isSleeping && Vector3.Distance(spawnPoint.transform.position, activePlayer.transform.position) <= spawnPoint.triggerDistance)
			{
				return true;
			}
		}
		return false;
	}

	private void EnsureActivePlayers()
	{
		activePlayers.RemoveAll((TSPlayerController p) => p == null);
		foreach (TSPlayerController allRegisteredPlayer in ZombieController.AllRegisteredPlayers)
		{
			if (allRegisteredPlayer != null && !activePlayers.Contains(allRegisteredPlayer))
			{
				activePlayers.Add(allRegisteredPlayer);
			}
		}
	}

	private IEnumerator SpawnPointLoop()
	{
		while (true)
		{
			float seconds = Mathf.Max(0.1f, spawnPointCheckInterval);
			yield return new WaitForSeconds(seconds);
			EnsureActivePlayers();
			CheckSpawnPoints();
		}
	}

	private void SpawnZombieAtSpawnPoint(ZombieSpawnPoint spawnPoint)
	{
		if (spawnPoint.HasSpawnedZombie || spawnData == null)
		{
			return;
		}
		GameObject gameObject = ((spawnPoint.overrideZombiePrefab != null) ? spawnPoint.overrideZombiePrefab : spawnData.GetRandomZombie());
		if (gameObject != null)
		{
			Vector3 vector = (spawnPoint.snapToGround ? SnapToGround(spawnPoint.transform.position) : spawnPoint.transform.position);
			GameObject obj = Object.Instantiate(gameObject, vector, spawnPoint.transform.rotation);
			obj.transform.SetParent(base.transform);
			ZombieController component = obj.GetComponent<ZombieController>();
			if (component != null)
			{
				spawnPoint.SetSpawnedZombie(component);
				spawnPointZombies.Add(component);
			}
			if (useEmergeAnimation && spawnPoint.useEmergeAnimation && component != null && component.emergeOnSpawn)
			{
				component.PrepareEmergeUnderground(vector);
			}
			NetworkServer.Spawn(obj);
			if (useEmergeAnimation && spawnPoint.useEmergeAnimation && component != null && component.emergeOnSpawn)
			{
				component.StartEmerge(vector);
			}
		}
		else
		{
			Debug.LogWarning("[ZombieSpawner " + biomeID + "] Spawn point " + spawnPoint.gameObject.name + " - Random zombie prefab null!");
		}
	}

	public void RegisterPlayer(TSPlayerController player)
	{
		if (player != null && !activePlayers.Contains(player))
		{
			activePlayers.Add(player);
		}
	}

	public void UnregisterPlayer(TSPlayerController player)
	{
		if (player != null && activePlayers.Contains(player))
		{
			activePlayers.Remove(player);
		}
	}

	public void RegisterSpawnPoint(ZombieSpawnPoint spawnPoint)
	{
		if (spawnPoint != null && !registeredSpawnPoints.Contains(spawnPoint))
		{
			registeredSpawnPoints.Add(spawnPoint);
		}
	}

	public void UnregisterSpawnPoint(ZombieSpawnPoint spawnPoint)
	{
		if (spawnPoint != null && registeredSpawnPoints.Contains(spawnPoint))
		{
			registeredSpawnPoints.Remove(spawnPoint);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
