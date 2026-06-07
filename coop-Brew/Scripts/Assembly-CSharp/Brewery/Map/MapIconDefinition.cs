using UnityEngine;

namespace Brewery.Map
{
	[CreateAssetMenu(fileName = "MapIconDefinition", menuName = "Brewery/Map Icon Definition", order = 101)]
	public class MapIconDefinition : ScriptableObject
	{
		[Header("Icon Prefab")]
		[Tooltip("3D icon prefab to display (e.g., SM_Icon_Location_01)")]
		public GameObject iconPrefab;

		[Header("Appearance")]
		[Tooltip("Offset above the target (e.g., (0, 3, 0) = 3 units above)")]
		public Vector3 offset;

		[Tooltip("Size multiplier for the icon")]
		[Min(0.1f)]
		public float scale;

		[Tooltip("Icon rotates to always face the camera (billboard effect)")]
		public bool enableBillboard;

		[Tooltip("Rotation offset: For movement direction icons, Y adjusts arrow alignment (e.g., if arrow points right when moving up, set Y to -90 or 90). For billboard icons, applies general rotation offset.")]
		public Vector3 rotationOffset;

		[Header("Movement Direction (for player icons)")]
		[Tooltip("Invert the movement direction by 180 degrees (arrow points opposite to movement)")]
		public bool invertDirection;

		[Tooltip("Smooth rotation speed (0 = instant, higher = smoother). Recommended: 5-15")]
		[Range(0f, 30f)]
		public float rotationSmoothSpeed;

		[Header("Animation")]
		[Tooltip("Enable pop-in animation when icon appears")]
		public bool enablePopAnimation;

		[Tooltip("Animation duration (seconds)")]
		[Range(0.1f, 2f)]
		public float popDuration;

		[Tooltip("Delay before animation starts (seconds after camera stops)")]
		[Range(0f, 2f)]
		public float popDelay;

		[Tooltip("Animation easing type (easeOutBack = bounce, easeOutElastic = spring)")]
		public LeanTweenType popEaseType;

		[Header("Pop-Out Animation")]
		[Tooltip("Enable pop-out animation when map closes")]
		public bool enablePopOutAnimation;

		[Tooltip("Pop-out animation duration (seconds) - should be fast")]
		[Range(0.05f, 1f)]
		public float popOutDuration;

		[Tooltip("Pop-out easing type (easeInBack = reverse bounce)")]
		public LeanTweenType popOutEaseType;

		[Header("Visibility")]
		[Tooltip("Only show icon when map is open")]
		public bool showOnlyWhenMapOpen;

		[Tooltip("Maximum distance to show icon (0 = infinite)")]
		[Range(0f, 1000f)]
		public float maxViewDistance;

		private void OnValidate()
		{
		}
	}
}
