#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateInGroup(typeof(ApplyEffectsGroup))]
	[UpdateAfter(typeof(ApplyTableModifiers))]
	public class ApplyDecorationModifiers : GameSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_ent;

					public LambdaParameterValueProvider_IComponentData<CTableSetModifier>.Runtime runtime_modifier;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_ent;

				private LambdaParameterValueProvider_IComponentData<CTableSetModifier> forParameter_modifier;

				public void ScheduleTimeInitialize(ApplyDecorationModifiers componentSystem)
				{
					forParameter_ent.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_modifier.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_ent = forParameter_ent.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_modifier = forParameter_modifier.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ApplyDecorationModifiers hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity ent, ref CTableSetModifier modifier)
			{
				hostInstance._003COnUpdate_003Eb__1_0(ent, ref modifier);
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
					OriginalLambdaBody(runtimes.runtime_ent.For(i), ref runtimes.runtime_modifier.For(i));
				}
			}

			public void ScheduleTimeInitialize(ApplyDecorationModifiers componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private HashSet<DecorationBonus> CurrentBonuses = new HashSet<DecorationBonus>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			CurrentBonuses.Clear();
			DynamicBuffer<CDecorationScore> decorationValue = GetDecorationValue();
			for (int i = 0; i < decorationValue.Length; i++)
			{
				CDecorationScore cDecorationScore = decorationValue[i];
				int bonusLevel = DecorationValues.GetBonusLevel((int)cDecorationScore);
				for (int j = 0; j <= bonusLevel; j++)
				{
					CurrentBonuses.Add(DecorationValues.Bonus(cDecorationScore, j));
				}
			}
			SetStatus(RestaurantStatus.HasQueuePatienceBoost, CurrentBonuses.Contains(DecorationBonus.QueuePatienceIncrease));
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
		private void _003COnUpdate_003Eb__1_0(Entity ent, ref CTableSetModifier modifier)
		{
			foreach (DecorationBonus currentBonuse in CurrentBonuses)
			{
				switch (currentBonuse)
				{
				case DecorationBonus.ExtraSides:
					modifier.OrderingModifiers.SidesModifier *= 2f;
					break;
				case DecorationBonus.FewerSides:
					modifier.OrderingModifiers.SidesModifier /= 2f;
					break;
				case DecorationBonus.MoneyPerDelivery:
					modifier.OrderingModifiers.BonusPerDelivery++;
					break;
				case DecorationBonus.InfinitePatienceIfQueue:
					modifier.PatienceModifiers.InfinitePatienceIfQueue = true;
					break;
				case DecorationBonus.QueuePatienceIncrease:
					modifier.PatienceModifiers.ProvidesQueuePatienceBoost = true;
					break;
				case DecorationBonus.WaitTimeDecrease:
					modifier.PatienceModifiers.Thinking /= 2f;
					modifier.PatienceModifiers.Eating /= 2f;
					break;
				case DecorationBonus.ConsumableReuseChance:
					modifier.OrderingModifiers.ConsumableReuseChance = 1f - (1f - modifier.OrderingModifiers.ConsumableReuseChance) * 0.5f;
					break;
				case DecorationBonus.DestroyTableWhenLeave:
					modifier.PatienceModifiers.DestroyTableIfLeave = true;
					break;
				case DecorationBonus.IncreasedServicePatience:
					modifier.PatienceModifiers.Service *= 1.5f;
					break;
				case DecorationBonus.BonusPatienceNearby:
					modifier.PatienceModifiers.BonusPatienceWhenNearby = true;
					break;
				case DecorationBonus.ResetPatienceAbility:
					modifier.PatienceModifiers.ResetPatienceOption = true;
					break;
				case DecorationBonus.IncreasedMess:
					modifier.OrderingModifiers.MessFactor *= 1.5f;
					break;
				case DecorationBonus.DecreasedOrderPatience:
					modifier.PatienceModifiers.WaitForFood *= 0.5f;
					break;
				case DecorationBonus.IncreasedOrderChangeChance:
					modifier.OrderingModifiers.ChangeMindModifier += 0.25f;
					break;
				case DecorationBonus.DecreasedMess:
					modifier.OrderingModifiers.MessFactor *= 0.75f;
					break;
				case DecorationBonus.IncreasedDeliveryPatience:
					modifier.PatienceModifiers.FoodDeliverBonus += 10f;
					break;
				case DecorationBonus.PreventMess:
					modifier.OrderingModifiers.PreventMess = true;
					break;
				case DecorationBonus.InformalService:
					modifier.PatienceModifiers.WaitForFood *= 0.5f;
					modifier.PatienceModifiers.SkipWaitPhase = true;
					break;
				case DecorationBonus.SeatWithoutClear:
					modifier.OrderingModifiers.SeatWithoutClear = true;
					break;
				}
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CTableSetModifier>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
