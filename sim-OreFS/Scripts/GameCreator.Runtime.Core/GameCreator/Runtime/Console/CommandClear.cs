using System;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandClear : Command
	{
		public override string Name => "clear";

		public override string Description => "Clears the Console";

		public override bool IsHidden => true;

		public override Output[] Run(Input input)
		{
			Console.Clear();
			return Array.Empty<Output>();
		}
	}
}
