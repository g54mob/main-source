using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal class MetaMember
	{
		private MethodInfo getMethod;

		private MethodInfo setMethod;

		public string Name { get; private set; }

		public string MemberName { get; private set; }

		public bool IsProperty => false;

		public bool IsField => false;

		public bool IsWritable { get; private set; }

		public bool IsReadable { get; private set; }

		public Type Type { get; private set; }

		public FieldInfo FieldInfo { get; private set; }

		public PropertyInfo PropertyInfo { get; private set; }

		public MethodInfo ShouldSerializeMethodInfo { get; private set; }

		protected MetaMember(Type type, string name, string memberName, bool isWritable, bool isReadable)
		{
		}

		public MetaMember(FieldInfo info, string name, bool allowPrivate)
		{
		}

		public MetaMember(PropertyInfo info, string name, bool allowPrivate)
		{
		}

		private static MethodInfo GetShouldSerialize(MemberInfo info)
		{
			return null;
		}

		public T GetCustomAttribute<T>(bool inherit) where T : Attribute
		{
			return null;
		}

		public virtual void EmitLoadValue(ILGenerator il)
		{
		}

		public virtual void EmitStoreValue(ILGenerator il)
		{
		}
	}
}
