using UnityEngine;
using UnityEngine.UI;

public class ItemAssigningTutorialHandler : MonoBehaviour
{
	public Text tutorialText;

	private void Start()
	{
		UltimateRadialMenu.EnableRadialMenu("ItemWheelExample");
		UltimateRadialMenu.GetUltimateRadialMenu("ItemWheelExample").OnRadialMenuEnabled += OnRadialMenuEnabled;
		UltimateRadialMenu.GetUltimateRadialMenu("ItemWheelExample").OnRadialMenuDisabled += OnRadialMenuDisabled;
	}

	private void OnRadialMenuEnabled()
	{
		tutorialText.text = "Click and drag the items on the right to the radial menu to assign them to a button.\n\nClicking on the item will increase the count of that item.";
	}

	private void OnRadialMenuDisabled()
	{
		tutorialText.text = "Press SPACE BAR to open your radial menu.";
	}
}
