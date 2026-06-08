#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class AppliancePatcher : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public AppliancePatcher _003C_003E4__this;

			public EntityContext ctx;

			internal void _003CAfterLoading_003Eb__0(Entity e, in CAppliance app)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_app;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_app;

				public void ScheduleTimeInitialize(AppliancePatcher componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public AppliancePatcher _003C_003E4__this;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CAppliance app)
			{
				if (!GameData.Main.TryGet<Appliance>(app, out var output))
				{
					return;
				}
				foreach (IApplianceProperty property in output.Properties)
				{
					if (property is CApplianceSinkBin value)
					{
						_003C_003E4__this.Update(e, value, ctx);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ctx = ctx;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_app.For(i));
				}
			}

			public void ScheduleTimeInitialize(AppliancePatcher componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EAfterLoading_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EAfterLoading_LambdaJob0_profilerMarker;

		public override void AfterLoading(SaveSystemType system_type)
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this
			};
			using EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			displayClass.ctx = new EntityContext(base.EntityManager, ecb);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EAfterLoading_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EAfterLoading_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EAfterLoading_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			displayClass.ctx.Playback();
		}

		protected void Update<T>(Entity e, T value, EntityContext ctx) where T : struct, IApplianceProperty
		{
			if (!ctx.Has<T>(e))
			{
				ctx.Set(e, value);
				Debug.LogWarning($"Patching {e} to have a copy of {value.GetType()}");
			}
		}

		protected override void OnUpdate()
		{
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EAfterLoading_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForAfterLoading_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.RunWithoutJobSystem;
			_003C_003EAfterLoading_LambdaJob0_profilerMarker = new ProfilerMarker("AfterLoading_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForAfterLoading_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CAppliance>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
