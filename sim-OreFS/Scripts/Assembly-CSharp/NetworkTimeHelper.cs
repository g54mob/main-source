using Mirror;
using UnityEngine;

public static class NetworkTimeHelper
{
	public static double GetNetworkTime()
	{
		if (NetworkClient.active)
		{
			return NetworkTime.time;
		}
		return Time.timeAsDouble;
	}
}
