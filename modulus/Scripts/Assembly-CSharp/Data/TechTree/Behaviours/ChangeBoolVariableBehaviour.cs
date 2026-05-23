using Data.Variables;
using NaughtyAttributes;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Change Bool Variable Behaviour", fileName = "ChangeBoolVariableBehaviour")]
	public class ChangeBoolVariableBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private BoolVariableSO _boolVariable;

		[SerializeField]
		private bool _setTo;

		[Button(null, EButtonEnableMode.Always)]
		public override void Unlock()
		{
			_boolVariable.SetValue(_setTo);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _boolVariable;
			return true;
		}
	}
}
