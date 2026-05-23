using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VFX.Blood;

namespace LVA.Limbs.Systems.Blood
{
	public class BloodDrain
	{
		private readonly IReadOnlyCollection<int3> sgo;

		private readonly BloodDrainParticle sgp;

		private readonly zb sgq;

		private readonly float sgr;

		private readonly float sgs;

		private float sgt;

		private float sgu;

		private int sgv;

		private readonly Vector2 sgw;

		private readonly Vector2 sgx;

		private readonly float sgy;

		public int3 sgz
		{
			[CompilerGenerated]
			get
			{
				return default(int3);
			}
		}

		public bjs xjg => null;

		public BloodDrain(BloodDrainParticle bloodDrainParticle, int3 drainCenterIndex, IReadOnlyCollection<int3> adjacentIndexes, zb force, int extraBurstsCount)
		{
		}

		public bool hrv(bje a)
		{
			return false;
		}

		public float hrw(float a)
		{
			return 0f;
		}

		public void hrx(float a)
		{
		}

		public void hry(int a)
		{
		}

		public void hrz(Quaternion a)
		{
		}

		public void hsa()
		{
		}

		private float hsb()
		{
			return 0f;
		}

		private int hsc()
		{
			return 0;
		}
	}
}
