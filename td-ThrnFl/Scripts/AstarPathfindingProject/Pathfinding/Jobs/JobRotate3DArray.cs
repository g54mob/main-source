using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobRotate3DArray<T> : IJob where T : unmanaged
	{
		public NativeArray<T> arr;

		public int3 size;

		public int dx;

		public int dz;

		public void Execute()
		{
			int x = size.x;
			int y = size.y;
			int z = size.z;
			UnsafeSpan<T> unsafeSpan = arr.AsUnsafeSpan();
			dx %= x;
			dz %= z;
			if (dx != 0)
			{
				if (dx < 0)
				{
					dx = x + dx;
				}
				UnsafeSpan<T> other = new NativeArray<T>(dx, Allocator.Temp).AsUnsafeSpan();
				for (int i = 0; i < y; i++)
				{
					int num = i * x * z;
					for (int j = 0; j < z; j++)
					{
						unsafeSpan.Slice(num + j * x + x - dx, dx).CopyTo(other);
						unsafeSpan.Move(num + j * x, num + j * x + dx, x - dx);
						other.CopyTo(unsafeSpan.Slice(num + j * x, dx));
					}
				}
			}
			if (dz != 0)
			{
				if (dz < 0)
				{
					dz = z + dz;
				}
				UnsafeSpan<T> other2 = new NativeArray<T>(dz * x, Allocator.Temp).AsUnsafeSpan();
				for (int k = 0; k < y; k++)
				{
					int num2 = k * x * z;
					unsafeSpan.Slice(num2 + (z - dz) * x, dz * x).CopyTo(other2);
					unsafeSpan.Move(num2, num2 + dz * x, (z - dz) * x);
					other2.CopyTo(unsafeSpan.Slice(num2, dz * x));
				}
			}
		}
	}
}
