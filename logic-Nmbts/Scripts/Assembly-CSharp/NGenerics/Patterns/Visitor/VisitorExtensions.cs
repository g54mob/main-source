using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
	public static class VisitorExtensions
	{
		public static void AcceptVisitor<T>(this IEnumerable<T> enumerable, IVisitor<T> visitor)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			foreach (T item in enumerable)
			{
				if (visitor.HasCompleted)
				{
					break;
				}
				visitor.Visit(item);
			}
		}
	}
}
