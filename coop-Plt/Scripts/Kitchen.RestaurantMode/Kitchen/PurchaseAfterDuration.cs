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
using UnityEngine;

namespace Kitchen
{
	public class PurchaseAfterDuration : RestaurantSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public bool performed_purchase;

			public PurchaseAfterDuration _003C_003E4__this;

			public SMoney player_money;

			public EntityCommandBuffer ecb;

			public float rebuyable_chance;

			public float refresh_chance;

			internal void _003COnUpdate_003Eb__0(Entity e, in CTakesDuration duration, in CApplianceBlueprint app, in CPurchaseAfterDuration change, in CForSale sale, in DynamicBuffer<CBeingActedOnBy> actors, in CPosition pos, in CAppliance letter_appliance)
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

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.Runtime runtime_duration;

					public LambdaParameterValueProvider_IComponentData<CApplianceBlueprint>.Runtime runtime_app;

					public LambdaParameterValueProvider_IComponentData_Tag<CPurchaseAfterDuration>.Runtime runtime_change;

					public LambdaParameterValueProvider_IComponentData<CForSale>.Runtime runtime_sale;

					public LambdaParameterValueProvider_DynamicBuffer<CBeingActedOnBy>.Runtime runtime_actors;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_letter_appliance;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CApplianceBlueprint> forParameter_app;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CPurchaseAfterDuration> forParameter_change;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CForSale> forParameter_sale;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CBeingActedOnBy> forParameter_actors;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_letter_appliance;

