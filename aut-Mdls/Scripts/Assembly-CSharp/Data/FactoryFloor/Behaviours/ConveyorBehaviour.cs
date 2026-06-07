using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ConveyorBehaviour", fileName = "ConveyorBehaviour", order = 0)]
	public class ConveyorBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private bool _canRecieveResource = true;

		public MainThreadEvent<Resource, bool> OnResourceRemoved = new MainThreadEvent<Resource, bool>();

		private bool _callCanReceiveOnNextUpdate;

		private bool _receivedResourceThisTick;

		public Resource Resource => GetResourceInInputBuffer();

		public bool CanReceiveResourceOverride
		{
			get
			{
				return _canRecieveResource;
			}
			set
			{
				_canRecieveResource = value;
			}
		}

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			SetShouldClearInputBufferOnOutput();
			UpdateOutput();
			ConveyorBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<ConveyorBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ShapeHashPair hash = (string.IsNullOrEmpty(behaviourSaveStateDto.Hash) ? default(ShapeHashPair) : ShapeHashPair.Parse(behaviourSaveStateDto.Hash));
				ResourceDataSO resourceDataFromID = _resourceDatabase.GetResourceDataFromID(behaviourSaveStateDto.ResourceDataID);
				Resource resource = _resourceFactory.CreateResource(resourceDataFromID, behaviourSaveStateDto.Color, hash);
				if (resource != null)
				{
					AddResource(resource);
				}
			}
		}

		public override void Process(int step)
		{
			base.Process(step);
			_receivedResourceThisTick = false;
		}

		public override void Update()
		{
			if (_callCanReceiveOnNextUpdate)
			{
				CallCanReceiveNewResources();
				_callCanReceiveOnNextUpdate = false;
			}
			if (!IsTryingToOutput() && IsInputBufferFull() && !_receivedResourceThisTick)
			{
				TryOutput(GetResourceInInputBuffer(), 0);
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (_canRecieveResource)
			{
				return base.CanReceiveResource(resource, inputData, position);
			}
			return false;
		}

		public override void ClearResources()
		{
			OnResourceRemoved.Fire(null, dataB: true);
			base.ClearResources();
		}

		public override void RemoveResource(Resource resource)
		{
			OnResourceRemoved.Fire(resource, dataB: true);
			ClearInputBuffers();
		}

		public void RemoveResourceWithoutCallingClearBuffers(Resource resource, bool returnResource)
		{
			OnResourceRemoved.Fire(resource, returnResource);
			ClearInputBuffers(callInputFreedEvents: false);
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			_receivedResourceThisTick = true;
		}

		public bool HasResource()
		{
			return IsInputBufferFull();
		}

		public void CallCanReceiveNewResourcesOnUpdate()
		{
			_callCanReceiveOnNextUpdate = true;
		}

		public override string ToString()
		{
			if (!_initialized)
			{
				return base.ToString();
			}
			return $"Has Resource: {HasResource()}";
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			if (!HasResource())
			{
				return null;
			}
			Resource resource = Resource;
			return new ConveyorBehaviourSaveStateDto
			{
				ResourceDataID = resource.Data.ID,
				Hash = ((resource is ShapeResource shapeResource && shapeResource.ShapeData != null) ? shapeResource.ShapeData.GetShapeHash().ToString() : string.Empty),
				Color = ((resource is IColorResource colorResource) ? colorResource.GetColor() : Color.white)
			};
		}
	}
}
