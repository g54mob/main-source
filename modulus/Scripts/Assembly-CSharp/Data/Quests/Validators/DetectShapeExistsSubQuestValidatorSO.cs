using Data.FactoryFloor.Resources;
using Data.Shapes;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Shape Exists", fileName = "DetectShapeExists", order = 6)]
	public class DetectShapeExistsSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private ShapeDataSO _shapeData;

		private bool _init;

		private bool _resourceGotCreated;

		private RotationIndependentHash _shapeHash;

		public override bool IsValid()
		{
			if (!_init)
			{
				_init = true;
				_resourceGotCreated = false;
				_resourceCreatedEvent.RegisterMainThread(OnResourceCreated);
				_shapeHash = _shapeData.Data.RotationIndependantHash;
			}
			return _resourceGotCreated;
		}

		private void OnResourceCreated(Resource createdResource)
		{
			if (createdResource is ShapeResource shapeResource)
			{
				ShapeHashPair? shapeHashPair = shapeResource.ShapeData.GetShapeHash();
				bool num = _shapeHash.Rotations == null || _shapeHash.ContainsShape(shapeHashPair.Value);
				bool flag = _shapeHash.Contains(shapeHashPair.Value);
				if (num && flag)
				{
					_resourceGotCreated = true;
				}
			}
		}

		public override void Reset()
		{
			_init = false;
			_resourceGotCreated = false;
			_resourceCreatedEvent.UnRegisterMainThread(OnResourceCreated);
		}
	}
}
