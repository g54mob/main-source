using System;
using UnityEngine;

namespace FractureField.Api
{
	public static class ApiExtensions
	{
		public static void ApiGet<T>(this MonoBehaviour obj, string endpoint, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}

		public static void ApiPost<T>(this MonoBehaviour obj, string endpoint, object data, Action<T> onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}

		public static void ApiDelete(this MonoBehaviour obj, string endpoint, Action onSuccess = null, Action<Exception> onError = null, Action onFinally = null)
		{
		}
	}
}
