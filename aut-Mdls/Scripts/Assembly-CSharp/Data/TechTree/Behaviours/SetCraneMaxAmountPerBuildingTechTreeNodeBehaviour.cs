using Data.Variables;
using Data.Variables.Cranes;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Set Crane Max Amount Per Building", fileName = "SetCraneMaxAmountPerBuildingTechTreeNodeBehaviour")]
	public class SetCraneMaxAmountPerBuildingTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private CraneMaxAmountPerBuilding _craneMaxAmountPerBuilding;

		[SerializeField]
		private int _newMaxAmount;

		public override void Unlock()
		{
			_craneMaxAmountPerBuilding.SetValue(_newMaxAmount);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _craneMaxAmountPerBuilding;
			return true;
		}
	}
}
