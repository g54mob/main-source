using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Interaction.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	[UpdateInGroup(typeof(GhostComponentSerializerCollectionSystemGroup))]
	[CreateAfter(typeof(GhostComponentSerializerCollectionSystemGroup))]
	[CreateBefore(typeof(DefaultVariantSystemGroup))]
	[BakingVersion(true)]
	public struct GhostComponentSerializerRegistrationSystem : ISystem, IGhostComponentSerializerRegistration
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000003F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000003F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000003F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
				__codegen__OnUpdate_0024BurstManaged(self, state);
			}
		}

		public void OnCreate(ref SystemState state)
		{
			using EntityQueryBuilder queriesDesc = new EntityQueryBuilder(Allocator.Temp).WithAllRW<GhostComponentSerializerCollectionData>();
			using EntityQuery entityQuery = state.EntityManager.CreateEntityQuery(in queriesDesc);
			ref GhostComponentSerializerCollectionData valueRW = ref entityQuery.GetSingletonRW<GhostComponentSerializerCollectionData>().ValueRW;
			ComponentTypeSerializationStrategy componentTypeSerializationStrategy = default(ComponentTypeSerializationStrategy);
			componentTypeSerializationStrategy = new ComponentTypeSerializationStrategy
			{
				DisplayName = "Interaction.InteractionCooldownCD",
				Component = ComponentType.ReadWrite<InteractionCooldownCD>(),
				Hash = 7776383813045168068uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.AllClients,
				SendForChildEntities = 0,
				IsDefaultSerializer = 1,
				IsInputComponent = 0,
				IsInputBuffer = 0,
				IsTestVariant = 0,
				HasDontSupportPrefabOverridesAttribute = 0
			};
			valueRW.AddSerializationStrategy(ref componentTypeSerializationStrategy);
			componentTypeSerializationStrategy = new ComponentTypeSerializationStrategy
			{
				DisplayName = "Interaction.InteractorCD",
				Component = ComponentType.ReadWrite<InteractorCD>(),
				Hash = 14847500600468005460uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.AllClients,
				SendForChildEntities = 0,
				IsDefaultSerializer = 1,
				IsInputComponent = 0,
				IsInputBuffer = 0,
				IsTestVariant = 0,
				HasDontSupportPrefabOverridesAttribute = 0
			};
			valueRW.AddSerializationStrategy(ref componentTypeSerializationStrategy);
			componentTypeSerializationStrategy = new ComponentTypeSerializationStrategy
			{
				DisplayName = "Interaction.LocalInteractorCD",
				Component = ComponentType.ReadWrite<LocalInteractorCD>(),
				Hash = 5477193915073681118uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.PredictedClient,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
				SendForChildEntities = 0,
				IsDefaultSerializer = 1,
				IsInputComponent = 0,
				IsInputBuffer = 0,
				IsTestVariant = 0,
				HasDontSupportPrefabOverridesAttribute = 0
			};
			valueRW.AddSerializationStrategy(ref componentTypeSerializationStrategy);
			valueRW.AddSerializer(InteractionCooldownCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(InteractorCDGhostComponentSerializer.GetState(ref state));
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			state.Enabled = false;
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((GhostComponentSerializerRegistrationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000003F_0024BurstDirectCall.Invoke(self, state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((GhostComponentSerializerRegistrationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
