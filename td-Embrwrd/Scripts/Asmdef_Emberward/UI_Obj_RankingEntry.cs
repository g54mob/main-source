using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_RankingEntry : MonoBehaviour
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
	private Button button_ViewScreenshot;

	[SerializeField]
	private Transform node_TowerCards;

	[SerializeField]
	private List<UI_CardFace> list_TowerCards;

	[SerializeField]
	private Transform node_RelicLayout;

	[SerializeField]
	private GameObject prefab_RelicItem;

	[SerializeField]
	private List<Image> list_RelicBackground;

	[SerializeField]
	private TMP_Text text_DebugInfo;

	[SerializeField]
	private Texture2D defaultPlayerIcon;

	private int playerID;

	private Texture2D screenshotTexture;

	private LeaderboardEntry entry;

	public int PlayerID => 0;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton_ViewScreenshot()
	{
	}

	public void Setup(int rank, int playerID, string playerName, int score, Texture2D playerIcon, LeaderboardEntry entry)
	{
	}

	public void SetupPlayerIcon(Texture2D playerIcon)
	{
	}

	public void SetupTowerCards(List<int> list_TowerTypeInt)
	{
	}

	public void SetupTowerCards(List<eItemType> list_Towers)
	{
	}

	public void SetupRelicCards(List<int> list_RelicTypeInt)
	{
	}

	public void SetupRelicCards(List<eItemType> list_RelicType)
	{
	}

	public void SetupEntryScreenshot(Texture2D tex)
	{
	}
}
