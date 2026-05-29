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
		private sealed class _003CWaitForResponseCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CWaitForResponseCoroutine_003Ed__15(int _003C_003E1__state)
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

		private static AsyncWebRequestData MakeGet(string uri)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData MakePost(string uri, WWWForm data)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData MakePost(string uri, string contentType, byte[] data)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData MakePut(string uri, string contentType = null, byte[] data = null)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData MakeRequest(string uri, WebRequestMethod method, string contentType = null, byte[] data = null)
		{
			return default(AsyncWebRequestData);
		}

		private static AsyncWebRequestData MakeRequest(string uri, WWWForm data)
		{
			return default(AsyncWebRequestData);
		}

		private static WebResponse WaitForResponse(AsyncWebRequestData requestData, Action<AsyncWebRequestData> onStatusUpdate = null)
		{
			return default(WebResponse);
		}

		[IteratorStateMachine(typeof(_003CWaitForResponseCoroutine_003Ed__15))]
		private static IEnumerator WaitForResponseCoroutine(AsyncWebRequestData requestData, Action<WebResponse> onResponseReturned = null)
		{
			return null;
		}

		private static UnityWebRequest ConstructWebRequest(string uri, WebRequestMethod method, string contentType = null, byte[] data = null)
		{
			return null;
		}

		private static UnityWebRequest ConstructWebRequest(string uri, WWWForm data)
		{
			return null;
		}

		private static AsyncOperation SendWebRequest(UnityWebRequest request)
		{
			return null;
		}

		private static string GetRequestMethodString(WebRequestMethod method)
		{
			return null;
		}

		private static void CheckCertificateValidationCallback()
		{
		}

		private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
