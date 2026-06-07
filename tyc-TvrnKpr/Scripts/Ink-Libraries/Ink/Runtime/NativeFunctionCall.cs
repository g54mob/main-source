using System.Collections.Generic;

namespace Ink.Runtime
{
	public class NativeFunctionCall : Object
	{
		private delegate object BinaryOp<T>(T left, T right);

		private delegate object UnaryOp<T>(T val);

		public const string Add = "+";

		public const string Subtract = "-";

		public const string Divide = "/";

		public const string Multiply = "*";

		public const string Mod = "%";

		public const string Negate = "_";

		public const string Equal = "==";

		public const string Greater = ">";

		public const string Less = "<";

		public const string GreaterThanOrEquals = ">=";

		public const string LessThanOrEquals = "<=";

		public const string NotEquals = "!=";

		public const string Not = "!";

		public const string And = "&&";

		public const string Or = "||";

		public const string Min = "MIN";

		public const string Max = "MAX";

		public const string Pow = "POW";

		public const string Floor = "FLOOR";

		public const string Ceiling = "CEILING";

		public const string Int = "INT";

		public const string Float = "FLOAT";

		public const string Has = "?";

		public const string Hasnt = "!?";

		public const string Intersect = "^";

		public const string ListMin = "LIST_MIN";

		public const string ListMax = "LIST_MAX";

		public const string All = "LIST_ALL";

		public const string Count = "LIST_COUNT";

		public const string ValueOfList = "LIST_VALUE";

		public const string Invert = "LIST_INVERT";

		private string _name;

		private int _numberOfParameters;

		private NativeFunctionCall _prototype;

		private bool _isPrototype;

		private Dictionary<ValueType, object> _operationFuncs;

		private static Dictionary<string, NativeFunctionCall> _nativeFunctions;

		public string name
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public int numberOfParameters
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		public static NativeFunctionCall CallWithName(string functionName)
		{
			return null;
		}

		public static bool CallExistsWithName(string functionName)
		{
			return false;
		}

		public Object Call(List<Object> parameters)
		{
			return null;
		}

		private Value Call<T>(List<Value> parametersOfSingleType)
		{
			return null;
		}

		private Value CallBinaryListOperation(List<Object> parameters)
		{
			return null;
		}

		private Value CallListIncrementOperation(List<Object> listIntParams)
		{
			return null;
		}

		private List<Value> CoerceValuesToSingleType(List<Object> parametersIn)
		{
			return null;
		}

		public NativeFunctionCall(string name)
		{
		}

		public NativeFunctionCall()
		{
		}

		private NativeFunctionCall(string name, int numberOfParameters)
		{
		}

		private static object Identity<T>(T t)
		{
			return null;
		}

		private static void GenerateNativeFunctionsIfNecessary()
		{
		}

		private void AddOpFuncForType(ValueType valType, object op)
		{
		}

		private static void AddOpToNativeFunc(string name, int args, ValueType valType, object op)
		{
		}

		private static void AddIntBinaryOp(string name, BinaryOp<int> op)
		{
		}

		private static void AddIntUnaryOp(string name, UnaryOp<int> op)
		{
		}

		private static void AddFloatBinaryOp(string name, BinaryOp<float> op)
		{
		}

		private static void AddStringBinaryOp(string name, BinaryOp<string> op)
		{
		}

		private static void AddListBinaryOp(string name, BinaryOp<InkList> op)
		{
		}

		private static void AddListUnaryOp(string name, UnaryOp<InkList> op)
		{
		}

		private static void AddFloatUnaryOp(string name, UnaryOp<float> op)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
