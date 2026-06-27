using Restory.Gameplay.WorkshopRatings;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class WorkshopRatingsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject workshopRatingsServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(workshopRatingsServicePrefab);
			base.Container.BindInterfacesAndSelfTo<WorkshopRatingsService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<WorkshopRatingsAppOpenStateComponent>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ReviewForOrderService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
