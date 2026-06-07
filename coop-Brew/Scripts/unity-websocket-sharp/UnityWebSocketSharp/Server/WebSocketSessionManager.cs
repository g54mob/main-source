using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Timers;

namespace UnityWebSocketSharp.Server
{
	internal class WebSocketSessionManager
	{
		[CompilerGenerated]
		private sealed class _003Cget_ActiveIDs_003Ed__15 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public WebSocketSessionManager _003C_003E4__this;

			private Dictionary<string, bool>.Enumerator _003C_003E7__wrap1;

			string IEnumerator<string>.Current
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
			public _003Cget_ActiveIDs_003Ed__15(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003Cget_InactiveIDs_003Ed__21 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public WebSocketSessionManager _003C_003E4__this;

			private Dictionary<string, bool>.Enumerator _003C_003E7__wrap1;

			string IEnumerator<string>.Current
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
			public _003Cget_InactiveIDs_003Ed__21(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private object _forSweep;

		private bool _keepClean;

		private Logger _log;

		private static readonly byte[] _rawEmptyPingFrame;

		private Dictionary<string, IWebSocketSession> _sessions;

		private ServerState _state;

		private bool _sweeping;

		private Timer _sweepTimer;

		private object _sync;

		private TimeSpan _waitTime;

		internal ServerState State => default(ServerState);

		public IEnumerable<string> ActiveIDs
		{
			[IteratorStateMachine(typeof(_003Cget_ActiveIDs_003Ed__15))]
			get
			{
				return null;
			}
		}

		public int Count => 0;

		public IEnumerable<string> IDs => null;

		public IEnumerable<string> InactiveIDs
		{
			[IteratorStateMachine(typeof(_003Cget_InactiveIDs_003Ed__21))]
			get
			{
				return null;
			}
		}

		public IWebSocketSession this[string id] => null;

		public bool KeepClean
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IEnumerable<IWebSocketSession> Sessions => null;

		public TimeSpan WaitTime
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		static WebSocketSessionManager()
		{
		}

		internal WebSocketSessionManager(Logger log)
		{
		}

		private void broadcast(Opcode opcode, byte[] data, Action completed)
		{
		}

		private void broadcast(Opcode opcode, Stream sourceStream, Action completed)
		{
		}

		private void broadcastAsync(Opcode opcode, byte[] data, Action completed)
		{
		}

		private void broadcastAsync(Opcode opcode, Stream sourceStream, Action completed)
		{
		}

		private Dictionary<string, bool> broadping(byte[] rawFrame)
		{
			return null;
		}

		private bool canSet()
		{
			return false;
		}

		private static string createID()
		{
			return null;
		}

		private void setSweepTimer(double interval)
		{
		}

		private void stop(PayloadData payloadData, bool send)
		{
		}

		private bool tryGetSession(string id, out IWebSocketSession session)
		{
			session = null;
			return false;
		}

		internal string Add(IWebSocketSession session)
		{
			return null;
		}

		internal bool Remove(string id)
		{
			return false;
		}

		internal void Start()
		{
		}

		internal void Stop(ushort code, string reason)
		{
		}

		public void Broadcast(byte[] data)
		{
		}

		public void Broadcast(string data)
		{
		}

		public void Broadcast(Stream stream, int length)
		{
		}

		public void BroadcastAsync(byte[] data, Action completed)
		{
		}

		public void BroadcastAsync(string data, Action completed)
		{
		}

		public void BroadcastAsync(Stream stream, int length, Action completed)
		{
		}

		public void CloseSession(string id)
		{
		}

		public void CloseSession(string id, ushort code, string reason)
		{
		}

		public void CloseSession(string id, CloseStatusCode code, string reason)
		{
		}

		public bool PingTo(string id)
		{
			return false;
		}

		public bool PingTo(string message, string id)
		{
			return false;
		}

		public void SendTo(byte[] data, string id)
		{
		}

		public void SendTo(string data, string id)
		{
		}

		public void SendTo(Stream stream, int length, string id)
		{
		}

		public void SendToAsync(byte[] data, string id, Action<bool> completed)
		{
		}

		public void SendToAsync(string data, string id, Action<bool> completed)
		{
		}

		public void SendToAsync(Stream stream, int length, string id, Action<bool> completed)
		{
		}

		public void Sweep()
		{
		}

		public bool TryGetSession(string id, out IWebSocketSession session)
		{
			session = null;
			return false;
		}
	}
}
