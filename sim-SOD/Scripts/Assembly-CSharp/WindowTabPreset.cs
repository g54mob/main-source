using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "windowtab_data", menuName = "Database/Window Tab Style")]
public class WindowTabPreset : SoCustomComparison
{
	public enum TabContentType
	{
		generated = 0,
		message = 1,
		facts = 2,
		history = 3,
		help = 4,
		photoSelect = 5,
		shop = 6,
		objectives = 7,
		callLogsIncoming = 8,
		callLogsOutgoing = 9,
		passcodes = 10,
		phoneNumbers = 11,
		resolve = 12,
		results = 13,
		decor = 14,
		furnishings = 15,
		colourPicker = 16,
		floors = 17,
		ceiling = 18,
		materialKey = 19,
		caseOptions = 20,
		items = 21,
		itemSelect = 22
	}

	[Header("Naming")]
	public string tabName;

	public Color colour;

	public GameObject contentPrefab;

	public TabContentType contentType;

	[Header("Scripts")]
	public bool scalableContent;

	public bool fitToScaleX;

	public bool fitToScaleY;

	public bool zoomWithMouseWheel;

	[Header("Scroll")]
	public bool scrollBars;

	public ScrollRect.MovementType scrollRestrcition;

	[Header("Content")]
	public string displayContentWithTag;
}
