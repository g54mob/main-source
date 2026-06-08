using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitchLib.Client.Internal
{
	public sealed class Rfc2812
	{
		private static readonly Regex NicknameRegex = new Regex("^[A-Za-z\\[\\]\\\\`_^{|}][A-Za-z0-9\\[\\]\\\\`_\\-^{|}]+$", RegexOptions.Compiled);

		private Rfc2812()
		{
		}

		public static bool IsValidNickname(string nickname)
		{
			return !string.IsNullOrEmpty(nickname) && NicknameRegex.Match(nickname).Success;
		}

		public static string Pass(string password)
		{
			return "PASS " + password;
		}

		public static string Nick(string nickname)
		{
			return "NICK " + nickname;
		}

		public static string User(string username, int usermode, string realname)
		{
			return $"USER {username} {usermode} * :{realname}";
		}

		public static string Oper(string name, string password)
		{
			return "OPER " + name + " " + password;
		}

		public static string Privmsg(string destination, string message)
		{
			return "PRIVMSG " + destination + " :" + message;
		}

		public static string Notice(string destination, string message)
		{
			return "NOTICE " + destination + " :" + message;
		}

		public static string Join(string channel)
		{
			return "JOIN " + channel;
		}

		public static string Join(string[] channels)
		{
			return "JOIN " + string.Join(",", channels);
		}

		public static string Join(string channel, string key)
		{
			return "JOIN " + channel + " " + key;
		}

		public static string Join(string[] channels, string[] keys)
		{
			return "JOIN " + string.Join(",", channels) + " " + string.Join(",", keys);
		}

		public static string Part(string channel)
		{
			return "PART " + channel;
		}

		public static string Part(string[] channels)
		{
			return "PART " + string.Join(",", channels);
		}

		public static string Part(string channel, string partmessage)
		{
			return "PART " + channel + " :" + partmessage;
		}

		public static string Part(string[] channels, string partmessage)
		{
			return "PART " + string.Join(",", channels) + " :" + partmessage;
		}

		public static string Kick(string channel, string nickname)
		{
			return "KICK " + channel + " " + nickname;
		}

		public static string Kick(string channel, string nickname, string comment)
		{
			return "KICK " + channel + " " + nickname + " :" + comment;
		}

		public static string Kick(string[] channels, string nickname)
		{
			return "KICK " + string.Join(",", channels) + " " + nickname;
		}

		public static string Kick(string[] channels, string nickname, string comment)
		{
			return "KICK " + string.Join(",", channels) + " " + nickname + " :" + comment;
		}

		public static string Kick(string channel, string[] nicknames)
		{
			return "KICK " + channel + " " + string.Join(",", nicknames);
		}

		public static string Kick(string channel, string[] nicknames, string comment)
		{
			return "KICK " + channel + " " + string.Join(",", nicknames) + " :" + comment;
		}

		public static string Kick(string[] channels, string[] nicknames)
		{
			return "KICK " + string.Join(",", channels) + " " + string.Join(",", nicknames);
		}

		public static string Kick(string[] channels, string[] nicknames, string comment)
		{
			return "KICK " + string.Join(",", channels) + " " + string.Join(",", nicknames) + " :" + comment;
		}

		public static string Motd()
		{
			return "MOTD";
		}

		public static string Motd(string target)
		{
			return "MOTD " + target;
		}

		public static string Lusers()
		{
			return "LUSERS";
		}

		public static string Lusers(string mask)
		{
			return "LUSER " + mask;
		}

		public static string Lusers(string mask, string target)
		{
			return "LUSER " + mask + " " + target;
		}

		public static string Version()
		{
			return "VERSION";
		}

		public static string Version(string target)
		{
			return "VERSION " + target;
		}

		public static string Stats()
		{
			return "STATS";
		}

		public static string Stats(string query)
		{
			return "STATS " + query;
		}

		public static string Stats(string query, string target)
		{
			return "STATS " + query + " " + target;
		}

		public static string Links()
		{
			return "LINKS";
		}

		public static string Links(string servermask)
		{
			return "LINKS " + servermask;
		}

		public static string Links(string remoteserver, string servermask)
		{
			return "LINKS " + remoteserver + " " + servermask;
		}

		public static string Time()
		{
			return "TIME";
		}

		public static string Time(string target)
		{
			return "TIME " + target;
		}

		public static string Connect(string targetserver, string port)
		{
			return "CONNECT " + targetserver + " " + port;
		}

		public static string Connect(string targetserver, string port, string remoteserver)
		{
			return "CONNECT " + targetserver + " " + port + " " + remoteserver;
		}

		public static string Trace()
		{
			return "TRACE";
		}

		public static string Trace(string target)
		{
			return "TRACE " + target;
		}

		public static string Admin()
		{
			return "ADMIN";
		}

		public static string Admin(string target)
		{
			return "ADMIN " + target;
		}

		public static string Info()
		{
			return "INFO";
		}

		public static string Info(string target)
		{
			return "INFO " + target;
		}

		public static string Servlist()
		{
			return "SERVLIST";
		}

		public static string Servlist(string mask)
		{
			return "SERVLIST " + mask;
		}

		public static string Servlist(string mask, string type)
		{
			return "SERVLIST " + mask + " " + type;
		}

		public static string Squery(string servicename, string servicetext)
		{
			return "SQUERY " + servicename + " :" + servicename;
		}

		public static string List()
		{
			return "LIST";
		}

		public static string List(string channel)
		{
			return "LIST " + channel;
		}

		public static string List(string[] channels)
		{
			return "LIST " + string.Join(",", channels);
		}

		public static string List(string channel, string target)
		{
			return "LIST " + channel + " " + target;
		}

		public static string List(string[] channels, string target)
		{
			return "LIST " + string.Join(",", channels) + " " + target;
		}

		public static string Names()
		{
			return "NAMES";
		}

		public static string Names(string channel)
		{
			return "NAMES " + channel;
		}

		public static string Names(string[] channels)
		{
			return "NAMES " + string.Join(",", channels);
		}

		public static string Names(string channel, string target)
		{
			return "NAMES " + channel + " " + target;
		}

		public static string Names(string[] channels, string target)
		{
			return "NAMES " + string.Join(",", channels) + " " + target;
		}

		public static string Topic(string channel)
		{
			return "TOPIC " + channel;
		}

		public static string Topic(string channel, string newtopic)
		{
			return "TOPIC " + channel + " :" + newtopic;
		}

		public static string Mode(string target)
		{
			return "MODE " + target;
		}

		public static string Mode(string target, string newmode)
		{
			return "MODE " + target + " " + newmode + target + " " + newmode;
		}

		public static string Mode(string target, string[] newModes, string[] newModeParameters)
		{
			if (newModes == null)
			{
				throw new ArgumentNullException("newModes");
			}
			if (newModeParameters == null)
			{
				throw new ArgumentNullException("newModeParameters");
			}
			if (newModes.Length != newModeParameters.Length)
			{
				throw new ArgumentException("newModes and newModeParameters must have the same size.");
			}
			StringBuilder stringBuilder = new StringBuilder(newModes.Length);
			StringBuilder stringBuilder2 = new StringBuilder();
			if (newModes.Length > 3)
			{
				throw new ArgumentOutOfRangeException("Length", newModes.Length, $"Mode change list is too large (> {3}).");
			}
			for (int i = 0; i <= newModes.Length; i += 3)
			{
				for (int j = 0; j < 3 && i + j < newModes.Length; j++)
				{
					stringBuilder.Append(newModes[i + j]);
				}
				for (int k = 0; k < 3 && i + k < newModeParameters.Length; k++)
				{
					stringBuilder2.Append(newModeParameters[i + k]);
					stringBuilder2.Append(" ");
				}
			}
			if (stringBuilder2.Length <= 0)
			{
				return Mode(target, stringBuilder.ToString());
			}
			stringBuilder2.Length--;
			stringBuilder.Append(" ");
			stringBuilder.Append(stringBuilder2);
			return Mode(target, stringBuilder.ToString());
		}

		public static string Service(string nickname, string distribution, string info)
		{
			return "SERVICE " + nickname + " * " + distribution + " * * :" + info;
		}

		public static string Invite(string nickname, string channel)
		{
			return "INVITE " + nickname + " " + channel;
		}

		public static string Who()
		{
			return "WHO";
		}

		public static string Who(string mask)
		{
			return "WHO " + mask;
		}

		public static string Who(string mask, bool ircop)
		{
			return ircop ? ("WHO " + mask + " o") : ("WHO " + mask);
		}

		public static string Whois(string mask)
		{
			return "WHOIS " + mask;
		}

		public static string Whois(string[] masks)
		{
			return "WHOIS " + string.Join(",", masks);
		}

		public static string Whois(string target, string mask)
		{
			return "WHOIS " + target + " " + mask;
		}

		public static string Whois(string target, string[] masks)
		{
			return "WHOIS " + target + " " + string.Join(",", masks);
		}

		public static string Whowas(string nickname)
		{
			return "WHOWAS " + nickname;
		}

		public static string Whowas(string[] nicknames)
		{
			return "WHOWAS " + string.Join(",", nicknames);
		}

		public static string Whowas(string nickname, string count)
		{
			return "WHOWAS " + nickname + " " + count + " ";
		}

		public static string Whowas(string[] nicknames, string count)
		{
			return "WHOWAS " + string.Join(",", nicknames) + " " + count + " ";
		}

		public static string Whowas(string nickname, string count, string target)
		{
			return "WHOWAS " + nickname + " " + count + " " + target;
		}

		public static string Whowas(string[] nicknames, string count, string target)
		{
			return "WHOWAS " + string.Join(",", nicknames) + " " + count + " " + target;
		}

		public static string Kill(string nickname, string comment)
		{
			return "KILL " + nickname + " :" + comment;
		}

		public static string Ping(string server)
		{
			return "PING " + server;
		}

		public static string Ping(string server, string server2)
		{
			return "PING " + server + " " + server2;
		}

		public static string Pong(string server)
		{
			return "PONG " + server;
		}

		public static string Pong(string server, string server2)
		{
			return "PONG " + server + " " + server2;
		}

		public static string Error(string errormessage)
		{
			return "ERROR :" + errormessage;
		}

		public static string Away()
		{
			return "AWAY";
		}

		public static string Away(string awaytext)
		{
			return "AWAY :" + awaytext;
		}

		public static string Rehash()
		{
			return "REHASH";
		}

		public static string Die()
		{
			return "DIE";
		}

		public static string Restart()
		{
			return "RESTART";
		}

		public static string Summon(string user)
		{
			return "SUMMON " + user;
		}

		public static string Summon(string user, string target)
		{
			return "SUMMON " + user + " " + target + user + " " + target;
		}

		public static string Summon(string user, string target, string channel)
		{
			return "SUMMON " + user + " " + target + " " + channel;
		}

		public static string Users()
		{
			return "USERS";
		}

		public static string Users(string target)
		{
			return "USERS " + target;
		}

		public static string Wallops(string wallopstext)
		{
			return "WALLOPS :" + wallopstext;
		}

		public static string Userhost(string nickname)
		{
			return "USERHOST " + nickname;
		}

		public static string Userhost(string[] nicknames)
		{
			return "USERHOST " + string.Join(" ", nicknames);
		}

		public static string Ison(string nickname)
		{
			return "ISON " + nickname;
		}

		public static string Ison(string[] nicknames)
		{
			return "ISON " + string.Join(" ", nicknames);
		}

		public static string Quit()
		{
			return "QUIT";
		}

		public static string Quit(string quitmessage)
		{
			return "QUIT :" + quitmessage;
		}

		public static string Squit(string server, string comment)
		{
			return "SQUIT " + server + " :" + comment;
		}
	}
}
