using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Lexone.UnityTwitchChat
{
	public static class Extensions
	{
		public static void WriteLine(this NetworkStream stream, string output, bool showDebug = false)
		{
			if (showDebug)
			{
				Debug.Log(Tags.write + " " + output);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(output);
			stream.Write(bytes, 0, bytes.Length);
			stream.WriteByte(13);
			stream.WriteByte(10);
			stream.Flush();
		}

		public static string GetDescription(this IRCReply alert)
		{
			return alert switch
			{
				IRCReply.CONNECTED_TO_SERVER => "Connected", 
				IRCReply.PONG_RECEIVED => "Pong!", 
				IRCReply.JOINED_CHANNEL => "Joined channel", 
				IRCReply.MISSING_LOGIN_INFO => "Missing login information", 
				IRCReply.BAD_LOGIN => "Login failed", 
				IRCReply.CONNECTION_INTERRUPTED => "Connection interrupted", 
				IRCReply.NO_CONNECTION => "Connection failed", 
				_ => "Unknown alert", 
			};
		}
	}
}
