using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts;
using Kitchen.ShopBuilder;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateShopRequests))]
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class HandleNewShop : NightSystem
	{
		private struct SShopRandomCounter : IComponentData
		{
			public Random.State State;

			public int Day;
		}

		private EntityQuery NewShops;

		private EntityQuery Discounts;

		private EntityQuery Extras;

		private EntityQuery DestroyExtras;

		private EntityQuery NewDecorShops;

		private EntityQuery Appliances;

		private EntityQuery Blockers;

		private EntityQuery BlueprintGrantDuplicators;

		private EntityQuery RandomShopPrices;

		private EntityQuery UpgradedShopChance;

		private EntityQuery ShopOptions;

		private readonly HashSet<int> TmpOffered = new HashSet<int>();

		private const int RandomSeedInstance = 823828;

		protected override void Initialise()
		{
			base.Initialise();
			NewShops = GetEntityQuery(typeof(CNewShop));
			NewDecorShops = GetEntityQuery(typeof(CNewDecorShop));
			Discounts = GetEntityQuery(typeof(CGrantsShopDiscount));
			Extras = GetEntityQuery(typeof(CGrantsExtraBlueprint));
			DestroyExtras = GetEntityQuery(typeof(CGrantsExtraBlueprint), typeof(CDestroyAfterUsage));
			BlueprintGrantDuplicators = GetEntityQuery(typeof(CBlueprintGrantDuplicator));
			RandomShopPrices = GetEntityQuery(typeof(CRandomiseShopPrices));
			UpgradedShopChance = GetEntityQuery(typeof(CUpgradedShopChance));
			Blockers = GetEntityQuery(new QueryHelper().Any(typeof(CProgressionOption), typeof(CProgressionRequest), typeof(CPopup)));
			ShopOptions = GetEntityQuery(typeof(CShopBuilderOption));
			Set<SShopRandomCounter>();
		}

		private FixedSeedContext GetRandomState(int day)
		{
			if (TryGetSingleton<SShopRandomCounter>(out var value) && value.Day == day)
			{
				return new FixedSeedContext(value.State, 823828, day);
			}
			value.State = GetState(823828, day);
			value.Day = day;
			Set(value);
			return new FixedSeedContext(value.State, 823828, day);
		}

		private void SaveRandomState(int day)
		{
			SShopRandomCounter orCreate = GetOrCreate<SShopRandomCounter>();
			orCreate.State = Random.state;
			orCreate.Day = day;
			Set(orCreate);
		}

		protected override void OnUpdate()
		{
			if (!Blockers.IsEmpty)
			{
				return;
			}
			using NativeArray<CGrantsExtraBlueprint> nativeArray = Extras.ToComponentDataArray<CGrantsExtraBlueprint>(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = Extras.ToEntityArray(Allocator.Temp);
			bool flag = false;
			foreach (CGrantsExtraBlueprint item in nativeArray)
			{
				flag |= item.ID != 0;
			}
			if (NewShops.IsEmpty && NewDecorShops.IsEmpty && !flag)
			{
				return;
			}
			int day = 1;
			if (Require<SDay>(out var comp))
			{
				day = comp.Day;
			}
			using FixedSeedContext fixedSeedContext = GetRandomState(day);
			using NativeArray<Entity> nativeArray3 = NewShops.ToEntityArray(Allocator.Temp);
			using NativeArray<Entity> nativeArray4 = NewDecorShops.ToEntityArray(Allocator.Temp);
			using NativeArray<CShopBuilderOption> list = ShopOptions.ToComponentDataArray<CShopBuilderOption>(Allocator.Temp);
			bool flag2 = Preferences.Get<bool>(Pref.LettersSpawnInside);
			FixedSeedContext fixedSeedContext2 = fixedSeedContext.UseSubcontext(1);
			List<Vector3> postTiles = GetPostTiles();
			fixedSeedContext2.Dispose();
			int placed_tile = 0;
			bool flag3 = !RandomShopPrices.IsEmpty;
			using NativeArray<CUpgradedShopChance> nativeArray5 = UpgradedShopChance.ToComponentDataArray<CUpgradedShopChance>(Allocator.Temp);
			float num = DifficultyHelpers.BaseUpgradedShopChance(comp.Day);
			foreach (CUpgradedShopChance item2 in nativeArray5)
			{
				num += (1f - num) * item2.Chance;
			}
			int num2 = BlueprintGrantDuplicators.CalculateEntityCount();
			using NativeArray<CGrantsShopDiscount> nativeArray6 = Discounts.ToComponentDataArray<CGrantsShopDiscount>(Allocator.Temp);
			float num3 = 1f;
			foreach (CGrantsShopDiscount item3 in nativeArray6)
			{
				num3 *= 1f - item3.Amount;
			}
			for (int i = 0; i < nativeArray.Length; i++)
			{
				CGrantsExtraBlueprint cGrantsExtraBlueprint = nativeArray[i];
				int num4 = ((!cGrantsExtraBlueprint.CanBeDuplicated) ? 1 : (1 + num2));
				if (cGrantsExtraBlueprint.ID != 0)
				{
					for (int j = 0; j < num4; j++)
					{
						Vector3 position = FindTile(ref placed_tile, postTiles);
						int force_price = (flag3 ? RandomPrice() : (-1));
						PostHelpers.CreateBlueprintLetter(base.EntityManager, position, cGrantsExtraBlueprint.ID, cGrantsExtraBlueprint.IsFree ? 0f : num3, force_price);
					}
					Set(nativeArray2[i], default(CGrantsExtraBlueprint));
				}
			}
			bool flag4 = HasStatus(RestaurantStatus.JanuaryRedEnvelopes);
			if (flag4)
			{
				num += (1f - num) * 0.2f;
			}
			if (flag4)
			{
				num3 *= 0.75f;
			}
			TmpOffered.Clear();
			for (int k = 0; k < nativeArray3.Length; k++)
			{
				Entity entity = nativeArray3[k];
				CNewShop component = GetComponent<CNewShop>(entity);
				bool flag5 = Random.value < num;
				list.ShuffleInPlace();
				for (int l = 0; l < list.Length; l++)
				{
					CShopBuilderOption cShopBuilderOption = list[l];
					if (!cShopBuilderOption.IsRemoved && !TmpOffered.Contains(cShopBuilderOption.Appliance) && cShopBuilderOption.MatchesRequestTags(component.Tags) && (flag5 || cShopBuilderOption.Staple != ShopStapleType.NonStaple || !cShopBuilderOption.SellAsUpgrade))
					{
						if (component.Tags != ShoppingTags.Decoration)
						{
							TmpOffered.Add(cShopBuilderOption.Appliance);
						}
						Vector3 position2 = component.Location;
						if (!component.FixedLocation)
						{
							position2 = FindTile(ref placed_tile, postTiles);
						}
						int num5 = (flag3 ? RandomPrice() : (-1));
						num5 = ((!component.IsFree) ? num5 : 0);
						if (!component.StartOpen)
						{
							PostHelpers.CreateBlueprintLetter(base.EntityManager, position2, cShopBuilderOption.Appliance, num3, num5, flag4);
						}
						else
						{
							PostHelpers.CreateOpenedLetter(new EntityContext(base.EntityManager), position2, cShopBuilderOption.Appliance, num3, num5);
						}
						break;
					}
				}
				base.EntityManager.DestroyEntity(entity);
			}
			if (!flag2)
			{
				postTiles = GetPostTiles(force_inside: true);
				placed_tile = 0;
			}
			List<Decor> list2 = (from e in base.Data.Get<Decor>()
				where e.IsAvailable
				select e).ToList().Shuffle();
			for (int num6 = 0; num6 < Mathf.Min(list2.Count, nativeArray4.Length); num6++)
			{
				Decor decor = list2[num6];
				Vector3 position3 = FindTile(ref placed_tile, postTiles);
				AddDecorationItem(decor.ApplicatorAppliance.ID, decor.ID, position3, decor.Type);
				base.EntityManager.DestroyEntity(nativeArray4[num6]);
			}
			base.EntityManager.DestroyEntity(DestroyExtras);
			SaveRandomState(day);
		}

		private int RandomPrice()
		{
			int num = 0;
			for (int i = 0; i < 5 && !(Random.value < 0.1f * (float)(i + 1)); i++)
			{
				num++;
			}
			return Appliance.GetPrice((PriceTier)num);
		}

		public Vector3 FindTile(ref int placed_tile, List<Vector3> floor_tiles)
		{
			Vector3 vector = default(Vector3);
			bool flag = false;
			while (!flag && placed_tile < floor_tiles.Count)
			{
				vector = floor_tiles[placed_tile++];
				if (!(base.TileManager.GetOccupant(vector) == default(Entity)))
				{
					continue;
				}
				flag = true;
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					Entity occupant = base.TileManager.GetOccupant(vector + (Vector3)direction);
					if (occupant != default(Entity) && Has<CApplianceTable>(occupant))
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				return GetFallbackTile();
			}
			return vector;
		}

		protected void AddDecorationItem(int applicator_id, int wallpaper_id, Vector3 position, LayoutMaterialType type)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CCreateAppliance
			{
				ID = applicator_id
			});
			base.EntityManager.AddComponentData(entity, new CPosition(position));
			base.EntityManager.AddComponentData(entity, new CApplyDecor
			{
				ID = wallpaper_id,
				Type = type
			});
			base.EntityManager.AddComponentData(entity, new CDrawApplianceUsing
			{
				DrawApplianceID = wallpaper_id
			});
			base.EntityManager.AddComponentData(entity, default(CShopEntity));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
