using Data.FactoryFloor;
using Data.Operator;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Has FactoryObject Been Placed", fileName = "HasFactoryObjectBeenPlaced", order = 3)]
	public class HasFactoryObjectBeenPlacedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _targetFactoryObject;

		[SerializeField]
		private int _requiredAmount = 1;

		private bool _init;

		private bool _factoryObjectWasPlaced;

		public override bool IsValid()
		{
			if (!_init)
			{
				HandleObjectsChanged(_factoryLayer);
				_factoryLayer.OnObjectsInLayerChanged += HandleObjectsChanged;
				_init = true;
			}
			return _factoryObjectWasPlaced;
		}

		private void HandleObjectsChanged(FactoryLayer obj)
		{
			_factoryLayer.TryGetObjectsFromData(_targetFactoryObject, out var factoryObjects);
			if (factoryObjects != null && factoryObjects.Count >= _requiredAmount)
			{
				_factoryLayer.OnObjectsInLayerChanged -= HandleObjectsChanged;
				_factoryObjectWasPlaced = true;
			}
		}

		public override void Reset()
		{
			if (_factoryLayer != null)
			{
				_factoryLayer.OnObjectsInLayerChanged -= HandleObjectsChanged;
			}
			_init = false;
			_factoryObjectWasPlaced = false;
		}
	}
}
