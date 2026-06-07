using Unity.Profiling;

public static class ProfilerUtility
{
	public static readonly ProfilerCategory CategoryProcess = new ProfilerCategory("Simulation.Processes");

	public static readonly ProfilerCategory CategoryModel = new ProfilerCategory("Simulation.Model");
}
