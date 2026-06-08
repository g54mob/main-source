using System;
using Kitchen.ChefConnector.Commands;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Entities.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__2870592777
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<Visit._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(Visit._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<Visit._003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(Visit._003C_003Ec__DisplayClass_OnUpdate_LambdaJob1));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		EarlyInitHelpers.AddEarlyInitFunction(CreateJobReflectionData);
	}
}
