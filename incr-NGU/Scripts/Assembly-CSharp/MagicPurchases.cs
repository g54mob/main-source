using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MagicPurchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Character character;

	public Text magicSpeedText;

	public Text magicBarText;

	public Text maxMagicText;

	public Text magicPowerText;

	public InputField powerInput;

	public Button powerBuyButton;

	public InputField capInput;

	public Button capBuyButton;

	public InputField barInput;

	public Button barBuyButton;

	public Button buyAllCustom;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int magicSpeed10Cost = 3;

	private int magicSpeed100Cost = 30;

	private int magicBar1Cost = 240;

	private int magicBar10Cost = 2400;

	private int magicBar100Cost = 24000;

	private int maxMagic10KCost = 120;

	private int maxMagic100KCost = 1200;

	private int maxMagic1MCost = 12000;

	private int magicPower01Cost = 45;

	private int magicPower1Cost = 450;

	private int magicPower10Cost = 4500;

	private int magicPower100Cost = 45000;

	public void refresh()
	{
		updateMagicPurchases();
	}

	private void Awake()
	{
		noAction = cancel;
	}

	private void cancel()
	{
	}

	private void Start()
	{
		updateMagicPurchases();
	}

	private void updateMagicPurchases()
	{
		if (character.menuID == 32)
		{
			magicSpeedText.text = "<b>Total Magic Speed</b>\n" + character.totalMagicSpeed().ToString("###,##0.#") + "\n\n<b>Base Magic Speed:</b>\n" + character.magic.magicBarSpeed.ToString("###,##0.#");
			magicBarText.text = "<b>Total Magic Bars</b>\n" + character.totalMagicBar().ToString("###,##0.#") + "\n\n<b>Base Magic Bars:</b>\n" + character.magic.magicPerBar.ToString("###,##0");
			maxMagicText.text = "<b>Total Magic Cap</b>\n" + character.totalCapMagic().ToString("###,##0.#") + "\n\n<b>Base Magic Cap:</b>\n" + character.magic.capMagic.ToString("###,##0");
			magicPowerText.text = "<b>Total Magic Power</b>\n" + character.totalMagicPower().ToString("###,##0.#") + "\n\n<b>Base Magic Power:</b>\n" + character.magic.magicPower.ToString("###,##0.#");
			powerBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customPowerCost(character.settings.customMagicPowerAmount)) + " EXP";
			barBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customBarCost(character.settings.customMagicBarAmount)) + " EXP";
			capBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customCapCost(character.settings.customMagicCapAmount)) + " EXP";
			buyAllCustom.GetComponentInChildren<Text>().text = "Buy ALL Custom Purchases at once for " + NumberOutput.expPrint(customAllCost()) + " EXP";
			powerInput.text = character.settings.customMagicPowerAmount.ToString();
			barInput.text = character.settings.customMagicBarAmount.ToString();
			capInput.text = character.settings.customMagicCapAmount.ToString();
		}
	}

	public void magicSpeed10()
	{
		if (character.realExp < magicSpeed10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.magicBarSpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max Magic Bar Speed you can get! For more magic generation, try purchasing Magic Gained per bar.", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10MagicSpeed;
			box.displayBox("Are you sure you want to buy +0.1 Magic Generation Speed for " + magicSpeed10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10MagicSpeed();
		}
	}

	private void buy10MagicSpeed()
	{
		character.realExp -= magicSpeed10Cost;
		character.magic.magicBarSpeed += 0.1f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +0.1 Magic Generation Speed!", 2f);
	}

	public void magicSpeed100()
	{
		if (character.realExp < magicSpeed100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.magicBarSpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max Magic Bar Speed you can get! For more magic generation, try purchasing Magic Gained per bar.", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100MagicSpeed;
			box.displayBox("Are you sure you want to buy +1 Magic Generation Speed for " + magicSpeed100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100MagicSpeed();
		}
	}

	private void buy100MagicSpeed()
	{
		character.realExp -= magicSpeed100Cost;
		character.magic.magicBarSpeed += 1f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +1 Magic Generation Speed!", 2f);
	}

	public void magicBar1()
	{
		if (character.realExp < magicBar1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1MagicBar;
			box.displayBox("Are you sure you want to buy +1 Magic Bar for " + magicBar1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1MagicBar();
		}
	}

	private void buy1MagicBar()
	{
		character.realExp -= magicBar1Cost;
		character.magic.magicPerBar++;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +1 Magic Bar!", 2f);
	}

	public void magicBar10()
	{
		if (character.realExp < magicBar10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10MagicBar;
			box.displayBox("Are you sure you want to buy +10 Bars for " + magicBar10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10MagicBar();
		}
	}

	private void buy10MagicBar()
	{
		character.realExp -= magicBar10Cost;
		character.magic.magicPerBar += 10L;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +10 Magic Bars! Aw, this one doesn't have a punchline.", 2f);
	}

	public void magicBar100()
	{
		if (character.realExp < magicBar100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100MagicBar;
			box.displayBox("Are you sure you want to buy +100 Bars for " + magicBar100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100MagicBar();
		}
	}

	private void buy100MagicBar()
	{
		character.realExp -= magicBar100Cost;
		character.magic.magicPerBar += 100L;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +100 Magic Bars! I like trains.", 2f);
	}

	public void maxmagic10K()
	{
		if (character.realExp < maxMagic10KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10KMaxMagic;
			box.displayBox("Are you sure you want to buy +10K Max Magic for " + maxMagic10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10KMaxMagic();
		}
	}

	private void buy10KMaxMagic()
	{
		character.realExp -= maxMagic10KCost;
		character.magic.capMagic += 10000L;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +10K Max Magic!", 2f);
	}

	public void maxmagic100K()
	{
		if (character.realExp < maxMagic100KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100KMaxMagic;
			box.displayBox("Are you sure you want to buy +100K Max Magic for " + maxMagic100KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100KMaxMagic();
		}
	}

	private void buy100KMaxMagic()
	{
		character.realExp -= maxMagic100KCost;
		character.magic.capMagic += 100000L;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +100K Max Magic! Take that, Harry Potter!", 2f);
	}

	public void maxmagic1M()
	{
		if (character.realExp < maxMagic1MCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1MMaxMagic;
			box.displayBox("Are you sure you want to buy +1M Max Magic for " + maxMagic1MCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1MMaxMagic();
		}
	}

	private void buy1MMaxMagic()
	{
		character.realExp -= maxMagic1MCost;
		character.magic.capMagic += 1000000L;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +1M Max Magic! Even your farts are magical at this point.", 2f);
	}

	public void magicPower01()
	{
		if (character.realExp < magicPower01Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 1000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy01MagicPower;
			box.displayBox("Are you sure you want to buy +0.1 Magic Power for " + magicPower01Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy01MagicPower();
		}
	}

	private void buy01MagicPower()
	{
		character.realExp -= magicPower01Cost;
		character.magic.magicPower += 0.1f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +0.1 Magic Power! Now you can magic stuff faster!", 2f);
	}

	public void magicPower1()
	{
		if (character.realExp < magicPower1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 10000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1MagicPower;
			box.displayBox("Are you sure you want to buy +1 Magic Power for " + magicPower1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1MagicPower();
		}
	}

	private void buy1MagicPower()
	{
		character.realExp -= magicPower1Cost;
		character.magic.magicPower += 1f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +1 Magic Power! Go magic the hell out of that magic!", 2f);
	}

	public void magicPower10()
	{
		if (character.realExp < magicPower10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 10000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10MagicPower;
			box.displayBox("Are you sure you want to buy +10 Magic Power for " + magicPower10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10MagicPower();
		}
	}

	private void buy10MagicPower()
	{
		character.realExp -= magicPower10Cost;
		character.magic.magicPower += 10f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +10 Magic Power! So much magic, even your magic has magic!", 2f);
	}

	public void magicPower100()
	{
		if (character.realExp < magicPower100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.magic.capMagic < 10000)
		{
			tooltip.showTooltip("You haven't unlocked Magic yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100MagicPower;
			box.displayBox("Are you sure you want to buy +100 Magic Power for " + magicPower100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100MagicPower();
		}
	}

	private void buy100MagicPower()
	{
		character.realExp -= magicPower100Cost;
		character.magic.magicPower += 100f;
		updateMagicPurchases();
		tooltip.showTooltip("You've successfully bought +100 Magic Power! magicmagicmagicmagicmagicmagicmagicmagicmagicmagicmagicmagic", 2f);
	}

	public void tryCustomPower()
	{
		int customMagicPowerAmount = character.settings.customMagicPowerAmount;
		long num = customPowerCost(customMagicPowerAmount);
		if (num >= 0 && customMagicPowerAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomPower;
				box.displayBox("Are you sure you want to buy " + character.display(customMagicPowerAmount) + " Magic Power for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomPower();
			}
		}
	}

	private void buyCustomPower()
	{
		int customMagicPowerAmount = character.settings.customMagicPowerAmount;
		long num = customPowerCost(customMagicPowerAmount);
		if (num >= 0 && customMagicPowerAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.magic.magicPower += customMagicPowerAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customMagicPowerAmount) + " Magic Power!", 3f);
			updateMagicPurchases();
		}
	}

	public void tryCustomBar()
	{
		int customMagicBarAmount = character.settings.customMagicBarAmount;
		long num = customBarCost(customMagicBarAmount);
		if (num >= 0 && customMagicBarAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomBar;
				box.displayBox("Are you sure you want to buy " + character.display(customMagicBarAmount) + " Magic Bars for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomBar();
			}
		}
	}

	private void buyCustomBar()
	{
		int customMagicBarAmount = character.settings.customMagicBarAmount;
		long num = customBarCost(customMagicBarAmount);
		if (num >= 0 && customMagicBarAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.magic.magicPerBar += customMagicBarAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customMagicBarAmount) + " Magic Bars!", 3f);
			updateMagicPurchases();
		}
	}

	public void tryCustomCap()
	{
		long customMagicCapAmount = character.settings.customMagicCapAmount;
		long num = customCapCost(customMagicCapAmount);
		if (num >= 0 && customMagicCapAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomCap;
				box.displayBox("Are you sure you want to buy " + character.display(customMagicCapAmount) + " Magic Cap for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomCap();
			}
		}
	}

	private void buyCustomCap()
	{
		long customMagicCapAmount = character.settings.customMagicCapAmount;
		long num = customCapCost(customMagicCapAmount);
		if (num >= 0 && customMagicCapAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			if ((double)(character.magic.capMagic + customMagicCapAmount) >= (double)character.hardCap())
			{
				character.magic.capMagic = character.hardCap();
			}
			else
			{
				character.magic.capMagic += customMagicCapAmount;
			}
			tooltip.showTooltip("You've successfully bought " + character.display(customMagicCapAmount) + " Magic Cap!", 3f);
			updateMagicPurchases();
		}
	}

	public long customPowerCost(int amount)
	{
		return (long)amount * 150L * 3;
	}

	public long customCapCost(long amount)
	{
		return amount / 250 * 3;
	}

	public long customBarCost(int amount)
	{
		return (long)amount * 80L * 3;
	}

	public long customAllCost()
	{
		return customPowerCost(character.settings.customMagicPowerAmount) + customCapCost(character.settings.customMagicCapAmount) + customBarCost(character.settings.customMagicBarAmount);
	}

	public void updateCustomPowerInput()
	{
		if (powerInput.text == "")
		{
			powerInput.text = "0";
		}
		try
		{
			character.settings.customMagicPowerAmount = int.Parse(powerInput.text);
		}
		catch (FormatException)
		{
			character.settings.customMagicPowerAmount = 0;
		}
		if (character.settings.customMagicPowerAmount < 0)
		{
			character.settings.customMagicPowerAmount = 0;
		}
		if (character.settings.customMagicPowerAmount > 1000000000)
		{
			character.settings.customMagicPowerAmount = 1000000000;
		}
		powerInput.text = character.settings.customMagicPowerAmount.ToString();
		refresh();
	}

	public void updateCustomCapInput()
	{
		if (capInput.text == "")
		{
			capInput.text = "10000";
		}
		try
		{
			character.settings.customMagicCapAmount = long.Parse(capInput.text);
		}
		catch (FormatException)
		{
			character.settings.customMagicCapAmount = 0L;
		}
		catch (OverflowException)
		{
			character.settings.customMagicCapAmount = long.MaxValue;
		}
		if (character.settings.customMagicCapAmount == 0L)
		{
			character.settings.customMagicCapAmount = 0L;
		}
		else if (character.settings.customMagicCapAmount < 10000)
		{
			character.settings.customMagicCapAmount = 10000L;
		}
		long num = character.settings.customMagicCapAmount / 250;
		character.settings.customMagicCapAmount = num * 250;
		capInput.text = character.settings.customMagicCapAmount.ToString();
		refresh();
	}

	public void updateCustomBarInput()
	{
		if (barInput.text == "")
		{
			barInput.text = "0";
		}
		try
		{
			character.settings.customMagicBarAmount = int.Parse(barInput.text);
		}
		catch (FormatException)
		{
			character.settings.customMagicBarAmount = 0;
		}
		catch (OverflowException)
		{
			character.settings.customMagicBarAmount = 1000000000;
		}
		if (character.settings.customMagicBarAmount < 0)
		{
			character.settings.customMagicBarAmount = 0;
		}
		if (character.settings.customMagicBarAmount > 1000000000)
		{
			character.settings.customMagicBarAmount = 1000000000;
		}
		barInput.text = character.settings.customMagicBarAmount.ToString();
		refresh();
	}

	public void tryCustomAll()
	{
		long num = character.settings.customMagicPowerAmount;
		long customMagicCapAmount = character.settings.customMagicCapAmount;
		long num2 = character.settings.customMagicBarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customMagicCapAmount >= 0 && num2 >= 0)
		{
			if (character.realExp < num3)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomAll;
				box.displayBox("Are you sure you want to buy " + character.display(num) + " Magic Power, " + character.display(customMagicCapAmount) + " Magic Cap, and " + character.display(num2) + " Magic Bars for " + NumberOutput.expPrint(num3) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomAll();
			}
		}
	}

	private void buyCustomAll()
	{
		long num = character.settings.customMagicPowerAmount;
		long customMagicCapAmount = character.settings.customMagicCapAmount;
		long num2 = character.settings.customMagicBarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customMagicCapAmount >= 0 && num2 >= 0 && character.realExp >= num3)
		{
			character.realExp -= num3;
			if ((double)(character.magic.capMagic + customMagicCapAmount) >= (double)character.hardCap())
			{
				character.magic.capMagic = character.hardCap();
			}
			else
			{
				character.magic.capMagic += customMagicCapAmount;
			}
			if ((double)(character.magic.magicPower + (float)num) >= (double)character.hardCapPowBar())
			{
				character.magic.magicPower = character.hardCapPowBar();
			}
			else
			{
				character.magic.magicPower += num;
			}
			if ((double)(character.magic.magicPerBar + num2) >= (double)character.hardCapPowBar())
			{
				character.magic.magicPerBar = character.hardCapPowBar();
			}
			else
			{
				character.magic.magicPerBar += num2;
			}
			tooltip.showTooltip("You've successfully bought " + character.display(num) + " Magic Power, " + character.display(customMagicCapAmount) + " Magic Cap, and " + character.display(num2) + " Magic Bars!", 3f);
			updateMagicPurchases();
		}
	}
}
