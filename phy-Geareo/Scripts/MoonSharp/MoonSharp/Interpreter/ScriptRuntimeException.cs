using System;
using MoonSharp.Interpreter.Interop;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter
{
	[Serializable]
	public class ScriptRuntimeException : InterpreterException
	{
		public ScriptRuntimeException(Exception ex)
			: base((Exception)null, (string)null)
		{
		}

		public ScriptRuntimeException(ScriptRuntimeException ex)
			: base((Exception)null, (string)null)
		{
		}

		public ScriptRuntimeException(string message)
			: base((Exception)null, (string)null)
		{
		}

		public ScriptRuntimeException(string format, params object[] args)
			: base((Exception)null, (string)null)
		{
		}

		public static ScriptRuntimeException ArithmeticOnNonNumber(DynValue l, DynValue r = null)
		{
			return null;
		}

		public static ScriptRuntimeException ConcatOnNonString(DynValue l, DynValue r)
		{
			return null;
		}

		public static ScriptRuntimeException LenOnInvalidType(DynValue r)
		{
			return null;
		}

		public static ScriptRuntimeException CompareInvalidType(DynValue l, DynValue r)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgument(int argNum, string funcName, string message)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgumentUserData(int argNum, string funcName, Type expected, object got, bool allowNil)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgument(int argNum, string funcName, DataType expected, DataType got, bool allowNil)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgument(int argNum, string funcName, string expected, string got, bool allowNil)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgumentNoValue(int argNum, string funcName, DataType expected)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgumentIndexOutOfRange(string funcName, int argNum)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgumentNoNegativeNumbers(int argNum, string funcName)
		{
			return null;
		}

		public static ScriptRuntimeException BadArgumentValueExpected(int argNum, string funcName)
		{
			return null;
		}

		public static ScriptRuntimeException IndexType(DynValue obj)
		{
			return null;
		}

		public static ScriptRuntimeException LoopInIndex()
		{
			return null;
		}

		public static ScriptRuntimeException LoopInNewIndex()
		{
			return null;
		}

		public static ScriptRuntimeException LoopInCall()
		{
			return null;
		}

		public static ScriptRuntimeException TableIndexIsNil()
		{
			return null;
		}

		public static ScriptRuntimeException TableIndexIsNaN()
		{
			return null;
		}

		public static ScriptRuntimeException ConvertToNumberFailed(int stage)
		{
			return null;
		}

		public static ScriptRuntimeException ConvertObjectFailed(object obj)
		{
			return null;
		}

		public static ScriptRuntimeException ConvertObjectFailed(DataType t)
		{
			return null;
		}

		public static ScriptRuntimeException ConvertObjectFailed(DataType t, Type t2)
		{
			return null;
		}

		public static ScriptRuntimeException UserDataArgumentTypeMismatch(DataType t, Type clrType)
		{
			return null;
		}

		public static ScriptRuntimeException UserDataMissingField(string typename, string fieldname)
		{
			return null;
		}

		public static ScriptRuntimeException CannotResumeNotSuspended(CoroutineState state)
		{
			return null;
		}

		public static ScriptRuntimeException CannotYield()
		{
			return null;
		}

		public static ScriptRuntimeException CannotYieldMain()
		{
			return null;
		}

		public static ScriptRuntimeException AttemptToCallNonFunc(DataType type, string debugText = null)
		{
			return null;
		}

		public static ScriptRuntimeException AccessInstanceMemberOnStatics(IMemberDescriptor desc)
		{
			return null;
		}

		public static ScriptRuntimeException AccessInstanceMemberOnStatics(IUserDataDescriptor typeDescr, IMemberDescriptor desc)
		{
			return null;
		}

		public override void Rethrow()
		{
		}
	}
}
