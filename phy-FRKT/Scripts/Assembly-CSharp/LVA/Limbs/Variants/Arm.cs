using System.Collections.Generic;
using LVA.Limbs.Systems.Node;
using LVA.Organs.Variants.Human;
using UnityEngine;

namespace LVA.Limbs.Variants
{
	public class Arm : HumanLimb
	{
		[SerializeField]
		private bool m_isLeft;

		[SerializeField]
		private su m_bone;

		[SerializeField]
		private sv m_skin;

		[SerializeField]
		private DefaultMuscle m_muscle;

		[SerializeField]
		private rv m_rotationProcessor;

		protected override HumanoidLimbHoldGroupType? xgs => null;

		public override string hgh()
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

		protected override vi hhd()
		{
			return null;
		}

		protected override bab hgr()
		{
			return null;
		}

		private static bab hky()
		{
			return null;
		}

		private static bab hkz()
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
