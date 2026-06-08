using System.Collections.Generic;

public class DerelictStatisticsWindow
{
	private Dictionary<MissionState.StateDataTypeEnum, List<MissionState.ChangedDataStruct>> changedDataDict;

	public DerelictStatisticsWindow(ref MissionState missionStateStart, ref MissionState missionStateEnd)
	{
		changedDataDict = MissionState.CompareMissionStates(ref missionStateStart, ref missionStateEnd);
	}

	public void ShowWindow()
	{
		string text = GenerateText();
		LogManager.ReplaceVariables(ref text, true);
		LogUI.Instance.ShowWindow(">\n> Loading statistics", text, GlobalSettings.Constants.MISSION_SUMMARY_DEFAULT_COLOR, 2, 0.3f);
	}

	public void ForceText(string text)
	{
		LogUI.Instance.ForceText(text);
	}

	protected string GenerateText()
	{
		DroneManager instance = DroneManager.Instance;
		string text = "#8ed0ff";
		string text2 = "#7fff7f";
		int num = -1;
		int num2 = -1;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		foreach (Drone drones in instance.dronesList)
		{
			if (drones.CurrentRoom != null && (GlobalSettings.CommandeeringShip || drones.CurrentRoom.boardingVessel))
			{
				num3 += drones.GetLootCount();
				num4 += drones.GetPropulsionFuelCount();
				num5 += drones.GetJumpFuelCount();
			}
		}
		num = GameSaveFile.Get("ST_CUR_DAYS", 0);
		num2 = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		int scrapMax = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
		int pFuelMax = GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax;
		if (GlobalSettings.CommandeeringShip)
		{
			scrapMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax;
			pFuelMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax;
		}
		int num6 = num3;
		int num7 = DungeonManager.Instance.RationsAddedWhenCommandeering;
		if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num6 > scrapMax)
		{
			num6 -= GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num6 - scrapMax;
			if (num6 < 0)
			{
				num6 = 0;
			}
		}
		if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num6 + num7 > scrapMax)
		{
			num7 -= GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num6 + num7 - scrapMax;
			if (num7 < 0)
			{
				num7 = 0;
			}
		}
		int num8 = num6 + num2 + num7;
		int num9 = num4;
		int propulsionFuelAddedWhenCommandeering = DungeonManager.Instance.PropulsionFuelAddedWhenCommandeering;
		int num10 = num9 + GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel + propulsionFuelAddedWhenCommandeering;
		int num11 = num5 + GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel + DungeonManager.Instance.JumpFuelAddedWhenCommandeering;
		int num12 = (int)GlobalSettings.MissionTime / 60;
		num12 %= 60;
		string empty = string.Empty;
		string text3 = num6.ToString();
		string text4 = num4.ToString();
		string text5 = num5.ToString();
		string text6 = num7.ToString();
		string text7 = DungeonManager.Instance.PropulsionFuelAddedWhenCommandeering.ToString();
		string text8 = DungeonManager.Instance.JumpFuelAddedWhenCommandeering.ToString();
		text3 = ((num6 == 0) ? ("<color=" + text2 + ">" + text3 + "</color>") : ("<color=" + text + ">" + text3 + "</color>"));
		text4 = ((num4 == 0) ? ("<color=" + text2 + ">" + text4 + "</color>") : ("<color=" + text + ">" + text4 + "</color>"));
		text5 = ((num5 == 0) ? ("<color=" + text2 + ">" + text5 + "</color>") : ("<color=" + text + ">" + text5 + "</color>"));
		text6 = ((num7 == 0) ? ("<color=" + text2 + ">" + text6 + "</color>") : ("<color=" + text + ">" + text6 + "</color>"));
		text7 = ((propulsionFuelAddedWhenCommandeering == 0) ? ("<color=" + text2 + ">" + text7 + "</color>") : ("<color=" + text + ">" + text7 + "</color>"));
		text8 = ((DungeonManager.Instance.JumpFuelAddedWhenCommandeering == 0) ? ("<color=" + text2 + ">" + text8 + "</color>") : ("<color=" + text + ">" + text8 + "</color>"));
		empty = ((!GlobalSettings.CommandeeringShip) ? string.Format(">\n>\n>===Mission Summary===\n>\n>\n> P-Fuel collected:          {0,4}\t(you now have {1,4})\n>\n> J-Fuel collected:          {2,4}\t(you now have {3,4})\n>\n> Scrap collected:           {4,4}\t(you now have {5,4}/{7})\n> \n> Days Survived:          {6,4}\n", text4, num10, text5, num11, text3, num8, num, scrapMax) : string.Format(">\n>\n>===Mission Summary===\n>\n>\n> P-Fuel collected:          {5,4}\n> P-Fuel auto-harvested:     {6,4}\n> P-Fuel on Mothership:   {7,4}   [{13} (+{14})]\n>                         ====\n> Total P-Fuel:           {8,4}\n>\n> J-Fuel collected:          {9,4}\n> J-Fuel auto-harvested:     {10,4}\n> J-Fuel on Mothership:   {11,4}\n>                         ====\n> Total J-Fuel:           {12,4}\n>\n> Scrap collected:           {1,4}\n> Scrap auto-harvested:      {4,4}\n> Scrap on Mothership:    {2,4}\n>                         ====\n> Total Scrap:            {3,4}\n\n> Total Days Survived:    {0,4}\n", num, text3, num2, num8, text6, text4, text7, GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel, num10, text5, text8, GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel, num11, GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge, GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve));
		empty += ">\n>\n> Running Diagnostics...";
		empty += "\n>** Diagnostics Readout **\n>\n";
		string text9 = string.Empty;
		if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
		{
			text9 += CollectorPermUpgrade.Instance.GetMissionStatusString();
		}
		text9 += GetStringDataForType(MissionState.StateDataTypeEnum.ShipState);
		text9 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneStateChanged);
		text9 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneLostHealth);
		text9 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneUpgradeStateChanged);
		empty = (string.IsNullOrEmpty(text9) ? (empty + "> no data...\n") : (empty + text9 + ">\n"));
		empty += ">\n>** Inventory Change Readout **\n>\n";
		string empty2 = string.Empty;
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneFound);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneLost);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneUpgradeFound);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.DroneUpgradeLost);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.ShipUpgradeFound);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.ShipCommandeered);
		empty2 += GetStringDataForType(MissionState.StateDataTypeEnum.DbfPresence);
		empty = (string.IsNullOrEmpty(empty2) ? (empty + "> no data...\n") : (empty + empty2));
		return empty + ">\n>===End of Summary===\n";
	}

	private string GetStringDataForType(MissionState.StateDataTypeEnum dataType)
	{
		string text = string.Empty;
		if (changedDataDict.ContainsKey(dataType))
		{
			List<MissionState.ChangedDataStruct> list = changedDataDict[dataType];
			if (list.Count > 0)
			{
				foreach (MissionState.ChangedDataStruct item in list)
				{
					text = text + "> " + item.changeDesc + "\n";
					if (item.additionalInfo == null)
					{
						continue;
					}
					foreach (string item2 in item.additionalInfo)
					{
						text = text + ">    " + item2 + "\n";
					}
				}
			}
		}
		return text;
	}
}
