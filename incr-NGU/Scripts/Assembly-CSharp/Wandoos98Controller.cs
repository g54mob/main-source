using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Wandoos98Controller : MonoBehaviour
{
	public Character character;

	public NumberFormat format;

	public HoverTooltip tooltip;

	public Slider energySlider;

	public Slider magicSlider;

	public Slider bootup;

	public Text wandoosTitleText;

	public InputField amountRequested;

	public Text totalBonus;

	public Text energyAllocated;

	public Text energyLevel;

	public Text magicAllocated;

	public Text magicLevel;

	public Text wandoosBarText;

	public GameObject energyPanel;

	public GameObject magicPanel;

	public ConfirmationBox box;

	public Image wandoos98Check;

	public Image wandoosMEHCheck;

	public Button wandoos98Button;

	public Button wandoosMEHButton;

	public Image wandoosXLCheck;

	public Button wandoosXLButton;

	private Image[] images;

	private UnityAction yesAction;

	private UnityAction noAction;

	private int nextOS;

	private string message;

	private void Awake()
	{
		noAction = cancel;
	}

	private void cancel()
	{
	}

	public float baseEnergyTime()
	{
		switch (character.settings.rebirthDifficulty)
		{
		case difficulty.normal:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+09f;
			case OSType.wandoosMEH:
				return 1E+12f;
			case OSType.wandoosXL:
				return 1E+15f;
			default:
				return 1E+09f;
			}
		case difficulty.evil:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+21f;
			case OSType.wandoosMEH:
				return 1E+27f;
			case OSType.wandoosXL:
				return 1E+33f;
			default:
				return 1E+21f;
			}
		default:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+21f;
			case OSType.wandoosMEH:
				return 1E+27f;
			case OSType.wandoosXL:
				return 1E+33f;
			default:
				return 1E+09f;
			}
		}
	}

	public float difficultyModifier()
	{
		switch (character.settings.rebirthDifficulty)
		{
		case difficulty.normal:
			return 1f;
		case difficulty.evil:
			return 1E+15f;
		case difficulty.sadistic:
			return 1E+30f;
		default:
			return 1f;
		}
	}

	public float baseMagicTime()
	{
		switch (character.settings.rebirthDifficulty)
		{
		case difficulty.normal:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+09f;
			case OSType.wandoosMEH:
				return 1E+12f;
			case OSType.wandoosXL:
				return 1E+15f;
			default:
				return 1E+09f;
			}
		case difficulty.evil:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+21f;
			case OSType.wandoosMEH:
				return 1E+27f;
			case OSType.wandoosXL:
				return 1E+33f;
			default:
				return 1E+20f;
			}
		default:
			switch (character.wandoos98.os)
			{
			case OSType.wandoos98:
				return 1E+21f;
			case OSType.wandoosMEH:
				return 1E+27f;
			case OSType.wandoosXL:
				return 1E+33f;
			default:
				return 1E+09f;
			}
		}
	}

	public float sadisticModifier()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		return 1E+12f;
	}

	public void updateWandoosUI()
	{
		if (character.wandoos98.installed || character.wandoos98.installTime.totalseconds >= 86400.0)
		{
			character.wandoos98.installed = true;
			energyPanel.gameObject.SetActive(value: true);
			magicPanel.gameObject.SetActive(value: true);
			totalBonus.gameObject.SetActive(value: true);
			for (int i = 0; i < images.Length; i++)
			{
				images[i].gameObject.SetActive(value: true);
			}
			wandoos98Button.gameObject.SetActive(value: true);
			wandoosMEHButton.gameObject.SetActive(value: true);
			wandoosXLButton.gameObject.SetActive(value: true);
			updateOSCheckmarks();
		}
		else
		{
			energyPanel.gameObject.SetActive(value: false);
			magicPanel.gameObject.SetActive(value: false);
			totalBonus.gameObject.SetActive(value: false);
			for (int j = 0; j < images.Length; j++)
			{
				images[j].gameObject.SetActive(value: false);
			}
			wandoos98Button.gameObject.SetActive(value: false);
			wandoosMEHButton.gameObject.SetActive(value: false);
			wandoosXLButton.gameObject.SetActive(value: false);
		}
	}

	public long OSLimit()
	{
		return 400L;
	}

	public float wandoosBootupTime()
	{
		float num = 3600f;
		if (character.inventory.itemList.xlComplete)
		{
			num = 3240f;
		}
		float num2 = 1f - (float)character.allChallenges.level100Challenge.evilCompletions() * 0.1f;
		if (num2 < 0.5f)
		{
			num2 = 0.5f;
		}
		if (num2 > 1f)
		{
			num2 = 1f;
		}
		return num * num2;
	}

	private void Start()
	{
		images = GetComponentsInChildren<Image>();
		if (float.IsNaN(character.wandoos98.energyProgress) || character.wandoos98.energyProgress < 0f)
		{
			character.wandoos98.energyProgress = 0f;
		}
		if (float.IsNaN(character.wandoos98.magicProgress) || character.wandoos98.magicProgress < 0f)
		{
			character.wandoos98.magicProgress = 0f;
		}
		character.wandoos98.updateBaseStats();
		InvokeRepeating("updateWandoos", 0f, 0.02f);
		enableWandoos();
	}

	private void updateWandoos()
	{
		if (!character.settings.wandoos98On)
		{
			return;
		}
		if (character.wandoos98.installTime.totalseconds < 86400.0 && !character.wandoos98.installed)
		{
			character.wandoos98.installTime.advanceTime(0.02f);
			disableWandoos();
			installTextUpdate();
			if (character.wandoos98.installTime.totalseconds >= 86400.0)
			{
				enableWandoos();
				character.wandoos98.installed = true;
			}
		}
		else if (character.wandoos98.installTime.totalseconds >= 86400.0 || character.wandoos98.installed)
		{
			advanceEnergyProgress();
			advanceMagicProgress();
			advanceBootup();
			updateText();
			updateBars();
		}
	}

	public void advanceBootup()
	{
		if (character.wandoos98.bootupTime.totalseconds >= 3600.0)
		{
			character.wandoos98.bootupTime.setTime(3600f);
		}
		else if (character.wandoos98.bootupTime.totalseconds != 3600.0)
		{
			character.wandoos98.bootupTime.advanceTime(0.02f);
		}
		bootup.value = bootupProgress();
	}

	public void advanceEnergyProgress()
	{
		if (character.wandoos98.wandoosEnergy == 0L)
		{
			return;
		}
		float num = energyProgressToAdd();
		if (num <= 1E-09f)
		{
			return;
		}
		character.wandoos98.energyProgress += num;
		energySlider.value = character.wandoos98.energyProgress;
		if (character.wandoos98.energyProgress >= 1f)
		{
			character.wandoos98.energyProgress = 0f;
			if (character.canLevel())
			{
				character.wandoos98.energyLevel++;
				character.settings.rebirthLevels++;
				updateText();
				updateBars();
			}
		}
	}

	public void refreshMenu()
	{
		if (character.menuID == 14)
		{
			if (character.wandoos98.bootupTime.totalseconds >= 3600.0)
			{
				character.wandoos98.bootupTime.setTime(3600f);
			}
			updateText();
			updateBars();
			updateOSCheckmarks();
		}
	}

	public double wandoosBonus()
	{
		if (character.wandoos98.disabled)
		{
			return 1.0;
		}
		if (character.wandoos98.energyLevel == 0L && character.wandoos98.magicLevel == 0L)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.wandoos98.os == OSType.wandoos98)
		{
			num = Math.Pow((1f + (float)character.wandoos98.energyLevel / 100f) * (1f + (float)character.wandoos98.magicLevel / 25f), 0.8);
		}
		else if (character.wandoos98.os == OSType.wandoosMEH)
		{
			num = (1f + (float)character.wandoos98.energyLevel / 5f) * (1f + (float)(character.wandoos98.magicLevel * 2));
		}
		else
		{
			if (character.wandoos98.os != OSType.wandoosXL)
			{
				return 1.0;
			}
			num = Math.Pow((1f + (float)character.wandoos98.energyLevel * 6f) * (1f + (float)character.wandoos98.magicLevel * 40f), 1.0499999523162842);
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public void updateOSCheckmarks()
	{
		if (character.wandoos98.os == OSType.wandoos98)
		{
			wandoos98Check.color = Color.white;
			wandoosMEHCheck.color = Color.clear;
			wandoosXLCheck.color = Color.clear;
		}
		else if (character.wandoos98.os == OSType.wandoosMEH)
		{
			wandoos98Check.color = Color.clear;
			wandoosMEHCheck.color = Color.white;
			wandoosXLCheck.color = Color.clear;
		}
		else
		{
			wandoos98Check.color = Color.clear;
			wandoosMEHCheck.color = Color.clear;
			wandoosXLCheck.color = Color.white;
		}
	}

	public void startSetOSType(int id)
	{
		if (id == 1 && !character.inventory.itemList.jakeComplete)
		{
			tooltip.showOverrideTooltip("You haven't unlocked this OS yet!", 2f);
		}
		else if (id == 2 && character.wandoos98.XLLevels == 0L)
		{
			tooltip.showOverrideTooltip("You haven't unlocked this OS yet!", 2f);
		}
		else if ((id != 0 || character.wandoos98.os != OSType.wandoos98) && (id != 1 || character.wandoos98.os != OSType.wandoosMEH) && (id != 2 || character.wandoos98.os != OSType.wandoosXL))
		{
			nextOS = id;
			yesAction = setOSType;
			box.displayBox("Are you sure you want to change your OS Type? You will lose all levels from Energy Dump and Magic Dump.", yesAction, noAction);
		}
	}

	private void setOSType()
	{
		switch (nextOS)
		{
		default:
			return;
		case 0:
			character.wandoos98.changeOS(OSType.wandoos98);
			break;
		case 1:
			character.wandoos98.changeOS(OSType.wandoosMEH);
			break;
		case 2:
			character.wandoos98.changeOS(OSType.wandoosXL);
			break;
		}
		refreshMenu();
	}

	public float energyProgressToAdd()
	{
		double num = 0.0;
		num = (float)character.wandoos98.wandoosEnergy * character.totalWandoosEnergySpeed() / baseEnergyTime();
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

	public long capAmountEnergy()
	{
		return (long)(baseEnergyTime() / character.totalWandoosEnergySpeed()) + 1;
	}

	public float energyProgressToAdd(long energy)
	{
		return (float)energy * character.totalWandoosEnergySpeed() / baseEnergyTime();
	}

	public float magicProgressToAdd()
	{
		double num = 0.0;
		num = (float)character.wandoos98.wandoosMagic * character.totalWandoosMagicSpeed() / baseMagicTime();
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

	public long capAmountMagic()
	{
		return (long)(baseMagicTime() / character.totalWandoosMagicSpeed()) + 1;
	}

	public float magicProgressToAdd(long magic)
	{
		return (float)magic * character.totalWandoosMagicSpeed() / baseMagicTime();
	}

	public void advanceMagicProgress()
	{
		if (character.wandoos98.wandoosMagic == 0L)
		{
			return;
		}
		float num = magicProgressToAdd();
		if (num <= 1E-09f)
		{
			return;
		}
		character.wandoos98.magicProgress += num;
		magicSlider.value = character.wandoos98.magicProgress;
		if (character.wandoos98.magicProgress >= 1f)
		{
			character.wandoos98.magicProgress = 0f;
			if (character.canLevel())
			{
				character.wandoos98.magicLevel++;
				character.settings.rebirthLevels++;
			}
		}
	}

	public string wandoosTitle()
	{
		switch (character.wandoos98.os)
		{
		case OSType.wandoos98:
			return "Wandoos 98";
		case OSType.wandoosMEH:
			return "Wandoos MEH";
		case OSType.wandoosXL:
			return "Wandoos XL";
		default:
			return "Wandoos 98";
		}
	}

	public void updateText()
	{
		if (character.menuID == 14)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				wandoosTitleText.text = "";
				totalBonus.text = "";
				energyAllocated.text = "";
				energyLevel.text = "";
				magicAllocated.text = "";
				magicLevel.text = "";
			}
			else
			{
				wandoosTitleText.text = wandoosTitle();
				totalBonus.text = "<b>Wandoos Energy Level:</b> " + format.suffixFormat(character.wandoos98.energyLevel) + "\n\n<b>Wandoos Magic Level:</b> " + format.suffixFormat(character.wandoos98.magicLevel) + "\n\n<b>Total Attack/Defense Bonus:</b> " + format.suffixFormat(wandoosBonus() * 100.0) + " %\n\n<b>" + wandoosTitle() + " OS Level</b>: " + OSLevel();
				energyAllocated.text = format.suffixFormat(character.wandoos98.wandoosEnergy);
				energyLevel.text = format.suffixFormat(character.wandoos98.energyLevel);
				magicAllocated.text = format.suffixFormat(character.wandoos98.wandoosMagic);
				magicLevel.text = format.suffixFormat(character.wandoos98.magicLevel);
			}
			if (bootupProgress() >= 1f)
			{
				wandoosBarText.text = wandoosTitle() + " fully booted up! Thank you for choosing macaroonsoft as your choice of OS.";
			}
			else
			{
				wandoosBarText.text = wandoosTitle() + " booting up... " + (bootupProgress() * 100f).ToString("#0.#") + " % effective power.";
			}
		}
	}

	public long OSLevel()
	{
		long num = character.wandoos98.OSlevel + character.wandoos98.pitOSLevels + character.wandoos98.XLLevels + character.adventureController.itopod.totalOSLevelBonus();
		if (num < 0)
		{
			num = 0L;
		}
		return num;
	}

	public float timeFactor()
	{
		return character.wandoos98.timeFactor();
	}

	public void updateBars()
	{
		if (character.menuID != 14)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 5)
		{
			energySlider.value = 0f;
			magicSlider.value = 0f;
		}
		else if (character.settings.antiFlickerBars)
		{
			if (energyProgressToAdd() > 0.1f)
			{
				energySlider.value = energyProgressToAdd();
			}
			else
			{
				energySlider.value = character.wandoos98.energyProgress;
			}
			if (magicProgressToAdd() > 0.1f)
			{
				magicSlider.value = magicProgressToAdd();
			}
			else
			{
				magicSlider.value = character.wandoos98.magicProgress;
			}
		}
		else
		{
			energySlider.value = character.wandoos98.energyProgress;
			magicSlider.value = character.wandoos98.magicProgress;
		}
	}

	public void addEnergy()
	{
		long num = Math.Min(character.input.energyMagicInput, character.idleEnergy);
		character.wandoos98.wandoosEnergy += num;
		character.idleEnergy -= num;
	}

	public void addCapEnergy()
	{
		character.idleEnergy += character.wandoos98.wandoosEnergy;
		character.wandoos98.wandoosEnergy = 0L;
		if (character.idleEnergy != 0L)
		{
			long num = (long)((float)(capAmountEnergy() / (long)Math.Ceiling((double)capAmountEnergy() / (double)character.idleEnergy)) * 1.000002f);
			if (num > character.idleEnergy)
			{
				num = character.idleEnergy;
			}
			if (num < 0)
			{
				num = 0L;
			}
			character.wandoos98.wandoosEnergy += num;
			character.idleEnergy -= num;
		}
	}

	public void addCapMagic()
	{
		character.magic.idleMagic += character.wandoos98.wandoosMagic;
		character.wandoos98.wandoosMagic = 0L;
		if (character.magic.idleMagic != 0L)
		{
			long num = (long)((float)(capAmountMagic() / (long)Math.Ceiling((double)capAmountMagic() / (double)character.magic.idleMagic)) * 1.000002f);
			if (num > character.magic.idleMagic)
			{
				num = character.magic.idleMagic;
			}
			if (num < 0)
			{
				num = 0L;
			}
			character.wandoos98.wandoosMagic += num;
			character.magic.idleMagic -= num;
		}
	}

	public void addMagic()
	{
		long num = Math.Min(character.input.energyMagicInput, character.magic.idleMagic);
		character.wandoos98.wandoosMagic += num;
		character.magic.idleMagic -= num;
	}

	public void removeEnergy()
	{
		long num = Math.Min(character.input.energyMagicInput, character.wandoos98.wandoosEnergy);
		character.wandoos98.wandoosEnergy -= num;
		character.idleEnergy += num;
	}

	public void removeMagic()
	{
		long num = Math.Min(character.input.energyMagicInput, character.wandoos98.wandoosMagic);
		character.wandoos98.wandoosMagic -= num;
		character.magic.idleMagic += num;
	}

	public void showEnergyTooltip()
	{
		message = "<b>Time until levelup: </b>" + energyTimeLeft();
		tooltip.showTooltip(message);
	}

	public void showMagicTooltip()
	{
		message = "<b>Time until levelup: </b>" + magicTimeLeft();
		tooltip.showTooltip(message);
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void showWandoosBarTooltip()
	{
		if (character.wandoos98.installTime.totalseconds < 86400.0 && !character.wandoos98.installed)
		{
			showInstallTooltip();
		}
		else
		{
			showBootupTooltip();
		}
	}

	public float bootupProgress()
	{
		float num = (float)character.wandoos98.bootupTime.totalseconds / wandoosBootupTime();
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float bootupSpeedFactor()
	{
		float num = bootupProgress();
		if (num >= 1f && character.inventory.itemList.wandoosComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float OSFactor()
	{
		long num = character.wandoos98.OSlevel + character.wandoos98.pitOSLevels + character.wandoos98.XLLevels + character.adventureController.itopod.totalOSLevelBonus();
		if (num > OSLimit())
		{
			num = OSLimit();
		}
		if (num < 0)
		{
			num = 0L;
		}
		return (float)(num + 1) / 25f;
	}

	public void reset()
	{
		character.wandoos98.reset();
	}

	private string energyTimeLeft()
	{
		if (character.totalWandoosEnergySpeed() == 0f)
		{
			return "Crap, somehow you have 0 speed. Tell 4g about it, cause that ain't right.";
		}
		if (character.wandoos98.wandoosEnergy == 0L)
		{
			return NumberOutput.timeOutput((1f - character.wandoos98.energyProgress) / energyProgressToAdd(character.totalCapEnergy()) / 50f) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		return NumberOutput.timeOutput((1f - character.wandoos98.energyProgress) / energyProgressToAdd() / 50f);
	}

	private string magicTimeLeft()
	{
		if (character.totalWandoosMagicSpeed() == 0f)
		{
			return "Crap, somehow you have 0 speed. Tell 4g about it, cause that ain't right.";
		}
		if (character.wandoos98.wandoosMagic == 0L)
		{
			return NumberOutput.timeOutput((1f - character.wandoos98.magicProgress) / magicProgressToAdd(character.totalCapMagic()) / 50f) + " (with " + character.display(character.totalCapMagic()) + " Magic)";
		}
		return NumberOutput.timeOutput((1f - character.wandoos98.magicProgress) / magicProgressToAdd() / 50f);
	}

	private void disableWandoos()
	{
		energyPanel.gameObject.SetActive(value: false);
		magicPanel.gameObject.SetActive(value: false);
		totalBonus.gameObject.SetActive(value: false);
		for (int i = 0; i < images.Length; i++)
		{
			images[i].gameObject.SetActive(value: false);
		}
		wandoos98Button.gameObject.SetActive(value: false);
		wandoosMEHButton.gameObject.SetActive(value: false);
		wandoosXLButton.gameObject.SetActive(value: false);
	}

	private void enableWandoos()
	{
		character.wandoos98.installed = true;
		energyPanel.gameObject.SetActive(value: true);
		magicPanel.gameObject.SetActive(value: true);
		totalBonus.gameObject.SetActive(value: true);
		for (int i = 0; i < images.Length; i++)
		{
			images[i].gameObject.SetActive(value: true);
		}
		character.wandoos98.energyProgress = 0f;
		wandoos98Button.gameObject.SetActive(value: true);
		wandoos98Button.gameObject.SetActive(value: true);
	}

	public void removeAllEnergy()
	{
		long wandoosEnergy = character.wandoos98.wandoosEnergy;
		character.idleEnergy += wandoosEnergy;
		character.wandoos98.wandoosEnergy -= wandoosEnergy;
		refreshMenu();
	}

	public void removeAllMagic()
	{
		long wandoosMagic = character.wandoos98.wandoosMagic;
		character.magic.idleMagic += wandoosMagic;
		character.wandoos98.wandoosMagic -= wandoosMagic;
		refreshMenu();
	}

	private void installTextUpdate()
	{
		wandoosBarText.text = "<b>Installing wandoos 98... " + (character.wandoos98.installTime.totalseconds / 86400.0 * 100.0).ToString("#0.#") + " % complete.</b>";
		character.wandoos98.energyProgress = (float)character.wandoos98.installTime.totalseconds / 86400f;
		bootup.value = character.wandoos98.energyProgress;
	}

	private void showInstallTooltip()
	{
		tooltip.showTooltip("<b>Time until installation completes:</b> " + character.wandoos98.installTime.inverseDisplayColon(86400.0));
	}

	private void showBootupTooltip()
	{
		if (!(bootupProgress() >= 1f))
		{
			tooltip.showTooltip("<b>Time until bootup completes:</b> " + character.wandoos98.bootupTime.inverseDisplayColon(wandoosBootupTime()));
		}
	}
}
