using Restory.Utils;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class ApplicationFocusDetectionServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject applicationFocusDetectorPrefab;

		public override void InstallBindings()
		{
			InstallApplicationFocusDetectionService();
			InstallApplicationQuitDetectionService();
		}

		private void InstallApplicationQuitDetectionService()
		{
			base.Container.Bind<ApplicationQuitDetectionService>().FromNewComponentOnNewGameObject().AsSingle();
			base.Container.BindInterfacesAndSelfTo<ApplicationQuitStartObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<ApplicationQuitEndObserver>().AsSingle().CopyIntoAllSubContainers();
		}

		private void InstallApplicationFocusDetectionService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(applicationFocusDetectorPrefab);
			base.Container.BindInterfacesAndSelfTo<ApplicationFocusDetectionService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ApplicationGetFocusObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<ApplicationLostFocusObserver>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
