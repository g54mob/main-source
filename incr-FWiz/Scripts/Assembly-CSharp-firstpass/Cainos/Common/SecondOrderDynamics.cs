using System;
using UnityEngine;

namespace Cainos.Common
{
	[Serializable]
	public struct SecondOrderDynamics
	{
		private Vector3 xp;

		private Vector3 y;

		private Vector3 yd;

		private float k1;

		private float k2;

		private float k3;

		private Vector3 xd;

		private float k2_stable;

		[SerializeField]
		private float f;

		[SerializeField]
		private float d;

		[SerializeField]
		private float r;

		public float Frequency
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

		public float Response
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SecondOrderDynamics(float frequency, float damping, float response)
		{
			xp = default(Vector3);
			y = default(Vector3);
			yd = default(Vector3);
			k1 = 0f;
			k2 = 0f;
			k3 = 0f;
			xd = default(Vector3);
			k2_stable = 0f;
			f = 0f;
			d = 0f;
			r = 0f;
		}

		public void Reset(float frequency, float damping, float response, Vector3 x0)
		{
		}

		public void Reset(Vector3 x0)
		{
		}

		public void Reset(Vector2 x0)
		{
		}

		public void Reset(float x0)
		{
		}

		public Vector3 Update(Vector3 x, float t)
		{
			return default(Vector3);
		}

		public Vector2 Update(Vector2 x, float t)
		{
			return default(Vector2);
		}

		public float Update(float x, float t)
		{
			return 0f;
		}

		private void UpdateInnerParams()
		{
		}
	}
}
