using System;
using Pug.ECS.Components.Generated;
using Unity.Entities;
using Unity.Jobs;
using Unity.NetCode;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__13488357670879074260
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<ClientInputDataInputBufferDataSendCommandSystem.SendJob>();
			JobChunkExtensions.EarlyJobInit<ClientInputDataInputBufferDataReceiveCommandSystem.ReceiveJob>();
			JobChunkExtensions.EarlyJobInit<ClientInputDataInputBufferDataCompareCommandSystem.CompareJob>();
			JobChunkExtensions.EarlyJobInit<BreakCrystalMeteorRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<StartGameRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<PlayerConnectRequestRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<PlayerConnectResponseRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<ModInfoRequestRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<ModInfoRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<NetworkCommMessageRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<NetworkCommDataMessageRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<UIInputActionDataRPCRpcCommandRequestSystem.SendRpc>();
			JobChunkExtensions.EarlyJobInit<ApplyInputDataFromBufferJob<ClientInputData, ClientInputDataEventHelper>>();
			JobChunkExtensions.EarlyJobInit<CopyInputToBufferJob<ClientInputData, ClientInputDataEventHelper>>();
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
