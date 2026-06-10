using System;
using NGS.MeshFusionPro;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__3245296533
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<JobsMeshMoverLW.MovePartsJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(JobsMeshMoverLW.MovePartsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<JobsMeshMoverLW.RecalculateBoundsJob>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(JobsMeshMoverLW.RecalculateBoundsJob));
		}
		try
		{
			IJobParallelForExtensions.EarlyJobInit<JobsMeshMoverSTD.MovePartsJob>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(JobsMeshMoverSTD.MovePartsJob));
		}
		try
		{
			IJobExtensions.EarlyJobInit<JobsMeshMoverSTD.RecalculateBoundsJob>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(JobsMeshMoverSTD.RecalculateBoundsJob));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
