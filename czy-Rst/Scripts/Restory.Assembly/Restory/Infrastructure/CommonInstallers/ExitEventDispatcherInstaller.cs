using Restory.EventSystems.ExitEvents;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class ExitEventDispatcherInstaller : MonoInstaller
	{
		[SerializeField]
		private ExitEventDispatcher exitEventDispatcherPrefab;

		[SerializeField]
		private ExitEventSettings exitEventSettings;

		public override void InstallBindings()
		{
			InstallExitEventDispatcher();
			InstallExitEventSettings();
		}

		private void InstallExitEventDispatcher()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(exitEventDispatcherPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<ExitEventDispatcher>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallExitEventSettings()
		{
			base.Container.Bind<ExitEventSettings>().FromInstance(Object.Instantiate(exitEventSettings)).AsSingle();
		}
	}
}
