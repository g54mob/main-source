using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	public class SerializableType : IEquatable<SerializableType>
	{
		[SerializeField]
		private string assemblyQualifiedName;

		private Type cachedType;

		public Type ToType => null;

		public string AssemblyQualifiedName => null;

		public SerializableType(Type type)
		{
		}

		public SerializableType(string assemblyQualifiedName)
		{
		}

		public static implicit operator Type(SerializableType type)
		{
			return null;
		}

		public static explicit operator SerializableType(Type type)
		{
			return null;
		}

		public static bool operator ==(SerializableType obj1, SerializableType obj2)
		{
			return false;
		}

		public static bool operator !=(SerializableType obj1, SerializableType obj2)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(SerializableType other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
