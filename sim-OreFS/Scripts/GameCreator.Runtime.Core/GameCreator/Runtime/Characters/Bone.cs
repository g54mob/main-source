using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct Bone : IBone
	{
		private enum Type
		{
			None = 0,
			Human = 1,
			Path = 2
		}

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private HumanBodyBones m_Human;

		[SerializeField]
		private string m_Path;

		public Bone(HumanBodyBones humanBone)
		{
			m_Type = Type.Human;
			m_Human = humanBone;
			m_Path = string.Empty;
		}

		public Bone(string bonePath)
		{
			m_Type = Type.Path;
			m_Human = HumanBodyBones.Hips;
			m_Path = bonePath;
		}

		public static Bone CreateNone()
		{
			return new Bone
			{
				m_Type = Type.None
			};
		}

		public GameObject Get(Animator animator)
		{
			Transform transform = GetTransform(animator);
			if (!(transform != null))
			{
				return null;
			}
			return transform.gameObject;
		}

		public Transform GetTransform(Animator animator)
		{
			return m_Type switch
			{
				Type.None => null, 
				Type.Human => animator.GetBoneTransform(m_Human), 
				Type.Path => animator.transform.Find(m_Path), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public override string ToString()
		{
			return m_Type switch
			{
				Type.None => "(none)", 
				Type.Human => TextUtils.Humanize(m_Human.ToString()), 
				Type.Path => m_Path, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
