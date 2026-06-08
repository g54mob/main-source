public class UpgradeStats : StatCollection
{
	public override void Refresh()
	{
		bool flag = false;
		bool flag2 = ConfigFile.GetSetting("ShowFullStats") == "true";
		if (headerArray != null)
		{
			StatHeaderItem[] array = headerArray;
			foreach (StatHeaderItem statHeaderItem in array)
			{
				switch (statHeaderItem.name)
				{
				case "Motion":
				{
					double num27 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.AreaSensor), 0.0);
					if (num27 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val14 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.AreaSensor), 0);
						int num28 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.AreaSensor), 0);
						FormatText(statHeaderItem.currentLabel, val14, true, num28);
						FormatText(statHeaderItem.currentBest, num28);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.AreaSensor), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Turret":
				{
					double num11 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.BruteTurret), 0.0);
					if (num11 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val6 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.BruteTurret), 0);
						int num12 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.BruteTurret), 0);
						FormatText(statHeaderItem.currentLabel, val6, true, num12);
						FormatText(statHeaderItem.currentBest, num12);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.BruteTurret), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Gather":
				{
					double num29 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Gatherer), 0.0);
					if (num29 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val15 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Gatherer), 0);
						int num30 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Gatherer), 0);
						FormatText(statHeaderItem.currentLabel, val15, true, num30);
						FormatText(statHeaderItem.currentBest, num30);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Gatherer), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Generator":
				{
					double num19 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Generator), 0.0);
					if (num19 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val10 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Generator), 0);
						int num20 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Generator), 0);
						FormatText(statHeaderItem.currentLabel, val10, true, num20);
						FormatText(statHeaderItem.currentBest, num20);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Generator), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Interface":
				{
					double num5 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Interface), 0.0);
					if (num5 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val3 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Interface), 0);
						int num6 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Interface), 0);
						FormatText(statHeaderItem.currentLabel, val3, true, num6);
						FormatText(statHeaderItem.currentBest, num6);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Interface), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Lure":
				{
					double num21 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Lure), 0.0);
					if (num21 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val11 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Lure), 0);
						int num22 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Lure), 0);
						FormatText(statHeaderItem.currentLabel, val11, true, num22);
						FormatText(statHeaderItem.currentBest, num22);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Lure), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Probe":
				{
					double num23 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Probe), 0.0);
					if (num23 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val12 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Probe), 0);
						int num24 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Probe), 0);
						FormatText(statHeaderItem.currentLabel, val12, true, num24);
						FormatText(statHeaderItem.currentBest, num24);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Probe), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Mine":
				{
					double num37 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.ProximityMine), 0.0);
					if (num37 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val19 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.ProximityMine), 0);
						int num38 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.ProximityMine), 0);
						FormatText(statHeaderItem.currentLabel, val19, true, num38);
						FormatText(statHeaderItem.currentBest, num38);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.ProximityMine), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Pry":
				{
					double num7 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Pry), 0.0);
					if (num7 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val4 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Pry), 0);
						int num8 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Pry), 0);
						FormatText(statHeaderItem.currentLabel, val4, true, num8);
						FormatText(statHeaderItem.currentBest, num8);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Pry), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Scanner":
				{
					double num15 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Scanner), 0.0);
					if (num15 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val8 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Scanner), 0);
						int num16 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Scanner), 0);
						FormatText(statHeaderItem.currentLabel, val8, true, num16);
						FormatText(statHeaderItem.currentBest, num16);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Scanner), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Sensor":
				{
					double num35 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Sensor), 0.0);
					if (num35 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val18 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Sensor), 0);
						int num36 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Sensor), 0);
						FormatText(statHeaderItem.currentLabel, val18, true, num36);
						FormatText(statHeaderItem.currentBest, num36);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Sensor), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Shield":
				{
					double num31 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Shield), 0.0);
					if (num31 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val16 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Shield), 0);
						int num32 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Shield), 0);
						FormatText(statHeaderItem.currentLabel, val16, true, num32);
						FormatText(statHeaderItem.currentBest, num32);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Shield), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Sonic":
				{
					double num13 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Sonic), 0.0);
					if (num13 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val7 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Sonic), 0);
						int num14 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Sonic), 0);
						FormatText(statHeaderItem.currentLabel, val7, true, num14);
						FormatText(statHeaderItem.currentBest, num14);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Sonic), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Speedboost":
				{
					double num3 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.SpeedBoost), 0.0);
					if (num3 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.SpeedBoost), 0);
						int num4 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.SpeedBoost), 0);
						FormatText(statHeaderItem.currentLabel, val2, true, num4);
						FormatText(statHeaderItem.currentBest, num4);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.SpeedBoost), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Stealth":
				{
					double num33 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.StealthField), 0.0);
					if (num33 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val17 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.StealthField), 0);
						int num34 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.StealthField), 0);
						FormatText(statHeaderItem.currentLabel, val17, true, num34);
						FormatText(statHeaderItem.currentBest, num34);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.StealthField), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Stun":
				{
					double num25 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Stun), 0.0);
					if (num25 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val13 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Stun), 0);
						int num26 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Stun), 0);
						FormatText(statHeaderItem.currentLabel, val13, true, num26);
						FormatText(statHeaderItem.currentBest, num26);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Stun), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Teleporter":
				{
					double num17 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Teleporter), 0.0);
					if (num17 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val9 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Teleporter), 0);
						int num18 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Teleporter), 0);
						FormatText(statHeaderItem.currentLabel, val9, true, num18);
						FormatText(statHeaderItem.currentBest, num18);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Teleporter), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Tow":
				{
					double num9 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Tow), 0.0);
					if (num9 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val5 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Tow), 0);
						int num10 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Tow), 0);
						FormatText(statHeaderItem.currentLabel, val5, true, num10);
						FormatText(statHeaderItem.currentBest, num10);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Tow), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Trap":
				{
					double num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Trap), 0.0);
					if (num > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", DroneUpgradeType.Trap), 0);
						int num2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_DUPG_USED", DroneUpgradeType.Trap), 0);
						FormatText(statHeaderItem.currentLabel, val, true, num2);
						FormatText(statHeaderItem.currentBest, num2);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", DroneUpgradeType.Trap), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				}
			}
		}
		if (!(noStatRow != null))
		{
			return;
		}
		if (flag)
		{
			HideRow(noStatRow);
			return;
		}
		if (StatUI.Instance != null)
		{
			noStatRow.headerLabel.color = StatUI.Instance.noStatsColor;
		}
		ShowRow(noStatRow, true);
	}
}
