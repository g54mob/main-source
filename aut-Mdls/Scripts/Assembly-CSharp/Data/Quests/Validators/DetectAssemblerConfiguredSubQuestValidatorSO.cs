using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Shapes;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Assembler Configured ShapeData", fileName = "DetectAssemblerConfiguredShapeData", order = 16)]
	public class DetectAssemblerConfiguredSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private Vector3Int _position;

		[SerializeField]
		private ShapeDataSO _requiredShape;

		private AssemblerBehaviour _assemblerBehaviour;

		public override bool IsValid()
		{
			if (_assemblerBehaviour == null)
			{
				_assemblerBehaviour = _factoryLayer.GetObjectAt(_position)?.GetFactoryObjectBehaviour<AssemblerBehaviour>();
			}
			if (_assemblerBehaviour != null && _assemblerBehaviour.IsConfigured)
			{
				return _requiredShape.Data.RotationIndependantHash.Contains(_assemblerBehaviour.OutCombinedShape.ShapeData.GetShapeHash());
			}
			return false;
		}

		public override void Reset()
		{
			_assemblerBehaviour = null;
		}
	}
}
