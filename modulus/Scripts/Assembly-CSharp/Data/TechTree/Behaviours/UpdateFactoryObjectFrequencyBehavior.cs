using Data.Operator;
using Data.Variables;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Update FactoryObject Frequency", fileName = "UpgradeFactoryObjectBehavior")]
	public class UpdateFactoryObjectFrequencyBehavior : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private IntVariableSO _updateFrequency;

		[SerializeField]
		private int _newTotalValue;

		[SerializeField]
		private FactoryObjectUIData _factoryObjectUIData;

		public FactoryObjectUIData FactoryObjectUIData => _factoryObjectUIData;

		public int NewTotalValue => _newTotalValue;

		public override void Unlock()
		{
			_updateFrequency.SetValue(_newTotalValue);
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _updateFrequency;
			return true;
		}
	}
}
