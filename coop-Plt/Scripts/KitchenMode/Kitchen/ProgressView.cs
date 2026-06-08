#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public class ProgressView : UpdatableObjectView<ProgressView.ViewData>
	{
		public class UpdateProgressView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass2_0
			{
				public BurstContext bctx;

				public bool is_hidden;

				public UpdateProgressView _003C_003E4__this;

				public EntityCommandBuffer ecb;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CProgressIndicator progress)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}

				internal void _003CPopulateNewViewUpdates_003Eb__1(Entity e, in CProgressIndicator indicator, in CInterfaceOf relates)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[Unity.Entities.DOTSCompilerGenerated]
			[BurstCompile]
			[NoAlias]
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
						public LambdaParameterValueProvider_IComponentData<CProgressIndicator>.Runtime runtime_progress;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CProgressIndicator> forParameter_progress;

					public void ScheduleTimeInitialize(UpdateProgressView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_progress.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_progress = forParameter_progress.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000CDF_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000CDF_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000CDF_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000CDF_0024BurstDirectCall()
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
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CProgressIndicator progress)
				{
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						IsBad = progress.IsBad,
						Progress = progress.Progress,
						Process = progress.Process,
						UnknownLength = (progress.IsUnknownLength | is_hidden),
						CurrentChange = progress.CurrentChange
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					bctx = displayClass.bctx;
					is_hidden = displayClass.is_hidden;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_progress.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateProgressView componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000CDF_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			[NoAlias]
			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_e;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CProgressIndicator>.Runtime runtime_indicator;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CInterfaceOf>.Runtime runtime_relates;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_e;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CProgressIndicator> forParameter_indicator;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CInterfaceOf> forParameter_relates;

					public void ScheduleTimeInitialize(UpdateProgressView componentSystem)
					{
						forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_relates.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_relates = forParameter_relates.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000CE8_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000CE8_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000CE8_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000CE8_0024BurstDirectCall()
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

				[NoAlias]
				[ReadOnly]
				private ComponentDataFromEntity<CHasProgressIndicator> _ComponentDataFromEntity_CHasProgressIndicator_0;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity e, in CProgressIndicator indicator, in CInterfaceOf relates)
				{
					if (!_ComponentDataFromEntity_CHasProgressIndicator_0.HasComponent(relates))
					{
						ecb.DestroyEntity(e);
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					ecb = displayClass.ecb;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
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
						OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_indicator.For(i), in runtimes.runtime_relates.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateProgressView componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
					_ComponentDataFromEntity_CHasProgressIndicator_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CHasProgressIndicator>(true);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000CE8_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker;

			protected bool HasStatus(RestaurantStatus status)
			{
				return GetOrCreate<SGlobalStatusList>().Has(status);
			}

			protected override void Initialise()
			{
				base.Initialise();
				RequireForUpdate(GetEntityQuery(typeof(CProgressIndicator)));
			}

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
				{
					bctx = bctx,
					_003C_003E4__this = this,
					is_hidden = HasStatus(RestaurantStatus.HiddenProgressBars)
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
				displayClass.ecb = GetCommandBuffer(ECB.End);
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
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CProgressIndicator>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CProgressIndicator>(),
					ComponentType.ReadOnly<CInterfaceOf>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000CDF_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000CDF_0024BurstDirectCall.Initialize();
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1_RunWithoutJobSystem_00000CE8_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem_00000CE8_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public bool IsBad;

			[Key(1)]
			public float Progress;

			[Key(2)]
			public int Process;

			[Key(3)]
			public bool UnknownLength;

			[Key(4)]
			public float CurrentChange;

			public bool IsChangedFrom(ViewData check)
			{
				if (IsBad == check.IsBad && !(Math.Abs(Progress - check.Progress) > 0.001f) && Process == check.Process && UnknownLength == check.UnknownLength)
				{
					return Math.Abs(CurrentChange - check.CurrentChange) > 0.001f;
				}
				return true;
			}
		}

		[SerializeField]
		[Header("References")]
		private GameObject ProgressIndicator;

		[SerializeField]
		private Rectangle ProgressBar;

		[SerializeField]
		private Line ProgressBarHiddenBottom;

		[SerializeField]
		private Line ProgressBarHiddenTop;

		[SerializeField]
		private TextMeshPro Icon;

		[SerializeField]
		private GameObject WarningIndicator;

		[Header("State")]
		private ViewData Data;

		private float BarFullX;

		private float BarFullWidth;

		private bool AllowObfuscation = true;

		private float EstimatedProgress;

		public override void Initialise()
		{
			base.Initialise();
			ProgressBar.Color = new Color(0.6f, 1f, 0.4f);
			BarFullX = ProgressBar.transform.localPosition.x;
			BarFullWidth = ProgressBar.Width;
			ProgressBar.Width = 0f;
		}

		public override void SetPosition(UpdateViewPositionData pos)
		{
			PositionInterpolator.Report(pos.Position, pos.GameTime, pos.Force);
			UpdatePosition();
		}

		private void SetBar(float fraction)
		{
			float num = fraction * BarFullWidth;
			Vector3 localPosition = ProgressBar.transform.localPosition;
			localPosition.x = BarFullX - (BarFullWidth - num) / 2f;
			ProgressBar.transform.localPosition = localPosition;
			ProgressBar.Width = num;
		}

		private void Update()
		{
			if (Data.CurrentChange != 0f)
			{
				float deltaTime = Time.deltaTime;
				if (Data.UnknownLength && AllowObfuscation)
				{
					ProgressBarHiddenTop.DashOffset += deltaTime;
					ProgressBarHiddenBottom.DashOffset += deltaTime;
				}
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (Data.Process != data.Process)
			{
				if (Data.Process != -1 && GameData.Main.TryGet<Process>(Data.Process, out var output, warn_if_fail: true))
				{
					AllowObfuscation = output.CanObfuscateProgress;
					Icon.text = output.Icon;
				}
				else
				{
					Icon.text = GameData.Main.Parse("$split$");
				}
			}
			if (Data.Process != data.Process || Data.UnknownLength != data.UnknownLength)
			{
				bool flag = Data.UnknownLength && AllowObfuscation;
				ProgressBarHiddenTop.gameObject.SetActive(flag);
				ProgressBarHiddenBottom.gameObject.SetActive(flag);
				ProgressBar.gameObject.SetActive(!flag);
			}
			if (Data.IsBad != data.IsBad)
			{
				WarningIndicator.SetActive(Data.IsBad);
			}
			if (Math.Abs(Data.Progress - data.Progress) > 0.001f)
			{
				EstimatedProgress = Data.Progress;
				SetProgress(Data.Progress);
			}
		}

		private void SetProgress(float amount)
		{
			if (!ProgressIndicator.activeSelf)
			{
				ProgressIndicator.SetActive(value: true);
			}
			amount = Mathf.Clamp01(amount);
			SetBar(amount);
			Color color;
			if (!Data.IsBad)
			{
				color = ((!(amount > 0.9f) || (Data.UnknownLength && AllowObfuscation)) ? new Color(0.6f, 1f, 0.4f) : Color.Lerp(new Color(0.6f, 1f, 0.4f), new Color(0.75f, 1f, 0.69f), (Data.Progress - 0.9f) * 20f));
			}
			else
			{
				float num = amount * amount * amount;
				float t = Mathf.Abs(Mathf.Cos(31f * num)) * num;
				color = Color.Lerp(new Color(1f, 0.93f, 0.07f), new Color(0.93f, 0.27f, 0.12f), t);
			}
			ProgressBarHiddenTop.Color = color;
			ProgressBarHiddenBottom.Color = color;
			ProgressBar.Color = color;
		}
	}
}
