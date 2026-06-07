using System;
using GPUInstancerPro.PrefabModule;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__6368090013526615711
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForTransformExtensions.EarlyJobInit<GPUIAutoUpdateTransformsJob>();
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
