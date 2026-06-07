using System;
using System.Collections.Generic;

namespace NVorbis
{
	internal class Mdct
	{
		private const float M_PI = (float)Math.PI;

		private static Dictionary<int, Mdct> _setupCache = new Dictionary<int, Mdct>(2);

		private int n;

		private int n2;

		private int n4;

		private int n8;

		private int ld;

		private float[] A;

		private float[] B;

		private float[] C;

		private float[] buf2;

		private ushort[] bitrev;

		public static void Reverse(float[] samples, int sampleCount)
		{
			GetSetup(sampleCount).CalcReverse(samples);
		}

		private static Mdct GetSetup(int n)
		{
			if (!_setupCache.ContainsKey(n))
			{
				lock (_setupCache)
				{
					if (!_setupCache.ContainsKey(n))
					{
						_setupCache[n] = new Mdct(n);
					}
				}
			}
			return _setupCache[n];
		}

		private Mdct(int n)
		{
			this.n = n;
			n2 = n >> 1;
			n4 = n2 >> 1;
			n8 = n4 >> 1;
			ld = Utils.ilog(n) - 1;
			A = new float[n2];
			B = new float[n2];
			C = new float[n4];
			buf2 = new float[n2];
			int num2;
			int num = (num2 = 0);
			while (num < n4)
			{
				A[num2] = (float)Math.Cos((float)(4 * num) * (float)Math.PI / (float)n);
				A[num2 + 1] = (float)(0.0 - Math.Sin((float)(4 * num) * (float)Math.PI / (float)n));
				B[num2] = (float)Math.Cos((float)(num2 + 1) * (float)Math.PI / (float)n / 2f) * 0.5f;
				B[num2 + 1] = (float)Math.Sin((float)(num2 + 1) * (float)Math.PI / (float)n / 2f) * 0.5f;
				num++;
				num2 += 2;
			}
			num = (num2 = 0);
			while (num < n8)
			{
				C[num2] = (float)Math.Cos((float)(2 * (num2 + 1)) * (float)Math.PI / (float)n);
				C[num2 + 1] = (float)(0.0 - Math.Sin((float)(2 * (num2 + 1)) * (float)Math.PI / (float)n));
				num++;
				num2 += 2;
			}
			bitrev = new ushort[n8];
			for (int i = 0; i < n8; i++)
			{
				bitrev[i] = (ushort)(Utils.BitReverse((uint)i, ld - 3) << 2);
			}
		}

