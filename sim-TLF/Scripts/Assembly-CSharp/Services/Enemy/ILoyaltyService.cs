using System;

namespace Services.Enemy
{
	public interface ILoyaltyService
	{
		float StressAmmount { get; }

		event Action<float> StressValueChanged;

		void AddStressValue(float value);

		void RemoveStressValue(float value);

		void SetStressValue(float value);
	}
}
