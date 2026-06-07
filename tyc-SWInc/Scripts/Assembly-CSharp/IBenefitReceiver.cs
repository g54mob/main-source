using System.Collections.Generic;

public interface IBenefitReceiver
{
	Dictionary<string, float> GetBenefits();

	float GetBenefitValue(string benefit, bool ignoreSelf = false);

	void CacheBenefits();

	void ApplyNewBenefits();
}
