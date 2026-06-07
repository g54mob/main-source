using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Munition : IMunition, ICloneable
	{
		[SerializeField]
		private int m_Id;

		[SerializeReference]
		private TMunitionValue m_Value;

		public int Id => m_Id;

		public TMunitionValue Value => m_Value;

		public Munition()
		{
		}

		public Munition(int id, TMunitionValue value)
		{
			m_Id = id;
			m_Value = value;
		}

		public object Clone()
		{
			return new Munition(m_Id, m_Value.Clone() as TMunitionValue);
		}
	}
}
