using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Events;
using Events.Generic;
using Logic.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/PainterBehaviour", fileName = "PainterBehaviour", order = 0)]
	public class PainterBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ColorEvent _shapePaintedEvent;

		[SerializeField]
		private NonShapeResourceDataSO _greyBotResourceData;

		[SerializeField]
		private BaseEvent _greyBotInPainterEvent;

		public MainThreadEvent<ColorResource> OnColorAdded = new MainThreadEvent<ColorResource>();

		public MainThreadEvent<bool> OnHasPaintChanged = new MainThreadEvent<bool>();

		private readonly Dictionary<string, ShapeResource> _paintedShapes = new Dictionary<string, ShapeResource>();

		private bool _hasPaintedShape;

		private ShapeResource _currentPaintedShape;

		private OperatorStateBehaviour _operatorStateBehaviour;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			OnOutputResource.RegisterInline(OnOutput);
			PainterBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<PainterBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplySaveState(behaviourSaveStateDto);
			}
		}

		public override void UnInit()
		{
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			_hasPaintedShape = false;
			OnHasPaintChanged.Fire(data: false);
		}

		public override void Update()
		{
			TryPaintShape();
			TryOutputPaintedShape();
		}

		private void TryPaintShape()
		{
			if (!IsInputBufferFull() || !IsInputBufferFull(1) || _hasPaintedShape)
			{
				EndActivity();
				return;
			}
			StartActivity();
			ColorResource obj = TakeResourceFromInputBuffer(1) as ColorResource;
			ShapeResource shapeResource = TakeResourceFromInputBuffer(0) as ShapeResource;
			Color colorValue = obj.ColorValue;
			colorValue.a = 1f;
			string key = shapeResource.ShapeData.GetShapeHash().ToString() + colorValue.ToString();
			if (!_paintedShapes.ContainsKey(key))
			{
				Shape shape = Shape.Create(shapeResource.ShapeData);
				shape.ChangeColor(colorValue);
				ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(shape);
				_paintedShapes.Add(key, _resourceFactory.CreateShapeResource(orCreateShapeData));
			}
			_shapePaintedEvent.Fire(colorValue);
			_currentPaintedShape = _paintedShapes[key];
			_hasPaintedShape = true;
		}

		private void TryOutputPaintedShape()
		{
			if (_hasPaintedShape && !IsTryingToOutput())
			{
				ShapeResource resource = _resourceFactory.CreateShapeResource(_currentPaintedShape.ShapeData);
				TryOutput(resource, 0);
			}
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_hasPaintedShape = false;
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			_operatorStateBehaviour.ResetState();
			if (inputData.Index == 1)
			{
				OnColorAdded.Fire(resource as ColorResource);
				OnHasPaintChanged.Fire(data: true);
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (inputData.Index == 0 && !(resource is ShapeResource))
			{
				if (resource.Data == _greyBotResourceData && IsInputBufferFull(1))
				{
					_greyBotInPainterEvent.Fire();
				}
				_operatorStateBehaviour.SetStateWrongInputType();
				return false;
			}
			if (inputData.Index == 1 && !(resource is ColorResource))
			{
				_operatorStateBehaviour.SetStateExpectingPaint();
				return false;
			}
			return true;
		}

		private void ApplySaveState(PainterBehaviourSaveStateDto saveStateDto)
		{
			ApplyInputBufferSaveData(saveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
			_hasPaintedShape = saveStateDto.HasPaintedShape;
			if (_hasPaintedShape)
			{
				_currentPaintedShape = ResourceDto.ToResource(saveStateDto.CurrentPaintedShape, _resourceFactory, _resourceDatabase) as ShapeResource;
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new PainterBehaviourSaveStateDto
			{
				InputBufferSaveData = GetInputBufferSaveData(),
				HasPaintedShape = _hasPaintedShape,
				CurrentPaintedShape = new ResourceDto(_currentPaintedShape)
			};
		}
	}
}
