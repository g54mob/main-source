using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupLevelDetailSlot : MonoBehaviour
{
	public const string LevelNamePrefixId = "level.name.";

	private TextMeshProUGUI levelNameText;

	private TextMeshProUGUI completedText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI bestTimesText;

	private TextMeshProUGUI noImageText;

	private Image levelImage;

	private Button playLevelButton;

	private Button leaderboardsButton;

	private LanguagesManager languagesManager;

	public LevelModel SelectedLevelModel { get; private set; }

	public event Action<LevelModel> OnPlayButtonEvent;

	public event Action<LevelModel> OnLeaderboardsButtonEvent;

	private void Awake()
	{
		languagesManager = LanguagesManager.Instance;
		levelNameText = base.transform.FindComponent<TextMeshProUGUI>("LevelNameText", isRecursively: true);
		completedText = base.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		bestTimeText = base.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		bestTimesText = base.transform.FindComponent<TextMeshProUGUI>("BestTimesText", isRecursively: true);
		noImageText = base.transform.FindComponent<TextMeshProUGUI>("NoImageText", isRecursively: true);
		levelImage = base.transform.FindComponent<Image>("LevelImage", isRecursively: true);
		playLevelButton = base.transform.FindComponent<Button>("PlayLevelButton", isRecursively: true);
		leaderboardsButton = base.transform.FindComponent<Button>("LeaderboardsButton", isRecursively: true);
		playLevelButton.onClick.AddListener(delegate
		{
			this.OnPlayButtonEvent?.Invoke(SelectedLevelModel);
		});
		leaderboardsButton.onClick.AddListener(delegate
		{
			this.OnLeaderboardsButtonEvent?.Invoke(SelectedLevelModel);
		});
	}

	public void SetConfiguration(LevelModel levelModel)
	{
		string item = LevelUtil.GetLevelNames(levelModel).levelName;
		levelNameText.SetText(item);
		bool isAllBoth = levelModel.LevelStatus != null && levelModel.LevelStatus.AllBothCollectables;
		bool isAllGold = levelModel.LevelStatus != null && levelModel.LevelStatus.AllGoldCollectables;
		bool isAllSilver = levelModel.LevelStatus != null && levelModel.LevelStatus.AllSilverCollectables;
		SetLevelCompleteness(levelModel.IsLevelCompleted, levelModel.IsThereCollectables, isAllBoth, isAllGold, isAllSilver);
		SetLevelBestTimes(levelModel.LevelStatus?.LowestTimeRecords, levelModel.IsThereCollectables);
		Sprite sprite = GameManager.Instance.LevelThumbnailCollection.GetSprite(levelModel.Id);
		if (sprite != null)
		{
			levelImage.enabled = true;
			levelImage.sprite = sprite;
			noImageText.gameObject.SetActive(value: false);
		}
		else
		{
			levelImage.enabled = false;
			noImageText.gameObject.SetActive(value: true);
		}
		leaderboardsButton.gameObject.SetActive(SteamManager.Initialized);
		SelectedLevelModel = levelModel;
	}

	private void SetLevelCompleteness(bool isLevelCompleted, bool isThereCollectables, bool isAllBoth, bool isAllGold, bool isAllSilver)
	{
		(string goldIcon, string silverIcon) levelStarsDefaultIcons = Util.GetLevelStarsDefaultIcons(isAllBoth, isAllGold, isAllSilver);
		string item = levelStarsDefaultIcons.goldIcon;
		string item2 = levelStarsDefaultIcons.silverIcon;
		string text = (isLevelCompleted ? "<#F7EC3DFF>\uf046" : "<#787878FF>\uf096");
		completedText.SetText((isThereCollectables ? (item + item2) : "") + "  " + text);
	}

	private void SetLevelBestTimes(LevelStatus.RecordsValues lowestTimeRecords, bool isThereCollectables)
	{
		if (lowestTimeRecords == null)
		{
			bestTimeText.SetText("--:--:---");
			bestTimeText.gameObject.SetActive(value: true);
			bestTimesText.gameObject.SetActive(value: false);
			return;
		}
		if (isThereCollectables)
		{
			string text = "<color=#F7EC3D>\uf005</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.BothStarValue);
			string text2 = "<color=#F7EC3D>\uf005</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.GoldStarValue);
			string text3 = "<color=#F7EC3D4D>\uf006</color><color=#787878>\uf005</color>   " + Util.TimeParser(lowestTimeRecords.SilverStarValue);
			string text4 = "<color=#F7EC3D4D>\uf006</color><color=#7878784D>\uf006</color>   " + Util.TimeParser(lowestTimeRecords.NoneStarValue);
			bestTimesText.SetText(text + "\n" + text2 + "\n" + text3 + "\n" + text4);
		}
		else
		{
			bestTimeText.SetText(Util.TimeParser(lowestTimeRecords.NoneStarValue));
		}
		bestTimeText.gameObject.SetActive(!isThereCollectables);
		bestTimesText.gameObject.SetActive(isThereCollectables);
	}

	public void RefreshLabels()
	{
		string item = LevelUtil.GetLevelNames(SelectedLevelModel).levelName;
		levelNameText.SetText(item);
	}
}
