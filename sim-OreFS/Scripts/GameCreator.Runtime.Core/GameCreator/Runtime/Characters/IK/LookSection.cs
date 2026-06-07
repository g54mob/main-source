using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	public class LookSection
	{
		[SerializeField]
		private HumanBodyBones m_Bone;

		[SerializeField]
		private Vector3 m_Euler;

		[SerializeField]
		private float m_Weight;

		public HumanBodyBones Bone => m_Bone;

		public Quaternion Rotation => Quaternion.Euler(m_Euler);

		public float Weight => m_Weight;

		public bool IsValid => Transform != null;

		[field: NonSerialized]
		public Transform Transform { get; set; }

		public LookSection(HumanBodyBones bone, float weight)
		{
			m_Bone = bone;
			m_Euler = Vector3.zero;
			m_Weight = weight;
		}
	}
}
