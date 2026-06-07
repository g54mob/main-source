using System.Collections.Generic;

namespace GameCreator.Runtime.Console
{
	internal static class Commands
	{
		private const string ERR_NOT_FOUND = "Unable to find command '{0}'";

		public static IEnumerable<Output> Run(Input input)
		{
			if (!Database.Get.TryGetValue(input.Command, out var value))
			{
				return new Output[1] { Output.Error($"Unable to find command '{input.Command}'", showHelp: true) };
			}
			return value.Run(input);
		}
	}
}
