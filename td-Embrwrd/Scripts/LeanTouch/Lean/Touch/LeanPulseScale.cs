using System;
using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanPulseScale")]
	[AddComponentMenu("Lean/Touch/Lean Pulse Scale")]
	public class LeanPulseScale : MonoBehaviour
	{
		[SerializeField]
		private Vector3 baseScale;

		[SerializeField]
		private float size;

		[SerializeField]
		private float pulseInterval;

		[SerializeField]
		private float pulseSize;

		[SerializeField]
		private float damping;

		[NonSerialized]
		private float counter;

		public Vector3 BaseScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float PulseInterval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float PulseSize
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

		protected virtual void Update()
		{
		}
	}
}
