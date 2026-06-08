using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(SelectFishOfDay))]
	public class CreateTwitchMenuOptions : RestaurantSystem
	{
		private EntityQuery Options;

		private EntityQuery MenuItems;

		private EntityQuery Ingredients;

		private HashSet<int> TempIngredients = new HashSet<int>();

		private HashSet<ItemList> SelectedOptions = new HashSet<ItemList>();

		protected override void Initialise()
		{
			base.Initialise();
			Options = GetEntityQuery(typeof(CTwitchOrderOption));
			MenuItems = GetEntityQuery(new QueryHelper().All(typeof(CMenuItem)).None(typeof(CDisabledMenuItem)));
			Ingredients = GetEntityQuery(typeof(CAvailableIngredient));
		}

		protected override void OnUpdate()
		{
			if (Has<SIsNightTime>() || !Has<STwitchOrderingActive>())
			{
				base.EntityManager.DestroyEntity(Options);
			}
			else
			{
				if (!Options.IsEmpty || Has<SIsDayFirstUpdate>())
				{
					return;
				}
				SelectedOptions.Clear();
				int num = 0;
				for (int i = 0; i < 20; i++)
				{
					if (CreateOption(num))
					{
						num++;
						if (num >= 3)
						{
							break;
						}
					}
				}
			}
		}

		private bool CreateOption(int index)
		{
			using NativeArray<Entity> nativeArray = MenuItems.ToEntityArray(Allocator.TempJob);
			using NativeArray<CMenuItem> items = MenuItems.ToComponentDataArray<CMenuItem>(Allocator.TempJob);
			using NativeArray<CAvailableIngredient> nativeArray2 = Ingredients.ToComponentDataArray<CAvailableIngredient>(Allocator.TempJob);
			if (nativeArray.Length == 0)
			{
				return false;
			}
			int num = PickRandomMenuItem(items, MenuPhase.Main);
			if (num == -1)
			{
				return false;
			}
			CMenuItem cMenuItem = items[num];
			NativeArray<CAvailableIngredient> nativeArray3 = nativeArray2;
			TempIngredients.Clear();
			for (int i = 0; i < nativeArray3.Length; i++)
			{
				CAvailableIngredient cAvailableIngredient = nativeArray3[i];
				if (cAvailableIngredient.MenuItem == cMenuItem.Item)
				{
					TempIngredients.Add(cAvailableIngredient.Ingredient);
				}
			}
			int item = cMenuItem.Item;
			if (!base.Data.TryGet<Item>(item, out var output, warn_if_fail: true))
			{
				return false;
			}
			ItemList itemList = ((output is ItemGroup) ? base.Data.ItemSetView.GetRandomConfiguration(item, TempIngredients) : new ItemList(item));
			foreach (ItemList selectedOption in SelectedOptions)
			{
				if (selectedOption.IsEquivalent(itemList))
				{
					return false;
				}
			}
			SelectedOptions.Add(itemList);
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				Type = ViewType.TwitchOrderOption,
				ViewMode = ViewMode.Screen
			});
			base.EntityManager.AddComponentData(entity, new CTwitchOrderOption
			{
				Index = index + 1
			});
			base.EntityManager.AddComponentData(entity, new CPosition(new Vector3(0f, 1f, 0f)));
			base.EntityManager.AddComponentData(entity, new CItem
			{
				ID = item,
				Items = itemList
			});
			return true;
		}

		public int PickRandomMenuItem(NativeArray<CMenuItem> items, MenuPhase phase)
		{
			float num = 0f;
			foreach (CMenuItem item in items)
			{
				if (item.Phase == phase)
				{
					num += item.Weight;
				}
			}
			float num2 = Random.Range(0f, num);
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].Phase == phase)
				{
					num2 -= items[i].Weight;
					if (num2 <= 0f)
					{
						return i;
					}
				}
			}
			return -1;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
