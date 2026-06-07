using System;
using Pathfinding;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2607421769
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForBatchExtensions.EarlyJobInit<NavmeshEdges.JobCalculateObstacles>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(NavmeshEdges.JobCalculateObstacles));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
