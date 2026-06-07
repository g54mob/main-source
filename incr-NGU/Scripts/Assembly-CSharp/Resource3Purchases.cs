using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Resource3Purchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Character character;

	public Text res3TitleText;

	public Text res3SpeedText;

	public Text res3BarText;

	public Text res3CapText;

	public Text res3PowerText;

	public InputField powerInput;

	public Button powerBuyButton;

	public InputField capInput;

	public Button capBuyButton;

	public InputField barInput;

	public Button barBuyButton;

	public Button buyAllCustom;

	private UnityAction yesAction;

	private UnityAction noAction;

	private long res3Speed10Cost = 300000L;

	private long res3Speed100Cost = 3000000L;

	private long res3Bar1Cost = 8000000L;

	private long res3Bar10Cost = 80000000L;

	private long res3Bar100Cost = 800000000L;

	private long maxRes3Cost10K = 4000000L;

	private long maxRes3Cost100K = 40000000L;

	private long maxRes3Cost1M = 400000000L;

	private long res3PowerCost01 = 1500000L;

	private long res3PowerCost1 = 15000000L;

	private long res3PowerCost10 = 150000000L;

	private long res3PowerCost100 = 1500000000L;

	public void refresh()
	{
		updateRes3Purchases();
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
		updateRes3Purchases();
	}

	private void updateRes3Purchases()
	{
		if (character.menuID == 51)
		{
			res3TitleText.text = character.res3.res3Name;
			res3SpeedText.text = "<b>Total " + character.res3.res3Name + " Speed</b>\n" + character.totalRes3Speed().ToString("###,##0.#") + "\n\n<b>Base " + character.res3.res3Name + " Speed:</b>\n" + character.res3.res3BarSpeed.ToString("###,##0.#");
			res3BarText.text = "<b>Total " + character.res3.res3Name + " Bars</b>\n" + character.totalRes3Bar().ToString("###,##0.#") + "\n\n<b>Base " + character.res3.res3Name + " Bars:</b>\n" + character.res3.res3PerBar.ToString("###,##0");
			res3CapText.text = "<b>Total " + character.res3.res3Name + " Cap </b>\n" + character.totalCapRes3().ToString("###,##0.#") + "\n\n<b>Base " + character.res3.res3Name + " Cap:</b>\n" + character.res3.capRes3.ToString("###,##0");
			res3PowerText.text = "<b>Total " + character.res3.res3Name + " Power </b>\n" + character.totalRes3Power().ToString("###,##0.#") + "\n\n<b>Base " + character.res3.res3Name + " Power:</b>\n" + character.res3.res3Power.ToString("###,##0.#");
			powerBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customPowerCost(character.settings.customRes3PowerAmount)) + " EXP";
			barBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customBarCost(character.settings.customRes3BarAmount)) + " EXP";
			capBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customCapCost(character.settings.customRes3CapAmount)) + " EXP";
			buyAllCustom.GetComponentInChildren<Text>().text = "Buy ALL Custom Purchases at once for " + NumberOutput.expPrint(customAllCost()) + " EXP";
			powerInput.text = character.settings.customRes3PowerAmount.ToString();
			barInput.text = character.settings.customRes3BarAmount.ToString();
			capInput.text = character.settings.customRes3CapAmount.ToString();
		}
	}

	public void res3Speed10()
	{
		if (character.realExp < res3Speed10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.res3BarSpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max " + character.res3.res3Name + " Bar Speed you can get! For more " + character.res3.res3Name + " generation, try purchasing " + character.res3.res3Name + " Gained per bar.", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10Res3Speed;
			box.displayBox("Are you sure you want to buy +0.1 " + character.res3.res3Name + " Generation Speed for " + NumberOutput.expPrint(res3Speed10Cost) + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10Res3Speed();
		}
	}

	private void buy10Res3Speed()
	{
		character.realExp -= res3Speed10Cost;
		character.res3.res3BarSpeed += 0.1f;
		if (character.res3.res3BarSpeed >= 49.91f && character.res3.res3BarSpeed < 50f)
		{
			character.res3.res3BarSpeed = 50f;
		}
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +0.1 " + character.res3.res3Name + " Generation Speed!", 2f);
	}

	public void res3Speed100()
	{
		if (character.realExp < res3Speed100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.res3BarSpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max " + character.res3.res3Name + " Bar Speed you can get! For more " + character.res3.res3Name + " generation, try purchasing " + character.res3.res3Name + " Gained per bar.", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100Res3Speed;
			box.displayBox("Are you sure you want to buy +1 " + character.res3.res3Name + " Generation Speed for " + NumberOutput.expPrint(res3Speed100Cost) + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100Res3Speed();
		}
	}

	private void buy100Res3Speed()
	{
		character.realExp -= res3Speed100Cost;
		character.res3.res3BarSpeed += 1f;
		if (character.res3.res3BarSpeed >= 49.91f && character.res3.res3BarSpeed < 50f)
		{
			character.res3.res3BarSpeed = 50f;
		}
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +1 " + character.res3.res3Name + " Generation Speed!", 2f);
	}

	public void res3Bar1()
	{
		if (character.realExp < res3Bar1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy1Res3Bar;
			box.displayBox("Are you sure you want to buy +1 " + character.res3.res3Name + " Bar for " + NumberOutput.expPrint(res3Bar1Cost) + " EXP?", yesAction, noAction);
		}
		else
		{
			buy1Res3Bar();
		}
	}

	private void buy1Res3Bar()
	{
		character.realExp -= res3Bar1Cost;
		character.res3.res3PerBar++;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +1 " + character.res3.res3Name + " Bar!", 2f);
	}

	public void res3Bar10()
	{
		if (character.realExp < res3Bar10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy10Res3Bar;
			box.displayBox("Are you sure you want to buy +10 Bars for " + NumberOutput.expPrint(res3Bar10Cost) + " EXP?", yesAction, noAction);
		}
		else
		{
			buy10Res3Bar();
		}
	}

	private void buy10Res3Bar()
	{
		character.realExp -= res3Bar10Cost;
		character.res3.res3PerBar += 10L;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +10 " + character.res3.res3Name + " Bars! Aw, this one doesn't have a punchline.", 2f);
	}

	public void res3Bar100()
	{
		if (character.realExp < res3Bar100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 1000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buy100Res3Bar;
			box.displayBox("Are you sure you want to buy +100 Bars for " + NumberOutput.expPrint(res3Bar100Cost) + " EXP?", yesAction, noAction);
		}
		else
		{
			buy100Res3Bar();
		}
	}

	private void buy100Res3Bar()
	{
		character.realExp -= res3Bar100Cost;
		character.res3.res3PerBar += 100L;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +100 " + character.res3.res3Name + " Bars! I like trains.", 2f);
	}

	public void res3Cap10K()
	{
		if (character.realExp < maxRes3Cost10K)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 1000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Cap10K;
			box.displayBox("Are you sure you want to buy +10K Max " + character.res3.res3Name + " for " + NumberOutput.expPrint(maxRes3Cost10K) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Cap10K();
		}
	}

	private void buyRes3Cap10K()
	{
		character.realExp -= maxRes3Cost10K;
		character.res3.capRes3 += 10000L;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +10K Max " + character.res3.res3Name + "!", 2f);
	}

	public void res3Cap100K()
	{
		if (character.realExp < maxRes3Cost100K)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Cap100K;
			box.displayBox("Are you sure you want to buy +100K Max " + character.res3.res3Name + " for " + NumberOutput.expPrint(maxRes3Cost100K) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Cap100K();
		}
	}

	private void buyRes3Cap100K()
	{
		character.realExp -= maxRes3Cost100K;
		character.res3.capRes3 += 100000L;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +100K Max " + character.res3.res3Name + "! Take that, Harry Potter!", 2f);
	}

	public void res3Cap1M()
	{
		if (character.realExp < maxRes3Cost1M)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Cap1M;
			box.displayBox("Are you sure you want to buy +1M Max " + character.res3.res3Name + " for " + NumberOutput.expPrint(maxRes3Cost1M) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Cap1M();
		}
	}

	private void buyRes3Cap1M()
	{
		character.realExp -= maxRes3Cost1M;
		character.res3.capRes3 += 1000000L;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +1M Max " + character.res3.res3Name + "! Even your farts contain " + character.res3.res3Name + " at this point.", 2f);
	}

	public void res3Power01()
	{
		if (character.realExp < res3PowerCost01)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Power01;
			box.displayBox("Are you sure you want to buy +0.1 " + character.res3.res3Name + " Power for " + NumberOutput.expPrint(res3PowerCost01) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Power01();
		}
	}

	private void buyRes3Power01()
	{
		character.realExp -= res3PowerCost01;
		character.res3.res3Power += 0.1f;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +0.1 " + character.res3.res3Name + " Power! Now you can " + character.res3.res3Name + " stuff faster!", 2f);
	}

	public void res3Power1()
	{
		if (character.realExp < res3PowerCost1)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Power1;
			box.displayBox("Are you sure you want to buy +1 " + character.res3.res3Name + " Power for " + NumberOutput.expPrint(res3PowerCost1) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Power1();
		}
	}

	private void buyRes3Power1()
	{
		character.realExp -= res3PowerCost1;
		character.res3.res3Power += 1f;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +1 " + character.res3.res3Name + " Power! Go " + character.res3.res3Name + " the hell out of that " + character.res3.res3Name + "!", 2f);
	}

	public void res3Power10()
	{
		if (character.realExp < res3PowerCost10)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Power10;
			box.displayBox("Are you sure you want to buy +10 " + character.res3.res3Name + " Power for " + NumberOutput.expPrint(res3PowerCost10) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Power10();
		}
	}

	private void buyRes3Power10()
	{
		character.realExp -= res3PowerCost10;
		character.res3.res3Power += 10f;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +10 " + character.res3.res3Name + " Power! So much " + character.res3.res3Name + ", even your " + character.res3.res3Name + " has " + character.res3.res3Name + "!", 2f);
	}

	public void res3Power100()
	{
		if (character.realExp < res3PowerCost100)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.res3.capRes3 < 10000)
		{
			tooltip.showTooltip("You haven't unlocked " + character.res3.res3Name + " yet! Why are you buying upgrades for it, silly?", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyRes3Power100;
			box.displayBox("Are you sure you want to buy +10 " + character.res3.res3Name + " Power for " + NumberOutput.expPrint(res3PowerCost100) + " EXP?", yesAction, noAction);
		}
		else
		{
			buyRes3Power100();
		}
	}

	private void buyRes3Power100()
	{
		character.realExp -= res3PowerCost100;
		character.res3.res3Power += 100f;
		updateRes3Purchases();
		tooltip.showTooltip("You've successfully bought +100 " + character.res3.res3Name + " Power! That sure is one powerful " + character.res3.res3Name + "!", 2f);
	}

	public void tryCustomPower()
	{
		int customRes3PowerAmount = character.settings.customRes3PowerAmount;
		long num = customPowerCost(customRes3PowerAmount);
		if (num >= 0 && customRes3PowerAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomPower;
				box.displayBox("Are you sure you want to buy " + character.display(customRes3PowerAmount) + " " + character.res3.res3Name + " Power for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomPower();
			}
		}
	}

	private void buyCustomPower()
	{
		int customRes3PowerAmount = character.settings.customRes3PowerAmount;
		long num = customPowerCost(customRes3PowerAmount);
		if (num >= 0 && customRes3PowerAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.res3.res3Power += customRes3PowerAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customRes3PowerAmount) + " " + character.res3.res3Name + " Power!", 3f);
			updateRes3Purchases();
		}
	}

	public void tryCustomBar()
	{
		int customRes3BarAmount = character.settings.customRes3BarAmount;
		long num = customBarCost(customRes3BarAmount);
		if (num >= 0 && customRes3BarAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomBar;
				box.displayBox("Are you sure you want to buy " + character.display(customRes3BarAmount) + " " + character.res3.res3Name + " Bars for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomBar();
			}
		}
	}

	private void buyCustomBar()
	{
		int customRes3BarAmount = character.settings.customRes3BarAmount;
		long num = customBarCost(customRes3BarAmount);
		if (num >= 0 && customRes3BarAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.res3.res3PerBar += customRes3BarAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customRes3BarAmount) + " " + character.res3.res3Name + " Bars!", 3f);
			updateRes3Purchases();
		}
	}

	public void tryCustomCap()
	{
		long customRes3CapAmount = character.settings.customRes3CapAmount;
		long num = customCapCost(customRes3CapAmount);
		if (num >= 0 && customRes3CapAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomCap;
				box.displayBox("Are you sure you want to buy " + character.display(customRes3CapAmount) + " " + character.res3.res3Name + " Cap for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomCap();
			}
		}
	}

	private void buyCustomCap()
	{
		long customRes3CapAmount = character.settings.customRes3CapAmount;
		long num = customCapCost(customRes3CapAmount);
		if (num >= 0 && customRes3CapAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			if ((double)(character.res3.capRes3 + customRes3CapAmount) >= (double)character.hardCap())
			{
				character.res3.capRes3 = character.hardCap();
			}
			else
			{
				character.res3.capRes3 += customRes3CapAmount;
			}
			tooltip.showTooltip("You've successfully bought " + character.display(customRes3CapAmount) + " " + character.res3.res3Name + " Cap!", 3f);
			updateRes3Purchases();
		}
	}

	public long customPowerCost(int amount)
	{
		return (long)amount * 150L * 100000;
	}

	public long customCapCost(long amount)
	{
		return amount / 250 * 100000;
	}

	public long customBarCost(int amount)
	{
		return (long)amount * 80L * 100000;
	}

	public long customAllCost()
	{
		return customPowerCost(character.settings.customRes3PowerAmount) + customCapCost(character.settings.customRes3CapAmount) + customBarCost(character.settings.customRes3BarAmount);
	}

	public void updateCustomPowerInput()
	{
		if (powerInput.text == "")
		{
			powerInput.text = "0";
		}
		try
		{
			character.settings.customRes3PowerAmount = int.Parse(powerInput.text);
		}
		catch (FormatException)
		{
			character.settings.customRes3PowerAmount = 0;
		}
		catch (OverflowException)
		{
			character.settings.customRes3PowerAmount = int.MaxValue;
		}
		if (character.settings.customRes3PowerAmount < 0)
		{
			character.settings.customRes3PowerAmount = 0;
		}
		if (character.settings.customRes3PowerAmount > 1000000000)
		{
			character.settings.customRes3PowerAmount = 1000000000;
		}
		powerInput.text = character.settings.customRes3PowerAmount.ToString();
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
			character.settings.customRes3CapAmount = long.Parse(capInput.text);
		}
		catch (FormatException)
		{
			character.settings.customRes3CapAmount = 0L;
		}
		catch (OverflowException)
		{
			character.settings.customRes3CapAmount = 1000000000L;
		}
		if (character.settings.customRes3CapAmount == 0L)
		{
			character.settings.customRes3CapAmount = 0L;
		}
		else if (character.settings.customRes3CapAmount < 10000)
		{
			character.settings.customRes3CapAmount = 10000L;
		}
		long num = character.settings.customRes3CapAmount / 250;
		character.settings.customRes3CapAmount = num * 250;
		capInput.text = character.settings.customRes3CapAmount.ToString();
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
			character.settings.customRes3BarAmount = int.Parse(barInput.text);
		}
		catch (FormatException)
		{
			character.settings.customRes3BarAmount = 0;
		}
		catch (OverflowException)
		{
			character.settings.customRes3BarAmount = 1000000000;
		}
		if (character.settings.customRes3BarAmount < 0)
		{
			character.settings.customRes3BarAmount = 0;
		}
		if (character.settings.customRes3BarAmount > 1000000000)
		{
			character.settings.customRes3BarAmount = 1000000000;
		}
		barInput.text = character.settings.customRes3BarAmount.ToString();
		refresh();
	}

	public void tryCustomAll()
	{
		long num = character.settings.customRes3PowerAmount;
		long customRes3CapAmount = character.settings.customRes3CapAmount;
		long num2 = character.settings.customRes3BarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customRes3CapAmount >= 0 && num2 >= 0)
		{
			if (character.realExp < num3)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomAll;
				box.displayBox("Are you sure you want to buy " + character.display(num) + " " + character.res3.res3Name + " Power, " + character.display(customRes3CapAmount) + " " + character.res3.res3Name + " Cap, and " + character.display(num2) + " " + character.res3.res3Name + " Bars for " + NumberOutput.expPrint(num3) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomAll();
			}
		}
	}

	private void buyCustomAll()
	{
		long num = character.settings.customRes3PowerAmount;
		long customRes3CapAmount = character.settings.customRes3CapAmount;
		long num2 = character.settings.customRes3BarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customRes3CapAmount >= 0 && num2 >= 0 && character.realExp >= num3)
		{
			character.realExp -= num3;
			if ((double)(character.res3.capRes3 + customRes3CapAmount) >= (double)character.hardCap())
			{
				character.res3.capRes3 = character.hardCap();
			}
			else
			{
				character.res3.capRes3 += customRes3CapAmount;
			}
			character.res3.res3Power += num;
			character.res3.res3PerBar += num2;
			tooltip.showTooltip("You've successfully bought " + character.display(num) + " " + character.res3.res3Name + " Power, " + character.display(customRes3CapAmount) + " " + character.res3.res3Name + " Cap, and " + character.display(num2) + " " + character.res3.res3Name + " Bars!", 3f);
			updateRes3Purchases();
		}
	}
}
