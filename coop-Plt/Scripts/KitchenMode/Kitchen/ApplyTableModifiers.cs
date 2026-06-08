#define ENABLE_PROFILER
using System.Collections.Generic;
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
	[UpdateInGroup(typeof(ApplyEffectsGroup))]
	public class ApplyTableModifiers : GameSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CTableSetModifier>.Runtime runtime_modifier;

					public LambdaParameterValueProvider_DynamicBuffer<CTableAffectedBy>.Runtime runtime_table_affected_by;

					public LambdaParameterValueProvider_DynamicBuffer<CTableSetParts>.Runtime runtime_parts;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_player;

				private LambdaParameterValueProvider_IComponentData<CTableSetModifier> forParameter_modifier;

				private LambdaParameterValueProvider_DynamicBuffer<CTableAffectedBy> forParameter_table_affected_by;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CTableSetParts> forParameter_parts;

				public void ScheduleTimeInitialize(ApplyTableModifiers componentSystem)
				{
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_modifier.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_table_affected_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_parts.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_modifier = forParameter_modifier.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table_affected_by = forParameter_table_affected_by.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_parts = forParameter_parts.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ApplyTableModifiers hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity player, ref CTableSetModifier modifier, ref DynamicBuffer<CTableAffectedBy> table_affected_by, [In] ref DynamicBuffer<CTableSetParts> parts)
			{
				hostInstance._003COnUpdate_003Eb__2_0(player, ref modifier, ref table_affected_by, in parts);
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
					Entity player = runtimes.runtime_player.For(i);
					ref CTableSetModifier modifier = ref runtimes.runtime_modifier.For(i);
					DynamicBuffer<CTableAffectedBy> table_affected_by = runtimes.runtime_table_affected_by.For(i);
					DynamicBuffer<CTableSetParts> parts = runtimes.runtime_parts.For(i);
					OriginalLambdaBody(player, ref modifier, ref table_affected_by, ref parts);
				}
			}

			public void ScheduleTimeInitialize(ApplyTableModifiers componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private readonly HashSet<int> Representations = new HashSet<int>();

		private readonly HashSet<Entity> AffectedBy = new HashSet<Entity>();

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
		private void _003COnUpdate_003Eb__2_0(Entity player, ref CTableSetModifier modifier, ref DynamicBuffer<CTableAffectedBy> table_affected_by, in DynamicBuffer<CTableSetParts> parts)
		{
			PatienceValues patienceModifiers = PatienceValues.Ones;
			OrderingValues orderingModifiers = OrderingValues.Ones;
			DecorationValues decorationModifiers = DecorationValues.Neutral;
			float num = 1f;
			AffectedBy.Clear();
			table_affected_by.Clear();
			for (int i = 0; i < parts.Length; i++)
			{
				CTableSetParts cTableSetParts = parts[i];
				if (HasComponent<CAffectedBy.Marker>(cTableSetParts))
				{
					DynamicBuffer<CAffectedBy> buffer = GetBuffer<CAffectedBy>(cTableSetParts);
					for (int j = 0; j < buffer.Length; j++)
					{
						AffectedBy.Add(buffer[j].Entity);
					}
				}
			}
			Representations.Clear();
			foreach (Entity item in AffectedBy)
			{
				CAppliesEffect comp;
				bool flag = Require<CAppliesEffect>(item, out comp) && comp.IsActive;
				if (item != parts[0] && Has<CEffectRangeTableSet>(item))
				{
					continue;
				}
				if (base.Data.TryGet<Appliance>(GetOrDefault<CAppliance>(item).ID, out var output) && output.EffectRepresentation != null)
				{
					int iD = output.EffectRepresentation.ID;
					if (Representations.Contains(iD))
					{
						continue;
					}
					table_affected_by.Add(new CTableAffectedBy
					{
						Active = flag,
						EffectRepresentation = iD
					});
					Representations.Add(iD);
				}
				if (flag && HasComponent<CTableModifier>(item))
				{
					CTableModifier component = GetComponent<CTableModifier>(item);
					patienceModifiers = patienceModifiers.ApplyModifiers(component.PatienceModifiers);
					orderingModifiers = orderingModifiers.ApplyModifiers(component.OrderingModifiers);
					decorationModifiers = decorationModifiers.ApplyModifiers(component.DecorationModifiers);
					num += component.Attractiveness;
				}
			}
			modifier = new CTableSetModifier
			{
				PatienceModifiers = patienceModifiers,
				OrderingModifiers = orderingModifiers,
				DecorationModifiers = decorationModifiers,
				Attractiveness = num
			};
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadOnly<CTableSet>(),
				ComponentType.ReadWrite<CTableSetModifier>(),
				ComponentType.ReadWrite<CTableAffectedBy>(),
				ComponentType.ReadOnly<CTableSetParts>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
