using System;
using ContainedMiniSim;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__7721715294731933106
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<AquariumFishMovementSystem.AquariumFishMovementJob>();
			JobChunkExtensions.EarlyJobInit<CacheContainedMiniSimVisualDataSystem.CacheContainedMiniSimVisualDataJob>();
			JobChunkExtensions.EarlyJobInit<ContainedMiniSimInitializeSystem.TerrariumCritterInitializeJob>();
			JobChunkExtensions.EarlyJobInit<TerrariumCritterMovementSystem.TerrariumCritterMovementJob>();
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
