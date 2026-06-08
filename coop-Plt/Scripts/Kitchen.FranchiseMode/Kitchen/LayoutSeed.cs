using System;
using System.Linq;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class LayoutSeed
	{
		private const int MaxSeedGenerationAttempts = 1000;

		public Seed FixedSeed { get; }

		public int LayoutID { get; }

		public LayoutSeed(Seed seed)
		{
			FixedSeed = seed;
			LayoutID = LayoutIDFromSeed();
		}

		public LayoutSeed(int source, int[] valid_layout_ids = null)
		{
			bool flag = valid_layout_ids != null && valid_layout_ids.Length != 0;
			if (!flag || valid_layout_ids.Intersect(AssetReference.FixedRunLayout).Any())
			{
				for (int i = 0; i < 1000; i++)
				{
					FixedSeed = Seed.Generate(source + i * 1000 * 10);
					LayoutID = LayoutIDFromSeed();
					if (!flag || Array.IndexOf(valid_layout_ids, LayoutID) > -1)
					{
						return;
					}
				}
				Debug.LogWarning("failed to generate layout seed in a reasonable number of attempts");
			}
			FixedSeed = Seed.Generate(source);
			using FixedSeedContext fixedSeedContext = new FixedSeedContext(FixedSeed, 883498);
			using (fixedSeedContext.UseSubcontext(0))
			{
				LayoutID = (flag ? valid_layout_ids.Random() : AssetReference.FixedRunLayout.Random());
			}
		}

		public Entity GenerateMap(EntityManager em, int setting_id)
		{
			RestaurantSetting restaurantSetting = GameData.Main.Get<RestaurantSetting>(setting_id);
			int num = ((LayoutID == 0) ? LayoutIDFromSeed() : LayoutID);
			bool flag = num == LayoutIDFromSeed();
			if (flag && restaurantSetting.ForceLayout != null)
			{
				num = restaurantSetting.ForceLayout.ID;
			}
			LayoutProfile profile = GameData.Main.Get<LayoutProfile>(num);
			using FixedSeedContext fixedSeedContext = new FixedSeedContext(FixedSeed, 98234234);
			using (fixedSeedContext.UseSubcontext(0))
			{
				int seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
				Entity layout = CreateLayoutHelper.ConstructLayout(em, profile, restaurantSetting, seed);
				return CreateMapItem(em, layout, restaurantSetting, FixedSeed, flag);
			}
		}

		private static Entity CreateMapItem(EntityManager em, Entity layout, RestaurantSetting setting, Seed seed, bool show_seed)
		{
			Entity entity = em.CreateEntity(typeof(CCreateItem), typeof(CHeldBy), typeof(CHome));
			em.SetComponentData(entity, new CCreateItem
			{
				ID = AssetReference.MapItem
			});
			em.AddComponentData(entity, new CItemLayoutMap
			{
				Layout = layout
			});
			em.AddComponentData(entity, new CSetting
			{
				RestaurantSetting = setting.ID,
				FixedSeed = seed
			});
			if (show_seed)
			{
				em.AddComponent<CShowSeed>(entity);
			}
			return entity;
		}

		private int LayoutIDFromSeed()
		{
			using FixedSeedContext fixedSeedContext = new FixedSeedContext(FixedSeed, 5078598);
			using (fixedSeedContext.UseSubcontext(0))
			{
				return AssetReference.FixedRunLayout.Random();
			}
		}
	}
}
