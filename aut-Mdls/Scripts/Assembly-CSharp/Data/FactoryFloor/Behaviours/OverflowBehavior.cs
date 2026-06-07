using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/OverflowBehaviour", fileName = "OverflowBehaviour", order = 0)]
	public class OverflowBehavior : SplitterBehaviorAbstract
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		private int _currentOutputIndex = -1;

		public MainThreadEvent<bool> OnMainOutputFreeUpdated = new MainThreadEvent<bool>();

		private int _blockOverflowForXUpdates;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void UpdateMainOutputFree(Resource resource, int outputIndex)
		{
			throw new NotIncludedInDemoException();
		}

		protected override void TryOutputShapeInternal()
		{
			throw new NotIncludedInDemoException();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			throw new NotIncludedInDemoException();
		}

		public override void Process(int step)
		{
			if (_blockOverflowForXUpdates <= 0 && IsTryingToOutputAtIndex(0))
			{
				TryOutputResourceToIndex(1);
				StopTryingToOutputAtIndex(1);
			}
			base.Process(step);
		}

		public override void Update()
		{
			base.Update();
			_blockOverflowForXUpdates--;
		}

		public override void HandleOutputResource(Resource resource, int outputIndex)
		{
			if (outputIndex == 0)
			{
				_blockOverflowForXUpdates = 2;
			}
			base.HandleOutputResource(resource, outputIndex);
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}
	}
}
