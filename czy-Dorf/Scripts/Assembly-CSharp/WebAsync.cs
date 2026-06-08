using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using UnityEngine;

public class WebAsync
{
	private sealed class _003CGetResponse_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WebAsync _003C_003E4__this;

		public WebRequest webRequest;

		private IAsyncResult _003CasyncResult_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetResponse_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			WebAsync webAsync = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				webAsync.isResponseCompleted = false;
				webAsync.requestState = new RequestState();
				webAsync.requestState.webRequest = webRequest;
				_003CasyncResult_003E5__2 = webRequest.BeginGetResponse(webAsync.RespCallback, webAsync.requestState);
				ThreadPool.RegisterWaitForSingleObject(_003CasyncResult_003E5__2.AsyncWaitHandle, webAsync.ScanTimeoutCallback, webAsync.requestState, 10000, executeOnlyOnce: true);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (!_003CasyncResult_003E5__2.IsCompleted)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (webAsync.requestState != null && webAsync.requestState.errorMessage != null)
			{
				Debug.Log("[WebAsync] Error message while getting response from request '" + webRequest.RequestUri.ToString() + "': " + webAsync.requestState.errorMessage);
				return false;
			}
			webAsync.isResponseCompleted = true;
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
			throw new NotSupportedException();
		}
	}

	public bool isResponseCompleted;

	public RequestState requestState;

	public IEnumerator GetResponse(WebRequest webRequest)
	{
		return new _003CGetResponse_003Ed__6(0)
		{
			_003C_003E4__this = this,
			webRequest = webRequest
		};
	}

	private void RespCallback(IAsyncResult asyncResult)
	{
		WebRequest webRequest = requestState.webRequest;
		try
		{
			requestState.webResponse = webRequest.EndGetResponse(asyncResult);
		}
		catch (WebException ex)
		{
			requestState.errorMessage = "From callback, " + ex.Message;
		}
	}

	private void ScanTimeoutCallback(object state, bool timedOut)
	{
		if (timedOut)
		{
			((RequestState)state)?.webRequest.Abort();
		}
		else
		{
			((RegisteredWaitHandle)state)?.Unregister(null);
		}
	}
}
