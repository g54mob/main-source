using TMPro;
using UnityEngine;

public class DatabaseApp : CruncherAppContent
{
	public enum CitizenPool
	{
		allCitizens = 0,
		companyOnly = 1,
		buildingOnly = 2
	}

	[Header("Components")]
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI searchText;

	public ComputerOSMultiSelect list;

	public RectTransform printButton;

	private Human selectedHuman;

	[Header("State")]
	public string searchString;

	public InteractablePreset ddsPrintout;

	public CitizenPool citizenPool;

	public override void OnSetup()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateSelected()
	{
	}

	public void KeyboardButton(string charStr)
	{
	}

	public void BackspaceButton()
	{
	}

	public void UpdateSearch()
	{
	}

	public void ExitButton()
	{
	}

	public void OnPrintEntry()
	{
	}
}
