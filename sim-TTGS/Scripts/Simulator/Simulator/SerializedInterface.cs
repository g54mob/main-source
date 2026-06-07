using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SerializedInterface<T> : IComparer<SerializedInterface<T>> where T : class
	{
		[SerializeField]
		private Component m_component;

		private T m_interfaceInstance;

		public Component Component
		{
			get
			{
				return m_component;
			}
			set
			{
				m_component = value;
				DeserializeInterfaceValue();
			}
		}

		public T Interface
		{
			get
			{
				if (m_interfaceInstance == null)
				{
					DeserializeInterfaceValue();
				}
				return m_interfaceInstance;
			}
			set
			{
				m_interfaceInstance = value;
				m_component = value as Component;
			}
		}

		public static bool operator ==(SerializedInterface<T> a, SerializedInterface<T> b)
		{
			return a?.Equals(b) ?? ((object)b == null);
		}

		public static bool operator !=(SerializedInterface<T> a, SerializedInterface<T> b)
		{
			return !(a == b);
		}

		public static implicit operator T(SerializedInterface<T> @interface)
		{
			return @interface.Interface;
		}

		public static implicit operator Component(SerializedInterface<T> @interface)
		{
			return @interface.m_component;
		}

		public override string ToString()
		{
			if (m_interfaceInstance == null)
			{
				return "[Null Interface]";
			}
			return m_interfaceInstance.ToString();
		}

		public override bool Equals(object @object)
		{
			if (@object is SerializedInterface<T> serializedInterface)
			{
				return Equals(serializedInterface);
			}
			return base.Equals(@object);
		}

		int IComparer<SerializedInterface<T>>.Compare(SerializedInterface<T> a, SerializedInterface<T> b)
		{
			if (a == null && b == null)
			{
				return 0;
			}
			if (a == null)
			{
				return -1;
			}
			if (b == null)
			{
				return 1;
			}
			return string.Compare(a.Interface.GetType().Name, b.Interface.GetType().Name, StringComparison.InvariantCulture);
		}

		private void DeserializeInterfaceValue()
		{
			if (m_component != null)
			{
				if (m_component is T val)
				{
					Interface = val;
					return;
				}
				Debug.LogError("The interface '" + typeof(T).FullName + "' component could not be found on this object!");
			}
			Interface = null;
		}

		public bool Equals(SerializedInterface<T> @interface)
		{
			if ((object)@interface != null)
			{
				return @interface.Interface == Interface;
			}
			return false;
		}
	}
}
