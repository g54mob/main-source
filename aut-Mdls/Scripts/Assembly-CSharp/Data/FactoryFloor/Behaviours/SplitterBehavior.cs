using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SplitterBehaviour", fileName = "SplitterBehaviour", order = 0)]
	public class SplitterBehavior : SplitterBehaviorAbstract
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		private bool _isRight;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			SplitterBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<SplitterBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_isRight = behaviourSaveStateDto.IsRight;
				ApplyInputBufferSaveData(behaviourSaveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
			}
			OnOutputResource.RegisterInline(OutputResource);
		}

		public override void UnInit()
		{
			OnOutputResource.UnRegisterInline(OutputResource);
			base.UnInit();
		}

		private void OutputResource(Resource resource, int outputIndex)
		{
			_isRight = outputIndex == 1;
		}

		protected override void TryOutputShapeInternal()
		{
			int index = ((!_isRight) ? 1 : 0);
			if (!TryOutputResourceToIndex(index))
			{
				index = (_isRight ? 1 : 0);
				TryOutputResourceToIndex(index);
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new SplitterBehaviourSaveStateDto
			{
				IsRight = _isRight,
				InputBufferSaveData = GetInputBufferSaveData()
			};
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!IsTryingToOutputAtIndex(0) || !IsTryingToOutputAtIndex(1))
			{
				TryOutputShapeInternal();
			}
			return base.CanReceiveResource(resource, inputData, position);
		}
	}
}
