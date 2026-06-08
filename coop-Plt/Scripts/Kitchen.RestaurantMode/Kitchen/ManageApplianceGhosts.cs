#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class ManageApplianceGhosts : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public ManageApplianceGhosts _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public EntityManager em;

			public Bounds bounds;

			public EntityArchetype default_archetype;

			internal void _003COnUpdate_003Eb__0(Entity e, in CApplianceGhost ghost)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(Entity player, ref CAttemptingInteraction interact, in CPosition pos)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CApplianceGhost>.Runtime runtime_ghost;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CApplianceGhost> forParameter_ghost;

				public void ScheduleTimeInitialize(ManageApplianceGhosts componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_ghost.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ghost = forParameter_ghost.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000110_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000110_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000110_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					IntPtr result = (IntPtr)0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static RunWithoutJobSystem_00000110_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
				}
			}

			public EntityCommandBuffer ecb;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPlayer> _ComponentDataFromEntity_CPlayer_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CApplianceGhost ghost)
			{
				if (!_ComponentDataFromEntity_CPlayer_0.HasComponent(ghost.FromPlayer))
				{
					ecb.DestroyEntity(e);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.ecb = ecb;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_ghost.For(i));
				}
			}

			public void ScheduleTimeInitialize(ManageApplianceGhosts componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPlayer_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPlayer>(true);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000110_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CAttemptingInteraction>.Runtime runtime_interact;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_player;

				private LambdaParameterValueProvider_IComponentData<CAttemptingInteraction> forParameter_interact;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(ManageApplianceGhosts componentSystem)
				{
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_interact.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interact = forParameter_interact.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityManager em;

			public ManageApplianceGhosts _003C_003E4__this;

			public Bounds bounds;

			public EntityCommandBuffer ecb;

			public EntityArchetype default_archetype;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CHasApplianceGhost> _ComponentDataFromEntity_CHasApplianceGhost_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CAllowPlacingOver> _ComponentDataFromEntity_CAllowPlacingOver_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CUnsellableAppliance> _ComponentDataFromEntity_CUnsellableAppliance_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CMustHaveWall> _ComponentDataFromEntity_CMustHaveWall_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity player, ref CAttemptingInteraction interact, in CPosition pos)
			{
				bool flag = false;
				bool flag2 = _ComponentDataFromEntity_CHasApplianceGhost_0.HasComponent(player);
				bool isHappy = false;
				int iD = 0;
				bool isSale = false;
				Quaternion quaternion2 = Quaternion.identity;
				if (em.RequireComponent<CItemHolder>(player, out var component) && component.HeldItem != default(Entity))
				{
					Entity heldItem = component.HeldItem;
					if (em.RequireComponent<CAppliance>(heldItem, out var component2))
					{
						flag = true;
						if (em.RequireComponent<CApplianceBlueprint>(heldItem, out var component3))
						{
							iD = component3.Appliance;
							isSale = true;
						}
						else
						{
							iD = component2.ID;
						}
						bool flag3 = false;
						foreach (Vector3 item in _003C_003E4__this.ReservedTilesCache)
						{
							if (item.IsSameTile(interact.Location))
							{
								flag3 = true;
								break;
							}
						}
						if (flag3 || !bounds.Contains(interact.Location))
						{
							isHappy = false;
						}
						else
						{
							Entity occupant = _003C_003E4__this.TileManager.GetOccupant(interact.Location, component2.Layer);
							isHappy = occupant == default(Entity) || _ComponentDataFromEntity_CAllowPlacingOver_1.HasComponent(occupant);
							bool flag4 = false;
							CLayoutRoomTile tile = _003C_003E4__this.TileManager.GetTile(interact.Location);
							Orientation[] preferredRotations = OrientationHelpers.PreferredRotations;
							foreach (Orientation o in preferredRotations)
							{
								Vector3 vector = o.ToOffset();
								if (_003C_003E4__this.TileManager.GetRoom(interact.Location + vector) != tile.RoomID)
								{
									flag4 = !tile.CanReach(o);
									quaternion2 = o.ToRotation();
									break;
								}
							}
							bool num = tile.RoomID == 0;
							if (num && _ComponentDataFromEntity_CUnsellableAppliance_2.HasComponent(heldItem))
							{
								isHappy = false;
							}
							if (!num && _ComponentDataFromEntity_CMustHaveWall_3.HasComponent(heldItem) && !flag4)
							{
								isHappy = false;
							}
						}
					}
				}
				CPosition component4 = default(CPosition);
				if (flag)
				{
					flag &= _003C_003E4__this.TileManager.CanReach(pos, interact.Location);
					component4 = new CPosition(new Vector3(Mathf.Round(interact.Location.x), 0f, Mathf.Round(interact.Location.z)), quaternion2);
				}
				if (flag && !flag2)
				{
					Entity entity = ecb.CreateEntity(default_archetype);
					ecb.AddComponent(entity, component4);
					ecb.AddComponent(entity, new CApplianceGhost
					{
						ID = iD,
						IsSale = isSale,
						IsHappy = isHappy,
						FromPlayer = player
					});
					ecb.AddComponent(entity, new CRequiresView
					{
						Type = ViewType.ApplianceGhost
					});
					ecb.AddComponent(player, new CHasApplianceGhost
					{
						Ghost = entity
					});
				}
				else if (flag2 && !flag)
				{
					ecb.DestroyEntity(_ComponentDataFromEntity_CHasApplianceGhost_0[player].Ghost);
					ecb.RemoveComponent<CHasApplianceGhost>(player);
				}
				else if (flag2)
				{
					Entity ghost = _ComponentDataFromEntity_CHasApplianceGhost_0[player].Ghost;
					ecb.SetComponent(ghost, component4);
					ecb.AddComponent(ghost, new CApplianceGhost
					{
						ID = iD,
						IsSale = isSale,
						IsHappy = isHappy,
						FromPlayer = player
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				em = displayClass.em;
				_003C_003E4__this = displayClass._003C_003E4__this;
				bounds = displayClass.bounds;
				ecb = displayClass.ecb;
				default_archetype = displayClass.default_archetype;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.em = em;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.bounds = bounds;
				displayClass.ecb = ecb;
				displayClass.default_archetype = default_archetype;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_player.For(i), ref runtimes.runtime_interact.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(ManageApplianceGhosts componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CHasApplianceGhost_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CHasApplianceGhost>(true);
				_ComponentDataFromEntity_CAllowPlacingOver_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAllowPlacingOver>(true);
				_ComponentDataFromEntity_CUnsellableAppliance_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CUnsellableAppliance>(true);
				_ComponentDataFromEntity_CMustHaveWall_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CMustHaveWall>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		protected List<Vector3> ReservedTilesCache = new List<Vector3>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this
			};
			ShouldRunSystem();
			displayClass.ecb = GetCommandBuffer(ECB.End);
			displayClass.em = base.EntityManager;
			displayClass.bounds = base.Bounds;
			Vector3 frontDoor = GetFrontDoor();
			ReservedTilesCache.Clear();
			GetReservedTiles(ReservedTilesCache);
			ReservedTilesCache.Add(GetFrontDoor());
			ReservedTilesCache.Add(GetFrontDoor(get_external_tile: true));
			displayClass.bounds.Encapsulate(frontDoor + new Vector3(0f, 0f, -2f));
			displayClass.bounds.Expand(0.5f);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			displayClass.default_archetype = DefaultArchetype;
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
			}
			jobData2.WriteToDisplayClass(ref displayClass);
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CApplianceGhost>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CAttemptingInteraction>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000110_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000110_0024BurstDirectCall.Initialize();
		}
	}
}
