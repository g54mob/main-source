using System;
using Interaction;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__8441331062636855580
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<DisableImmuneZoneSystem.DisableImmuneZoneJob>();
			JobChunkExtensions.EarlyJobInit<DisableImmuneZoneSystem.DestroyImmunZoneJob>();
			JobChunkExtensions.EarlyJobInit<TriggerPetPetSystem.PetPetJob>();
			JobChunkExtensions.EarlyJobInit<TriggerPickupGraveSystem.TriggerPickupGraveJob>();
			JobChunkExtensions.EarlyJobInit<TriggerSetVariationSystem.TriggerSetVariationJob>();
			JobChunkExtensions.EarlyJobInit<TriggerUseControllableSystem.TriggerUseControllableJob>();
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
