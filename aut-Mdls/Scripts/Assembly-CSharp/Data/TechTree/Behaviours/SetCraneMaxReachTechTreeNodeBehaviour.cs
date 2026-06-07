using Data.Variables;
using Data.Variables.Cranes;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Set Crane Max Reach", fileName = "SetCraneMaxReachTechTreeNodeBehaviour")]
	public class SetCraneMaxReachTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private CraneMaxReach _craneMaxReach;

		[SerializeField]
		private int _newMaxReach;

		public override void Unlock()
		{
			_craneMaxReach.SetValue(_newMaxReach);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _craneMaxReach;
			return true;
		}
	}
}
