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
using UnityEngine;

namespace Kitchen
{
	public class AcceptIntoOrderSatisfaction : TransferAcceptSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public AcceptIntoOrderSatisfaction _003C_003E4__this;

			public EntityContext ctx;

			public SGlobalStatusList restaurant_status;

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

				public void ScheduleTimeInitialize(AcceptIntoOrderSatisfaction componentSystem)
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

			public AcceptIntoOrderSatisfaction _003C_003E4__this;

			public EntityContext ctx;

			public SGlobalStatusList restaurant_status;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal)
			{
				if (proposal.Status == ItemTransferStatus.Pruned)
				{
					return;
				}
				Entity proposalTableSet = _003C_003E4__this.GetProposalTableSet(proposal);
				if (!_003C_003E4__this.Require<COccupiedByGroup>(proposalTableSet, out COccupiedByGroup comp) || !_003C_003E4__this.RequireBuffer((Entity)comp, out DynamicBuffer<CWaitingForItem> comp2))
				{
					return;
				}
				CProposalForMember comp3;
				bool flag = _003C_003E4__this.Require<CProposalForMember>(e, out comp3);
				CCustomerSettings orDefault = _003C_003E4__this.GetOrDefault<CCustomerSettings>(comp);
				for (int i = 0; i < comp2.Length; i++)
				{
					CWaitingForItem cWaitingForItem = comp2[i];
					if (cWaitingForItem.Satisfied || (flag && cWaitingForItem.MemberIndex != comp3.MemberIndex))
					{
						continue;
					}
					bool flag2 = _003C_003E4__this.Has<CSatisfyAnyOrder>(proposal.Item);
					Entity leftover = default(Entity);
					int deliveredItem = proposal.ItemType;
					if (!OrderingHelpers.IsRequestSatisfied(ctx, cWaitingForItem.Item, proposal.Item, out var also_provided_side) && !flag2)
					{
						if (!_003C_003E4__this.Require<CItem>(cWaitingForItem.Item, out CItem comp4) || !OrderingHelpers.AttemptTakeSideFrom(ctx, comp4, proposal.ItemData, out leftover))
						{
							continue;
						}
						deliveredItem = comp4.ID;
					}
					int num = i;
					if (restaurant_status.Has(RestaurantStatus.RandomOrderSatisfaction))
					{
						int num2 = OrderingHelpers.FindRandomUnsatisfiedOrder(comp2);
						num = ((num2 >= 0) ? num2 : num);
					}
					CWaitingForItem cWaitingForItem2 = comp2[num];
					Item output;
					bool flag3 = _003C_003E4__this.Data.TryGet<Item>(cWaitingForItem2.ItemID, out output);
					int a = (flag3 ? output.MaxOrderSharers : 0);
					a = Mathf.Max(a, orDefault.Ordering.MinimumShare);
					Entity entity = _003C_003E4__this.Accept(ctx, e, TransferFlags.OrderSatisfaction);
					ctx.Set(entity, new COrderAcceptance
					{
						OrderIndex = num,
						MemberIndex = cWaitingForItem.MemberIndex,
						MaxSharers = a,
						DeliveredItem = deliveredItem,
						CreditDish = ((flag3 && output.CreditSourceDish != null) ? output.CreditSourceDish.ID : cWaitingForItem.SourceMenuItem),
						Group = comp,
						TableSet = proposalTableSet,
						ProvidedSide = also_provided_side,
						AlwaysSatisfyAnything = flag2,
						Source = proposal.Source,
						Leftovers = leftover,
						IsSide = cWaitingForItem2.IsSide,
						OrderedItem = _003C_003E4__this.GetOrDefault<CItem>(cWaitingForItem2.Item)
					});
					ctx.Set(entity, new CTransferRequiresUnblockedEntity
					{
						Entity = comp
					});
					break;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
				restaurant_status = displayClass.restaurant_status;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ctx = ctx;
				displayClass.restaurant_status = restaurant_status;
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

			public void ScheduleTimeInitialize(AcceptIntoOrderSatisfaction componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
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
				displayClass.restaurant_status = GetOrCreate<SGlobalStatusList>();
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
			if (!Require<COrderAcceptance>(acceptance, out COrderAcceptance comp))
			{
				return;
			}
			return_item = comp.Leftovers;
			if (!Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp2))
			{
				return;
			}
			Entity proposalTableSet = GetProposalTableSet(comp2);
			if (!Require<COccupiedByGroup>(proposalTableSet, out COccupiedByGroup comp3) || !RequireBuffer((Entity)comp3, out DynamicBuffer<CWaitingForItem> comp4) || comp.OrderIndex < 0 || comp.OrderIndex >= comp4.Length)
			{
				return;
			}
			CWaitingForItem value = comp4[comp.OrderIndex];
			value.Satisfied = true;
			comp4[comp.OrderIndex] = value;
			if (Require<COriginalOrderBeforePiecemeal>(value.Item, out COriginalOrderBeforePiecemeal comp5) && Require<CItem>(value.Item, out CItem comp6))
			{
				comp6.Items = comp5.OriginalItems;
				ctx.Set(value.Item, comp6);
				comp.OrderedItem = new CItem
				{
					ID = comp5.ItemID,
					Items = comp5.OriginalItems
				};
				ctx.Set(acceptance, comp);
			}
			if (comp.AlwaysSatisfyAnything || comp.ProvidedSide != 0)
			{
				for (int i = 1; i < comp4.Length; i++)
				{
					int num = (i + comp.OrderIndex) % comp4.Length;
					if (!comp4[num].Satisfied)
					{
						bool num2 = comp.AlwaysSatisfyAnything && comp4[num].IsSide && comp4[num].MemberIndex == comp.OrderIndex;
						bool flag = comp4[num].ItemID == comp.ProvidedSide;
						if (num2 || flag)
						{
							CWaitingForItem cWaitingForItem = comp4[num];
							CWaitingForItem value2 = comp4[num];
							value2.Satisfied = true;
							comp4[num] = value2;
							Entity entity = ctx.CreateEntity();
							ctx.Set(entity, new COrderAcceptance
							{
								OrderIndex = num,
								MaxSharers = comp.MaxSharers,
								DeliveredItem = cWaitingForItem.ItemID,
								CreditDish = cWaitingForItem.SourceMenuItem,
								Group = comp3,
								TableSet = proposalTableSet,
								ProvidedSide = 0,
								AlwaysSatisfyAnything = comp.AlwaysSatisfyAnything,
								Source = comp.Source,
								IsSide = true,
								OrderedItem = GetOrDefault<CItem>(value2.Item)
							});
							break;
						}
					}
				}
			}
			ctx.Destroy(comp2.Item);
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
