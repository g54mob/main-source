using System;
using System.Collections.Generic;
using System.Reflection;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public abstract class FunctionMemberDescriptorBase : IOverloadableMemberDescriptor, IMemberDescriptor
	{
		public bool IsStatic { get; private set; }

		public string Name { get; private set; }

		public string SortDiscriminant { get; private set; }

		public ParameterDescriptor[] Parameters { get; private set; }

		public Type ExtensionMethodType { get; private set; }

		public Type VarArgsArrayType { get; private set; }

		public Type VarArgsElementType { get; private set; }

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		protected void Initialize(string funcName, bool isStatic, ParameterDescriptor[] parameters, bool isExtensionMethod)
		{
		}

		public Func<ScriptExecutionContext, CallbackArguments, DynValue> GetCallback(Script script, object obj = null)
		{
			return null;
		}

		public CallbackFunction GetCallbackFunction(Script script, object obj = null)
		{
			return null;
		}

		public DynValue GetCallbackAsDynValue(Script script, object obj = null)
		{
			return null;
		}

		public static DynValue CreateCallbackDynValue(Script script, MethodInfo mi, object obj = null)
		{
			return null;
		}

		protected virtual object[] BuildArgumentList(Script script, object obj, ScriptExecutionContext context, CallbackArguments args, out List<int> outParams)
		{
			outParams = null;
			return null;
		}

		protected static DynValue BuildReturnValue(Script script, List<int> outParams, object[] pars, object retv)
		{
			return null;
		}

		public abstract DynValue Execute(Script script, object obj, ScriptExecutionContext context, CallbackArguments args);

		public virtual DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		public virtual void SetValue(Script script, object obj, DynValue v)
		{
		}
	}
}
