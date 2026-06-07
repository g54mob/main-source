using UnityEngine;

namespace Brewery.Destruction
{
	[CreateAssetMenu(fileName = "DestroyableSettings", menuName = "Brewery/Destroyable Settings", order = 101)]
	public class DestroyableSettings : ScriptableObject
	{
		[Header("Layer Detection")]
		[Tooltip("Layer mask for destroyable objects")]
		public LayerMask destroyableLayer;

		[Header("Destruction Physics")]
		[Tooltip("Minimum vehicle speed (km/h) required to destroy objects. Uses EzerealCarController.CurrentSpeed. Set to 0 to always trigger on collision.")]
		public float minimumSpeedToDestroy;

		[Tooltip("Force multiplier applied to destroyed objects")]
		[Range(0.1f, 10f)]
		public float forceMultiplier;

		[Tooltip("Upward force component (makes objects fly up a bit)")]
		[Range(0f, 5f)]
		public float upwardForce;

		[Tooltip("Torque multiplier for rotation on impact")]
		[Range(0f, 5f)]
		public float torqueMultiplier;

		[Tooltip("Mass to assign to destroyed objects")]
		[Range(0.1f, 100f)]
		public float destroyedObjectMass;

		[Tooltip("Drag to assign to destroyed objects")]
		[Range(0f, 5f)]
		public float destroyedObjectDrag;

		[Tooltip("Angular drag to assign to destroyed objects")]
		[Range(0f, 5f)]
		public float destroyedObjectAngularDrag;

		[Header("Reset System")]
		[Tooltip("Time in seconds before destroyed object resets to original position")]
		[Range(5f, 120f)]
		public float resetDelay;

		[Tooltip("Duration of the reset animation (lerp back to position)")]
		[Range(0.5f, 5f)]
		public float resetAnimationDuration;

		[Tooltip("Ease type for reset animation")]
		public LeanTweenType resetEaseType;

		[Tooltip("Fade out the object before resetting (makes it less jarring)")]
		public bool fadeBeforeReset;

		[Tooltip("Fade duration before reset")]
		[Range(0.1f, 2f)]
		public float fadeDuration;

		[Header("Shake Only (Non-Destroyable)")]
		[Tooltip("Config for objects that shake but don't get destroyed (e.g., buildings)")]
		public ShakeOnlyConfig shakeOnlyConfig;

		[Header("Bump Animation (All Destroyables)")]
		[Tooltip("Enable subtle bump animation when objects are hit")]
		public bool enableBumpAnimation;

		[Tooltip("How far the object bumps on impact (world units)")]
		[Range(0.01f, 0.5f)]
		public float bumpDistance;

		[Tooltip("Duration of the bump animation")]
		[Range(0.05f, 0.5f)]
		public float bumpDuration;

		[Header("Network")]
		[Tooltip("Sync destruction across network (requires NetworkObject on vehicle)")]
		public bool networkSyncEnabled;

		[Header("Debug")]
		[Tooltip("Show debug logs")]
		public bool showDebugLogs;

		[Tooltip("Show debug gizmos")]
		public bool showDebugGizmos;

		public bool ShouldOnlyShake(GameObject obj)
		{
			return false;
		}

		private void OnValidate()
		{
		}
	}
}
