using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class AnalyticsLogger : MonoBehaviour
{
	public struct CaughtFishData
	{
		public string Name;

		public string Rarity;

		public int Level;
	}

	public enum LogEventType
	{
		Initial = 0,
		CaughtFish = 1,
		MissedFish = 2,
		BoughtUpgrade = 3,
		EndOfDay = 4,
		StatusSnapshot = 5,
		BoughtZone = 6,
		EnteredZone = 7
	}

	private string filePath;

	private static readonly string[] ColumnHeaders = new string[21]
	{
		"Timestamp", "TotalMoney", "ChangeAmount", "EventType", "FishName", "FishRarity", "FishValue", "FishXP", "SkillID", "SkillCost",
		"SkillLevel", "AreaID", "ExpeditionCount", "FishCaughtSummary", "MoneyGained", "PondLevel", "MoneyPerSec", "ClickDamage", "CurrentZoneLevel", "CurrentZoneXP",
		"CatchDuration"
	};

	private const int ColumnCount = 21;

	private List<string[]> logEntries = new List<string[]>();

	private float lastSaveTime;

	private float saveInterval = 60f;

	private readonly object fileLock = new object();

	private int upgradesBoughtSinceSnapshot;

	public static AnalyticsLogger Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
			string path = "money_log_" + text + ".csv";
			filePath = Path.Combine(Application.persistentDataPath, path);
			Debug.Log("Starting new analytics log file: " + filePath);
			StartCoroutine(LogInitialMoneyAfterFrame());
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (Time.realtimeSinceStartup - lastSaveTime > saveInterval)
		{
			SaveLog();
		}
	}

	private void OnApplicationQuit()
	{
		SaveLog();
	}

	private IEnumerator LogInitialMoneyAfterFrame()
	{
		yield return new WaitForEndOfFrame();
		double initialMoney = 0.0;
		if (GameManager.Instance != null)
		{
			initialMoney = GameManager.Instance.totalMoney;
		}
		else
		{
			Debug.LogWarning("AnalyticsLogger couldn't find GameManager to log initial money.");
		}
		LogGameStart(initialMoney);
	}

	private void LogGameStart(double initialMoney)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			initialMoney.ToString(CultureInfo.InvariantCulture),
			"0",
			LogEventType.Initial.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void TriggerStatusSnapshot()
	{
		double num = 0.0;
		double clickDamage = 0.0;
		int zoneLevel = 1;
		int zoneXp = 0;
		if (GameManager.Instance != null && GameManager.Instance.allZones != null && PlayerStats.Instance != null)
		{
			foreach (ZoneData allZone in GameManager.Instance.allZones)
			{
				num += (double)allZone.GetCurrentPassiveIncome();
			}
			num *= (double)PlayerStats.Instance.PassiveIncomeMultiplier;
			num += (double)PlayerStats.Instance.PassiveIncomeAdditive;
			clickDamage = PlayerStats.Instance.ReelInClickPower;
			if (GameManager.Instance.currentZone != null)
			{
				zoneLevel = GameManager.Instance.currentZone.currentLevel;
				zoneXp = GameManager.Instance.currentZone.currentXp;
			}
		}
		LogStatusSnapshot((GameManager.Instance != null) ? GameManager.Instance.totalMoney : 0.0, num, clickDamage, zoneLevel, zoneXp);
	}

	public void LogStatusSnapshot(double totalMoney, double moneyPerSec, double clickDamage, int zoneLevel, int zoneXp)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			totalMoney.ToString(CultureInfo.InvariantCulture),
			"0",
			LogEventType.StatusSnapshot.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			moneyPerSec.ToString(CultureInfo.InvariantCulture),
			clickDamage.ToString(CultureInfo.InvariantCulture),
			zoneLevel.ToString(CultureInfo.InvariantCulture),
			zoneXp.ToString(CultureInfo.InvariantCulture),
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void LogFishCaught(string fishName, string fishRarity, double currentTotalMoney, double fishValue, int fishXp, float catchDuration)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			currentTotalMoney.ToString(CultureInfo.InvariantCulture),
			fishValue.ToString(CultureInfo.InvariantCulture),
			LogEventType.CaughtFish.ToString(),
			fishName,
			fishRarity,
			fishValue.ToString(CultureInfo.InvariantCulture),
			fishXp.ToString(CultureInfo.InvariantCulture),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			catchDuration.ToString(CultureInfo.InvariantCulture)
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void LogUpgradeBought(string skillId, double cost, double moneyAfter, int skillLevel)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			moneyAfter.ToString(CultureInfo.InvariantCulture),
			(0.0 - cost).ToString(CultureInfo.InvariantCulture),
			LogEventType.BoughtUpgrade.ToString(),
			null,
			null,
			null,
			null,
			skillId,
			cost.ToString(CultureInfo.InvariantCulture),
			skillLevel.ToString(CultureInfo.InvariantCulture),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
		upgradesBoughtSinceSnapshot++;
		if (upgradesBoughtSinceSnapshot >= 5)
		{
			upgradesBoughtSinceSnapshot = 0;
			TriggerStatusSnapshot();
		}
	}

	public void LogZoneBought(string areaId, double cost, double moneyAfter)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			moneyAfter.ToString(CultureInfo.InvariantCulture),
			(0.0 - cost).ToString(CultureInfo.InvariantCulture),
			LogEventType.BoughtZone.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			areaId,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void LogZoneEntered(string areaId, double currentTotalMoney)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			currentTotalMoney.ToString(CultureInfo.InvariantCulture),
			"0",
			LogEventType.EnteredZone.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			areaId,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void LogEndOfDay(string areaId, int expeditionCount, List<CaughtFishData> fishCaught, double moneyGained, int pondLevel, double totalMoney)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			totalMoney.ToString(CultureInfo.InvariantCulture),
			moneyGained.ToString(CultureInfo.InvariantCulture),
			LogEventType.EndOfDay.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			areaId,
			expeditionCount.ToString(CultureInfo.InvariantCulture),
			SerializeFishSummary(fishCaught),
			moneyGained.ToString(CultureInfo.InvariantCulture),
			pondLevel.ToString(CultureInfo.InvariantCulture),
			null,
			null,
			null,
			null,
			null
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	public void LogFishMissed(string fishName, string fishRarity, double currentTotalMoney, double fishValue, int fishXp, float catchDuration = 0f)
	{
		string[] item = new string[21]
		{
			GetCurrentTimestamp(),
			currentTotalMoney.ToString(CultureInfo.InvariantCulture),
			"0",
			LogEventType.MissedFish.ToString(),
			fishName,
			fishRarity,
			fishValue.ToString(CultureInfo.InvariantCulture),
			fishXp.ToString(CultureInfo.InvariantCulture),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			catchDuration.ToString(CultureInfo.InvariantCulture)
		};
		lock (fileLock)
		{
			logEntries.Add(item);
		}
	}

	private string GetCurrentTimestamp()
	{
		return Time.time.ToString("F", CultureInfo.InvariantCulture);
	}

	private string SerializeFishSummary(List<CaughtFishData> fishCaught)
	{
		if (fishCaught == null || fishCaught.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < fishCaught.Count; i++)
		{
			CaughtFishData caughtFishData = fishCaught[i];
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}({1},Lvl{2})", caughtFishData.Name, caughtFishData.Rarity, caughtFishData.Level);
			if (i < fishCaught.Count - 1)
			{
				stringBuilder.Append(";");
			}
		}
		return stringBuilder.ToString();
	}

	private string EscapeCsvField(string field)
	{
		if (string.IsNullOrEmpty(field))
		{
			return "\"\"";
		}
		if (field.IndexOf(',') != -1 || field.IndexOf('"') != -1 || field.IndexOf('\n') != -1)
		{
			return "\"" + field.Replace("\"", "\"\"") + "\"";
		}
		return field;
	}

	public void SaveLog()
	{
		List<string[]> list = null;
		lock (fileLock)
		{
			if (logEntries.Count == 0)
			{
				return;
			}
			list = new List<string[]>(logEntries);
			logEntries.Clear();
		}
		if (list == null || list.Count == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			bool flag;
			lock (fileLock)
			{
				flag = File.Exists(filePath);
			}
			if (!flag)
			{
				stringBuilder.AppendLine(string.Join(",", ColumnHeaders));
			}
			foreach (string[] item in list)
			{
				for (int i = 0; i < item.Length; i++)
				{
					stringBuilder.Append(EscapeCsvField(item[i] ?? string.Empty));
					if (i < item.Length - 1)
					{
						stringBuilder.Append(",");
					}
				}
				stringBuilder.AppendLine();
			}
			lock (fileLock)
			{
				File.AppendAllText(filePath, stringBuilder.ToString());
			}
			lastSaveTime = Time.realtimeSinceStartup;
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to save analytics log: " + ex.Message);
			lock (fileLock)
			{
				logEntries.InsertRange(0, list);
			}
		}
	}
}
