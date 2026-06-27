using System;
using System.Collections.Generic;
using Rewired;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[CreateAssetMenu(menuName = "Restory/Controllers/RewiredControllerIdsDependencyMap", fileName = "New RewiredControllerIdsDependencyMap")]
	public class RewiredControllerIdsDependencyMap : SerializedScriptableObject
	{
		[SerializeField]
		private Dictionary<Guid, ControllerId> controllerIds = new Dictionary<Guid, ControllerId>();

		public bool TryGetControllerId(Controller controller, out ControllerId controllerId)
		{
			if (controller == null)
			{
				controllerId = null;
				return false;
			}
			return TryGetControllerId(controller.hardwareTypeGuid, out controllerId);
		}

		public bool TryGetControllerId(Guid hardwareTypeGuid, out ControllerId controllerId)
		{
			return controllerIds.TryGetValue(hardwareTypeGuid, out controllerId);
		}
	}
}
