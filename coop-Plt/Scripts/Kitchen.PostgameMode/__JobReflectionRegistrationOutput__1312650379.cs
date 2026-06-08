using System;
using Kitchen;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Entities.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__1312650379
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<GrantExpView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex, typeof(GrantExpView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<NewsItemView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex2)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex2, typeof(NewsItemView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<NewsUIView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex3)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex3, typeof(NewsUIView.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
		try
		{
			JobChunkExtensions.EarlyJobInit<CardsSubview.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>();
		}
		catch (Exception ex4)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex4, typeof(CardsSubview.UpdateView._003C_003Ec__DisplayClass_OnUpdate_LambdaJob0));
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		EarlyInitHelpers.AddEarlyInitFunction(CreateJobReflectionData);
	}
}
