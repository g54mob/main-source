using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class DynValueMemberDescriptor : IMemberDescriptor, IWireableDescriptor
	{
		private DynValue m_Value;

		public bool IsStatic => false;

		public string Name { get; private set; }

		public MemberDescriptorAccess MemberAccess { get; private set; }

		public virtual DynValue Value => null;

		protected DynValueMemberDescriptor(string name, string serializedTableValue)
		{
		}

		protected DynValueMemberDescriptor(string name)
		{
		}

		public DynValueMemberDescriptor(string name, DynValue value)
		{
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		public void SetValue(Script script, object obj, DynValue value)
		{
		}

		public void PrepareForWiring(Table t)
		{
		}
	}
}
