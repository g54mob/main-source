using System;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Events;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Statistics
{
	public class StatisticsManager : MonoBehaviour
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDeliveredEvent;

		[SerializeField]
		private ResourceWithdrawnEventSO _resourceWithdrawnEvent;

		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private FurnaceOutputResourceEventSO _furnaceOutputResourceEvent;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private AddXPEvent _addXPEvent;

		private bool _factoryIsLoading;

		private void Awake()
		{
			_preLoadingSaveEvent.Register(OnStartingLoadFactory);
			_finishedLoadingSaveEvent.Register(OnFinishedLoadFactory);
			_resourceCreatedEvent.RegisterInline(HandleResourceProduced);
			_resourceDeliveredEvent.RegisterInline(HandleResourceDelivered);
			_resourceWithdrawnEvent.RegisterInline(HandleResourceWithdrawn);
			_furnaceOutputResourceEvent.Register(HandleFurnaceResource);
			_createFactoryObjectEvent.Register(HandleFactoryObjectPlaced);
			_addXPEvent.RegisterInline(HandleXPEarned);
		}

		private void OnDestroy()
		{
			_preLoadingSaveEvent.UnRegister(OnStartingLoadFactory);
			_finishedLoadingSaveEvent.UnRegister(OnFinishedLoadFactory);
			_resourceCreatedEvent.UnRegisterInline(HandleResourceProduced);
			_resourceDeliveredEvent.UnRegisterInline(HandleResourceDelivered);
			_resourceWithdrawnEvent.UnRegisterInline(HandleResourceWithdrawn);
			_furnaceOutputResourceEvent.UnRegister(HandleFurnaceResource);
			_createFactoryObjectEvent.UnRegister(HandleFactoryObjectPlaced);
			_addXPEvent.UnRegisterInline(HandleXPEarned);
		}

		private void OnStartingLoadFactory()
		{
			_factoryIsLoading = true;
		}

		private void OnFinishedLoadFactory()
		{
			_factoryIsLoading = false;
		}

		private void HandleResourceProduced(Resource resource)
		{
			if (!_factoryIsLoading)
			{
				if (resource is ShapeResource shapeResource)
				{
					_statisticsSO.AddProducedShapeStatistic(shapeResource.ShapeData.RotationIndependantHash);
				}
				else
				{
					_statisticsSO.AddProducedStatistic(resource.Data.ID, 1uL);
				}
			}
		}

		private void HandleResourceDelivered(Resource resource)
		{
			if (!_factoryIsLoading)
			{
				if (resource is ShapeResource shapeResource)
				{
					_statisticsSO.AddDeliveredShapeStatistic(shapeResource.ShapeData.RotationIndependantHash);
				}
				else
				{
					_statisticsSO.AddDeliveredStatistic(resource.Data.ID);
				}
			}
		}

		private void HandleResourceWithdrawn(Resource resource)
		{
			if (!_factoryIsLoading)
			{
				if (resource is ShapeResource)
				{
					throw new NotImplementedException();
				}
				_statisticsSO.AddWithdrawnStatistic(resource.Data.ID);
			}
		}

		private void HandleFurnaceResource(Resource resource)
		{
			if (!_factoryIsLoading)
			{
				_statisticsSO.AddBehaviourStatistic(BehaviourStatisticType.CubesProduced);
			}
		}

		private void HandleFactoryObjectPlaced(CreateFactoryObjectDto createFactoryObjectDto)
		{
			if (!_factoryIsLoading && !createFactoryObjectDto.IsGameLoading)
			{
				FactoryObjectData factoryObjectData = createFactoryObjectDto.FactoryObject.FactoryObjectData;
				_statisticsSO.AddPlacedStatistic(factoryObjectData.ID);
				if (factoryObjectData is BuildingObjectData)
				{
					_statisticsSO.AddBehaviourStatistic(BehaviourStatisticType.BuildingPlaced);
				}
			}
		}

		private void HandleXPEarned(AddXPEvent.Data data)
		{
			if (!_factoryIsLoading)
			{
				_statisticsSO.AddXPEarnedStatistic(data.EarnedSource, data.Amount);
			}
		}
	}
}
