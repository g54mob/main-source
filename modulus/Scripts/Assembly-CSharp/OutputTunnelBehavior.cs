using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/OutputTunnelBehaviour", fileName = "OutputTunnelBehaviour", order = 0)]
public class OutputTunnelBehavior : ResourceHolderBehaviour
{
	[SerializeField]
	private ResourceFactory _resourceFactory;

	[SerializeField]
	private ResourceDatabaseSO _resourceDatabase;

	public override void Init(FactoryObject factoryObject)
	{
		factoryObject.DataInputPositions.Add(default(FactoryObjectData.InputData));
		base.Init(factoryObject);
		factoryObject.DataInputPositions.RemoveAt(factoryObject.DataInputPositions.Count - 1);
		OutputTunnelBehaviorSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<OutputTunnelBehaviorSaveStateDto>();
		if (behaviourSaveStateDto != null && behaviourSaveStateDto.InputBufferSaveData != null)
		{
			ApplyInputBufferSaveData(behaviourSaveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
		}
	}

	public override void Update()
	{
	}

	public override void Process(int step)
	{
		TryOutput();
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
		return new OutputTunnelBehaviorSaveStateDto
		{
			InputBufferSaveData = GetInputBufferSaveData()
		};
	}
}
