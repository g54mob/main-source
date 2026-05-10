using System;
using System.Collections.Generic;

namespace Yarn
{
	public static class BuiltinTypes
	{
		internal const IType Undefined = null;

		public static IType String { get; }

		public static IType Number { get; }

		public static IType Boolean { get; }

		public static IType Any { get; }

		public static IReadOnlyDictionary<Type, IType> TypeMappings { get; }

		internal static IEnumerable<IType> AllBuiltinTypes => null;
	}
}
