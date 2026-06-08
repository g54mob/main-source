#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class DelegateUnlockSystem : RestaurantSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public DelegateUnlockSystem _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public NativeArray<CProgressionUnlock> unlocks;

			public NativeArray<CProgressionOption> new_unlocks;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, in CProgressionOption unlock, in CProgressionOption.Selected selected)
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

					public LambdaParameterValueProvider_IComponentData<CProgressionOption>.Runtime runtime_unlock;

					public LambdaParameterValueProvider_IComponentData_Tag<CProgressionOption.Selected>.Runtime runtime_selected;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CProgressionOption> forParameter_unlock;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CProgressionOption.Selected> forParameter_selected;

				public void ScheduleTimeInitialize(DelegateUnlockSystem componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_unlock.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_selected.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_unlock = forParameter_unlock.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_selected = forParameter_selected.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public DelegateUnlockSystem _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public NativeArray<CProgressionUnlock> unlocks;

			public NativeArray<CProgressionOption> new_unlocks;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CProgressionOption unlock, in CProgressionOption.Selected selected)
			{
				CardType cardType = CardType.Default;
				Contract output2;
				if (_003C_003E4__this.Data.TryGet<Unlock>(unlock.ID, out var output))
				{
					cardType = output.CardType;
					if (cardType != CardType.FranchiseTier || unlock.FromFranchise)
					{
						if (!output.ItemRewards.IsNullOrEmpty())
						{
							foreach (Unlock.ItemReward itemReward in output.ItemRewards)
							{
								ecb.AddComponent(ecb.CreateEntity(), new CUnlockRewardBoost
								{
									ItemID = itemReward.Item.ID,
									Amount = itemReward.RewardAmount
								});
							}
						}
						if (output.HasSubOptions && output.OptionCard1 != null && output.OptionCard2 != null)
						{
							bool flag = false;
							foreach (CProgressionUnlock unlock2 in unlocks)
							{
								if (unlock2.ID == output.OptionCard1.ID || unlock2.ID == output.OptionCard2.ID)
								{
									flag = true;
								}
							}
							foreach (CProgressionOption new_unlock in new_unlocks)
							{
								if (new_unlock.ID == output.OptionCard1.ID || new_unlock.ID == output.OptionCard2.ID)
								{
									flag = true;
								}
							}
							if (!flag)
							{
								ecb.AddComponent(ecb.CreateEntity(), new CSubcardChoice
								{
									Choice1 = output.OptionCard1.ID,
									Choice2 = output.OptionCard2.ID,
									FromFranchise = unlock.FromFranchise
								});
							}
						}
						SKitchenParameters singleton = _003C_003E4__this.GetSingleton<SKitchenParameters>();
						singleton.Parameters.CustomersPerHourReduction += output.CustomerMultiplier.Value();
						_003C_003E4__this.SetSingleton(singleton);
						if (!(output is UnlockCard unlockCard))
						{
							if (output is Dish dish)
							{
								ecb.AddComponent(ecb.CreateEntity(), new CNewDish
								{
									ID = dish.ID,
									ShowRecipe = (!dish.SkipOwnRecipe && !_003C_003E4__this.Has<CSkipShowingRecipe>(e))
								});
								if (dish.AddsStatuses != null)
								{
									foreach (RestaurantStatus addsStatus in dish.AddsStatuses)
									{
										_003C_003E4__this.AddStatus(addsStatus);
									}
								}
							}
							else
							{
								Debug.LogError($"No handler for unlock type {output} (ID: {unlock.ID})");
							}
						}
						else
						{
							for (int i = 0; i < unlockCard.Effects.Count; i++)
							{
								UnlockEffect unlockEffect = unlockCard.Effects[i];
								if (!(unlockEffect is ParameterEffect))
								{
									if (!(unlockEffect is GlobalEffect))
									{
										if (!(unlockEffect is StatusEffect statusEffect))
										{
											if (!(unlockEffect is ThemeAddEffect themeAddEffect))
											{
												if (!(unlockEffect is ShopEffect effect))
												{
													if (!(unlockEffect is StartBonusEffect effect2))
													{
														if (!(unlockEffect is EnableGroupEffect enableGroupEffect))
														{
															if (unlockEffect is CustomerSpawnEffect customerSpawnEffect)
															{
																Entity entity = ctx.CreateEntity();
																ctx.Set(entity, new CCustomerSpawnModifier
																{
																	BaseCustomerMultiplier = customerSpawnEffect.Base,
																	PerDayCustomerMultiplier = customerSpawnEffect.PerDay
																});
															}
														}
														else
														{
															Entity entity2 = ctx.CreateEntity();
															ctx.Set(entity2, new CCustomerSpawnDefinition(enableGroupEffect.Probability));
															ctx.Set(entity2, new CCustomerType(enableGroupEffect.EnableType.ID));
														}
													}
													else
													{
														effect2.Apply(ctx);
													}
												}
												else
												{
													effect.Apply(ctx);
												}
											}
											else
											{
												_003C_003E4__this.SetTheme(themeAddEffect.AddsTheme);
											}
										}
										else
										{
											_003C_003E4__this.AddStatus(statusEffect.Status);
										}
									}
									else
									{
										ecb.AddComponent(ecb.CreateEntity(), new CNewEffectUnlock
										{
											ID = unlockCard.ID,
											Index = i
										});
									}
								}
								else
								{
									ecb.AddComponent(ecb.CreateEntity(), new CNewParameterChange
									{
										ID = unlockCard.ID,
										Index = i
									});
								}
							}
						}
					}
				}
				else if (_003C_003E4__this.Data.TryGet<Contract>(unlock.ID, out output2))
				{
					cardType = CardType.Contract;
					_003C_003E4__this.AddStatus(output2.Status);
				}
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent(e2, new CProgressionUnlock
				{
					ID = unlock.ID,
					FromFranchise = unlock.FromFranchise,
					Type = cardType
				});
				ecb.DestroyEntity(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
				unlocks = displayClass.unlocks;
				new_unlocks = displayClass.new_unlocks;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ecb = ecb;
				displayClass.unlocks = unlocks;
				displayClass.new_unlocks = new_unlocks;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_unlock.For(i), runtimes.runtime_selected.For(i));
				}
			}

			public void ScheduleTimeInitialize(DelegateUnlockSystem componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		public EntityQuery CurrentUnlocks;

		public EntityQuery AllChoices;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			CurrentUnlocks = GetEntityQuery(typeof(CProgressionUnlock));
			AllChoices = GetEntityQuery(typeof(CProgressionOption), typeof(CProgressionOption.Selected));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = default(_003C_003Ec__DisplayClass3_0);
			displayClass._003C_003E4__this = this;
			displayClass.ecb = new EntityCommandBuffer(Allocator.TempJob);
			displayClass.ctx = new EntityContext(base.EntityManager, displayClass.ecb);
			displayClass.unlocks = CurrentUnlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
			try
			{
				displayClass.new_unlocks = AllChoices.ToComponentDataArray<CProgressionOption>(Allocator.Temp);
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
					displayClass.ecb.Playback(base.EntityManager);
					displayClass.ecb.Dispose();
				}
				finally
				{
					((IDisposable)displayClass.new_unlocks/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.unlocks/*cast due to .constrained prefix*/).Dispose();
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CProgressionOption>(),
				ComponentType.ReadOnly<CProgressionOption.Selected>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
