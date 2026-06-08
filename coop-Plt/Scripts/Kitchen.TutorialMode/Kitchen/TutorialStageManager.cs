using System;
using System.Collections.Generic;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class TutorialStageManager : TutorialSystem
	{
		public Dictionary<TutorialStage, TutorialStageData> Stages;

		public TutorialStage FirstStage = TutorialStage.Setup;

		private EntityQuery _SingletonEntityQuery_STutorialSystemMarker_2;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STutorialStageRequireSetup_3;

		private void PerformAction(TutorialAction action)
		{
			if (!(action is TutorialSpawnAppliance action2))
			{
				if (!(action is TutorialSpawnTable action3))
				{
					if (!(action is TutorialSpawnCustomer action4))
					{
						if (!(action is TutorialAddMenuItem action5))
						{
							if (!(action is TutorialCleanUp action6))
							{
								if (!(action is TutorialSpawnItem action7))
								{
									if (action is TutorialSetFire fire)
									{
										SetFire(fire);
									}
								}
								else
								{
									SpawnItem(action7);
								}
							}
							else
							{
								Clean(action6);
							}
						}
						else
						{
							RecreateMenu(action5);
						}
					}
					else
					{
						SpawnCustomer(action4);
					}
				}
				else
				{
					SpawnTable(action3);
				}
			}
			else
			{
				SpawnAppliance(action2);
			}
		}

		private void SetFire(TutorialSetFire action)
		{
			foreach (Entity item in GetEntityQuery(typeof(CPosition), typeof(CAppliance)).ToEntityArray(Allocator.Temp))
			{
				if ((GetComponent<CPosition>(item) - action.Position).Chebyshev() < 0.5f)
				{
					base.EntityManager.AddComponent<CIsOnFire>(item);
					break;
				}
			}
		}

		private void Clean(TutorialCleanUp action)
		{
			foreach (Entity item in GetEntityQuery(typeof(CApplianceTable)).ToEntityArray(Allocator.Temp))
			{
				Entity heldItem = GetComponent<CItemHolder>(item).HeldItem;
				if (heldItem != default(Entity))
				{
					base.EntityManager.DestroyEntity(heldItem);
				}
				if (HasComponent<CTableSpawnDirt>(item))
				{
					base.EntityManager.RemoveComponent<CTableSpawnDirt>(item);
				}
				if (base.EntityManager.HasComponent<CDirtItem>(item))
				{
					GetBuffer<CDirtItem>(item).Clear();
				}
			}
		}

		private void SpawnItem(TutorialSpawnItem action)
		{
			foreach (Entity item in GetEntityQuery(typeof(CPosition), typeof(CItemHolder)).ToEntityArray(Allocator.Temp))
			{
				if ((GetComponent<CPosition>(item) - action.Position).Chebyshev() < 0.5f)
				{
					Entity heldItem = GetComponent<CItemHolder>(item).HeldItem;
					if (heldItem != default(Entity))
					{
						base.EntityManager.DestroyEntity(heldItem);
					}
					Entity entity = base.EntityManager.CreateEntity(typeof(CCreateItem));
					base.EntityManager.SetComponentData(entity, new CCreateItem
					{
						ID = action.ItemGroup,
						Holder = item
					});
					break;
				}
			}
		}

		private void SpawnAppliance(TutorialSpawnAppliance action)
		{
			if (action.IsProvider)
			{
				Item item = base.Data.Get<Item>(action.ApplianceOrItem);
				Entity entity = Create(item.DedicatedProvider, action.Position, action.Facing);
				base.EntityManager.AddComponentData(entity, CItemProvider.InfiniteItemProvider(item.ID));
			}
			else
			{
				Create(base.Data.Get<Appliance>(action.ApplianceOrItem), action.Position, action.Facing);
			}
		}

		private void SpawnTable(TutorialSpawnTable action)
		{
			Entity target = Create(AssetReference.TutorialTable, action.Position, action.Facing);
			Entity entity = Create(AssetReference.TutorialChair, action.Position - action.Facing, -action.Facing);
			Entity entity2 = Create(AssetReference.TutorialChair, action.Position + action.Facing, action.Facing);
			base.EntityManager.AddComponentData(entity, new CInteractionProxy
			{
				Target = target,
				IsActive = true
			});
			base.EntityManager.AddComponentData(entity, new CInteractionProxy
			{
				Target = target,
				IsActive = true
			});
			base.EntityManager.AddComponent<CApplianceChair>(entity);
			base.EntityManager.AddComponent<CApplianceChair>(entity2);
			if (!HasSingleton<SPerformTableUpdate>())
			{
				base.EntityManager.CreateEntity(typeof(SPerformTableUpdate));
			}
		}

		protected void RecreateMenu(TutorialAddMenuItem action)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CMenuItem), typeof(CAvailableIngredient), typeof(CMenuItemMain));
			base.EntityManager.AddComponentData(entity, new CMenuItem
			{
				Item = action.MenuItem,
				Weight = 1f,
				Phase = action.Phase
			});
			switch (action.Phase)
			{
			case MenuPhase.Starter:
				base.EntityManager.AddComponent<CMenuItemStarter>(entity);
				break;
			case MenuPhase.Main:
				base.EntityManager.AddComponent<CMenuItemMain>(entity);
				break;
			case MenuPhase.Dessert:
				base.EntityManager.AddComponent<CMenuItemDessert>(entity);
				break;
			case MenuPhase.Side:
				base.EntityManager.AddComponent<CMenuItemSide>(entity);
				break;
			}
			foreach (int ingredient in action.Ingredients)
			{
				UnlockIngredient(action.MenuItem, ingredient);
			}
		}

		private void SpawnCustomer(TutorialSpawnCustomer action)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CCustomerGroup), typeof(CPosition), typeof(CGroupArrive), typeof(CGroupMealPhase), typeof(CGroupReward));
			base.EntityManager.SetComponentData(entity, new CGroupMealPhase
			{
				Phase = MenuPhase.Main
			});
			OrderingValues orderingValues = OrderingValues.Default;
			orderingValues.SidesModifier = (action.OrderSides ? 999 : 0);
			orderingValues.PreventMess = true;
			PatienceValues patienceValues = PatienceValues.Default;
			patienceValues.WaitForFood = (action.LowPatience ? 10 : 70);
			base.EntityManager.AddComponentData(entity, new CPatience(PatienceReason.Seating));
			base.EntityManager.AddComponentData(entity, new CCustomerSettings
			{
				BasePatience = patienceValues,
				Patience = patienceValues,
				BaseOrdering = orderingValues,
				Ordering = orderingValues
			});
			base.EntityManager.AddBuffer<CGroupMember>(entity);
			for (int i = 0; i < action.Count; i++)
			{
				Entity entity2 = NewCustomer(entity, action.Position);
				base.EntityManager.GetBuffer<CGroupMember>(entity).Add(entity2);
			}
		}

		private Entity NewCustomer(Entity group, Vector3 pos)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CCustomer
			{
				Scale = 1f,
				Speed = 1f
			});
			base.EntityManager.AddComponentData(entity, new CCustomerState
			{
				CurrentState = CCustomerState.State.Normal
			});
			base.EntityManager.AddComponentData(entity, new CBelongsToGroup
			{
				Group = group
			});
			base.EntityManager.AddComponentData(entity, new CPosition(pos));
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.Customer,
				PhysicsDriven = true
			});
			return entity;
		}

		private bool IsConditionMet(TutorialCondition condition)
		{
			if (!(condition is HasAnyCondition hasAnyCondition))
			{
				if (!(condition is IsUndergoingProcess isUndergoingProcess))
				{
					if (!(condition is Always))
					{
						if (!(condition is GroupStage groupStage))
						{
							if (!(condition is TableState tableState))
							{
								if (!(condition is HasMess hasMess))
								{
									if (!(condition is PressButton pressButton))
									{
										if (condition is HasFire hasFire)
										{
											return HasFire() != hasFire.Invert;
										}
										return true;
									}
									return CheckButton() != pressButton.Invert;
								}
								return HasMess() != hasMess.Invert;
							}
							return TableState(tableState.State) != tableState.Invert;
						}
						return IsInStage(groupStage.Stage) != groupStage.Invert;
					}
					return true;
				}
				return UndergoingProcess(isUndergoingProcess.Process) != isUndergoingProcess.Invert;
			}
			return HasAny(hasAnyCondition.Item) != hasAnyCondition.Invert;
		}

		private bool HasAny(int id)
		{
			using NativeArray<CItem> nativeArray = GetEntityQuery(typeof(CItem)).ToComponentDataArray<CItem>(Allocator.Temp);
			foreach (CItem item in nativeArray)
			{
				if (item.ID == id)
				{
					return true;
				}
			}
			return false;
		}

		private bool HasFire()
		{
			return !GetEntityQuery(typeof(CIsOnFire)).IsEmpty;
		}

		private bool UndergoingProcess(int id)
		{
			using NativeArray<CItemUndergoingProcess> nativeArray = GetEntityQuery(typeof(CItemUndergoingProcess)).ToComponentDataArray<CItemUndergoingProcess>(Allocator.Temp);
			using NativeArray<CCompletedProcess> nativeArray2 = GetEntityQuery(typeof(CCompletedProcess)).ToComponentDataArray<CCompletedProcess>(Allocator.Temp);
			foreach (CItemUndergoingProcess item in nativeArray)
			{
				if (item.Process == id)
				{
					return true;
				}
			}
			foreach (CCompletedProcess item2 in nativeArray2)
			{
				if (item2.Process == id)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsInStage(Type stage)
		{
			using NativeArray<Entity> nativeArray = GetEntityQuery(typeof(CCustomerGroup)).ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (base.EntityManager.HasComponent(item, stage))
				{
					return true;
				}
			}
			return false;
		}

		private bool TableState(Type stage)
		{
			using NativeArray<Entity> nativeArray = GetEntityQuery(typeof(CTableSet)).ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (base.EntityManager.HasComponent(item, stage))
				{
					return true;
				}
			}
			return false;
		}

		private bool HasMess()
		{
			return !GetEntityQuery(typeof(CStackableMess)).IsEmpty;
		}

		private bool CheckButton()
		{
			foreach (CInputData item in GetEntityQuery(typeof(CInputData)).ToComponentDataArray<CInputData>(Allocator.Temp))
			{
				if (!item.IsCaptured && item.State.SecondaryAction1 == ButtonState.Pressed)
				{
					return true;
				}
			}
			return false;
		}

		protected override void Initialise()
		{
			Vector3 vector = new Vector3(2f, 0f, -1f);
			Stages = new Dictionary<TutorialStage, TutorialStageData>
			{
				{
					TutorialStage.Skip,
					new TutorialStageData().Add(Add.Appliance(AssetReference.InfiniteBin, new Vector3(-4f, 0f, 0f), Vector3.forward)).Add(Add.Appliance(AssetReference.TutorialHob, new Vector3(-3f, 0f, 2f), Vector3.forward)).Add(Add.Appliance(AssetReference.Counter, new Vector3(-2f, 0f, 2f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-3f, 0f, -1f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-2f, 0f, -1f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-1f, 0f, -1f), Vector3.forward))
						.Add(Add.Provider(AssetReference.TutorialFishIngredient, new Vector3(-1f, 0f, 2f), Vector3.forward))
						.Add(Add.Provider(AssetReference.TutorialPlateIngredient, new Vector3(0f, 0f, 2f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Sink, new Vector3(1f, 0f, 2f), Vector3.forward))
						.Add(Add.Table(vector, Vector3.right))
						.Add(Add.Main(AssetReference.TutorialPlatedFish, AssetReference.TutorialCookedFish, AssetReference.TutorialPlateIngredient))
						.Add(Add.Side(AssetReference.TutorialCookedChipsIngredient, AssetReference.TutorialCookedChipsIngredient))
						.Add(Add.Provider(AssetReference.TutorialPotatoIngredient, new Vector3(2f, 0f, 2f), Vector3.forward))
						.When(TutorialStage.SpawnMash, Is.Always)
				},
				{
					TutorialStage.Setup,
					new TutorialStageData().Add(Add.Appliance(AssetReference.InfiniteBin, new Vector3(-4f, 0f, 0f), Vector3.forward)).Add(Add.Appliance(AssetReference.TutorialHob, new Vector3(-3f, 0f, 2f), Vector3.forward)).Add(Add.Appliance(AssetReference.Counter, new Vector3(-2f, 0f, 2f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-3f, 0f, -1f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-2f, 0f, -1f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Counter, new Vector3(-1f, 0f, -1f), Vector3.forward))
						.Add(Add.Provider(AssetReference.TutorialFishIngredient, new Vector3(-1f, 0f, 2f), Vector3.forward))
						.Add(Add.Provider(AssetReference.TutorialPlateIngredient, new Vector3(0f, 0f, 2f), Vector3.forward))
						.Add(Add.Appliance(AssetReference.Sink, new Vector3(1f, 0f, 2f), Vector3.forward))
						.When(TutorialStage.PickUpFish, Is.Always)
				},
				{
					TutorialStage.PickUpFish,
					new TutorialStageData().Add(Hint.Above(new Vector3(-1f, 0f, 2f), TutorialMessage.PickUpFish, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.CookFish, Is.HasAny(AssetReference.TutorialFishIngredient))
				},
				{
					TutorialStage.CookFish,
					new TutorialStageData().Add(Hint.Above(new Vector3(-3f, 0f, 2f), TutorialMessage.CookFish, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.WaitFishCook, Is.Process(AssetReference.TutorialCook)).Not(TutorialStage.PickUpFish, Is.HasAny(AssetReference.TutorialFishIngredient))
				},
				{
					TutorialStage.WaitFishCook,
					new TutorialStageData().Add(Hint.Above(new Vector3(-3f, 0f, 2f), TutorialMessage.WaitFishCook)).When(TutorialStage.PlateFish, Is.HasAny(AssetReference.TutorialCookedFish)).Not(TutorialStage.CookFish, Is.Process(AssetReference.TutorialCook))
				},
				{
					TutorialStage.PlateFish,
					new TutorialStageData().Add(Hint.Above(new Vector3(0f, 0f, 2f), TutorialMessage.PlateFish, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.SpawnTable, Is.HasAny(AssetReference.TutorialPlatedFish)).Not(TutorialStage.CookFish, Is.HasAny(AssetReference.TutorialCookedFish))
				},
				{
					TutorialStage.SpawnTable,
					new TutorialStageData().Add(Add.Main(AssetReference.TutorialPlatedFish, AssetReference.TutorialCookedFish, AssetReference.TutorialPlateIngredient)).Add(Add.Table(vector, Vector3.right)).When(TutorialStage.SpawnCustomer, Is.Always)
				},
				{
					TutorialStage.SpawnCustomer,
					new TutorialStageData().Add(Add.Customer(new Vector3(12f, 0f, 0f))).When(TutorialStage.TakeCustomerOrder, Is.Always)
				},
				{
					TutorialStage.TakeCustomerOrder,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.TakeCustomerOrder, Button.Interact2, InputPromptAnimation.Press)).When(TutorialStage.DeliverFish, Is.InStage<CGroupAwaitingOrder>()).When(TutorialStage.SpawnCustomer, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.DeliverFish,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.DeliverFish)).When(TutorialStage.PickUpDish, Is.InStage<CGroupEating>()).When(TutorialStage.SpawnCustomer, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.PickUpDish,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.PickUpDirtyDish, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.WashDish, Is.InState<CTableReadyForCustomers>())
				},
				{
					TutorialStage.WashDish,
					new TutorialStageData().Add(Hint.Above(new Vector3(1f, 0f, 2f), TutorialMessage.WashDirtyDish, Button.Interact2, InputPromptAnimation.Hold)).Not(TutorialStage.SpawnPotato, Is.HasAny(AssetReference.TutorialPlateDirtyIngredient))
				},
				{
					TutorialStage.SpawnPotato,
					new TutorialStageData().Add(Add.Side(AssetReference.TutorialCookedChipsIngredient, AssetReference.TutorialCookedChipsIngredient)).Add(Add.Provider(AssetReference.TutorialPotatoIngredient, new Vector3(2f, 0f, 2f), Vector3.forward)).When(TutorialStage.PickUpPotato, Is.Always)
				},
				{
					TutorialStage.PickUpPotato,
					new TutorialStageData().Add(Hint.Below(new Vector3(2f, 0f, 2f), TutorialMessage.PickUpPotato, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.ChopPotato, Is.HasAny(AssetReference.TutorialPotatoIngredient))
				},
				{
					TutorialStage.ChopPotato,
					new TutorialStageData().Add(Hint.Below(new Vector3(-2f, 0f, -1f), TutorialMessage.ChopPotato, Button.Interact2, InputPromptAnimation.Hold)).When(TutorialStage.CookPotato, Is.HasAny(AssetReference.TutorialRawChipsIngredient)).Not(TutorialStage.PickUpPotato, Is.HasAny(AssetReference.TutorialPotatoIngredient))
				},
				{
					TutorialStage.CookPotato,
					new TutorialStageData().Add(Hint.Above(new Vector3(-3f, 0f, 2f), TutorialMessage.CookPotato)).When(TutorialStage.SpawnCustomerSide, Is.HasAny(AssetReference.TutorialCookedChipsIngredient)).Not(TutorialStage.ChopPotato, Is.HasAny(AssetReference.TutorialRawChipsIngredient))
				},
				{
					TutorialStage.SpawnCustomerSide,
					new TutorialStageData().Add(Add.Customer(new Vector3(12f, 0f, 0f), 1, order_sides: true)).When(TutorialStage.TakeCustomerOrderSide, Is.Always)
				},
				{
					TutorialStage.TakeCustomerOrderSide,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.TakeCustomerOrder, Button.Interact2, InputPromptAnimation.Press)).When(TutorialStage.DeliverSide, Is.InStage<CGroupAwaitingOrder>()).When(TutorialStage.SpawnCustomerSide, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.DeliverSide,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.DeliverSide)).When(TutorialStage.SpawnMess, Is.InStage<CGroupEating>()).When(TutorialStage.SpawnCustomerSide, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.SpawnMess,
					new TutorialStageData().Add(Add.Appliance(AssetReference.CustomerMess, vector + new Vector3(0f, 0f, -1f), Vector3.left)).When(TutorialStage.PickUpDishMess, Is.Always)
				},
				{
					TutorialStage.PickUpDishMess,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.PickUpDirtyDish, Button.Interact1, InputPromptAnimation.Press)).When(TutorialStage.WashDishMess, Is.InState<CTableReadyForCustomers>())
				},
				{
					TutorialStage.WashDishMess,
					new TutorialStageData().Add(Hint.Above(new Vector3(1f, 0f, 2f), TutorialMessage.WashDirtyDish, Button.Interact2, InputPromptAnimation.Hold)).Not(TutorialStage.CleanMess, Is.HasAny(AssetReference.TutorialPlateDirtyIngredient))
				},
				{
					TutorialStage.CleanMess,
					new TutorialStageData().Add(Hint.Below(vector + new Vector3(0f, 0f, -1f), TutorialMessage.CleanMess, Button.Interact2, InputPromptAnimation.Hold)).Not(TutorialStage.SpawnCustomerPair, Is.Mess)
				},
				{
					TutorialStage.SpawnCustomerPair,
					new TutorialStageData().Add(Add.Customer(new Vector3(12f, 0f, 0f), 2)).When(TutorialStage.TakeCustomerOrderPair, Is.Always)
				},
				{
					TutorialStage.TakeCustomerOrderPair,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.TakePairOrder, Button.Interact2, InputPromptAnimation.Press)).When(TutorialStage.DeliverPair, Is.InStage<CGroupAwaitingOrder>()).When(TutorialStage.SpawnCustomerPair, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.DeliverPair,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.DeliverPair)).When(TutorialStage.PairEating, Is.InStage<CGroupEating>()).When(TutorialStage.SpawnCustomerPair, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.PairEating,
					new TutorialStageData().Not(TutorialStage.CleanTables, Is.Always)
				},
				{
					TutorialStage.CleanTables,
					new TutorialStageData().Add(Do.Clean).When(TutorialStage.SpawnCustomerImpatient, Is.InState<CTableReadyForCustomers>()).Not(TutorialStage.PairEating, Is.InState<CTableReadyForCustomers>())
				},
				{
					TutorialStage.SpawnCustomerImpatient,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.AimOfGame)).Add(Add.Customer(new Vector3(12f, 0f, 0f), 1, order_sides: false, low_patience: true)).When(TutorialStage.TakeCustomerOrderImpatient, Is.InStage<CGroupChoosingOrder>())
				},
				{
					TutorialStage.TakeCustomerOrderImpatient,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.TakeImpatientOrder, Button.Interact2, InputPromptAnimation.Press)).When(TutorialStage.DeliverImpatient, Is.InStage<CGroupAwaitingOrder>()).When(TutorialStage.SpawnCustomerImpatient, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.DeliverImpatient,
					new TutorialStageData().Add(Hint.Below(vector, TutorialMessage.DeliverImpatient)).When(TutorialStage.SpawnMash, Is.InStage<CGroupEating>()).When(TutorialStage.SpawnCustomerImpatient, Is.InStage<CGroupStartLeaving>())
				},
				{
					TutorialStage.SpawnMash,
					new TutorialStageData().Add(Add.Item(AssetReference.TutorialMashPot, new Vector3(-3f, 0f, -1f))).Not(TutorialStage.Splittable, Is.Always)
				},
				{
					TutorialStage.Splittable,
					new TutorialStageData().Add(Hint.Above(new Vector3(-3f, 0f, -1f), TutorialMessage.Splittable, Button.Interact2, InputPromptAnimation.Hold)).When(TutorialStage.Fire, Is.HasAny(AssetReference.TutorialMashPortion)).Not(TutorialStage.SpawnMash, Is.HasAny(AssetReference.TutorialMashPot))
				},
				{
					TutorialStage.Fire,
					new TutorialStageData().Add(Add.Fire(new Vector3(-3f, 0f, 2f))).Add(Hint.Above(new Vector3(-3f, 0f, 2f), TutorialMessage.Fire, Button.Interact2, InputPromptAnimation.Hold)).Not(TutorialStage.TipRedecorate, Is.OnFire)
				},
				{
					TutorialStage.TipRedecorate,
					new TutorialStageData().Add(Hint.Above(new Vector3(0f, 0f, -1f), TutorialMessage.Redecorate, Button.Interact3)).When(TutorialStage.TipProgression, Is.PressButton)
				},
				{
					TutorialStage.TipProgression,
					new TutorialStageData().Add(Hint.Above(new Vector3(0f, 0f, -1f), TutorialMessage.Progression, Button.Interact3)).When(TutorialStage.TipLosing, Is.PressButton)
				},
				{
					TutorialStage.TipLosing,
					new TutorialStageData().Add(Hint.Above(new Vector3(0f, 0f, -1f), TutorialMessage.Losing, Button.Interact3)).When(TutorialStage.Finish, Is.PressButton)
				},
				{
					TutorialStage.Finish,
					new TutorialStageData().Add(Hint.Above(new Vector3(0f, 0f, -1f), TutorialMessage.Congratulations, Button.Interact3)).When(TutorialStage.Completed, Is.PressButton)
				}
			};
		}

		protected override void OnUpdate()
		{
			if (!TryGetSingleton<STutorialSystemMarker>(out var value))
			{
				return;
			}
			TutorialStage stage = value.Stage;
			if (stage == TutorialStage.Completed)
			{
				base.World.Add<CRequestQuitEvent>();
				return;
			}
			if (!Stages.TryGetValue(stage, out var value2))
			{
				_SingletonEntityQuery_STutorialSystemMarker_2.SetSingleton(new STutorialSystemMarker
				{
					Stage = FirstStage
				});
				base.World.Add<STutorialStageRequireSetup>();
				value2 = Stages[FirstStage];
			}
			if (HasSingleton<STutorialStageRequireSetup>())
			{
				foreach (TutorialHint hint in value2.Hints)
				{
					AddHint(hint);
				}
				foreach (TutorialAction action in value2.Actions)
				{
					PerformAction(action);
				}
				base.EntityManager.DestroyEntity(_SingletonEntityQuery_STutorialStageRequireSetup_3.GetSingletonEntity());
			}
			foreach (TutorialCondition transition in value2.Transitions)
			{
				if (IsConditionMet(transition))
				{
					MoveToStage(transition.LeadsTo);
					break;
				}
			}
		}

		private void AddHint(TutorialHint hint)
		{
			CreatePopup(hint.Location, hint.Message, hint.ButtonPrompt, hint.Animation);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STutorialSystemMarker_2 = GetEntityQuery(ComponentType.ReadWrite<STutorialSystemMarker>());
			_SingletonEntityQuery_STutorialStageRequireSetup_3 = GetEntityQuery(ComponentType.ReadOnly<STutorialStageRequireSetup>());
		}
	}
}
