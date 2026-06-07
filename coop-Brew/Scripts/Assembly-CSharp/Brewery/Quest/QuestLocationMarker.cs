using UnityEngine;

namespace Brewery.Quest
{
	public class QuestLocationMarker : MonoBehaviour
	{
		[Header("Location Identity")]
		[Tooltip("Unique identifier for this location (e.g., 'corn_grinder', 'boiling_station', 'uncle_benny_shack')")]
		[SerializeField]
		private string locationId;

		[Header("Optional")]
		[Tooltip("Display name shown in UI (optional, for debugging)")]
		[SerializeField]
		private string displayName;

		public string LocationId => null;

		public string DisplayName => null;
	}
}
