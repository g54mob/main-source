namespace MoonSharp.VsCodeDebugger.SDK
{
	public class Variable
	{
		public string name { get; private set; }

		public string value { get; private set; }

		public int variablesReference { get; private set; }

		public Variable(string name, string value, int variablesReference = 0)
		{
		}
	}
}
