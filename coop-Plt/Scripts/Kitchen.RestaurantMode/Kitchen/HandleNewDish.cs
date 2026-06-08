using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class HandleNewDish : RestaurantSystem
	{
		private EntityQuery NewPendingDishes;

		private EntityQuery CurrentMenuItems;

		private EntityQuery CurrentIngredients;

		private EntityQuery CurrentIngredientBlocks;

		private EntityQuery CurrentAppliances;

		private EntityQuery ParcelsAppliances;

		private EntityQuery ParcelsIngredients;

		private EntityQuery Slots;

		private HashSet<Vector3> UsedTiles = new HashSet<Vector3>();

		private EntityQuery CurrentVariableIngredients;

		protected override void Initialise()
		{
			base.Initialise();
			NewPendingDishes = GetEntityQuery(typeof(CNewDish));
			CurrentMenuItems = GetEntityQuery(typeof(CMenuItem), typeof(CAvailableIngredient));
			CurrentIngredients = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[1] { typeof(CItemProvider) },
				None = new ComponentType[1] { typeof(CDynamicItemProvider) }
			});
			CurrentVariableIngredients = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[1] { typeof(CVariableProvider) }
			});
			CurrentAppliances = GetEntityQuery(typeof(CAppliance));
			CurrentIngredientBlocks = GetEntityQuery(typeof(CBlockedIngredient));
			ParcelsAppliances = GetEntityQuery(new QueryHelper().All(typeof(CLetterAppliance)).None(typeof(CreateStartingItems.CIsBonusItem)));
			ParcelsIngredients = GetEntityQuery(typeof(CLetterIngredient));
			Slots = GetEntityQuery(new QueryHelper().All(typeof(CApplianceIngredientSlot)).None(typeof(CForSale)));
			RequireForUpdate(NewPendingDishes);
		}

		protected override void OnUpdate()
		{
			GameData data = base.Data;
			using NativeArray<Entity> nativeArray = NewPendingDishes.ToEntityArray(Allocator.Temp);
			using (CurrentMenuItems.ToEntityArray(Allocator.Temp))
			{
				using NativeArray<CItemProvider> nativeArray2 = CurrentIngredients.ToComponentDataArray<CItemProvider>(Allocator.Temp);
				using NativeArray<CVariableProvider> nativeArray3 = CurrentVariableIngredients.ToComponentDataArray<CVariableProvider>(Allocator.Temp);
				using NativeArray<CAppliance> nativeArray4 = CurrentAppliances.ToComponentDataArray<CAppliance>(Allocator.Temp);
				HashSet<Item> hashSet = new HashSet<Item>();
				foreach (CItemProvider item2 in nativeArray2)
				{
					ItemList providedComponents = item2.ProvidedComponents;
					if (providedComponents.IsNonGroup && data.TryGet<Item>(item2.ProvidedItem, out var output, warn_if_fail: true))
					{
						hashSet.Add(output);
					}
				}
				NativeArray<CLetterIngredient> nativeArray5 = ParcelsIngredients.ToComponentDataArray<CLetterIngredient>(Allocator.Temp);
				foreach (CLetterIngredient item3 in nativeArray5)
				{
					if (item3.IngredientID != 0 && data.TryGet<Item>(item3.IngredientID, out var output2, warn_if_fail: true))
					{
						hashSet.Add(output2);
					}
				}
				foreach (CVariableProvider item4 in nativeArray3)
				{
					if (item4.Provide1 != 0 && data.TryGet<Item>(item4.Provide1, out var output3, warn_if_fail: true))
					{
						hashSet.Add(output3);
					}
					if (item4.Provide2 != 0 && data.TryGet<Item>(item4.Provide2, out var output4, warn_if_fail: true))
					{
						hashSet.Add(output4);
					}
					if (item4.Provide3 != 0 && data.TryGet<Item>(item4.Provide3, out var output5, warn_if_fail: true))
					{
						hashSet.Add(output5);
					}
				}
				nativeArray5.Dispose();
				using NativeArray<CBlockedIngredient> nativeArray6 = CurrentIngredientBlocks.ToComponentDataArray<CBlockedIngredient>(Allocator.Temp);
				HashSet<int> hashSet2 = new HashSet<int>();
				foreach (CBlockedIngredient item5 in nativeArray6)
				{
					hashSet2.Add(item5.Item);
				}
				HashSet<Process> hashSet3 = new HashSet<Process>();
				foreach (CAppliance item6 in nativeArray4)
				{
					if (!data.TryGet<Appliance>(item6, out var output6, warn_if_fail: true))
					{
						continue;
					}
					foreach (Appliance.ApplianceProcesses process in output6.Processes)
					{
						if (process.Validity != ProcessValidity.DoesNotRegister)
						{
							hashSet3.Add(process.Process);
						}
					}
				}
				NativeArray<CLetterAppliance> nativeArray7 = ParcelsAppliances.ToComponentDataArray<CLetterAppliance>(Allocator.Temp);
				foreach (CLetterAppliance item7 in nativeArray7)
				{
					if (item7.ApplianceID == 0 || !data.TryGet<Appliance>(item7.ApplianceID, out var output7, warn_if_fail: true))
					{
						continue;
					}
					foreach (Appliance.ApplianceProcesses process2 in output7.Processes)
					{
						if (process2.Validity != ProcessValidity.DoesNotRegister)
						{
							hashSet3.Add(process2.Process);
						}
					}
				}
				nativeArray7.Dispose();
				if (nativeArray.Length <= 0)
				{
					return;
				}
				CNewDish component = GetComponent<CNewDish>(nativeArray[0]);
				int iD = component.ID;
				base.EntityManager.DestroyEntity(nativeArray[0]);
				if (!data.TryGet<Dish>(iD, out var output8, warn_if_fail: true))
				{
					return;
				}
				HashSet<Process> hashSet4 = new HashSet<Process>(output8.RequiredProcesses);
				hashSet4.ExceptWith(hashSet3);
				HashSet<Item> hashSet5 = new HashSet<Item>(output8.MinimumIngredients);
				hashSet5.ExceptWith(hashSet);
				HashSet<int> hashSet6 = new HashSet<int>();
				foreach (Item item8 in hashSet5)
				{
					if (hashSet2.Contains(item8.ID))
					{
						continue;
					}
					Appliance dedicatedProvider = item8.DedicatedProvider;
					int item = ((dedicatedProvider == null) ? base.Data.ReferableObjects.DefaultProvider.ID : dedicatedProvider.ID);
					if (!hashSet6.Contains(item))
					{
						if (dedicatedProvider != null)
						{
							hashSet6.Add(item);
						}
						Entity entity = base.EntityManager.CreateEntity(typeof(CNeedsNewIngredient));
						base.EntityManager.AddComponentData(entity, new CNeedsNewIngredient
						{
							Item = item8.ID
						});
					}
				}
				List<Vector3> postTiles = GetPostTiles();
				int num = 0;
				NativeArray<Entity> nativeArray8 = Slots.ToEntityArray(Allocator.Temp);
				int num2 = 0;
				UsedTiles.Clear();
				foreach (Process item9 in hashSet4)
				{
					GameDataObject basicEnablingAppliance = item9.BasicEnablingAppliance;
					if (basicEnablingAppliance == null || hashSet6.Contains(basicEnablingAppliance.ID))
					{
						continue;
					}
					hashSet6.Add(basicEnablingAppliance.ID);
					for (int i = 0; i < item9.EnablingApplianceCount; i++)
					{
						if (num2 < nativeArray8.Length)
						{
							Entity entity2 = nativeArray8[num2];
							num2++;
							CPosition component2 = GetComponent<CPosition>(entity2);
							Entity entity3 = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
							base.EntityManager.SetComponentData(entity3, new CCreateAppliance
							{
								ID = basicEnablingAppliance.ID
							});
							base.EntityManager.SetComponentData(entity3, component2);
							base.EntityManager.DestroyEntity(entity2);
							continue;
						}
						Vector3 vector = Vector3.zero;
						bool flag = false;
						while (!flag && num < postTiles.Count)
						{
							vector = postTiles[num++];
							if (!UsedTiles.Contains(vector) && base.TileManager.GetOccupant(vector) == default(Entity) && !base.TileManager.GetTile(vector).HasFeature)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							vector = GetFallbackTile();
						}
						UsedTiles.Add(vector);
						PostHelpers.CreateApplianceParcel(base.EntityManager, vector, basicEnablingAppliance.ID);
					}
				}
				nativeArray8.Dispose();
				HashSet<Dish.IngredientUnlock> unlocksIngredients = output8.UnlocksIngredients;
				int count = output8.UnlocksMenuItems.Count;
				foreach (Dish.MenuItem unlocksMenuItem in output8.UnlocksMenuItems)
				{
					Entity entity4 = base.EntityManager.CreateEntity(typeof(CMenuItem), typeof(CAvailableIngredient));
					base.EntityManager.AddComponentData(entity4, new CMenuItem
					{
						Item = unlocksMenuItem.Item.ID,
						Weight = unlocksMenuItem.Weight / (float)count,
						Phase = unlocksMenuItem.Phase,
						SourceDish = output8.ID
					});
					if (unlocksMenuItem.DynamicMenuType != DynamicMenuType.Static)
					{
						base.EntityManager.AddComponentData(entity4, new CDynamicMenuItem
						{
							Type = unlocksMenuItem.DynamicMenuType,
							Ingredient = unlocksMenuItem.DynamicMenuIngredient.ID
						});
					}
					switch (unlocksMenuItem.Phase)
					{
					case MenuPhase.Starter:
						base.EntityManager.AddComponent<CMenuItemStarter>(entity4);
						break;
					case MenuPhase.Main:
						base.EntityManager.AddComponent<CMenuItemMain>(entity4);
						break;
					case MenuPhase.Dessert:
						base.EntityManager.AddComponent<CMenuItemDessert>(entity4);
						break;
					case MenuPhase.Side:
						base.EntityManager.AddComponent<CMenuItemSide>(entity4);
						break;
					}
					if (!(unlocksMenuItem.Item is ItemGroup itemGroup))
					{
						continue;
					}
					foreach (ItemGroup.ItemSet derivedSet in itemGroup.DerivedSets)
					{
						if (derivedSet.RequiresUnlock)
						{
							continue;
						}
						foreach (Item item10 in derivedSet.Items)
						{
							UnlockIngredient(unlocksMenuItem.Item.ID, item10.ID);
						}
					}
				}
				foreach (Item blockProvider in output8.BlockProviders)
				{
					base.EntityManager.SetComponentData(base.EntityManager.CreateEntity(typeof(CBlockedIngredient)), new CBlockedIngredient
					{
						Item = blockProvider.ID
					});
				}
				if (component.ShowRecipe && !Preferences.Get<bool>(Pref.SkipNewRecipePopups) && !Preferences.Get<bool>(Pref.SpeedrunMode))
				{
					base.PopupUtilities.RequestManagedPopup(PopupType.Recipe, new CPopupRecipe
					{
						ID = output8.ID
					});
					if (output8.AlsoAddRecipes != null)
					{
						foreach (Dish alsoAddRecipe in output8.AlsoAddRecipes)
						{
							base.PopupUtilities.RequestManagedPopup(PopupType.Recipe, new CPopupRecipe
							{
								ID = alsoAddRecipe.ID
							});
						}
					}
				}
				if (unlocksIngredients != null)
				{
					foreach (Dish.IngredientUnlock item11 in unlocksIngredients)
					{
						UnlockIngredient(item11.MenuItem.ID, item11.Ingredient.ID);
					}
				}
				if (output8.ExtraOrderUnlocks == null)
				{
					return;
				}
				foreach (Dish.IngredientUnlock extraOrderUnlock in output8.ExtraOrderUnlocks)
				{
					AddPossibleExtra(extraOrderUnlock.MenuItem.ID, extraOrderUnlock.Ingredient.ID);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
