using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager instance;

	[SerializeField]
	private GameObject treasureChest;

	public Waypoint[] initialSpawns;

	private HashSet<Waypoint> spawnPoints = new HashSet<Waypoint>();

	public HashSet<IncomeGenerator> incomeGenerators = new HashSet<IncomeGenerator>();

	public HashSet<University> universities = new HashSet<University>();

	public HashSet<Mine> mines = new HashSet<Mine>();

	[SerializeField]
	private TowerFlyweight vampireTowers;

	public HashSet<House> houses = new HashSet<House>();

	public HashSet<GameObject> destroyOnNewLevel = new HashSet<GameObject>();

	public HashSet<GameObject> tileSpawnUis = new HashSet<GameObject>();

	public HashSet<Enemy> currentEnemies = new HashSet<Enemy>();

	public bool combat;

	private float levelTime;

	private bool enemiesLeftToSpawn;

	[SerializeField]
	private Text levelText;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private int cardDrawFrequency = 5;

	[SerializeField]
	private float baseRepairChance;

	public int level;

	public int lastLevel = 45;

	public bool monsterMode;

	public bool endless;

	[SerializeField]
	private GameObject level15Boss;

	[SerializeField]
	private GameObject level25Boss;

	[SerializeField]
	private GameObject level35Boss;

	[SerializeField]
	private GameObject level45Boss;

	[SerializeField]
	private GameObject endlessBoss;

	[SerializeField]
	private GameObject[] tier2Bosses;

	[SerializeField]
	private GameObject[] tier3Bosses;

	[SerializeField]
	private GameObject[] tier4Bosses;

	[SerializeField]
	private GameObject[] tier1;

	[SerializeField]
	private GameObject[] tier2;

	[SerializeField]
	private GameObject[] tier3;

	[SerializeField]
	private GameObject[] tier4;

	[SerializeField]
	private string[] tier2Names;

	[SerializeField]
	private string[] tier3Names;

	[SerializeField]
	private string[] tier4Names;

	public int[] tierClasses = new int[3];

	[SerializeField]
	private GameObject[] class21;

	[SerializeField]
	private GameObject[] class22;

	[SerializeField]
	private GameObject[] class23;

	[SerializeField]
	private GameObject[] class31;

	[SerializeField]
	private GameObject[] class32;

	[SerializeField]
	private GameObject[] class33;

	[SerializeField]
	private GameObject[] class41;

	[SerializeField]
	private GameObject[] class42;

	[SerializeField]
	private GameObject[] class43;

	[SerializeField]
	private string[] names21;

	[SerializeField]
	private string[] names22;

	[SerializeField]
	private string[] names23;

	[SerializeField]
	private string[] names31;

	[SerializeField]
	private string[] names32;

	[SerializeField]
	private string[] names33;

	[SerializeField]
	private string[] names41;

	[SerializeField]
	private string[] names42;

	[SerializeField]
	private string[] names43;

	[SerializeField]
	private LightManager lightManager;

	[SerializeField]
	private int secondStageLightLevel;

	[SerializeField]
	private int thirdStageLightLevel;

	[SerializeField]
	private int fourthStageLightLevel;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		Waypoint[] array = initialSpawns;
		foreach (Waypoint item in array)
		{
			spawnPoints.Add(item);
		}
		levelText.text = "Level: " + level;
		scoreText.text = "Score: " + 0;
		if (PlayerPrefs.GetInt("MonsterMode", 0) == 1)
		{
			monsterMode = true;
		}
		else
		{
			monsterMode = false;
		}
		cardDrawFrequency = 3 - PlayerPrefs.GetInt("CardFreq1", 0) - PlayerPrefs.GetInt("CardFreq2", 0);
		baseRepairChance = 34f * (float)(PlayerPrefs.GetInt("TowerRepair1", 0) + PlayerPrefs.GetInt("TowerRepair2", 0) + PlayerPrefs.GetInt("TowerRepair3", 0));
		SetTiers(0, 0, 0);
	}

	private void Update()
	{
		if (combat && currentEnemies.Count == 0 && !GameManager.instance.gameOver && levelTime > 2f && !enemiesLeftToSpawn)
		{
			EndWave();
		}
		else
		{
			levelTime += Time.deltaTime;
		}
	}

	public void SetTiers(int t2, int t3, int t4)
	{
		if (t2 < 1 || t2 > 3)
		{
			tierClasses[0] = Random.Range(1, 4);
		}
		else
		{
			tierClasses[0] = t2;
		}
		if (t3 < 1 || t3 > 3)
		{
			tierClasses[1] = Random.Range(1, 4);
		}
		else
		{
			tierClasses[1] = t2;
		}
		if (t4 < 1 || t4 > 3)
		{
			tierClasses[2] = Random.Range(1, 4);
		}
		else
		{
			tierClasses[2] = t2;
		}
		Debug.Log("Enemy Tiers: 1, " + tierClasses[0] + ", " + tierClasses[1] + ", " + tierClasses[2]);
		if (tierClasses[0] == 1)
		{
			tier2 = class21;
			tier2Names = names21;
		}
		else if (tierClasses[0] == 2)
		{
			tier2 = class22;
			tier2Names = names22;
		}
		else
		{
			tier2 = class23;
			tier2Names = names23;
		}
		if (tierClasses[1] == 1)
		{
			tier3 = class31;
			tier3Names = names31;
		}
		else if (tierClasses[1] == 2)
		{
			tier3 = class32;
			tier3Names = names32;
		}
		else
		{
			tier3 = class33;
			tier3Names = names33;
		}
		if (tierClasses[2] == 1)
		{
			tier4 = class41;
			tier4Names = names41;
		}
		else if (tierClasses[2] == 2)
		{
			tier4 = class42;
			tier4Names = names42;
		}
		else
		{
			tier4 = class43;
			tier4Names = names43;
		}
	}

	private void EndWave()
	{
		combat = false;
		AchievementManager.instance.BeatLevel(level);
		int num = PlayerPrefs.GetInt("XP", 0);
		PlayerPrefs.SetInt("XP", num + level * GameManager.instance.gameMode);
		scoreText.text = "Score: " + GameManager.instance.NaturalSum(level) * GameManager.instance.gameMode;
		if (level >= lastLevel && !endless)
		{
			GameManager.instance.Victory();
			return;
		}
		ShowSpawnUIs(state: true);
		if (level % cardDrawFrequency == 0)
		{
			ShowSpawnUIs(state: false);
			CardManager.instance.DrawCards();
			if (monsterMode)
			{
				CardManager.instance.DrawCards();
			}
		}
		if (monsterMode)
		{
			CardManager.instance.DrawMonsterCards();
		}
		if (level == 15 || level == 25 || level == 35)
		{
			MusicManager.instance.FadeOut(6f);
		}
		else
		{
			MusicManager.instance.SetIntensity(action: false);
		}
		GameObject[] array = new GameObject[destroyOnNewLevel.Count];
		destroyOnNewLevel.CopyTo(array);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			destroyOnNewLevel.Remove(gameObject);
			Object.Destroy(gameObject);
		}
		if (tileSpawnUis.Count == 0)
		{
			if (!endless)
			{
				Debug.Log("I GUESS ILL JUST DIE THEN");
				AchievementManager.instance.UnlockAchievement("NoMorePaths");
			}
			StartNextWave();
		}
	}

	public void StartNextWave()
	{
		levelTime = 0f;
		UpdateSpawnPoints();
		DamageTracker.instance.NewRound();
		float num = 1f - (float)(GameManager.instance.health / GameManager.instance.maxHealth);
		if (Random.Range(1f, 100f) <= baseRepairChance * num)
		{
			GameManager.instance.RepairTower(10);
		}
		level++;
		if (endless)
		{
			levelText.text = "Endless: " + level;
			MonsterManager.instance.EndlessBuff(level);
		}
		else
		{
			levelText.text = "Level: " + level;
		}
		if (level == secondStageLightLevel)
		{
			lightManager.ChangeColor(2);
		}
		else if (level == thirdStageLightLevel)
		{
			lightManager.ChangeColor(3);
		}
		else if (level == fourthStageLightLevel)
		{
			lightManager.ChangeColor(4);
		}
		else if (level == 46)
		{
			lightManager.ChangeColor(5);
		}
		if (level == 15 || level == 25 || level == 35 || level == 45 || (endless && level > 45 && level % 5 == 0))
		{
			SpawnBoss(level);
		}
		if (level > 16 && level % 2 == 1 && !endless)
		{
			SpawnMiniBoss(level - 1);
		}
		if (level == 16)
		{
			MusicManager.instance.PlaySong(1, action: true);
		}
		else if (level == 26)
		{
			MusicManager.instance.PlaySong(2, action: true);
		}
		else if (level == 36)
		{
			MusicManager.instance.PlaySong(3, action: true);
		}
		else if (level == 46)
		{
			MusicManager.instance.PlaySong(0, action: true);
		}
		else if (level > 1)
		{
			MusicManager.instance.SetIntensity(action: true);
		}
		StartCoroutine(Spawn(level * level));
		combat = true;
		ShowSpawnUIs(state: false);
		foreach (House house in houses)
		{
			if (house != null)
			{
				house.CheckTowers();
			}
		}
		foreach (IncomeGenerator incomeGenerator in incomeGenerators)
		{
			if (incomeGenerator != null)
			{
				incomeGenerator.GenerateIncome();
			}
		}
		foreach (University university in universities)
		{
			if (university != null)
			{
				university.Research();
			}
		}
		foreach (Mine mine in mines)
		{
			if (mine != null)
			{
				mine.Repair();
			}
		}
		foreach (Tower tower in vampireTowers.towers)
		{
			tower.GetComponent<VampireLair>().Repair();
		}
	}

	public void ShowSpawnUIs(bool state)
	{
		foreach (GameObject tileSpawnUi in tileSpawnUis)
		{
			tileSpawnUi.SetActive(state);
		}
	}

	private void SpawnBoss(int lvl)
	{
		Waypoint spawnLocation = null;
		float num = -1f;
		foreach (Waypoint spawnPoint in spawnPoints)
		{
			if (spawnPoint.distanceFromEnd > num)
			{
				num = spawnPoint.distanceFromEnd;
				spawnLocation = spawnPoint;
			}
		}
		switch (lvl)
		{
		case 15:
			SpawnEnemy(level15Boss, spawnLocation, 1);
			return;
		case 25:
		{
			GameObject unit2 = tier2Bosses[tierClasses[0] - 1];
			SpawnEnemy(unit2, spawnLocation, 1);
			return;
		}
		case 35:
		{
			GameObject unit = tier3Bosses[tierClasses[1] - 1];
			SpawnEnemy(unit, spawnLocation, 1);
			return;
		}
		case 45:
		{
			GameObject unit3 = tier4Bosses[tierClasses[2] - 1];
			SpawnEnemy(unit3, spawnLocation, 1);
			return;
		}
		}
		if (endless && lvl > 45 && lvl % 5 == 0)
		{
			SpawnEnemy(endlessBoss, spawnLocation, 1);
		}
	}

	private void SpawnMiniBoss(int monsterLevel)
	{
		Waypoint waypoint = null;
		Waypoint waypoint2 = null;
		float num = float.MaxValue;
		foreach (Waypoint spawnPoint in spawnPoints)
		{
			if (spawnPoint.distanceFromEnd < num)
			{
				waypoint2 = waypoint;
				num = spawnPoint.distanceFromEnd;
				waypoint = spawnPoint;
			}
		}
		Waypoint spawnLocation = ((!(waypoint2 != null)) ? waypoint : waypoint2);
		int num2 = (monsterLevel - 16) / 2;
		if (num2 < 5)
		{
			Enemy enemy = SpawnEnemy(tier2[num2], spawnLocation, 2);
			enemy.SetName(tier2Names[num2]);
			enemy.gameObject.transform.localScale = Vector3.one * 1.5f;
			enemy.damageToTower += 4;
			if (Random.Range(0f, 100f) < 50f)
			{
				enemy.deathObjectSpawn = treasureChest;
			}
		}
		else if (num2 < 10)
		{
			Enemy enemy2 = SpawnEnemy(tier3[num2 - 5], spawnLocation, 3);
			enemy2.SetName(tier3Names[num2 - 5]);
			enemy2.gameObject.transform.localScale = Vector3.one * 1.5f;
			enemy2.damageToTower += 4;
			if (Random.Range(0f, 100f) < 50f)
			{
				enemy2.deathObjectSpawn = treasureChest;
			}
		}
		else if (num2 < 15)
		{
			Enemy enemy3 = SpawnEnemy(tier4[num2 - 10], spawnLocation, 4);
			enemy3.SetName(tier4Names[num2 - 10]);
			enemy3.gameObject.transform.localScale = Vector3.one * 1.5f;
			enemy3.damageToTower += 4;
			if (Random.Range(0f, 100f) < 50f)
			{
				enemy3.deathObjectSpawn = treasureChest;
			}
		}
	}

	private IEnumerator Spawn(int num)
	{
		int safetyCount = level * level + 100;
		int count = num;
		enemiesLeftToSpawn = true;
		float t = 0.5f / (float)spawnPoints.Count;
		while (count > 0)
		{
			foreach (Waypoint spawnPoint in spawnPoints)
			{
				if (count <= 0)
				{
					break;
				}
				count -= SpawnSelection(spawnPoint);
				yield return new WaitForSeconds(t);
			}
			safetyCount--;
			if (safetyCount <= 0)
			{
				Debug.LogError("Spawn loop might be looping infinitely");
				break;
			}
		}
		enemiesLeftToSpawn = false;
	}

	private int SpawnSelection(Waypoint spawnPoint)
	{
		int num = 0;
		if (level >= 36)
		{
			num = SpawnFromArray(tier4, 4f, spawnPoint);
			if (num > 0)
			{
				return num;
			}
		}
		if (level >= 26)
		{
			num = SpawnFromArray(tier3, 3f, spawnPoint);
			if (num > 0)
			{
				return num;
			}
		}
		if (level >= 16)
		{
			num = SpawnFromArray(tier2, 2f, spawnPoint);
			if (num > 0)
			{
				return num;
			}
		}
		num = SpawnFromArray(tier1, 1f, spawnPoint);
		if (num <= 0)
		{
			Debug.LogError("Failed to Spawn minimum level enemy");
		}
		return num;
	}

	private int SpawnFromArray(GameObject[] array, float multiplier, Waypoint spawnPoint)
	{
		if (array.Length < 1)
		{
			Debug.LogError("Attempting to Spawn from empty array");
			return -1;
		}
		int result = 0;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			int num2 = array[num].GetComponent<Enemy>().level;
			if (num2 <= level && Random.Range(0f, 1f) < multiplier / (float)num2)
			{
				SpawnEnemy(array[num], spawnPoint, 1);
				result = Mathf.Max(Mathf.RoundToInt((float)num2 / multiplier), 1);
				break;
			}
		}
		return result;
	}

	private Enemy SpawnEnemy(GameObject unit, Waypoint spawnLocation, int multiplier)
	{
		Enemy component = Object.Instantiate(unit, spawnLocation.transform.position, Quaternion.identity).GetComponent<Enemy>();
		component.SetStats(multiplier);
		component.SetFirstSpawnPoint(spawnLocation);
		currentEnemies.Add(component);
		return component;
	}

	private void UpdateSpawnPoints()
	{
		List<Waypoint> list = new List<Waypoint>();
		List<Waypoint> list2 = new List<Waypoint>();
		foreach (Waypoint spawnPoint in spawnPoints)
		{
			if (!CheckSpawnPoint(spawnPoint))
			{
				continue;
			}
			list.Add(spawnPoint);
			foreach (Waypoint newSpawnPoint in GetNewSpawnPoints(spawnPoint, 1))
			{
				list2.Add(newSpawnPoint);
			}
		}
		foreach (Waypoint item in list)
		{
			spawnPoints.Remove(item);
		}
		foreach (Waypoint item2 in list2)
		{
			spawnPoints.Add(item2);
		}
	}

	private bool CheckSpawnPoint(Waypoint point)
	{
		if (point.GetPreviousWaypoints().Length != 0)
		{
			return true;
		}
		return false;
	}

	private List<Waypoint> GetNewSpawnPoints(Waypoint start, int count)
	{
		if (count > 100)
		{
			Debug.LogError("Possible infinite loop while finding new spawn points (count over 100)");
			return null;
		}
		Waypoint[] previousWaypoints = start.GetPreviousWaypoints();
		List<Waypoint> list = new List<Waypoint>();
		if (previousWaypoints.Length == 0)
		{
			list.Add(start);
			return list;
		}
		count++;
		Waypoint[] array = previousWaypoints;
		foreach (Waypoint start2 in array)
		{
			foreach (Waypoint newSpawnPoint in GetNewSpawnPoints(start2, count))
			{
				list.Add(newSpawnPoint);
			}
		}
		return list;
	}
}
