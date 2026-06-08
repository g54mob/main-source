using System;
using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Tools;

namespace Jobberwocky.TriangleNet
{
	public class RobustPredicates : IPredicates
	{
		private static readonly object creationLock;

		private static RobustPredicates _default;

		private static double epsilon;

		private static double splitter;

		private static double resulterrbound;

		private static double ccwerrboundA;

		private static double ccwerrboundB;

		private static double ccwerrboundC;

		private static double iccerrboundA;

		private static double iccerrboundB;

		private static double iccerrboundC;

		private double[] fin1;

		private double[] fin2;

		private double[] abdet;

		private double[] axbc;

		private double[] axxbc;

		private double[] aybc;

		private double[] ayybc;

		private double[] adet;

		private double[] bxca;

		private double[] bxxca;

		private double[] byca;

		private double[] byyca;

		private double[] bdet;

		private double[] cxab;

		private double[] cxxab;

		private double[] cyab;

		private double[] cyyab;

		private double[] cdet;

		private double[] temp8;

		private double[] temp16a;

		private double[] temp16b;

		private double[] temp16c;

		private double[] temp32a;

		private double[] temp32b;

		private double[] temp48;

		private double[] temp64;

		public static RobustPredicates Default
		{
			get
			{
				if (_default == null)
				{
					lock (creationLock)
					{
						if (_default == null)
						{
							_default = new RobustPredicates();
						}
					}
				}
				return _default;
			}
		}

		static RobustPredicates()
		{
			creationLock = new object();
			bool flag = true;
			double num = 0.5;
			epsilon = 1.0;
			splitter = 1.0;
			double num2 = 1.0;
			double num3;
			do
			{
				num3 = num2;
				epsilon *= num;
				if (flag)
				{
					splitter *= 2.0;
				}
				flag = !flag;
				num2 = 1.0 + epsilon;
			}
			while (num2 != 1.0 && num2 != num3);
			splitter += 1.0;
			resulterrbound = (3.0 + 8.0 * epsilon) * epsilon;
			ccwerrboundA = (3.0 + 16.0 * epsilon) * epsilon;
			ccwerrboundB = (2.0 + 12.0 * epsilon) * epsilon;
			ccwerrboundC = (9.0 + 64.0 * epsilon) * epsilon * epsilon;
			iccerrboundA = (10.0 + 96.0 * epsilon) * epsilon;
			iccerrboundB = (4.0 + 48.0 * epsilon) * epsilon;
			iccerrboundC = (44.0 + 576.0 * epsilon) * epsilon * epsilon;
		}

		public RobustPredicates()
		{
			AllocateWorkspace();
		}

		public double CounterClockwise(Point pa, Point pb, Point pc)
		{
			Statistic.CounterClockwiseCount++;
			double num = (pa.x - pc.x) * (pb.y - pc.y);
			double num2 = (pa.y - pc.y) * (pb.x - pc.x);
			double num3 = num - num2;
			if (Behavior.NoExact)
			{
				return num3;
			}
			double num4;
			if (num > 0.0)
			{
				if (num2 <= 0.0)
				{
					return num3;
				}
				num4 = num + num2;
			}
			else
			{
				if (!(num < 0.0))
				{
					return num3;
				}
				if (num2 >= 0.0)
				{
					return num3;
				}
				num4 = 0.0 - num - num2;
			}
			double num5 = ccwerrboundA * num4;
			if (num3 >= num5 || 0.0 - num3 >= num5)
			{
				return num3;
			}
			Statistic.CounterClockwiseAdaptCount++;
			return CounterClockwiseAdapt(pa, pb, pc, num4);
		}

		public double InCircle(Point pa, Point pb, Point pc, Point pd)
		{
			Statistic.InCircleCount++;
			double num = pa.x - pd.x;
			double num2 = pb.x - pd.x;
			double num3 = pc.x - pd.x;
			double num4 = pa.y - pd.y;
			double num5 = pb.y - pd.y;
			double num6 = pc.y - pd.y;
			double num7 = num2 * num6;
			double num8 = num3 * num5;
			double num9 = num * num + num4 * num4;
			double num10 = num3 * num4;
			double num11 = num * num6;
			double num12 = num2 * num2 + num5 * num5;
			double num13 = num * num5;
			double num14 = num2 * num4;
			double num15 = num3 * num3 + num6 * num6;
			double num16 = num9 * (num7 - num8) + num12 * (num10 - num11) + num15 * (num13 - num14);
			if (Behavior.NoExact)
			{
				return num16;
			}
			double num17 = (Math.Abs(num7) + Math.Abs(num8)) * num9 + (Math.Abs(num10) + Math.Abs(num11)) * num12 + (Math.Abs(num13) + Math.Abs(num14)) * num15;
			double num18 = iccerrboundA * num17;
			if (num16 > num18 || 0.0 - num16 > num18)
			{
				return num16;
			}
			Statistic.InCircleAdaptCount++;
			return InCircleAdapt(pa, pb, pc, pd, num17);
		}

		public Point FindCircumcenter(Point org, Point dest, Point apex, ref double xi, ref double eta, double offconstant)
		{
			Statistic.CircumcenterCount++;
			double num = dest.x - org.x;
			double num2 = dest.y - org.y;
			double num3 = apex.x - org.x;
			double num4 = apex.y - org.y;
			double num5 = num * num + num2 * num2;
			double num6 = num3 * num3 + num4 * num4;
			double num7 = (dest.x - apex.x) * (dest.x - apex.x) + (dest.y - apex.y) * (dest.y - apex.y);
			double num8;
			if (Behavior.NoExact)
			{
				num8 = 0.5 / (num * num4 - num3 * num2);
			}
			else
			{
				num8 = 0.5 / CounterClockwise(dest, apex, org);
				Statistic.CounterClockwiseCount--;
			}
			double num9 = (num4 * num5 - num2 * num6) * num8;
			double num10 = (num * num6 - num3 * num5) * num8;
			if (num5 < num6 && num5 < num7)
			{
				if (offconstant > 0.0)
				{
					double num11 = 0.5 * num - offconstant * num2;
					double num12 = 0.5 * num2 + offconstant * num;
					if (num11 * num11 + num12 * num12 < num9 * num9 + num10 * num10)
					{
						num9 = num11;
						num10 = num12;
					}
				}
			}
			else if (num6 < num7)
			{
				if (offconstant > 0.0)
				{
					double num11 = 0.5 * num3 + offconstant * num4;
					double num12 = 0.5 * num4 - offconstant * num3;
					if (num11 * num11 + num12 * num12 < num9 * num9 + num10 * num10)
					{
						num9 = num11;
						num10 = num12;
					}
				}
			}
			else if (offconstant > 0.0)
			{
				double num11 = 0.5 * (apex.x - dest.x) - offconstant * (apex.y - dest.y);
				double num12 = 0.5 * (apex.y - dest.y) + offconstant * (apex.x - dest.x);
				if (num11 * num11 + num12 * num12 < (num9 - num) * (num9 - num) + (num10 - num2) * (num10 - num2))
				{
					num9 = num + num11;
					num10 = num2 + num12;
				}
			}
			xi = (num4 * num9 - num3 * num10) * (2.0 * num8);
			eta = (num * num10 - num2 * num9) * (2.0 * num8);
			return new Point(org.x + num9, org.y + num10);
		}

