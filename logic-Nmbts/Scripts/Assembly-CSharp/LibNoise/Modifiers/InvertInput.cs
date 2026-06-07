using System;

namespace LibNoise.Modifiers
{
	public class InvertInput : IModule
	{
		public IModule SourceModule { get; set; }

		public InvertInput(IModule sourceModule)
		{
			if (sourceModule == null)
			{
				throw new ArgumentNullException("A source module must be provided.");
			}
			SourceModule = sourceModule;
		}

		public double GetValue(double x, double y, double z)
		{
			if (SourceModule == null)
			{
				throw new NullReferenceException("A source module must be provided.");
			}
			return SourceModule.GetValue(0.0 - x, 0.0 - y, 0.0 - z);
		}
	}
}
