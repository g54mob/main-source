using System;
using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class TypeProvider : TestProvider<Type>
	{
		public override bool Compare(Type before, Type after)
		{
			return before == after;
		}

		public override IEnumerable<Type> GetValues()
		{
			yield return typeof(int);
			yield return typeof(TestProvider<>);
			yield return typeof(TestProvider<int>);
		}
	}
}