		private void CalcReverse(float[] buffer)
		{
			int num = n2 - 2;
			int num2 = 0;
			int i = 0;
			for (int num3 = n2; i != num3; i += 4)
			{
				buf2[num + 1] = buffer[i] * A[num2] - buffer[i + 2] * A[num2 + 1];
				buf2[num] = buffer[i] * A[num2 + 1] + buffer[i + 2] * A[num2];
				num -= 2;
				num2 += 2;
			}
			i = n2 - 3;
			while (num >= 0)
			{
				buf2[num + 1] = (0f - buffer[i + 2]) * A[num2] - (0f - buffer[i]) * A[num2 + 1];
				buf2[num] = (0f - buffer[i + 2]) * A[num2 + 1] + (0f - buffer[i]) * A[num2];
				num -= 2;
				num2 += 2;
				i -= 4;
			}
			float[] array = buf2;
			int num4 = n2 - 8;
			int num5 = n4;
			int num6 = 0;
			int num7 = n4;
			int num8 = 0;
			while (num4 >= 0)
			{
				float num9 = array[num5 + 1] - array[num6 + 1];
				float num10 = array[num5] - array[num6];
				buffer[num7 + 1] = array[num5 + 1] + array[num6 + 1];
				buffer[num7] = array[num5] + array[num6];
				buffer[num8 + 1] = num9 * A[num4 + 4] - num10 * A[num4 + 5];
				buffer[num8] = num10 * A[num4 + 4] + num9 * A[num4 + 5];
				num9 = array[num5 + 3] - array[num6 + 3];
				num10 = array[num5 + 2] - array[num6 + 2];
				buffer[num7 + 3] = array[num5 + 3] + array[num6 + 3];
				buffer[num7 + 2] = array[num5 + 2] + array[num6 + 2];
				buffer[num8 + 3] = num9 * A[num4] - num10 * A[num4 + 1];
				buffer[num8 + 2] = num10 * A[num4] + num9 * A[num4 + 1];
				num4 -= 8;
				num7 += 4;
				num8 += 4;
				num5 += 4;
				num6 += 4;
			}
			int num11 = n >> 4;
			int num12 = n2 - 1;
			_ = n4;
			step3_iter0_loop(num11, buffer, num12 - 0, -n8);
			step3_iter0_loop(n >> 4, buffer, n2 - 1 - n4, -n8);
			int lim = n >> 5;
			int num13 = n2 - 1;
			_ = n8;
			step3_inner_r_loop(lim, buffer, num13 - 0, -(n >> 4), 16);
			step3_inner_r_loop(n >> 5, buffer, n2 - 1 - n8, -(n >> 4), 16);
			step3_inner_r_loop(n >> 5, buffer, n2 - 1 - n8 * 2, -(n >> 4), 16);
			step3_inner_r_loop(n >> 5, buffer, n2 - 1 - n8 * 3, -(n >> 4), 16);
			int j;
			for (j = 2; j < ld - 3 >> 1; j++)
			{
				int num14 = n >> j + 2;
				int num15 = num14 >> 1;
				int num16 = 1 << j + 1;
				for (int k = 0; k < num16; k++)
				{
					step3_inner_r_loop(n >> j + 4, buffer, n2 - 1 - num14 * k, -num15, 1 << j + 3);
				}
			}
			for (; j < ld - 6; j++)
			{
				int num17 = n >> j + 2;
				int num18 = 1 << j + 3;
				int num19 = num17 >> 1;
				int num20 = n >> j + 6;
				int num21 = 1 << j + 1;
				int num22 = n2 - 1;
				int num23 = 0;
				for (int num24 = num20; num24 > 0; num24--)
				{
					step3_inner_s_loop(num21, buffer, num22, -num19, num23, num18, num17);
					num23 += num18 * 4;
					num22 -= 8;
				}
			}
			step3_inner_s_loop_ld654(n >> 5, buffer, n2 - 1, n);
			int num25 = 0;
			int num26 = n4 - 4;
			int num27 = n2 - 4;
			while (num26 >= 0)
			{
				int num28 = bitrev[num25];
				array[num27 + 3] = buffer[num28];
				array[num27 + 2] = buffer[num28 + 1];
				array[num26 + 3] = buffer[num28 + 2];
				array[num26 + 2] = buffer[num28 + 3];
				num28 = bitrev[num25 + 1];
				array[num27 + 1] = buffer[num28];
				array[num27] = buffer[num28 + 1];
				array[num26 + 1] = buffer[num28 + 2];
				array[num26] = buffer[num28 + 3];
				num26 -= 4;
				num27 -= 4;
				num25 += 2;
			}
			int num29 = 0;
			int num30 = 0;
			int num31 = n2 - 4;
			while (num30 < num31)
			{
				float num32 = array[num30] - array[num31 + 2];
				float num33 = array[num30 + 1] + array[num31 + 3];
				float num34 = C[num29 + 1] * num32 + C[num29] * num33;
				float num35 = C[num29 + 1] * num33 - C[num29] * num32;
				float num36 = array[num30] + array[num31 + 2];
				float num37 = array[num30 + 1] - array[num31 + 3];
				array[num30] = num36 + num34;
				array[num30 + 1] = num37 + num35;
				array[num31 + 2] = num36 - num34;
				array[num31 + 3] = num35 - num37;
				num32 = array[num30 + 2] - array[num31];
				num33 = array[num30 + 3] + array[num31 + 1];
				num34 = C[num29 + 3] * num32 + C[num29 + 2] * num33;
				num35 = C[num29 + 3] * num33 - C[num29 + 2] * num32;
				num36 = array[num30 + 2] + array[num31];
				num37 = array[num30 + 3] - array[num31 + 1];
				array[num30 + 2] = num36 + num34;
				array[num30 + 3] = num37 + num35;
				array[num31] = num36 - num34;
				array[num31 + 1] = num35 - num37;
				num29 += 4;
				num30 += 4;
				num31 -= 4;
			}
			int num38 = n2 - 8;
			int num39 = n2 - 8;
			int num40 = 0;
			int num41 = n2 - 4;
			int num42 = n2;
			int num43 = n - 4;
			while (num39 >= 0)
			{
				float num44 = buf2[num39 + 6] * B[num38 + 7] - buf2[num39 + 7] * B[num38 + 6];
				float num45 = (0f - buf2[num39 + 6]) * B[num38 + 6] - buf2[num39 + 7] * B[num38 + 7];
				buffer[num40] = num44;
				buffer[num41 + 3] = 0f - num44;
				buffer[num42] = num45;
				buffer[num43 + 3] = num45;
				float num46 = buf2[num39 + 4] * B[num38 + 5] - buf2[num39 + 5] * B[num38 + 4];
				float num47 = (0f - buf2[num39 + 4]) * B[num38 + 4] - buf2[num39 + 5] * B[num38 + 5];
				buffer[num40 + 1] = num46;
				buffer[num41 + 2] = 0f - num46;
				buffer[num42 + 1] = num47;
				buffer[num43 + 2] = num47;
				num44 = buf2[num39 + 2] * B[num38 + 3] - buf2[num39 + 3] * B[num38 + 2];
				num45 = (0f - buf2[num39 + 2]) * B[num38 + 2] - buf2[num39 + 3] * B[num38 + 3];
				buffer[num40 + 2] = num44;
				buffer[num41 + 1] = 0f - num44;
				buffer[num42 + 2] = num45;
				buffer[num43 + 1] = num45;
				num46 = buf2[num39] * B[num38 + 1] - buf2[num39 + 1] * B[num38];
				num47 = (0f - buf2[num39]) * B[num38] - buf2[num39 + 1] * B[num38 + 1];
				buffer[num40 + 3] = num46;
				buffer[num41] = 0f - num46;
				buffer[num42 + 3] = num47;
				buffer[num43] = num47;
				num38 -= 8;
				num39 -= 8;
				num40 += 4;
				num42 += 4;
				num41 -= 4;
				num43 -= 4;
			}
		}

