using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class ByteArraySlicePool
	{
		private int minStackIndex;

		internal readonly Stack<ByteArraySlice>[] poolTiers;

		private int allocationCounter;

		public int MinStackIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int AllocationCounter => 0;

		public ByteArraySlice Acquire(byte[] buffer, int offset = 0, int count = 0)
		{
			return null;
		}

		public ByteArraySlice Acquire(int minByteCount)
		{
			return null;
		}

		private ByteArraySlice PopOrCreate(Stack<ByteArraySlice> stack, int stackIndex)
		{
			return null;
		}

		internal bool Release(ByteArraySlice slice, int stackIndex)
		{
			return false;
		}

		public void ClearPools(int lower = 0, int upper = 2147483647)
		{
		}
	}
}
