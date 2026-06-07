using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags.Validators;
using Data.Operator;
using Data.Shapes;
using SaveData.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ModuleSpawner", fileName = "ModuleSpawnerBehaviour", order = 0)]
	public class ModuleSpawnerBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private BuildingObjectDatabase _buildingObjectDatabase;

		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSO;

		[SerializeField]
		private FeatureFlagValidator _enableDevelopmentValidator;

		private readonly List<ShapeData> _shapeDatas = new List<ShapeData>();

		private Resource _resource;

		private int _chosenShapeDataIndex;

		private bool _playAnimation = true;

		private bool _alreadyPlayedAnimationThisUpdate;

		private ShapeData _shapeData;

		public Resource Resource => _resource;

		public int ChosenIndex => _chosenShapeDataIndex;

		public ShapeData ChosenShapeData => _shapeDatas[_chosenShapeDataIndex];

		public IReadOnlyList<ShapeData> ShapeDatas => _shapeDatas;

		public event Action<Resource> OnChangeResource = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void PopulateShapeDataList()
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
