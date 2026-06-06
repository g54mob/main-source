using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "HotspotBehavior", menuName = "Brewery/NPC/Hotspot Behavior Profile", order = 122)]
	public class HotspotBehaviorProfile : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Name of this behavior profile (e.g., 'Church - Reverent', 'Library - Quiet')")]
		[SerializeField]
		private string profileName;

		[Header("Animation Override")]
		[Tooltip("Allowed animation indices for this location (e.g., Church: 0=idle, 7=nod, 17=pray, 20=thoughtful)")]
		[SerializeField]
		private int[] allowedAnimations;

		[Tooltip("If true, ignores NPC personality animations and forces location-specific animations")]
		[SerializeField]
		private bool overridePersonalityAnimations;

		[Tooltip("How often NPCs change animations at this location (seconds). 0 = use personality default")]
		[Range(0f, 60f)]
		[SerializeField]
		private float animationChangeFrequency;

		[Header("Interaction Behavior")]
		[Tooltip("Multiplier for interaction frequency (0.3 = 70% fewer interactions, 1.5 = 50% more)")]
		[Range(0f, 2f)]
		[SerializeField]
		private float interactionFrequencyMultiplier;

		[Header("Movement Behavior")]
		[Tooltip("Multiplier for wander frequency (0.3 = wander 70% less, 1.5 = 50% more wandering)")]
		[Range(0f, 2f)]
		[SerializeField]
		private float wanderFrequencyMultiplier;

		[Tooltip("Multiplier for movement speed (0.7 = 30% slower, 1.3 = 30% faster)")]
		[Range(0.3f, 2f)]
		[SerializeField]
		private float movementSpeedMultiplier;

		[Header("Stay Duration")]
		[Tooltip("Multiplier for how long NPCs stay at this location (2.0 = stay twice as long)")]
		[Range(0.5f, 5f)]
		[SerializeField]
		private float stayDurationMultiplier;

		public string ProfileName => null;

		public int[] AllowedAnimations => null;

		public bool OverridePersonalityAnimations => false;

		public float AnimationChangeFrequency => 0f;

		public float InteractionFrequencyMultiplier => 0f;

		public float WanderFrequencyMultiplier => 0f;

		public float MovementSpeedMultiplier => 0f;

		public float StayDurationMultiplier => 0f;

		private void OnValidate()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string GetDetailedSummary()
		{
			return null;
		}

		[ContextMenu("Preset: Church (Reverent)")]
		private void CreateChurchPreset()
		{
		}

		[ContextMenu("Preset: Library (Quiet)")]
		private void CreateLibraryPreset()
		{
		}

		[ContextMenu("Preset: Gym (Energetic)")]
		private void CreateGymPreset()
		{
		}

		[ContextMenu("Preset: Cemetery (Somber)")]
		private void CreateCemeteryPreset()
		{
		}
	}
}
