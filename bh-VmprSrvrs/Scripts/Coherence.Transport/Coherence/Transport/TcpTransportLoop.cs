using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	internal class TcpTransportLoop
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFlushSendQueue_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			private Stopwatch _003CflushTimer_003E5__2;

			private CancellationToken _003CcancellationToken_003E5__3;

			private ValueTaskAwaiter<IOutOctetStream> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReceiveFull_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			public byte[] buffer;

			private int _003CtotalRead_003E5__2;

			private TaskAwaiter<int> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReceivePacketHeader_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<(bool, int)> _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			public byte[] headerBuffer;

			private TaskAwaiter<int> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReceivePacketPayload_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int packetSize;

			public TcpTransportLoop _003C_003E4__this;

			private byte[] _003Cpacket_003E5__2;

			private TaskAwaiter<int> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRun_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunReceiveLoopAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			private byte[] _003CheaderBuffer_003E5__2;

			private TaskAwaiter<(bool, int)> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunSendLoopAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			private bool _003Cflush_003E5__2;

			private object _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private TaskAwaiter _003C_003Eu__1;

			private ValueTaskAwaiter<IOutOctetStream> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendMagicAndRoomUID_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpTransportLoop _003C_003E4__this;

			private byte[] _003CheaderPacket_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendPacket_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public IOutOctetStream data;

			public TcpTransportLoop _003C_003E4__this;

			public CancellationToken? cancellationToken;

			private ArraySegment<byte> _003Cpacket_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public const uint HEADER_SIZE = 2u;

		private const uint MAX_PACKET_SIZE = 32767u;

		private const ushort MAGIC_CODE = 1337;

		private const int MAGIC_CODE_SIZE = 2;

		private const int ROOM_UID_SIZE = 8;

		private readonly Stream stream;

		private readonly ulong uniqueRoomId;

		private readonly IStats stats;

		private readonly Logger logger;

		private readonly CancellationToken cancellationToken;

		private readonly ConcurrentQueue<(byte[], ConnectionException)> receiveQueue;

		private readonly AsyncQueue<IOutOctetStream> sendQueue;

		private bool runExecuted;

		public TimeSpan FlushTimeout { get; set; }

		public TcpTransportLoop(Stream stream, ulong uniqueRoomId, ConcurrentQueue<(byte[], ConnectionException)> receiveQueue, AsyncQueue<IOutOctetStream> sendQueue, IStats stats, Logger logger, CancellationToken cancellationToken)
		{
		}

		[AsyncStateMachine(typeof(_003CRun_003Ed__18))]
		public Task Run()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunReceiveLoopAsync_003Ed__19))]
		private Task RunReceiveLoopAsync()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReceivePacketHeader_003Ed__20))]
		private Task<(bool, int)> ReceivePacketHeader(byte[] headerBuffer)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReceivePacketPayload_003Ed__21))]
		private Task<bool> ReceivePacketPayload(int packetSize)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunSendLoopAsync_003Ed__22))]
		private Task RunSendLoopAsync()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendMagicAndRoomUID_003Ed__23))]
		private Task SendMagicAndRoomUID()
		{
			return null;
		}

		private byte[] CreateMagicAndRoomIDPacket()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendPacket_003Ed__25))]
		private Task SendPacket(IOutOctetStream data, CancellationToken? cancellationToken = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFlushSendQueue_003Ed__26))]
		private Task FlushSendQueue()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReceiveFull_003Ed__27))]
		private Task<int> ReceiveFull(byte[] buffer)
		{
			return null;
		}

		public static void WriteHeader(IOutOctetStream data)
		{
		}
	}
}
