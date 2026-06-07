using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Events.FactoryFloor;
using Logic.Shapes;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/FurnaceBehaviour", fileName = "FurnaceBehaviour", order = 0)]
	public class FurnaceBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private Color _cubeColor;

		[SerializeField]
		private int _defaultCubeSizeToCreate = 4;

		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private PolyRockResourceDataSO _polyRockResourceData;

		[SerializeField]
		private FurnaceOutputResourceEventSO _furnaceOutputResourceEvent;

		private int _voxelCountNeeded;

		private int _currentVoxelCount;

		private int _currentPolyrockCount;

		private int _currentCubeSize;

		private ShapeData _cubeShapeData;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private bool _hasCube;

		private ShapeResource _shapeResource;

		public int VoxelCountNeeded => _voxelCountNeeded;

		public int CurrentVoxelCount => _currentVoxelCount;

		public int CurrentPolyrockCount => _currentPolyrockCount;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			SetCubeSize(_defaultCubeSizeToCreate);
			OnOutputResource.RegisterInline(OnOutput);
			FurnaceBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<FurnaceBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_hasCube = behaviourSaveStateDto.HasCube;
				_currentVoxelCount = behaviourSaveStateDto.VoxelCount;
				_currentPolyrockCount = behaviourSaveStateDto.PolyRockCount;
				if (_hasCube)
				{
					_shapeResource = _resourceFactory.CreateShapeResource(_cubeShapeData);
				}
			}
		}

		public override void UnInit()
		{
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		public override void Update()
		{
			TryCreateCube();
			if (_hasCube && !IsTryingToOutput())
			{
				TryOutput(_shapeResource, 0);
			}
		}

		private void OnOutput(Resource resource, int _)
		{
			_hasCube = false;
			_furnaceOutputResourceEvent.Fire(resource);
		}

		public void SetCubeSize(int cubeSize)
		{
			_currentCubeSize = cubeSize;
			_voxelCountNeeded = _currentCubeSize * _currentCubeSize * _currentCubeSize;
			Shape shape = Shape.CreateCube(Vector3.zero, _currentCubeSize, _cubeColor);
			_cubeShapeData = _shapesDatabase.GetOrCreateShapeData(shape);
		}

		private void TryCreateCube()
		{
			if (_currentVoxelCount < _voxelCountNeeded || _hasCube)
			{
				EndActivity();
				return;
			}
			StartActivity();
			_currentVoxelCount -= _voxelCountNeeded;
			_currentPolyrockCount = 0;
			_hasCube = true;
			_shapeResource = _resourceFactory.CreateShapeResource(_cubeShapeData);
			CallCanReceiveNewResources();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			AddResourceVoxels(TakeResourceFromInputBuffer(inputData.Index));
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (inputData.AllowedResourceTypes != null && inputData.AllowedResourceTypes.Count > 0 && !inputData.AllowedResourceTypes.Contains(resource.Data))
			{
				_operatorStateBehaviour.SetStateWrongInputTypeGeneral();
				return false;
			}
			if (_currentVoxelCount < _voxelCountNeeded)
			{
				_operatorStateBehaviour.ResetState();
				return true;
			}
			return false;
		}

		private void AddResourceVoxels(Resource resource)
		{
			if (resource.Data == _polyRockResourceData)
			{
				_currentVoxelCount += _polyRockResourceData.VoxelValue;
				_currentPolyrockCount++;
			}
			if (resource is ShapeResource shapeResource)
			{
				_currentVoxelCount += shapeResource.ShapeData.OccupiedVoxels.Count;
			}
			_operatorStateBehaviour.ResetState();
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_hasCube = false;
			_currentPolyrockCount = 0;
			_currentVoxelCount = 0;
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new FurnaceBehaviourSaveStateDto
			{
				HasCube = _hasCube,
				PolyRockCount = _currentPolyrockCount,
				VoxelCount = _currentVoxelCount
			};
		}
	}
}
