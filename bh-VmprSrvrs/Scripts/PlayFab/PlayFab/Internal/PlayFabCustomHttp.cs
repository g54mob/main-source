using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SimpleHttp;

namespace PlayFab.Internal
{
	public class PlayFabCustomHttp : ITransportPlugin, IPlayFabPlugin
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public Task<SimpleHttpResponse> responseTask;

			internal bool _003CPost_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CPost_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CallRequestContainer reqContainer;

			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

			public PlayFabCustomHttp _003C_003E4__this;

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
			public _003CPost_003Ed__11(int _003C_003E1__state)
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

		private bool _isInitialized;

		public bool IsInitialized => false;

		public void Initialize()
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}

		public int GetPendingMessages()
		{
			return 0;
		}

		public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
		{
		}

		public void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
		{
		}

		public void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
		{
		}

		public void MakeApiCall(object reqContainerObj)
		{
		}

		[IteratorStateMachine(typeof(_003CPost_003Ed__11))]
		private IEnumerator Post(CallRequestContainer reqContainer)
		{
			return null;
		}

		private void OnResponse(string response, CallRequestContainer reqContainer)
		{
		}

		private void OnError(Exception error, CallRequestContainer reqContainer)
		{
		}

		private void OnError(string error, CallRequestContainer reqContainer)
		{
		}
	}
}
