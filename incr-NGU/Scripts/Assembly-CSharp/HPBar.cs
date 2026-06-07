using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	public Character character;

	public Slider hpBar;

	public Text hpText;

	public NumberFormat format;

	private void Start()
	{
		hpBar.value = 1f;
		InvokeRepeating("updateHPBar", 0f, 0.02f);
	}

	private void updateHPBar()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			if (hpText.text != "")
			{
				hpText.text = "";
			}
			if (character.allChallenges.blindChallenge.completions() < 1)
			{
				hpBar.value = (float)(character.curHP / character.maxHP);
			}
			else if (hpBar.value != 0f)
			{
				hpBar.value = 0f;
			}
		}
		else
		{
			hpText.text = format.suffixFormat(character.curHP) + " HP";
			hpBar.value = (float)(character.curHP / character.maxHP);
		}
	}
}
