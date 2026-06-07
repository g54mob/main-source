using TMPro;

public class DescriptionTooltipPanel : TooltipPanelBase
{
	private TextMeshProUGUI descriptionText;

	protected override void Awake()
	{
		base.Awake();
		descriptionText = base.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
	}

	public void SetDescriptionText(string description)
	{
		descriptionText.text = description;
	}
}
