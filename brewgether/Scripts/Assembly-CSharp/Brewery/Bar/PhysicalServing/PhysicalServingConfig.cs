using UnityEngine;

namespace Brewery.Bar.PhysicalServing
{
	[CreateAssetMenu(fileName = "PhysicalServingConfig", menuName = "Brewery/Physical Serving Config")]
	public class PhysicalServingConfig : ScriptableObject
	{
		private static PhysicalServingConfig _instance;

		[Header("=== DRINK REQUEST PANEL ===")]
		[Header("Panel Position (Local Space)")]
		[Tooltip("Local Y position above NPC head for the drink request panel")]
		[SerializeField]
		private float panelHeightOffset;

		[Tooltip("Local X offset for the panel")]
		[SerializeField]
		private float panelXOffset;

		[Tooltip("Local Z offset for the panel")]
		[SerializeField]
		private float panelZOffset;

		[Header("Panel Display")]
		[Tooltip("Maximum distance at which the panel is visible to the player")]
		[SerializeField]
		private float panelShowDistance;

		[Tooltip("Sorting order for world-space UI. Lower = renders behind. Should be below speech bubble (100).")]
		[SerializeField]
		private int panelSortingOrder;

		[Header("Panel Animation")]
		[Tooltip("Duration of the pop-in animation when panel appears")]
		[SerializeField]
		private float panelPopInDuration;

		[Tooltip("Duration of the pop-out animation when panel hides")]
		[SerializeField]
		private float panelPopOutDuration;

		[Header("=== SERVING INTERACTION ===")]
		[Tooltip("Maximum distance from which player can serve an NPC")]
		[SerializeField]
		private float interactionDistance;

		[Tooltip("Interaction priority (higher = takes precedence). NPCs should be higher than most objects.")]
		[SerializeField]
		private int interactionPriority;

		[Header("=== THROW BEHAVIOR ===")]
		[Header("Throw Physics")]
		[Tooltip("Force applied forward when NPC throws drink")]
		[SerializeField]
		private float throwForce;

		[Tooltip("Upward force added when throwing")]
		[SerializeField]
		private float throwUpwardForce;

		[Tooltip("Random spin torque applied on throw")]
		[SerializeField]
		private float throwSpinTorque;

		[Tooltip("Spawn offset from NPC position (local space) if no throwOrigin set")]
		[SerializeField]
		private Vector3 throwOriginOffset;

		[Header("Projectile")]
		[Tooltip("How long the thrown drink exists before despawning")]
		[SerializeField]
		private float projectileLifetime;

		[Header("Animation Timing")]
		[Tooltip("Total throw animation duration (fallback if animation event doesn't fire)")]
		[SerializeField]
		private float throwAnimationDuration;

		[Tooltip("Duration angry dialogue is shown")]
		[SerializeField]
		private float throwDialogueDuration;

		public static PhysicalServingConfig Instance => null;

		public float PanelHeightOffset => 0f;

		public float PanelXOffset => 0f;

		public float PanelZOffset => 0f;

		public Vector3 PanelLocalPosition => default(Vector3);

		public float PanelShowDistance => 0f;

		public int PanelSortingOrder => 0;

		public float PanelPopInDuration => 0f;

		public float PanelPopOutDuration => 0f;

		public float InteractionDistance => 0f;

		public int InteractionPriority => 0;

		public float ThrowForce => 0f;

		public float ThrowUpwardForce => 0f;

		public float ThrowSpinTorque => 0f;

		public Vector3 ThrowOriginOffset => default(Vector3);

		public float ProjectileLifetime => 0f;

		public float ThrowAnimationDuration => 0f;

		public float ThrowDialogueDuration => 0f;

		public static void ClearCache()
		{
		}

		private void OnValidate()
		{
		}
	}
}
