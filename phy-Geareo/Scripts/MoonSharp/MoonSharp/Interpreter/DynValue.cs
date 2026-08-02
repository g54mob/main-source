using System;
using System.Text;

namespace MoonSharp.Interpreter
{
	public sealed class DynValue
	{
		private static int s_RefIDCounter;

		private int m_RefID;

		private int m_HashCode;

		private bool m_ReadOnly;

		private double m_Number;

		private object m_Object;

		private DataType m_Type;

		public int ReferenceID => 0;

		public DataType Type => default(DataType);

		public Closure Function => null;

		public double Number => 0.0;

		public DynValue[] Tuple => null;

		public Coroutine Coroutine => null;

		public Table Table => null;

		public bool Boolean => false;

		public string String => null;

		public CallbackFunction Callback => null;

		public TailCallData TailCallData => null;

		public YieldRequest YieldRequest => null;

		public UserData UserData => null;

		public bool ReadOnly => false;

		public static DynValue Void { get; private set; }

		public static DynValue Nil { get; private set; }

		public static DynValue True { get; private set; }

		public static DynValue False { get; private set; }

		public static DynValue NewNil()
		{
			return null;
		}

		public static DynValue NewBoolean(bool v)
		{
			return null;
		}

		public static DynValue NewNumber(double num)
		{
			return null;
		}

		public static DynValue NewString(string str)
		{
			return null;
		}

		public static DynValue NewString(StringBuilder sb)
		{
			return null;
		}

		public static DynValue NewString(string format, params object[] args)
		{
			return null;
		}

		public static DynValue NewCoroutine(Coroutine coroutine)
		{
			return null;
		}

		public static DynValue NewClosure(Closure function)
		{
			return null;
		}

		public static DynValue NewCallback(Func<ScriptExecutionContext, CallbackArguments, DynValue> callBack, string name = null)
		{
			return null;
		}

		public static DynValue NewCallback(CallbackFunction function)
		{
			return null;
		}

		public static DynValue NewTable(Table table)
		{
			return null;
		}

		public static DynValue NewPrimeTable()
		{
			return null;
		}

		public static DynValue NewTable(Script script)
		{
			return null;
		}

		public static DynValue NewTable(Script script, params DynValue[] arrayValues)
		{
			return null;
		}

		public static DynValue NewTailCallReq(DynValue tailFn, params DynValue[] args)
		{
			return null;
		}

		public static DynValue NewTailCallReq(TailCallData tailCallData)
		{
			return null;
		}

		public static DynValue NewYieldReq(DynValue[] args)
		{
			return null;
		}

		internal static DynValue NewForcedYieldReq()
		{
			return null;
		}

		public static DynValue NewTuple(params DynValue[] values)
		{
			return null;
		}

		public static DynValue NewTupleNested(params DynValue[] values)
		{
			return null;
		}

		public static DynValue NewUserData(UserData userData)
		{
			return null;
		}

		public DynValue AsReadOnly()
		{
			return null;
		}

		public DynValue Clone()
		{
			return null;
		}

		public DynValue Clone(bool readOnly)
		{
			return null;
		}

		public DynValue CloneAsWritable()
		{
			return null;
		}

		static DynValue()
		{
		}

		public string ToPrintString()
		{
			return null;
		}

		public string ToDebugPrintString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public string CastToString()
		{
			return null;
		}

		public double? CastToNumber()
		{
			return null;
		}

		public bool CastToBool()
		{
			return false;
		}

		public IScriptPrivateResource GetAsPrivateResource()
		{
			return null;
		}

		public DynValue ToScalar()
		{
			return null;
		}

		public void Assign(DynValue value)
		{
		}

		public DynValue GetLength()
		{
			return null;
		}

		public bool IsNil()
		{
			return false;
		}

		public bool IsNotNil()
		{
			return false;
		}

		public bool IsVoid()
		{
			return false;
		}

		public bool IsNotVoid()
		{
			return false;
		}

		public bool IsNilOrNan()
		{
			return false;
		}

		internal void AssignNumber(double num)
		{
		}

		public static DynValue FromObject(Script script, object obj)
		{
			return null;
		}

		public object ToObject()
		{
			return null;
		}

		public object ToObject(Type desiredType)
		{
			return null;
		}

		public T ToObject<T>()
		{
			return default(T);
		}

		public DynValue CheckType(string funcName, DataType desiredType, int argNum = -1, TypeValidationFlags flags = TypeValidationFlags.AutoConvert)
		{
			return null;
		}

		public T CheckUserDataType<T>(string funcName, int argNum = -1, TypeValidationFlags flags = TypeValidationFlags.AutoConvert)
		{
			return default(T);
		}
	}
}
