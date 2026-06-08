using System.Collections.Generic;
using TwitchLib.Client.Enums.Internal;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Internal.Parsing
{
	internal class IrcParser
	{
		private enum ParserState
		{
			STATE_NONE = 0,
			STATE_V3 = 1,
			STATE_PREFIX = 2,
			STATE_COMMAND = 3,
			STATE_PARAM = 4,
			STATE_TRAILING = 5
		}

		public IrcMessage ParseIrcMessage(string raw)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ParserState parserState = ParserState.STATE_NONE;
			int[] array = new int[6];
			int[] array2 = new int[6];
			for (int i = 0; i < raw.Length; i++)
			{
				array2[(int)parserState] = i - array[(int)parserState] - 1;
				if (parserState == ParserState.STATE_NONE && raw[i] == '@')
				{
					parserState = ParserState.STATE_V3;
					i = (array[(int)parserState] = i + 1);
					int num = i;
					string text = null;
					for (; i < raw.Length; i++)
					{
						if (raw[i] == '=')
						{
							text = raw.Substring(num, i - num);
							num = i + 1;
						}
						else if (raw[i] == ';')
						{
							if (text == null)
							{
								dictionary[raw.Substring(num, i - num)] = "1";
							}
							else
							{
								dictionary[text] = raw.Substring(num, i - num);
							}
							num = i + 1;
						}
						else if (raw[i] == ' ')
						{
							if (text == null)
							{
								dictionary[raw.Substring(num, i - num)] = "1";
							}
							else
							{
								dictionary[text] = raw.Substring(num, i - num);
							}
							break;
						}
					}
				}
				else if (parserState < ParserState.STATE_PREFIX && raw[i] == ':')
				{
					parserState = ParserState.STATE_PREFIX;
					i = (array[(int)parserState] = i + 1);
				}
				else if (parserState < ParserState.STATE_COMMAND)
				{
					parserState = ParserState.STATE_COMMAND;
					array[(int)parserState] = i;
				}
				else
				{
					if (parserState < ParserState.STATE_TRAILING && raw[i] == ':')
					{
						parserState = ParserState.STATE_TRAILING;
						i = (array[(int)parserState] = i + 1);
						break;
					}
					if ((parserState < ParserState.STATE_TRAILING && raw[i] == '+') || (parserState < ParserState.STATE_TRAILING && raw[i] == '-'))
					{
						parserState = ParserState.STATE_TRAILING;
						array[(int)parserState] = i;
						break;
					}
					if (parserState == ParserState.STATE_COMMAND)
					{
						parserState = ParserState.STATE_PARAM;
						array[(int)parserState] = i;
					}
				}
				for (; i < raw.Length && raw[i] != ' '; i++)
				{
				}
			}
			array2[(int)parserState] = raw.Length - array[(int)parserState];
			string text2 = raw.Substring(array[3], array2[3]);
			IrcCommand command = IrcCommand.Unknown;
			switch (text2)
			{
			case "PRIVMSG":
				command = IrcCommand.PrivMsg;
				break;
			case "NOTICE":
				command = IrcCommand.Notice;
				break;
			case "PING":
				command = IrcCommand.Ping;
				break;
			case "PONG":
				command = IrcCommand.Pong;
				break;
			case "HOSTTARGET":
				command = IrcCommand.HostTarget;
				break;
			case "CLEARCHAT":
				command = IrcCommand.ClearChat;
				break;
			case "CLEARMSG":
				command = IrcCommand.ClearMsg;
				break;
			case "USERSTATE":
				command = IrcCommand.UserState;
				break;
			case "GLOBALUSERSTATE":
				command = IrcCommand.GlobalUserState;
				break;
			case "NICK":
				command = IrcCommand.Nick;
				break;
			case "JOIN":
				command = IrcCommand.Join;
				break;
			case "PART":
				command = IrcCommand.Part;
				break;
			case "PASS":
				command = IrcCommand.Pass;
				break;
			case "CAP":
				command = IrcCommand.Cap;
				break;
			case "001":
				command = IrcCommand.RPL_001;
				break;
			case "002":
				command = IrcCommand.RPL_002;
				break;
			case "003":
				command = IrcCommand.RPL_003;
				break;
			case "004":
				command = IrcCommand.RPL_004;
				break;
			case "353":
				command = IrcCommand.RPL_353;
				break;
			case "366":
				command = IrcCommand.RPL_366;
				break;
			case "372":
				command = IrcCommand.RPL_372;
				break;
			case "375":
				command = IrcCommand.RPL_375;
				break;
			case "376":
				command = IrcCommand.RPL_376;
				break;
			case "WHISPER":
				command = IrcCommand.Whisper;
				break;
			case "SERVERCHANGE":
				command = IrcCommand.ServerChange;
				break;
			case "RECONNECT":
				command = IrcCommand.Reconnect;
				break;
			case "ROOMSTATE":
				command = IrcCommand.RoomState;
				break;
			case "USERNOTICE":
				command = IrcCommand.UserNotice;
				break;
			case "MODE":
				command = IrcCommand.Mode;
				break;
			}
			string text3 = raw.Substring(array[4], array2[4]);
			string text4 = raw.Substring(array[5], array2[5]);
			string hostmask = raw.Substring(array[2], array2[2]);
			return new IrcMessage(command, new string[2] { text3, text4 }, hostmask, dictionary);
		}
	}
}
