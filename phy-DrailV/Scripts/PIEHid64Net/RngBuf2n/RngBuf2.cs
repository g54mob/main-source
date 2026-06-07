using System;
using System.Threading;

namespace RngBuf2n
{
	internal class RngBuf2
	{
		private int N;

		private int M;

		private int i;

		private int j;

		private int fl;

		private int f;

		private byte[] pB;

		private void jlock()
		{
			Monitor.Enter(pB);
		}

		private void junlock()
		{
			Monitor.Exit(pB);
		}

		public RngBuf2(int nn, int mm)
		{
			N = nn;
			M = mm;
			i = 0;
			j = 0;
			f = 0;
			fl = 0;
			pB = new byte[N * M];
			Monitor.Enter(pB);
			Monitor.Exit(pB);
		}

		public int putIfCan(byte[] pData)
		{
			jlock();
			if (fl == 1)
			{
				junlock();
				return 3;
			}
			i++;
			if (i == N)
			{
				i = 0;
			}
			if (i == j)
			{
				fl = 1;
			}
			Array.Copy(pData, 0, pB, M * i, M);
			f = 1;
			junlock();
			return 0;
		}

		public void put(byte[] pData)
		{
			jlock();
			i++;
			if (i == N)
			{
				i = 0;
			}
			if (fl == 1)
			{
				j++;
				if (j == N)
				{
					j = 0;
				}
			}
			if (i == j)
			{
				fl = 1;
			}
			Array.Copy(pData, 0, pB, M * i, M);
			f = 1;
			junlock();
		}

		public int putIfDiff(byte[] pData)
		{
			int result = 1;
			jlock();
			byte[] array = new byte[M];
			Array.Copy(pData, 0, array, 0, M);
			bool flag = false;
			for (int i = 0; i < M; i++)
			{
				if (array[i] != pB[i + this.i * M])
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this.i++;
				if (this.i == N)
				{
					this.i = 0;
				}
				if (fl == 1)
				{
					j++;
					if (j == N)
					{
						j = 0;
					}
				}
				if (this.i == j)
				{
					fl = 1;
				}
				Array.Copy(pData, 0, pB, M * this.i, M);
				f = 1;
				result = 0;
			}
			junlock();
			return result;
		}

		public int get(byte[] pS)
		{
			jlock();
			if (fl == 0 && j == i)
			{
				junlock();
				return 1;
			}
			fl = 0;
			j++;
			if (j == N)
			{
				j = 0;
			}
			Array.Copy(pB, j * M, pS, 0, M);
			junlock();
			return 0;
		}

		public int getlast(byte[] pS)
		{
			jlock();
			if (f == 0)
			{
				junlock();
				return 2;
			}
			Array.Copy(pB, i * M, pS, 0, M);
			junlock();
			return 0;
		}

		public void clear()
		{
			jlock();
			i = 0;
			j = 0;
			f = 0;
			fl = 0;
			Array.Clear(pB, 0, M * N);
			junlock();
		}

		public bool IsEmpty()
		{
			jlock();
			bool result = fl == 0 && j == i;
			junlock();
			return result;
		}
	}
}
