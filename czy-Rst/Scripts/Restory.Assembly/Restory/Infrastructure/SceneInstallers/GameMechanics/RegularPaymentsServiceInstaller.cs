using Restory.Gameplay.RegularPayments;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class RegularPaymentsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject deliveryPaymentsServicePrefab;

		[SerializeField]
		private RegularPaymentsService prefab;

		[SerializeField]
		private GameObject regularPaymentObjectSaveLoadServicePrefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<RegularPaymentsService>().FromComponentOn(base.Container.InstantiateAndQueueForInject(prefab.gameObject)).AsSingle();
			base.Container.BindInterfacesAndSelfTo<DeliveryPaymentsService>().FromComponentOn(base.Container.InstantiateAndQueueForInject(deliveryPaymentsServicePrefab)).AsSingle();
			base.Container.BindInterfacesAndSelfTo<RegularPaymentObjectSaveLoadService>().FromComponentOn(base.Container.InstantiateAndQueueForInject(regularPaymentObjectSaveLoadServicePrefab)).AsSingle();
			base.Container.BindInterfacesTo<DeliveryPaymentsServiceLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<RegularPaymentObjectRegistry>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<RegularPaymentObjectService>().FromNew().AsSingle();
		}
	}
}
