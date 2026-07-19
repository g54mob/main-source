using UnityEngine;

namespace UniHumanoid
{
	public class HumanPoseTransfer : MonoBehaviour
	{
		public enum HumanPoseTransferSourceType
		{
			None = 0,
			HumanPoseTransfer = 1,
			HumanPoseClip = 2
		}

		[SerializeField]
		public HumanPoseTransferSourceType SourceType;

		[SerializeField]
		public Avatar Avatar;

		[SerializeField]
		public HumanPoseTransfer Source;

		[SerializeField]
		public HumanPoseClip PoseClip;

		private HumanPoseHandler m_handler;

		private HumanPose m_pose;

		private int m_lastFrameCount = -1;

		public HumanPose CreatePose()
		{
			HumanPoseHandler humanPoseHandler = new HumanPoseHandler(Avatar, base.transform);
			HumanPose humanPose = default(HumanPose);
			humanPoseHandler.GetHumanPose(ref humanPose);
			return humanPose;
		}

		public void SetPose(HumanPose pose)
		{
			SetPose(Avatar, base.transform, pose);
		}

		public static void SetPose(Avatar avatar, Transform transform, HumanPose pose)
		{
			new HumanPoseHandler(avatar, transform).SetHumanPose(ref pose);
		}

		public static void SetTPose(Avatar avatar, Transform transform)
		{
			HumanPose pose = Resources.Load<HumanPoseClip>("T-Pose.pose").GetPose();
			SetPose(avatar, transform, pose);
		}

		private void Reset()
		{
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				Avatar = component.avatar;
			}
		}

		[ContextMenu("Set T-Pose")]
		private void SetTPose()
		{
			if (!(Avatar == null))
			{
				SetTPose(Avatar, base.transform);
			}
		}

		public void OnEnable()
		{
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				Avatar = component.avatar;
			}
			Setup();
		}

		public void Setup()
		{
			if (!(Avatar == null))
			{
				m_handler = new HumanPoseHandler(Avatar, base.transform);
			}
		}

		public bool GetPose(int frameCount, ref HumanPose pose)
		{
			if (PoseClip != null)
			{
				pose = PoseClip.GetPose();
				return true;
			}
			if (m_handler == null)
			{
				pose = m_pose;
				return false;
			}
			if (frameCount != m_lastFrameCount)
			{
				m_handler.GetHumanPose(ref m_pose);
				m_lastFrameCount = frameCount;
			}
			pose = m_pose;
			return true;
		}

		private void Update()
		{
			switch (SourceType)
			{
			case HumanPoseTransferSourceType.HumanPoseTransfer:
				if (Source != null && m_handler != null && Source.GetPose(Time.frameCount, ref m_pose))
				{
					m_handler.SetHumanPose(ref m_pose);
				}
				break;
			case HumanPoseTransferSourceType.HumanPoseClip:
				if (PoseClip != null)
				{
					HumanPose humanPose = PoseClip.GetPose();
					m_handler.SetHumanPose(ref humanPose);
				}
				break;
			case HumanPoseTransferSourceType.None:
				break;
			}
		}
	}
}
