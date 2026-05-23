using Data.Variables;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Update Int Variable", fileName = "UpdateIntVariableFrequencyBehaviour")]
	public class UpdateIntVariableFrequencyBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private IntVariableSO _intVariable;

		[SerializeField]
		private int _newValue;

		public override void Unlock()
		{
			_intVariable.SetValue(_newValue);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _intVariable;
			return true;
		}
	}
}
