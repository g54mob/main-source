#define ENABLE_DEBUG_ERRORS
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using Data.Operator;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/MultiDifferentResourceExtractorBehaviour", fileName = "MultiDifferentResourceExtractorBehaviour", order = 0)]
	public class MultiDifferentResourceExtractorBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private SerializedDictionary<FactoryObjectData, ResourceDataSO> _outputResourceData;

		[SerializeField]
		private int _resourcesPerUpdate = 8;

		private ResourceDataSO _resourceData;

		private bool _hasResourceData;

		private int _currentResources;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			OilRigBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<OilRigBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_currentResources = behaviourSaveStateDto.CurrentResourcesCount;
			}
			FactoryObject objectAt = _terrainLayer.GetObjectAt(factoryObject.Position);
			if (objectAt != null)
			{
				if (_outputResourceData.TryGetValue(objectAt.FactoryObjectData, out var _))
				{
					_resourceData = _outputResourceData[objectAt.FactoryObjectData];
				}
				else
				{
					this.LogError(string.Format("{0} was placed on a \"{1}\" which shouldn't happen at {2}", "MultiDifferentResourceExtractorBehaviour", objectAt.FactoryObjectData.name, factoryObject.Position), "Init", 41);
				}
			}
			else
			{
				_resourceData = null;
			}
			_hasResourceData = _resourceData != null;
			if (_hasResourceData)
			{
				OnOutputResource.RegisterInline(OnOutput);
			}
		}

		public override void UnInit()
		{
			if (_hasResourceData)
			{
				OnOutputResource.UnRegisterInline(OnOutput);
			}
			_currentResources = 0;
			base.UnInit();
		}

		private void OnOutput(Resource resource, int i)
		{
			_currentResources--;
			TryOutputResources();
		}

		public override void Update()
		{
			GenerateResources();
			TryOutputResources();
		}

		private void GenerateResources()
		{
			if (_currentResources >= _resourcesPerUpdate)
			{
				EndActivity();
				return;
			}
			StartActivity();
			_currentResources = _resourcesPerUpdate;
		}

		private void TryOutputResources()
		{
			if (!_hasResourceData || _currentResources <= 0)
			{
				return;
			}
			for (int i = 0; i < base.FactoryObject.DataOutputPositions.Count; i++)
			{
				if (!IsTryingToOutputAtIndex(i))
				{
					Resource resource = _resourceFactory.CreateResource(_resourceData);
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
