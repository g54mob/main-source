public class EnemyStats : StatCollection
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
				case "PatrolBotKilled":
				{
					double num5 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.PatrolBot), 0.0);
					if (num5 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val3 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.PatrolBot), 0);
						int num6 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.PatrolBot), 0);
						FormatText(statHeaderItem.currentLabel, val3, true, num6);
						FormatText(statHeaderItem.currentBest, num6);
						FormatText(statHeaderItem.currentTotal, num5);
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "SwarmsKilled":
				{
					double num3 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Swarm), 0.0);
					if (num3 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Swarm), 0);
						int num4 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Swarm), 0);
						FormatText(statHeaderItem.currentLabel, val2, true, num4);
						FormatText(statHeaderItem.currentBest, num4);
						FormatText(statHeaderItem.currentBest, GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Swarm), 0));
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Swarm), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "BrutesKilled":
				{
					double num7 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Brute), 0.0);
					if (num7 > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val4 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Brute), 0);
						int num8 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Brute), 0);
						FormatText(statHeaderItem.currentLabel, val4, true, num8);
						FormatText(statHeaderItem.currentBest, num8);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Brute), 0.0));
						flag = true;
					}
					else
					{
						HideRow(statHeaderItem);
					}
					break;
				}
				case "SlimeKilled":
				{
					double num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Slime), 0.0);
					if (num > 0.0 || flag2)
					{
						ShowRow(statHeaderItem);
						int val = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Slime), 0);
						int num2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Slime), 0);
						FormatText(statHeaderItem.currentLabel, val, true, num2);
						FormatText(statHeaderItem.currentBest, num2);
						FormatText(statHeaderItem.currentTotal, GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Slime), 0.0));
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
