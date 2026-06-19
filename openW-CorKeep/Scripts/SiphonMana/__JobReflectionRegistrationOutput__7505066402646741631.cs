using System;
using SiphonMana;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__7505066402646741631
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<SiphonManaSystem.SiphonManaStateTargetConnectJob>();
			JobChunkExtensions.EarlyJobInit<SiphonManaSystem.SiphonManaJob>();
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
