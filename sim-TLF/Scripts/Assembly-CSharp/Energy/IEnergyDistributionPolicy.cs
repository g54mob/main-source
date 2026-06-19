using System.Collections.Generic;

namespace Energy
{
	public interface IEnergyDistributionPolicy
	{
		void Distribute(IEnergySource source, IReadOnlyList<IEnergyConsumer> consumers, float deltaTime);
	}
}
