using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers.Extensions
{
	public static class IEnumerableExtensions
	{
		public static T GetRandomOrDefault<T>(this IEnumerable<T> instance)
		{
			int num = instance.Count();
			if (num == 0)
			{
				return default(T);
			}
			int index = Random.Range(0, num);
			return instance.ElementAt(index);
		}
	}
}
