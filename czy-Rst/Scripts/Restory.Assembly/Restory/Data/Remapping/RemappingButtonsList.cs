using System.Collections.Generic;
using Rewired;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Remapping
{
	[CreateAssetMenu(fileName = "RemappingButtonsInfo", menuName = "Restory/Remapping/ButtonsInfo", order = 0)]
	public class RemappingButtonsList : SerializedScriptableObject
	{
		[SerializeField]
		private Dictionary<ControllerType, List<RemappingButton>> buttons = new Dictionary<ControllerType, List<RemappingButton>>();

		public ICollection<InputAction> GetAllActions(ControllerType controllerType)
		{
			HashSet<InputAction> hashSet = new HashSet<InputAction>();
			if (buttons.TryGetValue(controllerType, out var value))
			{
				foreach (RemappingButton item in value)
				{
					hashSet.Add(item.Action);
				}
			}
			return hashSet;
		}

		public ICollection<RemappingButton> GetRemappingButtons(InputAction action, ControllerType controllerType)
		{
			HashSet<RemappingButton> hashSet = new HashSet<RemappingButton>();
			if (buttons.TryGetValue(controllerType, out var value))
			{
				foreach (RemappingButton item in value)
				{
					if (item.Action == action)
					{
						hashSet.Add(item);
					}
				}
			}
			return hashSet;
		}

		public bool TryGetRemappingButtons(ControllerType controllerType, out IReadOnlyList<RemappingButton> buttons)
		{
			if (this.buttons.TryGetValue(controllerType, out var value))
			{
				buttons = value;
				return true;
			}
			buttons = null;
			return false;
		}
	}
}
