using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class ReferenceEqualityComparer : IEqualityComparer<object>
	{
		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return false;
		}

		int IEqualityComparer<object>.GetHashCode(object obj)
		{
			return 0;
		}
	}
}
