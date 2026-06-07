using System;
using System.Diagnostics;

namespace Mirror
{
	public static class NetworkTime
	{
		public static float PingFrequency;

		public static int PingWindowSize;

		private static double lastPingTime;

		private static readonly Stopwatch stopwatch;

		private static ExponentialMovingAverage _rtt;

		private static ExponentialMovingAverage _offset;

		private static double offsetMin;

		private static double offsetMax;

		public static double time => 0.0;

		public static double timeVariance => 0.0;

		[Obsolete]
		public static double timeVar => 0.0;

		public static double timeStandardDeviation => 0.0;

		[Obsolete]
		public static double timeSd => 0.0;

		public static double offset => 0.0;

		public static double rtt => 0.0;

		public static double rttVariance => 0.0;

		[Obsolete]
		public static double rttVar => 0.0;

		public static double rttStandardDeviation => 0.0;

		[Obsolete]
		public static double rttSd => 0.0;

		static NetworkTime()
		{
		}

		private static double LocalTime()
		{
			return 0.0;
		}

		public static void Reset()
		{
		}

		internal static void UpdateClient()
		{
		}

		internal static void OnServerPing(NetworkConnection conn, NetworkPingMessage message)
		{
		}

		internal static void OnClientPong(NetworkPongMessage message)
		{
		}
	}
}
