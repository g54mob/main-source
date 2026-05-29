using ScheduleOne.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools
{
	public class BombPlantLocation : MonoBehaviour
	{
		public const float COUNTDOWN_TIME = 45f;

		public const float BEEP_INTERVAL_MAX = 1f;

		public const float BEEP_INTERVAL_MIN = 0.125f;

		[Header("References")]
		public InteractableObject IntObj;

		public GameObject BombModel;

		public UnityEvent onPlantBomb;

		public UnityEvent onBeep;

		public UnityEvent onDetonate;

		public bool BombPlanted { get; private set; }

		private void Awake()
		{
		}

		private void Hovered()
		{
		}

		private void Interacted()
		{
		}

		public void PlantBomb()
		{
		}

		private bool CanPlantBomb()
		{
			return false;
		}
	}
}
