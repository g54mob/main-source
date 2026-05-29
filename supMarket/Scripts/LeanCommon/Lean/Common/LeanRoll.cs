using UnityEngine;

namespace Lean.Common
{
	[ExecuteInEditMode]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanRoll")]
	[AddComponentMenu("Lean/Common/Lean Roll")]
	public class LeanRoll : MonoBehaviour
	{
		[SerializeField]
		private float angle;

		[SerializeField]
		private bool clamp;

		[SerializeField]
		private float clampMin;

		[SerializeField]
		private float clampMax;

		[SerializeField]
		private float damping;

		[SerializeField]
		private float currentAngle;

		public float Angle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Clamp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ClampMin
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ClampMax
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

		public void IncrementAngle(float delta)
		{
		}

		public void DecrementAngle(float delta)
		{
		}

		public void RotateToDelta(Vector2 delta)
		{
		}

		[ContextMenu("Snap To Target")]
		public void SnapToTarget()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
