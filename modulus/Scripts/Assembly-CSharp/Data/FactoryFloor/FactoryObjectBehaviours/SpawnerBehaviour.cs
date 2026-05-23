using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags.Validators;
using Data.Operator;
using Data.Variables;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/Spawner", fileName = "SpawnerBehaviour", order = 0)]
	public class SpawnerBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private List<ResourceDataSO> _resourceDatas;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ResourceDataSO _defaultResourceData;

		[SerializeField]
		private FeatureFlagValidator _enableDevelopmentValidator;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		private readonly List<ResourceDataSO> _devResourceDatas = new List<ResourceDataSO>();

		private Resource _resource;

		private int _chosenResourceDataIndex;

		private bool _playAnimation = true;

		private bool _alreadyPlayedAnimationThisUpdate;

		public MainThreadEvent<Resource> OnChangeResource = new MainThreadEvent<Resource>();

		public ResourceDataSO ChosenResourceData => _resourceDatabase.GetResourceDataFromID(_chosenResourceDataIndex);

		public int ChosenResourceDataIndex => _chosenResourceDataIndex;

		public Resource Resource => _resource;

		public IReadOnlyList<ResourceDataSO> GetResourceDatas()
		{
			if (_zenModeSO.Value || !_enableDevelopmentValidator.IsEnabledFeatureFlag())
			{
				return _resourceDatas;
			}
			return _devResourceDatas;
		}

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void PlayAnimation(Resource _, int __)
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
			throw new NotIncludedInDemoException();
		}

		private void GetChosenResource()
		{
			throw new NotIncludedInDemoException();
		}

		private void TryOutput()
		{
			throw new NotIncludedInDemoException();
		}

		private Resource GetCopyResource(Resource resource)
		{
			throw new NotIncludedInDemoException();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return true;
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public void SetChosenResourceIndex(int index)
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			throw new NotIncludedInDemoException();
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			throw new NotIncludedInDemoException();
		}
	}
}
