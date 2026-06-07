using TMPro;

public class LevelObjectTooltipPanel : TooltipPanelBase
{
	private TextMeshProUGUI nameText;

	private TextMeshProUGUI descriptionText;

	private TextMeshProUGUI scaleText;

	protected override void Awake()
	{
		base.Awake();
		nameText = base.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		descriptionText = base.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		scaleText = base.transform.FindComponent<TextMeshProUGUI>("ScaleText", isRecursively: true);
	}

	public void SetLevelObjectInfos(string name, string description, string scale = "")
	{
		nameText.SetText(name);
		descriptionText.SetText(description);
		if (!string.IsNullOrEmpty(scale) && !string.IsNullOrWhiteSpace(scale))
		{
			scaleText.gameObject.SetActive(value: true);
			scaleText.SetText(scale);
		}
		else
		{
			scaleText.gameObject.SetActive(value: false);
		}
	}
}
