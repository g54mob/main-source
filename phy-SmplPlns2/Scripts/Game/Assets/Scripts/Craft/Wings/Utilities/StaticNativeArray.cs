using Unity.Collections;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public class StaticNativeArray<T> where T : struct
	{
		public NativeArray<T> Array { get; private set; }

		public StaticNativeArray(NativeArray<T> array)
		{
			Array = array;
		}

		public StaticNativeArray(int length)
			: this(new NativeArray<T>(length, Allocator.Persistent))
		{
		}

		public StaticNativeArray(T[] data)
		{
			NativeArray<T> array = new NativeArray<T>(data.Length, Allocator.Persistent);
			array.CopyFrom(data);
			Array = array;
		}

		~StaticNativeArray()
		{
			if (Array.IsCreated)
			{
				Array.Dispose();
			}
		}
	}
}
