using UnityEngine;
using UnityEngine.UI;

public class MiscStatsDisplay : MonoBehaviour
{
	public Character character;

	public Boss boss;

	public NumberFormat format;

	public Text statTitle;

	public Text statsBreakdown;

	public Text statValue;

	public Scrollbar scrollbar;

	private string statsName;

	private string statsValue;

	public int displayMode;

	public float oldBreakdownPosition = 1f;

	private void Start()
	{
		refreshMenu();
	}

	public void updateMiscStats()
	{
		if (character.menuID == 10)
		{
			statTitle.text = "Miscellaneous Statistics";
			statsName = "<b>\nTotal Rebirths:\n";
			statsName += "\nTotal Bosses Defeated:\n";
			statsName += "\nHighest Boss Defeated:\n";
			statsName += "\nHighest Damage Dealt in 1 Hit:\n";
			statsName += "\nTitans Defeated (Adventure Mode):\n";
			statsName += "\nTotal Earned EXP:\n";
			statsName += "\nTotal Earned AP:\n";
			statsName += "\nTotal Earned Gold:\n";
			statsName += "</b>";
			statsBreakdown.text = statsName;
			statsValue = "\n" + NumberOutput.suffixFormat(character.stats.rebirthNumber, character.settings.numberDisplay);
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.stats.bossesDefeated, character.settings.numberDisplay);
			if (character.stats.highestBoss < 1)
			{
				statsValue += "\n\nNONE";
			}
			else
			{
				statsValue = statsValue + "\n\n" + character.bossController.getBossName((int)(character.stats.highestBoss - 1)) + "(" + NumberOutput.suffixFormat(character.stats.highestBoss, character.settings.numberDisplay) + ")";
			}
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.stats.highestDamageDealt, character.settings.numberDisplay);
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.stats.titansDefeated, character.settings.numberDisplay);
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.stats.totalExp, character.settings.numberDisplay);
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.arbitrary.curLifetimePoints, character.settings.numberDisplay);
			statsValue = statsValue + "\n\n" + NumberOutput.suffixFormat(character.stats.totalGold, character.settings.numberDisplay);
			statValue.text = statsValue;
			if (character.adventure.itopod.lifetimePoints > 0)
			{
				statsName += "\nTotal Earned PP:\n";
				statsValue = statsValue + "\n\n" + character.display(character.adventure.itopod.lifetimePoints);
			}
		}
	}

	public void refreshMenu()
	{
		updateMiscStats();
	}
}
