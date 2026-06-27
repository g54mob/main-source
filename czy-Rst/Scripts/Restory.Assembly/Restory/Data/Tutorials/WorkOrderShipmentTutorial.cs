using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/WorkOrderShipment", fileName = "Tutorial - 00 - WorkOrderShipment", order = 0)]
	public class WorkOrderShipmentTutorial : TutorialBase
	{
		[SerializeField]
		private WorkOrderShipmentTutorialSettings settings;

		public WorkOrderShipmentTutorialSettings Settings => settings;
	}
}
