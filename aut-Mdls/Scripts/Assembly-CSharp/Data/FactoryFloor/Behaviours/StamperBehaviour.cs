using System;
using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.Pool;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/StamperBehaviour", fileName = "StamperBehaviour", order = 0)]
	public class StamperBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSo;

		[SerializeField]
		private int _inputShapeMaxBound = 8;

		private bool _newConfig;

		private bool _isConfigured;

		private ShapeResource _configResource;

		private bool _hasStampShape0;

		private bool _hasStampShape1;

		private RotationIndependentHash _lastStampedShapeHash;

		private Vector2Int _stampStart;

		private Vector2Int _stampEnd;

		private Vector3Int _rotation;

		private ShapeResource[] _shapesToOutput = Array.Empty<ShapeResource>();

		private StamperOutputCache _outputCache;

		private OperatorStateBehaviour _operatorStateBehaviour;

		public MainThreadEvent<ShapeResource> OnSetConfigResource = new MainThreadEvent<ShapeResource>();

		public MainThreadEvent<ShapeResource> OnReceivedShapeResource = new MainThreadEvent<ShapeResource>();

		public bool IsConfigured => _isConfigured;

		public bool HasConfigResource => _configResource != null;

		public ShapeResource ConfigResource => _configResource;

		public Vector2Int StampStart => _stampStart;

		public Vector2Int StampEnd => _stampEnd;

		public Vector3Int Rotation => _rotation;

		public int InputShapeMaxBound => _inputShapeMaxBound;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			StamperBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<StamperBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			StamperBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<StamperBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
				if (AnyInputBufferIsFull() && !_isConfigured)
				{
					_operatorStateBehaviour.SetStateNeedsConfiguration();
				}
			}
			_newConfig = true;
			OnOutputResource.RegisterInline(OnOutput);
		}

		public override void UnInit()
		{
			ResetStampConfig(callInputFreedEvents: false);
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			if (outputIndex == 0)
			{
				_hasStampShape0 = false;
			}
			if (outputIndex == 1)
			{
				_hasStampShape1 = false;
			}
		}

		public override void Update()
		{
			if (!IsInputBufferFull())
			{
				EndActivity();
				return;
			}
			TryStampShape();
			TryOutputStampedShape();
		}

		private void TryStampShape()
		{
			if ((_hasStampShape0 && _hasStampShape1) || !_isConfigured)
			{
				EndActivity();
				return;
			}
			StartActivity();
			ShapeResource shapeResource = GetResourceInInputBuffer() as ShapeResource;
			if (_newConfig || !_lastStampedShapeHash.Contains(shapeResource.ShapeData.GetShapeHash()))
			{
				StampShape(shapeResource.ShapeData);
			}
			_hasStampShape0 = true;
			_hasStampShape1 = true;
			ClearInputBuffers();
		}

		private void StampShape(ShapeData shapeData)
		{
			_lastStampedShapeHash = shapeData.RotationIndependantHash;
			ShapeData rotatedInputShapeData;
			ShapeData[] orCreateStamperOutputs = _outputCache.GetOrCreateStamperOutputs(shapeData, out rotatedInputShapeData);
			_configResource = _resourceFactory.CreateShapeResource(rotatedInputShapeData);
			OnSetConfigResource.Fire(_configResource);
			_shapesToOutput = new ShapeResource[orCreateStamperOutputs.Length];
			for (int i = 0; i < orCreateStamperOutputs.Length; i++)
			{
				_shapesToOutput[i] = _resourceFactory.CreateShapeResource(orCreateStamperOutputs[i]);
			}
			_newConfig = false;
		}

		private void TryOutputStampedShape()
		{
			if (_hasStampShape0 || _hasStampShape1)
			{
				if (!IsTryingToOutputAtIndex(0) && _hasStampShape0 && _shapesToOutput.Length >= 1)
				{
					TryOutput(_shapesToOutput[0], 0);
				}
				if (!IsTryingToOutputAtIndex(1) && _hasStampShape1 && _shapesToOutput.Length >= 2)
				{
					TryOutput(_shapesToOutput[1], 1);
				}
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			ShapeResource shapeResource = resource as ShapeResource;
			OnReceivedShapeResource.Fire(shapeResource);
			_operatorStateBehaviour.ResetState();
			if (!_isConfigured)
			{
				_operatorStateBehaviour.SetStateNeedsConfiguration();
				_configResource = shapeResource;
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
				ShapeHashPair shapeHash = shapeResource.ShapeData.GetShapeHash();
				int num;
				if (_lastStampedShapeHash.Rotations != null)
				{
					num = (_lastStampedShapeHash.ContainsShape(shapeHash) ? 1 : 0);
					if (num == 0)
					{
						_operatorStateBehaviour.SetStateExpectingDifferentModule();
					}
				}
				else
				{
					num = 1;
				}
				return (byte)num != 0;
			}
			return true;
		}

		public override void RemoveResource(Resource resource)
		{
			ClearInputBuffers();
		}

		public void SetStampConfig(Vector2Int stampStart, Vector2Int stampEnd, Vector3Int rotation)
		{
			_lastStampedShapeHash = default(RotationIndependentHash);
			_stampStart = stampStart;
			_stampEnd = stampEnd;
			_rotation = rotation;
			_isConfigured = true;
			_hasStampShape0 = false;
			_hasStampShape1 = false;
			_outputCache = new StamperOutputCache(_shapesDatabase, _rotation, stampStart, stampEnd, _configResource.ShapeData);
			_operatorStateBehaviour.ResetState();
		}

		public void ResetStampConfig(bool callInputFreedEvents = true)
		{
			_isConfigured = false;
			_hasStampShape0 = false;
			_hasStampShape1 = false;
			_configResource = null;
			_newConfig = false;
			_lastStampedShapeHash = default(RotationIndependentHash);
			StopTryingToOutput();
			ClearInputBuffers(callInputFreedEvents);
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			if (!_isConfigured || !HasConfigResource)
			{
				return null;
			}
			return new StamperBehaviourConfigurationDto
			{
				StampStart = _stampStart,
				StampEnd = _stampEnd,
				Rotation = _rotation,
				Shape = new ShapeDto(_configResource.ShapeData)
			};
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (configDto is StamperBehaviourConfigurationDto stamperBehaviourConfigurationDto)
			{
				ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(stamperBehaviourConfigurationDto.Shape);
				_configResource = _resourceFactory.CreateShapeResource(orCreateShapeData);
				_lastStampedShapeHash = orCreateShapeData.RotationIndependantHash;
				SetStampConfig(stamperBehaviourConfigurationDto.StampStart, stamperBehaviourConfigurationDto.StampEnd, stamperBehaviourConfigurationDto.Rotation);
				StampShape(_configResource.ShapeData);
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new StamperBehaviourSaveStateDto
			{
				HasStampShape = _hasStampShape0,
				OutputHashes = GetOutputHashes(),
				InputBufferSaveData = GetInputBufferSaveData()
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
				ShapeResource shapeResource = _shapesToOutput[i];
				array[i] = shapeResource.ShapeData.GetShapeHash().ToString();
			}
			return array;
		}

		private void SetSaveState(StamperBehaviourSaveStateDto saveStateDto)
		{
			ApplyInputBufferSaveData(saveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabaseSo);
			_hasStampShape0 = saveStateDto.HasStampShape;
			_hasStampShape1 = saveStateDto.HasStampShape;
			if (saveStateDto.OutputHashes == null)
			{
				_shapesToOutput = Array.Empty<ShapeResource>();
				return;
			}
			List<ShapeResource> list = CollectionPool<List<ShapeResource>, ShapeResource>.Get();
			for (int i = 0; i < saveStateDto.OutputHashes.Length; i++)
			{
				string hashString = saveStateDto.OutputHashes[i];
				if (_shapesDatabase.TryGetShapeData(ShapeHashPair.Parse(hashString), out var shapeData))
				{
					list.Add(_resourceFactory.CreateShapeResource(shapeData));
				}
			}
			_shapesToOutput = list.ToArray();
			CollectionPool<List<ShapeResource>, ShapeResource>.Release(list);
			if (!_isConfigured && IsInputBufferFull())
			{
				_configResource = GetResourceInInputBuffer() as ShapeResource;
				OnSetConfigResource.Fire(_configResource);
			}
		}

		public override IEnumerable<Resource> GetInputResources()
		{
			if (IsConfigured)
			{
				yield return IsInputBufferFull() ? (GetResourceInInputBuffer() as ShapeResource).GetCopy() : _configResource.GetCopy();
			}
		}

		public override IEnumerable<Resource> GetOutputResources()
		{
			if (IsConfigured)
			{
				ShapeData inputShapeData = (IsInputBufferFull() ? (GetResourceInInputBuffer() as ShapeResource).ShapeData : _configResource.ShapeData);
				ShapeData rotatedInputShapeData;
				ShapeData[] orCreateStamperOutputs = _outputCache.GetOrCreateStamperOutputs(inputShapeData, out rotatedInputShapeData);
				ShapeData[] array = orCreateStamperOutputs;
				foreach (ShapeData shapeData in array)
				{
					yield return _resourceFactory.CreateShapeResource(shapeData);
				}
			}
		}
	}
}
