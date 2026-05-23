using System.Collections.Generic;
using LVA.Organs.Variants.Human;
using UnityEngine;

namespace LVA.Limbs.Variants
{
	public class Spine : HumanLimb
	{
		[SerializeField]
		private sb m_lowerBackbone;

		[SerializeField]
		private sb m_upperBackbone;

		[SerializeField]
		private sp m_ribs;

		[SerializeField]
		private sl m_leftLung;

		[SerializeField]
		private sl m_rightLung;

		[SerializeField]
		private si m_heart;

		[SerializeField]
		private DefaultMuscle m_muscle;

		[SerializeField]
		private sv m_skin;

		[SerializeField]
		private rv m_rotationModeProcessor;

		protected override int xgr => 0;

		protected override vi hhd()
		{
			return null;
		}

		protected override List<rx> hgm()
		{
			return null;
		}

		protected override void hgn()
		{
		}

		protected override bab hgr()
		{
			return null;
		}

		protected override List<wv> hla()
		{
			return null;
		}

		protected override wx hgs()
		{
			return null;
		}

		protected override void hgp()
		{
		}
	}
}
