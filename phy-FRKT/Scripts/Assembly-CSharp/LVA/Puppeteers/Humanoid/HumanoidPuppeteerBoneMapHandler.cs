using System.Collections.Generic;
using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	public class HumanoidPuppeteerBoneMapHandler : MonoBehaviour
	{
		[SerializeField]
		private Transform m_root;

		[Space(10f)]
		[Space(5f)]
		[SerializeField]
		private Transform m_pelvis;

		[SerializeField]
		private Transform m_spine1;

		[SerializeField]
		private Transform m_spine2;

		[SerializeField]
		private Transform m_head;

		[Space(8f)]
		[Space(6f)]
		[SerializeField]
		private Transform m_leftLeg;

		[SerializeField]
		private Transform m_leftKnee;

		[SerializeField]
		private Transform m_leftFoot;

		[Space(6f)]
		[SerializeField]
		private Transform m_rightLeg;

		[SerializeField]
		private Transform m_rightKnee;

		[SerializeField]
		private Transform m_rightFoot;

		[Space(8f)]
		[Space(5f)]
		[SerializeField]
		private Transform m_leftArm;

		[SerializeField]
		private Transform m_leftForearm;

		[SerializeField]
		private Transform m_leftHand;

		[Space(6f)]
		[SerializeField]
		private Transform m_rightArm;

		[SerializeField]
		private Transform m_rightForearm;

		[SerializeField]
		private Transform m_rightHand;

		private Dictionary<HumanoidPuppeteerBoneType, Transform> rjm;

		private bool rjn;

		private const bool rjo = true;

		public IReadOnlyDictionary<HumanoidPuppeteerBoneType, Transform> xeb => null;

		public void gjz()
		{
		}

		private void gka(Dictionary<HumanoidPuppeteerBoneType, Transform> a)
		{
		}
	}
}
