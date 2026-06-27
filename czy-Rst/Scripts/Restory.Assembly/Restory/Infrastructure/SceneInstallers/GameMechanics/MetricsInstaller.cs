using Restory.Gameplay.Metrics;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class MetricsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject ratingsServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(ratingsServicePrefab);
			base.Container.BindInterfacesAndSelfTo<MetricsService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesTo<MetricPointsNotificationService>().FromComponentOn(gameObject).AsSingle();
			MetricTrigger[] componentsInChildren = gameObject.GetComponentsInChildren<MetricTrigger>();
			foreach (MetricTrigger metricTrigger in componentsInChildren)
			{
				base.Container.BindInterfacesTo(metricTrigger.GetType()).FromInstance(metricTrigger).AsSingle();
			}
		}
	}
}
