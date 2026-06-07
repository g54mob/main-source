using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TSkin<T> : Skin where T : class
	{
		[SerializeReference]
		protected T m_Value;

		public T Value => m_Value;

		public bool HasValue => m_Value != null;
	}
}
