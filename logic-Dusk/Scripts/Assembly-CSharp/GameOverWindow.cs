using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverWindow
{
	public void ShowWindow()
	{
		string rawText = GenerateText();
		LogUI.Instance.ShowWindow(">\n> Loading statistics", rawText, GlobalSettings.Constants.GAME_END_DEFAULT_COLOR, 3, 0.3f);
	}

	protected string GenerateText()
	{
		string empty = string.Empty;
		List<string> allGroups = GameSaveFile.GetAllGroups("STAT_");
		SortedList<int, string> sortedList = new SortedList<int, string>();
		int count = allGroups.Count;
		for (int i = 0; i < count; i++)
		{
			int num = GameSaveFile.Get(allGroups[i], "ST_CUR_DAYS", -1);
			num *= 10000;
			if (num <= -1)
			{
				continue;
			}
			if (sortedList.ContainsKey(num))
			{
				do
				{
					num++;
				}
				while (sortedList.ContainsKey(num));
			}
			sortedList.Add(num, allGroups[i]);
		}
		int num2 = GameSaveFile.Get("ST_CUR_DAYS", -1);
		num2 *= 10000;
		if (sortedList.ContainsKey(num2))
		{
			do
			{
				num2++;
			}
			while (sortedList.ContainsKey(num2));
		}
		sortedList.Add(num2, "NEW");
		IEnumerable<KeyValuePair<int, string>> source = sortedList.Reverse();
		List<KeyValuePair<int, string>> list = source.ToList();
		count = list.Count;
		List<string> list2 = new List<string>();
		if (count > 1)
		{
			for (int j = 1; j < 5; j++)
			{
				if (GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)j), 0) > GameSaveFile.Get("PREPLAY", string.Format("{0}_{1}", "ST_BST_ENKILL", (ShipInfestationType)j), 0))
				{
					list2.Add(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)j));
				}
			}
			for (int k = 1; k < 6; k++)
			{
				if (GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", (DungeonTypeEnum)k), 0) > GameSaveFile.Get("PREPLAY", string.Format("{0}_{1}", "ST_BST_VISITED", (DungeonTypeEnum)k), 0))
				{
					list2.Add(string.Format("{0}_{1}", "ST_CUR_VISITED", (DungeonTypeEnum)k));
				}
			}
			if (GameSaveFile.Get("ST_CUR_GAL_VISITED", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_GAL_VISITED", 0))
			{
				list2.Add("ST_CUR_GAL_VISITED");
			}
			for (int l = 1; l < 22; l++)
			{
				if (GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", (DroneUpgradeType)l), 0) > GameSaveFile.Get("PREPLAY", string.Format("{0}_{1}", "ST_BST_DUPG_USED", (DroneUpgradeType)l), 0))
				{
					list2.Add(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", (DroneUpgradeType)l));
				}
			}
			for (int m = 1; m < 12; m++)
			{
				if (GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", (ShipUpgradeType)m), 0) > GameSaveFile.Get("PREPLAY", string.Format("{0}_{1}", "ST_BST_SUPG_USED", (ShipUpgradeType)m), 0))
				{
					list2.Add(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", (ShipUpgradeType)m));
				}
			}
			if (GameSaveFile.Get("ST_CUR_SCRAP_COL", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_SCRAP_COL", 0))
			{
				list2.Add("ST_CUR_SCRAP_COL");
			}
			if (GameSaveFile.Get("ST_CUR_JFUEL_COL", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_JFUEL_COL", 0))
			{
				list2.Add("ST_CUR_JFUEL_COL");
			}
			if (GameSaveFile.Get("ST_CUR_PFUEL_COL", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_PFUEL_COL", 0))
			{
				list2.Add("ST_CUR_PFUEL_COL");
			}
			if (GameSaveFile.Get("ST_CUR_DRN_DEAD", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_DRN_DEAD", 0))
			{
				list2.Add("ST_CUR_DRN_DEAD");
			}
			if (GameSaveFile.Get("ST_CUR_SYS_VISITED", 0) > GameSaveFile.Get("PREPLAY", "ST_BST_SYS_VISITED", 0))
			{
				list2.Add("ST_CUR_SYS_VISITED");
			}
		}
		List<string> list3 = null;
		if (list2.Count > 0)
		{
			int num3 = 4;
			if (list2.Count < num3)
			{
				list3 = list2;
			}
			else
			{
				list3 = new List<string>(num3);
				int count2 = list2.Count;
				if (count2 < num3)
				{
					num3 = list2.Count;
				}
				do
				{
					int index = Random.Range(0, list2.Count);
					list3.Add(list2[index]);
					list2.RemoveAt(index);
					num3--;
				}
				while (num3 > 0);
			}
		}
		empty = ">\n>\n>===Top Campaigns===\n>\n>(Current in <color=#71b4ff>blue</color>)\n>\n";
		int num4 = 1;
		bool flag = false;
		for (int n = 0; n < count; n++)
		{
			if (num4 >= 6 && flag)
			{
				continue;
			}
			string value = list.ElementAt(n).Value;
			if (value != "NEW")
			{
				int num5 = -1;
				num5 = GameSaveFile.Get(value, "ST_CUR_DAYS", -1);
				if (num5 <= -1)
				{
					continue;
				}
				empty += string.Format("<color=#1aff11>===============================\n#{1}: Days Survived: {0}\n", num5, num4++);
				empty = empty + "> Ship Name: " + GameSaveFile.Get(value, "NAME", "UNKNOWN") + "\n";
				if (list3 != null)
				{
					int count3 = list3.Count;
					for (int num6 = 0; num6 < count3; num6++)
					{
						if (GameSaveFile.Get(value, list3[num6], 0) > 0)
						{
							string text = empty;
							empty = text + "> " + ConvertStatKeyToUserFriendly(list3[num6]) + ": " + GameSaveFile.Get(value, list3[num6], 0) + "\n";
						}
					}
				}
				empty += "</color>";
				continue;
			}
			int num7 = -1;
			if (GlobalSettings.GameState.ThePlayer != null)
			{
				num7 = GameSaveFile.Get("ST_CUR_DAYS", -1);
			}
			if (num4 < 6)
			{
				empty += string.Format("<color=#71b4ff>===============================\n#{1}: Days Survived: {0}\n", num7, num4++);
				flag = true;
			}
			else
			{
				empty += string.Format("<color=#71b4ff>===============================\n#Not Ranked: Days Survived: {0}\n", num7, num4++);
			}
			empty = empty + "> Ship Name: " + GlobalSettings.GameState.ThePlayer.MyShip.Name + "\n";
			if (list3 != null)
			{
				empty += "New Records:\n";
				int count4 = list3.Count;
				for (int num8 = 0; num8 < count4; num8++)
				{
					string text2 = " (was " + GameSaveFile.Get("PREPLAY", list3[num8].Replace("_CUR_", "_BST_"), 0) + ")";
					string text = empty;
					empty = text + "> " + ConvertStatKeyToUserFriendly(list3[num8]) + ": " + GameSaveFile.Get(list3[num8], 0) + text2 + "\n";
				}
			}
			empty += "</color>";
		}
		return empty + ">\n>\n>Entering hibernation mode...\n";
	}

	private string ConvertStatKeyToUserFriendly(string key)
	{
		switch (key)
		{
		case "ST_CUR_DUPG_USED_SpeedBoost":
			return "Ships Speed Boost Upgrades Used";
		case "ST_CUR_DUPG_USED_Generator":
			return "Ships Generator Upgrades Used";
		case "ST_CUR_DUPG_USED_Scanner":
			return "Ships Scanner Upgrades Used";
		case "ST_CUR_DUPG_USED_Interface":
			return "Ships Interface Upgrades Used";
		case "ST_CUR_DUPG_USED_Gatherer":
			return "Ships Gatherer Upgrades Used";
		case "ST_CUR_DUPG_USED_BruteTurret":
			return "Ships Turret Upgrades Used";
		case "ST_CUR_DUPG_USED_Sensor":
			return "Ships Sensor Upgrades Used";
		case "ST_CUR_DUPG_USED_Lure":
			return "Ships Lure Upgrades Used";
		case "ST_CUR_DUPG_USED_Trap":
			return "Ships Trap Upgrades Used";
		case "ST_CUR_DUPG_USED_Stun":
			return "Ships Stun Upgrades Used";
		case "ST_CUR_DUPG_USED_ProximityMine":
			return "Ships Mine Upgrades Used";
		case "ST_CUR_DUPG_USED_StealthField":
			return "Ships Stealth Upgrades Used";
		case "ST_CUR_DUPG_USED_Shield":
			return "Ships Shield Upgrades Used";
		case "ST_CUR_DUPG_USED_Teleporter":
			return "Ships Teleporter Upgrades Used";
		case "ST_CUR_DUPG_USED_Probe":
			return "Ships Probe Upgrades Used";
		case "ST_CUR_DUPG_USED_AreaSensor":
			return "Ships Motion Sensor Upgrades Used";
		case "ST_CUR_DUPG_USED_Sonic":
			return "Ships Sonic Upgrades Used";
		case "ST_CUR_DUPG_USED_Tow":
			return "Ships Tow Upgrades Used";
		case "ST_CUR_DUPG_USED_Pry":
			return "Ships Pry Upgrades Used";
		case "ST_CUR_SUPG_USED_ShipSurveyor":
			return "Ships Ship Surveyor Upgrades Used";
		case "ST_CUR_SUPG_USED_PowerManager":
			return "Ships Power Manager Upgrades Used";
		case "ST_CUR_SUPG_USED_Transporter":
			return "Ships Transporter Upgrades Used";
		case "ST_CUR_SUPG_USED_RemotePower":
			return "Ships Remote Power Upgrades Used";
		case "ST_CUR_SUPG_USED_LongRangeScanner":
			return "Ships Long Range Scanner Upgrades Used";
		case "ST_CUR_SUPG_USED_Quarantine":
			return "Ships Quarantine Upgrades Used";
		case "ST_CUR_SUPG_USED_PermCannon":
			return "Ships Cannon Upgrades Used";
		case "ST_CUR_SUPG_USED_PermDecontaminate":
			return "Ships Decontaminate Upgrades Used";
		case "ST_CUR_SUPG_USED_PermCollector":
			return "Ships Collector Upgrades Used";
		case "ST_CUR_SUPG_USED_PermSolder":
			return "Ships Solder Upgrades Used";
		case "ST_CUR_SUPG_USED_PermOverload":
			return "Ships Overload Upgrades Used";
		case "ST_CUR_SCRAP_COL":
			return "Scrap Collected";
		case "ST_CUR_JFUEL_COL":
			return "J-Fuel Collected";
		case "ST_CUR_PFUEL_COL":
			return "P-Fuel Collected";
		case "ST_CUR_DRN_DEAD":
			return "Dead Drones";
		case "ST_CUR_ENKILL_Swarm":
			return "Swarms Killed";
		case "ST_CUR_ENKILL_Brute":
			return "Brutes Killed";
		case "ST_CUR_ENKILL_Slime":
			return "Slimes Killed";
		case "ST_CUR_ENKILL_PatrolBot":
			return "Patrol Bots Killed";
		case "ST_CUR_VISITED_Derelict":
			return "Derelicts Visited";
		case "ST_CUR_VISITED_Outpost":
			return "Outposts Visited";
		case "ST_CUR_VISITED_Station":
			return "Stations Visited";
		case "ST_CUR_VISITED_AutoTrade":
			return "Trade Posts Visited";
		case "ST_CUR_VISITED_Stargate":
			return "Stargates Visited";
		case "ST_CUR_GAL_VISITED":
			return "Galaxies Visitied";
		case "ST_CUR_SYS_VISITED":
			return "Systems Visited";
		default:
			return string.Empty;
		}
	}

	protected string GenerateTextOld()
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		if (GlobalSettings.GameState.ThePlayer != null)
		{
			num = GlobalSettings.GameState.ThePlayer.DaysAlive;
			num2 = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		}
		num3 = UniverseSaveFile.Get("STAT_VDUN", 0);
		num4 = UniverseSaveFile.Get("STAT_VSYS", 0);
		int num5 = (int)GlobalSettings.MissionTime % 60;
		int num6 = (int)GlobalSettings.MissionTime / 60;
		int num7 = num6 / 60;
		num6 %= 60;
		int num8 = num;
		string result = string.Format(">\n>\n>===System Summary===\n>\n> Days Survived: {0}\n> Previous Best Days Survived: {8}\n> Ships Visited: {4}\n> Systems Visited: {5}\n> \n>===End of Summary===\n> \n>Entering hibernation mode...\n", num, num7, num6, num5, num3, num4, num2, num8, GlobalSettings.BestDaysSurvived);
		GlobalSettings.SubmitBestDaysSurvived(num8);
		return result;
	}
}
