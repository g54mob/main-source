using TMPro;
using UnityEngine.UI;

public class LoadWorkshopLevelSlot : LoadLevelSlot
{
	private TextMeshProUGUI authorText;

	private TextMeshProUGUI scoreText;

	public string AuthorName { get; private set; }

	public float Score { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		authorText = base.transform.FindComponent<TextMeshProUGUI>("AuthorText", isRecursively: true);
		scoreText = base.transform.FindComponent<TextMeshProUGUI>("ScoreText", isRecursively: true);
		SetAuthorName("---");
		SetScore(0f);
	}

	public override void SetConfiguration(LevelModel levelModel, ToggleGroup toggleGroup)
	{
		base.SetConfiguration(levelModel, toggleGroup);
		WOCMetaData wOCMetaData = WOCMetaData.LoadFromLevelModel(levelModel);
		if (SteamManager.Initialized && wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out var result))
		{
			SteamWorkshopManager.Instance.GetItemInfos(result, RequestItemInfosHandler);
		}
	}

	private void RequestItemInfosHandler(string authorName, float score)
	{
		SetAuthorName(authorName);
		SetScore(score * 5f);
	}

	public void SetAuthorName(string authorName)
	{
		authorText.SetText("\uf007  " + authorName);
		AuthorName = authorName;
	}

	public void SetScore(float score)
	{
		scoreText.SetText(Util.GetStarsScore(score));
		Score = score;
	}

	protected override void SetToggleStyles(bool isOn)
	{
		base.SetToggleStyles(isOn);
		authorText.color = (isOn ? Util.HexToColor("#212224FF") : Util.HexToColor("#7A7583FF"));
		scoreText.color = (isOn ? Util.HexToColor("#212224FF") : Util.HexToColor("#7A7583FF"));
	}
}
