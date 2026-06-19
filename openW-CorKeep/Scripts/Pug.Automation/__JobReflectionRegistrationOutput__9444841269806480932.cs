using System;
using Pug.Automation;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__9444841269806480932
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<AvailableRecipesFromContentBundlesSystem.UpdateAvailableRecipesJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationCraftingSystem.PugAutomationCraftJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationCritterCatchingSystem.CritterCatchingJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationExtractionSystem.ExtractJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationFishingSystem.FishingJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationIncinerateSystem.IncinerateJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationStartCraftSystem.UpdateCraftingTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationStartCritterCatchingSystem.UpdateCritterCatchingTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationStartExtractSystem.UpdateExtractionTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationStartFishingSystem.UpdateFishingTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationStartIncinerateSystem.UpdateIncinerationTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateBigEntityIsDisabledJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateMoverTimerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.CycleEnabledMoversJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.EnableSharedMoversJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateEnabledMoveeJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateDisabledMoveeJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.MoveeMergeJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.PlanterCheckPlantStateChangedJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.PlaceInStorageJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.PlantJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.StorageChangeCheckJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateMinerJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.MiningMineablesJob>();
			IJobExtensions.EarlyJobInit<PugAutomationSystem.ApplyTileDamageJob>();
			IJobExtensions.EarlyJobInit<PugAutomationSystem.DropPlacedJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.MoverFilterUpdateJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.MoverMoveAndPickupJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.MoverHarvestJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.DeactivateSharedMoversOnMoverOrPickupJob>();
			IJobExtensions.EarlyJobInit<PugAutomationSystem.SetNewMoveePositionJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateMoveeBigEntityJob>();
			JobChunkExtensions.EarlyJobInit<PugAutomationSystem.UpdateSyncedOrchestratorFieldsJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricityInstantiateSystem.PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<PugElectricityInstantiateSystem.PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<PugElectricityInstantiateSystem.PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job>();
			JobChunkExtensions.EarlyJobInit<PugElectricityInstantiateSystem.PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.GetElectricityTriggerJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.GetElectricitySourcesJob>();
			IJobExtensions.EarlyJobInit<PugElectricitySystem.SortElectricityTriggersJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.ComputeConnectionRelevancyJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.GetRelevantConnectionsJob>();
			IJobExtensions.EarlyJobInit<PugElectricitySystem.BFSJob>();
			IJobExtensions.EarlyJobInit<PugElectricitySystem.WritebackJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.DelayCircuitJob>();
			JobChunkExtensions.EarlyJobInit<PugElectricitySystem.LogicCircuitJob>();
			JobChunkExtensions.EarlyJobInit<TriggerCrafterChangedSystem.TriggerCrafterUpdateOnChangeJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
