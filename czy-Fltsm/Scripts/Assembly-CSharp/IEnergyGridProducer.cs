using System;

public interface IEnergyGridProducer : IEnergyGridComponent, IComparable<IEnergyGridProducer>
{
	float EnergyFillPercentage { get; }

	float Production { get; }

	int Priority { get; }

	bool IsGenerating { get; }

	bool ReturnCanRun();
}
