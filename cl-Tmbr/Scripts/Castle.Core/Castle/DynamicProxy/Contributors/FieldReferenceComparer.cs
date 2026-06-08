using System;
using System.Collections.Generic;

namespace Castle.DynamicProxy.Contributors
{
	internal class FieldReferenceComparer : IComparer<Type>
	{
		public int Compare(Type x, Type y)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			return string.CompareOrdinal(x.FullName, y.FullName);
		}
	}
}
