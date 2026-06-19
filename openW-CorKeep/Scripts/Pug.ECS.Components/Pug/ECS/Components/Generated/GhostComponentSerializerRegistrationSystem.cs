using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
using Pug.Automation;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;

namespace Pug.ECS.Components.Generated
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
		internal delegate void __codegen__OnUpdate_0000198C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000198C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000198C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
				DisplayName = "ClientInputData",
				Component = ComponentType.ReadWrite<ClientInputData>(),
				Hash = 2094285665734961426uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.AllClients,
				SendForChildEntities = 0,
				IsDefaultSerializer = 1,
				IsInputComponent = 1,
				IsInputBuffer = 0,
				IsTestVariant = 0,
				HasDontSupportPrefabOverridesAttribute = 0
			};
			valueRW.AddSerializationStrategy(ref componentTypeSerializationStrategy);
			componentTypeSerializationStrategy = new ComponentTypeSerializationStrategy
			{
				DisplayName = "Unity.NetCode.InputBufferData<ClientInputData>",
				Component = ComponentType.ReadWrite<InputBufferData<ClientInputData>>(),
				Hash = 15440339137800310364uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.AllClients,
				SendForChildEntities = 0,
				IsDefaultSerializer = 1,
				IsInputComponent = 1,
				IsInputBuffer = 0,
				IsTestVariant = 0,
				HasDontSupportPrefabOverridesAttribute = 0
			};
			valueRW.AddSerializationStrategy(ref componentTypeSerializationStrategy);
			componentTypeSerializationStrategy = new ComponentTypeSerializationStrategy
			{
				DisplayName = "ActiveCracksCD",
				Component = ComponentType.ReadWrite<ActiveCracksCD>(),
				Hash = 101376423813320092uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "AddRandomLootCD",
				Component = ComponentType.ReadWrite<AddRandomLootCD>(),
				Hash = 7882210139416596782uL,
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
				DisplayName = "AncientElectricityConnectionCD",
				Component = ComponentType.ReadWrite<AncientElectricityConnectionCD>(),
				Hash = 11678305854886934292uL,
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
				DisplayName = "AnimationOrientationCD",
				Component = ComponentType.ReadWrite<AnimationOrientationCD>(),
				Hash = 10087128587238587442uL,
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
				DisplayName = "AnimationTriggeredCD",
				Component = ComponentType.ReadWrite<AnimationTriggeredCD>(),
				Hash = 17130977708838105244uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "BirdBossHasAppearedCD",
				Component = ComponentType.ReadWrite<BirdBossHasAppearedCD>(),
				Hash = 7706597597484680042uL,
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
				DisplayName = "BeamBuffer",
				Component = ComponentType.ReadWrite<BeamBuffer>(),
				Hash = 15098878587110893786uL,
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
				DisplayName = "BossLarvaCD",
				Component = ComponentType.ReadWrite<BossLarvaCD>(),
				Hash = 1337281800963773332uL,
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
				DisplayName = "BossStatueCD",
				Component = ComponentType.ReadWrite<BossStatueCD>(),
				Hash = 14058513593979196412uL,
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
				DisplayName = "CicadaEnemyCD",
				Component = ComponentType.ReadWrite<CicadaEnemyCD>(),
				Hash = 12550489800398529212uL,
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
				DisplayName = "GiantCicadaBossCD",
				Component = ComponentType.ReadWrite<GiantCicadaBossCD>(),
				Hash = 6577423328010557572uL,
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
				DisplayName = "GiantCicadaBossHasAppearedCD",
				Component = ComponentType.ReadWrite<GiantCicadaBossHasAppearedCD>(),
				Hash = 4396088225339493436uL,
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
				DisplayName = "CicadaNymphCD",
				Component = ComponentType.ReadWrite<CicadaNymphCD>(),
				Hash = 6272509682117021020uL,
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
				DisplayName = "CoreBossSpawnCD",
				Component = ComponentType.ReadWrite<CoreBossSpawnCD>(),
				Hash = 5764182462250466660uL,
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
				DisplayName = "CoreBossCD",
				Component = ComponentType.ReadWrite<CoreBossCD>(),
				Hash = 12196185376554208686uL,
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
				DisplayName = "CoreBossOrbCD",
				Component = ComponentType.ReadWrite<CoreBossOrbCD>(),
				Hash = 15960167195874715964uL,
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
				DisplayName = "CoreBossOrbsBuffer",
				Component = ComponentType.ReadWrite<CoreBossOrbsBuffer>(),
				Hash = 2618672124585410132uL,
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
				DisplayName = "CoreBossVoidImmuneZoneBuffer",
				Component = ComponentType.ReadWrite<CoreBossVoidImmuneZoneBuffer>(),
				Hash = 1428741820419779802uL,
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
				DisplayName = "HydraBossCD",
				Component = ComponentType.ReadWrite<HydraBossCD>(),
				Hash = 1525307274730697476uL,
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
				DisplayName = "HydraBossVulnerableEntityCD",
				Component = ComponentType.ReadWrite<HydraBossVulnerableEntityCD>(),
				Hash = 16493414504716922666uL,
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
				DisplayName = "VulnerableStateCD",
				Component = ComponentType.ReadWrite<VulnerableStateCD>(),
				Hash = 15523860251389594884uL,
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
				DisplayName = "HydraBossBuriedCombatStateCD",
				Component = ComponentType.ReadWrite<HydraBossBuriedCombatStateCD>(),
				Hash = 17440102543421045148uL,
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
				DisplayName = "HydraBossBuriedRoamingStateCD",
				Component = ComponentType.ReadWrite<HydraBossBuriedRoamingStateCD>(),
				Hash = 13062236555414207314uL,
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
				DisplayName = "OctopusBossCD",
				Component = ComponentType.ReadWrite<OctopusBossCD>(),
				Hash = 12734805183593703130uL,
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
				DisplayName = "OctopusBossHasAppearedCD",
				Component = ComponentType.ReadWrite<OctopusBossHasAppearedCD>(),
				Hash = 5414740215644188690uL,
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
				DisplayName = "RobotBossCD",
				Component = ComponentType.ReadWrite<RobotBossCD>(),
				Hash = 4707385604239488412uL,
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
				DisplayName = "RobotBossLegsBuffer",
				Component = ComponentType.ReadWrite<RobotBossLegsBuffer>(),
				Hash = 7431589839372841876uL,
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
				DisplayName = "ScarabBossHasAppearedCD",
				Component = ComponentType.ReadWrite<ScarabBossHasAppearedCD>(),
				Hash = 17011097848124331900uL,
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
				DisplayName = "ScarabBossChargeStateCD",
				Component = ComponentType.ReadWrite<ScarabBossChargeStateCD>(),
				Hash = 2355749195047841586uL,
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
				DisplayName = "PhaseTransitionStateCD",
				Component = ComponentType.ReadWrite<PhaseTransitionStateCD>(),
				Hash = 11380539972314453404uL,
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
				DisplayName = "SnakeBossCD",
				Component = ComponentType.ReadWrite<SnakeBossCD>(),
				Hash = 11811076192434693660uL,
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
				DisplayName = "TheCoreCD",
				Component = ComponentType.ReadWrite<TheCoreCD>(),
				Hash = 5491319586904525566uL,
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
				DisplayName = "TitanShrineCD",
				Component = ComponentType.ReadWrite<TitanShrineCD>(),
				Hash = 17847025003510446788uL,
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
				DisplayName = "WallBossCD",
				Component = ComponentType.ReadWrite<WallBossCD>(),
				Hash = 9259816993571709076uL,
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
				DisplayName = "WallBossBufferElement",
				Component = ComponentType.ReadWrite<WallBossBufferElement>(),
				Hash = 15644665462564189486uL,
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
				DisplayName = "WallBossHeadCD",
				Component = ComponentType.ReadWrite<WallBossHeadCD>(),
				Hash = 15993247530930978388uL,
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
				DisplayName = "WallBossHeadRefCD",
				Component = ComponentType.ReadWrite<WallBossHeadRefCD>(),
				Hash = 13578476701398384382uL,
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
				DisplayName = "BreedToggleCD",
				Component = ComponentType.ReadWrite<BreedToggleCD>(),
				Hash = 1656235020325864606uL,
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
				DisplayName = "CharacterTypeCD",
				Component = ComponentType.ReadWrite<CharacterTypeCD>(),
				Hash = 1335878963702152796uL,
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
				DisplayName = "CoinAmountCD",
				Component = ComponentType.ReadWrite<CoinAmountCD>(),
				Hash = 12773381857523351132uL,
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
				DisplayName = "AffectedBySlipperyMovementConditionCD",
				Component = ComponentType.ReadWrite<AffectedBySlipperyMovementConditionCD>(),
				Hash = 12232487728859413436uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "BurningConditionCD",
				Component = ComponentType.ReadWrite<BurningConditionCD>(),
				Hash = 3096236970127480626uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "AffectedByAcidConditionCD",
				Component = ComponentType.ReadWrite<AffectedByAcidConditionCD>(),
				Hash = 1930054017770662420uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "RadioActiveConditionCD",
				Component = ComponentType.ReadWrite<RadioActiveConditionCD>(),
				Hash = 15558747727907830526uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "VoidDamageConditionCD",
				Component = ComponentType.ReadWrite<VoidDamageConditionCD>(),
				Hash = 7156423438962996954uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "OilCombustByConditionsCD",
				Component = ComponentType.ReadWrite<OilCombustByConditionsCD>(),
				Hash = 14918275159275961266uL,
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
				DisplayName = "AmassThenReciprocateCD",
				Component = ComponentType.ReadWrite<AmassThenReciprocateCD>(),
				Hash = 16581523059502888540uL,
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
				DisplayName = "ConditionsBuffer",
				Component = ComponentType.ReadWrite<ConditionsBuffer>(),
				Hash = 12712454704550267324uL,
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
				DisplayName = "IsBeingBeHealedByOtherEntitiesCD",
				Component = ComponentType.ReadWrite<IsBeingBeHealedByOtherEntitiesCD>(),
				Hash = 13416341371587793340uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "IsBeingBeHealedByOtherEntitiesBuffer",
				Component = ComponentType.ReadWrite<IsBeingBeHealedByOtherEntitiesBuffer>(),
				Hash = 10129430979267741102uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "HasAuraConditionCD",
				Component = ComponentType.ReadWrite<HasAuraConditionCD>(),
				Hash = 12390685238652616750uL,
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
				DisplayName = "ConditionTickTimerBuffer",
				Component = ComponentType.ReadWrite<ConditionTickTimerBuffer>(),
				Hash = 15757172125263213278uL,
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
				DisplayName = "HealOverTimeConditionCD",
				Component = ComponentType.ReadWrite<HealOverTimeConditionCD>(),
				Hash = 8749286621828789778uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "InfectedWithMoldConditionCD",
				Component = ComponentType.ReadWrite<InfectedWithMoldConditionCD>(),
				Hash = 6099367491256488284uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "ConditionsFromMovementCD",
				Component = ComponentType.ReadWrite<ConditionsFromMovementCD>(),
				Hash = 5665551025432444116uL,
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
				DisplayName = "CoreAttentionMarkerCD",
				Component = ComponentType.ReadWrite<CoreAttentionMarkerCD>(),
				Hash = 9426333926149474972uL,
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
				DisplayName = "DamageTakenTriggerCD",
				Component = ComponentType.ReadWrite<DamageTakenTriggerCD>(),
				Hash = 18150278277806673630uL,
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
				DisplayName = "DealDamageToCrittersCD",
				Component = ComponentType.ReadWrite<DealDamageToCrittersCD>(),
				Hash = 17900646383726562482uL,
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
				DisplayName = "DetectCollisionCD",
				Component = ComponentType.ReadWrite<DetectCollisionCD>(),
				Hash = 8450072620732350044uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "EffectiveVelocityCD",
				Component = ComponentType.ReadWrite<EffectiveVelocityCD>(),
				Hash = 1124623906377178334uL,
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
				DisplayName = "EffectEventCD",
				Component = ComponentType.ReadWrite<EffectEventCD>(),
				Hash = 833309810126387540uL,
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
				DisplayName = "GhostEffectEventBufferPointerCD",
				Component = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>(),
				Hash = 16696470655392650556uL,
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
				DisplayName = "GhostEffectEventBuffer",
				Component = ComponentType.ReadWrite<GhostEffectEventBuffer>(),
				Hash = 3407782589638822148uL,
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
				DisplayName = "LocalEffectEventBufferPointerCD",
				Component = ComponentType.ReadWrite<LocalEffectEventBufferPointerCD>(),
				Hash = 5062175398883856228uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "LocalEffectEventBuffer",
				Component = ComponentType.ReadWrite<LocalEffectEventBuffer>(),
				Hash = 9990590500025295292uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "EnemyCD",
				Component = ComponentType.ReadWrite<EnemyCD>(),
				Hash = 11778432040864515566uL,
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
				DisplayName = "IsCloneCD",
				Component = ComponentType.ReadWrite<IsCloneCD>(),
				Hash = 202638882688084924uL,
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
				DisplayName = "EnemySpawnerPlatformCD",
				Component = ComponentType.ReadWrite<EnemySpawnerPlatformCD>(),
				Hash = 18237982834336156956uL,
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
				DisplayName = "EnemyStagesStateCD",
				Component = ComponentType.ReadWrite<EnemyStagesStateCD>(),
				Hash = 4980240847395292190uL,
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
				DisplayName = "EntityDestroyedCD",
				Component = ComponentType.ReadWrite<EntityDestroyedCD>(),
				Hash = 3411252084564116402uL,
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
				DisplayName = "EntityPartCD",
				Component = ComponentType.ReadWrite<EntityPartCD>(),
				Hash = 6531519232870831578uL,
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
				DisplayName = "EquipmentCD",
				Component = ComponentType.ReadWrite<EquipmentCD>(),
				Hash = 9837177272398195758uL,
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
				DisplayName = "ActiveEquipmentPresetCD",
				Component = ComponentType.ReadWrite<ActiveEquipmentPresetCD>(),
				Hash = 15027506356902558804uL,
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
				DisplayName = "EventTerminalCD",
				Component = ComponentType.ReadWrite<EventTerminalCD>(),
				Hash = 13454551255532132658uL,
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
				DisplayName = "EventTerminalElectricityEntityBuffer",
				Component = ComponentType.ReadWrite<EventTerminalElectricityEntityBuffer>(),
				Hash = 14507241739624159892uL,
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
				DisplayName = "GodModeCD",
				Component = ComponentType.ReadWrite<GodModeCD>(),
				Hash = 10064792719405038940uL,
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
				DisplayName = "GrowingPlantCD",
				Component = ComponentType.ReadWrite<GrowingPlantCD>(),
				Hash = 88730890793424750uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "HealNearbyEntitiesCD",
				Component = ComponentType.ReadWrite<HealNearbyEntitiesCD>(),
				Hash = 294196214463098750uL,
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
				DisplayName = "HealthCD",
				Component = ComponentType.ReadWrite<HealthCD>(),
				Hash = 14685727138100931546uL,
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
				DisplayName = "MaxHealthChangeAffectHealthCD",
				Component = ComponentType.ReadWrite<MaxHealthChangeAffectHealthCD>(),
				Hash = 2737495913470680668uL,
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
				DisplayName = "InitialHealthChange",
				Component = ComponentType.ReadWrite<InitialHealthChange>(),
				Hash = 10659893765851423316uL,
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
				DisplayName = "ImmuneToDamageCD",
				Component = ComponentType.ReadWrite<ImmuneToDamageCD>(),
				Hash = 3183306690708524828uL,
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
				DisplayName = "ImmunityZoneCD",
				Component = ComponentType.ReadWrite<ImmunityZoneCD>(),
				Hash = 12677657948645863474uL,
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
				DisplayName = "IndestructibleCD",
				Component = ComponentType.ReadWrite<IndestructibleCD>(),
				Hash = 3859438310400743396uL,
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
				DisplayName = "ContainedObjectsBuffer",
				Component = ComponentType.ReadWrite<ContainedObjectsBuffer>(),
				Hash = 10135632064218960402uL,
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
				DisplayName = "LockedObjectsBuffer",
				Component = ComponentType.ReadWrite<LockedObjectsBuffer>(),
				Hash = 7798214124692206036uL,
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
				DisplayName = "StartDroppingLootCD",
				Component = ComponentType.ReadWrite<StartDroppingLootCD>(),
				Hash = 14011437994608126492uL,
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
				DisplayName = "FinishedDroppingLootCD",
				Component = ComponentType.ReadWrite<FinishedDroppingLootCD>(),
				Hash = 15247722504552784996uL,
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
				DisplayName = "InventoryBuffer",
				Component = ComponentType.ReadWrite<InventoryBuffer>(),
				Hash = 16991197401716332228uL,
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
				DisplayName = "InventoryAuxDataCD",
				Component = ComponentType.ReadWrite<InventoryAuxDataCD>(),
				Hash = 8636647244225490286uL,
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
				DisplayName = "IsInCombatCD",
				Component = ComponentType.ReadWrite<IsInCombatCD>(),
				Hash = 16404678679032944388uL,
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
				DisplayName = "ResizableTileSizeCD",
				Component = ComponentType.ReadWrite<ResizableTileSizeCD>(),
				Hash = 16256135854579051738uL,
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
				DisplayName = "DirectionCD",
				Component = ComponentType.ReadWrite<DirectionCD>(),
				Hash = 10320789623338086868uL,
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
				DisplayName = "LastDamageTakenTimeCD",
				Component = ComponentType.ReadWrite<LastDamageTakenTimeCD>(),
				Hash = 7949055829496435388uL,
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
				DisplayName = "LeashedCD",
				Component = ComponentType.ReadWrite<LeashedCD>(),
				Hash = 16651254738154894718uL,
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
				DisplayName = "LeashingCD",
				Component = ComponentType.ReadWrite<LeashingCD>(),
				Hash = 7639619864316751956uL,
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
				DisplayName = "MagicBarrierCD",
				Component = ComponentType.ReadWrite<MagicBarrierCD>(),
				Hash = 9114454192317353498uL,
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
				DisplayName = "ManaCD",
				Component = ComponentType.ReadWrite<ManaCD>(),
				Hash = 14565222576491013844uL,
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
				DisplayName = "MealsEatenCD",
				Component = ComponentType.ReadWrite<MealsEatenCD>(),
				Hash = 15098444372972442260uL,
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
				DisplayName = "MergeDroppedItemCD",
				Component = ComponentType.ReadWrite<MergeDroppedItemCD>(),
				Hash = 4188539795598497732uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "MinecartCD",
				Component = ComponentType.ReadWrite<MinecartCD>(),
				Hash = 4165494830369499668uL,
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
				DisplayName = "MinionCD",
				Component = ComponentType.ReadWrite<MinionCD>(),
				Hash = 13085540295702118398uL,
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
				DisplayName = "MinionLevelCD",
				Component = ComponentType.ReadWrite<MinionLevelCD>(),
				Hash = 3300736012356059274uL,
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
				DisplayName = "TouchAttackCD",
				Component = ComponentType.ReadWrite<TouchAttackCD>(),
				Hash = 17996549058516174292uL,
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
				DisplayName = "MinionCountTrackerCD",
				Component = ComponentType.ReadWrite<MinionCountTrackerCD>(),
				Hash = 13598509795148616028uL,
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
				DisplayName = "MinionOrbitCD",
				Component = ComponentType.ReadWrite<MinionOrbitCD>(),
				Hash = 1854248353822131730uL,
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
				DisplayName = "MinionOrbitPosCD",
				Component = ComponentType.ReadWrite<MinionOrbitPosCD>(),
				Hash = 13246664534886154602uL,
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
				DisplayName = "MinionOwnerCD",
				Component = ComponentType.ReadWrite<MinionOwnerCD>(),
				Hash = 7296242531845145236uL,
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
				DisplayName = "MortarProjectileCD",
				Component = ComponentType.ReadWrite<MortarProjectileCD>(),
				Hash = 13788187538782812190uL,
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
				DisplayName = "MortarProjectileDamageEffectCD",
				Component = ComponentType.ReadWrite<MortarProjectileDamageEffectCD>(),
				Hash = 11363529822092469982uL,
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
				DisplayName = "ClientInput",
				Component = ComponentType.ReadWrite<ClientInput>(),
				Hash = 6943602050847636562uL,
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
				DisplayName = "ObjectDataCD",
				Component = ComponentType.ReadWrite<ObjectDataCD>(),
				Hash = 1383164420162703380uL,
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
				DisplayName = "OwnerReferenceCD",
				Component = ComponentType.ReadWrite<OwnerReferenceCD>(),
				Hash = 10986604678012520574uL,
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
				DisplayName = "BeDestroyedAlongWithOwnerCD",
				Component = ComponentType.ReadWrite<BeDestroyedAlongWithOwnerCD>(),
				Hash = 12262716854653216282uL,
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
				DisplayName = "PetCD",
				Component = ComponentType.ReadWrite<PetCD>(),
				Hash = 161581113364414268uL,
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
				DisplayName = "PetSkinCD",
				Component = ComponentType.ReadWrite<PetSkinCD>(),
				Hash = 8023812671290434174uL,
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
				DisplayName = "PetTalentBuffer",
				Component = ComponentType.ReadWrite<PetTalentBuffer>(),
				Hash = 1574828006749056306uL,
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
				DisplayName = "PetOwnerCD",
				Component = ComponentType.ReadWrite<PetOwnerCD>(),
				Hash = 5764019343390999986uL,
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
				DisplayName = "PheromoneAdderCD",
				Component = ComponentType.ReadWrite<PheromoneAdderCD>(),
				Hash = 17938685166331586908uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "PheromoneSensorCD",
				Component = ComponentType.ReadWrite<PheromoneSensorCD>(),
				Hash = 6333818163893312572uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "PickUpItemCD",
				Component = ComponentType.ReadWrite<PickUpItemCD>(),
				Hash = 9754975002539750396uL,
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
				DisplayName = "PlacementCD",
				Component = ComponentType.ReadWrite<PlacementCD>(),
				Hash = 17955917204926978876uL,
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
				DisplayName = "PlacementSizeByEquipmentTypeBuffer",
				Component = ComponentType.ReadWrite<PlacementSizeByEquipmentTypeBuffer>(),
				Hash = 6309633034768992302uL,
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
				DisplayName = "BeamWeaponAttackCD",
				Component = ComponentType.ReadWrite<BeamWeaponAttackCD>(),
				Hash = 14825086761540427900uL,
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
				DisplayName = "BlocksDiggingTilesCD",
				Component = ComponentType.ReadWrite<BlocksDiggingTilesCD>(),
				Hash = 17334545405264482834uL,
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
				DisplayName = "ClientBiomeSamplesCD",
				Component = ComponentType.ReadWrite<ClientBiomeSamplesCD>(),
				Hash = 17019261023658142386uL,
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
				DisplayName = "ClientInputNonPartialStateCD",
				Component = ComponentType.ReadWrite<ClientInputNonPartialStateCD>(),
				Hash = 3668100732541086090uL,
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
				DisplayName = "CornerSmoothingCD",
				Component = ComponentType.ReadWrite<CornerSmoothingCD>(),
				Hash = 14707126523708960212uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.All,
				SendTypeOptimization = GhostSendType.OnlyPredictedClients,
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
				DisplayName = "DiggableCD",
				Component = ComponentType.ReadWrite<DiggableCD>(),
				Hash = 2305206107928380060uL,
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
				DisplayName = "DistanceToPlayerCD",
				Component = ComponentType.ReadWrite<DistanceToPlayerCD>(),
				Hash = 7143003720223193028uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "PlayerEquipment.EquipmentSlotCD",
				Component = ComponentType.ReadWrite<EquipmentSlotCD>(),
				Hash = 8542065726680055644uL,
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
				DisplayName = "EquippedObjectCD",
				Component = ComponentType.ReadWrite<EquippedObjectCD>(),
				Hash = 16037615631324036570uL,
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
				DisplayName = "MineableCD",
				Component = ComponentType.ReadWrite<MineableCD>(),
				Hash = 5652112292546991892uL,
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
				DisplayName = "PaintableObjectCD",
				Component = ComponentType.ReadWrite<PaintableObjectCD>(),
				Hash = 15707820797129997140uL,
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
				DisplayName = "PlayerAimPositionCD",
				Component = ComponentType.ReadWrite<PlayerAimPositionCD>(),
				Hash = 17250948261952935260uL,
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
				DisplayName = "PlayerEquipment.PlayerAttackCD",
				Component = ComponentType.ReadWrite<PlayerAttackCD>(),
				Hash = 653187025514511322uL,
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
				DisplayName = "PlayerAttackCooldownCD",
				Component = ComponentType.ReadWrite<PlayerAttackCooldownCD>(),
				Hash = 17194995914115946526uL,
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
				DisplayName = "PlayerChainTargetsBuffer",
				Component = ComponentType.ReadWrite<PlayerChainTargetsBuffer>(),
				Hash = 4966201126584855380uL,
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
				DisplayName = "PlayerCustomizationCD",
				Component = ComponentType.ReadWrite<PlayerCustomizationCD>(),
				Hash = 14704247468094646638uL,
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
				DisplayName = "PlayerGhost",
				Component = ComponentType.ReadWrite<PlayerGhost>(),
				Hash = 9949911123698397540uL,
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
				DisplayName = "HungerCD",
				Component = ComponentType.ReadWrite<HungerCD>(),
				Hash = 10702058291001203924uL,
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
				DisplayName = "PlayerInvincibilityCD",
				Component = ComponentType.ReadWrite<PlayerInvincibilityCD>(),
				Hash = 4173288199954962954uL,
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
				DisplayName = "PlayerOrientationCD",
				Component = ComponentType.ReadWrite<PlayerOrientationCD>(),
				Hash = 16846198354404759060uL,
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
				DisplayName = "PlayerRoutineCD",
				Component = ComponentType.ReadWrite<PlayerRoutineCD>(),
				Hash = 11789409103795831124uL,
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
				DisplayName = "SyncedPlayerSharedCooldownTimersCD",
				Component = ComponentType.ReadWrite<SyncedPlayerSharedCooldownTimersCD>(),
				Hash = 5322942322082228996uL,
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
				DisplayName = "PlayerState.PlayerStateCD",
				Component = ComponentType.ReadWrite<PlayerStateCD>(),
				Hash = 8035656825479101806uL,
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
				DisplayName = "PlayerState.WalkStateCD",
				Component = ComponentType.ReadWrite<WalkStateCD>(),
				Hash = 5388225225481330186uL,
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
				DisplayName = "PlayerState.FishingStateCD",
				Component = ComponentType.ReadWrite<FishingStateCD>(),
				Hash = 11945669944982433372uL,
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
				DisplayName = "PlayerState.FishingMiniGameStateCD",
				Component = ComponentType.ReadWrite<FishingMiniGameStateCD>(),
				Hash = 14442990905461324762uL,
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
				DisplayName = "PlayerState.BoatRidingStateCD",
				Component = ComponentType.ReadWrite<BoatRidingStateCD>(),
				Hash = 7239215961602049582uL,
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
				DisplayName = "PlayerState.VehicleRidingStateCD",
				Component = ComponentType.ReadWrite<VehicleRidingStateCD>(),
				Hash = 17110174830599239022uL,
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
				DisplayName = "PlayerState.ReleaseStateCD",
				Component = ComponentType.ReadWrite<ReleaseStateCD>(),
				Hash = 9757459710722807082uL,
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
				DisplayName = "PlayerState.AnticipationCD",
				Component = ComponentType.ReadWrite<AnticipationCD>(),
				Hash = 15939815341760764156uL,
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
				DisplayName = "PlayerState.UseOffHandStateCD",
				Component = ComponentType.ReadWrite<UseOffHandStateCD>(),
				Hash = 9912015590936605550uL,
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
				DisplayName = "PlayerState.DeathStateCD",
				Component = ComponentType.ReadWrite<DeathStateCD>(),
				Hash = 13901288934998488252uL,
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
				DisplayName = "PlayerState.TeleportingStateCD",
				Component = ComponentType.ReadWrite<TeleportingStateCD>(),
				Hash = 893795862110843610uL,
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
				DisplayName = "PlayerState.PlayerSleepStateCD",
				Component = ComponentType.ReadWrite<PlayerSleepStateCD>(),
				Hash = 3716343627598950236uL,
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
				DisplayName = "PlayerState.CastingStateCD",
				Component = ComponentType.ReadWrite<CastingStateCD>(),
				Hash = 9864660405096211634uL,
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
				DisplayName = "PlayerState.SpawningFromCoreStateCD",
				Component = ComponentType.ReadWrite<SpawningFromCoreStateCD>(),
				Hash = 8604596798356106324uL,
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
				DisplayName = "PlayerState.MinecartRidingStateCD",
				Component = ComponentType.ReadWrite<MinecartRidingStateCD>(),
				Hash = 18179382745356785244uL,
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
				DisplayName = "PlayerState.SittingStateCD",
				Component = ComponentType.ReadWrite<SittingStateCD>(),
				Hash = 11107218726235645468uL,
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
				DisplayName = "PlayerState.RefillWaterStateCD",
				Component = ComponentType.ReadWrite<RefillWaterStateCD>(),
				Hash = 213407601381482802uL,
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
				DisplayName = "PlayerState.PlaceWaterStateCD",
				Component = ComponentType.ReadWrite<PlaceWaterStateCD>(),
				Hash = 4080310029937144292uL,
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
				DisplayName = "PlayerState.DigStateCD",
				Component = ComponentType.ReadWrite<DigStateCD>(),
				Hash = 12655483319173172252uL,
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
				DisplayName = "PlayerState.FlattenStateCD",
				Component = ComponentType.ReadWrite<FlattenStateCD>(),
				Hash = 5351481367168434148uL,
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
				DisplayName = "PlayerState.PlaceObjectPlayerStateCD",
				Component = ComponentType.ReadWrite<PlaceObjectPlayerStateCD>(),
				Hash = 1200448409787303346uL,
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
				DisplayName = "PlayerMovementCD",
				Component = ComponentType.ReadWrite<PlayerMovementCD>(),
				Hash = 17190174920614373554uL,
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
				DisplayName = "PlayerRecentAttackersBuffer",
				Component = ComponentType.ReadWrite<PlayerRecentAttackersBuffer>(),
				Hash = 13218999955924191716uL,
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
				DisplayName = "PlayerRecentAttackersBufferPointerCD",
				Component = ComponentType.ReadWrite<PlayerRecentAttackersBufferPointerCD>(),
				Hash = 7684812761024968828uL,
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
				DisplayName = "PlayerSpawnCD",
				Component = ComponentType.ReadWrite<PlayerSpawnCD>(),
				Hash = 16484048644342925138uL,
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
				DisplayName = "Pug.Automation.PugAutomationEnabledMoverSyncedCD",
				Component = ComponentType.ReadWrite<PugAutomationEnabledMoverSyncedCD>(),
				Hash = 14373437539832559794uL,
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
				DisplayName = "QuickSwapTorchCD",
				Component = ComponentType.ReadWrite<QuickSwapTorchCD>(),
				Hash = 1114541113094648990uL,
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
				DisplayName = "RandomCD",
				Component = ComponentType.ReadWrite<RandomCD>(),
				Hash = 4866921120802415812uL,
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
				DisplayName = "AchievementTrackerCD",
				Component = ComponentType.ReadWrite<AchievementTrackerCD>(),
				Hash = 1896682013361762044uL,
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
				DisplayName = "SwapColliderCD",
				Component = ComponentType.ReadWrite<SwapColliderCD>(),
				Hash = 12927694043530993556uL,
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
				DisplayName = "AddForceToNearbyEntitiesCD",
				Component = ComponentType.ReadWrite<AddForceToNearbyEntitiesCD>(),
				Hash = 1562778582758447388uL,
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
				DisplayName = "AffectObjectWhenMelodyPlayedCD",
				Component = ComponentType.ReadWrite<AffectObjectWhenMelodyPlayedCD>(),
				Hash = 10617038374702508636uL,
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
				DisplayName = "MimicPlayerInstrumentNotesCD",
				Component = ComponentType.ReadWrite<MimicPlayerInstrumentNotesCD>(),
				Hash = 16867038773843849070uL,
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
				DisplayName = "AuraDistanceOverrideCD",
				Component = ComponentType.ReadWrite<AuraDistanceOverrideCD>(),
				Hash = 7129921742483603506uL,
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
				DisplayName = "ClaimedByPlayerGuidCD",
				Component = ComponentType.ReadWrite<ClaimedByPlayerGuidCD>(),
				Hash = 10749646357794407194uL,
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
				DisplayName = "WayPointCD",
				Component = ComponentType.ReadWrite<WayPointCD>(),
				Hash = 3825487920780135700uL,
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
				DisplayName = "CattleCD",
				Component = ComponentType.ReadWrite<CattleCD>(),
				Hash = 12355225973414493156uL,
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
				DisplayName = "CraftingCD",
				Component = ComponentType.ReadWrite<CraftingCD>(),
				Hash = 8953330621608848126uL,
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
				DisplayName = "CraftingTimerSlotBuffer",
				Component = ComponentType.ReadWrite<CraftingTimerSlotBuffer>(),
				Hash = 12289518773876557790uL,
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
				DisplayName = "CraftingByRecipeSlotBuffer",
				Component = ComponentType.ReadWrite<CraftingByRecipeSlotBuffer>(),
				Hash = 7567821487368709486uL,
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
				DisplayName = "ObjectFilteringCD",
				Component = ComponentType.ReadWrite<ObjectFilteringCD>(),
				Hash = 13025283968029865924uL,
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
				DisplayName = "CharacterGuidCD",
				Component = ComponentType.ReadWrite<CharacterGuidCD>(),
				Hash = 4531254935945861374uL,
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
				DisplayName = "PlayerGuidCD",
				Component = ComponentType.ReadWrite<PlayerGuidCD>(),
				Hash = 5607198428555834890uL,
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
				DisplayName = "DamageReductionCD",
				Component = ComponentType.ReadWrite<DamageReductionCD>(),
				Hash = 8056985780928636398uL,
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
				DisplayName = "DestroyEntityIfNotOnTileCD",
				Component = ComponentType.ReadWrite<DestroyEntityIfNotOnTileCD>(),
				Hash = 12544804477633232238uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "DestroyEntityIfPlacementNotValidCD",
				Component = ComponentType.ReadWrite<DestroyEntityIfPlacementNotValidCD>(),
				Hash = 9439966513710708010uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "DontDropSelfCD",
				Component = ComponentType.ReadWrite<DontDropSelfCD>(),
				Hash = 8665649070305438106uL,
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
				DisplayName = "DontDropLootCD",
				Component = ComponentType.ReadWrite<DontDropLootCD>(),
				Hash = 6585786977947790002uL,
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
				DisplayName = "HasExplodedCD",
				Component = ComponentType.ReadWrite<HasExplodedCD>(),
				Hash = 5828502333995949724uL,
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
				DisplayName = "ExplosionCD",
				Component = ComponentType.ReadWrite<ExplosionCD>(),
				Hash = 12257121935135403780uL,
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
				DisplayName = "IsSpawningTilesFromExplosionCD",
				Component = ComponentType.ReadWrite<IsSpawningTilesFromExplosionCD>(),
				Hash = 6114682582884782564uL,
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
				DisplayName = "SpawnTileOnExplosionCD",
				Component = ComponentType.ReadWrite<SpawnTileOnExplosionCD>(),
				Hash = 16139487288788508308uL,
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
				DisplayName = "SequenceExplosiveCD",
				Component = ComponentType.ReadWrite<SequenceExplosiveCD>(),
				Hash = 10481076126887380274uL,
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
				DisplayName = "ProximityTriggerCD",
				Component = ComponentType.ReadWrite<ProximityTriggerCD>(),
				Hash = 14044675564251482564uL,
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
				DisplayName = "MapMarkerActivatedCD",
				Component = ComponentType.ReadWrite<MapMarkerActivatedCD>(),
				Hash = 14152030772442050196uL,
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
				DisplayName = "MerchantCD",
				Component = ComponentType.ReadWrite<MerchantCD>(),
				Hash = 16987413652775458558uL,
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
				DisplayName = "MovementSpeedCD",
				Component = ComponentType.ReadWrite<MovementSpeedCD>(),
				Hash = 4586439711293877386uL,
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
				DisplayName = "MusicAreaCD",
				Component = ComponentType.ReadWrite<MusicAreaCD>(),
				Hash = 13935243347858870302uL,
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
				DisplayName = "NameCD",
				Component = ComponentType.ReadWrite<NameCD>(),
				Hash = 7568045238184304764uL,
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
				DisplayName = "DescriptionBuffer",
				Component = ComponentType.ReadWrite<DescriptionBuffer>(),
				Hash = 8598399910666876508uL,
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
				DisplayName = "AuthorCD",
				Component = ComponentType.ReadWrite<AuthorCD>(),
				Hash = 8615319743201194260uL,
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
				DisplayName = "IsHabitableIdolCD",
				Component = ComponentType.ReadWrite<IsHabitableIdolCD>(),
				Hash = 4558448324989612754uL,
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
				DisplayName = "NearbyEntitiesTrackerCD",
				Component = ComponentType.ReadWrite<NearbyEntitiesTrackerCD>(),
				Hash = 9496231712281202990uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "NearbyEntitiesBufferCD",
				Component = ComponentType.ReadWrite<NearbyEntitiesBufferCD>(),
				Hash = 11697339027011782110uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "OverrideGhostRelevancyCD",
				Component = ComponentType.ReadWrite<OverrideGhostRelevancyCD>(),
				Hash = 7841366159889600222uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "PlantCD",
				Component = ComponentType.ReadWrite<PlantCD>(),
				Hash = 11263914152451907580uL,
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
				DisplayName = "PiercingProjectileCD",
				Component = ComponentType.ReadWrite<PiercingProjectileCD>(),
				Hash = 17259081973800386322uL,
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
				DisplayName = "BouncingProjectileCD",
				Component = ComponentType.ReadWrite<BouncingProjectileCD>(),
				Hash = 7775255850831409970uL,
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
				DisplayName = "PingPongProjectileCD",
				Component = ComponentType.ReadWrite<PingPongProjectileCD>(),
				Hash = 3072589067928168708uL,
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
				DisplayName = "ContinouslyDamagingProjectileCD",
				Component = ComponentType.ReadWrite<ContinouslyDamagingProjectileCD>(),
				Hash = 3921452921528058238uL,
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
				DisplayName = "ZigZagProjectileCD",
				Component = ComponentType.ReadWrite<ZigZagProjectileCD>(),
				Hash = 13062473148631054212uL,
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
				DisplayName = "ProjectileSourceCD",
				Component = ComponentType.ReadWrite<ProjectileSourceCD>(),
				Hash = 3135698760267307282uL,
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
				DisplayName = "ProjectileSetupCD",
				Component = ComponentType.ReadWrite<ProjectileSetupCD>(),
				Hash = 5012978592088311774uL,
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
				DisplayName = "ProjectileCD",
				Component = ComponentType.ReadWrite<ProjectileCD>(),
				Hash = 15563923098960743252uL,
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
				DisplayName = "IndirectProjectileCD",
				Component = ComponentType.ReadWrite<IndirectProjectileCD>(),
				Hash = 4522929196334677820uL,
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
				DisplayName = "GroundBouncableProjectileCD",
				Component = ComponentType.ReadWrite<GroundBouncableProjectileCD>(),
				Hash = 1221124123998873980uL,
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
				DisplayName = "VelocityAffectorCD",
				Component = ComponentType.ReadWrite<VelocityAffectorCD>(),
				Hash = 16932820127151350620uL,
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
				DisplayName = "VelocityAffectedCD",
				Component = ComponentType.ReadWrite<VelocityAffectedCD>(),
				Hash = 13186083512287455636uL,
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
				DisplayName = "DestroyTimerCD",
				Component = ComponentType.ReadWrite<DestroyTimerCD>(),
				Hash = 15793146406437367124uL,
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
				DisplayName = "DisablePhysicsCD",
				Component = ComponentType.ReadWrite<DisablePhysicsCD>(),
				Hash = 7900750979391449980uL,
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
				DisplayName = "CrackableTileCD",
				Component = ComponentType.ReadWrite<CrackableTileCD>(),
				Hash = 17431687927944305534uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "DamageObjectStateCD",
				Component = ComponentType.ReadWrite<DamageObjectStateCD>(),
				Hash = 18353379974854508156uL,
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
				DisplayName = "ControllingOtherEntityCD",
				Component = ComponentType.ReadWrite<ControllingOtherEntityCD>(),
				Hash = 2428645859570488458uL,
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
				DisplayName = "ControlledByOtherEntityCD",
				Component = ComponentType.ReadWrite<ControlledByOtherEntityCD>(),
				Hash = 8038583902518163742uL,
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
				DisplayName = "PlayerClaimedBed",
				Component = ComponentType.ReadWrite<PlayerClaimedBed>(),
				Hash = 11744698181009733082uL,
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
				DisplayName = "DontDestroyOnZeroHealthCD",
				Component = ComponentType.ReadWrite<DontDestroyOnZeroHealthCD>(),
				Hash = 16536217059296822410uL,
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
				DisplayName = "GrowingCD",
				Component = ComponentType.ReadWrite<GrowingCD>(),
				Hash = 1786945445618419556uL,
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
				DisplayName = "HealthRegenerationCD",
				Component = ComponentType.ReadWrite<HealthRegenerationCD>(),
				Hash = 3382238333272406676uL,
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
				DisplayName = "IgnoreVertexOffsetsCD",
				Component = ComponentType.ReadWrite<IgnoreVertexOffsetsCD>(),
				Hash = 11957090849140000926uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Client,
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
				DisplayName = "MusicSheetPlayedCD",
				Component = ComponentType.ReadWrite<MusicSheetPlayedCD>(),
				Hash = 18252021574075924uL,
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
				DisplayName = "SellSlotsCD",
				Component = ComponentType.ReadWrite<SellSlotsCD>(),
				Hash = 14406646275429367036uL,
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
				DisplayName = "VanitySlotsCD",
				Component = ComponentType.ReadWrite<VanitySlotsCD>(),
				Hash = 7970316235324124014uL,
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
				DisplayName = "WorldInfoCD",
				Component = ComponentType.ReadWrite<WorldInfoCD>(),
				Hash = 1349408334882915226uL,
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
				DisplayName = "FactionCD",
				Component = ComponentType.ReadWrite<FactionCD>(),
				Hash = 3181455631401099474uL,
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
				DisplayName = "RootCD",
				Component = ComponentType.ReadWrite<RootCD>(),
				Hash = 11386717375220358910uL,
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
				DisplayName = "ActivatedContentBundlesBuffer",
				Component = ComponentType.ReadWrite<ActivatedContentBundlesBuffer>(),
				Hash = 17361348650387195402uL,
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
				DisplayName = "ShieldCD",
				Component = ComponentType.ReadWrite<ShieldCD>(),
				Hash = 1624404400857247804uL,
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
				DisplayName = "SkillBuffer",
				Component = ComponentType.ReadWrite<SkillBuffer>(),
				Hash = 17932977263794099566uL,
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
				DisplayName = "SkillConditionsBuffer",
				Component = ComponentType.ReadWrite<SkillConditionsBuffer>(),
				Hash = 14368240414425891550uL,
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
				DisplayName = "SkillTalentConditionsBuffer",
				Component = ComponentType.ReadWrite<SkillTalentConditionsBuffer>(),
				Hash = 14420477230516760498uL,
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
				DisplayName = "SnakeSegmentCD",
				Component = ComponentType.ReadWrite<SnakeSegmentCD>(),
				Hash = 5412944472995960732uL,
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
				DisplayName = "SnakeSegmentsBuffer",
				Component = ComponentType.ReadWrite<SnakeSegmentsBuffer>(),
				Hash = 15808950819334701028uL,
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
				DisplayName = "SoulsInfoCD",
				Component = ComponentType.ReadWrite<SoulsInfoCD>(),
				Hash = 18166779364285193522uL,
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
				DisplayName = "CollectedSoulsBuffer",
				Component = ComponentType.ReadWrite<CollectedSoulsBuffer>(),
				Hash = 14350229661943542702uL,
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
				DisplayName = "SoulsConditionsBuffer",
				Component = ComponentType.ReadWrite<SoulsConditionsBuffer>(),
				Hash = 10404194026915207004uL,
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
				DisplayName = "CollectedAndEnabledSoulsMask",
				Component = ComponentType.ReadWrite<CollectedAndEnabledSoulsMask>(),
				Hash = 9500599246841159386uL,
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
				DisplayName = "SpawnTickCD",
				Component = ComponentType.ReadWrite<SpawnTickCD>(),
				Hash = 3336372784773968878uL,
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
				DisplayName = "PlayAnimationStateCD",
				Component = ComponentType.ReadWrite<PlayAnimationStateCD>(),
				Hash = 3542075892761378916uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "DropLootDelayCD",
				Component = ComponentType.ReadWrite<DropLootDelayCD>(),
				Hash = 6062611347828927962uL,
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
				DisplayName = "AttackCooldownTimerCD",
				Component = ComponentType.ReadWrite<AttackCooldownTimerCD>(),
				Hash = 10458420319146571118uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "RangeAttackStateCD",
				Component = ComponentType.ReadWrite<RangeAttackStateCD>(),
				Hash = 1053430860618556690uL,
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
				DisplayName = "ChargeAttackStateCD",
				Component = ComponentType.ReadWrite<ChargeAttackStateCD>(),
				Hash = 8152280798630521684uL,
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
				DisplayName = "HealOtherEntityStateCD",
				Component = ComponentType.ReadWrite<HealOtherEntityStateCD>(),
				Hash = 11129861896131606578uL,
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
				DisplayName = "JumpAttackStateCD",
				Component = ComponentType.ReadWrite<JumpAttackStateCD>(),
				Hash = 3109927949299157444uL,
				SelfIndex = -1,
				SerializerIndex = -1,
				PrefabType = GhostPrefabType.Server,
				SendTypeOptimization = GhostSendType.DontSend,
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
				DisplayName = "SnakeMovementStateCD",
				Component = ComponentType.ReadWrite<SnakeMovementStateCD>(),
				Hash = 2554466419895600110uL,
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
				DisplayName = "SnakeMovementAttackCooldownCD",
				Component = ComponentType.ReadWrite<SnakeMovementAttackCooldownCD>(),
				Hash = 1454668312271079210uL,
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
				DisplayName = "EnrageStateCD",
				Component = ComponentType.ReadWrite<EnrageStateCD>(),
				Hash = 16079177462707028820uL,
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
				DisplayName = "EntitiesHealedBuffer",
				Component = ComponentType.ReadWrite<EntitiesHealedBuffer>(),
				Hash = 4197468239316707412uL,
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
				DisplayName = "LarvaHiveEggHatchStateCD",
				Component = ComponentType.ReadWrite<LarvaHiveEggHatchStateCD>(),
				Hash = 7851376104195143550uL,
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
				DisplayName = "TeleportStateCD",
				Component = ComponentType.ReadWrite<TeleportStateCD>(),
				Hash = 13234749265438291758uL,
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
				DisplayName = "ClientSubMapLayerCD",
				Component = ComponentType.ReadWrite<ClientSubMapLayerCD>(),
				Hash = 9824809055455300062uL,
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
				DisplayName = "TileDamageTagCD",
				Component = ComponentType.ReadWrite<TileDamageTagCD>(),
				Hash = 11208200761862650772uL,
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
				DisplayName = "Unity.Transforms.Translation",
				Component = ComponentType.ReadWrite<Translation>(),
				Hash = 1185573726043932634uL,
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
				DisplayName = "TrophyCD",
				Component = ComponentType.ReadWrite<TrophyCD>(),
				Hash = 13832858871486759954uL,
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
				DisplayName = "UIActionsCD",
				Component = ComponentType.ReadWrite<UIActionsCD>(),
				Hash = 9982725921302846332uL,
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
				DisplayName = "DelayedFishLootCD",
				Component = ComponentType.ReadWrite<DelayedFishLootCD>(),
				Hash = 18122588505340795986uL,
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
			valueRW.AddSerializer(AddRandomLootCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AncientElectricityConnectionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AnimationOrientationCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BirdBossHasAppearedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BeamBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BossLarvaCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BossStatueCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GiantCicadaBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GiantCicadaBossHasAppearedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoreBossSpawnCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoreBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoreBossOrbCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoreBossOrbsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoreBossVoidImmuneZoneBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HydraBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HydraBossVulnerableEntityCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(VulnerableStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HydraBossBuriedCombatStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HydraBossBuriedRoamingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(OctopusBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(OctopusBossHasAppearedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RobotBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RobotBossLegsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ScarabBossHasAppearedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ScarabBossChargeStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PhaseTransitionStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SnakeBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WallBossCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WallBossBufferElementGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WallBossHeadCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WallBossHeadRefCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BreedToggleCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CharacterTypeCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CoinAmountCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AffectedBySlipperyMovementConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BurningConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AffectedByAcidConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RadioActiveConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(VoidDamageConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(OilCombustByConditionsCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AmassThenReciprocateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ConditionsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsBeingBeHealedByOtherEntitiesCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsBeingBeHealedByOtherEntitiesBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HasAuraConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ConditionTickTimerBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HealOverTimeConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(InfectedWithMoldConditionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ConditionsFromMovementCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DamageTakenTriggerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DealDamageToCrittersCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EffectiveVelocityCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EffectEventCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GhostEffectEventBufferPointerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GhostEffectEventBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsCloneCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EnemySpawnerPlatformCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EnemyStagesStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EntityDestroyedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EntityPartCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ActiveEquipmentPresetCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EventTerminalCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EventTerminalElectricityEntityBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GodModeCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HealNearbyEntitiesCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HealthCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MaxHealthChangeAffectHealthCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(InitialHealthChangeGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ImmuneToDamageCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ImmunityZoneCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IndestructibleCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ContainedObjectsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(LockedObjectsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(StartDroppingLootCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(FinishedDroppingLootCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(InventoryBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(InventoryAuxDataCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsInCombatCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DirectionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(LastDamageTakenTimeCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(LeashedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(LeashingCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MagicBarrierCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ManaCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MealsEatenCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinecartCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionLevelCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(TouchAttackCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionCountTrackerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionOrbitCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionOrbitPosCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinionOwnerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MortarProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MortarProjectileDamageEffectCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ClientInputGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ObjectDataCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(OwnerReferenceCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BeDestroyedAlongWithOwnerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PetCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PetSkinCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PetTalentBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PetOwnerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PickUpItemCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlacementCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlacementSizeByEquipmentTypeBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BeamWeaponAttackCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ClientBiomeSamplesCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ClientInputNonPartialStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CornerSmoothingCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EquipmentSlotCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EquippedObjectCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PaintableObjectCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerAimPositionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerAttackCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerAttackCooldownCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerChainTargetsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerCustomizationCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerGhostGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HungerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerInvincibilityCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerOrientationCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerRoutineCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SyncedPlayerSharedCooldownTimersCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WalkStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(FishingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(FishingMiniGameStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BoatRidingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(VehicleRidingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ReleaseStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AnticipationCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(UseOffHandStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DeathStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(TeleportingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerSleepStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CastingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SpawningFromCoreStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MinecartRidingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SittingStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RefillWaterStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlaceWaterStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DigStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(FlattenStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlaceObjectPlayerStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerMovementCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerRecentAttackersBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerRecentAttackersBufferPointerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerSpawnCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PugAutomationEnabledMoverSyncedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(QuickSwapTorchCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RandomCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AchievementTrackerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SwapColliderCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AddForceToNearbyEntitiesCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AffectObjectWhenMelodyPlayedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MimicPlayerInstrumentNotesCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AuraDistanceOverrideCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ClaimedByPlayerGuidCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WayPointCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CraftingTimerSlotBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CraftingByRecipeSlotBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ObjectFilteringCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CharacterGuidCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerGuidCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DamageReductionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DontDropSelfCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DontDropLootCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HasExplodedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ExplosionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsSpawningTilesFromExplosionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SpawnTileOnExplosionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SequenceExplosiveCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MapMarkerActivatedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MerchantCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MovementSpeedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MusicAreaCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(NameCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DescriptionBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(AuthorCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(IsHabitableIdolCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlantCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PiercingProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(BouncingProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PingPongProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ContinouslyDamagingProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ZigZagProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ProjectileSourceCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ProjectileSetupCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GroundBouncableProjectileCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(VelocityAffectorCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(VelocityAffectedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DestroyTimerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DisablePhysicsCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DamageObjectStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ControllingOtherEntityCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ControlledByOtherEntityCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(PlayerClaimedBedGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DontDestroyOnZeroHealthCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(GrowingCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(MusicSheetPlayedCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(WorldInfoCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(FactionCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ActivatedContentBundlesBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ShieldCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SkillBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SkillConditionsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SkillTalentConditionsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SnakeSegmentCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SnakeSegmentsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SoulsInfoCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CollectedSoulsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SoulsConditionsBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(CollectedAndEnabledSoulsMaskGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SpawnTickCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DropLootDelayCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(RangeAttackStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ChargeAttackStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(HealOtherEntityStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(SnakeMovementStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EnrageStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(EntitiesHealedBufferGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(LarvaHiveEggHatchStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(TeleportStateCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(ClientSubMapLayerCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(TileDamageTagCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(TranslationGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(UIActionsCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddSerializer(DelayedFishLootCDGhostComponentSerializer.GetState(ref state));
			valueRW.AddInputComponent(ComponentType.ReadWrite<ClientInputData>(), ComponentType.ReadWrite<InputBufferData<ClientInputData>>());
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
			__codegen__OnUpdate_0000198C_0024BurstDirectCall.Invoke(self, state);
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
