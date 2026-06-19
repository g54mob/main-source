using System;
using Interaction;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__71765080322210029
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<ResolveInteractableActiveSystem.ResolveInteractableActiveJob>();
			JobChunkExtensions.EarlyJobInit<ResolveInteractorActiveSystem.ResolveInteractorActiveJob>();
			JobChunkExtensions.EarlyJobInit<SetInteractorInputSystem.InteractorGatherInputJob>();
			JobChunkExtensions.EarlyJobInit<ToggleClosestLocalInteractableSystem.ToggleClosestLocalInteractableJob>();
			JobChunkExtensions.EarlyJobInit<TriggerLocalInteractionSystem.TriggerLocalExitInteractionJob>();
			JobChunkExtensions.EarlyJobInit<TriggerLocalInteractionSystem.TriggerLocalUseInteractionJob>();
			JobChunkExtensions.EarlyJobInit<TriggerUseInteractionSystem.TriggerUseInteractionJob>();
			JobChunkExtensions.EarlyJobInit<UpdateSelectedInteractableSystem.RegisterNearbyInteractableToInteractorJob>();
			IJobExtensions.EarlyJobInit<UpdateSelectedInteractableSystem.FillHashMapJob>();
			JobChunkExtensions.EarlyJobInit<UpdateSelectedInteractableSystem.FindClosestValidInteractableJob>();
			JobChunkExtensions.EarlyJobInit<UpdateSelectedInteractableSystem.ChangeSelectedInteractableJob>();
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
