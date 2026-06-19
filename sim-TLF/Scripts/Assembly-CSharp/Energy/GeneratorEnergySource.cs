using ComplexItems.Generator;
using UnityEngine;

namespace Energy
{
	public class GeneratorEnergySource : IEnergySource
	{
		private readonly GeneratorObject _generator;

		public float MaxOutput
		{
			get
			{
				if (!_generator.IsOn || !_generator.IsWorking)
				{
					return 0f;
				}
				return _generator.CurrentPower * 10f;
			}
		}

		public float AvailableEnergy => MaxOutput;

		public GeneratorEnergySource(GeneratorObject generator)
		{
			_generator = generator;
		}

		public float ExtractEnergy(float amount)
		{
			float num = Mathf.Min(amount, AvailableEnergy);
			float amount2 = num * 0.1f;
			if (_generator.TryConsumeFuel(amount2))
			{
				return num;
			}
			return 0f;
		}
	}
}
