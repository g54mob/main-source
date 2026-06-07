using Simulator;
using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class TabletopGameScoreTracker : GameScoreTracker
	{
		public int MiniatureBoxUnpacked { get; private set; }

		public int MiniatureAssembled { get; private set; }

		public float PaintingEarnings { get; private set; }

		public float WargameEarnings { get; private set; }

		protected override void Load()
		{
			base.Load();
			SaveClass_TabletopGameScore tabletopGameScore = SaveManager.GetCurrentSaveAs<TabletopSave>().tabletopGameScore;
			MiniatureBoxUnpacked = tabletopGameScore.miniatureBoxUnpacked;
			MiniatureAssembled = tabletopGameScore.miniatureAssembled;
			PaintingEarnings = tabletopGameScore.paintingEarnings;
			WargameEarnings = tabletopGameScore.wargameEarnings;
		}

		public override void Save()
		{
			base.Save();
			SaveClass_TabletopGameScore tabletopGameScore = SaveManager.GetCurrentSaveAs<TabletopSave>().tabletopGameScore;
			tabletopGameScore.miniatureBoxUnpacked = MiniatureBoxUnpacked;
			tabletopGameScore.miniatureAssembled = MiniatureAssembled;
			tabletopGameScore.paintingEarnings = PaintingEarnings;
			tabletopGameScore.wargameEarnings = WargameEarnings;
		}

		protected override void Register()
		{
			base.Register();
			MiniatureBoxProduct.StartOpenBox += OnUnpackedMiniatureBox;
			Collection.CompleteAssembleMiniature += OnAssembledMiniature;
			TabletopClientBehaviour.CompletedPainting += OnCompletedPainting;
			TabletopClientBehaviour.CompletedWargame += OnCompletedWargame;
		}

		public override void Unregister()
		{
			base.Unregister();
			MiniatureBoxProduct.StartOpenBox -= OnUnpackedMiniatureBox;
			Collection.CompleteAssembleMiniature -= OnAssembledMiniature;
			TabletopClientBehaviour.CompletedPainting -= OnCompletedPainting;
			TabletopClientBehaviour.CompletedWargame -= OnCompletedWargame;
		}

		private void OnUnpackedMiniatureBox(int uid)
		{
			MiniatureBoxUnpacked++;
			switch (MiniatureBoxUnpacked)
			{
			case 1:
				ESteamAchievement.PACK_OPENER.Trigger();
				break;
			case 100:
				ESteamAchievement.PACK_OPENER_100.Trigger();
				break;
			case 500:
				ESteamAchievement.PACK_OPENER_500.Trigger();
				break;
			case 1000:
				ESteamAchievement.PACK_OPENER_1000.Trigger();
				break;
			}
			if (ProductDatabase.Get(uid) is MiniatureBoxProductData miniatureBoxProductData)
			{
				switch (miniatureBoxProductData.Rarity)
				{
				case EMiniatureBoxRarity.NORMAL:
					ESteamAchievement.BASIC_SHOP.Trigger();
					break;
				case EMiniatureBoxRarity.COLLECTOR:
					ESteamAchievement.COLLECTOR_SHOP.Trigger();
					break;
				case EMiniatureBoxRarity.LEGENDARY:
					ESteamAchievement.LEGENDARY_SHOP.Trigger();
					break;
				}
			}
		}

		private void OnAssembledMiniature(int uid)
		{
			MiniatureAssembled++;
			switch (MiniatureAssembled)
			{
			case 1:
				ESteamAchievement.ASSEMBLE_MINIATURE.Trigger();
				break;
			case 50:
				ESteamAchievement.ASSEMBLE_MINIATURE_50.Trigger();
				break;
			case 150:
				ESteamAchievement.ASSEMBLE_MINIATURE_150.Trigger();
				break;
			case 500:
				ESteamAchievement.ASSEMBLE_MINIATURE_500.Trigger();
				break;
			}
			MiniatureData miniatureData = MiniatureDatabase.Get(uid);
			if ((object)miniatureData != null && miniatureData.Type == EMiniatureType.RARE)
			{
				ESteamAchievement.ASSEMBLE_RARE.Trigger();
			}
		}

		private void OnCompletedPainting(float _, float earning)
		{
			float paintingEarnings = PaintingEarnings;
			PaintingEarnings += earning;
			if (paintingEarnings < 1000f && PaintingEarnings >= 1000f)
			{
				ESteamAchievement.PAINT_4_RENT.Trigger();
			}
		}

		private void OnCompletedWargame(float _, float earning)
		{
			WargameEarnings += earning;
		}
	}
}
