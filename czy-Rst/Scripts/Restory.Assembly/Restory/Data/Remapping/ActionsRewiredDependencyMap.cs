using System;
using System.Collections.Generic;
using Rewired;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Remapping
{
	[CreateAssetMenu(fileName = "ActionsDependencyMap", menuName = "Restory/Remapping/ActionsDependencyMap", order = 0)]
	public class ActionsRewiredDependencyMap : SerializedScriptableObject
	{
		[Serializable]
		private class ActionsList : Dictionary<InputAction, TargetsList>
		{
			private Dictionary<string, TargetsList> cache;

			public void CacheIds()
			{
				cache = new Dictionary<string, TargetsList>();
				foreach (InputAction key in base.Keys)
				{
					cache[key.Id] = base[key];
				}
			}

			public bool TryGetValue(string id, out TargetsList value)
			{
				if (cache == null)
				{
					CacheIds();
				}
				return cache.TryGetValue(id, out value);
			}
		}

		[Serializable]
		private class TargetsList : List<TargetRewiredActionElementMap>
		{
		}

		[SerializeField]
		private Dictionary<ControllerType, ActionsList> dependencies = new Dictionary<ControllerType, ActionsList>();

		public bool TryGetFirstRewiredTargets(InputAction actionId, ControllerType controllerType, out TargetRewiredActionElementMap target)
		{
			if (TryGetAllRewiredTargets(actionId, controllerType, out var targets) && targets.Count > 0)
			{
				target = targets[0];
				return true;
			}
			target = default(TargetRewiredActionElementMap);
			return false;
		}

		public bool TryGetAllRewiredTargets(InputAction actionId, ControllerType controllerType, out IReadOnlyList<TargetRewiredActionElementMap> targets)
		{
			if (dependencies.TryGetValue(controllerType, out var value) && value.TryGetValue(actionId.Id, out var value2))
			{
				targets = value2;
				return true;
			}
			targets = null;
			return false;
		}
	}
}
