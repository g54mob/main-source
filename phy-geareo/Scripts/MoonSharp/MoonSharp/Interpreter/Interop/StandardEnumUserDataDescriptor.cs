using System;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class StandardEnumUserDataDescriptor : DispatchingUserDataDescriptor
	{
		private Func<object, ulong> m_EnumToULong;

		private Func<ulong, object> m_ULongToEnum;

		private Func<object, long> m_EnumToLong;

		private Func<long, object> m_LongToEnum;

		public Type UnderlyingType { get; private set; }

		public bool IsUnsigned { get; private set; }

		public bool IsFlags { get; private set; }

		public StandardEnumUserDataDescriptor(Type enumType, string friendlyName = null, string[] names = null, object[] values = null, Type underlyingType = null)
			: base(null)
		{
		}

		private void FillMemberList(string[] names, object[] values)
		{
		}

		private void AddEnumMethod(string name, DynValue dynValue)
		{
		}

		private long GetValueSigned(DynValue dv)
		{
			return 0L;
		}

		private ulong GetValueUnsigned(DynValue dv)
		{
			return 0uL;
		}

		private DynValue CreateValueSigned(long value)
		{
			return null;
		}

		private DynValue CreateValueUnsigned(ulong value)
		{
			return null;
		}

		private void CreateSignedConversionFunctions()
		{
		}

		private void CreateUnsignedConversionFunctions()
		{
		}

		private DynValue PerformBinaryOperationS(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<long, long, DynValue> operation)
		{
			return null;
		}

		private DynValue PerformBinaryOperationU(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<ulong, ulong, DynValue> operation)
		{
			return null;
		}

		private DynValue PerformBinaryOperationS(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<long, long, long> operation)
		{
			return null;
		}

		private DynValue PerformBinaryOperationU(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<ulong, ulong, ulong> operation)
		{
			return null;
		}

		private DynValue PerformUnaryOperationS(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<long, long> operation)
		{
			return null;
		}

		private DynValue PerformUnaryOperationU(string funcName, ScriptExecutionContext ctx, CallbackArguments args, Func<ulong, ulong> operation)
		{
			return null;
		}

		internal DynValue Callback_Or(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		internal DynValue Callback_And(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		internal DynValue Callback_Xor(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		internal DynValue Callback_BwNot(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		internal DynValue Callback_HasAll(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		internal DynValue Callback_HasAny(ScriptExecutionContext ctx, CallbackArguments args)
		{
			return null;
		}

		public override bool IsTypeCompatible(Type type, object obj)
		{
			return false;
		}

		public override DynValue MetaIndex(Script script, object obj, string metaname)
		{
			return null;
		}
	}
}
