using System;
using Kitchen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Entities.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__4007917313
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<MovePlayersToStartTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(MovePlayersToStartTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<DespawnCustomerGroupsTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(DespawnCustomerGroupsTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<LoopPlayersOutOfBounds._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(LoopPlayersOutOfBounds._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<TutorialBubbleView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(TutorialBubbleView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		EarlyInitHelpers.AddEarlyInitFunction(CreateJobReflectionData);
	}
}
