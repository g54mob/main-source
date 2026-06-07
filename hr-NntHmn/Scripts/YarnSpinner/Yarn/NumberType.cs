using System;
using System.Collections.Generic;

namespace Yarn
{
	internal class NumberType : TypeBase, IBridgeableType<float>, IType
	{
		public float DefaultValue => 0f;

		public override string Name => null;

		public override IType Parent => null;

		public override string Description => null;

		private static IReadOnlyDictionary<string, Delegate> DefaultMethods => null;

		public NumberType()
			: base(null)
		{
		}

		public float ToBridgedType(Value value)
		{
			return 0f;
		}

		private static bool MethodEqualTo(Value a, Value b)
		{
			return false;
		}

		private static float MethodAdd(Value a, Value b)
		{
			return 0f;
		}

		private static float MethodSubtract(Value a, Value b)
		{
			return 0f;
		}

		private static float MethodDivide(Value a, Value b)
		{
			return 0f;
		}

		private static float MethodMultiply(Value a, Value b)
		{
			return 0f;
		}

		private static int MethodModulus(Value a, Value b)
		{
			return 0;
		}

		private static float MethodUnaryMinus(Value a)
		{
			return 0f;
		}

		private static bool MethodGreaterThan(Value a, Value b)
		{
			return false;
		}

		private static bool MethodGreaterThanOrEqualTo(Value a, Value b)
		{
			return false;
		}

		private static bool MethodLessThan(Value a, Value b)
		{
			return false;
		}

		private static bool MethodLessThanOrEqualTo(Value a, Value b)
		{
			return false;
		}
	}
}
