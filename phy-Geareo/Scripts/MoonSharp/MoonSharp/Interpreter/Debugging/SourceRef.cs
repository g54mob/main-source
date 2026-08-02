namespace MoonSharp.Interpreter.Debugging
{
	public class SourceRef
	{
		public bool Breakpoint;

		public bool IsClrLocation { get; private set; }

		public int SourceIdx { get; private set; }

		public int FromChar { get; private set; }

		public int ToChar { get; private set; }

		public int FromLine { get; private set; }

		public int ToLine { get; private set; }

		public bool IsStepStop { get; private set; }

		public bool CannotBreakpoint { get; private set; }

		internal static SourceRef GetClrLocation()
		{
			return null;
		}

		public SourceRef(SourceRef src, bool isStepStop)
		{
		}

		public SourceRef(int sourceIdx, int from, int to, int fromline, int toline, bool isStepStop)
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal int GetLocationDistance(int sourceIdx, int line, int col)
		{
			return 0;
		}

		public bool IncludesLocation(int sourceIdx, int line, int col)
		{
			return false;
		}

		public SourceRef SetNoBreakPoint()
		{
			return null;
		}

		public string FormatLocation(Script script, bool forceClassicFormat = false)
		{
			return null;
		}
	}
}
