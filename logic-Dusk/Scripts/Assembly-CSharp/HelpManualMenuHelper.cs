using System;
using System.Collections.Generic;
using UnityEngine;

public class HelpManualMenuHelper
{
	private HelpManualMenu _firstMenu;

	private HelpManualMenu droneUpgrades;

	private bool useSimpleHelp;

	public bool BuildMenus()
	{
		return BuildMenus(false);
	}

	public bool BuildMenus(bool useSimpleHelp)
	{
		this.useSimpleHelp = useSimpleHelp;
		bool result = true;
		HelpManualMenu helpManualMenu = (_firstMenu = new HelpManualMenu("Main Menu"));
		HelpManualMenu helpManualMenu2 = new HelpManualMenu("Basic Commands");
		HelpManualMenu helpManualMenu3 = new HelpManualMenu("Basic Controls");
		HelpManualMenu helpManualMenu4 = new HelpManualMenu("Advanced Commands");
		droneUpgrades = new HelpManualMenu("Drone Upgrades");
		HelpManualMenu helpManualMenu5 = new HelpManualMenu("Ship Upgrades");
		HelpManualMenu helpManualMenu6 = new HelpManualMenu("Strategy");
		HelpManualMenu helpManualMenu7 = new HelpManualMenu("Tips");
		try
		{
			helpManualMenu.MenuItems.Add("0", new HelpManualMenuItem(helpManualMenu2));
			helpManualMenu.MenuItems.Add("1", new HelpManualMenuItem(helpManualMenu3));
			helpManualMenu.MenuItems.Add("2", new HelpManualMenuItem(helpManualMenu4));
			helpManualMenu.MenuItems.Add("3", new HelpManualMenuItem(droneUpgrades));
			helpManualMenu.MenuItems.Add("4", new HelpManualMenuItem(helpManualMenu5));
			helpManualMenu.MenuItems.Add("5", new HelpManualMenuItem(helpManualMenu6));
			helpManualMenu.MenuItems.Add("6", new HelpManualMenuItem(helpManualMenu7));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("GlobalCommands"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("ShortcutCommands"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonManager"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonManager.Derelict"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonTerminalType"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.Scan"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.defense"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("BoardingVessel"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.Scan"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("DroneManager"));
			AddCommands(helpManualMenu2.MenuItems, CommandHelper.GetCommands("Drone"));
			helpManualMenu3.MenuItems.Add("a", new HelpManualMenuItem("SPACE", "Toggle between Drone and Schematic View", false));
			helpManualMenu3.MenuItems.Add("b", new HelpManualMenuItem("1", "Switch to first drone in fleet", false));
			helpManualMenu3.MenuItems.Add("c", new HelpManualMenuItem("2", "Switch to second drone in fleet", false));
			helpManualMenu3.MenuItems.Add("d", new HelpManualMenuItem("3", "Switch to third drone in fleet", false));
			helpManualMenu3.MenuItems.Add("e", new HelpManualMenuItem("4", "Switch to fourth drone in fleet", false));
			helpManualMenu3.MenuItems.Add("f", new HelpManualMenuItem("Up", "Drive drone forward (Drone View) or pan schematic up (Schematic View)", false));
			helpManualMenu3.MenuItems.Add("g", new HelpManualMenuItem("Down", "Drive drone backward (Drone View) or pan schematic down (Schematic View)", false));
			helpManualMenu3.MenuItems.Add("h", new HelpManualMenuItem("Left", "Turn drone left (Drone View) or pan schematic left (Schematic View)", false));
			helpManualMenu3.MenuItems.Add("i", new HelpManualMenuItem("Right", "Turn drone right (Drone View) or pan schematic right (Schematic View)", false));
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("GlobalCommands"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("ShortcutCommands"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonManager"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonManager.Derelict"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonTerminalType"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.Scan"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.defense"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("BoardingVessel"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DungeonTerminalType.Scan"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("DroneManager"), true);
			AddCommands(helpManualMenu4.MenuItems, CommandHelper.GetCommands("Drone"), true);
			RefreshDroneUpdadeMenu();
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("ShipUpgradeTransporter"));
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("ShipUpgradePowerManager"));
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("ShipUpgradeRemotePower"));
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("PermShipUpgradeCannon"));
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("PermShipUpgradeDecontainate"));
			AddCommands(helpManualMenu5.MenuItems, CommandHelper.GetCommands("PermShipUpgradeOverload"));
			helpManualMenu7.MenuItems.Add("0", new HelpManualMenuItem("Semicolon [ ; ]", SemicolonText(), false));
			helpManualMenu7.MenuItems.Add("1", new HelpManualMenuItem("Single-Quote [ ' ]", ApostropheText(), false));
			helpManualMenu7.MenuItems.Add("2", new HelpManualMenuItem("Alias", AliasText(), false));
			helpManualMenu7.MenuItems.Add("3", new HelpManualMenuItem("CTRL + UP", CtrlUpText(), false));
			helpManualMenu7.MenuItems.Add("4", new HelpManualMenuItem("CTRL + DOWN", CtrlDownText(), false));
			helpManualMenu7.MenuItems.Add("5", new HelpManualMenuItem("CTRL + PLUS [ + ]", ResizeFontTextUp(), false));
			helpManualMenu7.MenuItems.Add("6", new HelpManualMenuItem("CTRL + MINUS [ - ]", ResizeFontTextDown(), false));
			helpManualMenu7.MenuItems.Add("7", new HelpManualMenuItem("CTRL + C", ClearText(), false));
			helpManualMenu7.MenuItems.Add("8", new HelpManualMenuItem("CTRL + U", "Clear everything before the cursor in the command line", false));
			helpManualMenu7.MenuItems.Add("9", new HelpManualMenuItem("CTRL + A", "Jump to beginning of command line", false));
			helpManualMenu7.MenuItems.Add("a", new HelpManualMenuItem("CTRL + E", "Jump to end of command line", false));
			helpManualMenu7.MenuItems.Add("b", new HelpManualMenuItem("CTRL + BACKSPACE", "Delete the previous word in the command line", false));
			helpManualMenu7.MenuItems.Add("c", new HelpManualMenuItem("F8", ResizeConsoleText(), false));
			helpManualMenu7.MenuItems.Add("d", new HelpManualMenuItem("SHIFT + Up/Down Arrow", ScrollUpDownInConsole(), false));
			helpManualMenu7.MenuItems.Add("e", new HelpManualMenuItem("SHIFT + Left/Right Arrow", ScrollLeftRightInConsole(), false));
			helpManualMenu7.MenuItems.Add("f", new HelpManualMenuItem("HOME", "When viewing another system, this returns you to your current system\n\nWhen in a mission, this centers the Schematic View", false));
			helpManualMenu7.MenuItems.Add("g", new HelpManualMenuItem("Using Drone Names", "Just about anywhere you specify the drone NUMBER you can use the drone NAME, instead.\n\nFor example:\n\tnavigate John r5\n\nNote that while the names do NOT auto-complete, you can use partial names, as well:\n\tgather Jo all", false));
			helpManualMenu6.MenuItems.Add("0", new HelpManualMenuItem("Motion", "Don't rely on Motion Sensor exclusively for exploration. Many other upgrades can be used by themselves or in tandem to safely explore derelicts", false));
			helpManualMenu6.MenuItems.Add("1", new HelpManualMenuItem("Difficulty", "In the options there are MANY difficulty options. Try adjusting some settings to make the game easier till you get the hang of things", false));
			helpManualMenu6.MenuItems.Add("2", new HelpManualMenuItem("Doors", "It is a bad idea to open a door if you don't know if there are threats on the other side. There's another way to explore, take a moment to think it through", false));
			helpManualMenu6.MenuItems.Add("3", new HelpManualMenuItem("Greed", "Take what you need and run. Trying to explore that last room might net you some scrap, or a fleet of dead drones.", false));
			helpManualMenu6.MenuItems.Add("4", new HelpManualMenuItem("Subterfuge", "There are several ways to skulk about a ship, rarely is confronting a threat a good move.", false));
			helpManualMenu6.MenuItems.Add("5", new HelpManualMenuItem("Ship Types", "Different ship types/classes/ages have different tendencies, both in terms of risks and rewards. Pay attention and let that help you choose which ship to board", false));
			helpManualMenu6.MenuItems.Add("6", new HelpManualMenuItem("Safe Start", "The first room (and adjoining rooms with open doors) are safe initially and don't contain threats. Initially.", false));
			helpManualMenu6.MenuItems.Add("7", new HelpManualMenuItem("Docking Bay", "Your docking bay can be used for more than cold storage, aided by the right upgrades.", false));
			helpManualMenu6.MenuItems.Add("8", new HelpManualMenuItem("Tells", "Threats all behave differently. By learning their 'tells' and paying attention to the number of infestation types, you can deduce which are aboard. In turn you'll know, say, if it's safe to be in a room with a vent or not...", false));
			helpManualMenu6.MenuItems.Add("9", new HelpManualMenuItem("Commandeering", "Commandeering a ship can not only net you more ship upgrades (those permanently and securely installed), but more ship upgrade slots, scrap capacity (listed on system map or with 'status' command), fuel capacity (use 'info' command on fuel access point), and certain specialized ship upgrades. Likewise ships wear over time (see 'Ship Wear') and start to malfunction so keep an eye out for signs of wear (ship slots & ship schematic video feed).", false));
			helpManualMenu6.MenuItems.Add("91", new HelpManualMenuItem("Scrap", "Some scrap can only be revealed by scanning", false));
			helpManualMenu6.MenuItems.Add("92", new HelpManualMenuItem("Upgrade Wear", "Upgrades take wear upon initial activation during a mission. So if you don't use an upgrade it will not wear, and after initial use on a mission, additional uses do not cause significant wear.", false));
			helpManualMenu6.MenuItems.Add("93", new HelpManualMenuItem("Ship Wear", "Your ship will wear over time. Ship upgrade slots will deteriorate, as will the schematic view video feed. Commandeering another vessel is recommended as the new vessel will have less wear, and repairing slots and ship video feed can be cost prohibitive.", false));
		}
		catch (Exception ex)
		{
			result = false;
			Debug.LogError("Failed to load help manual menu:" + ex.Message + "\n" + ex.StackTrace);
		}
		return result;
	}

	private string SemicolonText()
	{
		return "Semicolons can be used to execute more than one command on a single command line.  Example:\n\n> open d5; navigate 1 r4; navigate 3 r7\n\nCommands issued to the same drone will get executed serially (one after another). Other commands will execute in parallel (at the same time)\n\nExample: navigate 2 a1; generator; navigate 3; a1\n\nDrone 2 will not attempt to power it's generator until after navigating through a1, however drone 3 will immediately navigate\n\nDoor and Airlock commands are issued to the ship and happen in parallel (immediately)";
	}

	private string AliasText()
	{
		return "The alias file can be used to alias an entire command line with one keyword.  Example:\n\nend=navigate 1 2 3 4 r1\n\nType 'alias' into the command prompt to edit the file.\n\nYou can also add new aliases directly from the command prompt:\n\n> alias end=navigate 1 2 3 4 r1";
	}

	private string CtrlUpText()
	{
		return "Move backwards through console history.";
	}

	private string CtrlDownText()
	{
		return "Move forwards through console history.  Can be used to clear the input line of a partially entered command.";
	}

	private string ClearText()
	{
		return "Clears the input line of a partially entered command from the console";
	}

	private string ApostropheText()
	{
		return "When visiting a ship, press the apostrophe (') character in the schematic view to toggle the icons on and off and see room numbers more easily in a crowded room.";
	}

	private string ResizeConsoleText()
	{
		return "Expand/Collapse the console window";
	}

	private string ResizeFontTextUp()
	{
		return "Increase console text size";
	}

	private string ResizeFontTextDown()
	{
		return "Decrease console text size";
	}

	private string ScrollUpDownInConsole()
	{
		return "Page Up/Down in Console (alt: use PGUP/DN)";
	}

	private string ScrollLeftRightInConsole()
	{
		return "Scroll Left/Right in Console (alt: use SHIFT + PGUP/DN)";
	}

	public void RefreshDroneUpdadeMenu()
	{
		List<DroneUpgradeType> discoveredUpgrades = GlobalSettings.DiscoveredUpgrades;
		discoveredUpgrades.AddRange(GlobalSettings.DiscoveredUpgrades_Exploring);
		droneUpgrades.MenuItems.Clear();
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.AreaSensor))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("MotionSensorUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.BruteTurret))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("BruteTurretUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.StealthField))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("StealthUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Gatherer))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("GathererUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Generator))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("GeneratorUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Interface))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("InterfaceUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Lure))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("LureUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Probe))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("ProbeUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.ProximityMine))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("ProximityMineUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Repair))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("RepairUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Scanner))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("ScannerUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Sensor))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("SensorUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Shield))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("ShieldUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Stun))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("StunUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.SwarmTurret))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("SwarmTurretUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Teleporter))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("TeleporterUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Trap))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("TrapUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Sonic))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("SonicUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Tow))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("TowUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.Pry))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("PryUpgrade"));
		}
		if (useSimpleHelp || FastUpgradeTypeContains(discoveredUpgrades, DroneUpgradeType.SpeedBoost))
		{
			AddCommands(droneUpgrades.MenuItems, CommandHelper.GetCommands("SpeedboostUpgrade"));
		}
	}

	private bool FastUpgradeTypeContains(List<DroneUpgradeType> lst, DroneUpgradeType upgradeType)
	{
		int count = lst.Count;
		for (int i = 0; i < count; i++)
		{
			if (lst[i] == upgradeType)
			{
				return true;
			}
		}
		return false;
	}

	private HelpManualMenuItem CreateHelpMenuItem(CommandDefinition command)
	{
		string empty = string.Empty;
		if (!useSimpleHelp)
		{
			string text = empty;
			empty = text + "<color=#" + HelpManualScript.Instance.hexBaseHighlightColor + ">> help " + command.CommandName + "</color>";
			text = empty;
			empty = text + "\n<color=#" + HelpManualScript.Instance.hexBaseColor + ">" + command.Description + "</color>";
			if (command.Example != string.Empty)
			{
				text = empty;
				empty = text + "\n    <color=#" + HelpManualScript.Instance.hexBaseColor + ">" + command.Example + "</color>";
			}
			if (command.DetailedDescription != null && command.DetailedDescription.Count > 0)
			{
				int count = command.DetailedDescription.Count;
				for (int i = 0; i < count; i++)
				{
					text = empty;
					empty = text + "\n<color=#" + HelpManualScript.Instance.hexDetailColor + ">" + command.DetailedDescription[i].Message + "</color>";
				}
			}
			if (command.ModList != null && command.ModList.Count > 0)
			{
				empty = empty + "\n\n<color=#" + HelpManualScript.Instance.hexBaseHighlightColor + ">== available modifications == </color>";
				int count2 = command.ModList.Count;
				for (int j = 0; j < count2; j++)
				{
					if (j > 0)
					{
						empty += "\n";
					}
					text = empty;
					empty = text + "\n <color=#" + HelpManualScript.Instance.hexBaseHighlightColor + ">" + command.ModList[j].ModType + "</color>";
					if (command.ModList[j].Symbol != string.Empty)
					{
						empty = empty + " (" + command.ModList[j].Symbol + ")";
					}
					text = empty;
					empty = text + "\n <color=#" + HelpManualScript.Instance.hexBaseColor + ">" + command.ModList[j].Description + "</color>";
					if (command.ModList[j].Example != string.Empty)
					{
						text = empty;
						empty = text + "\n    <color=#" + HelpManualScript.Instance.hexBaseColor + ">" + command.ModList[j].Example + "</color>";
					}
				}
			}
		}
		else
		{
			empty += command.Description;
		}
		return new HelpManualMenuItem(command.CommandName, empty);
	}

	public void AddCommands(SortedList<string, HelpManualMenuItem> items, List<CommandDefinition> commands)
	{
		AddCommands(items, commands, false);
	}

	public void AddCommands(SortedList<string, HelpManualMenuItem> items, List<CommandDefinition> commands, bool advancedOnly)
	{
		int count = commands.Count;
		for (int i = 0; i < count; i++)
		{
			CommandDefinition commandDefinition = commands[i];
			if (commandDefinition.IsAdvanced == advancedOnly && !commandDefinition.DeveloperCommand && !commandDefinition.InternalCmd && !commandDefinition.HideFromManual && !FastListContains(items, commandDefinition.CommandName))
			{
				items.Add(commandDefinition.CommandName, CreateHelpMenuItem(commandDefinition));
			}
		}
	}

	private bool FastListContains(SortedList<string, HelpManualMenuItem> items, string key)
	{
		IList<string> keys = items.Keys;
		int count = keys.Count;
		int length = key.Length;
		for (int i = 0; i < count; i++)
		{
			string text = keys[i];
			char c = text[0];
			char c2 = key[0];
			if (c > c2)
			{
				return false;
			}
			if (text.Length == length && c == c2 && text == key)
			{
				return true;
			}
		}
		return false;
	}

	public HelpManualMenu GetFirstMenu()
	{
		return _firstMenu;
	}

	public string FindHelpText(string commandName)
	{
		if (commandName == null)
		{
			return string.Empty;
		}
		IEnumerator<KeyValuePair<string, HelpManualMenuItem>> enumerator = _firstMenu.MenuItems.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IEnumerator<KeyValuePair<string, HelpManualMenuItem>> enumerator2 = enumerator.Current.Value.JumpToMenu.MenuItems.GetEnumerator();
			SortedList<string, HelpManualMenuItem> menuItems = enumerator.Current.Value.JumpToMenu.MenuItems;
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current.Key != null && enumerator2.Current.Key.ToLower() == commandName.ToLower())
				{
					return enumerator2.Current.Value.HelpText;
				}
			}
		}
		return string.Empty;
	}
}
