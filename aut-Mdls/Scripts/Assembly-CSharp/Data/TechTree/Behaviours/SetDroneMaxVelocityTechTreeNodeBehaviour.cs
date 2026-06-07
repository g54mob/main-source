using Data.Variables;
using Data.Variables.Drones;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Set Drone Max Velocity", fileName = "SetDroneMaxVelocityTechTreeNodeBehaviour")]
	public class SetDroneMaxVelocityTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private DroneMaxVelocityData _droneMaxVelocityData;

		[SerializeField]
		private float _newVelocity;

		public override void Unlock()
		{
			_droneMaxVelocityData.SetValue(_newVelocity);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _droneMaxVelocityData;
			return true;
		}
	}
}
