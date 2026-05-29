using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Energy : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Slider energyBar;

	public Character character;

	public InventoryController inventoryController;

	public Text energyText;

	public HoverTooltip tooltip;

	private string tooltipMessage;

	private void Start()
	{
		updateEnergyText();
		InvokeRepeating("updateBar", 0.1f, 0.02f);
	}

	private void updateBar()
	{
		float num = 0f;
		if (character.mainMenu.doneInitialLoad)
		{
			num = character.totalEnergySpeed() / 50f;
		}
		if (num >= 1f)
		{
			character.energyBarProgress = 1f;
			addEnergy();
			updateEnergyText();
			updateSlider(num);
		}
		else
		{
			updateEnergyText();
			character.energyBarProgress += num;
			if (character.energyBarProgress >= 1f)
			{
				addEnergy();
				character.energyBarProgress = 0f;
				updateEnergyText();
			}
		}
		updateSlider(num);
	}

	private void updateSlider(float toAdd)
	{
		if (character.settings.antiFlickerBars && toAdd > 0.1f)
		{
			if (energyBar.value != toAdd)
			{
				energyBar.value = toAdd;
			}
		}
		else if (energyBar.value != character.energyBarProgress)
		{
			energyBar.value = character.energyBarProgress;
		}
	}

	private void addEnergy()
	{
		long num = character.totalEnergyBar();
		if (num < 0)
		{
			num = 0L;
		}
		if (character.energyGained < 3000000)
		{
			character.energyGained += num;
		}
		if ((double)character.curEnergy + (double)num >= (double)character.hardCap())
		{
			num = character.totalCapEnergy() - character.curEnergy;
			character.curEnergy += num;
			character.idleEnergy += num;
		}
		else
		{
			if (character.curEnergy + num > character.totalCapEnergy())
			{
				num = character.totalCapEnergy() - character.curEnergy;
			}
			character.curEnergy += num;
			character.idleEnergy += num;
		}
		if ((double)(character.stats.lifeTimeEnergy + num) < (double)character.hardCap())
		{
			character.stats.lifeTimeEnergy += num;
		}
	}

	public void updateEnergyText()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			energyText.text = "";
			return;
		}
		if (character.totalCapEnergy() >= 1000000000)
		{
			energyText.text = "<b>E: </b>" + character.display(character.idleEnergy) + " /\n " + character.display(character.curEnergy);
			return;
		}
		if (character.totalCapEnergy() >= 10000000)
		{
			energyText.text = "<b>E: </b>" + character.idleEnergy.ToString("###,##0") + " /\n " + character.curEnergy.ToString("###,##0");
			return;
		}
		energyText.text = "<b>Energy:</b> " + character.idleEnergy.ToString("###,##0") + " Idle\n" + character.curEnergy.ToString("###,##0") + " Cap";
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("tooltipDisplay", 0f, 0.1f);
	}

	public void tooltipDisplay()
	{
		float num = ((character.capEnergy < 100000) ? Mathf.Min(100000f, Mathf.Floor(character.energyGained / 20) + 500f) : ((float)character.capEnergy));
		if (character.capEnergy < 100000)
		{
			tooltipMessage = "Max energy on this rebirth is capped at " + character.totalCapEnergy().ToString("###,##0") + ". On rebirth, you will have " + num + " Energy.";
			tooltipMessage += "\nEvery 20 Energy gained grants 1 extra energy to your max upon rebirth, up to 100,000.";
		}
		else if (character.totalCapEnergy() < 1000000000)
		{
			tooltipMessage = "Max energy on this rebirth is capped at:\n<b><color=#2E814AFF>" + character.totalCapEnergy().ToString("###,##0") + "</color></b>";
		}
		else
		{
			tooltipMessage = "Max energy on this rebirth is capped at:\n<b><color=#2E814AFF>" + character.display(character.totalCapEnergy()) + "</color></b>";
		}
		if (character.totalCapEnergy() < 1000000000)
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.energyPerSecond().ToString("###,##0") + " Energy per second.";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.display(character.energyPerSecond()) + " Energy per second.";
		}
		if (character.energyPerSecond() > 0f)
		{
			float num2 = (float)(character.totalCapEnergy() - character.curEnergy) / character.energyPerSecond();
			if (num2 > 0f)
			{
				tooltipMessage = tooltipMessage + "\nYou will hit your Energy cap in <b>" + NumberOutput.timeOutput(num2) + "</b>";
			}
		}
		if (character.totalEnergySpeed() < 50f)
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent Energy Speed is " + character.totalEnergySpeed().ToString("#0.#") + ", meaning the bar fills every " + ticksperFill() + " ticks.";
			tooltipMessage = tooltipMessage + " Next Speed Increase is at  " + nextIncrease().ToString("#0.#") + " Energy Speed";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent Energy Speed is " + character.totalEnergySpeed().ToString("#0.#");
		}
		tooltipMessage += "\n\nSHORTCUT: Tap R to reclaim Energy from all features except training.";
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("tooltipDisplay");
		tooltip.hideTooltip();
	}

	public int ticksperFill()
	{
		return Mathf.CeilToInt(50f / character.totalEnergySpeed());
	}

	public float nextIncrease()
	{
		return 50f / (float)Mathf.FloorToInt(50f / character.totalEnergySpeed());
	}
}