		public Point FindCircumcenter(Point org, Point dest, Point apex, ref double xi, ref double eta)
		{
			Statistic.CircumcenterCount++;
			double num = dest.x - org.x;
			double num2 = dest.y - org.y;
			double num3 = apex.x - org.x;
			double num4 = apex.y - org.y;
			double num5 = num * num + num2 * num2;
			double num6 = num3 * num3 + num4 * num4;
			double num7;
			if (Behavior.NoExact)
			{
				num7 = 0.5 / (num * num4 - num3 * num2);
			}
			else
			{
				num7 = 0.5 / CounterClockwise(dest, apex, org);
				Statistic.CounterClockwiseCount--;
			}
			double num8 = (num4 * num5 - num2 * num6) * num7;
			double num9 = (num * num6 - num3 * num5) * num7;
			xi = (num4 * num8 - num3 * num9) * (2.0 * num7);
			eta = (num * num9 - num2 * num8) * (2.0 * num7);
			return new Point(org.x + num8, org.y + num9);
		}

		private int FastExpansionSumZeroElim(int elen, double[] e, int flen, double[] f, double[] h)
		{
			double num = e[0];
			double num2 = f[0];
			int num4;
			int num3 = (num4 = 0);
			double num5;
			if (num2 > num == num2 > 0.0 - num)
			{
				num5 = num;
				num = e[++num3];
			}
			else
			{
				num5 = num2;
				num2 = f[++num4];
			}
			int num6 = 0;
			if (num3 < elen && num4 < flen)
			{
				double num7;
				double num9;
				if (num2 > num == num2 > 0.0 - num)
				{
					num7 = num + num5;
					double num8 = num7 - num;
					num9 = num5 - num8;
					num = e[++num3];
				}
				else
				{
					num7 = num2 + num5;
					double num8 = num7 - num2;
					num9 = num5 - num8;
					num2 = f[++num4];
				}
				num5 = num7;
				if (num9 != 0.0)
				{
					h[num6++] = num9;
				}
				while (num3 < elen && num4 < flen)
				{
					if (num2 > num == num2 > 0.0 - num)
					{
						num7 = num5 + num;
						double num8 = num7 - num5;
						double num10 = num7 - num8;
						double num11 = num - num8;
						double num12 = num5 - num10;
						num9 = num12 + num11;
						num = e[++num3];
					}
					else
					{
						num7 = num5 + num2;
						double num8 = num7 - num5;
						double num10 = num7 - num8;
						double num11 = num2 - num8;
						double num12 = num5 - num10;
						num9 = num12 + num11;
						num2 = f[++num4];
					}
					num5 = num7;
					if (num9 != 0.0)
					{
						h[num6++] = num9;
					}
				}
			}
			while (num3 < elen)
			{
				double num7 = num5 + num;
				double num8 = num7 - num5;
				double num10 = num7 - num8;
				double num11 = num - num8;
				double num12 = num5 - num10;
				double num9 = num12 + num11;
				num = e[++num3];
				num5 = num7;
				if (num9 != 0.0)
				{
					h[num6++] = num9;
				}
			}
			while (num4 < flen)
			{
				double num7 = num5 + num2;
				double num8 = num7 - num5;
				double num10 = num7 - num8;
				double num11 = num2 - num8;
				double num12 = num5 - num10;
				double num9 = num12 + num11;
				num2 = f[++num4];
				num5 = num7;
				if (num9 != 0.0)
				{
					h[num6++] = num9;
				}
			}
			if (num5 != 0.0 || num6 == 0)
			{
				h[num6++] = num5;
			}
			return num6;
		}

		private int ScaleExpansionZeroElim(int elen, double[] e, double b, double[] h)
		{
			double num = splitter * b;
			double num2 = num - b;
			double num3 = num - num2;
			double num4 = b - num3;
			double num5 = e[0] * b;
			num = splitter * e[0];
			num2 = num - e[0];
			double num6 = num - num2;
			double num7 = e[0] - num6;
			double num8 = num5 - num6 * num3;
			double num9 = num8 - num7 * num3;
			double num10 = num9 - num6 * num4;
			double num11 = num7 * num4 - num10;
			int num12 = 0;
			if (num11 != 0.0)
			{
				h[num12++] = num11;
			}
			for (int i = 1; i < elen; i++)
			{
				double num13 = e[i];
				double num14 = num13 * b;
				num = splitter * num13;
				num2 = num - num13;
				num6 = num - num2;
				num7 = num13 - num6;
				num8 = num14 - num6 * num3;
				num9 = num8 - num7 * num3;
				num10 = num9 - num6 * num4;
				double num15 = num7 * num4 - num10;
				double num16 = num5 + num15;
				double num17 = num16 - num5;
				double num18 = num16 - num17;
				double num19 = num15 - num17;
				double num20 = num5 - num18;
				num11 = num20 + num19;
				if (num11 != 0.0)
				{
					h[num12++] = num11;
				}
				num5 = num14 + num16;
				num17 = num5 - num14;
				num11 = num16 - num17;
				if (num11 != 0.0)
				{
					h[num12++] = num11;
				}
			}
			if (num5 != 0.0 || num12 == 0)
			{
				h[num12++] = num5;
			}
			return num12;
		}

		private double Estimate(int elen, double[] e)
		{
			double num = e[0];
			for (int i = 1; i < elen; i++)
			{
				num += e[i];
			}
			return num;
		}

