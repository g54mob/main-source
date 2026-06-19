using System;

namespace Water2D
{
	[Serializable]
	public class ModernWater2DSettings
	{
		public ObstructorSettings _obstructorSettings;

		public ReflectionsSettings _reflectionsSettings;

		public WaterSettings _waterSettings;

		public SimulationSettings _simulationSettings;

		public WaveSimulationSettings _wavesSettings;

		public BlurSettings _blurSettings;
	}
}
