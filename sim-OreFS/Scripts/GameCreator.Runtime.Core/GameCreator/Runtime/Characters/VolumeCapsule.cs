using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Capsule")]
	[Category("Capsule")]
	[Image(typeof(IconCapsuleSolid), ColorTheme.Type.Green)]
	[Description("Use a Capsule volume")]
	public class VolumeCapsule : TVolume
	{
		public enum Direction
		{
			AxisX = 0,
			AxisY = 1,
			AxisZ = 2
		}

		private const int SEGMENTS = 24;

		[SerializeField]
		private Vector3 m_Center = Vector3.zero;

		[SerializeField]
		private float m_Height = 1f;

		[SerializeField]
		private float m_Radius = 0.1f;

		[SerializeField]
		private Direction m_Direction;

		public VolumeCapsule()
		{
		}

		public VolumeCapsule(HumanBodyBones humanBone, float weight, IJoint joint, Vector3 center, float height, float radius, Direction direction)
			: base(humanBone, weight, joint)
		{
			m_Center = center;
			m_Height = height;
			m_Radius = radius;
			m_Direction = direction;
		}

		protected override Collider SetupCollider(GameObject bone, Skeleton skeleton)
		{
			CapsuleCollider capsuleCollider = bone.Get<CapsuleCollider>();
			if (capsuleCollider == null)
			{
				capsuleCollider = bone.Add<CapsuleCollider>();
			}
			capsuleCollider.enabled = false;
			capsuleCollider.center = m_Center;
			capsuleCollider.height = m_Height;
			capsuleCollider.radius = m_Radius;
			capsuleCollider.direction = (int)m_Direction;
			return capsuleCollider;
		}

		protected override void DrawGizmos(Transform bone, Volumes.Display display)
		{
			switch (display)
			{
			case Volumes.Display.Outline:
				GizmosExtension.CapsuleWire(bone.TransformPoint(m_Center), bone.rotation, m_Radius * GetBoneScale(bone), m_Height * GetBoneScale(bone), 24, (int)m_Direction);
				break;
			case Volumes.Display.Solid:
				GizmosExtension.Capsule(bone.TransformPoint(m_Center), bone.rotation, m_Radius * GetBoneScale(bone), m_Height * GetBoneScale(bone), 24, (int)m_Direction);
				break;
			}
		}
	}
}
