#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/AssemblerBehaviour", fileName = "AssemblerBehaviour", order = 0)]
	public class AssemblerBehaviour : SupplyTankRecipientBehaviour
	{
		public class ConfiguredAssemblerShape
		{
			public ShapeData Data;

			public Vector3 Position;

			public Vector3Int Rotation;
		}

		[Header("Assembler")]
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private int _outputShapeMaxBound = 8;

		[SerializeField]
		private int _inputShapeMaxBound = 8;

		private bool _isConfigured;

		private List<ConfiguredAssemblerShape> _configuredShapes = new List<ConfiguredAssemblerShape>();

		private ShapeResource _outCombinedShape;

		private bool _hasAssembledShape;

		private bool _newColoredInputShapes;

		private AssemblerOutputCache _outputCache;

		private Dictionary<int, int> _configuredShapeToInputBuffer = new Dictionary<int, int>();

		public MainThreadEvent OnCurrentResourcesUpdated = new MainThreadEvent();

		public bool IsConfigured => _isConfigured;

		public IReadOnlyList<ConfiguredAssemblerShape> ConfiguredShapes => _configuredShapes;

		public ShapeResource OutCombinedShape => _outCombinedShape;

		public int OutputShapeMaxBound => _outputShapeMaxBound;

		public int InputShapeMaxBound => _inputShapeMaxBound;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			AssemblerBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<AssemblerBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			AssemblerBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<AssemblerBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
				if (AnyInputBufferIsFull() && !_isConfigured)
				{
					_operatorStateBehaviour.SetStateNeedsConfiguration();
				}
			}
			OnOutputResource.RegisterInline(OnOutput);
		}

		public override void UnInit()
		{
			OnOutputResource.UnRegisterInline(OnOutput);
			_isConfigured = false;
			_outCombinedShape = null;
			_configuredShapes.Clear();
			_configuredShapeToInputBuffer.Clear();
			_newColoredInputShapes = false;
			base.UnInit();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			_hasAssembledShape = false;
		}

		public override void OperatorUpdate()
		{
			bool flag = AllNecessaryInputsFull();
			if (!_isConfigured || !flag || IsTryingToOutput())
			{
				EndActivity();
				if (!flag)
				{
					CallCanReceiveNewResources();
				}
				return;
			}
			if (_newColoredInputShapes && !_hasAssembledShape)
			{
				StartActivity();
				TryAssembleShapeNewColors();
				_hasAssembledShape = true;
				_newColoredInputShapes = false;
				_configuredShapeToInputBuffer.Clear();
				ClearInputBuffers();
				base.OperatorUpdate();
			}
			if (!_hasAssembledShape)
			{
				StartActivity();
				TryAssembleShape();
				_hasAssembledShape = true;
				_configuredShapeToInputBuffer.Clear();
				ClearInputBuffers();
				base.OperatorUpdate();
			}
			TryOutputAssembledShape();
		}

		private void TryAssembleShape()
		{
			List<ConfiguredAssemblerShape> list = new List<ConfiguredAssemblerShape>(_configuredShapes);
			for (int i = 0; i < _configuredShapes.Count; i++)
			{
				if (_configuredShapes[i] != null)
				{
					list[i] = new ConfiguredAssemblerShape
					{
						Data = _configuredShapes[i].Data,
						Position = _configuredShapes[i].Position,
						Rotation = _configuredShapes[i].Rotation
					};
				}
			}
			_configuredShapes = list;
			_outCombinedShape = _resourceFactory.CreateShapeResource(_outputCache.GetOrCreateAssemblerOutput(list));
		}

		private void TryAssembleShapeNewColors()
		{
			List<ConfiguredAssemblerShape> list = new List<ConfiguredAssemblerShape>(_configuredShapes);
			for (int i = 0; i < _configuredShapes.Count; i++)
			{
				if (_configuredShapes[i] != null && _configuredShapeToInputBuffer.TryGetValue(i, out var value))
				{
					ShapeData shapeData = (GetResourceInInputBuffer(value) as ShapeResource).ShapeData;
					ShapeData shapeInDesiredRotation = GetShapeInDesiredRotation(shapeData, _configuredShapes[i].Data);
					list[i] = new ConfiguredAssemblerShape
					{
						Data = shapeInDesiredRotation,
						Position = _configuredShapes[i].Position,
						Rotation = _configuredShapes[i].Rotation
					};
				}
			}
			_configuredShapes = list;
			_outCombinedShape = _resourceFactory.CreateShapeResource(_outputCache.GetOrCreateAssemblerOutput(list));
		}

		private ShapeData GetShapeInDesiredRotation(ShapeData shapeData, ShapeData desiredRotationShapeData)
		{
			if (desiredRotationShapeData.GetShapeHash().VoxelHash.Equals(shapeData.VoxelHash))
			{
				return shapeData;
			}
			Shape shape = Shape.Create(shapeData);
			if (shape.RotateToDesiredShapeRotation(desiredRotationShapeData))
			{
				return _shapesDatabase.GetOrCreateShapeData(shape);
			}
			return shapeData;
		}

		private void TryOutputAssembledShape()
		{
			if (_isConfigured && _hasAssembledShape && !IsTryingToOutput())
			{
				ShapeResource resource = _resourceFactory.CreateShapeResource(_outCombinedShape.ShapeData);
				TryOutput(resource, 0);
			}
		}

		private bool AllNecessaryInputsFull()
		{
			int num = 0;
			for (int i = 0; i < _configuredShapes.Count; i++)
			{
				if (_configuredShapes[i] != null)
				{
					num++;
				}
			}
			int num2 = 0;
			for (int j = 0; j < _factoryObject.DataInputPositions.Count; j++)
			{
				if (IsInputBufferFull(j))
				{
					num2++;
				}
			}
			return num <= num2;
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			if (!_isConfigured)
			{
				OnCurrentResourcesUpdated.Fire();
				return;
			}
			ShapeResource shapeResource = resource as ShapeResource;
			ShapeHashPair shapeHash = shapeResource.ShapeData.GetShapeHash();
			if (TryFindFreeIndexOfConfiguredShape(shapeResource, inputData.Index, out var configuredShapeIndex))
			{
				if (!_configuredShapes[configuredShapeIndex].Data.RotationIndependantHash.Contains(shapeHash))
				{
					_newColoredInputShapes = true;
				}
				_configuredShapeToInputBuffer.Add(configuredShapeIndex, inputData.Index);
				_operatorStateBehaviour.ResetState();
				OnCurrentResourcesUpdated.Fire();
			}
			else
			{
				this.DevException("Failed to add resource to _configuredShapeToInputBuffer. This should never happen, the CanReceiveResource should've prevented this.", "AddResource", 227);
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (!(resource is ShapeResource shapeResource))
			{
				_operatorStateBehaviour.SetStateWrongInputType();
				return false;
			}
			if (!_isConfigured)
			{
				if (shapeResource.ShapeData.Bounds.x > InputShapeMaxBound || shapeResource.ShapeData.Bounds.y > InputShapeMaxBound || shapeResource.ShapeData.Bounds.z > InputShapeMaxBound)
				{
					_operatorStateBehaviour.SetStateInputMaxBoundsExceeded();
					return false;
				}
				_operatorStateBehaviour.SetStateNeedsConfiguration();
				return true;
			}
			if (TryFindFreeIndexOfConfiguredShape(shapeResource, inputData.Index, out var _))
			{
				_operatorStateBehaviour.ResetState();
				return true;
			}
			_operatorStateBehaviour.SetStateExpectingDifferentModule();
			return false;
		}

		private bool TryFindFreeIndexOfConfiguredShape(ShapeResource inputedShapeResource, int inputBufferIndex, out int configuredShapeIndex)
		{
			return _configuredShapes.ForWrapped(inputBufferIndex, MatchesConfiguredShapeAtIndex, out configuredShapeIndex);
			bool MatchesConfiguredShapeAtIndex(ConfiguredAssemblerShape shape, int index)
			{
				ConfiguredAssemblerShape configuredAssemblerShape = _configuredShapes[index];
				if (configuredAssemblerShape == null || configuredAssemblerShape.Data == null)
				{
					return true;
				}
				if (_configuredShapeToInputBuffer.ContainsKey(index))
				{
					return true;
				}
				ShapeHashPair shapeHash = inputedShapeResource.ShapeData.GetShapeHash();
				if (!configuredAssemblerShape.Data.RotationIndependantHash.ContainsShape(shapeHash))
				{
					return true;
				}
				_operatorStateBehaviour.ResetState();
				return false;
			}
		}

		public void Reset()
		{
			_hasAssembledShape = false;
			_isConfigured = false;
			_outCombinedShape = null;
			_configuredShapes.Clear();
			_configuredShapeToInputBuffer.Clear();
			_newColoredInputShapes = false;
			ClearInputBuffers();
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_hasAssembledShape = false;
			_configuredShapeToInputBuffer.Clear();
			_newColoredInputShapes = false;
		}

		public void SetConfiguration(List<ConfiguredAssemblerShape> configShapes)
		{
			_configuredShapes = configShapes;
			_outputCache = new AssemblerOutputCache(_shapesDatabase);
			ShapeData orCreateAssemblerOutput = _outputCache.GetOrCreateAssemblerOutput(configShapes);
			_outCombinedShape = _resourceFactory.CreateShapeResource(orCreateAssemblerOutput);
			_isConfigured = true;
			_operatorStateBehaviour.ResetState();
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (!(configDto is AssemblerBehaviourConfigurationDto assemblerBehaviourConfigurationDto))
			{
				return;
			}
			_outputCache = new AssemblerOutputCache(_shapesDatabase);
			if (!assemblerBehaviourConfigurationDto.IsConfigured)
			{
				return;
			}
			ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(assemblerBehaviourConfigurationDto.CombinedShapeDto);
			_outCombinedShape = _resourceFactory.CreateShapeResource(orCreateShapeData);
			_configuredShapes.Clear();
			foreach (ConfigAssemblerShapeDto configShape in assemblerBehaviourConfigurationDto.ConfigShapes)
			{
				if (configShape == null)
				{
					_configuredShapes.Add(null);
					continue;
				}
				ShapeData orCreateShapeData2 = _shapesDatabase.GetOrCreateShapeData(configShape.ShapeDto);
				_configuredShapes.Add(new ConfiguredAssemblerShape
				{
					Data = orCreateShapeData2,
					Position = configShape.Position,
					Rotation = configShape.Rotation
				});
			}
			_isConfigured = true;
			_operatorStateBehaviour.ResetState();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			if (!_isConfigured)
			{
				return new AssemblerBehaviourConfigurationDto();
			}
			return new AssemblerBehaviourConfigurationDto
			{
				CombinedShapeDto = new ShapeDto(_outCombinedShape.ShapeData),
				ConfigShapes = GetConfigShapes(),
				IsConfigured = true
			};
		}

		private List<ConfigAssemblerShapeDto> GetConfigShapes()
		{
			List<ConfigAssemblerShapeDto> list = new List<ConfigAssemblerShapeDto>();
			foreach (ConfiguredAssemblerShape configuredShape in _configuredShapes)
			{
				if (configuredShape == null)
				{
					list.Add(null);
					continue;
				}
				list.Add(new ConfigAssemblerShapeDto
				{
					Position = configuredShape.Position,
					Rotation = configuredShape.Rotation,
					ShapeDto = new ShapeDto(configuredShape.Data)
				});
			}
			return list;
		}

		private void SetSaveState(AssemblerBehaviourSaveStateDto saveStateDto)
		{
			ApplyInputBufferSaveData(saveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
			_hasAssembledShape = saveStateDto.HasAssembledShape;
			if (_hasAssembledShape)
			{
				_outCombinedShape = (ShapeResource)ResourceDto.ToResource(saveStateDto.AssembledShape, _resourceFactory, _resourceDatabase);
			}
			if (saveStateDto.ConfiguredShapeToInputBuffer != null)
			{
				_configuredShapeToInputBuffer = saveStateDto.ConfiguredShapeToInputBuffer;
			}
			_newColoredInputShapes = saveStateDto.NewColoredInputShapes;
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new AssemblerBehaviourSaveStateDto
			{
				InputBufferSaveData = GetInputBufferSaveData(),
				HasAssembledShape = _hasAssembledShape,
				AssembledShape = new ResourceDto(_outCombinedShape),
				ConfiguredShapeToInputBuffer = new Dictionary<int, int>(_configuredShapeToInputBuffer),
				NewColoredInputShapes = _newColoredInputShapes
			};
		}

		public override IEnumerable<Resource> GetInputResources()
		{
			if (!IsConfigured || _configuredShapes.Count <= 0)
			{
				yield break;
			}
			foreach (ConfiguredAssemblerShape configuredShape in _configuredShapes)
			{
				if (configuredShape != null)
				{
					yield return _resourceFactory.CreateShapeResource(configuredShape.Data);
				}
			}
		}

		public override IEnumerable<Resource> GetOutputResources()
		{
			if (!IsConfigured)
			{
				yield break;
			}
			if (_outCombinedShape == null)
			{
				List<Shape> list = CollectionPool<List<Shape>, Shape>.Get();
				foreach (ConfiguredAssemblerShape configuredShape in _configuredShapes)
				{
					Shape shape = Shape.Create(configuredShape.Data);
					shape.Rotate(configuredShape.Rotation);
					shape.Position = configuredShape.Position;
					list.Add(shape);
				}
				Shape shape2 = list[0].Combine(list);
				ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(shape2);
				_outCombinedShape = _resourceFactory.CreateShapeResource(orCreateShapeData);
				CollectionPool<List<Shape>, Shape>.Release(list);
			}
			yield return _outCombinedShape;
		}

		public (ShapeData, int)[] GetShapesInBuffers()
		{
			(ShapeData, int)[] array = new(ShapeData, int)[_factoryObject.DataInputPositions.Count];
			for (int i = 0; i < _factoryObject.DataInputPositions.Count; i++)
			{
				if (!IsInputBufferFull(i))
				{
					array[i] = (null, 0);
				}
				else
				{
					array[i] = ((GetResourceInInputBuffer(i) as ShapeResource).ShapeData, 1);
				}
			}
			return array;
		}
	}
}
