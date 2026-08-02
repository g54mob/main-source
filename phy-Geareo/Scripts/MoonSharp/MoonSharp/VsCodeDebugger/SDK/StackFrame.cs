namespace MoonSharp.VsCodeDebugger.SDK
{
	public class StackFrame
	{
		public int id { get; private set; }

		public Source source { get; private set; }

		public int line { get; private set; }

		public int column { get; private set; }

		public string name { get; private set; }

		public int? endLine { get; private set; }

		public int? endColumn { get; private set; }

		public StackFrame(int id, string name, Source source, int line, int column = 0, int? endLine = null, int? endColumn = null)
		{
		}
	}
}
