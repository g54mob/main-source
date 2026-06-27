using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/Controllers/ControllerIdsList", fileName = "New ControllerIdsList")]
	public sealed class ControllerIdsList : ScriptableObject
	{
		[SerializeField]
		private ControllerId keypoardId;

		[SerializeField]
		private ControllerId mouseId;

		[SerializeField]
		private ControllerId defaultGamepadId;

		[SerializeField]
		private List<ControllerId> gamepadIds = new List<ControllerId>();

		private Dictionary<string, ControllerId> controllersCache;

		public ControllerId KeyboardId => keypoardId;

		public ControllerId MouseId => mouseId;

		public ControllerId DefaultGamepadId => defaultGamepadId;

		public IReadOnlyCollection<ControllerId> GamepadIds => gamepadIds;

		private void CreateCache()
		{
			if (controllersCache != null)
			{
				return;
			}
			controllersCache = new Dictionary<string, ControllerId>();
			controllersCache[keypoardId.ID] = keypoardId;
			controllersCache[mouseId.ID] = mouseId;
			foreach (ControllerId gamepadId in gamepadIds)
			{
				controllersCache[gamepadId.ID] = gamepadId;
			}
		}

		public bool TryGetControllerId(string id, out ControllerId controllerId)
		{
			if (id == null)
			{
				controllerId = null;
				return false;
			}
			CreateCache();
			return controllersCache.TryGetValue(id, out controllerId);
		}
	}
}
