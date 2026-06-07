using System.Collections.Generic;

namespace Simulator.GameWorld
{
	public class GameScoreTracker
	{
		public int Sales { get; private set; }

		public int TrashThrown { get; private set; }

		public GameScoreTracker()
		{
			Register();
			Load();
		}

		protected virtual void Load()
		{
			SaveClass_GameScore gameScore = SaveManager.CurrentSave.gameScore;
			Sales = gameScore.sales;
			TrashThrown = gameScore.trashThrown;
		}

		public virtual void Save()
		{
			SaveClass_GameScore gameScore = SaveManager.CurrentSave.gameScore;
			gameScore.sales = Sales;
			gameScore.trashThrown = TrashThrown;
		}

		protected virtual void Register()
		{
			CashRegisterWorkshop.ClientCheckedOut += OnClientCheckedOut;
			Bin.TrashThrown += OnTrashThrown;
		}

		public virtual void Unregister()
		{
			CashRegisterWorkshop.ClientCheckedOut -= OnClientCheckedOut;
			Bin.TrashThrown -= OnTrashThrown;
		}

		protected virtual void OnClientCheckedOut(List<Product> products, float totalCost)
		{
			Sales++;
			switch (Sales)
			{
			case 1:
				ESteamAchievement.FIRST_SALE.Trigger();
				break;
			case 50:
				ESteamAchievement.SOLD_50.Trigger();
				break;
			case 150:
				ESteamAchievement.SOLD_150.Trigger();
				break;
			case 500:
				ESteamAchievement.SOLD_500.Trigger();
				break;
			}
		}

		protected virtual void OnTrashThrown()
		{
			TrashThrown++;
			if (TrashThrown == 100)
			{
				ESteamAchievement.DUST_TO_DUST.Trigger();
			}
		}
	}
}
