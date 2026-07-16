using System;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.Events;

namespace Lexone.UnityTwitchChat
{
	[AddComponentMenu("Unity Twitch Chat/Twitch IRC")]
	public class IRC : MonoBehaviour
	{
		[Header("Twitch IRC address and port")]
		[SerializeField]
		public string address = "irc.chat.twitch.tv";

		[SerializeField]
		public int port = 6667;

		[Header("Twitch IRC connection")]
		[Tooltip("If true, the client will connect to Twitch IRC anonymously (OAuth and username will be ignored)\n\nNote that you can't send chat messages when using anonymous login.")]
		[SerializeField]
		private bool useAnonymousLogin;

		[Tooltip("The OAuth token which will be used to authenticate with Twitch.\n\nGenerate one at: https://twitchapps.com/tmi/")]
		[SerializeField]
		public string oauth = "";

		[Tooltip("The Twitch username which will be used to authenticate with Twitch IRC.\n\n(this is the login name, not display name)")]
		[SerializeField]
		public string username = "";

		[Tooltip("The Twitch channel name which the client will join.")]
		[SerializeField]
		public string channel = "";

		[Header("General settings")]
		[Tooltip("If true, duplicate instances will be destroyed. The first instance will be set to DontDestroyOnLoad.")]
		[SerializeField]
		public bool singleton = true;

		[Tooltip("If true, the client will connect to Twitch IRC on Start.")]
		[SerializeField]
		private bool connectOnStart = true;

		[Tooltip("If true, every IRC message sent and received will be logged to the console.")]
		[SerializeField]
		public bool showIRCDebug = true;

		[Tooltip("If true, the thread start and stop will be logged to the console.")]
		[SerializeField]
		public bool showThreadDebug = true;

		[Tooltip("If true, chatters who haven't set their name color on Twitch will be assigned a random color, instead of white.")]
		[SerializeField]
		public bool useRandomColorForUndefined;

		[Header("Chat read settings (read thread)")]
		[Tooltip("The number of milliseconds between each time the read thread checks for new messages.")]
		[SerializeField]
		public int readInterval = 50;

		[Tooltip("The capacity of the read buffer. Smaller values consume less memory but require more cycles to retrieve data (CPU usage)")]
		[SerializeField]
		public ReadBufferSize readBufferSize = ReadBufferSize._256;

		[Header("Chat write settings (write thread)")]
		[Tooltip("The number of milliseconds between each time the write thread checks its queues.")]
		public int writeInterval = 50;

		public bool stayConnected;

		private static readonly int maxDataPerFrame = 100;

		private int connectionFailCount;

		private TwitchConnection connection;

		public UnityEvent OnConnected;

		public UnityEvent OnDisconnect;

		public UnityEvent OnTwitchSettingsChanged = new UnityEvent();

		internal readonly ConcurrentQueue<IRCReply> alertQueue = new ConcurrentQueue<IRCReply>();

		internal readonly ConcurrentQueue<Chatter> chatterQueue = new ConcurrentQueue<Chatter>();

		public bool isConnected => connection != null;

		public static IRC Instance { get; private set; }

		public IRCTags ClientUserTags => connection?.ClientUserTags;

		public event Action<Chatter> OnChatMessage;

		public event Action<IRCReply> OnConnectionAlert;

		[ContextMenu("Ping")]
		public void Ping()
		{
			connection?.Ping();
		}

