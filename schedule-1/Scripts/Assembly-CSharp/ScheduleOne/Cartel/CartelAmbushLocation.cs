using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class CartelAmbushLocation : MonoBehaviour
	{
		public const int REQUIRED_AMBUSH_POINTS = 4;

		[Range(2f, 20f)]
		[Header("Settings")]
		public float DetectionRadius;

		public Transform[] AmbushPoints;

		private void Awake()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
