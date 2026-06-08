using System;
using System.Reflection;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class FieldMemberDescriptor : IMemberDescriptor, IOptimizableDescriptor, IWireableDescriptor
	{
		private object m_ConstValue;

		private Func<object, object> m_OptimizedGetter;

		public FieldInfo FieldInfo { get; private set; }

		public InteropAccessMode AccessMode { get; private set; }

		public bool IsStatic { get; private set; }

		public string Name { get; private set; }

		public bool IsConst { get; private set; }

		public bool IsReadonly { get; private set; }

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		public static FieldMemberDescriptor TryCreateIfVisible(FieldInfo fi, InteropAccessMode accessMode)
		{
			return null;
		}

		public FieldMemberDescriptor(FieldInfo fi, InteropAccessMode accessMode)
		{
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		internal void OptimizeGetter()
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
