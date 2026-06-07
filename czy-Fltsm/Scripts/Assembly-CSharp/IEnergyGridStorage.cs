using System;
using UnityEngine.Events;

public interface IEnergyGridStorage : IEnergyGridComponent, IComparable<IEnergyGridStorage>
{
	UnityEvent OnEnergyUpdateEvent { get; }

	bool IsEmpty { get; }

	bool IsFull { get; }

	float EnergyAmount { get; }

	float NormalizedEnergyAmount { get; }

	float EnergyCapacity { get; }

	void SetEnergyAmount(float amount);

	bool TryRequestEnergy(float energyAmount, out float returnedAmount);

	bool TryAddEnergy(float energyAmount, out float addedAmount);
}
