public interface IIAP
{
	bool IsInited();

	void Init(InAppPurchaseProxy proxy);

	void Buy(string sku);

	void Restore();

	string GetPriceString(string sku);
}
