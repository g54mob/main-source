using System;

namespace MathNet.Numerics
{
	public static class Window
	{
		public static double[] Hamming(int width)
		{
			double num = Math.PI * 2.0 / ((double)width - 1.0);
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.53836 + -0.46164 * Math.Cos((double)i * num);
			}
			return array;
		}

		public static double[] HammingPeriodic(int width)
		{
			double num = Math.PI * 2.0 / (double)width;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.53836 + -0.46164 * Math.Cos((double)i * num);
			}
			return array;
		}

		public static double[] Hann(int width)
		{
			double num = Math.PI * 2.0 / ((double)width - 1.0);
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.5 - 0.5 * Math.Cos((double)i * num);
			}
			return array;
		}

		public static double[] HannPeriodic(int width)
		{
			double num = Math.PI * 2.0 / (double)width;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.5 - 0.5 * Math.Cos((double)i * num);
			}
			return array;
		}

		public static double[] Cosine(int width)
		{
			double num = Math.PI / ((double)width - 1.0);
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Math.Sin((double)i * num);
			}
			return array;
		}

		public static double[] CosinePeriodic(int width)
		{
			double num = Math.PI / (double)width;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Math.Sin((double)i * num);
			}
			return array;
		}

		public static double[] Lanczos(int width)
		{
			double num = 2.0 / ((double)width - 1.0);
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Trig.Sinc((double)i * num - 1.0);
			}
			return array;
		}

		public static double[] LanczosPeriodic(int width)
		{
			double num = 2.0 / (double)width;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Trig.Sinc((double)i * num - 1.0);
			}
			return array;
		}

		public static double[] Gauss(int width, double sigma)
		{
			double num = (double)(width - 1) / 2.0;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = ((double)i - num) / (sigma * num);
				array[i] = Math.Exp(-0.5 * num2 * num2);
			}
			return array;
		}

		public static double[] Blackman(int width)
		{
			int num = width - 1;
			double num2 = Math.PI * 2.0 / (double)num;
			double num3 = 2.0 * num2;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.42 - 0.5 * Math.Cos((double)i * num2) + 0.08 * Math.Cos((double)i * num3);
			}
			return array;
		}

		public static double[] BlackmanHarris(int width)
		{
			int num = width - 1;
			double num2 = Math.PI * 2.0 / (double)num;
			double num3 = 2.0 * num2;
			double num4 = 3.0 * num2;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 287.0 / 800.0 + -0.48829 * Math.Cos(num2 * (double)i) + 0.14128 * Math.Cos(num3 * (double)i) + -0.01168 * Math.Cos(num4 * (double)i);
			}
			return array;
		}

		public static double[] BlackmanNuttall(int width)
		{
			int num = width - 1;
			double num2 = Math.PI * 2.0 / (double)num;
			double num3 = 2.0 * num2;
			double num4 = 3.0 * num2;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.3635819 + -0.4891775 * Math.Cos(num2 * (double)i) + 0.1365995 * Math.Cos(num3 * (double)i) + -0.0106411 * Math.Cos(num4 * (double)i);
			}
			return array;
		}

		public static double[] Bartlett(int width)
		{
			int num = width - 1;
			double num2 = 2.0 / (double)num;
			double num3 = (double)num / 2.0;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = num2 * (num3 - Math.Abs((double)i - num3));
			}
			return array;
		}

		public static double[] BartlettHann(int width)
		{
			int num = width - 1;
			double num2 = 1.0 / (double)num;
			double num3 = Math.PI * 2.0 / (double)num;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.62 + -0.48 * Math.Abs((double)i * num2 - 0.5) + -0.38 * Math.Cos((double)i * num3);
			}
			return array;
		}

		public static double[] Nuttall(int width)
		{
			int num = width - 1;
			double num2 = Math.PI * 2.0 / (double)num;
			double num3 = 2.0 * num2;
			double num4 = 3.0 * num2;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0.355768 + -0.487396 * Math.Cos(num2 * (double)i) + 0.144232 * Math.Cos(num3 * (double)i) + -0.012604 * Math.Cos(num4 * (double)i);
			}
			return array;
		}

		public static double[] FlatTop(int width)
		{
			int num = width - 1;
			double num2 = Math.PI * 2.0 / (double)num;
			double num3 = 2.0 * num2;
			double num4 = 3.0 * num2;
			double num5 = 4.0 * num2;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 1.0 + -1.93 * Math.Cos(num2 * (double)i) + 1.29 * Math.Cos(num3 * (double)i) + -0.388 * Math.Cos(num4 * (double)i) + 0.032 * Math.Cos(num5 * (double)i);
			}
			return array;
		}

		public static double[] Dirichlet(int width)
		{
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 1.0;
			}
			return array;
		}

		public static double[] Triangular(int width)
		{
			double num = 2.0 / (double)width;
			double num2 = (double)width / 2.0;
			double num3 = (double)(width - 1) / 2.0;
			double[] array = new double[width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = num * (num2 - Math.Abs((double)i - num3));
			}
			return array;
		}

		public static double[] Tukey(int width, double r = 0.5)
		{
			if (r <= 0.0)
			{
				return Generate.Repeat(width, 1.0);
			}
			if (r >= 1.0)
			{
				return Hann(width);
			}
			double[] array = new double[width];
			double num = (double)(width - 1) * r;
			double num2 = Math.PI * 2.0 / num;
			int num3 = (int)Math.Floor((double)(width - 1) * r * 0.5 + 1.0);
			int num4 = width - num3;
			for (int i = 0; i < num3; i++)
			{
				array[i] = (1.0 - Math.Cos((double)i * num2)) * 0.5;
			}
			for (int j = num3; j < num4; j++)
			{
				array[j] = 1.0;
			}
			for (int k = num4; k < width; k++)
			{
				array[k] = array[width - k - 1];
			}
			return array;
		}
	}
}
