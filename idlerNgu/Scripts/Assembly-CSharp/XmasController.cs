using UnityEngine;
using UnityEngine.UI;

public class XmasController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Text santaText;

	public Button naughtyButton;

	public Button niceButton;

	public void updateMenu()
	{
		if (character.menuID != 54)
		{
			return;
		}
		if (character.settings.picked2ndPrize)
		{
			naughtyButton.gameObject.SetActive(value: false);
			niceButton.gameObject.SetActive(value: false);
			if (character.settings.isNaughty)
			{
				santaText.text = "I GUESS YOU'RE NAUGHTY THEN. I gave you some stupid crap but i'm not going to tell you what because i'm a grumpy arse. Maybe it's AP. Maybe it's a portrait. I dunno!";
			}
			else
			{
				santaText.text = "I GUESS YOU'RE NICE THEN. I gave you some stupid crap but i'm not going to tell you what because i'm a grumpy arse. Maybe it's AP. Maybe it's a portrait. I dunno!";
			}
		}
		else
		{
			naughtyButton.gameObject.SetActive(value: true);
			niceButton.gameObject.SetActive(value: true);
			santaText.text = "UUG, krissmuss again???\nI'm too lazy for this crap. HERE, mark yourself on my naughty or nice list, and i'll make up something dumb to give you. ";
		}
	}

	public void pickPrize(bool isNaughty)
	{
		if (!character.settings.picked2ndPrize)
		{
			character.settings.picked2ndPrize = true;
			character.settings.isNaughty = isNaughty;
			if (character.settings.isNaughty)
			{
				character.arbitrary.curArbitraryPoints += 25000L;
				character.portraits.portraitUnlocked[68] = true;
			}
			else
			{
				character.arbitrary.curArbitraryPoints += 25000L;
				character.portraits.portraitUnlocked[67] = true;
			}
			updateMenu();
		}
	}
}
