namespace MoonSharp.Interpreter
{
	public enum InteropAccessMode
	{
		Reflection = 0,
		LazyOptimized = 1,
		Preoptimized = 2,
		BackgroundOptimized = 3,
		HideMembers = 4,
		NoReflectionAllowed = 5,
		Default = 6
	}
}
