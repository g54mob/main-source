using System.Diagnostics;

namespace NSubstitute.Core
{
	[DebuggerDisplay("{_name}")]
	public class MatchArgs
	{
		private readonly string _name;

		public static readonly MatchArgs AsSpecifiedInCall = new MatchArgs("AsSpecifiedInCall");

		public static readonly MatchArgs Any = new MatchArgs("Any");

		private MatchArgs(string name)
		{
			_name = name;
		}
	}
}
