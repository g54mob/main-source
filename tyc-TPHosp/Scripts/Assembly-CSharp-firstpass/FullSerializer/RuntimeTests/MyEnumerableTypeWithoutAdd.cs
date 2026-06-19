using System;
using System.Collections;

namespace FullSerializer.RuntimeTests
{
	public class MyEnumerableTypeWithoutAdd : IEnumerable
	{
		public int A;

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
