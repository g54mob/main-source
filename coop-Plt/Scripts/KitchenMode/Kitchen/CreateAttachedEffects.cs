#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateBefore(typeof(ResetEffects))]
	[UpdateInGroup(typeof(EffectsGroup), OrderFirst = true)]
	public class CreateAttachedEffects : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public CreateAttachedEffects _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public bool made_effect;

			internal void _003COnUpdate_003Eb__0(Entity e, in CEffectCreator creator, in CHeldBy held_by)
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

					public LambdaParameterValueProvider_IComponentData<CEffectCreator>.Runtime runtime_creator;

					public LambdaParameterValueProvider_IComponentData<CHeldBy>.Runtime runtime_held_by;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CEffectCreator> forParameter_creator;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_held_by;

				public void ScheduleTimeInitialize(CreateAttachedEffects componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_creator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_held_by.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_creator = forParameter_creator.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_held_by = forParameter_held_by.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public CreateAttachedEffects _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public bool made_effect;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CNoAttachedBonuses> _ComponentDataFromEntity_CNoAttachedBonuses_0;

			[NoAlias]
			private BufferFromEntity<CAttachments> _BufferFromEntity_CAttachments_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAttachedEffect> _ComponentDataFromEntity_CAttachedEffect_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CEffectCreator creator, in CHeldBy held_by)
			{
				if (_ComponentDataFromEntity_CNoAttachedBonuses_0.HasComponent(held_by.Holder) || !creator.AffectTables || !_003C_003E4__this.Require<CPartOfTableSet>(held_by.Holder, out CPartOfTableSet comp) || _003C_003E4__this.Has<CNoTableConsumables>(held_by.Holder))
				{
					return;
				}
				DynamicBuffer<CAttachments> dynamicBuffer = _BufferFromEntity_CAttachments_1[held_by.Holder];
				if (!creator.AllowMultiple)
				{
					foreach (CAttachments item in dynamicBuffer)
					{
						if (_ComponentDataFromEntity_CAttachedEffect_2.HasComponent(item) && _ComponentDataFromEntity_CAttachedEffect_2[item].Source == creator.Source)
						{
							return;
						}
					}
				}
				if (!GameData.Main.TryGet<Effect>(creator.Source, out var output, warn_if_fail: true))
				{
					return;
				}
				Entity entity = ecb.CreateEntity();
				EffectHelpers.AddApplianceEffectComponents(ecb, entity, output);
				EffectHelpers.AddAttachedEffectComponents(ecb, entity, output);
				ecb.AddComponent(entity, new CPosition(_ComponentDataFromEntity_CPosition_3[held_by.Holder]));
				ecb.AddComponent(entity, new CAttachedEffect
				{
					Parent = held_by.Holder,
					Source = creator.Source
				});
				ecb.DestroyEntity(e);
				ecb.SetComponent(held_by.Holder, default(CItemHolder));
				made_effect = true;
				if (!_003C_003E4__this.RequireBuffer(comp.TableSet, out DynamicBuffer<CTableSetParts> comp2))
				{
					return;
				}
				foreach (CTableSetParts item2 in comp2)
				{
					ecb.AppendToBuffer((Entity)item2, (CAttachments)entity);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
				made_effect = displayClass.made_effect;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ecb = ecb;
				displayClass.made_effect = made_effect;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_creator.For(i), in runtimes.runtime_held_by.For(i));
				}
			}

			public void ScheduleTimeInitialize(CreateAttachedEffects componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CNoAttachedBonuses_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CNoAttachedBonuses>(true);
				_BufferFromEntity_CAttachments_1 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CAttachments>(false);
				_ComponentDataFromEntity_CAttachedEffect_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAttachedEffect>(true);
				_ComponentDataFromEntity_CPosition_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SRequireEffectUpdate_1;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
			};
			bool flag = HasSingleton<SRequireEffectUpdate>();
			displayClass.made_effect = false;
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
			if (displayClass.made_effect && !flag)
			{
				Entity e = displayClass.ecb.CreateEntity();
				displayClass.ecb.AddComponent(e, (ComponentType)typeof(SRequireEffectUpdate));
			}
			if (!displayClass.made_effect && flag)
			{
				displayClass.ecb.DestroyEntity(_SingletonEntityQuery_SRequireEffectUpdate_1.GetSingletonEntity());
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SRequireEffectUpdate_1 = GetEntityQuery(ComponentType.ReadOnly<SRequireEffectUpdate>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CEffectCreator>(),
				ComponentType.ReadOnly<CHeldBy>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
