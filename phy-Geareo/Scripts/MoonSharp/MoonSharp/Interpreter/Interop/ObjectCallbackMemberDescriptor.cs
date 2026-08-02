using System;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class ObjectCallbackMemberDescriptor : FunctionMemberDescriptorBase
	{
		private Func<object, ScriptExecutionContext, CallbackArguments, object> m_CallbackFunc;

		public ObjectCallbackMemberDescriptor(string funcName)
		{
		}

		public ObjectCallbackMemberDescriptor(string funcName, Func<object, ScriptExecutionContext, CallbackArguments, object> callBack)
		{
		}

		public ObjectCallbackMemberDescriptor(string funcName, Func<object, ScriptExecutionContext, CallbackArguments, object> callBack, ParameterDescriptor[] parameters)
		{
		}

		public override DynValue Execute(Script script, object obj, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}
	}
}
