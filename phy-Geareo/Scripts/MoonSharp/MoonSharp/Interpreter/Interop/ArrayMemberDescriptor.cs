using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class ArrayMemberDescriptor : ObjectCallbackMemberDescriptor, IWireableDescriptor
	{
		private bool m_IsSetter;

		public ArrayMemberDescriptor(string name, bool isSetter, ParameterDescriptor[] indexerParams)
			: base(null)
		{
		}

		public ArrayMemberDescriptor(string name, bool isSetter)
			: base(null)
		{
		}

		public void PrepareForWiring(Table t)
		{
		}

		private static int[] BuildArrayIndices(CallbackArguments args, int count)
		{
			return null;
		}

		private static object ArrayIndexerSet(object arrayObj, ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		private static object ArrayIndexerGet(object arrayObj, ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}
	}
}
