using System;
using System.Collections;
using UnityEngine.Networking;

namespace Mirror.Cloud
{
	public class RequestCreator : IRequestCreator
	{
		private const string GET = "GET";

		private const string POST = "POST";

		private const string PATCH = "PATCH";

		private const string DELETE = "DELETE";

		public readonly string baseAddress;

		public readonly string apiKey;

		private readonly ICoroutineRunner runner;

		public RequestCreator(string baseAddress, string apiKey, ICoroutineRunner coroutineRunner)
		{
		}

		private Uri CreateUri(string page)
		{
			return null;
		}

		private UnityWebRequest CreateWebRequest(string page, string method, string json = null)
		{
			return null;
		}

		public UnityWebRequest Get(string page)
		{
			return null;
		}

		public UnityWebRequest Post<T>(string page, T json) where T : struct, ICanBeJson
		{
			return null;
		}

		public UnityWebRequest Patch<T>(string page, T json) where T : struct, ICanBeJson
		{
			return null;
		}

		public UnityWebRequest Delete(string page)
		{
			return null;
		}

		public void SendRequest(UnityWebRequest request, RequestSuccess onSuccess = null, RequestFail onFail = null)
		{
		}

		public IEnumerator SendRequestEnumerator(UnityWebRequest request, RequestSuccess onSuccess = null, RequestFail onFail = null)
		{
			return null;
		}
	}
}
