using Restory.Gameplay.DeliveryRandomParts;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DeliveryRandomPartsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject deliveryRandomPartsServicePrefab;

		[SerializeField]
		private DeliveryRandomPartsSettings deliveryRandomPartsSettings;

		public override void InstallBindings()
		{
			base.Container.BindInstance(deliveryRandomPartsSettings).AsSingle().WhenInjectedInto<DeliveryRandomPartsService>();
			base.Container.BindInterfacesAndSelfTo<DeliveryRandomPartsService>().FromComponentOn(base.Container.InstantiateAndQueueForInject(deliveryRandomPartsServicePrefab)).AsSingle();
			base.Container.BindInterfacesTo<DeliveryRandomPartsServiceLuaWrappers>().FromNew().AsSingle();
		}
	}
}
