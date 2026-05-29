using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
	public Text equipStats;

	public Character character;

	public InventoryController ic;

	public void updateDisplay(string bonusDisplay)
	{
		if (character.menuID == 4)
		{
			equipStats.text = "<b>Power:</b> +" + ic.adventureAttackBonus().ToString("###,##0.#");
			Text text = equipStats;
			text.text = text.text + "\n<b>Toughness:</b> +" + ic.adventureDefenseBonus().ToString("###,##0.#");
			Text text2 = equipStats;
			text2.text = text2.text + "\n<b>Max Health:</b> +" + ic.adventureHPBonus().ToString("###,##0.#");
			Text text3 = equipStats;
			text3.text = text3.text + "\n<b>Health Regen/s:</b> +" + ic.adventureHPRegenBonus().ToString("###,##0.##");
			equipStats.text += "\n\n<b>Special Bonuses:</b>";
			equipStats.text += bonusDisplay;
			Text text4 = equipStats;
			text4.text = text4.text + "\n\n<b>Player Stat Boosts:</b>\n<b>Attack:</b> " + ic.attackBonus().ToString("###,##0.#") + "%";
			Text text5 = equipStats;
			text5.text = text5.text + "\n<b>Defense:</b> " + ic.defenseBonus().ToString("###,##0.#") + "%";
		}
	}
}
