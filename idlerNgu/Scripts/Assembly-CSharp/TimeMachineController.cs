using UnityEngine;
using UnityEngine.UI;

public class TimeMachineController : MonoBehaviour
{
	public Character character;

	public InventoryController inventoryController;

	public HoverTooltip tooltip;

	public Slider machineProgress;

	public Slider speedProgress;

	public Slider goldMultiProgress;

	public Text speedEnergyText;

	public Text levelSpeedText;

	public Text goldMultiMagicText;

	public Text goldMultiLevelText;

	public InputField energyRequested;

	public Text machineInfoText;

	public Text machineInfoText2;

	public Text machineInfoText3;

	public Text machineInfoText4;

	public InputField speedTarget;

	public InputField multiTarget;

	public NumberFormat format;

	private string message;

	private float speed;

	private float magicSpeed;

	private readonly float baseSpeedCost = 5000000f;

	private readonly float baseGoldMultiCost = 5000000f;

	public float baseNormalSpeedDivider;

	public float baseEvilSpeedDivider;

	public float baseSadisticSpeedDivider;

	public float baseNormalGoldMultiDivider;

	public float baseEvilGoldMultiDivider;

	public float baseSadisticGoldMultiDivider;

	public PlayerTime energyDump;

	public PlayerTime magicDump;

	public int energyDumpTime = 5;

	public int magicDumpTime = 5;

	private void Start()
	{
		updateBars();
		InvokeRepeating("updateTimeMachine", 0f, 0.02f);
		InvokeRepeating("updateMachineText", 0f, 0.5f);
	}

	public void updateTimeMachine()
	{
		if (character.bossID > 29)
		{
			advanceMachineProgress();
			if (character.machine.speedEnergy > 0)
			{
				advanceSpeedProgress();
			}
			if (character.machine.goldMultiMagic > 0)
			{
				advanceGoldMultiProgress();
			}
			_ = character.menuID;
			_ = 18;
		}
	}

	public void challengeReset()
	{
		character.machine.speedBankLevels = 0L;
		character.machine.goldMultiBankLevels = 0L;
		character.machine.transferredBankLevels = true;
	}

	public void setBankedLevels()
	{
		if (!character.machine.transferredBankLevels)
		{
			character.machine.levelSpeed = character.machine.speedBankLevels;
			character.machine.speedBankLevels = 0L;
			character.machine.levelGoldMulti = character.machine.goldMultiBankLevels;
			character.machine.goldMultiBankLevels = 0L;
			character.machine.transferredBankLevels = true;
		}
	}

	public float getBaseSpeedCost()
	{
		return baseSpeedCost;
	}

	public float getBaseMultiCost()
	{
		return baseGoldMultiCost;
	}

	public void setbaseGold(double newgold)
	{
		if (character.bossID > 29 && !(newgold <= character.machine.realBaseGold))
		{
			character.machine.realBaseGold = newgold;
		}
	}

	public float machineProgresPerTick()
	{
		return 0.02f * (float)(1 + character.machine.levelSpeed);
	}

