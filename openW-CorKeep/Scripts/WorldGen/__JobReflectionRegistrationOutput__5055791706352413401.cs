using System;
using PugWorldGen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using WorldGen;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__5055791706352413401
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<LegacySpawnCustomSceneSystem.LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<LegacySpawnEnvironmentObjectInNewAreaSystem.LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<LegacySpawnEnvironmentObjectInNewAreaSystem.LegacySpawnEnvironmentObjectInNewAreaSystem_4477599E_LambdaJob_1_Job>();
			IJobExtensions.EarlyJobInit<LegacySpawnProceduralTextureSystem.GetUnsetPositionsJob>();
			IJobExtensions.EarlyJobInit<LegacySpawnProceduralTextureSystem.GenerateSubmapFromTexturesJob>();
			JobChunkExtensions.EarlyJobInit<LegacySpawnProceduralTextureSystem.LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job>();
			IJobExtensions.EarlyJobInit<SpawnProceduralTerrainSystem.FindSetPositionsJob>();
			IJobExtensions.EarlyJobInit<SpawnProceduralTerrainSystem.UpdateSubMapJob>();
			JobChunkExtensions.EarlyJobInit<SpawnRootsInNewAreasSystem.SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<SpawnTerritoriesInNewAreasSystem.SpawnJob>();
			JobChunkExtensions.EarlyJobInit<SpawnTerritoriesInNewAreasSystem.CleanupJob>();
			JobChunkExtensions.EarlyJobInit<SpawnTerritoriesInNewAreasSystem.RemoveCompletedSpawnCellJob>();
			JobChunkExtensions.EarlyJobInit<LegacyDungeonSpawnSystem.LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<LegacyDungeonSpawnSystem.LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<LegacySpawnRootsInNewAreasSystem.LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<LegacySpawnTerritoriesInNewAreasSystem.LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<SpawnDungeonAndSceneSystem.SpawnJob>();
			JobChunkExtensions.EarlyJobInit<SpawnDungeonAndSceneSystem.AfterSpawnCleanupJob>();
			JobChunkExtensions.EarlyJobInit<SpawnDungeonAndSceneSystem.ForwardToProceduralSpawnJob>();
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
