using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestPlayersView : BaseGUIView
{
	public const string LeaderboardChangedEvent = "BestPlayersView.LeaderboardChangedEvent";

	public const string LeaderboardPagesChangedEvent = "BestPlayersView.LeaderboardPagesChangedEvent";

	public const string CloseButtonEvent = "BestPlayersView.CloseButtonEvent";

	private TextMeshProUGUI infoText;

	private Toggle timeToggle;

	private Toggle blocksToggle;

	private Toggle costToggle;

	private Toggle weightToggle;

	private Toggle anyStarToggle;

	private Toggle zeroStarToggle;

	private Toggle oneStarToggle;

	private Toggle twoStarToggle;

	private Toggle threeStarToggle;

	private GameObject scoresPanelObject;

	private GameObject infoPanelObject;

	private GameObject pagesPanel;

	private Button previousPageButton;

	private Button nextPageButton;

	private TextMeshProUGUI numberOfPagesText;

	private Button closeButton;

	private List<BestPlayerScoreSlot> scoreSlotList;

	public override void Initialize()
	{
		scoreSlotList = new List<BestPlayerScoreSlot>();
		timeToggle = mainPanel.transform.FindComponent<Toggle>("TimeToggle", isRecursively: true);
		blocksToggle = mainPanel.transform.FindComponent<Toggle>("BlocksToggle", isRecursively: true);
		costToggle = mainPanel.transform.FindComponent<Toggle>("CostToggle", isRecursively: true);
		weightToggle = mainPanel.transform.FindComponent<Toggle>("WeightToggle", isRecursively: true);
		anyStarToggle = mainPanel.transform.FindComponent<Toggle>("AnyStarToggle", isRecursively: true);
		zeroStarToggle = mainPanel.transform.FindComponent<Toggle>("ZeroStarToggle", isRecursively: true);
		oneStarToggle = mainPanel.transform.FindComponent<Toggle>("OneStarToggle", isRecursively: true);
		twoStarToggle = mainPanel.transform.FindComponent<Toggle>("TwoStarToggle", isRecursively: true);
		threeStarToggle = mainPanel.transform.FindComponent<Toggle>("ThreeStarToggle", isRecursively: true);
		scoresPanelObject = mainPanel.transform.FindChildRecursively("ScoresPanel").gameObject;
		infoPanelObject = mainPanel.transform.FindChildRecursively("InfoPanel").gameObject;
		infoText = infoPanelObject.transform.FindComponent<TextMeshProUGUI>("InfoText", isRecursively: true);
		pagesPanel = mainPanel.transform.FindChildRecursively("PagesPanel").gameObject;
		previousPageButton = pagesPanel.transform.FindComponent<Button>("PreviousPageButton", isRecursively: true);
		nextPageButton = pagesPanel.transform.FindComponent<Button>("NextPageButton", isRecursively: true);
		numberOfPagesText = pagesPanel.transform.FindComponent<TextMeshProUGUI>("NumberOfPagesText", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		scoresPanelObject.GetComponentsInChildren(includeInactive: true, scoreSlotList);
		scoreSlotList.ForEach(delegate(BestPlayerScoreSlot scoreSlot)
		{
			scoreSlot.Initialize();
		});
		timeToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		blocksToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		costToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		weightToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		anyStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		zeroStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		oneStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		twoStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		threeStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("BestPlayersView.LeaderboardChangedEvent");
			}
		});
		previousPageButton.onClick.AddListener(delegate
		{
			NotifyChange("BestPlayersView.LeaderboardPagesChangedEvent", -1);
		});
		nextPageButton.onClick.AddListener(delegate
		{
			NotifyChange("BestPlayersView.LeaderboardPagesChangedEvent", 1);
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("BestPlayersView.CloseButtonEvent");
		});
	}

	public (LeaderboardType type, LeaderboardDifficult difficult) GetSelectedLeaderboardInfos()
	{
		LeaderboardType item = LeaderboardType.Time;
		if (timeToggle.isOn)
		{
			item = LeaderboardType.Time;
		}
		else if (blocksToggle.isOn)
		{
			item = LeaderboardType.Blocks;
		}
		else if (costToggle.isOn)
		{
			item = LeaderboardType.Cost;
		}
		else if (weightToggle.isOn)
		{
			item = LeaderboardType.Weight;
		}
		LeaderboardDifficult item2 = LeaderboardDifficult.AnyStar;
		if (anyStarToggle.isOn)
		{
			item2 = LeaderboardDifficult.AnyStar;
		}
		else if (zeroStarToggle.isOn)
		{
			item2 = LeaderboardDifficult.ZeroStar;
		}
		else if (oneStarToggle.isOn)
		{
			item2 = LeaderboardDifficult.OneStar;
		}
		else if (twoStarToggle.isOn)
		{
			item2 = LeaderboardDifficult.TwoStar;
		}
		else if (threeStarToggle.isOn)
		{
			item2 = LeaderboardDifficult.ThreeStar;
		}
		return (type: item, difficult: item2);
	}

	public void UpdateScoreList(List<SteamLeaderboardsManager.BestUserData> bestUserDatas, int pageIndex = 0)
	{
		for (int i = 0; i < scoreSlotList.Count; i++)
		{
			BestPlayerScoreSlot bestPlayerScoreSlot = scoreSlotList[i];
			int num = i + pageIndex * 10;
			if (num < bestUserDatas.Count)
			{
				SteamLeaderboardsManager.BestUserData bestUserData = bestUserDatas[num];
				bestPlayerScoreSlot.gameObject.SetActive(value: true);
				bestPlayerScoreSlot.SetInfos(num + 1, bestUserData.userName, bestUserData.score, bestUserData.goldMedal, bestUserData.silverMedal, bestUserData.bronzeMedal, bestUserData.isCurrentUser);
				Texture2D userProfileImage = SteamLeaderboardsManager.Instance.GetUserProfileImage(bestUserData.userId);
				bestPlayerScoreSlot.SetProfileImage(userProfileImage);
			}
			else
			{
				bestPlayerScoreSlot.gameObject.SetActive(value: false);
			}
		}
	}

	public void SetScoresPanelVisibility(bool isVisible)
	{
		scoresPanelObject.SetActive(isVisible);
	}

	public void SetInfoPanelVisibility(bool isVisible)
	{
		infoPanelObject.SetActive(isVisible);
	}

	public void SetInfoText(string text)
	{
		infoText.SetText(text);
	}

	public void SetPagesComponentsVisibility(bool isVisible)
	{
		previousPageButton.gameObject.SetActive(isVisible);
		nextPageButton.gameObject.SetActive(isVisible);
		numberOfPagesText.gameObject.SetActive(isVisible);
	}

	public void UpdatePagesSystem(List<SteamLeaderboardsManager.BestUserData> bestUserDatas, int newPageSelected)
	{
		int num = bestUserDatas.Count / 10 + ((bestUserDatas.Count % 10 != 0) ? 1 : 0);
		newPageSelected = Mathf.Clamp(newPageSelected, 1, num);
		bool pagesComponentsVisibility = num > 1;
		SetPagesComponentsVisibility(pagesComponentsVisibility);
		string text = LanguagesManager.Instance.GetText("page.separator.text", "/");
		numberOfPagesText.SetText($"{newPageSelected} {text} {num}");
		previousPageButton.interactable = newPageSelected > 1;
		nextPageButton.interactable = newPageSelected < num;
	}
}