				public void ScheduleTimeInitialize(PurchaseAfterDuration componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_change.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_sale.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_actors.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_letter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_duration = forParameter_duration.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_change = forParameter_change.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_sale = forParameter_sale.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_actors = forParameter_actors.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_letter_appliance = forParameter_letter_appliance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool performed_purchase;

			public SMoney player_money;

			public EntityCommandBuffer ecb;

			public PurchaseAfterDuration _003C_003E4__this;

			public float rebuyable_chance;

			public float refresh_chance;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CItemHolder> _ComponentDataFromEntity_CItemHolder_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CTakesDuration duration, in CApplianceBlueprint app, in CPurchaseAfterDuration change, in CForSale sale, in DynamicBuffer<CBeingActedOnBy> actors, in CPosition pos, in CAppliance letter_appliance)
			{
				if (performed_purchase || actors.IsEmpty || !duration.Active || !(duration.Remaining <= 0f))
				{
					return;
				}
				for (int i = 0; i < actors.Length; i++)
				{
					Entity interactor = actors[i].Interactor;
					if (actors[i].IsTransferOnly || !_ComponentDataFromEntity_CItemHolder_0.HasComponent(interactor) || !(_ComponentDataFromEntity_CItemHolder_0[interactor].HeldItem == default(Entity)) || sale.Price > (int)player_money)
					{
						continue;
					}
					player_money.Amount -= sale.Price;
					ecb.RemoveComponent<CTakesDuration>(e);
					ecb.RemoveComponent<CDisplayDuration>(e);
					ecb.RemoveComponent<CHasIndicator>(e);
					ecb.RemoveComponent<CPurchaseAfterDuration>(e);
					ecb.RemoveComponent<CForSale>(e);
					if (_003C_003E4__this.Has<CShowApplianceInfo>(e))
					{
						ecb.RemoveComponent<CShowApplianceInfo>(e);
					}
					ecb.RemoveComponent<CApplianceBlueprint>(e);
					ecb.RemoveComponent<CShopEntity>(e);
					ecb.AddComponent<CRemoveView>(e);
					ecb.SetComponent(e, new CRequiresView
					{
						Type = ViewType.HeldAppliance
					});
					ecb.AddComponent(e, new CCreateAppliance
					{
						ID = app.Appliance
					});
					ecb.AddComponent(e, new CHeldBy
					{
						Holder = interactor
					});
					ecb.AddComponent(e, default(CHeldAppliance));
					ecb.SetComponent(interactor, new CItemHolder
					{
						HeldItem = e
					});
					performed_purchase = true;
					if (!app.IsCopy && Random.value < rebuyable_chance)
					{
						Entity e2 = ecb.CreateEntity();
						ecb.AddComponent(e2, new CCreateAppliance
						{
							ID = letter_appliance.ID
						});
						ecb.AddComponent(e2, new CPosition(pos));
						ecb.AddComponent(e2, new CApplianceBlueprint
						{
							Appliance = app.Appliance
						});
						if (_003C_003E4__this.Has<CShowApplianceInfo>(e))
						{
							ecb.AddComponent(e2, new CShowApplianceInfo
							{
								Appliance = app.Appliance,
								Price = sale.Price,
								ShowPrice = true
							});
						}
						ecb.AddComponent(e2, new CForSale
						{
							Price = sale.Price
						});
						ecb.AddComponent(e2, default(CShopEntity));
					}
					if (!app.IsCopy && Random.value < refresh_chance)
					{
						Entity e3 = ecb.CreateEntity();
						ecb.AddComponent(e3, new CNewShop
						{
							Tags = (ShoppingTags.Technology | ShoppingTags.FrontOfHouse | ShoppingTags.Plumbing | ShoppingTags.Cooking | ShoppingTags.Automation | ShoppingTags.Misc | ShoppingTags.Office),
							FixedLocation = true,
							Location = pos
						});
					}
					break;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				performed_purchase = displayClass.performed_purchase;
				player_money = displayClass.player_money;
				ecb = displayClass.ecb;
				_003C_003E4__this = displayClass._003C_003E4__this;
				rebuyable_chance = displayClass.rebuyable_chance;
				refresh_chance = displayClass.refresh_chance;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass.performed_purchase = performed_purchase;
				displayClass.player_money = player_money;
				displayClass.ecb = ecb;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.rebuyable_chance = rebuyable_chance;
				displayClass.refresh_chance = refresh_chance;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_duration.For(i), in runtimes.runtime_app.For(i), runtimes.runtime_change.For(i), in runtimes.runtime_sale.For(i), runtimes.runtime_actors.For(i), in runtimes.runtime_pos.For(i), in runtimes.runtime_letter_appliance.For(i));
				}
			}

			public void ScheduleTimeInitialize(PurchaseAfterDuration componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CItemHolder_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItemHolder>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery RebuyChances;

		private EntityQuery RefreshLetterChances;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_53;

		private EntityQuery _SingletonEntityQuery_SMoney_54;

		protected override void Initialise()
		{
			base.Initialise();
			RebuyChances = GetEntityQuery(typeof(CBlueprintRebuyableChance));
			RefreshLetterChances = GetEntityQuery(typeof(CBlueprintRefreshChance));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End),
				player_money = _SingletonEntityQuery_SMoney_53.GetSingleton<SMoney>(),
				performed_purchase = false
			};
			using NativeArray<CBlueprintRebuyableChance> nativeArray = RebuyChances.ToComponentDataArray<CBlueprintRebuyableChance>(Allocator.Temp);
			displayClass.rebuyable_chance = 0f;
			foreach (CBlueprintRebuyableChance item in nativeArray)
			{
				displayClass.rebuyable_chance += (1f - displayClass.rebuyable_chance) * item.Chance;
			}
			using NativeArray<CBlueprintRefreshChance> nativeArray2 = RefreshLetterChances.ToComponentDataArray<CBlueprintRefreshChance>(Allocator.Temp);
			displayClass.refresh_chance = 0f;
			foreach (CBlueprintRefreshChance item2 in nativeArray2)
			{
				displayClass.refresh_chance += (1f - displayClass.refresh_chance) * item2.Chance;
			}
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
			if (displayClass.performed_purchase)
			{
				_SingletonEntityQuery_SMoney_54.SetSingleton(displayClass.player_money);
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SMoney_53 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_54 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[8]
			{
				ComponentType.ReadOnly<CApplianceBlueprint>(),
				ComponentType.ReadOnly<CShopEntity>(),
				ComponentType.ReadOnly<CTakesDuration>(),
				ComponentType.ReadOnly<CPurchaseAfterDuration>(),
				ComponentType.ReadOnly<CForSale>(),
				ComponentType.ReadOnly<CBeingActedOnBy>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CAppliance>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
