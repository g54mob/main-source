using System;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop.StandardDescriptors.HardwiredDescriptors
{
	public abstract class HardwiredMemberDescriptor : IMemberDescriptor
	{
		public Type MemberType { get; private set; }

		public bool IsStatic { get; private set; }

		public string Name { get; private set; }

		public MemberDescriptorAccess MemberAccess { get; private set; }

		protected HardwiredMemberDescriptor(Type memberType, string name, bool isStatic, MemberDescriptorAccess access)
		{
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		public void SetValue(Script script, object obj, DynValue value)
		{
		}

		protected virtual object GetValueImpl(Script script, object obj)
		{
			return null;
		}

		protected virtual void SetValueImpl(Script script, object obj, object value)
		{
		}
	}
}
