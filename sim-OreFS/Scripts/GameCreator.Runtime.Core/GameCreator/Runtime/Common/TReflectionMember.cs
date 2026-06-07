using System;
using System.Reflection;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TReflectionMember<T> : IReflectionMember
	{
		protected const BindingFlags BINDINGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		[SerializeField]
		protected Component m_Component;

		[SerializeField]
		protected string m_Member;

		public Type Type => typeof(T);

		public abstract T Value { get; set; }

		public override string ToString()
		{
			if (!(m_Component != null))
			{
				return "(none)";
			}
			return m_Component.gameObject.name + "[" + m_Member + "]";
		}
	}
}
