using Data.Variables;
using Data.Variables.Drones;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Set Drone Max Amount Per HarvesterPad", fileName = "SetDroneMaxAmountPerHarvesterPadTechTreeNodeBehaviour")]
	public class SetDroneMaxAmountPerHarvesterPadTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private DroneMaxAmountPerHarvesterPadData _droneMaxAmountPerHarvesterPadData;

		[SerializeField]
		private int _newAmount;

		public override void Unlock()
		{
			_droneMaxAmountPerHarvesterPadData.SetValue(_newAmount);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _droneMaxAmountPerHarvesterPadData;
			return true;
		}
	}
}
