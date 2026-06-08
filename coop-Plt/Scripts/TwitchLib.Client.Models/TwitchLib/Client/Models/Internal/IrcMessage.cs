using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Enums.Internal;

namespace TwitchLib.Client.Models.Internal
{
	public class IrcMessage
	{
		private readonly string[] _parameters;

		public readonly string User;

		public readonly string Hostmask;

		public readonly IrcCommand Command;

		public readonly Dictionary<string, string> Tags;

		public string Channel => Params.StartsWith("#") ? Params.Remove(0, 1) : Params;

		public string Params => (_parameters != null && _parameters.Length != 0) ? _parameters[0] : "";

		public string Message => Trailing;

		public string Trailing => (_parameters != null && _parameters.Length > 1) ? _parameters[_parameters.Length - 1] : "";

		public IrcMessage(string user)
		{
			_parameters = null;
			User = user;
			Hostmask = null;
			Command = IrcCommand.Unknown;
			Tags = null;
		}

		public IrcMessage(IrcCommand command, string[] parameters, string hostmask, Dictionary<string, string> tags = null)
		{
			int num = hostmask.IndexOf('!');
			User = ((num != -1) ? hostmask.Substring(0, num) : hostmask);
			Hostmask = hostmask;
			_parameters = parameters;
			Command = command;
			Tags = tags;
		}

		public new string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			if (Tags != null)
			{
				string[] array = new string[Tags.Count];
				int num = 0;
				foreach (KeyValuePair<string, string> tag in Tags)
				{
					array[num] = tag.Key + "=" + tag.Value;
					num++;
				}
				if (array.Length != 0)
				{
					stringBuilder.Append("@").Append(string.Join(";", array)).Append(" ");
				}
			}
			if (!string.IsNullOrEmpty(Hostmask))
			{
				stringBuilder.Append(":").Append(Hostmask).Append(" ");
			}
			stringBuilder.Append(Command.ToString().ToUpper().Replace("RPL_", ""));
			if (_parameters.Length == 0)
			{
				return stringBuilder.ToString();
			}
			if (_parameters[0] != null && _parameters[0].Length > 0)
			{
				stringBuilder.Append(" ").Append(_parameters[0]);
			}
			if (_parameters.Length > 1 && _parameters[1] != null && _parameters[1].Length > 0)
			{
				stringBuilder.Append(" :").Append(_parameters[1]);
			}
			return stringBuilder.ToString();
		}
	}
}
