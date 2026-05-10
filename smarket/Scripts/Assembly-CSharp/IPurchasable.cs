public interface IPurchasable
{
	void Purchase(IPurchaser purchaser);

	bool CanBePurchased(IPurchaser purchaser);

	float GetCost();
}
