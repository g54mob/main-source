using System;
using FixedTickInterpolation;
using PlacementIndicator;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__13036389116312022735
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<PlacementIndicatorMoveByControllerSystem.PlacementIndicatorMoveByControllerJob>();
			JobChunkExtensions.EarlyJobInit<PlacementIndicatorVisualStateUpdateSystem.UpdateMortarPlacementJob>();
			JobChunkExtensions.EarlyJobInit<FixedTickInterpolationSwapSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>.SwapInterpolatedJob>();
			JobChunkExtensions.EarlyJobInit<FixedTickInterpolationSmoothingSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>.SmoothJob>();
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
