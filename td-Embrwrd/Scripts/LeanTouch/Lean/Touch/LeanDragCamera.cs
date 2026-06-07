using UnityEngine;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Drag Camera")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanDragCamera")]
	public class LeanDragCamera : MonoBehaviour
	{
		public LeanFingerFilter Use;

		public LeanScreenDepth ScreenDepth;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private float damping;

		[Range(0f, 1f)]
		[SerializeField]
		private float inertia;

		[SerializeField]
		private Vector3 remainingDelta;

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

		public float Inertia
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ContextMenu("Move To Selection")]
		public virtual void MoveToSelection()
		{
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

		protected virtual void LateUpdate()
		{
		}
	}
}
