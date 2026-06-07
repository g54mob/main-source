using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardsPanelView : BaseGUIPanelView
{
	public const string LeaderboardChangedEvent = "LeaderboardsView.LeaderboardChangedEvent";

	private TextMeshProUGUI infoText;

	private CanvasGroup typeCanvas;

	private CanvasGroup starCanvas;

	private CanvasGroup listCanvas;

	private Toggle timeToggle;

	private Toggle blocksToggle;

	private Toggle costToggle;

	private Toggle weightToggle;

	private Toggle anyStarToggle;

	private Toggle zeroStarToggle;

	private Toggle oneStarToggle;

	private Toggle twoStarToggle;

	private Toggle threeStarToggle;

	private Toggle personalToggle;

	private Toggle friendsToggle;

	private Toggle top10Toggle;

	private GameObject scoresPanelObject;

	private GameObject infoPanelObject;

	private List<ScoreSlot> scoreSlotList;

	public LeaderboardsPanelView(BaseGUIView baseGUIView)
	{
		GameObject gameObject = (base.MainPanel = baseGUIView.mainPanel.transform.FindChildRecursively("LeaderboardsPanel").gameObject);
		scoreSlotList = new List<ScoreSlot>();
		typeCanvas = gameObject.transform.FindComponent<CanvasGroup>("TypePanel", isRecursively: true);
		starCanvas = gameObject.transform.FindComponent<CanvasGroup>("StarPanel", isRecursively: true);
		listCanvas = gameObject.transform.FindComponent<CanvasGroup>("ListPanel", isRecursively: true);
		timeToggle = gameObject.transform.FindComponent<Toggle>("TimeToggle", isRecursively: true);
		blocksToggle = gameObject.transform.FindComponent<Toggle>("BlocksToggle", isRecursively: true);
		costToggle = gameObject.transform.FindComponent<Toggle>("CostToggle", isRecursively: true);
		weightToggle = gameObject.transform.FindComponent<Toggle>("WeightToggle", isRecursively: true);
		anyStarToggle = gameObject.transform.FindComponent<Toggle>("AnyStarToggle", isRecursively: true);
		zeroStarToggle = gameObject.transform.FindComponent<Toggle>("ZeroStarToggle", isRecursively: true);
		oneStarToggle = gameObject.transform.FindComponent<Toggle>("OneStarToggle", isRecursively: true);
		twoStarToggle = gameObject.transform.FindComponent<Toggle>("TwoStarToggle", isRecursively: true);
		threeStarToggle = gameObject.transform.FindComponent<Toggle>("ThreeStarToggle", isRecursively: true);
		personalToggle = gameObject.transform.FindComponent<Toggle>("PersonalToggle", isRecursively: true);
		friendsToggle = gameObject.transform.FindComponent<Toggle>("FriendsToggle", isRecursively: true);
		top10Toggle = gameObject.transform.FindComponent<Toggle>("Top10Toggle", isRecursively: true);
		scoresPanelObject = gameObject.transform.FindChildRecursively("ScoresPanel").gameObject;
		infoPanelObject = gameObject.transform.FindChildRecursively("InfoPanel").gameObject;
		infoText = infoPanelObject.transform.FindComponent<TextMeshProUGUI>("InfoText", isRecursively: true);
		scoresPanelObject.GetComponentsInChildren(includeInactive: true, scoreSlotList);
		scoreSlotList.ForEach(delegate(ScoreSlot scoreSlot)
		{
			scoreSlot.Initialize();
		});
		timeToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		blocksToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		costToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		weightToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		anyStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		zeroStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		oneStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		twoStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		threeStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		personalToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		friendsToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
		top10Toggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LeaderboardsView.LeaderboardChangedEvent");
			}
		});
	}

	public (LeaderboardType type, LeaderboardDifficult difficult, LeaderboardList list) GetSelectedLeaderboardInfos()
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
		LeaderboardList item3 = LeaderboardList.Personal;
		if (personalToggle.isOn)
		{
			item3 = LeaderboardList.Personal;
		}
		else if (friendsToggle.isOn)
		{
			item3 = LeaderboardList.Friends;
		}
		else if (top10Toggle.isOn)
		{
			item3 = LeaderboardList.Top10;
		}
		return (type: item, difficult: item2, list: item3);
	}

	public void UpdateScoreList(List<SteamLeaderboardsManager.UserScoreData> userScoreDatas)
	{
		for (int i = 0; i < scoreSlotList.Count; i++)
		{
			ScoreSlot scoreSlot = scoreSlotList[i];
			if (i < userScoreDatas.Count)
			{
				SteamLeaderboardsManager.UserScoreData userScoreData = userScoreDatas[i];
				int[] details = new int[5] { userScoreData.time, userScoreData.blocks, userScoreData.cost, userScoreData.weight, userScoreData.difficult };
				scoreSlot.gameObject.SetActive(value: true);
				scoreSlot.SetInfos(userScoreData.rank.ToString(), userScoreData.userName, userScoreData.score, userScoreData.leadboardType, details, userScoreData.isCurrentUser);
				Texture2D userProfileImage = SteamLeaderboardsManager.Instance.GetUserProfileImage(userScoreData.userId);
				scoreSlot.SetProfileImage(userProfileImage);
			}
			else
			{
				scoreSlot.gameObject.SetActive(value: false);
			}
		}
	}

	public void SetFiltersInteractivity(bool isInteractable)
	{
		typeCanvas.interactable = isInteractable;
		starCanvas.interactable = isInteractable;
		listCanvas.interactable = isInteractable;
	}

	public void SetScoresPanelVisibility(bool isVisible)
	{
		scoresPanelObject.SetActive(isVisible);
		infoPanelObject.SetActive(!isVisible);
	}

	public void SetInfoText(string text)
	{
		infoText.SetText(text);
	}
}
