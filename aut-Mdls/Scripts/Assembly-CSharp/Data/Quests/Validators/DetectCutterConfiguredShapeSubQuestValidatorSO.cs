using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Shapes;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Cutter Configured ShapeData", fileName = "DetectCutterConfiguredShapeData", order = 17)]
	public class DetectCutterConfiguredShapeSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private Vector3Int _position;

		[SerializeField]
		private ShapeDataSO _requiredShape;

		private CutterBehaviour _cutterBehaviour;

		public override bool IsValid()
		{
			if (_cutterBehaviour == null)
			{
				_cutterBehaviour = _factoryLayer.GetObjectAt(_position)?.GetFactoryObjectBehaviour<CutterBehaviour>();
			}
			bool flag = _cutterBehaviour.ShapeToCut != null && _cutterBehaviour.ShapeToCut.GetShapeHash() == _requiredShape.GetShapeHash();
			return _cutterBehaviour != null && _cutterBehaviour.IsConfigured && flag;
		}

		public override void Reset()
		{
			_cutterBehaviour = null;
		}
	}
}
