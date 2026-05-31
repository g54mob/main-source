using System.Collections.Generic;
using UnityEngine.Pool;

namespace CTS.Utilities
{
	public static class TemporaryCollection
	{
		public readonly ref struct TemporaryList<T>
		{
			public List<T> List { get; }

			private TemporaryList(List<T> list)
			{
				List = list;
			}

			public static TemporaryList<T> Create()
			{
				return new TemporaryList<T>(CollectionPool<List<T>, T>.Get());
			}

			public void Dispose()
			{
				CollectionPool<List<T>, T>.Release(List);
			}
		}

		public static TemporaryList<T> GetTemporaryList<T>()
		{
			return TemporaryList<T>.Create();
		}
	}
}
