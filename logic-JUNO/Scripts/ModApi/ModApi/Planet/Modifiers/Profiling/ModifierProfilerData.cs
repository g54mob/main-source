namespace ModApi.Planet.Modifiers.Profiling
{
	public class ModifierProfilerData
	{
		public readonly ModifierProfilerKey Key;

		public long ExecutionCount;

		public double ExecutionTime;

		public ModifierProfilerData(ModifierProfilerKey key)
		{
			Key = key;
		}
	}
}
