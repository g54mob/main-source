using System;
using Restory.ObjectPools;
using Restory.UI.Presenters.Metrics;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public class GUI_MetricsInstaller : Installer
	{
		[SerializeField]
		private GameObject ratingScoreNotificationCanvasPrefab;

		[SerializeField]
		private GameObject ratingScoreNotificationPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().WithArguments(ratingScoreNotificationPrefab)
				.WhenInjectedInto<GUI_MetricScoreNotificationCanvas>();
			base.Container.Bind<GUI_MetricScoreNotificationCanvas>().FromComponentInNewPrefab(ratingScoreNotificationCanvasPrefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
