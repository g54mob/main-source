#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Timers;
using Microsoft.Extensions.Logging;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Enums.Internal;
using TwitchLib.Client.Events;
using TwitchLib.Client.Exceptions;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Internal;
using TwitchLib.Client.Internal.Parsing;
using TwitchLib.Client.Manager;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Internal;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Interfaces;

namespace TwitchLib.Client
{
	public class TwitchClient : ITwitchClient
	{
		private IClient _client;

		private MessageEmoteCollection _channelEmotes = new MessageEmoteCollection();

		private readonly ICollection<char> _chatCommandIdentifiers = new HashSet<char>();

		private readonly ICollection<char> _whisperCommandIdentifiers = new HashSet<char>();

		private readonly Queue<JoinedChannel> _joinChannelQueue = new Queue<JoinedChannel>();

		private readonly ILogger<TwitchClient> _logger;

		private readonly ClientProtocol _protocol;

		private bool _currentlyJoiningChannels;

		private Timer _joinTimer;

		private List<KeyValuePair<string, DateTime>> _awaitingJoins;

		private readonly IrcParser _ircParser;

		private readonly JoinedChannelManager _joinedChannelManager;

		private readonly List<string> _hasSeenJoinedChannels = new List<string>();

		private string _lastMessageSent;

		public Version Version => Assembly.GetEntryAssembly().GetName().Version;

		public bool IsInitialized => _client != null;

		public IReadOnlyList<JoinedChannel> JoinedChannels => _joinedChannelManager.GetJoinedChannels();

		public string TwitchUsername { get; private set; }

		public WhisperMessage PreviousWhisper { get; private set; }

		public bool IsConnected => IsInitialized && _client != null && _client.IsConnected;

		public MessageEmoteCollection ChannelEmotes => _channelEmotes;

		public bool DisableAutoPong { get; set; } = false;

		public bool WillReplaceEmotes { get; set; } = false;

		public bool OverrideBeingHostedCheck { get; set; } = false;

		public ConnectionCredentials ConnectionCredentials { get; private set; }

		public bool AutoReListenOnException { get; set; }

		public event EventHandler<OnVIPsReceivedArgs> OnVIPsReceived;

		public event EventHandler<OnLogArgs> OnLog;

		public event EventHandler<OnConnectedArgs> OnConnected;

		public event EventHandler<OnJoinedChannelArgs> OnJoinedChannel;

		public event EventHandler<OnIncorrectLoginArgs> OnIncorrectLogin;

		public event EventHandler<OnChannelStateChangedArgs> OnChannelStateChanged;

		public event EventHandler<OnUserStateChangedArgs> OnUserStateChanged;

		public event EventHandler<OnMessageReceivedArgs> OnMessageReceived;

		public event EventHandler<OnWhisperReceivedArgs> OnWhisperReceived;

		public event EventHandler<OnMessageSentArgs> OnMessageSent;

		public event EventHandler<OnWhisperSentArgs> OnWhisperSent;

		public event EventHandler<OnChatCommandReceivedArgs> OnChatCommandReceived;

		public event EventHandler<OnWhisperCommandReceivedArgs> OnWhisperCommandReceived;

		public event EventHandler<OnUserJoinedArgs> OnUserJoined;

		public event EventHandler<OnModeratorJoinedArgs> OnModeratorJoined;

		public event EventHandler<OnModeratorLeftArgs> OnModeratorLeft;

		public event EventHandler<OnMessageClearedArgs> OnMessageCleared;

		public event EventHandler<OnNewSubscriberArgs> OnNewSubscriber;

		public event EventHandler<OnReSubscriberArgs> OnReSubscriber;

		public event EventHandler<OnPrimePaidSubscriberArgs> OnPrimePaidSubscriber;

		public event EventHandler OnHostLeft;

		public event EventHandler<OnExistingUsersDetectedArgs> OnExistingUsersDetected;

		public event EventHandler<OnUserLeftArgs> OnUserLeft;

		public event EventHandler<OnHostingStartedArgs> OnHostingStarted;

		public event EventHandler<OnHostingStoppedArgs> OnHostingStopped;

		public event EventHandler<OnDisconnectedEventArgs> OnDisconnected;

		public event EventHandler<OnConnectionErrorArgs> OnConnectionError;

		public event EventHandler<OnChatClearedArgs> OnChatCleared;

		public event EventHandler<OnUserTimedoutArgs> OnUserTimedout;

		public event EventHandler<OnLeftChannelArgs> OnLeftChannel;

		public event EventHandler<OnUserBannedArgs> OnUserBanned;

		public event EventHandler<OnModeratorsReceivedArgs> OnModeratorsReceived;

		public event EventHandler<OnChatColorChangedArgs> OnChatColorChanged;

		public event EventHandler<OnSendReceiveDataArgs> OnSendReceiveData;

		public event EventHandler<OnNowHostingArgs> OnNowHosting;

