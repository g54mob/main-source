using UnityEngine;
using UnityEngine.UI;

public class ItemListDisplayController : MonoBehaviour
{
	public Character character;

	public Text droppedText;

	public Text maxxedText;

	private void Start()
	{
		updateDisplay();
	}

	public void updateDisplay()
	{
		droppedText.text = "Items Discovered: " + character.allItemList.totalDiscovered;
		maxxedText.text = "Items Levelled to Max: " + character.allItemList.totalMaxxed;
	}
}
