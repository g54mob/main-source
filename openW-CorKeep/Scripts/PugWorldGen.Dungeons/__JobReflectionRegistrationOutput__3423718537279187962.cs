using System;
using PugWorldGen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__3423718537279187962
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<DungeonAddBlockedAreasSystem.DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.ReplaceObjectsJob>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.RemoveNullObjectsJob>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.InitializeSubMapsJob>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.EnableAreaJob>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.ClearAreaJob>();
			JobChunkExtensions.EarlyJobInit<DungeonApplySpawnedObjectsSystem.SpawnObjectsJob>();
			JobChunkExtensions.EarlyJobInit<DungeonJob>();
			JobChunkExtensions.EarlyJobInit<DungeonAssignSpawnTemplateSystem.DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonFillSystem.DungeonFillSystem_260EB06F_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonFillSystem.DungeonFillSystem_260EB06F_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonGenerateRoomsSystem.DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Job>();
			IJobExtensions.EarlyJobInit<DungeonGenerateRoomsSystem.DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonPlaceCustomScenesSystem.DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<DungeonPlacePathsSystem.GeneratePathsJob>();
			JobChunkExtensions.EarlyJobInit<DungeonPlaceRoomsSystem.DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Job>();
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
