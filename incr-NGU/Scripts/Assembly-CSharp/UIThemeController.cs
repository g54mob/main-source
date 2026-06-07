using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIThemeController : MonoBehaviour
{
	public List<Sprite> darkTheme;

	public List<Sprite> normalTheme;

	public List<Sprite> goldTheme;

	public List<Sprite> goldDarkTheme;

	public List<Sprite> xmasTheme;

	public List<GameObject> ui;

	public List<Image> bolts;

	public Sprite normalBolt;

	public Sprite darkBolt;

	public Sprite goldBolt;

	public Sprite darkGoldBolt;

	public Sprite xmasGreenBolt;

	public Sprite xmasRedBolt;

	public Sprite normalButton;

	public Sprite darkButton;

	public Character character;

	public int curTheme;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void changeTheme(int newID)
	{
		if (newID == curTheme)
		{
			return;
		}
		if (newID == 2 && !character.arbitrary.boughtAscendedNewbiePack)
		{
			character.tooltip.showOverrideTooltip("You need to buy the Ascended Newbie Pack in the Sellout shop to turn on this fancy-shmancy theme!", 2f);
			return;
		}
		if (newID == 3 && !character.arbitrary.boughtAscendedNewbiePack)
		{
			character.tooltip.showOverrideTooltip("You need to buy the Ascended Newbie Pack in the Sellout shop to turn on this fancy-shmancy theme!", 2f);
			return;
		}
		switch (newID)
		{
		case 0:
		{
			for (int m = 0; m < ui.Count; m++)
			{
				if (m < normalTheme.Count && !(ui[m] == null))
				{
					ui[m].GetComponent<Image>().sprite = normalTheme[m];
				}
			}
			for (int n = 0; n < bolts.Count; n++)
			{
				if (!(bolts[n] == null))
				{
					bolts[n].sprite = normalBolt;
				}
			}
			character.settings.themeID = newID;
			curTheme = newID;
			break;
		}
		case 1:
		{
			for (int num3 = 0; num3 < ui.Count; num3++)
			{
				if (num3 < darkTheme.Count && !(ui[num3] == null))
				{
					ui[num3].GetComponent<Image>().sprite = darkTheme[num3];
				}
			}
			for (int num4 = 0; num4 < bolts.Count; num4++)
			{
				if (!(bolts[num4] == null))
				{
					bolts[num4].sprite = darkBolt;
				}
			}
			character.settings.themeID = newID;
			curTheme = newID;
			break;
		}
		case 2:
		{
			for (int num = 0; num < ui.Count; num++)
			{
				if (num < darkTheme.Count && num < normalTheme.Count && !(ui[num] == null))
				{
					if (goldTheme[num] == null)
					{
						ui[num].GetComponent<Image>().sprite = normalTheme[num];
					}
					else
					{
						ui[num].GetComponent<Image>().sprite = goldTheme[num];
					}
				}
			}
			for (int num2 = 0; num2 < bolts.Count; num2++)
			{
				if (!(bolts[num2] == null))
				{
					bolts[num2].sprite = goldBolt;
				}
			}
			character.settings.themeID = newID;
			curTheme = newID;
			break;
		}
		case 3:
		{
			for (int k = 0; k < ui.Count; k++)
			{
				if (k < darkTheme.Count && k < normalTheme.Count && !(ui[k] == null))
				{
					if (goldDarkTheme[k] == null)
					{
						ui[k].GetComponent<Image>().sprite = darkTheme[k];
					}
					else
					{
						ui[k].GetComponent<Image>().sprite = goldDarkTheme[k];
					}
				}
			}
			for (int l = 0; l < bolts.Count; l++)
			{
				if (!(bolts[l] == null))
				{
					bolts[l].sprite = darkGoldBolt;
				}
			}
			character.settings.themeID = newID;
			curTheme = newID;
			break;
		}
		case 4:
		{
			for (int i = 0; i < ui.Count; i++)
			{
				if (i < xmasTheme.Count && !(ui[i] == null))
				{
					if (xmasTheme[i] == null)
					{
						ui[i].GetComponent<Image>().sprite = normalTheme[i];
					}
					else
					{
						ui[i].GetComponent<Image>().sprite = xmasTheme[i];
					}
				}
			}
			for (int j = 0; j < bolts.Count; j++)
			{
				if (!(bolts[j] == null))
				{
					if (Random.Range(0, 2) == 0)
					{
						bolts[j].sprite = xmasRedBolt;
					}
					else
					{
						bolts[j].sprite = xmasGreenBolt;
					}
				}
			}
			character.settings.themeID = newID;
			curTheme = newID;
			break;
		}
		}
	}
}
