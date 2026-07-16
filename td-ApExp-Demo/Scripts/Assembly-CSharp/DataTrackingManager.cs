using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DataTrackingManager : MonoBehaviour
{
	[SerializeField]
	private bool sendDataFromEditor;

	public static DataTrackingManager Instance;

	public RunData runData;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	public void SendData()
	{
		if (sendDataFromEditor)
		{
			StartCoroutine(SendRunDataCoroutine(runData));
		}
		else if (SaveManager.Instance.IsDataTrackingEnabled)
		{
			StartCoroutine(SendRunDataCoroutine(runData));
		}
	}

	public void InitializeFromGameManager(GameManager gameManager, bool atQuit = false)
	{
		if (atQuit)
		{
			SetRunEndCondition(runWon: false);
		}
		else
		{
			SetRunEndCondition(Train.Instance.HealthComponent.HealthCurrent > 0f);
		}
		SetQuitRun(atQuit);
		SetFinalHull(Train.Instance.HealthComponent.HealthCurrent);
		runData.modulesTaken = new List<string>();
		foreach (Module module in Train.Instance.Modules)
		{
			if (module != null && !(module is ModuleCannon) && !(module is ModuleDirectionLever) && !(module is ModuleFurnace) && !(module is ModuleClaw))
			{
				AddModule(module.GetType().Name);
			}
		}
		runData.upgradesTaken = new List<string>();
		foreach (EnhancementUpgrade item in UpgradeManager.Instance.UpgradesInInventory)
		{
			if (item != null)
			{
				AddUpgrade(item.name);
			}
		}
		runData.relicsTaken = new List<string>();
		EnhancementUpgrade[] relicsInInventory = UpgradeManager.Instance.RelicsInInventory;
		foreach (EnhancementUpgrade enhancementUpgrade in relicsInInventory)
		{
			if (enhancementUpgrade != null)
			{
				AddRelic(enhancementUpgrade.name);
			}
		}
		SetRunDuration(gameManager.playtimeInRun);
	}

	public void InitializeRunData()
	{
		runData = new RunData();
	}

	public void SetQuitRun(bool quit)
	{
		runData.runQuit = quit;
	}

	public void SetRunEndCondition(bool runWon)
	{
		runData.runWon = runWon;
	}

	public void AddModule(string module)
	{
		if (runData.modulesTaken == null)
		{
			runData.modulesTaken = new List<string>();
		}
		runData.modulesTaken.Add(module);
	}

	public void AddUpgrade(string upgrade)
	{
		if (runData.upgradesTaken == null)
		{
			runData.upgradesTaken = new List<string>();
		}
		runData.upgradesTaken.Add(upgrade);
	}

	public void AddRelic(string relic)
	{
		if (runData.relicsTaken == null)
		{
			runData.relicsTaken = new List<string>();
		}
		runData.relicsTaken.Add(relic);
	}

	public void AddRadarUpgrade(string radarUpgrade)
	{
		if (runData.radarUpgrades == null)
		{
			runData.radarUpgrades = new List<string>();
		}
		runData.radarUpgrades.Add(radarUpgrade);
	}

	public void AddLocationCountByType(LootType lootType)
	{
		switch (lootType)
		{
		case LootType.CannonUpgrade:
			runData.cannonLocations++;
			break;
		case LootType.Upgrade:
			runData.upgradeLocations++;
			break;
		case LootType.Module:
			runData.moduleLocations++;
			break;
		case LootType.Relic:
			runData.relicLocations++;
			break;
		case LootType.Shop:
			runData.shopLocations++;
			break;
		}
	}

	public void AddLocationCountByDifficulty(string difficulty)
	{
		switch (difficulty)
		{
		case "Easy":
			runData.easyLocations++;
			break;
		case "Medium":
			runData.mediumLocations++;
			break;
		case "Hard":
			runData.hardLocations++;
			break;
		}
	}

	public void AddScrapCollected(int scrap)
	{
		runData.scrapCollected += scrap;
	}

	public void AddScrapUsed(int scrap)
	{
		runData.scrapUsed += scrap;
	}

	public void AddScrapUsedWagons(int scrap)
	{
		runData.scrapUsedWagons += scrap;
	}

	public void AddScrapUsedAmmo(int scrap)
	{
		runData.scrapUsedAmmo += scrap;
	}

	public void AddScrapUsedRepair(int scrap)
	{
		runData.scrapUsedRepair += scrap;
	}

	public void AddScrapUsedUpgrades(int scrap)
	{
		runData.scrapUsedUpgrades += scrap;
	}

	public void AddAmmoCollected(int ammo)
	{
		runData.ammoCollected += ammo;
	}

	public void AddAmmoUsed(int ammo)
	{
		runData.ammoUsed += ammo;
	}

	public void AddScrapUsedAsAmmo(int scrap)
	{
		runData.scrapUsedAsAmmo += scrap;
	}

	public void AddBossesKilled(int bosses = 1)
	{
		runData.bossesKilled += bosses;
	}

	public void SetFinalHull(float hull)
	{
		runData.finalHull = hull;
	}

	public void SetLevelAtEnd(int level)
	{
		runData.levelAtEnd = level;
	}

	public void AddRegularDamageTaken(float damage)
	{
		runData.regularDamageTaken += damage;
	}

	public void AddHullDamageTaken(float damage)
	{
		runData.hullDamageTaken += damage;
	}

	public void AddDamageRepaired(float damage)
	{
		runData.damageRepaired += damage;
	}

	public void AddDamageByEnemy(string enemy, float damage)
	{
		if (runData.damageByEnemy == null)
		{
			runData.damageByEnemy = new Dictionary<string, float>();
		}
		if (runData.damageByEnemy.ContainsKey(enemy))
		{
			runData.damageByEnemy[enemy] += damage;
		}
		else
		{
			runData.damageByEnemy[enemy] = damage;
		}
	}

	public void AddModulesBroken(int modules = 1)
	{
		runData.modulesBroken += modules;
	}

	public void SetRunDuration(float duration)
	{
		runData.runDuration = duration;
	}

	public void AddRunToTotal()
	{
		runData.totalRuns++;
	}

	public void AddRunToTotalBeaten()
	{
		runData.totalRunsBeaten++;
	}

	public void SetCurrentCoreCount(int count)
	{
		runData.currentCoreCount = count;
	}

	public void AddCoreCount(int count = 1)
	{
		runData.currentCoreCount += count;
	}

	public IEnumerator SendRunDataCoroutine(RunData runData)
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			Debug.LogError("No internet connection. Cannot send run data.");
			yield return null;
			yield break;
		}
		JsonUtility.ToJson(runData, prettyPrint: true);
		string csv = ClassToCsvConverter.ToCsv(runData);
		try
		{
			SendEmailAsync(csv);
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to send run data: " + ex.Message);
		}
		yield return null;
	}

	private async Task SendEmailAsync(string csv)
	{
		await Task.Run(delegate
		{
			string addresses = "llamawaredatatracking@gmail.com";
			string text = "llamawaredatatracking@gmail.com";
			string host = "smtp.gmail.com";
			int port = 587;
			MailMessage message = new MailMessage
			{
				From = new MailAddress(text),
				To = { addresses },
				Subject = "RunData",
				Body = "",
				IsBodyHtml = false,
				Attachments = 
				{
					new Attachment(new MemoryStream(Encoding.UTF8.GetBytes(csv)), $"RunData_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.csv", "text/csv")
				}
			};
			SmtpClient smtpClient = new SmtpClient(host, port)
			{
				Credentials = new NetworkCredential(text, "pkhn xyru dpnt tsvx "),
				EnableSsl = true
			};
			try
			{
				smtpClient.Send(message);
				Debug.Log("Run data sent successfully.");
			}
			catch (Exception ex)
			{
				Debug.LogError("Error sending run data: " + ex.Message);
			}
		});
	}

	public void SetCoreCount(int count)
	{
		runData.currentCoreCount = count;
	}
}
