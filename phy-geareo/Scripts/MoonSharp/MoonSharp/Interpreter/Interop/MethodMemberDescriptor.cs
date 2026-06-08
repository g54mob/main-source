using System;
using System.Reflection;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class MethodMemberDescriptor : FunctionMemberDescriptorBase, IOptimizableDescriptor, IWireableDescriptor
	{
		private Func<object, object[], object> m_OptimizedFunc;

		private Action<object, object[]> m_OptimizedAction;

		private bool m_IsAction;

		private bool m_IsArrayCtor;

		public MethodBase MethodInfo { get; private set; }

		public InteropAccessMode AccessMode { get; private set; }

		public bool IsConstructor { get; private set; }

		public MethodMemberDescriptor(MethodBase methodBase, InteropAccessMode accessMode = InteropAccessMode.Default)
		{
		}

		public static MethodMemberDescriptor TryCreateIfVisible(MethodBase methodBase, InteropAccessMode accessMode, bool forceVisibility = false)
		{
			return null;
		}

		public static bool CheckMethodIsCompatible(MethodBase methodBase, bool throwException)
		{
			return false;
		}

		public override DynValue Execute(Script script, object obj, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}

		void IOptimizableDescriptor.Optimize()
		{
		}

		public void PrepareForWiring(Table t)
		{
		}
	}
}
