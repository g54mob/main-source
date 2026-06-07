using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatFruitController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public NumberFormat format;

	public HoverTooltip tooltip;

	public Slider fruitSlider;

	public YggdrasilDisplay display;

	public Image fill;

	public Image background;

	public Button actionButton;

	public Button unlockButton;

	public ThreeChoiceBox box;

	private string message;

	private UnityAction action1;

	private UnityAction action2;

	private UnityAction cancelAction;

	private long baseSeedCost = 10L;

	private long baseSeedReward = 1L;

	private long activationCost = 200000L;

	private string fruitName = "Fruit of Power";

	private void Start()
	{
		cancelAction = cancel;
		updateButtonText();
		updateFruitSlider();
		InvokeRepeating("updateFruit", 0f, 1f);
	}

	public void cancel()
	{
	}

	public void reset()
	{
		character.yggdrasil.statFruit.reset(character.yggdrasil.resetFactor);
		updateButtonText();
		updateFruitSlider();
	}

	public void updateFruit()
	{
		if (character.yggdrasil.statFruit.activated)
		{
			character.yggdrasil.statFruit.addTime();
		}
		updateFruitSlider();
	}

	public void doAction()
	{
		if (character.yggdrasil.statFruit.growing())
		{
			if (character.yggdrasil.statFruit.harvestTier() > 0)
			{
				action1 = consume;
				action2 = harvest;
				box.displayBox("Do you want to:\n Eat the fruit (gaining your reward but fewer Seeds) OR \n Harvest the fruit (gain no direct benefit but 2x Seeds)", action1, action2, cancelAction, "Eat", "Harvest");
			}
			else
			{
				tooltip.showTooltip("This fruit isn't ready to eat or harvest!");
			}
		}
		else
		{
			activate();
		}
	}

	public void activate()
	{
		long num = activationCost;
		if (character.yggdrasil.statFruit.maxTier == 0L)
		{
			tooltip.showTooltip("This fruit isn't unlocked yet!", 2f);
		}
		else if (character.idleEnergy >= num)
		{
			character.idleEnergy -= num;
			character.curEnergy -= num;
			character.yggdrasil.statFruit.activate();
			updateButtonText();
		}
		else
		{
			tooltip.showTooltip("You don't have enough idle Energy to start growing this fruit!");
		}
	}

	public void consume()
	{
		int num = character.yggdrasil.statFruit.harvestTier();
		character.yggdrasil.statFruit.totalLevels += Mathf.CeilToInt(Mathf.Pow(num, 1.3f));
		character.yggdrasil.seeds += baseSeedReward * Mathf.CeilToInt(Mathf.Pow(num, 1.3f));
		character.yggdrasil.statFruit.deactivate();
		updateButtonText();
		updateFruitSlider();
	}

	public void harvest()
	{
		int num = character.yggdrasil.statFruit.harvestTier();
		character.yggdrasil.seeds += baseSeedReward * Mathf.CeilToInt(Mathf.Pow(num, 1.3f)) * 2;
		character.yggdrasil.statFruit.deactivate();
		updateButtonText();
		updateFruitSlider();
	}

	public void upgrade()
	{
		long num = baseSeedCost * Mathf.CeilToInt(Mathf.Pow(character.yggdrasil.statFruit.maxTier + 1, 2f));
		if (character.yggdrasil.seeds < num)
		{
			if (character.yggdrasil.statFruit.maxTier == 0L)
			{
				tooltip.showTooltip("You can't afford to unlock this fruit!");
			}
			else
			{
				tooltip.showTooltip("You can't afford to upgrade this fruit!");
			}
		}
		else if (character.yggdrasil.statFruit.maxTier >= 10)
		{
			tooltip.showTooltip("This fruit has the highest Max Tier possible!");
		}
		else
		{
			character.yggdrasil.seeds -= num;
			character.yggdrasil.statFruit.maxTier++;
			if (character.yggdrasil.statFruit.maxTier == 0L)
			{
				tooltip.showTooltip("You've successfully unlocked this fruit!");
			}
			else
			{
				tooltip.showTooltip("You've successfully upgraded this fruit!");
			}
		}
		updateButtonText();
		updateFruitSlider();
	}

	public void updateFruitSlider()
	{
		if (character.settings.specialAdvHpBars)
		{
			fancyFruitSlider();
		}
		else
		{
			normalFruitSlider();
		}
	}

	public void normalFruitSlider()
	{
		float value = character.yggdrasil.statFruit.seconds / 3600f % 1f;
		fill.color = Color.red;
		background.color = Color.white;
		fruitSlider.value = value;
	}

	public void fancyFruitSlider()
	{
		float a = character.yggdrasil.statFruit.seconds / 3600f;
		a = Mathf.Min(a, character.yggdrasil.statFruit.maxTier);
		float value = a % 1f;
		if (a >= 10f)
		{
			fill.color = new Color(0.51f, 0.4f, 0.95f);
			background.color = new Color(0f, 0f, 1f);
			value = 1f;
		}
		else if (a >= 9f)
		{
			fill.color = new Color(0.51f, 0.4f, 0.95f);
			background.color = new Color(0f, 0f, 1f);
		}
		else if (a >= 8f)
		{
			fill.color = new Color(0f, 0f, 1f);
			background.color = new Color(0f, 0.78f, 1f);
		}
		else if (a >= 7f)
		{
			fill.color = new Color(0f, 0.78f, 1f);
			background.color = new Color(0.25f, 0.875f, 0.81f);
		}
		else if (a >= 6f)
		{
			fill.color = new Color(0.25f, 0.875f, 0.81f);
			background.color = new Color(0.2f, 0.8f, 0.2f);
		}
		else if (a >= 5f)
		{
			fill.color = new Color(0.2f, 0.8f, 0.2f);
			background.color = new Color(0.675f, 1f, 0.2f);
		}
		else if (a >= 4f)
		{
			fill.color = new Color(0.675f, 1f, 0.2f);
			background.color = new Color(0.8f, 1f, 0.1f);
		}
		else if (a >= 3f)
		{
			fill.color = new Color(0.8f, 1f, 0.1f);
			background.color = new Color(1f, 1f, 0f);
		}
		else if (a >= 2f)
		{
			fill.color = new Color(1f, 1f, 0f);
			background.color = new Color(1f, 0.66f, 0f);
		}
		else if (a >= 1f)
		{
			fill.color = new Color(1f, 0.66f, 0f);
			background.color = new Color(255f, 0f, 0f);
		}
		else if (a >= 0f)
		{
			fill.color = new Color(255f, 0f, 0f);
			background.color = new Color(255f, 255f, 255f);
		}
		fruitSlider.value = value;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 1f);
	}

	public void showTooltip()
	{
		message = "<b>" + fruitName + "</b>\n\n";
		message += "This fruit is bursting with  blood-red juices, and it makes you hunger just staring at it. Eating this fruit will boost your stats for this rebirth.";
		message = message + "\n\n<b>Current Fruit Tier:</b> " + character.yggdrasil.statFruit.harvestTier();
		message = message + "\n\n<b>Time to next Tier:</b> " + timeToNextTier();
		message = message + "\n\n<b>Max Tier:</b> " + character.yggdrasil.statFruit.maxTier;
		if (!character.yggdrasil.statFruit.activated)
		{
			message = message + "\n\n<b>Activation Cost: </b> " + activationCost + " Energy";
		}
		else
		{
			message += "\n\n<b>Fruit activated and growing.</b>";
		}
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	private string timeToNextTier()
	{
		if (character.yggdrasil.statFruit.harvestTier() == 10)
		{
			return "MAXED OUT";
		}
		int num = (int)(3600f - character.yggdrasil.statFruit.seconds % 3600f);
		int num2 = num / 60;
		num %= 60;
		if (character.yggdrasil.statFruit.seconds / 3600f > (float)character.yggdrasil.statFruit.maxTier)
		{
			return "DONE";
		}
		if (num2 > 0)
		{
			return num2 + ":" + num.ToString("00") + " minutes";
		}
		return num + " s";
	}

	private void updateButtonText()
	{
		if (character.yggdrasil.statFruit.activated)
		{
			actionButton.GetComponentInChildren<Text>().text = "Consume";
		}
		else
		{
			actionButton.GetComponentInChildren<Text>().text = "Activate";
		}
		if (character.yggdrasil.statFruit.maxTier == 0L)
		{
			unlockButton.GetComponentInChildren<Text>().text = "Unlock";
		}
		else
		{
			unlockButton.GetComponentInChildren<Text>().text = "Upgrade";
		}
	}
}
