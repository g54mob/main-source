using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HelpTextManager
{
	private const int NUMBER_OF_DUNGEONS_TO_REPEAT_COMMAND = 3;

	public static HelpTextManager Instance = null;

	private List<HelpTextTypeEnum> _activeTypes = new List<HelpTextTypeEnum>();

	private List<HelpTextTypeEnum> _typesThatShouldDisplay = new List<HelpTextTypeEnum>();

	private List<HelpTextTypeEnum> _typesThatShouldDisplayThisDungeon = new List<HelpTextTypeEnum>();

	private static bool _initializedCounts = false;

	private static Dictionary<HelpTextTypeEnum, int> _countEachTypeProcessed = new Dictionary<HelpTextTypeEnum, int>();

	private Dictionary<HelpTextTypeEnum, List<string>> _commandsExecutedPerType = new Dictionary<HelpTextTypeEnum, List<string>>();

	private List<WeakReference> _droneUiObjects = new List<WeakReference>();

	public HelpTextManager()
	{
		Instance = this;
		string thatWorksInTutorial = GameSaveFile.GetThatWorksInTutorial("NEEDSHELPTEXT", "--NO_HELP_TEXT_NEEDED_SAVED--");
		if (thatWorksInTutorial == "--NO_HELP_TEXT_NEEDED_SAVED--")
		{
			RegisterHelpTextEnum(HelpTextTypeEnum.Ration);
			RegisterHelpTextEnum(HelpTextTypeEnum.Drone);
			RegisterHelpTextEnum(HelpTextTypeEnum.ShipUpgrade);
			RegisterHelpTextEnum(HelpTextTypeEnum.Receiver);
			RegisterHelpTextEnum(HelpTextTypeEnum.PowerInlet);
			RegisterHelpTextEnum(HelpTextTypeEnum.Terminal);
			RegisterHelpTextEnum(HelpTextTypeEnum.FuelAccess);
		}
		else
		{
			try
			{
				if (!string.IsNullOrEmpty(thatWorksInTutorial))
				{
					string[] array = thatWorksInTutorial.Split(',');
					if (array.Length > 0)
					{
						string[] array2 = array;
						foreach (string s in array2)
						{
							int result;
							if (int.TryParse(s, out result))
							{
								RegisterHelpTextEnum((HelpTextTypeEnum)result);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Error reading in needed help text types: " + ex.Message);
			}
		}
		try
		{
			string thatWorksInTutorial2 = GameSaveFile.GetThatWorksInTutorial("CMD_USAGE_COUNT", string.Empty);
			if (!string.IsNullOrEmpty(thatWorksInTutorial2))
			{
				string[] array3 = thatWorksInTutorial2.Split(',');
				if (array3.Length > 0)
				{
					string[] array4 = array3;
					foreach (string text in array4)
					{
						string[] array5 = text.Split('=');
						int result2;
						int result3;
						if (array5.Length == 2 && int.TryParse(array5[0], out result2) && int.TryParse(array5[1], out result3))
						{
							_countEachTypeProcessed[(HelpTextTypeEnum)result2] = result3;
						}
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Debug.LogError("Error reading in needed help text command counts: " + ex2.Message);
		}
		_initializedCounts = true;
	}

	public static void Initialize()
	{
		if (Instance == null)
		{
			Instance = new HelpTextManager();
		}
	}

	public static void Reset()
	{
		Instance = null;
		_initializedCounts = false;
		_countEachTypeProcessed.Clear();
	}

	private void RegisterHelpTextEnum(HelpTextTypeEnum value)
	{
		_typesThatShouldDisplay.Add(value);
		_typesThatShouldDisplayThisDungeon.Add(value);
		if (!_initializedCounts)
		{
			_countEachTypeProcessed[value] = 0;
		}
	}

	public void AddDroneUiObject(DroneUIObject obj)
	{
		if (!_droneUiObjects.Any((WeakReference x) => x.Target as DroneUIObject == obj))
		{
			_droneUiObjects.Add(new WeakReference(obj));
		}
	}

	public bool IsThisTypeActive(HelpTextTypeEnum helpTextType)
	{
		return _activeTypes.Any((HelpTextTypeEnum x) => x == helpTextType);
	}

	public void FlagTypeActive(HelpTextTypeEnum helpTextType)
	{
		if (!IsThisTypeActive(helpTextType))
		{
			_activeTypes.Add(helpTextType);
		}
	}

	public void FlagTypeInactive(HelpTextTypeEnum helpTextType)
	{
		_activeTypes.Remove(helpTextType);
	}

	public bool CanMakeHelpTextActive(HelpTextTypeEnum helpTextType)
	{
		if (_activeTypes.Count == 0 && HelpTextShouldDisplay(helpTextType))
		{
			return true;
		}
		return false;
	}

	public bool HelpTextShouldDisplay(HelpTextTypeEnum helpTextType)
	{
		int count = _typesThatShouldDisplayThisDungeon.Count;
		for (int i = 0; i < count; i++)
		{
			if (_typesThatShouldDisplayThisDungeon[i] == helpTextType)
			{
				return true;
			}
		}
		return false;
	}

	public void ProcessExecutedCommand(string command)
	{
		if (_typesThatShouldDisplay.Count == 0 || _typesThatShouldDisplayThisDungeon.Count == 0)
		{
			return;
		}
		List<HelpTextTypeEnum> list = null;
		int count = _droneUiObjects.Count;
		if (count > 0)
		{
			list = new List<HelpTextTypeEnum>();
			for (int i = 0; i < count; i++)
			{
				WeakReference weakReference = _droneUiObjects[i];
				if (weakReference.Target == null)
				{
					continue;
				}
				DroneUIObject droneUIObject = (DroneUIObject)weakReference.Target;
				if (_activeTypes.Count == 0 || !_activeTypes.Contains(droneUIObject.HelpTextType) || _typesThatShouldDisplayThisDungeon.Count == 0 || !_typesThatShouldDisplayThisDungeon.Contains(droneUIObject.HelpTextType) || _typesThatShouldDisplay.Count == 0 || !_typesThatShouldDisplay.Contains(droneUIObject.HelpTextType))
				{
					continue;
				}
				List<string> value;
				if (!_commandsExecutedPerType.TryGetValue(droneUIObject.HelpTextType, out value))
				{
					value = new List<string>();
					_commandsExecutedPerType[droneUIObject.HelpTextType] = value;
				}
				if (droneUIObject.DisplayCommands.Contains(command) && !value.Contains(command))
				{
					value.Add(command);
				}
				if (droneUIObject.DisplayCommands.Count == value.Count && droneUIObject.DisplayCommands.OrderBy((string x) => x).SequenceEqual(value.OrderBy((string x) => x)) && !list.Contains(droneUIObject.HelpTextType))
				{
					if (!_countEachTypeProcessed.ContainsKey(droneUIObject.HelpTextType))
					{
						_countEachTypeProcessed[droneUIObject.HelpTextType] = 0;
					}
					Dictionary<HelpTextTypeEnum, int> countEachTypeProcessed;
					Dictionary<HelpTextTypeEnum, int> dictionary = (countEachTypeProcessed = _countEachTypeProcessed);
					HelpTextTypeEnum helpTextType;
					HelpTextTypeEnum key = (helpTextType = droneUIObject.HelpTextType);
					int num = countEachTypeProcessed[helpTextType];
					num = (dictionary[key] = num + 1);
					if (num >= 3)
					{
						_typesThatShouldDisplay.Remove(droneUIObject.HelpTextType);
						_commandsExecutedPerType.Remove(droneUIObject.HelpTextType);
						string text = string.Empty;
						foreach (HelpTextTypeEnum item in _typesThatShouldDisplay)
						{
							text = text + (int)item + ",";
						}
						text = text.TrimEnd(',');
						GameSaveFile.Save("NEEDSHELPTEXT", text);
					}
					string text2 = string.Empty;
					foreach (KeyValuePair<HelpTextTypeEnum, int> item2 in _countEachTypeProcessed)
					{
						text2 += string.Format("{0}={1},", (int)item2.Key, item2.Value);
					}
					text2 = text2.TrimEnd(',');
					GameSaveFile.Save("CMD_USAGE_COUNT", text2);
					_typesThatShouldDisplayThisDungeon.Remove(droneUIObject.HelpTextType);
				}
				if (!list.Contains(droneUIObject.HelpTextType))
				{
					list.Add(droneUIObject.HelpTextType);
				}
			}
		}
		count = _commandsExecutedPerType.Count;
		for (int num3 = 0; num3 < count; num3++)
		{
			KeyValuePair<HelpTextTypeEnum, List<string>> keyValuePair = _commandsExecutedPerType.ElementAt(num3);
			HelpTextTypeEnum key2 = keyValuePair.Key;
			List<string> value2 = keyValuePair.Value;
			int count2 = _droneUiObjects.Count;
			for (int num4 = 0; num4 < count2; num4++)
			{
				WeakReference weakReference2 = _droneUiObjects[num4];
				if (weakReference2.Target == null)
				{
					continue;
				}
				DroneUIObject droneUIObject2 = (DroneUIObject)weakReference2.Target;
				if (droneUIObject2.HelpTextType == key2)
				{
					int count3 = value2.Count;
					for (int num5 = 0; num5 < count3; num5++)
					{
						string command2 = value2[num5];
						droneUIObject2.MarkCommandAsUsed(command2);
					}
				}
			}
		}
	}

	public void ProcessInstalledDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		if (upgrade == null)
		{
			return;
		}
		HelpTextTypeEnum helpTextTypeEnum = HelpTextTypeEnum.None;
		DroneUpgradeType type = upgrade.Definition.Type;
		if (type == DroneUpgradeType.Interface)
		{
			helpTextTypeEnum = HelpTextTypeEnum.Terminal;
		}
		if (helpTextTypeEnum == HelpTextTypeEnum.None)
		{
			return;
		}
		foreach (WeakReference droneUiObject in _droneUiObjects)
		{
			if (droneUiObject.Target != null)
			{
				DroneUIObject droneUIObject = (DroneUIObject)droneUiObject.Target;
				if (droneUIObject.HelpTextType == helpTextTypeEnum)
				{
					droneUIObject.AllowHelpTextToBeShown();
				}
			}
		}
	}
}
