using UnityEngine;

namespace Player
{
	public class BuildingToolVisualizer : MonoBehaviour
	{
		[Header("Tools")]
		[Tooltip("The hammer GameObject to show when building")]
		[SerializeField]
		private GameObject hammerVisual;

		[Header("Animation Settings")]
		[Tooltip("Duration of the show animation")]
		[SerializeField]
		private float showDuration;

		[Tooltip("Duration of the hide animation")]
		[SerializeField]
		private float hideDuration;

		[Tooltip("Ease type for showing the hammer")]
		[SerializeField]
		private LeanTweenType showEase;

		[Tooltip("Ease type for hiding the hammer")]
		[SerializeField]
		private LeanTweenType hideEase;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isShowing;

		private Vector3 originalScale;

		public bool IsHammerVisible => false;

		private void Awake()
		{
		}

		public void ShowHammer()
		{
		}

		public void HideHammer()
		{
		}

		public void HideHammerImmediate()
		{
		}
	}
}
