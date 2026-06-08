using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KitchenData;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateSeededRuns : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			Season season = Seasons.GetSeason();
			if (season == Season.Normal && (!Require<SPlayerLevel>(out var comp) || comp.Level < 2))
			{
				return;
			}
			Vector3 office = LobbyPositionAnchors.Office;
			Entity entity = Create(AssetReference.FixedRunPedestal, office + new Vector3(2.5f, 0f, 0f), Vector3.forward);
			Entity entity2 = Create(AssetReference.FixedRunPedestal, office + new Vector3(3.5f, 0f, 0f), Vector3.forward);
			Create(AssetReference.FixedRunVisual, office + new Vector3(3f, 0f, 0f), Vector3.forward);
			bool flag = false;
			LayoutSeed layoutSeed = DetermineFixedDailyRunSeed();
			LayoutSeed layoutSeed2 = DetermineFixedWeeklyRunSeed();
			if (season != Season.Normal)
			{
				using (new FixedSeedContext(layoutSeed.FixedSeed, 1285380))
				{
					flag |= CreateSeasonalOverride(season, entity, DetermineFixedWeeklyRunSeed);
				}
				using (new FixedSeedContext(layoutSeed2.FixedSeed, 1285382))
				{
					flag |= CreateSeasonalOverride(season, entity2, DetermineFixedWeeklyRunSeed);
				}
			}
			if (!flag)
			{
				int id;
				using (new FixedSeedContext(layoutSeed2.FixedSeed, 1238979))
				{
					id = AssetReference.FixedRunSetting.Random();
				}
				if (GameData.Main.TryGet<RestaurantSetting>(id, out var output))
				{
					CreateSeededRun(layoutSeed, entity, output);
					CreateSeededRun(layoutSeed2, entity2, output);
				}
			}
			if (!PlatformSettings.IsDemoMode)
			{
				Entity entity3 = Create(AssetReference.SeededRunIndicator, office + new Vector3(-2f, 0f, 0f), Vector3.forward);
				base.EntityManager.AddComponent<CSeededRunInfo>(entity3);
			}
		}

		private bool CreateSeasonalOverride(Season season, Entity pedestal_day, Func<int[], LayoutSeed> determine)
		{
			bool result = false;
			foreach (RestaurantSetting item in GameData.Main.Get<RestaurantSetting>().ToList().Shuffle())
			{
				if (item.FixedRunSeason != season)
				{
					continue;
				}
				List<int> list = new List<int>();
				if (item.ForceLayout != null)
				{
					list.Add(item.ForceLayout.ID);
				}
				else
				{
					foreach (LayoutProfile item2 in GameData.Main.Get<LayoutProfile>().ToList().Shuffle())
					{
						if (item2.FixedRunSeason == season)
						{
							list.Add(item2.ID);
							result = true;
						}
					}
				}
				if (list.Count > 0)
				{
					result = true;
					LayoutSeed ls = determine(list.ToArray());
					CreateSeededRun(ls, pedestal_day, item);
					break;
				}
			}
			return result;
		}

		private void CreateSeededRun(LayoutSeed ls, Entity pedestal, RestaurantSetting setting)
		{
			Entity entity = ls.GenerateMap(base.EntityManager, setting.ID);
			base.EntityManager.AddComponentData(pedestal, (CItemHolder)entity);
			base.EntityManager.SetComponentData(entity, (CHeldBy)pedestal);
			base.EntityManager.AddComponentData(entity, (CHome)pedestal);
			if (setting.FixedDish != null)
			{
				base.EntityManager.AddComponentData(entity, new CSettingDish
				{
					DishID = setting.FixedDish.ID
				});
			}
		}

		private LayoutSeed DetermineFixedWeeklyRunSeed(int[] valid_layout_ids = null)
		{
			GregorianCalendar gregorianCalendar = new GregorianCalendar();
			int weekOfYear = gregorianCalendar.GetWeekOfYear(DateTime.UtcNow, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
			return new LayoutSeed(gregorianCalendar.GetYear(DateTime.UtcNow) * 100 + weekOfYear, valid_layout_ids);
		}

		private LayoutSeed DetermineFixedDailyRunSeed(int[] valid_layout_ids = null)
		{
			GregorianCalendar gregorianCalendar = new GregorianCalendar();
			int dayOfYear = gregorianCalendar.GetDayOfYear(DateTime.UtcNow);
			return new LayoutSeed(gregorianCalendar.GetYear(DateTime.UtcNow) * 1000 + dayOfYear, valid_layout_ids);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
