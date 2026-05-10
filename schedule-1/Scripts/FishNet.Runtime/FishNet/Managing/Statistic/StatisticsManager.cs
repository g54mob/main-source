using UnityEngine;

namespace FishNet.Managing.Statistic
{
	[AddComponentMenu("FishNet/Manager/StatisticsManager")]
	[DisallowMultipleComponent]
	public class StatisticsManager : MonoBehaviour
	{
		public NetworkTraficStatistics NetworkTraffic;

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}
	}
}
