using Restory.Infrastructure.ProjectServices;
using Unity.Services.Core;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class UnityServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject userReportSystemPrefab;

		public override void InstallBindings()
		{
			UnityServices.InitializeAsync();
			InstallUnityUserReportSystem();
			InstallCrashReportMetaDataCollector();
		}

		private void InstallUnityUserReportSystem()
		{
		}

		private void InstallCrashReportMetaDataCollector()
		{
			base.Container.BindFactory<GlobalGameCrashReportMetaDataCollector, GlobalGameCrashReportMetaDataCollector.Factory>();
			base.Container.BindInterfacesAndSelfTo<GlobalGameCrashReportMetaDataCollector>().AsSingle();
		}
	}
}
