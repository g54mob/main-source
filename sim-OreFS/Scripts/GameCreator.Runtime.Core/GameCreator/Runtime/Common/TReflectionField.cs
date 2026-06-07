using System;
using System.Reflection;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TReflectionField<T> : TReflectionMember<T>
	{
		public override T Value
		{
			get
			{
				if (m_Component == null)
				{
					return default(T);
				}
				FieldInfo field = m_Component.GetType().GetField(m_Member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field == null)
				{
					return default(T);
				}
				object value = field.GetValue(m_Component);
				if (value is T)
				{
					return (T)value;
				}
				return default(T);
			}
			set
			{
				if (!(m_Component == null))
				{
					FieldInfo field = m_Component.GetType().GetField(m_Member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (field != null)
					{
						field.SetValue(m_Component, value);
					}
				}
			}
		}
	}
}
