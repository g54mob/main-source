using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class AnalyticsClient
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CBootEvent_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AnalyticsEventRequest_Boot request;

		private HttpResponseMessage _003Cres_003E5__2;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private object _003C_003E7__wrap2;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CGenericEvent_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AnalyticsEventRequest_Generic request;

		private HttpResponseMessage _003Cres_003E5__2;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private object _003C_003E7__wrap2;

		private TaskAwaiter<string> _003C_003Eu__2;

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
	private struct _003CMissionEvent_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AnalyticsEventRequest_Mission request;

		private HttpResponseMessage _003Cres_003E5__2;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private object _003C_003E7__wrap2;

		private TaskAwaiter<string> _003C_003Eu__2;

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

	private static readonly HttpClient _http;

	private static string _baseUrl;

	private static string _key;

	private static string _deviceID;

	private static readonly JsonSerializerSettings _jsonOptions;

	public static void Init(string baseUrl, string analyticsKey, string deviceID)
	{
	}

	private static HttpRequestMessage CreateRequest(HttpMethod method, string url, object body = null)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CBootEvent_003Ed__7))]
	public static Task<bool> BootEvent(AnalyticsEventRequest_Boot request)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CMissionEvent_003Ed__8))]
	public static Task<bool> MissionEvent(AnalyticsEventRequest_Mission request)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CGenericEvent_003Ed__9))]
	public static Task<bool> GenericEvent(AnalyticsEventRequest_Generic request)
	{
		return null;
	}
}
