using System;
using System.Reflection;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TReflectionProperty<T> : TReflectionMember<T>
	{
		private Func<T> m_GetCache;

		private Action<T> m_SetCache;

		public override T Value
		{
			get
			{
				Setup();
				if (m_GetCache == null)
				{
					return default(T);
				}
				object obj = m_GetCache();
				if (obj is T)
				{
					return (T)obj;
				}
				return default(T);
			}
			set
			{
				Setup();
				m_SetCache?.Invoke(value);
			}
		}

		private void Setup()
		{
			if (!(m_Component == null) && m_GetCache == null && m_SetCache == null)
			{
				PropertyInfo property = m_Component.GetType().GetProperty(m_Member, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (!(property == null))
				{
					m_GetCache = (Func<T>)(property.GetGetMethod()?.CreateDelegate(typeof(Func<T>), m_Component));
					m_SetCache = (Action<T>)(property.GetSetMethod()?.CreateDelegate(typeof(Action<T>), m_Component));
				}
			}
		}
	}
}
