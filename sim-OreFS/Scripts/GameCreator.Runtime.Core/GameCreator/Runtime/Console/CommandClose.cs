using System;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandClose : Command
	{
		public override string Name => "close";

		public override string Description => "Closes the Console";

		public override bool IsHidden => true;

		public override Output[] Run(Input input)
		{
			Console.Close();
			return Array.Empty<Output>();
		}
	}
}
