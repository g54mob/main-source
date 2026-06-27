using Rewired;
using UnityEngine;

namespace Restory.Gameplay.GameSettings
{
	public class ActiveControllerTypeManager : MonoBehaviour
	{
		[SerializeField]
		private ControllerType controllerType;

		public ControllerType ActiveController => controllerType;

		public void SetActiveController(ControllerType newControllerType)
		{
			controllerType = newControllerType;
		}
	}
}
