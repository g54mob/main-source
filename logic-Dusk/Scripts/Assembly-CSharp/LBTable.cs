using UnityEngine;

public class LBTable : MonoBehaviour
{
	public LBColumn rankCol;

	public LBColumn playerCol;

	public LBColumn scoreCol;

	public Color playerColor = Color.yellow;

	public Color playerColorPartial = Color.yellow;

	public Color playerLowRankColor = Color.yellow;

	public Color playerLowRankColorPartial = Color.yellow;

	public Color nonPlayerColor = Color.white;

	public Color nonPlayerColorPartial = Color.white;

	private void Awake()
	{
		Clear();
	}

	public void Clear()
	{
		int num = rankCol.rowArray.Length;
		for (int i = 0; i < num; i++)
		{
			rankCol.rowArray[i].enabled = false;
		}
		num = playerCol.rowArray.Length;
		for (int j = 0; j < num; j++)
		{
			playerCol.rowArray[j].enabled = false;
		}
		num = scoreCol.rowArray.Length;
		for (int k = 0; k < num; k++)
		{
			scoreCol.rowArray[k].enabled = false;
		}
	}

	public void RefreshRows(SteamLeaderboard.ScoreInfo[] scoreInfo, int recCount)
	{
		for (int i = 0; i < recCount; i++)
		{
			rankCol.rowArray[i].enabled = true;
			rankCol.rowArray[i].text = scoreInfo[i].Rank.ToString();
			playerCol.rowArray[i].enabled = true;
			playerCol.rowArray[i].text = scoreInfo[i].PlayerName.ToString();
			scoreCol.rowArray[i].enabled = true;
			scoreCol.rowArray[i].text = scoreInfo[i].Score.ToString();
			Color color = nonPlayerColor;
			if (scoreInfo[i].ScoreStatus == SteamLeaderboard.ScoreStatusEnum.Partial)
			{
				color = nonPlayerColorPartial;
			}
			if (scoreInfo[i].IsSelf)
			{
				if (i == 10)
				{
					color = playerLowRankColor;
					if (scoreInfo[i].ScoreStatus == SteamLeaderboard.ScoreStatusEnum.Partial)
					{
						color = playerLowRankColorPartial;
					}
				}
				else
				{
					color = playerColor;
					if (scoreInfo[i].ScoreStatus == SteamLeaderboard.ScoreStatusEnum.Partial)
					{
						color = playerColorPartial;
					}
				}
			}
			rankCol.rowArray[i].color = color;
			playerCol.rowArray[i].color = color;
			scoreCol.rowArray[i].color = color;
		}
	}
}
