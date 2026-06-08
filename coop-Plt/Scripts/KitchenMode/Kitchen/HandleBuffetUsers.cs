#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferLatePrune))]
	public class HandleBuffetUsers : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public HandleBuffetUsers _003C_003E4__this;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemTransferAccept acceptance)
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

					public LambdaParameterValueProvider_IComponentData<CItemTransferAccept>.Runtime runtime_acceptance;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemTransferAccept> forParameter_acceptance;

				public void ScheduleTimeInitialize(HandleBuffetUsers componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_acceptance.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_acceptance = forParameter_acceptance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public HandleBuffetUsers _003C_003E4__this;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemTransferAccept acceptance)
			{
				if (acceptance.Status == ItemAcceptStatus.Pruned || !_003C_003E4__this.Require<CItemTransferProposal>(acceptance.Proposal, out CItemTransferProposal comp) || (comp.Flags & TransferFlags.Buffet) == 0)
				{
					return;
				}
				Entity source = comp.Source;
				Entity entity = default(Entity);
				CPartialOrderAcceptance comp4;
				if (_003C_003E4__this.Require<COrderAcceptance>(e, out COrderAcceptance comp2))
				{
					if (!_003C_003E4__this.RequireBuffer(comp2.Group, out DynamicBuffer<CGroupMember> comp3) || comp2.MemberIndex < 0 || comp2.MemberIndex >= comp3.Length)
					{
						return;
					}
					entity = comp3[comp2.MemberIndex].Customer;
				}
				else if (_003C_003E4__this.Require<CPartialOrderAcceptance>(e, out comp4))
				{
					if (!_003C_003E4__this.RequireBuffer(comp4.Group, out DynamicBuffer<CGroupMember> comp5) || comp4.MemberIndex < 0 || comp4.MemberIndex >= comp5.Length)
					{
						return;
					}
					entity = comp5[comp4.MemberIndex].Customer;
				}
				if (_003C_003E4__this.IsWithinDistance(entity, source, 0.2f))
				{
					if (_003C_003E4__this.Require<CGoingToBuffet>(entity, out CGoingToBuffet comp6))
					{
						ctx.Set(entity, comp6.PreviousInstruction);
						ctx.Remove<CGoingToBuffet>(entity);
					}
					return;
				}
				acceptance.PrunedBy = _003C_003E4__this;
				acceptance.Status = ItemAcceptStatus.Pruned;
				if (_003C_003E4__this.Require<CGoingToBuffet>(entity, out CGoingToBuffet comp7))
				{
					if (comp7.Buffet == source)
					{
						comp7.IsConfirmed = true;
						_003C_003E4__this.Set(entity, comp7);
					}
					return;
				}
				ctx.Set(entity, new CGoingToBuffet
				{
					PreviousInstruction = (_003C_003E4__this.Require<CMoveToLocation>(entity, out CMoveToLocation comp8) ? comp8 : default(CMoveToLocation)),
					Buffet = source,
					IsConfirmed = true
				});
				CPosition orDefault = _003C_003E4__this.GetOrDefault<CPosition>(source);
				ctx.Set(entity, new CMoveToLocation
				{
					StoppingDistance = 0.25f,
					Location = orDefault.ForwardPosition,
					DesiredFacing = orDefault - orDefault.ForwardPosition
				});
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_acceptance.For(i));
				}
			}

			public void ScheduleTimeInitialize(HandleBuffetUsers componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
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
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ctx = EntityContext.WithTemporaryBuffer(base.EntityManager)
			};
			try
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
			}
			finally
			{
				((IDisposable)displayClass.ctx/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private bool IsWithinDistance(Entity a, Entity buffet, float distance)
		{
			if (!Require<CPosition>(a, out CPosition comp))
			{
				return false;
			}
			if (!Require<CPosition>(buffet, out CPosition comp2))
			{
				return false;
			}
			return (comp.Position - comp2.ForwardPosition).sqrMagnitude < distance * distance;
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CItemTransferAccept>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
