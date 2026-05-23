using System;
using NGS.MeshFusionPro;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__1097108344
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<JobsMeshMoverLW.MovePartsJob>();
			IJobExtensions.EarlyJobInit<JobsMeshMoverLW.RecalculateBoundsJob>();
			IJobParallelForExtensions.EarlyJobInit<JobsMeshMoverSTD.MovePartsJob>();
			IJobExtensions.EarlyJobInit<JobsMeshMoverSTD.RecalculateBoundsJob>();
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
