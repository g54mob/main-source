using System;
using UnityEngine;

namespace LaundryBear
{
	[Serializable]
	public class SerializableSystemType
	{
		[SerializeField]
		private string m_Name;

		[SerializeField]
		private string m_AssemblyQualifiedName;

		[SerializeField]
		private string m_AssemblyName;

		private Type m_SystemType;

		public string Name => m_Name;

		public string AssemblyQualifiedName => m_AssemblyQualifiedName;

		public string AssemblyName => m_AssemblyName;

		public Type SystemType
		{
			get
			{
				if (m_SystemType == null)
				{
					GetSystemType();
				}
				return m_SystemType;
			}
		}

		private void GetSystemType()
		{
			m_SystemType = Type.GetType(m_AssemblyQualifiedName);
		}

		public SerializableSystemType(Type _SystemType)
		{
			m_SystemType = _SystemType;
			m_Name = _SystemType.Name;
			m_AssemblyQualifiedName = _SystemType.AssemblyQualifiedName;
			m_AssemblyName = _SystemType.Assembly.FullName;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is SerializableSystemType serializableSystemType))
			{
				return false;
			}
			return Equals(serializableSystemType);
		}

		public bool Equals(SerializableSystemType _Object)
		{
			return _Object.SystemType.Equals(SystemType);
		}

		public override int GetHashCode()
		{
			return SystemType.GetHashCode();
		}

		public static bool operator ==(SerializableSystemType a, SerializableSystemType b)
		{
			if ((object)a == b)
			{
				return true;
			}
			if ((object)a == null || (object)b == null)
			{
				return false;
			}
			return a.Equals(b);
		}

		public static bool operator !=(SerializableSystemType a, SerializableSystemType b)
		{
			return !(a == b);
		}
	}
}
