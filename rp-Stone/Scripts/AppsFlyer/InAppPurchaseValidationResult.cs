using System;

[Serializable]
internal class InAppPurchaseValidationResult : EventArgs
{
	public bool success;

	public ProductPurchase? productPurchase;

	public ValidationFailureData? failureData;

	public string token;
}
