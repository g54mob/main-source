using System;
using System.Collections.Generic;

namespace Yarn
{
	internal class BooleanType : TypeBase, IBridgeableType<bool>, IType
	{
		public bool DefaultValue => false;

		public override string Name => null;

		public override IType Parent => null;

		public override string Description => null;

		private static IReadOnlyDictionary<string, Delegate> DefaultMethods => null;

		internal BooleanType()
			: base(null)
		{
		}

		private static bool MethodEqualTo(Value a, Value b)
		{
			return false;
		}

		private static bool MethodAnd(Value a, Value b)
		{
			return false;
		}

		private static bool MethodOr(Value a, Value b)
		{
			return false;
		}

		private static bool MethodXor(Value a, Value b)
		{
			return false;
		}

		private static bool MethodNot(Value a)
		{
			return false;
		}

		public bool ToBridgedType(Value value)
		{
			return false;
		}
	}
}
