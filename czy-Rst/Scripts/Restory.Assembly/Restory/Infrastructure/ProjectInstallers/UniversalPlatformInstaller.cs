using Restory.UniversalPlatform;
using Restory.UniversalPlatform.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class UniversalPlatformInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject platformManagerPrefab;

		[SerializeField]
		private GameObject achievementsManagerPrefab;

		public override void InstallBindings()
		{
			InstallPlatformManager();
			InstallAchievementsManager();
		}

		private void InstallPlatformManager()
		{
			PlatformManager componentInChildren = base.Container.InstantiateAndQueueForInject(platformManagerPrefab).GetComponentInChildren<PlatformManager>();
			base.Container.BindInterfacesAndSelfTo<PlatformManager>().FromInstance(componentInChildren).AsSingle();
			base.Container.BindInterfacesAndSelfTo<PlatformManagerMainInitializationObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<PlatformManagerProfileInitializationObserver>().AsSingle().CopyIntoAllSubContainers();
		}

		private void InstallAchievementsManager()
		{
			PlatformAchievementsManager componentInChildren = base.Container.InstantiateAndQueueForInject(achievementsManagerPrefab).GetComponentInChildren<PlatformAchievementsManager>();
			base.Container.BindInterfacesAndSelfTo<PlatformAchievementsManager>().FromInstance(componentInChildren).AsSingle();
			base.Container.BindInterfacesAndSelfTo<PlatformAchievementsManagerInitializationObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<PlatformAchievementsManagerAchievementsReceivedObserver>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
