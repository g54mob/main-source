using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
	public Character character;

	public Boss boss;

	public NumberFormat format;

	public Text statTitle;

	public Text statsBreakdown;

	public Text statValue;

	public Scrollbar scrollbar;

	public Text res3ButtonName;

	public Button res3Button;

	private string statsName;

	private string statsValue;

	public int displayMode;

	public float oldBreakdownPosition = 1f;

	private void Start()
	{
		refreshMenu();
	}

	public void statsBreakdownTextUpdate()
	{
	}

	public void refreshMenu()
	{
		if (character.menuID == 43)
		{
			if (!character.res3.res3On)
			{
				res3Button.interactable = false;
				res3ButtonName.text = "Locked";
			}
			else
			{
				res3Button.interactable = true;
				res3ButtonName.text = character.res3.res3Name;
			}
			displayAttackDefense();
		}
	}

	public void displayEnergy()
	{
		scrollbar.value = 1f;
		statTitle.text = "Energy Stats Breakdown";
		statsBreakdown.text = "\n<b>Base Energy Power:</b> ";
		statValue.text = "\n  " + character.energyPower.ToString("###,##0.#");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.EnergyPower] + character.inventoryController.bonuses[specType.EnergyPower2] + character.inventoryController.bonuses[specType.EnergyPower3] + character.inventoryController.bonuses[specType.AllPower]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[0] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + character.display(character.inventory.macguffinBonuses[0] * 100f) + "%";
		}
		if (character.adventureController.itopod.totalEnergyPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.display(character.adventureController.itopod.totalEnergyPowerBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalEnergyPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + character.display(character.beastQuestPerkController.totalEnergyPowerBonus() * 100f) + "%";
		}
		if (character.wishesController.totalEnergyPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.wishesController.totalEnergyPowerBonus() * 100f) + "%";
		}
		if (character.arbitrary.energyPotion1Time.totalseconds > 0.0)
		{
			statsBreakdown.text += "\n<b>Energy Potion α Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		if (character.arbitrary.energyPotion2InUse)
		{
			statsBreakdown.text += "\n<b>Energy Potion β Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		statsBreakdown.text += "\n<b>Total Energy Power:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + character.display(character.totalEnergyPower());
		statsBreakdown.text += "<b>\n\nBase Energy Bars:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\n\n  " + character.display(character.energyBars);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text9 = statValue;
		text9.text = text9.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.EnergyPerBar] + character.inventoryController.bonuses[specType.EnergyPerBar2] + character.inventoryController.bonuses[specType.EnergyPerBar3] + character.inventoryController.bonuses[specType.AllPerBar]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[6] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text10 = statValue;
			text10.text = text10.text + "\nx " + character.display(character.inventory.macguffinBonuses[6] * 100f) + "%";
		}
		if (character.adventureController.itopod.totalEnergyBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text11 = statValue;
			text11.text = text11.text + "\nx " + character.display(character.adventureController.itopod.totalEnergyBarBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalEnergyBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.beastQuestPerkController.totalEnergyBarBonus() * 100f) + "%";
		}
		if (character.wishesController.totalEnergyBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\nx " + character.display(character.wishesController.totalEnergyBarBonus() * 100f) + "%";
		}
		if (character.arbitrary.energyBarBar1Time.totalseconds > 0.0)
		{
			statsBreakdown.text += "\n<b>Energy Bar Bar Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		statsBreakdown.text += "\n<b>Total Energy Bars:</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\n  " + character.display(character.totalEnergyBar());
		statsBreakdown.text += "<b>\n\nBase Energy Cap:</b> ";
		Text text15 = statValue;
		text15.text = text15.text + "\n\n  " + character.capEnergy.ToString("###,##0");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text16 = statValue;
		text16.text = text16.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.EnergyCap] + character.inventoryController.bonuses[specType.EnergyCap3] + character.inventoryController.bonuses[specType.AllCap]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[1] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text17 = statValue;
			text17.text = text17.text + "\nx " + character.display(character.inventory.macguffinBonuses[1] * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalEnergyCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text18 = statValue;
			text18.text = text18.text + "\nx " + character.display(character.beastQuestPerkController.totalEnergyCapBonus() * 100f) + "%";
		}
		if (character.wishesController.totalEnergyCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text19 = statValue;
			text19.text = text19.text + "\nx " + character.display(character.wishesController.totalEnergyCapBonus() * 100f) + "%";
		}
		if (character.adventureController.itopod.totalEnergyCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text20 = statValue;
			text20.text = text20.text + "\nx " + character.display(character.adventureController.itopod.totalEnergyCapBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Energy Cap:</b> ";
		Text text21 = statValue;
		text21.text = text21.text + "\n  " + character.totalCapEnergy().ToString("###,##0");
	}

	public void displayMagic()
	{
		scrollbar.value = 1f;
		statTitle.text = "Magic Stats Breakdown";
		statsBreakdown.text = "\n<b>Base Magic Power:</b> ";
		statValue.text = "\n  " + character.display(character.magic.magicPower);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.MagicPower] + character.inventoryController.bonuses[specType.MagicPower2] + character.inventoryController.bonuses[specType.MagicPower3] + character.inventoryController.bonuses[specType.AllPower]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[2] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + character.display(character.inventory.macguffinBonuses[2] * 100f) + "%";
		}
		if (character.arbitrary.magicPotion1Time.totalseconds > 0.0)
		{
			statsBreakdown.text += "\n<b>Magic Potion α Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		if (character.arbitrary.magicPotion2InUse)
		{
			statsBreakdown.text += "\n<b>Magic Potion β Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		if (character.adventureController.itopod.totalMagicPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + character.display(character.adventureController.itopod.totalMagicPowerBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalMagicPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.beastQuestPerkController.totalMagicPowerBonus() * 100f) + "%";
		}
		if (character.wishesController.totalMagicPowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.display(character.wishesController.totalMagicPowerBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Magic Power:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + character.display(character.totalMagicPower());
		statsBreakdown.text += "\n\n<b>Base Magic Bars:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\n\n  " + character.magic.magicPerBar.ToString("###,##0");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text9 = statValue;
		text9.text = text9.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.MagicPerBar] + character.inventoryController.bonuses[specType.MagicPerBar2] + character.inventoryController.bonuses[specType.MagicPerBar3] + character.inventoryController.bonuses[specType.AllPerBar]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[7] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text10 = statValue;
			text10.text = text10.text + "\nx " + character.display(character.inventory.macguffinBonuses[7] * 100f) + "%";
		}
		if (character.arbitrary.magicBarBar1Time.totalseconds > 0.0)
		{
			statsBreakdown.text += "\n<b>Magic Bar Bar Modifier:</b>";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		if (character.adventureController.itopod.totalMagicBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text11 = statValue;
			text11.text = text11.text + "\nx " + character.display(character.adventureController.itopod.totalMagicBarBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalMagicBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.beastQuestPerkController.totalMagicBarBonus() * 100f) + "%";
		}
		if (character.wishesController.totalMagicBarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\nx " + character.display(character.wishesController.totalMagicBarBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Magic Bars:</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\n  " + character.display(character.totalMagicBar());
		statsBreakdown.text += "\n\n<b>Base Magic Cap:</b> ";
		Text text15 = statValue;
		text15.text = text15.text + "\n\n  " + character.magic.capMagic.ToString("###,##0");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text16 = statValue;
		text16.text = text16.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.MagicCap] + character.inventoryController.bonuses[specType.MagicCap3] + character.inventoryController.bonuses[specType.AllCap]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[3] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text17 = statValue;
			text17.text = text17.text + "\nx " + character.display(character.inventory.macguffinBonuses[3] * 100f) + "%";
		}
		if (character.adventureController.itopod.totalMagicCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text18 = statValue;
			text18.text = text18.text + "\nx " + character.display(character.adventureController.itopod.totalMagicCapBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalMagicCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text19 = statValue;
			text19.text = text19.text + "\nx " + character.display(character.beastQuestPerkController.totalMagicCapBonus() * 100f) + "%";
		}
		if (character.wishesController.totalMagicCapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text20 = statValue;
			text20.text = text20.text + "\nx " + character.display(character.wishesController.totalMagicCapBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Magic Cap:</b> ";
		Text text21 = statValue;
		text21.text = text21.text + "\n  " + character.totalCapMagic().ToString("###,##0");
	}

	public void displayRes3()
	{
		scrollbar.value = 1f;
		statTitle.text = character.res3.res3Name + " Stats Breakdown";
		statsBreakdown.text = "\n<b>Base " + character.res3.res3Name + " Power:</b> ";
		statValue.text = "\n  " + character.res3.res3Power.ToString("###,##0.#");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Res3Power]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[20] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + character.display(character.inventory.macguffinBonuses[20] * 100f) + "%";
		}
		if (character.adventureController.itopod.totalRes3PowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.display(character.adventureController.itopod.totalRes3PowerBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalRes3PowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + character.display(character.beastQuestPerkController.totalRes3PowerBonus() * 100f) + "%";
		}
		if (character.wishesController.totalRes3PowerBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.wishesController.totalRes3PowerBonus() * 100f) + "%";
		}
		if (character.arbitrary.res3Potion1Time.totalseconds > 0.0)
		{
			Text text6 = statsBreakdown;
			text6.text = text6.text + "\n<b>" + character.res3.res3Name + " Potion α Modifier:</b> ";
			Text text7 = statValue;
			text7.text = text7.text + "\nx " + character.allArbitrary.res3PotionModifier() * 100f + "%";
		}
		if (character.arbitrary.res3Potion2InUse)
		{
			Text text8 = statsBreakdown;
			text8.text = text8.text + "\n<b>" + character.res3.res3Name + " Potion β Modifier:</b> ";
			Text text7 = statValue;
			text7.text = text7.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "%";
		}
		Text text9 = statsBreakdown;
		text9.text = text9.text + "\n<b>Total " + character.res3.res3Name + " Power:</b> ";
		Text text10 = statValue;
		text10.text = text10.text + "\n  " + character.display(character.totalRes3Power());
		Text text11 = statsBreakdown;
		text11.text = text11.text + "<b>\n\nBase " + character.res3.res3Name + " Bars:</b> ";
		Text text12 = statValue;
		text12.text = text12.text + "\n\n  " + character.display(character.res3.res3PerBar);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text13 = statValue;
		text13.text = text13.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Res3Bar]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[22] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text14 = statValue;
			text14.text = text14.text + "\nx " + character.display(character.inventory.macguffinBonuses[22] * 100f) + "%";
		}
		if (character.adventureController.itopod.totalRes3BarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text15 = statValue;
			text15.text = text15.text + "\nx " + character.display(character.adventureController.itopod.totalRes3BarBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalRes3BarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\nx " + character.display(character.beastQuestPerkController.totalRes3BarBonus() * 100f) + "%";
		}
		if (character.wishesController.totalRes3BarBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text17 = statValue;
			text17.text = text17.text + "\nx " + character.display(character.wishesController.totalRes3BarBonus() * 100f) + "%";
		}
		Text text18 = statsBreakdown;
		text18.text = text18.text + "\n<b>Total " + character.res3.res3Name + " Bars:</b> ";
		Text text19 = statValue;
		text19.text = text19.text + "\n  " + character.display(character.totalRes3Bar());
		Text text20 = statsBreakdown;
		text20.text = text20.text + "<b>\n\nBase " + character.res3.res3Name + " Cap:</b> ";
		Text text21 = statValue;
		text21.text = text21.text + "\n\n  " + character.res3.capRes3.ToString("###,##0");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text22 = statValue;
		text22.text = text22.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Res3Cap]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[21] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text23 = statValue;
			text23.text = text23.text + "\nx " + character.display(character.inventory.macguffinBonuses[21] * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalRes3CapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text24 = statValue;
			text24.text = text24.text + "\nx " + character.display(character.beastQuestPerkController.totalRes3CapBonus() * 100f) + "%";
		}
		if (character.wishesController.totalRes3CapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text25 = statValue;
			text25.text = text25.text + "\nx " + character.display(character.wishesController.totalRes3CapBonus() * 100f) + "%";
		}
		if (character.adventureController.itopod.totalRes3CapBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text26 = statValue;
			text26.text = text26.text + "\nx " + character.display(character.adventureController.itopod.totalRes3CapBonus() * 100f) + "%";
		}
		Text text27 = statsBreakdown;
		text27.text = text27.text + "\n<b>Total " + character.res3.res3Name + " Cap:</b> ";
		Text text28 = statValue;
		text28.text = text28.text + "\n  " + character.totalCapRes3().ToString("###,##0");
	}

	public void displayAttackDefense()
	{
		scrollbar.value = 1f;
		statTitle.text = "Attack/Defense Breakdown";
		statsBreakdown.text = "\n<b>Base Attack:</b> ";
		statValue.text = "\n  " + character.display(character.training.getTotalAttack());
		statsBreakdown.text += "\n<b>NUMBER Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display(character.attackMulti * 100.0) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\nx " + character.display((1f + character.inventoryController.attackBonus() / 100f) * 100f) + "%";
		if (character.inventory.macguffinBonuses[13] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.display(character.inventory.macguffinBonuses[13] * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Rich Jerk Modifier:</b> ";
		Text text4 = statValue;
		text4.text = text4.text + "\nx " + character.display(character.attackBoost * 100f) + "%";
		statsBreakdown.text += "\n<b>Augment Modifier:</b> ";
		Text text5 = statValue;
		text5.text = text5.text + "\nx " + character.display(character.augmentsController.totalBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Wandoos Modifier:</b> ";
		Text text6 = statValue;
		text6.text = text6.text + "\nx " + character.display(character.wandoos98Controller.wandoosBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>NGU Modifier:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\nx " + character.display(character.NGUController.statBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Yggdrasil Modifier:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\nx " + character.display((1.0 + character.yggdrasil.totalStatBonus()) * character.yggdrasilController.permStatBonus() * character.yggdrasilController.permStatBonus2() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Beard Modifier:</b> ";
		Text text9 = statValue;
		text9.text = text9.text + "\nx " + character.display(character.allBeards.statBonus() * 100.0) + "%";
		if (character.allDiggers.totalStatBonus() > 1.0)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text10 = statValue;
			text10.text = text10.text + "\nx " + character.display(character.allDiggers.totalStatBonus() * 100.0) + "%";
		}
		statsBreakdown.text += "\n<b>ITOPOD Perk Modifier:</b> ";
		Text text11 = statValue;
		text11.text = text11.text + "\nx " + character.display(character.adventureController.itopod.totalStatBonus() * 100.0) + "%";
		if (character.beastQuestPerkController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.beastQuestPerkController.totalStatBonus() * 100f) + "%";
		}
		if (character.wishesController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\nx " + character.display(character.wishesController.totalStatBonus() * 100f) + "%";
		}
		if (character.hacksController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text14 = statValue;
			text14.text = text14.text + "\nx " + character.display(character.hacksController.totalStatBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.atkDefStats) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text15 = statValue;
			text15.text = text15.text + "\nx " + character.cardsController.cardBonusString(cardBonus.atkDefStats);
		}
		if (character.difficultyModifier() > 1.0)
		{
			statsBreakdown.text += "\n<b>Difficulty DIVIDER:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\n/ " + character.display(character.difficultyModifier() * 100.0) + "%";
		}
		statsBreakdown.text += "\n<b>Total Attack:</b> ";
		Text text17 = statValue;
		text17.text = text17.text + "\n  " + character.display(character.totalAttack());
		statsBreakdown.text += "\n\n<b>Base Defense:</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\n\n  " + character.display(character.training.getTotalDefense());
		statsBreakdown.text += "\n<b>NUMBER Modifier:</b> ";
		Text text19 = statValue;
		text19.text = text19.text + "\nx " + character.display(character.defenseMulti * 100.0) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text20 = statValue;
		text20.text = text20.text + "\nx " + character.display((1f + character.inventoryController.defenseBonus() / 100f) * 100f) + "%";
		if (character.inventory.macguffinBonuses[13] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text21 = statValue;
			text21.text = text21.text + "\nx " + character.display(character.inventory.macguffinBonuses[13] * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Rich Jerk Modifier:</b> ";
		Text text22 = statValue;
		text22.text = text22.text + "\nx " + character.display(character.defenseBoost * 100f) + "%";
		statsBreakdown.text += "\n<b>Augment Modifier:</b> ";
		Text text23 = statValue;
		text23.text = text23.text + "\nx " + character.display(character.augmentsController.totalBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Wandoos Modifier:</b> ";
		Text text24 = statValue;
		text24.text = text24.text + "\nx " + character.display(character.wandoos98Controller.wandoosBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>NGU Modifier:</b> ";
		Text text25 = statValue;
		text25.text = text25.text + "\nx " + character.display(character.NGUController.statBonus() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Yggdrasil Modifier:</b> ";
		Text text26 = statValue;
		text26.text = text26.text + "\nx " + character.display((1.0 + character.yggdrasil.totalStatBonus()) * character.yggdrasilController.permStatBonus() * character.yggdrasilController.permStatBonus2() * 100.0) + "%";
		statsBreakdown.text += "\n<b>Beard Modifier:</b> ";
		Text text27 = statValue;
		text27.text = text27.text + "\nx " + character.display(character.allBeards.statBonus() * 100.0) + "%";
		if (character.allDiggers.totalStatBonus() > 1.0)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text28 = statValue;
			text28.text = text28.text + "\nx " + character.display(character.allDiggers.totalStatBonus() * 100.0) + "%";
		}
		statsBreakdown.text += "\n<b>ITOPOD Perk Modifier:</b> ";
		Text text29 = statValue;
		text29.text = text29.text + "\nx " + character.display(character.adventureController.itopod.totalStatBonus() * 100.0) + "%";
		if (character.beastQuestPerkController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text30 = statValue;
			text30.text = text30.text + "\nx " + character.display(character.beastQuestPerkController.totalStatBonus() * 100f) + "%";
		}
		if (character.wishesController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text31 = statValue;
			text31.text = text31.text + "\nx " + character.display(character.wishesController.totalStatBonus() * 100f) + "%";
		}
		if (character.hacksController.totalStatBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text32 = statValue;
			text32.text = text32.text + "\nx " + character.display(character.hacksController.totalStatBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.atkDefStats) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text33 = statValue;
			text33.text = text33.text + "\nx " + character.cardsController.cardBonusString(cardBonus.atkDefStats);
		}
		if (character.difficultyModifier() > 1.0)
		{
			statsBreakdown.text += "\n<b>Difficulty DIVIDER:</b> ";
			Text text34 = statValue;
			text34.text = text34.text + "\n/ " + character.display(character.difficultyModifier() * 100.0) + "%";
		}
		statsBreakdown.text += "\n<b>Total Defense:</b> ";
		Text text35 = statValue;
		text35.text = text35.text + "\n  " + character.display(character.totalDefense());
	}

	public void displayAdventure()
	{
		scrollbar.value = 1f;
		statTitle.text = "Adventure Stats Breakdown";
		statsBreakdown.text = "\n<b>Base Adventure Power:</b> ";
		statValue.text = "\n  " + character.display(character.adventure.attack);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\n+ " + character.display(character.inventoryController.adventureAttackBonus());
		statsBreakdown.text += "\n<b>Infinity Cube Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\n+ " + character.display(character.inventoryController.cubePower());
		statsBreakdown.text += "\n<b>Subtotal:</b> ";
		Text text3 = statValue;
		text3.text = text3.text + "\n  " + character.display(character.inventoryController.cubePower() + character.inventoryController.adventureAttackBonus() + character.adventure.attack);
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		Text text4 = statValue;
		text4.text = text4.text + "\nx " + ((1f + character.advancedTrainingController.adventurePowerBonus(0)) * 100f).ToString("###,##0.##") + "%";
		statsBreakdown.text += "\n<b>Energy NGU Modifier:</b> ";
		Text text5 = statValue;
		text5.text = text5.text + "\nx " + (character.NGUController.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>Magic NGU Modifier:</b> ";
		Text text6 = statValue;
		text6.text = text6.text + "\nx " + (character.NGUController.adventureBonus2() * 100f).ToString("###,##0") + "%";
		if (character.allDiggers.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text7 = statValue;
			text7.text = text7.text + "\nx " + (character.allDiggers.totalAdventureBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Basic Challenge Modifier:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\nx " + (character.allChallenges.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (This run):</b> ";
		Text text9 = statValue;
		text9.text = text9.text + "\nx " + character.display(character.allBeards.tempAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (Permanent):</b> ";
		Text text10 = statValue;
		text10.text = text10.text + "\nx " + character.display(character.allBeards.permAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		Text text11 = statValue;
		text11.text = text11.text + "\nx " + character.adventureController.itopod.totalAdventureBonus() * 100f + "%";
		if (character.beastQuestPerkController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.beastQuestPerkController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.wishesController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\nx " + character.display(character.wishesController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.inventory.macguffinBonuses[19] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text14 = statValue;
			text14.text = text14.text + "\nx " + character.display(character.inventory.macguffinBonuses[19] * 100f) + "%";
		}
		if (character.hacksController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text15 = statValue;
			text15.text = text15.text + "\nx " + character.display(character.hacksController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.adventureStat) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\nx " + character.cardsController.cardBonusString(cardBonus.adventureStat);
		}
		if (character.adventure.beastModeOn)
		{
			statsBreakdown.text += "\n<b>BEAST MODE Modifier:</b> ";
			text11 = statValue;
			text11.text = text11.text + "\nx " + character.adventureController.beastModeBonus() * 100f + "%";
		}
		if (character.inventory.itemList.evilBonusAccComplete)
		{
			statsBreakdown.text += "\n<b>Evil Accs Set Bonus:</b> ";
			statValue.text += "\nx 120%";
		}
		statsBreakdown.text += "\n<b>Total Adventure Power:</b> ";
		Text text17 = statValue;
		text17.text = text17.text + "\n  " + character.display(character.totalAdvAttack());
		statsBreakdown.text += "\n\n<b>Base Adventure Toughness:</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\n\n  " + character.display(character.adventure.defense);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text19 = statValue;
		text19.text = text19.text + "\n+ " + character.display(character.inventoryController.adventureDefenseBonus());
		statsBreakdown.text += "\n<b>Infinity Cube Modifier:</b> ";
		Text text20 = statValue;
		text20.text = text20.text + "\n+ " + character.display(character.inventoryController.cubeToughness());
		statsBreakdown.text += "\n<b>Subtotal:</b> ";
		Text text21 = statValue;
		text21.text = text21.text + "\n  " + character.display(character.inventoryController.cubeToughness() + character.inventoryController.adventureDefenseBonus() + character.adventure.defense);
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		Text text22 = statValue;
		text22.text = text22.text + "\nx " + character.display((1f + character.advancedTrainingController.adventureToughnessBonus(0)) * 100f) + "%";
		statsBreakdown.text += "\n<b>Energy NGU Modifier:</b> ";
		Text text23 = statValue;
		text23.text = text23.text + "\nx " + (character.NGUController.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>Magic NGU Modifier:</b> ";
		Text text24 = statValue;
		text24.text = text24.text + "\nx " + (character.NGUController.adventureBonus2() * 100f).ToString("###,##0") + "%";
		if (character.allDiggers.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text25 = statValue;
			text25.text = text25.text + "\nx " + (character.allDiggers.totalAdventureBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Basic Challenge Modifier:</b> ";
		Text text26 = statValue;
		text26.text = text26.text + "\nx " + (character.allChallenges.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (This run):</b> ";
		Text text27 = statValue;
		text27.text = text27.text + "\nx " + character.display(character.allBeards.tempAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (Permanent):</b> ";
		Text text28 = statValue;
		text28.text = text28.text + "\nx " + character.display(character.allBeards.permAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		text11 = statValue;
		text11.text = text11.text + "\nx " + character.adventureController.itopod.totalAdventureBonus() * 100f + "%";
		if (character.beastQuestPerkController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text29 = statValue;
			text29.text = text29.text + "\nx " + character.display(character.beastQuestPerkController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.wishesController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text30 = statValue;
			text30.text = text30.text + "\nx " + character.display(character.wishesController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.inventory.macguffinBonuses[19] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text31 = statValue;
			text31.text = text31.text + "\nx " + character.display(character.inventory.macguffinBonuses[19] * 100f) + "%";
		}
		if (character.hacksController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text32 = statValue;
			text32.text = text32.text + "\nx " + character.display(character.hacksController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.adventureStat) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text33 = statValue;
			text33.text = text33.text + "\nx " + character.cardsController.cardBonusString(cardBonus.adventureStat);
		}
		if (character.inventory.itemList.evilBonusAccComplete)
		{
			statsBreakdown.text += "\n<b>Evil Accs Set Bonus:</b> ";
			statValue.text += "\nx 120%";
		}
		statsBreakdown.text += "\n<b>Total Adventure Toughness:</b> ";
		Text text34 = statValue;
		text34.text = text34.text + "\n  " + character.display(character.totalAdvDefense());
		statsBreakdown.text += "<b>\n\nBase Adventure Max Health:</b> ";
		Text text35 = statValue;
		text35.text = text35.text + "\n\n  " + character.display(character.adventure.maxHP);
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text36 = statValue;
		text36.text = text36.text + "\n+ " + character.display(character.inventoryController.adventureHPBonus());
		statsBreakdown.text += "\n<b>Infinity Cube Modifier:</b> ";
		Text text37 = statValue;
		text37.text = text37.text + "\n+ " + character.display(character.inventoryController.cubePower() * 3f);
		statsBreakdown.text += "\n<b>Subtotal:</b> ";
		Text text38 = statValue;
		text38.text = text38.text + "\n  " + character.display(character.inventoryController.cubePower() * 3f + character.inventoryController.adventureHPBonus() + character.adventure.maxHP);
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		Text text39 = statValue;
		text39.text = text39.text + "\nx " + ((1f + character.advancedTrainingController.adventurePowerBonus(0)) * 100f).ToString("###,##0.##") + "%";
		statsBreakdown.text += "\n<b>Energy NGU Modifier:</b> ";
		Text text40 = statValue;
		text40.text = text40.text + "\nx " + (character.NGUController.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>Magic NGU Modifier:</b> ";
		Text text41 = statValue;
		text41.text = text41.text + "\nx " + (character.NGUController.adventureBonus2() * 100f).ToString("###,##0") + "%";
		if (character.allDiggers.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text42 = statValue;
			text42.text = text42.text + "\nx " + (character.allDiggers.totalAdventureBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Basic Challenge Modifier:</b> ";
		Text text43 = statValue;
		text43.text = text43.text + "\nx " + (character.allChallenges.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (This run):</b> ";
		Text text44 = statValue;
		text44.text = text44.text + "\nx " + character.display(character.allBeards.tempAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (Permanent):</b> ";
		Text text45 = statValue;
		text45.text = text45.text + "\nx " + character.display(character.allBeards.permAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		text11 = statValue;
		text11.text = text11.text + "\nx " + character.adventureController.itopod.totalAdventureBonus() * 100f + "%";
		if (character.beastQuestPerkController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text46 = statValue;
			text46.text = text46.text + "\nx " + character.display(character.beastQuestPerkController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.wishesController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text47 = statValue;
			text47.text = text47.text + "\nx " + character.display(character.wishesController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.inventory.macguffinBonuses[19] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text48 = statValue;
			text48.text = text48.text + "\nx " + character.display(character.inventory.macguffinBonuses[19] * 100f) + "%";
		}
		if (character.hacksController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text49 = statValue;
			text49.text = text49.text + "\nx " + character.display(character.hacksController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.adventureStat) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text50 = statValue;
			text50.text = text50.text + "\nx " + character.cardsController.cardBonusString(cardBonus.adventureStat);
		}
		if (character.inventory.itemList.evilBonusAccComplete)
		{
			statsBreakdown.text += "\n<b>Evil Accs Set Bonus:</b> ";
			statValue.text += "\nx 120%";
		}
		statsBreakdown.text += "\n<b>Total Adventure Max Health:</b> ";
		Text text51 = statValue;
		text51.text = text51.text + "\n  " + character.display(character.totalAdvHP());
		statsBreakdown.text += "\n\n<b>Base Adventure Health Regen:</b> ";
		Text text52 = statValue;
		text52.text = text52.text + "\n\n  " + character.adventure.regen.ToString("###,##0.#");
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text53 = statValue;
		text53.text = text53.text + "\n+ " + character.display(character.inventoryController.adventureHPRegenBonus());
		statsBreakdown.text += "\n<b>Infinity Cube Modifier:</b> ";
		Text text54 = statValue;
		text54.text = text54.text + "\n+ " + (character.inventoryController.cubeToughness() * 0.03f).ToString("###,##0");
		statsBreakdown.text += "\n<b>Subtotal:</b> ";
		Text text55 = statValue;
		text55.text = text55.text + "\n  " + (character.adventure.regen + character.inventoryController.adventureHPRegenBonus() + character.inventoryController.cubeToughness() * 0.03f).ToString("###,##0");
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		text11 = statValue;
		text11.text = text11.text + "\nx " + (1f + character.advancedTrainingController.adventureToughnessBonus(0)) * 100f + "%";
		statsBreakdown.text += "\n<b>Energy NGU Modifier:</b> ";
		Text text56 = statValue;
		text56.text = text56.text + "\nx " + (character.NGUController.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>Magic NGU Modifier:</b> ";
		Text text57 = statValue;
		text57.text = text57.text + "\nx " + (character.NGUController.adventureBonus2() * 100f).ToString("###,##0") + "%";
		if (character.allDiggers.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text58 = statValue;
			text58.text = text58.text + "\nx " + (character.allDiggers.totalAdventureBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Basic Challenge Modifier:</b> ";
		Text text59 = statValue;
		text59.text = text59.text + "\nx " + (character.allChallenges.adventureBonus() * 100f).ToString("###,##0") + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (This run):</b> ";
		Text text60 = statValue;
		text60.text = text60.text + "\nx " + character.display(character.allBeards.tempAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>BEARd Modifier (Permanent):</b> ";
		Text text61 = statValue;
		text61.text = text61.text + "\nx " + character.display(character.allBeards.permAdventureBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		text11 = statValue;
		text11.text = text11.text + "\nx " + character.adventureController.itopod.totalAdventureBonus() * 100f + "%";
		if (character.beastQuestPerkController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text62 = statValue;
			text62.text = text62.text + "\nx " + character.display(character.beastQuestPerkController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.wishesController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text63 = statValue;
			text63.text = text63.text + "\nx " + character.display(character.wishesController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.inventory.macguffinBonuses[19] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text64 = statValue;
			text64.text = text64.text + "\nx " + character.display(character.inventory.macguffinBonuses[19] * 100f) + "%";
		}
		if (character.hacksController.totalAdventureBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text65 = statValue;
			text65.text = text65.text + "\nx " + character.display(character.hacksController.totalAdventureBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.adventureStat) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text66 = statValue;
			text66.text = text66.text + "\nx " + character.cardsController.cardBonusString(cardBonus.adventureStat);
		}
		if (character.inventory.itemList.evilBonusAccComplete)
		{
			statsBreakdown.text += "\n<b>Evil Accs Set Bonus:</b> ";
			statValue.text += "\nx 120%";
		}
		statsBreakdown.text += "\n<b>Total Adventure Health Regen:</b> ";
		Text text67 = statValue;
		text67.text = text67.text + "\n  " + character.display(character.totalAdvHPRegen());
	}

	public void displayMiscAdventure()
	{
		scrollbar.value = 1f;
		statTitle.text = "Misc. Adventure Stats Breakdown";
		statsBreakdown.text = "\n<b>Base Gold Drop Modifier:</b> ";
		statValue.text = "\n  100%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + (1f + character.inventoryController.bonuses[specType.GoldDropAmount] + character.inventoryController.bonuses[specType.GoldDrop2] + character.inventoryController.cubeGoldBonus()) * 100f + "%";
		if (character.inventory.macguffinBonuses[11] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + character.display(character.inventory.macguffinBonuses[11] * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>NGU Modifier:</b> ";
		Text text3 = statValue;
		text3.text = text3.text + "\nx " + character.display(character.NGUController.goldBonus() * 100f) + "%";
		if (character.adventureController.itopod.totalGoldDropBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + (character.adventureController.itopod.totalGoldDropBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.beastQuestPerkController.totalGoldBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.beastQuestPerkController.totalGoldBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.goldDrop) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.cardsController.cardBonusString(cardBonus.goldDrop);
		}
		if (character.allChallenges.timeMachineChallenge.evilCompletions() >= 1)
		{
			statsBreakdown.text += "\n<b>No TM Challenge Modifier:</b> ";
			statValue.text += "\nx 200%";
		}
		statsBreakdown.text += "\n<b>Total Gold Drop Modifier:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + character.display(character.totalGoldbonus() * 100f) + "%";
		statsBreakdown.text += "\n\n<b>Base Respawn Rate:</b> ";
		statValue.text += "\n\n  100% (4 seconds)";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		text = statValue;
		text.text = text.text + "\nx " + (1f - character.inventoryController.bonuses[specType.Respawn]) * 100f + "%";
		statsBreakdown.text += "\n<b>NGU Modifier:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\nx " + (character.NGUController.respawnBonus() * 100f).ToString("###,##0.##") + "%";
		if (character.inventory.itemList.clockComplete)
		{
			statsBreakdown.text += "\n<b>Clock Bonus Modifier:</b> ";
			statValue.text += "\nx 95% ";
		}
		if (character.adventure.itopod.perkLevel[93] > 0)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			text = statValue;
			text.text = text.text + "\nx " + character.adventureController.itopod.totalRespawnBonus() * 100f + "%";
		}
		if (character.wishesController.totalRespawnBonus() < 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			text = statValue;
			text.text = text.text + "\nx " + character.wishesController.totalRespawnBonus() * 100f + "%";
		}
		statsBreakdown.text += "\n<b>Total Respawn Rate:</b> ";
		text = statValue;
		text.text = text.text + "\n  " + (character.adventureController.respawnBonus() * 100f).ToString("###,##0.##") + "% (" + (character.adventureController.respawnBonus() * 4f).ToString("###,##0.##") + " seconds)";
		statsBreakdown.text += "\n\n<b>Base Drop Chance Modifier:</b> ";
		statValue.text += "\n\n  100%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		text = statValue;
		text.text = text.text + "\nx " + (1f + character.inventoryController.bonuses[specType.Looting] + character.inventoryController.bonuses[specType.Looting2] + character.inventoryController.cubeLootBonus()) * 100f + "%";
		if (character.inventory.macguffinBonuses[10] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text9 = statValue;
			text9.text = text9.text + "\nx " + (character.inventory.macguffinBonuses[10] * 100f).ToString("###,##0.##") + "%";
		}
		if (character.inventory.itemList.twoDComplete)
		{
			statsBreakdown.text += "\n<b>2D Set Bonus Modifier:</b> ";
			statValue.text += "\nx 107.43% ";
		}
		statsBreakdown.text += "\n<b>Blood Magic Modifier:</b> ";
		text = statValue;
		text.text = text.text + "\nx " + character.bloodMagicController.lootBonus() * 100f + "%";
		statsBreakdown.text += "\n<b>Yggdrasil Fruit Modifier:</b> ";
		Text text10 = statValue;
		text10.text = text10.text + "\nx " + character.display(character.yggdrasilController.luckBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>NGU Drop Chance Modifier:</b> ";
		Text text11 = statValue;
		text11.text = text11.text + "\nx " + character.display(character.NGUController.lootBonus() * 100f) + "%";
		if (character.allDiggers.totalDropChanceBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + (character.allDiggers.totalDropChanceBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Neckbeard Modifier (This run):</b> ";
		Text text13 = statValue;
		text13.text = text13.text + "\nx " + character.display(character.allBeards.tempLootBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Neckbeard Modifier (Permanent):</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\nx " + character.display(character.allBeards.permLootBonus() * 100f) + "%";
		if (character.arbitrary.lootcharm1Time.totalseconds > 0.0)
		{
			statsBreakdown.text += "\n<b>Lucky Charm Modifier: </b> ";
			text = statValue;
			text.text = text.text + "\nx " + character.allArbitrary.potionModifier() * 100f + "% ";
		}
		if (character.adventureController.itopod.totalDropChanceBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			Text text15 = statValue;
			text15.text = text15.text + "\nx " + (character.adventureController.itopod.totalDropChanceBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.hacksController.totalDropChanceBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\nx " + character.display(character.hacksController.totalDropChanceBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.dropChance) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text17 = statValue;
			text17.text = text17.text + "\nx " + character.cardsController.cardBonusString(cardBonus.dropChance);
		}
		if (character.inventory.itemList.normalBonusAccComplete)
		{
			statsBreakdown.text += "\n<b>Normal Accs Set Bonus:</b> ";
			statValue.text += "\nx 125%";
		}
		statsBreakdown.text += "\n<b>Total Drop Chance Modifier:</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\n  " + character.display(character.lootFactor() * 100f) + "%";
	}

	public void displayNGU()
	{
		scrollbar.value = 1f;
		statTitle.text = "NGU Speed Breakdown";
		statsBreakdown.text = "\n<b>Base Energy NGU Speed:</b> ";
		statValue.text = "\n  100%";
		statsBreakdown.text += "\n<b>Energy Power Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display(character.totalEnergyPower() * 100f) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.NGU] + character.inventoryController.bonuses[specType.NGU2]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[4] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.display(character.inventory.macguffinBonuses[4] * 100f) + "%";
		}
		if (character.inventory.itemList.numberComplete)
		{
			statsBreakdown.text += "\n<b>'A Number' Set Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.inventory.itemList.metaComplete)
		{
			statsBreakdown.text += "\n<b>Meta Set Modifier:</b> ";
			statValue.text += "\nx 120%";
		}
		if (character.inventory.itemList.schoolComplete)
		{
			statsBreakdown.text += "\n<b>School Set Modifier:</b> ";
			statValue.text += "\nx 115%";
		}
		statsBreakdown.text += "\n<b>Magic NGU Modifier:</b> ";
		Text text4 = statValue;
		text4.text = text4.text + "\nx " + character.display(character.NGUController.energyNGUBonus() * 100f) + "%";
		statsBreakdown.text += "\n<b>Beard Modifier:</b> ";
		Text text5 = statValue;
		text5.text = text5.text + "\nx " + character.display(character.allBeards.nguBonus() * 100f) + "%";
		if (character.allDiggers.totalEnergyNGUBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.display(character.allDiggers.totalEnergyNGUBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\nx " + character.display(character.adventureController.itopod.totalEnergyNGUBonus() * 100f) + "%";
		if (character.allChallenges.nguBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Challenge Modifier:</b> ";
			Text text8 = statValue;
			text8.text = text8.text + "\nx " + character.display(character.allChallenges.nguBonus() * 100f) + "%";
		}
		if (character.allChallenges.trollChallenge.sadisticCompletions() > 1)
		{
			statsBreakdown.text += "\n<b>Troll Challenge Modifier:</b> ";
			Text text9 = statValue;
			text9.text = text9.text + "\nx " + character.allChallenges.trollChallenge.totalEnergyNGUBonus() * 100f + "%";
		}
		if (character.hacksController.totalEnergyNGUBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text10 = statValue;
			text10.text = text10.text + "\nx " + character.display(character.hacksController.totalEnergyNGUBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalEnergyNGUSpeed() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text11 = statValue;
			text11.text = text11.text + "\nx " + character.display(character.beastQuestPerkController.totalEnergyNGUSpeed() * 100f) + "%";
		}
		if (character.wishesController.totalEnergyNGUSpeed() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.wishesController.totalEnergyNGUSpeed() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.energyNGUSpeed) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\nx " + character.cardsController.cardBonusString(cardBonus.energyNGUSpeed);
		}
		statsBreakdown.text += "\n<b>Total Energy NGU Speed Factor:</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\n  " + character.display(character.totalNGUSpeedBonus() * character.totalEnergyPower() * character.NGUController.energyNGUBonus() * character.allDiggers.totalEnergyNGUBonus() * character.adventureController.itopod.totalEnergyNGUBonus() * character.inventory.macguffinBonuses[4] * character.hacksController.totalEnergyNGUBonus() * character.beastQuestPerkController.totalEnergyNGUSpeed() * character.allChallenges.trollChallenge.totalEnergyNGUBonus() * character.wishesController.totalEnergyNGUSpeed() * character.cardsController.getBonus(cardBonus.energyNGUSpeed) * 100f) + "%";
		statsBreakdown.text += "\n\n<b>Base Magic NGU Speed:</b> ";
		statValue.text += "\n\n  100%";
		statsBreakdown.text += "\n<b>Magic Power Modifier:</b> ";
		Text text15 = statValue;
		text15.text = text15.text + "\nx " + character.display(character.totalMagicPower() * 100f) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text16 = statValue;
		text16.text = text16.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.NGU] + character.inventoryController.bonuses[specType.NGU2]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[5] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text17 = statValue;
			text17.text = text17.text + "\nx " + character.display(character.inventory.macguffinBonuses[5] * 100f) + "%";
		}
		if (character.inventory.itemList.numberComplete)
		{
			statsBreakdown.text += "\n<b> 'A Number' Set Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.inventory.itemList.metaComplete)
		{
			statsBreakdown.text += "\n<b>Meta Set Modifier:</b> ";
			statValue.text += "\nx 120%";
		}
		if (character.inventory.itemList.schoolComplete)
		{
			statsBreakdown.text += "\n<b>School Set Modifier:</b> ";
			statValue.text += "\nx 115%";
		}
		statsBreakdown.text += "\n<b>Energy NGU Modifier:</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\nx " + character.display(character.NGUController.magicNGUBonus() * 100f) + "%";
		if (character.settings.beardsOn)
		{
			statsBreakdown.text += "\n<b>Beard Modifier:</b> ";
			Text text19 = statValue;
			text19.text = text19.text + "\nx " + character.display(character.allBeards.nguBonus() * 100f) + "%";
		}
		if (character.allDiggers.totalMagicNGUBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text20 = statValue;
			text20.text = text20.text + "\nx " + character.display(character.allDiggers.totalMagicNGUBonus() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
		Text text21 = statValue;
		text21.text = text21.text + "\nx " + character.display(character.adventureController.itopod.totalMagicNGUBonus() * 100f) + "%";
		if (character.allChallenges.nguBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Challenge Modifier:</b> ";
			Text text22 = statValue;
			text22.text = text22.text + "\nx " + character.display(character.allChallenges.nguBonus() * 100f) + "%";
		}
		if (character.allChallenges.trollChallenge.completions() > 1)
		{
			statsBreakdown.text += "\n<b>Troll Challenge Modifier:</b> ";
			Text text9 = statValue;
			text9.text = text9.text + "\nx " + character.allChallenges.trollChallenge.totalMagicNGUBonus() * 100f + "%";
		}
		if (character.hacksController.totalEnergyNGUBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text23 = statValue;
			text23.text = text23.text + "\nx " + character.display(character.hacksController.totalMagicNGUBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalMagicNGUSpeed() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text24 = statValue;
			text24.text = text24.text + "\nx " + character.display(character.beastQuestPerkController.totalMagicNGUSpeed() * 100f) + "%";
		}
		if (character.wishesController.totalMagicNGUSpeed() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text25 = statValue;
			text25.text = text25.text + "\nx " + character.display(character.wishesController.totalMagicNGUSpeed() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.magicNGUSpeed) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text26 = statValue;
			text26.text = text26.text + "\nx " + character.cardsController.cardBonusString(cardBonus.magicNGUSpeed);
		}
		statsBreakdown.text += "\n<b>Total Magic NGU Speed Factor:</b> ";
		Text text27 = statValue;
		text27.text = text27.text + "\n  " + character.display(character.totalNGUSpeedBonus() * character.totalMagicPower() * character.NGUController.magicNGUBonus() * character.allDiggers.totalMagicNGUBonus() * character.adventureController.itopod.totalMagicNGUBonus() * character.allChallenges.trollChallenge.totalMagicNGUBonus() * character.inventory.macguffinBonuses[5] * character.hacksController.totalMagicNGUBonus() * character.beastQuestPerkController.totalMagicNGUSpeed() * character.wishesController.totalMagicNGUSpeed() * character.cardsController.getBonus(cardBonus.magicNGUSpeed) * 100f) + "%";
	}

	public void displayBeards()
	{
		scrollbar.value = 1f;
		statTitle.text = "Energy/Magic Beard Speed Breakdown";
		statsBreakdown.text = "\n<b>Base Energy Beard Speed:</b> ";
		statValue.text = "\n  100%";
		statsBreakdown.text += "\n<b>Energy Bar Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display((float)character.totalEnergyBar() * 100f) + "%";
		statsBreakdown.text += "\n<b>Energy Power Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\nx " + character.display(Mathf.Sqrt(character.totalEnergyPower()) * 100f) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text3 = statValue;
		text3.text = text3.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) * 100f) + "%";
		if (character.allDiggers.totalEnergyBeardBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + character.display(character.allDiggers.totalEnergyBeardBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalBeardSpeedBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.beastQuestPerkController.totalBeardSpeedBonus() * 100f) + "%";
		}
		if (character.inventory.itemList.uugComplete)
		{
			statsBreakdown.text += "\n<b>Set Bonus Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		statsBreakdown.text += "\n<b>Energy Beard Count Divider:</b> ";
		Text text6 = statValue;
		text6.text = text6.text + "\n/ " + character.allBeards.beardCountDivider(energyBeard: true);
		statsBreakdown.text += "\n<b>Total Energy Beard Speed Factor:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + character.display(character.allBeards.energyBeardSpeedFactor() * 100f) + "%";
		statsBreakdown.text += "\n\n<b>Base Magic Beard Speed:</b> ";
		statValue.text += "\n\n  100%";
		statsBreakdown.text += "\n<b>Magic Bar Modifier:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\nx " + character.display((float)character.totalMagicBar() * 100f) + "%";
		statsBreakdown.text += "\n<b>Magic Power Modifier:</b> ";
		Text text9 = statValue;
		text9.text = text9.text + "\nx " + character.display(Mathf.Sqrt(character.totalMagicPower()) * 100f) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text10 = statValue;
		text10.text = text10.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) * 100f) + "%";
		if (character.allDiggers.totalMagicBeardBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text11 = statValue;
			text11.text = text11.text + "\nx " + character.display(character.allDiggers.totalMagicBeardBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalBeardSpeedBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.display(character.beastQuestPerkController.totalBeardSpeedBonus() * 100f) + "%";
		}
		if (character.inventory.itemList.uugComplete)
		{
			statsBreakdown.text += "\n<b>Set Bonus Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		statsBreakdown.text += "\n<b>Magic Beard Count Divider:</b> ";
		Text text13 = statValue;
		text13.text = text13.text + "\n/ " + character.allBeards.beardCountDivider(energyBeard: false);
		statsBreakdown.text += "\n<b>Total Magic Beard Speed Factor:</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\n  " + character.display(character.allBeards.magicBeardSpeedFactor() * 100f) + "%";
	}

	public void displayAugments()
	{
		scrollbar.value = 1f;
		statTitle.text = "Augment Speed Breakdown";
		statsBreakdown.text = "\n<b>Base Augment Speed:</b> ";
		statValue.text = "\n  100%";
		statsBreakdown.text += "\n<b>Energy Power Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + character.display(character.totalEnergyPower() * 100f) + "%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Augs]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[12] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + character.display(character.inventory.macguffinBonuses[12] * 100f) + "%";
		}
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			statsBreakdown.text += "\n<b>No Augs Challenge Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= 1)
		{
			statsBreakdown.text += "\n<b>Evil No Augs Challenges Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + (1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f) * 100f + "%";
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			statsBreakdown.text += "\n<b>Evil No Augs Max Completion:</b> ";
			statValue.text += "\nx 125%";
		}
		if (character.hacksController.totalAugSpeedBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + character.display(character.hacksController.totalAugSpeedBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.augSpeed) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.cardsController.cardBonusString(cardBonus.augSpeed);
		}
		statsBreakdown.text += "\n<b>Total Augment Speed Factor:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + character.display(character.augmentsController.getTotalSpeedFactor() * 100f) + "%";
	}

	public void displayWandoos()
	{
		scrollbar.value = 1f;
		statTitle.text = "Wandoos Speed Breakdown";
		statsBreakdown.text = "\n<b>Base Wandoos Energy Speed:</b> ";
		statValue.text = "\n  100%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text = statValue;
		text.text = text.text + "\nx " + (1f + character.inventoryController.bonuses[specType.Wandoos98] + character.inventoryController.bonuses[specType.Wandoos2]) * 100f + "%";
		if (character.inventory.macguffinBonuses[15] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + character.display(character.inventory.macguffinBonuses[15] * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>OS Level Modifier:</b> ";
		Text text3 = statValue;
		text3.text = text3.text + "\nx " + character.display(character.wandoos98Controller.OSFactor() * 100f) + "%";
		statsBreakdown.text += "\n<b>Wandoos Bootup Modifier:</b> ";
		Text text4 = statValue;
		text4.text = text4.text + "\nx " + character.display(character.wandoos98Controller.bootupSpeedFactor() * 100f) + "%";
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		Text text5 = statValue;
		text5.text = text5.text + "\nx " + character.display((1f + character.advancedTrainingController.wandoosEnergy.trainingBonus(0)) * 100f) + "%";
		if (character.NGUController.wandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>NGU Wandoos Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + character.display(character.NGUController.wandoosBonus() * 100f) + "%";
		}
		if (character.allDiggers.totalWandoosSpeedBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text7 = statValue;
			text7.text = text7.text + "\nx " + character.display(character.allDiggers.totalWandoosSpeedBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalEnergyWandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text8 = statValue;
			text8.text = text8.text + "\nx " + character.display(character.beastQuestPerkController.totalEnergyWandoosBonus() * 100f) + "%";
		}
		if (character.allChallenges.level100Challenge.completions() > 0)
		{
			statsBreakdown.text += "\n<b>100 Level Challenge Modifier:</b> ";
			Text text9 = statValue;
			text9.text = text9.text + "\nx " + character.display(character.allChallenges.wandoosBonus() * 100f) + "%";
		}
		if (character.inventory.itemList.wandoosComplete && character.wandoos98.bootupProgress >= 1f)
		{
			statsBreakdown.text += "\n<b>Wandoos 98 Set Completion Bonus:</b> ";
			statValue.text += "\nx  110%";
		}
		if (character.allBeards.wandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Beard Modifier (This Run):</b> ";
			Text text10 = statValue;
			text10.text = text10.text + "\nx " + character.display(character.allBeards.tempWandoosBonus() * 100f) + "%";
			statsBreakdown.text += "\n<b>Beard Modifier (Permanent):</b> ";
			Text text11 = statValue;
			text11.text = text11.text + "\nx " + character.display(character.allBeards.permWandoosBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.wandoosSpeed) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text12 = statValue;
			text12.text = text12.text + "\nx " + character.cardsController.cardBonusString(cardBonus.wandoosSpeed);
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			statsBreakdown.text += "\n<b>SADISTIC DIVIDER: </b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\n  " + character.display(character.wandoos98Controller.sadisticModifier() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Wandoos Energy Speed:</b> ";
		Text text14 = statValue;
		text14.text = text14.text + "\n  " + character.display(character.totalWandoosEnergySpeed() * 100f) + "%";
		statsBreakdown.text += "\n\n<b>Base Wandoos Magic Speed:</b> ";
		statValue.text += "\n\n  100%";
		statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
		Text text15 = statValue;
		text15.text = text15.text + "\nx " + character.display((1f + character.inventoryController.bonuses[specType.Wandoos98] + character.inventoryController.bonuses[specType.Wandoos2]) * 100f) + "%";
		if (character.inventory.macguffinBonuses[16] > 1f)
		{
			statsBreakdown.text += "\n<b>MacGuffin Modifier:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\nx " + character.display(character.inventory.macguffinBonuses[16] * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>OS Level Modifier:</b> ";
		Text text17 = statValue;
		text17.text = text17.text + "\nx " + character.display(character.wandoos98Controller.OSFactor() * 100f) + "%";
		statsBreakdown.text += "\n<b>Wandoos Bootup Modifier:</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\nx " + character.display(character.wandoos98Controller.bootupSpeedFactor() * 100f) + "%";
		statsBreakdown.text += "\n<b>Advanced Training Modifier:</b> ";
		Text text19 = statValue;
		text19.text = text19.text + "\nx " + character.display((1f + character.advancedTrainingController.wandoosMagic.trainingBonus(0)) * 100f) + "%";
		if (character.NGUController.wandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>NGU Wandoos Modifier:</b> ";
			Text text20 = statValue;
			text20.text = text20.text + "\nx " + character.display(character.NGUController.wandoosBonus() * 100f) + "%";
		}
		if (character.allDiggers.totalWandoosSpeedBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text21 = statValue;
			text21.text = text21.text + "\nx " + character.display(character.allDiggers.totalWandoosSpeedBonus() * 100f) + "%";
		}
		if (character.beastQuestPerkController.totalMagicWandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Quirk Modifier:</b> ";
			Text text22 = statValue;
			text22.text = text22.text + "\nx " + character.display(character.beastQuestPerkController.totalMagicWandoosBonus() * 100f) + "%";
		}
		if (character.allChallenges.level100Challenge.completions() > 0)
		{
			statsBreakdown.text += "\n<b>100 level Challenge Modifier:</b> ";
			Text text23 = statValue;
			text23.text = text23.text + "\nx " + character.display(character.allChallenges.wandoosBonus() * 100f) + "%";
		}
		if (character.inventory.itemList.wandoosComplete && character.wandoos98.bootupProgress >= 1f)
		{
			statsBreakdown.text += "\n<b>Wandoos 98 Set Completion Bonus:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.allBeards.wandoosBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Beard Modifier (This Run):</b> ";
			Text text24 = statValue;
			text24.text = text24.text + "\nx " + character.display(character.allBeards.tempWandoosBonus() * 100f) + "%";
			statsBreakdown.text += "\n<b>Beard Modifier (Permanent):</b> ";
			Text text25 = statValue;
			text25.text = text25.text + "\nx " + character.display(character.allBeards.permWandoosBonus() * 100f) + "%";
		}
		if (character.cardsController.getBonus(cardBonus.wandoosSpeed) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text26 = statValue;
			text26.text = text26.text + "\nx " + character.cardsController.cardBonusString(cardBonus.wandoosSpeed);
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			statsBreakdown.text += "\n<b>SADISTIC DIVIDER: </b> ";
			Text text27 = statValue;
			text27.text = text27.text + "\n  " + character.display(character.wandoos98Controller.sadisticModifier() * 100f) + "%";
		}
		statsBreakdown.text += "\n<b>Total Wandoos Magic Speed:</b> ";
		Text text28 = statValue;
		text28.text = text28.text + "\n  " + character.display(character.totalWandoosMagicSpeed() * 100f) + "%";
	}

	public void displayEXPGain()
	{
		scrollbar.value = 1f;
		statTitle.text = "EXP/AP/PP Breakdowns";
		statsBreakdown.text = "\n<b>Base EXP Gain:</b> ";
		statValue.text = "\n  100%";
		if (character.inventory.itemList.itemMaxxed[119])
		{
			statsBreakdown.text += "\n<b>Red Heart Set Bonus Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		else
		{
			statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
			Text text = statValue;
			text.text = text.text + "\nx " + ((1f + character.inventoryController.bonuses[specType.EXP]) * 100f).ToString("###,##0") + "%";
		}
		statsBreakdown.text += "\n<b>NGU EXP Modifier:</b> ";
		Text text2 = statValue;
		text2.text = text2.text + "\nx " + (character.NGUController.expBonus() * 100f).ToString("###,##0") + "%";
		if (character.allDiggers.totalEXPBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text3 = statValue;
			text3.text = text3.text + "\nx " + (character.allDiggers.totalEXPBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.adventure.itopod.perkLevel[94] >= 987)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			statValue.text += "\nx 105%";
		}
		if (character.hacksController.totalEXPBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text4 = statValue;
			text4.text = text4.text + "\nx " + (character.hacksController.totalEXPBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.wishesController.totalExpBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
			Text text5 = statValue;
			text5.text = text5.text + "\nx " + (character.wishesController.totalExpBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.cookingController.totalExpBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Cooking Modifier:</b> ";
			Text text6 = statValue;
			text6.text = text6.text + "\nx " + (character.cookingController.totalExpBonus() * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Total EXP Bonus:</b> ";
		Text text7 = statValue;
		text7.text = text7.text + "\n  " + ((float)character.checkExpAdded(10000L) / 10000f * 100f).ToString("###,##0.##") + "%";
		statsBreakdown.text += "\n\n<b>Titan EXP Bonuses from 24H Challenge:</b> ";
		Text text8 = statValue;
		text8.text = text8.text + "\n\nx " + (character.allChallenges.expFactor() * 100f).ToString("###,##0.##") + "%";
		statsBreakdown.text += "\n\n<b>Base AP Gain:</b> ";
		statValue.text += "\n\n  100%";
		if (character.inventory.itemList.itemMaxxed[129])
		{
			statsBreakdown.text += "\n<b>Yellow Heart Set Bonus Modifier:</b> ";
			statValue.text += "\nx 120%";
		}
		else
		{
			statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
			Text text9 = statValue;
			text9.text = text9.text + "\nx " + ((1f + character.inventoryController.bonuses[specType.AP]) * 100f).ToString("###,##0.##") + "%";
		}
		statsBreakdown.text += "\n<b>Achievements Modifier:</b> ";
		Text text10 = statValue;
		text10.text = text10.text + "\nx " + (character.allAchievements.bonusAP() * 100f).ToString("###,##0.##") + "%";
		if (character.adventure.itopod.perkLevel[94] >= 89)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			statValue.text += "\nx 102%";
		}
		statsBreakdown.text += "\n<b>Total AP Bonus:</b> ";
		Text text11 = statValue;
		text11.text = text11.text + "\n  " + ((float)character.checkAPAdded(10000L) / 10000f * 100f).ToString("###,##0.##") + "%";
		statsBreakdown.text += "\n\n<b>Base PP Gain:</b> ";
		statValue.text += "\n\n  100%";
		if (character.inventory.itemList.itemMaxxed[171])
		{
			statsBreakdown.text += "\n<b>Green Heart Set Bonus Modifier:</b> ";
			statValue.text += "\nx 120%";
		}
		if (character.inventory.itemList.itopodKeyComplete)
		{
			statsBreakdown.text += "\n<b>Pissed Off Key Set Bonus Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.inventory.itemList.prettyComplete)
		{
			statsBreakdown.text += "\n<b>PPP Set Bonus Modifier:</b> ";
			statValue.text += "\nx 110%";
		}
		if (character.inventory.itemList.halloweeniesComplete)
		{
			statsBreakdown.text += "\n<b>Halloweenies Set Bonus Modifier:</b> ";
			statValue.text += "\nx 145%";
		}
		Text text12;
		if (character.adventure.itopod.buffedKills > 0 && character.settings.buffedKillsOn)
		{
			statsBreakdown.text += "\n<b>Pill Modifier:</b> ";
			text12 = statValue;
			text12.text = text12.text + "\nx " + character.allArbitrary.pillModifier() * 100f + "% ";
		}
		statsBreakdown.text += "\n<b>NGU PP Modifier:</b> ";
		Text text13 = statValue;
		text13.text = text13.text + "\nx " + (character.NGUController.PPBonus() * 100f).ToString("###,##0.##") + "%";
		if (character.allDiggers.totalPPBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
			Text text14 = statValue;
			text14.text = text14.text + "\nx " + (character.allDiggers.totalPPBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.adventure.itopod.perkLevel[94] >= 13)
		{
			statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
			statValue.text += "\nx 105%";
		}
		if (character.hacksController.totalPPGainBonus() > 1f)
		{
			statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
			Text text15 = statValue;
			text15.text = text15.text + "\nx " + (character.hacksController.totalPPGainBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.cardsController.getBonus(cardBonus.PP) > 1f)
		{
			statsBreakdown.text += "\n<b>Card Modifier:</b> ";
			Text text16 = statValue;
			text16.text = text16.text + "\nx " + character.cardsController.cardBonusString(cardBonus.PP);
		}
		statsBreakdown.text += "\n<b>Total PP Bonus:</b> ";
		Text text17 = statValue;
		text17.text = text17.text + "\n  " + (character.adventureController.itopod.totalPPBonus() * 100f).ToString("###,##0.##") + "%";
		text12 = statsBreakdown;
		text12.text = text12.text + "\n<b>Base PP progress Gain (On Floor " + character.calculateBestItopodLevel() + "):</b> ";
		Text text18 = statValue;
		text18.text = text18.text + "\n  " + character.adventureController.itopod.baseProgressGained(character.calculateBestItopodLevel()).ToString("###,##0");
		text12 = statsBreakdown;
		text12.text = text12.text + "\n<b>Total PP progress Gain (Floor " + character.calculateBestItopodLevel() + "):</b> ";
		Text text19 = statValue;
		text19.text = text19.text + "\n  " + character.adventureController.itopod.progressGained(character.calculateBestItopodLevel()).ToString("###,##0");
	}

	public void displayAPGain()
	{
		scrollbar.value = 1f;
		statTitle.text = "AP Gain Breakdown";
	}

	public void displayPPGain()
	{
		scrollbar.value = 1f;
		statTitle.text = "PP Gain Breakdown";
	}

	public void displayMisc()
	{
		scrollbar.value = 1f;
		statTitle.text = "Misc Breakdowns";
		statsBreakdown.text = "";
		statValue.text = "";
		if (character.purchases.hasDaycare)
		{
			statsBreakdown.text += "\n\n<b>Base Kitty Happiness</b> ";
			statValue.text += "\n\n  100%";
			if ((double)character.allDiggers.totalDaycareBonus() > 1.0)
			{
				statsBreakdown.text += "\n<b>Digger Modifier:</b> ";
				Text text = statValue;
				text.text = text.text + "\nx " + character.display(character.allDiggers.totalDaycareBonus(0, skipCheck: false) * 100f) + "%";
			}
			statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + (1f + character.inventoryController.bonuses[specType.DaycareSpeed]) * 100f + "%";
			if (character.allChallenges.blindChallenge.evilCompletions() > 0)
			{
				statsBreakdown.text += "\n<b>Evil Blind Challenge Modifier:</b> ";
				Text text3 = statValue;
				text3.text = text3.text + "\nx " + character.display((1f + (float)character.allChallenges.blindChallenge.evilCompletions() * 0.02f) * 100f) + "%";
			}
			if (character.allChallenges.blindChallenge.sadisticCompletions() > 0)
			{
				statsBreakdown.text += "\n<b>Sadistic Blind Challenge Modifier:</b> ";
				Text text4 = statValue;
				text4.text = text4.text + "\nx " + character.display((1f + (float)character.allChallenges.blindChallenge.sadisticCompletions() * 0.01f) * 100f) + "%";
			}
			if (character.hacksController.totalDaycareSpeedBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Hacks Modifier:</b> ";
				Text text5 = statValue;
				text5.text = text5.text + "\nx " + character.display(character.hacksController.totalDaycareSpeedBonus() * 100f) + "%";
			}
			if (character.wishesController.totalDaycareSpeedBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
				Text text6 = statValue;
				text6.text = text6.text + "\nx " + character.display(character.wishesController.totalDaycareSpeedBonus() * 100f) + "%";
			}
			if (character.cardsController.getBonus(cardBonus.dayCareSpeed) > 1f)
			{
				statsBreakdown.text += "\n<b>Card Modifier:</b> ";
				Text text7 = statValue;
				text7.text = text7.text + "\nx " + character.cardsController.cardBonusString(cardBonus.dayCareSpeed);
			}
			if (character.adventure.itopod.perkLevel[94] >= 55)
			{
				statsBreakdown.text += "\n<b>Fibonacci Perk Modifier:</b> ";
				statValue.text += "\nx 105%";
			}
			statsBreakdown.text += "\n<b>Total Kitty Happiness:</b> ";
			Text text8 = statValue;
			text8.text = text8.text + "\n  " + character.display(character.allDiggers.totalDaycareBonus() * 100f) + "%";
		}
		if (character.hacks.hacksOn)
		{
			statsBreakdown.text += "\n\n<b>Base Hack Speed</b> ";
			statValue.text += "\n\n  100%";
			statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + (1f + character.inventoryController.bonuses[specType.HackSpeed] + character.inventoryController.cubeHackBonus()) * 100f + "%";
			if (character.hacksController.totalHackBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
				Text text9 = statValue;
				text9.text = text9.text + "\nx " + character.display(character.hacksController.totalHackBonus() * 100f) + "%";
			}
			if (character.wishesController.totalHackSpeedBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
				Text text10 = statValue;
				text10.text = text10.text + "\nx " + character.display(character.wishesController.totalHackSpeedBonus() * 100f) + "%";
			}
			if (character.cardsController.getBonus(cardBonus.hackSpeed) > 1f)
			{
				statsBreakdown.text += "\n<b>Card Modifier:</b> ";
				Text text11 = statValue;
				text11.text = text11.text + "\nx " + character.cardsController.cardBonusString(cardBonus.hackSpeed);
			}
			if (character.inventory.itemList.itemMaxxed[297])
			{
				statsBreakdown.text += "\n<b>Grey Heart Set Bonus Modifier:</b> ";
				statValue.text += "\nx 125%";
			}
			if (character.allChallenges.NGUChallenge.evilCompletions() > 0)
			{
				statsBreakdown.text += "\n<b>Evil No NGU Challenge Modifier:</b> ";
				Text text12 = statValue;
				text12.text = text12.text + "\nx " + character.display((1f + (float)character.allChallenges.NGUChallenge.evilCompletions() * 0.2f) * 100f) + "%";
			}
			if (character.allChallenges.trollChallenge.evilCompletions() >= 5)
			{
				statsBreakdown.text += "\n<b>Evil Troll Challenge Modifier:</b> ";
				statValue.text += "\nx 125%";
			}
			statsBreakdown.text += "\n<b>Total Hack Speed:</b> ";
			Text text13 = statValue;
			text13.text = text13.text + "\n  " + character.display(character.hacksController.totalHackSpeedBonus() * 100f) + "%";
		}
		if (character.wishes.wishesOn)
		{
			statsBreakdown.text += "\n\n<b>Base Wish Speed</b> ";
			statValue.text += "\n\n  100%";
			if (character.wishesController.totalWishBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Wish Modifier:</b> ";
				Text text14 = statValue;
				text14.text = text14.text + "\nx " + character.display(character.wishesController.totalWishBonus() * 100f) + "%";
			}
			statsBreakdown.text += "\n<b>Equipment Modifier:</b> ";
			Text text2 = statValue;
			text2.text = text2.text + "\nx " + (1f + character.inventoryController.bonuses[specType.WishSpeed] + character.inventoryController.cubeWishBonus()) * 100f + "%";
			if (character.hacksController.totalWishSpeedBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Hack Modifier:</b> ";
				Text text15 = statValue;
				text15.text = text15.text + "\nx " + character.display(character.hacksController.totalWishSpeedBonus() * 100f) + "%";
			}
			if (character.cardsController.getBonus(cardBonus.wishSpeed) > 1f)
			{
				statsBreakdown.text += "\n<b>Card Modifier:</b> ";
				Text text16 = statValue;
				text16.text = text16.text + "\nx " + character.cardsController.cardBonusString(cardBonus.wishSpeed);
			}
			if (character.adventureController.itopod.totalWishSpeedBonus() > 1f)
			{
				statsBreakdown.text += "\n<b>Perk Modifier:</b> ";
				Text text17 = statValue;
				text17.text = text17.text + "\nx " + character.display(character.adventureController.itopod.totalWishSpeedBonus() * 100f) + "%";
			}
			if (character.inventory.itemList.severedHeadComplete)
			{
				statsBreakdown.text += "\n<b>Severed Head Set Completion Bonus:</b> ";
				statValue.text += "\nx 113.37%";
			}
			if (character.arbitrary.wishSpeedBoster)
			{
				statsBreakdown.text += "\n<b>Wish Speed Booster Modifier:</b> ";
				statValue.text += "\nx 125%";
			}
			if (character.inventory.itemList.typoComplete)
			{
				statsBreakdown.text += "\n<b>Typo Set Bonus Modifier:</b> ";
				statValue.text += "\nx 120%";
			}
			statsBreakdown.text += "\n<b>Total Wish Speed:</b> ";
			Text text18 = statValue;
			text18.text = text18.text + "\n  " + character.display(character.wishesController.totalWishSpeedBonuses() * 100f) + "%";
		}
	}
}
