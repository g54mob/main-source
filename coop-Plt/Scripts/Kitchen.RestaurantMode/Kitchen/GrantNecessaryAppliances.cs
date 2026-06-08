using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	[UpdateAfter(typeof(HandleNewDish))]
	[UpdateAfter(typeof(HandleNewIngredients))]
	[UpdateAfter(typeof(CheckSellingRequiredAppliance))]
	public class GrantNecessaryAppliances : NightSystem
	{
		private EntityQuery Tables;

		private EntityQuery SoldProviders;

		private EntityQuery UnsoldProviders;

		private EntityQuery Appliances;

		private EntityQuery Parcels;

		private EntityQuery IngredientParcels;

		private EntityQuery Unlocks;

		private EntityQuery CreateAppliances;

		private Dictionary<int, (int, int)> ProvidersOfType = new Dictionary<int, (int, int)>();

		private Dictionary<int, int> TablesOfType = new Dictionary<int, int>();

		protected override void Initialise()
		{
			base.Initialise();
			Tables = GetEntityQuery(typeof(CAppliance), typeof(CApplianceTable));
			SoldProviders = GetEntityQuery(typeof(CAppliance), typeof(CItemProvider), typeof(CDestroyApplianceAtDay));
			UnsoldProviders = GetEntityQuery(new QueryHelper().All(typeof(CAppliance), typeof(CItemProvider)).None(typeof(CDestroyApplianceAtDay)));
			Appliances = GetEntityQuery(typeof(CAppliance));
			Unlocks = GetEntityQuery(typeof(CProgressionUnlock));
			Parcels = GetEntityQuery(typeof(CLetterAppliance));
			IngredientParcels = GetEntityQuery(typeof(CLetterIngredient));
			CreateAppliances = GetEntityQuery(new QueryHelper().Any(typeof(CCreateAppliance), typeof(CNeedsNewIngredient)));
		}

		protected override void OnUpdate()
		{
			if (!CreateAppliances.IsEmpty)
			{
				return;
			}
			int maximumGroupSize = GetOrDefault<SKitchenParameters>().Parameters.MaximumGroupSize;
			int offset = 0;
			if (MaxTableSize() < maximumGroupSize)
			{
				List<Vector3> postTiles = GetPostTiles();
				Vector3 parcelTile = GetParcelTile(postTiles, ref offset);
				PostHelpers.CreateApplianceParcel(base.EntityManager, parcelTile, AssetReference.Table);
			}
			using NativeArray<CProgressionUnlock> nativeArray = Unlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
			bool flag = false;
			bool flag2 = false;
			foreach (CProgressionUnlock item in nativeArray)
			{
				if (!base.Data.TryGet<Dish>(item.ID, out var output))
				{
					continue;
				}
				if (output.RequiresCleaning)
				{
					flag = true;
				}
				if (output.IsMainThatDoesNotNeedPlates)
				{
					continue;
				}
				foreach (Dish.MenuItem unlocksMenuItem in output.UnlocksMenuItems)
				{
					if (unlocksMenuItem.Phase == MenuPhase.Main)
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				(int, int) tuple = TotalPlates();
				if (tuple.Item2 < maximumGroupSize)
				{
					List<Vector3> postTiles2 = GetPostTiles();
					Vector3 parcelTile2 = GetParcelTile(postTiles2, ref offset);
					if (GameData.Main.TryGet<Item>(AssetReference.Plate, out var output2) && output2.DedicatedProvider != null)
					{
						PostHelpers.CreateApplianceParcel(base.EntityManager, parcelTile2, output2.DedicatedProvider.ID);
					}
				}
				else if (tuple.Item1 < maximumGroupSize)
				{
					Set<CheckSellingRequiredAppliance.SWarning>();
				}
			}
			if (flag && HasNoCleaningProcess())
			{
				List<Vector3> postTiles3 = GetPostTiles();
				Vector3 parcelTile3 = GetParcelTile(postTiles3, ref offset);
				PostHelpers.CreateApplianceParcel(base.EntityManager, parcelTile3, AssetReference.Sink);
			}
		}

		private bool HasNoCleaningProcess()
		{
			using NativeArray<CAppliance> current_appliances = Appliances.ToComponentDataArray<CAppliance>(Allocator.Temp);
			using NativeArray<CLetterAppliance> current_parcels = Parcels.ToComponentDataArray<CLetterAppliance>(Allocator.Temp);
			return CheckSellingRequiredAppliance.IsMissingCleaningProcess(current_appliances, current_parcels);
		}

		private Vector3 GetParcelTile(List<Vector3> tiles, ref int offset)
		{
			Vector3 vector = Vector3.zero;
			bool flag = false;
			while (!flag && offset < tiles.Count)
			{
				vector = tiles[offset++];
				if (base.TileManager.GetOccupant(vector) == default(Entity) && !base.TileManager.GetTile(vector).HasFeature)
				{
					flag = true;
				}
			}
			if (flag)
			{
				return vector;
			}
			return GetFallbackTile();
		}

		private (int unsold, int total) TotalPlates()
		{
			ProvidersOfType.Clear();
			using NativeArray<CAppliance> nativeArray = SoldProviders.ToComponentDataArray<CAppliance>(Allocator.Temp);
			using NativeArray<CAppliance> nativeArray2 = UnsoldProviders.ToComponentDataArray<CAppliance>(Allocator.Temp);
			using NativeArray<CLetterAppliance> nativeArray3 = Parcels.ToComponentDataArray<CLetterAppliance>(Allocator.Temp);
			using NativeArray<CLetterIngredient> nativeArray4 = IngredientParcels.ToComponentDataArray<CLetterIngredient>(Allocator.Temp);
			foreach (CAppliance item in nativeArray)
			{
				Add(ProvidersOfType, item.ID, is_unsold: false);
			}
			foreach (CAppliance item2 in nativeArray2)
			{
				Add(ProvidersOfType, item2.ID, is_unsold: true);
			}
			foreach (CLetterAppliance item3 in nativeArray3)
			{
				Add(ProvidersOfType, item3.ApplianceID, is_unsold: true);
			}
			foreach (CLetterIngredient item4 in nativeArray4)
			{
				if (GameData.Main.TryGet<Item>(item4.IngredientID, out var output) && output.DedicatedProvider != null)
				{
					Add(ProvidersOfType, output.DedicatedProvider.ID, is_unsold: true);
				}
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<int, (int, int)> item5 in ProvidersOfType)
			{
				if (item5.Value.Item2 > 0 && GameData.Main.TryGet<Appliance>(item5.Key, out var output2) && output2.GetProperty<CItemProvider>(out var result) && result.DefaultProvidedItem == AssetReference.Plate)
				{
					num += result.Maximum * item5.Value.Item1;
					num2 += result.Maximum * item5.Value.Item2;
				}
			}
			return (unsold: num, total: num2);
		}

		private int MaxTableSize()
		{
			TablesOfType.Clear();
			using NativeArray<CAppliance> nativeArray = Tables.ToComponentDataArray<CAppliance>(Allocator.Temp);
			using NativeArray<CLetterAppliance> nativeArray2 = Parcels.ToComponentDataArray<CLetterAppliance>(Allocator.Temp);
			foreach (CAppliance item in nativeArray)
			{
				Add(TablesOfType, item.ID);
			}
			foreach (CLetterAppliance item2 in nativeArray2)
			{
				Add(TablesOfType, item2.ApplianceID);
			}
			int num = 0;
			foreach (KeyValuePair<int, int> item3 in TablesOfType)
			{
				if (item3.Value > 0 && GameData.Main.TryGet<Appliance>(item3.Key, out var output) && output.GetProperty<CApplianceTable>(out var result) && !result.IsWaitingTable)
				{
					num = Mathf.Max(GetMaxSeats(result.MaxSeats, item3.Value, !result.IsIndividualTable), num);
				}
			}
			return num;
		}

		private int GetMaxSeats(int per_table, int table_count, bool can_combine)
		{
			if (can_combine)
			{
				switch (table_count)
				{
				case 1:
					break;
				case 2:
					return Mathf.Clamp(per_table, 0, 3) * 2;
				default:
					return Mathf.Clamp(per_table, 0, 3) * 2 + Mathf.Clamp(per_table, 0, 2) * (table_count - 2);
				}
			}
			return per_table;
		}

		private void Add(Dictionary<int, int> dict, int key)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				dict[key] = 0;
			}
			dict[key] = value + 1;
		}

		private void Add(Dictionary<int, (int, int)> dict, int key, bool is_unsold)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				dict[key] = (0, 0);
			}
			dict[key] = (value.Item1 + (is_unsold ? 1 : 0), value.Item2 + 1);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
