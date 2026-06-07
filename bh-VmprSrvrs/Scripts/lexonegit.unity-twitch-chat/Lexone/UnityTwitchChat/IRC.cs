using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Lexone.UnityTwitchChat
{
	[AddComponentMenu("Unity Twitch Chat/Twitch IRC")]
	public class IRC : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CNonBlockingDisconnect_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public IRC _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CNonBlockingDisconnect_003Ed__41(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Twitch IRC address and port")]
		[SerializeField]
		public string address;

		[SerializeField]
		public int port;

		[Header("Twitch IRC connection")]
		[Tooltip("If true, the client will connect to Twitch IRC anonymously (OAuth and username will be ignored)\n\nNote that you can't send chat messages when using anonymous login.")]
		[SerializeField]
		private bool useAnonymousLogin;

		[Tooltip("The OAuth token which will be used to authenticate with Twitch.\n\nGenerate one at: https://twitchapps.com/tmi/")]
		[SerializeField]
		public string oauth;

		[Tooltip("The Twitch username which will be used to authenticate with Twitch IRC.\n\n(this is the login name, not display name)")]
		[SerializeField]
		public string username;

		[Tooltip("The Twitch channel name which the client will join.")]
		[SerializeField]
		public string channel;

		[Header("General settings")]
		[Tooltip("If true, duplicate instances will be destroyed. The first instance will be set to DontDestroyOnLoad.")]
		[SerializeField]
		public bool singleton;

		[Tooltip("If true, the client will connect to Twitch IRC on Start.")]
		[SerializeField]
		private bool connectOnStart;

		[Tooltip("If true, every IRC message sent and received will be logged to the console.")]
		[SerializeField]
		public bool showIRCDebug;

		[Tooltip("If true, the thread start and stop will be logged to the console.")]
		[SerializeField]
		public bool showThreadDebug;

		[Tooltip("If true, chatters who haven't set their name color on Twitch will be assigned a random color, instead of white.")]
		[SerializeField]
		public bool useRandomColorForUndefined;

		[Header("Chat read settings (read thread)")]
		[Tooltip("The number of milliseconds between each time the read thread checks for new messages.")]
		[SerializeField]
		public int readInterval;

		[Tooltip("The capacity of the read buffer. Smaller values consume less memory but require more cycles to retrieve data (CPU usage)")]
		[SerializeField]
		public ReadBufferSize readBufferSize;

		[Header("Chat write settings (write thread)")]
		[Tooltip("The number of milliseconds between each time the write thread checks its queues.")]
		public int writeInterval;

		private static readonly int maxDataPerFrame;

		private int connectionFailCount;

		private TwitchConnection connection;

		internal readonly ConcurrentQueue<IRCReply> alertQueue;

		internal readonly ConcurrentQueue<Chatter> chatterQueue;

		public static IRC Instance { get; private set; }

		public IRCTags ClientUserTags => null;

		public event Action<Chatter> OnChatMessage
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IRCReply> OnConnectionAlert
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[ContextMenu("Ping")]
		public void Ping()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void HandlePendingInformation()
		{
		}

		private void HandleConnectionAlert(IRCReply alert)
		{
		}

		[ContextMenu("Connect")]
		public void Connect()
		{
		}

		[ContextMenu("Disconnect")]
		public void Disconnect()
		{
		}

		[IteratorStateMachine(typeof(_003CNonBlockingDisconnect_003Ed__41))]
		private IEnumerator NonBlockingDisconnect()
		{
			return null;
		}

		private void BlockingDisconnect()
		{
		}

		public void SendChatMessage(string message)
		{
		}

		public void JoinChannel(string channel)
		{
		}

		public void LeaveChannel(string channel)
		{
		}

		public bool IsConnected()
		{
			return false;
		}
	}
}
