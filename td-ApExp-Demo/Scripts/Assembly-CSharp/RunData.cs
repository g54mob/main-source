using System;
using System.Collections.Generic;

[Serializable]
public class RunData
{
	public bool runWon;

	public bool runQuit;

	public List<string> modulesTaken;

	public List<string> upgradesTaken;

	public List<string> relicsTaken;

	public List<string> radarUpgrades;

	public List<string> visitedLocations;

	public int easyLocations;

	public int mediumLocations;

	public int hardLocations;

	public int cannonLocations;

	public int moduleLocations;

	public int upgradeLocations;

	public int relicLocations;

	public int shopLocations;

	public int levelAtEnd;

	public int scrapCollected;

	public int scrapUsed;

	public int scrapUsedWagons;

	public int scrapUsedAmmo;

	public int scrapUsedRepair;

	public int scrapUsedUpgrades;

	public int ammoCollected;

	public int ammoUsed;

	public int scrapUsedAsAmmo;

	public int bossesKilled;

	public float finalHull;

	public float regularDamageTaken;

	public float hullDamageTaken;

	public float damageRepaired;

	public Dictionary<string, float> damageByEnemy;

	public int modulesBroken;

	public float runDuration;

	public int totalRuns;

	public int totalRunsBeaten;

	public int currentCoreCount;

	public RunData(bool runWon = false, List<string> modulesTaken = null, List<string> upgradesTaken = null, List<string> relicsTaken = null, List<string> radarUpgrades = null, List<string> visitedLocations = null, int easyLocations = 0, int normalLocations = 0, int hardLocations = 0, int scrapCollected = 0, int scrapUsed = 0, int scrapUsedWagons = 0, int scrapUsedAmmo = 0, int scrapUsedRepair = 0, int scrapUsedUpgrades = 0, int ammoCollected = 0, int ammoUsed = 0, int bossesKilled = 0, float finalHull = 0f, float totalDamageTaken = 0f, float hullDamageTaken = 0f, float damageRepaired = 0f, Dictionary<string, float> damageByEnemy = null, int modulesBroken = 0, float runDuration = 0f, int totalRuns = 0, int totalRunsBeaten = 0, int currentCoreCount = 0, int currentGameCount = 0, bool blank = true)
	{
		this.runWon = runWon;
		this.modulesTaken = modulesTaken ?? new List<string>();
		this.upgradesTaken = upgradesTaken ?? new List<string>();
		this.relicsTaken = relicsTaken ?? new List<string>();
		this.radarUpgrades = radarUpgrades ?? new List<string>();
		this.visitedLocations = visitedLocations ?? new List<string>();
		this.easyLocations = easyLocations;
		mediumLocations = normalLocations;
		this.hardLocations = hardLocations;
		this.scrapCollected = scrapCollected;
		this.scrapUsed = scrapUsed;
		this.scrapUsedWagons = scrapUsedWagons;
		this.scrapUsedAmmo = scrapUsedAmmo;
		this.scrapUsedRepair = scrapUsedRepair;
		this.scrapUsedUpgrades = scrapUsedUpgrades;
		this.ammoCollected = ammoCollected;
		this.ammoUsed = ammoUsed;
		this.bossesKilled = bossesKilled;
		this.finalHull = finalHull;
		regularDamageTaken = totalDamageTaken;
		this.hullDamageTaken = hullDamageTaken;
		this.damageRepaired = damageRepaired;
		this.damageByEnemy = damageByEnemy ?? new Dictionary<string, float>();
		this.modulesBroken = modulesBroken;
		this.runDuration = runDuration;
		this.totalRuns = totalRuns;
		this.totalRunsBeaten = totalRunsBeaten;
		this.currentCoreCount = currentCoreCount;
	}

	public RunData()
	{
		runWon = false;
		modulesTaken = new List<string>();
		upgradesTaken = new List<string>();
		relicsTaken = new List<string>();
		radarUpgrades = new List<string>();
		visitedLocations = new List<string>();
		easyLocations = 0;
		mediumLocations = 0;
		hardLocations = 0;
		cannonLocations = 0;
		moduleLocations = 0;
		upgradeLocations = 0;
		relicLocations = 0;
		shopLocations = 0;
		levelAtEnd = 0;
		scrapCollected = 0;
		scrapUsed = 0;
		scrapUsedWagons = 0;
		scrapUsedAmmo = 0;
		scrapUsedRepair = 0;
		scrapUsedUpgrades = 0;
		ammoCollected = 0;
		ammoUsed = 0;
		bossesKilled = 0;
		finalHull = 0f;
		regularDamageTaken = 0f;
		hullDamageTaken = 0f;
		damageRepaired = 0f;
		damageByEnemy = new Dictionary<string, float>();
		modulesBroken = 0;
		runDuration = 0f;
		totalRuns = 0;
		totalRunsBeaten = 0;
		currentCoreCount = 0;
	}
}
