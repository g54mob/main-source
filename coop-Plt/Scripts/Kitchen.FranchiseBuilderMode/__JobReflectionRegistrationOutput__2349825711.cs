using System;
using Kitchen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Entities.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2349825711
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<CardPedestalView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(CardPedestalView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<LoopPlayersOutOfBoundsTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(LoopPlayersOutOfBoundsTutorial._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<MovePlayersToStartFranchiseBuilder._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(MovePlayersToStartFranchiseBuilder._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<SetInteractionModeBuilder._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(SetInteractionModeBuilder._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<CreateFranchiseTextView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex5)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex5, typeof(CreateFranchiseTextView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<CreateFranchiseTextView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>();
		}
		catch (Exception ex6)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex6, typeof(CreateFranchiseTextView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob1));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		EarlyInitHelpers.AddEarlyInitFunction(CreateJobReflectionData);
	}
}
