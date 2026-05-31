using System;
using UnityEngine;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwCameraPivot")]
	[AddComponentMenu("Common/CW Camera Pivot")]
	public class CwCameraPivot : MonoBehaviour
	{
		[SerializeField]
		private bool listen;

		[SerializeField]
		private float damping;

		[SerializeField]
		private CwInputManager.Axis pitchControls;

		[SerializeField]
		private CwInputManager.Axis yawControls;

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

		protected virtual void OnEnable()
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
