using System.Collections;
using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class MyEnumerableTypeWithAdd : IEnumerable
	{
		[fsIgnore]
		public List<int> items = new List<int>();

		public void Add(int item)
		{
			items.Add(item);
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
