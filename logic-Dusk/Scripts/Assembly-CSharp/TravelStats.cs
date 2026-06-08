public class TravelStats : StatCollection
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
				case "DerelictsVisited":
				{
					double num4 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Derelict), 0.0);
					if (num4 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", DungeonTypeEnum.Derelict), 0);
						int num5 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", DungeonTypeEnum.Derelict), 0);
						FormatText(statHeaderItem.currentLabel, val2, true, num5);
						FormatText(statHeaderItem.currentBest, num5);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Derelict), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "OutpostsVisited":
				{
					double num10 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Outpost), 0.0);
					if (num10 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val5 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", DungeonTypeEnum.Outpost), 0);
						int num11 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", DungeonTypeEnum.Outpost), 0);
						FormatText(statHeaderItem.currentLabel, val5, true, num11);
						FormatText(statHeaderItem.currentBest, num11);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Outpost), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "TradingPostsVisited":
				{
					double num6 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.AutoTrade), 0.0);
					if (num6 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val3 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", DungeonTypeEnum.AutoTrade), 0);
						int num7 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", DungeonTypeEnum.AutoTrade), 0);
						FormatText(statHeaderItem.currentLabel, val3, true, num7);
						FormatText(statHeaderItem.currentBest, num7);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.AutoTrade), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "StargatesVisited":
				{
					double num12 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Stargate), 0.0);
					if (num12 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val6 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", DungeonTypeEnum.Stargate), 0);
						int num13 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", DungeonTypeEnum.Stargate), 0);
						FormatText(statHeaderItem.currentLabel, val6, true, num13);
						FormatText(statHeaderItem.currentBest, num13);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", DungeonTypeEnum.Stargate), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "SystemsVisited":
				{
					double num2 = GameSaveFile.Get("ST_TTL_SYS_VISITED", 0.0);
					if (num2 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val = GameSaveFile.Get("ST_CUR_SYS_VISITED", 0);
						int num3 = GameSaveFile.Get("ST_BST_SYS_VISITED", 0);
						FormatText(statHeaderItem.currentLabel, val, true, num3);
						FormatText(statHeaderItem.currentBest, num3);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_SYS_VISITED", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "GalaxiesVisited":
				{
					double num8 = GameSaveFile.Get("ST_TTL_GAL_VISITED", 0.0);
					if (num8 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val4 = GameSaveFile.Get("ST_CUR_GAL_VISITED", 0);
						int num9 = GameSaveFile.Get("ST_BST_GAL_VISITED", 0);
						FormatText(statHeaderItem.currentLabel, val4, true, num9);
						FormatText(statHeaderItem.currentBest, num9);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_GAL_VISITED", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "UniversesVisited":
				{
					double num = GameSaveFile.Get("ST_TTL_GAL_VISITED", 0.0);
					if (num > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_UN_VISITED", 0.0));
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
