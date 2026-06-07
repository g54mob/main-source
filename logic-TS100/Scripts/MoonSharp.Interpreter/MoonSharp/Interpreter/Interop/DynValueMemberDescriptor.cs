using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class DynValueMemberDescriptor : IMemberDescriptor
	{
		public bool IsStatic
		{
			get
			{
				return true;
			}
		}

		public string Name { get; private set; }

		public MemberDescriptorAccess MemberAccess { get; private set; }

		public DynValue Value { get; private set; }

		public DynValueMemberDescriptor(string name, DynValue value)
		{
			Value = value;
			Name = name;
			if (value.Type == DataType.ClrFunction)
			{
				MemberAccess = MemberDescriptorAccess.CanExecute;
			}
			else
			{
				MemberAccess = MemberDescriptorAccess.CanRead;
			}
		}

		public DynValue GetValue(Script script, object obj)
		{
			return Value;
		}

		public void SetValue(Script script, object obj, DynValue value)
		{
			throw new ScriptRuntimeException("userdata '{0}' cannot be written to.", Name);
		}
	}
}
