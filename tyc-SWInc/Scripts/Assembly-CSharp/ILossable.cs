public interface ILossable : IReferenceFix
{
	void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false);

	void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false);

	float GetLicenseAmount();
}
