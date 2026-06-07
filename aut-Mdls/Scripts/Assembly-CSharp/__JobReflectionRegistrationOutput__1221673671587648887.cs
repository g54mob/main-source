using System;
using Presentation.FactoryFloor.Culling.Jobs;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__1221673671587648887
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<TransformAnimationDeltaJob>();
			IJobParallelForTransformExtensions.EarlyJobInit<TransformMovementJob>();
			IJobParallelForExtensions.EarlyJobInit<CullingDiffJob>();
			IJobParallelForExtensions.EarlyJobInit<DistanceCullingBurstJob>();
			IJobParallelForExtensions.EarlyJobInit<FrustumCullingBurstJob>();
			IJobParallelForExtensions.EarlyJobInit<IslandCullingBurstJob>();
			IJobParallelForExtensions.EarlyJobInit<QualityLevelCullingBurstJob>();
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
