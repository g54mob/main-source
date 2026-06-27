using Restory.Data.NPCs;
using Restory.Data.Visits;
using Restory.Gameplay.DeviceSales;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.ToDoList;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class NpcVisitsServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject visitsServicesPrefab;

		[SerializeField]
		private GameObject workOrderServicePrefab;

		[SerializeField]
		private GameObject devicesForSaleDeliveryTrackerPrefab;

		[SerializeField]
		private CurrentDayVisitsSettings currentDayVisitsSettings;

		[SerializeField]
		private LicencesToVisitsTriggers licencesToVisitsTriggers;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(visitsServicesPrefab);
			GameObject gameObject2 = base.Container.InstantiateAndQueueForInject(workOrderServicePrefab);
			GameObject gameObject3 = base.Container.InstantiateAndQueueForInject(devicesForSaleDeliveryTrackerPrefab);
			base.Container.Bind<VisitsScheduleService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<CurrentDayVisitsQueueService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<WorkOrdersService>().FromComponentOn(gameObject2).AsSingle();
			base.Container.Bind<FreeSaleShippingDevicesTrackingService>().FromComponentOn(gameObject3).AsSingle();
			base.Container.BindInterfacesAndSelfTo<DeliveryForNpcsDevicesStorageChangesDispatcher>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<VisitsBlockerFromWindowShutters>().FromNew().AsSingle()
				.WithArguments(currentDayVisitsSettings);
			base.Container.BindInterfacesTo<VisitsFromLicensesService>().FromNew().AsSingle()
				.WithArguments(licencesToVisitsTriggers);
			base.Container.BindInterfacesTo<VisitsFromToDoListService>().FromNew().AsSingle();
		}
	}
}
