using TMPro;

public class LoadWorkshopCreationSlot : LoadCreationSlot
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

	public override void SetCreationModel(CreationModel creationModel)
	{
		base.SetCreationModel(creationModel);
		WOCMetaData wOCMetaData = WOCMetaData.LoadFromCreationModel(creationModel);
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
}
