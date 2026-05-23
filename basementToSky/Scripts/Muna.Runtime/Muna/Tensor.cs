namespace Muna
{
	[Preserve]
	public readonly struct Tensor<T> where T : unmanaged
	{
		public readonly T[] data;

		public readonly int[] shape;

		private unsafe readonly T* nativeData;

		public unsafe Tensor(T[] data, int[] shape)
		{
			this.data = data;
			nativeData = null;
			this.shape = shape;
		}

		public unsafe Tensor(T* data, int[] shape)
		{
			this.data = null;
			nativeData = data;
			this.shape = shape;
		}

		public unsafe ref T GetPinnableReference()
		{
			if (nativeData != null)
			{
				return ref *nativeData;
			}
			return ref data[0];
		}
	}
}
