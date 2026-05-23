using System.Collections.Generic;
using LVA.Organs.Variants.Human;
using UnityEngine;

namespace LVA.Limbs.Variants
{
	public class Head : HumanLimb
	{
		[SerializeField]
		private sr m_skull;

		[SerializeField]
		private sb m_backbone;

		[SerializeField]
		private sd m_brain;

		[SerializeField]
		private sh m_leftEye;

		[SerializeField]
		private sh m_rightEye;

		[SerializeField]
		private DefaultMuscle m_muscle;

		[SerializeField]
		private sv m_skin;

		[SerializeField]
		private rv m_rotationModeProcessor;

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

		protected override wx hgs()
		{
			return null;
		}

		protected override void hgp()
		{
		}
	}
}
