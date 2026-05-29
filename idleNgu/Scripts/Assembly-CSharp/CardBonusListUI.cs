using UnityEngine;
using UnityEngine.UI;

public class CardBonusListUI : MonoBehaviour
{
	public Character character;

	public Text bonusNamesText;

	public Text bonusAmountsText;

	public void updatePod()
	{
		bonusNamesText.text = "";
		bonusAmountsText.text = "";
		for (int i = 1; i < character.cards.bonuses.Count; i++)
		{
			if (character.cards.bonuses[i] > 1f)
			{
				Text text = bonusNamesText;
				text.text = text.text + "<b>" + character.cardsController.getBonusName((cardBonus)i) + ":</b>\n";
				Text text2 = bonusAmountsText;
				text2.text = text2.text + "<b>" + character.cardsController.cardBonusAmountBonusPod(character.cards.bonuses[i]) + "</b>\n";
			}
		}
		if (bonusNamesText.text == "")
		{
			bonusNamesText.text = "You have literally zero bonuses, dumdum. Get some Cards to spawn and cast them, and you'll see your lovely bonuses appear right here!";
		}
	}
}
