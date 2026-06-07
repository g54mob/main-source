using UnityEngine;
using UnityEngine.UI;

public class AttackDefense : MonoBehaviour
{
	public Text attackText;

	public Text defenseText;

	public Text goldText;

	public Character character;

	public NumberFormat format;

	private void Start()
	{
		InvokeRepeating("updateAttackDef", 0f, 0.5f);
		InvokeRepeating("updateGold", 0f, 0.02f);
	}

	private void updateAttackDef()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			attackText.text = "";
			defenseText.text = "";
		}
		else
		{
			defenseText.text = NumberOutput.suffixFormat(character.defense, character.settings.numberDisplay);
			attackText.text = NumberOutput.suffixFormat(character.attack, character.settings.numberDisplay);
		}
	}

	private void updateGold()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			goldText.text = "";
		}
		else
		{
			goldText.text = NumberOutput.suffixFormat(character.realGold, character.settings.numberDisplay);
		}
	}
}
