#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/InputTunnelBehaviour", fileName = "InputTunnelBehaviour", order = 0)]
public class InputTunnelBehavior : ResourceHolderBehaviour
{
	private struct ResourceInTunnel
	{
		public Resource Resouce;

		public uint ExitOnUpdate;

		public ResourceInTunnel(Resource resource, uint exitOnUpdate)
		{
			Resouce = resource;
			ExitOnUpdate = exitOnUpdate;
		}
	}

	[SerializeField]
	private ResourceFactory _resourceFactory;

	[SerializeField]
	private ResourceDatabaseSO _resourceDatabase;

	private uint _currentUpdate;

	private int _tunnelDistance = 1;

	private readonly Queue<ResourceInTunnel> _resources = new Queue<ResourceInTunnel>();

	private OutputTunnelBehavior _outputTunnelBehavior;

	private bool _hasOutputTunnelBehaviour;

	private Resource _outputResource;

	private int ResourcesCount => _resources.Count + ((_outputResource != null) ? 1 : 0);

	public int TunnelDistance => _tunnelDistance;

	public override void Init(FactoryObject factoryObject)
	{
		base.Init(factoryObject);
		factoryObject.OnObjectLinked += GetOutTunnel;
		OnOutputResource.RegisterInline(OnOutput);
	}

	public override void UnInit()
	{
		if (_factoryObject != null)
		{
			_factoryObject.OnObjectLinked -= GetOutTunnel;
		}
		OnOutputResource.UnRegisterInline(OnOutput);
		base.UnInit();
	}

	private void GetOutTunnel(FactoryObject linkObject)
	{
		FactoryObject factoryObject = _factoryObject.HardLinkedObjects[0];
		factoryObject.HardLink(_factoryObject);
		_hasOutputTunnelBehaviour = factoryObject.TryGetFactoryObjectBehaviour<OutputTunnelBehavior>(out _outputTunnelBehavior);
		_tunnelDistance = Mathf.RoundToInt((_factoryObject.Position - factoryObject.Position).magnitude) + 1;
		_resources.Clear();
		TunnelBehaviourSaveStateDto behaviourSaveStateDto = _factoryObject.GetBehaviourSaveStateDto<TunnelBehaviourSaveStateDto>();
		if (behaviourSaveStateDto != null)
		{
			_outputResource = ResourceDto.ToResource(behaviourSaveStateDto.OutputResource, _resourceFactory, _resourceDatabase);
			_currentUpdate = behaviourSaveStateDto.CurrentUpdate;
			for (int i = 0; i < behaviourSaveStateDto.Resources.Count; i++)
			{
				Resource resource = behaviourSaveStateDto.Resources[i].ToResource(_resourceFactory, _resourceDatabase);
				_resources.Enqueue(new ResourceInTunnel(resource, behaviourSaveStateDto.ExitOnUpdates[i]));
			}
		}
	}

	private void OnOutput(Resource resource, int __)
	{
		if (!_hasOutputTunnelBehaviour)
		{
			this.LogError("Can't handle state without being linked to an OutputTunnelBehavior", "OnOutput", 82);
			return;
		}
		_outputTunnelBehavior.AddResource(resource);
		_outputResource = null;
		CallCanReceiveNewResources();
	}

	public override void Update()
	{
		UpdateOutputResource();
		TryPassResource();
	}

	public override void AddResource(Resource resource, FactoryObjectData.InputData inputData)
	{
		_resources.Enqueue(new ResourceInTunnel(resource, _currentUpdate + (uint)_tunnelDistance));
		CallCanReceiveNewResources();
	}

	public override void RemoveResource(Resource resource)
	{
		_resources.Dequeue();
	}

	public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData, Vector3Int position = default(Vector3Int))
	{
		return ResourcesCount < _tunnelDistance;
	}

	private void UpdateOutputResource()
	{
		if (_resources.Count == 0 || _outputResource != null)
		{
			_currentUpdate++;
			return;
		}
		ResourceInTunnel resourceInTunnel = _resources.Peek();
		if (++_currentUpdate >= resourceInTunnel.ExitOnUpdate)
		{
			_resources.Dequeue();
			_outputResource = resourceInTunnel.Resouce;
		}
	}

	private void TryPassResource()
	{
		if (_outputResource != null)
		{
			TryOutputToOutputTunnel();
		}
	}

	private void TryOutputToOutputTunnel()
	{
		if (!_hasOutputTunnelBehaviour)
		{
			this.LogError("Can't output without being linked to an OutputTunnelBehavior", "TryOutputToOutputTunnel", 142);
		}
		else if (_outputTunnelBehavior.CanReceiveResource(_outputResource))
		{
			_outputTunnelBehavior.AddResource(_outputResource);
			_outputResource = null;
			CallCanReceiveNewResources();
		}
	}

	public override void ClearResources()
	{
		base.ClearResources();
		_resources.Clear();
		_outputResource = null;
	}

	public override BehaviourSaveStateDto GetSaveState()
	{
		List<ResourceDto> list = new List<ResourceDto>();
		List<uint> list2 = new List<uint>();
		foreach (ResourceInTunnel resource in _resources)
		{
			list.Add(new ResourceDto(resource.Resouce));
			list2.Add(resource.ExitOnUpdate);
		}
		return new TunnelBehaviourSaveStateDto
		{
			OutputResource = new ResourceDto(_outputResource),
			Resources = list,
			ExitOnUpdates = list2,
			CurrentUpdate = _currentUpdate
		};
	}
}
