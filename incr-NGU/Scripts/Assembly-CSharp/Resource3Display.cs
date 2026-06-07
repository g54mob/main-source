using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Resource3Display : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Slider res3Bar;

	public Image res3Fill;

	public Image res3Background;

	public Character character;

	public Text res3Text;

	public Text res3InputTitle;

	public HoverTooltip tooltip;

	public CUIColorPicker colorPicker;

	public List<string> res3Names;

	private string tooltipMessage;

	private void Start()
	{
		res3Text.text = character.res3.res3Name + ": " + character.res3.idleRes3 + "Idle\n" + character.res3.curRes3.ToString("n0") + "Total";
		InvokeRepeating("updateRes3Bar", 0f, 0.02f);
		colorPicker.SetOnValueChangeCallback(onColorChange);
	}

	public void onColorChange(Color newColour)
	{
		character.res3.res3R = newColour.r;
		character.res3.res3G = newColour.g;
		character.res3.res3B = newColour.b;
	}

	private void Update()
	{
	}

	private void updateRes3Bar()
	{
		long num = character.totalRes3Bar();
		if (num < 0)
		{
			num = 0L;
		}
		float num2 = character.totalRes3Speed() / 50f;
		character.res3.res3BarProgress += num2;
		updateSlider(num2);
		if (character.res3.res3BarProgress >= 1f)
		{
			character.res3.res3BarProgress = 0f;
			if ((double)character.res3.curRes3 + (double)character.totalRes3Bar() >= (double)character.hardCap())
			{
				num = character.totalCapRes3() - character.res3.curRes3;
				character.res3.curRes3 += num;
				character.res3.idleRes3 += num;
			}
			else if (character.res3.curRes3 + character.totalRes3Bar() > character.totalCapRes3())
			{
				num = character.totalCapRes3() - character.res3.curRes3;
				character.res3.curRes3 += num;
				character.res3.idleRes3 += num;
			}
			else
			{
				character.res3.curRes3 += num;
				character.res3.idleRes3 += num;
			}
		}
		updateRes3Text();
	}

	public void updateRes3Text()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			res3Text.color = Color.black;
			res3Background.color = Color.white;
			res3Text.text = "";
			return;
		}
		if (character.res3.capRes3 < 10000)
		{
			res3Text.color = Color.black;
			res3Background.color = Color.grey;
			res3Text.text = "Locked";
			return;
		}
		if (0.3f * character.res3.res3R + 0.59f * character.res3.res3G + 0.11f * character.res3.res3B >= 0.4f)
		{
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				res3Background.color = Color.grey;
			}
			else
			{
				res3Background.color = Color.white;
			}
			res3Text.color = Color.black;
		}
		else
		{
			res3Text.color = Color.white;
			res3Background.color = Color.grey;
		}
		if (character.totalCapRes3() < 10000000)
		{
			res3Text.text = "<b>" + character.res3.res3Name + ":</b> " + character.res3.idleRes3.ToString("###,###0") + " Idle\n" + character.res3.curRes3.ToString("###,##0") + " Total";
		}
		else if (character.totalCapRes3() < 1000000000)
		{
			string text = character.res3.res3Name[0].ToString().ToUpper();
			res3Text.text = "<b>" + text + ":</b> " + character.res3.idleRes3.ToString("###,##0") + " /\n" + character.res3.curRes3.ToString("###,##0");
		}
		else
		{
			string text2 = character.res3.res3Name[0].ToString().ToUpper();
			res3Text.text = "<b>" + text2 + ":</b> " + character.display(character.res3.idleRes3) + " /\n" + character.display(character.res3.curRes3);
		}
	}

	private void updateSlider(float toAdd)
	{
		if (character.res3.capRes3 < 10000)
		{
			res3Bar.GetComponentInChildren<Image>().color = Color.grey;
			if (res3Bar.value != 0f)
			{
				res3Bar.value = 0f;
			}
			return;
		}
		if (res3Bar.GetComponentInChildren<Image>().color != Color.white)
		{
			res3Bar.GetComponentInChildren<Image>().color = Color.white;
		}
		if (res3Fill.color != new Color(character.res3.res3R, character.res3.res3G, character.res3.res3B))
		{
			res3Fill.color = new Color(character.res3.res3R, character.res3.res3G, character.res3.res3B);
		}
		if (character.settings.antiFlickerBars && toAdd > 0.1f)
		{
			if (res3Bar.value != toAdd)
			{
				res3Bar.value = toAdd;
			}
		}
		else if (res3Bar.value != character.res3.res3BarProgress)
		{
			res3Bar.value = character.res3.res3BarProgress;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("tooltipDisplay", 0f, 0.1f);
	}

	public void tooltipDisplay()
	{
		if (character.res3.capRes3 < 10000)
		{
			tooltipMessage = "You're not NERDY enough to unlock this. Go watch more Star Trek or something. Bazinga.";
			tooltip.showTooltip(tooltipMessage);
			return;
		}
		if (character.totalCapRes3() < 1000000000)
		{
			tooltipMessage = "Your " + character.res3.res3Name + " is currently capped at:\n<b><color=#" + character.res3.colourHexString() + ">" + character.totalCapRes3().ToString("###,##0") + "</color></b>";
		}
		else
		{
			tooltipMessage = "Your " + character.res3.res3Name + " is currently capped at:\n<b><color=#" + character.res3.colourHexString() + ">" + character.display(character.totalCapRes3()) + "</color></b>";
		}
		if (character.totalCapRes3() < 1000000000)
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.res3PerSecond().ToString("###,##0") + " " + character.res3.res3Name + " per second.";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\nYou currently make " + character.display(character.res3PerSecond()) + " " + character.res3.res3Name + " per second.";
		}
		if (character.res3PerSecond() > 0f)
		{
			float num = (float)(character.totalCapRes3() - character.res3.curRes3) / character.res3PerSecond();
			if (num > 0f)
			{
				tooltipMessage = tooltipMessage + "\nYou will hit your " + character.res3.res3Name + " cap in <b>" + NumberOutput.timeOutput(num) + "</b>";
			}
		}
		if (character.totalRes3Speed() < 50f && character.totalRes3Speed() > 0f)
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent " + character.res3.res3Name + " Speed is " + character.totalRes3Speed().ToString("#0.#") + ", meaning the bar fills every " + ticksperFill() + " ticks.";
			tooltipMessage = tooltipMessage + " Next Speed Increase is at  " + nextIncrease().ToString("#0.#") + " " + character.res3.res3Name + " Speed";
		}
		else
		{
			tooltipMessage = tooltipMessage + "\n\nCurrent " + character.res3.res3Name + " Speed is " + character.totalRes3Speed().ToString("#0.#");
		}
		tooltipMessage = tooltipMessage + "\n\nSHORTCUT: Press F to reclaim " + character.res3.res3Name + " from all features.";
		tooltipMessage += "\n\n<b>Reminder:</b> You can change the name and colour of this resource in Page 2 of Settings!";
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("tooltipDisplay");
		tooltip.hideTooltip();
	}

	public int ticksperFill()
	{
		return Mathf.CeilToInt(50f / character.totalRes3Speed());
	}

	public float nextIncrease()
	{
		return 50f / (float)Mathf.FloorToInt(50f / character.totalRes3Speed());
	}

	public void unlockResource3()
	{
		if (!character.res3.res3On)
		{
			if (character.res3.capRes3 < 10000)
			{
				character.res3.capRes3 = 10000L;
			}
			if (character.res3.res3BarSpeed < 3f)
			{
				character.res3.res3BarSpeed = 3f;
			}
			if (character.res3.res3PerBar < 1)
			{
				character.res3.res3PerBar = 1L;
			}
			character.res3.res3Name = randomStarterName();
			character.res3.res3On = true;
		}
	}

	public string randomStarterName()
	{
		int num = Random.Range(0, res3Names.Count);
		if (num < 0 || num > res3Names.Count)
		{
			return "Butts";
		}
		return res3Names[num];
	}
}
