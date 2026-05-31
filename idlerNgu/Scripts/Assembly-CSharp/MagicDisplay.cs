using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicDisplay : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Slider magicBar;

	public Character character;

	public Text magicText;

	public HoverTooltip tooltip;

	private string tooltipMessage;

	private void Start()
	{
		magicText.text = "Magic: " + character.magic.idleMagic + "Idle\n" + character.magic.curMagic.ToString("n0") + "Total";
		InvokeRepeating("updateMagicBar", 0f, 0.02f);
	}

	private void Update()
	{
	}

	private void updateMagicBar()
	{
		long num = character.totalMagicBar();
		if (num < 0)
		{
			num = 0L;
		}
		float num2 = character.totalMagicSpeed() / 50f;
		character.magic.magicBarProgress += num2;
		updateSlider(num2);
		if (character.magic.magicBarProgress >= 1f)
		{
			character.magic.magicBarProgress = 0f;
			if ((double)character.magic.curMagic + (double)character.totalMagicBar() >= (double)character.hardCap())
			{
				num = character.totalCapMagic() - character.magic.curMagic;
				character.magic.curMagic += num;
				character.magic.idleMagic += num;
			}
			else if (character.magic.curMagic + character.totalMagicBar() > character.totalCapMagic())
			{
				num = character.totalCapMagic() - character.magic.curMagic;
				character.magic.curMagic += num;
				character.magic.idleMagic += num;
			}
			else
			{
				character.magic.curMagic += num;
				character.magic.idleMagic += num;
			}
		}
		updateMagicText();
	}

	public void updateMagicText()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			magicText.text = "";
		}
		else if (character.magic.capMagic < 10000)
		{
			magicText.text = "Locked";
		}
		else if (character.totalCapMagic() < 10000000)
		{
			magicText.text = "<b>Magic:</b> " + character.magic.idleMagic.ToString("###,###0") + " Idle\n" + character.magic.curMagic.ToString("###,##0") + " Total";
		}
		else if (character.totalCapMagic() < 1000000000)
		{
			magicText.text = "<b>M:</b> " + character.magic.idleMagic.ToString("###,##0") + " /\n" + character.magic.curMagic.ToString("###,##0");
		}
		else
		{
			magicText.text = "<b>M:</b> " + character.display(character.magic.idleMagic) + " /\n" + character.display(character.magic.curMagic);
		}
	}

	private void updateSlider(float toAdd)
	{
		if (character.magic.capMagic < 10000)
		{
			magicBar.GetComponentInChildren<Image>().color = Color.grey;
			return;
		}
		magicBar.GetComponentInChildren<Image>().color = Color.white;
		if (character.settings.antiFlickerBars && toAdd > 0.1f)
		{
			if (magicBar.value != toAdd)
			{
				magicBar.value = toAdd;
			}
		}
		else if (magicBar.value != character.magic.magicBarProgress)
		{
			magicBar.value = character.magic.magicBarProgress;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("tooltipDisplay", 0f, 0.1f);
	}

	public void tooltipDisplay()
	{
		if (character.magic.capMagic < 10000)
		{
			tooltipMessage = "Defeat boss 37 to see this sweet-ass bar do stuff. Like, filling up!";
			tooltip.showTooltip(tooltipMessage);
			return;
		}
		if (character.totalCapMagic() < 1000000000)
		{
			tooltipMessage = "Your Magic is currently capped at:\n<b><color=#275AADFF>" + character.totalCapMagic().ToString("###,##0") + "</color></b>";
		}
		else
		{
			tooltipMessage = "Your Magic is currently capped at:\n<b><color=#275AADFF>" + character.display(character.totalCapMagic()) + "</color></b>";
		}
		if (character.totalCapMagic() < 1000000000)
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.magicPerSecond().ToString("###,##0") + " Magic per second.";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.display(character.magicPerSecond()) + " Magic per second.";
		}
		if (character.magicPerSecond() > 0f)
		{
			float num = (float)(character.totalCapMagic() - character.magic.curMagic) / character.magicPerSecond();
			if (num > 0f)
			{
				tooltipMessage = tooltipMessage + "\nYou will hit your Magic cap in <b>" + NumberOutput.timeOutput(num) + "</b>";
			}
		}
		if (character.totalMagicSpeed() < 50f && character.totalMagicSpeed() > 0f)
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent Magic Speed is " + character.totalMagicSpeed().ToString("#0.#") + ", meaning the bar fills every " + ticksperFill() + " ticks.";
			tooltipMessage = tooltipMessage + " Next Speed Increase is at  " + nextIncrease().ToString("#0.#") + " Magic Speed";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent Magic Speed is " + character.totalMagicSpeed().ToString("#0.#");
		}
		tooltipMessage += "\n\nSHORTCUT: Tap T to reclaim Magic from all features.";
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("tooltipDisplay");
		tooltip.hideTooltip();
	}

	public int ticksperFill()
	{
		return Mathf.CeilToInt(50f / character.totalMagicSpeed());
	}

	public float nextIncrease()
	{
		return 50f / (float)Mathf.FloorToInt(50f / character.totalMagicSpeed());
	}
}
