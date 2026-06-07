using System;
using BestHTTP.Logger;

namespace BestHTTP.Connections
{
	public static class ConnectionHelper
	{
		public static void HandleResponse(string context, HTTPRequest request, out bool resendRequest, out HTTPConnectionStates proposedConnectionState, ref KeepAliveHeader keepAlive, LoggingContext loggingContext1 = null, LoggingContext loggingContext2 = null, LoggingContext loggingContext3 = null)
		{
			resendRequest = default(bool);
			proposedConnectionState = default(HTTPConnectionStates);
		}

		public static bool LoadFromCache(string context, HTTPRequest request, LoggingContext loggingContext1 = null, LoggingContext loggingContext2 = null, LoggingContext loggingContext3 = null)
		{
			return false;
		}

		private static bool LoadFromCache(string context, HTTPRequest request, Uri uri, LoggingContext loggingContext1 = null, LoggingContext loggingContext2 = null, LoggingContext loggingContext3 = null)
		{
			return false;
		}

		public static bool TryLoadAllFromCache(string context, HTTPRequest request, LoggingContext loggingContext1 = null, LoggingContext loggingContext2 = null, LoggingContext loggingContext3 = null)
		{
			return false;
		}

		public static void TryStoreInCache(HTTPRequest request)
		{
		}

		public static Uri GetRedirectUri(HTTPRequest request, string location)
		{
			return null;
		}
	}
}
