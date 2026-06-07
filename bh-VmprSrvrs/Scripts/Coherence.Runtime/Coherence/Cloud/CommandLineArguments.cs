using System.Collections.Generic;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class CommandLineArguments
	{
		private readonly Logger logger;

		public Dictionary<string, string> Args { get; private set; }

		public ushort GamePort { get; private set; }

		public ushort ApiPort { get; private set; }

		public string AuthToken { get; private set; }

		public string PlayApiEndpoint { get; private set; }

		public string Region { get; private set; }

		public string StateFile { get; private set; }

		public string Id { get; private set; }

		public string Tag { get; private set; }

		public Dictionary<string, string> KV { get; private set; }

		public CommandLineArguments(string[] args = null)
		{
		}

		private static Dictionary<string, string> GetArgumentsDictionary(IReadOnlyList<string> args)
		{
			return null;
		}
	}
}
