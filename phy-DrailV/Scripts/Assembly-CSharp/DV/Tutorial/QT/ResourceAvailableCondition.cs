using DV.Simulation.Cars;
using LocoSim.Implementations;
using LocoSim.Resources;

namespace DV.Tutorial.QT
{
	public class ResourceAvailableCondition : AQuickTutorialCondition
	{
		private ResourceContainerController rcc;

		private (ResourceContainerType type, float targetAmountNormalized)[] requirements;

		private string message;

		public ResourceAvailableCondition(ResourceContainerController rcc, (ResourceContainerType type, float targetAmountNormalized)[] requirements, string message)
		{
			this.rcc = rcc;
			this.requirements = requirements;
			this.message = (string.IsNullOrEmpty(message) ? "ResourceAvailableCondition not fulfilled" : message);
		}

		public override string Check()
		{
			(ResourceContainerType, float)[] array = requirements;
			for (int i = 0; i < array.Length; i++)
			{
				(ResourceContainerType, float) tuple = array[i];
				ResourceContainer resourceContainer = rcc.GetResourceContainer(tuple.Item1);
				if (resourceContainer != null && !(resourceContainer.normalizedReadOutPort.Value > tuple.Item2))
				{
					return message;
				}
			}
			return string.Empty;
		}
	}
}
