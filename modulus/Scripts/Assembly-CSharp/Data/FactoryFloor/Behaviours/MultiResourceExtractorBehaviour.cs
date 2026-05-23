using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/MultiResourceExtractorBehaviour", fileName = "MultiResourceExtractorBehaviour", order = 0)]
	public class MultiResourceExtractorBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDataSO _outputResourceData;

		[SerializeField]
		private FactoryObjectData _outputFactoryObjectData;

		[SerializeField]
		private int _resourcesPerUpdate = 8;

		private int _currentResources;

		private bool _isOnOutputResource;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			OilRigBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<OilRigBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_currentResources = behaviourSaveStateDto.CurrentResourcesCount;
			}
			FactoryObject objectAt = _terrainLayer.GetObjectAt(factoryObject.Position);
			_isOnOutputResource = objectAt != null && objectAt.FactoryObjectData == _outputFactoryObjectData;
			if (_isOnOutputResource)
			{
				OnOutputResource.RegisterInline(OnOutput);
			}
		}

		public override void UnInit()
		{
			if (_isOnOutputResource)
			{
				OnOutputResource.UnRegisterInline(OnOutput);
			}
			_currentResources = 0;
			base.UnInit();
		}

		private void OnOutput(Resource resource, int i)
		{
			_currentResources--;
		}

		public override void Update()
		{
			GenerateResources();
			TryOutputResources();
		}

		private void GenerateResources()
		{
			for (int i = 0; i < _currentResources; i++)
			{
				EndActivity();
			}
			if (_isOnOutputResource && _currentResources < _resourcesPerUpdate)
			{
				StartActivity();
				_currentResources = _resourcesPerUpdate;
			}
		}

		private void TryOutputResources()
		{
			if (!_isOnOutputResource || _currentResources <= 0)
			{
				return;
			}
			for (int i = 0; i < base.FactoryObject.DataOutputPositions.Count; i++)
			{
				if (!IsTryingToOutputAtIndex(i))
				{
					Resource resource = _resourceFactory.CreateResource(_outputResourceData);
					TryOutput(resource, i);
				}
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new OilRigBehaviourSaveStateDto
			{
				CurrentResourcesCount = _currentResources
			};
		}
	}
}
