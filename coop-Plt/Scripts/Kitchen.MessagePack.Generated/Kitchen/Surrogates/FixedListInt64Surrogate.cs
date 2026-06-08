using MessagePack;
using Unity.Collections;

namespace Kitchen.Surrogates
{
	[MessagePackObject(false)]
	public struct FixedListInt64Surrogate
	{
		[Key(0)]
		public int[] Data;

		public static implicit operator FixedListInt64Surrogate(FixedListInt64 v)
		{
			return new FixedListInt64Surrogate
			{
				Data = v.ToArray()
			};
		}

		public static implicit operator FixedListInt64(FixedListInt64Surrogate v)
		{
			FixedListInt64 result = default(FixedListInt64);
			int[] data = v.Data;
			for (int i = 0; i < data.Length; i++)
			{
				int item = data[i];
				result.Add(in item);
			}
			return result;
		}
	}
}