		public event EventHandler<OnBeingHostedArgs> OnBeingHosted;

		public event EventHandler<OnRaidNotificationArgs> OnRaidNotification;

		public event EventHandler<OnGiftedSubscriptionArgs> OnGiftedSubscription;

		public event EventHandler<OnCommunitySubscriptionArgs> OnCommunitySubscription;

		public event EventHandler<OnContinuedGiftedSubscriptionArgs> OnContinuedGiftedSubscription;

		public event EventHandler<OnMessageThrottledEventArgs> OnMessageThrottled;

		public event EventHandler<OnWhisperThrottledEventArgs> OnWhisperThrottled;

		public event EventHandler<OnErrorEventArgs> OnError;

		public event EventHandler<OnReconnectedEventArgs> OnReconnected;

		public event EventHandler<OnRitualNewChatterArgs> OnRitualNewChatter;

		public event EventHandler OnSelfRaidError;

		public event EventHandler OnNoPermissionError;

		public event EventHandler OnRaidedChannelIsMatureAudience;

		public event EventHandler<OnFailureToReceiveJoinConfirmationArgs> OnFailureToReceiveJoinConfirmation;

		public event EventHandler<OnUnaccountedForArgs> OnUnaccountedFor;

		public TwitchClient(IClient client = null, ClientProtocol protocol = ClientProtocol.WebSocket, ILogger<TwitchClient> logger = null)
		{
			_logger = logger;
			_client = client;
			_protocol = protocol;
			_joinedChannelManager = new JoinedChannelManager();
			_ircParser = new IrcParser();
		}

		public void Initialize(ConnectionCredentials credentials, string channel = null, char chatCommandIdentifier = '!', char whisperCommandIdentifier = '!', bool autoReListenOnExceptions = true)
		{
			initializeHelper(credentials, new List<string> { channel }, chatCommandIdentifier, whisperCommandIdentifier, autoReListenOnExceptions);
		}

		public void Initialize(ConnectionCredentials credentials, List<string> channels, char chatCommandIdentifier = '!', char whisperCommandIdentifier = '!', bool autoReListenOnExceptions = true)
		{
			initializeHelper(credentials, channels, chatCommandIdentifier, whisperCommandIdentifier, autoReListenOnExceptions);
		}

		private void initializeHelper(ConnectionCredentials credentials, List<string> channels, char chatCommandIdentifier = '!', char whisperCommandIdentifier = '!', bool autoReListenOnExceptions = true)
		{
			Log($"TwitchLib-TwitchClient initialized, assembly version: {Assembly.GetExecutingAssembly().GetName().Version}");
			ConnectionCredentials = credentials;
			TwitchUsername = ConnectionCredentials.TwitchUsername;
			if (chatCommandIdentifier != 0)
			{
				_chatCommandIdentifiers.Add(chatCommandIdentifier);
			}
			if (whisperCommandIdentifier != 0)
			{
				_whisperCommandIdentifiers.Add(whisperCommandIdentifier);
			}
			AutoReListenOnException = autoReListenOnExceptions;
			if (channels != null && channels.Count > 0)
			{
				int i;
				for (i = 0; i < channels.Count; i++)
				{
					if (!string.IsNullOrEmpty(channels[i]))
					{
						if (JoinedChannels.FirstOrDefault((JoinedChannel x) => x.Channel.ToLower() == channels[i]) != null)
						{
							return;
						}
						_joinChannelQueue.Enqueue(new JoinedChannel(channels[i]));
					}
				}
			}
			InitializeClient();
		}

		private void InitializeClient()
		{
			if (_client == null)
			{
				switch (_protocol)
				{
				case ClientProtocol.TCP:
					_client = new TcpClient();
					break;
				case ClientProtocol.WebSocket:
					_client = new WebSocketClient();
					break;
				}
			}
			Debug.Assert(_client != null, "_client != null");
			_client.OnConnected += _client_OnConnected;
			_client.OnMessage += _client_OnMessage;
			_client.OnDisconnected += _client_OnDisconnected;
			_client.OnFatality += _client_OnFatality;
			_client.OnMessageThrottled += _client_OnMessageThrottled;
			_client.OnWhisperThrottled += _client_OnWhisperThrottled;
			_client.OnReconnected += _client_OnReconnected;
		}

		internal void RaiseEvent(string eventName, object args = null)
		{
			FieldInfo field = GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
			MulticastDelegate multicastDelegate = field.GetValue(this) as MulticastDelegate;
			Delegate[] invocationList = multicastDelegate.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				obj.Method.Invoke(obj.Target, (args == null) ? new object[2]
				{
					this,
					new EventArgs()
				} : new object[2] { this, args });
			}
		}

