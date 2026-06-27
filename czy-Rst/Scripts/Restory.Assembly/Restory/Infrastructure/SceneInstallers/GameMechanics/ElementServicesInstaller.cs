using Restory.Data.Elements.Condition;
using Restory.Data.Elements.ElementTypes;
using Restory.Data.Outline;
using Restory.Data.Projections;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class ElementServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private ElementService elementServicePrefab;

		[SerializeField]
		private ElementProjectionHighlighter elementProjectionHighlighterPrefab;

		[SerializeField]
		private ElementMarkerService elementMarkerServicePrefab;

		[SerializeField]
		private ElementProjection elementProjectionPrefab;

		[SerializeField]
		private ElementProjection smallElementProjectionPrefab;

		[SerializeField]
		private AssembleProjectionSettings assembleProjectionSettings;

		[SerializeField]
		private ElementOutlineSettings elementOutlineSettings;

		[SerializeField]
		private ElementConditionsMaterialsTable elementConditionsMaterialsTable;

		[SerializeField]
		private ElementMaterialTypesMalfunctionsTable elementMaterialTypesMalfunctionsTable;

		[SerializeField]
		private DirtTypesMaskPresetsTable dirtTypesMaskPresetsTable;

		[SerializeField]
		private GameObject competitionElementPlacementObjectPrefab;

		public override void InstallBindings()
		{
			InstallElementServices();
			InstallElementProjectionHighlighter();
			InstallElementProjectionFactory();
			InstallAssemblePositionAdjuster();
			InstallPlacementPositionFinder();
			InstallElementPositionControllers();
			InstallPlacedElementsHandler();
			InstallCleanedElementDestinationHandler();
			InstallCompetitionElementsDestinationHandler();
			InstallSettings();
			InstallElementConditionMaterialsProvider();
			InstallElementDirtMaskPresetSelectionService();
			InstallElementDetectionRegistrator();
			InstallElementMarkerService();
		}

		private void InstallElementServices()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(elementServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<ElementService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<ElementFactory>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<StorageElasticElementsDropService>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<StorageElasticElementsDragService>().FromNew().AsSingle();
		}

		private void InstallElementProjectionHighlighter()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(elementProjectionHighlighterPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<ElementProjectionHighlighter>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallElementProjectionFactory()
		{
			base.Container.Bind<ElementProjectionPool>().FromNew().AsSingle()
				.WithArguments(elementProjectionPrefab.gameObject)
				.WhenInjectedInto<ElementProjectionFactory>();
			base.Container.Bind<SmallElementProjectionPool>().FromNew().AsSingle()
				.WithArguments(smallElementProjectionPrefab.gameObject)
				.WhenInjectedInto<ElementProjectionFactory>();
			base.Container.Bind<ElementProjectionFactory>().FromNew().AsSingle();
		}

		private void InstallAssemblePositionAdjuster()
		{
			base.Container.BindInterfacesAndSelfTo<AssemblePositionAdjuster>().AsSingle();
		}

		private void InstallPlacementPositionFinder()
		{
			base.Container.BindInterfacesAndSelfTo<PlacementPositionFinder>().AsSingle();
		}

		private void InstallElementPositionControllers()
		{
			base.Container.BindInterfacesAndSelfTo<ElementPlacementController>().AsSingle();
			base.Container.BindInterfacesAndSelfTo<ElementAssembleController>().AsSingle();
		}

		private void InstallPlacedElementsHandler()
		{
			base.Container.BindInterfacesAndSelfTo<PlacedElementsHandler>().AsSingle();
		}

		private void InstallCleanedElementDestinationHandler()
		{
			base.Container.BindInterfacesAndSelfTo<CleanedElementDestinationHandler>().AsSingle();
		}

		private void InstallCompetitionElementsDestinationHandler()
		{
			base.Container.BindInterfacesAndSelfTo<CompetitionElementPositionObjectsPool>().FromNew().AsSingle()
				.WithArguments(competitionElementPlacementObjectPrefab)
				.WhenInjectedInto<CompetitionElementsPositioner>();
			base.Container.BindInterfacesAndSelfTo<CompetitionElementsPositioner>().FromNew().AsSingle();
		}

		private void InstallSettings()
		{
			base.Container.Bind<AssembleProjectionSettings>().FromInstance(Object.Instantiate(assembleProjectionSettings)).AsSingle();
			base.Container.Bind<ElementOutlineSettings>().FromInstance(Object.Instantiate(elementOutlineSettings)).AsSingle();
		}

		private void InstallElementConditionMaterialsProvider()
		{
			base.Container.Bind<ElementConditionsMaterialsProvidingService>().FromNew().AsSingle()
				.WithArguments(elementConditionsMaterialsTable);
		}

		private void InstallElementDirtMaskPresetSelectionService()
		{
			base.Container.Bind<ElementDirtMaskPresetSelectionService>().FromNew().AsSingle()
				.WithArguments(elementMaterialTypesMalfunctionsTable, dirtTypesMaskPresetsTable);
		}

		private void InstallElementDetectionRegistrator()
		{
			base.Container.BindInterfacesAndSelfTo<ElementDetectionRegistrator>().AsSingle();
		}

		private void InstallElementMarkerService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(elementMarkerServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<ElementMarkerService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
