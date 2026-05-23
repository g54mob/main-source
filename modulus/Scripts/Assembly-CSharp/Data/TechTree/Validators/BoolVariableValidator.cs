using Data.Variables;
using UnityEngine;

namespace Data.TechTree.Validators
{
	[CreateAssetMenu(menuName = "Tech Tree/Validators/Bool Variable Validator", fileName = "BoolVariableValidator")]
	public class BoolVariableValidator : AbstractTechTreeNodeValidator
	{
		[SerializeField]
		private BoolVariableSO _variable;

		public bool CompareBoolVariableSO(BoolVariableSO variable)
		{
			return _variable == variable;
		}

		public override bool CanBuy(TechTreeNodeSO node)
		{
			return _variable.Value;
		}

		public override void Buy(TechTreeNodeSO node)
		{
		}
	}
}
