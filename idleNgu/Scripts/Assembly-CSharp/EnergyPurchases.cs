using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnergyPurchases : MonoBehaviour
{
	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Character character;

	public Text energySpeedText;

	public Text energyBarText;

	public Text maxEnergyText;

	public Text energyPowerText;

	public Button energy10;

	public Button energy100;

	public Button special1;

	public Button special2;

	public Button special3;

	public InputField powerInput;

	public Button powerBuyButton;

	public InputField capInput;

	public Button capBuyButton;

	public InputField barInput;

	public Button barBuyButton;

	public Button buyAllCustom;

	public GameObject energyPowerPod;

	public GameObject energyCapPod;

	public GameObject energyBarPod;

	public Text newbieHint;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int energySpecial1Cost = 1;

	private int energySpecial2Cost = 2;

	private int energySpecial3Cost = 3;

	private int energyBar1Cost = 80;

	private int energyBar10Cost = 800;

	private int energyBar100Cost = 8000;

	private int maxEnergy10KCost = 40;

	private int maxEnergy100KCost = 400;

	private int maxEnergy1MCost = 4000;

	private int energyPower01Cost = 15;

	private int energyPower1Cost = 150;

	private int energyPower10Cost = 1500;

	private int energyPower100Cost = 15000;

	private void Awake()
	{
		noAction = cancel;
	}

	private void cancel()
	{
	}

	private void Start()
	{
		refresh();
	}

	public long energySpeed10Cost()
	{
		if (character.energySpeed < 50f)
		{
			return 2L;
		}
		if (character.energySpeed >= 50f && character.energySpeed < 100f)
		{
			return 20L;
		}
		_ = character.energySpeed;
		_ = 500f;
		return 200L;
	}

	public long energySpeed100Cost()
	{
		if (character.energySpeed < 50f)
		{
			return 20L;
		}
		if (character.energySpeed >= 50f && character.energySpeed < 500f)
		{
			return 200L;
		}
		_ = character.energySpeed;
		_ = 500f;
		return 2000L;
	}

	public void refresh()
	{
		updateEnergyPurchases();
	}

	private void updateEnergyPurchases()
	{
		if (character.menuID == 13)
		{
			energySpeedText.text = "<b>Total Energy Speed</b>\n" + character.totalEnergySpeed().ToString("###,##0.#") + "\n\n<b>Base Energy Speed:</b>\n" + character.energySpeed.ToString("###,##0.#");
			energyBarText.text = "<b>Total Energy Bars</b>\n" + character.totalEnergyBar().ToString("###,##0.#") + "\n\n<b>Base Energy Bars:</b>\n" + character.energyBars.ToString("###,##0");
			maxEnergyText.text = "<b>Total Energy Cap</b>\n" + character.totalCapEnergy().ToString("###,##0.#") + "\n\n<b>Base Energy Cap:</b>\n" + character.capEnergy.ToString("###,##0");
			energyPowerText.text = "<b>Total Energy Power</b>\n" + character.totalEnergyPower().ToString("###,##0.#") + "\n\n<b>Base Energy Power:</b>\n" + character.energyPower.ToString("###,##0.#");
			energy10.GetComponentInChildren<Text>().text = " +0.1 for " + energySpeed10Cost() + " EXP";
			energy100.GetComponentInChildren<Text>().text = " +1 for " + energySpeed100Cost() + " EXP";
			if (character.settings.special1Bought)
			{
				special1.gameObject.SetActive(value: false);
			}
			else
			{
				special1.gameObject.SetActive(value: true);
			}
			if (character.settings.special2Bought)
			{
				special2.gameObject.SetActive(value: false);
			}
			else
			{
				special2.gameObject.SetActive(value: true);
			}
			if (character.settings.special3Bought)
			{
				special3.gameObject.SetActive(value: false);
			}
			else
			{
				special3.gameObject.SetActive(value: true);
			}
			if (character.highestBoss < 17)
			{
				buyAllCustom.gameObject.SetActive(value: false);
				energyPowerPod.SetActive(value: false);
				energyCapPod.SetActive(value: false);
				energyBarPod.SetActive(value: true);
				newbieHint.text = "Reach boss 17 for more purchases here!";
			}
			else
			{
				buyAllCustom.gameObject.SetActive(value: true);
				energyPowerPod.SetActive(value: true);
				energyCapPod.SetActive(value: true);
				energyBarPod.SetActive(value: true);
				newbieHint.text = "";
			}
			powerBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customPowerCost(character.settings.customPowerAmount)) + " EXP";
			barBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customBarCost(character.settings.customBarAmount)) + " EXP";
			capBuyButton.GetComponentInChildren<Text>().text = "Buy for " + NumberOutput.expPrint(customCapCost(character.settings.customCapAmount)) + " EXP";
			buyAllCustom.GetComponentInChildren<Text>().text = "Buy ALL Custom Purchases at once for " + NumberOutput.expPrint(customAllCost()) + " EXP";
			powerInput.text = character.settings.customPowerAmount.ToString();
			barInput.text = character.settings.customBarAmount.ToString();
			capInput.text = character.settings.customCapAmount.ToString();
		}
	}

	public void energySpeed10()
	{
		if (character.energySpeed > 49.91f && character.energySpeed < 50f)
		{
			character.energySpeed = 50f;
		}
		if (character.energySpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max Energy Bar Speed you can get! For more energy generation, try purchasing Energy Gained per bar.", 3f);
		}
		else if (character.realExp < energySpeed10Cost())
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergySpeed10;
			box.displayBox("Are you sure you want to buy +0.1 Energy Generation Speed for " + energySpeed10Cost() + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergySpeed10();
		}
	}

	private void buyEnergySpeed10()
	{
		character.realExp -= energySpeed10Cost();
		character.energySpeed += 0.1f;
		if (character.energySpeed > 49.91f && character.energySpeed < 50f)
		{
			character.energySpeed = 50f;
		}
		tooltip.showTooltip("You've successfully bought +0.1 Energy Generation Speed! This is truly a joyous occasion.", 2f);
		updateEnergyPurchases();
	}

	public void energySpeed100()
	{
		if ((double)character.energySpeed > 49.91 && character.energySpeed < 50f)
		{
			character.energySpeed = 50f;
		}
		if (character.energySpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max Energy Bar Speed you can get! For more energy generation, try purchasing Energy Gained per bar.", 3f);
		}
		else if (character.realExp < energySpeed100Cost())
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergySpeed100;
			box.displayBox("Are you sure you want to buy +1 Energy Generation Speed for " + energySpeed100Cost() + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergySpeed100();
		}
	}

	private void buyEnergySpeed100()
	{
		character.realExp -= energySpeed100Cost();
		character.energySpeed += 1f;
		if (character.energySpeed > 49.91f && character.energySpeed < 50f)
		{
			character.energySpeed = 50f;
		}
		tooltip.showTooltip("You've successfully bought +1 Energy Generation Speed! Look at that energy bar whiz by!", 3f);
		updateEnergyPurchases();
	}

	public void energyBar1()
	{
		if (character.realExp < energyBar1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyBar1;
			box.displayBox("Are you sure you want to buy +1 Energy Gained per Bar for " + energyBar1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyBar1();
		}
	}

	private void buyEnergyBar1()
	{
		character.realExp -= energyBar1Cost;
		character.energyBars++;
		tooltip.showTooltip("You've successfully bought +1 Energy Gained Per Bar! That's like downing five cups of coffee at once!", 2f);
		updateEnergyPurchases();
	}

	public void energySpeedSpecial1()
	{
		if (character.energySpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max Energy Bar Speed you can get! For more energy generation, try purchasing Energy Gained per bar.", 3f);
			return;
		}
		if (character.realExp < energySpecial1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
			return;
		}
		yesAction = buyEnergySpeedSpecial1;
		box.displayBox("Are you sure you want to buy +0.2 Energy Generation Speed for " + energySpecial1Cost + " EXP?", yesAction, noAction);
	}

	private void buyEnergySpeedSpecial1()
	{
		character.realExp -= energySpecial1Cost;
		character.energySpeed += 0.2f;
		character.settings.special1Bought = true;
		tooltip.showTooltip("You've successfully bought +0.2 Energy Generation Speed! *sniff* I'm so proud of you.", 2f);
		updateEnergyPurchases();
	}

	public void energySpeedSpecial2()
	{
		if (character.energySpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max energy speed you can get! For more energy generation, try purchasing Energy Gained per bar.", 3f);
			return;
		}
		if (character.realExp < energySpecial2Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
			return;
		}
		yesAction = buyEnergySpeedSpecial2;
		box.displayBox("Are you sure you want to buy +0.3 Energy Generation Speed for " + energySpecial2Cost + " EXP?", yesAction, noAction);
	}

	private void buyEnergySpeedSpecial2()
	{
		character.realExp -= energySpecial2Cost;
		character.energySpeed += 0.3f;
		character.settings.special2Bought = true;
		tooltip.showTooltip("You've successfully bought +0.3 Energy Generation Speed! Noticing the change in speed now?", 3f);
		updateEnergyPurchases();
	}

	public void energySpeedSpecial3()
	{
		if (character.energySpeed >= 50f)
		{
			tooltip.showTooltip("You've already got the max energy speed you can get! For more energy generation, try purchasing Energy Gained per bar.", 2f);
			return;
		}
		if (character.realExp < energySpecial3Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
			return;
		}
		yesAction = buyEnergySpeedSpecial3;
		box.displayBox("Are you sure you want to buy +0.4 Energy Generation Speed for " + energySpecial3Cost + " EXP?", yesAction, noAction);
	}

	private void buyEnergySpeedSpecial3()
	{
		character.realExp -= energySpecial3Cost;
		character.energySpeed += 0.4f;
		tooltip.showTooltip("You've successfully bought +0.4 Energy Generation Speed! Noticing the change in speed now?", 3f);
		character.settings.special3Bought = true;
		updateEnergyPurchases();
	}

	public void energyBar10()
	{
		if (character.realExp < energyBar10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyBar10;
			box.displayBox("Are you sure you want to buy +10 Energy Gained per Bar for " + energyBar10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyBar10();
		}
	}

	private void buyEnergyBar10()
	{
		character.realExp -= energyBar10Cost;
		character.energyBars += 10L;
		tooltip.showTooltip("You've successfully bought +10 Energy Gained per Bar! That's like downing 10 five-hour energies at once for 50 continuous hours of energy!", 3f);
		updateEnergyPurchases();
	}

	public void energyBar100()
	{
		if (character.realExp < energyBar100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyBar100;
			box.displayBox("Are you sure you want to buy +100 Energy Gained per Bar for " + energyBar100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyBar100();
		}
	}

	private void buyEnergyBar100()
	{
		character.realExp -= energyBar100Cost;
		character.energyBars += 100L;
		tooltip.showTooltip("You've successfully bought +100 Energy Gained per Bar! That's like downing 100 five-hour energies at once for a fatal heart attack!", 3f);
		updateEnergyPurchases();
	}

	public void maxEnergy10K()
	{
		if (character.realExp < maxEnergy10KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.capEnergy < 100000)
		{
			tooltip.showTooltip("You need to hit a cap of 100K energy first!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMaxEnergy10K;
			box.displayBox("Are you sure you want to buy +10K Max Energy for " + maxEnergy10KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMaxEnergy10K();
		}
	}

	private void buyMaxEnergy10K()
	{
		character.realExp -= maxEnergy10KCost;
		character.capEnergy += 10000L;
		tooltip.showTooltip("You've successfully bought 10k extra Max Energy! Ooooh yeah!", 2f);
		updateEnergyPurchases();
	}

	public void maxEnergy100k()
	{
		if (character.realExp < maxEnergy100KCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.capEnergy < 100000)
		{
			tooltip.showTooltip("You need to hit a cap of 100K energy first!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMaxEnergy100K;
			box.displayBox("Are you sure you want to buy +100K Max Energy for " + maxEnergy100KCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMaxEnergy100K();
		}
	}

	private void buyMaxEnergy100K()
	{
		character.realExp -= maxEnergy100KCost;
		character.capEnergy += 100000L;
		tooltip.showTooltip("You've successfully bought 100k extra Max Energy! So much more energy for... activities!", 3f);
		updateEnergyPurchases();
	}

	public void maxEnergy1M()
	{
		if (character.realExp < maxEnergy1MCost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.capEnergy < 100000)
		{
			tooltip.showTooltip("You need to hit a cap of 100K energy first!", 2f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyMaxEnergy1M;
			box.displayBox("Are you sure you want to buy +1M Max Energy for " + maxEnergy1MCost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyMaxEnergy1M();
		}
	}

	private void buyMaxEnergy1M()
	{
		character.realExp -= maxEnergy1MCost;
		if ((double)(character.capEnergy + 1000000) >= (double)character.hardCap())
		{
			character.capEnergy = character.hardCap();
		}
		else
		{
			character.capEnergy += 1000000L;
		}
		tooltip.showTooltip("You've successfully bought 1M extra Max Energy! I'm getting a bit worried here.", 3f);
		updateEnergyPurchases();
	}

	public void energyPower01()
	{
		if (character.realExp < energyPower01Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.highestBoss < 17)
		{
			tooltip.showTooltip("This does nothing for you right now kiddo, grab some Energy speed instead. But you'll unlock a use for this stat soon!", 5f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyPower01;
			box.displayBox("Are you sure you want to buy +0.1 Energy Power for " + energyPower01Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyPower01();
		}
	}

	private void buyEnergyPower01()
	{
		character.realExp -= energyPower01Cost;
		character.energyPower += 0.1f;
		tooltip.showTooltip("You've successfully bought 0.1 Energy Power! I didn't even know energy could be more energy-y, anyways.", 2f);
		updateEnergyPurchases();
	}

	public void energyPower1()
	{
		if (character.realExp < energyPower1Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.highestBoss < 17)
		{
			tooltip.showTooltip("This does nothing for you right now kiddo, grab some Energy speed instead. But you'll unlock a use for this stat soon!", 5f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyPower1;
			box.displayBox("Are you sure you want to buy +1 Energy Power for " + energyPower1Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyPower1();
		}
	}

	private void buyEnergyPower1()
	{
		character.realExp -= energyPower1Cost;
		character.energyPower += 1f;
		tooltip.showTooltip("You've successfully bought 1 Energy Power! That's some powerful energy you've got there.", 3f);
		updateEnergyPurchases();
	}

	public void energyPower10()
	{
		if (character.realExp < energyPower10Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.highestBoss < 17)
		{
			tooltip.showTooltip("This does nothing for you right now kiddo, grab some Energy speed instead. But you'll unlock a use for this stat soon!", 5f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyPower10;
			box.displayBox("Are you sure you want to buy +10 Energy Power for " + energyPower10Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyPower10();
		}
	}

	private void buyEnergyPower10()
	{
		character.realExp -= energyPower10Cost;
		character.energyPower += 10f;
		tooltip.showTooltip("You've successfully bought 10 Energy Power! You must have EXP to burn.", 3f);
		updateEnergyPurchases();
	}

	public void energyPower100()
	{
		if (character.realExp < energyPower100Cost)
		{
			tooltip.showTooltip("Not enough Exp!", 2f);
		}
		else if (character.highestBoss < 17)
		{
			tooltip.showTooltip("This does nothing for you right now kiddo, grab some Energy speed instead. But you'll unlock a use for this stat soon!", 5f);
		}
		else if (character.settings.expPopups)
		{
			yesAction = buyEnergyPower100;
			box.displayBox("Are you sure you want to buy +100 Energy Power for " + energyPower100Cost + " EXP?", yesAction, noAction);
		}
		else
		{
			buyEnergyPower100();
		}
	}

	private void buyEnergyPower100()
	{
		character.realExp -= energyPower100Cost;
		character.energyPower += 100f;
		tooltip.showTooltip("You've successfully bought 100 Energy Power! You must have EXP to burn.", 3f);
		updateEnergyPurchases();
	}

	public void tryCustomEnergyPower()
	{
		int customPowerAmount = character.settings.customPowerAmount;
		long num = customPowerCost(customPowerAmount);
		if (num >= 0 && customPowerAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.highestBoss < 17)
			{
				tooltip.showTooltip("This does nothing for you right now kiddo, grab some Energy speed instead. But you'll unlock a use for this stat soon!", 5f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomPower;
				box.displayBox("Are you sure you want to buy " + character.display(customPowerAmount) + " Energy Power for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomPower();
			}
		}
	}

	private void buyCustomPower()
	{
		int customPowerAmount = character.settings.customPowerAmount;
		long num = customPowerCost(customPowerAmount);
		if (num >= 0 && customPowerAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.energyPower += customPowerAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customPowerAmount) + " Energy Power!", 3f);
			updateEnergyPurchases();
		}
	}

	public void tryCustomEnergyBar()
	{
		int customBarAmount = character.settings.customBarAmount;
		long num = customBarCost(customBarAmount);
		if (num >= 0 && customBarAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomBar;
				box.displayBox("Are you sure you want to buy " + character.display(customBarAmount) + " Energy Bars for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomBar();
			}
		}
	}

	private void buyCustomBar()
	{
		int customBarAmount = character.settings.customBarAmount;
		long num = customBarCost(customBarAmount);
		if (num >= 0 && customBarAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			character.energyBars += customBarAmount;
			tooltip.showTooltip("You've successfully bought " + character.display(customBarAmount) + " Energy Bars!", 3f);
			updateEnergyPurchases();
		}
	}

	public void tryCustomEnergyCap()
	{
		long customCapAmount = character.settings.customCapAmount;
		long num = customCapCost(customCapAmount);
		if (num >= 0 && customCapAmount >= 0)
		{
			if (character.realExp < num)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.capEnergy < 100000)
			{
				tooltip.showTooltip("You need to hit a cap of 100K energy first!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomCap;
				box.displayBox("Are you sure you want to buy " + character.display(customCapAmount) + " Energy Cap for " + NumberOutput.expPrint(num) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomCap();
			}
		}
	}

	private void buyCustomCap()
	{
		long customCapAmount = character.settings.customCapAmount;
		long num = customCapCost(customCapAmount);
		if (num >= 0 && customCapAmount >= 0 && character.realExp >= num)
		{
			character.realExp -= num;
			if ((double)(character.capEnergy + customCapAmount) >= (double)character.hardCap())
			{
				character.capEnergy = character.hardCap();
			}
			else
			{
				character.capEnergy += customCapAmount;
			}
			tooltip.showTooltip("You've successfully bought " + character.display(customCapAmount) + " Energy Cap!", 3f);
			updateEnergyPurchases();
		}
	}

	public void tryCustomAll()
	{
		long num = character.settings.customPowerAmount;
		long customCapAmount = character.settings.customCapAmount;
		long num2 = character.settings.customBarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customCapAmount >= 0 && num2 >= 0)
		{
			if (character.realExp < num3)
			{
				tooltip.showTooltip("Not enough Exp!", 2f);
			}
			else if (character.capEnergy < 100000)
			{
				tooltip.showTooltip("You need to hit a cap of 100K energy first!", 2f);
			}
			else if (character.settings.expPopups)
			{
				yesAction = buyCustomAll;
				box.displayBox("Are you sure you want to buy " + character.display(num) + " Energy Power, " + character.display(customCapAmount) + " Energy Cap, and " + character.display(num2) + " Energy Bars for " + NumberOutput.expPrint(num3) + " EXP?", yesAction, noAction);
			}
			else
			{
				buyCustomAll();
			}
		}
	}

	private void buyCustomAll()
	{
		long num = character.settings.customPowerAmount;
		long customCapAmount = character.settings.customCapAmount;
		long num2 = character.settings.customBarAmount;
		long num3 = customAllCost();
		if (num3 >= 0 && num >= 0 && customCapAmount >= 0 && num2 >= 0 && character.realExp >= num3)
		{
			character.realExp -= num3;
			if ((double)(character.capEnergy + customCapAmount) >= (double)character.hardCap())
			{
				character.capEnergy = character.hardCap();
			}
			else
			{
				character.capEnergy += customCapAmount;
			}
			character.energyPower += num;
			character.energyBars += num2;
			tooltip.showTooltip("You've successfully bought " + character.display(num) + " Energy Power, " + character.display(customCapAmount) + " Energy Cap, and " + character.display(num2) + " Energy Bars!", 3f);
			updateEnergyPurchases();
		}
	}

	public long customPowerCost(int amount)
	{
		return (long)amount * 150L;
	}

	public long customCapCost(long amount)
	{
		return amount / 250;
	}

	public long customBarCost(int amount)
	{
		return (long)amount * 80L;
	}

	public long customAllCost()
	{
		return customPowerCost(character.settings.customPowerAmount) + customCapCost(character.settings.customCapAmount) + customBarCost(character.settings.customBarAmount);
	}

	public void updateCustomPowerInput()
	{
		if (powerInput.text == "")
		{
			powerInput.text = "0";
		}
		try
		{
			character.settings.customPowerAmount = int.Parse(powerInput.text);
		}
		catch (FormatException)
		{
			character.settings.customPowerAmount = 0;
		}
		catch (OverflowException)
		{
			character.settings.customPowerAmount = 1000000000;
		}
		if (character.settings.customPowerAmount < 0)
		{
			character.settings.customPowerAmount = 0;
		}
		if (character.settings.customPowerAmount > 1000000000)
		{
			character.settings.customPowerAmount = 1000000000;
		}
		powerInput.text = character.settings.customPowerAmount.ToString();
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
			character.settings.customCapAmount = long.Parse(capInput.text);
		}
		catch (FormatException)
		{
			character.settings.customCapAmount = 0L;
		}
		catch (OverflowException)
		{
			character.settings.customCapAmount = long.MaxValue;
		}
		if (character.settings.customCapAmount == 0L)
		{
			character.settings.customCapAmount = 0L;
		}
		else if (character.settings.customCapAmount < 10000)
		{
			character.settings.customCapAmount = 10000L;
		}
		long num = character.settings.customCapAmount / 250;
		character.settings.customCapAmount = num * 250;
		capInput.text = character.settings.customCapAmount.ToString();
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
			character.settings.customBarAmount = int.Parse(barInput.text);
		}
		catch (FormatException)
		{
			character.settings.customBarAmount = 0;
		}
		catch (OverflowException)
		{
			character.settings.customBarAmount = 1000000000;
		}
		if (character.settings.customBarAmount < 0)
		{
			character.settings.customBarAmount = 0;
		}
		if (character.settings.customBarAmount > 1000000000)
		{
			character.settings.customBarAmount = 1000000000;
		}
		barInput.text = character.settings.customBarAmount.ToString();
		refresh();
	}
}
