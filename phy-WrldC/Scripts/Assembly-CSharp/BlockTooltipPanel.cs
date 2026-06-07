using TMPro;

public class BlockTooltipPanel : TooltipPanelBase
{
	private TextMeshProUGUI nameText;

	private TextMeshProUGUI descriptionText;

	private TextMeshProUGUI costText;

	private TextMeshProUGUI weightText;

	protected override void Awake()
	{
		base.Awake();
		nameText = base.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		descriptionText = base.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		costText = base.transform.FindComponent<TextMeshProUGUI>("CostText", isRecursively: true);
		weightText = base.transform.FindComponent<TextMeshProUGUI>("WeightText", isRecursively: true);
	}

	public void SetCreationInfo(CreationModel creationModel)
	{
		nameText.text = creationModel.Name;
		descriptionText.text = creationModel.Description;
		costText.text = "\uf0eb " + creationModel.TotalCost();
		weightText.text = "\ue908 " + creationModel.TotalWeight();
	}
}
