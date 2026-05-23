using System.Collections.Generic;
using UnityEngine;

namespace VFX.Blood
{
	public class BloodDecalDrawer : MonoBehaviour, fd, fe
	{
		[SerializeField]
		private BloodDecalsPool m_bloodDecalsPoolPrefab;

		private BloodDecalsPool pwk;

		private Dictionary<int, BloodDecalsPool> pwl;

		private fb pwm;

		public void dxv()
		{
		}

		public bool dxw(ParticleCollisionEvent a)
		{
			return false;
		}

		public bool dxx(Vector3 a, Vector3 b, Transform c)
		{
			return false;
		}

		public void dxy(int a)
		{
		}

		private BloodDecalsPool dxz(Transform a)
		{
			return null;
		}
	}
}