		private double CounterClockwiseAdapt(Point pa, Point pb, Point pc, double detsum)
		{
			double[] array = new double[5];
			double[] array2 = new double[5];
			double[] array3 = new double[8];
			double[] array4 = new double[12];
			double[] array5 = new double[16];
			double num = pa.x - pc.x;
			double num2 = pb.x - pc.x;
			double num3 = pa.y - pc.y;
			double num4 = pb.y - pc.y;
			double num5 = num * num4;
			double num6 = splitter * num;
			double num7 = num6 - num;
			double num8 = num6 - num7;
			double num9 = num - num8;
			num6 = splitter * num4;
			num7 = num6 - num4;
			double num10 = num6 - num7;
			double num11 = num4 - num10;
			double num12 = num5 - num8 * num10;
			double num13 = num12 - num9 * num10;
			double num14 = num13 - num8 * num11;
			double num15 = num9 * num11 - num14;
			double num16 = num3 * num2;
			num6 = splitter * num3;
			num7 = num6 - num3;
			num8 = num6 - num7;
			num9 = num3 - num8;
			num6 = splitter * num2;
			num7 = num6 - num2;
			num10 = num6 - num7;
			num11 = num2 - num10;
			num12 = num16 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			double num17 = num9 * num11 - num14;
			double num18 = num15 - num17;
			double num19 = num15 - num18;
			double num20 = num18 + num19;
			double num21 = num19 - num17;
			double num22 = num15 - num20;
			array[0] = num22 + num21;
			double num23 = num5 + num18;
			num19 = num23 - num5;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num5 - num20;
			double num24 = num22 + num21;
			num18 = num24 - num16;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num16;
			num22 = num24 - num20;
			array[1] = num22 + num21;
			double num25 = num23 + num18;
			num19 = num25 - num23;
			num20 = num25 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array[2] = num22 + num21;
			array[3] = num25;
			double num26 = Estimate(4, array);
			double num27 = ccwerrboundB * detsum;
			if (num26 >= num27 || 0.0 - num26 >= num27)
			{
				return num26;
			}
			num19 = pa.x - num;
			num20 = num + num19;
			num21 = num19 - pc.x;
			num22 = pa.x - num20;
			double num28 = num22 + num21;
			num19 = pb.x - num2;
			num20 = num2 + num19;
			num21 = num19 - pc.x;
			num22 = pb.x - num20;
			double num29 = num22 + num21;
			num19 = pa.y - num3;
			num20 = num3 + num19;
			num21 = num19 - pc.y;
			num22 = pa.y - num20;
			double num30 = num22 + num21;
			num19 = pb.y - num4;
			num20 = num4 + num19;
			num21 = num19 - pc.y;
			num22 = pb.y - num20;
			double num31 = num22 + num21;
			if (num28 == 0.0 && num30 == 0.0 && num29 == 0.0 && num31 == 0.0)
			{
				return num26;
			}
			num27 = ccwerrboundC * detsum + resulterrbound * ((num26 >= 0.0) ? num26 : (0.0 - num26));
			num26 += num * num31 + num4 * num28 - (num3 * num29 + num2 * num30);
			if (num26 >= num27 || 0.0 - num26 >= num27)
			{
				return num26;
			}
			double num32 = num28 * num4;
			num6 = splitter * num28;
			num7 = num6 - num28;
			num8 = num6 - num7;
			num9 = num28 - num8;
			num6 = splitter * num4;
			num7 = num6 - num4;
			num10 = num6 - num7;
			num11 = num4 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			double num33 = num9 * num11 - num14;
			double num34 = num30 * num2;
			num6 = splitter * num30;
			num7 = num6 - num30;
			num8 = num6 - num7;
			num9 = num30 - num8;
			num6 = splitter * num2;
			num7 = num6 - num2;
			num10 = num6 - num7;
			num11 = num2 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			double num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array2[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array2[1] = num22 + num21;
			double num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array2[2] = num22 + num21;
			array2[3] = num36;
			int elen = FastExpansionSumZeroElim(4, array, 4, array2, array3);
			num32 = num * num31;
			num6 = splitter * num;
			num7 = num6 - num;
			num8 = num6 - num7;
			num9 = num - num8;
			num6 = splitter * num31;
			num7 = num6 - num31;
			num10 = num6 - num7;
			num11 = num31 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num33 = num9 * num11 - num14;
			num34 = num3 * num29;
			num6 = splitter * num3;
			num7 = num6 - num3;
			num8 = num6 - num7;
			num9 = num3 - num8;
			num6 = splitter * num29;
			num7 = num6 - num29;
			num10 = num6 - num7;
			num11 = num29 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array2[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array2[1] = num22 + num21;
			num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array2[2] = num22 + num21;
			array2[3] = num36;
			int elen2 = FastExpansionSumZeroElim(elen, array3, 4, array2, array4);
			num32 = num28 * num31;
			num6 = splitter * num28;
			num7 = num6 - num28;
			num8 = num6 - num7;
			num9 = num28 - num8;
			num6 = splitter * num31;
			num7 = num6 - num31;
			num10 = num6 - num7;
			num11 = num31 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num33 = num9 * num11 - num14;
			num34 = num30 * num29;
			num6 = splitter * num30;
			num7 = num6 - num30;
			num8 = num6 - num7;
			num9 = num30 - num8;
			num6 = splitter * num29;
			num7 = num6 - num29;
			num10 = num6 - num7;
			num11 = num29 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array2[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array2[1] = num22 + num21;
			num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array2[2] = num22 + num21;
			array2[3] = num36;
			int num37 = FastExpansionSumZeroElim(elen2, array4, 4, array2, array5);
			return array5[num37 - 1];
		}

		private double InCircleAdapt(Point pa, Point pb, Point pc, Point pd, double permanent)
		{
			double[] array = new double[4];
			double[] array2 = new double[4];
			double[] array3 = new double[4];
			double[] array4 = new double[4];
			double[] array5 = new double[4];
			double[] array6 = new double[4];
			double[] array7 = new double[5];
			double[] array8 = new double[5];
			double[] array9 = new double[8];
			double[] array10 = new double[8];
			double[] array11 = new double[8];
			double[] array12 = new double[8];
			double[] array13 = new double[8];
			double[] array14 = new double[8];
			double[] array15 = new double[8];
			double[] array16 = new double[8];
			double[] array17 = new double[8];
			double[] array18 = new double[8];
			double[] array19 = new double[8];
			double[] array20 = new double[8];
			double[] array21 = new double[8];
			double[] array22 = new double[8];
			double[] array23 = new double[8];
			double[] array24 = new double[8];
			double[] array25 = new double[8];
			double[] array26 = new double[8];
			int elen = 0;
			int elen2 = 0;
			int elen3 = 0;
			int elen4 = 0;
			int elen5 = 0;
			int elen6 = 0;
			double[] array27 = new double[16];
			double[] array28 = new double[16];
			double[] array29 = new double[16];
			double[] array30 = new double[16];
			double[] array31 = new double[16];
			double[] array32 = new double[16];
			double[] array33 = new double[8];
			double[] array34 = new double[8];
			double[] array35 = new double[8];
			double[] array36 = new double[8];
			double[] array37 = new double[8];
			double[] array38 = new double[8];
			double[] array39 = new double[8];
			double[] array40 = new double[8];
			double[] array41 = new double[8];
			double[] array42 = new double[4];
			double[] array43 = new double[4];
			double[] array44 = new double[4];
			double num = pa.x - pd.x;
			double num2 = pb.x - pd.x;
			double num3 = pc.x - pd.x;
			double num4 = pa.y - pd.y;
			double num5 = pb.y - pd.y;
			double num6 = pc.y - pd.y;
			num = pa.x - pd.x;
			num2 = pb.x - pd.x;
			num3 = pc.x - pd.x;
			num4 = pa.y - pd.y;
			num5 = pb.y - pd.y;
			num6 = pc.y - pd.y;
			double num7 = num2 * num6;
			double num8 = splitter * num2;
			double num9 = num8 - num2;
			double num10 = num8 - num9;
			double num11 = num2 - num10;
			num8 = splitter * num6;
			num9 = num8 - num6;
			double num12 = num8 - num9;
			double num13 = num6 - num12;
			double num14 = num7 - num10 * num12;
			double num15 = num14 - num11 * num12;
			double num16 = num15 - num10 * num13;
			double num17 = num11 * num13 - num16;
			double num18 = num3 * num5;
			num8 = splitter * num3;
			num9 = num8 - num3;
			num10 = num8 - num9;
			num11 = num3 - num10;
			num8 = splitter * num5;
			num9 = num8 - num5;
			num12 = num8 - num9;
			num13 = num5 - num12;
			num14 = num18 - num10 * num12;
			num15 = num14 - num11 * num12;
			num16 = num15 - num10 * num13;
			double num19 = num11 * num13 - num16;
			double num20 = num17 - num19;
			double num21 = num17 - num20;
			double num22 = num20 + num21;
			double num23 = num21 - num19;
			double num24 = num17 - num22;
			array[0] = num24 + num23;
			double num25 = num7 + num20;
			num21 = num25 - num7;
			num22 = num25 - num21;
			num23 = num20 - num21;
			num24 = num7 - num22;
			double num26 = num24 + num23;
			num20 = num26 - num18;
			num21 = num26 - num20;
			num22 = num20 + num21;
			num23 = num21 - num18;
			num24 = num26 - num22;
			array[1] = num24 + num23;
			double num27 = num25 + num20;
			num21 = num27 - num25;
			num22 = num27 - num21;
			num23 = num20 - num21;
			num24 = num25 - num22;
			array[2] = num24 + num23;
			array[3] = num27;
			int elen7 = ScaleExpansionZeroElim(4, array, num, axbc);
			int elen8 = ScaleExpansionZeroElim(elen7, axbc, num, axxbc);
			int elen9 = ScaleExpansionZeroElim(4, array, num4, aybc);
			int flen = ScaleExpansionZeroElim(elen9, aybc, num4, ayybc);
			int elen10 = FastExpansionSumZeroElim(elen8, axxbc, flen, ayybc, adet);
			double num28 = num3 * num4;
			num8 = splitter * num3;
			num9 = num8 - num3;
			num10 = num8 - num9;
			num11 = num3 - num10;
			num8 = splitter * num4;
			num9 = num8 - num4;
			num12 = num8 - num9;
			num13 = num4 - num12;
			num14 = num28 - num10 * num12;
			num15 = num14 - num11 * num12;
			num16 = num15 - num10 * num13;
			double num29 = num11 * num13 - num16;
			double num30 = num * num6;
			num8 = splitter * num;
			num9 = num8 - num;
			num10 = num8 - num9;
			num11 = num - num10;
			num8 = splitter * num6;
			num9 = num8 - num6;
			num12 = num8 - num9;
			num13 = num6 - num12;
			num14 = num30 - num10 * num12;
			num15 = num14 - num11 * num12;
			num16 = num15 - num10 * num13;
			double num31 = num11 * num13 - num16;
			num20 = num29 - num31;
			num21 = num29 - num20;
			num22 = num20 + num21;
			num23 = num21 - num31;
			num24 = num29 - num22;
			array2[0] = num24 + num23;
			num25 = num28 + num20;
			num21 = num25 - num28;
			num22 = num25 - num21;
			num23 = num20 - num21;
			num24 = num28 - num22;
			num26 = num24 + num23;
			num20 = num26 - num30;
			num21 = num26 - num20;
			num22 = num20 + num21;
			num23 = num21 - num30;
			num24 = num26 - num22;
			array2[1] = num24 + num23;
			double num32 = num25 + num20;
			num21 = num32 - num25;
			num22 = num32 - num21;
			num23 = num20 - num21;
			num24 = num25 - num22;
			array2[2] = num24 + num23;
			array2[3] = num32;
			int elen11 = ScaleExpansionZeroElim(4, array2, num2, bxca);
			int elen12 = ScaleExpansionZeroElim(elen11, bxca, num2, bxxca);
			int elen13 = ScaleExpansionZeroElim(4, array2, num5, byca);
			int flen2 = ScaleExpansionZeroElim(elen13, byca, num5, byyca);
			int flen3 = FastExpansionSumZeroElim(elen12, bxxca, flen2, byyca, bdet);
			double num33 = num * num5;
			num8 = splitter * num;
			num9 = num8 - num;
			num10 = num8 - num9;
			num11 = num - num10;
			num8 = splitter * num5;
			num9 = num8 - num5;
			num12 = num8 - num9;
			num13 = num5 - num12;
			num14 = num33 - num10 * num12;
			num15 = num14 - num11 * num12;
			num16 = num15 - num10 * num13;
			double num34 = num11 * num13 - num16;
			double num35 = num2 * num4;
			num8 = splitter * num2;
			num9 = num8 - num2;
			num10 = num8 - num9;
			num11 = num2 - num10;
			num8 = splitter * num4;
			num9 = num8 - num4;
			num12 = num8 - num9;
			num13 = num4 - num12;
			num14 = num35 - num10 * num12;
			num15 = num14 - num11 * num12;
			num16 = num15 - num10 * num13;
			double num36 = num11 * num13 - num16;
			num20 = num34 - num36;
			num21 = num34 - num20;
			num22 = num20 + num21;
			num23 = num21 - num36;
			num24 = num34 - num22;
			array3[0] = num24 + num23;
			num25 = num33 + num20;
			num21 = num25 - num33;
			num22 = num25 - num21;
			num23 = num20 - num21;
			num24 = num33 - num22;
			num26 = num24 + num23;
			num20 = num26 - num35;
			num21 = num26 - num20;
			num22 = num20 + num21;
			num23 = num21 - num35;
			num24 = num26 - num22;
			array3[1] = num24 + num23;
			double num37 = num25 + num20;
			num21 = num37 - num25;
			num22 = num37 - num21;
			num23 = num20 - num21;
			num24 = num25 - num22;
			array3[2] = num24 + num23;
			array3[3] = num37;
			int elen14 = ScaleExpansionZeroElim(4, array3, num3, cxab);
			int elen15 = ScaleExpansionZeroElim(elen14, cxab, num3, cxxab);
			int elen16 = ScaleExpansionZeroElim(4, array3, num6, cyab);
			int flen4 = ScaleExpansionZeroElim(elen16, cyab, num6, cyyab);
			int flen5 = FastExpansionSumZeroElim(elen15, cxxab, flen4, cyyab, cdet);
			int elen17 = FastExpansionSumZeroElim(elen10, adet, flen3, bdet, abdet);
			int num38 = FastExpansionSumZeroElim(elen17, abdet, flen5, cdet, fin1);
			double num39 = Estimate(num38, fin1);
			double num40 = iccerrboundB * permanent;
			if (num39 >= num40 || 0.0 - num39 >= num40)
			{
				return num39;
			}
			num21 = pa.x - num;
			num22 = num + num21;
			num23 = num21 - pd.x;
			num24 = pa.x - num22;
			double num41 = num24 + num23;
			num21 = pa.y - num4;
			num22 = num4 + num21;
			num23 = num21 - pd.y;
			num24 = pa.y - num22;
			double num42 = num24 + num23;
			num21 = pb.x - num2;
			num22 = num2 + num21;
			num23 = num21 - pd.x;
			num24 = pb.x - num22;
			double num43 = num24 + num23;
			num21 = pb.y - num5;
			num22 = num5 + num21;
			num23 = num21 - pd.y;
			num24 = pb.y - num22;
			double num44 = num24 + num23;
			num21 = pc.x - num3;
			num22 = num3 + num21;
			num23 = num21 - pd.x;
			num24 = pc.x - num22;
			double num45 = num24 + num23;
			num21 = pc.y - num6;
			num22 = num6 + num21;
			num23 = num21 - pd.y;
			num24 = pc.y - num22;
			double num46 = num24 + num23;
			if (num41 == 0.0 && num43 == 0.0 && num45 == 0.0 && num42 == 0.0 && num44 == 0.0 && num46 == 0.0)
			{
				return num39;
			}
			num40 = iccerrboundC * permanent + resulterrbound * ((num39 >= 0.0) ? num39 : (0.0 - num39));
			num39 += (num * num + num4 * num4) * (num2 * num46 + num6 * num43 - (num5 * num45 + num3 * num44)) + 2.0 * (num * num41 + num4 * num42) * (num2 * num6 - num5 * num3) + ((num2 * num2 + num5 * num5) * (num3 * num42 + num4 * num45 - (num6 * num41 + num * num46)) + 2.0 * (num2 * num43 + num5 * num44) * (num3 * num4 - num6 * num)) + ((num3 * num3 + num6 * num6) * (num * num44 + num5 * num41 - (num4 * num43 + num2 * num42)) + 2.0 * (num3 * num45 + num6 * num46) * (num * num5 - num4 * num2));
			if (num39 >= num40 || 0.0 - num39 >= num40)
			{
				return num39;
			}
			double[] array45 = fin1;
			double[] array46 = fin2;
			if (num43 != 0.0 || num44 != 0.0 || num45 != 0.0 || num46 != 0.0)
			{
				double num47 = num * num;
				num8 = splitter * num;
				num9 = num8 - num;
				num10 = num8 - num9;
				num11 = num - num10;
				num14 = num47 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num48 = num11 * num11 - num16;
				double num49 = num4 * num4;
				num8 = splitter * num4;
				num9 = num8 - num4;
				num10 = num8 - num9;
				num11 = num4 - num10;
				num14 = num49 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num50 = num11 * num11 - num16;
				num20 = num48 + num50;
				num21 = num20 - num48;
				num22 = num20 - num21;
				num23 = num50 - num21;
				num24 = num48 - num22;
				array4[0] = num24 + num23;
				num25 = num47 + num20;
				num21 = num25 - num47;
				num22 = num25 - num21;
				num23 = num20 - num21;
				num24 = num47 - num22;
				num26 = num24 + num23;
				num20 = num26 + num49;
				num21 = num20 - num26;
				num22 = num20 - num21;
				num23 = num49 - num21;
				num24 = num26 - num22;
				array4[1] = num24 + num23;
				double num51 = num25 + num20;
				num21 = num51 - num25;
				num22 = num51 - num21;
				num23 = num20 - num21;
				num24 = num25 - num22;
				array4[2] = num24 + num23;
				array4[3] = num51;
			}
			if (num45 != 0.0 || num46 != 0.0 || num41 != 0.0 || num42 != 0.0)
			{
				double num52 = num2 * num2;
				num8 = splitter * num2;
				num9 = num8 - num2;
				num10 = num8 - num9;
				num11 = num2 - num10;
				num14 = num52 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num53 = num11 * num11 - num16;
				double num54 = num5 * num5;
				num8 = splitter * num5;
				num9 = num8 - num5;
				num10 = num8 - num9;
				num11 = num5 - num10;
				num14 = num54 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num55 = num11 * num11 - num16;
				num20 = num53 + num55;
				num21 = num20 - num53;
				num22 = num20 - num21;
				num23 = num55 - num21;
				num24 = num53 - num22;
				array5[0] = num24 + num23;
				num25 = num52 + num20;
				num21 = num25 - num52;
				num22 = num25 - num21;
				num23 = num20 - num21;
				num24 = num52 - num22;
				num26 = num24 + num23;
				num20 = num26 + num54;
				num21 = num20 - num26;
				num22 = num20 - num21;
				num23 = num54 - num21;
				num24 = num26 - num22;
				array5[1] = num24 + num23;
				double num56 = num25 + num20;
				num21 = num56 - num25;
				num22 = num56 - num21;
				num23 = num20 - num21;
				num24 = num25 - num22;
				array5[2] = num24 + num23;
				array5[3] = num56;
			}
			if (num41 != 0.0 || num42 != 0.0 || num43 != 0.0 || num44 != 0.0)
			{
				double num57 = num3 * num3;
				num8 = splitter * num3;
				num9 = num8 - num3;
				num10 = num8 - num9;
				num11 = num3 - num10;
				num14 = num57 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num58 = num11 * num11 - num16;
				double num59 = num6 * num6;
				num8 = splitter * num6;
				num9 = num8 - num6;
				num10 = num8 - num9;
				num11 = num6 - num10;
				num14 = num59 - num10 * num10;
				num16 = num14 - (num10 + num10) * num11;
				double num60 = num11 * num11 - num16;
				num20 = num58 + num60;
				num21 = num20 - num58;
				num22 = num20 - num21;
				num23 = num60 - num21;
				num24 = num58 - num22;
				array6[0] = num24 + num23;
				num25 = num57 + num20;
				num21 = num25 - num57;
				num22 = num25 - num21;
				num23 = num20 - num21;
				num24 = num57 - num22;
				num26 = num24 + num23;
				num20 = num26 + num59;
				num21 = num20 - num26;
				num22 = num20 - num21;
				num23 = num59 - num21;
				num24 = num26 - num22;
				array6[1] = num24 + num23;
				double num61 = num25 + num20;
				num21 = num61 - num25;
				num22 = num61 - num21;
				num23 = num20 - num21;
				num24 = num25 - num22;
				array6[2] = num24 + num23;
				array6[3] = num61;
			}
			if (num41 != 0.0)
			{
				elen = ScaleExpansionZeroElim(4, array, num41, array21);
				int elen18 = ScaleExpansionZeroElim(elen, array21, 2.0 * num, temp16a);
				int elen19 = ScaleExpansionZeroElim(4, array6, num41, array10);
				int flen6 = ScaleExpansionZeroElim(elen19, array10, num5, temp16b);
				int elen20 = ScaleExpansionZeroElim(4, array5, num41, array9);
				int elen21 = ScaleExpansionZeroElim(elen20, array9, 0.0 - num6, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num42 != 0.0)
			{
				elen2 = ScaleExpansionZeroElim(4, array, num42, array22);
				int elen18 = ScaleExpansionZeroElim(elen2, array22, 2.0 * num4, temp16a);
				int elen22 = ScaleExpansionZeroElim(4, array5, num42, array11);
				int flen6 = ScaleExpansionZeroElim(elen22, array11, num3, temp16b);
				int elen23 = ScaleExpansionZeroElim(4, array6, num42, array12);
				int elen21 = ScaleExpansionZeroElim(elen23, array12, 0.0 - num2, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num43 != 0.0)
			{
				elen3 = ScaleExpansionZeroElim(4, array2, num43, array23);
				int elen18 = ScaleExpansionZeroElim(elen3, array23, 2.0 * num2, temp16a);
				int elen24 = ScaleExpansionZeroElim(4, array4, num43, array13);
				int flen6 = ScaleExpansionZeroElim(elen24, array13, num6, temp16b);
				int elen25 = ScaleExpansionZeroElim(4, array6, num43, array14);
				int elen21 = ScaleExpansionZeroElim(elen25, array14, 0.0 - num4, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num44 != 0.0)
			{
				elen4 = ScaleExpansionZeroElim(4, array2, num44, array24);
				int elen18 = ScaleExpansionZeroElim(elen4, array24, 2.0 * num5, temp16a);
				int elen26 = ScaleExpansionZeroElim(4, array6, num44, array16);
				int flen6 = ScaleExpansionZeroElim(elen26, array16, num, temp16b);
				int elen27 = ScaleExpansionZeroElim(4, array4, num44, array15);
				int elen21 = ScaleExpansionZeroElim(elen27, array15, 0.0 - num3, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num45 != 0.0)
			{
				elen5 = ScaleExpansionZeroElim(4, array3, num45, array25);
				int elen18 = ScaleExpansionZeroElim(elen5, array25, 2.0 * num3, temp16a);
				int elen28 = ScaleExpansionZeroElim(4, array5, num45, array18);
				int flen6 = ScaleExpansionZeroElim(elen28, array18, num4, temp16b);
				int elen29 = ScaleExpansionZeroElim(4, array4, num45, array17);
				int elen21 = ScaleExpansionZeroElim(elen29, array17, 0.0 - num5, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num46 != 0.0)
			{
				elen6 = ScaleExpansionZeroElim(4, array3, num46, array26);
				int elen18 = ScaleExpansionZeroElim(elen6, array26, 2.0 * num6, temp16a);
				int elen30 = ScaleExpansionZeroElim(4, array4, num46, array19);
				int flen6 = ScaleExpansionZeroElim(elen30, array19, num2, temp16b);
				int elen31 = ScaleExpansionZeroElim(4, array5, num46, array20);
				int elen21 = ScaleExpansionZeroElim(elen31, array20, 0.0 - num, temp16c);
				int flen7 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32a);
				int flen8 = FastExpansionSumZeroElim(elen21, temp16c, flen7, temp32a, temp48);
				num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
				double[] array47 = array45;
				array45 = array46;
				array46 = array47;
			}
			if (num41 != 0.0 || num42 != 0.0)
			{
				int elen32;
				int elen33;
				if (num43 != 0.0 || num44 != 0.0 || num45 != 0.0 || num46 != 0.0)
				{
					double num62 = num43 * num6;
					num8 = splitter * num43;
					num9 = num8 - num43;
					num10 = num8 - num9;
					num11 = num43 - num10;
					num8 = splitter * num6;
					num9 = num8 - num6;
					num12 = num8 - num9;
					num13 = num6 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num63 = num11 * num13 - num16;
					double num64 = num2 * num46;
					num8 = splitter * num2;
					num9 = num8 - num2;
					num10 = num8 - num9;
					num11 = num2 - num10;
					num8 = splitter * num46;
					num9 = num8 - num46;
					num12 = num8 - num9;
					num13 = num46 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array7[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array7[1] = num24 + num23;
					double num66 = num25 + num20;
					num21 = num66 - num25;
					num22 = num66 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array7[2] = num24 + num23;
					array7[3] = num66;
					double num67 = 0.0 - num5;
					num62 = num45 * num67;
					num8 = splitter * num45;
					num9 = num8 - num45;
					num10 = num8 - num9;
					num11 = num45 - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num67 = 0.0 - num44;
					num64 = num3 * num67;
					num8 = splitter * num3;
					num9 = num8 - num3;
					num10 = num8 - num9;
					num11 = num3 - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array8[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array8[1] = num24 + num23;
					double num68 = num25 + num20;
					num21 = num68 - num25;
					num22 = num68 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array8[2] = num24 + num23;
					array8[3] = num68;
					elen32 = FastExpansionSumZeroElim(4, array7, 4, array8, array40);
					num62 = num43 * num46;
					num8 = splitter * num43;
					num9 = num8 - num43;
					num10 = num8 - num9;
					num11 = num43 - num10;
					num8 = splitter * num46;
					num9 = num8 - num46;
					num12 = num8 - num9;
					num13 = num46 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num64 = num45 * num44;
					num8 = splitter * num45;
					num9 = num8 - num45;
					num10 = num8 - num9;
					num11 = num45 - num10;
					num8 = splitter * num44;
					num9 = num8 - num44;
					num12 = num8 - num9;
					num13 = num44 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 - num65;
					num21 = num63 - num20;
					num22 = num20 + num21;
					num23 = num21 - num65;
					num24 = num63 - num22;
					array43[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 - num64;
					num21 = num26 - num20;
					num22 = num20 + num21;
					num23 = num21 - num64;
					num24 = num26 - num22;
					array43[1] = num24 + num23;
					double num69 = num25 + num20;
					num21 = num69 - num25;
					num22 = num69 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array43[2] = num24 + num23;
					array43[3] = num69;
					elen33 = 4;
				}
				else
				{
					array40[0] = 0.0;
					elen32 = 1;
					array43[0] = 0.0;
					elen33 = 1;
				}
				if (num41 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen, array21, num41, temp16a);
					int elen34 = ScaleExpansionZeroElim(elen32, array40, num41, array27);
					int flen7 = ScaleExpansionZeroElim(elen34, array27, 2.0 * num, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					if (num44 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array6, num41, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num44, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					if (num46 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array5, 0.0 - num41, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num46, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					flen7 = ScaleExpansionZeroElim(elen34, array27, num41, temp32a);
					int elen36 = ScaleExpansionZeroElim(elen33, array43, num41, array33);
					elen18 = ScaleExpansionZeroElim(elen36, array33, 2.0 * num, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen36, array33, num41, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
				if (num42 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen2, array22, num42, temp16a);
					int elen37 = ScaleExpansionZeroElim(elen32, array40, num42, array28);
					int flen7 = ScaleExpansionZeroElim(elen37, array28, 2.0 * num4, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					flen7 = ScaleExpansionZeroElim(elen37, array28, num42, temp32a);
					int elen38 = ScaleExpansionZeroElim(elen33, array43, num42, array34);
					elen18 = ScaleExpansionZeroElim(elen38, array34, 2.0 * num4, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen38, array34, num42, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
			}
			if (num43 != 0.0 || num44 != 0.0)
			{
				int elen39;
				int elen40;
				if (num45 != 0.0 || num46 != 0.0 || num41 != 0.0 || num42 != 0.0)
				{
					double num62 = num45 * num4;
					num8 = splitter * num45;
					num9 = num8 - num45;
					num10 = num8 - num9;
					num11 = num45 - num10;
					num8 = splitter * num4;
					num9 = num8 - num4;
					num12 = num8 - num9;
					num13 = num4 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num63 = num11 * num13 - num16;
					double num64 = num3 * num42;
					num8 = splitter * num3;
					num9 = num8 - num3;
					num10 = num8 - num9;
					num11 = num3 - num10;
					num8 = splitter * num42;
					num9 = num8 - num42;
					num12 = num8 - num9;
					num13 = num42 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array7[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array7[1] = num24 + num23;
					double num66 = num25 + num20;
					num21 = num66 - num25;
					num22 = num66 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array7[2] = num24 + num23;
					array7[3] = num66;
					double num67 = 0.0 - num6;
					num62 = num41 * num67;
					num8 = splitter * num41;
					num9 = num8 - num41;
					num10 = num8 - num9;
					num11 = num41 - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num67 = 0.0 - num46;
					num64 = num * num67;
					num8 = splitter * num;
					num9 = num8 - num;
					num10 = num8 - num9;
					num11 = num - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array8[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array8[1] = num24 + num23;
					double num68 = num25 + num20;
					num21 = num68 - num25;
					num22 = num68 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array8[2] = num24 + num23;
					array8[3] = num68;
					elen39 = FastExpansionSumZeroElim(4, array7, 4, array8, array41);
					num62 = num45 * num42;
					num8 = splitter * num45;
					num9 = num8 - num45;
					num10 = num8 - num9;
					num11 = num45 - num10;
					num8 = splitter * num42;
					num9 = num8 - num42;
					num12 = num8 - num9;
					num13 = num42 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num64 = num41 * num46;
					num8 = splitter * num41;
					num9 = num8 - num41;
					num10 = num8 - num9;
					num11 = num41 - num10;
					num8 = splitter * num46;
					num9 = num8 - num46;
					num12 = num8 - num9;
					num13 = num46 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 - num65;
					num21 = num63 - num20;
					num22 = num20 + num21;
					num23 = num21 - num65;
					num24 = num63 - num22;
					array44[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 - num64;
					num21 = num26 - num20;
					num22 = num20 + num21;
					num23 = num21 - num64;
					num24 = num26 - num22;
					array44[1] = num24 + num23;
					double num70 = num25 + num20;
					num21 = num70 - num25;
					num22 = num70 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array44[2] = num24 + num23;
					array44[3] = num70;
					elen40 = 4;
				}
				else
				{
					array41[0] = 0.0;
					elen39 = 1;
					array44[0] = 0.0;
					elen40 = 1;
				}
				if (num43 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen3, array23, num43, temp16a);
					int elen41 = ScaleExpansionZeroElim(elen39, array41, num43, array29);
					int flen7 = ScaleExpansionZeroElim(elen41, array29, 2.0 * num2, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					if (num46 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array4, num43, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num46, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					if (num42 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array6, 0.0 - num43, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num42, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					flen7 = ScaleExpansionZeroElim(elen41, array29, num43, temp32a);
					int elen42 = ScaleExpansionZeroElim(elen40, array44, num43, array35);
					elen18 = ScaleExpansionZeroElim(elen42, array35, 2.0 * num2, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen42, array35, num43, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
				if (num44 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen4, array24, num44, temp16a);
					int elen43 = ScaleExpansionZeroElim(elen39, array41, num44, array30);
					int flen7 = ScaleExpansionZeroElim(elen43, array30, 2.0 * num5, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					flen7 = ScaleExpansionZeroElim(elen43, array30, num44, temp32a);
					int elen44 = ScaleExpansionZeroElim(elen40, array44, num44, array36);
					elen18 = ScaleExpansionZeroElim(elen44, array36, 2.0 * num5, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen44, array36, num44, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
			}
			if (num45 != 0.0 || num46 != 0.0)
			{
				int elen45;
				int elen46;
				if (num41 != 0.0 || num42 != 0.0 || num43 != 0.0 || num44 != 0.0)
				{
					double num62 = num41 * num5;
					num8 = splitter * num41;
					num9 = num8 - num41;
					num10 = num8 - num9;
					num11 = num41 - num10;
					num8 = splitter * num5;
					num9 = num8 - num5;
					num12 = num8 - num9;
					num13 = num5 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num63 = num11 * num13 - num16;
					double num64 = num * num44;
					num8 = splitter * num;
					num9 = num8 - num;
					num10 = num8 - num9;
					num11 = num - num10;
					num8 = splitter * num44;
					num9 = num8 - num44;
					num12 = num8 - num9;
					num13 = num44 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					double num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array7[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array7[1] = num24 + num23;
					double num66 = num25 + num20;
					num21 = num66 - num25;
					num22 = num66 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array7[2] = num24 + num23;
					array7[3] = num66;
					double num67 = 0.0 - num4;
					num62 = num43 * num67;
					num8 = splitter * num43;
					num9 = num8 - num43;
					num10 = num8 - num9;
					num11 = num43 - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num67 = 0.0 - num42;
					num64 = num2 * num67;
					num8 = splitter * num2;
					num9 = num8 - num2;
					num10 = num8 - num9;
					num11 = num2 - num10;
					num8 = splitter * num67;
					num9 = num8 - num67;
					num12 = num8 - num9;
					num13 = num67 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 + num65;
					num21 = num20 - num63;
					num22 = num20 - num21;
					num23 = num65 - num21;
					num24 = num63 - num22;
					array8[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 + num64;
					num21 = num20 - num26;
					num22 = num20 - num21;
					num23 = num64 - num21;
					num24 = num26 - num22;
					array8[1] = num24 + num23;
					double num68 = num25 + num20;
					num21 = num68 - num25;
					num22 = num68 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array8[2] = num24 + num23;
					array8[3] = num68;
					elen45 = FastExpansionSumZeroElim(4, array7, 4, array8, array39);
					num62 = num41 * num44;
					num8 = splitter * num41;
					num9 = num8 - num41;
					num10 = num8 - num9;
					num11 = num41 - num10;
					num8 = splitter * num44;
					num9 = num8 - num44;
					num12 = num8 - num9;
					num13 = num44 - num12;
					num14 = num62 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num63 = num11 * num13 - num16;
					num64 = num43 * num42;
					num8 = splitter * num43;
					num9 = num8 - num43;
					num10 = num8 - num9;
					num11 = num43 - num10;
					num8 = splitter * num42;
					num9 = num8 - num42;
					num12 = num8 - num9;
					num13 = num42 - num12;
					num14 = num64 - num10 * num12;
					num15 = num14 - num11 * num12;
					num16 = num15 - num10 * num13;
					num65 = num11 * num13 - num16;
					num20 = num63 - num65;
					num21 = num63 - num20;
					num22 = num20 + num21;
					num23 = num21 - num65;
					num24 = num63 - num22;
					array42[0] = num24 + num23;
					num25 = num62 + num20;
					num21 = num25 - num62;
					num22 = num25 - num21;
					num23 = num20 - num21;
					num24 = num62 - num22;
					num26 = num24 + num23;
					num20 = num26 - num64;
					num21 = num26 - num20;
					num22 = num20 + num21;
					num23 = num21 - num64;
					num24 = num26 - num22;
					array42[1] = num24 + num23;
					double num71 = num25 + num20;
					num21 = num71 - num25;
					num22 = num71 - num21;
					num23 = num20 - num21;
					num24 = num25 - num22;
					array42[2] = num24 + num23;
					array42[3] = num71;
					elen46 = 4;
				}
				else
				{
					array39[0] = 0.0;
					elen45 = 1;
					array42[0] = 0.0;
					elen46 = 1;
				}
				if (num45 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen5, array25, num45, temp16a);
					int elen47 = ScaleExpansionZeroElim(elen45, array39, num45, array31);
					int flen7 = ScaleExpansionZeroElim(elen47, array31, 2.0 * num3, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					if (num42 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array5, num45, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num42, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					if (num44 != 0.0)
					{
						int elen35 = ScaleExpansionZeroElim(4, array4, 0.0 - num45, temp8);
						elen18 = ScaleExpansionZeroElim(elen35, temp8, num44, temp16a);
						num38 = FastExpansionSumZeroElim(num38, array45, elen18, temp16a, array46);
						array47 = array45;
						array45 = array46;
						array46 = array47;
					}
					flen7 = ScaleExpansionZeroElim(elen47, array31, num45, temp32a);
					int elen48 = ScaleExpansionZeroElim(elen46, array42, num45, array37);
					elen18 = ScaleExpansionZeroElim(elen48, array37, 2.0 * num3, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen48, array37, num45, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
				if (num46 != 0.0)
				{
					int elen18 = ScaleExpansionZeroElim(elen6, array26, num46, temp16a);
					int elen49 = ScaleExpansionZeroElim(elen45, array39, num46, array32);
					int flen7 = ScaleExpansionZeroElim(elen49, array32, 2.0 * num6, temp32a);
					int flen8 = FastExpansionSumZeroElim(elen18, temp16a, flen7, temp32a, temp48);
					num38 = FastExpansionSumZeroElim(num38, array45, flen8, temp48, array46);
					double[] array47 = array45;
					array45 = array46;
					array46 = array47;
					flen7 = ScaleExpansionZeroElim(elen49, array32, num46, temp32a);
					int elen50 = ScaleExpansionZeroElim(elen46, array42, num46, array38);
					elen18 = ScaleExpansionZeroElim(elen50, array38, 2.0 * num6, temp16a);
					int flen6 = ScaleExpansionZeroElim(elen50, array38, num46, temp16b);
					int flen9 = FastExpansionSumZeroElim(elen18, temp16a, flen6, temp16b, temp32b);
					int flen10 = FastExpansionSumZeroElim(flen7, temp32a, flen9, temp32b, temp64);
					num38 = FastExpansionSumZeroElim(num38, array45, flen10, temp64, array46);
					array47 = array45;
					array45 = array46;
					array46 = array47;
				}
			}
			return array45[num38 - 1];
		}

		private void AllocateWorkspace()
		{
			fin1 = new double[1152];
			fin2 = new double[1152];
			abdet = new double[64];
			axbc = new double[8];
			axxbc = new double[16];
			aybc = new double[8];
			ayybc = new double[16];
			adet = new double[32];
			bxca = new double[8];
			bxxca = new double[16];
			byca = new double[8];
			byyca = new double[16];
			bdet = new double[32];
			cxab = new double[8];
			cxxab = new double[16];
			cyab = new double[8];
			cyyab = new double[16];
			cdet = new double[32];
			temp8 = new double[8];
			temp16a = new double[16];
			temp16b = new double[16];
			temp16c = new double[16];
			temp32a = new double[32];
			temp32b = new double[32];
			temp48 = new double[48];
			temp64 = new double[64];
		}
	}
}
