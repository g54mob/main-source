using UnityEngine;
using UnityEngine.UI;

public class NewbiePackChecker : MonoBehaviour
{
	public Character character;

	public Button buyButton;

	private void Start()
	{
	}

	private void Update()
	{
		if (character.menuID == 27)
		{
			if (character.arbitrary.boughtNewbiePack && character.arbitrary.boughtAscendedNewbiePack && character.arbitrary.boughtAscendedNewbiePack2)
			{
				buyButton.interactable = false;
				buyButton.GetComponentInChildren<Text>().text = "Bought!";
			}
			else
			{
				buyButton.interactable = true;
				buyButton.GetComponentInChildren<Text>().text = "I'll buy that!";
			}
		}
	}
}
