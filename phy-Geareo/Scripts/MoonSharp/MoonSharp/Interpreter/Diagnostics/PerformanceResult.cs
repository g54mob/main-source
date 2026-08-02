namespace MoonSharp.Interpreter.Diagnostics
{
	public class PerformanceResult
	{
		public string Name { get; internal set; }

		public long Counter { get; internal set; }

		public int Instances { get; internal set; }

		public bool Global { get; internal set; }

		public PerformanceCounterType Type { get; internal set; }

		public override string ToString()
		{
			return null;
		}

		public static string PerformanceCounterTypeToString(PerformanceCounterType Type)
		{
			return null;
		}
	}
}
