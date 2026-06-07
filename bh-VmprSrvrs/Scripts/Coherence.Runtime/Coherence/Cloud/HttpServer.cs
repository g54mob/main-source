using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Log;

namespace Coherence.Cloud
{
	public class HttpServer
	{
		private delegate Task HandleEndpoint(HttpListenerContext ctx, HttpServer serv, Logger logger);

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHandleEndpointGetHealth_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpListenerContext ctx;

			public Logger logger;

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
		private struct _003CHandleEndpointGetMetrics_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpServer serv;

			public HttpListenerContext ctx;

			public Logger logger;

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
		private struct _003CHandleEndpointGetStats_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpServer serv;

			public HttpListenerContext ctx;

			public Logger logger;

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
		private struct _003CListen_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public HttpServer _003C_003E4__this;

			private TaskAwaiter<HttpListenerContext> _003C_003Eu__1;

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
		private struct _003CRouteRequest_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpListenerContext ctx;

			public HttpServer _003C_003E4__this;

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
		private struct _003CWriteResponse_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpListenerContext ctx;

			public HttpStatusCode status;

			public Logger logger;

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
		private struct _003CWriteResponse_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public HttpListenerContext ctx;

			public HttpStatusCode status;

			public string body;

			private HttpListenerResponse _003Cr_003E5__2;

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

		private static readonly Dictionary<(string method, string path), HandleEndpoint> endpoints;

		private HttpListener listener;

		private CancellationTokenSource cts;

		private static Logger logger;

		private int port;

		private Func<GameServerStats> statsFn;

		public Task<bool> Start(int port, Func<GameServerStats> statsFn)
		{
			return null;
		}

		public void Stop()
		{
		}

		[AsyncStateMachine(typeof(_003CListen_003Ed__9))]
		private Task<bool> Listen()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRouteRequest_003Ed__10))]
		private Task RouteRequest(HttpListenerContext ctx)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteResponse_003Ed__11))]
		private static Task WriteResponse(HttpListenerContext ctx, HttpStatusCode status, Logger logger)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteResponse_003Ed__12))]
		private static Task WriteResponse(HttpListenerContext ctx, HttpStatusCode status, string body, Logger logger)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleEndpointGetHealth_003Ed__13))]
		private static Task HandleEndpointGetHealth(HttpListenerContext ctx, HttpServer serv, Logger logger)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleEndpointGetStats_003Ed__14))]
		private static Task HandleEndpointGetStats(HttpListenerContext ctx, HttpServer serv, Logger logger)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleEndpointGetMetrics_003Ed__15))]
		private static Task HandleEndpointGetMetrics(HttpListenerContext ctx, HttpServer serv, Logger logger)
		{
			return null;
		}

		private static GameServerStats GetStats(HttpServer serv)
		{
			return default(GameServerStats);
		}

		private static string PrometheusMetric(string type, string name, string description, IFormattable value)
		{
			return null;
		}
	}
}
