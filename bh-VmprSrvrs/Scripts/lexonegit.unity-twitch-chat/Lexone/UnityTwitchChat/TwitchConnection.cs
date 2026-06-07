using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Lexone.UnityTwitchChat
{
	internal class TwitchConnection
	{
		[CompilerGenerated]
		private sealed class _003CEnd_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TwitchConnection _003C_003E4__this;

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
			public _003CEnd_003Ed__30(int _003C_003E1__state)
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

		private IRCTags _clientUserTags;

		private int _threadsRunning;

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

		private RateLimit rateLimit;

		private object rateLimitLock;

		private int sessionRandom;

		private ConcurrentQueue<string> priorityWriteQueue;

		private ConcurrentQueue<string> writeQueue;

		private ConcurrentQueue<DateTime> writeTimestamps;

		public TcpClient tcpClient { get; private set; }

		public IRCTags ClientUserTags
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private bool ThreadsRunning
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TwitchConnection(IRC irc)
		{
		}

		public void Begin()
		{
		}

		[IteratorStateMachine(typeof(_003CEnd_003Ed__30))]
		public IEnumerator End()
		{
			return null;
		}

		public void BlockingEnd()
		{
		}

		private void UpdateRateLimits()
		{
		}

		private void ReadThreadLoop()
		{
		}

		private bool CheckConnection(Socket socket)
		{
			return false;
		}

		private void HandleRawLine(string raw)
		{
		}

		private void HandlePRIVMSG(string ircString, string tagString)
		{
		}

		private void HandleUSERSTATE(string ircString, string tagString)
		{
		}

		private void HandleNOTICE(string ircString, string tagString)
		{
		}

		private void HandleRPL(string type)
		{
		}

		private void WriteThreadLoop()
		{
		}

		public void Ping()
		{
		}

		public void Pong()
		{
		}

		public void SendCommand(string command, bool priority = false)
		{
		}

		public void SendChatMessage(string message)
		{
		}
	}
}
