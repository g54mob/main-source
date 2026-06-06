using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "VisitorScheduleConfig", menuName = "Brewery/NPC/Visitor Schedule Config")]
	public class VisitorScheduleConfig : ScriptableObject
	{
		[Header("Visitor Count")]
		[Tooltip("Minimum number of visitors to spawn each day")]
		[SerializeField]
		[Range(1f, 10f)]
		private int minVisitorsPerDay;

		[Tooltip("Maximum number of visitors to spawn each day")]
		[SerializeField]
		[Range(1f, 10f)]
		private int maxVisitorsPerDay;

		[Header("Time Window")]
		[Tooltip("Hour when visitors arrive (0-23, e.g., 9 = 9am)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int spawnHour;

		[Tooltip("Hour when non-housed visitors leave (0-23, e.g., 18 = 6pm)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int despawnHour;

		[Header("Location")]
		[Tooltip("SpawnPoint ID where visitors gather (e.g., 'TownCenter_Visitors')")]
		[SerializeField]
		private string visitorGatheringPointId;

		[Tooltip("Optional idle anchors within the gathering area for visitors to use")]
		[SerializeField]
		private string[] visitorIdleAnchorIds;

		public int MinVisitorsPerDay => 0;

		public int MaxVisitorsPerDay => 0;

		public int SpawnHour => 0;

		public int DespawnHour => 0;

		public string VisitorGatheringPointId => null;

		public string[] VisitorIdleAnchorIds => null;

		public int GetRandomVisitorCount()
		{
			return 0;
		}

		public bool IsWithinVisitorWindow(int currentHour)
		{
			return false;
		}

		public bool ShouldSpawnVisitors(int currentHour)
		{
			return false;
		}

		public bool ShouldDespawnVisitors(int currentHour)
		{
			return false;
		}
	}
}
