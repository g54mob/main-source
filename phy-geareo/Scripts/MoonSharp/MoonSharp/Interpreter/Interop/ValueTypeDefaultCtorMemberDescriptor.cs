using System;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class ValueTypeDefaultCtorMemberDescriptor : IOverloadableMemberDescriptor, IMemberDescriptor, IWireableDescriptor
	{
		public bool IsStatic => false;

		public string Name { get; private set; }

		public Type ValueTypeDefaultCtor { get; private set; }

		public ParameterDescriptor[] Parameters { get; private set; }

		public Type ExtensionMethodType => null;

		public Type VarArgsArrayType => null;

		public Type VarArgsElementType => null;

		public string SortDiscriminant => null;

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		public ValueTypeDefaultCtorMemberDescriptor(Type valueType)
		{
		}

		public DynValue Execute(Script script, object obj, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
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
