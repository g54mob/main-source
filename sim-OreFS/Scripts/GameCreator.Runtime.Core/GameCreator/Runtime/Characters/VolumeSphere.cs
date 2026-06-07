using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Sphere")]
	[Category("Sphere")]
	[Image(typeof(IconSphereSolid), ColorTheme.Type.Green)]
	[Description("Use a Spherical volume")]
	public class VolumeSphere : TVolume
	{
		[SerializeField]
		private Vector3 m_Center = Vector3.zero;

		[SerializeField]
		private float m_Radius = 0.1f;

		public VolumeSphere()
		{
		}

		public VolumeSphere(HumanBodyBones humanBone, float weight, IJoint joint, Vector3 center, float radius)
			: base(humanBone, weight, joint)
		{
			m_Center = center;
			m_Radius = radius;
		}

		protected override Collider SetupCollider(GameObject bone, Skeleton skeleton)
		{
			SphereCollider sphereCollider = bone.Get<SphereCollider>();
			if (sphereCollider == null)
			{
				sphereCollider = bone.Add<SphereCollider>();
			}
			sphereCollider.enabled = false;
			sphereCollider.center = m_Center;
			sphereCollider.radius = m_Radius;
			return sphereCollider;
		}

		protected override void DrawGizmos(Transform bone, Volumes.Display display)
		{
			switch (display)
			{
			case Volumes.Display.Outline:
				GizmosExtension.OctahedronWire(bone.TransformPoint(m_Center), bone.rotation, m_Radius * GetBoneScale(bone));
				break;
			case Volumes.Display.Solid:
				GizmosExtension.Octahedron(bone.TransformPoint(m_Center), bone.rotation, m_Radius * GetBoneScale(bone));
				break;
			}
		}
	}
}
