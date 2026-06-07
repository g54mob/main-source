using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_SimpleRankingEntry : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_Rank;

	[SerializeField]
	private Text text_PlayerName;

	[SerializeField]
	private TMP_Text text_Score;

	[SerializeField]
	private RawImage image_PlayerIcon;

	[SerializeField]
	private TMP_Text text_DebugInfo;

	private int playerID;

	public int PlayerID => 0;

	public void Setup(int rank, int playerID, string playerName, int score, Texture2D playerIcon)
	{
	}

	public void SetupPlayerIcon(Texture2D playerIcon)
	{
	}
}
