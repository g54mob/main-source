using Restory.Gameplay.Delivery;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DeliveryServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DeliveryService deliveryServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(deliveryServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DeliveryService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
