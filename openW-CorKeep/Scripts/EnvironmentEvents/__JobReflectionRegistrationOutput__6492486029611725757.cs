using System;
using EnvironmentEvents;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__6492486029611725757
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<EnvironmentEventSystem.EnvironmentEventJob>();
			JobChunkExtensions.EarlyJobInit<TriggerEnvironmentEventOnDeathSystem.TriggerEnvironmentEventOnDeathJob>();
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
