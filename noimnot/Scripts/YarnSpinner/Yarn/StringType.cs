using System;
using System.Collections.Generic;

namespace Yarn
{
	internal class StringType : TypeBase, IBridgeableType<string>, IType
	{
		public override string Name => null;

		public override IType Parent => null;

		public override string Description { get; }

		public string DefaultValue => null;

		private static IReadOnlyDictionary<string, Delegate> DefaultMethods => null;

		public StringType()
			: base(null)
		{
		}

		public string ToBridgedType(Value value)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		private static string MethodConcatenate(Value arg1, Value arg2)
		{
			return null;
		}

		private static bool MethodEqualTo(Value a, Value b)
		{
			return false;
		}
	}
}
