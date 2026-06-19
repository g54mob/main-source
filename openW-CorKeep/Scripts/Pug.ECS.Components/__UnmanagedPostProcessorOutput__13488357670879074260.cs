using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.ECS.Components.Generated;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__13488357670879074260
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1A_0024PostfixBurstDelegate>(__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1B_0024PostfixBurstDelegate>(__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1D_0024PostfixBurstDelegate>(__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1E_0024PostfixBurstDelegate>(__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_00001A1D_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_00001A1E_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ClientInputDataInputBufferDataSendCommandSystem), BurstRuntime.GetHashCode64<ClientInputDataInputBufferDataSendCommandSystem>(), ClientInputDataInputBufferDataSendCommandSystem.__codegen__OnCreate, ClientInputDataInputBufferDataSendCommandSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.ClientInputDataInputBufferDataSendCommandSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ClientInputDataInputBufferDataReceiveCommandSystem), BurstRuntime.GetHashCode64<ClientInputDataInputBufferDataReceiveCommandSystem>(), ClientInputDataInputBufferDataReceiveCommandSystem.__codegen__OnCreate, ClientInputDataInputBufferDataReceiveCommandSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.ClientInputDataInputBufferDataReceiveCommandSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ClientInputDataInputBufferDataCompareCommandSystem), BurstRuntime.GetHashCode64<ClientInputDataInputBufferDataCompareCommandSystem>(), ClientInputDataInputBufferDataCompareCommandSystem.__codegen__OnCreate, ClientInputDataInputBufferDataCompareCommandSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.ClientInputDataInputBufferDataCompareCommandSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(GhostComponentSerializerRegistrationSystem), BurstRuntime.GetHashCode64<GhostComponentSerializerRegistrationSystem>(), GhostComponentSerializerRegistrationSystem.__codegen__OnCreate, GhostComponentSerializerRegistrationSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.GhostComponentSerializerRegistrationSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(BreakCrystalMeteorRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<BreakCrystalMeteorRPCRpcCommandRequestSystem>(), BreakCrystalMeteorRPCRpcCommandRequestSystem.__codegen__OnCreate, BreakCrystalMeteorRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.BreakCrystalMeteorRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(StartGameRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<StartGameRPCRpcCommandRequestSystem>(), StartGameRPCRpcCommandRequestSystem.__codegen__OnCreate, StartGameRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.StartGameRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(PlayerConnectRequestRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<PlayerConnectRequestRPCRpcCommandRequestSystem>(), PlayerConnectRequestRPCRpcCommandRequestSystem.__codegen__OnCreate, PlayerConnectRequestRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.PlayerConnectRequestRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(PlayerConnectResponseRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<PlayerConnectResponseRPCRpcCommandRequestSystem>(), PlayerConnectResponseRPCRpcCommandRequestSystem.__codegen__OnCreate, PlayerConnectResponseRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.PlayerConnectResponseRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ModInfoRequestRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<ModInfoRequestRPCRpcCommandRequestSystem>(), ModInfoRequestRPCRpcCommandRequestSystem.__codegen__OnCreate, ModInfoRequestRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.ModInfoRequestRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ModInfoRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<ModInfoRPCRpcCommandRequestSystem>(), ModInfoRPCRpcCommandRequestSystem.__codegen__OnCreate, ModInfoRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.ModInfoRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(NetworkCommMessageRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<NetworkCommMessageRPCRpcCommandRequestSystem>(), NetworkCommMessageRPCRpcCommandRequestSystem.__codegen__OnCreate, NetworkCommMessageRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.NetworkCommMessageRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(NetworkCommDataMessageRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<NetworkCommDataMessageRPCRpcCommandRequestSystem>(), NetworkCommDataMessageRPCRpcCommandRequestSystem.__codegen__OnCreate, NetworkCommDataMessageRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.NetworkCommDataMessageRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(UIInputActionDataRPCRpcCommandRequestSystem), BurstRuntime.GetHashCode64<UIInputActionDataRPCRpcCommandRequestSystem>(), UIInputActionDataRPCRpcCommandRequestSystem.__codegen__OnCreate, UIInputActionDataRPCRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.ECS.Components.Generated.UIInputActionDataRPCRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>), BurstRuntime.GetHashCode64<ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>>(), __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate, __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate, null, null, null, __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreateForCompiler, "Unity.NetCode.ApplyCurrentInputBufferElementToInputDataSystem`2<ClientInputData,Pug.ECS.Components.Generated.ClientInputDataEventHelper>", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>), BurstRuntime.GetHashCode64<CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>>(), __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate, __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate, null, null, null, __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreateForCompiler, "Unity.NetCode.CopyInputToCommandBufferSystem`2<ClientInputData,Pug.ECS.Components.Generated.ClientInputDataEventHelper>", 3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_ApplyCurrentInputBufferElementToInputDataSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__Unity_NetCode_CopyInputToCommandBufferSystem_2_ClientInputData_Pug_ECS_Components_Generated_ClientInputDataEventHelper__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
