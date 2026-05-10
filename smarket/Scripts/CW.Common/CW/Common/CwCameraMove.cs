using System;
using UnityEngine;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwCameraMove")]
	[AddComponentMenu("Common/CW Camera Move")]
	public class CwCameraMove : MonoBehaviour
	{
		[SerializeField]
		private bool listen;

		[SerializeField]
		private float damping;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private CwInputManager.Axis horizontalControls;

		[SerializeField]
		private CwInputManager.Axis depthControls;

		[SerializeField]
		private CwInputManager.Axis verticalControls;

		[NonSerialized]
		private Vector3 remainingDelta;

		public bool Listen
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

		public CwInputManager.Axis HorizontalControls
		{
			get
			{
				return default(CwInputManager.Axis);
			}
			set
			{
			}
		}

		public CwInputManager.Axis DepthControls
		{
			get
			{
				return default(CwInputManager.Axis);
			}
			set
			{
			}
		}

		public CwInputManager.Axis VerticalControls
		{
			get
			{
				return default(CwInputManager.Axis);
			}
			set
			{
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		private void AddToDelta()
		{
		}

		private void DampenDelta()
		{
		}
	}
}
