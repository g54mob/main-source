using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehicleDoor : MonoBehaviour
	{
		public enum HingeAxis
		{
			Y = 0,
			X = 1,
			Z = 2
		}

		[Header("Hinge")]
		[Tooltip("Which LOCAL axis the door rotates around. Y = side-opening door (typical car door). X = tailgate / trunk that tilts forward-back. Z = gullwing / lambo-style upward-swing (rare).")]
		[SerializeField]
		private HingeAxis hingeAxis;

		[Tooltip("Angle delta (degrees) added to the captured baseline when fully open. For a tailgate that starts at -90 and fully opens at -180, set this to -90. Use a negative value to swing the other way.")]
		[SerializeField]
		private float openAngle;

		[Header("Tween Durations")]
		[Tooltip("Total duration of the open tween in seconds.")]
		[SerializeField]
		[Min(0.01f)]
		private float openDuration;

		[Tooltip("Total duration of the close tween in seconds.")]
		[SerializeField]
		[Min(0.01f)]
		private float closeDuration;

		[Header("Cartoony Motion Curves")]
		[Tooltip("Open motion: time (0..1) → interpolation parameter. 0 = closed, 1 = fully open. Values below 0 = anticipation (door pulls back). Values above 1 = overshoot (door swings past). Default: subtle pull-back, strong overshoot past fully open, bounce back to target.")]
		[SerializeField]
		private AnimationCurve openCurve;

		[Tooltip("Close motion: time (0..1) → interpolation parameter. 0 = closed, 1 = fully open. Default: anticipation (door opens a bit more), snap closed, tiny rebound, settle.")]
		[SerializeField]
		private AnimationCurve closeCurve;

		private float _baselineNonHingeA;

		private float _baselineNonHingeB;

		private float _hingeClosed;

		private float _hingeOpen;

		private float _hingeCurrent;

		private bool _captured;

		private int _tweenId;

		private bool _isOpen;

		private bool _isDestroyed;

		public bool IsOpen => false;

		public float OpenDuration => 0f;

		private void Awake()
		{
		}

		private void CaptureClosed()
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void SnapClosed()
		{
		}

		private void PlayMotionCurve(AnimationCurve curve, float duration, bool targetIsOpen)
		{
		}

		private void ApplyHingeAngle(float angle)
		{
		}

		private void CancelTween()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
