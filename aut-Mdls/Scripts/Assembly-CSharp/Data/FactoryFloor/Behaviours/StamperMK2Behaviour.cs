using System;
using System.Collections.Generic;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.FactoryObjectBehaviours.CachedOutputs;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/StamperMK2Behaviour", fileName = "StamperMK2Behaviour", order = 0)]
	public class StamperMK2Behaviour : SupplyTankRecipientBehaviour
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

		private ShapeResource _configResourceShape;

		private bool _hasStampShape0;

		private bool _hasStampShape1;

		private RotationIndependentHash _lastStampedShapeHash;

		private Vector3Int _rotation;

		private ShapeResource[] _shapesToOutput = Array.Empty<ShapeResource>();

		private StamperMK2OutputCache _outputCache;

		public MainThreadEvent<ShapeResource> OnSetConfigResource = new MainThreadEvent<ShapeResource>();

		public MainThreadEvent<ShapeResource> OnReceivedShapeResource = new MainThreadEvent<ShapeResource>();

		private Shape _stampedShape;

		private Shape _excessShape;

		private Shape _selectedShapeA;

		private Shape _selectedShapeB;

		public bool IsConfigured => _isConfigured;

		public bool HasConfigResource => _configResourceShape != null;

		public ShapeResource ConfigResourceShape => _configResourceShape;

		public int InputShapeMaxBound => _inputShapeMaxBound;

		public Vector3Int Rotation => _rotation;

		public Shape SelectedShapeA => _selectedShapeA;

		public Shape SelectedShapeB => _selectedShapeB;

		public ShapeResource[] ShapesToOutput => _shapesToOutput;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			throw new NotIncludedInDemoException();
		}

		public override void OperatorUpdate()
		{
			throw new NotIncludedInDemoException();
		}

		private bool TryStampShape()
		{
			throw new NotIncludedInDemoException();
		}

		private void StampShape(ShapeData shapeData)
		{
			throw new NotIncludedInDemoException();
		}

		private void TryOutputStampedShape()
		{
			throw new NotIncludedInDemoException();
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			throw new NotIncludedInDemoException();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			throw new NotIncludedInDemoException();
		}

		public override void RemoveResource(Resource resource)
		{
			ClearInputBuffers();
		}

		public void ApplyStampConfig(Shape stampedShape, Shape excessShape, Shape selectedShapeA, Shape selectedShapeB, Vector3Int rotation, Shape configShape)
		{
			throw new NotIncludedInDemoException();
		}

		public void ResetStampConfig()
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

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}

		private string[] GetOutputHashes()
		{
			throw new NotIncludedInDemoException();
		}

		private void ApplySaveState(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override IEnumerable<Resource> GetInputResources()
		{
			throw new NotIncludedInDemoException();
		}

		public override IEnumerable<Resource> GetOutputResources()
		{
			throw new NotIncludedInDemoException();
		}
	}
}
