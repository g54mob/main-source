#define ENABLE_PROFILER
using System;
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
	public class AcceptIntoExtraSatisfaction : TransferAcceptSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public AcceptIntoExtraSatisfaction _003C_003E4__this;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemTransferProposal proposal)
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

					public LambdaParameterValueProvider_IComponentData<CItemTransferProposal>.Runtime runtime_proposal;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemTransferProposal> forParameter_proposal;

				public void ScheduleTimeInitialize(AcceptIntoExtraSatisfaction componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_proposal.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_proposal = forParameter_proposal.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public AcceptIntoExtraSatisfaction _003C_003E4__this;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal)
			{
				if (proposal.Status == ItemTransferStatus.Pruned || (proposal.Flags & TransferFlags.RequireMerge) != TransferFlags.Null)
				{
					return;
				}
				Entity proposalTableSet = _003C_003E4__this.GetProposalTableSet(proposal);
				if (!_003C_003E4__this.Require<COccupiedByGroup>(proposalTableSet, out COccupiedByGroup comp) || !_003C_003E4__this.RequireBuffer((Entity)comp, out DynamicBuffer<CWaitingForItem> comp2))
				{
					return;
				}
				_003C_003E4__this.GetOrDefault<CCustomerSettings>(comp);
				CProposalForMember comp3;
				bool flag = _003C_003E4__this.Require<CProposalForMember>(e, out comp3);
				for (int i = 0; i < comp2.Length; i++)
				{
					CWaitingForItem cWaitingForItem = comp2[i];
					if (cWaitingForItem.Satisfied && cWaitingForItem.ExtraRequested && !cWaitingForItem.ExtraSatisfied && (!flag || cWaitingForItem.MemberIndex == comp3.MemberIndex))
					{
						bool flag2 = _003C_003E4__this.Has<CSatisfyAnyOrder>(proposal.Item);
						if ((flag2 || cWaitingForItem.Extra == proposal.ItemData.ID) && GameData.Main.TryGet<Item>(proposal.ItemData.ID, out var output))
						{
							Entity entity = _003C_003E4__this.Accept(ctx, e, TransferFlags.OrderSatisfaction);
							ctx.Set(entity, new COrderAcceptance
							{
								OrderIndex = i,
								MemberIndex = cWaitingForItem.MemberIndex,
								MaxSharers = 0,
								DeliveredItem = output.ID,
								CreditDish = ((output.CreditSourceDish != null) ? output.CreditSourceDish.ID : cWaitingForItem.SourceMenuItem),
								Group = comp,
								TableSet = proposalTableSet,
								ProvidedSide = 0,
								AlwaysSatisfyAnything = flag2,
								Source = proposal.Source,
								Leftovers = default(Entity),
								IsExtraSatisfaction = true
							});
							ctx.Set(entity, new CTransferRequiresUnblockedEntity
							{
								Entity = comp
							});
						}
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_proposal.For(i));
				}
			}

			public void ScheduleTimeInitialize(AcceptIntoExtraSatisfaction componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
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

		public Entity GetProposalTableSet(CItemTransferProposal proposal)
		{
			if (Require<CPartOfTableSet>(proposal.Destination, out CPartOfTableSet comp))
			{
				return comp.TableSet;
			}
			if (Has<CTableSet>(proposal.Destination))
			{
				return proposal.Destination;
			}
			return default(Entity);
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				ctx = EntityContext.WithTemporaryBuffer(base.EntityManager)
			};
			try
			{
				GetOrCreate<SGlobalStatusList>();
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

		public override void AcceptTransfer(Entity proposal_entity, Entity acceptance, EntityContext ctx, out Entity return_item)
		{
			return_item = default(Entity);
			if (!Require<COrderAcceptance>(acceptance, out COrderAcceptance comp) || !Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp2))
			{
				return;
			}
			Entity proposalTableSet = GetProposalTableSet(comp2);
			if (!Require<COccupiedByGroup>(proposalTableSet, out COccupiedByGroup comp3) || !RequireBuffer((Entity)comp3, out DynamicBuffer<CWaitingForItem> comp4) || comp.OrderIndex < 0 || comp.OrderIndex >= comp4.Length)
			{
				return;
			}
			CWaitingForItem value = comp4[comp.OrderIndex];
			value.ExtraSatisfied = true;
			comp4[comp.OrderIndex] = value;
			if (GameData.Main.TryGet<Item>(comp2.ItemData.ID, out var output))
			{
				if (output.IsConsumedByCustomer)
				{
					ctx.Destroy(comp2.Item);
					return_item = comp.Leftovers;
				}
				else
				{
					return_item = comp2.Item;
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CItemTransferProposal>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
