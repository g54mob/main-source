using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class CheckSellingRequiredIngredient : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SWarning : IComponentData
		{
		}

		private EntityQuery CurrentUnlocks;

		private EntityQuery CurrentIngredients;

		private EntityQuery CurrentVariableIngredients;

		private EntityQuery CurrentIngredientBlocks;

		private EntityQuery CurrentIngredientUnlocks;

		private EntityQuery AllAppliancesNotBeingSold;

		protected override void Initialise()
		{
			base.Initialise();
			CurrentUnlocks = GetEntityQuery(typeof(CProgressionUnlock));
			CurrentIngredients = GetEntityQuery(new QueryHelper().All(typeof(CItemProvider)).None(typeof(CDynamicItemProvider), typeof(CDestroyApplianceAtDay)));
			CurrentVariableIngredients = GetEntityQuery(new QueryHelper().All(typeof(CVariableProvider)).None(typeof(CDestroyApplianceAtDay)));
			CurrentIngredientBlocks = GetEntityQuery(typeof(CBlockedIngredient));
			AllAppliancesNotBeingSold = GetEntityQuery(new QueryHelper().All(typeof(CAppliance)).None(typeof(CDestroyApplianceAtDay)));
		}

		protected override void OnUpdate()
		{
			GameData data = base.Data;
			using NativeArray<CProgressionUnlock> nativeArray = CurrentUnlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
			using NativeArray<CItemProvider> nativeArray2 = CurrentIngredients.ToComponentDataArray<CItemProvider>(Allocator.Temp);
			using NativeArray<CVariableProvider> nativeArray3 = CurrentVariableIngredients.ToComponentDataArray<CVariableProvider>(Allocator.Temp);
			using NativeArray<CBlockedIngredient> nativeArray4 = CurrentIngredientBlocks.ToComponentDataArray<CBlockedIngredient>(Allocator.Temp);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (CProgressionUnlock item in nativeArray)
			{
				if (!GameData.Main.TryGet<Dish>(item.ID, out var output))
				{
					continue;
				}
				foreach (Item minimumIngredient in output.MinimumIngredients)
				{
					hashSet.Add(minimumIngredient.ID);
				}
			}
			foreach (CItemProvider item2 in nativeArray2)
			{
				ItemList providedComponents = item2.ProvidedComponents;
				if (providedComponents.IsNonGroup && data.TryGet<Item>(item2.ProvidedItem, out var output2, warn_if_fail: true))
				{
					hashSet.Remove(output2.ID);
				}
			}
			foreach (CVariableProvider item3 in nativeArray3)
			{
				hashSet.Remove(item3.Provide1);
				hashSet.Remove(item3.Provide2);
				hashSet.Remove(item3.Provide3);
			}
			foreach (CBlockedIngredient item4 in nativeArray4)
			{
				hashSet.Remove(item4.Item);
			}
			hashSet.Remove(0);
			Clear<SWarning>();
			if (hashSet.Count == 0)
			{
				return;
			}
			using NativeArray<CAppliance> nativeArray5 = AllAppliancesNotBeingSold.ToComponentDataArray<CAppliance>(Allocator.Temp);
			foreach (int item5 in hashSet)
			{
				if (!GameData.Main.TryGet<Item>(item5, out var output3))
				{
					continue;
				}
				bool flag = false;
				if ((bool)(Object)(object)output3.DedicatedProvider)
				{
					foreach (CAppliance item6 in nativeArray5)
					{
						if (item6.ID == output3.DedicatedProvider.ID)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					Set<SWarning>();
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
