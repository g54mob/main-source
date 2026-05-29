using UnityEngine;
using UnityEngine.UI;

public class ZoneSelector : MonoBehaviour
{
	public Character character;

	public Dropdown dropdown;

	public AdventureController ac;

	public void selectZone(int zone)
	{
		zone--;
		changeZone(zone);
	}

	public void changeZone(int zone)
	{
		if (character.adventure.zone != zone)
		{
			character.adventureController.globalKillCounter = 0L;
		}
		if (zone >= 1000)
		{
			dropdown.value = 1;
			dropdown.RefreshShownValue();
			dropdown.captionText.text = "THE ITOPOD";
			ac.itopodLevel = character.adventure.itopodStart;
			ac.itopodKillCount = 0;
			if (character.adventure.clue3Complete)
			{
				ac.clue4Eligible = true;
			}
		}
		else
		{
			dropdown.value = zone + 1;
			dropdown.RefreshShownValue();
			dropdown.captionText.text = ac.zoneName(zone);
			if (ac.zone == 1000)
			{
				ac.itopodLevel = 0;
				ac.itopodKillCount = 0;
			}
		}
		Random.state = character.lootState;
		_ = Random.value;
		character.lootState = Random.state;
		ac.playerController.clearDisableFlags();
		ac.zone = zone;
		character.adventure.zone = zone;
		ac.fightInProgress = false;
		ac.respawnTimer = 0f;
		ac.idleAttackTimer = 0f;
		if (ac.currentEnemy != null)
		{
			ac.currentEnemy.curHP = ac.currentEnemy.maxHP;
		}
		ac.currentEnemy = null;
		ac.enemyAI.resetAI();
		if (zone != 1000)
		{
			ac.updateEnemyPortrait();
		}
		ac.displayEnemyStats();
		ac.bossIcon.enabled = false;
		ac.updateEnemy();
		ac.updatePlayer();
		ac.updateZone();
		ac.resetBar();
		ac.updateTitanDifficultyUI();
		ac.constructDropdown();
		dropdown.RefreshShownValue();
		dropdown.captionText.text = ac.zoneName(zone);
	}
}
