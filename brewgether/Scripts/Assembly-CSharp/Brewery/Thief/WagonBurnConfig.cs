using UnityEngine;

namespace Brewery.Thief
{
	[CreateAssetMenu(fileName = "WagonBurnConfig", menuName = "Brewery/Wagon Burn Config")]
	public class WagonBurnConfig : ScriptableObject
	{
		[Header("Burning Mechanics")]
		[Tooltip("Number of molotov hits required per wagon to fully ignite")]
		[Range(1f, 10f)]
		[SerializeField]
		private int hitsPerWagon;

		[Tooltip("Total number of wagons that must be ignited")]
		[Range(1f, 10f)]
		[SerializeField]
		private int totalWagons;

		[Tooltip("Seconds from first hit to complete all burns (global timer)")]
		[Range(30f, 300f)]
		[SerializeField]
		private float burnWindowSeconds;

		[Header("Camp Suppression")]
		[Tooltip("In-game days the camp stays suppressed after all wagons are burned")]
		[Range(1f, 30f)]
		[SerializeField]
		private int suppressionDays;

		[Tooltip("Radius in meters - camp despawns when all players leave this radius")]
		[Range(20f, 150f)]
		[SerializeField]
		private float proximityRadius;

		[Tooltip("How often to check player proximity (seconds)")]
		[Range(0.5f, 5f)]
		[SerializeField]
		private float proximityCheckInterval;

		[Header("Behavior")]
		[Tooltip("Should partial wagon hits be saved and persist?")]
		[SerializeField]
		private bool persistPartialHits;

		[Tooltip("Should defenders panic (run erratically) when wagons are burning?")]
		[SerializeField]
		private bool defendersPanicWhenBurning;

		[Tooltip("Should stealers immediately return to camp when burning starts?")]
		[SerializeField]
		private bool stealersReturnWhenBurning;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public int HitsPerWagon => 0;

		public int TotalWagons => 0;

		public float BurnWindowSeconds => 0f;

		public int SuppressionDays => 0;

		public float ProximityRadius => 0f;

		public float ProximityCheckInterval => 0f;

		public bool PersistPartialHits => false;

		public bool DefendersPanicWhenBurning => false;

		public bool StealersReturnWhenBurning => false;

		public bool ShowDebugLogs => false;

		public int TotalMolotovsRequired => 0;

		private void OnValidate()
		{
		}
	}
}
