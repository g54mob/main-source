using System;
using ModApi.Common.Jobs;
using ModApi.Planet;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__1044416493
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<PlanetCubemapUtility.ConvertColorTextureToByteArrayJob>();
			IJobExtensions.EarlyJobInit<PlanetCubemapUtility.ConvertNormalTextureToByteArrayJob>();
			IJobExtensions.EarlyJobInit<PlanetCubemapUtility.DownsampleJob>();
			IJobExtensions.EarlyJobInit<PlanetCubemapUtility.DownsampleNormalsJob>();
			IJobExtensions.EarlyJobInit<PlanetCubemapUtility.GenerateNormalsJob>();
			IJobExtensions.EarlyJobInit<ManagedActionJob>();
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
