using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Box")]
	[Category("Box")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Green)]
	[Description("Use a Cubic volume")]
	public class VolumeBox : TVolume
	{
		[SerializeField]
		private Vector3 m_Center = Vector3.zero;

		[SerializeField]
		private Vector3 m_Size = Vector3.zero;

		public VolumeBox()
		{
		}

		public VolumeBox(HumanBodyBones humanBone, float weight, IJoint joint, Vector3 center, Vector3 size)
			: base(humanBone, weight, joint)
		{
			m_Center = center;
			m_Size = size;
		}

		protected override Collider SetupCollider(GameObject bone, Skeleton skeleton)
		{
			BoxCollider boxCollider = bone.Get<BoxCollider>();
			if (boxCollider == null)
			{
				boxCollider = bone.Add<BoxCollider>();
			}
			boxCollider.enabled = false;
			boxCollider.center = m_Center;
			boxCollider.size = m_Size;
			return boxCollider;
		}

		protected override void DrawGizmos(Transform bone, Volumes.Display display)
		{
			switch (display)
			{
			case Volumes.Display.Outline:
				GizmosExtension.BoxWire(bone.TransformPoint(m_Center), bone.rotation, Vector3.Scale(m_Size, bone.lossyScale));
				break;
			case Volumes.Display.Solid:
				GizmosExtension.Box(bone.TransformPoint(m_Center), bone.rotation, Vector3.Scale(m_Size, bone.lossyScale));
				break;
			}
		}
	}
}
