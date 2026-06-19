using System.Text;

namespace SickDev.CommandSystem
{
	public class AmbiguousCommandCallException : CommandSystemException
	{
		private string rawCall;

		private CommandBase[] matches;

		public override string Message
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(matches[0].name);
				for (int i = 1; i < matches.Length; i++)
				{
					stringBuilder.Append("\n" + matches[i].name);
				}
				return "The command call \"" + rawCall + "\" is ambiguous between the following commands:\n" + stringBuilder.ToString();
			}
		}

		public AmbiguousCommandCallException(string rawCall, CommandBase[] matches)
		{
			this.rawCall = rawCall;
			this.matches = matches;
		}
	}
}
