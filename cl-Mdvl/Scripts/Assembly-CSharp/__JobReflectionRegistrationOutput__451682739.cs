using System;
using FIMSpace.FOptimizing;
using NSMedieval.Fire;
using NSMedieval.Village.Map;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__451682739
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<OptimizersManager.CullingDelayJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(OptimizersManager.CullingDelayJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<OptimizersManager.CreateRayCommandsJob>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(OptimizersManager.CreateRayCommandsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<OptimizersManager.CreateTransparentRayCommandsJob>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(OptimizersManager.CreateTransparentRayCommandsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<OptimizersManager.GetResultsJob>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(OptimizersManager.GetResultsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<AddToBuildingsInRangeJob>();
		}
		catch (Exception ex5)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex5, typeof(AddToBuildingsInRangeJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<FireLogicJob>();
		}
		catch (Exception ex6)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex6, typeof(FireLogicJob));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
