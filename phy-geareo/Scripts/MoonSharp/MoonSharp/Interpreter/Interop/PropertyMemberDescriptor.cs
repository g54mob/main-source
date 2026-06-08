using System;
using System.Reflection;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class PropertyMemberDescriptor : IMemberDescriptor, IOptimizableDescriptor, IWireableDescriptor
	{
		private MethodInfo m_Getter;

		private MethodInfo m_Setter;

		private Func<object, object> m_OptimizedGetter;

		private Action<object, object> m_OptimizedSetter;

		public PropertyInfo PropertyInfo { get; private set; }

		public InteropAccessMode AccessMode { get; private set; }

		public bool IsStatic { get; private set; }

		public string Name { get; private set; }

		public bool CanRead => false;

		public bool CanWrite => false;

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		public static PropertyMemberDescriptor TryCreateIfVisible(PropertyInfo pi, InteropAccessMode accessMode)
		{
			return null;
		}

		private static PropertyMemberDescriptor TryCreate(PropertyInfo pi, InteropAccessMode accessMode, MethodInfo getter, MethodInfo setter)
		{
			return null;
		}

		public PropertyMemberDescriptor(PropertyInfo pi, InteropAccessMode accessMode)
		{
		}

		public PropertyMemberDescriptor(PropertyInfo pi, InteropAccessMode accessMode, MethodInfo getter, MethodInfo setter)
		{
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		internal void OptimizeGetter()
		{
		}

		internal void OptimizeSetter()
		{
		}

		public void SetValue(Script script, object obj, DynValue v)
		{
		}

		void IOptimizableDescriptor.Optimize()
		{
		}

		public void PrepareForWiring(Table t)
		{
		}
	}
}
