using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class ReadWriteDataServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject writeReadServicePrefab;

		[SerializeField]
		private GameObject writeReadIndicationCanvasPrefab;

		[SerializeField]
		private GameObject corruptedDataServicePrefab;

		[SerializeField]
		private GameObject diskSpaceServicePrefab;

		[SerializeField]
		private SaveSystemSettings saveSystemSettings;

		public override void InstallBindings()
		{
			InstallSaveFileNameGenerator();
			InstallSaveFileNameSorter();
			InstallSaveFileVersionReader();
			InstallSaveFileCompatibilityChecker();
			InstallSaveSystem();
			InstallCorruptedDataService();
			InstallDiskSpaceService();
			base.Container.BindFactory<LastSaveLoader, LastSaveLoader.Factory>().AsSingle();
		}

		private void InstallCorruptedDataService()
		{
			CorruptedDataService component = base.Container.InstantiateAndQueueForInject(corruptedDataServicePrefab).GetComponent<CorruptedDataService>();
			base.Container.BindInterfacesAndSelfTo<CorruptedDataService>().FromInstance(component).AsSingle();
		}

		private void InstallDiskSpaceService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(diskSpaceServicePrefab);
			base.Container.Bind<IDiskSpaceService>().To<DiskSpaceService>().FromComponentOn(gameObject)
				.AsSingle();
		}

		private void InstallSaveFileNameGenerator()
		{
			base.Container.Bind<SaveFileNameGenerator>().AsSingle().WithArguments(saveSystemSettings);
		}

		private void InstallSaveFileNameSorter()
		{
			base.Container.BindInterfacesAndSelfTo<SaveFileNameSorter>().AsSingle().WithArguments(saveSystemSettings);
		}

		private void InstallSaveFileVersionReader()
		{
			base.Container.Bind<SaveFileVersionReader>().FromNew().AsSingle();
		}

		private void InstallSaveFileCompatibilityChecker()
		{
			base.Container.BindInterfacesAndSelfTo<SaveFileCompatibilityChecker>().FromNew().AsSingle();
		}

		private void InstallSaveSystem()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(writeReadServicePrefab);
			base.Container.Bind(typeof(IReadWriteDataService), typeof(IGameplayReadOnlyDataService)).To<GlobalReadWriteDataService>().FromComponentOn(gameObject)
				.AsSingle();
		}
	}
}
