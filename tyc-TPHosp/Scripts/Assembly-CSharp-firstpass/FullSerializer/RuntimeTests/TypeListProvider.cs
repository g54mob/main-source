using System;
using System.Collections.Generic;
using System.Linq;

namespace FullSerializer.RuntimeTests
{
	public class TypeListProvider : TestProvider<List<Type>>
	{
		public override bool Compare(List<Type> before, List<Type> after)
		{
			if (before.Except(after).Count() == 0)
			{
				return after.Except(before).Count() == 0;
			}
			return false;
		}

		public override IEnumerable<List<Type>> GetValues()
		{
			yield return new List<Type>
			{
				typeof(int),
				typeof(int),
				typeof(float),
				typeof(int)
			};
		}
	}
}
