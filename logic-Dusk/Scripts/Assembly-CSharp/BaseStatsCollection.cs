public class BaseStatsCollection : StatCollection
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
				case "DaysSurvived":
				{
					double num10 = GameSaveFile.Get("ST_TTL_DAYS", 0.0);
					if (num10 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val5 = GameSaveFile.Get("ST_CUR_DAYS", 0);
						int num11 = GameSaveFile.Get("ST_BST_DAYS", 0);
						FormatText(statHeaderItem.currentLabel, val5, true, num11);
						FormatText(statHeaderItem.currentBest, num11);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_DAYS", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "ScrapCollected":
				{
					double num2 = GameSaveFile.Get("ST_TTL_SCRAP_COL", 0.0);
					if (num2 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val = GameSaveFile.Get("ST_CUR_SCRAP_COL", 0);
						int num3 = GameSaveFile.Get("ST_BST_SCRAP_COL", 0);
						FormatText(statHeaderItem.currentLabel, val, true, num3);
						FormatText(statHeaderItem.currentBest, num3);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_SCRAP_COL", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "JFuelCollected":
				{
					double num6 = GameSaveFile.Get("ST_TTL_JFUEL_COL", 0.0);
					if (num6 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val3 = GameSaveFile.Get("ST_CUR_JFUEL_COL", 0);
						int num7 = GameSaveFile.Get("ST_BST_JFUEL_COL", 0);
						FormatText(statHeaderItem.currentLabel, val3, true, num7);
						FormatText(statHeaderItem.currentBest, num7);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_JFUEL_COL", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "PFuelCollected":
				{
					double num4 = GameSaveFile.Get("ST_TTL_PFUEL_COL", 0.0);
					if (num4 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val2 = GameSaveFile.Get("ST_CUR_PFUEL_COL", 0);
						int num5 = GameSaveFile.Get("ST_BST_PFUEL_COL", 0);
						FormatText(statHeaderItem.currentLabel, val2, true, num5);
						FormatText(statHeaderItem.currentBest, num5);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_PFUEL_COL", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "DroneDeaths":
				{
					double num8 = GameSaveFile.Get("ST_TTL_DRN_DEAD", 0.0);
					if (num8 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val4 = GameSaveFile.Get("ST_CUR_DRN_DEAD", 0);
						int num9 = GameSaveFile.Get("ST_BST_DRN_DEAD", 0);
						FormatText(statHeaderItem.currentLabel, val4, true, num9);
						FormatText(statHeaderItem.currentBest, num9);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_DRN_DEAD", 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "Deaths":
				{
					double num = GameSaveFile.Get("ST_TTL_PLAYER_DEATH", 0.0);
					if (num > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get("ST_TTL_PLAYER_DEATH", 0.0));
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
