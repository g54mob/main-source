using System.Collections.Generic;
using LVA.Limbs.Systems.Node;
using LVA.Organs.Variants.Human;
using UnityEngine;

namespace LVA.Limbs.Variants
{
	public class Knee : HumanLimb
	{
		[SerializeField]
		private bool m_isLeft;

		[SerializeField]
		private su m_bone;

		[SerializeField]
		private sv m_skin;

		[SerializeField]
		private DefaultMuscle m_muscle;

		protected override HumanoidLimbHoldGroupType? xgs => null;

		public override string hgh()
		{
			return null;
		}

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

		protected override List<wv> hla()
		{
			return null;
		}

		protected override bab hgr()
		{
			return null;
		}
	}
}
