using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class ReferenceEqualityComparer : IEqualityComparer<object>
	{
		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return object.ReferenceEquals(x, y);
		}

		int IEqualityComparer<object>.GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}
	}
}
