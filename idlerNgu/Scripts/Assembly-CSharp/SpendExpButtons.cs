using UnityEngine;
using UnityEngine.UI;

public class SpendExpButtons : MonoBehaviour
{
	public Character character;

	public Button[] yggdrasilButtons;

	public Button[] adventureStatButtons;

	public Button[] adventureSpecialButtons;

	public Button[] magicButtons;

	public Button[] miscButtons;

	public Button[] res3Buttons;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void refresh()
	{
		if (character.res3.res3On)
		{
			for (int i = 0; i < res3Buttons.Length; i++)
			{
				res3Buttons[i].interactable = true;
				res3Buttons[i].GetComponentInChildren<Text>().text = character.res3.res3Name;
			}
		}
		else
		{
			for (int j = 0; j < res3Buttons.Length; j++)
			{
				res3Buttons[j].interactable = false;
				res3Buttons[j].GetComponentInChildren<Text>().text = "Locked";
			}
		}
		if (character.settings.yggdrasilOn)
		{
			for (int k = 0; k < yggdrasilButtons.Length; k++)
			{
				yggdrasilButtons[k].interactable = true;
				yggdrasilButtons[k].GetComponentInChildren<Text>().text = "Yggdrasil";
			}
		}
		else
		{
			for (int l = 0; l < yggdrasilButtons.Length; l++)
			{
				yggdrasilButtons[l].interactable = false;
				yggdrasilButtons[l].GetComponentInChildren<Text>().text = "Locked";
			}
		}
		if (character.highestBoss >= 37)
		{
			for (int m = 0; m < magicButtons.Length; m++)
			{
				magicButtons[m].interactable = true;
				magicButtons[m].GetComponentInChildren<Text>().text = "Magic";
			}
			for (int n = 0; n < miscButtons.Length; n++)
			{
				miscButtons[n].interactable = true;
				miscButtons[n].GetComponentInChildren<Text>().text = "Misc";
			}
		}
		else
		{
			for (int num = 0; num < magicButtons.Length; num++)
			{
				magicButtons[num].interactable = false;
				magicButtons[num].GetComponentInChildren<Text>().text = "Locked";
			}
			for (int num2 = 0; num2 < miscButtons.Length; num2++)
			{
				miscButtons[num2].interactable = false;
				miscButtons[num2].GetComponentInChildren<Text>().text = "Locked";
			}
		}
		if (character.highestBoss >= 4)
		{
			for (int num3 = 0; num3 < adventureStatButtons.Length; num3++)
			{
				adventureStatButtons[num3].interactable = true;
				adventureStatButtons[num3].GetComponentInChildren<Text>().text = "Adventure Stats";
			}
			for (int num4 = 0; num4 < adventureSpecialButtons.Length; num4++)
			{
				adventureSpecialButtons[num4].interactable = true;
				adventureSpecialButtons[num4].GetComponentInChildren<Text>().text = "Adventure Special";
			}
		}
		else
		{
			for (int num5 = 0; num5 < adventureStatButtons.Length; num5++)
			{
				adventureStatButtons[num5].interactable = false;
				adventureStatButtons[num5].GetComponentInChildren<Text>().text = "Locked";
			}
			for (int num6 = 0; num6 < adventureSpecialButtons.Length; num6++)
			{
				adventureSpecialButtons[num6].interactable = false;
				adventureSpecialButtons[num6].GetComponentInChildren<Text>().text = "Locked";
			}
		}
	}
}
