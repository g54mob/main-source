using System;
using Kitchen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Entities.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2293194624
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<ResearchMovePlayersToStart._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(ResearchMovePlayersToStart._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<UpdateAcceptsResearch._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(UpdateAcceptsResearch._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		EarlyInitHelpers.AddEarlyInitFunction(CreateJobReflectionData);
	}
}
