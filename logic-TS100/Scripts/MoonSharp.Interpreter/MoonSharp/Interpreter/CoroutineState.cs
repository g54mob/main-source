namespace MoonSharp.Interpreter
{
	public enum CoroutineState
	{
		Main = 0,
		NotStarted = 1,
		Suspended = 2,
		Running = 3,
		Dead = 4
	}
}
