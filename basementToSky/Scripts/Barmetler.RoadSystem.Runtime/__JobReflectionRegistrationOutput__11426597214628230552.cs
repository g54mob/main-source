using System;
using Barmetler;
using Barmetler.RoadSystem;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__11426597214628230552
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<AStar.FindShortestPathJob>();
			IJobExtensions.EarlyJobInit<Bezier.GetEvenlySpacedPointsBurstJob>();
			IJobExtensions.EarlyJobInit<RoadMeshGenerator.GenerateRoadMeshV2Job>();
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
