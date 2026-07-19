using UnityEngine;
using UnityEngine.Serialization;

namespace UniHumanoid
{
	public class HandRig : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animator;

		[FormerlySerializedAs("LeftStrech")]
		[SerializeField]
		[Range(-1f, 1f)]
		public float LeftStretch;

		[SerializeField]
		[Range(-1f, 1f)]
		public float LeftSpread;

		[FormerlySerializedAs("RightStrech")]
		[SerializeField]
		[Range(-1f, 1f)]
		public float RightStretch;

		[SerializeField]
		[Range(-1f, 1f)]
		public float RightSpread;

		private HumanPoseHandler m_handler;

		private HandPoseModifier m_updater;

		private HandPoseModifier.HandPose m_leftHand = new HandPoseModifier.HandPose();

		private HandPoseModifier.HandPose m_rightHand = new HandPoseModifier.HandPose();

		private HumanPose m_pose;

		public Animator Animator => m_animator;

		private void Reset()
		{
			m_animator = GetComponent<Animator>();
		}

		public static HumanPoseHandler GetHandler(Animator animator)
		{
			if (animator == null)
			{
				return null;
			}
			if (animator.avatar == null)
			{
				return null;
			}
			if (!animator.avatar.isValid || !animator.avatar.isHuman)
			{
				return null;
			}
			return new HumanPoseHandler(animator.avatar, animator.transform);
		}

		private void Awake()
		{
			m_handler = GetHandler(m_animator);
			if (m_handler == null)
			{
				base.enabled = false;
			}
			else
			{
				m_updater = new HandPoseModifier();
			}
		}

		private void Update()
		{
			m_leftHand.ThumbStretch = LeftStretch;
			m_leftHand.ThumbSpread = LeftSpread;
			m_leftHand.IndexStretch = LeftStretch;
			m_leftHand.IndexSpread = LeftSpread;
			m_leftHand.MiddleStretch = LeftStretch;
			m_leftHand.MiddleSpread = LeftSpread;
			m_leftHand.RingStretch = LeftStretch;
			m_leftHand.RingSpread = LeftSpread;
			m_leftHand.LittleStretch = LeftStretch;
			m_leftHand.LittleSpread = LeftSpread;
			m_rightHand.ThumbStretch = RightStretch;
			m_rightHand.ThumbSpread = RightSpread;
			m_rightHand.IndexStretch = RightStretch;
			m_rightHand.IndexSpread = RightSpread;
			m_rightHand.MiddleStretch = RightStretch;
			m_rightHand.MiddleSpread = RightSpread;
			m_rightHand.RingStretch = RightStretch;
			m_rightHand.RingSpread = RightSpread;
			m_rightHand.LittleStretch = RightStretch;
			m_rightHand.LittleSpread = RightSpread;
			m_updater.LeftHandPose = m_leftHand;
			m_updater.RightHandPose = m_rightHand;
			m_handler.GetHumanPose(ref m_pose);
			m_updater.Modify(ref m_pose);
			m_handler.SetHumanPose(ref m_pose);
		}
	}
}
