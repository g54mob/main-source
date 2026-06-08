using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace AWSSDK.Runtime.Internal.Util
{
	internal static class ExceptionUtils
	{
		internal static HttpStatusCode? DetermineHttpStatusCode(Exception e)
		{
			if ((e as WebException)?.Response is HttpWebResponse httpWebResponse)
			{
				return httpWebResponse.StatusCode;
			}
			if (e is HttpRequestException ex && ex.Data?.Contains("StatusCode") == true)
			{
				return (HttpStatusCode)ex.Data["StatusCode"];
			}
			if (e?.InnerException != null)
			{
				return DetermineHttpStatusCode(e.InnerException);
			}
			return null;
		}

		internal static bool IsInnerException<T>(Exception exception) where T : Exception
		{
			T inner;
			return IsInnerException<T>(exception, out inner);
		}

		internal static bool IsInnerException<T>(Exception exception, out T inner) where T : Exception
		{
			inner = null;
			Queue<Exception> queue = new Queue<Exception>();
			Exception ex = exception;
			do
			{
				if (queue.Count > 0)
				{
					ex = queue.Dequeue();
					inner = ex as T;
					if (inner != null)
					{
						return true;
					}
				}
				if (ex is AggregateException ex2)
				{
					foreach (Exception innerException in ex2.InnerExceptions)
					{
						queue.Enqueue(innerException);
					}
				}
				else if (ex.InnerException != null)
				{
					queue.Enqueue(ex.InnerException);
				}
			}
			while (queue.Count > 0);
			return false;
		}
	}
}
