using System;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SkylineOutBehaviour", fileName = "SkylineOutBehaviour", order = 0)]
	public class SkylineOutBehaviour : ResourceHolderBehaviour
	{
		public Action<int> OnSkylineInFound = delegate
		{
		};

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		public override void Init(FactoryObject factoryObject)
		{
			factoryObject.DataInputPositions.Add(default(FactoryObjectData.InputData));
			base.Init(factoryObject);
			factoryObject.DataInputPositions.RemoveAt(factoryObject.DataInputPositions.Count - 1);
			SkylineOutBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<SkylineOutBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null && behaviourSaveStateDto.InputBufferSaveData != null)
			{
				ApplyInputBufferSaveData(behaviourSaveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
			}
			if (_factoryObject.IsLinked && _factoryObject.HardLinkedObjects[0].TryGetFactoryObjectBehaviour<SkylineInBehaviour>(out var behaviour) && behaviour.Initialized)
			{
				behaviour.SetSkylineOut(this);
			}
		}

		public override void Update()
		{
		}

		public override void Process(int step)
		{
			lock (this)
			{
				TryOutput();
			}
		}

		private void TryOutput()
		{
			if (IsInputBufferFull() && HasOutputResourceHolder(0) && !IsTryingToOutputAtIndex(0))
			{
				TryOutput(TakeResourceFromInputBuffer(0), 0);
				EndActivity();
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			StartActivity();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return base.CanReceiveResource(resource, inputData, position);
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new SkylineOutBehaviourSaveStateDto
			{
				InputBufferSaveData = GetInputBufferSaveData()
			};
		}
	}
}
