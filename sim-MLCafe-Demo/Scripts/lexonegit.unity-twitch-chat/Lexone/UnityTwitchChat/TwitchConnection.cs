using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Lexone.UnityTwitchChat
{
	internal class TwitchConnection
	{
		private IRCTags _clientUserTags;

		private int _threadsRunning = 1;

		public bool disconnectCalled;

		private readonly string oauth;

		private readonly string nick;

		private readonly string channel;

		private readonly int readBufferSize;

		private readonly int readInterval;

		private readonly int writeInterval;

		private readonly bool showIRCDebug;

		private readonly bool showThreadDebug;

		private readonly bool useRandomColorForUndefined;

		private readonly ConcurrentQueue<IRCReply> alertQueue;

		private readonly ConcurrentQueue<Chatter> chatterQueue;

		private Thread readThread;

		private Thread writeThread;

		private RateLimit rateLimit = RateLimit.ChatRegular;

		private object rateLimitLock = new object();

		private int sessionRandom = DateTime.Now.Second;

		private ConcurrentQueue<string> priorityWriteQueue = new ConcurrentQueue<string>();

		private ConcurrentQueue<string> writeQueue = new ConcurrentQueue<string>();

		private ConcurrentQueue<DateTime> writeTimestamps = new ConcurrentQueue<DateTime>();

		public TcpClient tcpClient { get; private set; }

		public IRCTags ClientUserTags
		{
			get
			{
				return _clientUserTags;
			}
			set
			{
				Interlocked.Exchange(ref _clientUserTags, value);
			}
		}

		private bool ThreadsRunning
		{
			get
			{
				return _threadsRunning == 1;
			}
			set
			{
				Interlocked.Exchange(ref _threadsRunning, value ? 1 : 0);
			}
		}

		public TwitchConnection(IRC irc)
		{
			try
			{
				tcpClient = new TcpClient(irc.address, irc.port);
			}
			catch
			{
				tcpClient = null;
			}
			oauth = irc.oauth;
			nick = irc.username;
			channel = irc.channel;
			readBufferSize = (int)irc.readBufferSize;
			readInterval = irc.readInterval;
			writeInterval = irc.writeInterval;
			alertQueue = irc.alertQueue;
			chatterQueue = irc.chatterQueue;
			rateLimit = RateLimit.ChatRegular;
			showIRCDebug = irc.showIRCDebug;
			showThreadDebug = irc.showThreadDebug;
			useRandomColorForUndefined = irc.useRandomColorForUndefined;
		}

		public void Begin()
		{
			readThread = new Thread((ThreadStart)delegate
			{
				ReadThreadLoop();
			});
			writeThread = new Thread((ThreadStart)delegate
			{
				WriteThreadLoop();
			});
			readThread.Start();
			writeThread.Start();
			SendCommand("PASS oauth:" + oauth.ToLower(), priority: true);
			SendCommand("NICK " + nick.ToLower(), priority: true);
			SendCommand("CAP REQ :twitch.tv/tags twitch.tv/commands", priority: true);
		}

		public IEnumerator End()
		{
			if (tcpClient != null && !disconnectCalled)
			{
				disconnectCalled = true;
				ThreadsRunning = false;
				while (readThread.IsAlive)
				{
					yield return null;
				}
				while (writeThread.IsAlive)
				{
					yield return null;
				}
				tcpClient.Close();
			}
		}

		public void BlockingEnd()
		{
			if (tcpClient != null)
			{
				disconnectCalled = true;
				ThreadsRunning = false;
				readThread?.Join();
				writeThread?.Join();
				tcpClient.Close();
			}
		}

		private void UpdateRateLimits()
		{
			if (ClientUserTags.HasBadge("broadcaster") || ClientUserTags.HasBadge("moderator"))
			{
				lock (rateLimitLock)
				{
					rateLimit = RateLimit.ChatModerator;
					return;
				}
			}
			lock (rateLimitLock)
			{
				rateLimit = RateLimit.ChatRegular;
			}
		}

		private void ReadThreadLoop()
		{
			if (showThreadDebug)
			{
				Debug.Log(Tags.thread + " Read thread started");
			}
			using (NetworkStream networkStream = tcpClient.GetStream())
			{
				byte[] array = new byte[readBufferSize];
				StringBuilder stringBuilder = new StringBuilder();
				Decoder decoder = Encoding.UTF8.GetDecoder();
				char[] array2 = new char[readBufferSize + Mathf.Clamp(readBufferSize / 4, 1, 32)];
				while (ThreadsRunning)
				{
					if (!CheckConnection(tcpClient.Client))
					{
						alertQueue.Enqueue(IRCReply.CONNECTION_INTERRUPTED);
						return;
					}
					while (networkStream.DataAvailable)
					{
						int byteCount = networkStream.Read(array, 0, readBufferSize);
						int chars = decoder.GetChars(array, 0, byteCount, array2, 0);
						for (int i = 0; i < chars; i++)
						{
							if (array2[i] == '\n' || array2[i] == '\r')
							{
								if (stringBuilder.Length > 0)
								{
									HandleRawLine(stringBuilder.ToString());
									stringBuilder.Clear();
								}
							}
							else
							{
								stringBuilder.Append(array2[i]);
							}
						}
					}
					Thread.Sleep(readInterval);
				}
			}
			if (showThreadDebug)
			{
				Debug.Log(Tags.thread + " Read thread stopped");
			}
		}

		private bool CheckConnection(Socket socket)
		{
			bool num = socket.Poll(1000, SelectMode.SelectRead);
			bool flag = socket.Available == 0;
			if ((num && flag) || !socket.Connected)
			{
				return false;
			}
			return true;
		}

		private void HandleRawLine(string raw)
		{
			if (showIRCDebug)
			{
				Debug.Log(Tags.read + " " + raw);
			}
			string text = raw;
			string tagString = string.Empty;
			if (raw[0] == '@')
			{
				int num = raw.IndexOf(' ');
				tagString = raw.Substring(0, num);
				text = raw.Substring(num).TrimStart();
			}
			if (text[0] == ':')
			{
				string text2 = text.Substring(text.IndexOf(' ')).TrimStart();
				text2 = text2.Substring(0, text2.IndexOf(' '));
				switch (text2)
				{
				case "PRIVMSG":
					HandlePRIVMSG(text, tagString);
					break;
				case "USERSTATE":
					HandleUSERSTATE(text, tagString);
					break;
				case "NOTICE":
					HandleNOTICE(text, tagString);
					break;
				case "353":
				case "001":
					HandleRPL(text2);
					break;
				}
			}
			if (raw.StartsWith("PING"))
			{
				Pong();
			}
			if (raw.StartsWith(":tmi.twitch.tv PONG"))
			{
				alertQueue.Enqueue(IRCReply.PONG_RECEIVED);
			}
		}

		private void HandlePRIVMSG(string ircString, string tagString)
		{
			string login = ParseHelper.ParseLoginName(ircString);
			string text = ParseHelper.ParseChannel(ircString);
			string message = ParseHelper.ParseMessage(ircString);
			IRCTags iRCTags = ParseHelper.ParseTags(tagString);
			if (iRCTags.colorHex.Length <= 0)
			{
				iRCTags.colorHex = (useRandomColorForUndefined ? ChatColors.GetRandomNameColor(sessionRandom, login) : "#FFFFFF");
			}
			if (iRCTags.emotes.Length != 0)
			{
				Array.Sort(iRCTags.emotes, (ChatterEmote a, ChatterEmote b) => a.indexes[0].startIndex.CompareTo(b.indexes[0].startIndex));
			}
			chatterQueue.Enqueue(new Chatter(login, text, message, iRCTags));
		}

		private void HandleUSERSTATE(string ircString, string tagString)
		{
			IRCTags clientUserTags = ParseHelper.ParseTags(tagString);
			ClientUserTags = clientUserTags;
			UpdateRateLimits();
		}

		private void HandleNOTICE(string ircString, string tagString)
		{
			if (ircString.Contains(":Login authentication failed"))
			{
				alertQueue.Enqueue(IRCReply.BAD_LOGIN);
			}
		}

		private void HandleRPL(string type)
		{
			if (!(type == "001"))
			{
				if (type == "353")
				{
					alertQueue.Enqueue(IRCReply.JOINED_CHANNEL);
				}
			}
			else
			{
				alertQueue.Enqueue(IRCReply.CONNECTED_TO_SERVER);
				SendCommand("JOIN #" + channel.ToLower(), priority: true);
			}
		}

		private void WriteThreadLoop()
		{
			if (showThreadDebug)
			{
				Debug.Log(Tags.thread + " Write thread started");
			}
			NetworkStream stream = tcpClient.GetStream();
			while (ThreadsRunning)
			{
				while (!priorityWriteQueue.IsEmpty)
				{
					if (priorityWriteQueue.TryDequeue(out var result))
					{
						stream.WriteLine(result, showIRCDebug);
					}
				}
				lock (rateLimitLock)
				{
					_ = rateLimit;
				}
				DateTime dateTime = DateTime.Now - rateLimit.timeSpan;
				DateTime result2;
				while (writeTimestamps.TryPeek(out result2) && result2 < dateTime)
				{
					writeTimestamps.TryDequeue(out var _);
				}
				while (!writeQueue.IsEmpty && writeTimestamps.Count < rateLimit.count)
				{
					if (writeQueue.TryDequeue(out var result4))
					{
						stream.WriteLine(result4, showIRCDebug);
						writeTimestamps.Enqueue(DateTime.Now);
					}
				}
				Thread.Sleep(writeInterval);
			}
			if (showThreadDebug)
			{
				Debug.Log(Tags.thread + " Write thread stopped");
			}
		}

		public void Ping()
		{
			SendCommand("PING :tmi.twitch.tv", priority: true);
		}

		public void Pong()
		{
			SendCommand("PONG :tmi.twitch.tv", priority: true);
		}

		public void SendCommand(string command, bool priority = false)
		{
			if (priority)
			{
				priorityWriteQueue.Enqueue(command);
			}
			else
			{
				writeQueue.Enqueue(command);
			}
		}

		public void SendChatMessage(string message)
		{
			if (message.Length <= 0)
			{
				Debug.LogWarning(Tags.write + " Tried sending an empty chat message");
			}
			else
			{
				SendCommand("PRIVMSG #" + channel + " :" + message);
			}
		}
	}
}
