namespace NSMedieval.GameEventSystem
{
	public interface IEnemyPurchaseUnit
	{
		bool IsTrader();

		int GetPrice();

		float GetPriceThreshold();

		string GetID();
	}
}
