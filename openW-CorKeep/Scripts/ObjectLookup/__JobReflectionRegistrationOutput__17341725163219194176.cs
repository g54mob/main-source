using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__17341725163219194176
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<ObjectLookupServerSystem.AddUnloadedObjectsToLookupJob>();
			JobChunkExtensions.EarlyJobInit<ObjectLookupServerSystem.RemoveLoadedObjectsToLookupJob>();
			JobChunkExtensions.EarlyJobInit<ObjectLookupServerSystem.AddCreatedEntitiesToLookupJob>();
			JobChunkExtensions.EarlyJobInit<ObjectLookupServerSystem.RemoveDestroyedEntitiesToLookupJob>();
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
