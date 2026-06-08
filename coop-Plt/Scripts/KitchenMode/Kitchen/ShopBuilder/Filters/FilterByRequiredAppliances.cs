#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;

namespace Kitchen.ShopBuilder.Filters
{
	[UpdateAfter(typeof(TagStaples))]
	public class FilterByRequiredAppliances : ShopBuilderFilter
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass5_0
		{
			public NativeHashMap<int, ShopBuilderApplianceInfo> app_cache;

			public NativeHashSet<int> owned_apps;

			public SystemReference sys_ref;

			internal void _003CFilter_003Eb__0(Entity e, ref CShopBuilderOption option)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[BurstCompile]
		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Filter_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CShopBuilderOption>.Runtime runtime_option;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CShopBuilderOption> forParameter_option;

				public void ScheduleTimeInitialize(FilterByRequiredAppliances componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_option.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_option = forParameter_option.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000F64_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000F64_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000F64_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000F64_0024BurstDirectCall()
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

			public NativeHashMap<int, ShopBuilderApplianceInfo> app_cache;

			public NativeHashSet<int> owned_apps;

			public SystemReference sys_ref;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref CShopBuilderOption option)
			{
				if (!option.IsRemoved && option.Staple != ShopStapleType.BonusStaple && option.Staple != ShopStapleType.WhenMissing && app_cache.TryGetValue(option.Appliance, out var item) && !HasRequirements(item, owned_apps))
				{
					option.IsRemoved = true;
					option.FilteredBy = sys_ref;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				app_cache = displayClass.app_cache;
				owned_apps = displayClass.owned_apps;
				sys_ref = displayClass.sys_ref;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				displayClass.app_cache = app_cache;
				displayClass.owned_apps = owned_apps;
				displayClass.sys_ref = sys_ref;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_option.For(i));
				}
			}

			public void ScheduleTimeInitialize(FilterByRequiredAppliances componentSystem, ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000F64_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_Filter_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Appliances;

		private NativeHashSet<int> OwnedApplianceIDs = new NativeHashSet<int>(128, Allocator.Persistent);

		private EntityQuery _003C_003EFilter_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EFilter_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Appliances = GetEntityQuery(typeof(CAppliance));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			OwnedApplianceIDs.Dispose();
		}

		protected override void BeforeRun()
		{
			base.BeforeRun();
			using NativeArray<CAppliance> nativeArray = Appliances.ToComponentDataArray<CAppliance>(Allocator.TempJob);
			OwnedApplianceIDs.Clear();
			foreach (CAppliance item in nativeArray)
			{
				OwnedApplianceIDs.Add(item.ID);
			}
		}

		protected override void Filter()
		{
			_003C_003Ec__DisplayClass5_0 displayClass = new _003C_003Ec__DisplayClass5_0
			{
				sys_ref = this,
				owned_apps = OwnedApplianceIDs,
				app_cache = base.World.GetOrCreateSystem<CreateShopOptions>().CachedApplianceInfo
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_Filter_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_Filter_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EFilter_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_Filter_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_Filter_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EFilter_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
			}
			finally
			{
				_003C_003EFilter_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
		}

		private static bool HasRequirements(ShopBuilderApplianceInfo app, NativeHashSet<int> owned_apps)
		{
			if (app.SellOnlyAsDuplicate && !owned_apps.Contains(app.ID))
			{
				return false;
			}
			if (app.SellOnlyAsUnique && owned_apps.Contains(app.ID))
			{
				return false;
			}
			if (app.RequiresForShop.Count == 0)
			{
				return true;
			}
			foreach (int item in app.RequiresForShop)
			{
				if (owned_apps.Contains(item))
				{
					return true;
				}
			}
			return false;
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EFilter_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForFilter_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_Filter_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Filter_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_Filter_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_Filter_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EFilter_LambdaJob0_profilerMarker = new ProfilerMarker("Filter_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForFilter_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CShopBuilderOption>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_Filter_LambdaJob0_RunWithoutJobSystem_00000F64_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_Filter_LambdaJob0.RunWithoutJobSystem_00000F64_0024BurstDirectCall.Initialize();
		}
	}
}
