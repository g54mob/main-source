using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerminalManager : ICommandable
{
	public static TerminalManager Instance;

	private List<DungeonTerminal> terminalList;

	private List<CommandDefinition> filteredCommandDefinitionList = new List<CommandDefinition>();

	private bool hasDefenses;

	private bool hasSurvey;

	private bool hasShipScan;

	private bool haveFilteredCommandList;

	public static bool ScavengerHunt_CanTriggerWin { get; set; }

	public bool TerminalAccessed { get; set; }

	public string CommandHeader
	{
		get
		{
			return string.Empty;
		}
	}

	public bool IsPrimaryCommandContext { get; set; }

	public TerminalManager()
	{
		terminalList = new List<DungeonTerminal>();
		Object[] array = Object.FindObjectsOfType(typeof(DungeonTerminal));
		Object[] array2 = array;
		foreach (Object obj in array2)
		{
			if (obj != null)
			{
				DungeonTerminal item = (DungeonTerminal)obj;
				terminalList.Add(item);
			}
		}
		int num = 1;
		if (Random.Range(0, 100) < 30 || !GameSaveFile.Get("NC", false))
		{
			num = ((Random.Range(0, 100) >= 30) ? 2 : 3);
		}
		if (terminalList.Count > 0 && DungeonManager.Instance.defenses.Length > 0)
		{
			hasDefenses = true;
			num--;
		}
		if (num > 0)
		{
			if (num == 2)
			{
				hasShipScan = true;
				hasSurvey = true;
			}
			else if (GameSaveFile.Get("NC", false))
			{
				if (Random.Range(0, 100) < 50)
				{
					hasShipScan = true;
				}
				else
				{
					hasSurvey = true;
				}
			}
			else
			{
				hasShipScan = true;
			}
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (hasDefenses)
		{
			List<DungeonTerminal> list = new List<DungeonTerminal>();
			List<DungeonPowerInlet> list2 = new List<DungeonPowerInlet>();
			DungeonDefense[] defenses = DungeonManager.Instance.defenses;
			foreach (DungeonDefense dungeonDefense in defenses)
			{
				foreach (DungeonPowerInlet potentialPowerSource in dungeonDefense.roomLocation.potentialPowerSourceList)
				{
					if (!list2.Contains(potentialPowerSource))
					{
						list2.Add(potentialPowerSource);
					}
				}
				foreach (DungeonTerminal terminal in terminalList)
				{
					if (terminal.roomLocation.potentialPowerSourceList == null || terminal.roomLocation.potentialPowerSourceList.Count <= 0)
					{
						continue;
					}
					foreach (DungeonPowerInlet potentialPowerSource2 in dungeonDefense.roomLocation.potentialPowerSourceList)
					{
						if (terminal.roomLocation.potentialPowerSourceList.Contains(potentialPowerSource2))
						{
							list.Add(terminal);
							break;
						}
					}
				}
			}
			if (list.Count > 0)
			{
				do
				{
					int index = Random.Range(0, list.Count);
					list[index].supportsDefenseCommand = true;
					list.RemoveAt(index);
					num2++;
				}
				while (list.Count > 0 && Random.Range(0, 100) < 25);
			}
		}
		foreach (DungeonTerminal terminal2 in terminalList)
		{
			if (hasShipScan && hasSurvey)
			{
				if (!terminal2.supportsDefenseCommand || Random.Range(0, 2) == 0)
				{
					switch (Random.Range(0, 3))
					{
					case 0:
						terminal2.supportsSurveyCommand = true;
						terminal2.supportsShipScanCommand = true;
						num4++;
						num3++;
						break;
					case 1:
						terminal2.supportsSurveyCommand = true;
						num3++;
						break;
					case 2:
						terminal2.supportsShipScanCommand = true;
						num4++;
						break;
					}
				}
			}
			else if (hasShipScan)
			{
				if (!terminal2.supportsDefenseCommand || Random.Range(0, 2) == 0)
				{
					terminal2.supportsShipScanCommand = true;
				}
			}
			else if (hasSurvey && (!terminal2.supportsDefenseCommand || Random.Range(0, 2) == 0))
			{
				terminal2.supportsSurveyCommand = true;
			}
		}
		if (terminalList.Count > 0)
		{
			if (hasDefenses && num2 == 0)
			{
				List<DungeonTerminal> list3 = null;
				DungeonTerminal[] array3 = new DungeonTerminal[terminalList.Count];
				terminalList.CopyTo(array3);
				list3 = new List<DungeonTerminal>(array3);
				do
				{
					int index2 = Random.Range(0, list3.Count);
					list3[index2].supportsDefenseCommand = true;
					list3.RemoveAt(index2);
				}
				while (list3.Count > 0 && Random.Range(0, 100) < 25);
			}
			if (hasSurvey && num3 == 0)
			{
				List<DungeonTerminal> list4 = null;
				DungeonTerminal[] array4 = new DungeonTerminal[terminalList.Count];
				terminalList.CopyTo(array4);
				list4 = new List<DungeonTerminal>(array4);
				do
				{
					int index3 = Random.Range(0, list4.Count);
					list4[index3].supportsSurveyCommand = true;
					list4.RemoveAt(index3);
				}
				while (list4.Count > 0 && Random.Range(0, 100) < 25);
			}
			if (hasShipScan && num4 == 0)
			{
				List<DungeonTerminal> list5 = null;
				DungeonTerminal[] array5 = new DungeonTerminal[terminalList.Count];
				terminalList.CopyTo(array5);
				list5 = new List<DungeonTerminal>(array5);
				do
				{
					int index4 = Random.Range(0, list5.Count);
					list5[index4].supportsShipScanCommand = true;
					list5.RemoveAt(index4);
				}
				while (list5.Count > 0 && Random.Range(0, 100) < 25);
			}
			foreach (DungeonTerminal terminal3 in terminalList)
			{
				if (!terminal3.supportsDefenseCommand && !terminal3.supportsShipScanCommand && !terminal3.supportsSurveyCommand)
				{
					if (hasDefenses)
					{
						terminal3.supportsDefenseCommand = true;
						continue;
					}
					int num5 = 0;
					num5++;
				}
			}
		}
		Instance = this;
	}

	public List<CommandDefinition> QueryAvailableCommands()
	{
		if (TerminalAccessed && !haveFilteredCommandList)
		{
			List<CommandDefinition> commands = CommandHelper.GetCommands("DungeonTerminalType");
			CommandDefinition[] array = new CommandDefinition[commands.Count];
			commands.CopyTo(array);
			filteredCommandDefinitionList.AddRange(commands);
			if (!hasDefenses)
			{
				int count = filteredCommandDefinitionList.Count;
				for (int num = count - 1; num >= 0; num--)
				{
					if (filteredCommandDefinitionList[num].CommandName == "defense")
					{
						filteredCommandDefinitionList.RemoveAt(num);
						break;
					}
				}
			}
			if (!hasSurvey)
			{
				int count2 = filteredCommandDefinitionList.Count;
				for (int num2 = count2 - 1; num2 >= 0; num2--)
				{
					if (filteredCommandDefinitionList[num2].CommandName == "survey")
					{
						filteredCommandDefinitionList.RemoveAt(num2);
						break;
					}
				}
			}
			if (!hasShipScan)
			{
				int count3 = filteredCommandDefinitionList.Count;
				for (int num3 = count3 - 1; num3 >= 0; num3--)
				{
					if (filteredCommandDefinitionList[num3].CommandName == "shipscan")
					{
						filteredCommandDefinitionList.RemoveAt(num3);
						break;
					}
				}
			}
			haveFilteredCommandList = true;
		}
		return filteredCommandDefinitionList;
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		return QueryAvailableCommands();
	}

	public void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		bool flag = false;
		switch (command.Command.CommandName)
		{
		case "shipscan":
		case "defense":
		case "terminal":
		case "survey":
			if (hasDefenses || command.Command.CommandName != "defense")
			{
				foreach (DungeonTerminal terminal in terminalList)
				{
					if (terminal.Powered && terminal.isActivated())
					{
						if (command.Command.CommandName == "terminal")
						{
							flag = true;
						}
						else if (command.Command.CommandName == "shipscan" && terminal.supportsShipScanCommand)
						{
							flag = true;
						}
						else if (command.Command.CommandName == "defense" && terminal.supportsDefenseCommand)
						{
							flag = true;
						}
						else if (command.Command.CommandName == "survey" && terminal.supportsSurveyCommand)
						{
							flag = true;
						}
						if (flag)
						{
							break;
						}
					}
				}
			}
			command.Handled = true;
			break;
		}
		if (flag)
		{
			switch (command.Command.CommandName)
			{
			case "shipscan":
				ConsoleWindow3.SendConsoleResponse("Scanning...", ConsoleMessageType.Info);
				if (command.Arguments.Count == 0 || command.Arguments[0].ToLower() == "all")
				{
					command.Handled = true;
					Room[] rooms = DungeonManager.Instance.rooms;
					foreach (Room room in rooms)
					{
						if (room.isPowered && room.Label.ToLower() != "r1")
						{
							string result;
							if (room.scan(true, out result))
							{
								ConsoleWindow3.SendConsoleResponse("    " + room.Label + ": " + result, ConsoleMessageType.Info);
							}
							else
							{
								ConsoleWindow3.SendConsoleResponse("    " + room.Label + ": Error Scanning", ConsoleMessageType.Error);
							}
						}
					}
				}
				else
				{
					foreach (string argument in command.Arguments)
					{
						Room[] rooms2 = DungeonManager.Instance.rooms;
						foreach (Room room2 in rooms2)
						{
							if (!(room2.Label.ToLower() == argument.ToLower()) || !room2.isPowered)
							{
								continue;
							}
							command.Handled = true;
							if (room2.Label.ToLower() != "r1")
							{
								string result2;
								if (room2.scan(true, out result2))
								{
									ConsoleWindow3.SendConsoleResponse(room2.Label + ": " + result2, ConsoleMessageType.Info);
								}
								else
								{
									ConsoleWindow3.SendConsoleResponse(room2.Label + ": Error Scanning", ConsoleMessageType.Error);
								}
							}
						}
					}
				}
				ConsoleWindow3.SendConsoleResponse("View scan results on schematic view", ConsoleMessageType.Info);
				break;
			case "defense":
			{
				bool flag2 = false;
				DungeonDefense[] defenses = DungeonManager.Instance.defenses;
				foreach (DungeonDefense dungeonDefense in defenses)
				{
					if (dungeonDefense != null && dungeonDefense.Powered && !dungeonDefense.IsDead)
					{
						if (dungeonDefense.toggleArmed())
						{
							ConsoleWindow3.SendConsoleResponse("Defenses Activated", ConsoleMessageType.Info);
						}
						else
						{
							ConsoleWindow3.SendConsoleResponse("Defenses Deactivated", ConsoleMessageType.Info);
						}
						flag2 = true;
					}
				}
				if (!flag2)
				{
					ConsoleWindow3.SendConsoleResponse("No powered defenses turrets found", ConsoleMessageType.Info);
				}
				break;
			}
			case "survey":
			{
				int num = 0;
				Room[] rooms3 = DungeonManager.Instance.rooms;
				foreach (Room room3 in rooms3)
				{
					if (!room3.isExplored)
					{
						num++;
						room3.ExternallyMarkAsOnSchematic();
					}
				}
				ConsoleWindow3.SendConsoleResponse(string.Format("...found {0} rooms.", num), ConsoleMessageType.Info);
				break;
			}
			case "terminal":
				if (command.Arguments.Count > 0 && command.Arguments.First().ToLower() == "?")
				{
					Debug.LogWarning("Oops - I forgot to hook up the new, distributed terminals to this command");
				}
				else
				{
					ConsoleWindow3.SendConsoleResponse("invalid command.  Ex: terminal", ConsoleMessageType.Warning);
				}
				break;
			}
		}
		else if (command.Handled)
		{
			ConsoleWindow3.SendConsoleResponse("No activated terminals support this command...", ConsoleMessageType.Warning);
		}
	}

	public void DisplayAllAvailableTerminalCommands()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (DungeonTerminal terminal in terminalList)
		{
			if (terminal.Powered && terminal.isActivated())
			{
				if (!flag)
				{
					flag = terminal.supportsDefenseCommand;
				}
				if (!flag2)
				{
					flag2 = terminal.supportsShipScanCommand;
				}
				if (!flag3)
				{
					flag3 = terminal.supportsSurveyCommand;
				}
			}
		}
		if (flag2)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>shipscan</color> - scans nearby rooms", ConsoleMessageType.Info);
		}
		if (flag)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>defense</color> - activates/deactivates powered ship defenses", ConsoleMessageType.Info);
		}
		if (flag3)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>survey</color> - surveys ship", ConsoleMessageType.Info);
		}
		ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>interface list</color> - this list", ConsoleMessageType.Info);
	}

	public void DisplayTerminalCommands(DungeonTerminal terminal)
	{
		if (terminal.supportsShipScanCommand)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>shipscan</color> - scans nearby rooms", ConsoleMessageType.Info);
		}
		if (terminal.supportsDefenseCommand)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>defense</color> - activates/deactivates powered ship defenses", ConsoleMessageType.Info);
		}
		if (terminal.supportsSurveyCommand)
		{
			ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>survey</color> - surveys ship", ConsoleMessageType.Info);
		}
		ConsoleWindow3.SendConsoleResponse("     <color=#8ed0ff>interface list</color> - this list", ConsoleMessageType.Info);
	}

	public List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return QueryAvailableCommands();
	}
}
