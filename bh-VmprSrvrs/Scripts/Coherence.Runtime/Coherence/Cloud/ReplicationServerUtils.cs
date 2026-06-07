using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Coherence.Cloud
{
	public static class ReplicationServerUtils
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPingHttpServerAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string host;

			public int port;

			private UnityWebRequest _003Crequest_003E5__2;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		public static int Timeout { get; set; }

		[AsyncStateMachine(typeof(_003CPingHttpServerAsync_003Ed__4))]
		public static Task<bool> PingHttpServerAsync(string host, int port)
		{
			return null;
		}

		public static void PingHttpServer(string host, int port, Action<bool> onCompleted)
		{
		}

		[Deprecated("02/2025", 1, 5, 1)]
		[Obsolete("Use void PingHttpServer(string host, int port, Action<bool> onCompleted) instead.")]
		public static bool PingHttpServer(string host, int port)
		{
			return false;
		}
	}
}
