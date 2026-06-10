using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking;

namespace AeLa.EasyFeedback.Web
{
	internal static class WebInterface
	{
		[CompilerGenerated]
		private sealed class _003C_waitForResponseCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AsyncWebRequestData requestData;

			public Action<WebResponse> onResponseReturned;

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
			public _003C_waitForResponseCoroutine_003Ed__15(int _003C_003E1__state)
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

		public static WebResponse Get(string uri, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		public static IEnumerator GetCoroutine(string uri, Action<WebResponse> onResponseReturned)
		{
			return null;
		}

		public static WebResponse Post(string uri, WWWForm data, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		public static WebResponse Post(string uri, string contentType, byte[] data, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		public static IEnumerator PostCoroutine(string uri, WWWForm data, Action<WebResponse> onResponseReturned)
		{
			return null;
		}

		public static IEnumerator PostCoroutine(string uri, string contentType, byte[] data, Action<WebResponse> onResponseReturned)
		{
			return null;
		}

		public static WebResponse Put(string uri, string contentType = null, byte[] data = null, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		public static IEnumerator PutCoroutine(string uri, string contentType, byte[] data, Action<WebResponse> onResponseReturned)
		{
			return null;
		}

		private static AsyncWebRequestData _makeGet(string uri)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData _makePost(string uri, WWWForm data)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData _makePost(string uri, string contentType, byte[] data)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData _makePut(string uri, string contentType = null, byte[] data = null)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData _makeRequest(string uri, WebRequestMethod method, string contentType = null, byte[] data = null)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData _makeRequest(string uri, WWWForm data)
		{
			return default(AsyncWebRequestData);
		}

		private static WebResponse _waitForResponse(AsyncWebRequestData requestData, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		[IteratorStateMachine(typeof(_003C_waitForResponseCoroutine_003Ed__15))]
		private static IEnumerator _waitForResponseCoroutine(AsyncWebRequestData requestData, Action<WebResponse> onResponseReturned = null)
		{
			return null;
		}

		private static UnityWebRequest _constructWebRequest(string uri, WebRequestMethod method, string contentType = null, byte[] data = null)
		{
			return null;
		}

		private static UnityWebRequest _constructWebRequest(string uri, WWWForm data)
		{
			return null;
		}

		private static AsyncOperation _sendWebRequest(UnityWebRequest request)
		{
			return null;
		}

		private static string _getRequestMethodString(WebRequestMethod method)
		{
			return null;
		}

		private static void _checkCertificateValidationCallback()
		{
		}

		private static bool _remoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
