using System.Collections.Generic;
using System.IO;
using Rewired;
using UnityEngine;

public static class ControlConfigSaveLoad
{
	private static string SavePath => Application.persistentDataPath + "/ControlsConfig_v2.json";

	public static void SaveControlConfigToJson()
	{
		try
		{
			Player player = ReInput.players.GetPlayer(0);
			ControlConfig controlConfig = new ControlConfig();
			controlConfig.Initialize(new List<ControllerMap>(player.controllers.maps.GetAllMaps()));
			string contents = JsonUtility.ToJson(controlConfig);
			File.WriteAllText(SavePath, contents);
			Debug.Log("Control Config successfully saved.");
		}
		catch
		{
			Debug.LogError("There has been an error while trying to save the control config.");
		}
	}

	public static void LoadControlConfigFromJson()
	{
		try
		{
			if (!File.Exists(SavePath))
			{
				return;
			}
			ControlConfig controlConfig = JsonUtility.FromJson<ControlConfig>(File.ReadAllText(SavePath));
			Player player = ReInput.players.GetPlayer(0);
			List<int> allKnownActionIDs = GetAllKnownActionIDs();
			foreach (ControlConfig.ControllerData item in controlConfig.controllerDataSet)
			{
				Controller controller = ReInput.controllers.GetController(item.controllerType, item.controllerId);
				if (controller != null)
				{
					try
					{
						ControllerMap controllerMap = ControllerMap.CreateFromJson(controller.type, item.jsonMap);
						AddDefaultMappingsForNewActions(controller.identifier, controllerMap, item.knownActionIds, allKnownActionIDs);
						player.controllers.maps.AddMap(controller, controllerMap);
					}
					catch
					{
						Debug.LogError("There was an error when trying to load a control map");
					}
				}
			}
			Debug.Log("Controls Config loaded.");
		}
		catch
		{
			Debug.Log("There has been an error while trying to load the control config.");
		}
	}

	public static List<int> GetAllKnownActionIDs()
	{
		if (!ReInput.isReady)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		IList<InputAction> actions = ReInput.mapping.Actions;
		for (int i = 0; i < actions.Count; i++)
		{
			list.Add(actions[i].id);
		}
		return list;
	}

	private static void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds, List<int> allActionIds)
	{
		if (controllerMap == null || knownActionIds == null || knownActionIds == null || knownActionIds.Count == 0)
		{
			return;
		}
		ControllerMap controllerMapInstance = ReInput.mapping.GetControllerMapInstance(controllerIdentifier, controllerMap.categoryId, controllerMap.layoutId);
		if (controllerMapInstance == null)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int allActionId in allActionIds)
		{
			if (!knownActionIds.Contains(allActionId))
			{
				list.Add(allActionId);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		foreach (ActionElementMap allMap in controllerMapInstance.AllMaps)
		{
			if (list.Contains(allMap.actionId) && !controllerMap.DoesElementAssignmentConflict(allMap))
			{
				ElementAssignment elementAssignment = new ElementAssignment(controllerMap.controllerType, allMap.elementType, allMap.elementIdentifierId, allMap.axisRange, allMap.keyCode, allMap.modifierKeyFlags, allMap.actionId, allMap.axisContribution, allMap.invert);
				controllerMap.CreateElementMap(elementAssignment);
			}
		}
	}
}
