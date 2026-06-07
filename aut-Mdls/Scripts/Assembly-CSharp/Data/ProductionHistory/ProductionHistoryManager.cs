using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.ProductionHistory
{
	public class ProductionHistoryManager : MonoBehaviour
	{
		[SerializeField]
		private ProductionHistoryPersistentSO _persistentSO;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[Header("Steps")]
		[SerializeField]
		private FactoryStepEvent _factoryStepEvent;

		[SerializeField]
		private IntVariableSO _stepsPerSecond;

		[SerializeField]
		private int _debugStepScalar = 1;

		[Header("Factory Objects")]
		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private FactoryObjectDeletedEvent _factoryObjectDeletedEvent;

		[SerializeField]
		private FactoryLayer _editableFactoryLayer;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[Header("Resources")]
		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		private bool _isFactoryDoneLoading;

		private int StepsPerMinute => _stepsPerSecond.Value * 60;

		private void Awake()
		{
			_factoryStepEvent.RegisterInline(Process);
			_finishedLoadingSaveEvent.Register(OnFactoryFinishedLoading);
			_resourceCreatedEvent.RegisterInline(OnResourceCreated);
			_resourceDeliveredEvent.RegisterInline(OnResourceDelivered);
			_createFactoryObjectEvent.Register(HandleFactoryObjectPlaced);
			_factoryObjectDeletedEvent.Register(HandleFactoryObjectsDeleted);
		}

		private void OnDestroy()
		{
			_factoryStepEvent.UnRegisterInline(Process);
			_finishedLoadingSaveEvent.UnRegister(OnFactoryFinishedLoading);
			_resourceCreatedEvent.UnRegisterInline(OnResourceCreated);
			_resourceDeliveredEvent.UnRegisterInline(OnResourceDelivered);
			_createFactoryObjectEvent.UnRegister(HandleFactoryObjectPlaced);
			_factoryObjectDeletedEvent.UnRegister(HandleFactoryObjectsDeleted);
		}

		private void Process(int step)
		{
			_persistentSO.ManagerStep += _debugStepScalar;
			if (_persistentSO.ManagerStep >= StepsPerMinute)
			{
				_persistentSO.ManagerStep -= StepsPerMinute;
				_persistentSO.OnMinuteReached();
			}
		}

		private void OnFactoryFinishedLoading()
		{
			_isFactoryDoneLoading = true;
			_persistentSO.CurrentHistory.FactoryObjectAmounts.Clear();
			foreach (FactoryObjectData allFactoryObjectsDatum in _factoryObjectDatabase.AllFactoryObjectsData)
			{
				if (_editableFactoryLayer.TryGetObjectsFromData(allFactoryObjectsDatum, out var factoryObjects))
				{
					_persistentSO.ModifyFactoryObjectAmount(allFactoryObjectsDatum.ID, factoryObjects.Count);
				}
			}
		}

		private void OnResourceCreated(Resource resource)
		{
			if (_isFactoryDoneLoading && !(resource is ShapeResource))
			{
				_persistentSO.ModifyResourceProducedDelta(resource.Data.ID);
			}
		}

		private void OnResourceDelivered(Resource resource)
		{
			if (_isFactoryDoneLoading && !(resource is ShapeResource))
			{
				_persistentSO.ModifyResourceDeliveredDelta(resource.Data.ID);
			}
		}

		private void HandleFactoryObjectPlaced(CreateFactoryObjectDto createFactoryObjectDto)
		{
			if (!createFactoryObjectDto.IsGameLoading && !(createFactoryObjectDto.FactoryObject.FactoryLayer != _editableFactoryLayer))
			{
				FactoryObjectData factoryObjectData = createFactoryObjectDto.FactoryObject.FactoryObjectData;
				_persistentSO.ModifyFactoryObjectAmount(factoryObjectData.ID);
			}
		}

		private void HandleFactoryObjectsDeleted((FactoryObject factoryObject, FactoryLayer factoryLayer) deleted)
		{
			if (!(deleted.factoryLayer != _editableFactoryLayer))
			{
				_persistentSO.ModifyFactoryObjectAmount(deleted.factoryObject.ObjectId, -1);
			}
		}
	}
}
