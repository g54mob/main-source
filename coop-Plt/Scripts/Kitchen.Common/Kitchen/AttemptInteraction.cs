#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderFirst = true)]
	public class AttemptInteraction : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass11_0
		{
			public bool all_users_captured;

			public NativeHashSet<int> is_user_captured;

			public AttemptInteraction _003C_003E4__this;

			public NativeArray<Entity> interactives;

			public EntityContext ctx;

			public NativeArray<CIsInteractive> interactive_priority;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__1(Entity e, int entityInQueryIndex, ref CInputData input, in CIsInteractor interactor, in CPosition player_position, in CPlayer player)
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
					public LambdaParameterValueProvider_DynamicBuffer<CBeingActedOnBy>.Runtime runtime_acted_on_by;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CBeingActedOnBy> forParameter_acted_on_by;

				public void ScheduleTimeInitialize(AttemptInteraction componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_acted_on_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_acted_on_by = forParameter_acted_on_by.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000223_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000223_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000223_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000223_0024BurstDirectCall()
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

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CBeingActedOnBy> acted_on_by)
			{
				acted_on_by.Clear();
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CBeingActedOnBy> acted_on_by = runtimes.runtime_acted_on_by.For(i);
					OriginalLambdaBody(e, ref acted_on_by);
				}
			}

			public void ScheduleTimeInitialize(AttemptInteraction componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000223_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					public LambdaParameterValueProvider_IComponentData<CInputData>.Runtime runtime_input;

					public LambdaParameterValueProvider_IComponentData<CIsInteractor>.Runtime runtime_interactor;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_player_position;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.Runtime runtime_player;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				private LambdaParameterValueProvider_IComponentData<CInputData> forParameter_input;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CIsInteractor> forParameter_interactor;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_player_position;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				public void ScheduleTimeInitialize(AttemptInteraction componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_input.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_interactor.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_input = forParameter_input.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interactor = forParameter_interactor.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player_position = forParameter_player_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool all_users_captured;

			public NativeHashSet<int> is_user_captured;

			public AttemptInteraction _003C_003E4__this;

			public NativeArray<Entity> interactives;

			public EntityContext ctx;

			public NativeArray<CIsInteractive> interactive_priority;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, int entityInQueryIndex, ref CInputData input, in CIsInteractor interactor, in CPosition player_position, in CPlayer player)
			{
				if (all_users_captured || is_user_captured.Contains(player.ID))
				{
					input.IsCaptured = true;
					return;
				}
				input.IsCaptured = false;
				InteractionType interactionType = InteractionType.Look;
				bool isHeld = false;
				if (input.State.GrabAction == ButtonState.Pressed)
				{
					interactionType = InteractionType.Grab;
				}
				else if (input.State.InteractAction == ButtonState.Pressed || input.State.InteractAction == ButtonState.Held)
				{
					interactionType = InteractionType.Act;
					isHeld = input.State.InteractAction == ButtonState.Held;
				}
				else if (input.State.SecondaryAction2 == ButtonState.Pressed)
				{
					interactionType = InteractionType.Notify;
				}
				float3 float5 = math.normalizesafe(new float3(input.State.Movement.x, 0f, input.State.Movement.y), math.mul(player_position.Rotation, new float3(0f, 0f, 1f)));
				float3 float6 = new float3(player_position.Position) + float5 * interactor.InteractionOffset;
				float num = interactor.InteractionRadius;
				if (!_003C_003E4__this.TileManager.CanReach(player_position, float6))
				{
					float6 = new float3(player_position.Position) + float5 * interactor.InteractionOffset * 0.25f;
					num *= 0.25f;
				}
				float num2 = num;
				Entity entity = default(Entity);
				bool flag = false;
				int length = interactives.Length;
				for (int i = 0; i < length; i++)
				{
					Entity entity2 = interactives[i];
					if (!ctx.Require<CPosition>(entity2, out var comp))
					{
						continue;
					}
					Vector3 vector = comp.Position - player_position.Position;
					float num3 = (comp.Position - (Vector3)float6).magnitude;
					if (vector.magnitude < 0.3f)
					{
						num3 = num2 * 0.9f;
						if (ctx.Require<CAppliance>(entity2, out var comp2))
						{
							float num4 = num3;
							num3 = num4 + comp2.Layer switch
							{
								OccupancyLayer.Default => 0f, 
								OccupancyLayer.Floor => 0.01f, 
								OccupancyLayer.Wall => 0.02f, 
								OccupancyLayer.Ceiling => 0.03f, 
								_ => 0.04f, 
							};
						}
						if (num3 > num)
						{
							continue;
						}
					}
					else if (num3 >= num + 0.01f || !_003C_003E4__this.TileManager.CanReach(player_position, comp) || (num3 > num - 0.05f && flag && interactive_priority[i].IsLowPriority))
					{
						continue;
					}
					entity = entity2;
					num = num3;
					flag = !interactive_priority[i].IsLowPriority;
				}
				if (entity != default(Entity))
				{
					if (!ctx.Has<CIsOnFire>(entity) && ctx.Require<CInteractionProxy>(entity, out var comp3) && comp3.IsActive)
					{
						entity = comp3.Target;
					}
					ecb.AddComponent(e, new CAttemptingInteraction
					{
						Mode = interactor.Mode,
						IsHeld = isHeld,
						Target = entity,
						Type = interactionType,
						Location = float6
					});
					switch (interactionType)
					{
					case InteractionType.Act:
						ecb.AddComponent(entity, default(CBeingActedOn));
						if (!_003C_003E4__this.HasBuffer<CBeingActedOnBy>(entity))
						{
							ecb.AddBuffer<CBeingActedOnBy>(entity);
						}
						ecb.AppendToBuffer(entity, new CBeingActedOnBy
						{
							Interactor = e
						});
						break;
					case InteractionType.Grab:
						ecb.AddComponent(entity, new CBeingGrabbed
						{
							Interactor = e
						});
						break;
					default:
						ecb.AddComponent(entity, new CBeingLookedAt
						{
							Interactor = e
						});
						break;
					}
				}
				else
				{
					ecb.AddComponent(e, new CAttemptingInteraction
					{
						Mode = interactor.Mode,
						IsHeld = isHeld,
						Type = interactionType,
						Location = float6
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				all_users_captured = displayClass.all_users_captured;
				is_user_captured = displayClass.is_user_captured;
				_003C_003E4__this = displayClass._003C_003E4__this;
				interactives = displayClass.interactives;
				ctx = displayClass.ctx;
				interactive_priority = displayClass.interactive_priority;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				displayClass.all_users_captured = all_users_captured;
				displayClass.is_user_captured = is_user_captured;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.interactives = interactives;
				displayClass.ctx = ctx;
				displayClass.interactive_priority = interactive_priority;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_input.For(i), in runtimes.runtime_interactor.For(i), in runtimes.runtime_player_position.For(i), in runtimes.runtime_player.For(i));
				}
			}

			public void ScheduleTimeInitialize(AttemptInteraction componentSystem, ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery InteractivesQuery;

		private EntityQuery InteractivesQueryToClear;

		private EntityQuery ApplianceQuery;

		private EntityQuery ApplianceQueryActedOnBy;

		private EntityQuery ApplianceQueryGrabbed;

		private EntityQuery ApplianceQueryActed;

		private EntityQuery ApplianceQueryLooked;

		private EntityQuery InputCaptures;

		private NativeHashSet<int> IsUserCaptured;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			InteractivesQuery = GetEntityQuery(new QueryHelper().All(typeof(CIsInteractive), typeof(CPosition)).None(typeof(CDemoLock), typeof(CHeldAppliance)));
			InteractivesQueryToClear = GetEntityQuery(new QueryHelper().All(typeof(CIsInteractive), typeof(CPosition), typeof(CAttemptingInteraction)).None(typeof(CDemoLock), typeof(CHeldAppliance)));
			QueryHelper queryHelper = new QueryHelper().Any(typeof(CIsInteractive), typeof(CInteractionProxy));
			ApplianceQuery = GetEntityQuery(queryHelper);
			ApplianceQueryActedOnBy = GetEntityQuery(queryHelper.All(typeof(CBeingActedOnBy)));
			ApplianceQueryGrabbed = GetEntityQuery(queryHelper.All(typeof(CBeingGrabbed)));
			ApplianceQueryActed = GetEntityQuery(queryHelper.All(typeof(CBeingActedOn)));
			ApplianceQueryLooked = GetEntityQuery(queryHelper.All(typeof(CBeingLookedAt)));
			InputCaptures = GetEntityQuery(new QueryHelper().All(typeof(CCaptureInput)).None(typeof(CCapturePassthrough)));
			IsUserCaptured = new NativeHashSet<int>(10, Allocator.Persistent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			IsUserCaptured.Dispose();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass11_0 displayClass = new _003C_003Ec__DisplayClass11_0
			{
				_003C_003E4__this = this
			};
			NativeArray<CCaptureInput> nativeArray = InputCaptures.ToComponentDataArray<CCaptureInput>(Allocator.Temp);
			IsUserCaptured.Clear();
			displayClass.all_users_captured = false;
			foreach (CCaptureInput item in nativeArray)
			{
				IsUserCaptured.Add(item.UserID);
				displayClass.all_users_captured = displayClass.all_users_captured || item.AllUsers;
			}
			nativeArray.Dispose();
			displayClass.is_user_captured = IsUserCaptured;
			base.EntityManager.RemoveComponent(ApplianceQueryGrabbed, typeof(CBeingGrabbed));
			base.EntityManager.RemoveComponent(ApplianceQueryActed, typeof(CBeingActedOn));
			base.EntityManager.RemoveComponent(ApplianceQueryLooked, typeof(CBeingLookedAt));
			base.EntityManager.RemoveComponent(InteractivesQueryToClear, typeof(CAttemptingInteraction));
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
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
			if (!HasSingleton<SLayout>() || base.Time.IsPaused)
			{
				return;
			}
			displayClass.ecb = new EntityCommandBuffer(Allocator.TempJob);
			try
			{
				displayClass.interactives = InteractivesQuery.ToEntityArray(Allocator.TempJob);
				try
				{
					displayClass.interactive_priority = InteractivesQuery.ToComponentDataArray<CIsInteractive>(Allocator.TempJob);
					try
					{
						displayClass.ctx = new EntityContext(base.EntityManager);
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
						displayClass.ecb.Playback(base.EntityManager);
					}
					finally
					{
						((IDisposable)displayClass.interactive_priority/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)displayClass.interactives/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.ecb/*cast due to .constrained prefix*/).Dispose();
			}
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CBeingActedOnBy>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadWrite<CInputData>(),
				ComponentType.ReadOnly<CIsInteractor>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CPlayer>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000223_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000223_0024BurstDirectCall.Initialize();
		}
	}
}
