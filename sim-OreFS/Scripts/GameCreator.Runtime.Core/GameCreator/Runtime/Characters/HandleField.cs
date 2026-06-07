using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class HandleField
	{
		public enum Type
		{
			Value = 0,
			Handle = 1
		}

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.RightHand);

		[SerializeField]
		private Vector3 m_LocalPosition = Vector3.zero;

		[SerializeField]
		private Vector3 m_LocalRotation = Vector3.zero;

		[SerializeField]
		private Handle m_Handle;

		public HandleField()
		{
		}

		public HandleField(HumanBodyBones humanBone)
		{
			m_Type = Type.Value;
			m_Bone = new Bone(humanBone);
		}

		public HandleField(string bonePath)
		{
			m_Type = Type.Value;
			m_Bone = new Bone(bonePath);
		}

		public HandleField(Handle handle)
		{
			m_Type = Type.Handle;
			m_Handle = handle;
		}

		public HandleResult Get(Args args)
		{
			return m_Type switch
			{
				Type.Value => new HandleResult(m_Bone, m_LocalPosition, Quaternion.Euler(m_LocalRotation)), 
				Type.Handle => (m_Handle != null) ? m_Handle.Get(args) : HandleResult.None, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public override string ToString()
		{
			return m_Type switch
			{
				Type.Value => m_Bone.ToString(), 
				Type.Handle => (m_Handle != null) ? m_Handle.ToString() : "(none)", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
