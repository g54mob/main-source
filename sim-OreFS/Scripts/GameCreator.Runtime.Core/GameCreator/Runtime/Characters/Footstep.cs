using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Footstep : TPolymorphicItem<Footstep>
	{
		[SerializeField]
		private Bone m_Bone;

		public Bone Bone => m_Bone;

		public Footstep()
		{
		}

		public Footstep(HumanBodyBones bone)
		{
			m_Bone = new Bone(bone);
		}

		public Footstep(string bonePath)
		{
			m_Bone = new Bone(bonePath);
		}
	}
}
