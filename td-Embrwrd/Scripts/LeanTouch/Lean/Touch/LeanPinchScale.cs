using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanPinchScale")]
	[AddComponentMenu("Lean/Touch/Lean Pinch Scale")]
	public class LeanPinchScale : MonoBehaviour
	{
		public LeanFingerFilter Use;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private bool relative;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private float damping;

		[SerializeField]
		private Vector3 remainingScale;

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

		public float Sensitivity
		{
			get
			{
				return 0f;
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

		protected virtual void TranslateUI(float pinchScale, Vector2 pinchScreenCenter)
		{
		}

		protected virtual void Translate(float pinchScale, Vector2 screenCenter)
		{
		}
	}
}
