using System;
using Pug.Dev.Generated;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__13644973290699417700
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<MapDebugExtractSubmapSystem.MapDebugExtractSubmapSystem_73E821C2_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<MapDebugServerRunSystem.MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job>();
			IJobExtensions.EarlyJobInit<MapDebugServerRunSystem.MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<MapDebugClientRunSystem.MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job>();
			JobChunkExtensions.EarlyJobInit<MapDebugClientRunSystem.MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job>();
			JobChunkExtensions.EarlyJobInit<GoToObjectRequestRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<GoToObjectResponseRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<RevealWholeMapRequestRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<RevealWholeMapProgressUpdateRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<RegenerateTerrainRequestRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<RegenerateTerrainResponseRpcCommandRequestSystem.SendRpc>();
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
