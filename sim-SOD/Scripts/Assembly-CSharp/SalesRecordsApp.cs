using TMPro;
using UnityEngine;

public class SalesRecordsApp : CruncherAppContent
{
	public enum CitizenPool
	{
		allCitizens = 0,
		companyOnly = 1,
		buildingOnly = 2
	}

	[Header("Components")]
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI displayText;

	public ComputerOSMultiSelect list;

	public RectTransform printButton;

	[Header("State")]
	public InteractablePreset ddsPrintout;

	public override void OnSetup()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateEntries()
	{
	}

	public void OnChangePage()
	{
	}

	public void UpdateSelected()
	{
	}

	public void ExitButton()
	{
	}

	public void OnPrintEntry()
	{
	}
}
