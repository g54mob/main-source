using System;

namespace Os.Utils
{
	[Serializable]
	public struct Triplet<T>
	{
		public T v0;

		public T v1;

		public T v2;

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public Triplet(T v0, T v1, T v2)
		{
			this.v0 = default(T);
			this.v1 = default(T);
			this.v2 = default(T);
		}
	}
}
