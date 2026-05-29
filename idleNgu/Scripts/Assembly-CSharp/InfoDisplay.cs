using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
	public Text infoText;

	public Text titleText;

	public Character character;

	public Scrollbar scrollbar;

	public List<Button> wtfButtons;

	private void Start()
	{
	}

	public void refreshMenu()
	{
		if (character.menuID == 21)
		{
			if (character.highestBoss >= 3)
			{
				wtfButtons[0].gameObject.SetActive(value: true);
				wtfButtons[1].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[0].gameObject.SetActive(value: false);
				wtfButtons[1].gameObject.SetActive(value: false);
			}
			if (character.settings.inventoryOn)
			{
				wtfButtons[2].gameObject.SetActive(value: true);
				wtfButtons[3].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[2].gameObject.SetActive(value: false);
				wtfButtons[3].gameObject.SetActive(value: false);
			}
			if (character.highestBoss >= 17)
			{
				wtfButtons[4].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[4].gameObject.SetActive(value: false);
			}
			if (character.highestBoss >= 30)
			{
				wtfButtons[5].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[5].gameObject.SetActive(value: false);
			}
			if (character.highestBoss >= 37)
			{
				wtfButtons[6].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[6].gameObject.SetActive(value: false);
			}
			if (character.training.attackTraining[4] >= 25000 && character.training.defenseTraining[4] >= 25000)
			{
				wtfButtons[7].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[7].gameObject.SetActive(value: false);
			}
			if (character.settings.itopodOn)
			{
				wtfButtons[8].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[8].gameObject.SetActive(value: false);
			}
			if (character.settings.wandoos98On)
			{
				wtfButtons[9].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[9].gameObject.SetActive(value: false);
			}
			if (character.settings.nguOn)
			{
				wtfButtons[13].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[13].gameObject.SetActive(value: false);
			}
			if (character.settings.yggdrasilOn)
			{
				wtfButtons[10].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[10].gameObject.SetActive(value: false);
			}
			if (character.settings.beardsOn)
			{
				wtfButtons[11].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[11].gameObject.SetActive(value: false);
			}
			if (character.settings.diggersOn)
			{
				wtfButtons[12].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[12].gameObject.SetActive(value: false);
			}
			if (character.settings.beastOn)
			{
				wtfButtons[14].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[14].gameObject.SetActive(value: false);
			}
			if (character.hacks.hacksOn)
			{
				wtfButtons[15].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[15].gameObject.SetActive(value: false);
			}
			if (character.achievements.achievementComplete[145])
			{
				wtfButtons[16].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[16].gameObject.SetActive(value: false);
			}
			if (character.wishes.wishesOn)
			{
				wtfButtons[17].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[17].gameObject.SetActive(value: false);
			}
			if (character.cards.cardsOn)
			{
				wtfButtons[18].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[18].gameObject.SetActive(value: false);
			}
			if (character.cooking.unlocked)
			{
				wtfButtons[19].gameObject.SetActive(value: true);
			}
			else
			{
				wtfButtons[19].gameObject.SetActive(value: false);
			}
		}
	}

	public void loadTrainingInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Training") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Training";
		scrollbar.value = 1f;
	}

	public void loadTechnicalInfo()
	{
		if (character.platform == platform.Kong || character.platform == platform.AG)
		{
			TextAsset textAsset = Resources.Load("InfoText/BasicInfo") as TextAsset;
			infoText.text = textAsset.text;
			titleText.text = "Technical Info";
			scrollbar.value = 1f;
		}
		else if (character.platform == platform.Kartridge || character.platform == platform.Steam)
		{
			TextAsset textAsset2 = Resources.Load("InfoText/BasicInfoStandalone") as TextAsset;
			infoText.text = textAsset2.text;
			titleText.text = "Technical Info";
			scrollbar.value = 1f;
		}
	}

	public void loadNUMBERInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Number") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "All about your NUMBER";
		scrollbar.value = 1f;
	}

	public void loadAugmentInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Augmentation") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Augmentation";
		scrollbar.value = 1f;
	}

	public void loadAdventureInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Adventure") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Adventure";
		scrollbar.value = 1f;
	}

	public void loadInventoryInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Inventory") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Inventory";
		scrollbar.value = 1f;
	}

	public void loadMachineInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/TimeMachine") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "The Broken Time Machine";
		scrollbar.value = 1f;
	}

	public void loadBloodMagicInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/BloodMagic") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Blood Magic";
		scrollbar.value = 1f;
	}

	public void loadExpInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Exp") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "EXP";
		scrollbar.value = 1f;
	}

	public void loadRebirthInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Rebirth") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Rebirthing (It's awesome)";
		scrollbar.value = 1f;
	}

	public void loadAdvancedTrainingInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/AdvancedTraining") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Advanced Training";
		scrollbar.value = 1f;
	}

	public void loadWandoosInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Wandoos") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Wandoos (Eventually worth it. No, really!)";
		scrollbar.value = 1f;
	}

	public void loadNGUInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/NGU") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "NGU";
		scrollbar.value = 1f;
	}

	public void loadYggdrasilInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Yggdrasil") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "TREEEEEEEEEEEEEEEEEE";
		scrollbar.value = 1f;
	}

	public void loadBeardnfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Beards") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "BEARDS OF POWER";
		scrollbar.value = 1f;
	}

	public void loadMacguffinInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/MacGuffins") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "MACGUFFINS";
		scrollbar.value = 1f;
	}

	public void loadItopodInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Itopod") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "THE I.T.O.P.O.D";
		scrollbar.value = 1f;
	}

	public void loadDiggerInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Diggers") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "GOLD DIGGERS!";
		scrollbar.value = 1f;
	}

	public void loadQuestingInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Questing") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "QUESTING";
		scrollbar.value = 1f;
	}

	public void loadHacksInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Hacks") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "HACKS";
		scrollbar.value = 1f;
	}

	public void loadWishesInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Wishes") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "WISHES";
		scrollbar.value = 1f;
	}

	public void loadCardsInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/CARDS") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "CARDS";
		scrollbar.value = 1f;
	}

	public void loadCookingInfo()
	{
		TextAsset textAsset = Resources.Load("InfoText/Cooking") as TextAsset;
		infoText.text = textAsset.text;
		titleText.text = "Cooking";
		scrollbar.value = 1f;
	}
}
