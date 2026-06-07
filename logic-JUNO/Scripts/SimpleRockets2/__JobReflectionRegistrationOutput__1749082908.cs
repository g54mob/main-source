using System;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Jobs;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__1749082908
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<ManagedJobParallelFor>();
			IJobParallelForExtensions.EarlyJobInit<FuselageSmoother.CopyMeshJob>();
			IJobParallelForExtensions.EarlyJobInit<FuselageSmoother.SmoothingJob>();
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
