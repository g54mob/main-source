using Brewery.NPC.Data;
using UnityEngine;

namespace Brewery.NPC
{
	[DisallowMultipleComponent]
	public class NPCHotspot : MonoBehaviour
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this hotspot")]
		[SerializeField]
		private string hotspotId;

		[Tooltip("Set name for grouping (e.g., 'Parks', 'Stores', 'TownSquares'). NPCs can filter by set.")]
		[SerializeField]
		private string setName;

		[Tooltip("Optional tags for further filtering (e.g., 'scenic', 'food', 'shopping')")]
		[SerializeField]
		private string[] tags;

		[Header("Anchor")]
		[Tooltip("Position where NPC stands/sits when visiting this hotspot")]
		[SerializeField]
		private Transform standPoint;

		[Header("Capacity")]
		[Tooltip("Maximum number of NPCs that can occupy this hotspot simultaneously (0 = unlimited)")]
		[SerializeField]
		private int capacity;

		[Header("Wander Area")]
		[Tooltip("Radius around standpoint where NPCs can wander (2-30m). Smaller hotspots = smaller radius.")]
		[Range(2f, 30f)]
		[SerializeField]
		private float wanderRadius;

		[Header("Special Behavior")]
		[Tooltip("Optional: Overrides default NPC behavior at this location (churches, libraries, gyms, etc.)")]
		[SerializeField]
		private HotspotBehaviorProfile behaviorProfile;

		[Header("Schedule")]
		[Tooltip("Start hour when this hotspot is accessible (0-23)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int openHour;

		[Tooltip("Start minute when this hotspot is accessible (0-59)")]
		[Range(0f, 59f)]
		[SerializeField]
		private int openMinute;

		[Tooltip("End hour when this hotspot closes (0-23). If same as open hour, it's open 24/7.")]
		[Range(0f, 23f)]
		[SerializeField]
		private int closeHour;

		[Tooltip("End minute when this hotspot closes (0-59)")]
		[Range(0f, 59f)]
		[SerializeField]
		private int closeMinute;

		[Header("Weighting")]
		[Tooltip("Selection weight for random hotspot picking (higher = more likely)")]
		[SerializeField]
		private float selectionWeight;

		private bool[] slotsOccupied;

		private int currentOccupancy;

		public string HotspotId => null;

		public string SetName => null;

		public string[] Tags => null;

		public Transform StandPoint => null;

		public int Capacity => 0;

		public int CurrentOccupancy => 0;

		public bool IsFull => false;

		public float WanderRadius => 0f;

		public int OpenHour => 0;

		public int OpenMinute => 0;

		public int CloseHour => 0;

		public int CloseMinute => 0;

		public float SelectionWeight => 0f;

		public HotspotBehaviorProfile BehaviorProfile => null;

		private void Awake()
		{
		}

		public bool TryReserve(out int slotIndex)
		{
			slotIndex = default(int);
			return false;
		}

		public void Release(int slotIndex)
		{
		}

		public bool IsOpenAtTime(int hour, int minute)
		{
			return false;
		}

		public bool HasTag(string tag)
		{
			return false;
		}

		public bool HasSpecialBehavior()
		{
			return false;
		}

		public int[] GetAllowedAnimations()
		{
			return null;
		}

		public bool ShouldOverridePersonalityAnimations()
		{
			return false;
		}

		public float GetAnimationChangeFrequency()
		{
			return 0f;
		}

		public float GetInteractionFrequencyMultiplier()
		{
			return 0f;
		}

		public float GetWanderFrequencyMultiplier()
		{
			return 0f;
		}

		public float GetMovementSpeedMultiplier()
		{
			return 0f;
		}

		public float GetStayDurationMultiplier()
		{
			return 0f;
		}

		private void OnValidate()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
