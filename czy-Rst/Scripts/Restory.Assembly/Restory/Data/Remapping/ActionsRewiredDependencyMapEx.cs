using System.Collections.Generic;
using Restory.Remapping;
using Rewired;
using UnityEngine;

namespace Restory.Data.Remapping
{
	public static class ActionsRewiredDependencyMapEx
	{
		public static bool GetRewiredInputButtonData(this ActionsRewiredDependencyMap dependencyMap, int playerId, ControllerType controllerType, int controllerId, InputAction action, AxisRange axisRange, out InputButtonData inputButtonData)
		{
			if (dependencyMap.GetRewiredFirstActionElementMap(playerId, controllerType, controllerId, action, axisRange, out var actionElementMap))
			{
				inputButtonData.elementIdentifierId = actionElementMap.elementIdentifierId;
				inputButtonData.keyboardKeyCode = actionElementMap.keyCode;
				return true;
			}
			inputButtonData = default(InputButtonData);
			return false;
		}

		public static bool GetRewiredFirstActionElementMap(this ActionsRewiredDependencyMap dependencyMap, int playerId, ControllerType controllerType, int controllerId, InputAction action, AxisRange axisRange, out ActionElementMap actionElementMap)
		{
			actionElementMap = null;
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return false;
			}
			if (!dependencyMap.TryGetFirstRewiredTargets(action, controllerType, out var target))
			{
				return false;
			}
			ControllerMap map = player.controllers.maps.GetMap(controllerType, controllerId, target.CategoryMapId, 0);
			if (map == null)
			{
				return false;
			}
			ActionElementMap[] elementMapsWithAction = map.GetElementMapsWithAction(target.ActionId);
			foreach (ActionElementMap actionElementMap2 in elementMapsWithAction)
			{
				if (actionElementMap2.ShowInField(axisRange))
				{
					actionElementMap = actionElementMap2;
					return true;
				}
			}
			return false;
		}

		public static List<ActionElementMap> GetRewiredActionElementMaps(this ActionsRewiredDependencyMap dependencyMap, int playerId, ControllerType controllerType, int controllerId, InputAction action, AxisRange axisRange)
		{
			List<ActionElementMap> list = new List<ActionElementMap>();
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return list;
			}
			if (!dependencyMap.TryGetAllRewiredTargets(action, controllerType, out var targets))
			{
				return list;
			}
			foreach (TargetRewiredActionElementMap item in targets)
			{
				ControllerMap map = player.controllers.maps.GetMap(controllerType, controllerId, item.CategoryMapId, 0);
				if (map == null)
				{
					continue;
				}
				ActionElementMap[] elementMapsWithAction = map.GetElementMapsWithAction(item.ActionId);
				foreach (ActionElementMap actionElementMap in elementMapsWithAction)
				{
					if (actionElementMap.ShowInField(axisRange))
					{
						list.Add(actionElementMap);
					}
				}
			}
			return list;
		}

		public static bool SetRewiredInputButtonData(this ActionsRewiredDependencyMap dependencyMap, int playerId, ControllerType controllerType, int controllerId, InputAction action, AxisRange axisRange, InputButtonData inputButtonData)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return false;
			}
			if (!dependencyMap.TryGetAllRewiredTargets(action, controllerType, out var targets))
			{
				return false;
			}
			foreach (TargetRewiredActionElementMap item in targets)
			{
				ControllerMap map = player.controllers.maps.GetMap(controllerType, controllerId, item.CategoryMapId, 0);
				if (map == null)
				{
					continue;
				}
				ActionElementMap[] elementMapsWithAction = map.GetElementMapsWithAction(item.ActionId);
				foreach (ActionElementMap actionElementMap in elementMapsWithAction)
				{
					if (actionElementMap.ShowInField(axisRange))
					{
						ElementAssignment elementAssignment = ElementAssignment.CompleteAssignment(map.controllerType, actionElementMap.elementType, inputButtonData.elementIdentifierId, actionElementMap.axisRange, inputButtonData.keyboardKeyCode, actionElementMap.modifierKeyFlags, actionElementMap.actionId, actionElementMap.axisContribution, actionElementMap.invert, actionElementMap.id);
						if (!map.ReplaceElementMap(elementAssignment))
						{
							Debug.LogError("Error Replacing ActionElementMap." + $" ActionElementMap not found and cannot be overwritten! Action: {action.Id} AxisRange: {axisRange}");
						}
					}
				}
			}
			return true;
		}

		public static bool SetRewiredInputButtonData(this ActionsRewiredDependencyMap dependencyMap, int playerId, ControllerType controllerType, int controllerId, InputAction action, AxisRange axisRange, ActionElementMap actionElementMap)
		{
			InputButtonData inputButtonData = new InputButtonData
			{
				elementIdentifierId = actionElementMap.elementIdentifierId,
				keyboardKeyCode = actionElementMap.keyCode
			};
			return dependencyMap.SetRewiredInputButtonData(playerId, controllerType, controllerId, action, axisRange, inputButtonData);
		}
	}
}
