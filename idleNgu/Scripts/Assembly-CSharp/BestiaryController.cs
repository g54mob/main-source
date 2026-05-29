using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryController : MonoBehaviour
{
	public Character character;

	public List<BestiaryIconController> bestiaryIcons;

	public List<string> bestiaryFlavour;

	public Image bestiaryPortrait;

	public Text bestiaryInfoText;

	public Text enemiesDefeatedText;

	public Text pageInfo;

	public Button storyButton;

	public Button flavourButton;

	public Scrollbar scrollbar;

	public int curSelectedID = 1;

	public int pageID;

	public bestiaryType beastiaryMode;

	public void Start()
	{
		pageID = 0;
		for (int i = 0; i < bestiaryIcons.Count; i++)
		{
			bestiaryIcons[i].id = pageID + i + 1;
			bestiaryIcons[i].updateIcon();
		}
		curSelectedID = 1;
		selectNewEnemy(1);
	}

	public void setPage(int newID)
	{
		if (newID > character.bestiary.enemies.Count / bestiaryIcons.Count)
		{
			newID = character.bestiary.enemies.Count / bestiaryIcons.Count;
		}
		if (newID < 0)
		{
			newID = 0;
		}
		if (newID != pageID)
		{
			int num = newID * bestiaryIcons.Count + 1;
			for (int i = 0; i < bestiaryIcons.Count; i++)
			{
				bestiaryIcons[i].id = num + i;
				bestiaryIcons[i].updateIcon();
			}
			pageID = newID;
			updatePageText();
		}
	}

	public void updateMenu()
	{
		if (character.menuID == 24)
		{
			updateIcons();
			updatePortrait();
			updatePageText();
			updateEnemiesDefeatedText();
			updateButtons();
			selectStory();
		}
	}

	public void updateIcons()
	{
		if (character.menuID == 24)
		{
			for (int i = 0; i < bestiaryIcons.Count; i++)
			{
				bestiaryIcons[i].updateIcon();
			}
		}
	}

	public void updatePortrait()
	{
		if (character.menuID == 24)
		{
			if (curSelectedID <= 0 || curSelectedID >= character.adventureController.enemySprites.Count)
			{
				bestiaryPortrait.sprite = character.adventureController.enemySprites[0];
			}
			else
			{
				bestiaryPortrait.sprite = character.adventureController.enemySprites[curSelectedID];
			}
		}
	}

	public void updateButtons()
	{
		if (character.menuID != 24)
		{
			return;
		}
		if (curSelectedID <= 0 || curSelectedID >= character.adventureController.enemySprites.Count)
		{
			storyButton.gameObject.SetActive(value: false);
			flavourButton.gameObject.SetActive(value: false);
			return;
		}
		if (character.bestiary.enemies[curSelectedID].kills <= 0)
		{
			flavourButton.gameObject.SetActive(value: false);
		}
		else
		{
			flavourButton.gameObject.SetActive(value: true);
		}
		if (curSelectedID > 0 && curSelectedID <= 150 && character.highestBoss >= curSelectedID)
		{
			storyButton.gameObject.SetActive(value: true);
		}
		else if (curSelectedID > 150 && curSelectedID <= 200 && character.highestHardBoss >= curSelectedID)
		{
			storyButton.gameObject.SetActive(value: true);
		}
		else if (curSelectedID > 200 && curSelectedID <= 300 && character.highestSadisticBoss >= curSelectedID)
		{
			storyButton.gameObject.SetActive(value: true);
		}
		else
		{
			storyButton.gameObject.SetActive(value: false);
		}
	}

	public void updatePageText()
	{
		if (character.menuID == 24)
		{
			pageInfo.text = "<b>Enemy\n" + (pageID * bestiaryIcons.Count + 1) + "-" + (pageID + 1) * bestiaryIcons.Count + "</b>";
		}
	}

	public void updateEnemiesDefeatedText()
	{
		if (character.menuID == 24)
		{
			enemiesDefeatedText.text = "<b>Enemies Defeated: " + enemiesDefeatedCount() + "/" + character.bestiary.enemies.Count + "</b>";
		}
	}

	public int enemiesDefeatedCount()
	{
		int num = 0;
		foreach (BestiaryInfo enemy in character.bestiary.enemies)
		{
			if (enemy.kills > 0)
			{
				num++;
			}
		}
		return num;
	}

	public void selectStory()
	{
		if (curSelectedID > 0 && curSelectedID <= 301)
		{
			bestiaryInfoText.text = enemyMetaInfo() + "\n\n<b>Story</b>\n\n" + character.bossController.bossProperties[curSelectedID - 1].bossStory.text;
		}
	}

	public void selectFlavour()
	{
		if (bestiaryFlavour[curSelectedID] == "")
		{
			bestiaryInfoText.text = enemyMetaInfo() + "\n\n<b>Flavour Text</b>\n\nTo be added in a future patch!";
		}
		else
		{
			bestiaryInfoText.text = enemyMetaInfo() + "\n\n<b>Flavour Text</b>\n\n" + bestiaryFlavour[curSelectedID];
		}
	}

	public void selectNewEnemy(int newEnemyID)
	{
		if (newEnemyID > 0 && newEnemyID < character.bestiary.enemies.Count)
		{
			curSelectedID = newEnemyID;
			updatePortrait();
			updateButtons();
			if (newEnemyID > 0 && newEnemyID <= 301)
			{
				selectStory();
			}
			else
			{
				selectFlavour();
			}
			scrollbar.value = 1f;
		}
	}

	public void confirmedKill(int enemyID)
	{
		if (enemyID > 0 && enemyID < character.bestiary.enemies.Count && character.bestiary.enemies[enemyID].kills < int.MaxValue)
		{
			character.bestiary.enemies[enemyID].kills++;
			updateIcons();
			if (character.bestiary.enemies[enemyID].kills == 1)
			{
				updateEnemiesDefeatedText();
			}
		}
	}

	public void confirmedItopodKill(int enemyID)
	{
		if (enemyID > 0 && enemyID < character.bestiary.enemies.Count && character.bestiary.enemies[enemyID].kills < int.MaxValue)
		{
			character.bestiary.enemies[enemyID].kills++;
			updateIcons();
			if (character.bestiary.enemies[enemyID].kills == 1)
			{
				updateEnemiesDefeatedText();
			}
		}
	}

	public void addKills(int enemyID, int kills)
	{
		if (enemyID > 0 && enemyID < character.bestiary.enemies.Count && character.bestiary.enemies[enemyID].kills < int.MaxValue - kills)
		{
			character.bestiary.enemies[enemyID].kills += kills;
			updateIcons();
		}
	}

	public void forceUnlock(int enemyID)
	{
		if (enemyID > 0 && enemyID < character.bestiary.enemies.Count)
		{
			if (character.bestiary.enemies[enemyID].kills <= 0)
			{
				character.bestiary.enemies[enemyID].kills = 1;
			}
			updateIcons();
		}
	}

	public void pageUp()
	{
		setPage(pageID + 1);
	}

	public void pageDown()
	{
		setPage(pageID - 1);
	}

	public void goToPageMin()
	{
		setPage(0);
	}

	public void goToPageMax()
	{
		setPage(character.bestiary.enemies.Count / bestiaryIcons.Count);
	}

	public string enemyMetaInfo()
	{
		if (curSelectedID <= 0 || curSelectedID >= character.bestiary.enemies.Count)
		{
			return "";
		}
		string text = "";
		text = ((curSelectedID <= 0 || curSelectedID > 301) ? (text + "<b>" + character.adventureController.fetchEnemyNamebySpriteID(curSelectedID) + "</b>") : (text + "<b>" + character.bossController.bossProperties[curSelectedID - 1].bossName + "</b>"));
		text = text + "\n<b>Enemy # " + curSelectedID + "</b>";
		return text + "\n<b>Kills: " + character.bestiary.enemies[curSelectedID].kills + "</b>";
	}
}
