using System.Collections.Generic;
using UnityEngine;

public class DifficultyOptionsMenu : MenuScreenClass
{
	private List<string> galaxyMapList = new List<string>();

	private DuskersMenuItem scrapMenuItem;

	private DuskersMenuItem upgradeBreakingMenuItem;

	private DuskersMenuItem enemyResetItem;

	private DuskersMenuItem enemyRectileItem;

	private DuskersMenuItem radiationEnabledMenuItem;

	private DuskersMenuItem ventEnabledMenuItem;

	private DuskersMenuItem blockingDroneMenuItem;

	private DuskersMenuItem blockingObjectsInFirstRoomMenuItem;

	private DuskersMenuItem blockingObjectsInOtherRoomMenuItem;

	private DuskersMenuItem galaxyDifficultyMenuItem;

	private DuskersMenuItem airlockMenuItem;

	private DuskersMenuItem disabledDroneWarningMenuItem;

	private DuskersMenuItem softResetMenuItem;

	private DuskersMenuItem abnormalShipRevisitItem;

	protected override void Initialize()
	{
		base.ActiveText = "Difficulty Options";
		base.IgnoreCancel = false;
		base.Initialize();
	}

	public override void LoadMenu()
	{
		int num = 0;
		radiationEnabledMenuItem = new DuskersMenuItem("[R]adiation\t\t", KeyCode.R, "Right", "Left", RadiationItem, RadiationItem, RadiationItem, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_RAD", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = radiation will not randomly happen - it can still come in from other events!",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(radiationEnabledMenuItem);
		ventEnabledMenuItem = new DuskersMenuItem("[V]ents\t\t", KeyCode.V, "Right", "Left", VentItem, VentItem, VentItem, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_VENT", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = vents will still be in the game, but enemies no longer use them",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(ventEnabledMenuItem);
		blockingDroneMenuItem = new DuskersMenuItem("[D]rones in Small Rooms\t", KeyCode.D, "Right", "Left", BlockingDroneItem, BlockingDroneItem, BlockingDroneItem, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_BLKDRONE", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = drones won't be placed in very narrow/small rooms",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(blockingDroneMenuItem);
		blockingObjectsInFirstRoomMenuItem = new DuskersMenuItem("[F]irst Room Blocking\t", KeyCode.F, "Right", "Left", BlockingObjectInFirstRoom, BlockingObjectInFirstRoom, BlockingObjectInFirstRoom, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_BLKOBJ_F", false)) ? "Disabled" : "Enabled"),
			Description = "Disabled = less likely passage through first room will be blocked by environment objects",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(blockingObjectsInFirstRoomMenuItem);
		blockingObjectsInOtherRoomMenuItem = new DuskersMenuItem("[O]ther Room Blocking\t", KeyCode.O, "Right", "Left", BlockingObjectInOtherRooms, BlockingObjectInOtherRooms, BlockingObjectInOtherRooms, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_BLKOBJ_O", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = less likely passage through other rooms will be blocked by environment objects",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(blockingObjectsInOtherRoomMenuItem);
		disabledDroneWarningMenuItem = new DuskersMenuItem("Silence Drone [W]arning\t\t", KeyCode.W, "Right", "Left", SuppressDisabledDroneWarning, SuppressDisabledDroneWarning, SuppressDisabledDroneWarning, num++)
		{
			TextValue = ((!GameSaveFile.Get("MSG_SUP_DISDRONEWARN", false)) ? "Disabled" : "Enabled"),
			Description = "Disabled = warning shown each time boarding a ship with a 0 hp drone in your fleet"
		};
		MenuPanelUI.Instance.AddMenuItem(disabledDroneWarningMenuItem);
		galaxyDifficultyMenuItem = new DuskersMenuItem("[E]asy Starting Galaxy\t\t", KeyCode.E, "Right", "Left", GalaxyDifficultyItem, GalaxyDifficultyItem, GalaxyDifficultyItem, num++)
		{
			TextValue = ((!GameSaveFile.Get("DIFF_GLXY", false)) ? "Disabled" : "Enabled"),
			Description = "Enabled = starting galaxies will be easier (change applies after a [R]eset or a [C]lear)",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(galaxyDifficultyMenuItem);
		airlockMenuItem = new DuskersMenuItem("[A]irlock Confirmation\t\t", KeyCode.A, "Right", "Left", AirlockDifficultyItem, AirlockDifficultyItem, AirlockDifficultyItem, num++)
		{
			TextValue = ((!GameSaveFile.Get("DIFF_W_AR", false)) ? "Disabled" : "Enabled"),
			Description = "Enabled = airlock will require confirmation everytime you attempt to open",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(airlockMenuItem);
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		int num2 = GameSaveFile.Get("DIFF_SCRAP", 0);
		DuskersMenuItem duskersMenuItem = new DuskersMenuItem("[S]crap\t\t", KeyCode.S, "Right", "Left", ScrapItem, ScrapItemIncrease, ScrapItemDecrease, num++);
		DuskersMenuItem duskersMenuItem2 = duskersMenuItem;
		object textValue;
		switch (num2)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Easy";
			break;
		default:
			textValue = "Hard";
			break;
		}
		duskersMenuItem2.TextValue = (string)textValue;
		duskersMenuItem.Description = "Easy = more scrap than normal, Hard = less scrap than normal";
		duskersMenuItem.Disabled = GlobalSettings.gameMode != GameModeEnum.Normal;
		scrapMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(scrapMenuItem);
		num2 = GameSaveFile.Get("DIFF_UPG", 0);
		duskersMenuItem = new DuskersMenuItem("Breaking [U]pgrades Damage\t\t", KeyCode.U, "Right", "Left", BreakingUpgradesItem, BreakingUpgradesItemIncrease, BreakingUpgradesItemDecrease, num++);
		DuskersMenuItem duskersMenuItem3 = duskersMenuItem;
		object textValue2;
		switch (num2)
		{
		case 0:
			textValue2 = "Normal";
			break;
		case 1:
			textValue2 = "Easy";
			break;
		default:
			textValue2 = "Hard";
			break;
		}
		duskersMenuItem3.TextValue = (string)textValue2;
		duskersMenuItem.Description = "Easy = upgrades get damaged slower, Hard = damaged faster";
		duskersMenuItem.Disabled = GlobalSettings.gameMode != GameModeEnum.Normal;
		upgradeBreakingMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(upgradeBreakingMenuItem);
		enemyResetItem = new DuskersMenuItem("E[n]emy Types Reset\t\t", KeyCode.N, "Right", "Left", ResetEnemyTypesItem, ResetEnemyTypesItemDecrease, ResetEnemyTypesItemDecrease, num++)
		{
			TextValue = (GameSaveFile.Get("D_ENMYRST", false) ? "Reset" : "Don't Reset"),
			Description = "If set to 'reset', harder enemy types will not be on earlier ships whenever you Reset the game (easier)",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(enemyResetItem);
		enemyRectileItem = new DuskersMenuItem("Enemy Red Re[c]tiles\t\t", KeyCode.C, "Right", "Left", EnemyRectiles, EnemyRectiles, EnemyRectiles, num++)
		{
			TextValue = (GameSaveFile.Get("D_ENMYREC", true) ? "Show" : "Don't Show"),
			Description = "Highlight nearby enemies with red rectiles (default).  Turn off to increase the difficulty.",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(enemyRectileItem);
		softResetMenuItem = new DuskersMenuItem("Allow Sof[t] Reset\t\t", KeyCode.T, "Right", "Left", SoftReset, SoftReset, SoftReset, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_SFTRST", false)) ? "Disabled" : "Enabled"),
			Description = "Basically removes perma-death. If you die, option to restore before mission, but ship marked explored. Not recommended.",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(softResetMenuItem);
		abnormalShipRevisitItem = new DuskersMenuItem("Abnor[m]al Exit Revisit\t", KeyCode.M, "Right", "Left", AbnormalShipRevisit, AbnormalShipRevisit, AbnormalShipRevisit, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_ABN_RVT", false)) ? "Disabled" : "Enabled"),
			Description = "Allows missions to be replayed if an abnormal event occured, and wasn't completed. Not recommended unless you experience crashes regularly in-mission.",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(abnormalShipRevisitItem);
		base.LoadMenu();
	}

	private void ScrapItem()
	{
		ScrapItemIncrease(null);
	}

	private void ScrapItemDecrease(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("DIFF_SCRAP", 0);
		num++;
		if (num > 2)
		{
			num = 0;
		}
		RefreshScrapItem(num);
	}

	private void ScrapItemIncrease(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("DIFF_SCRAP", 0);
		num--;
		if (num < 0)
		{
			num = 2;
		}
		RefreshScrapItem(num);
	}

	private void RefreshScrapItem(int newValue)
	{
		GameSaveFile.Save("DIFF_SCRAP", newValue);
		DuskersMenuItem duskersMenuItem = scrapMenuItem;
		object textValue;
		switch (newValue)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Easy";
			break;
		default:
			textValue = "Hard";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
	}

	private void ResetEnemyTypesItem()
	{
		ResetEnemyTypesItemDecrease(null);
	}

	private void ResetEnemyTypesItemDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_ENMYRST", !GameSaveFile.Get("D_ENMYRST", false));
		enemyResetItem.TextValue = (GameSaveFile.Get("D_ENMYRST", false) ? "Reset" : "Don't Reset");
	}

	private void EnemyRectiles()
	{
		EnemyRectiles(null);
	}

	private void EnemyRectiles(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_ENMYREC", !GameSaveFile.Get("D_ENMYREC", true));
		enemyRectileItem.TextValue = (GameSaveFile.Get("D_ENMYREC", true) ? "Show" : "Don't Show");
	}

	private void SoftReset()
	{
		SoftReset(null);
	}

	private void SoftReset(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_SFTRST", !GameSaveFile.Get("D_SFTRST", false));
		softResetMenuItem.TextValue = ((!GameSaveFile.Get("D_SFTRST", false)) ? "Disabled" : "Enabled");
	}

	private void AbnormalShipRevisit()
	{
		AbnormalShipRevisit(null);
	}

	private void AbnormalShipRevisit(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_ABN_RVT", !GameSaveFile.Get("D_ABN_RVT", false));
		abnormalShipRevisitItem.TextValue = ((!GameSaveFile.Get("D_ABN_RVT", false)) ? "Disabled" : "Enabled");
	}

	private void BreakingUpgradesItem()
	{
		BreakingUpgradesItemIncrease(null);
	}

	private void BreakingUpgradesItemDecrease(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("DIFF_UPG", 0);
		num++;
		if (num > 2)
		{
			num = 0;
		}
		RefreshBreakingUpgradesItem(num);
	}

	private void BreakingUpgradesItemIncrease(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("DIFF_UPG", 0);
		num--;
		if (num < 0)
		{
			num = 2;
		}
		RefreshBreakingUpgradesItem(num);
	}

	private void RefreshBreakingUpgradesItem(int newValue)
	{
		GameSaveFile.Save("DIFF_UPG", newValue);
		DuskersMenuItem duskersMenuItem = upgradeBreakingMenuItem;
		object textValue;
		switch (newValue)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Easy";
			break;
		default:
			textValue = "Hard";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
	}

	private void RadiationItem()
	{
		RadiationItem(null);
	}

	private void RadiationItem(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_RAD", !GameSaveFile.Get("D_RAD", true));
		radiationEnabledMenuItem.TextValue = ((!GameSaveFile.Get("D_RAD", true)) ? "Disabled" : "Enabled");
	}

	private void GalaxyDifficultyItem()
	{
		GalaxyDifficultyItem(null);
	}

	private void GalaxyDifficultyItem(DuskersMenuItem item)
	{
		GameSaveFile.Save("DIFF_GLXY", !GameSaveFile.Get("DIFF_GLXY", false));
		galaxyDifficultyMenuItem.TextValue = ((!GameSaveFile.Get("DIFF_GLXY", true)) ? "Disabled" : "Enabled");
	}

	private void AirlockDifficultyItem()
	{
		AirlockDifficultyItem(null);
	}

	private void AirlockDifficultyItem(DuskersMenuItem item)
	{
		GameSaveFile.Save("DIFF_W_AR", !GameSaveFile.Get("DIFF_W_AR", false));
		airlockMenuItem.TextValue = ((!GameSaveFile.Get("DIFF_W_AR", true)) ? "Disabled" : "Enabled");
	}

	private void VentItem()
	{
		VentItem(null);
	}

	private void VentItem(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_VENT", !GameSaveFile.Get("D_VENT", true));
		ventEnabledMenuItem.TextValue = ((!GameSaveFile.Get("D_VENT", true)) ? "Disabled" : "Enabled");
	}

	private void BlockingDroneItem()
	{
		BlockingDroneItem(null);
	}

	private void BlockingDroneItem(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_BLKDRONE", !GameSaveFile.Get("D_BLKDRONE", true));
		blockingDroneMenuItem.TextValue = ((!GameSaveFile.Get("D_BLKDRONE", true)) ? "Disabled" : "Enabled");
	}

	private void BlockingObjectInFirstRoom()
	{
		BlockingObjectInFirstRoom(null);
	}

	private void BlockingObjectInFirstRoom(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_BLKOBJ_F", !GameSaveFile.Get("D_BLKOBJ_F", false));
		blockingObjectsInFirstRoomMenuItem.TextValue = ((!GameSaveFile.Get("D_BLKOBJ_F", false)) ? "Disabled" : "Enabled");
	}

	private void BlockingObjectInOtherRooms()
	{
		BlockingObjectInOtherRooms(null);
	}

	private void BlockingObjectInOtherRooms(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_BLKOBJ_O", !GameSaveFile.Get("D_BLKOBJ_O", true));
		blockingObjectsInOtherRoomMenuItem.TextValue = ((!GameSaveFile.Get("D_BLKOBJ_O", true)) ? "Disabled" : "Enabled");
	}

	private void SuppressDisabledDroneWarning()
	{
		SuppressDisabledDroneWarning(null);
	}

	private void SuppressDisabledDroneWarning(DuskersMenuItem item)
	{
		GameSaveFile.Save("MSG_SUP_DISDRONEWARN", !GameSaveFile.Get("MSG_SUP_DISDRONEWARN", false));
		disabledDroneWarningMenuItem.TextValue = ((!GameSaveFile.Get("MSG_SUP_DISDRONEWARN", false)) ? "Disabled" : "Enabled");
	}
}
