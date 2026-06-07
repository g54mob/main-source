using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanTwistRotateAxis")]
	[AddComponentMenu("Lean/Touch/Lean Twist Rotate Axis")]
	public class LeanTwistRotateAxis : MonoBehaviour
	{
		public LeanFingerFilter Use;

		[SerializeField]
		private Vector3 axis;

		[SerializeField]
		private Space space;

		[SerializeField]
		private float sensitivity;

		public Vector3 Axis
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Space Space
		{
			get
			{
				return default(Space);
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
	}
}
