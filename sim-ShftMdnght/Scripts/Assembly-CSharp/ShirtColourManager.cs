using UnityEngine;
using UnityEngine.UI;

public class ShirtColourManager : MonoBehaviour
{
	public Image pickerBTN;

	public GameObject pickingMenu;

	public Image[] pickImages;

	private void Start()
	{
		if (PlayerPrefs.GetInt("ShirtColor", 0) == 0)
		{
			PlayerPrefs.SetInt("ShirtColor", Random.Range(1, 13));
		}
		PickColor(PlayerPrefs.GetInt("ShirtColor", 0));
	}

	public void ClickPickerBTN()
	{
		pickingMenu.SetActive(!pickingMenu.activeInHierarchy);
	}

	public void PickColor(int color)
	{
		pickerBTN.color = pickImages[color].color;
		PlayerPrefs.SetInt("ShirtColor", color);
	}
}
