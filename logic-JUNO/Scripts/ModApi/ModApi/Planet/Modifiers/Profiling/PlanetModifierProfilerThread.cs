using System.Diagnostics;

namespace ModApi.Planet.Modifiers.Profiling
{
	public class PlanetModifierProfilerThread
	{
		public ModifierProfilerData CurrentModifier;

		public Stopwatch Stopwatch;

		public PlanetModifierProfilerThread()
		{
			Stopwatch = new Stopwatch();
		}
	}
}
