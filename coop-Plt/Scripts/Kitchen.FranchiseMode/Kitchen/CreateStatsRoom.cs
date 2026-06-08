using System.Linq;
using KitchenData;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateStatsRoom : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			if (PlatformSettings.DebugQuickLoadLobby)
			{
				return;
			}
			EntityContext ctx = new EntityContext(base.EntityManager);
			if (PlatformSettings.IsDemoMode || !SpeedrunHelpers.IsStatsRoomUnlocked(ctx))
			{
				Create(GameData.Main.Get<Appliance>(AssetReference.StatsLock), LobbyPositionAnchors.Stats + new Vector3(0f, 0f, -3f), Vector3.forward);
				return;
			}
			Create(AssetReference.ExperienceView, LobbyPositionAnchors.Stats + new Vector3(0f, 0f, -3f), Vector3.forward);
			if (Platform.Current.CanShowAchievementProgress)
			{
				Create(AssetReference.AchievementView, LobbyPositionAnchors.Stats + new Vector3(0f, 0f, -1f), Vector3.forward);
			}
			Create(AssetReference.UnlockTrackView, LobbyPositionAnchors.Stats + new Vector3(2f, 0f, -1f), Vector3.forward);
			CreateSpeedrunBoard(ctx);
		}

		private void CreateSpeedrunBoard(EntityContext ctx)
		{
			(int year, int week) tuple = SpeedrunHelpers.CurrentLeaderboardYearAndWeek();
			int item = tuple.year;
			int item2 = tuple.week;
			LayoutSeed layoutSeed = new LayoutSeed(item * 200 + item2);
			using FixedSeedContext fixedSeedContext = new FixedSeedContext(layoutSeed.FixedSeed, 8853129);
			int setting_id;
			using (fixedSeedContext.UseSubcontext(0))
			{
				setting_id = AssetReference.FixedRunSetting.Random();
			}
			int iD;
			using (fixedSeedContext.UseSubcontext(1))
			{
				iD = (from x in GameData.Main.Get<Dish>()
					where x.IsSpeedrunDish
					select x).ToList().Random().ID;
			}
			Vector3 stats = LobbyPositionAnchors.Stats;
			Entity entity = Create(AssetReference.FixedRunPedestal, stats + new Vector3(-2.5f, 0f, 0f), Vector3.forward);
			Entity entity2 = Create(AssetReference.SpeedrunBoardVisual, stats + new Vector3(-2f, 0f, 0f), Vector3.forward);
			ctx.Add<CSpeedrunBoard>(entity2);
			Entity entity3 = layoutSeed.GenerateMap(base.EntityManager, setting_id);
			ctx.Set(entity3, new CSpeedrun
			{
				Seed = layoutSeed.FixedSeed,
				Year = item,
				Week = item2,
				DishID = iD
			});
			ctx.Set(entity, (CItemHolder)entity3);
			ctx.Set(entity3, (CHeldBy)entity);
			ctx.Set(entity3, (CHome)entity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
