using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Mirror
{
	public static class NetworkTime
	{
		public static float PingInterval = 2f;

		public static int PingWindowSize = 6;

		private static double lastPingTime;

		private static ExponentialMovingAverage _rtt = new ExponentialMovingAverage(PingWindowSize);

		[Obsolete("NetworkTime.PingFrequency was renamed to PingInterval, because we use it as seconds, not as Hz. Please rename all usages, but keep using it just as before.")]
		public static float PingFrequency
		{
			get
			{
				return PingInterval;
			}
			set
			{
				PingInterval = value;
			}
		}

		public static double localTime
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Time.unscaledTimeAsDouble;
			}
		}

		public static double time
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (!NetworkServer.active)
				{
					return NetworkClient.localTimeline;
				}
				return localTime;
			}
		}

		public static double offset => localTime - time;

		public static double rtt => _rtt.Value;

		public static double rttVariance => _rtt.Variance;

		[RuntimeInitializeOnLoadMethod]
		public static void ResetStatics()
		{
			PingInterval = 2f;
			PingWindowSize = 6;
			lastPingTime = 0.0;
			_rtt = new ExponentialMovingAverage(PingWindowSize);
		}

		internal static void UpdateClient()
		{
			if (localTime >= lastPingTime + (double)PingInterval)
			{
				NetworkClient.Send(new NetworkPingMessage(localTime), 1);
				lastPingTime = localTime;
			}
		}

		internal static void OnServerPing(NetworkConnectionToClient conn, NetworkPingMessage message)
		{
			NetworkPongMessage message2 = new NetworkPongMessage
			{
				localTime = message.localTime
			};
			conn.Send(message2, 1);
		}

		internal static void OnClientPong(NetworkPongMessage message)
		{
			if (!(message.localTime > localTime))
			{
				double newValue = localTime - message.localTime;
				_rtt.Add(newValue);
			}
		}

		internal static void OnClientPing(NetworkPingMessage message)
		{
			NetworkClient.Send(new NetworkPongMessage
			{
				localTime = message.localTime
			}, 1);
		}

		internal static void OnServerPong(NetworkConnectionToClient conn, NetworkPongMessage message)
		{
			if (!(message.localTime > localTime))
			{
				double newValue = localTime - message.localTime;
				conn._rtt.Add(newValue);
			}
		}
	}
}
