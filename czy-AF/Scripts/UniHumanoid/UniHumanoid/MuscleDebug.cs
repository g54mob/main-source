using System;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	public class MuscleDebug : MonoBehaviour
	{
		[Serializable]
		public struct Muscle
		{
			public int Index;

			public string Name;

			public float Value;
		}

		private HumanPoseHandler m_handler;

		public HumanPose m_pose;

		public Vector3 BodyPosition;

		public Muscle[] Muscles;

		private Avatar GetAvatar()
		{
			Animator component = GetComponent<Animator>();
			if (component != null && component.avatar != null)
			{
				return component.avatar;
			}
			HumanPoseTransfer component2 = GetComponent<HumanPoseTransfer>();
			if (component2 != null && component2.Avatar != null)
			{
				return component2.Avatar;
			}
			return null;
		}

		private void OnEnable()
		{
			Avatar avatar = GetAvatar();
			if (avatar == null)
			{
				base.enabled = false;
				return;
			}
			m_handler = new HumanPoseHandler(avatar, base.transform);
			Muscles = HumanTrait.MuscleName.Select((string x, int i) => new Muscle
			{
				Index = i,
				Name = x
			}).ToArray();
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
			m_handler.GetHumanPose(ref m_pose);
			BodyPosition = m_pose.bodyPosition;
			for (int i = 0; i < m_pose.muscles.Length; i++)
			{
				Muscles[i].Value = m_pose.muscles[i];
			}
		}
	}
}
