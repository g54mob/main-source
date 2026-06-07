using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Log;

namespace Coherence.Runtime
{
	internal static class Request
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public bool silenceWarning;

			public string requestId;

			public string path;

			public string method;

			public IRuntimeSettings settings;

			public string body;

			public Dictionary<string, string> headers;

			public string sessionToken;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CExecuteCustomAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string endpoint;

			public string path;

			public string method;

			public string body;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private static readonly Logger logger;

		internal static void ExecuteCustom(string endpoint, string path, string method, string body, Action<RequestResponse<string>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CExecuteCustomAsync_003Ed__2))]
		internal static Task<string> ExecuteCustomAsync(string endpoint, string path, string method, string body)
		{
			return null;
		}

		internal static void Execute(string path, string method, string body, Dictionary<string, string> headers, IRuntimeSettings settings, string sessionToken, string requestId, Action<RequestResponse<string>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
		internal static Task<string> ExecuteAsync(string path, string method, string body, Dictionary<string, string> headers, IRuntimeSettings settings, string sessionToken, string requestId, bool silenceWarning = false)
		{
			return null;
		}

		private static string ReplacePasswordJSON(string input)
		{
			return null;
		}
	}
}
