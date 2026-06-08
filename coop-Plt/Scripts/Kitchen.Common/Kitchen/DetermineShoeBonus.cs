#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class DetermineShoeBonus : GenericSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.Runtime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CShoeEffect>.Runtime runtime_shoes;

					public LambdaParameterValueProvider_IComponentData<CPlayerCosmetics>.Runtime runtime_cosmetics;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				private LambdaParameterValueProvider_IComponentData<CShoeEffect> forParameter_shoes;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayerCosmetics> forParameter_cosmetics;

				public void ScheduleTimeInitialize(DetermineShoeBonus componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_shoes.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_cosmetics.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_shoes = forParameter_shoes.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_cosmetics = forParameter_cosmetics.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public DetermineShoeBonus hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, ref CPlayer player, ref CShoeEffect shoes, [In] ref CPlayerCosmetics cosmetics)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref player, ref shoes, in cosmetics);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_player.For(i), ref runtimes.runtime_shoes.For(i), ref runtimes.runtime_cosmetics.For(i));
				}
			}

			public void ScheduleTimeInitialize(DetermineShoeBonus componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
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
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CPlayer player, ref CShoeEffect shoes, in CPlayerCosmetics cosmetics)
		{
			shoes.SpeedModifier = 0f;
			shoes.IgnoreMess = false;
			if (cosmetics.Shoe == PlayerShoe.Trainers)
			{
				if (Has<CPlayerDirtyShoes>(e))
				{
					shoes.SpeedModifier = -0.4f;
				}
				else
				{
					shoes.SpeedModifier = 0.2f;
				}
			}
			if (cosmetics.Shoe == PlayerShoe.Wellies)
			{
				shoes.IgnoreMess = true;
				shoes.SpeedModifier = -0.2f;
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<CPlayer>(),
				ComponentType.ReadWrite<CShoeEffect>(),
				ComponentType.ReadOnly<CPlayerCosmetics>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
