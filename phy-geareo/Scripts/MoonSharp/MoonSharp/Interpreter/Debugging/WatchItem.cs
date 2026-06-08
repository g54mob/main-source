namespace MoonSharp.Interpreter.Debugging
{
	public class WatchItem
	{
		public int Address { get; set; }

		public int BasePtr { get; set; }

		public int RetAddress { get; set; }

		public string Name { get; set; }

		public DynValue Value { get; set; }

		public SymbolRef LValue { get; set; }

		public bool IsError { get; set; }

		public SourceRef Location { get; set; }

		public override string ToString()
		{
			return null;
		}
	}
}
