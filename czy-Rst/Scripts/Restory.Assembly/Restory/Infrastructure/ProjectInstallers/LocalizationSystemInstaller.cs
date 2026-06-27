using Restory.Data.Localization;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class LocalizationSystemInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject localizationSystemPrefab;

		public override void InstallBindings()
		{
			InstallLocalizationSystem();
		}

		private void InstallLocalizationSystem()
		{
			LocalizationSystem component = base.Container.InstantiateAndQueueForInject(localizationSystemPrefab).GetComponent<LocalizationSystem>();
			base.Container.Bind(typeof(LocalizationSystem), typeof(IInitializable)).FromInstance(component).AsSingle();
		}
	}
}
