namespace CTS
{
	public class StockMissionGoal : QuestGoal
	{
		private readonly StockMissionData _stockMissionData;

		private readonly MissionBasket _basket;

		public StockMissionGoal(Quest quest, int entryID, StockMissionData stockMissionData, MissionBasket basket)
			: base(quest, entryID)
		{
			_stockMissionData = stockMissionData;
			_basket = basket;
		}

		public override void StopObserving()
		{
			_basket.EndCurrentMission();
			MissionBasket.MissionEnded -= OnMissionEnded;
		}

		public override void StartObserving()
		{
			_basket.SetMission(_stockMissionData);
			MissionBasket.MissionEnded += OnMissionEnded;
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult result)
		{
			if (!(basket != _basket))
			{
				AchieveGoal();
			}
		}
	}
}