		public void SendRaw(string message)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			Log("Writing: " + message);
			_client.Send(message);
			this.OnSendReceiveData?.Invoke(this, new OnSendReceiveDataArgs
			{
				Direction = SendReceiveDirection.Sent,
				Data = message
			});
		}

		private void SendTwitchMessage(JoinedChannel channel, string message, string replyToId = null, bool dryRun = false)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			if (channel == null || message == null || dryRun)
			{
				return;
			}
			if (message.Length > 500)
			{
				LogError("Message length has exceeded the maximum character count. (500)");
				return;
			}
			OutboundChatMessage outboundChatMessage = new OutboundChatMessage
			{
				Channel = channel.Channel,
				Username = ConnectionCredentials.TwitchUsername,
				Message = message
			};
			if (replyToId != null)
			{
				outboundChatMessage.ReplyToId = replyToId;
			}
			_lastMessageSent = message;
			_client.Send(outboundChatMessage.ToString());
		}

		public void SendMessage(JoinedChannel channel, string message, bool dryRun = false)
		{
			SendTwitchMessage(channel, message, null, dryRun);
		}

		public void SendMessage(string channel, string message, bool dryRun = false)
		{
			SendMessage(GetJoinedChannel(channel), message, dryRun);
		}

		public void SendReply(JoinedChannel channel, string replyToId, string message, bool dryRun = false)
		{
			SendTwitchMessage(channel, message, replyToId, dryRun);
		}

		public void SendReply(string channel, string replyToId, string message, bool dryRun = false)
		{
			SendReply(GetJoinedChannel(channel), replyToId, message, dryRun);
		}

		public void SendWhisper(string receiver, string message, bool dryRun = false)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			if (!dryRun)
			{
				OutboundWhisperMessage outboundWhisperMessage = new OutboundWhisperMessage
				{
					Receiver = receiver,
					Username = ConnectionCredentials.TwitchUsername,
					Message = message
				};
				_client.SendWhisper(outboundWhisperMessage.ToString());
				this.OnWhisperSent?.Invoke(this, new OnWhisperSentArgs
				{
					Receiver = receiver,
					Message = message
				});
			}
		}

		public bool Connect()
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			Log("Connecting to: " + ConnectionCredentials.TwitchWebsocketURI);
			_joinedChannelManager.Clear();
			if (_client.Open())
			{
				Log("Should be connected!");
				return true;
			}
			return false;
		}

		public void Disconnect()
		{
			Log("Disconnect Twitch Chat Client...");
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_client.Close();
			_joinedChannelManager.Clear();
			PreviousWhisper = null;
		}

		public void Reconnect()
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			Log("Reconnecting to Twitch");
			foreach (JoinedChannel joinedChannel in _joinedChannelManager.GetJoinedChannels())
			{
				_joinChannelQueue.Enqueue(joinedChannel);
			}
			_joinedChannelManager.Clear();
			_client.Reconnect();
		}

		public void AddChatCommandIdentifier(char identifier)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_chatCommandIdentifiers.Add(identifier);
		}

		public void RemoveChatCommandIdentifier(char identifier)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_chatCommandIdentifiers.Remove(identifier);
		}

		public void AddWhisperCommandIdentifier(char identifier)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_whisperCommandIdentifiers.Add(identifier);
		}

		public void RemoveWhisperCommandIdentifier(char identifier)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_whisperCommandIdentifiers.Remove(identifier);
		}

		public void SetConnectionCredentials(ConnectionCredentials credentials)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			if (IsConnected)
			{
				throw new IllegalAssignmentException("While the client is connected, you are unable to change the connection credentials. Please disconnect first and then change them.");
			}
			ConnectionCredentials = credentials;
		}

		public void JoinChannel(string channel, bool overrideCheck = false)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			if (!IsConnected)
			{
				HandleNotConnected();
			}
			if (JoinedChannels.FirstOrDefault((JoinedChannel x) => x.Channel.ToLower() == channel && !overrideCheck) == null)
			{
				_joinChannelQueue.Enqueue(new JoinedChannel(channel));
				if (!_currentlyJoiningChannels)
				{
					QueueingJoinCheck();
				}
			}
		}

		public JoinedChannel GetJoinedChannel(string channel)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			if (JoinedChannels.Count == 0)
			{
				throw new BadStateException("Must be connected to at least one channel.");
			}
			return _joinedChannelManager.GetJoinedChannel(channel);
		}

		public void LeaveChannel(string channel)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			channel = channel.ToLower();
			Log("Leaving channel: " + channel);
			JoinedChannel joinedChannel = _joinedChannelManager.GetJoinedChannel(channel);
			if (joinedChannel != null)
			{
				_client.Send(Rfc2812.Part("#" + channel));
			}
		}

		public void LeaveChannel(JoinedChannel channel)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			LeaveChannel(channel.Channel);
		}

		public void OnReadLineTest(string rawIrc)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			HandleIrcMessage(_ircParser.ParseIrcMessage(rawIrc));
		}

		private void _client_OnWhisperThrottled(object sender, OnWhisperThrottledEventArgs e)
		{
			this.OnWhisperThrottled?.Invoke(sender, e);
		}

		private void _client_OnMessageThrottled(object sender, OnMessageThrottledEventArgs e)
		{
			this.OnMessageThrottled?.Invoke(sender, e);
		}

		private void _client_OnFatality(object sender, OnFatalErrorEventArgs e)
		{
			this.OnConnectionError?.Invoke(this, new OnConnectionErrorArgs
			{
				BotUsername = TwitchUsername,
				Error = new ErrorEvent
				{
					Message = e.Reason
				}
			});
		}

		private void _client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
		{
			this.OnDisconnected?.Invoke(sender, e);
			_joinedChannelManager.Clear();
		}

		private void _client_OnReconnected(object sender, OnReconnectedEventArgs e)
		{
			this.OnReconnected?.Invoke(sender, e);
		}

		private void _client_OnMessage(object sender, OnMessageEventArgs e)
		{
			string[] separator = new string[1] { "\r\n" };
			string[] array = e.Message.Split(separator, StringSplitOptions.None);
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Length > 1)
				{
					Log("Received: " + text);
					this.OnSendReceiveData?.Invoke(this, new OnSendReceiveDataArgs
					{
						Direction = SendReceiveDirection.Received,
						Data = text
					});
					HandleIrcMessage(_ircParser.ParseIrcMessage(text));
				}
			}
		}

		private void _client_OnConnected(object sender, object e)
		{
			_client.Send(Rfc2812.Pass(ConnectionCredentials.TwitchOAuth));
			_client.Send(Rfc2812.Nick(ConnectionCredentials.TwitchUsername));
			_client.Send(Rfc2812.User(ConnectionCredentials.TwitchUsername, 0, ConnectionCredentials.TwitchUsername));
			if (ConnectionCredentials.Capabilities.Membership)
			{
				_client.Send("CAP REQ twitch.tv/membership");
			}
			if (ConnectionCredentials.Capabilities.Commands)
			{
				_client.Send("CAP REQ twitch.tv/commands");
			}
			if (ConnectionCredentials.Capabilities.Tags)
			{
				_client.Send("CAP REQ twitch.tv/tags");
			}
			if (_joinChannelQueue != null && _joinChannelQueue.Count > 0)
			{
				QueueingJoinCheck();
			}
		}

		private void QueueingJoinCheck()
		{
			if (_joinChannelQueue.Count > 0)
			{
				_currentlyJoiningChannels = true;
				JoinedChannel joinedChannel = _joinChannelQueue.Dequeue();
				Log("Joining channel: " + joinedChannel.Channel);
				_client.Send(Rfc2812.Join("#" + joinedChannel.Channel.ToLower()));
				_joinedChannelManager.AddJoinedChannel(new JoinedChannel(joinedChannel.Channel));
				StartJoinedChannelTimer(joinedChannel.Channel);
			}
			else
			{
				Log("Finished channel joining queue.");
			}
		}

		private void StartJoinedChannelTimer(string channel)
		{
			if (_joinTimer == null)
			{
				_joinTimer = new Timer(1000.0);
				_joinTimer.Elapsed += JoinChannelTimeout;
				_awaitingJoins = new List<KeyValuePair<string, DateTime>>();
			}
			_awaitingJoins.Add(new KeyValuePair<string, DateTime>(channel.ToLower(), DateTime.Now));
			if (!_joinTimer.Enabled)
			{
				_joinTimer.Start();
			}
		}

		private void JoinChannelTimeout(object sender, ElapsedEventArgs e)
		{
			if (_awaitingJoins.Any())
			{
				List<KeyValuePair<string, DateTime>> list = _awaitingJoins.Where((KeyValuePair<string, DateTime> x) => (DateTime.Now - x.Value).TotalSeconds > 5.0).ToList();
				if (!list.Any())
				{
					return;
				}
				_awaitingJoins.RemoveAll((KeyValuePair<string, DateTime> x) => (DateTime.Now - x.Value).TotalSeconds > 5.0);
				{
					foreach (KeyValuePair<string, DateTime> item in list)
					{
						_joinedChannelManager.RemoveJoinedChannel(item.Key.ToLowerInvariant());
						this.OnFailureToReceiveJoinConfirmation?.Invoke(this, new OnFailureToReceiveJoinConfirmationArgs
						{
							Exception = new FailureToReceiveJoinConfirmationException(item.Key)
						});
					}
					return;
				}
			}
			_joinTimer.Stop();
			_currentlyJoiningChannels = false;
			QueueingJoinCheck();
		}

		private void HandleIrcMessage(IrcMessage ircMessage)
		{
			if (ircMessage.Message.Contains("Login authentication failed"))
			{
				this.OnIncorrectLogin?.Invoke(this, new OnIncorrectLoginArgs
				{
					Exception = new ErrorLoggingInException(ircMessage.ToString(), TwitchUsername)
				});
			}
			switch (ircMessage.Command)
			{
			case IrcCommand.PrivMsg:
				HandlePrivMsg(ircMessage);
				break;
			case IrcCommand.Notice:
				HandleNotice(ircMessage);
				break;
			case IrcCommand.Ping:
				if (!DisableAutoPong)
				{
					SendRaw("PONG");
				}
				break;
			case IrcCommand.Pong:
				break;
			case IrcCommand.Join:
				HandleJoin(ircMessage);
				break;
			case IrcCommand.Part:
				HandlePart(ircMessage);
				break;
			case IrcCommand.HostTarget:
				HandleHostTarget(ircMessage);
				break;
			case IrcCommand.ClearChat:
				HandleClearChat(ircMessage);
				break;
			case IrcCommand.ClearMsg:
				HandleClearMsg(ircMessage);
				break;
			case IrcCommand.UserState:
				HandleUserState(ircMessage);
				break;
			case IrcCommand.GlobalUserState:
				break;
			case IrcCommand.RPL_001:
				break;
			case IrcCommand.RPL_002:
				break;
			case IrcCommand.RPL_003:
				break;
			case IrcCommand.RPL_004:
				Handle004();
				break;
			case IrcCommand.RPL_353:
				Handle353(ircMessage);
				break;
			case IrcCommand.RPL_366:
				Handle366();
				break;
			case IrcCommand.RPL_372:
				break;
			case IrcCommand.RPL_375:
				break;
			case IrcCommand.RPL_376:
				break;
			case IrcCommand.Whisper:
				HandleWhisper(ircMessage);
				break;
			case IrcCommand.RoomState:
				HandleRoomState(ircMessage);
				break;
			case IrcCommand.Reconnect:
				Reconnect();
				break;
			case IrcCommand.UserNotice:
				HandleUserNotice(ircMessage);
				break;
			case IrcCommand.Mode:
				HandleMode(ircMessage);
				break;
			case IrcCommand.Unknown:
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = null,
					Location = "HandleIrcMessage",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				break;
			default:
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = null,
					Location = "HandleIrcMessage",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				break;
			}
		}

		private void HandlePrivMsg(IrcMessage ircMessage)
		{
			if (ircMessage.Hostmask.Equals("jtv!jtv@jtv.tmi.twitch.tv"))
			{
				BeingHostedNotification beingHostedNotification = new BeingHostedNotification(TwitchUsername, ircMessage);
				this.OnBeingHosted?.Invoke(this, new OnBeingHostedArgs
				{
					BeingHostedNotification = beingHostedNotification
				});
				return;
			}
			ChatMessage chatMessage = new ChatMessage(TwitchUsername, ircMessage, ref _channelEmotes, WillReplaceEmotes);
			foreach (JoinedChannel item in JoinedChannels.Where((JoinedChannel x) => string.Equals(x.Channel, ircMessage.Channel, StringComparison.InvariantCultureIgnoreCase)))
			{
				item.HandleMessage(chatMessage);
			}
			this.OnMessageReceived?.Invoke(this, new OnMessageReceivedArgs
			{
				ChatMessage = chatMessage
			});
			if (_chatCommandIdentifiers != null && _chatCommandIdentifiers.Count != 0 && !string.IsNullOrEmpty(chatMessage.Message) && _chatCommandIdentifiers.Contains(chatMessage.Message[0]))
			{
				ChatCommand command = new ChatCommand(chatMessage);
				this.OnChatCommandReceived?.Invoke(this, new OnChatCommandReceivedArgs
				{
					Command = command
				});
			}
		}

		private void HandleNotice(IrcMessage ircMessage)
		{
			if (ircMessage.Message.Contains("Improperly formatted auth"))
			{
				this.OnIncorrectLogin?.Invoke(this, new OnIncorrectLoginArgs
				{
					Exception = new ErrorLoggingInException(ircMessage.ToString(), TwitchUsername)
				});
				return;
			}
			if (!ircMessage.Tags.TryGetValue("msg-id", out var value))
			{
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel,
					Location = "NoticeHandling",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
			}
			switch (value)
			{
			case "color_changed":
				this.OnChatColorChanged?.Invoke(this, new OnChatColorChangedArgs
				{
					Channel = ircMessage.Channel
				});
				break;
			case "host_on":
				this.OnNowHosting?.Invoke(this, new OnNowHostingArgs
				{
					Channel = ircMessage.Channel,
					HostedChannel = ircMessage.Message.Split(' ')[2].Replace(".", "")
				});
				break;
			case "host_off":
				this.OnHostLeft?.Invoke(this, null);
				break;
			case "room_mods":
				this.OnModeratorsReceived?.Invoke(this, new OnModeratorsReceivedArgs
				{
					Channel = ircMessage.Channel,
					Moderators = ircMessage.Message.Replace(" ", "").Split(':')[1].Split(',').ToList()
				});
				break;
			case "no_mods":
				this.OnModeratorsReceived?.Invoke(this, new OnModeratorsReceivedArgs
				{
					Channel = ircMessage.Channel,
					Moderators = new List<string>()
				});
				break;
			case "no_permission":
				this.OnNoPermissionError?.Invoke(this, null);
				break;
			case "raid_error_self":
				this.OnSelfRaidError?.Invoke(this, null);
				break;
			case "raid_notice_mature":
				this.OnRaidedChannelIsMatureAudience?.Invoke(this, null);
				break;
			case "msg_channel_suspended":
				_awaitingJoins.RemoveAll((KeyValuePair<string, DateTime> x) => x.Key.ToLower() == ircMessage.Channel);
				_joinedChannelManager.RemoveJoinedChannel(ircMessage.Channel);
				QueueingJoinCheck();
				this.OnFailureToReceiveJoinConfirmation?.Invoke(this, new OnFailureToReceiveJoinConfirmationArgs
				{
					Exception = new FailureToReceiveJoinConfirmationException(ircMessage.Channel, ircMessage.Message)
				});
				break;
			case "no_vips":
				this.OnVIPsReceived?.Invoke(this, new OnVIPsReceivedArgs
				{
					Channel = ircMessage.Channel,
					VIPs = new List<string>()
				});
				break;
			case "vips_success":
				this.OnVIPsReceived?.Invoke(this, new OnVIPsReceivedArgs
				{
					Channel = ircMessage.Channel,
					VIPs = ircMessage.Message.Replace(" ", "").Replace(".", "").Split(':')[1].Split(',').ToList()
				});
				break;
			default:
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel,
					Location = "NoticeHandling",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				break;
			}
		}

		private void HandleJoin(IrcMessage ircMessage)
		{
			this.OnUserJoined?.Invoke(this, new OnUserJoinedArgs
			{
				Channel = ircMessage.Channel,
				Username = ircMessage.User
			});
		}

		private void HandlePart(IrcMessage ircMessage)
		{
			if (string.Equals(TwitchUsername, ircMessage.User, StringComparison.InvariantCultureIgnoreCase))
			{
				_joinedChannelManager.RemoveJoinedChannel(ircMessage.Channel);
				_hasSeenJoinedChannels.Remove(ircMessage.Channel);
				this.OnLeftChannel?.Invoke(this, new OnLeftChannelArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel
				});
			}
			else
			{
				this.OnUserLeft?.Invoke(this, new OnUserLeftArgs
				{
					Channel = ircMessage.Channel,
					Username = ircMessage.User
				});
			}
		}

		private void HandleHostTarget(IrcMessage ircMessage)
		{
			if (ircMessage.Message.StartsWith("-"))
			{
				HostingStopped hostingStopped = new HostingStopped(ircMessage);
				this.OnHostingStopped?.Invoke(this, new OnHostingStoppedArgs
				{
					HostingStopped = hostingStopped
				});
			}
			else
			{
				HostingStarted hostingStarted = new HostingStarted(ircMessage);
				this.OnHostingStarted?.Invoke(this, new OnHostingStartedArgs
				{
					HostingStarted = hostingStarted
				});
			}
		}

		private void HandleClearChat(IrcMessage ircMessage)
		{
			string value;
			if (string.IsNullOrWhiteSpace(ircMessage.Message))
			{
				this.OnChatCleared?.Invoke(this, new OnChatClearedArgs
				{
					Channel = ircMessage.Channel
				});
			}
			else if (ircMessage.Tags.TryGetValue("ban-duration", out value))
			{
				UserTimeout userTimeout = new UserTimeout(ircMessage);
				this.OnUserTimedout?.Invoke(this, new OnUserTimedoutArgs
				{
					UserTimeout = userTimeout
				});
			}
			else
			{
				UserBan userBan = new UserBan(ircMessage);
				this.OnUserBanned?.Invoke(this, new OnUserBannedArgs
				{
					UserBan = userBan
				});
			}
		}

		private void HandleClearMsg(IrcMessage ircMessage)
		{
			this.OnMessageCleared?.Invoke(this, new OnMessageClearedArgs
			{
				Channel = ircMessage.Channel,
				Message = ircMessage.Message,
				TargetMessageId = ircMessage.ToString().Split('=')[3].Split(';')[0],
				TmiSentTs = ircMessage.ToString().Split('=')[4].Split(' ')[0]
			});
		}

		private void HandleUserState(IrcMessage ircMessage)
		{
			UserState userState = new UserState(ircMessage);
			if (!_hasSeenJoinedChannels.Contains(userState.Channel.ToLowerInvariant()))
			{
				_hasSeenJoinedChannels.Add(userState.Channel.ToLowerInvariant());
				this.OnUserStateChanged?.Invoke(this, new OnUserStateChangedArgs
				{
					UserState = userState
				});
			}
			else
			{
				this.OnMessageSent?.Invoke(this, new OnMessageSentArgs
				{
					SentMessage = new SentMessage(userState, _lastMessageSent)
				});
			}
		}

		private void Handle004()
		{
			this.OnConnected?.Invoke(this, new OnConnectedArgs
			{
				BotUsername = TwitchUsername
			});
		}

		private void Handle353(IrcMessage ircMessage)
		{
			if (string.Equals(ircMessage.Channel, TwitchUsername, StringComparison.InvariantCultureIgnoreCase))
			{
				this.OnExistingUsersDetected?.Invoke(this, new OnExistingUsersDetectedArgs
				{
					Channel = ircMessage.Channel,
					Users = ircMessage.Message.Split(' ').ToList()
				});
			}
		}

		private void Handle366()
		{
			_currentlyJoiningChannels = false;
			QueueingJoinCheck();
		}

		private void HandleWhisper(IrcMessage ircMessage)
		{
			WhisperMessage whisperMessage = (PreviousWhisper = new WhisperMessage(ircMessage, TwitchUsername));
			this.OnWhisperReceived?.Invoke(this, new OnWhisperReceivedArgs
			{
				WhisperMessage = whisperMessage
			});
			if (_whisperCommandIdentifiers != null && _whisperCommandIdentifiers.Count != 0 && !string.IsNullOrEmpty(whisperMessage.Message) && _whisperCommandIdentifiers.Contains(whisperMessage.Message[0]))
			{
				WhisperCommand command = new WhisperCommand(whisperMessage);
				this.OnWhisperCommandReceived?.Invoke(this, new OnWhisperCommandReceivedArgs
				{
					Command = command
				});
				return;
			}
			this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
			{
				BotUsername = TwitchUsername,
				Channel = ircMessage.Channel,
				Location = "WhispergHandling",
				RawIRC = ircMessage.ToString()
			});
			UnaccountedFor(ircMessage.ToString());
		}

		private void HandleRoomState(IrcMessage ircMessage)
		{
			if (ircMessage.Tags.Count > 2)
			{
				KeyValuePair<string, DateTime> item = _awaitingJoins.FirstOrDefault((KeyValuePair<string, DateTime> x) => x.Key == ircMessage.Channel);
				_awaitingJoins.Remove(item);
				this.OnJoinedChannel?.Invoke(this, new OnJoinedChannelArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel
				});
				if (this.OnBeingHosted != null && ircMessage.Channel.ToLowerInvariant() != TwitchUsername && !OverrideBeingHostedCheck)
				{
					Log("[OnBeingHosted] OnBeingHosted will only be fired while listening to this event as the broadcaster's channel. You do not appear to be connected as the broadcaster. To hide this warning, set TwitchClient property OverrideBeingHostedCheck to true.");
				}
			}
			this.OnChannelStateChanged?.Invoke(this, new OnChannelStateChangedArgs
			{
				ChannelState = new ChannelState(ircMessage),
				Channel = ircMessage.Channel
			});
		}

		private void HandleUserNotice(IrcMessage ircMessage)
		{
			if (!ircMessage.Tags.TryGetValue("msg-id", out var value))
			{
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel,
					Location = "UserNoticeHandling",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				return;
			}
			switch (value)
			{
			case "raid":
			{
				RaidNotification raidNotification = new RaidNotification(ircMessage);
				this.OnRaidNotification?.Invoke(this, new OnRaidNotificationArgs
				{
					Channel = ircMessage.Channel,
					RaidNotification = raidNotification
				});
				break;
			}
			case "resub":
			{
				ReSubscriber reSubscriber = new ReSubscriber(ircMessage);
				this.OnReSubscriber?.Invoke(this, new OnReSubscriberArgs
				{
					ReSubscriber = reSubscriber,
					Channel = ircMessage.Channel
				});
				break;
			}
			case "ritual":
			{
				if (!ircMessage.Tags.TryGetValue("msg-param-ritual-name", out var value2))
				{
					this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
					{
						BotUsername = TwitchUsername,
						Channel = ircMessage.Channel,
						Location = "UserNoticeRitualHandling",
						RawIRC = ircMessage.ToString()
					});
					UnaccountedFor(ircMessage.ToString());
					break;
				}
				string text = value2;
				string text2 = text;
				if (text2 == "new_chatter")
				{
					this.OnRitualNewChatter?.Invoke(this, new OnRitualNewChatterArgs
					{
						RitualNewChatter = new RitualNewChatter(ircMessage)
					});
					break;
				}
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel,
					Location = "UserNoticeHandling",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				break;
			}
			case "subgift":
			{
				GiftedSubscription giftedSubscription2 = new GiftedSubscription(ircMessage);
				this.OnGiftedSubscription?.Invoke(this, new OnGiftedSubscriptionArgs
				{
					GiftedSubscription = giftedSubscription2,
					Channel = ircMessage.Channel
				});
				break;
			}
			case "submysterygift":
			{
				CommunitySubscription giftedSubscription = new CommunitySubscription(ircMessage);
				this.OnCommunitySubscription?.Invoke(this, new OnCommunitySubscriptionArgs
				{
					GiftedSubscription = giftedSubscription,
					Channel = ircMessage.Channel
				});
				break;
			}
			case "giftpaidupgrade":
			{
				ContinuedGiftedSubscription continuedGiftedSubscription = new ContinuedGiftedSubscription(ircMessage);
				this.OnContinuedGiftedSubscription?.Invoke(this, new OnContinuedGiftedSubscriptionArgs
				{
					ContinuedGiftedSubscription = continuedGiftedSubscription,
					Channel = ircMessage.Channel
				});
				break;
			}
			case "sub":
			{
				Subscriber subscriber = new Subscriber(ircMessage);
				this.OnNewSubscriber?.Invoke(this, new OnNewSubscriberArgs
				{
					Subscriber = subscriber,
					Channel = ircMessage.Channel
				});
				break;
			}
			case "primepaidupgrade":
			{
				PrimePaidSubscriber primePaidSubscriber = new PrimePaidSubscriber(ircMessage);
				this.OnPrimePaidSubscriber?.Invoke(this, new OnPrimePaidSubscriberArgs
				{
					PrimePaidSubscriber = primePaidSubscriber,
					Channel = ircMessage.Channel
				});
				break;
			}
			default:
				this.OnUnaccountedFor?.Invoke(this, new OnUnaccountedForArgs
				{
					BotUsername = TwitchUsername,
					Channel = ircMessage.Channel,
					Location = "UserNoticeHandling",
					RawIRC = ircMessage.ToString()
				});
				UnaccountedFor(ircMessage.ToString());
				break;
			}
		}

		private void HandleMode(IrcMessage ircMessage)
		{
			if (ircMessage.Message.StartsWith("+o"))
			{
				this.OnModeratorJoined?.Invoke(this, new OnModeratorJoinedArgs
				{
					Channel = ircMessage.Channel,
					Username = ircMessage.Message.Split(' ')[1]
				});
			}
			else if (ircMessage.Message.StartsWith("-o"))
			{
				this.OnModeratorLeft?.Invoke(this, new OnModeratorLeftArgs
				{
					Channel = ircMessage.Channel,
					Username = ircMessage.Message.Split(' ')[1]
				});
			}
		}

		private void UnaccountedFor(string ircString)
		{
			Log("Unaccounted for: " + ircString + " (please create a TwitchLib GitHub issue :P)");
		}

		private void Log(string message, bool includeDate = false, bool includeTime = false)
		{
			string arg = ((includeDate && includeTime) ? $"{DateTime.UtcNow}" : ((!includeDate) ? (DateTime.UtcNow.ToShortTimeString() ?? "") : (DateTime.UtcNow.ToShortDateString() ?? "")));
			if (includeDate || includeTime)
			{
				_logger?.LogInformation($"[TwitchLib, {Assembly.GetExecutingAssembly().GetName().Version} - {arg}] {message}");
			}
			else
			{
				_logger?.LogInformation($"[TwitchLib, {Assembly.GetExecutingAssembly().GetName().Version}] {message}");
			}
			this.OnLog?.Invoke(this, new OnLogArgs
			{
				BotUsername = ConnectionCredentials?.TwitchUsername,
				Data = message,
				DateTime = DateTime.UtcNow
			});
		}

		private void LogError(string message, bool includeDate = false, bool includeTime = false)
		{
			string arg = ((includeDate && includeTime) ? $"{DateTime.UtcNow}" : ((!includeDate) ? (DateTime.UtcNow.ToShortTimeString() ?? "") : (DateTime.UtcNow.ToShortDateString() ?? "")));
			if (includeDate || includeTime)
			{
				_logger?.LogError($"[TwitchLib, {Assembly.GetExecutingAssembly().GetName().Version} - {arg}] {message}");
			}
			else
			{
				_logger?.LogError($"[TwitchLib, {Assembly.GetExecutingAssembly().GetName().Version}] {message}");
			}
			this.OnLog?.Invoke(this, new OnLogArgs
			{
				BotUsername = ConnectionCredentials?.TwitchUsername,
				Data = message,
				DateTime = DateTime.UtcNow
			});
		}

		public void SendQueuedItem(string message)
		{
			if (!IsInitialized)
			{
				HandleNotInitialized();
			}
			_client.Send(message);
		}

		protected static void HandleNotInitialized()
		{
			throw new ClientNotInitializedException("The twitch client has not been initialized and cannot be used. Please call Initialize();");
		}

		protected static void HandleNotConnected()
		{
			throw new ClientNotConnectedException("In order to perform this action, the client must be connected to Twitch. To confirm connection, try performing this action in or after the OnConnected event has been fired.");
		}
	}
}
