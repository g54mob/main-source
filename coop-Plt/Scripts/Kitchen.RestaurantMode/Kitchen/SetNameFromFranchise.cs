#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class SetNameFromFranchise : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CHasRun : IComponentData
		{
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public FixedString64 incoming_name;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CRenameRestaurant name)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CRenameRestaurant>.Runtime runtime_name;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CRenameRestaurant> forParameter_name;

				public void ScheduleTimeInitialize(SetNameFromFranchise componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_name.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_name = forParameter_name.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public FixedString64 incoming_name;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CRenameRestaurant name)
			{
				name.Name = incoming_name;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				incoming_name = displayClass.incoming_name;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass.incoming_name = incoming_name;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_name.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetNameFromFranchise componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery HasRun;

		private EntityQuery Nameplates;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			HasRun = GetEntityQuery(typeof(CHasRun));
			Nameplates = GetEntityQuery(typeof(CRenameRestaurant));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = default(_003C_003Ec__DisplayClass4_0);
			if (!HasRun.IsEmpty || !RequireEntity<SKitchenLayout>(out var comp))
			{
				return;
			}
			displayClass.incoming_name = "";
			if (Require<CFranchiseItem>(comp, out CFranchiseItem comp2))
			{
				displayClass.incoming_name = comp2.Name;
			}
			else
			{
				if (!Require<CStartingName>(comp, out CStartingName comp3))
				{
					Set<CHasRun>();
					return;
				}
				displayClass.incoming_name = comp3.Name;
			}
			Set(new SRestaurantStartingName
			{
				Name = displayClass.incoming_name
			});
			if (!Nameplates.IsEmpty)
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
				}
				jobData.WriteToDisplayClass(ref displayClass);
				Set<CHasRun>();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CRenameRestaurant>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