		private void step3_iter0_loop(int n, float[] e, int i_off, int k_off)
		{
			int num = i_off;
			int num2 = num + k_off;
			int num3 = 0;
			for (int num4 = n >> 2; num4 > 0; num4--)
			{
				float num5 = e[num] - e[num2];
				float num6 = e[num - 1] - e[num2 - 1];
				e[num] += e[num2];
				e[num - 1] += e[num2 - 1];
				e[num2] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 1] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += 8;
				num5 = e[num - 2] - e[num2 - 2];
				num6 = e[num - 3] - e[num2 - 3];
				e[num - 2] += e[num2 - 2];
				e[num - 3] += e[num2 - 3];
				e[num2 - 2] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 3] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += 8;
				num5 = e[num - 4] - e[num2 - 4];
				num6 = e[num - 5] - e[num2 - 5];
				e[num - 4] += e[num2 - 4];
				e[num - 5] += e[num2 - 5];
				e[num2 - 4] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 5] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += 8;
				num5 = e[num - 6] - e[num2 - 6];
				num6 = e[num - 7] - e[num2 - 7];
				e[num - 6] += e[num2 - 6];
				e[num - 7] += e[num2 - 7];
				e[num2 - 6] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 7] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += 8;
				num -= 8;
				num2 -= 8;
			}
		}

		private void step3_inner_r_loop(int lim, float[] e, int d0, int k_off, int k1)
		{
			int num = d0;
			int num2 = num + k_off;
			int num3 = 0;
			for (int num4 = lim >> 2; num4 > 0; num4--)
			{
				float num5 = e[num] - e[num2];
				float num6 = e[num - 1] - e[num2 - 1];
				e[num] += e[num2];
				e[num - 1] += e[num2 - 1];
				e[num2] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 1] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += k1;
				num5 = e[num - 2] - e[num2 - 2];
				num6 = e[num - 3] - e[num2 - 3];
				e[num - 2] += e[num2 - 2];
				e[num - 3] += e[num2 - 3];
				e[num2 - 2] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 3] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += k1;
				num5 = e[num - 4] - e[num2 - 4];
				num6 = e[num - 5] - e[num2 - 5];
				e[num - 4] += e[num2 - 4];
				e[num - 5] += e[num2 - 5];
				e[num2 - 4] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 5] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += k1;
				num5 = e[num - 6] - e[num2 - 6];
				num6 = e[num - 7] - e[num2 - 7];
				e[num - 6] += e[num2 - 6];
				e[num - 7] += e[num2 - 7];
				e[num2 - 6] = num5 * A[num3] - num6 * A[num3 + 1];
				e[num2 - 7] = num6 * A[num3] + num5 * A[num3 + 1];
				num3 += k1;
				num -= 8;
				num2 -= 8;
			}
		}

		private void step3_inner_s_loop(int n, float[] e, int i_off, int k_off, int a, int a_off, int k0)
		{
			float num = A[a];
			float num2 = A[a + 1];
			float num3 = A[a + a_off];
			float num4 = A[a + a_off + 1];
			float num5 = A[a + a_off * 2];
			float num6 = A[a + a_off * 2 + 1];
			float num7 = A[a + a_off * 3];
			float num8 = A[a + a_off * 3 + 1];
			int num9 = i_off;
			int num10 = num9 + k_off;
			for (int num11 = n; num11 > 0; num11--)
			{
				float num12 = e[num9] - e[num10];
				float num13 = e[num9 - 1] - e[num10 - 1];
				e[num9] += e[num10];
				e[num9 - 1] += e[num10 - 1];
				e[num10] = num12 * num - num13 * num2;
				e[num10 - 1] = num13 * num + num12 * num2;
				num12 = e[num9 - 2] - e[num10 - 2];
				num13 = e[num9 - 3] - e[num10 - 3];
				e[num9 - 2] += e[num10 - 2];
				e[num9 - 3] += e[num10 - 3];
				e[num10 - 2] = num12 * num3 - num13 * num4;
				e[num10 - 3] = num13 * num3 + num12 * num4;
				num12 = e[num9 - 4] - e[num10 - 4];
				num13 = e[num9 - 5] - e[num10 - 5];
				e[num9 - 4] += e[num10 - 4];
				e[num9 - 5] += e[num10 - 5];
				e[num10 - 4] = num12 * num5 - num13 * num6;
				e[num10 - 5] = num13 * num5 + num12 * num6;
				num12 = e[num9 - 6] - e[num10 - 6];
				num13 = e[num9 - 7] - e[num10 - 7];
				e[num9 - 6] += e[num10 - 6];
				e[num9 - 7] += e[num10 - 7];
				e[num10 - 6] = num12 * num7 - num13 * num8;
				e[num10 - 7] = num13 * num7 + num12 * num8;
				num9 -= k0;
				num10 -= k0;
			}
		}

		private void step3_inner_s_loop_ld654(int n, float[] e, int i_off, int base_n)
		{
			int num = base_n >> 3;
			float num2 = A[num];
			int num3 = i_off;
			int num4 = num3 - 16 * n;
			while (num3 > num4)
			{
				float num5 = e[num3] - e[num3 - 8];
				float num6 = e[num3 - 1] - e[num3 - 9];
				e[num3] += e[num3 - 8];
				e[num3 - 1] += e[num3 - 9];
				e[num3 - 8] = num5;
				e[num3 - 9] = num6;
				num5 = e[num3 - 2] - e[num3 - 10];
				num6 = e[num3 - 3] - e[num3 - 11];
				e[num3 - 2] += e[num3 - 10];
				e[num3 - 3] += e[num3 - 11];
				e[num3 - 10] = (num5 + num6) * num2;
				e[num3 - 11] = (num6 - num5) * num2;
				num5 = e[num3 - 12] - e[num3 - 4];
				num6 = e[num3 - 5] - e[num3 - 13];
				e[num3 - 4] += e[num3 - 12];
				e[num3 - 5] += e[num3 - 13];
				e[num3 - 12] = num6;
				e[num3 - 13] = num5;
				num5 = e[num3 - 14] - e[num3 - 6];
				num6 = e[num3 - 7] - e[num3 - 15];
				e[num3 - 6] += e[num3 - 14];
				e[num3 - 7] += e[num3 - 15];
				e[num3 - 14] = (num5 + num6) * num2;
				e[num3 - 15] = (num5 - num6) * num2;
				iter_54(e, num3);
				iter_54(e, num3 - 8);
				num3 -= 16;
			}
		}

		private void iter_54(float[] e, int z)
		{
			float num = e[z] - e[z - 4];
			float num2 = e[z] + e[z - 4];
			float num3 = e[z - 2] + e[z - 6];
			float num4 = e[z - 2] - e[z - 6];
			e[z] = num2 + num3;
			e[z - 2] = num2 - num3;
			float num5 = e[z - 3] - e[z - 7];
			e[z - 4] = num + num5;
			e[z - 6] = num - num5;
			float num6 = e[z - 1] - e[z - 5];
			float num7 = e[z - 1] + e[z - 5];
			float num8 = e[z - 3] + e[z - 7];
			e[z - 1] = num7 + num8;
			e[z - 3] = num7 - num8;
			e[z - 5] = num6 - num4;
			e[z - 7] = num6 + num4;
		}
	}
}
