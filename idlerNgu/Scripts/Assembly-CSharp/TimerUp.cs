using UnityEngine;
using UnityEngine.UI;

public class TimerUp : MonoBehaviour
{
	public Character character;

	public Text timerText;

	private void Start()
	{
		InvokeRepeating("updateText", 0f, 0.1f);
		InvokeRepeating("checkTriggers", 0f, 1f);
	}

	private void Update()
	{
		updateTime();
	}

	public void updateTime()
	{
		character.rebirthTime.advanceTime(Time.deltaTime);
	}

	public void checkTriggers()
	{
		if (character.adventure.itopod.perkLevel[16] >= 1 && character.yggdrasil.fruits[6].maxTier >= 1 && character.rebirthTime.totalseconds >= 1800.0 && !character.yggdrasil.permBonusOn)
		{
			character.yggdrasil.permBonusOn = true;
		}
		if (character.adventure.itopod.perkLevel[17] >= 1 && character.yggdrasil.fruits[8].maxTier >= 1 && character.rebirthTime.totalseconds >= 1800.0 && !character.yggdrasil.permNumberBonusOn)
		{
			character.yggdrasil.permNumberBonusOn = true;
		}
	}

	private void updateText()
	{
		timerText.text = "<b>Current Rebirth Time:</b> " + character.rebirthTime.timeDisplayColon();
	}
}
