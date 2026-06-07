using System;
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

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/CutterBehaviour", fileName = "CutterBehaviour", order = 0)]
	public class CutterBehaviour : SupplyTankRecipientBehaviour
	{
		[Header("Cutter")]
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private int _inputShapeMaxBound = 8;

		private bool _hasResource;

		private ShapeResource _currentResource;

		private bool _hasCutShape;

		private RotationIndependentHash _lastCutShapeHash;

		private int _shapeOutputIndex;

		private ShapeData[] _shapesToOutput = Array.Empty<ShapeData>();

		private CutterOutputCache _outputCache;

		private bool _isConfigured;

		private ShapeResource _configResource;

		private Vector3Int _rotation;

		private List<int> _cuts;

		private int _cutInterval;

		private Shape _shapeToCut;

		private bool _newConfig;

		public MainThreadEvent<ShapeResource> OnSetConfigResource = new MainThreadEvent<ShapeResource>();

		public MainThreadEvent<ShapeResource> OnReceivedShapeResource = new MainThreadEvent<ShapeResource>();

		public MainThreadEvent<Resource, int> OnNewCutShapePassed = new MainThreadEvent<Resource, int>();

		public bool IsConfigured => _isConfigured;

		public bool HasConfigResource => _configResource != null;

		public ShapeResource ConfigResource => _configResource;

		public List<int> Cuts => _cuts;

		public int CutInterval => _cutInterval;

		public Vector3Int Rotation => _rotation;

		public Shape ShapeToCut => _shapeToCut;

		public int InputShapeMaxBound => _inputShapeMaxBound;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			OnOutputResource.RegisterInline(OnOutput);
			CutterBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<CutterBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			CutterBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<CutterBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
				if (AllInputBuffersFull() && !_isConfigured)
				{
					_operatorStateBehaviour.SetStateNeedsConfiguration();
				}
			}
		}

		public override void UnInit()
		{
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			OnNewCutShapePassed.Fire(resource, _shapeOutputIndex);
			_shapeOutputIndex++;
			if (_shapeOutputIndex >= _shapesToOutput.Length)
			{
				_hasCutShape = false;
				CallCanReceiveNewResources();
			}
			TryOutputCutShape();
		}

		public override void OperatorUpdate()
		{
			bool num = TryCutShape();
			TryOutputCutShape();
			if (num)
			{
				base.OperatorUpdate();
			}
		}

		private bool TryCutShape()
		{
			if (!_hasResource || !_isConfigured || (_hasCutShape && _shapeOutputIndex < _shapesToOutput.Length))
			{
				EndActivity();
				return false;
			}
			StartActivity();
			if (_newConfig || !_lastCutShapeHash.Contains(_currentResource.ShapeData.GetShapeHash()))
			{
				CutShape(_currentResource.ShapeData);
			}
			_hasCutShape = true;
			_shapeOutputIndex = 0;
			RemoveResource(_currentResource);
			return true;
		}

		private void CutShape(ShapeData shapeData)
		{
			_shapeToCut = Shape.Create(shapeData);
			_shapeToCut.Rotate(_rotation);
			_shapesToOutput = _outputCache.GetOrCreateCutterOutputs(shapeData, _shapeToCut, out var rotatedInputShapeData);
			_configResource = _resourceFactory.CreateShapeResource(rotatedInputShapeData);
			OnSetConfigResource.Fire(_configResource);
			_lastCutShapeHash = shapeData.RotationIndependantHash;
			_newConfig = false;
		}

		private void TryOutputCutShape()
		{
			if (_hasCutShape && _shapesToOutput.Length >= 1 && !IsTryingToOutput())
			{
				ShapeResource resource = _resourceFactory.CreateShapeResource(_shapesToOutput[_shapeOutputIndex]);
				TryOutput(resource, 0);
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			ShapeResource configResource = (_currentResource = resource as ShapeResource);
			_hasResource = true;
			OnReceivedShapeResource.Fire(_currentResource);
			_operatorStateBehaviour.ResetState();
			if (!_isConfigured)
			{
				_operatorStateBehaviour.SetStateNeedsConfiguration();
				_configResource = configResource;
				OnSetConfigResource.Fire(_configResource);
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
			if (shapeResource.ShapeData.Bounds.x > InputShapeMaxBound || shapeResource.ShapeData.Bounds.y > InputShapeMaxBound || shapeResource.ShapeData.Bounds.z > InputShapeMaxBound)
			{
				_operatorStateBehaviour.SetStateInputMaxBoundsExceeded();
				return false;
			}
			if (_isConfigured)
			{
				ShapeHashPair? shapeHashPair = shapeResource?.ShapeData.GetShapeHash();
				bool flag = _lastCutShapeHash.Rotations == null || _lastCutShapeHash.ContainsShape(shapeHashPair.Value);
				if (!_hasResource && !flag)
				{
					_operatorStateBehaviour.SetStateExpectingDifferentModule();
				}
				return flag;
			}
			return true;
		}

		public override void RemoveResource(Resource resource)
		{
			if (_currentResource == resource)
			{
				_currentResource = null;
				_hasResource = false;
				TakeResourceFromInputBuffer(0);
			}
		}

		public void SetCuttingConfig(List<int> cuts, int cutInterval, Vector3Int rotation, ShapeData rotatedConfigShapeData)
		{
			_cuts = cuts;
			_cutInterval = cutInterval;
			_rotation = rotation;
			_isConfigured = true;
			_newConfig = true;
			_hasCutShape = false;
			_outputCache = new CutterOutputCache(_shapesDatabase, _cuts, _configResource.ShapeData, rotatedConfigShapeData);
			_operatorStateBehaviour.ResetState();
		}

		private void SetSaveState(CutterBehaviourSaveStateDto saveStateDto)
		{
			_hasResource = saveStateDto.HasResource;
			_hasCutShape = saveStateDto.HasCutShape;
			_shapeOutputIndex = saveStateDto.CurrentOutputIndex;
			if (_hasResource && _shapesDatabase.TryGetShapeData(ShapeHashPair.Parse(saveStateDto.CurrentResourceHash), out var shapeData))
			{
				_currentResource = _resourceFactory.CreateShapeResource(shapeData);
				AddResource(_currentResource);
			}
			else
			{
				_currentResource = null;
			}
			if (saveStateDto.OutputHashes == null)
			{
				_shapesToOutput = Array.Empty<ShapeData>();
				return;
			}
			List<ShapeData> list = CollectionPool<List<ShapeData>, ShapeData>.Get();
			for (int i = 0; i < saveStateDto.OutputHashes.Length; i++)
			{
				if (_shapesDatabase.TryGetShapeData(ShapeHashPair.Parse(saveStateDto.OutputHashes[i]), out shapeData))
				{
					list.Add(shapeData);
				}
			}
			_shapesToOutput = list.ToArray();
			CollectionPool<List<ShapeData>, ShapeData>.Release(list);
		}

		public void ResetCutterConfig()
		{
			_isConfigured = false;
			_configResource = null;
			_hasCutShape = false;
			_cuts = null;
			_cutInterval = 0;
			_currentResource = null;
			_hasResource = false;
			StopTryingToOutput();
			ClearInputBuffers();
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_hasResource = false;
			_currentResource = null;
			_hasCutShape = false;
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new CutterBehaviourConfigurationDto(_cuts, _cutInterval, _rotation, (_configResource == null) ? null : new ShapeDto(_configResource.ShapeData), _isConfigured);
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (configDto is CutterBehaviourConfigurationDto cutterBehaviourConfigurationDto)
			{
				_isConfigured = cutterBehaviourConfigurationDto.IsConfigured;
				if (cutterBehaviourConfigurationDto.ConfigShape != null && _isConfigured)
				{
					ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(cutterBehaviourConfigurationDto.ConfigShape);
					Shape shape = Shape.Create(cutterBehaviourConfigurationDto.ConfigShape);
					shape.Rotate(cutterBehaviourConfigurationDto.Rotation);
					ShapeData orCreateShapeData2 = _shapesDatabase.GetOrCreateShapeData(shape);
					_configResource = _resourceFactory.CreateShapeResource(orCreateShapeData);
					_lastCutShapeHash = orCreateShapeData.RotationIndependantHash;
					SetCuttingConfig(cutterBehaviourConfigurationDto.Cuts, cutterBehaviourConfigurationDto.CutInterval, cutterBehaviourConfigurationDto.Rotation, orCreateShapeData2);
					CutShape(_configResource.ShapeData);
					_newConfig = true;
				}
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new CutterBehaviourSaveStateDto
			{
				HasResource = _hasResource,
				HasCutShape = _hasCutShape,
				OutputHashes = GetOutputHashes(),
				CurrentOutputIndex = _shapeOutputIndex,
				CurrentResourceHash = _currentResource?.ShapeData.GetShapeHash().ToString()
			};
		}

		private string[] GetOutputHashes()
		{
			if (!_isConfigured || _shapesToOutput == null || _shapesToOutput.Length == 0)
			{
				return Array.Empty<string>();
			}
			string[] array = new string[_shapesToOutput.Length];
			for (int i = 0; i < _shapesToOutput.Length; i++)
			{
				ShapeData shapeData = _shapesToOutput[i];
				array[i] = shapeData.GetShapeHash().ToString();
			}
			return array;
		}

		public override IEnumerable<Resource> GetInputResources()
		{
			if (IsConfigured)
			{
				yield return (_currentResource != null) ? _currentResource.GetCopy() : _configResource.GetCopy();
			}
		}

		public override IEnumerable<Resource> GetOutputResources()
		{
			if (IsConfigured)
			{
				ShapeData shapeData = ((_currentResource != null) ? _currentResource.ShapeData : _configResource.ShapeData);
				Shape shape = Shape.Create(shapeData);
				shape.Rotate(_rotation);
				ShapeData rotatedInputShapeData;
				ShapeData[] orCreateCutterOutputs = _outputCache.GetOrCreateCutterOutputs(shapeData, shape, out rotatedInputShapeData);
				ShapeData[] array = orCreateCutterOutputs;
				foreach (ShapeData shapeData2 in array)
				{
					yield return _resourceFactory.CreateShapeResource(shapeData2);
				}
			}
		}
	}
}
