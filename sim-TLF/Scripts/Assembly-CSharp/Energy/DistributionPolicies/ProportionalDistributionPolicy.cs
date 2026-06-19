using System.Collections.Generic;

namespace Energy.DistributionPolicies
{
	public class ProportionalDistributionPolicy : IEnergyDistributionPolicy
	{
		public void Distribute(IEnergySource source, IReadOnlyList<IEnergyConsumer> consumers, float dt)
		{
			float num = 0f;
			foreach (IEnergyConsumer consumer in consumers)
			{
				if (consumer.IsActive)
				{
					num += consumer.RequestedEnergy;
				}
			}
			float maxOutput = source.MaxOutput;
			foreach (IEnergyConsumer consumer2 in consumers)
			{
				if (consumer2.IsActive)
				{
					float num2 = ((num <= maxOutput) ? 1f : (consumer2.RequestedEnergy / num));
					float num3 = consumer2.RequestedEnergy * num2;
					float num4 = source.ExtractEnergy(num3 * dt);
					consumer2.SupplyEnergy(num4 / dt);
				}
			}
		}
	}
}
