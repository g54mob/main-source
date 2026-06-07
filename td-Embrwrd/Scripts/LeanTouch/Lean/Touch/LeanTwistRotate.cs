using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanTwistRotate")]
	[AddComponentMenu("Lean/Touch/Lean Twist Rotate")]
	public class LeanTwistRotate : MonoBehaviour
	{
		public LeanFingerFilter Use;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private bool relative;

		[SerializeField]
		private float damping;

		[SerializeField]
		private Vector3 remainingTranslation;

		[SerializeField]
		private Quaternion remainingRotation;

		public Camera Camera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Relative
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Damping
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void AddFinger(LeanFinger finger)
		{
		}

		public void RemoveFinger(LeanFinger finger)
		{
		}

		public void RemoveAllFingers()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void TranslateUI(float twistDegrees, Vector2 twistScreenCenter)
		{
		}

		protected virtual void Translate(float twistDegrees, Vector2 twistScreenCenter)
		{
		}

		protected virtual void RotateUI(float twistDegrees)
		{
		}

		protected virtual void Rotate(float twistDegrees)
		{
		}
	}
}
