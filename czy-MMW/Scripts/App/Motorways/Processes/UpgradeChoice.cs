using System.Collections.Generic;
using Factory;
using Factory.Pools;

namespace Motorways.Processes
{
	[Serializable(1)]
	public class UpgradeChoice : IReusable
	{
		public List<UpgradePackageDefinition> choices = new List<UpgradePackageDefinition>();

		public bool isFree;

		public DisabledUpgradeOptions disabledOptions;

		public void ShuffleChoices(PseudorandomGenerator random)
		{
			for (int num = choices.Count; num > 0; num--)
			{
				int index = random.Int(num);
				UpgradePackageDefinition value = choices[0];
				choices[0] = choices[index];
				choices[index] = value;
			}
		}

		public void Reset()
		{
			disabledOptions = DisabledUpgradeOptions.None;
			isFree = false;
			choices.Clear();
		}
	}
}
