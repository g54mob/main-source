using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Types;

namespace FluentAssertions
{
	[DebuggerNonUserCode]
	public static class TypeExtensions
	{
		public static TypeSelector Types(this Assembly assembly)
		{
			return new TypeSelector(assembly.GetTypes());
		}

		public static TypeSelector Types(this Type type)
		{
			return new TypeSelector(type);
		}

		public static TypeSelector Types(this IEnumerable<Type> types)
		{
			return new TypeSelector(types);
		}

		public static MethodInfoSelector Methods(this Type type)
		{
			return new MethodInfoSelector(type);
		}

		public static MethodInfoSelector Methods(this TypeSelector typeSelector)
		{
			Guard.ThrowIfArgumentIsNull(typeSelector, "typeSelector");
			return new MethodInfoSelector(typeSelector.ToList());
		}

		public static PropertyInfoSelector Properties(this Type type)
		{
			return new PropertyInfoSelector(type);
		}

		public static PropertyInfoSelector Properties(this TypeSelector typeSelector)
		{
			Guard.ThrowIfArgumentIsNull(typeSelector, "typeSelector");
			return new PropertyInfoSelector(typeSelector.ToList());
		}
	}
}
