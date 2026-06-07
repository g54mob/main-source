using System;

namespace LibNoise.Modifiers
{
	public class BiasOutput : IModule
	{
		public IModule SourceModule { get; set; }

		public double Bias { get; set; }

		public BiasOutput(IModule sourceModule, double bias)
		{
			if (sourceModule == null)
			{
				throw new ArgumentNullException("A source module must be provided.");
			}
			SourceModule = sourceModule;
			Bias = bias;
		}

		public double GetValue(double x, double y, double z)
		{
			if (SourceModule == null)
			{
				throw new NullReferenceException("A source module must be provided.");
			}
			return SourceModule.GetValue(x, y, z) + Bias;
		}
	}
}
