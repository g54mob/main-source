using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Encoder.Bptc
{
	internal struct ClusterIndices4X4
	{
		public int i00;

		public int i10;

		public int i20;

		public int i30;

		public int i01;

		public int i11;

		public int i21;

		public int i31;

		public int i02;

		public int i12;

		public int i22;

		public int i32;

		public int i03;

		public int i13;

		public int i23;

		public int i33;

		public Span<int> AsSpan => MemoryMarshal.CreateSpan(ref i00, 16);

		public int this[int x, int y]
		{
			get
			{
				return AsSpan[x + y * 4];
			}
			set
			{
				AsSpan[x + y * 4] = value;
			}
		}

		public int this[int index]
		{
			get
			{
				return AsSpan[index];
			}
			set
			{
				AsSpan[index] = value;
			}
		}

		public int NumClusters
		{
			get
			{
				Span<int> asSpan = AsSpan;
				Span<int> span = stackalloc int[16];
				int num = 0;
				for (int i = 0; i < 16; i++)
				{
					int num2 = asSpan[i];
					bool flag = false;
					for (int j = 0; j < num; j++)
					{
						if (span[j] == num2)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						span[num] = num2;
						num++;
					}
				}
				return num;
			}
		}

		public ClusterIndices4X4 Reduce(out int numClusters)
		{
			ClusterIndices4X4 result = default(ClusterIndices4X4);
			numClusters = NumClusters;
			Span<int> span = stackalloc int[numClusters];
			Span<int> asSpan = AsSpan;
			Span<int> asSpan2 = result.AsSpan;
			int num = 0;
			for (int i = 0; i < 16; i++)
			{
				int num2 = asSpan[i];
				bool flag = false;
				for (int j = 0; j < num; j++)
				{
					if (span[j] == num2)
					{
						flag = true;
						asSpan2[i] = j;
						break;
					}
				}
				if (!flag)
				{
					asSpan2[i] = num;
					span[num] = num2;
					num++;
				}
			}
			return result;
		}
	}
}
