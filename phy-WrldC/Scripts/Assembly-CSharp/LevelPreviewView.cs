using TMPro;

public class LevelPreviewView : BaseGUIView
{
	private TextMeshProUGUI levelGroupText;

	private TextMeshProUGUI levelNameText;

	public override void Initialize()
	{
		levelGroupText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelGroupText", isRecursively: true);
		levelNameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelNameText", isRecursively: true);
	}

	public void SetLevelModel(LevelModel levelModel)
	{
		var (sourceText, sourceText2) = LevelUtil.GetLevelNames(levelModel);
		levelNameText.SetText(sourceText2);
		levelGroupText.SetText(sourceText);
	}
}
