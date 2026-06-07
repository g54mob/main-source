using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoadSlotView : BaseGUIView
{
	public enum LevelType
	{
		WithoutGoal = 0,
		WithGoal = 1
	}

	public const string LevelNamePrefixId = "level.name.";

	public const string LevelLockedText = "???";

	private Button slotButton;

	private TextMeshProUGUI numberText;

	private TextMeshProUGUI nameText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI completedText;

	private TextMeshProUGUI starsText;

	private LevelModel levelModel;

	[SerializeField]
	private Color levelNameColor;

	[SerializeField]
	private Color levelNumberColor;

	[SerializeField]
	private Color bestTimeColor;

	[SerializeField]
	private Color disabledColor;

	public Color LevelNameColor
	{
		set
		{
			levelNameColor = value;
		}
	}

	public Color LevelNumberColor
	{
		set
		{
			levelNumberColor = value;
		}
	}

	public Color BestTimeColor
	{
		set
		{
			bestTimeColor = value;
		}
	}

	public Color DisabledColor
	{
		set
		{
			disabledColor = value;
		}
	}

	public bool IsInteractible { get; private set; }

	public override void Initialize()
	{
		slotButton = mainPanel.GetComponent<Button>();
		numberText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NumberText", isRecursively: true);
		nameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		bestTimeText = mainPanel.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		completedText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		starsText = base.transform.FindComponent<TextMeshProUGUI>("StarsText", isRecursively: true);
		IsInteractible = true;
	}

	public void ConfigSlot(LevelModel levelModel, LevelType levelType, string levelIndex = "")
	{
		this.levelModel = levelModel;
		if (!string.IsNullOrEmpty(levelIndex))
		{
			numberText.text = levelIndex;
		}
		SetLevelName(levelModel.Name);
		SetLevelBestTime(levelModel.LevelStatus, levelModel.BestTime);
		SetLevelCompleteness(levelModel.IsLevelCompleted);
		SetLevelCollectables(levelModel.IsThereCollectables, levelModel.LevelStatus);
		if (levelType == LevelType.WithoutGoal)
		{
			bestTimeText.gameObject.SetActive(value: false);
			completedText.gameObject.SetActive(value: false);
			starsText.gameObject.SetActive(value: false);
		}
	}

	public void SetInteractivity(bool isInteractible)
	{
		IsInteractible = isInteractible;
		slotButton.interactable = isInteractible;
		string text = LanguagesManager.Instance.GetText("level.name." + levelModel.Id, levelModel.Name);
		nameText.text = (isInteractible ? text : "???");
		nameText.color = (isInteractible ? levelNameColor : disabledColor);
		numberText.color = (isInteractible ? levelNumberColor : disabledColor);
		bestTimeText.color = (isInteractible ? bestTimeColor : disabledColor);
	}

	public void SetLevelName(string baseId)
	{
		string text = LanguagesManager.Instance.GetText("level.name." + baseId, levelModel.Name);
		nameText.text = text;
	}

	public void SetLevelIndex(int index)
	{
		numberText.text = index.ToString();
	}

	public void SetLevelCompleteness(bool isLevelCompleted)
	{
		completedText.SetText(isLevelCompleted ? "<#F7EC3DFF>\uf046" : "<#7A7583FF>\uf096");
	}

	public void SetLevelBestTime(LevelStatus levelStatus, float bestTimeDefault)
	{
		if (levelStatus != null)
		{
			bestTimeText.SetText(Util.TimeParser(levelStatus.BestTimeEver().time));
		}
		else
		{
			bestTimeText.SetText(Util.TimeParser(bestTimeDefault));
		}
	}

	public void SetLevelCollectables(bool isThereCollectables, LevelStatus levelStatus)
	{
		starsText.gameObject.SetActive(isThereCollectables);
		if (isThereCollectables)
		{
			string text;
			string text2;
			if (levelStatus == null)
			{
				(text, text2) = Util.GetLevelStarsDefaultIcons(isAllBoth: false, isAllGold: false, isAllSilver: false);
			}
			else
			{
				(text, text2) = Util.GetLevelStarsDefaultIcons(levelStatus.AllBothCollectables, levelStatus.AllGoldCollectables, levelStatus.AllSilverCollectables);
			}
			starsText.SetText(text + text2);
		}
	}
}
