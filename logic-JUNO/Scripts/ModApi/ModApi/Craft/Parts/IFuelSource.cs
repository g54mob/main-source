using ModApi.Craft.Propulsion;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IFuelSource
	{
		FuelTransferMode FuelTransferMode { get; set; }

		FuelType FuelType { get; }

		bool IsDestroyed { get; }

		bool IsEmpty { get; }

		Vector3 Position { get; }

		int Priority { get; }

		int SubPriority { get; }

		bool SupportsFuelTransfer { get; }

		double TotalCapacity { get; }

		double TotalFuel { get; }

		double AddFuel(double amount);

		double RemoveFuel(double amount);
	}
}
