using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	public readonly struct LookToTransform : ILookTo
	{
		[NonSerialized]
		private readonly Transform m_Transform;

		[NonSerialized]
		private readonly Character m_Character;

		[NonSerialized]
		private readonly Vector3 m_Offset;

		[field: NonSerialized]
		public int Layer { get; }

		public bool Exists => m_Transform != null;

		public Vector3 Position
		{
			get
			{
				Vector3 vector = m_Transform.TransformDirection(m_Offset);
				if (!(m_Character != null))
				{
					return m_Transform.position + vector;
				}
				return m_Character.Eyes + vector;
			}
		}

		public GameObject Target
		{
			get
			{
				if (!(m_Transform != null))
				{
					return null;
				}
				return m_Transform.gameObject;
			}
		}

		public LookToTransform(int layer, Transform transform, Vector3 offset)
		{
			Layer = layer;
			m_Transform = transform;
			m_Character = ((transform != null) ? transform.Get<Character>() : null);
			m_Offset = offset;
		}
	}
}
