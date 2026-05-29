using System;
using UnityEngine;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwCameraLook")]
	[AddComponentMenu("Common/CW Camera Look")]
	public class CwCameraLook : MonoBehaviour
	{
		[SerializeField]
		private bool listen;

		[SerializeField]
		private float damping;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private CwInputManager.Axis pitchControls;

		[SerializeField]
		private CwInputManager.Axis yawControls;

		[SerializeField]
		private CwInputManager.Axis rollControls;

		[NonSerialized]
		private Quaternion remainingDelta;

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

		public CwInputManager.Axis PitchControls
		{
			get
			{
				return default(CwInputManager.Axis);
			}
			set
			{
			}
		}

		public CwInputManager.Axis YawControls
		{
			get
			{
				return default(CwInputManager.Axis);
			}
			set
			{
			}
		}

		public CwInputManager.Axis RollControls
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

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnApplicationFocus(bool focus)
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
