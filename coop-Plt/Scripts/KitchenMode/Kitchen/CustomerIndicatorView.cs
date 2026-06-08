#define ENABLE_PROFILER
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using Shapes;
using TMPro;
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
	[Serializable]
	public class CustomerIndicatorView : UpdatableObjectView<CustomerIndicatorView.ViewData>
	{
		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public BurstContext bctx;

				public bool is_hidden;

				public EntityContext ctx;

				public PatienceReason patience_reason;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CCustomerIndicator indicator)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}

				internal void _003CPopulateNewViewUpdates_003Eb__1(Entity entity, int entityInQueryIndex, in CHasIndicator indicator, in CPatience patience)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[NoAlias]
			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						[NoAlias]
						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CCustomerIndicator>.Runtime runtime_indicator;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CCustomerIndicator> forParameter_indicator;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000C6C_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000C6C_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000C6C_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000C6C_0024BurstDirectCall()
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

				public BurstContext bctx;

				public bool is_hidden;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CCustomerIndicator indicator)
				{
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						HasPatience = indicator.HasPatience,
						Patience = indicator.Patience,
						PatienceReason = indicator.PatienceReason,
						PatienceFactors = indicator.PatienceFactors,
						Drink = indicator.Drink,
						WantsDrink = indicator.WantsDrink,
						IsObfuscated = is_hidden
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					bctx = displayClass.bctx;
					is_hidden = displayClass.is_hidden;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass.bctx = bctx;
					displayClass.is_hidden = is_hidden;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_indicator.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000C6C_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			[Unity.Entities.DOTSCompilerGenerated]
			[BurstCompile]
			[NoAlias]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						[NoAlias]
						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CHasIndicator>.Runtime runtime_indicator;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CHasIndicator> forParameter_indicator;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000C75_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000C75_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000C75_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000C75_0024BurstDirectCall()
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

				public EntityContext ctx;

				public BurstContext bctx;

				public PatienceReason patience_reason;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CHasIndicator indicator, in CPatience patience)
				{
					if (ctx.Require<CLinkedView>(indicator.Indicator, out var comp))
					{
						bctx.ProposeUpdate(comp, new ViewData
						{
							HasPatience = patience.Active,
							Patience = ((patience.StartTime > 0f) ? patience.RemainingTime : 1f),
							PatienceReason = patience_reason,
							IsHidden = !patience.Active
						});
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					ctx = displayClass.ctx;
					bctx = displayClass.bctx;
					patience_reason = displayClass.patience_reason;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass.ctx = ctx;
					displayClass.bctx = bctx;
					displayClass.patience_reason = patience_reason;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_indicator.For(i), in runtimes.runtime_patience.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000C75_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SWeatherPrecipitation_15;

			protected bool HasStatus(RestaurantStatus status)
			{
				return GetOrCreate<SGlobalStatusList>().Has(status);
			}

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
				{
					bctx = bctx,
					is_hidden = HasStatus(RestaurantStatus.HiddenPatienceBars),
					ctx = new EntityContext(base.EntityManager)
				};
				_ = base.Entities;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
				}
				finally
				{
					_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
				}
				jobData.WriteToDisplayClass(ref displayClass);
				displayClass.patience_reason = PatienceReason.Queue;
				if (HasSingleton<SWeatherDarkness>())
				{
					displayClass.patience_reason = PatienceReason.QueueInDarkness;
				}
				else if (HasSingleton<SWeatherPrecipitation>())
				{
					SWeatherPrecipitation singleton = _SingletonEntityQuery_SWeatherPrecipitation_15.GetSingleton<SWeatherPrecipitation>();
					if (singleton.IsActive)
					{
						displayClass.patience_reason = singleton.Mode switch
						{
							WeatherMode.None => displayClass.patience_reason, 
							WeatherMode.Rain => PatienceReason.QueueInRain, 
							WeatherMode.Snow => PatienceReason.QueueInSnow, 
							_ => displayClass.patience_reason, 
						};
					}
				}
				_ = base.Entities;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query2 = _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer2);
				}
				finally
				{
					_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.End();
				}
				jobData2.WriteToDisplayClass(ref displayClass);
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
				_003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob1");
				_SingletonEntityQuery_SWeatherPrecipitation_15 = GetEntityQuery(ComponentType.ReadOnly<SWeatherPrecipitation>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CCustomerIndicator>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<SQueueMarker>(),
					ComponentType.ReadOnly<CHasIndicator>(),
					ComponentType.ReadOnly<CPatience>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000C6C_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000C6C_0024BurstDirectCall.Initialize();
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1_RunWithoutJobSystem_00000C75_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem_00000C75_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public bool HasPatience;

			[Key(1)]
			public float Patience;

			[Key(2)]
			public PatienceReason PatienceReason;

			[Key(3)]
			public DrinkData Drink;

			[Key(4)]
			public bool WantsDrink;

			[Key(5)]
			public bool IsHidden;

			[Key(6)]
			public DisplayedPatienceFactor PatienceFactors;

			[Key(7)]
			public bool IsObfuscated;

			public bool IsChangedFrom(ViewData check)
			{
				if (HasPatience == check.HasPatience && Patience == check.Patience && PatienceReason == check.PatienceReason && !(Drink != check.Drink) && WantsDrink == check.WantsDrink && IsHidden == check.IsHidden && IsObfuscated == check.IsObfuscated)
				{
					return PatienceFactors != check.PatienceFactors;
				}
				return true;
			}
		}

		[SerializeField]
		[Header("References")]
		private Animator Animator;

		[SerializeField]
		private Rectangle Patience;

		[SerializeField]
		private GameObject PatienceContainer;

		[SerializeField]
		private Rectangle PatienceBacking;

		[SerializeField]
		private TextMeshPro Icon;

		[SerializeField]
		private IconSetElement Icons;

		[SerializeField]
		private Line ProgressBarHiddenBottom;

		[SerializeField]
		private Line ProgressBarHiddenTop;

		[SerializeField]
		private GameObject DrinkContainer;

		[SerializeField]
		private Disc DrinkComponent1;

		[SerializeField]
		private Disc DrinkComponent2;

		[SerializeField]
		private Disc DrinkComponent3;

		[Header("State")]
		private bool HasPerformedUpdate;

		private ViewData Data;

		private float BarFullY;

		private float BarFullHeight;

		private static readonly int IsWarning = Animator.StringToHash("IsWarning");

		public override void Initialise()
		{
			base.Initialise();
			BarFullY = Patience.transform.localPosition.y;
			BarFullHeight = Patience.Height;
			Animator.Update(0f);
		}

		private void SetBar(float fraction)
		{
			float num = fraction * BarFullHeight;
			Vector3 localPosition = Patience.transform.localPosition;
			localPosition.y = BarFullY - (BarFullHeight - num) / 2f;
			Patience.transform.localPosition = localPosition;
			Patience.Height = num;
		}

		private void Update()
		{
			if (Data.IsObfuscated)
			{
				float num = 0.5f;
				ProgressBarHiddenTop.DashOffset = Time.time * num;
				ProgressBarHiddenBottom.DashOffset = Time.time * num;
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (Data.PatienceFactors != data.PatienceFactors)
			{
				Icons.Clear();
				foreach (DisplayedPatienceFactor item in Enum.GetValues(typeof(DisplayedPatienceFactor)).Cast<DisplayedPatienceFactor>())
				{
					if (Data.PatienceFactors.HasFlagFast(item))
					{
						Icons.Add(GameData.Main.GlobalLocalisation.GetIcon(item), "");
					}
				}
			}
			if (Data.IsObfuscated != data.IsObfuscated || Data.IsHidden != data.IsHidden || Data.HasPatience != data.HasPatience)
			{
				base.gameObject.SetActive(!Data.IsHidden);
				ProgressBarHiddenTop.gameObject.SetActive(!Data.IsHidden && Data.IsObfuscated && Data.HasPatience);
				ProgressBarHiddenBottom.gameObject.SetActive(!Data.IsHidden && Data.IsObfuscated && Data.HasPatience);
				Patience.gameObject.SetActive(!Data.IsHidden && !Data.IsObfuscated);
				if (!Data.IsHidden)
				{
					Animator.Update(0f);
				}
			}
			if (Math.Abs(Data.Patience - data.Patience) > 1E-05f || !HasPerformedUpdate)
			{
				float num = Data.Patience * Data.Patience;
				float bar = Mathf.Clamp01(num * 1.01f - 0.01f);
				SetBar(bar);
				if (Data.Patience < 0.5f)
				{
					float num2 = 1f - num;
					float num3 = num2 * num2 * num2;
					float f = 50f * (1f - Data.Patience / 0.5f);
					Color color = Color.Lerp(new Color(0.27f, 0.27f, 0.35f), new Color(0.93f, 0.27f, 0.12f) * Mathf.Pow(2f, 0.5f), Mathf.Abs(Mathf.Sin(f)) * num3);
					PatienceBacking.Color = color;
					Animator.SetBool(IsWarning, value: true);
				}
				else
				{
					PatienceBacking.Color = new Color(0.27f, 0.27f, 0.35f);
					Animator.SetBool(IsWarning, value: false);
				}
			}
			if (Data.PatienceReason != data.PatienceReason || !HasPerformedUpdate)
			{
				if (HasPerformedUpdate && base.gameObject.activeInHierarchy && Animator.isActiveAndEnabled)
				{
					Animator.Play("Swap Phase");
				}
				Icon.text = base.Localisation.GetIcon(Data.PatienceReason);
			}
			if (Data.HasPatience != data.HasPatience || !HasPerformedUpdate)
			{
				PatienceContainer.SetActive(Data.HasPatience);
			}
			if (Data.WantsDrink == data.WantsDrink)
			{
				_ = HasPerformedUpdate;
			}
			if (Data.Drink != data.Drink || !HasPerformedUpdate)
			{
				DrinkComponent1.Color = DrinkData.GetColour(Data.Drink.Component1);
				DrinkComponent2.Color = DrinkData.GetColour(Data.Drink.Component2);
				DrinkComponent3.Color = DrinkData.GetColour(Data.Drink.Component3);
			}
			HasPerformedUpdate = true;
		}

		private void UpdateBar(Disc bar, Vector2 range, float value, float old_value)
		{
			if (value != old_value)
			{
				float angRadiansEnd = value * (range.y - range.x) + range.x;
				bar.AngRadiansStart = range.x;
				bar.AngRadiansEnd = angRadiansEnd;
			}
		}
	}
}