		private void Awake()
		{
			if ((bool)Instance)
			{
				if (singleton)
				{
					base.gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else
			{
				Instance = this;
				if (singleton)
				{
					UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				}
			}
		}

		private void Start()
		{
			if (connectOnStart)
			{
				Connect();
			}
		}

		private void Update()
		{
			HandlePendingInformation();
		}

		private void OnDestroy()
		{
			if (singleton && Instance == this)
			{
				Instance = null;
			}
			BlockingDisconnect();
		}

		private void OnDisable()
		{
			BlockingDisconnect();
		}

		private void HandlePendingInformation()
		{
			int num = 0;
			while (!alertQueue.IsEmpty && num < maxDataPerFrame)
			{
				if (alertQueue.TryDequeue(out var result))
				{
					HandleConnectionAlert(result);
					num++;
				}
			}
			while (!chatterQueue.IsEmpty && num < maxDataPerFrame)
			{
				if (chatterQueue.TryDequeue(out var result2))
				{
					this.OnChatMessage?.Invoke(result2);
					num++;
				}
			}
		}

		private void HandleConnectionAlert(IRCReply alert)
		{
			if (showIRCDebug)
			{
				Debug.Log(Tags.alert + " " + alert.GetDescription());
			}
			switch (alert)
			{
			case IRCReply.MISSING_LOGIN_INFO:
			case IRCReply.BAD_LOGIN:
			case IRCReply.NO_CONNECTION:
				connectionFailCount = 0;
				Disconnect();
				break;
			case IRCReply.CONNECTION_INTERRUPTED:
				connectionFailCount++;
				Connect();
				break;
			case IRCReply.JOINED_CHANNEL:
				connectionFailCount = 0;
				break;
			}
			this.OnConnectionAlert?.Invoke(alert);
		}

		[ContextMenu("Connect")]
		public void Connect()
		{
			if (useAnonymousLogin)
			{
				username = "justinfan" + UnityEngine.Random.Range(1000, 9999);
				oauth = "";
			}
			else
			{
				if (oauth.Length <= 0 || username.Length <= 0)
				{
					alertQueue.Enqueue(IRCReply.MISSING_LOGIN_INFO);
					return;
				}
				if (oauth.StartsWith("oauth:"))
				{
					oauth = oauth.Substring(6);
				}
			}
			if (channel.Length <= 0)
			{
				alertQueue.Enqueue(IRCReply.MISSING_LOGIN_INFO);
			}
			else
			{
				StartCoroutine(StartConnection());
			}
			IEnumerator StartConnection()
			{
				if (connection != null)
				{
					yield return StartCoroutine(NonBlockingDisconnect());
				}
				connection = new TwitchConnection(this);
				if (connection.tcpClient == null || !connection.tcpClient.Connected)
				{
					alertQueue.Enqueue(IRCReply.NO_CONNECTION);
				}
				else
				{
					if (connectionFailCount >= 2)
					{
						int num = 1 << connectionFailCount - 2;
						if (showIRCDebug)
						{
							Debug.Log($"{Tags.alert} Reconnecting in {num} seconds");
						}
						yield return new WaitForSecondsRealtime(num);
					}
					connection.Begin();
					OnConnected.Invoke();
				}
			}
		}

		[ContextMenu("Disconnect")]
		public void Disconnect()
		{
			OnDisconnect.Invoke();
			if (connection != null && !connection.disconnectCalled)
			{
				StartCoroutine(NonBlockingDisconnect());
			}
		}

		private IEnumerator NonBlockingDisconnect()
		{
			yield return StartCoroutine(connection.End());
			connection = null;
			if (showIRCDebug)
			{
				Debug.Log(Tags.alert + " Disconnected from Twitch IRC");
			}
		}

		private void BlockingDisconnect()
		{
			if (connection != null)
			{
				connection.BlockingEnd();
				connection = null;
				if (showIRCDebug)
				{
					Debug.Log(Tags.alert + " Disconnected from Twitch IRC");
				}
			}
		}

		public void SendChatMessage(string message)
		{
			if (useAnonymousLogin)
			{
				Debug.LogWarning("Chat messages cannot be sent with anonymous login");
			}
			else
			{
				connection.SendChatMessage(message);
			}
		}

		public void JoinChannel(string channel)
		{
			if (channel != "")
			{
				connection.SendCommand("JOIN #" + channel.ToLower(), priority: true);
			}
		}

		public void LeaveChannel(string channel)
		{
			if (channel != "")
			{
				connection.SendCommand("PART #" + channel.ToLower(), priority: true);
			}
		}
	}
}
