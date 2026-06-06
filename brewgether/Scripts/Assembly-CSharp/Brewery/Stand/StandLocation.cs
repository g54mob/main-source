using UnityEngine;

namespace Brewery.Stand
{
	public class StandLocation : MonoBehaviour
	{
		[Header("Waiting Zone")]
		[Tooltip("Center of the waiting zone. Place in front of the stand. Rotation controls box orientation. If null, uses stand transform.")]
		[SerializeField]
		private Transform waitingZoneCenter;

		[Tooltip("Half-width of the waiting box (local X axis of zone center)")]
		[SerializeField]
		private float zoneHalfWidth;

		[Tooltip("Half-depth of the waiting box (local Z axis of zone center)")]
		[SerializeField]
		private float zoneHalfDepth;

		[Tooltip("Inner padding — NPCs won't idle within this distance of the zone center")]
		[SerializeField]
		private float zoneInnerPadding;

		[Tooltip("Minimum distance between idle NPCs to prevent stacking")]
		[SerializeField]
		private float npcSeparation;

		[Header("NPC Timing")]
		[Tooltip("Base patience at the stand before NPC leaves (seconds)")]
		[SerializeField]
		private float basePatience;

		[Tooltip("How long NPC drinks at the stand (shorter than bar)")]
		[SerializeField]
		private float drinkDuration;

		[Tooltip("How far NPC wanders from stand while drinking")]
		[SerializeField]
		private float wanderRadius;

		[Tooltip("How often NPC picks a new wander point at stand")]
		[SerializeField]
		private float wanderInterval;

		[Tooltip("Safety timeout for leaving-stand state")]
		[SerializeField]
		private float leaveTimeout;

		[Tooltip("Sip animation interval at the stand (seconds)")]
		[SerializeField]
		private float sipInterval;

		[Tooltip("Rest pause between drinks so old bottle visually disappears (seconds)")]
		[SerializeField]
		private float restBetweenDrinks;

		[Header("References")]
		[SerializeField]
		private StandStateManager stateManager;

		[SerializeField]
		private StandInventoryManager inventoryManager;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public StandStateManager StateManager => null;

		public StandInventoryManager InventoryManager => null;

		public Vector3 WaitingZonePosition => default(Vector3);

		public float BasePatience => 0f;

		public float DrinkDuration => 0f;

		public float WanderRadius => 0f;

		public float WanderInterval => 0f;

		public float LeaveTimeout => 0f;

		public float SipInterval => 0f;

		public float RestBetweenDrinks => 0f;

		public float WaitingZoneRadius => 0f;

		public bool IsOpenAndStocked => false;

		public bool IsOpen => false;

		public Vector3 GetWalkTarget()
		{
			return default(Vector3);
		}

		public Vector3 GetRandomIdlePosition()
		{
			return default(Vector3);
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
