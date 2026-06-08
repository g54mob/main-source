using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Castle.DynamicProxy.Generators
{
	public static class AttributesToAvoidReplicating
	{
		private static readonly object lockObject;

		private static IList<Type> attributes;

		static AttributesToAvoidReplicating()
		{
			lockObject = new object();
			attributes = new List<Type>
			{
				typeof(ComImportAttribute),
				typeof(MarshalAsAttribute),
				typeof(TypeIdentifierAttribute),
				typeof(SecurityAttribute)
			};
		}

		public static void Add(Type attribute)
		{
			lock (lockObject)
			{
				attributes = new List<Type>(attributes) { attribute };
			}
		}

		public static void Add<T>()
		{
			Add(typeof(T));
		}

		public static bool Contains(Type attribute)
		{
			return attributes.Contains(attribute);
		}

		internal static bool ShouldAvoid(Type attribute)
		{
			return attributes.Any((Type attr) => attr.IsAssignableFrom(attribute));
		}
	}
}