	public float baseSpeedDivider()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return baseNormalSpeedDivider;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return baseEvilSpeedDivider;
		}
		_ = character.settings.rebirthDifficulty;
		_ = 2;
		return baseSadisticSpeedDivider;
	}

	public float baseGoldMultiDivider()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return baseNormalGoldMultiDivider;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return baseEvilGoldMultiDivider;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return baseSadisticGoldMultiDivider;
		}
		return baseSadisticSpeedDivider;
	}

	public float sadisticDivider()
	{
		return 1f;
	}

	public float speedProgressPerTick()
	{
		double num = 0.0;
		num = character.totalEnergyPower() / baseSpeedDivider() * ((float)character.machine.speedEnergy / 50000f) * character.hacksController.totalTMSpeedBonus() * character.allChallenges.timeMachineChallenge.TMSpeedBonus() * character.cardsController.getBonus(cardBonus.TMSpeed) / (float)(character.machine.levelSpeed + 1);
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public float speedProgressPerTick(long amount)
	{
		double num = 0.0;
		num = character.totalEnergyPower() / baseSpeedDivider() * ((float)amount / 50000f) * character.hacksController.totalTMSpeedBonus() * character.allChallenges.timeMachineChallenge.TMSpeedBonus() * character.cardsController.getBonus(cardBonus.TMSpeed) / (float)(character.machine.levelSpeed + 1);
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public float goldMultiProgressPerTick()
	{
		double num = 0.0;
		num = character.totalMagicPower() / baseGoldMultiDivider() * ((float)character.machine.goldMultiMagic / 50000f) * character.hacksController.totalTMSpeedBonus() * character.allChallenges.timeMachineChallenge.TMSpeedBonus() * character.cardsController.getBonus(cardBonus.TMSpeed) / (float)(character.machine.levelGoldMulti + 1);
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public float goldMultiProgressPerTick(long amount)
	{
		double num = 0.0;
		num = character.totalMagicPower() / baseGoldMultiDivider() * ((float)amount / 50000f) * character.hacksController.totalTMSpeedBonus() * character.allChallenges.timeMachineChallenge.TMSpeedBonus() * character.cardsController.getBonus(cardBonus.TMSpeed) / (float)(character.machine.levelGoldMulti + 1);
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public long barFillsPerSecond()
	{
		return (int)Mathf.Min(1 + character.machine.levelSpeed, 50f);
	}

	public long speedGoldMultiBonus()
	{
		return Mathf.Max(1, Mathf.CeilToInt(character.machine.levelSpeed - 48));
	}

	public long goldMultiBonus()
	{
		return 1 + character.machine.levelGoldMulti;
	}

	public void updateSpeedText()
	{
		if (character.menuID == 18)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				speedEnergyText.text = "";
				levelSpeedText.text = "";
			}
			else
			{
				speedEnergyText.text = character.display(character.machine.speedEnergy);
				levelSpeedText.text = character.display(character.machine.levelSpeed);
			}
		}
	}

	public void updateGoldMultiText()
	{
		if (character.menuID == 18)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				goldMultiMagicText.text = "";
				goldMultiLevelText.text = "";
			}
			else
			{
				goldMultiMagicText.text = character.display(character.machine.goldMultiMagic);
				goldMultiLevelText.text = character.display(character.machine.levelGoldMulti);
			}
		}
	}

	public void advanceMachineProgress()
	{
		if (character.bossID >= 27)
		{
			float num = machineProgresPerTick();
			if (num > 1f)
			{
				num = 1f;
			}
			character.machine.machineProgress += num;
			character.addGold(character.goldPerSecond() / 50.0);
			updateMachineBar();
			if (character.machine.machineProgress >= 1f)
			{
				character.machine.machineProgress = 0f;
			}
		}
	}

	public void advanceSpeedProgress()
	{
		if (character.machine.speedEnergy <= 0)
		{
			return;
		}
		if (hitSpeedLevelTarget())
		{
			long speedEnergy = character.machine.speedEnergy;
			character.machine.speedEnergy -= speedEnergy;
			character.idleEnergy += speedEnergy;
			updateMenu();
			return;
		}
		if (character.machine.speedProgress == 0f)
		{
			float num = machineSpeedGoldCost();
			if (character.realGold < (double)num)
			{
				return;
			}
			character.realGold -= num * character.totalDiscount();
			float num2 = speedProgressPerTick();
			character.machine.speedProgress += num2;
		}
		else
		{
			float num3 = speedProgressPerTick();
			character.machine.speedProgress += num3;
		}
		updateSpeedBar();
		if (character.machine.speedProgress >= 1f)
		{
			character.machine.speedProgress = 0f;
			if (character.canLevel())
			{
				character.machine.levelSpeed++;
				character.settings.rebirthLevels++;
				updateSpeedText();
			}
		}
	}

	public void advanceGoldMultiProgress()
	{
		if (character.machine.goldMultiMagic <= 0)
		{
			return;
		}
		if (hitMultiLevelTarget())
		{
			long goldMultiMagic = character.machine.goldMultiMagic;
			character.machine.goldMultiMagic -= goldMultiMagic;
			character.magic.idleMagic += goldMultiMagic;
			updateMenu();
			return;
		}
		if (character.machine.goldMultiProgress == 0f)
		{
			float num = machineGoldMultiCost();
			if (character.realGold < (double)num)
			{
				return;
			}
			character.realGold -= num * character.totalDiscount();
			float num2 = goldMultiProgressPerTick();
			character.machine.goldMultiProgress += num2;
		}
		else
		{
			float num3 = goldMultiProgressPerTick();
			character.machine.goldMultiProgress += num3;
		}
		updateGoldMultiBar();
		if (character.machine.goldMultiProgress >= 1f)
		{
			character.machine.goldMultiProgress = 0f;
			if (character.canLevel())
			{
				character.machine.levelGoldMulti++;
				character.settings.rebirthLevels++;
				updateGoldMultiText();
			}
		}
	}

	public void addEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.idleEnergy)
		{
			num = character.idleEnergy;
			character.machine.speedEnergy += num;
			character.idleEnergy = 0L;
		}
		else
		{
			character.machine.speedEnergy += num;
			character.idleEnergy -= num;
		}
		updateSpeedText();
	}

	public void removeEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.machine.speedEnergy)
		{
			num = character.machine.speedEnergy;
			character.idleEnergy += character.machine.speedEnergy;
			character.machine.speedEnergy = 0L;
		}
		else
		{
			character.idleEnergy += num;
			character.machine.speedEnergy -= num;
		}
		updateSpeedText();
	}

	public void addMagic()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.magic.idleMagic)
		{
			num = character.magic.idleMagic;
			character.machine.goldMultiMagic += num;
			character.magic.idleMagic = 0L;
		}
		else
		{
			character.machine.goldMultiMagic += num;
			character.magic.idleMagic -= num;
		}
		updateGoldMultiText();
	}

	public void removeMagic()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.machine.goldMultiMagic)
		{
			num = character.machine.goldMultiMagic;
			character.magic.idleMagic += character.machine.goldMultiMagic;
			character.machine.goldMultiMagic = 0L;
		}
		else
		{
			character.magic.idleMagic += num;
			character.machine.goldMultiMagic -= num;
		}
		updateGoldMultiText();
	}

	public void reset()
	{
		long num = (long)(character.adventureController.itopod.totalBankedTimeMachine() * (float)character.machine.levelSpeed);
		long num2 = (long)(character.adventureController.itopod.totalBankedTimeMachine() * (float)character.machine.levelGoldMulti);
		if (num < 0)
		{
			num = 0L;
		}
		if (num > (long)((float)character.machine.levelSpeed * character.adventureController.itopod.totalBankedTimeMachine()))
		{
			num = (long)((float)character.machine.levelSpeed * character.adventureController.itopod.totalBankedTimeMachine());
		}
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (num2 > (long)((float)character.machine.levelGoldMulti * character.adventureController.itopod.totalBankedTimeMachine()))
		{
			num2 = (long)((float)character.machine.levelGoldMulti * character.adventureController.itopod.totalBankedTimeMachine());
		}
		character.machine.speedBankLevels = num;
		character.machine.goldMultiBankLevels = num2;
		character.machine.machineProgress = 0f;
		character.machine.speedProgress = 0f;
		character.machine.goldMultiProgress = 0f;
		character.machine.machineEnergy = 0L;
		character.machine.speedEnergy = 0L;
		character.machine.goldMultiMagic = 0L;
		character.machine.levelSpeed = 0L;
		character.machine.levelGoldMulti = 0L;
		character.machine.baseGold = 0f;
		character.machine.realBaseGold = 0.0;
		character.machine.transferredBankLevels = false;
		updateBars();
		updateGoldMultiText();
		updateSpeedText();
	}

	public void updateMachineBar()
	{
		if (character.menuID != 18)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 5)
		{
			if (machineProgress.value != 0f)
			{
				machineProgress.value = 0f;
			}
		}
		else if (character.settings.antiFlickerBars)
		{
			float num = machineProgresPerTick();
			if (num > 0.1f)
			{
				if (machineProgress.value != num)
				{
					machineProgress.value = num;
				}
			}
			else if (machineProgress.value != character.machine.machineProgress)
			{
				machineProgress.value = character.machine.machineProgress;
			}
		}
		else if (machineProgress.value != character.machine.machineProgress)
		{
			machineProgress.value = character.machine.machineProgress;
		}
	}

	public void updateSpeedBar()
	{
		if (character.menuID != 18)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 5)
		{
			speedProgress.value = 0f;
		}
		else if (character.settings.antiFlickerBars)
		{
			float num = speedProgressPerTick();
			if (num > 0.1f)
			{
				speedProgress.value = num;
			}
			else
			{
				speedProgress.value = character.machine.speedProgress;
			}
		}
		else
		{
			speedProgress.value = character.machine.speedProgress;
		}
	}

	public void updateGoldMultiBar()
	{
		if (character.menuID != 18)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 5)
		{
			goldMultiProgress.value = 0f;
		}
		else if (character.settings.antiFlickerBars)
		{
			float num = goldMultiProgressPerTick();
			if (num > 0.1f)
			{
				goldMultiProgress.value = num;
			}
			else
			{
				goldMultiProgress.value = character.machine.goldMultiProgress;
			}
		}
		else
		{
			goldMultiProgress.value = character.machine.goldMultiProgress;
		}
	}

	public void updateBars()
	{
		if (character.menuID == 18)
		{
			updateMachineBar();
			updateSpeedBar();
			updateGoldMultiBar();
		}
	}

	private void updateMachineText()
	{
		if (character.menuID != 18)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 5)
		{
			machineInfoText.text = "";
			machineInfoText2.text = "";
			machineInfoText3.text = "";
			return;
		}
		string text = "";
		string text2 = "";
		text = "<b>Gold per Bar Fill:</b> " + format.suffixFormat(character.machine.realBaseGold) + "\n<b>Bar Fills per second:</b> " + barFillsPerSecond();
		if (character.bloodMagicController.goldBonus() > 1f)
		{
			text = text + "\n<b>Blood Magic GPS Bonus:</b> " + (character.bloodMagicController.goldBonus() * 100f).ToString("###,##0") + "%";
		}
		text2 = "<b>Highest Boss Multiplier:</b> " + character.machineBossMulti() + "\n<b>Gold Multiplier:</b> " + character.display(1 + character.machine.levelGoldMulti);
		if (character.machine.levelSpeed >= 50)
		{
			text2 = text2 + "\n<b>Machine Speed GPS Multiplier:</b> " + character.display(Mathf.Max(character.machine.levelSpeed - 48, 1f));
		}
		if (character.allBeards.goldBonus() > 100f)
		{
			text2 = text2 + "\n<b>Beard GPS Multiplier:</b> " + character.display(character.allBeards.goldBonus() * 100f) + "%";
		}
		else if (character.allBeards.goldBonus() > 1f)
		{
			text2 = text2 + "\n<b>Beard GPS Multiplier:</b> " + (character.allBeards.goldBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.NGUController.timeMachineBonus() > 100.0)
		{
			text = text + "\n<b>NGU GPS Multiplier:</b> " + character.display(character.NGUController.timeMachineBonus() * 100.0) + "%";
		}
		else if (character.NGUController.timeMachineBonus() > 1.0)
		{
			text = text + "\n<b>NGU GPS Multiplier:</b> " + (character.NGUController.timeMachineBonus() * 100.0).ToString("###,##0.##") + "%";
		}
		if (character.allChallenges.timeMachineChallenge.totalGPSbonus() > 1.0)
		{
			text = text + "\n<b>Challenge Multiplier:</b> " + (character.allChallenges.timeMachineChallenge.totalGPSbonus() * 100.0).ToString("###,##0.##") + "%";
		}
		if (character.settings.diggersOn)
		{
			machineInfoText3.text = "<b>Gross GPS: " + character.display(character.grossGoldPerSecond()) + "</b>";
			machineInfoText4.text = "<b>Net GPS: " + character.display(character.goldPerSecond()) + "</b>";
		}
		else
		{
			machineInfoText3.text = "<b>Total GPS: " + character.display(character.grossGoldPerSecond()) + "</b>";
		}
		machineInfoText.text = text;
		machineInfoText2.text = text2;
	}

	public void updateMenu()
	{
		if (character.menuID == 18)
		{
			updateGoldMultiText();
			updateMachineText();
			updateSpeedText();
			updateBars();
			updateSpeedTarget();
			updateMultiTarget();
		}
	}

	public float machineSpeedGoldCost()
	{
		return (float)(1 + character.machine.levelSpeed) * baseSpeedCost;
	}

	public float machineGoldMultiCost()
	{
		return (float)(1 + character.machine.levelGoldMulti) * baseGoldMultiCost;
	}

	public void displaySpeedTooltip()
	{
		message = "<b>Time Machine Playback Speed</b>\n\nSpeeds up the rate of time that passes in the time bubble. This means, more gold!\n\n<b>Current Speed</b>: " + Mathf.Min(50f, 1 + character.machine.levelSpeed);
		if (character.machine.levelSpeed >= 50)
		{
			message = message + "\n\n<b>Bonus Gold Multiplier:</b> " + Mathf.Max(character.machine.levelSpeed - 48, 1f);
		}
		message = message + "\n\n<b>Gold Cost:</b> " + format.suffixFormat(machineSpeedGoldCost()) + "\n\n<b>Time to level up:</b> " + speedTimeLeft();
		if (!character.challenges.blindChallenge.inChallenge)
		{
			tooltip.showTooltip(message);
		}
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void displayGoldMultiTooltip()
	{
		message = "<b>Time Machine Gold Multiplier</b>\n\nCapture multiple time bubbles within a single time bubble, letting multiple past-you's loot gold at once!\n\n<b>Current Gold Multiplier</b>\n" + (character.machine.levelGoldMulti + 1) + "\n\n<b>Time to level up:</b> " + goldMultiTimeLeft() + "\n\nGold Cost: " + format.suffixFormat(machineGoldMultiCost());
		if (!character.challenges.blindChallenge.inChallenge)
		{
			tooltip.showTooltip(message);
		}
	}

	private string speedTimeLeft()
	{
		if (character.machine.speedEnergy == 0L)
		{
			return NumberOutput.timeOutput((1f - character.machine.speedProgress) / speedProgressPerTick(character.totalCapEnergy()) / 50f) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		return NumberOutput.timeOutput((1f - character.machine.speedProgress) / speedProgressPerTick() / 50f);
	}

	private string goldMultiTimeLeft()
	{
		if (character.machine.goldMultiMagic == 0L)
		{
			return NumberOutput.timeOutput((1f - character.machine.goldMultiProgress) / goldMultiProgressPerTick(character.totalCapMagic()) / 50f) + " (with " + character.display(character.totalCapMagic()) + " Magic)";
		}
		return NumberOutput.timeOutput((1f - character.machine.goldMultiProgress) / goldMultiProgressPerTick() / 50f);
	}

	public void removeAllEnergy()
	{
		long speedEnergy = character.machine.speedEnergy;
		character.idleEnergy += speedEnergy;
		character.machine.speedEnergy -= speedEnergy;
		updateMenu();
	}

	public void removeAllMagic()
	{
		long goldMultiMagic = character.machine.goldMultiMagic;
		character.magic.idleMagic += goldMultiMagic;
		character.machine.goldMultiMagic -= goldMultiMagic;
		updateMenu();
	}

	public bool hitSpeedLevelTarget()
	{
		if (character.machine.speedTarget == 0L)
		{
			return false;
		}
		return character.machine.levelSpeed >= character.machine.speedTarget;
	}

	public bool hitMultiLevelTarget()
	{
		if (character.machine.multiTarget == 0L)
		{
			return false;
		}
		return character.machine.levelGoldMulti >= character.machine.multiTarget;
	}

	public void checkSpeedTargetInput()
	{
		long num = long.Parse(speedTarget.text);
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= long.MaxValue)
		{
			num = long.MaxValue;
		}
		speedTarget.text = num.ToString();
		character.machine.speedTarget = num;
	}

	public void checkMultiTargetInput()
	{
		long num = long.Parse(multiTarget.text);
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= long.MaxValue)
		{
			num = long.MaxValue;
		}
		multiTarget.text = num.ToString();
		character.machine.multiTarget = num;
	}

	public void updateSpeedTarget()
	{
		speedTarget.text = character.machine.speedTarget.ToString();
	}

	public void updateMultiTarget()
	{
		multiTarget.text = character.machine.multiTarget.ToString();
	}

	public void wipeTimeMachine()
	{
		character.machine.levelSpeed = 0L;
		character.machine.levelGoldMulti = 0L;
	}
}
