using System;
using Restory.Data.Analytics;
using Restory.Data.GameConfigs;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class AnalyticsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject analyticsConsentCheckingServicePrefab;

		public override void InstallBindings()
		{
			InstallAnalytics();
			InstallAnalyticsConsentCheckingService();
		}

		private void InstallAnalytics()
		{
			Type type = (base.Container.Resolve<GameConfig>().AnalyticsSupportedPlatforms.GetSupportedStatus() ? typeof(RestoryAnalyticsService) : typeof(StubAnalyticsService));
			base.Container.BindInterfacesAndSelfTo(type).AsSingle();
		}

		private void InstallAnalyticsConsentCheckingService()
		{
			base.Container.BindInterfacesAndSelfTo<AnalyticsConsentCheckingService>().FromComponentInNewPrefab(analyticsConsentCheckingServicePrefab).AsSingle()
				.NonLazy();
		}
	}
}
