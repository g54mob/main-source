using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ExtractorBehaviour", fileName = "ExtractorBehaviour", order = 0)]
	public class ExtractorBehaviour : FactoryObjectBehaviour
	{
		public MainThreadEvent<Resource> OnCreatedNewResource = new MainThreadEvent<Resource>();

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		private Resource _resource;

		private ConveyorBehaviour _conveyorBehaviour;

		private ResourceBehaviour _resourceBehaviour;

		private bool _hasResourceBehaviour;

		private Color _color;

		public ConveyorBehaviour ConveyorBehaviour => _conveyorBehaviour;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_conveyorBehaviour = factoryObject.GetFactoryObjectBehaviour<ConveyorBehaviour>();
			FactoryObject objectAt = _terrainLayer.GetObjectAt(_factoryObject.Position);
			if (objectAt == null)
			{
				_resourceBehaviour = null;
				_hasResourceBehaviour = false;
				return;
			}
			_resourceBehaviour = objectAt.GetFactoryObjectBehaviour<ResourceBehaviour>();
			if (_resourceBehaviour is ColorResourceBehaviour colorResourceBehaviour)
			{
				_color = colorResourceBehaviour.Color;
			}
			_hasResourceBehaviour = _resourceBehaviour != null;
		}

		public override void Process(int step)
		{
			base.Process(step);
			TryOutputResource();
		}

		public override void Update()
		{
			GenerateResource();
		}

		private void GenerateResource()
		{
			if (!_hasResourceBehaviour || _resource != null)
			{
				EndActivity();
				return;
			}
			StartActivity();
			_resource = _resourceFactory.CreateResource(_resourceBehaviour.ResourceData, _color);
		}

		private void TryOutputResource()
		{
			if (_resource != null && _conveyorBehaviour.CanReceiveResource(_resource, default(FactoryObjectData.InputData), _factoryObject.Position))
			{
				_conveyorBehaviour.AddResource(_resource);
				OnCreatedNewResource.Fire(_resource);
				_resource = null;
			}
		}
	}
}
