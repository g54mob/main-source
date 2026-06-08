using System;
using UnityEngine;

namespace LaundryBear.EditorAttributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class AssignableInterfaceAttribute : PropertyAttribute
	{
		private Type m_type;

		public Type Type => m_type;

		public AssignableInterfaceAttribute()
		{
		}

		public AssignableInterfaceAttribute(Type type)
		{
			m_type = type;
		}
	}
}
