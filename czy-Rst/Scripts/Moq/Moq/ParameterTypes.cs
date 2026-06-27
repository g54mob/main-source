using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Moq
{
	internal readonly struct ParameterTypes : IReadOnlyList<Type>, IEnumerable<Type>, IEnumerable, IReadOnlyCollection<Type>
	{
		private readonly ParameterInfo[] parameters;

		public Type this[int index] => parameters[index].ParameterType;

		public int Count => parameters.Length;

		public ParameterTypes(ParameterInfo[] parameters)
		{
			this.parameters = parameters;
		}

		public IEnumerator<Type> GetEnumerator()
		{
			int i = 0;
			int n = Count;
			while (i < n)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
