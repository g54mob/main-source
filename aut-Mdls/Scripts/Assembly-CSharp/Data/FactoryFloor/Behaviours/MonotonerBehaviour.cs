using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/MonotonerBehaviour", fileName = "MonotonerBehaviour", order = 0)]
	public class MonotonerBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ColorLibrarySO _mainColorLibrary;

		[SerializeField]
		private int _whiteColorIndex;

		[SerializeField]
		private int _blackColorIndex;

		private bool _isPaintingBlack = true;

		private bool _hasPaintedShape;

		private ShapeResource _paintedShape;

		private Color _currentColor;

		private readonly Dictionary<int, ShapeResource> _paintedShapes = new Dictionary<int, ShapeResource>();

		private OperatorStateBehaviour _operatorStateBehaviour;

		public MainThreadEvent<bool> OnChangedPaintMode = new MainThreadEvent<bool>();

		public bool IsPaintingBlack => _isPaintingBlack;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			_currentColor = _mainColorLibrary.ColorDictionary.ElementAt(_blackColorIndex).Key;
			MonotonerBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<MonotonerBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			MonotonerBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<MonotonerBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplyInputBufferSaveData(behaviourSaveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
				_hasPaintedShape = behaviourSaveStateDto.HasPaintedShape;
				if (_hasPaintedShape)
				{
					_paintedShape = ResourceDto.ToResource(behaviourSaveStateDto.PaintedShapeDto, _resourceFactory, _resourceDatabase) as ShapeResource;
				}
			}
			OnOutputResource.RegisterInline(OnOutput);
		}

		public override void UnInit()
		{
			_isPaintingBlack = true;
			ClearShape();
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		private void OnOutput(Resource _, int __)
		{
			ClearShape();
		}

		public override void Update()
		{
			TryPaintShape();
			TryOutputPaintedShape();
		}

		public void ToggleColor()
		{
			ClearShape();
			_isPaintingBlack = !_isPaintingBlack;
			_currentColor = (_isPaintingBlack ? _mainColorLibrary.ColorDictionary.ElementAt(_blackColorIndex).Key : _mainColorLibrary.ColorDictionary.ElementAt(_whiteColorIndex).Key);
			OnChangedPaintMode.Fire(_isPaintingBlack);
			StopTryingToOutput();
		}

		private void TryPaintShape()
		{
			if (_hasPaintedShape || !IsInputBufferFull())
			{
				EndActivity();
				return;
			}
			StartActivity();
			_currentColor.a = 1f;
			ShapeResource shapeResource = TakeResourceFromInputBuffer(0) as ShapeResource;
			int key = HashCode.Combine(shapeResource.ShapeData.GetShapeHash(), _currentColor);
			if (!_paintedShapes.TryGetValue(key, out _paintedShape))
			{
				Shape shape = Shape.Create(shapeResource.ShapeData);
				shape.ChangeColor(_currentColor);
				ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(shape);
				_paintedShape = _resourceFactory.CreateShapeResource(orCreateShapeData);
				_paintedShapes.Add(key, _paintedShape);
			}
			_paintedShape = _paintedShape.GetCopy();
			_hasPaintedShape = true;
		}

		private void TryOutputPaintedShape()
		{
			if (_hasPaintedShape && !IsTryingToOutput())
			{
				TryOutput(_paintedShape, 0);
			}
		}

		private void ClearShape()
		{
			_hasPaintedShape = false;
			_paintedShape = null;
		}

		public override void ClearResources()
		{
			base.ClearResources();
			ClearShape();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			_operatorStateBehaviour.ResetState();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (!(resource is ShapeResource))
			{
				_operatorStateBehaviour.SetStateWrongInputType();
				return false;
			}
			return true;
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new MonotonerBehaviourConfigurationDto(_isPaintingBlack);
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (configDto is MonotonerBehaviourConfigurationDto monotonerBehaviourConfigurationDto && _isPaintingBlack != monotonerBehaviourConfigurationDto.IsPaintingBlack)
			{
				ToggleColor();
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new MonotonerBehaviourSaveStateDto
			{
				InputBufferSaveData = GetInputBufferSaveData(),
				HasPaintedShape = _hasPaintedShape,
				PaintedShapeDto = new ResourceDto(_paintedShape)
			};
		}
	}
}
