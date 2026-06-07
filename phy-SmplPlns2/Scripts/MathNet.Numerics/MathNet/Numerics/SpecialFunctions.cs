using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathNet.Numerics
{
	public static class SpecialFunctions
	{
		private static class Amos
		{
			public static Complex Cairy(Complex z)
			{
				int id = 0;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z.Real, z.Imaginary, id, kode, ref air, ref aii, ref nz, ref ierr);
				return new Complex(air, aii);
			}

			public static Complex ScaledCairy(Complex z)
			{
				int id = 0;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z.Real, z.Imaginary, id, kode, ref air, ref aii, ref nz, ref ierr);
				return new Complex(air, aii);
			}

			public static double ScaledCairy(double z)
			{
				if (z < 0.0)
				{
					return double.NaN;
				}
				int id = 0;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z, 0.0, id, kode, ref air, ref aii, ref nz, ref ierr);
				return air;
			}

			public static Complex CairyPrime(Complex z)
			{
				int id = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z.Real, z.Imaginary, id, kode, ref air, ref aii, ref nz, ref ierr);
				return new Complex(air, aii);
			}

			public static Complex ScaledCairyPrime(Complex z)
			{
				int id = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z.Real, z.Imaginary, id, kode, ref air, ref aii, ref nz, ref ierr);
				return new Complex(air, aii);
			}

			public static double ScaledCairyPrime(double z)
			{
				if (z < 0.0)
				{
					return double.NaN;
				}
				int id = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double air = double.NaN;
				double aii = double.NaN;
				AmosHelper.zairy(z, 0.0, id, kode, ref air, ref aii, ref nz, ref ierr);
				return air;
			}

			public static Complex Cbiry(Complex z)
			{
				int id = 0;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double bir = double.NaN;
				double bii = double.NaN;
				AmosHelper.zbiry(z.Real, z.Imaginary, id, kode, ref bir, ref bii, ref nz, ref ierr);
				return new Complex(bir, bii);
			}

			public static Complex ScaledCbiry(Complex z)
			{
				int id = 0;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double bir = double.NaN;
				double bii = double.NaN;
				AmosHelper.zbiry(z.Real, z.Imaginary, id, kode, ref bir, ref bii, ref nz, ref ierr);
				return new Complex(bir, bii);
			}

			public static Complex CbiryPrime(Complex z)
			{
				int id = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double bir = double.NaN;
				double bii = double.NaN;
				AmosHelper.zbiry(z.Real, z.Imaginary, id, kode, ref bir, ref bii, ref nz, ref ierr);
				return new Complex(bir, bii);
			}

			public static Complex ScaledCbiryPrime(Complex z)
			{
				int id = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double bir = double.NaN;
				double bii = double.NaN;
				AmosHelper.zbiry(z.Real, z.Imaginary, id, kode, ref bir, ref bii, ref nz, ref ierr);
				return new Complex(bir, bii);
			}

			public static Complex Cbesj(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num2];
				double[] array2 = new double[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesj(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, ref ierr);
				Complex jy = new Complex(array[0], array2[0]);
				if (ierr == 2)
				{
					jy = ScaledCbesj(v, z);
					jy = new Complex(jy.Real * double.PositiveInfinity, jy.Imaginary * double.PositiveInfinity);
				}
				if (num == -1 && !ReflectJY(ref jy, v))
				{
					double[] array3 = new double[num2];
					double[] array4 = new double[num2];
					double[] array5 = new double[num2];
					double[] array6 = new double[num2];
					for (int j = 0; j < num2; j++)
					{
						array3[j] = double.NaN;
						array4[j] = double.NaN;
						array5[j] = double.NaN;
						array6[j] = double.NaN;
					}
					AmosHelper.zbesy(z.Real, z.Imaginary, v, kode, num2, array3, array4, ref nz, array5, array6, ref ierr);
					jy = RotateJY(y: new Complex(array3[0], array4[0]), j: jy, v: v);
				}
				return jy;
			}

			public static double Cbesj(double v, double z)
			{
				if (z < 0.0 && v != (double)(int)v)
				{
					return double.NaN;
				}
				return Cbesj(v, new Complex(z, 0.0)).Real;
			}

			public static Complex ScaledCbesj(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num2];
				double[] array2 = new double[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesj(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, ref ierr);
				Complex jy = new Complex(array[0], array2[0]);
				if (num == -1 && !ReflectJY(ref jy, v))
				{
					double[] array3 = new double[num2];
					double[] array4 = new double[num2];
					double[] array5 = new double[num2];
					double[] array6 = new double[num2];
					for (int j = 0; j < num2; j++)
					{
						array3[j] = double.NaN;
						array4[j] = double.NaN;
						array5[j] = double.NaN;
						array6[j] = double.NaN;
					}
					AmosHelper.zbesy(z.Real, z.Imaginary, v, kode, num2, array3, array4, ref nz, array5, array6, ref ierr);
					return RotateJY(y: new Complex(array3[0], array4[0]), j: jy, v: v);
				}
				return jy;
			}

			public static double ScaledCbesj(double v, double z)
			{
				if (z < 0.0 && v != (double)(int)v)
				{
					return double.NaN;
				}
				return ScaledCbesj(v, new Complex(z, 0.0)).Real;
			}

			public static Complex Cbesy(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				Complex jy;
				if (z.Real == 0.0 && z.Imaginary == 0.0)
				{
					jy = new Complex(double.NegativeInfinity, 0.0);
				}
				else
				{
					double[] array = new double[num2];
					double[] array2 = new double[num2];
					double[] array3 = new double[num2];
					double[] array4 = new double[num2];
					for (int i = 0; i < num2; i++)
					{
						array[i] = double.NaN;
						array2[i] = double.NaN;
						array3[i] = double.NaN;
						array4[i] = double.NaN;
					}
					AmosHelper.zbesy(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, array3, array4, ref ierr);
					jy = new Complex(array[0], array2[0]);
					if (ierr == 2 && z.Real >= 0.0 && z.Imaginary == 0.0)
					{
						jy = new Complex(double.NegativeInfinity, 0.0);
					}
				}
				if (num == -1 && !ReflectJY(ref jy, v))
				{
					double[] array5 = new double[num2];
					double[] array6 = new double[num2];
					for (int j = 0; j < num2; j++)
					{
						array5[j] = double.NaN;
						array6[j] = double.NaN;
					}
					AmosHelper.zbesj(z.Real, z.Imaginary, v, kode, num2, array5, array6, ref nz, ref ierr);
					return RotateJY(y: new Complex(array5[0], array6[0]), j: jy, v: 0.0 - v);
				}
				return jy;
			}

			public static double Cbesy(double v, double x)
			{
				if (x < 0.0)
				{
					return double.NaN;
				}
				Complex z = new Complex(x, 0.0);
				return Cbesy(v, z).Real;
			}

			public static Complex ScaledCbesy(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num2];
				double[] array2 = new double[num2];
				double[] array3 = new double[num2];
				double[] array4 = new double[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
					array3[i] = double.NaN;
					array4[i] = double.NaN;
				}
				AmosHelper.zbesy(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, array3, array4, ref ierr);
				Complex jy = new Complex(array[0], array2[0]);
				if (ierr == 2 && z.Real >= 0.0 && z.Imaginary == 0.0)
				{
					jy = new Complex(double.PositiveInfinity, 0.0);
				}
				if (num == -1 && !ReflectJY(ref jy, v))
				{
					double[] array5 = new double[num2];
					double[] array6 = new double[num2];
					for (int j = 0; j < num2; j++)
					{
						array5[j] = double.NaN;
						array6[j] = double.NaN;
					}
					AmosHelper.zbesj(z.Real, z.Imaginary, v, kode, num2, array5, array6, ref nz, ref ierr);
					return RotateJY(y: new Complex(array5[0], array6[0]), j: jy, v: 0.0 - v);
				}
				return jy;
			}

			public static double ScaledCbesy(double v, double x)
			{
				if (x < 0.0)
				{
					return double.NaN;
				}
				return ScaledCbesy(v, new Complex(x, 0.0)).Real;
			}

			public static Complex Cbesi(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num2];
				double[] array2 = new double[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesi(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (ierr == 2)
				{
					if (z.Imaginary == 0.0 && (z.Real >= 0.0 || v == Math.Floor(v)))
					{
						complex = ((!(z.Real < 0.0) || v / 2.0 == Math.Floor(v / 2.0)) ? new Complex(double.PositiveInfinity, 0.0) : new Complex(double.NegativeInfinity, 0.0));
					}
					else
					{
						complex = ScaledCbesi(v * (double)num, z);
						complex = new Complex(complex.Real * double.PositiveInfinity, complex.Imaginary * double.PositiveInfinity);
					}
				}
				if (num == -1 && !ReflectI(v))
				{
					double[] array3 = new double[num2];
					double[] array4 = new double[num2];
					AmosHelper.zbesk(z.Real, z.Imaginary, v, kode, num2, array3, array4, ref nz, ref ierr);
					Complex k = new Complex(array3[0], array4[0]);
					complex = RotateI(complex, k, v);
				}
				return complex;
			}

			public static Complex ScaledCbesi(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num = -1;
				}
				int num2 = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num2];
				double[] array2 = new double[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesi(z.Real, z.Imaginary, v, kode, num2, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (num == -1 && !ReflectI(v))
				{
					double[] array3 = new double[num2];
					double[] array4 = new double[num2];
					AmosHelper.zbesk(z.Real, z.Imaginary, v, kode, num2, array3, array4, ref nz, ref ierr);
					Complex z2 = new Complex(array3[0], array4[0]);
					z2 = Rotate(z2, (0.0 - z.Imaginary) / Math.PI);
					if (z.Real > 0.0)
					{
						z2 = new Complex(z2.Real * Math.Exp(-2.0 * z.Real), z2.Imaginary * Math.Exp(-2.0 * z.Real));
					}
					return RotateI(complex, z2, v);
				}
				return complex;
			}

			public static double ScaledCbesi(double v, double x)
			{
				if (v != Math.Floor(v) && x < 0.0)
				{
					return double.NaN;
				}
				return ScaledCbesi(v, new Complex(x, 0.0)).Real;
			}

			public static Complex Cbesk(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (v < 0.0)
				{
					v = 0.0 - v;
				}
				int num = 1;
				int kode = 1;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesk(z.Real, z.Imaginary, v, kode, num, array, array2, ref nz, ref ierr);
				Complex result = new Complex(array[0], array2[0]);
				switch (ierr)
				{
				case 1:
					if (z.Real == 0.0 && z.Imaginary == 0.0)
					{
						result = new Complex(double.PositiveInfinity, 0.0);
					}
					break;
				case 2:
					if (z.Real >= 0.0 && z.Imaginary == 0.0)
					{
						result = new Complex(double.PositiveInfinity, 0.0);
					}
					break;
				}
				return result;
			}

			public static double Cbesk(double v, double z)
			{
				if (z < 0.0)
				{
					return double.NaN;
				}
				if (z == 0.0)
				{
					return double.PositiveInfinity;
				}
				if (z > 710.0 * (1.0 + Math.Abs(v)))
				{
					return 0.0;
				}
				Complex z2 = new Complex(z, 0.0);
				return Cbesk(v, z2).Real;
			}

			public static Complex ScaledCbesk(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (v < 0.0)
				{
					v = 0.0 - v;
				}
				int num = 1;
				int kode = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				AmosHelper.zbesk(z.Real, z.Imaginary, v, kode, num, array, array2, ref nz, ref ierr);
				Complex result = new Complex(array[0], array2[0]);
				if (ierr == 2 && z.Real >= 0.0 && z.Imaginary == 0.0)
				{
					result = new Complex(double.PositiveInfinity, 0.0);
				}
				return result;
			}

			public static double ScaledCbesk(double v, double z)
			{
				if (z < 0.0)
				{
					return double.NaN;
				}
				if (z == 0.0)
				{
					return double.PositiveInfinity;
				}
				Complex z2 = new Complex(z, 0.0);
				return ScaledCbesk(v, z2).Real;
			}

			public static Complex Cbesh1(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				int kode = 1;
				int m = 1;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				int num2 = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num2 = -1;
				}
				AmosHelper.zbesh(z.Real, z.Imaginary, v, kode, m, num, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (num2 == -1)
				{
					return Rotate(complex, v);
				}
				return complex;
			}

			public static Complex ScaledCbesh1(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				int kode = 2;
				int m = 1;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				int num2 = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num2 = -1;
				}
				AmosHelper.zbesh(z.Real, z.Imaginary, v, kode, m, num, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (num2 == -1)
				{
					return Rotate(complex, v);
				}
				return complex;
			}

			public static Complex Cbesh2(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (v == 0.0 && z.Real == 0.0 && z.Imaginary == 0.0)
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				int kode = 1;
				int m = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				int num2 = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num2 = -1;
				}
				AmosHelper.zbesh(z.Real, z.Imaginary, v, kode, m, num, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (num2 == -1)
				{
					return Rotate(complex, 0.0 - v);
				}
				return complex;
			}

			public static Complex ScaledCbesh2(double v, Complex z)
			{
				if (double.IsNaN(v) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (v == 0.0 && z.Real == 0.0 && z.Imaginary == 0.0)
				{
					return new Complex(double.NaN, double.NaN);
				}
				int num = 1;
				int kode = 2;
				int m = 2;
				int nz = 0;
				int ierr = 0;
				double[] array = new double[num];
				double[] array2 = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = double.NaN;
					array2[i] = double.NaN;
				}
				int num2 = 1;
				if (v < 0.0)
				{
					v = 0.0 - v;
					num2 = -1;
				}
				AmosHelper.zbesh(z.Real, z.Imaginary, v, kode, m, num, array, array2, ref nz, ref ierr);
				Complex complex = new Complex(array[0], array2[0]);
				if (num2 == -1)
				{
					return Rotate(complex, 0.0 - v);
				}
				return complex;
			}

			private static double SinPi(double x)
			{
				if (Math.Floor(x) == x && Math.Abs(x) < 100000000000000.0)
				{
					return 0.0;
				}
				return Math.Sin(Math.PI * x);
			}

			private static double CosPi(double x)
			{
				if (Math.Floor(x + 0.5) == x + 0.5 && Math.Abs(x) < 100000000000000.0)
				{
					return 0.0;
				}
				return Math.Cos(Math.PI * x);
			}

			private static Complex Rotate(Complex z, double v)
			{
				double num = CosPi(v);
				double num2 = SinPi(v);
				return new Complex(z.Real * num - z.Imaginary * num2, z.Real * num2 + z.Imaginary * num);
			}

			private static Complex RotateJY(Complex j, Complex y, double v)
			{
				double num = CosPi(v);
				double num2 = SinPi(v);
				return new Complex(j.Real * num - y.Real * num2, j.Imaginary * num - y.Imaginary * num2);
			}

			private static bool ReflectJY(ref Complex jy, double v)
			{
				if (v != Math.Floor(v))
				{
					return false;
				}
				if ((int)(v - 16384.0 * Math.Floor(v / 16384.0)) % 2 == 1)
				{
					jy = new Complex(0.0 - jy.Real, 0.0 - jy.Imaginary);
				}
				return true;
			}

			private static bool ReflectI(double v)
			{
				if (v != Math.Floor(v))
				{
					return false;
				}
				return true;
			}

			private static Complex RotateI(Complex i, Complex k, double v)
			{
				double num = Math.Sin(v * Math.PI) * (2.0 / Math.PI);
				return new Complex(i.Real + num * k.Real, i.Imaginary + num * k.Imaginary);
			}
		}

		private static class AmosHelper
		{
			public static int zairy(double zr, double zi, int id, int kode, ref double air, ref double aii, ref int nz, ref int ierr)
			{
				double bi = 0.0;
				double br = 0.0;
				double bi2 = 0.0;
				double br2 = 0.0;
				int nz2 = 0;
				double[] array = new double[1];
				double[] array2 = new double[1];
				air = 0.0;
				aii = 0.0;
				ierr = 0;
				nz = 0;
				if (id < 0 || id > 1)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				double num = zabs(zr, zi);
				double num2 = Math.Max(d1mach(4), 1E-18);
				double num3 = id;
				int i;
				double num8;
				if (!(num > 1.0))
				{
					double num4 = 1.0;
					double num5 = 0.0;
					double num6 = 1.0;
					double num7 = 0.0;
					if (!(num < num2))
					{
						num8 = num * num;
						if (!(num8 < num2 / num))
						{
							double num9 = 1.0;
							double num10 = 0.0;
							double num11 = 1.0;
							double num12 = 0.0;
							double num13 = 1.0;
							br2 = zr * zr - zi * zi;
							bi2 = zr * zi + zi * zr;
							double num14 = br2 * zr - bi2 * zi;
							double num15 = br2 * zi + bi2 * zr;
							double num16 = num * num8;
							double num17 = 2.0 + num3;
							double num18 = 3.0 - num3 - num3;
							double num19 = 4.0 - num3;
							double num20 = 3.0 + num3 + num3;
							double num21 = num17 * num20;
							double num22 = num18 * num19;
							double num23 = Math.Min(num21, num22);
							num17 = 24.0 + 9.0 * num3;
							num18 = 30.0 - 9.0 * num3;
							for (i = 1; i <= 25; i++)
							{
								br2 = (num9 * num14 - num10 * num15) / num21;
								num10 = (num9 * num15 + num10 * num14) / num21;
								num9 = br2;
								num4 += num9;
								num5 += num10;
								br2 = (num11 * num14 - num12 * num15) / num22;
								num12 = (num11 * num15 + num12 * num14) / num22;
								num11 = br2;
								num6 += num11;
								num7 += num12;
								num13 = num13 * num16 / num23;
								num21 += num17;
								num22 += num18;
								num23 = Math.Min(num21, num22);
								if (num13 < num2 * num23)
								{
									break;
								}
								num17 += 18.0;
								num18 += 18.0;
							}
						}
						double ar;
						double ai;
						double num24;
						if (id != 1)
						{
							air = num4 * 0.3550280538878172 - 0.2588194037928068 * (zr * num6 - zi * num7);
							aii = num5 * 0.3550280538878172 - 0.2588194037928068 * (zr * num7 + zi * num6);
							if (kode == 1)
							{
								return 0;
							}
							zsqrt(zr, zi, ref br2, ref bi2);
							ar = 2.0 / 3.0 * (zr * br2 - zi * bi2);
							ai = 2.0 / 3.0 * (zr * bi2 + zi * br2);
							zexp(ar, ai, ref br2, ref bi2);
							num24 = air * br2 - aii * bi2;
							aii = air * bi2 + aii * br2;
							air = num24;
							return 0;
						}
						air = (0.0 - num6) * 0.2588194037928068;
						aii = (0.0 - num7) * 0.2588194037928068;
						if (!(num <= num2))
						{
							br2 = zr * num4 - zi * num5;
							bi2 = zr * num5 + zi * num4;
							double num25 = 0.3550280538878172 / (num3 + 1.0);
							air += num25 * (br2 * zr - bi2 * zi);
							aii += num25 * (br2 * zi + bi2 * zr);
						}
						if (kode == 1)
						{
							return 0;
						}
						zsqrt(zr, zi, ref br2, ref bi2);
						ar = 2.0 / 3.0 * (zr * br2 - zi * bi2);
						ai = 2.0 / 3.0 * (zr * bi2 + zi * br2);
						zexp(ar, ai, ref br2, ref bi2);
						num24 = br2 * air - bi2 * aii;
						aii = br2 * aii + bi2 * air;
						air = num24;
						return 0;
					}
					num8 = 1000.0 * d1mach(1);
					num4 = 0.0;
					num5 = 0.0;
					if (id != 1)
					{
						if (!(num <= num8))
						{
							num4 = 0.2588194037928068 * zr;
							num5 = 0.2588194037928068 * zi;
						}
						air = 0.3550280538878172 - num4;
						aii = 0.0 - num5;
						return 0;
					}
					air = -0.2588194037928068;
					aii = 0.0;
					num8 = Math.Sqrt(num8);
					if (!(num <= num8))
					{
						num4 = (zr * zr - zi * zi) * 0.5;
						num5 = zr * zi;
					}
					air += 0.3550280538878172 * num4;
					aii += 0.3550280538878172 * num5;
					return 0;
				}
				double fnu = (1.0 + num3) / 3.0;
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num26 = d1mach(5);
				i = Math.Min(Math.Abs(value), Math.Abs(value2));
				double num27 = ((double)i * num26 - 3.0) * 2.303;
				value = i1mach(14) - 1;
				num8 = num26 * (double)value;
				double num28 = Math.Min(num8, 18.0);
				num8 *= 2.303;
				double num29 = num27 + Math.Max(0.0 - num8, -41.45);
				double rl = 1.2 * num28 + 3.0;
				double num30 = Math.Log(num);
				num8 = 0.5 / num2;
				double val = (double)i1mach(9) * 0.5;
				num8 = Math.Min(num8, val);
				num8 = Math.Pow(num8, 2.0 / 3.0);
				if (!(num > num8))
				{
					num8 = Math.Sqrt(num8);
					if (num > num8)
					{
						ierr = 3;
					}
					zsqrt(zr, zi, ref br, ref bi);
					double ar = 2.0 / 3.0 * (zr * br - zi * bi);
					double ai = 2.0 / 3.0 * (zr * bi + zi * br);
					int num31 = 0;
					double num32 = 1.0;
					double num17 = ai;
					if (!(zr >= 0.0))
					{
						double num18 = ar;
						double num19 = 0.0 - Math.Abs(num18);
						ar = num19;
						ai = num17;
					}
					if (zi == 0.0 && !(zr > 0.0))
					{
						ar = 0.0;
						ai = num17;
					}
					num8 = ar;
					if (!(num8 >= 0.0) || !(zr > 0.0))
					{
						if (kode != 2 && !(num8 > 0.0 - num29))
						{
							num8 = 0.0 - num8 + num30 * 0.25;
							num31 = 1;
							num32 = num2;
							if (num8 > num27)
							{
								goto IL_086f;
							}
						}
						int mr = 1;
						if (zi < 0.0)
						{
							mr = -1;
						}
						zacai(ar, ai, fnu, kode, mr, 1, array2, array, ref nz2, rl, num2, num27, num29);
						if (nz2 < 0)
						{
							if (nz2 != -1)
							{
								nz = 0;
								ierr = 5;
								return 0;
							}
							goto IL_086f;
						}
						nz += nz2;
					}
					else
					{
						if (kode != 2 && !(num8 < num29))
						{
							num8 = 0.0 - num8 - 0.25 * num30;
							num31 = 2;
							num32 = 1.0 / num2;
							if (num8 < 0.0 - num27)
							{
								nz = 1;
								air = 0.0;
								aii = 0.0;
								return 0;
							}
						}
						zbknu(ar, ai, fnu, kode, 1, array2, array, ref nz, num2, num27, num29);
					}
					double num4 = array2[0] * 0.18377629847393068;
					double num5 = array[0] * 0.18377629847393068;
					if (num31 == 0)
					{
						if (id != 1)
						{
							air = br * num4 - bi * num5;
							aii = br * num5 + bi * num4;
							return 0;
						}
						air = 0.0 - (zr * num4 - zi * num5);
						aii = 0.0 - (zr * num5 + zi * num4);
						return 0;
					}
					num4 *= num32;
					num5 *= num32;
					if (id != 1)
					{
						br2 = num4 * br - num5 * bi;
						num5 = num4 * bi + num5 * br;
						num4 = br2;
						air = num4 / num32;
						aii = num5 / num32;
						return 0;
					}
					br2 = 0.0 - (num4 * zr - num5 * zi);
					num5 = 0.0 - (num4 * zi + num5 * zr);
					num4 = br2;
					air = num4 / num32;
					aii = num5 / num32;
					return 0;
				}
				ierr = 4;
				nz = 0;
				return 0;
				IL_086f:
				nz = 0;
				ierr = 2;
				return 0;
			}

			public static int zbiry(double zr, double zi, int id, int kode, ref double bir, ref double bii, ref int nz, ref int ierr)
			{
				double bi = 0.0;
				double br = 0.0;
				double bi2 = 0.0;
				double br2 = 0.0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				ierr = 0;
				nz = 0;
				if (id < 0 || id > 1)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				double num = zabs(zr, zi);
				double num2 = Math.Max(d1mach(4), 1E-18);
				double num3 = id;
				int i;
				double num8;
				if (!(num > 1.0))
				{
					double num4 = 1.0;
					double num5 = 0.0;
					double num6 = 1.0;
					double num7 = 0.0;
					if (!(num < num2))
					{
						num8 = num * num;
						if (!(num8 < num2 / num))
						{
							double num9 = 1.0;
							double num10 = 0.0;
							double num11 = 1.0;
							double num12 = 0.0;
							double num13 = 1.0;
							br2 = zr * zr - zi * zi;
							bi2 = zr * zi + zi * zr;
							double num14 = br2 * zr - bi2 * zi;
							double num15 = br2 * zi + bi2 * zr;
							double num16 = num * num8;
							double num17 = 2.0 + num3;
							double num18 = 3.0 - num3 - num3;
							double num19 = 4.0 - num3;
							double num20 = 3.0 + num3 + num3;
							double num21 = num17 * num20;
							double num22 = num18 * num19;
							double num23 = Math.Min(num21, num22);
							num17 = 24.0 + 9.0 * num3;
							num18 = 30.0 - 9.0 * num3;
							for (i = 1; i <= 25; i++)
							{
								br2 = (num9 * num14 - num10 * num15) / num21;
								num10 = (num9 * num15 + num10 * num14) / num21;
								num9 = br2;
								num4 += num9;
								num5 += num10;
								br2 = (num11 * num14 - num12 * num15) / num22;
								num12 = (num11 * num15 + num12 * num14) / num22;
								num11 = br2;
								num6 += num11;
								num7 += num12;
								num13 = num13 * num16 / num23;
								num21 += num17;
								num22 += num18;
								num23 = Math.Min(num21, num22);
								if (num13 < num2 * num23)
								{
									break;
								}
								num17 += 18.0;
								num18 += 18.0;
							}
						}
						double num24;
						double num25;
						double num26;
						if (id != 1)
						{
							bir = 0.6149266274460007 * num4 + 0.4482883573538264 * (zr * num6 - zi * num7);
							bii = 0.6149266274460007 * num5 + 0.4482883573538264 * (zr * num7 + zi * num6);
							if (kode == 1)
							{
								return 0;
							}
							zsqrt(zr, zi, ref br2, ref bi2);
							num24 = 2.0 / 3.0 * (zr * br2 - zi * bi2);
							num25 = 2.0 / 3.0 * (zr * bi2 + zi * br2);
							num8 = num24;
							num8 = 0.0 - Math.Abs(num8);
							num26 = Math.Exp(num8);
							bir *= num26;
							bii *= num26;
							return 0;
						}
						bir = num6 * 0.4482883573538264;
						bii = num7 * 0.4482883573538264;
						if (!(num <= num2))
						{
							double num27 = 0.6149266274460007 / (1.0 + num3);
							br2 = num4 * zr - num5 * zi;
							bi2 = num4 * zi + num5 * zr;
							bir += num27 * (br2 * zr - bi2 * zi);
							bii += num27 * (br2 * zi + bi2 * zr);
						}
						if (kode == 1)
						{
							return 0;
						}
						zsqrt(zr, zi, ref br2, ref bi2);
						num24 = 2.0 / 3.0 * (zr * br2 - zi * bi2);
						num25 = 2.0 / 3.0 * (zr * bi2 + zi * br2);
						num8 = num24;
						num8 = 0.0 - Math.Abs(num8);
						num26 = Math.Exp(num8);
						bir *= num26;
						bii *= num26;
						return 0;
					}
					num8 = 0.6149266274460007 * (1.0 - num3) + num3 * 0.4482883573538264;
					bir = num8;
					bii = 0.0;
					return 0;
				}
				double num28 = (1.0 + num3) / 3.0;
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num29 = d1mach(5);
				i = Math.Min(Math.Abs(value), Math.Abs(value2));
				double num30 = 2.303 * ((double)i * num29 - 3.0);
				value = i1mach(14) - 1;
				num8 = num29 * (double)value;
				double num31 = Math.Min(num8, 18.0);
				num8 *= 2.303;
				double num32 = num30 + Math.Max(0.0 - num8, -41.45);
				double rl = 1.2 * num31 + 3.0;
				double fnul = 10.0 + 6.0 * (num31 - 3.0);
				num8 = 0.5 / num2;
				double val = (double)i1mach(9) * 0.5;
				num8 = Math.Min(num8, val);
				num8 = Math.Pow(num8, 2.0 / 3.0);
				if (!(num > num8))
				{
					num8 = Math.Sqrt(num8);
					if (num > num8)
					{
						ierr = 3;
					}
					zsqrt(zr, zi, ref br, ref bi);
					double num24 = 2.0 / 3.0 * (zr * br - zi * bi);
					double num25 = 2.0 / 3.0 * (zr * bi + zi * br);
					double num33 = 1.0;
					double num17 = num25;
					if (!(zr >= 0.0))
					{
						double num18 = num24;
						double num19 = 0.0 - Math.Abs(num18);
						num24 = num19;
						num25 = num17;
					}
					if (zi == 0.0 && !(zr > 0.0))
					{
						num24 = 0.0;
						num25 = num17;
					}
					num8 = num24;
					if (kode != 2)
					{
						val = Math.Abs(num8);
						if (!(val < num32))
						{
							val += 0.25 * Math.Log(num);
							num33 = num2;
							if (val > num30)
							{
								goto IL_0836;
							}
						}
					}
					double num34 = 0.0;
					if (!(num8 >= 0.0) || !(zr > 0.0))
					{
						num34 = Math.PI;
						if (zi < 0.0)
						{
							num34 = -Math.PI;
						}
						num24 = 0.0 - num24;
						num25 = 0.0 - num25;
					}
					zbinu(num24, num25, num28, kode, 1, array, array2, ref nz, rl, fnul, num2, num30, num32);
					if (nz >= 0)
					{
						num8 = num34 * num28;
						double num14 = num33;
						br2 = Math.Cos(num8);
						bi2 = Math.Sin(num8);
						double num4 = (br2 * array[0] - bi2 * array2[0]) * num14;
						double num5 = (br2 * array2[0] + bi2 * array[0]) * num14;
						num28 = (2.0 - num3) / 3.0;
						zbinu(num24, num25, num28, kode, 2, array, array2, ref nz, rl, fnul, num2, num30, num32);
						array[0] *= num14;
						array2[0] *= num14;
						array[1] *= num14;
						array2[1] *= num14;
						zdiv(array[0], array2[0], num24, num25, ref br2, ref bi2);
						double num6 = (num28 + num28) * br2 + array[1];
						double num7 = (num28 + num28) * bi2 + array2[1];
						num8 = num34 * (num28 - 1.0);
						br2 = Math.Cos(num8);
						bi2 = Math.Sin(num8);
						num4 = 0.5773502691896257 * (num4 + num6 * br2 - num7 * bi2);
						num5 = 0.5773502691896257 * (num5 + num6 * bi2 + num7 * br2);
						if (id != 1)
						{
							br2 = br * num4 - bi * num5;
							num5 = br * num5 + bi * num4;
							num4 = br2;
							bir = num4 / num33;
							bii = num5 / num33;
							return 0;
						}
						br2 = zr * num4 - zi * num5;
						num5 = zr * num5 + zi * num4;
						num4 = br2;
						bir = num4 / num33;
						bii = num5 / num33;
						return 0;
					}
					if (nz != -1)
					{
						nz = 0;
						ierr = 5;
						return 0;
					}
					goto IL_0836;
				}
				ierr = 4;
				nz = 0;
				return 0;
				IL_0836:
				ierr = 2;
				nz = 0;
				return 0;
			}

			public static int zbesj(double zr, double zi, double fnu, int kode, int n, double[] cyr, double[] cyi, ref int nz, ref int ierr)
			{
				ierr = 0;
				nz = 0;
				if (fnu < 0.0)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (n < 1)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				double num = Math.Max(d1mach(4), 1E-18);
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num2 = d1mach(5);
				double num3 = ((double)Math.Min(Math.Abs(value), Math.Abs(value2)) * num2 - 3.0) * 2.303;
				value = i1mach(14) - 1;
				double num4 = num2 * (double)value;
				double num5 = Math.Min(num4, 18.0);
				num4 *= 2.303;
				double alim = num3 + Math.Max(0.0 - num4, -41.45);
				double rl = num5 * 1.2 + 3.0;
				double fnul = (num5 - 3.0) * 6.0 + 10.0;
				double num6 = zabs(zr, zi);
				double num7 = fnu + (double)(n - 1);
				num4 = 0.5 / num;
				double val = 0.5 * (double)i1mach(9);
				num4 = Math.Min(num4, val);
				if (!(num6 > num4) && !(num7 > num4))
				{
					num4 = Math.Sqrt(num4);
					if (num6 > num4)
					{
						ierr = 3;
					}
					if (num7 > num4)
					{
						ierr = 3;
					}
					double num8 = 1.0;
					int num9 = (int)fnu;
					int num10 = num9 / 2;
					int num11 = num9 - (num10 << 1);
					double num12 = (fnu - (double)(num9 - num11)) * (Math.PI / 2.0);
					double num13 = Math.Cos(num12);
					double num14 = Math.Sin(num12);
					if (num10 % 2 != 0)
					{
						num13 = 0.0 - num13;
						num14 = 0.0 - num14;
					}
					double num15 = zi;
					double num16 = 0.0 - zr;
					if (!(zi >= 0.0))
					{
						num15 = 0.0 - num15;
						num16 = 0.0 - num16;
						num14 = 0.0 - num14;
						num8 = 0.0 - num8;
					}
					zbinu(num15, num16, fnu, kode, n, cyr, cyi, ref nz, rl, fnul, num, num3, alim);
					if (nz >= 0)
					{
						int num17 = n - nz;
						if (num17 == 0)
						{
							return 0;
						}
						double num18 = 1.0 / num;
						double num19 = d1mach(1) * num18 * 1000.0;
						for (int i = 1; i <= num17; i++)
						{
							num4 = cyr[i - 1];
							val = cyi[i - 1];
							double num20 = 1.0;
							if (!(Math.Max(Math.Abs(num4), Math.Abs(val)) > num19))
							{
								num4 *= num18;
								val *= num18;
								num20 = num;
							}
							double num21 = num4 * num13 - val * num14;
							double num22 = num4 * num14 + val * num13;
							cyr[i - 1] = num21 * num20;
							cyi[i - 1] = num22 * num20;
							num21 = (0.0 - num14) * num8;
							num14 = num13 * num8;
							num13 = num21;
						}
						return 0;
					}
					if (nz != -2)
					{
						nz = 0;
						ierr = 2;
						return 0;
					}
					nz = 0;
					ierr = 5;
					return 0;
				}
				nz = 0;
				ierr = 4;
				return 0;
			}

			public static int zbesy(double zr, double zi, double fnu, int kode, int n, double[] cyr, double[] cyi, ref int nz, double[] cwrkr, double[] cwrki, ref int ierr)
			{
				int nz2 = 0;
				int nz3 = 0;
				ierr = 0;
				nz = 0;
				if (zr == 0.0 && zi == 0.0)
				{
					ierr = 1;
				}
				if (fnu < 0.0)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (n < 1)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				double num = 0.5;
				zbesh(zr, zi, fnu, kode, 1, n, cyr, cyi, ref nz2, ref ierr);
				if (ierr == 0 || ierr == 3)
				{
					zbesh(zr, zi, fnu, kode, 2, n, cwrkr, cwrki, ref nz3, ref ierr);
					if (ierr == 0 || ierr == 3)
					{
						nz = Math.Min(nz2, nz3);
						if (kode != 2)
						{
							for (int i = 1; i <= n; i++)
							{
								double num2 = cwrkr[i - 1] - cyr[i - 1];
								double num3 = cwrki[i - 1] - cyi[i - 1];
								cyr[i - 1] = (0.0 - num3) * num;
								cyi[i - 1] = num2 * num;
							}
							return 0;
						}
						double num4 = Math.Max(d1mach(4), 1E-18);
						int value = i1mach(15);
						int num5 = Math.Min(val2: Math.Abs(i1mach(16)), val1: Math.Abs(value));
						double num6 = d1mach(5);
						double num7 = 2.303 * ((double)num5 * num6 - 3.0);
						double num8 = Math.Cos(zr);
						double num9 = Math.Sin(zr);
						double num10 = 0.0;
						double num11 = Math.Abs(zi + zi);
						if (num11 < num7)
						{
							num10 = Math.Exp(0.0 - num11);
						}
						double num12;
						double num13;
						double num14;
						double num15;
						if (!(zi < 0.0))
						{
							num12 = num8 * num10;
							num13 = num9 * num10;
							num14 = num8;
							num15 = 0.0 - num9;
						}
						else
						{
							num12 = num8;
							num13 = num9;
							num14 = num8 * num10;
							num15 = (0.0 - num9) * num10;
						}
						nz = 0;
						double num16 = 1.0 / num4;
						double num17 = d1mach(1) * num16 * 1000.0;
						for (int i = 1; i <= n; i++)
						{
							double num18 = cwrkr[i - 1];
							double num19 = cwrki[i - 1];
							double num20 = 1.0;
							if (!(Math.Max(Math.Abs(num18), Math.Abs(num19)) > num17))
							{
								num18 *= num16;
								num19 *= num16;
								num20 = num4;
							}
							double num2 = (num18 * num14 - num19 * num15) * num20;
							double num3 = (num18 * num15 + num19 * num14) * num20;
							num18 = cyr[i - 1];
							num19 = cyi[i - 1];
							num20 = 1.0;
							if (!(Math.Max(Math.Abs(num18), Math.Abs(num19)) > num17))
							{
								num18 *= num16;
								num19 *= num16;
								num20 = num4;
							}
							num2 -= (num18 * num12 - num19 * num13) * num20;
							num3 -= (num18 * num13 + num19 * num12) * num20;
							cyr[i - 1] = (0.0 - num3) * num;
							cyi[i - 1] = num2 * num;
							if (num2 == 0.0 && num3 == 0.0 && num10 == 0.0)
							{
								nz++;
							}
						}
						return 0;
					}
				}
				nz = 0;
				return 0;
			}

			public static int zbesi(double zr, double zi, double fnu, int kode, int n, double[] cyr, double[] cyi, ref int nz, ref int ierr)
			{
				ierr = 0;
				nz = 0;
				if (fnu < 0.0)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (n < 1)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				double num = Math.Max(d1mach(4), 1E-18);
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num2 = d1mach(5);
				int num3 = Math.Min(Math.Abs(value), Math.Abs(value2));
				double num4 = 2.303 * ((double)num3 * num2 - 3.0);
				value = i1mach(14) - 1;
				double num5 = num2 * (double)value;
				double num6 = Math.Min(num5, 18.0);
				num5 *= 2.303;
				double alim = num4 + Math.Max(0.0 - num5, -41.45);
				double rl = num6 * 1.2 + 3.0;
				double fnul = 10.0 + 6.0 * (num6 - 3.0);
				double num7 = zabs(zr, zi);
				double num8 = fnu + (double)(n - 1);
				num5 = 0.5 / num;
				double val = (double)i1mach(9) * 0.5;
				num5 = Math.Min(num5, val);
				if (!(num7 > num5) && !(num8 > num5))
				{
					num5 = Math.Sqrt(num5);
					if (num7 > num5)
					{
						ierr = 3;
					}
					if (num8 > num5)
					{
						ierr = 3;
					}
					double zr2 = zr;
					double zi2 = zi;
					double num9 = 1.0;
					double num10 = 0.0;
					if (!(zr >= 0.0))
					{
						zr2 = 0.0 - zr;
						zi2 = 0.0 - zi;
						int num11 = (int)fnu;
						double num12 = (fnu - (double)num11) * Math.PI;
						if (zi < 0.0)
						{
							num12 = 0.0 - num12;
						}
						num9 = Math.Cos(num12);
						num10 = Math.Sin(num12);
						if (num11 % 2 != 0)
						{
							num9 = 0.0 - num9;
							num10 = 0.0 - num10;
						}
					}
					zbinu(zr2, zi2, fnu, kode, n, cyr, cyi, ref nz, rl, fnul, num, num4, alim);
					if (nz >= 0)
					{
						if (zr >= 0.0)
						{
							return 0;
						}
						int num13 = n - nz;
						if (num13 == 0)
						{
							return 0;
						}
						double num14 = 1.0 / num;
						double num15 = d1mach(1) * num14 * 1000.0;
						for (int i = 1; i <= num13; i++)
						{
							num5 = cyr[i - 1];
							val = cyi[i - 1];
							double num16 = 1.0;
							if (!(Math.Max(Math.Abs(num5), Math.Abs(val)) > num15))
							{
								num5 *= num14;
								val *= num14;
								num16 = num;
							}
							double num17 = num5 * num9 - val * num10;
							double num18 = num5 * num10 + val * num9;
							cyr[i - 1] = num17 * num16;
							cyi[i - 1] = num18 * num16;
							num9 = 0.0 - num9;
							num10 = 0.0 - num10;
						}
						return 0;
					}
					if (nz != -2)
					{
						nz = 0;
						ierr = 2;
						return 0;
					}
					nz = 0;
					ierr = 5;
					return 0;
				}
				nz = 0;
				ierr = 4;
				return 0;
			}

			public static int zbesk(double zr, double zi, double fnu, int kode, int n, double[] cyr, double[] cyi, ref int nz, ref int ierr)
			{
				int nuf = 0;
				int nz2 = 0;
				ierr = 0;
				nz = 0;
				if (zi == 0.0 && zr == 0.0)
				{
					ierr = 1;
				}
				if (fnu < 0.0)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (n < 1)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				int num = n;
				double num2 = Math.Max(d1mach(4), 1E-18);
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num3 = d1mach(5);
				int num4 = Math.Min(Math.Abs(value), Math.Abs(value2));
				double num5 = 2.303 * ((double)num4 * num3 - 3.0);
				value = i1mach(14) - 1;
				double num6 = num3 * (double)value;
				double num7 = Math.Min(num6, 18.0);
				num6 *= 2.303;
				double alim = num5 + Math.Max(0.0 - num6, -41.45);
				double num8 = (num7 - 3.0) * 6.0 + 10.0;
				double rl = 1.2 * num7 + 3.0;
				double num9 = zabs(zr, zi);
				double num10 = fnu + (double)(num - 1);
				num6 = 0.5 / num2;
				double val = (double)i1mach(9) * 0.5;
				num6 = Math.Min(num6, val);
				if (!(num9 > num6) && !(num10 > num6))
				{
					num6 = Math.Sqrt(num6);
					if (num9 > num6)
					{
						ierr = 3;
					}
					if (num10 > num6)
					{
						ierr = 3;
					}
					double num11 = d1mach(1) * 1000.0;
					if (num9 < num11)
					{
						goto IL_02fe;
					}
					if (!(fnu > num8))
					{
						if (!(num10 <= 1.0))
						{
							if (num10 > 2.0)
							{
								zuoik(zr, zi, fnu, kode, 2, num, cyr, cyi, ref nuf, num2, num5, alim);
								if (nuf >= 0)
								{
									nz += nuf;
									num -= nuf;
									if (num != 0)
									{
										goto IL_0231;
									}
									if (!(zr < 0.0))
									{
										return 0;
									}
								}
								goto IL_02fe;
							}
							if (!(num9 > num2))
							{
								double d = num9 * 0.5;
								if ((0.0 - num10) * Math.Log(d) > num5)
								{
									goto IL_02fe;
								}
							}
						}
						goto IL_0231;
					}
					int mr = 0;
					if (!(zr >= 0.0))
					{
						mr = 1;
						if (zi < 0.0)
						{
							mr = -1;
						}
					}
					zbunk(zr, zi, fnu, kode, mr, num, cyr, cyi, ref nz2, num2, num5, alim);
					if (nz2 >= 0)
					{
						nz += nz2;
						return 0;
					}
					goto IL_0308;
				}
				nz = 0;
				ierr = 4;
				return 0;
				IL_0231:
				if (!(zr < 0.0))
				{
					zbknu(zr, zi, fnu, kode, num, cyr, cyi, ref nz2, num2, num5, alim);
					if (nz2 >= 0)
					{
						nz = nz2;
						return 0;
					}
				}
				else
				{
					if (nz != 0)
					{
						goto IL_02fe;
					}
					int mr = 1;
					if (zi < 0.0)
					{
						mr = -1;
					}
					zacon(zr, zi, fnu, kode, mr, num, cyr, cyi, ref nz2, rl, num8, num2, num5, alim);
					if (nz2 >= 0)
					{
						nz = nz2;
						return 0;
					}
				}
				goto IL_0308;
				IL_02fe:
				nz = 0;
				ierr = 2;
				return 0;
				IL_0308:
				if (nz2 != -1)
				{
					nz = 0;
					ierr = 5;
					return 0;
				}
				goto IL_02fe;
			}

			public static int zbesh(double zr, double zi, double fnu, int kode, int m, int n, double[] cyr, double[] cyi, ref int nz, ref int ierr)
			{
				int nuf = 0;
				int nz2 = 0;
				ierr = 0;
				nz = 0;
				if (zr == 0.0 && zi == 0.0)
				{
					ierr = 1;
				}
				if (fnu < 0.0)
				{
					ierr = 1;
				}
				if (m < 1 || m > 2)
				{
					ierr = 1;
				}
				if (kode < 1 || kode > 2)
				{
					ierr = 1;
				}
				if (n < 1)
				{
					ierr = 1;
				}
				if (ierr != 0)
				{
					return 0;
				}
				int num = n;
				double num2 = Math.Max(d1mach(4), 1E-18);
				int value = i1mach(15);
				int value2 = i1mach(16);
				double num3 = d1mach(5);
				int num4 = Math.Min(Math.Abs(value), Math.Abs(value2));
				double num5 = 2.303 * ((double)num4 * num3 - 3.0);
				value = i1mach(14) - 1;
				double num6 = num3 * (double)value;
				double num7 = Math.Min(num6, 18.0);
				num6 *= 2.303;
				double alim = num5 + Math.Max(0.0 - num6, -41.45);
				double num8 = (num7 - 3.0) * 6.0 + 10.0;
				double rl = num7 * 1.2 + 3.0;
				double num9 = fnu + (double)(num - 1);
				int num10 = 3 - m - m;
				double num11 = num10;
				double num12 = num11 * zi;
				double num13 = (0.0 - num11) * zr;
				double num14 = zabs(zr, zi);
				num6 = 0.5 / num2;
				double val = (double)i1mach(9) * 0.5;
				num6 = Math.Min(num6, val);
				double num15;
				double d;
				if (!(num14 > num6) && !(num9 > num6))
				{
					num6 = Math.Sqrt(num6);
					if (num14 > num6)
					{
						ierr = 3;
					}
					if (num9 > num6)
					{
						ierr = 3;
					}
					num15 = d1mach(1) * 1000.0;
					if (num14 < num15)
					{
						goto IL_0484;
					}
					if (!(fnu > num8))
					{
						if (!(num9 <= 1.0))
						{
							if (num9 > 2.0)
							{
								zuoik(num12, num13, fnu, kode, 2, num, cyr, cyi, ref nuf, num2, num5, alim);
								if (nuf >= 0)
								{
									nz += nuf;
									num -= nuf;
									if (num != 0)
									{
										goto IL_0257;
									}
									if (!(num12 < 0.0))
									{
										return 0;
									}
								}
								goto IL_0484;
							}
							if (!(num14 > num2))
							{
								d = 0.5 * num14;
								if ((0.0 - num9) * Math.Log(d) > num5)
								{
									goto IL_0484;
								}
							}
						}
						goto IL_0257;
					}
					int mr = 0;
					if (!(num12 >= 0.0) || (num12 == 0.0 && !(num13 >= 0.0) && m == 2))
					{
						mr = -num10;
						if (num12 == 0.0 && !(num13 >= 0.0))
						{
							num12 = 0.0 - num12;
							num13 = 0.0 - num13;
						}
					}
					zbunk(num12, num13, fnu, kode, mr, num, cyr, cyi, ref nz2, num2, num5, alim);
					if (nz2 >= 0)
					{
						nz += nz2;
						goto IL_035b;
					}
					goto IL_048e;
				}
				nz = 0;
				ierr = 4;
				return 0;
				IL_048e:
				if (nz2 != -1)
				{
					nz = 0;
					ierr = 5;
					return 0;
				}
				goto IL_0484;
				IL_0257:
				if (!(num12 < 0.0) && (num12 != 0.0 || !(num13 < 0.0) || m != 2))
				{
					zbknu(num12, num13, fnu, kode, num, cyr, cyi, ref nz, num2, num5, alim);
				}
				else
				{
					int mr = -num10;
					zacon(num12, num13, fnu, kode, mr, num, cyr, cyi, ref nz2, rl, num8, num2, num5, alim);
					if (nz2 < 0)
					{
						goto IL_048e;
					}
					nz = nz2;
				}
				goto IL_035b;
				IL_035b:
				double num16 = dsign(Math.PI / 2.0, 0.0 - num11);
				int num17 = (int)fnu;
				int num18 = num17 / 2;
				int num19 = num17 - 2 * num18;
				d = (fnu - (double)(num17 - num19)) * num16;
				double num20 = 1.0 / num16;
				double num21 = num20 * Math.Cos(d);
				double num22 = (0.0 - num20) * Math.Sin(d);
				if (num18 % 2 != 0)
				{
					num22 = 0.0 - num22;
					num21 = 0.0 - num21;
				}
				double num23 = 0.0 - num11;
				double num24 = 1.0 / num2;
				double num25 = num15 * num24;
				for (int i = 1; i <= num; i++)
				{
					num6 = cyr[i - 1];
					val = cyi[i - 1];
					double num26 = 1.0;
					if (!(Math.Max(Math.Abs(num6), Math.Abs(val)) > num25))
					{
						num6 *= num24;
						val *= num24;
						num26 = num2;
					}
					double num27 = num6 * num22 - val * num21;
					double num28 = num6 * num21 + val * num22;
					cyr[i - 1] = num27 * num26;
					cyi[i - 1] = num28 * num26;
					num27 = (0.0 - num21) * num23;
					num21 = num22 * num23;
					num22 = num27;
				}
				return 0;
				IL_0484:
				nz = 0;
				ierr = 2;
				return 0;
			}

			public static double dgamln(double z, ref int ierr)
			{
				double[] array = new double[100]
				{
					0.0, 0.0, 0.6931471805599453, 1.791759469228055, 3.1780538303479458, 4.787491742782046, 6.579251212010101, 8.525161361065415, 10.60460290274525, 12.801827480081469,
					15.104412573075516, 17.502307845873887, 19.987214495661885, 22.552163853123425, 25.19122118273868, 27.89927138384089, 30.671860106080672, 33.50507345013689, 36.39544520803305, 39.339884187199495,
					42.335616460753485, 45.38013889847691, 48.47118135183523, 51.60667556776438, 54.78472939811232, 58.00360522298052, 61.261701761002, 64.55753862700634, 67.88974313718154, 71.25703896716801,
					74.65823634883016, 78.0922235533153, 81.55795945611504, 85.05446701758152, 88.58082754219768, 92.1361756036871, 95.7196945421432, 99.33061245478743, 102.96819861451381, 106.63176026064346,
					110.32063971475739, 114.0342117814617, 117.77188139974507, 121.53308151543864, 125.3172711493569, 129.12393363912722, 132.95257503561632, 136.80272263732635, 140.67392364823425, 144.5657439463449,
					148.47776695177302, 152.40959258449735, 156.3608363030788, 160.3311282166309, 164.32011226319517, 168.32744544842765, 172.3527971391628, 176.39584840699735, 180.45629141754378, 184.53382886144948,
					188.6281734236716, 192.7390472878449, 196.86618167289, 201.00931639928152, 205.1681994826412, 209.34258675253685, 213.53224149456327, 217.73693411395422, 221.95644181913033, 226.1905483237276,
					230.43904356577696, 234.70172344281826, 238.97838956183432, 243.2688490029827, 247.57291409618688, 251.8904022097232, 256.22113555000954, 260.5649409718632, 264.9216497985528, 269.2910976510198,
					273.6731242856937, 278.0675734403661, 282.4742926876304, 286.893133295427, 291.3239500942703, 295.76660135076065, 300.22094864701415, 304.6868567656687, 309.1641935801469, 313.65282994987905,
					318.1526396202093, 322.66349912672615, 327.1852877037752, 331.7178871969285, 336.26118197919845, 340.815058870799, 345.37940706226686, 349.95411804077025, 354.5390855194408, 359.1342053695754
				};
				double[] array2 = new double[22]
				{
					1.0 / 12.0,
					-1.0 / 360.0,
					0.0007936507936507937,
					-0.0005952380952380953,
					0.0008417508417508417,
					-0.0019175269175269176,
					1.0 / 156.0,
					-0.029550653594771242,
					0.17964437236883057,
					-1.3924322169059011,
					13.402864044168393,
					-156.84828462600203,
					2193.1033333333335,
					-36108.77125372499,
					691472.268851313,
					-15238221.539407415,
					382900751.39141417,
					-10882266035.784391,
					347320283765.00226,
					-12369602142269.275,
					488788064793079.3,
					-21320333960919372.0
				};
				int num = 0;
				ierr = 0;
				if (!(z <= 0.0))
				{
					if (!(z > 101.0))
					{
						num = (int)z;
						if (!(z - (double)num > 0.0) && num <= 100)
						{
							return array[num - 1];
						}
					}
					double val = d1mach(4);
					val = Math.Max(val, 5E-19);
					int num2 = i1mach(14);
					double val2 = Math.Min(d1mach(5) * (double)num2, 20.0);
					val2 = Math.Max(val2, 3.0);
					val2 += -3.0;
					double num3 = (int)(1.8 + 0.3875 * val2) + 1;
					double num4 = z;
					double num5 = 0.0;
					if (!(z >= num3))
					{
						num5 = num3 - (double)num;
						num4 = z + num5;
					}
					double num6 = 1.0 / num4;
					double num7 = array2[0] * num6;
					double num8 = num7;
					if (!(num6 < val))
					{
						double num9 = num6 * num6;
						double num10 = num7 * val;
						for (int i = 2; i <= 22; i++)
						{
							num6 *= num9;
							double num11 = array2[i - 1] * num6;
							if (Math.Abs(num11) < num10)
							{
								break;
							}
							num8 += num11;
						}
					}
					double num12;
					if (num5 == 0.0)
					{
						num12 = Math.Log(z);
						return z * (num12 - 1.0) + (1.8378770664093456 - num12) * 0.5 + num8;
					}
					num6 = 1.0;
					num = (int)num5;
					for (int j = 1; j <= num; j++)
					{
						num6 *= z + (double)(j - 1);
					}
					num12 = Math.Log(num4);
					return num4 * (num12 - 1.0) - Math.Log(num6) + (1.8378770664093456 - num12) * 0.5 + num8;
				}
				ierr = 1;
				return d1mach(2);
			}

			private static double d1mach(int i)
			{
				return i switch
				{
					1 => 2.2250738585072014E-308, 
					2 => double.MaxValue, 
					3 => 1.1102230246251565E-16, 
					4 => 2.220446049250313E-16, 
					5 => Math.Log10(2.0), 
					_ => 0.0, 
				};
			}

			private static int i1mach(int i)
			{
				return i switch
				{
					9 => int.MaxValue, 
					14 => 53, 
					15 => -1021, 
					16 => 1024, 
					_ => 0, 
				};
			}

			private static double dsign(double a, double b)
			{
				double num = ((a >= 0.0) ? a : (0.0 - a));
				if (!(b >= 0.0))
				{
					return 0.0 - num;
				}
				return num;
			}

			private static double zabs(double zr, double zi)
			{
				double num = Math.Abs(zr);
				double num2 = Math.Abs(zi);
				if ((num + num2) * 1.0 != 0.0)
				{
					double num3;
					if (!(num > num2))
					{
						num3 = num / num2;
						return num2 * Math.Sqrt(1.0 + num3 * num3);
					}
					num3 = num2 / num;
					return num * Math.Sqrt(1.0 + num3 * num3);
				}
				return 0.0;
			}

			private static int zdiv(double ar, double ai, double br, double bi, ref double cr, ref double ci)
			{
				double num = 1.0 / zabs(br, bi);
				double num2 = br * num;
				double num3 = bi * num;
				double num4 = (ar * num2 + ai * num3) * num;
				double num5 = (ai * num2 - ar * num3) * num;
				cr = num4;
				ci = num5;
				return 0;
			}

			private static int zexp(double ar, double ai, ref double br, ref double bi)
			{
				double num = Math.Exp(ar);
				double num2 = num * Math.Cos(ai);
				double num3 = num * Math.Sin(ai);
				br = num2;
				bi = num3;
				return 0;
			}

			private static int zlog(double ar, double ai, ref double br, ref double bi, ref int ierr)
			{
				double num = Math.PI / 2.0;
				double num2 = Math.PI;
				ierr = 0;
				if (ar != 0.0)
				{
					if (ai != 0.0)
					{
						double num3 = Math.Atan(ai / ar);
						if (!(num3 <= 0.0))
						{
							if (ar < 0.0)
							{
								num3 -= num2;
							}
						}
						else if (ar < 0.0)
						{
							num3 += num2;
						}
						double d = zabs(ar, ai);
						br = Math.Log(d);
						bi = num3;
						return 0;
					}
					if (!(ar > 0.0))
					{
						br = Math.Log(Math.Abs(ar));
						bi = num2;
						return 0;
					}
					br = Math.Log(ar);
					bi = 0.0;
					return 0;
				}
				if (ai != 0.0)
				{
					bi = num;
					br = Math.Log(Math.Abs(ai));
					if (ai < 0.0)
					{
						bi = 0.0 - bi;
					}
					return 0;
				}
				ierr = 1;
				return 0;
			}

			private static int zmlt(double ar, double ai, double br, double bi, ref double cr, ref double ci)
			{
				double num = ar * br - ai * bi;
				double num2 = ar * bi + ai * br;
				cr = num;
				ci = num2;
				return 0;
			}

			private static int zsqrt(double ar, double ai, ref double br, ref double bi)
			{
				double d = zabs(ar, ai);
				d = Math.Sqrt(d);
				if (ar != 0.0)
				{
					if (ai != 0.0)
					{
						double num = Math.Atan(ai / ar);
						if (!(num <= 0.0))
						{
							if (ar < 0.0)
							{
								num -= Math.PI;
							}
						}
						else if (ar < 0.0)
						{
							num += Math.PI;
						}
						num *= 0.5;
						br = d * Math.Cos(num);
						bi = d * Math.Sin(num);
						return 0;
					}
					if (!(ar > 0.0))
					{
						br = 0.0;
						bi = Math.Sqrt(Math.Abs(ar));
						return 0;
					}
					br = Math.Sqrt(ar);
					bi = 0.0;
					return 0;
				}
				if (!(ai > 0.0))
				{
					if (!(ai < 0.0))
					{
						br = 0.0;
						bi = 0.0;
						return 0;
					}
					br = d * 0.7071067811865476;
					bi = (0.0 - d) * 0.7071067811865476;
					return 0;
				}
				br = d * 0.7071067811865476;
				bi = d * 0.7071067811865476;
				return 0;
			}

			private static int zacai(double zr, double zi, double fnu, int kode, int mr, int n, double[] yr, double[] yi, ref int nz, double rl, double tol, double elim, double alim)
			{
				int nz2 = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				nz = 0;
				double num = 0.0 - zr;
				double num2 = 0.0 - zi;
				double num3 = zabs(zr, zi);
				double num4 = fnu + (double)(n - 1);
				if (num3 <= 2.0 || !(num3 * num3 * 0.25 > num4 + 1.0))
				{
					zseri(num, num2, fnu, kode, n, yr, yi, ref nz2, tol, elim, alim);
					goto IL_00c0;
				}
				if (!(num3 < rl))
				{
					zasyi(num, num2, fnu, kode, n, yr, yi, ref nz2, rl, tol, elim, alim);
					if (nz2 >= 0)
					{
						goto IL_00c0;
					}
				}
				else
				{
					zmlri(num, num2, fnu, kode, n, yr, yi, ref nz2, tol);
					if (nz2 >= 0)
					{
						goto IL_00c0;
					}
				}
				goto IL_01d7;
				IL_00c0:
				zbknu(num, num2, fnu, kode, 1, array, array2, ref nz2, tol, elim, alim);
				if (nz2 == 0)
				{
					double b = mr;
					double num5 = 0.0 - dsign(Math.PI, b);
					double num6 = 0.0;
					double num7 = num5;
					if (kode != 1)
					{
						double num8 = 0.0 - num2;
						num6 = (0.0 - num7) * Math.Sin(num8);
						num7 *= Math.Cos(num8);
					}
					int num9 = (int)fnu;
					double num10 = (fnu - (double)num9) * num5;
					double num11 = Math.Cos(num10);
					double num12 = Math.Sin(num10);
					if (num9 % 2 != 0)
					{
						num11 = 0.0 - num11;
						num12 = 0.0 - num12;
					}
					double s1r = array[0];
					double s1i = array2[0];
					double s2r = yr[0];
					double s2i = yi[0];
					if (kode != 1)
					{
						int iuf = 0;
						double ascle = d1mach(1) * 1000.0 / tol;
						zs1s2(num, num2, ref s1r, ref s1i, ref s2r, ref s2i, ref nz2, ascle, alim, ref iuf);
						nz += nz2;
					}
					yr[0] = num11 * s1r - num12 * s1i + num6 * s2r - num7 * s2i;
					yi[0] = num11 * s1i + num12 * s1r + num6 * s2i + num7 * s2r;
					return 0;
				}
				goto IL_01d7;
				IL_01d7:
				nz = -1;
				if (nz2 == -2)
				{
					nz = -2;
				}
				return 0;
			}

			private static int zacon(double zr, double zi, double fnu, int kode, int mr, int n, double[] yr, double[] yi, ref int nz, double rl, double fnul, double tol, double elim, double alim)
			{
				double ci = 0.0;
				double cr = 0.0;
				double num = 0.0;
				double num2 = 0.0;
				double ci2 = 0.0;
				double cr2 = 0.0;
				int nz2 = 0;
				double[] array = new double[3];
				double[] array2 = new double[3];
				double[] array3 = new double[3];
				double[] array4 = new double[2];
				double[] array5 = new double[2];
				nz = 0;
				double num3 = 0.0 - zr;
				double num4 = 0.0 - zi;
				int n2 = n;
				zbinu(num3, num4, fnu, kode, n2, yr, yi, ref nz2, rl, fnul, tol, elim, alim);
				if (nz2 >= 0)
				{
					n2 = Math.Min(2, n);
					zbknu(num3, num4, fnu, kode, n2, array5, array4, ref nz2, tol, elim, alim);
					if (nz2 == 0)
					{
						double num5 = array5[0];
						double num6 = array4[0];
						double b = mr;
						double num7 = 0.0 - dsign(Math.PI, b);
						double cr3 = 0.0;
						double ci3 = num7;
						double br;
						double bi;
						if (kode != 1)
						{
							double num8 = 0.0 - num4;
							br = Math.Cos(num8);
							bi = Math.Sin(num8);
							zmlt(cr3, ci3, br, bi, ref cr3, ref ci3);
						}
						int num9 = (int)fnu;
						double num10 = (fnu - (double)num9) * num7;
						br = Math.Cos(num10);
						bi = Math.Sin(num10);
						double num11 = br;
						double num12 = bi;
						if (num9 % 2 != 0)
						{
							num11 = 0.0 - num11;
							num12 = 0.0 - num12;
						}
						int iuf = 0;
						double s1r = num5;
						double s1i = num6;
						double s2r = yr[0];
						double s2i = yi[0];
						double num13 = 1000.0 * d1mach(1) / tol;
						if (kode != 1)
						{
							zs1s2(num3, num4, ref s1r, ref s1i, ref s2r, ref s2i, ref nz2, num13, alim, ref iuf);
							nz += nz2;
							double num14 = s1r;
							double num15 = s1i;
						}
						zmlt(num11, num12, s1r, s1i, ref cr2, ref ci2);
						zmlt(cr3, ci3, s2r, s2i, ref cr, ref ci);
						yr[0] = cr2 + cr;
						yi[0] = ci2 + ci;
						if (n == 1)
						{
							return 0;
						}
						num11 = 0.0 - num11;
						num12 = 0.0 - num12;
						double num16 = array5[1];
						double num17 = array4[1];
						s1r = num16;
						s1i = num17;
						s2r = yr[1];
						s2i = yi[1];
						if (kode != 1)
						{
							zs1s2(num3, num4, ref s1r, ref s1i, ref s2r, ref s2i, ref nz2, num13, alim, ref iuf);
							nz += nz2;
							num2 = s1r;
							num = s1i;
						}
						zmlt(num11, num12, s1r, s1i, ref cr2, ref ci2);
						zmlt(cr3, ci3, s2r, s2i, ref cr, ref ci);
						yr[1] = cr2 + cr;
						yi[1] = ci2 + ci;
						if (n == 2)
						{
							return 0;
						}
						num11 = 0.0 - num11;
						num12 = 0.0 - num12;
						double num18 = zabs(num3, num4);
						double num19 = 1.0 / num18;
						cr2 = num3 * num19;
						ci2 = (0.0 - num4) * num19;
						double num20 = (cr2 + cr2) * num19;
						double num21 = (ci2 + ci2) * num19;
						double num22 = fnu + 1.0;
						double num23 = num22 * num20;
						double num24 = num22 * num21;
						double num25 = 1.0 / tol;
						array3[0] = num25;
						array3[1] = 1.0;
						array3[2] = tol;
						array2[0] = tol;
						array2[1] = 1.0;
						array2[2] = num25;
						array[0] = num13;
						array[1] = 1.0 / num13;
						array[2] = d1mach(2);
						double num26 = zabs(num16, num17);
						int num27 = 2;
						if (!(num26 > array[0]))
						{
							num27 = 1;
						}
						else if (!(num26 < array[1]))
						{
							num27 = 3;
						}
						double num28 = array[num27 - 1];
						num5 *= array3[num27 - 1];
						num6 *= array3[num27 - 1];
						num16 *= array3[num27 - 1];
						num17 *= array3[num27 - 1];
						double num29 = array2[num27 - 1];
						for (int i = 3; i <= n; i++)
						{
							cr2 = num16;
							ci2 = num17;
							num16 = num23 * cr2 - num24 * ci2 + num5;
							num17 = num23 * ci2 + num24 * cr2 + num6;
							num5 = cr2;
							num6 = ci2;
							s1r = num16 * num29;
							s1i = num17 * num29;
							cr2 = s1r;
							ci2 = s1i;
							s2r = yr[i - 1];
							s2i = yi[i - 1];
							if (kode != 1 && iuf >= 0)
							{
								zs1s2(num3, num4, ref s1r, ref s1i, ref s2r, ref s2i, ref nz2, num13, alim, ref iuf);
								nz += nz2;
								double num14 = num2;
								double num15 = num;
								num2 = s1r;
								num = s1i;
								if (iuf == 3)
								{
									iuf = -4;
									num5 = num14 * array3[num27 - 1];
									num6 = num15 * array3[num27 - 1];
									num16 = num2 * array3[num27 - 1];
									num17 = num * array3[num27 - 1];
									cr2 = num2;
									ci2 = num;
								}
							}
							cr = num11 * s1r - num12 * s1i;
							ci = num11 * s1i + num12 * s1r;
							yr[i - 1] = cr + cr3 * s2r - ci3 * s2i;
							yi[i - 1] = ci + cr3 * s2i + ci3 * s2r;
							num23 += num20;
							num24 += num21;
							num11 = 0.0 - num11;
							num12 = 0.0 - num12;
							if (num27 < 3)
							{
								cr = Math.Abs(s1r);
								ci = Math.Abs(s1i);
								if (!(Math.Max(cr, ci) <= num28))
								{
									num27++;
									num28 = array[num27 - 1];
									num5 *= num29;
									num6 *= num29;
									num16 = cr2;
									num17 = ci2;
									num5 *= array3[num27 - 1];
									num6 *= array3[num27 - 1];
									num16 *= array3[num27 - 1];
									num17 *= array3[num27 - 1];
									num29 = array2[num27 - 1];
								}
							}
						}
						return 0;
					}
				}
				nz = -1;
				if (nz2 == -2)
				{
					nz = -2;
				}
				return 0;
			}

			private static int zasyi(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, double rl, double tol, double elim, double alim)
			{
				double bi = 0.0;
				double br = 0.0;
				nz = 0;
				double num = zabs(zr, zi);
				double num2 = Math.Sqrt(d1mach(1) * 1000.0);
				int num3 = Math.Min(2, n);
				double num4 = fnu + (double)(n - num3);
				double num5 = 1.0 / num;
				double br2 = zr * num5;
				double bi2 = (0.0 - zi) * num5;
				double br3 = 1.0 / (2.0 * Math.PI) * br2 * num5;
				double bi3 = 1.0 / (2.0 * Math.PI) * bi2 * num5;
				zsqrt(br3, bi3, ref br3, ref bi3);
				double num6 = zr;
				double ai = zi;
				if (kode == 2)
				{
					num6 = 0.0;
					ai = zi;
				}
				if (!(Math.Abs(num6) > elim))
				{
					double num7 = num4 + num4;
					int num8 = 1;
					if (!(Math.Abs(num6) > alim) || n <= 2)
					{
						num8 = 0;
						zexp(num6, ai, ref br2, ref bi2);
						zmlt(br3, bi3, br2, bi2, ref br3, ref bi3);
					}
					double num9 = 0.0;
					if (num7 > num2)
					{
						num9 = num7 * num7;
					}
					double num10 = zr * 8.0;
					double num11 = zi * 8.0;
					double num12 = 8.0 * num;
					double num13 = tol / num12;
					int num14 = (int)(rl + rl) + 2;
					double num15 = 0.0;
					double num16 = 0.0;
					double num19;
					if (zi != 0.0)
					{
						int num17 = (int)fnu;
						double num18 = (fnu - (double)num17) * Math.PI;
						num17 = num17 + n - num3;
						num19 = 0.0 - Math.Sin(num18);
						double num20 = Math.Cos(num18);
						if (zi < 0.0)
						{
							num20 = 0.0 - num20;
						}
						num15 = num19;
						num16 = num20;
						if (num17 % 2 != 0)
						{
							num15 = 0.0 - num15;
							num16 = 0.0 - num16;
						}
					}
					int i;
					for (i = 1; i <= num3; i++)
					{
						double num21 = num9 - 1.0;
						double num22 = num13 * Math.Abs(num21);
						double num23 = 1.0;
						double num24 = 1.0;
						double num25 = 0.0;
						double num26 = 1.0;
						double num27 = 0.0;
						br = 1.0;
						bi = 0.0;
						num19 = 0.0;
						double num28 = 1.0;
						double num29 = num12;
						double num30 = num10;
						double num31 = num11;
						int num32 = 1;
						while (true)
						{
							if (num32 <= num14)
							{
								zdiv(br, bi, num30, num31, ref br2, ref bi2);
								br = br2 * num21;
								bi = bi2 * num21;
								num26 += br;
								num27 += bi;
								num23 = 0.0 - num23;
								num24 += br * num23;
								num25 += bi * num23;
								num30 += num10;
								num31 += num11;
								num28 = num28 * Math.Abs(num21) / num29;
								num29 += num12;
								num19 += 8.0;
								num21 -= num19;
								if (num28 <= num22)
								{
									break;
								}
								num32++;
								continue;
							}
							nz = -2;
							return 0;
						}
						double num33 = num24;
						double num34 = num25;
						if (!(zr + zr >= elim))
						{
							double num35 = zr + zr;
							double num36 = zi + zi;
							zexp(0.0 - num35, 0.0 - num36, ref br2, ref bi2);
							zmlt(br2, bi2, num15, num16, ref br2, ref bi2);
							zmlt(br2, bi2, num26, num27, ref br2, ref bi2);
							num33 += br2;
							num34 += bi2;
						}
						num9 = num9 + num4 * 8.0 + 4.0;
						num15 = 0.0 - num15;
						num16 = 0.0 - num16;
						int num37 = n - num3 + i;
						yr[num37 - 1] = num33 * br3 - num34 * bi3;
						yi[num37 - 1] = num33 * bi3 + num34 * br3;
					}
					if (n <= 2)
					{
						return 0;
					}
					i = n - 2;
					num19 = i;
					br2 = zr * num5;
					bi2 = (0.0 - zi) * num5;
					double num38 = (br2 + br2) * num5;
					double num39 = (bi2 + bi2) * num5;
					for (int j = 3; j <= n; j++)
					{
						yr[i - 1] = (num19 + fnu) * (num38 * yr[i] - num39 * yi[i]) + yr[i + 1];
						yi[i - 1] = (num19 + fnu) * (num38 * yi[i] + num39 * yr[i]) + yi[i + 1];
						num19 -= 1.0;
						i--;
					}
					if (num8 == 0)
					{
						return 0;
					}
					zexp(num6, ai, ref br, ref bi);
					for (int j = 1; j <= n; j++)
					{
						br2 = yr[j - 1] * br - yi[j - 1] * bi;
						yi[j - 1] = yr[j] * bi + yi[j - 1] * br;
						yr[j - 1] = br2;
					}
					return 0;
				}
				nz = -1;
				return 0;
			}

			private static int zbinu(double zr, double zi, double fnu, int kode, int n, double[] cyr, double[] cyi, ref int nz, double rl, double fnul, double tol, double elim, double alim)
			{
				int nlast = 0;
				int num = 0;
				int nz2 = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				nz = 0;
				double num2 = zabs(zr, zi);
				int num3 = n;
				double num4 = fnu + (double)(n - 1);
				if (num2 <= 2.0 || !(num2 * num2 * 0.25 > num4 + 1.0))
				{
					zseri(zr, zi, fnu, kode, num3, cyr, cyi, ref nz2, tol, elim, alim);
					int num5 = Math.Abs(nz2);
					nz += num5;
					num3 -= num5;
					if (num3 == 0)
					{
						return 0;
					}
					if (nz2 >= 0)
					{
						goto IL_021f;
					}
					num4 = fnu + (double)(num3 - 1);
				}
				if (!(num2 < rl))
				{
					if (num4 <= 1.0 || !(num2 + num2 < num4 * num4))
					{
						zasyi(zr, zi, fnu, kode, num3, cyr, cyi, ref nz2, rl, tol, elim, alim);
						if (nz2 >= 0)
						{
							goto IL_021f;
						}
						goto IL_0221;
					}
				}
				else if (num4 <= 1.0)
				{
					goto IL_013b;
				}
				zuoik(zr, zi, fnu, kode, 1, num3, cyr, cyi, ref nz2, tol, elim, alim);
				if (nz2 >= 0)
				{
					nz += nz2;
					num3 -= nz2;
					if (num3 == 0)
					{
						return 0;
					}
					num4 = fnu + (double)(num3 - 1);
					if (num4 > fnul || num2 > fnul)
					{
						num = (int)(fnul - num4) + 1;
						num = Math.Max(num, 0);
						zbuni(zr, zi, fnu, kode, num3, cyr, cyi, ref nz2, num, ref nlast, fnul, tol, elim, alim);
						if (nz2 < 0)
						{
							goto IL_0221;
						}
						nz += nz2;
						if (nlast == 0)
						{
							goto IL_021f;
						}
						num3 = nlast;
					}
					if (!(num2 > rl))
					{
						goto IL_013b;
					}
					zuoik(zr, zi, fnu, kode, 2, 2, array2, array, ref nz2, tol, elim, alim);
					if (nz2 < 0)
					{
						nz = num3;
						for (int i = 1; i <= num3; i++)
						{
							cyr[i - 1] = 0.0;
							cyi[i - 1] = 0.0;
						}
						return 0;
					}
					if (nz2 <= 0)
					{
						zwrsk(zr, zi, fnu, kode, num3, cyr, cyi, ref nz2, array2, array, tol, elim, alim);
						if (nz2 >= 0)
						{
							goto IL_021f;
						}
					}
				}
				goto IL_0221;
				IL_013b:
				zmlri(zr, zi, fnu, kode, num3, cyr, cyi, ref nz2, tol);
				if (nz2 >= 0)
				{
					goto IL_021f;
				}
				goto IL_0221;
				IL_021f:
				return 0;
				IL_0221:
				nz = -1;
				if (nz2 == -2)
				{
					nz = -2;
				}
				return 0;
			}

			private static int zbknu(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, double tol, double elim, double alim)
			{
				double[] array = new double[8] { 0.5772156649015329, -0.04200263503409524, -0.04219773455554433, 0.0072189432466631, -0.00021524167411495098, -2.013485478078824E-05, 1.133027231981696E-06, 6.116095104481416E-09 };
				double cchi = 0.0;
				double cchr = 0.0;
				double num = 0.0;
				double num2 = 0.0;
				double ci = 0.0;
				double cr = 0.0;
				double cshi = 0.0;
				double cshr = 0.0;
				double ci2 = 0.0;
				double cr2 = 0.0;
				double num3 = 0.0;
				double ci3 = 0.0;
				double cr3 = 0.0;
				double bi = 0.0;
				double br = 0.0;
				double ci4 = 0.0;
				double cr4 = 0.0;
				int ierr = 0;
				int nz2 = 0;
				double[] array2 = new double[2];
				double[] array3 = new double[2];
				double[] array4 = new double[3];
				double[] array5 = new double[3];
				double[] array6 = new double[3];
				double num4 = zabs(zr, zi);
				double num5 = 1.0 / tol;
				array4[0] = num5;
				array4[1] = 1.0;
				array4[2] = tol;
				array5[0] = tol;
				array5[1] = 1.0;
				array5[2] = num5;
				array6[0] = 1000.0 * d1mach(1) / tol;
				array6[1] = 1.0 / array6[0];
				array6[2] = d1mach(2);
				nz = 0;
				int num6 = 0;
				int num7 = kode;
				double num8 = 1.0 / num4;
				double br2 = zr * num8;
				double bi2 = (0.0 - zi) * num8;
				double num9 = (br2 + br2) * num8;
				double num10 = (bi2 + bi2) * num8;
				int num11 = (int)(fnu + 0.5);
				double num12 = fnu - (double)num11;
				int num32;
				double num16;
				double num27;
				double num28;
				if (Math.Abs(num12) != 0.5)
				{
					num3 = 0.0;
					if (Math.Abs(num12) > tol)
					{
						num3 = num12 * num12;
					}
					if (!(num4 > 2.0))
					{
						double num13 = 1.0;
						zlog(num9, num10, ref br, ref bi, ref ierr);
						double num14 = br * num12;
						double num15 = bi * num12;
						zshch(num14, num15, ref cshr, ref cshi, ref cchr, ref cchi);
						if (num12 != 0.0)
						{
							num13 = num12 * Math.PI;
							num13 /= Math.Sin(num13);
							br = cshr / num12;
							bi = cshi / num12;
						}
						double z = 1.0 + num12;
						num16 = Math.Exp(0.0 - dgamln(z, ref ierr));
						double num17 = 1.0 / (num16 * num13);
						double num21;
						double num18;
						if (!(Math.Abs(num12) > 0.1))
						{
							num18 = 1.0;
							double num19 = array[0];
							for (int i = 2; i <= 8; i++)
							{
								num18 *= num3;
								double num20 = array[i - 1] * num18;
								num19 += num20;
								if (Math.Abs(num20) < tol)
								{
									break;
								}
							}
							num21 = 0.0 - num19;
						}
						else
						{
							num21 = (num17 - num16) / (num12 + num12);
						}
						double num22 = (num17 + num16) * 0.5;
						double br3 = num13 * (cchr * num21 + br * num22);
						double bi3 = num13 * (cchi * num21 + bi * num22);
						zexp(num14, num15, ref br2, ref bi2);
						double num23 = 0.5 * br2 / num16;
						double num24 = 0.5 * bi2 / num16;
						zdiv(0.5, 0.0, br2, bi2, ref cr3, ref ci3);
						double num25 = cr3 / num17;
						double num26 = ci3 / num17;
						num27 = br3;
						num28 = bi3;
						cr4 = num23;
						ci4 = num24;
						num18 = 1.0;
						double num29 = 1.0;
						num2 = 1.0;
						num = 0.0;
						double num30 = 1.0 - num3;
						if (num11 <= 0 && n <= 1)
						{
							if (!(num4 < tol))
							{
								zmlt(zr, zi, zr, zi, ref cr2, ref ci2);
								cr2 = 0.25 * cr2;
								ci2 = 0.25 * ci2;
								num17 = 0.25 * num4 * num4;
								do
								{
									br3 = (br3 * num18 + num23 + num25) / num30;
									bi3 = (bi3 * num18 + num24 + num26) / num30;
									br2 = 1.0 / (num18 - num12);
									num23 *= br2;
									num24 *= br2;
									br2 = 1.0 / (num18 + num12);
									num25 *= br2;
									num26 *= br2;
									br2 = num2 * cr2 - num * ci2;
									double num31 = 1.0 / num18;
									num = (num2 * ci2 + num * cr2) * num31;
									num2 = br2 * num31;
									num27 = num2 * br3 - num * bi3 + num27;
									num28 = num2 * bi3 + num * br3 + num28;
									num29 = num29 * num17 * num31;
									num30 = num30 + num18 + num18 + 1.0;
									num18 += 1.0;
								}
								while (num29 > tol);
							}
							yr[0] = num27;
							yi[0] = num28;
							if (num7 == 1)
							{
								return 0;
							}
							zexp(zr, zi, ref br2, ref bi2);
							zmlt(num27, num28, br2, bi2, ref yr[0], ref yi[0]);
							return 0;
						}
						if (!(num4 < tol))
						{
							zmlt(zr, zi, zr, zi, ref cr2, ref ci2);
							cr2 = 0.25 * cr2;
							ci2 = 0.25 * ci2;
							num17 = 0.25 * num4 * num4;
							do
							{
								br3 = (br3 * num18 + num23 + num25) / num30;
								bi3 = (bi3 * num18 + num24 + num26) / num30;
								br2 = 1.0 / (num18 - num12);
								num23 *= br2;
								num24 *= br2;
								br2 = 1.0 / (num18 + num12);
								num25 *= br2;
								num26 *= br2;
								br2 = num2 * cr2 - num * ci2;
								double num31 = 1.0 / num18;
								num = (num2 * ci2 + num * cr2) * num31;
								num2 = br2 * num31;
								num27 = num2 * br3 - num * bi3 + num27;
								num28 = num2 * bi3 + num * br3 + num28;
								br2 = num23 - br3 * num18;
								bi2 = num24 - bi3 * num18;
								cr4 = num2 * br2 - num * bi2 + cr4;
								ci4 = num2 * bi2 + num * br2 + ci4;
								num29 = num29 * num17 * num31;
								num30 = num30 + num18 + num18 + 1.0;
								num18 += 1.0;
							}
							while (num29 > tol);
						}
						num32 = 2;
						num29 = fnu + 1.0;
						num18 = num29 * Math.Abs(br);
						if (num18 > alim)
						{
							num32 = 3;
						}
						br2 = array4[num32 - 1];
						double ar = cr4 * br2;
						double ai = ci4 * br2;
						zmlt(ar, ai, num9, num10, ref cr4, ref ci4);
						num27 *= br2;
						num28 *= br2;
						if (num7 != 1)
						{
							zexp(zr, zi, ref br3, ref bi3);
							zmlt(num27, num28, br3, bi3, ref num27, ref num28);
							zmlt(cr4, ci4, br3, bi3, ref cr4, ref ci4);
						}
						goto IL_0c63;
					}
				}
				zsqrt(zr, zi, ref br2, ref bi2);
				zdiv(1.2533141373155003, 0.0, br2, bi2, ref cr, ref ci);
				num32 = 2;
				if (num7 != 2)
				{
					if (!(zr > alim))
					{
						br2 = Math.Exp(0.0 - zr) * array4[num32 - 1];
						bi2 = (0.0 - br2) * Math.Sin(zi);
						br2 *= Math.Cos(zi);
						zmlt(cr, ci, br2, bi2, ref cr, ref ci);
					}
					else
					{
						num7 = 2;
						num6 = 1;
						num32 = 2;
					}
				}
				double num44;
				double num45;
				int num38;
				double num37;
				if (Math.Abs(num12) != 0.5)
				{
					double num18 = Math.Cos(Math.PI * num12);
					num18 = Math.Abs(num18);
					if (num18 != 0.0)
					{
						double num33 = Math.Abs(0.25 - num3);
						if (num33 != 0.0)
						{
							double num17 = i1mach(14) - 1;
							num17 = num17 * d1mach(5) * 3.321928094;
							num17 = Math.Max(num17, 12.0);
							num17 = Math.Min(num17, 60.0);
							num16 = 2.0 / 3.0 * num17 - 6.0;
							if (zr == 0.0)
							{
								num17 = Math.PI / 2.0;
							}
							else
							{
								num17 = Math.Atan(zi / zr);
								num17 = Math.Abs(num17);
							}
							double num35;
							double num36;
							double ar;
							if (!(num16 > num4))
							{
								double num34 = num18 / (Math.PI * num4 * tol);
								num35 = 1.0;
								if (!(num34 < 1.0))
								{
									num36 = 2.0;
									num2 = num4 + num4 + 2.0;
									num37 = 0.0;
									ar = 1.0;
									num38 = 1;
									while (true)
									{
										if (num38 <= 30)
										{
											num18 = num33 / num36;
											double num39 = num2 / (num35 + 1.0);
											cr3 = ar;
											ar = num39 * ar - num37 * num18;
											num37 = cr3;
											num2 += 2.0;
											num36 = num36 + num35 + num35 + 2.0;
											num33 = num33 + num35 + num35;
											num35 += 1.0;
											br2 = Math.Abs(ar) * num35;
											if (num34 < br2)
											{
												break;
											}
											num38++;
											continue;
										}
										nz = -2;
										return 0;
									}
									num35 += 6.0 / Math.PI * num17 * Math.Sqrt(num16 / num4);
									num33 = Math.Abs(0.25 - num3);
								}
							}
							else
							{
								double z = Math.Sqrt(num4);
								num18 = 1.8976999933151775 * num18 / (tol * Math.Sqrt(z));
								double d = 3.0 * num17 / (1.0 + num4);
								double d2 = 14.7 * num17 / (28.0 + num4);
								num18 = (Math.Log(num18) + num4 * Math.Cos(d) / (1.0 + 0.008 * num4)) / Math.Cos(d2);
								num35 = 97.0 / 800.0 * num18 * num18 / num4 + 1.5;
							}
							int i = (int)num35;
							num35 = i;
							num36 = num35 * num35;
							num37 = 0.0;
							double num40 = 0.0;
							ar = tol;
							double ai = 0.0;
							double num41 = ar;
							double num42 = ai;
							for (num38 = 1; num38 <= i; num38++)
							{
								double num29 = num36 - num35;
								num18 = (num36 + num35) / (num29 + num33);
								double num31 = 2.0 / (num35 + 1.0);
								double num39 = (num35 + zr) * num31;
								double num43 = zi * num31;
								cr3 = ar;
								ci3 = ai;
								ar = (cr3 * num39 - ci3 * num43 - num37) * num18;
								ai = (ci3 * num39 + cr3 * num43 - num40) * num18;
								num37 = cr3;
								num40 = ci3;
								num41 += ar;
								num42 += ai;
								num36 = num29 - num35 + 1.0;
								num35 -= 1.0;
							}
							double num20 = zabs(num41, num42);
							cr3 = 1.0 / num20;
							num27 = ar * cr3;
							num28 = ai * cr3;
							num41 *= cr3;
							num42 = (0.0 - num42) * cr3;
							zmlt(cr, ci, num27, num28, ref br2, ref bi2);
							zmlt(br2, bi2, num41, num42, ref num27, ref num28);
							if (num11 <= 0 && n <= 1)
							{
								num44 = zr;
								num45 = zi;
								if (num6 != 1)
								{
									goto IL_0db1;
								}
								goto IL_1099;
							}
							num20 = zabs(ar, ai);
							cr3 = 1.0 / num20;
							num37 *= cr3;
							num40 *= cr3;
							ar *= cr3;
							ai = (0.0 - ai) * cr3;
							zmlt(num37, num40, ar, ai, ref cr3, ref ci3);
							br2 = num12 + 0.5 - cr3;
							bi2 = 0.0 - ci3;
							zdiv(br2, bi2, zr, zi, ref br2, ref bi2);
							br2 += 1.0;
							zmlt(br2, bi2, num27, num28, ref cr4, ref ci4);
							goto IL_0c63;
						}
					}
				}
				num27 = cr;
				num28 = ci;
				cr4 = cr;
				ci4 = ci;
				goto IL_0c63;
				IL_1048:
				num32 = 1;
				int num46 = num38 + 1;
				int num47;
				cr4 = array2[num47 - 1];
				ci4 = array3[num47 - 1];
				num47 = 3 - num47;
				num27 = array2[num47 - 1];
				num28 = array3[num47 - 1];
				if (num46 <= num11)
				{
					goto IL_0cba;
				}
				if (n == 1)
				{
					num27 = cr4;
					num28 = ci4;
				}
				goto IL_0db1;
				IL_1099:
				yr[0] = num27;
				yi[0] = num28;
				if (n != 1)
				{
					yr[1] = cr4;
					yi[1] = ci4;
				}
				double ascle = array6[0];
				zkscl(num44, num45, fnu, n, yr, yi, ref nz, num9, num10, ascle, tol, elim);
				num11 = n - nz;
				if (num11 <= 0)
				{
					return 0;
				}
				int num48 = nz + 1;
				num27 = yr[num48 - 1];
				num28 = yi[num48 - 1];
				yr[num48 - 1] = num27 * array5[0];
				yi[num48 - 1] = num28 * array5[0];
				if (num11 == 1)
				{
					return 0;
				}
				num48 = nz + 2;
				cr4 = yr[num48 - 1];
				ci4 = yi[num48 - 1];
				yr[num48 - 1] = cr4 * array5[0];
				yi[num48 - 1] = ci4 * array5[0];
				if (num11 == 2)
				{
					return 0;
				}
				num16 = fnu + (double)(num48 - 1);
				num2 = num16 * num9;
				num = num16 * num10;
				num32 = 1;
				goto IL_0def;
				IL_0cba:
				num37 = array5[num32 - 1];
				ascle = array6[num32 - 1];
				for (num38 = num46; num38 <= num11; num38++)
				{
					br2 = cr4;
					bi2 = ci4;
					cr4 = num2 * br2 - num * bi2 + num27;
					ci4 = num2 * bi2 + num * br2 + num28;
					num27 = br2;
					num28 = bi2;
					num2 += num9;
					num += num10;
					if (num32 < 3)
					{
						double ar = cr4 * num37;
						double ai = ci4 * num37;
						br2 = Math.Abs(ar);
						bi2 = Math.Abs(ai);
						if (!(Math.Max(br2, bi2) <= ascle))
						{
							num32++;
							ascle = array6[num32 - 1];
							num27 *= num37;
							num28 *= num37;
							cr4 = ar;
							ci4 = ai;
							br2 = array4[num32 - 1];
							num27 *= br2;
							num28 *= br2;
							cr4 *= br2;
							ci4 *= br2;
							num37 = array5[num32 - 1];
						}
					}
				}
				if (n == 1)
				{
					num27 = cr4;
					num28 = ci4;
				}
				goto IL_0db1;
				IL_0def:
				num48++;
				if (num48 > n)
				{
					return 0;
				}
				num37 = array5[num32 - 1];
				ascle = array6[num32 - 1];
				for (num38 = num48; num38 <= n; num38++)
				{
					double ar = cr4;
					double ai = ci4;
					cr4 = num2 * ar - num * ai + num27;
					ci4 = num * ar + num2 * ai + num28;
					num27 = ar;
					num28 = ai;
					num2 += num9;
					num += num10;
					ar = cr4 * num37;
					ai = ci4 * num37;
					yr[num38 - 1] = ar;
					yi[num38 - 1] = ai;
					if (num32 < 3)
					{
						br2 = Math.Abs(ar);
						bi2 = Math.Abs(ai);
						if (!(Math.Max(br2, bi2) <= ascle))
						{
							num32++;
							ascle = array6[num32 - 1];
							num27 *= num37;
							num28 *= num37;
							cr4 = ar;
							ci4 = ai;
							br2 = array4[num32 - 1];
							num27 *= br2;
							num28 *= br2;
							cr4 *= br2;
							ci4 *= br2;
							num37 = array5[num32 - 1];
						}
					}
				}
				return 0;
				IL_0c63:
				br2 = num12 + 1.0;
				num2 = br2 * num9;
				num = br2 * num10;
				if (n == 1)
				{
					num11--;
				}
				if (num11 <= 0)
				{
					if (n <= 1)
					{
						num27 = cr4;
						num28 = ci4;
					}
					num44 = zr;
					num45 = zi;
					if (num6 != 1)
					{
						goto IL_0db1;
					}
				}
				else
				{
					num46 = 1;
					if (num6 != 1)
					{
						goto IL_0cba;
					}
					double num49 = 0.5 * elim;
					double num50 = Math.Exp(0.0 - elim);
					ascle = array6[0];
					num44 = zr;
					num45 = zi;
					int num51 = -1;
					num47 = 2;
					for (num38 = 1; num38 <= num11; num38++)
					{
						br2 = cr4;
						bi2 = ci4;
						cr4 = br2 * num2 - bi2 * num + num27;
						ci4 = bi2 * num2 + br2 * num + num28;
						num27 = br2;
						num28 = bi2;
						num2 += num9;
						num += num10;
						double num52 = Math.Log(zabs(cr4, ci4));
						double ar = 0.0 - num44 + num52;
						if (!(ar < 0.0 - elim))
						{
							zlog(cr4, ci4, ref br2, ref bi2, ref ierr);
							ar = 0.0 - num44 + br2;
							double ai = 0.0 - num45 + bi2;
							double num53 = Math.Exp(ar) / tol;
							num37 = num53 * Math.Cos(ai);
							double num40 = num53 * Math.Sin(ai);
							zuchk(num37, num40, ref nz2, ascle, tol);
							if (nz2 == 0)
							{
								num47 = 3 - num47;
								array2[num47 - 1] = num37;
								array3[num47 - 1] = num40;
								if (num51 != num38 - 1)
								{
									num51 = num38;
									continue;
								}
								goto IL_1048;
							}
						}
						if (!(num52 < num49))
						{
							num44 -= elim;
							num27 *= num50;
							num28 *= num50;
							cr4 *= num50;
							ci4 *= num50;
						}
					}
					if (n == 1)
					{
						num27 = cr4;
						num28 = ci4;
					}
				}
				goto IL_1099;
				IL_0db1:
				br2 = array5[num32 - 1];
				yr[0] = num27 * br2;
				yi[0] = num28 * br2;
				if (n == 1)
				{
					return 0;
				}
				yr[1] = cr4 * br2;
				yi[1] = ci4 * br2;
				if (n == 2)
				{
					return 0;
				}
				num48 = 2;
				goto IL_0def;
			}

			private static int zbuni(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, int nui, ref int nlast, double fnul, double tol, double elim, double alim)
			{
				int nz2 = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				double[] array3 = new double[3];
				nz = 0;
				double num = Math.Abs(zr) * 1.7321;
				double num2 = Math.Abs(zi);
				int num3 = 1;
				if (num2 > num)
				{
					num3 = 2;
				}
				if (nui != 0)
				{
					double num4 = nui;
					double num5 = fnu + (double)(n - 1);
					double fnu2 = num5 + num4;
					if (num3 != 2)
					{
						zuni1(zr, zi, fnu2, kode, 2, array2, array, ref nz2, ref nlast, fnul, tol, elim, alim);
					}
					else
					{
						zuni2(zr, zi, fnu2, kode, 2, array2, array, ref nz2, ref nlast, fnul, tol, elim, alim);
					}
					if (nz2 >= 0)
					{
						if (nz2 == 0)
						{
							double num6 = zabs(array2[0], array[0]);
							array3[0] = d1mach(1) * 1000.0 / tol;
							array3[1] = 1.0 / array3[0];
							array3[2] = array3[1];
							int num7 = 2;
							double num8 = array3[1];
							double num9 = 1.0;
							if (!(num6 > array3[0]))
							{
								num7 = 1;
								num8 = array3[0];
								num9 = 1.0 / tol;
							}
							else if (!(num6 < array3[1]))
							{
								num7 = 3;
								num8 = array3[2];
								num9 = tol;
							}
							double num10 = 1.0 / num9;
							double num11 = array2[1] * num9;
							double num12 = array[1] * num9;
							double num13 = array2[0] * num9;
							double num14 = array[0] * num9;
							double num15 = 1.0 / zabs(zr, zi);
							num6 = zr * num15;
							double num16 = (0.0 - zi) * num15;
							double num17 = (num6 + num6) * num15;
							double num18 = (num16 + num16) * num15;
							for (int i = 1; i <= nui; i++)
							{
								num6 = num13;
								num16 = num14;
								num13 = (num5 + num4) * (num17 * num6 - num18 * num16) + num11;
								num14 = (num5 + num4) * (num17 * num16 + num18 * num6) + num12;
								num11 = num6;
								num12 = num16;
								num4 += -1.0;
								if (num7 < 3)
								{
									num6 = num13 * num10;
									num16 = num14 * num10;
									double val = Math.Abs(num6);
									double val2 = Math.Abs(num16);
									if (!(Math.Max(val, val2) <= num8))
									{
										num7++;
										num8 = array3[num7 - 1];
										num11 *= num10;
										num12 *= num10;
										num13 = num6;
										num14 = num16;
										num9 *= tol;
										num10 = 1.0 / num9;
										num11 *= num9;
										num12 *= num9;
										num13 *= num9;
										num14 *= num9;
									}
								}
							}
							yr[n - 1] = num13 * num10;
							yi[n - 1] = num14 * num10;
							if (n == 1)
							{
								return 0;
							}
							int num19 = n - 1;
							num4 = num19;
							int num20 = num19;
							for (int i = 1; i <= num19; i++)
							{
								num6 = num13;
								num16 = num14;
								num13 = (fnu + num4) * (num17 * num6 - num18 * num16) + num11;
								num14 = (fnu + num4) * (num17 * num16 + num18 * num6) + num12;
								num11 = num6;
								num12 = num16;
								num6 = num13 * num10;
								num16 = num14 * num10;
								yr[num20 - 1] = num6;
								yi[num20 - 1] = num16;
								num4 += -1.0;
								num20--;
								if (num7 < 3)
								{
									double val3 = Math.Abs(num6);
									double val2 = Math.Abs(num16);
									if (!(Math.Max(val3, val2) <= num8))
									{
										num7++;
										num8 = array3[num7 - 1];
										num11 *= num10;
										num12 *= num10;
										num13 = num6;
										num14 = num16;
										num9 *= tol;
										num10 = 1.0 / num9;
										num11 *= num9;
										num12 *= num9;
										num13 *= num9;
										num14 *= num9;
									}
								}
							}
							return 0;
						}
						nlast = n;
						return 0;
					}
				}
				else
				{
					if (num3 != 2)
					{
						zuni1(zr, zi, fnu, kode, n, yr, yi, ref nz2, ref nlast, fnul, tol, elim, alim);
					}
					else
					{
						zuni2(zr, zi, fnu, kode, n, yr, yi, ref nz2, ref nlast, fnul, tol, elim, alim);
					}
					if (nz2 >= 0)
					{
						nz = nz2;
						return 0;
					}
				}
				nz = -1;
				if (nz2 == -2)
				{
					nz = -2;
				}
				return 0;
			}

			private static int zbunk(double zr, double zi, double fnu, int kode, int mr, int n, double[] yr, double[] yi, ref int nz, double tol, double elim, double alim)
			{
				nz = 0;
				double num = Math.Abs(zr) * 1.7321;
				if (!(Math.Abs(zi) > num))
				{
					zunk1(zr, zi, fnu, kode, mr, n, yr, yi, ref nz, tol, elim, alim);
				}
				else
				{
					zunk2(zr, zi, fnu, kode, mr, n, yr, yi, ref nz, tol, elim, alim);
				}
				return 0;
			}

			private static int zkscl(double zrr, double zri, double fnu, int n, double[] yr, double[] yi, ref int nz, double rzr, double rzi, double ascle, double tol, double elim)
			{
				double bi = 0.0;
				double br = 0.0;
				int ierr = 0;
				int nz2 = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				nz = 0;
				int num = 0;
				int num2 = Math.Min(2, n);
				double num3;
				double num4;
				int i;
				for (i = 1; i <= num2; i++)
				{
					num3 = yr[i - 1];
					num4 = yi[i - 1];
					array2[i - 1] = num3;
					array[i - 1] = num4;
					double d = zabs(num3, num4);
					double num5 = 0.0 - zrr + Math.Log(d);
					nz++;
					yr[i - 1] = 0.0;
					yi[i - 1] = 0.0;
					if (!(num5 < 0.0 - elim))
					{
						zlog(num3, num4, ref br, ref bi, ref ierr);
						br -= zrr;
						bi -= zri;
						double num6 = Math.Exp(br) / tol;
						br = num6 * Math.Cos(bi);
						bi = num6 * Math.Sin(bi);
						zuchk(br, bi, ref nz2, ascle, tol);
						if (nz2 == 0)
						{
							yr[i - 1] = br;
							yi[i - 1] = bi;
							num = i;
							nz--;
						}
					}
				}
				if (n == 1)
				{
					return 0;
				}
				if (num <= 1)
				{
					yr[0] = 0.0;
					yi[0] = 0.0;
					nz = 2;
				}
				if (n == 2)
				{
					return 0;
				}
				if (nz == 0)
				{
					return 0;
				}
				double num7 = fnu + 1.0;
				double num8 = num7 * rzr;
				double num9 = num7 * rzi;
				num3 = array2[0];
				num4 = array[0];
				double num10 = array2[1];
				double num11 = array[1];
				double num12 = elim * 0.5;
				double num13 = Math.Exp(0.0 - elim);
				double num14 = zrr;
				i = 3;
				while (true)
				{
					if (i <= n)
					{
						int num15 = i;
						br = num10;
						bi = num11;
						num10 = num8 * br - num9 * bi + num3;
						num11 = num9 * br + num8 * bi + num4;
						num3 = br;
						num4 = bi;
						num8 += rzr;
						num9 += rzi;
						double d = zabs(num10, num11);
						double num16 = Math.Log(d);
						double num17 = 0.0 - num14 + num16;
						nz++;
						yr[i - 1] = 0.0;
						yi[i - 1] = 0.0;
						if (!(num17 < 0.0 - elim))
						{
							zlog(num10, num11, ref br, ref bi, ref ierr);
							br -= num14;
							bi -= zri;
							double num18 = Math.Exp(br) / tol;
							br = num18 * Math.Cos(bi);
							bi = num18 * Math.Sin(bi);
							zuchk(br, bi, ref nz2, ascle, tol);
							if (nz2 == 0)
							{
								yr[i - 1] = br;
								yi[i - 1] = bi;
								nz--;
								if (num != num15 - 1)
								{
									num = num15;
									goto IL_02ba;
								}
								nz = num15 - 2;
								break;
							}
						}
						if (!(num16 < num12))
						{
							num14 -= elim;
							num3 *= num13;
							num4 *= num13;
							num10 *= num13;
							num11 *= num13;
						}
						goto IL_02ba;
					}
					nz = n;
					if (num == n)
					{
						nz = n - 1;
					}
					break;
					IL_02ba:
					i++;
				}
				for (i = 1; i <= nz; i++)
				{
					yr[i - 1] = 0.0;
					yi[i - 1] = 0.0;
				}
				return 0;
			}

			private static int zmlri(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, double tol)
			{
				double ci = 0.0;
				double cr = 0.0;
				int ierr = 0;
				double num = d1mach(1) / tol;
				nz = 0;
				double num2 = zabs(zr, zi);
				int num3 = (int)num2;
				int num4 = (int)fnu;
				int num5 = num4 + n - 1;
				double num6 = (double)num3 + 1.0;
				double num7 = 1.0 / num2;
				double br = zr * num7;
				double bi = (0.0 - zi) * num7;
				double num8 = br * num6 * num7;
				double num9 = bi * num6 * num7;
				double num10 = (br + br) * num7;
				double num11 = (bi + bi) * num7;
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = 1.0;
				double num15 = 0.0;
				double num16 = (num6 + 1.0) * num7;
				double num17 = num16 + Math.Sqrt(num16 * num16 - 1.0);
				double num18 = num17 * num17;
				double num19 = (num18 + num18) / ((num18 - 1.0) * (num17 - 1.0));
				num19 /= tol;
				double num20 = num6;
				int num21 = 1;
				while (num21 <= 80)
				{
					double num22 = num14;
					double num23 = num15;
					num14 = num12 - (num8 * num22 - num9 * num23);
					num15 = num13 - (num9 * num22 + num8 * num23);
					num12 = num22;
					num13 = num23;
					num8 += num10;
					num9 += num11;
					double num24 = zabs(num14, num15);
					if (!(num24 > num19 * num20 * num20))
					{
						num20 += 1.0;
						num21++;
						continue;
					}
					num21++;
					int i = 0;
					if (num5 >= num3)
					{
						num12 = 0.0;
						num13 = 0.0;
						num14 = 1.0;
						num15 = 0.0;
						num6 = (double)num5 + 1.0;
						br = zr * num7;
						bi = (0.0 - zi) * num7;
						num8 = br * num6 * num7;
						num9 = bi * num6 * num7;
						num16 = num6 * num7;
						num19 = Math.Sqrt(num16 / tol);
						int num25 = 1;
						for (i = 1; i <= 80; i++)
						{
							num22 = num14;
							num23 = num15;
							num14 = num12 - (num8 * num22 - num9 * num23);
							num15 = num13 - (num8 * num23 + num9 * num22);
							num12 = num22;
							num13 = num23;
							num8 += num10;
							num9 += num11;
							num24 = zabs(num14, num15);
							if (num24 < num19)
							{
								continue;
							}
							if (num25 != 2)
							{
								num16 = zabs(num8, num9);
								double val = num16 + Math.Sqrt(num16 * num16 - 1.0);
								double val2 = num24 / zabs(num12, num13);
								num17 = Math.Min(val, val2);
								num19 *= Math.Sqrt(num17 / (num17 * num17 - 1.0));
								num25 = 2;
								continue;
							}
							goto IL_02c6;
						}
						break;
					}
					goto IL_02c6;
					IL_02c6:
					i++;
					int num26 = Math.Max(num21 + num3, i + num5);
					double num27 = num26;
					num12 = 0.0;
					num13 = 0.0;
					num14 = num;
					num15 = 0.0;
					double num28 = fnu - (double)num4;
					double num29 = num28 + num28;
					double d = dgamln(num27 + num29 + 1.0, ref ierr) - dgamln(num27 + 1.0, ref ierr) - dgamln(num29 + 1.0, ref ierr);
					d = Math.Exp(d);
					double num30 = 0.0;
					double num31 = 0.0;
					int num32 = num26 - num5;
					for (num21 = 1; num21 <= num32; num21++)
					{
						num22 = num14;
						num23 = num15;
						num14 = num12 + (num27 + num28) * (num10 * num22 - num11 * num23);
						num15 = num13 + (num27 + num28) * (num11 * num22 + num10 * num23);
						num12 = num22;
						num13 = num23;
						num20 = 1.0 - num29 / (num27 + num29);
						num16 = d * num20;
						num30 += (num16 + d) * num12;
						num31 += (num16 + d) * num13;
						d = num16;
						num27 += -1.0;
					}
					yr[n - 1] = num14;
					yi[n - 1] = num15;
					if (n != 1)
					{
						for (num21 = 2; num21 <= n; num21++)
						{
							num22 = num14;
							num23 = num15;
							num14 = num12 + (num27 + num28) * (num10 * num22 - num11 * num23);
							num15 = num13 + (num27 + num28) * (num11 * num22 + num10 * num23);
							num12 = num22;
							num13 = num23;
							num20 = 1.0 - num29 / (num27 + num29);
							num16 = d * num20;
							num30 += (num16 + d) * num12;
							num31 += (num16 + d) * num13;
							d = num16;
							num27 += -1.0;
							int num33 = n - num21 + 1;
							yr[num33 - 1] = num14;
							yi[num33 - 1] = num15;
						}
					}
					if (num4 > 0)
					{
						for (num21 = 1; num21 <= num4; num21++)
						{
							num22 = num14;
							num23 = num15;
							num14 = num12 + (num27 + num28) * (num10 * num22 - num11 * num23);
							num15 = num13 + (num27 + num28) * (num10 * num23 + num11 * num22);
							num12 = num22;
							num13 = num23;
							num20 = 1.0 - num29 / (num27 + num29);
							num16 = d * num20;
							num30 += (num16 + d) * num12;
							num31 += (num16 + d) * num13;
							d = num16;
							num27 += -1.0;
						}
					}
					num22 = zr;
					num23 = zi;
					if (kode == 2)
					{
						num22 = 0.0;
					}
					zlog(num10, num11, ref br, ref bi, ref ierr);
					num12 = (0.0 - num28) * br + num22;
					num13 = (0.0 - num28) * bi + num23;
					num24 = dgamln(num28 + 1.0, ref ierr);
					num22 = num12 - num24;
					num23 = num13;
					num14 += num30;
					num15 += num31;
					num24 = zabs(num14, num15);
					num12 = 1.0 / num24;
					zexp(num22, num23, ref br, ref bi);
					num8 = br * num12;
					num9 = bi * num12;
					num22 = num14 * num12;
					num23 = (0.0 - num15) * num12;
					zmlt(num8, num9, num22, num23, ref cr, ref ci);
					for (num21 = 1; num21 <= n; num21++)
					{
						br = yr[num21 - 1] * cr - yi[num21 - 1] * ci;
						yi[num21 - 1] = yr[num21 - 1] * ci + yi[num21 - 1] * cr;
						yr[num21 - 1] = br;
					}
					return 0;
				}
				nz = -2;
				return 0;
			}

			private static int zrati(double zr, double zi, double fnu, int n, double[] cyr, double[] cyi, double tol)
			{
				double num = zabs(zr, zi);
				int num2 = (int)fnu + n - 1;
				int num3 = (int)num;
				double val = num3 + 1;
				double val2 = num2;
				double num4 = Math.Max(val, val2);
				int num5 = num2 - num3 - 1;
				int num6 = 1;
				int num7 = 1;
				double num8 = 1.0 / num;
				double num9 = num8 * (zr + zr) * num8;
				double num10 = (0.0 - num8) * (zi + zi) * num8;
				double num11 = num9 * num4;
				double num12 = num10 * num4;
				double num13 = 0.0 - num11;
				double num14 = 0.0 - num12;
				double num15 = 1.0;
				double num16 = 0.0;
				num11 += num9;
				num12 += num10;
				if (num5 > 0)
				{
					num5 = 0;
				}
				double num17 = zabs(num13, num14);
				double num18 = zabs(num15, num16);
				double num19 = Math.Sqrt((num17 + num17) / (num18 * tol));
				double num20 = num19;
				double num21 = 1.0 / num18;
				num15 *= num21;
				num16 *= num21;
				num13 *= num21;
				num14 *= num21;
				num17 *= num21;
				double num23;
				while (true)
				{
					num7++;
					num18 = num17;
					num8 = num13;
					double num22 = num14;
					num13 = num15 - (num11 * num8 - num12 * num22);
					num14 = num16 - (num11 * num22 + num12 * num8);
					num15 = num8;
					num16 = num22;
					num11 += num9;
					num12 += num10;
					num17 = zabs(num13, num14);
					if (!(num18 <= num20))
					{
						if (num6 == 2)
						{
							break;
						}
						num23 = zabs(num11, num12) * 0.5;
						double val3 = num23 + Math.Sqrt(num23 * num23 - 1.0);
						double num24 = Math.Min(num17 / num18, val3);
						num20 = num19 * Math.Sqrt(num24 / (num24 * num24 - 1.0));
						num6 = 2;
					}
				}
				int num25 = num7 + 1 - num5;
				num23 = num25;
				num11 = num23;
				num12 = 0.0;
				double num26 = fnu + (double)(n - 1);
				num15 = 1.0 / num17;
				num16 = 0.0;
				num13 = 0.0;
				num14 = 0.0;
				for (int i = 1; i <= num25; i++)
				{
					num8 = num15;
					double num22 = num16;
					num21 = num26 + num11;
					double num27 = num9 * num21;
					double num28 = num10 * num21;
					num15 = num8 * num27 - num22 * num28 + num13;
					num16 = num8 * num28 + num22 * num27 + num14;
					num13 = num8;
					num14 = num22;
					num11 -= 1.0;
				}
				if (num15 == 0.0 && num16 == 0.0)
				{
					num15 = tol;
					num16 = tol;
				}
				zdiv(num13, num14, num15, num16, ref cyr[n - 1], ref cyi[n - 1]);
				if (n == 1)
				{
					return 0;
				}
				num7 = n - 1;
				num23 = num7;
				num11 = num23;
				num12 = 0.0;
				double num29 = fnu * num9;
				double num30 = fnu * num10;
				for (int i = 2; i <= n; i++)
				{
					num8 = num29 + (num11 * num9 - num12 * num10) + cyr[num7];
					double num22 = num30 + (num11 * num10 + num12 * num9) + cyi[num7];
					num23 = zabs(num8, num22);
					if (num23 == 0.0)
					{
						num8 = tol;
						num22 = tol;
						num23 = tol * 1.4142135623730951;
					}
					double num31 = 1.0 / num23;
					cyr[num7 - 1] = num31 * num8 * num31;
					cyi[num7 - 1] = (0.0 - num31) * num22 * num31;
					num11 -= 1.0;
					num7--;
				}
				return 0;
			}

			private static int zs1s2(double zrr, double zri, ref double s1r, ref double s1i, ref double s2r, ref double s2i, ref int nz, double ascle, double alim, ref int iuf)
			{
				double bi = 0.0;
				double br = 0.0;
				int ierr = 0;
				nz = 0;
				double num = zabs(s1r, s1i);
				double val = zabs(s2r, s2i);
				if ((s1r != 0.0 || s1i != 0.0) && num != 0.0)
				{
					double num2 = 0.0 - zrr - zrr + Math.Log(num);
					double ar = s1r;
					double ai = s1i;
					s1r = 0.0;
					s1i = 0.0;
					num = 0.0;
					if (!(num2 < 0.0 - alim))
					{
						zlog(ar, ai, ref br, ref bi, ref ierr);
						br = br - zrr - zrr;
						bi = bi - zri - zri;
						zexp(br, bi, ref s1r, ref s1i);
						num = zabs(s1r, s1i);
						iuf++;
					}
				}
				if (Math.Max(num, val) > ascle)
				{
					return 0;
				}
				s1r = 0.0;
				s1i = 0.0;
				s2r = 0.0;
				s2i = 0.0;
				nz = 1;
				iuf = 0;
				return 0;
			}

			private static int zseri(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, double tol, double elim, double alim)
			{
				double num = 0.0;
				double bi = 0.0;
				double br = 0.0;
				double num2 = 0.0;
				double ci = 0.0;
				double cr = 0.0;
				double num3 = 0.0;
				int ierr = 0;
				int nz2 = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				nz = 0;
				double num4 = zabs(zr, zi);
				if (num4 != 0.0)
				{
					double num5 = d1mach(1) * 1000.0;
					double num6 = Math.Sqrt(num5);
					double num7 = 1.0;
					int num8 = 0;
					if (!(num4 < num5))
					{
						double num9 = zr * 0.5;
						double num10 = zi * 0.5;
						double cr2 = 0.0;
						double ci2 = 0.0;
						if (!(num4 <= num6))
						{
							zmlt(num9, num10, num9, num10, ref cr2, ref ci2);
						}
						double num11 = zabs(cr2, ci2);
						int num12 = n;
						zlog(num9, num10, ref br, ref bi, ref ierr);
						while (true)
						{
							double num13 = fnu + (double)(num12 - 1);
							double num14 = num13 + 1.0;
							double num15 = br * num13;
							double num16 = bi * num13;
							double num17 = dgamln(num14, ref ierr);
							num15 -= num17;
							if (kode == 2)
							{
								num15 -= zr;
							}
							if (num15 > 0.0 - elim)
							{
								if (!(num15 > 0.0 - alim))
								{
									num8 = 1;
									num2 = 1.0 / tol;
									num7 = tol;
									num = num5 * num2;
								}
								double num18 = Math.Exp(num15);
								if (num8 == 1)
								{
									num18 *= num2;
								}
								double num19 = num18 * Math.Cos(num16);
								double num20 = num18 * Math.Sin(num16);
								double num21 = tol * num11 / num14;
								int num22 = Math.Min(2, num12);
								int num23 = 1;
								while (true)
								{
									if (num23 <= num22)
									{
										num13 = fnu + (double)(num12 - num23);
										num14 = num13 + 1.0;
										double num24 = 1.0;
										num3 = 0.0;
										if (!(num11 < tol * num14))
										{
											num15 = 1.0;
											num16 = 0.0;
											num17 = num14 + 2.0;
											double num25 = num14;
											num18 = 2.0;
											do
											{
												double num26 = 1.0 / num25;
												cr = num15 * cr2 - num16 * ci2;
												ci = num15 * ci2 + num16 * cr2;
												num15 = cr * num26;
												num16 = ci * num26;
												num24 += num15;
												num3 += num16;
												num25 += num17;
												num17 += 2.0;
												num18 = num18 * num11 * num26;
											}
											while (num18 > num21);
										}
										double num27 = num24 * num19 - num3 * num20;
										double num28 = num24 * num20 + num3 * num19;
										array2[num23 - 1] = num27;
										array[num23 - 1] = num28;
										if (num8 != 0)
										{
											zuchk(num27, num28, ref nz2, num, tol);
											if (nz2 != 0)
											{
												break;
											}
										}
										int num29 = num12 - num23 + 1;
										yr[num29 - 1] = num27 * num7;
										yi[num29 - 1] = num28 * num7;
										if (num23 != num22)
										{
											zdiv(num19, num20, num9, num10, ref cr, ref ci);
											num19 = cr * num13;
											num20 = ci * num13;
										}
										num23++;
										continue;
									}
									if (num12 <= 2)
									{
										return 0;
									}
									int num30 = num12 - 2;
									num17 = num30;
									double num31 = 1.0 / num4;
									cr = zr * num31;
									ci = (0.0 - zi) * num31;
									double num32 = (cr + cr) * num31;
									double num33 = (ci + ci) * num31;
									int num34;
									if (num8 != 1)
									{
										num34 = 3;
									}
									else
									{
										double num24 = array2[0];
										num3 = array[0];
										double num27 = array2[1];
										double num28 = array[1];
										int num35 = 3;
										while (true)
										{
											if (num35 <= num12)
											{
												br = num27;
												bi = num28;
												num27 = num24 + (num17 + fnu) * (num32 * br - num33 * bi);
												num28 = num3 + (num17 + fnu) * (num32 * bi + num33 * br);
												num24 = br;
												num3 = bi;
												br = num27 * num7;
												bi = num28 * num7;
												yr[num30 - 1] = br;
												yi[num30 - 1] = bi;
												num17 += -1.0;
												num30--;
												if (zabs(br, bi) > num)
												{
													break;
												}
												num35++;
												continue;
											}
											return 0;
										}
										num34 = num35 + 1;
										if (num34 > num12)
										{
											return 0;
										}
									}
									for (num23 = num34; num23 <= num12; num23++)
									{
										yr[num30 - 1] = (num17 + fnu) * (num32 * yr[num30] - num33 * yi[num30]) + yr[num30 + 1];
										yi[num30 - 1] = (num17 + fnu) * (num32 * yi[num30] + num33 * yr[num30]) + yi[num30 + 1];
										num17 += -1.0;
										num30--;
									}
									return 0;
								}
							}
							nz++;
							yr[num12 - 1] = 0.0;
							yi[num12 - 1] = 0.0;
							if (num11 > num13)
							{
								break;
							}
							num12--;
							if (num12 == 0)
							{
								return 0;
							}
						}
						nz = -nz;
						return 0;
					}
					nz = n;
					if (fnu == 0.0)
					{
						nz--;
					}
				}
				yr[0] = 0.0;
				yi[0] = 0.0;
				if (fnu == 0.0)
				{
					yr[0] = 1.0;
					yi[0] = 0.0;
				}
				if (n == 1)
				{
					return 0;
				}
				for (int num23 = 2; num23 <= n; num23++)
				{
					yr[num23 - 1] = 0.0;
					yi[num23 - 1] = 0.0;
				}
				return 0;
			}

			private static int zshch(double zr, double zi, ref double cshr, ref double cshi, ref double cchr, ref double cchi)
			{
				double num = Math.Sinh(zr);
				double num2 = Math.Cosh(zr);
				double num3 = Math.Sin(zi);
				double num4 = Math.Cos(zi);
				cshr = num * num4;
				cshi = num2 * num3;
				cchr = num2 * num4;
				cchi = num * num3;
				return 0;
			}

			private static int zuchk(double yr, double yi, ref int nz, double ascle, double tol)
			{
				nz = 0;
				double val = Math.Abs(yr);
				double val2 = Math.Abs(yi);
				double num = Math.Min(val, val2);
				if (num > ascle)
				{
					return 0;
				}
				double num2 = Math.Max(val, val2);
				num /= tol;
				if (num2 < num)
				{
					nz = 1;
				}
				return 0;
			}

			private static int zunhj(double zr, double zi, double fnu, int ipmtr, double tol, ref double phir, ref double phii, ref double argr, ref double argi, ref double zeta1r, ref double zeta1i, ref double zeta2r, ref double zeta2i, ref double asumr, ref double asumi, ref double bsumr, ref double bsumi)
			{
				double[] array = new double[14]
				{
					1.0,
					5.0 / 48.0,
					0.08355034722222222,
					0.12822657455632716,
					0.29184902646414046,
					0.8816272674437576,
					3.3214082818627677,
					14.995762986862555,
					78.92301301158652,
					474.4515388682643,
					3207.490090890662,
					24086.549640874004,
					198923.1191695098,
					1791902.0077753437
				};
				double[] array2 = new double[14]
				{
					1.0,
					-7.0 / 48.0,
					-0.09874131944444445,
					-0.14331205391589505,
					-0.31722720267841353,
					-0.9424291479571203,
					-3.5112030408263544,
					-15.727263620368046,
					-82.28143909718594,
					-492.3553705236705,
					-3316.2185685479726,
					-24827.67424520859,
					-204526.5873151298,
					-1838444.91706821
				};
				double[] array3 = new double[105]
				{
					1.0,
					-5.0 / 24.0,
					0.125,
					0.3342013888888889,
					-77.0 / 192.0,
					9.0 / 128.0,
					-1.0258125964506173,
					1.8464626736111112,
					-0.8912109375,
					0.0732421875,
					4.669584423426247,
					-11.207002616222994,
					8.78912353515625,
					-2.3640869140625,
					0.112152099609375,
					-28.212072558200244,
					84.63621767460073,
					-91.81824154324002,
					42.53499874538846,
					-7.368794359479632,
					0.22710800170898438,
					212.57013003921713,
					-765.2524681411817,
					1059.9904525279999,
					-699.5796273761325,
					218.1905117442116,
					-26.491430486951554,
					0.5725014209747314,
					-1919.457662318407,
					8061.722181737309,
					-13586.550006434138,
					11655.393336864534,
					-5305.646978613403,
					1200.9029132163525,
					-108.09091978839466,
					1.7277275025844574,
					20204.29133096615,
					-96980.59838863752,
					192547.00123253153,
					-203400.17728041555,
					122200.46498301746,
					-41192.65496889755,
					7109.514302489364,
					-493.915304773088,
					6.074042001273483,
					-242919.18790055133,
					1311763.6146629772,
					-2998015.9185381066,
					3763271.297656404,
					-2813563.226586534,
					1268365.2733216248,
					-331645.1724845636,
					45218.76898136273,
					-2499.8304818112097,
					24.380529699556064,
					3284469.853072038,
					-19706819.118432228,
					50952602.49266464,
					-74105148.21153265,
					66344512.27472903,
					-37567176.66076335,
					13288767.166421818,
					-2785618.1280864547,
					308186.4046126624,
					-13886.08975371704,
					110.01714026924674,
					-49329253.66450996,
					325573074.18576574,
					-939462359.6815784,
					1553596899.57058,
					-1621080552.1083372,
					1106842816.8230145,
					-495889784.2750303,
					142062907.7975331,
					-24474062.72573873,
					2243768.1779224495,
					-84005.43360302408,
					551.3358961220206,
					814789096.1183121,
					-5866481492.051847,
					18688207509.295826,
					-34632043388.158775,
					41280185579.753975,
					-33026599749.800724,
					17954213731.1556,
					-6563293792.619285,
					1559279864.8792574,
					-225105661.88941526,
					17395107.553978164,
					-549842.3275722887,
					3038.090510922384,
					-14679261247.695616,
					114498237732.0258,
					-399096175224.4665,
					819218669548.5773,
					-1098375156081.2233,
					1008158106865.3821,
					-645364869245.3765,
					287900649906.1506,
					-87867072178.02327,
					17634730606.83497,
					-2167164983.223795,
					143157876.71888897,
					-3871833.442572613,
					18257.755474293175
				};
				double[] array4 = new double[180]
				{
					-1.0 / 225.0,
					-0.000922077922077922,
					-8.848928848928849E-05,
					0.00016592768783244973,
					0.0002466913727417929,
					0.0002659955893462548,
					0.00026182429706150096,
					0.0002487304373446556,
					0.00023272104008323209,
					0.00021636248571236508,
					0.00020073885876275234,
					0.00018626763663754517,
					0.0001730607759178765,
					0.00016109170592901574,
					0.00015027477416090814,
					0.0001405034973912698,
					0.0001316688165459228,
					0.00012366744559825325,
					0.00011640527147473791,
					0.00010979829837271337,
					0.00010377241042299283,
					9.826260783693634E-05,
					9.321205172495032E-05,
					8.857108524787117E-05,
					8.429631057157003E-05,
					8.034975484077912E-05,
					7.669813453592074E-05,
					7.331221574817778E-05,
					7.016626251631414E-05,
					6.723756337901603E-05,
					0.000693735541354589,
					0.00023224174518292166,
					-1.419862735566912E-05,
					-0.00011644493167204864,
					-0.00015080355805304876,
					-0.00015512192491809622,
					-0.00014680975664646556,
					-0.00013381550386749137,
					-0.00011974497568425405,
					-0.00010618431920797402,
					-9.376995498911944E-05,
					-8.269230455881933E-05,
					-7.293743481552213E-05,
					-6.440423577210163E-05,
					-5.69611566009369E-05,
					-5.0473104430356164E-05,
					-4.481348680088828E-05,
					-3.9868872771759884E-05,
					-3.554005329720425E-05,
					-3.174142566090225E-05,
					-2.839967939041748E-05,
					-2.5452272063487058E-05,
					-2.2845929716472455E-05,
					-2.053527531064806E-05,
					-1.848162176276661E-05,
					-1.665193300213938E-05,
					-1.5017941298011949E-05,
					-1.3555403137904052E-05,
					-1.2243474647385812E-05,
					-1.1064188481130817E-05,
					-0.00035421197145774384,
					-0.00015616126394515941,
					3.044655035949364E-05,
					0.0001301986557732427,
					0.00016747110669971228,
					0.00017022258768359256,
					0.00015650142760859472,
					0.00013633917097744512,
					0.00011488669202982512,
					9.458690930346882E-05,
					7.644984192508983E-05,
					6.0757033496519734E-05,
					4.743942992905088E-05,
					3.627575120053443E-05,
					2.699397149792249E-05,
					1.9321093824793926E-05,
					1.3005667479396321E-05,
					7.826208667444966E-06,
					3.592574858193516E-06,
					1.4404004981425182E-07,
					-2.653967696979391E-06,
					-4.913468670984859E-06,
					-6.727392960912483E-06,
					-8.17269379678658E-06,
					-9.313047150935612E-06,
					-1.0201141879801643E-05,
					-1.0880596251059288E-05,
					-1.1387548150960355E-05,
					-1.1751967567455642E-05,
					-1.1998736487094414E-05,
					0.0003781941992017729,
					0.00020247195276181616,
					-6.379385063188624E-05,
					-0.0002385982306030059,
					-0.0003109162560273616,
					-0.00031368011524757634,
					-0.0002789502737913234,
					-0.00022856408261914138,
					-0.00017524528034084676,
					-0.00012554406306069035,
					-8.229828728202083E-05,
					-4.628607305881165E-05,
					-1.7233430236696227E-05,
					5.6069048230460226E-06,
					2.313954431482868E-05,
					3.626427458567939E-05,
					4.5800612449018877E-05,
					5.2459529495911405E-05,
					5.683962085458153E-05,
					5.9434982039310406E-05,
					6.0647852757842175E-05,
					6.080239077884365E-05,
					6.0157789453946036E-05,
					5.891996573446985E-05,
					5.72515823777593E-05,
					5.528043755858526E-05,
					5.310637738028802E-05,
					5.080693020123257E-05,
					4.8441864762009484E-05,
					4.6056858160747536E-05,
					-0.0006911413972882942,
					-0.0004299766330588719,
					0.000183067735980039,
					0.0006600881475420142,
					0.0008759649699511859,
					0.0008773352359582355,
					0.0007493695853789907,
					0.000563832329756981,
					0.0003680593199714432,
					0.0001884645355144556,
					3.7066305766490415E-05,
					-8.28520220232137E-05,
					-0.000172751952869173,
					-0.00023631487360587297,
					-0.0002779661506949067,
					-0.00030207951415545694,
					-0.0003125947126438201,
					-0.00031287255875806717,
					-0.0003056780384663244,
					-0.0002932264706145573,
					-0.0002772556555829348,
					-0.0002591039284670317,
					-0.00023978401439648034,
					-0.00022004826004542284,
					-0.00020044391109497149,
					-0.00018135869221097068,
					-0.00016305767447865748,
					-0.00014571267217520584,
					-0.0001294254219839246,
					-0.00011424569194244596,
					0.0019282196424877589,
					0.0013559257630202223,
					-0.000717858090421303,
					-0.0025808480257527035,
					-0.0034927113082616847,
					-0.003469862993409606,
					-0.002822852333513102,
					-0.0018810307640489134,
					-0.0008895317183839476,
					3.8791210263103525E-06,
					0.0007286885401196914,
					0.0012656637305345775,
					0.0016251815837267443,
					0.0018320315321637317,
					0.0019158838899052792,
					0.0019058884675554615,
					0.0018279898242182574,
					0.0017038950642112153,
					0.0015509712717109768,
					0.0013826142185227616,
					0.0012088142423006478,
					0.0010367653263834496,
					0.0008714379180686191,
					0.000716080155297701,
					0.0005726370025581294,
					0.0004420898194658023,
					0.00032472494850309055,
					0.00022034204273024659,
					0.00012841289840135388,
					4.8200592455209545E-05
				};
				double[] array5 = new double[210]
				{
					0.01799887214135533, 0.005599649110643881, 0.0028850140223113277, 0.0018009660676105393, 0.001247531105891992, 0.0009228788765729383, 0.0007144304217272874, 0.0005717872817897049, 0.00046943100760648155, 0.00039323283546291665,
					0.0003348188893182977, 0.00028895214849575154, 0.0002522116155495733, 0.00022228058079888332, 0.0001975418380330625, 0.00017683685501971802, 0.0001593168996618211, 0.00014434793019733397, 0.0001314480681199654, 0.00012024544494930288,
					0.0001104491445045994, 0.00010182877074056726, 9.419982242042375E-05, 8.741305457538345E-05, 8.134662621628014E-05, 7.590022696462193E-05, 7.099063006341535E-05, 6.654828748424682E-05, 6.25146958969275E-05, 5.884033944262518E-05,
					-0.0014928295321342917, -0.0008782047095463894, -0.0005029165495720346, -0.000294822138512746, -0.00017546399697078284, -0.00010400855046081644, -5.961419530464579E-05, -3.1203892907609836E-05, -1.2608973598023005E-05, -2.4289260857573037E-07,
					8.059961654142736E-06, 1.3650700926214739E-05, 1.7396412547292627E-05, 1.9867297884213378E-05, 2.1446326379082263E-05, 2.2395465923245652E-05, 2.2896778381471263E-05, 2.307853898111778E-05, 2.3032197608090914E-05, 2.2823607372034874E-05,
					2.250058811052924E-05, 2.2098101536199144E-05, 2.164184274481039E-05, 2.1150764925622083E-05, 2.0638874978217072E-05, 2.0116524199708165E-05, 1.9591345014117925E-05, 1.9068936791043675E-05, 1.8553371964163667E-05, 1.804757222596742E-05,
					0.0005522130767212928, 0.00044793258155238465, 0.0002795206539920206, 0.0001524681561984466, 6.932711056570436E-05, 1.762586830699914E-05, -1.3574499634326914E-05, -3.179724133504272E-05, -4.188618616966934E-05, -4.6900488937914104E-05,
					-4.8766544741378735E-05, -4.8701003118673505E-05, -4.747556208900866E-05, -4.558130581386284E-05, -4.33309644511266E-05, -4.0923019315775034E-05, -3.848226386032213E-05, -3.608571675354105E-05, -3.377933061233674E-05, -3.158885607721096E-05,
					-2.952695617508073E-05, -2.7597891482833575E-05, -2.5800617466688372E-05, -2.413083567612802E-05, -2.2582350951834605E-05, -2.1147965676891298E-05, -1.9820063888529493E-05, -1.8590987080106508E-05, -1.7453269984421023E-05, -1.63997823854498E-05,
					-0.0004746177965599598, -0.0004778645671473215, -0.00032039022806703763, -0.00016110501611996228, -4.257781012854352E-05, 3.445712942949675E-05, 7.97092684075675E-05, 0.0001031382367082722, 0.00011246677526220416, 0.0001131036421084814,
					0.00010865163484877427, 0.00010143795159766197, 9.29298396593364E-05, 8.4029313301609E-05, 7.52727991349134E-05, 6.696325219757309E-05, 5.925645473231947E-05, 5.2216930882697554E-05, 4.585394851653606E-05, 4.014455138914868E-05,
					3.504817300313281E-05, 3.0515799503434667E-05, 2.6495611995051603E-05, 2.2936363369099816E-05, 1.9789305666402162E-05, 1.7009198463641262E-05, 1.45547428261524E-05, 1.238866409958784E-05, 1.0477587607658323E-05, 8.791799549784793E-06,
					0.0007364658105725784, 0.000872790805146194, 0.0006226148625731351, 0.00028599815419430417, 3.847376728793661E-06, -0.00018790600363697156, -0.00029760364659455455, -0.00034599812683265633, -0.00035338247091603773, -0.00033571563577504876,
					-0.0003043211247890398, -0.00026672272304761283, -0.00022765421412281953, -0.00018992261185456235, -0.00015505891859909386, -0.00012377824076187363, -9.629261477176441E-05, -7.251783277144253E-05, -5.220700288956338E-05, -3.5034775051190054E-05,
					-2.0648976103555174E-05, -8.701060968497671E-06, 1.136986866751003E-06, 9.164264741227788E-06, 1.564777854288726E-05, 2.0822362948246685E-05, 2.4892338100459516E-05, 2.803405095741463E-05, 3.039877746298619E-05, 3.211567314067006E-05,
					-0.0018018219196388571, -0.0024340296293804253, -0.001834226635498568, -0.0007622045963540097, 0.00023907947525692722, 0.0009492661171768811, 0.0013446744970154036, 0.0014845749525944918, 0.001447323398306176, 0.0013026826128565718,
					0.0011035159737564268, 0.0008860474404197917, 0.0006730732081656654, 0.00047760387285658237, 0.00030599192635878935, 0.00016031569459472162, 4.007495552706133E-05, -5.666074616352516E-05, -0.00013250618677298264, -0.00019029618798961406,
					-0.0002328114503769374, -0.00026262881146466884, -0.00028205046986759866, -0.00029308156319286116, -0.0002974359621763166, -0.0002965573342393481, -0.0002916473633120909, -0.0002836962038377342, -0.00027351231709567335, -0.0002617501558067686,
					0.006385858912120509, 0.00962374215806378, 0.0076187806120700105, 0.0028321905554562804, -0.002098413520127201, -0.005738267642166265, -0.0077080424449541465, -0.008210116922648444, -0.007658245203469054, -0.006472097293910452,
					-0.004991324120049665, -0.0034561228971313326, -0.002017855800141708, -0.0007594306867819614, 0.0002841736315238591, 0.001108916675863374, 0.0017290149387272878, 0.002168125908026847, 0.002453577104945397, 0.0026128182105833488,
					0.002671410396562769, 0.0026520307339598045, 0.002574116528772873, 0.0024538912623609443, 0.002304600580717955, 0.0021368483768671267, 0.001958965284788709, 0.0017773700867945441, 0.0015969028076583906, 0.0014211197566443854
				};
				double[] array6 = new double[30]
				{
					0.6299605249474366, 0.25198420997897464, 0.15479030041565583, 0.11071306241615901, 0.08573093955273949, 0.06971613169586843, 0.05860856718937136, 0.05046988735363107, 0.04426005806891548, 0.039372066154350994,
					0.03542831959244554, 0.032181885750209825, 0.029464624079115768, 0.027158167711293448, 0.025176827297386177, 0.02345707553060789, 0.02195083901349072, 0.020621082823564625, 0.019438824089788084, 0.018381063380068317,
					0.017429321323196318, 0.016568583778661234, 0.015786528598791844, 0.01507295014940956, 0.014419325083995464, 0.013818480573534178, 0.013264337899427657, 0.012751712197049864, 0.012276154531876277, 0.01183382623984824
				};
				double ci = 0.0;
				double cr = 0.0;
				double bi = 0.0;
				double br = 0.0;
				double bi2 = 0.0;
				double br2 = 0.0;
				double ci2 = 0.0;
				double cr2 = 0.0;
				double bi3 = 0.0;
				double br3 = 0.0;
				int ierr = 0;
				double[] array7 = new double[30];
				double[] array8 = new double[14];
				double[] array9 = new double[14];
				double[] array10 = new double[14];
				double[] array11 = new double[14];
				double[] array12 = new double[30];
				double[] array13 = new double[30];
				double[] array14 = new double[14];
				double[] array15 = new double[14];
				double num = 1.0 / fnu;
				double num2 = d1mach(1) * 1000.0;
				double num3 = fnu * num2;
				if (!(Math.Abs(zr) > num3) && !(Math.Abs(zi) > num3))
				{
					zeta1r = Math.Abs(Math.Log(num2)) * 2.0 + fnu;
					zeta1i = 0.0;
					zeta2r = fnu;
					zeta2i = 0.0;
					phir = 1.0;
					phii = 0.0;
					argr = 1.0;
					argi = 0.0;
					return 0;
				}
				double num4 = zr * num;
				double num5 = zi * num;
				double num6 = num * num;
				double num7 = Math.Pow(fnu, 1.0 / 3.0);
				double num8 = num7 * num7;
				double num9 = 1.0 / num7;
				double num10 = 1.0 - num4 * num4 + num5 * num5;
				double num11 = 0.0 - num4 * num5 - num4 * num5;
				double num12 = zabs(num10, num11);
				if (!(num12 > 0.25))
				{
					int num13 = 1;
					array13[0] = 1.0;
					array12[0] = 0.0;
					double num14 = array6[0];
					double num15 = 0.0;
					array7[0] = 1.0;
					if (!(num12 < tol))
					{
						num13 = 2;
						while (true)
						{
							if (num13 <= 30)
							{
								array13[num13 - 1] = array13[num13 - 2] * num10 - array12[num13 - 2] * num11;
								array12[num13 - 1] = array13[num13 - 2] * num11 + array12[num13 - 2] * num10;
								num14 += array13[num13 - 1] * array6[num13 - 1];
								num15 += array12[num13 - 1] * array6[num13 - 1];
								array7[num13 - 1] = array7[num13 - 2] * num12;
								if (array7[num13 - 1] < tol)
								{
									break;
								}
								num13++;
								continue;
							}
							num13 = 30;
							break;
						}
					}
					int num16 = num13;
					double num17 = num10 * num14 - num11 * num15;
					double num18 = num10 * num15 + num11 * num14;
					argr = num17 * num8;
					argi = num18 * num8;
					zsqrt(num14, num15, ref cr2, ref ci2);
					zsqrt(num10, num11, ref br, ref bi);
					zeta2r = br * fnu;
					zeta2i = bi * fnu;
					br = 1.0 + 2.0 / 3.0 * (num17 * cr2 - num18 * ci2);
					bi = 0.0 + 2.0 / 3.0 * (num17 * ci2 + num18 * cr2);
					zeta1r = br * zeta2r - bi * zeta2i;
					zeta1i = br * zeta2i + bi * zeta2r;
					cr2 += cr2;
					ci2 += ci2;
					zsqrt(cr2, ci2, ref br, ref bi);
					phir = br * num9;
					phii = bi * num9;
					if (ipmtr != 1)
					{
						double num19 = 0.0;
						double num20 = 0.0;
						for (num13 = 1; num13 <= num16; num13++)
						{
							num19 += array13[num13 - 1] * array5[num13 - 1];
							num20 += array12[num13 - 1] * array5[num13 - 1];
						}
						asumr = 0.0;
						asumi = 0.0;
						bsumr = num19;
						bsumi = num20;
						int num21 = 0;
						int num22 = 30;
						double num23 = tol * (Math.Abs(bsumr) + Math.Abs(bsumi));
						double num24 = tol;
						double num25 = 1.0;
						int num26 = 0;
						int num27 = 0;
						if (!(num6 < tol))
						{
							for (int i = 2; i <= 7; i++)
							{
								num24 /= num6;
								num25 *= num6;
								if (num26 != 1)
								{
									num14 = 0.0;
									num15 = 0.0;
									for (num13 = 1; num13 <= num16; num13++)
									{
										int num28 = num21 + num13;
										num14 += array13[num13 - 1] * array4[num28 - 1];
										num15 += array12[num13 - 1] * array4[num28 - 1];
										if (array7[num13 - 1] < num24)
										{
											break;
										}
									}
									asumr += num14 * num25;
									asumi += num15 * num25;
									if (num25 < tol)
									{
										num26 = 1;
									}
								}
								if (num27 != 1)
								{
									num19 = 0.0;
									num20 = 0.0;
									for (num13 = 1; num13 <= num16; num13++)
									{
										int num28 = num22 + num13;
										num19 += array13[num13 - 1] * array5[num28 - 1];
										num20 += array12[num13 - 1] * array5[num28 - 1];
										if (array7[num13 - 1] < num24)
										{
											break;
										}
									}
									bsumr += num19 * num25;
									bsumi += num20 * num25;
									if (num25 < num23)
									{
										num27 = 1;
									}
								}
								if (num26 == 1 && num27 == 1)
								{
									break;
								}
								num21 += 30;
								num22 += 30;
							}
						}
						asumr += 1.0;
						num25 = num * num9;
						bsumr *= num25;
						bsumi *= num25;
					}
				}
				else
				{
					zsqrt(num10, num11, ref br2, ref bi2);
					if (br2 < 0.0)
					{
						br2 = 0.0;
					}
					if (bi2 < 0.0)
					{
						bi2 = 0.0;
					}
					br = 1.0 + br2;
					bi = bi2;
					zdiv(br, bi, num4, num5, ref cr2, ref ci2);
					zlog(cr2, ci2, ref br3, ref bi3, ref ierr);
					if (bi3 < 0.0)
					{
						bi3 = 0.0;
					}
					if (bi3 > Math.PI / 2.0)
					{
						bi3 = Math.PI / 2.0;
					}
					if (br3 < 0.0)
					{
						br3 = 0.0;
					}
					double num29 = (br3 - br2) * 1.5;
					double num30 = (bi3 - bi2) * 1.5;
					zeta1r = br3 * fnu;
					zeta1i = bi3 * fnu;
					zeta2r = br2 * fnu;
					zeta2i = bi2 * fnu;
					double num31 = zabs(num29, num30);
					double num32 = 4.71238898038469;
					if (!(num29 >= 0.0) || !(num30 < 0.0))
					{
						num32 = Math.PI / 2.0;
						if (num29 != 0.0)
						{
							num32 = Math.Atan(num30 / num29);
							if (num29 < 0.0)
							{
								num32 += Math.PI;
							}
						}
					}
					double num25 = Math.Pow(num31, 2.0 / 3.0);
					num32 *= 2.0 / 3.0;
					double num17 = num25 * Math.Cos(num32);
					double num18 = num25 * Math.Sin(num32);
					if (num18 < 0.0)
					{
						num18 = 0.0;
					}
					argr = num17 * num8;
					argi = num18 * num8;
					zdiv(num29, num30, num17, num18, ref cr, ref ci);
					zdiv(cr, ci, br2, bi2, ref cr2, ref ci2);
					double ar = cr2 + cr2;
					double ai = ci2 + ci2;
					zsqrt(ar, ai, ref br, ref bi);
					phir = br * num9;
					phii = bi * num9;
					if (ipmtr != 1)
					{
						double num33 = 1.0 / Math.Sqrt(num12);
						br = br2 * num33;
						bi = (0.0 - bi2) * num33;
						double num34 = br * num * num33;
						double num35 = bi * num * num33;
						double num36 = 1.0 / num31;
						br = num29 * num36;
						bi = (0.0 - num30) * num36;
						double num37 = br * num36 * num;
						double num38 = bi * num36 * num;
						br3 = num37 * array[1];
						bi3 = num38 * array[1];
						double num39 = 1.0 / num12;
						br = num10 * num39;
						bi = (0.0 - num11) * num39;
						double num40 = br * num39;
						double num41 = bi * num39;
						br = num40 * array3[1] + array3[2];
						bi = num41 * array3[1];
						array15[1] = br * num34 - bi * num35;
						array14[1] = br * num35 + bi * num34;
						bsumr = array15[1] + br3;
						bsumi = array14[1] + bi3;
						asumr = 0.0;
						asumi = 0.0;
						if (!(num < tol))
						{
							double num42 = num37;
							double num43 = num38;
							double num44 = num34;
							double num45 = num35;
							array15[0] = 1.0;
							array14[0] = 0.0;
							num25 = 1.0;
							double num23 = tol * (Math.Abs(bsumr) + Math.Abs(bsumi));
							int num46 = 0;
							int num47 = 2;
							int num48 = 3;
							int num26 = 0;
							int num27 = 0;
							for (int j = 2; j <= 12; j += 2)
							{
								int num49 = j + 1;
								for (int num13 = j; num13 <= num49; num13++)
								{
									num46++;
									num47++;
									num48++;
									cr2 = array3[num48 - 1];
									ci2 = 0.0;
									for (int k = 2; k <= num47; k++)
									{
										num48++;
										br = cr2 * num40 - num41 * ci2 + array3[num48 - 1];
										ci2 = cr2 * num41 + ci2 * num40;
										cr2 = br;
									}
									br = num44 * num34 - num45 * num35;
									num45 = num44 * num35 + num45 * num34;
									num44 = br;
									array15[num47 - 1] = num44 * cr2 - num45 * ci2;
									array14[num47 - 1] = num45 * cr2 + num44 * ci2;
									array9[num46 - 1] = num42 * array2[num46];
									array8[num46 - 1] = num43 * array2[num46];
									br = num42 * num37 - num43 * num38;
									num43 = num42 * num38 + num43 * num37;
									num42 = br;
									array11[num46 - 1] = num42 * array[num46 + 1];
									array10[num46 - 1] = num43 * array[num46 + 1];
								}
								num25 *= num6;
								if (num26 != 1)
								{
									double num14 = array15[num49 - 1];
									double num15 = array14[num49 - 1];
									int num50 = num49;
									for (int l = 1; l <= j; l++)
									{
										num50--;
										num14 = num14 + array9[l - 1] * array15[num50 - 1] - array8[l - 1] * array14[num50 - 1];
										num15 = num15 + array9[l - 1] * array14[num50 - 1] + array8[l - 1] * array15[num50 - 1];
									}
									asumr += num14;
									asumi += num15;
									num2 = Math.Abs(num14) + Math.Abs(num15);
									if (num25 < tol && num2 < tol)
									{
										num26 = 1;
									}
								}
								if (num27 != 1)
								{
									double num19 = array15[j + 1] + array15[num49 - 1] * br3 - array14[num49 - 1] * bi3;
									double num20 = array14[j + 1] + array15[num49 - 1] * bi3 + array14[num49 - 1] * br3;
									int num50 = num49;
									for (int l = 1; l <= j; l++)
									{
										num50--;
										num19 = num19 + array11[l - 1] * array15[num50 - 1] - array10[l - 1] * array14[num50 - 1];
										num20 = num20 + array11[l - 1] * array14[num50 - 1] + array10[l - 1] * array15[num50 - 1];
									}
									bsumr += num19;
									bsumi += num20;
									num2 = Math.Abs(num19) + Math.Abs(num20);
									if (num25 < num23 && num2 < num23)
									{
										num27 = 1;
									}
								}
								if (num26 == 1 && num27 == 1)
								{
									break;
								}
							}
						}
						asumr += 1.0;
						br = (0.0 - bsumr) * num9;
						bi = (0.0 - bsumi) * num9;
						zdiv(br, bi, cr, ci, ref bsumr, ref bsumi);
					}
				}
				return 0;
			}

			private static int zuni1(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, ref int nlast, double fnul, double tol, double elim, double alim)
			{
				double phii = 0.0;
				double phir = 0.0;
				double sumi = 0.0;
				double sumr = 0.0;
				double zeta1i = 0.0;
				double zeta1r = 0.0;
				double zeta2i = 0.0;
				double zeta2r = 0.0;
				int num = 0;
				int nuf = 0;
				int nz2 = 0;
				double[] array = new double[3];
				double[] array2 = new double[3];
				double[] array3 = new double[3];
				double[] cwrki = new double[16];
				double[] cwrkr = new double[16];
				double[] array4 = new double[2];
				double[] array5 = new double[2];
				nz = 0;
				int num2 = n;
				nlast = 0;
				double num3 = 1.0 / tol;
				array3[0] = num3;
				array3[1] = 1.0;
				array3[2] = tol;
				array2[0] = tol;
				array2[1] = 1.0;
				array2[2] = num3;
				array[0] = d1mach(1) * 1000.0 / tol;
				double num4 = Math.Max(fnu, 1.0);
				int init = 0;
				zunik(zr, zi, num4, 1, 1, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref cwrkr, ref cwrki);
				double num8;
				if (kode != 1)
				{
					double num5 = zr + zeta2r;
					double num6 = zi + zeta2i;
					double num7 = num4 / zabs(num5, num6);
					num5 = num5 * num7 * num7;
					num6 = (0.0 - num6) * num7 * num7;
					num8 = 0.0 - zeta1r + num5;
					double num9 = 0.0 - zeta1i + num6;
				}
				else
				{
					num8 = 0.0 - zeta1r + zeta2r;
					double num9 = 0.0 - zeta1i + zeta2i;
				}
				double num10 = num8;
				if (!(Math.Abs(num10) > elim))
				{
					while (true)
					{
						int num11 = Math.Min(2, num2);
						int num14;
						double num12;
						double num13;
						for (int i = 1; i <= num11; array5[i - 1] = num12, array4[i - 1] = num13, num14 = num2 - i + 1, yr[num14 - 1] = num12 * array2[num - 1], yi[num14 - 1] = num13 * array2[num - 1], i++)
						{
							num4 = fnu + (double)(num2 - i);
							init = 0;
							zunik(zr, zi, num4, 1, 0, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref cwrkr, ref cwrki);
							double num9;
							if (kode != 1)
							{
								double num5 = zr + zeta2r;
								double num6 = zi + zeta2i;
								double num7 = num4 / zabs(num5, num6);
								num5 = num5 * num7 * num7;
								num6 = (0.0 - num6) * num7 * num7;
								num8 = 0.0 - zeta1r + num5;
								num9 = 0.0 - zeta1i + num6 + zi;
							}
							else
							{
								num8 = 0.0 - zeta1r + zeta2r;
								num9 = 0.0 - zeta1i + zeta2i;
							}
							num10 = num8;
							if (!(Math.Abs(num10) > elim))
							{
								if (i == 1)
								{
									num = 2;
								}
								if (!(Math.Abs(num10) < alim))
								{
									double d = zabs(phir, phii);
									num10 += Math.Log(d);
									if (Math.Abs(num10) > elim)
									{
										goto IL_04f8;
									}
									if (i == 1)
									{
										num = 1;
									}
									if (!(num10 < 0.0) && i == 1)
									{
										num = 3;
									}
								}
								num12 = phir * sumr - phii * sumi;
								num13 = phir * sumi + phii * sumr;
								double num5 = Math.Exp(num8) * array3[num - 1];
								num8 = num5 * Math.Cos(num9);
								num9 = num5 * Math.Sin(num9);
								num5 = num12 * num8 - num13 * num9;
								num13 = num12 * num9 + num13 * num8;
								num12 = num5;
								if (num != 1)
								{
									continue;
								}
								zuchk(num12, num13, ref nz2, array[0], tol);
								if (nz2 == 0)
								{
									continue;
								}
							}
							goto IL_04f8;
						}
						if (num2 > 2)
						{
							double num7 = 1.0 / zabs(zr, zi);
							double num5 = zr * num7;
							double num6 = (0.0 - zi) * num7;
							double num15 = (num5 + num5) * num7;
							double num16 = (num6 + num6) * num7;
							array[1] = 1.0 / array[0];
							array[2] = d1mach(2);
							num8 = array5[0];
							double num9 = array4[0];
							num12 = array5[1];
							num13 = array4[1];
							double num17 = array2[num - 1];
							double num18 = array[num - 1];
							int num19 = num2 - 2;
							num4 = num19;
							for (int i = 3; i <= num2; i++)
							{
								double num20 = num12;
								double num21 = num13;
								num12 = num8 + (fnu + num4) * (num15 * num20 - num16 * num21);
								num13 = num9 + (fnu + num4) * (num15 * num21 + num16 * num20);
								num8 = num20;
								num9 = num21;
								num20 = num12 * num17;
								num21 = num13 * num17;
								yr[num19 - 1] = num20;
								yi[num19 - 1] = num21;
								num19--;
								num4 += -1.0;
								if (num < 3)
								{
									num5 = Math.Abs(num20);
									num6 = Math.Abs(num21);
									if (!(Math.Max(num5, num6) <= num18))
									{
										num++;
										num18 = array[num - 1];
										num8 *= num17;
										num9 *= num17;
										num12 = num20;
										num13 = num21;
										num8 *= array3[num - 1];
										num9 *= array3[num - 1];
										num12 *= array3[num - 1];
										num13 *= array3[num - 1];
										num17 = array2[num - 1];
									}
								}
							}
						}
						goto IL_04f6;
						IL_04f8:
						if (num10 > 0.0)
						{
							break;
						}
						yr[num2 - 1] = 0.0;
						yi[num2 - 1] = 0.0;
						nz++;
						num2--;
						if (num2 != 0)
						{
							zuoik(zr, zi, fnu, kode, 1, num2, yr, yi, ref nuf, tol, elim, alim);
							if (nuf < 0)
							{
								break;
							}
							num2 -= nuf;
							nz += nuf;
							if (num2 != 0)
							{
								num4 = fnu + (double)(num2 - 1);
								if (!(num4 >= fnul))
								{
									nlast = num2;
									return 0;
								}
								continue;
							}
						}
						goto IL_04f6;
						IL_04f6:
						return 0;
					}
				}
				else if (!(num10 > 0.0))
				{
					nz = n;
					for (int i = 1; i <= n; i++)
					{
						yr[i - 1] = 0.0;
						yi[i - 1] = 0.0;
					}
					return 0;
				}
				nz = -1;
				return 0;
			}

			private static int zuni2(double zr, double zi, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, ref int nlast, double fnul, double tol, double elim, double alim)
			{
				double aii = 0.0;
				double air = 0.0;
				double argi = 0.0;
				double argr = 0.0;
				double asumi = 0.0;
				double asumr = 0.0;
				double bsumi = 0.0;
				double bsumr = 0.0;
				double aii2 = 0.0;
				double air2 = 0.0;
				double phii = 0.0;
				double phir = 0.0;
				double zeta1i = 0.0;
				double zeta1r = 0.0;
				double zeta2i = 0.0;
				double zeta2r = 0.0;
				int num = 0;
				int nz2 = 0;
				int nz3 = 0;
				int nuf = 0;
				int nz4 = 0;
				int ierr = 0;
				double[] array = new double[4] { 0.0, 1.0, 0.0, -1.0 };
				double[] array2 = new double[4] { 1.0, 0.0, -1.0, 0.0 };
				double[] array3 = new double[3];
				double[] array4 = new double[3];
				double[] array5 = new double[3];
				double[] array6 = new double[2];
				double[] array7 = new double[2];
				nz = 0;
				int num2 = n;
				nlast = 0;
				double num3 = 1.0 / tol;
				array5[0] = num3;
				array5[1] = 1.0;
				array5[2] = tol;
				array4[0] = tol;
				array4[1] = 1.0;
				array4[2] = num3;
				array3[0] = d1mach(1) * 1000.0 / tol;
				double num4 = zi;
				double zi2 = 0.0 - zr;
				double num5 = zi;
				double num6 = -1.0;
				int num7 = (int)fnu;
				double num8 = Math.PI / 2.0 * (fnu - (double)num7);
				double num9 = Math.Cos(num8);
				double num10 = Math.Sin(num8);
				double num11 = num9;
				double num12 = num10;
				int num13 = num7 + n - 1;
				num13 = num13 % 4 + 1;
				double num14 = num9 * array2[num13 - 1] - num10 * array[num13 - 1];
				num10 = num9 * array[num13 - 1] + num10 * array2[num13 - 1];
				num9 = num14;
				if (!(zi > 0.0))
				{
					num4 = 0.0 - num4;
					num5 = 0.0 - num5;
					num6 = 0.0 - num6;
					num10 = 0.0 - num10;
				}
				double num15 = Math.Max(fnu, 1.0);
				zunhj(num4, zi2, num15, 1, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
				double num18;
				if (kode != 1)
				{
					num14 = zr + zeta2r;
					double num16 = num5 + zeta2i;
					double num17 = num15 / zabs(num14, num16);
					num14 = num14 * num17 * num17;
					num16 = (0.0 - num16) * num17 * num17;
					num18 = 0.0 - zeta1r + num14;
					double num19 = 0.0 - zeta1i + num16;
				}
				else
				{
					num18 = 0.0 - zeta1r + zeta2r;
					double num19 = 0.0 - zeta1i + zeta2i;
				}
				double num20 = num18;
				if (!(Math.Abs(num20) > elim))
				{
					while (true)
					{
						int num21 = Math.Min(2, num2);
						int num22 = 1;
						while (num22 <= num21)
						{
							num15 = fnu + (double)(num2 - num22);
							zunhj(num4, zi2, num15, 0, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
							double num19;
							if (kode != 1)
							{
								num14 = zr + zeta2r;
								double num16 = num5 + zeta2i;
								double num17 = num15 / zabs(num14, num16);
								num14 = num14 * num17 * num17;
								num16 = (0.0 - num16) * num17 * num17;
								num18 = 0.0 - zeta1r + num14;
								num19 = 0.0 - zeta1i + num16 + Math.Abs(zi);
							}
							else
							{
								num18 = 0.0 - zeta1r + zeta2r;
								num19 = 0.0 - zeta1i + zeta2i;
							}
							num20 = num18;
							if (!(Math.Abs(num20) > elim))
							{
								if (num22 == 1)
								{
									num = 2;
								}
								if (!(Math.Abs(num20) < alim))
								{
									double d = zabs(phir, phii);
									double d2 = zabs(argr, argi);
									num20 = num20 + Math.Log(d) - Math.Log(d2) * 0.25 - 1.2655121234846454;
									if (Math.Abs(num20) > elim)
									{
										goto IL_0701;
									}
									if (num22 == 1)
									{
										num = 1;
									}
									if (!(num20 < 0.0) && num22 == 1)
									{
										num = 3;
									}
								}
								zairy(argr, argi, 0, 2, ref air, ref aii, ref nz2, ref ierr);
								zairy(argr, argi, 1, 2, ref air2, ref aii2, ref nz3, ref ierr);
								num14 = air2 * bsumr - aii2 * bsumi;
								double num16 = air2 * bsumi + aii2 * bsumr;
								num14 += air * asumr - aii * asumi;
								num16 += air * asumi + aii * asumr;
								double num23 = phir * num14 - phii * num16;
								double num24 = phir * num16 + phii * num14;
								num14 = Math.Exp(num18) * array5[num - 1];
								num18 = num14 * Math.Cos(num19);
								num19 = num14 * Math.Sin(num19);
								num14 = num23 * num18 - num24 * num19;
								num24 = num23 * num19 + num24 * num18;
								num23 = num14;
								if (num == 1)
								{
									zuchk(num23, num24, ref nz4, array3[0], tol);
									if (nz4 != 0)
									{
										goto IL_0701;
									}
								}
								if (zi <= 0.0)
								{
									num24 = 0.0 - num24;
								}
								num14 = num23 * num9 - num24 * num10;
								num24 = num23 * num10 + num24 * num9;
								num23 = (array7[num22 - 1] = num14);
								array6[num22 - 1] = num24;
								int num25 = num2 - num22 + 1;
								yr[num25 - 1] = num23 * array4[num - 1];
								yi[num25 - 1] = num24 * array4[num - 1];
								num14 = (0.0 - num10) * num6;
								num10 = num9 * num6;
								num9 = num14;
								num22++;
								continue;
							}
							goto IL_0701;
						}
						if (num2 > 2)
						{
							double num26 = 1.0 / zabs(zr, zi);
							num14 = zr * num26;
							double num16 = (0.0 - zi) * num26;
							double num27 = (num14 + num14) * num26;
							double num28 = (num16 + num16) * num26;
							array3[1] = 1.0 / array3[0];
							array3[2] = d1mach(2);
							num18 = array7[0];
							double num19 = array6[0];
							double num23 = array7[1];
							double num24 = array6[1];
							double num29 = array4[num - 1];
							double num30 = array3[num - 1];
							int num31 = num2 - 2;
							num15 = num31;
							for (num22 = 3; num22 <= num2; num22++)
							{
								num9 = num23;
								num10 = num24;
								num23 = num18 + (fnu + num15) * (num27 * num9 - num28 * num10);
								num24 = num19 + (fnu + num15) * (num27 * num10 + num28 * num9);
								num18 = num9;
								num19 = num10;
								num9 = num23 * num29;
								num10 = num24 * num29;
								yr[num31 - 1] = num9;
								yi[num31 - 1] = num10;
								num31--;
								num15 += -1.0;
								if (num < 3)
								{
									num14 = Math.Abs(num9);
									num16 = Math.Abs(num10);
									if (!(Math.Max(num14, num16) <= num30))
									{
										num++;
										num30 = array3[num - 1];
										num18 *= num29;
										num19 *= num29;
										num23 = num9;
										num24 = num10;
										num18 *= array5[num - 1];
										num19 *= array5[num - 1];
										num23 *= array5[num - 1];
										num24 *= array5[num - 1];
										num29 = array4[num - 1];
									}
								}
							}
						}
						goto IL_06ff;
						IL_0701:
						if (num20 > 0.0)
						{
							break;
						}
						yr[num2 - 1] = 0.0;
						yi[num2 - 1] = 0.0;
						nz++;
						num2--;
						if (num2 != 0)
						{
							zuoik(zr, zi, fnu, kode, 1, num2, yr, yi, ref nuf, tol, elim, alim);
							if (nuf < 0)
							{
								break;
							}
							num2 -= nuf;
							nz += nuf;
							if (num2 != 0)
							{
								num15 = fnu + (double)(num2 - 1);
								if (!(num15 < fnul))
								{
									num13 = num7 + num2 - 1;
									num13 = num13 % 4 + 1;
									num9 = num11 * array2[num13 - 1] - num12 * array[num13 - 1];
									num10 = num11 * array[num13 - 1] + num12 * array2[num13 - 1];
									if (zi <= 0.0)
									{
										num10 = 0.0 - num10;
									}
									continue;
								}
								nlast = num2;
								return 0;
							}
						}
						goto IL_06ff;
						IL_06ff:
						return 0;
					}
				}
				else if (!(num20 > 0.0))
				{
					nz = n;
					for (int num22 = 1; num22 <= n; num22++)
					{
						yr[num22 - 1] = 0.0;
						yi[num22 - 1] = 0.0;
					}
					return 0;
				}
				nz = -1;
				return 0;
			}

			private static int zunik(double zrr, double zri, double fnu, int ikflg, int ipmtr, double tol, ref int init, ref double phir, ref double phii, ref double zeta1r, ref double zeta1i, ref double zeta2r, ref double zeta2i, ref double sumr, ref double sumi, ref double[] cwrkr, ref double[] cwrki)
			{
				double[] array = new double[2] { 0.3989422804014327, 1.2533141373155003 };
				double[] array2 = new double[120]
				{
					1.0,
					-5.0 / 24.0,
					0.125,
					0.3342013888888889,
					-77.0 / 192.0,
					9.0 / 128.0,
					-1.0258125964506173,
					1.8464626736111112,
					-0.8912109375,
					0.0732421875,
					4.669584423426247,
					-11.207002616222994,
					8.78912353515625,
					-2.3640869140625,
					0.112152099609375,
					-28.212072558200244,
					84.63621767460073,
					-91.81824154324002,
					42.53499874538846,
					-7.368794359479632,
					0.22710800170898438,
					212.57013003921713,
					-765.2524681411817,
					1059.9904525279999,
					-699.5796273761325,
					218.1905117442116,
					-26.491430486951554,
					0.5725014209747314,
					-1919.457662318407,
					8061.722181737309,
					-13586.550006434138,
					11655.393336864534,
					-5305.646978613403,
					1200.9029132163525,
					-108.09091978839466,
					1.7277275025844574,
					20204.29133096615,
					-96980.59838863752,
					192547.00123253153,
					-203400.17728041555,
					122200.46498301746,
					-41192.65496889755,
					7109.514302489364,
					-493.915304773088,
					6.074042001273483,
					-242919.18790055133,
					1311763.6146629772,
					-2998015.9185381066,
					3763271.297656404,
					-2813563.226586534,
					1268365.2733216248,
					-331645.1724845636,
					45218.76898136273,
					-2499.8304818112097,
					24.380529699556064,
					3284469.853072038,
					-19706819.118432228,
					50952602.49266464,
					-74105148.21153265,
					66344512.27472903,
					-37567176.66076335,
					13288767.166421818,
					-2785618.1280864547,
					308186.4046126624,
					-13886.08975371704,
					110.01714026924674,
					-49329253.66450996,
					325573074.18576574,
					-939462359.6815784,
					1553596899.57058,
					-1621080552.1083372,
					1106842816.8230145,
					-495889784.2750303,
					142062907.7975331,
					-24474062.72573873,
					2243768.1779224495,
					-84005.43360302408,
					551.3358961220206,
					814789096.1183121,
					-5866481492.051847,
					18688207509.295826,
					-34632043388.158775,
					41280185579.753975,
					-33026599749.800724,
					17954213731.1556,
					-6563293792.619285,
					1559279864.8792574,
					-225105661.88941526,
					17395107.553978164,
					-549842.3275722887,
					3038.090510922384,
					-14679261247.695616,
					114498237732.0258,
					-399096175224.4665,
					819218669548.5773,
					-1098375156081.2233,
					1008158106865.3821,
					-645364869245.3765,
					287900649906.1506,
					-87867072178.02327,
					17634730606.83497,
					-2167164983.223795,
					143157876.71888897,
					-3871833.442572613,
					18257.755474293175,
					286464035717.679,
					-2406297900028.504,
					9109341185239.898,
					-20516899410934.438,
					30565125519935.32,
					-31667088584785.16,
					23348364044581.84,
					-12320491305598.287,
					4612725780849.132,
					-1196552880196.1816,
					205914503232.41,
					-21822927757.529224,
					1247009293.5127103,
					-29188388.122220814,
					118838.42625678325
				};
				double bi = 0.0;
				double br = 0.0;
				double num = 0.0;
				double num2 = 0.0;
				double ci = 0.0;
				double cr = 0.0;
				double ci2 = 0.0;
				double cr2 = 0.0;
				int ierr = 0;
				zeta1r = 0.0;
				zeta1i = 0.0;
				double num6;
				double num7;
				double cr3;
				if (init == 0)
				{
					double num3 = 1.0 / fnu;
					double num4 = d1mach(1) * 1000.0;
					double num5 = fnu * num4;
					if (!(Math.Abs(zrr) > num5) && !(Math.Abs(zri) > num5))
					{
						zeta1r = 2.0 * Math.Abs(Math.Log(num4)) + fnu;
						zeta1i = 0.0;
						zeta2r = fnu;
						zeta2i = 0.0;
						phir = 1.0;
						phii = 0.0;
						return 0;
					}
					cr3 = zrr * num3;
					double ci3 = zri * num3;
					num6 = 1.0 + (cr3 * cr3 - ci3 * ci3);
					num7 = 0.0 + (cr3 * ci3 + ci3 * cr3);
					zsqrt(num6, num7, ref br, ref bi);
					num2 = 1.0 + br;
					num = 0.0 + bi;
					zdiv(num2, num, cr3, ci3, ref cr2, ref ci2);
					zlog(cr2, ci2, ref num2, ref num, ref ierr);
					zeta1r = fnu * num2;
					zeta1i = fnu * num;
					zeta2r = fnu * br;
					zeta2i = fnu * bi;
					zdiv(1.0, 0.0, br, bi, ref cr3, ref ci3);
					br = cr3 * num3;
					bi = ci3 * num3;
					zsqrt(br, bi, ref cwrkr[15], ref cwrki[15]);
					phir = cwrkr[15] * array[ikflg - 1];
					phii = cwrki[15] * array[ikflg - 1];
					if (ipmtr != 0)
					{
						return 0;
					}
					zdiv(1.0, 0.0, num6, num7, ref cr, ref ci);
					cwrkr[0] = 1.0;
					cwrki[0] = 0.0;
					double num8 = 1.0;
					double num9 = 0.0;
					num5 = 1.0;
					int num10 = 1;
					int num11 = 2;
					while (true)
					{
						if (num11 <= 15)
						{
							num6 = 0.0;
							num7 = 0.0;
							for (int i = 1; i <= num11; i++)
							{
								num10++;
								num2 = num6 * cr - num7 * ci + array2[num10 - 1];
								num7 = num6 * ci + num7 * cr;
								num6 = num2;
							}
							num2 = num8 * br - num9 * bi;
							num9 = num8 * bi + num9 * br;
							num8 = num2;
							cwrkr[num11 - 1] = num8 * num6 - num9 * num7;
							cwrki[num11 - 1] = num8 * num7 + num9 * num6;
							num5 *= num3;
							num4 = Math.Abs(cwrkr[num11 - 1]) + Math.Abs(cwrki[num11 - 1]);
							if (num5 < tol && num4 < tol)
							{
								break;
							}
							num11++;
							continue;
						}
						num11 = 15;
						break;
					}
					init = num11;
				}
				if (ikflg != 2)
				{
					num6 = 0.0;
					num7 = 0.0;
					for (int j = 1; j <= init; j++)
					{
						num6 += cwrkr[j - 1];
						num7 += cwrki[j - 1];
					}
					sumr = num6;
					sumi = num7;
					phir = cwrkr[15] * array[0];
					phii = cwrki[15] * array[0];
					return 0;
				}
				num6 = 0.0;
				num7 = 0.0;
				cr3 = 1.0;
				for (int j = 1; j <= init; j++)
				{
					num6 += cr3 * cwrkr[j - 1];
					num7 += cr3 * cwrki[j - 1];
					cr3 = 0.0 - cr3;
				}
				sumr = num6;
				sumi = num7;
				phir = cwrkr[15] * array[1];
				phii = cwrki[15] * array[1];
				return 0;
			}

			private static int zunk1(double zr, double zi, double fnu, int kode, int mr, int n, double[] yr, double[] yi, ref int nz, double tol, double elim, double alim)
			{
				double num = 0.0;
				double phii = 0.0;
				double phir = 0.0;
				double sumi = 0.0;
				double sumr = 0.0;
				double zeta1i = 0.0;
				double zeta1r = 0.0;
				double zeta2i = 0.0;
				double zeta2r = 0.0;
				int num2 = 0;
				int init = 0;
				int num3 = 0;
				int nz2 = 0;
				double[] array = new double[3];
				double[] array2 = new double[3];
				double[] array3 = new double[3];
				double[][] array4 = new double[3][]
				{
					new double[16],
					new double[16],
					new double[16]
				};
				double[][] array5 = new double[3][]
				{
					new double[16],
					new double[16],
					new double[16]
				};
				double[] array6 = new double[2];
				double[] array7 = new double[2];
				double[] array8 = new double[2];
				double[] array9 = new double[2];
				double[] array10 = new double[2];
				double[] array11 = new double[2];
				double[] array12 = new double[2];
				double[] array13 = new double[2];
				double[] array14 = new double[2];
				double[] array15 = new double[2];
				int[] array16 = new int[2];
				int num4 = 1;
				nz = 0;
				double num5 = 1.0 / tol;
				array3[0] = num5;
				array3[1] = 1.0;
				array3[2] = tol;
				array2[0] = tol;
				array2[1] = 1.0;
				array2[2] = num5;
				array[0] = 1000.0 * d1mach(1) / tol;
				array[1] = 1.0 / array[0];
				array[2] = d1mach(2);
				double num6 = zr;
				double num7 = zi;
				if (!(zr >= 0.0))
				{
					num6 = 0.0 - zr;
					num7 = 0.0 - zi;
				}
				int num8 = 2;
				int num9 = 1;
				while (true)
				{
					double num15;
					double num11;
					double num10;
					if (num9 <= n)
					{
						num8 = 3 - num8;
						num = fnu + (double)(num9 - 1);
						array16[num8 - 1] = 0;
						zunik(num6, num7, num, 2, 0, tol, ref array16[num8 - 1], ref array9[num8 - 1], ref array8[num8 - 1], ref array14[num8 - 1], ref array12[num8 - 1], ref array15[num8 - 1], ref array13[num8 - 1], ref array11[num8 - 1], ref array10[num8 - 1], ref array5[num8 - 1], ref array4[num8 - 1]);
						double num13;
						double num14;
						if (kode != 1)
						{
							num10 = num6 + array15[num8 - 1];
							num11 = num7 + array13[num8 - 1];
							double num12 = num / zabs(num10, num11);
							num10 = num10 * num12 * num12;
							num11 = (0.0 - num11) * num12 * num12;
							num13 = array14[num8 - 1] - num10;
							num14 = array12[num8 - 1] - num11;
						}
						else
						{
							num13 = array14[num8 - 1] - array15[num8 - 1];
							num14 = array12[num8 - 1] - array13[num8 - 1];
						}
						num15 = num13;
						if (Math.Abs(num15) > elim)
						{
							goto IL_0446;
						}
						if (num4 == 1)
						{
							num3 = 2;
						}
						if (!(Math.Abs(num15) < alim))
						{
							double d = zabs(array9[num8 - 1], array8[num8 - 1]);
							num15 += Math.Log(d);
							if (Math.Abs(num15) > elim)
							{
								goto IL_0446;
							}
							if (num4 == 1)
							{
								num3 = 1;
							}
							if (!(num15 < 0.0) && num4 == 1)
							{
								num3 = 3;
							}
						}
						double num16 = array9[num8 - 1] * array11[num8 - 1] - array8[num8 - 1] * array10[num8 - 1];
						double num17 = array9[num8 - 1] * array10[num8 - 1] + array8[num8 - 1] * array11[num8 - 1];
						num10 = Math.Exp(num13) * array3[num3 - 1];
						num13 = num10 * Math.Cos(num14);
						num14 = num10 * Math.Sin(num14);
						num10 = num16 * num13 - num17 * num14;
						num17 = num13 * num17 + num16 * num14;
						num16 = num10;
						if (num3 == 1)
						{
							zuchk(num16, num17, ref nz2, array[0], tol);
							if (nz2 != 0)
							{
								goto IL_0446;
							}
						}
						array7[num4 - 1] = num16;
						array6[num4 - 1] = num17;
						yr[num9 - 1] = num16 * array2[num3 - 1];
						yi[num9 - 1] = num17 * array2[num3 - 1];
						if (num4 != 2)
						{
							num4 = 2;
							goto IL_04e1;
						}
					}
					else
					{
						num9 = n;
					}
					double num18 = 1.0 / zabs(num6, num7);
					num10 = num6 * num18;
					num11 = (0.0 - num7) * num18;
					double num19 = (num10 + num10) * num18;
					double num20 = (num11 + num11) * num18;
					double num21 = num * num19;
					double num22 = num * num20;
					int num23 = num9 + 1;
					if (n >= num23)
					{
						num = fnu + (double)(n - 1);
						int ipmtr = 1;
						if (mr != 0)
						{
							ipmtr = 0;
						}
						zunik(num6, num7, num, 2, ipmtr, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref array5[2], ref array4[2]);
						double num13;
						double num14;
						if (kode != 1)
						{
							num10 = num6 + zeta2r;
							num11 = num7 + zeta2i;
							double num12 = num / zabs(num10, num11);
							num10 = num10 * num12 * num12;
							num11 = (0.0 - num11) * num12 * num12;
							num13 = zeta1r - num10;
							num14 = zeta1i - num11;
						}
						else
						{
							num13 = zeta1r - zeta2r;
							num14 = zeta1i - zeta2i;
						}
						num15 = num13;
						if (Math.Abs(num15) > elim)
						{
							goto IL_061b;
						}
						if (!(Math.Abs(num15) < alim))
						{
							double d = zabs(phir, phii);
							num15 += Math.Log(d);
							if (!(Math.Abs(num15) < elim))
							{
								goto IL_061b;
							}
						}
						num13 = array7[0];
						num14 = array6[0];
						double num16 = array7[1];
						double num17 = array6[1];
						double num24 = array2[num3 - 1];
						double num25 = array[num3 - 1];
						for (num9 = num23; num9 <= n; num9++)
						{
							double num26 = num16;
							double num27 = num17;
							num16 = num21 * num26 - num22 * num27 + num13;
							num17 = num21 * num27 + num22 * num26 + num14;
							num13 = num26;
							num14 = num27;
							num21 += num19;
							num22 += num20;
							num26 = num16 * num24;
							num27 = num17 * num24;
							yr[num9 - 1] = num26;
							yi[num9 - 1] = num27;
							if (num3 < 3)
							{
								num10 = Math.Abs(num26);
								num11 = Math.Abs(num27);
								if (!(Math.Max(num10, num11) <= num25))
								{
									num3++;
									num25 = array[num3 - 1];
									num13 *= num24;
									num14 *= num24;
									num16 = num26;
									num17 = num27;
									num13 *= array3[num3 - 1];
									num14 *= array3[num3 - 1];
									num16 *= array3[num3 - 1];
									num17 *= array3[num3 - 1];
									num24 = array2[num3 - 1];
								}
							}
						}
					}
					if (mr == 0)
					{
						return 0;
					}
					nz = 0;
					double b = mr;
					double num28 = 0.0 - dsign(Math.PI, b);
					double num29 = num28;
					int num30 = (int)fnu;
					double num31 = fnu - (double)num30;
					int num32 = num30 + n - 1;
					double num33 = num31 * num28;
					double num34 = Math.Cos(num33);
					double num35 = Math.Sin(num33);
					if (num32 % 2 != 0)
					{
						num34 = 0.0 - num34;
						num35 = 0.0 - num35;
					}
					double ascle = array[0];
					int iuf = 0;
					int num36 = n;
					num4 = 1;
					num23--;
					int num37 = num23 - 1;
					int num38 = 1;
					while (true)
					{
						int num39;
						if (num38 <= n)
						{
							num = fnu + (double)(num36 - 1);
							num39 = 3;
							if (n <= 2)
							{
								goto IL_0820;
							}
							if (num36 != n || num23 >= n)
							{
								if (num36 == num23 || num36 == num37)
								{
									goto IL_0820;
								}
								init = 0;
							}
							goto IL_0898;
						}
						num38 = n;
						goto IL_0b38;
						IL_0afa:
						if (num15 > 0.0)
						{
							break;
						}
						double num16 = 0.0;
						double num17 = 0.0;
						goto IL_0a2d;
						IL_0820:
						init = array16[num8 - 1];
						phir = array9[num8 - 1];
						phii = array8[num8 - 1];
						zeta1r = array14[num8 - 1];
						zeta1i = array12[num8 - 1];
						zeta2r = array15[num8 - 1];
						zeta2i = array13[num8 - 1];
						sumr = array11[num8 - 1];
						sumi = array10[num8 - 1];
						num39 = num8;
						num8 = 3 - num8;
						goto IL_0898;
						IL_0898:
						zunik(num6, num7, num, 1, 0, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref array5[num39 - 1], ref array4[num39 - 1]);
						double num13;
						double num14;
						if (kode != 1)
						{
							num10 = num6 + zeta2r;
							num11 = num7 + zeta2i;
							double num12 = num / zabs(num10, num11);
							num10 = num10 * num12 * num12;
							num11 = (0.0 - num11) * num12 * num12;
							num13 = 0.0 - zeta1r + num10;
							num14 = 0.0 - zeta1i + num11;
						}
						else
						{
							num13 = 0.0 - zeta1r + zeta2r;
							num14 = 0.0 - zeta1i + zeta2i;
						}
						num15 = num13;
						if (!(Math.Abs(num15) > elim))
						{
							if (num4 == 1)
							{
								num2 = 2;
							}
							if (!(Math.Abs(num15) < alim))
							{
								double d = zabs(phir, phii);
								num15 += Math.Log(d);
								if (Math.Abs(num15) > elim)
								{
									goto IL_0afa;
								}
								if (num4 == 1)
								{
									num2 = 1;
								}
								if (!(num15 < 0.0) && num4 == 1)
								{
									num2 = 3;
								}
							}
							num10 = phir * sumr - phii * sumi;
							num11 = phir * sumi + phii * sumr;
							num16 = (0.0 - num29) * num11;
							num17 = num29 * num10;
							num10 = Math.Exp(num13) * array3[num2 - 1];
							num13 = num10 * Math.Cos(num14);
							num14 = num10 * Math.Sin(num14);
							num10 = num16 * num13 - num17 * num14;
							num17 = num16 * num14 + num17 * num13;
							num16 = num10;
							if (num2 == 1)
							{
								zuchk(num16, num17, ref nz2, array[0], tol);
								if (nz2 != 0)
								{
									num16 = 0.0;
									num17 = 0.0;
								}
							}
							goto IL_0a2d;
						}
						goto IL_0afa;
						IL_0b38:
						int num40 = n - num38;
						if (num40 == 0)
						{
							return 0;
						}
						num13 = array7[0];
						num14 = array6[0];
						num16 = array7[1];
						num17 = array6[1];
						double num41 = array2[num2 - 1];
						double num25 = array[num2 - 1];
						num = num30 + num40;
						double num26;
						double num27;
						for (num9 = 1; num9 <= num40; num9++)
						{
							num26 = num16;
							num27 = num17;
							num16 = num13 + (num + num31) * (num19 * num26 - num20 * num27);
							num17 = num14 + (num + num31) * (num19 * num27 + num20 * num26);
							num13 = num26;
							num14 = num27;
							num -= 1.0;
							num26 = num16 * num41;
							num27 = num17 * num41;
							num21 = num26;
							num22 = num27;
							double num24 = yr[num36 - 1];
							double s1i = yi[num36 - 1];
							if (kode != 1)
							{
								zs1s2(num6, num7, ref num24, ref s1i, ref num26, ref num27, ref nz2, ascle, alim, ref iuf);
								nz += nz2;
							}
							yr[num36 - 1] = num24 * num34 - s1i * num35 + num26;
							yi[num36 - 1] = num24 * num35 + s1i * num34 + num27;
							num36--;
							num34 = 0.0 - num34;
							num35 = 0.0 - num35;
							if (num2 < 3)
							{
								num26 = Math.Abs(num21);
								num27 = Math.Abs(num22);
								if (!(Math.Max(num26, num27) <= num25))
								{
									num2++;
									num25 = array[num2 - 1];
									num13 *= num41;
									num14 *= num41;
									num16 = num21;
									num17 = num22;
									num13 *= array3[num2 - 1];
									num14 *= array3[num2 - 1];
									num16 *= array3[num2 - 1];
									num17 *= array3[num2 - 1];
									num41 = array2[num2 - 1];
								}
							}
						}
						return 0;
						IL_0b25:
						num38++;
						continue;
						IL_0a2d:
						array7[num4 - 1] = num16;
						array6[num4 - 1] = num17;
						num26 = num16;
						num27 = num17;
						num16 *= array2[num2 - 1];
						num17 *= array2[num2 - 1];
						num13 = yr[num36 - 1];
						num14 = yi[num36 - 1];
						if (kode != 1)
						{
							zs1s2(num6, num7, ref num13, ref num14, ref num16, ref num17, ref nz2, ascle, alim, ref iuf);
							nz += nz2;
						}
						yr[num36 - 1] = num13 * num34 - num14 * num35 + num16;
						yi[num36 - 1] = num34 * num14 + num35 * num13 + num17;
						num36--;
						num34 = 0.0 - num34;
						num35 = 0.0 - num35;
						if (num26 == 0.0 && num27 == 0.0)
						{
							num4 = 1;
							goto IL_0b25;
						}
						if (num4 != 2)
						{
							num4 = 2;
							goto IL_0b25;
						}
						goto IL_0b38;
					}
					break;
					IL_04e1:
					num9++;
					continue;
					IL_061b:
					if (Math.Abs(num15) > 0.0 || zr < 0.0)
					{
						break;
					}
					nz = n;
					for (num9 = 1; num9 <= n; num9++)
					{
						yr[num9 - 1] = 0.0;
						yi[num9 - 1] = 0.0;
					}
					return 0;
					IL_0446:
					if (num15 > 0.0 || zr < 0.0)
					{
						break;
					}
					num4 = 1;
					yr[num9 - 1] = 0.0;
					yi[num9 - 1] = 0.0;
					nz++;
					if (num9 != 1 && (yr[num9 - 2] != 0.0 || yi[num9 - 2] != 0.0))
					{
						yr[num9 - 2] = 0.0;
						yi[num9 - 2] = 0.0;
						nz++;
					}
					goto IL_04e1;
				}
				nz = -1;
				return 0;
			}

			private static int zunk2(double zr, double zi, double fnu, int kode, int mr, int n, double[] yr, double[] yi, ref int nz, double tol, double elim, double alim)
			{
				double aii = 0.0;
				double air = 0.0;
				double argi = 0.0;
				double argr = 0.0;
				double asumi = 0.0;
				double asumr = 0.0;
				double bsumi = 0.0;
				double bsumr = 0.0;
				double aii2 = 0.0;
				double air2 = 0.0;
				double num = 0.0;
				double phii = 0.0;
				double phir = 0.0;
				double zeta1i = 0.0;
				double zeta1r = 0.0;
				double zeta2i = 0.0;
				double zeta2r = 0.0;
				int num2 = 0;
				int num3 = 0;
				int nz2 = 0;
				int nz3 = 0;
				int nz4 = 0;
				int ierr = 0;
				double[] array = new double[2];
				double[] array2 = new double[2];
				double[] array3 = new double[2];
				double[] array4 = new double[2];
				double[] array5 = new double[2];
				double[] array6 = new double[2];
				double[] array7 = new double[3];
				double[] array8 = new double[4] { 0.0, -1.0, 0.0, 1.0 };
				double[] array9 = new double[4] { 1.0, 0.0, -1.0, 0.0 };
				double[] array10 = new double[3];
				double[] array11 = new double[3];
				double[] array12 = new double[2];
				double[] array13 = new double[2];
				double[] array14 = new double[2];
				double[] array15 = new double[2];
				double[] array16 = new double[2];
				double[] array17 = new double[2];
				double[] array18 = new double[2];
				double[] array19 = new double[2];
				int num4 = 1;
				nz = 0;
				double num5 = 1.0 / tol;
				array11[0] = num5;
				array11[1] = 1.0;
				array11[2] = tol;
				array10[0] = tol;
				array10[1] = 1.0;
				array10[2] = num5;
				array7[0] = d1mach(1) * 1000.0 / tol;
				array7[1] = 1.0 / array7[0];
				array7[2] = d1mach(2);
				double num6 = zr;
				double num7 = zi;
				if (!(zr >= 0.0))
				{
					num6 = 0.0 - zr;
					num7 = 0.0 - zi;
				}
				double num8 = num7;
				double num9 = num7;
				double zi2 = 0.0 - num6;
				double num10 = num6;
				double num11 = num7;
				int num12 = (int)fnu;
				double num13 = fnu - (double)num12;
				double num14 = -Math.PI / 2.0 * num13;
				double num15 = Math.Cos(num14);
				double num16 = Math.Sin(num14);
				double num17 = Math.PI / 2.0 * num16;
				double num18 = -Math.PI / 2.0 * num15;
				int num19 = num12 % 4 + 1;
				double num20 = num17 * array9[num19 - 1] - num18 * array8[num19 - 1];
				double num21 = num17 * array8[num19 - 1] + num18 * array9[num19 - 1];
				double num22 = 1.0 * num20 - 1.7320508075688772 * num21;
				double num23 = 1.0 * num21 + 1.7320508075688772 * num20;
				if (!(num8 > 0.0))
				{
					num9 = 0.0 - num9;
					num11 = 0.0 - num11;
				}
				int num24 = 2;
				int num25 = 1;
				while (true)
				{
					double num29;
					if (num25 <= n)
					{
						num24 = 3 - num24;
						num = fnu + (double)(num25 - 1);
						zunhj(num9, zi2, num, 0, tol, ref array15[num24 - 1], ref array14[num24 - 1], ref array2[num24 - 1], ref array[num24 - 1], ref array18[num24 - 1], ref array16[num24 - 1], ref array19[num24 - 1], ref array17[num24 - 1], ref array4[num24 - 1], ref array3[num24 - 1], ref array6[num24 - 1], ref array5[num24 - 1]);
						double num27;
						double num28;
						if (kode != 1)
						{
							num20 = num10 + array19[num24 - 1];
							num21 = num11 + array17[num24 - 1];
							double num26 = num / zabs(num20, num21);
							num20 = num20 * num26 * num26;
							num21 = (0.0 - num21) * num26 * num26;
							num27 = array18[num24 - 1] - num20;
							num28 = array16[num24 - 1] - num21;
						}
						else
						{
							num27 = array18[num24 - 1] - array19[num24 - 1];
							num28 = array16[num24 - 1] - array17[num24 - 1];
						}
						num29 = num27;
						if (Math.Abs(num29) > elim)
						{
							goto IL_06d5;
						}
						if (num4 == 1)
						{
							num3 = 2;
						}
						if (!(Math.Abs(num29) < alim))
						{
							double d = zabs(array15[num24 - 1], array14[num24 - 1]);
							double d2 = zabs(array2[num24 - 1], array[num24 - 1]);
							num29 = num29 + Math.Log(d) - Math.Log(d2) * 0.25 - 1.2655121234846454;
							if (Math.Abs(num29) > elim)
							{
								goto IL_06d5;
							}
							if (num4 == 1)
							{
								num3 = 1;
							}
							if (!(num29 < 0.0) && num4 == 1)
							{
								num3 = 3;
							}
						}
						num17 = array2[num24 - 1] * -0.5 - array[num24 - 1] * -0.8660254037844386;
						num18 = array2[num24 - 1] * -0.8660254037844386 + array[num24 - 1] * -0.5;
						zairy(num17, num18, 0, 2, ref air, ref aii, ref nz2, ref ierr);
						zairy(num17, num18, 1, 2, ref air2, ref aii2, ref nz3, ref ierr);
						num20 = air2 * array6[num24 - 1] - aii2 * array5[num24 - 1];
						num21 = air2 * array5[num24 - 1] + aii2 * array6[num24 - 1];
						double num30 = num20 * -0.5 - num21 * -0.8660254037844386;
						double num31 = num20 * -0.8660254037844386 + num21 * -0.5;
						num20 = num30 + (air * array4[num24 - 1] - aii * array3[num24 - 1]);
						num21 = num31 + (air * array3[num24 - 1] + aii * array4[num24 - 1]);
						double num32 = num20 * array15[num24 - 1] - num21 * array14[num24 - 1];
						num31 = num20 * array14[num24 - 1] + num21 * array15[num24 - 1];
						double num33 = num32 * num22 - num31 * num23;
						double num34 = num32 * num23 + num31 * num22;
						num20 = Math.Exp(num27) * array11[num3 - 1];
						num27 = num20 * Math.Cos(num28);
						num28 = num20 * Math.Sin(num28);
						num20 = num33 * num27 - num34 * num28;
						num34 = num27 * num34 + num33 * num28;
						num33 = num20;
						if (num3 == 1)
						{
							zuchk(num33, num34, ref nz4, array7[0], tol);
							if (nz4 != 0)
							{
								goto IL_06d5;
							}
						}
						if (num8 <= 0.0)
						{
							num34 = 0.0 - num34;
						}
						array13[num4 - 1] = num33;
						array12[num4 - 1] = num34;
						yr[num25 - 1] = num33 * array10[num3 - 1];
						yi[num25 - 1] = num34 * array10[num3 - 1];
						num20 = num23;
						num23 = 0.0 - num22;
						num22 = num20;
						if (num4 != 2)
						{
							num4 = 2;
							goto IL_077d;
						}
					}
					else
					{
						num25 = n;
					}
					double num35 = 1.0 / zabs(num6, num7);
					num20 = num6 * num35;
					num21 = (0.0 - num7) * num35;
					double num36 = (num20 + num20) * num35;
					double num37 = (num21 + num21) * num35;
					double num38 = num * num36;
					double num39 = num * num37;
					int num40 = num25 + 1;
					if (n >= num40)
					{
						num = fnu + (double)(n - 1);
						int ipmtr = 1;
						if (mr != 0)
						{
							ipmtr = 0;
						}
						zunhj(num9, zi2, num, ipmtr, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
						double num27;
						double num28;
						if (kode != 1)
						{
							num20 = num10 + zeta2r;
							num21 = num11 + zeta2i;
							double num26 = num / zabs(num20, num21);
							num20 = num20 * num26 * num26;
							num21 = (0.0 - num21) * num26 * num26;
							num27 = zeta1r - num20;
							num28 = zeta1i - num21;
						}
						else
						{
							num27 = zeta1r - zeta2r;
							num28 = zeta1i - zeta2i;
						}
						num29 = num27;
						if (Math.Abs(num29) > elim)
						{
							goto IL_08ad;
						}
						if (!(Math.Abs(num29) < alim))
						{
							double d = zabs(phir, phii);
							num29 += Math.Log(d);
							if (!(Math.Abs(num29) < elim))
							{
								goto IL_08ad;
							}
						}
						num27 = array13[0];
						num28 = array12[0];
						double num33 = array13[1];
						double num34 = array12[1];
						double num41 = array10[num3 - 1];
						double num42 = array7[num3 - 1];
						for (num25 = num40; num25 <= n; num25++)
						{
							num17 = num33;
							num18 = num34;
							num33 = num38 * num17 - num39 * num18 + num27;
							num34 = num38 * num18 + num39 * num17 + num28;
							num27 = num17;
							num28 = num18;
							num38 += num36;
							num39 += num37;
							num17 = num33 * num41;
							num18 = num34 * num41;
							yr[num25 - 1] = num17;
							yi[num25 - 1] = num18;
							if (num3 < 3)
							{
								num20 = Math.Abs(num17);
								num21 = Math.Abs(num18);
								if (!(Math.Max(num20, num21) <= num42))
								{
									num3++;
									num42 = array7[num3 - 1];
									num27 *= num41;
									num28 *= num41;
									num33 = num17;
									num34 = num18;
									num27 *= array11[num3 - 1];
									num28 *= array11[num3 - 1];
									num33 *= array11[num3 - 1];
									num34 *= array11[num3 - 1];
									num41 = array10[num3 - 1];
								}
							}
						}
					}
					if (mr == 0)
					{
						return 0;
					}
					nz = 0;
					double b = mr;
					double num43 = 0.0 - dsign(Math.PI, b);
					double num44 = num43;
					if (num8 <= 0.0)
					{
						num44 = 0.0 - num44;
					}
					int num45 = num12 + n - 1;
					double num46 = num13 * num43;
					double num47 = Math.Cos(num46);
					double num48 = Math.Sin(num46);
					if (num45 % 2 != 0)
					{
						num47 = 0.0 - num47;
						num48 = 0.0 - num48;
					}
					num22 = num16 * num44;
					num23 = num15 * num44;
					int num49 = num45 % 4 + 1;
					num17 = array9[num49 - 1];
					num18 = array8[num49 - 1];
					num20 = num22 * num17 + num23 * num18;
					num23 = (0.0 - num22) * num18 + num23 * num17;
					num22 = num20;
					double ascle = array7[0];
					int iuf = 0;
					num19 = n;
					num4 = 1;
					num40--;
					int num50 = num40 - 1;
					int num51 = 1;
					while (true)
					{
						if (num51 <= n)
						{
							num = fnu + (double)(num19 - 1);
							if (n <= 2)
							{
								goto IL_0aff;
							}
							if (num19 != n || num40 >= n)
							{
								if (num19 == num40 || num19 == num50)
								{
									goto IL_0aff;
								}
								zunhj(num9, zi2, num, 0, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
							}
							goto IL_0bb8;
						}
						num51 = n;
						goto IL_0ec9;
						IL_0e8b:
						if (num29 > 0.0)
						{
							break;
						}
						double num33 = 0.0;
						double num34 = 0.0;
						goto IL_0d9e;
						IL_0aff:
						phir = array15[num24 - 1];
						phii = array14[num24 - 1];
						argr = array2[num24 - 1];
						argi = array[num24 - 1];
						zeta1r = array18[num24 - 1];
						zeta1i = array16[num24 - 1];
						zeta2r = array19[num24 - 1];
						zeta2i = array17[num24 - 1];
						asumr = array4[num24 - 1];
						asumi = array3[num24 - 1];
						bsumr = array6[num24 - 1];
						bsumi = array5[num24 - 1];
						num24 = 3 - num24;
						goto IL_0bb8;
						IL_0bb8:
						double num27;
						double num28;
						if (kode != 1)
						{
							num20 = num10 + zeta2r;
							num21 = num11 + zeta2i;
							double num26 = num / zabs(num20, num21);
							num20 = num20 * num26 * num26;
							num21 = (0.0 - num21) * num26 * num26;
							num27 = 0.0 - zeta1r + num20;
							num28 = 0.0 - zeta1i + num21;
						}
						else
						{
							num27 = 0.0 - zeta1r + zeta2r;
							num28 = 0.0 - zeta1i + zeta2i;
						}
						num29 = num27;
						if (!(Math.Abs(num29) > elim))
						{
							if (num4 == 1)
							{
								num2 = 2;
							}
							if (!(Math.Abs(num29) < alim))
							{
								double d = zabs(phir, phii);
								double d2 = zabs(argr, argi);
								num29 = num29 + Math.Log(d) - 0.25 * Math.Log(d2) - 1.2655121234846454;
								if (Math.Abs(num29) > elim)
								{
									goto IL_0e8b;
								}
								if (num4 == 1)
								{
									num2 = 1;
								}
								if (!(num29 < 0.0) && num4 == 1)
								{
									num2 = 3;
								}
							}
							zairy(argr, argi, 0, 2, ref air, ref aii, ref nz2, ref ierr);
							zairy(argr, argi, 1, 2, ref air2, ref aii2, ref nz3, ref ierr);
							num20 = air2 * bsumr - aii2 * bsumi;
							num21 = air2 * bsumi + aii2 * bsumr;
							num20 += air * asumr - aii * asumi;
							num21 += air * asumi + aii * asumr;
							double num52 = num20 * phir - num21 * phii;
							double num31 = num20 * phii + num21 * phir;
							num33 = num52 * num22 - num31 * num23;
							num34 = num52 * num23 + num31 * num22;
							num20 = Math.Exp(num27) * array11[num2 - 1];
							num27 = num20 * Math.Cos(num28);
							num28 = num20 * Math.Sin(num28);
							num20 = num33 * num27 - num34 * num28;
							num34 = num33 * num28 + num34 * num27;
							num33 = num20;
							if (num2 == 1)
							{
								zuchk(num33, num34, ref nz4, array7[0], tol);
								if (nz4 != 0)
								{
									num33 = 0.0;
									num34 = 0.0;
								}
							}
							goto IL_0d9e;
						}
						goto IL_0e8b;
						IL_0eb6:
						num51++;
						continue;
						IL_0ec9:
						int num53 = n - num51;
						if (num53 == 0)
						{
							return 0;
						}
						num27 = array13[0];
						num28 = array12[0];
						num33 = array13[1];
						num34 = array12[1];
						num22 = array10[num2 - 1];
						double num42 = array7[num2 - 1];
						num = num12 + num53;
						for (num25 = 1; num25 <= num53; num25++)
						{
							num17 = num33;
							num18 = num34;
							num33 = num27 + (num + num13) * (num36 * num17 - num37 * num18);
							num34 = num28 + (num + num13) * (num36 * num18 + num37 * num17);
							num27 = num17;
							num28 = num18;
							num -= 1.0;
							num17 = num33 * num22;
							num18 = num34 * num22;
							num38 = num17;
							num39 = num18;
							double num41 = yr[num19 - 1];
							double s1i = yi[num19 - 1];
							if (kode != 1)
							{
								zs1s2(num6, num7, ref num41, ref s1i, ref num17, ref num18, ref nz4, ascle, alim, ref iuf);
								nz += nz4;
							}
							yr[num19 - 1] = num41 * num47 - s1i * num48 + num17;
							yi[num19 - 1] = num41 * num48 + s1i * num47 + num18;
							num19--;
							num47 = 0.0 - num47;
							num48 = 0.0 - num48;
							if (num2 < 3)
							{
								num17 = Math.Abs(num38);
								num18 = Math.Abs(num39);
								if (!(Math.Max(num17, num18) <= num42))
								{
									num2++;
									num42 = array7[num2 - 1];
									num27 *= num22;
									num28 *= num22;
									num33 = num38;
									num34 = num39;
									num27 *= array11[num2 - 1];
									num28 *= array11[num2 - 1];
									num33 *= array11[num2 - 1];
									num34 *= array11[num2 - 1];
									num22 = array10[num2 - 1];
								}
							}
						}
						return 0;
						IL_0d9e:
						if (num8 <= 0.0)
						{
							num34 = 0.0 - num34;
						}
						array13[num4 - 1] = num33;
						array12[num4 - 1] = num34;
						num17 = num33;
						num18 = num34;
						num33 *= array10[num2 - 1];
						num34 *= array10[num2 - 1];
						num27 = yr[num19 - 1];
						num28 = yi[num19 - 1];
						if (kode != 1)
						{
							zs1s2(num6, num7, ref num27, ref num28, ref num33, ref num34, ref nz4, ascle, alim, ref iuf);
							nz += nz4;
						}
						yr[num19 - 1] = num27 * num47 - num28 * num48 + num33;
						yi[num19 - 1] = num27 * num48 + num28 * num47 + num34;
						num19--;
						num47 = 0.0 - num47;
						num48 = 0.0 - num48;
						num20 = num23;
						num23 = 0.0 - num22;
						num22 = num20;
						if (num17 == 0.0 && num18 == 0.0)
						{
							num4 = 1;
							goto IL_0eb6;
						}
						if (num4 != 2)
						{
							num4 = 2;
							goto IL_0eb6;
						}
						goto IL_0ec9;
					}
					break;
					IL_06d5:
					if (num29 > 0.0 || zr < 0.0)
					{
						break;
					}
					num4 = 1;
					yr[num25 - 1] = 0.0;
					yi[num25 - 1] = 0.0;
					nz++;
					num20 = num23;
					num23 = 0.0 - num22;
					num22 = num20;
					if (num25 != 1 && (yr[num25 - 1] != 0.0 || yi[num25 - 1] != 0.0))
					{
						yr[num25 - 2] = 0.0;
						yi[num25 - 2] = 0.0;
						nz++;
					}
					goto IL_077d;
					IL_077d:
					num25++;
					continue;
					IL_08ad:
					if (num29 > 0.0 || zr < 0.0)
					{
						break;
					}
					nz = n;
					for (num25 = 1; num25 <= n; num25++)
					{
						yr[num25 - 1] = 0.0;
						yi[num25 - 1] = 0.0;
					}
					return 0;
				}
				nz = -1;
				return 0;
			}

			private static int zuoik(double zr, double zi, double fnu, int kode, int ikflg, int n, double[] yr, double[] yi, ref int nuf, double tol, double elim, double alim)
			{
				double d = 0.0;
				double argi = 0.0;
				double argr = 0.0;
				double asumi = 0.0;
				double asumr = 0.0;
				double bsumi = 0.0;
				double bsumr = 0.0;
				double phii = 0.0;
				double phir = 0.0;
				double br = 0.0;
				double bi = 0.0;
				double sumi = 0.0;
				double sumr = 0.0;
				double zeta1i = 0.0;
				double zeta1r = 0.0;
				double zeta2i = 0.0;
				double zeta2r = 0.0;
				double zi2 = 0.0;
				double num = 0.0;
				int ierr = 0;
				int nz = 0;
				double[] cwrkr = new double[16];
				double[] cwrki = new double[16];
				nuf = 0;
				int num2 = n;
				double num3 = zr;
				double num4 = zi;
				if (!(zr >= 0.0))
				{
					num3 = 0.0 - zr;
					num4 = 0.0 - zi;
				}
				double num5 = num3;
				double num6 = num4;
				double num7 = Math.Abs(zr) * 1.7321;
				double num8 = Math.Abs(zi);
				int num9 = 1;
				if (num8 > num7)
				{
					num9 = 2;
				}
				double fnu2 = Math.Max(fnu, 1.0);
				if (ikflg != 1)
				{
					double num10 = num2;
					fnu2 = Math.Max(fnu + num10 - 1.0, num10);
				}
				double num11;
				double num12;
				if (num9 != 2)
				{
					int init = 0;
					zunik(num3, num4, fnu2, ikflg, 1, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref cwrkr, ref cwrki);
					num11 = 0.0 - zeta1r + zeta2r;
					num12 = 0.0 - zeta1i + zeta2i;
				}
				else
				{
					num = num4;
					zi2 = 0.0 - num3;
					if (!(zi > 0.0))
					{
						num = 0.0 - num;
					}
					zunhj(num, zi2, fnu2, 1, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
					num11 = 0.0 - zeta1r + zeta2r;
					num12 = 0.0 - zeta1i + zeta2i;
					d = zabs(argr, argi);
				}
				if (kode != 1)
				{
					num11 -= num5;
					num12 -= num6;
				}
				if (ikflg != 1)
				{
					num11 = 0.0 - num11;
					num12 = 0.0 - num12;
				}
				double d2 = zabs(phir, phii);
				double num13 = num11;
				if (!(num13 > elim))
				{
					if (num13 < alim)
					{
						if (!(num13 < 0.0 - elim))
						{
							if (num13 > 0.0 - alim)
							{
								goto IL_03ad;
							}
							num13 += Math.Log(d2);
							if (num9 == 2)
							{
								num13 = num13 - Math.Log(d) * 0.25 - 1.2655121234846454;
							}
							if (num13 > 0.0 - elim)
							{
								double ascle = d1mach(1) * 1000.0 / tol;
								zlog(phir, phii, ref br, ref bi, ref ierr);
								num11 += br;
								num12 += bi;
								if (num9 != 1)
								{
									zlog(argr, argi, ref br, ref bi, ref ierr);
									num11 = num11 - br * 0.25 - 1.2655121234846454;
									num12 -= bi * 0.25;
								}
								num7 = Math.Exp(num13) / tol;
								num8 = num12;
								num11 = num7 * Math.Cos(num8);
								num12 = num7 * Math.Sin(num8);
								zuchk(num11, num12, ref nz, ascle, tol);
								if (nz == 0)
								{
									goto IL_03ad;
								}
							}
						}
						for (int i = 1; i <= num2; i++)
						{
							yr[i - 1] = 0.0;
							yi[i - 1] = 0.0;
						}
						nuf = num2;
						return 0;
					}
					num13 += Math.Log(d2);
					if (num9 == 2)
					{
						num13 = num13 - Math.Log(d) * 0.25 - 1.2655121234846454;
					}
					if (!(num13 > elim))
					{
						goto IL_03ad;
					}
				}
				nuf = -1;
				return 0;
				IL_03ad:
				if (ikflg == 2)
				{
					return 0;
				}
				if (n == 1)
				{
					return 0;
				}
				while (true)
				{
					fnu2 = fnu + (double)(num2 - 1);
					if (num9 != 2)
					{
						int init = 0;
						zunik(num3, num4, fnu2, ikflg, 1, tol, ref init, ref phir, ref phii, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref sumr, ref sumi, ref cwrkr, ref cwrki);
						num11 = 0.0 - zeta1r + zeta2r;
						num12 = 0.0 - zeta1i + zeta2i;
					}
					else
					{
						zunhj(num, zi2, fnu2, 1, tol, ref phir, ref phii, ref argr, ref argi, ref zeta1r, ref zeta1i, ref zeta2r, ref zeta2i, ref asumr, ref asumi, ref bsumr, ref bsumi);
						num11 = 0.0 - zeta1r + zeta2r;
						num12 = 0.0 - zeta1i + zeta2i;
						d = zabs(argr, argi);
					}
					if (kode != 1)
					{
						num11 -= num5;
						num12 -= num6;
					}
					d2 = zabs(phir, phii);
					num13 = num11;
					if (!(num13 < 0.0 - elim))
					{
						if (num13 > 0.0 - alim)
						{
							return 0;
						}
						num13 += Math.Log(d2);
						if (num9 == 2)
						{
							num13 = num13 - Math.Log(d) * 0.25 - 1.2655121234846454;
						}
						if (num13 > 0.0 - elim)
						{
							double ascle = d1mach(1) * 1000.0 / tol;
							zlog(phir, phii, ref br, ref bi, ref ierr);
							num11 += br;
							num12 += bi;
							if (num9 != 1)
							{
								zlog(argr, argi, ref br, ref bi, ref ierr);
								num11 = num11 - br * 0.25 - 1.2655121234846454;
								num12 -= bi * 0.25;
							}
							num7 = Math.Exp(num13) / tol;
							num8 = num12;
							num11 = num7 * Math.Cos(num8);
							num12 = num7 * Math.Sin(num8);
							zuchk(num11, num12, ref nz, ascle, tol);
							if (nz == 0)
							{
								break;
							}
						}
					}
					yr[num2 - 1] = 0.0;
					yi[num2 - 1] = 0.0;
					num2--;
					nuf++;
					if (num2 == 0)
					{
						return 0;
					}
				}
				return 0;
			}

			private static int zwrsk(double zrr, double zri, double fnu, int kode, int n, double[] yr, double[] yi, ref int nz, double[] cwr, double[] cwi, double tol, double elim, double alim)
			{
				int nz2 = 0;
				nz = 0;
				zbknu(zrr, zri, fnu, kode, 2, cwr, cwi, ref nz2, tol, elim, alim);
				if (nz2 == 0)
				{
					zrati(zrr, zri, fnu, n, yr, yi, tol);
					double num = 1.0;
					double num2 = 0.0;
					if (kode != 1)
					{
						num = Math.Cos(zri);
						num2 = Math.Sin(zri);
					}
					double num3 = zabs(cwr[1], cwi[1]);
					double num4 = d1mach(1) * 1000.0 / tol;
					double num5 = 1.0;
					if (!(num3 > num4))
					{
						num5 = 1.0 / tol;
					}
					else
					{
						num4 = 1.0 / num4;
						if (!(num3 < num4))
						{
							num5 = tol;
						}
					}
					double num6 = cwr[0] * num5;
					double num7 = cwi[0] * num5;
					double num8 = cwr[1] * num5;
					double num9 = cwi[1] * num5;
					double num10 = yr[0];
					double num11 = yi[0];
					double num12 = num10 * num6 - num11 * num7;
					double num13 = num10 * num7 + num11 * num6;
					num12 += num8;
					num13 += num9;
					double num14 = zrr * num12 - zri * num13;
					double num15 = zrr * num13 + zri * num12;
					double num16 = zabs(num14, num15);
					double num17 = 1.0 / num16;
					num14 *= num17;
					num15 = (0.0 - num15) * num17;
					num12 = num * num17;
					num13 = num2 * num17;
					num = num12 * num14 - num13 * num15;
					num2 = num12 * num15 + num13 * num14;
					yr[0] = num * num5;
					yi[0] = num2 * num5;
					if (n == 1)
					{
						return 0;
					}
					for (int i = 2; i <= n; i++)
					{
						num12 = num10 * num - num11 * num2;
						num2 = num10 * num2 + num11 * num;
						num = num12;
						num10 = yr[i - 1];
						num11 = yi[i - 1];
						yr[i - 1] = num * num5;
						yi[i - 1] = num2 * num5;
					}
					return 0;
				}
				nz = -1;
				if (nz2 == -2)
				{
					nz = -2;
				}
				return 0;
			}
		}

		internal static class MarcumQFunction
		{
			private static class IncompleteGamma
			{
				internal static void Incgam(double a, double x, out double p, out double q, out int ierr)
				{
					ierr = 0;
					p = 0.0;
					q = 0.0;
					double num = ((x < Dwarf) ? Math.Log(Dwarf) : Math.Log(x));
					double num2;
					if (a > Alfa(x))
					{
						num2 = Dompart(a, x, qt: false);
						if (num2 < 0.0)
						{
							ierr = 1;
							p = 0.0;
							q = 0.0;
							return;
						}
						if (x < 0.3 * a || a < 12.0)
						{
							p = Ptaylor(a, x, num2);
						}
						else
						{
							p = PQasymp(a, x, num2, p: true);
						}
						q = 1.0 - p;
						return;
					}
					if (a < (0.0 - Dwarf) / num)
					{
						q = 0.0;
						return;
					}
					if (x < 1.0)
					{
						num2 = Dompart(a, x, qt: true);
						if (num2 < 0.0)
						{
							ierr = 1;
							q = 0.0;
							p = 0.0;
						}
						else
						{
							q = Qtaylor(a, x, num2);
							p = 1.0 - q;
						}
						return;
					}
					num2 = Dompart(a, x, qt: false);
					if (num2 < 0.0)
					{
						ierr = 1;
						p = 0.0;
						q = 0.0;
						return;
					}
					if (x > 1.5 * a || a < 12.0)
					{
						q = Qfraction(a, x, num2);
					}
					else
					{
						q = PQasymp(a, x, num2, p: false);
						if (num2 == 0.0)
						{
							q = 0.0;
						}
					}
					p = 1.0 - q;
				}

				internal static void Invincgam(double a, double p, double q, out double xr, out int ierr)
				{
					ierr = 0;
					double num = 0.0;
					bool flag;
					double num2;
					double num3;
					if (p < 0.5)
					{
						flag = true;
						num2 = p;
						num3 = -1.0;
					}
					else
					{
						flag = false;
						num2 = q;
						num3 = 1.0;
					}
					double num4 = 1.0 / a * (Math.Log(p) + Loggam(a + 1.0));
					double[] array = new double[6];
					int num6;
					double num16;
					double num7;
					if (num4 < Math.Log(0.2 * (1.0 + a)))
					{
						double num5 = Math.Exp(num4);
						num6 = 0;
						num7 = a * a;
						double num8 = num7 * a;
						double num9 = num8 * a;
						double num10 = a + 1.0;
						double num11 = (a + 1.0) * num10;
						double num12 = (a + 1.0) * num11;
						double num13 = num11 * num11;
						double num14 = a + 2.0;
						double num15 = num14 * num14;
						array[1] = 1.0;
						array[2] = 1.0 / (1.0 + a);
						array[3] = 0.5 * (3.0 * a + 5.0) / (num11 * (a + 2.0));
						array[4] = 1.0 / 3.0 * (31.0 + 8.0 * num7 + 33.0 * a) / (num12 * num14 * (a + 3.0));
						array[5] = 1.0 / 24.0 * (2888.0 + 1179.0 * num8 + 125.0 * num9 + 3971.0 * num7 + 5661.0 * a) / (num13 * num15 * (a + 3.0) * (a + 4.0));
						num16 = num5 * (1.0 + num5 * (array[2] + num5 * (array[3] + num5 * (array[4] + num5 * array[5]))));
					}
					else if (q < Math.Min(0.02, Math.Exp(-1.5 * a) / Gamma(a)) && a < 10.0)
					{
						num6 = 0;
						double num17 = 1.0 - a;
						double num18 = num17 * num17;
						double num19 = num18 * num17;
						num = Math.Sqrt(-2.0 / a * Math.Log(q * Gamstar(a) * 2.5066282746310007 / Math.Sqrt(a)));
						num16 = a * Lambdaeta(num);
						double num20 = Math.Log(num16);
						if (a > 0.12 || num16 > 5.0)
						{
							double num21 = num20 * num20;
							double num22 = num21 * num20;
							double num23 = num22 * num20;
							double num24 = 1.0 / num16;
							array[1] = num20 - 1.0;
							array[2] = (3.0 * num17 - 2.0 * num17 * num20 + num21 - 2.0 * num20 + 2.0) / 2.0;
							array[3] = (24.0 * num17 * num20 - 11.0 * num18 - 24.0 * num17 - 6.0 * num21 + 12.0 * num20 - 12.0 - 9.0 * num17 * num21 + 6.0 * num18 * num20 + 2.0 * num22) / 6.0;
							array[4] = (-12.0 * num19 * num20 + 84.0 * num17 * num21 - 114.0 * num18 * num20 + 72.0 + 36.0 * num21 + 3.0 * num23 - 72.0 * num20 + 162.0 * num17 - 168.0 * num17 * num20 - 12.0 * num22 + 25.0 * num19 - 22.0 * num17 * num22 + 36.0 * num18 * num21 + 120.0 * num18) / 12.0;
							num16 = num16 - num20 + num17 * num24 * (array[1] + num24 * (array[2] + num24 * (array[3] + num24 * array[4])));
						}
						else
						{
							double num25 = 1.0 / num16;
							array[1] = num20 - 1.0;
							num16 = num16 - num20 + num17 * num25 * array[1];
						}
					}
					else if (Math.Abs(num2 - 0.5) < 1E-05)
					{
						num6 = 0;
						num16 = a - 1.0 / 3.0 + (8.0 / 405.0 + 0.007211444248481286 / a) / a;
					}
					else if (Math.Abs(a - 1.0) < 0.0001)
					{
						num6 = 0;
						num16 = ((!flag) ? (0.0 - Math.Log(q)) : (0.0 - Math.Log(1.0 - p)));
					}
					else if (a < 1.0)
					{
						num6 = 0;
						num16 = ((!flag) ? Math.Exp(1.0 / a * (Math.Log(1.0 - num2) + Loggam(a + 1.0))) : Math.Exp(1.0 / a * (Math.Log(num2) + Loggam(a + 1.0))));
					}
					else
					{
						num6 = 1;
						double num26 = Inverfc(2.0 * num2);
						num = num3 * num26 / Math.Sqrt(a * 0.5);
						num += (Eps1(num) + (Eps2(num) + Eps3(num) / a) / a) / a;
						num16 = a * Lambdaeta(num);
					}
					double num27 = 1.0;
					double num28 = num16;
					int num29 = 1;
					num7 = a * a;
					while (num27 > 1E-15 && num29 < 15)
					{
						num28 = num16;
						double num30 = num28 * num28;
						int ierr2;
						if (num6 == 0)
						{
							double num31 = (1.0 - a) * Math.Log(num28) + num28 + Loggam(a);
							if (num31 > Math.Log(Giant))
							{
								num29 = 20;
								ierr = -1;
							}
							else
							{
								double num32 = Math.Exp(num31);
								Incgam(a, num28, out var p2, out var q2, out ierr2);
								array[1] = (flag ? ((0.0 - num32) * (p2 - p)) : (num32 * (q2 - q)));
								array[2] = (num28 - a + 1.0) / (2.0 * num28);
								array[3] = (2.0 * num30 - 4.0 * num28 * a + 4.0 * num28 + 2.0 * num7 - 3.0 * a + 1.0) / (6.0 * num30);
								num32 = array[1];
								num16 = ((!(a > 0.1)) ? ((!(a > 0.05)) ? (num28 + num32) : (num28 + num32 * (1.0 + num32 * array[2]))) : (num28 + num32 * (1.0 + num32 * (array[2] + num32 * array[3]))));
							}
						}
						else
						{
							double num33 = num;
							double num34 = (0.0 - Math.Sqrt(a / (Math.PI * 2.0))) * Math.Exp(-0.5 * a * num33 * num33) / Gamstar(a);
							double num35 = (0.0 - 1.0 / num34) * num28;
							Incgam(a, num28, out var p3, out var q3, out ierr2);
							array[1] = (flag ? ((0.0 - num35) * (p3 - p)) : (num35 * (q3 - q)));
							array[2] = (num28 - a + 1.0) / (2.0 * num28);
							array[3] = (2.0 * num30 - 4.0 * num28 * a + 4.0 * num28 + 2.0 * num7 - 3.0 * a + 1.0) / (6.0 * num30);
							num35 = array[1];
							num16 = ((!(a > 0.1)) ? ((!(a > 0.05)) ? (num28 + num35) : (num28 + num35 * (1.0 + num35 * array[2]))) : (num28 + num35 * (1.0 + num35 * (array[2] + num35 * array[3]))));
						}
						num27 = Math.Abs(num28 / num16 - 1.0);
						num29++;
						num28 = num16;
					}
					if (num29 == 15)
					{
						ierr = -2;
					}
					xr = num28;
				}

				private static double Sinh(double x, double eps)
				{
					double num = Math.Abs(x);
					if (x == 0.0)
					{
						return 0.0;
					}
					if (num < 0.12)
					{
						double num2 = eps / 10.0;
						double num3 = x * x;
						double num4 = 1.0;
						double num5 = 1.0;
						int num6 = 0;
						int num7 = 1;
						while (num5 > num2)
						{
							num6 = num6 + 8 * num7 - 2;
							num7++;
							num5 = num5 * num3 / (double)num6;
							num4 += num5;
						}
						return x * num4;
					}
					if (num < 0.36)
					{
						double num8 = Sinh(x / 3.0, eps);
						return num8 * (3.0 + 4.0 * num8 * num8);
					}
					double num9 = Math.Exp(x);
					return (num9 - 1.0 / num9) / 2.0;
				}

				private static double Exmin1(double x, double eps)
				{
					if (x == 0.0)
					{
						return 1.0;
					}
					if (x < -0.69 || x > 0.4)
					{
						return (Math.Exp(x) - 1.0) / x;
					}
					double num = x / 2.0;
					return Math.Exp(num) * Sinh(num, eps) / num;
				}

				private static double Exmin1minx(double x, double eps)
				{
					if (x == 0.0)
					{
						return 1.0;
					}
					if (Math.Abs(x) > 0.9)
					{
						return (Math.Exp(x) - 1.0 - x) / (x * x / 2.0);
					}
					double num = Sinh(x / 2.0, eps);
					double num2 = num * num;
					return (2.0 * num2 + (2.0 * num * Math.Sqrt(1.0 + num2) - x)) / (x * x / 2.0);
				}

				private static double Logoneplusx(double x)
				{
					double num = Math.Log(1.0 + x);
					if (-0.2928 < x && x < 0.4142)
					{
						double num2 = num * Exmin1(num, MachTol);
						double num3 = (num2 - x) / (num2 + 1.0);
						num -= num3 * (6.0 - num3) / (6.0 - 4.0 * num3);
					}
					return num;
				}

				private static double Lnec(double x)
				{
					double num = Logoneplusx(x);
					double num2 = num - x;
					double num3 = Exmin1minx(num, MachTol) * num * num / 2.0;
					double num4 = (num3 + num2) / (num3 + 1.0 + num);
					return num2 - num4 * (6.0 - num4) / (6.0 - 4.0 * num4);
				}

				private static double Alfa(double x)
				{
					double num = Math.Log(x);
					if (x > 0.25)
					{
						return x + 0.25;
					}
					if (x >= Dwarf)
					{
						return -0.6931 / num;
					}
					return -0.6931 / Math.Log(Dwarf);
				}

				internal static double Dompart(double a, double x, bool qt)
				{
					double num = Math.Log(x);
					double num2;
					if (a <= 1.0)
					{
						num2 = 0.0 - x + a * num;
					}
					else
					{
						if (x == a)
						{
							num2 = 0.0;
						}
						else
						{
							double num3 = x / a;
							num2 = a * (1.0 - num3 + Math.Log(num3));
						}
						num2 -= 0.5 * Math.Log(6.2832 * a);
					}
					double result = ((num2 < ExpLow) ? 0.0 : Math.Exp(num2));
					if (qt)
					{
						return result;
					}
					if (a < 3.0 || x < 0.2)
					{
						return Math.Exp(a * num - x) / Gamma(a + 1.0);
					}
					double num4 = Lnec((x - a) / a);
					if (a * num4 > Math.Log(Giant))
					{
						return -100.0;
					}
					if (a * num4 < Math.Log(Dwarf))
					{
						return 0.0;
					}
					return Math.Exp(a * num4) / (Math.Sqrt(a * 2.0 * Math.PI) * Gamstar(a));
				}

				private static double Chepolsum(int n, double x, double[] a)
				{
					switch (n)
					{
					case 0:
						return a[0] / 2.0;
					case 1:
						return a[0] / 2.0 + a[1] + x;
					default:
					{
						double num = x + x;
						double num2 = a[n];
						double num3 = a[n - 1] + num2 * num;
						for (int num4 = n - 2; num4 >= 1; num4--)
						{
							double num5 = num2;
							num2 = num3;
							num3 = a[num4] + num2 * num - num5;
						}
						return a[0] / 2.0 - num2 + num3 * x;
					}
					}
				}

				private static double Auxloggam(double x)
				{
					if (x < -1.0)
					{
						return Giant;
					}
					if (Math.Abs(x) <= Dwarf)
					{
						return -0.5772156649015329;
					}
					if (Math.Abs(x - 1.0) <= MachTol)
					{
						return -0.42278433509846713;
					}
					if (x < 0.0)
					{
						return (0.0 - (x * (1.0 + x) * Auxloggam(x + 1.0) + Logoneplusx(x))) / (x * (1.0 - x));
					}
					if (x < 1.0)
					{
						double[] a = new double[26]
						{
							-0.9828307860587743, 0.07611416167043585, -0.008432324965932778, 0.001079493726328608, -0.00014900748003692966, 2.151239988855679E-05, -3.19793298608622E-06, 4.8516930121399E-07, -7.471487821163E-08, 1.163829670017E-08,
							-1.82940043712E-09, 2.8969180607E-10, -4.615701406E-11, 7.39281023E-12, -1.189428E-12, 1.9212069E-13, -3.113976E-14, 5.06284E-15, -8.2542E-16, 1.3491E-16,
							-2.21E-17, 3.63E-18, -6E-19, 9.8E-20, -2E-20, 3E-21
						};
						double x2 = 2.0 * x - 1.0;
						return Chepolsum(25, x2, a);
					}
					if (x < 1.5)
					{
						return (Logoneplusx(x - 1.0) + (x - 1.0) * (2.0 - x) * Auxloggam(x - 1.0)) / (x * (1.0 - x));
					}
					return (Math.Log(x) + (x - 1.0) * (2.0 - x) * Auxloggam(x - 1.0)) / (x * (1.0 - x));
				}

				internal static double Loggam(double x)
				{
					if (x >= 3.0)
					{
						return (x - 0.5) * Math.Log(x) - x + LnSqrt2Pi + Stirling(x);
					}
					if (x >= 2.0)
					{
						return (x - 2.0) * (3.0 - x) * Auxloggam(x - 2.0) + Logoneplusx(x - 2.0);
					}
					if (x >= 1.0)
					{
						return (x - 1.0) * (2.0 - x) * Auxloggam(x - 1.0);
					}
					if (x > 0.5)
					{
						return x * (1.0 - x) * Auxloggam(x) - Logoneplusx(x - 1.0);
					}
					if (x > 0.0)
					{
						return x * (1.0 - x) * Auxloggam(x) - Math.Log(x);
					}
					return Giant;
				}

				private static double Auxgam(double x)
				{
					if (x < 0.0)
					{
						return (0.0 - (1.0 + (1.0 + x) * (1.0 + x) * Auxgam(1.0 + x))) / (1.0 - x);
					}
					double[] a = new double[18]
					{
						-1.0136092580098657, 0.07849035310247823, 0.006758866874325832, -0.0012790434869623469, 4.629398386427396E-05, 4.338168174474035E-06, -5.326872422618006E-07, 1.72233457410539E-08, 8.300542107118E-10, -1.0553994239968E-10,
						3.9415842851E-12, 3.62068537E-14, -1.07440229E-14, 5.000413E-16, -6.2452E-18, -5.185E-19, 3.47E-20, -9E-22
					};
					double x2 = 2.0 * x - 1.0;
					return Chepolsum(17, x2, a);
				}

				private static double Lngam1(double x)
				{
					return 0.0 - Logoneplusx(x * (x - 1.0) * Auxgam(x));
				}

				private static double Stirling(double x)
				{
					if (x < Dwarf)
					{
						return Giant;
					}
					if (x < 1.0)
					{
						return Lngam1(x) - (x + 0.5) * Math.Log(x) + x - LnSqrt2Pi;
					}
					if (x < 2.0)
					{
						return Lngam1(x - 1.0) - (x - 0.5) * Math.Log(x) + x - LnSqrt2Pi;
					}
					if (x < 3.0)
					{
						return Lngam1(x - 2.0) - (x - 0.5) * Math.Log(x) + x - LnSqrt2Pi + Math.Log(x - 1.0);
					}
					if (x < 12.0)
					{
						double[] a = new double[18]
						{
							1.9963790515900766, -0.0017971032528832887, 1.3129285796384672E-05, -2.340875228178749E-07, 7.2291210671127E-09, -3.280997607821E-10, 1.9875070901E-11, -1.509214183E-12, 1.375340084E-13, -1.45728923E-14,
							1.7532367E-15, -2.351465E-16, 3.46551E-17, -5.5471E-18, 9.548E-19, -1.748E-19, 3.32E-20, -5.8E-21
						};
						double x2 = 18.0 / (x * x) - 1.0;
						return Chepolsum(17, x2, a) / (12.0 * x);
					}
					double num = 1.0 / (x * x);
					if (x < 1000.0)
					{
						double[] array = new double[7] { 0.025721014990011306, 0.08247596616699963, -0.0025328157302663564, 0.0006099292666946337, -0.00033543297638406, 0.000250505279903, 0.30865217988013566 };
						return (((((array[5] * num + array[4]) * num + array[3]) * num + array[2]) * num + array[1]) * num + array[0]) / (array[6] + num) / x;
					}
					return ((((0.0 - num) / 1680.0 + 0.0007936507936507937) * num - 1.0 / 360.0) * num + 1.0 / 12.0) / x;
				}

				private static double Gamma(double x)
				{
					int num = (int)Math.Round(x);
					int num2 = num - 1;
					double num3 = ((num == 0) ? Dwarf : MachTol);
					double num4;
					if (num <= 0 && Math.Abs((double)num - x) <= num3)
					{
						num4 = ((num % 2 <= 0) ? ((x - (double)num < 0.0) ? (0.0 - Giant) : Giant) : (((double)num - x < 0.0) ? (0.0 - Giant) : Giant));
					}
					else if (x < 0.45)
					{
						num4 = Math.PI / (Math.Sin(Math.PI * x) * Gamma(1.0 - x));
					}
					else if (Math.Abs((double)num - x) < num3 && x < 21.0)
					{
						num4 = 1.0;
						for (int i = 2; i <= num2; i++)
						{
							num4 *= (double)i;
						}
					}
					else if (Math.Abs((double)num - x - 0.5) < num3 && x < 21.0)
					{
						num4 = 1.772453850905516;
						for (int j = 1; j <= num2; j++)
						{
							num4 *= (double)j - 0.5;
						}
					}
					else if (x < 3.0)
					{
						if ((double)num > x)
						{
							num = num2;
						}
						num2 = 3 - num;
						double num5 = (double)num2 + x;
						num4 = Gamma(num5);
						for (int k = 1; k <= num2; k++)
						{
							num4 /= num5 - (double)k;
						}
					}
					else
					{
						num4 = 2.5066282746310007 * Math.Exp(0.0 - x + (x - 0.5) * Math.Log(x) + Stirling(x));
					}
					return num4;
				}

				private static double Gamstar(double x)
				{
					if (x >= 3.0)
					{
						return Math.Exp(Stirling(x));
					}
					if (x > 0.0)
					{
						return Gamma(x) / (Math.Exp(0.0 - x + (x - 0.5) * Math.Log(x)) * 2.5066282746310007);
					}
					return Giant;
				}

				private static double Errorfunction(double x, bool erfcc, bool expo)
				{
					if (erfcc)
					{
						if (x < -6.5)
						{
							return 2.0;
						}
						if (x < 0.0)
						{
							return 2.0 - Errorfunction(0.0 - x, erfcc: true, expo: false);
						}
						if (x == 0.0)
						{
							return 1.0;
						}
						double num;
						if (x < 0.5)
						{
							num = (expo ? Math.Exp(x * x) : 1.0);
							return num * (1.0 - Errorfunction(x, erfcc: false, expo: false));
						}
						if (x < 4.0)
						{
							num = (expo ? 1.0 : Math.Exp((0.0 - x) * x));
							double[] r = new double[9] { 1230.3393547979972, 2051.0783778260716, 1712.0476126340707, 881.952221241769, 298.6351381974001, 66.11919063714163, 8.883149794388377, 0.5641884969886701, 2.1531153547440383E-08 };
							double[] s = new double[8] { 1230.3393548037495, 3439.3676741437216, 4362.619090143247, 3290.7992357334597, 1621.3895745666903, 537.1811018620099, 117.6939508913125, 15.744926110709835 };
							return num * Fractio(x, 8, r, s);
						}
						double num2 = x * x;
						num = (expo ? 1.0 : Math.Exp(0.0 - num2));
						num2 = 1.0 / num2;
						double[] r2 = new double[6] { 0.0006587491615298378, 0.016083785148742275, 0.12578172611122926, 0.36034489994980445, 0.30532663496123236, 0.016315387137302097 };
						double[] s2 = new double[5] { 0.0023352049762686918, 0.06051834131244132, 0.5279051029514285, 1.8729528499234604, 2.568520192289822 };
						return num * ((0.5641895835477563 - num2 * Fractio(num2, 5, r2, s2)) / x);
					}
					if (x == 0.0)
					{
						return 0.0;
					}
					if (Math.Abs(x) > 6.5)
					{
						return x / Math.Abs(x);
					}
					if (x > 0.5)
					{
						return 1.0 - Errorfunction(x, erfcc: true, expo: false);
					}
					if (x < -0.5)
					{
						return Errorfunction(0.0 - x, erfcc: true, expo: false) - 1.0;
					}
					double[] r3 = new double[5] { 3209.3775891384694, 377.485237685302, 113.86415415105016, 3.1611237438705655, 0.18577770618460315 };
					double[] s3 = new double[4] { 2844.236833439171, 1282.6165260773723, 244.02463793444417, 23.601290952344122 };
					double x2 = x * x;
					return x * Fractio(x2, 4, r3, s3);
				}

				private static double Fractio(double x, int n, double[] r, double[] s)
				{
					double num = r[n];
					double num2 = 1.0;
					for (int num3 = n - 1; num3 >= 0; num3--)
					{
						num = num * x + r[num3];
						num2 = num2 * x + s[num3];
					}
					return num / num2;
				}

				private static double PQasymp(double a, double x, double dp, bool p)
				{
					if (dp == 0.0)
					{
						return p ? 0.0 : 1.0;
					}
					double num = ((!p) ? 1 : (-1));
					double num2 = (x - a) / a;
					double num3 = 0.0 - Lnec(num2);
					double num4 = ((num3 < 0.0) ? 0.0 : Math.Sqrt(2.0 * num3));
					num3 *= a;
					double num5 = Math.Sqrt(Math.Abs(num3));
					if (num2 < 0.0)
					{
						num4 = 0.0 - num4;
						num5 = 0.0 - num5;
					}
					double num6 = 0.5 * Errorfunction(num * num5, erfcc: true, expo: false);
					num5 = num * Math.Exp(0.0 - num3) * Saeta(a, num4) / Math.Sqrt(Math.PI * 2.0 * a);
					return num6 + num5;
				}

				private static double Saeta(double a, double eta)
				{
					double epss = Epss;
					double[] array = new double[27]
					{
						1.0,
						-1.0 / 3.0,
						1.0 / 12.0,
						-2.0 / 135.0,
						1.0 / 864.0,
						0.0003527336860670194,
						-0.0001787551440329218,
						3.919263178522438E-05,
						-2.185448510679992E-06,
						-1.85406221071516E-06,
						8.296711340953087E-07,
						-1.7665952736826078E-07,
						6.707853543401498E-09,
						1.0261809784240309E-08,
						-4.382036018453353E-09,
						9.14769958223679E-10,
						-2.5514193994946248E-11,
						-5.830772132550426E-11,
						2.4361948020667415E-11,
						-5.0276692801141755E-12,
						1.1004392031956135E-13,
						3.371763262400985E-13,
						-1.392388722418162E-13,
						2.8534893807047445E-14,
						-5.139111834242572E-16,
						-1.9752288294349442E-15,
						8.099521156704561E-16
					};
					double[] array2 = new double[26];
					array2[25] = array[26];
					array2[24] = array[25];
					for (int num = 24; num >= 1; num--)
					{
						array2[num - 1] = array[num] + (double)(num + 1) * array2[num + 1] / a;
					}
					double num2 = array2[0];
					double num3 = num2;
					double num4 = eta;
					int num5 = 1;
					while (Math.Abs(num3 / num2) > epss && num5 < 25)
					{
						num3 = array2[num5] * num4;
						num2 += num3;
						num5++;
						num4 *= eta;
					}
					return num2 / (1.0 + array2[1] / a);
				}

				private static double Qfraction(double a, double x, double dp)
				{
					double epss = Epss;
					if (dp == 0.0)
					{
						return 0.0;
					}
					double num = 0.0;
					double num2 = (x - 1.0 - a) * (x + 1.0 - a);
					double num3 = 4.0 * (x + 1.0 - a);
					double num4 = 1.0 - a;
					double num5 = 0.0;
					double num6 = 1.0;
					double num7;
					for (num7 = 1.0; Math.Abs(num6 / num7) >= epss; num7 += num6)
					{
						num += num4;
						num2 += num3;
						num3 += 8.0;
						num4 += 2.0;
						double num8 = num * (1.0 + num5);
						num5 = num8 / (num2 - num8);
						num6 = num5 * num6;
					}
					return a / (x + 1.0 - a) * num7 * dp;
				}

				private static double Qtaylor(double a, double x, double dp)
				{
					double epss = Epss;
					double num = Math.Log(x);
					if (dp == 0.0)
					{
						return 0.0;
					}
					double num2 = a * num;
					double num3 = num2 * Exmin1(num2, epss);
					double num4 = a * (1.0 - a) * Auxgam(a);
					num3 *= 1.0 - num4;
					double num5 = num4 - num3;
					double num6 = a * x;
					num3 = a + 1.0;
					num2 = a + 3.0;
					double num7 = 1.0;
					double num8;
					for (num8 = 1.0; Math.Abs(num7 / num8) > epss; num8 += num7)
					{
						num6 += x;
						num3 += num2;
						num2 += 2.0;
						num7 = (0.0 - num6) * num7 / num3;
					}
					num8 = a * (1.0 - num4) * Math.Exp((a + 1.0) * num) * num8 / (a + 1.0);
					return num5 + num8;
				}

				private static double Ptaylor(double a, double x, double dp)
				{
					double epss = Epss;
					if (dp == 0.0)
					{
						return 0.0;
					}
					double num = 1.0;
					double num2 = 1.0;
					double num3 = a;
					for (; num2 / num > epss; num += num2)
					{
						num3 += 1.0;
						num2 *= x / num3;
					}
					return num * dp;
				}

				private static double Eps1(double eta)
				{
					if (Math.Abs(eta) < 1.0)
					{
						double[] ak = new double[5] { -0.3333333333438, -0.2070740359969, -0.05041806657154, -0.004923635739372, -4.293658292782E-05 };
						double[] bk = new double[5] { 1.0, 0.7045554412463, 0.2118190062224, 0.03048648397436, 0.001605037988091 };
						return Ratfun(eta, ak, bk);
					}
					double num = Lambdaeta(eta);
					return Math.Log(eta / (num - 1.0)) / eta;
				}

				private static double Eps2(double eta)
				{
					double[] array = new double[5];
					double[] array2 = new double[5];
					if (eta < -5.0)
					{
						double num = eta * eta;
						double num2 = Math.Log(0.0 - eta);
						return (12.0 - num - 6.0 * (num2 * num2)) / (12.0 * num * eta);
					}
					if (eta < -2.0)
					{
						array[0] = -0.0172847633523;
						array2[0] = 1.0;
						array[1] = -0.0159372646475;
						array2[1] = 0.764050615669;
						array[2] = -0.00464910887221;
						array2[2] = 0.297143406325;
						array[3] = -0.00060683488776;
						array2[3] = 0.0579490176079;
						array[4] = -6.14830384279E-06;
						array2[4] = 0.00574558524851;
						return Ratfun(eta, array, array2);
					}
					if (eta < 2.0)
					{
						array[0] = -0.0172839517431;
						array2[0] = 1.0;
						array[1] = -0.0146362417966;
						array2[1] = 0.690560400696;
						array[2] = -0.00357406772616;
						array2[2] = 0.249962384741;
						array[3] = -0.000391032032692;
						array2[3] = 0.0443843438769;
						array[4] = 2.49634036069E-06;
						array2[4] = 0.00424073217211;
						return Ratfun(eta, array, array2);
					}
					if (eta < 1000.0)
					{
						array[0] = 0.99994466948;
						array2[0] = 1.0;
						array[1] = 104.649839762;
						array2[1] = 104.526456943;
						array[2] = 857.204033806;
						array2[2] = 823.313447808;
						array[3] = 731.901559577;
						array2[3] = 3119.93802124;
						array[4] = 45.5174411671;
						array2[4] = 3970.03311219;
						return Ratfun(1.0 / eta, array, array2) / (-12.0 * eta);
					}
					return -1.0 / (12.0 * eta);
				}

				private static double Eps3(double eta)
				{
					double[] array = new double[5];
					double[] array2 = new double[5];
					if (eta < -8.0)
					{
						double num = eta * eta;
						double num2 = Math.Log(0.0 - eta) / eta;
						return (-30.0 + eta * num2 * (6.0 * num * num2 * num2 - 12.0 + num)) / (12.0 * eta * num * num);
					}
					if (eta < -4.0)
					{
						array[0] = 0.0495346498136;
						array2[0] = 1.0;
						array[1] = 0.0299521337141;
						array2[1] = 0.759803615283;
						array[2] = 0.00688296911516;
						array2[2] = 0.261547111595;
						array[3] = 0.000512634846317;
						array2[3] = 0.0464854522477;
						array[4] = -2.01411722031E-05;
						array2[4] = 0.00403751193496;
						return Ratfun(eta, array, array2) / (eta * eta);
					}
					if (eta < -2.0)
					{
						array[0] = 0.00452313583942;
						array2[0] = 1.0;
						array[1] = 0.00120744920113;
						array2[1] = 0.912203410349;
						array[2] = -7.89724156582E-05;
						array2[2] = 0.405368773071;
						array[3] = -5.04476066942E-05;
						array2[3] = 0.0901638932349;
						array[4] = -5.35770949796E-06;
						array2[4] = 0.00948935714996;
						return Ratfun(eta, array, array2);
					}
					if (eta < 2.0)
					{
						array[0] = 0.00439937562904;
						array2[0] = 1.0;
						array[1] = 0.000487225670639;
						array2[1] = 0.794435257415;
						array[2] = -0.000128470657374;
						array2[2] = 0.333094721709;
						array[3] = 5.29110969589E-06;
						array2[3] = 0.0703527806143;
						array[4] = 1.5716677175E-07;
						array2[4] = 0.00806110846078;
						return Ratfun(eta, array, array2);
					}
					if (eta < 10.0)
					{
						array[0] = -0.0011481191232;
						array2[0] = 1.0;
						array[1] = -0.112850923276;
						array2[1] = 14.2482206905;
						array[2] = 1.51623048511;
						array2[2] = 69.7360396285;
						array[3] = -0.218472031183;
						array2[3] = 218.938950816;
						array[4] = 0.0730002451555;
						array2[4] = 277.067027185;
						return Ratfun(1.0 / eta, array, array2) / (eta * eta);
					}
					if (eta < 100.0)
					{
						array[0] = -0.000145727889667;
						array2[0] = 1.0;
						array[1] = -0.290806748131;
						array2[1] = 139.612587808;
						array[2] = -13.308504545;
						array2[2] = 2189.01116348;
						array[3] = 199.722374056;
						array2[3] = 7115.24019009;
						array[4] = -11.4311378756;
						array2[4] = 45574.6081453;
						return Ratfun(1.0 / eta, array, array2) / (eta * eta);
					}
					double num3 = eta * eta * eta;
					return (0.0 - Math.Log(eta)) / (12.0 * num3);
				}

				private static double Lambdaeta(double eta)
				{
					double num = eta * eta * 0.5;
					double[] array = new double[6];
					double num2;
					if (eta == 0.0)
					{
						num2 = 1.0;
					}
					else if (eta < -1.0)
					{
						double num3 = Math.Exp(-1.0 - num);
						array[1] = 1.0;
						array[2] = 1.0;
						array[3] = 1.5;
						array[4] = 2.6666666666666665;
						array[5] = 5.208333333333333;
						array[6] = 10.8;
						num2 = num3 * (array[1] + num3 * (array[2] + num3 * (array[3] + num3 * (array[4] + num3 * (array[5] + num3 * array[6])))));
					}
					else if (eta < 1.0)
					{
						array[1] = 1.0;
						array[2] = 1.0 / 3.0;
						array[3] = 1.0 / 36.0;
						array[4] = -1.0 / 270.0;
						array[5] = 0.0002314814814814815;
						array[6] = 5.878894767783657E-05;
						double num3 = eta;
						num2 = 1.0 + num3 * (array[1] + num3 * (array[2] + num3 * (array[3] + num3 * (array[4] + num3 * (array[5] + num3 * array[6])))));
					}
					else
					{
						double num3 = 11.0 + num;
						double num4 = Math.Log(num3);
						num2 = num3 + num4;
						num3 = 1.0 / num3;
						double num5 = num4 * num4;
						double num6 = num5 * num4;
						double num7 = num6 * num4;
						double num8 = num7 * num4;
						array[1] = 1.0;
						array[2] = (2.0 - num4) * 0.5;
						array[3] = (-9.0 * num4 + 6.0 + 2.0 * num5) / 6.0;
						array[4] = (0.0 - (3.0 * num6 + 36.0 * num4 - 22.0 * num5 - 12.0)) / 12.0;
						array[5] = (60.0 + 350.0 * num5 - 300.0 * num4 - 125.0 * num6 + 12.0 * num7) / 60.0;
						array[6] = (0.0 - (-120.0 - 274.0 * num7 + 900.0 * num4 - 1700.0 * num5 + 1125.0 * num6 + 20.0 * num8)) / 120.0;
						num2 += num4 * num3 * (array[1] + num3 * (array[2] + num3 * (array[3] + num3 * (array[4] + num3 * (array[5] + num3 * array[6])))));
					}
					if ((eta > -3.5 && eta < -0.03) || (eta > 0.03 && eta < 40.0))
					{
						double num3 = 1.0;
						double num9 = num2;
						while (num3 > 1E-08)
						{
							num2 = num9 * (num + Math.Log(num9)) / (num9 - 1.0);
							num3 = Math.Abs(num9 / num2 - 1.0);
							num9 = num2;
						}
					}
					return num2;
				}

				private static double Invq(double x)
				{
					double num = Math.Sqrt(-2.0 * Math.Log(x));
					return num - (2.515517 + num * (0.802853 + num * 0.010328)) / (1.0 + num * (1.432788 + num * (0.189269 + num * 0.001308)));
				}

				private static double Inverfc(double x)
				{
					if (x > 1.0)
					{
						return 0.0 - Inverfc(2.0 - x);
					}
					double num = 0.70710678 * Invq(x / 2.0);
					double num2 = Errorfunction(num, erfcc: true, expo: false) - x;
					double num3 = num * num;
					double num4 = -1.1283791670955126 * Math.Exp(0.0 - num3);
					double num5 = -1.0 / num4;
					double num6 = num;
					double num7 = (4.0 * num3 + 1.0) / 3.0;
					double num8 = num * (12.0 * num3 + 7.0) / 6.0;
					double num9 = (8.0 * num3 + 7.0) * (12.0 * num3 + 1.0) / 30.0;
					double num10 = num2 * num5;
					double num11 = num10 * (1.0 + num10 * (num6 + num10 * (num7 + num10 * (num8 + num10 * num9))));
					return num + num11;
				}

				private static double Ratfun(double x, double[] ak, double[] bk)
				{
					double num = ak[0] + x * (ak[1] + x * (ak[2] + x * (ak[3] + x * ak[4])));
					double num2 = bk[0] + x * (bk[1] + x * (bk[2] + x * (bk[3] + x * bk[4])));
					return num / num2;
				}

				private static double InvGam(double a, double q, bool pgam)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = (pgam ? (1.0 - q) : q);
					double num4 = 2.0 * num3;
					if (Math.Abs(num4 - 1.0) < 1E-10)
					{
						return a - 1.0 / 3.0 + (8.0 / 405.0 + 0.007211444248481286 / a) / a;
					}
					double num14;
					double num20;
					double num5;
					double num6;
					double num7;
					double num12;
					double num13;
					double num15;
					double num16;
					double num17;
					if (num4 != 2.0 && !(num4 < 1E-50))
					{
						num2 = Inverfc(num4) / Math.Sqrt(a / 2.0);
						num5 = num2 * num2;
						num6 = num2 * num5;
						num7 = num5 * num5;
						double num8 = num2 * num7;
						double num9 = num6 * num6;
						double num10 = 1.4142135623730951;
						double num11;
						if (Math.Abs(num2) < 0.3)
						{
							num11 = -1.0 / 3.0 + 1.0 / 36.0 * num2 + 0.0006172839506172839 * num5 - 0.0010802469135802468 * num6 + 0.0002755731922398589 * num7 - 2.8741263309164543E-05 * num8 - 6.185087203605722E-06 * num9;
							num12 = -7.0 / 405.0 - 0.002700617283950617 * num2 + 0.002611209092690574 * num5 - 0.0007520766651425087 * num6 + 6.229995427526292E-05 * num7 + 4.055292003251537E-05 * num8;
							num13 = 0.004399372917891437 - 0.003007782731290962 * num2 + 0.0007956376423454613 * num5 + 6.554653913335898E-05 * num6 - 0.00014083659963035565 * num7;
						}
						else
						{
							num14 = Inveta(num2 / num10);
							num15 = num14 - 1.0;
							num16 = num15 * num15;
							num17 = num15 * num16;
							double num18 = (num15 + 1.0) * num2 / num15;
							num14 = num2 / num15;
							double num19 = num14 * num14;
							num20 = num14 * (1.0 - num19 - num2 * num14) / num2;
							double num21 = (0.0 - num14) * (3.0 * num14 * num20 + num14 + 2.0 * num2 * num20) / num2;
							num11 = Math.Log(num14) / num2;
							double num22 = num11 * num11;
							double num23 = (0.0 - num11) / num2 + 1.0 / num5 - num18 / (num15 * num2);
							double num24 = num11 / num5 - num23 / num2 - 2.0 / num6 + num18 * (2.0 + num15) / num17;
							num12 = (0.0 - (-12.0 * num23 * num14 - 12.0 * num20 * num11 + num14 + 6.0 * num22 * num14)) / (12.0 * num14 * num2);
							double num25 = (0.0 - num12) / num2 - num12 * num20 / num14 + (12.0 * (num24 * num14 + 2.0 * num23 * num20 + num21 * num11) - num20 - 12.0 * num14 * num11 * num23 - 6.0 * num20 * num22) / (12.0 * num14 * num2);
							num13 = (6.0 * ((2.0 * num11 - num22 * num2) * num20 * num20 + num22 * (num21 * num14 * num2 + num11 * num19) - num23 * num23 * num19 * num2) + 12.0 * ((num25 * num2 - num11 * num23) * num19 + num20 * num23 * num14) + num11 * num19 - num14 * (num20 + 18.0 * num20 * num22)) / (12.0 * num19 * num5);
						}
						num2 += (num11 + (num12 + num13 / a) / a) / a;
						num = a * Inveta(num2 / num10);
					}
					Incgam(a, num, out var _, out num14, out var _);
					num20 = (0.0 - Math.Sqrt(a / (Math.PI * 2.0))) * Math.Exp(-0.5 * num2 * num2) / Gamstar(a);
					num2 = (num14 - num3) / num20;
					double num26 = num * num;
					double num27 = num * num26;
					double num28 = num * num27;
					num5 = num2 * num2;
					num6 = num2 * num5;
					num7 = num2 * num6;
					num12 = a * a;
					num13 = a * num12;
					double num29 = a * num13;
					num15 = 60.0 * (0.0 - num + a - 1.0);
					num16 = 20.0 * (2.0 * num26 - 4.0 * a * num + 4.0 * num + 2.0 * num12 - 3.0 * a + 1.0);
					num17 = 5.0 * (6.0 * a + 6.0 * num13 - 6.0 * num27 - 11.0 * num - 1.0 + 29.0 * a * num - 11.0 * num12 - 18.0 * num26 - 18.0 * num12 * num + 18.0 * a * num26);
					double num30 = 24.0 * num28 - 10.0 * a - 50.0 * num13 + 96.0 * num27 + 26.0 * num + 24.0 * num29 + 144.0 * num12 * num26 - 96.0 * num13 * num - 126.0 * a * num - 96.0 * a * num27 + 35.0 * num12 + 98.0 * num26 + 196.0 * num12 * num - 242.0 * a * num26 + 1.0;
					return num * (1.0 - num2 * (120.0 + num15 * num2 + num16 * num5 + num17 * num6 + num30 * num7) / 120.0);
				}

				private static double Inveta(double x)
				{
					if (x < -26.0)
					{
						return 0.0;
					}
					if (x == 0.0)
					{
						return 1.0;
					}
					double num = x * x;
					double num2 = x * (Math.PI * 2.0);
					double num8;
					double num9;
					if (num2 > 2.0)
					{
						double num3 = num + 1.0;
						double num4 = Math.Log(num3);
						double num5 = 1.0 / num4;
						double num6 = 1.0 / 3.0 + num5 * (num5 - 1.5);
						double num7 = num4 / num3;
						num8 = num + num4 + num7 * (1.0 + num7 * (num5 - 0.5 + num6 * num7));
						num9 = num8 + 1.0;
					}
					else if (num2 > -1.5)
					{
						num8 = num2 * (1.0 + num2 * (1.0 / 3.0 + num2 * (1.0 / 36.0 + num2 * (-1.0 / 270.0 + num2 * (0.0002314814814814815 + num2 / 17010.0)))));
						num9 = num8 + 1.0;
					}
					else
					{
						double num3 = Math.Exp(0.0 - num - 1.0);
						num9 = num3 * (1.0 + num3 * (1.0 + num3 * (1.5 + num3 * (2.6666666666666665 + num3 * 125.0 / 24.0))));
						num8 = num9 - 1.0;
					}
					bool flag = false;
					int num10 = 0;
					while (!flag)
					{
						flag = true;
						double num3 = Lnec(num8);
						double num11 = 0.0 - num3 - num;
						if (Math.Abs(num11) > 1E-18)
						{
							num11 = num11 * num9 / num8;
							num3 = num11 / num9 / num8;
							double num4 = num11 * (1.0 - num3 * (4.0 * num9 - 1.0) / 6.0) / (1.0 - num3 * (2.0 * num9 + 1.0) / 3.0);
							num8 -= num4;
							num9 -= num4;
							num10++;
							if (num9 <= 0.0 || num8 <= -1.0)
							{
								num9 = 0.0;
								num8 = -1.0;
							}
							else
							{
								flag = num10 > 5 || Math.Abs(num4) < 1E-10 * (Math.Abs(num8) + 1.0);
							}
						}
					}
					return num9;
				}
			}

			private static readonly double Tiny = 2.225073858507201E-308;

			private static readonly double Huge = double.MaxValue;

			private static readonly double TwoExp1Over4 = 1.189207115002721;

			private static readonly double MachTol = 2.220446049250313E-16;

			private static readonly double LnSqrt2Pi = 0.9189385332046728;

			private static readonly double Dwarf = Tiny * 10.0;

			private static readonly double Giant = Huge / 1000.0;

			private static readonly double ExpLow = -300.0;

			private static readonly double Epss = 1E-15;

			public static void Marcum(double mu, double x, double y, out double p, out double q, out int ierr)
			{
				ierr = 0;
				p = 0.0;
				q = 0.0;
				if (x > 10000.0 || y > 10000.0 || mu > 10000.0)
				{
					ierr = 2;
				}
				if (x < 0.0 || y < 0.0 || mu < 1.0)
				{
					ierr = 2;
				}
				ierr = 0;
				if (ierr == 0)
				{
					double num = 135.0;
					double num2 = 1.0 * Math.Sqrt(4.0 * x + 2.0 * mu);
					double num3 = 2.0 * Math.Sqrt(x * y);
					double num4 = x + mu - num2;
					double num5 = x + mu + num2;
					if (y > x + mu && x < 30.0)
					{
						Qser(mu, x, y, out p, out q, out ierr);
					}
					else if (y <= x + mu && x < 30.0)
					{
						Pser(mu, x, y, out p, out q, out ierr);
					}
					else if (mu * mu < 2.0 * num3 && num3 > 30.0)
					{
						PQasyxy(mu, x, y, out p, out q, out ierr);
					}
					else if (mu >= num && num4 <= y && y <= num5)
					{
						PQasymu(mu, x, y, out p, out q, out ierr);
					}
					else if (y <= num5 && y > x + mu && mu < num)
					{
						Qrec(mu, x, y, out p, out q, out ierr);
					}
					else if (y >= num4 && y <= x + mu && mu < num)
					{
						Prec(mu, x, y, out p, out q, out ierr);
					}
					else
					{
						MarcumPQtrap(mu, x, y, out p, out q, ref ierr);
					}
				}
				if (ierr == 0)
				{
					if (p < 1E-290)
					{
						p = 0.0;
						q = 1.0;
						ierr = 1;
					}
					if (q < 1E-290)
					{
						p = 1.0;
						q = 0.0;
						ierr = 1;
					}
				}
			}

			private static double Fc(double pnu, double z)
			{
				int num = 0;
				double num2 = 2.0 * pnu / z;
				double num3 = 1.0;
				double num4 = Dwarf;
				double num5 = num4;
				double num6 = 0.0;
				double num7 = 0.0;
				while (Math.Abs(num7 - 1.0) > Epss)
				{
					num6 = num2 + num3 * num6;
					if (Math.Abs(num6) < Dwarf)
					{
						num6 = Dwarf;
					}
					num5 = num2 + num3 / num5;
					if (Math.Abs(num5) < Dwarf)
					{
						num5 = Dwarf;
					}
					num6 = 1.0 / num6;
					num7 = num5 * num6;
					num4 *= num7;
					num++;
					num3 = 1.0;
					num2 = 2.0 * (pnu + (double)num) / z;
				}
				return num4;
			}

			private static double Factor(double x, int n)
			{
				double num = 1.0;
				for (int i = 1; i <= n; i++)
				{
					num *= x / (double)i;
				}
				return num;
			}

			private static double Pol(double[] fjkm, int d, double v)
			{
				double num = fjkm[d];
				int num2 = d;
				while (num2 > 0)
				{
					num2--;
					num = num * v + fjkm[num2];
				}
				return num;
			}

			private static void Fjkproc16(double u, double[,] fjk)
			{
				double[] array = new double[33];
				double[] array2 = new double[65];
				array2[1] = u;
				double v = (array2[2] = u * u);
				for (int i = 2; i <= 64; i++)
				{
					array2[i] = u * array2[i - 1];
				}
				fjk[0, 0] = 1.0;
				array[0] = 0.5;
				array[1] = 1.0 / 6.0;
				SetFjk16(fjk, 1, 0, array2, array, v);
				array[0] = -0.125;
				array[1] = 0.0;
				array[2] = 5.0 / 24.0;
				SetFjk16(fjk, 2, 0, array2, array, v);
				array[0] = 0.0625;
				array[1] = -13.0 / 240.0;
				array[2] = -0.3125;
				array[3] = 125.0 / 432.0;
				SetFjk16(fjk, 3, 0, array2, array, v);
				array[0] = -5.0 / 128.0;
				array[1] = 1.0 / 12.0;
				array[2] = 211.0 / 576.0;
				array[3] = -5.0 / 6.0;
				array[4] = 0.42390046296296297;
				SetFjk16(fjk, 4, 0, array2, array, v);
				array[0] = 7.0 / 256.0;
				array[1] = -0.10145089285714286;
				array[2] = -49.0 / 128.0;
				array[3] = 1.6061921296296295;
				array[4] = -1.7903645833333333;
				array[5] = 0.6414448302469136;
				SetFjk16(fjk, 5, 0, array2, array, v);
				array[0] = -0.0205078125;
				array[1] = 109.0 / 960.0;
				array[2] = 0.36983072916666665;
				array[3] = -2.576388888888889;
				array[4] = 4.6821108217592595;
				array[5] = -3.560763888888889;
				array[6] = 0.9919986175411523;
				SetFjk16(fjk, 6, 0, array2, array, v);
				array[0] = 0.01611328125;
				array[1] = -0.1219695560515873;
				array[2] = -0.33297526041666664;
				array[3] = 3.7101836350859787;
				array[4] = -9.712462625385802;
				array[5] = 11.698143727494855;
				array[6] = -6.8153513213734565;
				array[7] = 1.5583573120284637;
				SetFjk16(fjk, 7, 0, array2, array, v);
				array[0] = -0.013092041015625;
				array[1] = 0.12801339285714286;
				array[2] = 0.2764525204613095;
				array[3] = -4.973877728174603;
				array[4] = 17.501935105096727;
				array[5] = -29.549479166666668;
				array[6] = 26.907133829250256;
				array[7] = -12.754267939814815;
				array[8] = 2.477179842557763;
				SetFjk16(fjk, 8, 0, array2, array, v);
				array[0] = 0.0109100341796875;
				array[1] = -0.1324287403541554;
				array[2] = -0.20350690569196428;
				array[3] = 6.334938473979001;
				array[4] = -28.6621148111118;
				array[5] = 63.36748336442143;
				array[6] = -79.92548561881108;
				array[7] = 58.757341382271306;
				array[8] = -23.521455678429625;
				array[9] = 3.97431664548499;
				SetFjk16(fjk, 9, 0, array2, array, v);
				array[0] = -0.009273529052734375;
				array[1] = 0.1356906467013889;
				array[2] = 0.1166891125414467;
				array[3] = -7.762507595486111;
				array[4] = 43.78456262533557;
				array[5] = -121.31910738398369;
				array[6] = 198.2012198129542;
				array[7] = -200.43673900016432;
				array[8] = 123.80342757950794;
				array[9] = -42.937783937667895;
				array[10] = 6.423822498985321;
				SetFjk16(fjk, 10, 0, array2, array, v);
				array[0] = 0.008008956909179688;
				array[1] = -0.13811212730852318;
				array[2] = -0.018036238655211433;
				array[3] = 9.227585344579714;
				array[4] = -63.43318905865704;
				array[5] = 213.60596888977804;
				array[6] = -432.9618339664161;
				array[7] = 563.5828281072922;
				array[8] = -476.6485895149011;
				array[9] = 254.12602383553943;
				array[10] = -77.79724833536868;
				array[11] = 10.446593930548513;
				SetFjk16(fjk, 11, 0, array2, array, v);
				array[0] = -0.0070078372955322266;
				array[1] = 0.13990718736965074;
				array[2] = -0.09080249353478408;
				array[3] = -10.70304671940292;
				array[4] = 88.13905570591616;
				array[5] = -352.5536541489697;
				array[6] = 860.2674766949058;
				array[7] = -1381.388490707554;
				array[8] = 1497.526238137558;
				array[9] = -1089.5695395426785;
				array[10] = 511.32054028583485;
				array[11] = -140.15612725058884;
				array[12] = 17.07545069514774;
				SetFjk16(fjk, 12, 0, array2, array, v);
				array[0] = 0.006199240684509277;
				array[1] = -0.14122658948520403;
				array[2] = 0.20847570003254473;
				array[3] = 12.163573370672875;
				array[4] = -118.39689039212288;
				array[5] = 552.6748799175799;
				array[6] = -1587.5976792806462;
				array[7] = 3052.8623335041016;
				array[8] = -4067.0706975337407;
				array[9] = 3781.4312193762994;
				array[10] = -2415.530696666978;
				array[11] = 1012.7298787459738;
				array[12] = -251.37116645382358;
				array[13] = 28.031797071713953;
				SetFjk16(fjk, 13, 0, array2, array, v);
				array[0] = -0.005535036325454712;
				array[1] = 0.14217921713372686;
				array[2] = -0.33386405994128193;
				array[3] = -13.585546133738642;
				array[4] = 154.6628244201525;
				array[5] = -830.7106993008341;
				array[6] = 2761.029118256234;
				array[7] = -6219.835115705068;
				array[8] = 9888.192779923864;
				array[9] = -11266.694472611705;
				array[10] = 9175.501758192004;
				array[11] = -5225.742970325184;
				array[12] = 1980.4053574007653;
				array[13] = -449.2157029031175;
				array[14] = 46.18988866137692;
				SetFjk16(fjk, 14, 0, array2, array, v);
				array[0] = 0.004981532692909241;
				array[1] = -0.14284537645361756;
				array[2] = 0.4660314433955633;
				array[3] = 14.94692239017483;
				array[4] = -197.35300817536964;
				array[5] = 1205.6532423474202;
				array[6] = -4572.947346725032;
				array[7] = 11865.183572985043;
				array[8] = -22026.784993357214;
				array[9] = 29873.20668972799;
				array[10] = -29749.925047590506;
				array[11] = 21561.07641433711;
				array[12] = -11081.438701085532;
				array[13] = 3832.1051284527;
				array[14] = -800.4079199584038;
				array[15] = 76.35687905290095;
				SetFjk16(fjk, 15, 0, array2, array, v);
				array[0] = -0.004514514002948999;
				array[1] = 0.1432853705134875;
				array[2] = -0.6041880495336683;
				array[3] = -16.227111168548124;
				array[4] = 246.84286168977113;
				array[5] = -1698.752899088895;
				array[6] = 7270.238718007833;
				array[7] = -21434.839860240816;
				array[8] = 45694.86603568991;
				array[9] = -72195.53010755668;
				array[10] = 85409.02284280748;
				array[11] = -75563.23444486906;
				array[12] = 49344.50122776959;
				array[13] = -23110.149147008742;
				array[14] = 7349.790938468142;
				array[15] = -1422.6485707704092;
				array[16] = 126.58493346342459;
				SetFjk16(fjk, 16, 0, array2, array, v);
				array[0] = 0.125;
				array[1] = 0.0;
				array[2] = -5.0 / 24.0;
				SetFjk16(fjk, 0, 1, array2, array, v);
				array[0] = -0.0625;
				array[1] = 7.0 / 48.0;
				array[2] = 25.0 / 48.0;
				array[3] = -95.0 / 144.0;
				SetFjk16(fjk, 1, 1, array2, array, v);
				array[0] = 3.0 / 64.0;
				array[1] = -0.25;
				array[2] = -67.0 / 96.0;
				array[3] = 2.5;
				array[4] = -1.6059027777777777;
				SetFjk16(fjk, 2, 1, array2, array, v);
				array[0] = -5.0 / 128.0;
				array[1] = 219.0 / 640.0;
				array[2] = 35.0 / 48.0;
				array[3] = -5.671296296296297;
				array[4] = 8.1640625;
				array[5] = -3.5238233024691357;
				SetFjk16(fjk, 3, 1, array2, array, v);
				array[0] = 0.0341796875;
				array[1] = -41.0 / 96.0;
				array[2] = -0.5979817708333334;
				array[3] = 10.208333333333334;
				array[4] = -24.38530815972222;
				array[5] = 22.48263888888889;
				array[6] = -7.314875096450617;
				SetFjk16(fjk, 4, 1, array2, array, v);
				array[0] = -0.03076171875;
				array[1] = 0.5066545758928571;
				array[2] = 0.29326171875;
				array[3] = -16.04466300843254;
				array[4] = 56.15677445023148;
				array[5] = -82.37282383294753;
				array[6] = 56.160933883101855;
				array[7] = -14.66940546231996;
				SetFjk16(fjk, 5, 1, array2, array, v);
				array[0] = 0.0281982421875;
				array[1] = -149.0 / 256.0;
				array[2] = 0.19236328125;
				array[3] = 23.032335069444443;
				array[4] = -110.33599717881944;
				array[5] = 227.7450810185185;
				array[6] = -243.01300676761832;
				array[7] = 131.66775173611111;
				array[8] = -28.734679254811812;
				SetFjk16(fjk, 6, 1, array2, array, v);
				array[0] = -0.02618408203125;
				array[1] = 0.653960697234623;
				array[2] = -0.8638636997767857;
				array[3] = -30.956497628348213;
				array[4] = 194.5489077828759;
				array[5] = -527.7434874304178;
				array[6] = 780.7970272111304;
				array[7] = -656.2967227888696;
				array[8] = 295.2217849291892;
				array[9] = -55.33492825703911;
				SetFjk16(fjk, 7, 1, array2, array, v);
				array[0] = 0.024547576904296875;
				array[1] = -0.7229771205357143;
				array[2] = 1.72462398710705;
				array[3] = 39.54634114583333;
				array[4] = -316.99617299397784;
				array[5] = 1081.582459077381;
				array[6] = -2074.4037171674995;
				array[7] = 2398.8177766525205;
				array[8] = -1664.7533222350237;
				array[9] = 640.3728519643776;
				array[10] = -105.19241070496638;
				SetFjk16(fjk, 8, 1, array2, array, v);
				array[0] = -0.023183822631835938;
				array[1] = 0.7894818277070017;
				array[2] = -2.7769457196432445;
				array[3] = -48.48351172505462;
				array[4] = 486.2694474679452;
				array[5] = -2023.8687997794445;
				array[6] = 4819.5203340475455;
				array[7] = -7173.845552154039;
				array[8] = 6815.549754769387;
				array[9] = -4029.148885996514;
				array[10] = 1353.9765257894258;
				array[11] = -197.95866455017787;
				SetFjk16(fjk, 9, 1, array2, array, v);
				array[0] = 0.02202463150024414;
				array[1] = -0.8537870619032119;
				array[2] = 4.022369764937835;
				array[3] = 57.40872852466725;
				array[4] = -711.1778817448752;
				array[5] = 3529.7027186963924;
				array[6] = -10126.360073656459;
				array[7] = 18593.57183384303;
				array[8] = -22636.974191769863;
				array[9] = 18256.758136740547;
				array[10] = -9401.739096348214;
				array[11] = 2805.130952132437;
				array[12] = -369.5117338213376;
				SetFjk16(fjk, 10, 1, array2, array, v);
				array[0] = -0.02102351188659668;
				array[1] = 0.916142290844506;
				array[2] = -5.461889736566365;
				array[3] = -65.92709073089979;
				array[4] = 1000.5846459432155;
				array[5] = -5819.510495824431;
				array[6] = 19669.512303383908;
				array[7] = -43248.109984766954;
				array[8] = 64686.83321992556;
				array[9] = -66644.72159278701;
				array[10] = 46700.22487657625;
				array[11] = -21305.241783200054;
				array[12] = 5716.056438886386;
				array[13] = -685.1337664336446;
				SetFjk16(fjk, 11, 1, array2, array, v);
				array[0] = 0.02014753222465515;
				array[1] = -0.9767510426508916;
				array[2] = 7.096097773252087;
				array[3] = 73.61240444693182;
				array[4] = -1363.2529599857205;
				array[5] = 9163.574960565107;
				array[6] = -35864.83202751768;
				array[7] = 92376.94794688314;
				array[8] = -164834.83784046138;
				array[9] = 208040.7421486424;
				array[10] = -185789.855430546;
				array[11] = 115101.05980498683;
				array[12] = -47134.49774740617;
				array[13] = 11488.455724263406;
				array[14] = -1263.256478134231;
				SetFjk16(fjk, 12, 1, array2, array, v);
				array[0] = -0.01937262713909149;
				array[1] = 1.0357822247248984;
				array[2] = -8.925286740954556;
				array[3] = -80.01076084820852;
				array[4] = 1807.7010112763721;
				array[5] = -13886.23977992694;
				array[6] = 62074.02578469107;
				array[7] = -184145.36258906484;
				array[8] = 383582.0397373852;
				array[9] = -576038.1480224165;
				array[10] = 628833.5717748705;
				array[11] = -495573.34466362547;
				array[12] = 275136.2655603748;
				array[13] = -102207.94135045742;
				array[14] = 22823.518594320783;
				array[15] = -2318.166419436824;
				SetFjk16(fjk, 13, 1, array2, array, v);
				array[0] = 0.018680747598409653;
				array[1] = -1.0933780262877535;
				array[2] = 10.949523517716477;
				array[3] = 84.643531757175;
				array[4] = -2342.0651134541363;
				array[5] = 20369.770814493524;
				array[6] = -102837.36670370684;
				array[7] = 346648.70123159565;
				array[8] = -828961.7526173387;
				array[9] = 1449716.2069081753;
				array[10] = -1879301.2063630472;
				array[11] = 1807331.1927210535;
				array[12] = -1274496.047955376;
				array[13] = 641015.8873563296;
				array[14] = -217895.3569816474;
				array[15] = 44894.191761385744;
				array[16] = -4236.673416458739;
				SetFjk16(fjk, 14, 1, array2, array, v);
				array[0] = -0.018058056011795998;
				array[1] = 1.149659605823462;
				array[2] = -13.16870257489409;
				array[3] = -87.00990462122273;
				array[4] = 2973.9704746271364;
				array[5] = -29057.863221639334;
				array[6] = 164134.7779750923;
				array[7] = -621775.7100815779;
				array[8] = 1684395.4811437516;
				array[9] = -3374103.7733925395;
				array[10] = 5084254.010108815;
				array[11] = -5797111.742665044;
				array[12] = 4981685.58932215;
				array[13] = -3178510.065144025;
				array[14] = 1461172.7927229458;
				array[15] = -457795.0665375895;
				array[16] = 87552.17816265863;
				array[17] = -7715.531861979758;
				SetFjk16(fjk, 15, 1, array2, array, v);
				array[0] = 9.0 / 128.0;
				array[1] = 0.0;
				array[2] = -77.0 / 192.0;
				array[3] = 0.0;
				array[4] = 0.3342013888888889;
				SetFjk16(fjk, 0, 2, array2, array, v);
				array[0] = -27.0 / 256.0;
				array[1] = 39.0 / 256.0;
				array[2] = 1.4036458333333333;
				array[3] = -1.6710069444444444;
				array[4] = -1.8381076388888888;
				array[5] = 2.060908564814815;
				SetFjk16(fjk, 1, 2, array2, array, v);
				array[0] = 0.1318359375;
				array[1] = -27.0 / 64.0;
				array[2] = -2.8623046875;
				array[3] = 8.020833333333334;
				array[4] = 1.0777994791666667;
				array[5] = -14.036458333333334;
				array[6] = 8.090458622685185;
				SetFjk16(fjk, 2, 2, array2, array, v);
				array[0] = -0.15380859375;
				array[1] = 0.79892578125;
				array[2] = 4.59033203125;
				array[3] = -22.751985677083333;
				array[4] = 14.934624565972221;
				array[5] = 42.52666256751543;
				array[6] = -65.69146050347223;
				array[7] = 25.746658387988685;
				SetFjk16(fjk, 3, 2, array2, array, v);
				array[0] = 0.17303466796875;
				array[1] = -1.27734375;
				array[2] = -6.361572265625;
				array[3] = 50.011935763888886;
				array[4] = -73.55933973524306;
				array[5] = -70.02633101851852;
				array[6] = 271.3406605661651;
				array[7] = -242.71375868055554;
				array[8] = 72.41271847069508;
				SetFjk16(fjk, 4, 2, array2, array, v);
				array[0] = -0.190338134765625;
				array[1] = 1.8524126325334822;
				array[2] = 7.9220947265625;
				array[3] = -94.17471516927084;
				array[4] = 221.09830050998264;
				array[5] = 13.578712293836805;
				array[6] = -765.0372254171489;
				array[7] = 1204.5108913845486;
				array[8] = -777.2272500874084;
				array[9] = 187.66711848589946;
				SetFjk16(fjk, 5, 2, array2, array, v);
				array[0] = 0.20619964599609375;
				array[1] = -2.520263671875;
				array[2] = -8.997949523925781;
				array[3] = 159.65856119791667;
				array[4] = -527.0220052761501;
				array[5] = 337.2190755208333;
				array[6] = 1618.7873626708983;
				array[7] = -4211.0382245852625;
				array[8] = 4434.1363497656885;
				array[9] = -2259.276816285687;
				array[10] = 458.84770992088926;
				SetFjk16(fjk, 6, 2, array2, array, v);
				array[0] = -0.22092819213867188;
				array[1] = 3.277611323765346;
				array[2] = 9.300320979527065;
				array[3] = -250.77115683984505;
				array[4] = 1087.8174260457356;
				array[5] = -1404.302891126091;
				array[6] = -2563.9444452795965;
				array[7] = 11622.495969086322;
				array[8] = -17934.3441636147;
				array[9] = 14479.313178892271;
				array[10] = -6122.63974060247;
				array[11] = 1074.0188194633058;
				SetFjk16(fjk, 7, 2, array2, array, v);
				array[0] = 0.23473620414733887;
				array[1] = -4.121603393554688;
				array[2] = -8.529084409986224;
				array[3] = 371.57630452473956;
				array[4] = -2030.4431650042156;
				array[5] = 3928.249814860026;
				array[6] = 2472.6031768756443;
				array[7] = -26784.70619288315;
				array[8] = 57707.467479758205;
				array[9] = -65779.37528455863;
				array[10] = 43428.75542900036;
				array[11] = -15731.92148300192;
				array[12] = 2430.2098720207428;
				SetFjk16(fjk, 8, 2, array2, array, v);
				array[0] = -0.24777710437774658;
				array[1] = 5.0497246547178785;
				array[2] = 6.375349464870634;
				array[3] = -525.7776319562821;
				array[4] = 3515.3901490500366;
				array[5] = -9098.946585413438;
				array[6] = 1501.449934117588;
				array[7] = 52968.40256942741;
				array[8] = -156962.17039552;
				array[9] = 237710.55444046526;
				array[10] = -217889.7609136776;
				array[11] = 122183.02599420559;
				array[12] = -38765.36676500369;
				array[13] = 5352.021907283489;
				SetFjk16(fjk, 9, 2, array2, array, v);
				array[0] = 0.2601659595966339;
				array[1] = -6.059730052947998;
				array[2] = -2.523333628283066;
				array[3] = 716.616098673987;
				array[4] = -5739.353151810857;
				array[5] = 18710.056678357367;
				array[6] = -15227.052778022873;
				array[7] = -90410.69342927846;
				array[8] = 374173.78606362105;
				array[9] = -726678.8590896743;
				array[10] = 867690.6361348755;
				array[11] = -669330.9729636007;
				array[12] = 326923.4316409403;
				array[13] = -92347.97513678823;
				array[14] = 11528.702830431737;
				SetFjk16(fjk, 10, 2, array2, array, v);
				array[0] = -0.27199168503284454;
				array[1] = 7.149596092688454;
				array[2] = -3.3482232633271773;
				array[3] = -946.7788687505007;
				array[4] = 8937.522375551387;
				array[5] = -35337.290730230234;
				array[6] = 49459.110954680524;
				array[7] = 130172.10642681314;
				array[8] = -799759.4362203731;
				array[9] = 1951258.3781149474;
				array[10] = -2917568.5809228728;
				array[11] = 2902364.7717490215;
				array[12] = -1939009.9106363829;
				array[13] = 839993.2900731042;
				array[14] = -213947.07574365748;
				array[15] = 24380.364047003815;
				SetFjk16(fjk, 11, 2, array2, array, v);
				array[0] = 0.28332467190921307;
				array[1] = -8.317484202323023;
				array[2] = 11.564968830087189;
				array[3] = 1218.3176746274855;
				array[4] = -13385.506466376133;
				array[5] = 62540.30144463991;
				array[6] = -122382.9136567534;
				array[7] = -143089.29056273054;
				array[8] = 1554707.5273250397;
				array[9] = -4718379.120243579;
				array[10] = 8605382.388217239;
				array[11] = -10599895.885891961;
				array[12] = 9077838.649203368;
				array[13] = -5358306.803673643;
				array[14] = 2087192.8797093735;
				array[15] = -484205.518878133;
				array[16] = 50761.44498958965;
				SetFjk16(fjk, 12, 2, array2, array, v);
				array[0] = -0.29422177467495203;
				array[1] = 9.561712386364025;
				array[2] = -22.456083202924763;
				array[3] = -1532.575201032898;
				array[4] = 19400.899387993297;
				array[5] = -105087.87893355958;
				array[6] = 262967.9235373233;
				array[7] = 61613.709412718184;
				array[8] = -2770349.5737553267;
				array[9] = 10454840.708341906;
				array[10] = -22841191.197018135;
				array[11] = 33883152.51340366;
				array[12] = -35702419.89131143;
				array[13] = 26908321.88726064;
				array[14] = -14241918.449935481;
				array[15] = 5042187.177232684;
				array[16] = -1074259.7908211057;
				array[17] = 104287.72699173732;
				SetFjk16(fjk, 13, 2, array2, array, v);
				array[0] = 0.30472969519905746;
				array[1] = -10.880732823367957;
				array[2] = 36.35359856684998;
				array[3] = 1890.1183163422475;
				array[4] = -27344.50396662656;
				array[5] = 169206.00701162635;
				array[6] = -515265.5792942078;
				array[7] = 248217.1837675576;
				array[8] = 4532205.969091296;
				array[9] = -21492951.40502682;
				array[10] = 55557247.108151935;
				array[11] = -97285892.16088973;
				array[12] = 122607925.7674121;
				array[13] = -113234217.41453911;
				array[14] = 76312885.3308721;
				array[15] = -36634431.269047916;
				array[16] = 11891540.51964304;
				array[17] = -2342835.9225964453;
				array[18] = 211794.47349942484;
				SetFjk16(fjk, 14, 2, array2, array, v);
				array[0] = 0.0732421875;
				array[1] = 0.0;
				array[2] = -0.8912109375;
				array[3] = 0.0;
				array[4] = 1.8464626736111112;
				array[5] = 0.0;
				array[6] = -1.0258125964506173;
				SetFjk16(fjk, 0, 3, array2, array, v);
				array[0] = -0.18310546875;
				array[1] = 0.23193359375;
				array[2] = 4.01044921875;
				array[3] = -4.60458984375;
				array[4] = -12.002007378472221;
				array[5] = 13.232982494212964;
				array[6] = 8.719407069830247;
				array[7] = -9.403282134130658;
				SetFjk16(fjk, 1, 3, array2, array, v);
				array[0] = 0.3204345703125;
				array[1] = -225.0 / 256.0;
				array[2] = -10.46416015625;
				array[3] = 26.736328125;
				array[4] = 29.225667317708332;
				array[5] = -103.40190972222223;
				array[6] = 17.13107036072531;
				array[7] = 92.32313368055556;
				array[8] = -50.99143448189943;
				SetFjk16(fjk, 2, 3, array2, array, v);
				array[0] = -0.48065185546875;
				array[1] = 2.11090087890625;
				array[2] = 21.0254150390625;
				array[3] = -89.87633409288195;
				array[4] = -15.28445095486111;
				array[5] = 411.04911024305557;
				array[6] = -389.3215256679205;
				array[7] = -293.92095419801313;
				array[8] = 567.7231588481385;
				array[9] = -213.0247079633827;
				SetFjk16(fjk, 3, 3, array2, array, v);
				array[0] = 0.6608963012695312;
				array[1] = -4.08935546875;
				array[2] = -36.04327646891276;
				array[3] = 229.6779296875;
				array[4] = -150.64704827202692;
				array[5] = -1115.023654513889;
				array[6] = 2175.9328758333936;
				array[7] = -176.7817041216564;
				array[8] = -2817.564374455372;
				array[9] = 2651.5545930587705;
				array[10] = -757.6768784769387;
				SetFjk16(fjk, 4, 3, array2, array, v);
				array[0] = -0.8591651916503906;
				array[1] = 6.969002314976284;
				array[2] = 55.378133392333986;
				array[3] = -495.0305846610902;
				array[4] = 733.5599177042643;
				array[5] = 2262.8678469622578;
				array[6] = -7898.558874040768;
				array[7] = 5695.140700031799;
				array[8] = 7718.792330973433;
				array[9] = -16089.784052072184;
				array[10] = 10424.89664595804;
				array[11] = -2413.3719004256172;
				SetFjk16(fjk, 5, 3, array2, array, v);
				array[0] = 1.0739564895629883;
				array[1] = -10.898971557617188;
				array[2] = -78.3541690826416;
				array[3] = 948.6580297851563;
				array[4] = -2219.4645106141834;
				array[5] = -3394.087506103516;
				array[6] = 22215.58137123579;
				array[7] = -30531.682191548916;
				array[8] = -6945.09541692773;
				array[9] = 63170.2367433357;
				array[10] = -72433.4733597442;
				array[11] = 36368.490166893054;
				array[12] = -7090.98414263977;
				SetFjk16(fjk, 6, 3, array2, array, v);
				array[0] = -1.3040900230407715;
				array[1] = 16.02356831232707;
				array[2] = 103.7233241308303;
				array[3] = -1667.315650667463;
				array[4] = 5406.656197744804;
				array[5] = 2872.9832533515446;
				array[6] = -52104.15788249263;
				array[7] = 110439.4425121051;
				array[8] = -46659.13728281303;
				array[9] = -173333.53977304077;
				array[10] = 339551.8623595128;
				array[11] = -281181.85781749483;
				array[12] = 116143.52270798283;
				array[13] = -19586.90142650334;
				SetFjk16(fjk, 7, 3, array2, array, v);
				array[0] = 1.5486069023609161;
				array[1] = -22.48286247253418;
				array[2] = -129.63729095714433;
				array[3] = 2741.638566981724;
				array[4] = -11510.430102675971;
				array[5] = 3157.633145077418;
				array[6] = 105738.58606273177;
				array[7] = -320687.7822228627;
				array[8] = 312110.0413375543;
				array[9] = 306706.99777237116;
				array[10] = -1199602.262675182;
				array[11] = 1489876.75818079;
				array[12] = -983301.0381246094;
				array[13] = 346445.2252546859;
				array[14] = -51524.795648340965;
				SetFjk16(fjk, 8, 3, array2, array, v);
				array[0] = -1.8067080527544022;
				array[1] = 30.41315558507587;
				array[2] = 153.62532423010893;
				array[3] = -4275.681855774877;
				array[4] = 22280.234407631844;
				array[5] = -22294.3603921321;
				array[6] = -188892.0765865273;
				array[7] = 800265.5772968673;
				array[8] = -1211192.8548070344;
				array[9] = -77428.4081847135;
				array[10] = 3343683.837970314;
				array[11] = -6075462.155411939;
				array[12] = 5742939.802563024;
				array[13] = -3178262.5289756646;
				array[14] = 978732.9806555888;
				array[15] = -130276.59845140693;
				SetFjk16(fjk, 9, 3, array2, array, v);
				array[0] = 2.0777142606675625;
				array[1] = -39.94736075401306;
				array[2] = -172.57638879468382;
				array[3] = 6386.186955562886;
				array[4] = -40128.23395013386;
				array[5] = 67957.94781470392;
				array[6] = 297268.90885718167;
				array[7] = -1779345.5277624794;
				array[8] = 3703482.95152391;
				array[9] = -1986101.2546910897;
				array[10] = -7335848.9571808;
				array[11] = 20236466.14831126;
				array[12] = -26009069.048248406;
				array[13] = 20168378.697199374;
				array[14] = -9655403.793821568;
				array[15] = 2644939.50994817;
				array[16] = -318773.08892039495;
				SetFjk16(fjk, 10, 3, array2, array, v);
				array[0] = -2.3610389325767756;
				array[1] = 51.215318048867836;
				array[2] = 182.7246220662577;
				array[3] = -9201.602610035008;
				array[4] = 68268.2562703701;
				array[5] = -162141.74207057405;
				array[6] = -402709.29424480087;
				array[7] = 3603004.6646962552;
				array[8] = -9740822.743691595;
				array[9] = 10107345.07482204;
				array[10] = 11498843.003383758;
				array[11] = -56841651.345428295;
				array[12] = 97219891.2514146;
				array[13] = -99519441.57239148;
				array[14] = 65942266.170395136;
				array[15] = -27893470.5277172;
				array[16] = 6888375.143118141;
				array[17] = -758786.3148474953;
				SetFjk16(fjk, 11, 3, array2, array, v);
				array[0] = 2.6561687991488725;
				array[1] = -64.3440605080747;
				array[2] = -179.63738093291838;
				array[3] = 12860.884276726403;
				array[4] = -110864.10416322605;
				array[5] = 338921.6696086328;
				array[6] = 430704.4637247086;
				array[7] = -6738355.617335457;
				array[8] = 22959038.837731227;
				array[9] = -34599901.8185986;
				array[10] = -5491093.148263638;
				array[11] = 136348100.13563344;
				array[12] = -311391327.48073316;
				array[13] = 406747852.8749038;
				array[14] = -350465400.6563456;
				array[15] = 203621539.6441128;
				array[16] = -77285292.82552329;
				array[17] = 17387623.032021545;
				array[18] = -1764164.565777261;
				SetFjk16(fjk, 12, 3, array2, array, v);
				array[0] = -2.962649814435281;
				array[1] = 79.45804137006725;
				array[2] = 158.20533868869907;
				array[3] = -17512.09240449678;
				array[4] = 173186.23779115768;
				array[5] = -648825.9023813056;
				array[6] = -226118.57798798103;
				array[7] = 11744385.639221318;
				array[8] = -49655262.44094926;
				array[9] = 97992370.80614321;
				array[10] = -45563229.25283381;
				array[11] = -276725901.5587914;
				array[12] = 874903955.44068;
				array[13] = -1431639430.0141678;
				array[14] = 1544324559.7308984;
				array[15] = -1156507831.0309398;
				array[16] = 599846625.3339608;
				array[17] = -206711172.70469868;
				array[18] = 42729154.354849584;
				array[19] = -4019188.669120067;
				SetFjk16(fjk, 13, 3, array2, array, v);
				array[0] = 0.112152099609375;
				array[1] = 0.0;
				array[2] = -2.3640869140625;
				array[3] = 0.0;
				array[4] = 8.78912353515625;
				array[5] = 0.0;
				array[6] = -11.207002616222994;
				array[7] = 0.0;
				array[8] = 4.669584423426247;
				SetFjk16(fjk, 0, 4, array2, array, v);
				array[0] = -0.3925323486328125;
				array[1] = 0.4673004150390625;
				array[2] = 13.00247802734375;
				array[3] = -14.578535970052084;
				array[4] = -65.91842651367188;
				array[5] = 71.77784220377605;
				array[6] = 106.46652485411845;
				array[7] = -113.93785993160044;
				array[8] = -53.700220869401846;
				array[9] = 56.81327715168601;
				SetFjk16(fjk, 1, 4, array2, array, v);
				array[0] = 0.8831977844238281;
				array[1] = -2.2430419921875;
				array[2] = -40.88886337280273;
				array[3] = 99.291650390625;
				array[4] = 222.9227086385091;
				array[5] = -632.81689453125;
				array[6] = -205.55324667471427;
				array[7] = 1232.7702877845293;
				array[8] = -339.1285687513312;
				array[9] = -728.4551700544946;
				array[10] = 393.2179216560186;
				SetFjk16(fjk, 2, 4, array2, array, v);
				array[0] = -1.6191959381103516;
				array[1] = 6.517438888549805;
				array[2] = 97.29213905334473;
				array[3] = -384.7201304711236;
				array[4] = -422.4613227844238;
				array[5] = 2925.81622249462;
				array[6] = -1437.2810672241965;
				array[7] = -5929.61635756316;
				array[8] = 6678.964970631854;
				array[9] = 1992.7516382310725;
				array[10] = -5560.599501221268;
				array[11] = 2034.9551693024277;
				SetFjk16(fjk, 3, 4, array2, array, v);
				array[0] = 2.6311933994293213;
				array[1] = -14.813423156738281;
				array[2] = -194.76567316055298;
				array[3] = 1116.295762125651;
				array[4] = 214.74175742997065;
				array[5] = -9500.200790405273;
				array[6] = 12733.852428636434;
				array[7] = 15619.117721871584;
				array[8] = -43856.44219541648;
				array[9] = 16041.189890575017;
				array[10] = 30538.376827393702;
				array[11] = -31457.433732481488;
				array[12] = 8757.450232923149;
				SetFjk16(fjk, 4, 4, array2, array, v);
				array[0] = -3.946790099143982;
				array[1] = 28.973631262779236;
				array[2] = 345.9624051570892;
				array[3] = -2698.264002605166;
				array[4] = 1749.166319439676;
				array[5] = 24230.291604531834;
				array[6] = -57186.68270652559;
				array[7] = -12268.269917924905;
				array[8] = 179642.68522044024;
				array[9] = -184075.59647969634;
				array[10] = -55836.464134952716;
				array[11] = 219854.46366368397;
				array[12] = -146898.326284019;
				array[13] = 33116.007471226345;
				SetFjk16(fjk, 5, 4, array2, array, v);
				array[0] = 5.591285973787308;
				array[1] = -51.149418354034424;
				array[2] = -562.3207324802876;
				array[3] = 5740.379038238525;
				array[4] = -8505.888519568523;
				array[5] = -51098.161945523156;
				array[6] = 189688.56368664134;
				array[7] = -98986.67611350543;
				array[8] = -524313.3332072016;
				array[9] = 1006412.2572891519;
				array[10] = -338656.53584266576;
				array[11] = -879242.3031416284;
				array[12] = 1184856.1356540793;
				array[13] = -599009.5959319434;
				array[14] = 113723.03789882673;
				SetFjk16(fjk, 6, 4, array2, array, v);
				array[0] = -7.588173821568489;
				array[1] = 83.79132223625977;
				array[2] = 852.651491996646;
				array[3] = -11106.11406304718;
				array[4] = 25906.550896742894;
				array[5] = 90628.03856082648;
				array[6] = -518627.0052655401;
				array[7] = 625235.1381343907;
				array[8] = 1093177.6471805288;
				array[9] = -3890056.269906493;
				array[10] = 3443257.530483528;
				array[11] = 1688397.8063561004;
				array[12] = -6072278.753811017;
				array[13] = 5368522.305391169;
				array[14] = -2206353.997770455;
				array[15] = 362368.2691728461;
				SetFjk16(fjk, 7, 4, array2, array, v);
				array[0] = 9.959478140808642;
				array[1] = -129.64064240455627;
				array[2] = -1221.6473410353065;
				array[3] = 19961.318612462794;
				array[4] = -64135.37720635896;
				array[5] = -132491.34865988838;
				array[6] = 1231383.3446542423;
				array[7] = -2354589.943537212;
				array[8] = -1264272.3547066583;
				array[9] = 11829877.236705665;
				array[10] = -17640228.8499216;
				array[11] = 3679036.5985685345;
				array[12] = 21328290.4639577;
				array[13] = -31765842.068457924;
				array[14] = 21552604.86205348;
				array[15] = -7505720.501322565;
				array[16] = 1087467.9477654193;
				SetFjk16(fjk, 8, 4, array2, array, v);
				array[0] = -12.72599984658882;
				array[1] = 191.72191139924425;
				array[2] = 1668.3300609576206;
				array[3] = -33822.37603736715;
				array[4] = 139670.53397437636;
				array[5] = 142413.44221576978;
				array[6] = -2615894.948837068;
				array[7] = 7028008.741102099;
				array[8] = -1692308.6869349768;
				array[9] = -29470781.81274997;
				array[10] = 66963160.30704782;
				array[11] = -48089009.18054011;
				array[12] = -47220345.65200829;
				array[13] = 138176622.72569343;
				array[14] = -141477318.49446413;
				array[15] = 78991076.06628808;
				array[16] = -23950277.790642798;
				array[17] = 3106959.7999206283;
				SetFjk16(fjk, 9, 4, array2, array, v);
				array[0] = 15.907499808236025;
				array[1] = -273.33609867841005;
				array[2] = -2184.4474298407245;
				array[3] = 54603.014533953545;
				array[4] = -277734.45331034885;
				array[5] = -41109.66279696009;
				array[6] = 5064705.805434759;
				array[7] = -18090940.629099194;
				array[8] = 15917528.891696546;
				array[9] = 60220437.63786092;
				array[10] = -208561974.26419502;
				array[11] = 250941409.40257928;
				array[12] = 12084648.536915455;
				array[13] = -458976381.3174162;
				array[14] = 699975914.260747;
				array[15] = -563757375.3416687;
				array[16] = 269426949.8534435;
				array[17] = -72497863.1843613;
				array[18] = 8519623.32566494;
				SetFjk16(fjk, 10, 4, array2, array, v);
				array[0] = -19.522840673744213;
				array[1] = 378.054427030434;
				array[2] = 2752.8286152184837;
				array[3] = -84659.00931676825;
				array[4] = 515277.57789757004;
				array[5] = -327436.1285876312;
				array[6] = -9039645.402186435;
				array[7] = 41795541.14558163;
				array[8] = -61523469.344794095;
				array[9] = -95072522.33600353;
				array[10] = 557312492.7699198;
				array[11] = -963898631.1721574;
				array[12] = 480963077.0527874;
				array[13] = 1131925258.235356;
				array[14] = -2762861092.1224475;
				array[15] = 3066633312.6192083;
				array[16] = -2065683582.7903266;
				array[17] = 866733914.7176133;
				array[18] = -209952808.47963646;
				array[19] = 22561861.30689057;
				SetFjk16(fjk, 11, 4, array2, array, v);
				array[0] = 23.590099147440924;
				array[1] = -509.7127086587716;
				array[2] = -3345.7051051560484;
				array[3] = 126830.08496875773;
				array[4] = -904536.1779632089;
				array[5] = 1241459.92395682;
				array[6] = 14964746.535519589;
				array[7] = -88697323.8770979;
				array[8] = 182496348.04247934;
				array[9] = 82548357.3736754;
				array[10] = -1305701152.6740456;
				array[11] = 3075905875.9322224;
				array[12] = -2915784132.1314454;
				array[13] = -1631935529.3260648;
				array[14] = 8923557290.446716;
				array[15] = -13522339111.332256;
				array[16] = 12138202400.912394;
				array[17] = -7081644626.242289;
				array[18] = 2655510812.919567;
				array[19] = -585530475.8366086;
				array[20] = 57986597.25398542;
				SetFjk16(fjk, 12, 4, array2, array, v);
				array[0] = 0.22710800170898438;
				array[1] = 0.0;
				array[2] = -7.368794359479632;
				array[3] = 0.0;
				array[4] = 42.53499874538846;
				array[5] = 0.0;
				array[6] = -91.81824154324002;
				array[7] = 0.0;
				array[8] = 84.63621767460073;
				array[9] = 0.0;
				array[10] = -28.212072558200244;
				SetFjk16(fjk, 0, 5, array2, array, v);
				array[0] = -1.0219860076904297;
				array[1] = 1.173391342163086;
				array[2] = 47.89716333661761;
				array[3] = -52.809692909604024;
				array[4] = -361.54748933580186;
				array[5] = 389.90415516606083;
				array[6] = 964.0915362040201;
				array[7] = -1025.3036972328468;
				array[8] = -1057.9527209325092;
				array[9] = 1114.3768660489097;
				array[10] = 409.07505209390354;
				array[11] = -427.88310046603704;
				SetFjk16(fjk, 1, 5, array2, array, v);
				array[0] = 2.8104615211486816;
				array[1] = -6.813240051269531;
				array[2] = -175.5926583153861;
				array[3] = 412.65248413085936;
				array[4] = 1483.698386529892;
				array[5] = -3828.149887084961;
				array[6] = -3429.1824372044316;
				array[7] = 12120.007883707682;
				array[8] = 557.0477956312674;
				array[9] = -15403.791616777333;
				array[10] = 5099.332114894694;
				array[11] = 6770.897413968059;
				array[12] = -3602.916766286823;
				SetFjk16(fjk, 2, 5, array2, array, v);
				array[0] = -6.0893332958221436;
				array[1] = 23.21895432472229;
				array[2] = 480.30594648633684;
				array[3] = -1808.5316684886388;
				array[4] = -3878.5356589824432;
				array[5] = 19896.567837257637;
				array[6] = -442.43697992960614;
				array[7] = -68889.99079285296;
				array[8] = 51994.29193359834;
				array[9] = 82310.6869110698;
				array[10] = -107791.27622674359;
				array[11] = -11421.030640241632;
				array[12] = 61775.6226297841;
				array[13] = -22242.80290037086;
				SetFjk16(fjk, 3, 5, array2, array, v);
				array[0] = 11.41749992966652;
				array[1] = -60.54320812225342;
				array[2] = -1092.4312783437115;
				array[3] = 5864.8337360927035;
				array[4] = 6502.6598836863795;
				array[5] = -73117.67362073364;
				array[6] = 62464.98649007569;
				array[7] = 248344.19895160815;
				array[8] = -446788.55343178427;
				array[9] = -141685.28980603762;
				array[10] = 805685.0085562568;
				array[11] = -411181.5535115825;
				array[12] = -353321.8498176741;
				array[13] = 410732.5113566978;
				array[14] = -112357.72180097661;
				SetFjk16(fjk, 4, 5, array2, array, v);
				array[0] = -19.409749880433083;
				array[1] = 133.60695303976536;
				array[2] = 2184.1347855359318;
				array[3] = -15685.927751365061;
				array[4] = -3330.0494749048685;
				array[5] = 213065.39140775686;
				array[6] = -371035.73548135295;
				array[7] = -595658.1035199931;
				array[8] = 2217706.3121620207;
				array[9] = -928359.7615083011;
				array[10] = -3462387.4565158784;
				array[11] = 4492508.583156209;
				array[12] = -105953.60990151919;
				array[13] = -3174045.4228780973;
				array[14] = 2222890.114855813;
				array[15] = -492012.66653936007;
				SetFjk16(fjk, 5, 5, array2, array, v);
				array[0] = 30.73210397735238;
				array[1] = -262.68730902671814;
				array[2] = -3966.703098702431;
				array[3] = 36616.605837684016;
				array[4] = -23288.02092194995;
				array[5] = -522073.1921054033;
				array[6] = 1445873.6105443314;
				array[7] = 729826.9199335962;
				array[8] = -8027322.740477521;
				array[9] = 9022069.972241307;
				array[10] = 8528377.766971355;
				array[11] = -26111911.326974582;
				array[12] = 15072848.600502055;
				array[13] = 11547035.062352154;
				array[14] = -20141460.694713123;
				array[15] = 10381853.494410237;
				array[16] = -1934247.3992962518;
				SetFjk16(fjk, 6, 5, array2, array, v);
				array[0] = -46.09815596602857;
				array[1] = 474.2817955557257;
				array[2] = 6683.698617373726;
				array[3] = -77185.9281083402;
				array[4] = 113831.12007369411;
				array[5] = 1111273.3131467255;
				array[6] = -4487654.882212431;
				array[7] = 1363280.0193113291;
				array[8] = 22934079.022569533;
				array[9] = -45086888.89143024;
				array[10] = -1310272.8912292086;
				array[11] = 103829405.25391139;
				array[12] = -124354846.65650934;
				array[13] = 7129538.37621234;
				array[14] = 107358912.4192952;
				array[15] = -104902766.60439073;
				array[16] = 43358616.23878111;
				array[17] = -6986431.791678039;
				SetFjk16(fjk, 7, 5, array2, array, v);
				array[0] = 66.26609920116607;
				array[1] = -801.8515903651714;
				array[2] = -10599.673972529736;
				array[3] = 150238.26124378282;
				array[4] = -349014.85897753894;
				array[5] = -2089251.7495501186;
				array[6] = 11932847.810754979;
				array[7] = -12233248.98935502;
				array[8] = -52996346.81033538;
				array[9] = 167552806.49381;
				array[10] = -104151238.67453538;
				array[11] = -295472139.386798;
				array[12] = 638921130.0502791;
				array[13] = -364575119.5506925;
				array[14] = -321938848.5018657;
				array[15] = 670099675.8740562;
				array[16] = -477068925.0747783;
				array[17] = 165792634.22539303;
				array[18] = -23563863.859185524;
				SetFjk16(fjk, 8, 5, array2, array, v);
				array[0] = -92.03624889050843;
				array[1] = 1286.5459820115675;
				array[2] = 15984.246642014752;
				array[3] = -274251.9413455901;
				array[4] = 875242.4878923426;
				array[5] = 3479369.5294348937;
				array[6] = -28243123.38238942;
				array[7] = 48978753.83393359;
				array[8] = 96403146.2551309;
				array[9] = -511553591.82361287;
				array[10] = 629980523.2038463;
				array[11] = 530948403.4101925;
				array[12] = -2455930387.019278;
				array[13] = 2650615136.5125113;
				array[14] = -13787083.107153494;
				array[15] = -2934135354.504286;
				array[16] = 3427343175.1586685;
				array[17] = -1959752975.9949665;
				array[18] = 590135160.4033043;
				array[19] = -75099321.778258;
				SetFjk16(fjk, 9, 5, array2, array, v);
				array[0] = 124.24893600218638;
				array[1] = -1977.9098049255554;
				array[2] = -23091.371137548784;
				array[3] = 474842.97883978905;
				array[4] = -1940160.8026042802;
				array[5] = -5051698.176475392;
				array[6] = 60910728.96112105;
				array[7] = -150451158.23316205;
				array[8] = -115862597.99920025;
				array[9] = 1340568362.9608934;
				array[10] = -2534626023.8559566;
				array[11] = 57223508.996001184;
				array[12] = 7462542511.136889;
				array[13] = -12803010436.906857;
				array[14] = 6529418551.99172;
				array[15] = 8333347633.630946;
				array[16] = -17879701023.37078;
				array[17] = 15384544080.383156;
				array[18] = -7429525037.630992;
				array[19] = 1979364564.1715841;
				array[20] = -228201703.20311713;
				SetFjk16(fjk, 10, 5, array2, array, v);
				array[0] = -163.7826883665184;
				array[1] = 2934.5753597465246;
				array[2] = 32133.674298098813;
				array[3] = -786448.5017351512;
				array[4] = 3940574.6676366506;
				array[5] = 6023482.021549257;
				array[6] = -121576300.80985078;
				array[7] = 396478314.8838899;
				array[8] = -28867608.104982562;
				array[9] = -3079357130.222696;
				array[10] = 8249384124.842691;
				array[11] = -5275292901.049003;
				array[12] = -17864885603.458946;
				array[13] = 48480263067.87549;
				array[14] = -46292296797.993835;
				array[15] = -6808810264.307432;
				array[16] = 70205428541.43004;
				array[17] = -89866265315.79846;
				array[18] = 62728346454.98143;
				array[19] = -26379975109.49727;
				array[20] = 6313975478.50704;
				array[21] = -665761463.932516;
				SetFjk16(fjk, 11, 5, array2, array, v);
				array[0] = 0.5725014209747314;
				array[1] = 0.0;
				array[2] = -26.491430486951554;
				array[3] = 0.0;
				array[4] = 218.1905117442116;
				array[5] = 0.0;
				array[6] = -699.5796273761325;
				array[7] = 0.0;
				array[8] = 1059.9904525279999;
				array[9] = 0.0;
				array[10] = -765.2524681411817;
				array[11] = 0.0;
				array[12] = 212.57013003921713;
				SetFjk16(fjk, 0, 6, array2, array, v);
				array[0] = -3.148757815361023;
				array[1] = 3.5304254293441772;
				array[2] = 198.68572865213667;
				array[3] = -216.34668231010437;
				array[4] = -2072.80986157001;
				array[5] = 2218.270202732818;
				array[6] = 8045.165714825524;
				array[7] = -8511.552133076279;
				array[8] = -14309.871109127998;
				array[9] = 15016.531410813332;
				array[10] = 11861.413256188316;
				array[11] = -12371.581568282436;
				array[12] = -3719.9772756862994;
				array[13] = 3861.6906957124443;
				SetFjk16(fjk, 1, 6, array2, array, v);
				array[0] = 10.233462899923325;
				array[1] = -24.04505968093872;
				array[2] = -830.5550415388176;
				array[3] = 1907.382995060512;
				array[4] = 9817.075505746376;
				array[5] = -24000.956291863276;
				array[6] = -37145.39865639345;
				array[7] = 109134.42187067667;
				array[8] = 44836.1310858795;
				array[9] = -222597.99503087997;
				array[10] = 21083.102663859052;
				array[11] = 208148.6713344014;
				array[12] = -75945.99320976129;
				array[13] = -72698.98447341226;
				array[14] = 38306.90885081725;
				SetFjk16(fjk, 2, 6, array2, array, v);
				array[0] = -25.58365724980831;
				array[1] = 94.00234790146351;
				array[2] = 2561.446454216327;
				array[3] = -9323.595824660999;
				array[4] = -30925.007683879998;
				array[5] = 137806.75057795568;
				array[6] = 66832.11490804658;
				array[7] = -695211.424089429;
				array[8] = 297044.2430620879;
				array[9] = 1456689.0310313085;
				array[10] = -1349408.441203692;
				array[11] = -1160751.910767026;
				array[12] = 1778986.1326650807;
				array[13] = 2732.4118798791033;
				array[14] = -771855.4278055248;
				array[15] = 274755.25810395356;
				SetFjk16(fjk, 3, 6, array2, array, v);
				array[0] = 54.36527165584266;
				array[1] = -276.5181863307953;
				array[2] = -6505.307639166713;
				array[3] = 33393.90900198902;
				array[4] = 70377.36768431832;
				array[5] = -559956.4224761113;
				array[6] = 214189.08434628605;
				array[7] = 2932546.143460969;
				array[8] = -3873550.933495049;
				array[9] = -5169809.562645506;
				array[10] = 12515387.720161637;
				array[11] = -485287.1010384119;
				array[12] = -14696506.049911873;
				array[13] = 8973612.611250544;
				array[14] = 4358025.711357972;
				array[15] = -5899263.963025857;
				array[16] = 1593568.945883017;
				SetFjk16(fjk, 4, 6, array2, array, v);
				array[0] = -103.29401614610106;
				array[1] = 679.4957387158647;
				array[2] = 14406.592158034444;
				array[3] = -97833.4854134274;
				array[4] = -109874.73447139263;
				array[5] = 1806898.478133067;
				array[6] = -2228617.568864937;
				array[7] = -9039218.069870703;
				array[8] = 22913970.35755808;
				array[9] = 6014580.774756414;
				array[10] = -67365551.08273101;
				array[11] = 49347945.00810039;
				array[12] = 61291772.21895597;
				array[13] = -101851641.61990358;
				array[14] = 18812228.43843536;
				array[15] = 48878028.30651433;
				array[16] = -36319210.680616364;
				array[17] = 7931540.865537214;
				SetFjk16(fjk, 5, 6, array2, array, v);
				array[0] = 180.76452825567685;
				array[1] = -1472.151622697711;
				array[2] = -28789.438034501905;
				array[3] = 248412.4928151497;
				array[4] = 57720.37443908062;
				array[5] = -4919773.7285477435;
				array[6] = 10556839.574755387;
				array[7] = 20546468.524262875;
				array[8] = -95782021.41390106;
				array[9] = 47859753.79401953;
				array[10] = 248947938.76422518;
				array[11] = -397302112.7750545;
				array[12] = -60373613.59319694;
				array[13] = 619895830.6794678;
				array[14] = -460542977.5769154;
				array[15] = -133881283.6228837;
				array[16] = 360816116.57296145;
				array[17] = -191228273.50596204;
				array[18] = 35131056.26464393;
				SetFjk16(fjk, 6, 6, array2, array, v);
				array[0] = -296.97029642004054;
				array[1] = 2903.8678610353963;
				array[2] = 53085.57401754476;
				array[3] = -566162.2156422413;
				array[4] = 351303.0507931015;
				array[5] = 11717363.296337798;
				array[6] = -37248885.40173167;
				array[7] = -29556393.543845627;
				array[8] = 317963019.1551406;
				array[9] = -391675101.1870579;
				array[10] = -632571201.8906721;
				array[11] = 2001265322.6458411;
				array[12] = -1008064787.2696644;
				array[13] = -2363398838.2753954;
				array[14] = 3743079200.591201;
				array[15] = -1091651847.4629543;
				array[16] = -1902208028.035804;
				array[17] = 2133928476.440911;
				array[18] = -893289789.9811288;
				array[19] = 141870657.61209;
				SetFjk16(fjk, 7, 6, array2, array, v);
				array[0] = 464.01608815631334;
				array[1] = -5325.306848096196;
				array[2] = -91725.50598115315;
				array[3] = 1185316.6466349284;
				array[4] = -1734253.4162956623;
				array[5] = -24965643.65768772;
				array[6] = 109865301.0696437;
				array[7] = -7842536.599009056;
				array[8] = -882004248.1653304;
				array[9] = 1812569161.1229405;
				array[10] = 796190115.1748242;
				array[11] = -7547640676.289125;
				array[12] = 8606208381.316284;
				array[13] = 4634326771.384026;
				array[14] = -19504767652.15116;
				array[15] = 15458811432.485826;
				array[16] = 3233232293.8508887;
				array[17] = -14292761227.388542;
				array[18] = 10872211035.524946;
				array[19] = -3794154076.5815444;
				array[20] = 531367092.46942383;
				SetFjk16(fjk, 8, 6, array2, array, v);
				array[0] = -696.02413223447;
				array[1] = 9211.732948445078;
				array[2] = 150176.80785295594;
				array[3] = -2316795.90169698;
				array[4] = 5353301.726709913;
				array[5] = 48240128.32064539;
				array[6] = -285088568.66606945;
				array[7] = 236539658.57255855;
				array[8] = 2091063546.042414;
				array[9] = -6478408107.947922;
				array[10] = 2114947617.4171696;
				array[11] = 22484222108.370438;
				array[12] = -43504182331.31258;
				array[13] = 9073306866.743038;
				array[14] = 72378013713.66345;
				array[15] = -104755002543.75143;
				array[16] = 35288894490.70863;
				array[17] = 58426452630.06238;
				array[18] = -83650899080.6256;
				array[19] = 49569134901.99425;
				array[20] = -14909719423.420584;
				array[21] = 1869289195.4875345;
				SetFjk16(fjk, 9, 6, array2, array, v);
				array[0] = 1009.2349917399815;
				array[1] = -15188.489623096204;
				array[2] = -234912.7446802936;
				array[3] = 4278033.8338822;
				array[4] = -13570280.995019535;
				array[5] = -85095459.3927672;
				array[6] = 669951675.0902301;
				array[7] = -1041016026.5703218;
				array[8] = -4241350570.52619;
				array[9] = 19536358548.670235;
				array[10] = -19158789931.456783;
				array[11] = -52588961930.56695;
				array[12] = 168223251386.27505;
				array[13] = -131543443714.17932;
				array[14] = -183278984759.32788;
				array[15] = 500731039137.68585;
				array[16] = -395175402811.80865;
				array[17] = -83866621459.66833;
				array[18] = 443918936157.0502;
				array[19] = -420471377306.8417;
				array[20] = 207052924562.9713;
				array[21] = -54907932888.50713;
				array[22] = 6236056730.263589;
				SetFjk16(fjk, 10, 6, array2, array, v);
				array[0] = 1.7277275025844574;
				array[1] = 0.0;
				array[2] = -108.09091978839466;
				array[3] = 0.0;
				array[4] = 1200.9029132163525;
				array[5] = 0.0;
				array[6] = -5305.646978613403;
				array[7] = 0.0;
				array[8] = 11655.393336864534;
				array[9] = 0.0;
				array[10] = -13586.550006434138;
				array[11] = 0.0;
				array[12] = 8061.722181737309;
				array[13] = 0.0;
				array[14] = -1919.457662318407;
				SetFjk16(fjk, 0, 7, array2, array, v);
				array[0] = -11.230228766798973;
				array[1] = 12.382047101855278;
				array[2] = 918.7728182013545;
				array[3] = -990.8334313936177;
				array[4] = -12609.480588771701;
				array[5] = 13410.082530915935;
				array[6] = 66320.58723266755;
				array[7] = -69857.68521840981;
				array[8] = -169003.20338453574;
				array[9] = 176773.46560911209;
				array[10] = 224178.07510616328;
				array[11] = -233235.7751104527;
				array[12] = -149141.86036214023;
				array[13] = 154516.34181663176;
				array[14] = 39348.88207752734;
				array[15] = -40628.52051907295;
				SetFjk16(fjk, 1, 7, array2, array, v);
				array[0] = 42.11335787549615;
				array[1] = -96.75274014472961;
				array[2] = -4309.387526895319;
				array[3] = 9728.18278095552;
				array[4] = 67131.49391428917;
				array[5] = -158519.18454455852;
				array[6] = -361549.21741861664;
				array[7] = 965627.7501076394;
				array[8] = 791368.9026948006;
				array[9] = -2797294.400847488;
				array[10] = -473067.2997835205;
				array[11] = 4157484.301968846;
				array[12] = -742925.2187595865;
				array[13] = -3063454.4290601774;
				array[14] = 1186992.6183777028;
				array[15] = 886789.4399911041;
				array[16] = -463948.9124628783;
				SetFjk16(fjk, 2, 7, array2, array, v);
				array[0] = -119.32118064723909;
				array[1] = 426.72709654457867;
				array[2] = 14774.672950860113;
				array[3] = -52455.44073722281;
				array[4] = -242280.570685599;
				array[5] = 994102.6739522996;
				array[6] = 1032233.4449197464;
				array[7] = -6741567.108560378;
				array[8] = 646495.8321529665;
				array[9] = 20680668.518424854;
				array[10] = -13425393.794712165;
				array[11] = -29950004.715897616;
				array[12] = 32133326.488920312;
				array[13] = 16877471.90592921;
				array[14] = -30879035.210339583;
				array[15] = 1961435.1350279427;
				array[16] = 10741165.11222991;
				array[17] = -3791244.349500207;
				SetFjk16(fjk, 3, 7, array2, array, v);
				array[0] = 283.38780403719284;
				array[1] = -1397.731549590826;
				array[2] = -41380.460209263256;
				array[3] = 205570.88069305534;
				array[4] = 656958.6927814606;
				array[5] = -4406726.3053560415;
				array[6] = -460386.1538930014;
				array[7] = 31745963.553354092;
				array[8] = -30185144.89950106;
				array[9] = -92885893.76184295;
				array[10] = 159671874.67639935;
				array[11] = 89037317.39194715;
				array[12] = -324112057.6206451;
				array[13] = 75417289.28844711;
				array[14] = 275169534.60077554;
				array[15] = -191141129.57979682;
				array[16] = -56632059.76142215;
				array[17] = 92789782.49257566;
				array[18] = -24828398.690560814;
				SetFjk16(fjk, 4, 7, array2, array, v);
				array[0] = -595.114388478105;
				array[1] = 3784.576488941093;
				array[2] = 100370.50080364884;
				array[3] = -654419.0938431186;
				array[4] = -1371381.6192330609;
				array[5] = 15498343.812751787;
				array[6] = -11665144.592299357;
				array[7] = -112601561.49426608;
				array[8] = 219262318.25667363;
				array[9] = 254104121.37964988;
				array[10] = -1006396481.7103226;
				array[11] = 253036623.9872969;
				array[12] = 1831393810.497864;
				array[13] = -1774529065.426649;
				array[14] = -1003472637.9292915;
				array[15] = 2290280875.9786744;
				array[16] = -651246794.1088722;
				array[17] = -803784902.9810971;
				array[18] = 640483342.2936913;
				array[19] = -138440607.21363136;
				SetFjk16(fjk, 5, 7, array2, array, v);
				array[0] = 1140.6359112497012;
				array[1] = -8957.26825843798;
				array[2] = -218407.3362912553;
				array[3] = 1794837.693023293;
				array[4] = 2046161.0563529024;
				array[5] = -45986041.82807991;
				array[6] = 74544641.81448273;
				array[7] = 314850611.4572535;
				array[8] = -1044136171.4521382;
				array[9] = -187106978.3335574;
				array[10] = 4438953626.095682;
				array[11] = -4408582954.0483055;
				array[12] = -6264272163.439719;
				array[13] = 14149702487.577581;
				array[14] = -2713149740.6519136;
				array[15] = -14233558941.890554;
				array[16] = 12753481214.719288;
				array[17] = 934842459.4043341;
				array[18] = -6845048171.934112;
				array[19] = 3754053882.012795;
				array[20] = -682202534.2837728;
				SetFjk16(fjk, 6, 7, array2, array, v);
				array[0] = -2036.8498415173235;
				array[1] = 19163.284363303756;
				array[2] = 436370.36938456364;
				array[3] = -4395730.580473922;
				array[4] = -1112960.9840974107;
				array[5] = 119491789.40923461;
				array[6] = -304912988.8434488;
				array[7] = -691963837.0133654;
				array[8] = 3885386169.73608;
				array[9] = -2313847981.3260245;
				array[10] = -14816925759.772211;
				array[11] = 28337891715.90571;
				array[12] = 7872387353.192413;
				array[13] = -72435569735.09131;
				array[14] = 59410896148.18937;
				array[15] = 46141874867.83198;
				array[16] = -105411711029.14682;
				array[17] = 45764643115.28315;
				array[18] = 33619493138.706043;
				array[19] = -45524891856.627266;
				array[20] = 19398990085.810093;
				array[21] = -3046176001.4829698;
				SetFjk16(fjk, 7, 7, array2, array, v);
				array[0] = 3437.1841075604834;
				array[1] = -37884.31644833955;
				array[2] = -813572.8279096411;
				array[3] = 9844700.119674265;
				array[4] = -5932665.573759617;
				array[5] = -278602941.80981755;
				array[6] = 999702331.7559991;
				array[7] = 1082145758.5676866;
				array[8] = -12097872233.934345;
				array[9] = 16269568192.896168;
				array[10] = 37442906272.62988;
				array[11] = -127678482632.39935;
				array[12] = 56533169829.379616;
				array[13] = 263705962704.22363;
				array[14] = -430880513772.40015;
				array[15] = 28685028305.645454;
				array[16] = 544657720548.1643;
				array[17] = -543385080747.8524;
				array[18] = 33319140131.86386;
				array[19] = 311025095335.0186;
				array[20] = -257492440682.7887;
				array[21] = 90635479554.8441;
				array[22] = -12545989968.390205;
				SetFjk16(fjk, 8, 7, array2, array, v);
				array[0] = -5537.685506625223;
				array[1] = 70275.28836444147;
				array[2] = 1432194.8403133915;
				array[3] = -20502591.084346145;
				array[4] = 29691158.739889488;
				array[5] = 592508323.2490427;
				array[6] = -2831998971.7799306;
				array[7] = -487772628.07968;
				array[8] = 32638786024.059948;
				array[9] = -70496897875.46951;
				array[10] = -62531875035.15364;
				array[11] = 456706039700.77563;
				array[12] = -503779673552.1839;
				array[13] = -650638245764.8473;
				array[14] = 2119375307389.9958;
				array[15] = -1373635599107.5234;
				array[16] = -1758554601545.7817;
				array[17] = 3640007756944.399;
				array[18] = -1912987782878.0613;
				array[19] = -1044942776057.9479;
				array[20] = 2082243082925.6113;
				array[21] = -1292209352199.4456;
				array[22] = 389815335189.77374;
				array[23] = -48292926381.68949;
				SetFjk16(fjk, 9, 7, array2, array, v);
				array[0] = 6.074042001273483;
				array[1] = 0.0;
				array[2] = -493.915304773088;
				array[3] = 0.0;
				array[4] = 7109.514302489364;
				array[5] = 0.0;
				array[6] = -41192.65496889755;
				array[7] = 0.0;
				array[8] = 122200.46498301746;
				array[9] = 0.0;
				array[10] = -203400.17728041555;
				array[11] = 0.0;
				array[12] = 192547.00123253153;
				array[13] = 0.0;
				array[14] = -96980.59838863752;
				array[15] = 0.0;
				array[16] = 20204.29133096615;
				SetFjk16(fjk, 0, 8, array2, array, v);
				array[0] = -45.55531500955112;
				array[1] = 49.604676343733445;
				array[2] = 4692.195395344336;
				array[3] = -5021.4722651930615;
				array[4] = -81759.41447862769;
				array[5] = 86499.09068028726;
				array[6] = 556100.842080117;
				array[7] = -583562.612059382;
				array[8] = -1894107.2072367705;
				array[9] = 1975574.1838921155;
				array[10] = 3559503.102407272;
				array[11] = -3695103.2205942157;
				array[12] = -3754666.524034365;
				array[13] = 3883031.1915227193;
				array[14] = 2085082.8653557065;
				array[15] = -2149736.597614798;
				array[16] = -474800.8462777045;
				array[17] = 488270.3738316819;
				SetFjk16(fjk, 1, 8, array2, array, v);
				array[0] = 193.61008879059227;
				array[1] = -437.3310240916908;
				array[2] = -24389.798720089893;
				array[3] = 54330.68352503968;
				array[4] = 481258.52318321;
				array[5] = -1109084.2311883408;
				array[6] = -3433050.7548587224;
				array[7] = 8650457.543468487;
				array[8] = 11004225.300068311;
				array[9] = -33238526.47538075;
				array[10] = -15303078.309507955;
				array[11] = 69562860.62990211;
				array[12] = 1830924.923944024;
				array[13] = -80869740.51766324;
				array[14] = 18943271.99449535;
				array[15] = 49072182.78465058;
				array[16] = -19806771.89902939;
				array[17] = -12122574.79857969;
				array[18] = 6307948.122622056;
				SetFjk16(fjk, 2, 8, array2, array, v);
				array[0] = -613.0986145035422;
				array[1] = 2147.8571771753195;
				array[2] = 91956.39909866106;
				array[3] = -320284.80771632295;
				array[4] = -1938565.2131506524;
				array[5] = 7533108.6348156;
				array[6] = 12364512.209251264;
				array[7] = -65358277.938386194;
				array[8] = -16530840.331176117;
				array[9] = 269292234.00676316;
				array[10] = -105780946.98529899;
				array[11] = -575008738.519056;
				array[12] = 462747211.13824445;
				array[13] = 619754381.8789831;
				array[14] = -755460241.9400861;
				array[15] = -252322946.06096464;
				array[16] = 569416784.9196941;
				array[17] = -61357261.82086586;
				array[18] = -164974352.55837953;
				array[19] = 57850732.22966805;
				SetFjk16(fjk, 3, 8, array2, array, v);
				array[0] = 1609.3838630717983;
				array[1] = -7751.996104125283;
				array[2] = -281313.5742689692;
				array[3] = 1362914.7891508336;
				array[4] = 5966457.108111073;
				array[5] = -36097318.95606442;
				array[6] = -22309783.293551423;
				array[7] = 336158425.1422515;
				array[8] = -205028522.0350672;
				array[9] = -1388339192.4100137;
				array[10] = 1836112835.6997824;
				array[11] = 2556726458.136804;
				array[12] = -5652778880.458099;
				array[13] = -1072688790.0156425;
				array[14] = 8223828086.676475;
				array[15] = -2962125430.617538;
				array[16] = -5363095697.458652;
				array[17] = 4151384158.228336;
				array[18] = 758617226.2906682;
				array[19] = -1589602926.9007583;
				array[20] = 422197436.2603177;
				SetFjk16(fjk, 4, 8, array2, array, v);
				array[0] = -3701.582885065136;
				array[1] = 22929.423816498227;
				array[2] = 740942.4546262622;
				array[3] = -4683368.479496754;
				array[4] = -14688082.295896811;
				array[5] = 136985890.98054215;
				array[6] = -37063877.251336545;
				array[7] = -1319571104.7402947;
				array[8] = 2005453574.1427636;
				array[9] = 4917316117.132459;
				array[10] = -13428166320.891447;
				array[11] = -3828355991.3598266;
				array[12] = 37778220592.815994;
				array[13] = -20635506272.06695;
				array[14] = -47082248514.737816;
				array[15] = 56649997707.122925;
				array[16] = 14169411429.388481;
				array[17] = -52510965464.20784;
				array[18] = 18673363121.781647;
				array[19] = 14082226269.939926;
				array[20] = -12159500780.523354;
				array[21] = 2607014902.95397;
				SetFjk16(fjk, 5, 8, array2, array, v);
				array[0] = 7711.631010552366;
				array[1] = -58858.32115449648;
				array[2] = -1741907.2159207466;
				array[3] = 13794087.929804008;
				array[4] = 28916480.06546469;
				array[5] = -437983696.2459598;
				array[6] = 494945307.5536342;
				array[7] = 4180226129.2961516;
				array[8] = -10954467146.581303;
				array[9] = -11060935369.012123;
				array[10] = 67274495072.65439;
				array[11] = -33385597946.54753;
				array[12] = -168738543918.6943;
				array[13] = 236353638119.121;
				array[14] = 123426482948.35286;
				array[15] = -460569493399.1512;
				array[16] = 183685386812.6055;
				array[17] = 323426896220.204;
				array[18] = -345059927788.03296;
				array[19] = 18066712637.598244;
				array[20] = 137638821647.93765;
				array[21] = -78528723144.41908;
				array[22] = 14147149999.27183;
				SetFjk16(fjk, 6, 8, array2, array, v);
				array[0] = -14872.431234636708;
				array[1] = 135739.2359106718;
				array[2] = 3743563.406669338;
				array[3] = -36117123.586437546;
				array[4] = -41857416.06405428;
				array[5] = 1225475415.8400152;
				array[6] = -2467842162.907412;
				array[7] = -10944143126.18331;
				array[8] = 45219896350.68711;
				array[9] = 3706147531.3941536;
				array[10] = -259638349679.498;
				array[11] = 331511238218.36096;
				array[12] = 503674442974.8522;
				array[13] = -1481164218255.801;
				array[14] = 369277357070.34485;
				array[15] = 2339646237464.701;
				array[16] = -2569885298111.3267;
				array[17] = -667794049596.5874;
				array[18] = 2906153064933.9253;
				array[19] = -1575977334606.5288;
				array[20] = -578377418663.531;
				array[21] = 1021516684285.5146;
				array[22] = -444821917816.5211;
				array[23] = 69214137882.70387;
				SetFjk16(fjk, 7, 8, array2, array, v);
				array[0] = 26956.281612779032;
				array[1] = -287752.7443175291;
				array[2] = -7479028.329331124;
				array[3] = 86134990.00981177;
				array[4] = 23679004.644932132;
				array[5] = -3077161905.388599;
				array[6] = 9103660424.390543;
				array[7] = 23518972784.280266;
				array[8] = -154703115855.8646;
				array[9] = 108277078595.12758;
				array[10] = 805587125662.5165;
				array[11] = -1805165807562.2092;
				array[12] = -672890155245.4949;
				array[13] = 6669143665397.138;
				array[14] = -6132703262892.643;
				array[15] = -7384886877294.082;
				array[16] = 17989877009001.984;
				array[17] = -6680625953666.217;
				array[18] = -14315112877022.322;
				array[19] = 17853687377733.207;
				array[20] = -3800827233430.3174;
				array[21] = -6918410846679.145;
				array[22] = 6365772360949.381;
				array[23] = -2267586042740.4272;
				array[24] = 310920009576.2226;
				SetFjk16(fjk, 8, 8, array2, array, v);
				array[0] = 24.380529699556064;
				array[1] = 0.0;
				array[2] = -2499.8304818112097;
				array[3] = 0.0;
				array[4] = 45218.76898136273;
				array[5] = 0.0;
				array[6] = -331645.1724845636;
				array[7] = 0.0;
				array[8] = 1268365.2733216248;
				array[9] = 0.0;
				array[10] = -2813563.226586534;
				array[11] = 0.0;
				array[12] = 3763271.297656404;
				array[13] = 0.0;
				array[14] = -2998015.9185381066;
				array[15] = 0.0;
				array[16] = 1311763.6146629772;
				array[17] = 0.0;
				array[18] = -242919.18790055133;
				SetFjk16(fjk, 0, 9, array2, array, v);
				array[0] = -207.23450244622654;
				array[1] = 223.48818891259725;
				array[2] = 26248.2200590177;
				array[3] = -27914.77371355851;
				array[4] = -565234.6122670341;
				array[5] = 595380.4582546093;
				array[6] = 4808855.001026172;
				array[7] = -5029951.782682547;
				array[8] = -20928027.009806808;
				array[9] = 21773603.858687893;
				array[10] = 52050919.69185088;
				array[11] = -53926628.50957524;
				array[12] = -77147061.60195628;
				array[13] = 79655909.13372722;
				array[14] = 67455358.1671074;
				array[15] = -69454035.44613281;
				array[16] = -32138208.55924294;
				array[17] = 33012717.635684926;
				array[18] = 6437358.47936461;
				array[19] = -6599304.604631645;
				SetFjk16(fjk, 1, 9, array2, array, v);
				array[0] = 984.3638866195761;
				array[1] = -2194.2476729600457;
				array[2] = -149715.34984220302;
				array[3] = 329977.62359907967;
				array[4] = 3636074.9553359346;
				array[5] = -8229815.954608016;
				array[6] = -32850375.70539885;
				array[7] = 79594841.39629526;
				array[8] = 140766384.09976012;
				array[9] = -388119773.6364172;
				array[10] = -302391232.5888283;
				array[11] = 1069154026.102883;
				array[12] = 267438889.51147762;
				array[13] = -1738631339.5172586;
				array[14] = 117013574.77418801;
				array[15] = 1654904787.033035;
				array[16] = -452792004.0990536;
				array[17] = -852646349.5309352;
				array[18] = 354479824.94387954;
				array[19] = 183646906.0528168;
				array[20] = -95153470.22721179;
				SetFjk16(fjk, 2, 9, array2, array, v);
				array[0] = -3445.2736031685163;
				array[1] = 11875.044917870855;
				array[2] = 615370.5061750343;
				array[3] = -2111012.288074303;
				array[4] = -16085470.193130488;
				array[5] = 60142798.465327084;
				array[6] = 138071565.42237887;
				array[7] = -645362876.5721123;
				array[8] = -403042168.77936625;
				array[9] = 3392353592.8461413;
				array[10] = -459521271.5412636;
				array[11] = -9731832243.412884;
				array[12] = 5664098916.139917;
				array[13] = 15628587453.068138;
				array[14] = -14586127233.110453;
				array[15] = -13112286301.064476;
				array[16] = 18076138583.501;
				array[17] = 3815036344.9012046;
				array[18] = -11188129037.135693;
				array[19] = 1563031125.3210442;
				array[20] = 2774182673.1720276;
				array[21] = -967769239.0172032;
				SetFjk16(fjk, 3, 9, array2, array, v);
				array[0] = 9905.161609109484;
				array[1] = -46820.775577189124;
				array[2] = -2040487.1579820313;
				array[3] = 9691735.57258924;
				array[4] = 54815060.69207336;
				array[5] = -309390686.57090217;
				array[6] = -360017948.0802763;
				array[7] = 3579817310.0615044;
				array[8] = -975311608.4990194;
				array[9] = -19324823653.63573;
				array[10] = 19615966368.54824;
				array[11] = 52313543472.729546;
				array[12] = -87319509031.59497;
				array[13] = -62880701946.0012;
				array[14] = 187577712375.82047;
				array[15] = -5014883987.803881;
				array[16] = -210187382319.75342;
				array[17] = 95721572764.80733;
				array[18] = 109424352395.85297;
				array[19] = -93578868051.24042;
				array[20] = -10054064393.16693;
				array[21] = 29497575770.435658;
				array[22] = -7788016225.40167;
				SetFjk16(fjk, 4, 9, array2, array, v);
				array[0] = -24762.90402277371;
				array[1] = 150202.12250011534;
				array[2] = 5795836.385474999;
				array[3] = -35748503.91572715;
				array[4] = -151894819.53780368;
				array[5] = 1257834576.5897312;
				array[6] = 283767191.8835147;
				array[7] = -15254386392.322462;
				array[8] = 17551211231.56745;
				array[9] = 79224659176.16066;
				array[10] = -169127446206.1995;
				array[11] = -159965663833.0501;
				array[12] = 667618088176.4683;
				array[13] = -96638419442.06247;
				array[14] = -1307530021252.0142;
				array[15] = 998989571129.4067;
				array[16] = 1171444346499.523;
				array[17] = -1737201461305.162;
				array[18] = -114746520425.41058;
				array[19] = 1243665816084.6792;
				array[20] = -512525557301.9352;
				array[21] = -261796114655.33667;
				array[22] = 247688439610.96542;
				array[23] = -52756420815.90127;
				SetFjk16(fjk, 5, 9, array2, array, v);
				array[0] = 55716.53405124085;
				array[1] = -415613.72155461746;
				array[2] = -14629090.28952118;
				array[3] = 112517365.15692088;
				array[4] = 349569807.61470723;
				array[5] = -4300749690.400817;
				array[6] = 2780201489.2284703;
				array[7] = 53008111096.39162;
				array[8] = -112833892526.88953;
				array[9] = -236800084652.33408;
				array[10] = 948058960807.1896;
				array[11] = 15893204800.58018;
				array[12] = -3467524908336.784;
				array[13] = 3164309467171.3657;
				array[14] = 5582435675279.182;
				array[15] = -10541249137249.73;
				array[16] = -1168774181536.203;
				array[17] = 14413943369875.125;
				array[18] = -7960463497916.106;
				array[19] = -7323822211977.289;
				array[20] = 9405979314966.688;
				array[21] = -1275663773372.9197;
				array[22] = -2930439830152.3545;
				array[23] = 1747630840980.1348;
				array[24] = -312613977240.16974;
				SetFjk16(fjk, 6, 9, array2, array, v);
				array[0] = -115412.82053471319;
				array[1] = 1027788.8260207104;
				array[2] = 33623754.973679066;
				array[3] = -313584768.22511894;
				array[4] = -659891574.7928052;
				array[5] = 12850764070.127691;
				array[6] = -19440345035.583477;
				array[7] = -155138555406.99155;
				array[8] = 516911193990.9226;
				array[9] = 451041007491.5112;
				array[10] = -4074544650661.9634;
				array[11] = 3101195098601.7686;
				array[12] = 13186035652463.635;
				array[13] = -24971415775329.26;
				array[14] = -10847664957177.135;
				array[15] = 66205224018265.48;
				array[16] = -37500185472771.586;
				array[17] = -69777795804669.38;
				array[18] = 99311193873506.56;
				array[19] = -492168373279.2016;
				array[20] = -80134019127845.98;
				array[21] = 51160427044311.74;
				array[22] = 9045641917569.246;
				array[23] = -24123027505367.164;
				array[24] = 10768904399045.848;
				array[25] = -1663085461560.5466;
				SetFjk16(fjk, 7, 9, array2, array, v);
				array[0] = 110.01714026924674;
				array[1] = 0.0;
				array[2] = -13886.08975371704;
				array[3] = 0.0;
				array[4] = 308186.4046126624;
				array[5] = 0.0;
				array[6] = -2785618.1280864547;
				array[7] = 0.0;
				array[8] = 13288767.166421818;
				array[9] = 0.0;
				array[10] = -37567176.66076335;
				array[11] = 0.0;
				array[12] = 66344512.27472903;
				array[13] = 0.0;
				array[14] = -74105148.21153265;
				array[15] = 0.0;
				array[16] = 50952602.49266464;
				array[17] = 0.0;
				array[18] = -19706819.118432228;
				array[19] = 0.0;
				array[20] = 3284469.853072038;
				SetFjk16(fjk, 0, 10, array2, array, v);
				array[0] = -1045.162832557844;
				array[1] = 1118.5075927373418;
				array[2] = 159690.03216774596;
				array[3] = -168947.42533689065;
				array[4] = -4160516.4622709425;
				array[5] = 4365974.065346051;
				array[6] = 43177080.98534005;
				array[7] = -45034159.737397686;
				array[8] = -232553425.41238183;
				array[9] = 241412603.5233297;
				array[10] = 732559944.8848853;
				array[11] = -757604729.3253943;
				array[12] = -1426407013.9066741;
				array[13] = 1470636688.7564933;
				array[14] = 1741470982.9710174;
				array[15] = -1790874415.1120393;
				array[16] = -1299291363.5629485;
				array[17] = 1333259765.2247248;
				array[18] = 541937525.7568862;
				array[19] = -555075405.1691744;
				array[20] = -96891860.66562511;
				array[21] = 99081507.2343398;
				SetFjk16(fjk, 1, 10, array2, array, v);
				array[0] = 5487.1048709286815;
				array[1] = -12101.885429617141;
				array[2] = -991438.7523947014;
				array[3] = 2166230.0015798584;
				array[4] = 28994419.876786742;
				array[5] = -64719144.9686591;
				array[6] = -321629835.31147623;
				array[7] = 757688130.8395157;
				array[8] = 1749409837.5100644;
				array[9] = -4544758370.916262;
				array[10] = -5113992851.954476;
				array[11] = 15778214197.520607;
				array[12] = 7774473545.944487;
				array[13] = -33570323211.012886;
				array[14] = -3804246527.475932;
				array[15] = 44463088926.91959;
				array[16] = -5920634247.333193;
				array[17] = -35768726949.85058;
				array[18] = 10834752690.813606;
				array[19] = 16001937124.166967;
				array[20] = -6803368741.907092;
				array[21] = -3054556963.356995;
				array[22] = 1577229794.0273015;
				SetFjk16(fjk, 2, 10, array2, array, v);
				array[0] = -21033.90200522661;
				array[1] = 71551.02238835797;
				array[2] = 4410889.421489859;
				array[3] = -14945521.65322753;
				array[4] = -139310283.22771755;
				array[5] = 506112018.78208166;
				array[6] = 1519598088.8133636;
				array[7] = -6552067582.056451;
				array[8] = -6692370095.428206;
				array[9] = 42444451633.41426;
				array[10] = 5560288488.776679;
				array[11] = -155035909620.11652;
				array[12] = 57543525805.054085;
				array[13] = 335136386281.40045;
				array[14] = -242028870673.91837;
				array[15] = -425158049601.57074;
				array[16] = 447281929473.23047;
				array[17] = 285539009675.267;
				array[18] = -446532174700.7554;
				array[19] = -56114815650.416794;
				array[20] = 234199738711.3991;
				array[21] = -38367666879.80787;
				array[22] = -50717346515.57769;
				array[23] = 17618025541.84948;
				SetFjk16(fjk, 3, 10, array2, array, v);
				array[0] = 65730.94376633316;
				array[1] = -305976.0032788201;
				array[2] = -15752484.913133094;
				array[3] = 73626048.7662199;
				array[4] = 517727813.38636845;
				array[5] = -2779778621.031182;
				array[6] = -4848484539.300694;
				array[7] = 38867748248.4867;
				array[8] = 2816113040.383313;
				array[9] = -261989764937.19714;
				array[10] = 193832179511.35043;
				array[11] = 941830771354.5242;
				array[12] = -1252062600825.4805;
				array[13] = -1788586580037.923;
				array[14] = 3715406759129.64;
				array[15] = 1338049108553.0784;
				array[16] = -6078517409833.267;
				array[17] = 1046877894952.0463;
				array[18] = 5489626110236.166;
				array[19] = -2928719118680.386;
				array[20] = -2340856193318.642;
				array[21] = 2206204676067.3125;
				array[22] = 119173943641.45927;
				array[23] = -589883942966.2108;
				array[24] = 154983207892.81174;
				SetFjk16(fjk, 4, 10, array2, array, v);
				array[0] = -177473.54816909952;
				array[1] = 1058104.4704696212;
				array[2] = 47977824.89795256;
				array[3] = -290115715.66147846;
				array[4] = -1577194622.2444813;
				array[5] = 12040320836.77494;
				array[6] = 8938496432.776169;
				array[7] = -177729149538.5476;
				array[8] = 142764258530.36398;
				array[9] = 1190892990608.0;
				array[10] = -2059313111949.912;
				array[11] = -3727699663610.191;
				array[12] = 10889256225145.523;
				array[13] = 3246312869985.9517;
				array[14] = -29702334678008.055;
				array[15] = 12354361209407.777;
				array[16] = 43335047349400.914;
				array[17] = -41504037524268.0;
				array[18] = -28336804589555.31;
				array[19] = 52945932725332.516;
				array[20] = -2984104941157.1313;
				array[21] = -30618403352283.41;
				array[22] = 14099792752244.01;
				array[23] = 5138575314225.492;
				array[24] = -5394419195595.038;
				array[25] = 1142750145697.5796;
				SetFjk16(fjk, 5, 10, array2, array, v);
				array[0] = 428894.40807532385;
				array[1] = -3139491.0587579524;
				array[2] = -129346362.91769879;
				array[3] = 971658116.2363682;
				array[4] = 4056885717.6650653;
				array[5] = -43776518263.068504;
				array[6] = 6886509445.733657;
				array[7] = 666192636622.6324;
				array[8] = -1146605162893.2336;
				array[9] = -4150515189210.382;
				array[10] = 12899393468582.902;
				array[11] = 7742402532790.661;
				array[12] = -63390570866544.42;
				array[13] = 31574846906545.7;
				array[14] = 155509830706127.22;
				array[15] = -197328514020298.7;
				array[16] = -161495194791368.9;
				array[17] = 431593958485279.1;
				array[18] = -57955664355845.42;
				array[19] = -444813800230214.8;
				array[20] = 304547176185415.8;
				array[21] = 164529366533754.03;
				array[22] = Math.PI * -83450936287651.0;
				array[23] = 51430539333046.6;
				array[24] = 65933562346693.24;
				array[25] = -41287526582645.05;
				array[26] = 7341963962580.312;
				SetFjk16(fjk, 6, 10, array2, array, v);
				array[0] = 551.3358961220206;
				array[1] = 0.0;
				array[2] = -84005.43360302408;
				array[3] = 0.0;
				array[4] = 2243768.1779224495;
				array[5] = 0.0;
				array[6] = -24474062.72573873;
				array[7] = 0.0;
				array[8] = 142062907.7975331;
				array[9] = 0.0;
				array[10] = -495889784.2750303;
				array[11] = 0.0;
				array[12] = 1106842816.8230145;
				array[13] = 0.0;
				array[14] = -1621080552.1083372;
				array[15] = 0.0;
				array[16] = 1553596899.57058;
				array[17] = 0.0;
				array[18] = -939462359.6815784;
				array[19] = 0.0;
				array[20] = 325573074.18576574;
				array[21] = 0.0;
				array[22] = -49329253.66450996;
				SetFjk16(fjk, 0, 11, array2, array, v);
				array[0] = -5789.026909281216;
				array[1] = 6156.584173362563;
				array[2] = 1050067.9200378011;
				array[3] = -1106071.5424398172;
				array[4] = -32534638.579875518;
				array[5] = 34030484.031823814;
				array[6] = 403822034.974689;
				array[7] = -420138076.7918482;
				array[8] = -2628163794.254362;
				array[9] = 2722872399.452718;
				array[10] = 10165740577.63812;
				array[11] = -10496333767.154808;
				array[12] = -24903963378.517826;
				array[13] = 25641858589.73317;
				array[14] = 39716473526.65426;
				array[15] = -40797193894.72649;
				array[16] = -41170317838.62037;
				array[17] = 42206049105.000755;
				array[18] = 26774677250.924984;
				array[19] = -27400985490.712704;
				array[20] = -9929978762.665855;
				array[21] = 10147027478.7897;
				array[22] = 1603200744.0965738;
				array[23] = -1636086913.206247;
				SetFjk16(fjk, 1, 11, array2, array, v);
				array[0] = 33286.90472836699;
				array[1] = -72776.33828810672;
				array[2] = -7048423.082037407;
				array[3] = 15288988.915750384;
				array[4] = 243935418.08573976;
				array[5] = -538504362.7013879;
				array[6] = -3246894911.639683;
				array[7] = 7489063194.076051;
				array[8] = 21666937100.705364;
				array[9] = -53983904963.06258;
				array[10] = -80910564664.87747;
				array[11] = 229101080335.064;
				array[12] = 172760876423.44067;
				array[13] = -610977234886.304;
				array[14] = -187937135374.72034;
				array[15] = 1053702358870.4191;
				array[16] = 18639458829.443775;
				array[17] = -1174519256075.3586;
				array[18] = 213630362751.48245;
				array[19] = 817332252922.9733;
				array[20] = -266086886489.81592;
				array[21] = -322968489592.2796;
				array[22] = 139744842706.19028;
				array[23] = 55347422611.58018;
				array[24] = -28497920919.101276;
				SetFjk16(fjk, 2, 11, array2, array, v);
				array[0] = -138695.4363681958;
				array[1] = 466698.9443685889;
				array[2] = 33739004.101605795;
				array[3] = -113151831.10727234;
				array[4] = -1262494179.8855195;
				array[5] = 4485679097.12217;
				array[6] = 16876412838.414698;
				array[7] = -68734331237.68523;
				array[8] = -99319007190.86728;
				array[9] = 535143925100.6457;
				array[10] = 219559829042.68088;
				array[11] = -2402169771537.23;
				array[12] = 385225420494.61273;
				array[13] = 6605716163805.363;
				array[14] = -3536807746028.463;
				array[15] = -11320974870399.201;
				array[16] = 9487604757721.176;
				array[17] = 11727696199159.895;
				array[18] = -13727281916428.068;
				array[19] = -6409955842808.298;
				array[20] = 11468445778721.254;
				array[21] = 723160235150.798;
				array[22] = -5214971540434.54;
				array[23] = 952560905703.6266;
				array[24] = 1001898723474.6755;
				array[25] = -346817425242.5275;
				SetFjk16(fjk, 3, 11, array2, array, v);
				array[0] = 468097.09774266084;
				array[1] = -2151404.5559841446;
				array[2] = -129076990.59865052;
				array[3] = 595316208.5142877;
				array[4] = 5064273602.590667;
				array[5] = -26185510869.073116;
				array[6] = -61837037264.90558;
				array[7] = 433386998010.2327;
				array[8] = 186443883288.3731;
				array[9] = -3537220973754.002;
				array[10] = 1681730347233.85;
				array[11] = 15988837394678.875;
				array[12] = -16993822946683.547;
				array[13] = -41340811227869.29;
				array[14] = 67591520066179.68;
				array[15] = 56621717984129.586;
				array[16] = -149792388677379.47;
				array[17] = -20183328379251.848;
				array[18] = 196651762467137.75;
				array[19] = -54964390301576.37;
				array[20] = -147653284026647.88;
				array[21] = 88925712863728.44;
				array[22] = 52472318964377.74;
				array[23] = -54571161032830.89;
				array[24] = -776744894101.8108;
				array[25] = 12653076888080.967;
				array[26] = -3310861678129.4434;
				SetFjk16(fjk, 4, 11, array2, array, v);
				array[0] = -1357481.5834537165;
				array[1] = 7977851.153514766;
				array[2] = 419517728.92817664;
				array[3] = -2495517054.7161427;
				array[4] = -16720780562.050493;
				array[5] = 120296564778.19437;
				array[6] = 154404724838.8961;
				array[7] = -2110123804399.9207;
				array[8] = 974123695127.8887;
				array[9] = 17443881430511.947;
				array[10] = -24448434409173.656;
				array[11] = -73513952038406.36;
				array[12] = 169708094306922.0;
				array[13] = 139392884698962.95;
				array[14] = -607701552209729.5;
				array[15] = 42904363912061.41;
				array[16] = 1241046770899817.2;
				array[17] = -768125556097572.1;
				array[18] = -1403171934960438.0;
				array[19] = 1622188475923667.8;
				array[20] = 657623934547413.9;
				array[21] = -1631882122398223.2;
				array[22] = 237083343503533.12;
				array[23] = 785835171244720.5;
				array[24] = -396417689594574.3;
				array[25] = -105868095076065.58;
				array[26] = 125179414423474.78;
				array[27] = -26396909127729.652;
				SetFjk16(fjk, 5, 11, array2, array, v);
				array[0] = 3038.090510922384;
				array[1] = 0.0;
				array[2] = -549842.3275722887;
				array[3] = 0.0;
				array[4] = 17395107.553978164;
				array[5] = 0.0;
				array[6] = -225105661.88941526;
				array[7] = 0.0;
				array[8] = 1559279864.8792574;
				array[9] = 0.0;
				array[10] = -6563293792.619285;
				array[11] = 0.0;
				array[12] = 17954213731.1556;
				array[13] = 0.0;
				array[14] = -33026599749.800724;
				array[15] = 0.0;
				array[16] = 41280185579.753975;
				array[17] = 0.0;
				array[18] = -34632043388.158775;
				array[19] = 0.0;
				array[20] = 18688207509.295826;
				array[21] = 0.0;
				array[22] = -5866481492.051847;
				array[23] = 0.0;
				array[24] = 814789096.1183121;
				SetFjk16(fjk, 0, 12, array2, array, v);
				array[0] = -34938.04087560742;
				array[1] = 36963.43454955568;
				array[2] = 7422871.422225897;
				array[3] = -7789432.973940756;
				array[4] = -269624167.0866616;
				array[5] = 281220905.4559803;
				array[6] = 3939349083.0647674;
				array[7] = -4089419524.3243775;
				array[8] = -30405957365.145523;
				array[9] = 31445477275.065025;
				array[10] = 141110816541.3146;
				array[11] = -145486345736.39413;
				array[12] = -421924022682.1566;
				array[13] = 433893498502.927;
				array[14] = 842178293619.9185;
				array[15] = -864196026786.4523;
				array[16] = -1135205103443.2344;
				array[17] = 1162725227163.0703;
				array[18] = 1021645279950.684;
				array[19] = -1044733308876.1232;
				array[20] = -588678536542.8185;
				array[21] = 601137341549.0157;
				array[22] = 196527129983.73688;
				array[23] = -200438117645.10477;
				array[24] = -28925012912.20008;
				array[25] = 29468205642.94562;
				SetFjk16(fjk, 1, 12, array2, array, v);
				array[0] = 218362.75547254636;
				array[1] = -473942.1197038919;
				array[2] = -53559985.272697166;
				array[3] = 115466888.79018062;
				array[4] = 2162702487.2919507;
				array[5] = -4731469254.682061;
				array[6] = -33930459549.83583;
				array[7] = 76986136366.18002;
				array[8] = 271095146839.7532;
				array[9] = -654897543249.2882;
				array[10] = -1244130265844.503;
				array[11] = 3321026659065.358;
				array[12] = 3434492363731.465;
				array[13] = -10772528238693.36;
				array[14] = -5553407245149.382;
				array[15] = 23184673024360.11;
				array[16] = 4148109873524.0835;
				array[17] = -33519510690760.227;
				array[18] = 1766187462911.1875;
				array[19] = 32207800350987.664;
				array[20] = -7064569616534.612;
				array[21] = -19734747129816.39;
				array[22] = 6780185269401.904;
				array[23] = 6981112975541.698;
				array[24] = -3063627371132.2563;
				array[25] = -1085299076029.5918;
				array[26] = 557485489473.2834;
				SetFjk16(fjk, 2, 12, array2, array, v);
				array[0] = -982632.3996264586;
				array[1] = 3276416.052793783;
				array[2] = 274430595.867674;
				array[3] = -912438377.6104804;
				array[4] = -11979589299.502913;
				array[5] = 41816043571.57036;
				array[6] = 191330729548.58234;
				array[7] = -746943185635.967;
				array[8] = -1416198224023.6465;
				array[9] = 6856956393274.589;
				array[10] = 4829515891796.997;
				array[11] = -36877687475484.6;
				array[12] = -2050957082915.0942;
				array[13] = 124378250253033.78;
				array[14] = -44312193894090.53;
				array[15] = -271207689501172.62;
				array[16] = 179586202876957.78;
				array[17] = 381618869449173.25;
				array[18] = -359490061117883.0;
				array[19] = -330393612742248.44;
				array[20] = 427952236370799.94;
				array[21] = 148052565489017.03;
				array[22] = -307266140839707.2;
				array[23] = -4687264091266.087;
				array[24] = 123260326898726.61;
				array[25] = -24376238900981.87;
				array[26] = -21272360948501.37;
				array[27] = 7341892911307.882;
				SetFjk16(fjk, 3, 12, array2, array, v);
				array[0] = 3562042.4486459126;
				array[1] = -16196313.687936474;
				array[2] = -1119546446.8249807;
				array[3] = 5105896697.657058;
				array[4] = 51476060928.63038;
				array[5] = -258447407741.23544;
				array[6] = -779649080899.6405;
				array[7] = 4982179421789.694;
				array[8] = 4004696303571.854;
				array[9] = -48152095258426.15;
				array[10] = 10206156605278.264;
				array[11] = 264344253278752.34;
				array[12] = -218798857956960.84;
				array[13] = -868622560677829.6;
				array[14] = 1161601525559524.2;
				array[15] = 1687979001191903.2;
				array[16] = -3349241418127554.0;
				array[17] = -1649878672532120.5;
				array[18] = 5897451215285125.0;
				array[19] = -125952827188585.92;
				array[20] = -6433283969334752.0;
				array[21] = 2343935079955608.5;
				array[22] = 4106725553395394.0;
				array[23] = -2735980005540132.5;
				array[24] = -1230142327980831.0;
				array[25] = 1417490532431040.0;
				array[26] = -23384761374805.902;
				array[27] = -289892454526107.4;
				array[28] = 75592403781851.47;
				SetFjk16(fjk, 4, 12, array2, array, v);
				array[0] = 18257.755474293175;
				array[1] = 0.0;
				array[2] = -3871833.442572613;
				array[3] = 0.0;
				array[4] = 143157876.71888897;
				array[5] = 0.0;
				array[6] = -2167164983.223795;
				array[7] = 0.0;
				array[8] = 17634730606.83497;
				array[9] = 0.0;
				array[10] = -87867072178.02327;
				array[11] = 0.0;
				array[12] = 287900649906.1506;
				array[13] = 0.0;
				array[14] = -645364869245.3765;
				array[15] = 0.0;
				array[16] = 1008158106865.3821;
				array[17] = 0.0;
				array[18] = -1098375156081.2233;
				array[19] = 0.0;
				array[20] = 819218669548.5773;
				array[21] = 0.0;
				array[22] = -399096175224.4665;
				array[23] = 0.0;
				array[24] = 114498237732.0258;
				array[25] = 0.0;
				array[26] = -14679261247.695616;
				SetFjk16(fjk, 0, 13, array2, array, v);
				array[0] = -228221.94342866467;
				array[1] = 240393.7804115268;
				array[2] = 56141584.917302884;
				array[3] = -58722807.21235129;
				array[4] = -2362104965.861668;
				array[5] = 2457543550.3409276;
				array[6] = 40092552189.64021;
				array[7] = -41537328845.12274;
				array[8] = -361511977440.1169;
				array[9] = 373268464511.3402;
				array[10] = 1977009124005.5234;
				array[11] = -2035587172124.2056;
				array[12] = -7053565922700.689;
				array[13] = 7245499689304.79;
				array[14] = 17102169035002.477;
				array[15] = -17532412281166.062;
				array[16] = -28732506045663.39;
				array[17] = 29404611450240.312;
				array[18] = 33500442260477.312;
				array[19] = -34232692364531.46;
				array[20] = -26624606760328.76;
				array[21] = 27170752540027.816;
				array[22] = 13768818045244.094;
				array[23] = -14034882162060.404;
				array[24] = -4179185677218.942;
				array[25] = 4255517835706.9595;
				array[26] = 565151558036.2812;
				array[27] = -574937732201.4116;
				SetFjk16(fjk, 1, 13, array2, array, v);
				array[0] = 1540498.1181434866;
				array[1] = -3322911.496321358;
				array[2] = -433313348.25129664;
				array[3] = 929240026.217427;
				array[4] = 20173953055.394386;
				array[5] = -43806310275.98003;
				array[6] = -367752562201.2417;
				array[7] = 823522693625.0421;
				array[8] = 3453452850623.271;
				array[9] = -8147245540357.756;
				array[10] = -18967395863304.5;
				array[11] = 48502623842268.84;
				array[12] = 64652876623215.016;
				array[13] = -187135422438997.88;
				array[14] = -137928375585894.45;
				array[15] = 487895841149504.6;
				array[16] = 171009666849543.97;
				array[17] = -877097552972882.4;
				array[18] = -74254863627598.11;
				array[19] = 1089588154832573.5;
				array[20] = -116085557257555.86;
				array[21] = -919163347233503.8;
				array[22] = 228872931917376.7;
				array[23] = 502861180782827.8;
				array[24] = -180138187046492.0;
				array[25] = -160984522251228.28;
				array[26] = 71472589051967.58;
				array[27] = 22899647546405.16;
				array[28] = -11739127546959.248;
				SetFjk16(fjk, 2, 13, array2, array, v);
				array[0] = -7445740.904360185;
				array[1] = 24634048.351746637;
				array[2] = 2366020806.02629;
				array[3] = -7808648260.642505;
				array[4] = -118977141825.00262;
				array[5] = 409347654830.3762;
				array[6] = 2227886871742.034;
				array[7] = -8418196051278.762;
				array[8] = -19993114336865.5;
				array[9] = 89749606285710.61;
				array[10] = 91027650219177.8;
				array[11] = -567320456048460.0;
				array[12] = -158541319151866.4;
				array[13] = 2286994298876364.5;
				array[14] = -406108119093234.2;
				array[15] = -6109006264284955.0;
				array[16] = 3061509093597577.5;
				array[17] = 10949569443954370.0;
				array[18] = -8409227264715248.0;
				array[19] = -12972671111828072.0;
				array[20] = 13506857028733486.0;
				array[21] = 9542099548494264.0;
				array[22] = -13665198589678694.0;
				array[23] = -3500771616752033.5;
				array[24] = 8599505926079282.0;
				array[25] = -192584364085979.72;
				array[26] = -9692145843006992.0 / Math.PI;
				array[27] = 648294322883069.6;
				array[28] = 483163296698761.3;
				array[29] = -166336791576720.84;
				SetFjk16(fjk, 3, 13, array2, array, v);
				array[0] = 118838.42625678325;
				array[1] = 0.0;
				array[2] = -29188388.122220814;
				array[3] = 0.0;
				array[4] = 1247009293.5127103;
				array[5] = 0.0;
				array[6] = -21822927757.529224;
				array[7] = 0.0;
				array[8] = 205914503232.41;
				array[9] = 0.0;
				array[10] = -1196552880196.1816;
				array[11] = 0.0;
				array[12] = 4612725780849.132;
				array[13] = 0.0;
				array[14] = -12320491305598.287;
				array[15] = 0.0;
				array[16] = 23348364044581.84;
				array[17] = 0.0;
				array[18] = -31667088584785.16;
				array[19] = 0.0;
				array[20] = 30565125519935.32;
				array[21] = 0.0;
				array[22] = -20516899410934.438;
				array[23] = 0.0;
				array[24] = 9109341185239.898;
				array[25] = 0.0;
				array[26] = -2406297900028.504;
				array[27] = 0.0;
				array[28] = 286464035717.679;
				SetFjk16(fjk, 0, 14, array2, array, v);
				array[0] = -1604318.754466574;
				array[1] = 1683544.3719710961;
				array[2] = 452420015.8944226;
				array[3] = -471878941.30923647;
				array[4] = -21822662636.47243;
				array[5] = 22654002165.480904;
				array[6] = 425547091271.8199;
				array[7] = -440095709776.83936;
				array[8] = -4427161819496.815;
				array[9] = 4564438154985.089;
				array[10] = 28118992684610.266;
				array[11] = -28916694604741.055;
				array[12] = -117624507411652.86;
				array[13] = 120699657932218.95;
				array[14] = 338813510903952.9;
				array[15] = -347027171774351.75;
				array[16] = -688776739315164.2;
				array[17] = 704342315344885.5;
				array[18] = 997513290420732.5;
				array[19] = -1018624682810589.2;
				array[20] = -1023931704917833.2;
				array[21] = 1044308455264456.8;
				array[22] = 728349929088172.5;
				array[23] = -742027862028795.5;
				array[24] = -341600294446496.2;
				array[25] = 347673188569989.5;
				array[26] = 95048767051125.9;
				array[27] = -96652965651144.9;
				array[28] = -11888257482283.68;
				array[29] = 12079233506095.467;
				SetFjk16(fjk, 1, 14, array2, array, v);
				array[0] = 11631310.969882661;
				array[1] = -24956069.513924483;
				array[2] = -3719130469.3827567;
				array[3] = 7939241569.244061;
				array[4] = 197650420583.57806;
				array[5] = -426477178381.3469;
				array[6] = -4137136219101.051;
				array[7] = 9165629658162.273;
				array[8] = 44999979919399.92;
				array[9] = -104192738635599.47;
				array[10] = -290053332678279.44;
				array[11] = 717931728117709.0;
				array[12] = 1184950942733151.0;
				array[13] = -10172896409150192.0 / Math.PI;
				array[14] = -3148099361614568.0;
				array[15] = 10004238940145810.0;
				array[16] = 5326672157182975.0;
				array[17] = -21713978561461110.0;
				array[18] = -4997511985428331.0;
				array[19] = 33440445545533130.0;
				array[20] = 429328409587667.0;
				array[21] = -36372499368723030.0;
				array[22] = 5419838346824587.0;
				array[23] = 27328510015364670.0;
				array[24] = -7462027883028048.0;
				array[25] = -13500043636525530.0;
				array[26] = 5000259547410615.0;
				array[27] = 3946328556046746.5;
				array[28] = -1769166076587921.0;
				array[29] = -517354048506128.4;
				array[30] = 264752449010576.62;
				SetFjk16(fjk, 2, 14, array2, array, v);
				array[0] = 832859.3040162893;
				array[1] = 0.0;
				array[2] = -234557963.52225152;
				array[3] = 0.0;
				array[4] = 11465754899.448236;
				array[5] = 0.0;
				array[6] = -229619372968.24646;
				array[7] = 0.0;
				array[8] = 2485000928034.0854;
				array[9] = 0.0;
				array[10] = -16634824724892.48;
				array[11] = 0.0;
				array[12] = 74373122908679.14;
				array[13] = 0.0;
				array[14] = -232604831188939.94;
				array[15] = 0.0;
				array[16] = 523054882578444.6;
				array[17] = 0.0;
				array[18] = -857461032982895.0;
				array[19] = 0.0;
				array[20] = 1026955196082762.5;
				array[21] = 0.0;
				array[22] = -889496939881026.5;
				array[23] = 0.0;
				array[24] = 542739664987659.75;
				array[25] = 0.0;
				array[26] = -221349638702525.2;
				array[27] = 0.0;
				array[28] = 54177510755106.05;
				array[29] = 0.0;
				array[30] = -6019723417234.006;
				SetFjk16(fjk, 0, 15, array2, array, v);
				array[0] = -12076459.908236194;
				array[1] = 12631699.444247054;
				array[2] = 3870206398.1171503;
				array[3] = -4026578373.798651;
				array[4] = -212116465639.7924;
				array[5] = 219760302239.42456;
				array[6] = 4707197145849.053;
				array[7] = -4860276727827.884;
				array[8] = -55912520880766.92;
				array[9] = 57569188166122.98;
				array[10] = 407553205759865.75;
				array[11] = -418643088909794.06;
				array[12] = -1970887757079997.2;
				array[13] = 2020469839019116.8;
				array[14] = 6629237688884788.0;
				array[15] = -6784307576344081.0;
				array[16] = -15953173918642562.0;
				array[17] = 16301877173694858.0;
				array[18] = 27867483571944090.0;
				array[19] = -28439124260599350.0;
				array[20] = -35429954264855304.0;
				array[21] = 36114591062243816.0;
				array[22] = 32466638305657464.0;
				array[23] = -33059636265578148.0;
				array[24] = -20895477102024900.0;
				array[25] = 21257303545350004.0;
				array[26] = 8964660367452270.0;
				array[27] = -9112226793253954.0;
				array[28] = -2302544207092007.0;
				array[29] = 2338662547595411.0;
				array[30] = 267877692066913.25;
				array[31] = -271890841011735.9;
				SetFjk16(fjk, 1, 15, array2, array, v);
				array[0] = 6252951.493434797;
				array[1] = 0.0;
				array[2] = -2001646928.1917763;
				array[3] = 0.0;
				array[4] = 110997405139.17902;
				array[5] = 0.0;
				array[6] = -2521558474912.8545;
				array[7] = 0.0;
				array[8] = 31007436472896.46;
				array[9] = 0.0;
				array[10] = -236652530451649.25;
				array[11] = 0.0;
				array[12] = 1212675804250347.5;
				array[13] = 0.0;
				array[14] = -11904241847326076.0 / Math.E;
				array[15] = 0.0;
				array[16] = 11486706978449752.0;
				array[17] = 0.0;
				array[18] = -22268225133911144.0;
				array[19] = 0.0;
				array[20] = 32138275268586240.0;
				array[21] = 0.0;
				array[22] = -34447226006485144.0;
				array[23] = 0.0;
				array[24] = 27054711306197080.0;
				array[25] = 0.0;
				array[26] = -15129826322457682.0;
				array[27] = 0.0;
				array[28] = 5705782159023671.0;
				array[29] = 0.0;
				array[30] = -1301012723549699.5;
				array[31] = 0.0;
				array[32] = 135522158703093.69;
				SetFjk16(fjk, 0, 16, array2, array, v);
			}

			private static void SetFjk16(double[,] fjk, int j, int k, double[] un, double[] fjkm, double v)
			{
				int num = j + 2 * k;
				fjk[j, k] = un[num] * Pol(fjkm, num, v);
			}

			private static int Startingpser(double mu, double x, double y)
			{
				double mulnmu = mu * Math.Log(mu);
				double lnx = Math.Log(x);
				double lny = Math.Log(y);
				double num = ((x < 2.0) ? (x + 5.0) : (1.5 * x));
				double num2 = 0.0;
				int a = 0;
				int b = 0;
				while (Math.Abs(num - num2) > 1.0)
				{
					num2 = num;
					num = Ps(mu, mulnmu, lnx, y, lny, num, a, b);
				}
				num += 1.0;
				if (mu + num > y)
				{
					if (y > mu)
					{
						a = 1;
					}
					else
					{
						b = 1;
					}
					num2 = 0.0;
					while (Math.Abs(num - num2) > 1.0)
					{
						num2 = num;
						num = Ps(mu, mulnmu, lnx, y, lny, num, a, b);
					}
				}
				return (int)Math.Round(num) + 1;
			}

			private static double Ps(double mu, double mulnmu, double lnx, double y, double lny, double n, int a, int b)
			{
				double num = Math.Log(Epss);
				if (a == 0 && b == 0)
				{
					return (n - num) / (Math.Log(n) - lnx);
				}
				if (a == 0 && b == 1)
				{
					return (2.0 * n - num + mulnmu - mu * Math.Log(mu + n)) / (Math.Log(n) - lnx - lny + Math.Log(mu + n));
				}
				if (a == 1 && b == 0)
				{
					return (2.0 * n - num - y + mu * lny - mu * Math.Log(mu + n) + mu) / (Math.Log(n) - lnx - lny + Math.Log(mu + n));
				}
				throw new ArgumentException("(a,b) must be (a==0&b==0)||(a==1&b==0)||(a==0&b==1)");
			}

			private static void Hypfun(double x, out double sinh, out double cosh)
			{
				double num = Math.Abs(x);
				if (num < 0.21)
				{
					double num2 = ((num < 0.07) ? (x * x) : (x * x / 9.0));
					double num3 = 2.0 + num2 * (num2 * 28.0 + 2520.0) / (num2 * (num2 + 420.0) + 15120.0);
					double num4 = num3 * num3;
					sinh = 2.0 * x * num3 / (num4 - num2);
					cosh = (num4 + num2) / (num4 - num2);
					if (num >= 0.07)
					{
						double num5 = 2.0 * sinh / 3.0;
						num3 = num5 * num5;
						sinh *= 1.0 + num3 / 3.0;
						cosh *= 1.0 + num3;
					}
				}
				else
				{
					double num2 = Math.Exp(x);
					double num3 = 1.0 / num2;
					cosh = (num2 + num3) / 2.0;
					sinh = (num2 - num3) / 2.0;
				}
			}

			private static double Ignega(int n, double x)
			{
				double num = 0.5 - (double)n;
				double num2 = Epss / 100.0;
				double num9;
				if (x > 1.5)
				{
					double num3 = 0.0;
					double num4 = (x - 1.0 - num) * (x + 1.0 - num);
					double num5 = 4.0 * (x + 1.0 - num);
					double num6 = 1.0 - num;
					double num7 = 0.0;
					double num8 = 1.0;
					for (num9 = 1.0; num8 / num9 > num2; num9 += num8)
					{
						num3 += num6;
						num4 += num5;
						num5 += 8.0;
						num6 += 2.0;
						double num10 = num3 * (1.0 + num7);
						num7 = num10 / (num4 - num10);
						num8 *= num7;
					}
					return num9 * (Math.Exp(num * Math.Log(x)) / (x + 1.0 - num));
				}
				double num11 = 1.0;
				double num12 = 1.0 / num;
				int num13 = 1;
				while (Math.Abs(num11 / num12) > num2)
				{
					num11 *= (0.0 - x) / (double)num13;
					num12 += num11 / ((double)num13 + num);
					num13++;
				}
				num9 = 1.772453850905516;
				for (int i = 1; i <= n; i++)
				{
					num9 /= 0.5 - (double)i;
				}
				return Math.Exp(x) * (num9 - Math.Exp(num * Math.Log(x)) * num12);
			}

			private static double Alfinv(int t, double r)
			{
				double num;
				double num3;
				if ((double)t + r < 2.7)
				{
					if (t == 0)
					{
						num = Math.Exp(Math.Log(3.0 * r) / 3.0);
						double num2 = num * num;
						num3 = num * (1.0 + num2 * (-1.0 / 30.0 + 0.004312 * num2));
					}
					else
					{
						num = Math.Sqrt(2.0 * (1.0 + r));
						double num4 = num * num;
						num3 = num / (1.0 + num4 / 8.0);
					}
				}
				else
				{
					num = Math.Log(0.7357589 * (r + (double)t));
					double num5 = Math.Log(num) / num;
					num3 = 1.0 + num + Math.Log(num) * (1.0 / num - 1.0) + 0.5 * num5 * num5;
				}
				while (Math.Abs(num / num3 - 1.0) > 0.01)
				{
					num = num3;
					num3 = Fi(num, r, t);
				}
				return num3;
			}

			private static double Falfa(double al, double r, int t, out double df)
			{
				Hypfun(al, out var sinh, out var cosh);
				double result;
				if (t == 1)
				{
					result = al * sinh / cosh - 1.0 - r / cosh;
					df = (sinh + (al + r * sinh) / cosh) / cosh;
				}
				else
				{
					result = al - (sinh + r) / cosh;
					df = al - (sinh + r) / cosh;
				}
				return result;
			}

			private static double Fi(double al, double r, int t)
			{
				double df;
				double num = Falfa(al, r, t, out df);
				return al - num / df;
			}

			private static double Recipgam(double x, out double q, out double r)
			{
				if (x == 0.0)
				{
					q = 0.5772156649015329;
					r = -0.6558780715202539;
				}
				else
				{
					double num = 2.0 * x;
					double t = 2.0 * num * num - 1.0;
					double[] ak = new double[9] { 1.142022680371168, -0.006516511267073688, -0.0003087090173085368, 3.4706269649043E-06, -6.9437664487E-09, -3.67795399E-11, 1.356395E-13, 3.68E-17, -5.5E-19 };
					q = Chepolsum(8, t, ak);
					ak = new double[9] { -1.2705836257787275, 0.020508324185970036, -7.84761097993185E-05, -5.37779898402E-07, 3.8823289907E-09, -2.6758703E-12, -2.3986E-14, 3.8E-17, 4E-20 };
					r = Chepolsum(8, t, ak);
				}
				return 1.0 + x * (q + x * r);
			}

			private static double Errorfunction(double x, bool erfcc, bool expo)
			{
				if (erfcc)
				{
					if (x < -6.5)
					{
						return 2.0;
					}
					if (x < 0.0)
					{
						return 2.0 - Errorfunction(0.0 - x, erfcc: true, expo: false);
					}
					if (x == 0.0)
					{
						return 1.0;
					}
					double num;
					if (x < 0.5)
					{
						num = (expo ? Math.Exp(x * x) : 1.0);
						return num * (1.0 - Errorfunction(x, erfcc: false, expo: false));
					}
					if (x < 4.0)
					{
						num = (expo ? 1.0 : Math.Exp((0.0 - x) * x));
						double[] r = new double[9] { 1230.3393547979972, 2051.0783778260716, 1712.0476126340707, 881.952221241769, 298.6351381974001, 66.11919063714163, 8.883149794388377, 0.5641884969886701, 2.1531153547440383E-08 };
						double[] s = new double[8] { 1230.3393548037495, 3439.3676741437216, 4362.619090143247, 3290.7992357334597, 1621.3895745666903, 537.1811018620099, 117.6939508913125, 15.744926110709835 };
						return num * Fractio(x, 8, r, s);
					}
					double num2 = x * x;
					num = (expo ? 1.0 : Math.Exp(0.0 - num2));
					num2 = 1.0 / num2;
					double[] r2 = new double[6] { 0.0006587491615298378, 0.016083785148742275, 0.12578172611122926, 0.36034489994980445, 0.30532663496123236, 0.016315387137302097 };
					double[] s2 = new double[5] { 0.0023352049762686918, 0.06051834131244132, 0.5279051029514285, 1.8729528499234604, 2.568520192289822 };
					return num * (0.5641895835477563 - num2 * Fractio(num2, 5, r2, s2)) / x;
				}
				if (x == 0.0)
				{
					return 0.0;
				}
				if (Math.Abs(x) > 6.5)
				{
					return x / Math.Abs(x);
				}
				if (x > 0.5)
				{
					return 1.0 - Errorfunction(x, erfcc: true, expo: false);
				}
				if (x < -0.5)
				{
					return Errorfunction(0.0 - x, erfcc: true, expo: false) - 1.0;
				}
				double[] r3 = new double[5] { 3209.3775891384694, 377.485237685302, 113.86415415105016, 3.1611237438705655, 0.18577770618460315 };
				double[] s3 = new double[4] { 2844.236833439171, 1282.6165260773723, 244.02463793444417, 23.601290952344122 };
				double x2 = x * x;
				return x * Fractio(x2, 4, r3, s3);
			}

			private static double Fractio(double x, int n, double[] r, double[] s)
			{
				double num = r[n];
				double num2 = 1.0;
				for (int num3 = n - 1; num3 >= 0; num3--)
				{
					num = num * x + r[num3];
					num2 = num2 * x + s[num3];
				}
				return num / num2;
			}

			private static double Zetaxy(double x, double y)
			{
				double num = y - x - 1.0;
				double num2 = Math.Pow(x, 2.0);
				double num3 = Math.Pow(x, 3.0);
				double num4 = Math.Pow(x, 4.0);
				double num5 = Math.Pow(x, 5.0);
				double num6 = Math.Pow(x, 6.0);
				double num7 = Math.Pow(x, 7.0);
				double num8 = Math.Pow(x, 8.0);
				double num9 = Math.Pow(x, 9.0);
				double num10 = Math.Pow(x, 10.0);
				double num11 = 2.0 * x + 1.0;
				double num15;
				if (Math.Abs(num) < 0.05)
				{
					double[] array = new double[11]
					{
						1.0,
						-1.0 / 3.0 * (3.0 * x + 1.0),
						1.0 / 36.0 * (72.0 * num2 + 42.0 * x + 7.0),
						-1.0 / 540.0 * (2700.0 * num3 + 2142.0 * num2 + 657.0 * x + 73.0),
						7.716049382716049E-05 * (1331.0 + 15972.0 * x + 76356.0 * num2 + 177552.0 * num3 + 181440.0 * num4),
						-3.6743092298647855E-06 * (22409.0 + 336135.0 * x + 2115000.0 * num2 + 7097868.0 * num3 + 13105152.0 * num4 + 11430720.0 * num5),
						1.8371546149323928E-07 * (6706278.0 * x + 52305684.0 * num2 + 228784392.0 * num3 + 602453376.0 * num4 + 935038080.0 * num5 + 718502400.0 * num6 + 372571.0),
						-6.12384871644131E-08 * (953677.0 + 20027217.0 * x + 186346566.0 * num2 + 1003641768.0 * num3 + 3418065864.0 * num4 + 7496168976.0 * num5 + 10129665600.0 * num6 + 7005398400.0 * num7),
						1.2758018159252727E-09 * (39833047.0 + 955993128.0 * x + 1120863744000.0 * num8 + 10332818424.0 * num2 + 66071604672.0 * num3 + 275568952176.0 * num4 + 776715910272.0 * num5 + 1472016602880.0 * num6 + 1773434373120.0 * num7),
						-2.577377405909642E-12 * (17422499659.0 + 470407490793.0 * x + 3228423729868800.0 * num8 + 1886413681152000.0 * num9 + 5791365522720.0 * num2 + 42859969263000.0 * num3 + 211370902874640.0 * num4 + 726288467241168.0 * num5 + 1759764571151616.0 * num6 + 2954947944510720.0 * num7),
						1.5341532178033583E-13 * (261834237251.0 + 7855027117530.0 * x + 2.0014964044100813E+17 * num8 + 2.0085546015166464E+17 * num9 + 1.094805903679488E+17 * num10 + 108506889674064.0 * num2 + 912062714644368.0 * num3 + 5189556987668592.0 * num4 + 21011917557260450.0 * num5 + 61823384007654530.0 * num6 + 1.3213161775714867E+17 * num7)
					};
					double x2 = num / (num11 * num11);
					double num12 = 1.0;
					double num13 = 1.0;
					int num14 = 1;
					while (Math.Abs(num13) > 1E-15 && num14 < 11)
					{
						num13 = array[num14] * Math.Pow(x2, num14);
						num12 += num13;
						num14++;
					}
					num15 = (0.0 - num) / Math.Sqrt(num11) * num12;
				}
				else
				{
					double num16 = Math.Sqrt(1.0 + 4.0 * x * y);
					num15 = Math.Sqrt(2.0 * (x + y - num16 - Math.Log(2.0 * y / (1.0 + num16))));
					if (x + 1.0 < y)
					{
						num15 = 0.0 - num15;
					}
				}
				return num15;
			}

			private static double Chepolsum(int n, double t, double[] ak)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = t + t;
				for (int num5 = n; num5 >= 0; num5--)
				{
					num3 = num2;
					num2 = num;
					num = num4 * num2 - num3 + ak[num5];
				}
				return (num - num3) / 2.0;
			}

			private static double Oddchepolsum(int n, double x, double[] ak)
			{
				switch (n)
				{
				case 0:
					return ak[0] * x;
				case 1:
					return x * (ak[0] + ak[1] * (4.0 * x * x - 3.0));
				default:
				{
					double num = 2.0 * (2.0 * x * x - 1.0);
					double num2 = ak[n];
					double num3 = ak[n - 1] + num2 * num;
					for (int num4 = n - 2; num4 >= 0; num4--)
					{
						double num5 = num2;
						num2 = num3;
						num3 = ak[num4] + num2 * num - num5;
					}
					return x * (num3 - num2);
				}
				}
			}

			private static double Logoneplusx(double t)
			{
				if (-0.2928 < t && t < 0.4142)
				{
					double[] array = new double[101];
					double twoExp1Over = TwoExp1Over4;
					twoExp1Over = (twoExp1Over - 1.0) / (twoExp1Over + 1.0);
					double num = (array[0] = twoExp1Over);
					double num2 = twoExp1Over * twoExp1Over;
					double value = 1.0;
					int num3 = 1;
					while (Math.Abs(value) > 1E-20)
					{
						num *= num2;
						value = (array[num3] = num / (2.0 * (double)num3 + 1.0));
						num3++;
					}
					double x = t / (2.0 + t) * (1.0 + num2) / (2.0 * twoExp1Over);
					return 4.0 * Oddchepolsum(num3 - 1, x, array);
				}
				return Math.Log(1.0 + t);
			}

			private static double Xminsinx(double x)
			{
				if (Math.Abs(x) > 1.0)
				{
					return 6.0 * (x - Math.Sin(x)) / (x * x * x);
				}
				double[] ak = new double[9] { 1.9508826048781982, -0.024412447032443958, 0.000145741981563655, -5.073893903402518E-07, 1.1556455068443E-09, -1.85522118416E-12, 2.2117315E-15, -2.035E-18, 1.5E-21 };
				double t = 2.0 * x * x - 1.0;
				return Chepolsum(8, t, ak);
			}

			private static double Trapsum(double a, double b, double h, double d, double xis2, double mu, double wxis, double ys)
			{
				double num = 0.0;
				double b2 = b;
				double inte;
				double num2;
				double num3;
				if (d == 0.0)
				{
					Integrand(a, ref b2, out inte, xis2, mu, wxis, ys);
					num = inte / 2.0;
					num2 = a + h;
					num3 = b - h / 2.0;
				}
				else
				{
					num2 = a + d;
					num3 = b;
				}
				for (; num2 < num3 && num2 < b2; num2 += h)
				{
					Integrand(num2, ref b2, out inte, xis2, mu, wxis, ys);
					num += inte;
				}
				return num * h;
			}

			private static double Trap(double a, double b, double e, double xis2, double mu, double wxis, double ys)
			{
				double num = (b - a) / 8.0;
				double num2 = Trapsum(a, b, num, 0.0, xis2, mu, wxis, ys);
				double num3 = 0.0;
				double num4 = 1.0;
				while ((num4 > e && num3 < 10.0) || num3 <= 2.0)
				{
					num3 += 1.0;
					double num5 = Trapsum(a, b, num, num / 2.0, xis2, mu, wxis, ys);
					num4 = ((Math.Abs(num5) > 0.0) ? Math.Abs(num2 / num5 - 1.0) : 0.0);
					num /= 2.0;
					num2 = (num2 + num5) / 2.0;
				}
				return num2;
			}

			private static void Integrand(double theta, ref double b0, out double inte, double xis2, double mu, double wxis, double ys)
			{
				double num = Math.Log(1E-16);
				double num2;
				if (theta > b0)
				{
					num2 = 0.0;
				}
				else if (Math.Abs(theta) < 1E-10)
				{
					double num3 = (1.0 + wxis) / (2.0 * ys);
					double num4 = theta * theta;
					double num5 = (0.0 - wxis) * num4 * 0.5;
					num2 = num3 / (1.0 - num3) * Math.Exp(mu * num5);
				}
				else
				{
					double num6 = theta * theta;
					double num7 = Math.Sin(theta);
					double num8 = Math.Cos(theta);
					double num9 = theta / num7;
					double num10 = num7 * num7;
					double num11 = Math.Sqrt(num9 * num9 + xis2);
					double num12 = Xminsinx(theta);
					double num13 = num12 * num6 * num9 / 6.0;
					double num14 = (num13 * (num9 + 1.0) - num6 - num10 * xis2) / (num8 * num11 + wxis);
					double num15 = 0.0 - Logoneplusx(num13 * ((1.0 + (num9 + 1.0) / (num11 + wxis)) / (1.0 + wxis)));
					double num16 = num14 + num15;
					num2 = mu * num16;
					if (num2 > num)
					{
						num2 = Math.Exp(num2);
					}
					else
					{
						num2 = 0.0;
						b0 = Math.Min(theta, b0);
					}
					double num17 = (num9 + num11) / (2.0 * ys);
					double num18 = Math.Sin(theta / 2.0);
					double num19 = ((2.0 * theta * num18 * num18 - num12 * num6 * theta / 6.0) / (2.0 * ys * num10) * (1.0 + num9 / num11) * num7 + (num8 - num17) * num17) / (num17 * (num17 - 2.0 * num8) + 1.0);
					num2 *= num19;
				}
				inte = num2;
			}

			private static void Qser(double mu, double x, double y, out double p, out double q, out int ierro)
			{
				ierro = 0;
				IncompleteGamma.Incgam(mu, y, out p, out q, out var ierr);
				double num = q;
				double num2 = mu * Math.Log(y) - y - IncompleteGamma.Loggam(mu + 1.0);
				if (num2 > Math.Log(Dwarf) && x < 100.0)
				{
					double num3 = Math.Exp(num2);
					double num4 = x * y;
					double num5 = Epss / 100.0;
					int num6 = 0;
					while (num / q > num5 && num6 < 1000)
					{
						num = x * (num + num3) / ((double)num6 + 1.0);
						num3 = num4 * num3 / (((double)num6 + 1.0) * (mu + (double)num6 + 1.0));
						q += num;
						num6++;
					}
					q = Math.Exp(0.0 - x) * q;
					p = 1.0 - q;
					return;
				}
				double num7 = 0.0;
				double num8 = 0.0;
				int num9 = 0;
				while (num8 < 10000.0 && num9 == 0)
				{
					IncompleteGamma.Incgam(mu + num8, y, out var _, out var q2, out ierr);
					double num10 = IncompleteGamma.Dompart(num8, x, qt: false) * q2;
					num7 += num10;
					num8 += 1.0;
					if (num7 == 0.0 && num8 < 150.0)
					{
						num9 = 1;
					}
					if (num7 > 0.0 && num10 / num7 < 1E-16 && num8 > 10.0)
					{
						num9 = 1;
					}
				}
				if (ierr == 0)
				{
					q = num7;
					p = 1.0 - q;
				}
				else
				{
					q = 0.0;
					p = 1.0;
					ierro = 1;
				}
			}

			private static void Pser(double mu, double x, double y, out double p, out double q, out int ierro)
			{
				ierro = 0;
				int ierr = 0;
				double num = x * y;
				int num2 = Startingpser(mu, x, y);
				int num3 = 1 + num2;
				double num4 = 0.0 - x - y + (double)num3 * Math.Log(x) + ((double)num3 + mu) * Math.Log(y) - IncompleteGamma.Loggam(mu + (double)num3 + 1.0) - IncompleteGamma.Loggam((double)num3 + 1.0);
				if (num4 < Math.Log(Dwarf))
				{
					double num5 = Math.Exp(0.0 - x);
					double num6 = 0.0;
					int num7 = Startingpser(mu, x, y) + 1;
					double p2;
					double q2;
					while (num7 > 0 && ierr == 0)
					{
						double a = mu + (double)num7;
						double num8 = Factor(x, num7);
						IncompleteGamma.Incgam(a, y, out p2, out q2, out ierr);
						double num9 = num8 * p2;
						num6 += num9;
						num7--;
						num7--;
					}
					if (ierr == 0)
					{
						IncompleteGamma.Incgam(mu, y, out p2, out q2, out ierr);
						num6 += p2;
						p = num6 * num5;
						q = 1.0 - p;
					}
					else
					{
						ierro = 1;
						p = 0.0;
						q = 1.0;
					}
					return;
				}
				double num10 = Math.Exp(num4);
				IncompleteGamma.Incgam(mu + (double)num3, y, out p, out q, out ierr);
				if (ierr == 0)
				{
					double p2 = p * Math.Exp(0.0 - x + (double)num3 * Math.Log(x) - IncompleteGamma.Loggam(num3 + 1));
					p = 0.0;
					for (int num11 = num3; num11 > 0; num11--)
					{
						num10 = num10 * (double)num11 * (mu + (double)num11) / num;
						p2 = (double)num11 * p2 / x + num10;
						p += p2;
					}
					q = 1.0 - p;
				}
				else
				{
					ierro = 1;
					p = 0.0;
					q = 1.0;
				}
			}

			private static void Prec(double mu, double x, double y, out double p, out double q, out int ierro)
			{
				ierro = 0;
				int ierr = 0;
				double num = 1.0;
				double a = y - x + num * num + num * Math.Sqrt(2.0 * (x + y) + num * num);
				int num2 = (int)Math.Round(mu);
				int num3 = (int)Math.Round(a) + 2 - num2;
				double num4 = mu + (double)num3;
				double z = 2.0 * Math.Sqrt(x * y);
				double num5 = Math.Sqrt(y / x) * Fc(num4, z);
				MarcumPQtrap(num4 + 1.0, x, y, out var p2, out q, ref ierr);
				MarcumPQtrap(num4 + 0.0, x, y, out var p3, out q, ref ierr);
				if (ierr == 0)
				{
					p = 0.0;
					for (int i = 0; i < num3; i++)
					{
						p = ((1.0 + num5) * p3 - p2) / num5;
						p2 = p3;
						p3 = p;
						num5 = y / (num4 - (double)i - 1.0 + x * num5);
					}
					q = 1.0 - p;
				}
				else
				{
					p = 0.0;
					q = 1.0;
					ierro = 1;
				}
			}

			private static void Qrec(double mu, double x, double y, out double p, out double q, out int ierro)
			{
				ierro = 0;
				int ierr = 0;
				double num = 1.0;
				double num2 = y - x + num * (num - Math.Sqrt(2.0 * (x + y) + num * num));
				if (num2 < 5.0)
				{
					if (x < 200.0)
					{
						Qser(mu, x, y, out p, out q, out ierr);
					}
					else
					{
						Prec(mu, x, y, out p, out q, out ierr);
					}
					return;
				}
				int num3 = (int)Math.Round(mu);
				int num4 = (int)Math.Round(num2) - 1;
				int num5 = num3 - num4;
				double num6 = mu - (double)num5;
				double z = 2.0 * Math.Sqrt(x * y);
				double[] array = new double[301];
				array[0] = Math.Sqrt(y / x) * Fc(mu, z);
				for (int i = 1; i <= num5; i++)
				{
					array[i] = y / (mu - (double)i + x * array[i - 1]);
				}
				MarcumPQtrap(num6 - 1.0, x, y, out p, out var q2, ref ierr);
				MarcumPQtrap(num6 + 0.0, x, y, out p, out var q3, ref ierr);
				if (ierr == 0)
				{
					q = 0.0;
					for (int j = 1; j <= num5; j++)
					{
						double num7 = array[num5 + 1 - j];
						q = (1.0 + num7) * q3 - num7 * q2;
						q2 = q3;
						q3 = q;
					}
					p = 1.0 - q;
				}
				else
				{
					q = 0.0;
					p = 1.0;
					ierro = 1;
				}
			}

			private static void PQasyxy(double mu, double x, double y, out double p, out double q, out int ierro)
			{
				ierro = 0;
				double num = ((y >= x) ? 1.0 : (-1.0));
				double num2 = Epss / 100.0;
				double num3 = 2.0 * Math.Sqrt(x * y);
				double num4 = Math.Sqrt(num3);
				double num5 = Math.Sqrt(y / x);
				double num6 = (y - x) * (y - x) / (x + y + num3);
				double num7 = mu * Math.Log(num5);
				if (num7 < Math.Log(Dwarf) || num7 > Math.Log(Giant))
				{
					q = ((num == 1.0) ? 0.0 : 1.0);
					p = ((num == 1.0) ? 1.0 : 0.0);
					ierro = 1;
					return;
				}
				double num8 = Math.Exp(num7);
				double num9 = Errorfunction(Math.Sqrt(num6), erfcc: true, expo: true);
				double num10 = 0.5 * num8 * num9 / Math.Sqrt(num5);
				double num11 = 2.0 * mu - 1.0;
				double num12 = num11 * (num5 - 1.0);
				double num13 = 2.0 * (num5 + 1.0);
				double num14 = 4.0 * mu * mu;
				double num15 = num * num8 / Math.Sqrt(Math.PI * 8.0);
				double num16 = num4;
				int num17 = 0;
				int num18 = 100;
				double[] array = new double[101];
				array[0] = 1.0;
				while (Math.Abs(array[num17]) > num2 && num17 < num18)
				{
					num17++;
					int num19 = 2 * num17 - 1;
					num16 = (num14 - (double)(num19 * num19)) * num16 / ((double)(8 * num17) * num3);
					array[num17] = num16 * (num12 - (double)num17 * num13) / (num5 * (num11 + (double)(2 * num17)));
				}
				num18 = num17;
				int num20 = Math.Min(num18, (int)Math.Round(num6) + 1);
				double[] array2 = new double[101];
				array2[num20] = Math.Exp(((double)num20 - 0.5) * Math.Log(num6)) * Ignega(num20, num6);
				for (int i = num20 + 1; i <= num18; i++)
				{
					array2[i] = ((0.0 - num6) * array2[i - 1] + 1.0) / ((double)i - 0.5);
				}
				for (int num21 = num20 - 1; num21 >= 1; num21--)
				{
					array2[num21] = (1.0 - ((double)num21 + 0.5) * array2[num21 + 1]) / num6;
				}
				double num22 = num10;
				for (int j = 1; j <= num18; j++)
				{
					num15 = 0.0 - num15;
					double num23 = num15 * array[j] * array2[j];
					num22 += num23;
				}
				num22 *= Math.Exp(0.0 - num6);
				if (num == 1.0)
				{
					q = num22;
					p = 1.0 - q;
				}
				else
				{
					p = num22;
					q = 1.0 - p;
				}
			}

			private static void PQasymu(double mu0, double x0, double y0, out double p, out double q, out int ierro)
			{
				ierro = 0;
				double num = mu0 - 1.0;
				double num2 = x0 / num;
				double y1 = y0 / num;
				double num3 = Zetaxy(num2, y1);
				int num4 = ((num3 < 0.0) ? 1 : (-1));
				double u = 1.0 / Math.Sqrt(2.0 * num2 + 1.0);
				double[,] array = new double[17, 17];
				Fjkproc16(u, array);
				num3 = (double)num4 * num3;
				double num5 = num3 * Math.Sqrt(num / 2.0);
				double[] array2 = new double[18];
				int num6 = 1;
				array2[num6] = Math.Sqrt(Math.PI / (2.0 * num)) * Errorfunction(0.0 - num5, erfcc: true, expo: false);
				double num7 = array2[num6];
				double num8 = (0.0 - num) * 0.5 * num3 * num3;
				if (num8 < Math.Log(Dwarf) || num8 > Math.Log(Giant))
				{
					if (num4 == 1)
					{
						q = 0.0;
						p = 1.0;
					}
					else
					{
						p = 0.0;
						q = 1.0;
					}
					ierro = 1;
					return;
				}
				num5 = Math.Exp(num8);
				array2[-1 + num6] = 0.0;
				double[] array3 = new double[17]
				{
					1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
					0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0
				};
				double num9 = num7;
				int num10 = 1;
				double num11 = 1.0;
				while (Math.Abs(num9 / num7) > 1E-30 && num10 <= 16)
				{
					array3[num10] = num * array3[num10 - 1];
					array2[num10 + num6] = ((double)(num10 - 1) * array2[num10 - 2 + num6] + num5 * num11) / num;
					num9 = 0.0;
					int num12 = 1;
					num11 = (0.0 - num3) * num11;
					for (int i = 0; i <= num10; i++)
					{
						int num13 = ((num4 != -1 || num12 != -1) ? 1 : (-1));
						num12 = -num12;
						num9 += (double)num13 * array[i, num10 - i] * array2[i + num6] / array3[num10 - i];
					}
					num7 += num9;
					num10++;
				}
				num5 = Math.Sqrt(num / (Math.PI * 2.0)) * num7;
				if (num4 == 1)
				{
					q = num5;
					p = 1.0 - q;
				}
				else
				{
					p = num5;
					q = 1.0 - p;
				}
			}

			private static void MarcumPQtrap(double mu, double x, double y, out double p, out double q, ref int ierr)
			{
				double num = x / mu;
				double num2 = y / mu;
				double num3 = 4.0 * num * num2;
				double wxis = Math.Sqrt(1.0 + num3);
				double b = 3.0;
				double e = 1E-13;
				double num4 = Trap(0.0, b, e, num3, mu, wxis, num2);
				double num5 = Zetaxy(num, num2);
				if ((0.0 - mu) * 0.5 * num5 * num5 < Math.Log(Dwarf))
				{
					if (y > x + mu)
					{
						p = 1.0;
						q = 0.0;
					}
					else
					{
						p = 0.0;
						q = 1.0;
					}
					ierr = 1;
				}
				else
				{
					num4 = num4 * Math.Exp((0.0 - mu) * 0.5 * num5 * num5) / Math.PI;
					if (num5 < 0.0)
					{
						q = num4;
						p = 1.0 - q;
					}
					else
					{
						p = 0.0 - num4;
						q = 1.0 - p;
					}
				}
			}
		}

		private static readonly double[] ErfImpAn = new double[8] { 0.0033791670955125737, -0.0007369565304816795, -0.3747323373929196, 0.08174424487335873, -0.04210893199365486, 0.007016570951209575, -0.004950912559824351, 0.0008716465990379225 };

		private static readonly double[] ErfImpAd = new double[8] { 1.0, -0.21808821808792464, 0.4125429727254421, -0.08418911478731067, 0.06553388564002416, -0.012001960445494177, 0.00408165558926174, -0.0006159007215577697 };

		private static readonly double[] ErfImpBn = new double[6] { -0.03617903907182625, 0.2922518834448827, 0.2814470417976045, 0.12561020886276694, 0.027413502826893053, 0.0025083967216806575 };

		private static readonly double[] ErfImpBd = new double[6] { 1.0, 1.8545005897903486, 1.4357580303783142, 0.5828276587530365, 0.12481047693294975, 0.011372417654635328 };

		private static readonly double[] ErfImpCn = new double[7] { -0.03978768926111369, 0.1531652124678783, 0.19126029560093624, 0.10276327061989304, 0.029637090615738836, 0.004609348678027549, 0.0003076078203486802 };

		private static readonly double[] ErfImpCd = new double[7] { 1.0, 1.955200729876277, 1.6476231719938486, 0.7682386070221262, 0.20979318593650978, 0.031956931689991336, 0.0021336316089578537 };

		private static readonly double[] ErfImpDn = new double[7] { -0.030083856055794972, 0.05385788298444545, 0.07262115416519142, 0.036762846988804936, 0.009646290155725275, 0.0013345348007529107, 7.780875997825043E-05 };

		private static readonly double[] ErfImpDd = new double[8] { 1.0, 1.7596709814716753, 1.3288357143796112, 0.5525285965087576, 0.13379305694133287, 0.017950964517628076, 0.0010471244001993736, -1.0664038182035734E-08 };

		private static readonly double[] ErfImpEn = new double[7] { -0.011790757013722784, 0.01426213209053881, 0.020223443590296084, 0.009306682999904321, 0.00213357802422066, 0.00025022987386460105, 1.2053491221958819E-05 };

		private static readonly double[] ErfImpEd = new double[7] { 1.0, 1.5037622520362048, 0.9653977862044629, 0.3392652304767967, 0.06897406495415698, 0.007710602624917683, 0.0003714211015310693 };

		private static readonly double[] ErfImpFn = new double[7] { -0.005469547955387293, 0.004041902787317071, 0.005496336955316117, 0.002126164726039454, 0.0003949840144950839, 3.655654770644424E-05, 1.3548589710993232E-06 };

		private static readonly double[] ErfImpFd = new double[8] { 1.0, 1.2101969777363077, 0.6209146682211439, 0.17303843066114277, 0.027655081377343203, 0.0024062597442430973, 8.918118172513365E-05, -4.655288362833827E-12 };

		private static readonly double[] ErfImpGn = new double[6] { -0.0027072253590577837, 0.00131875634250294, 0.0011992593326100233, 0.00027849619811344664, 2.6782298821833186E-05, 9.230436723150282E-07 };

		private static readonly double[] ErfImpGd = new double[7] { 1.0, 0.8146328085431416, 0.26890166585629954, 0.044987721610304114, 0.0038175966332024847, 0.00013157189788859692, 4.048153596757641E-12 };

		private static readonly double[] ErfImpHn = new double[6] { -0.001099467206917422, 0.00040642544275042267, 0.0002744994894169007, 4.652937706466594E-05, 3.2095542539576746E-06, 7.782860181450209E-08 };

		private static readonly double[] ErfImpHd = new double[6] { 1.0, 0.5881737106118461, 0.13936333128940975, 0.016632934041708368, 0.0010002392131023491, 2.4254837521587224E-05 };

		private static readonly double[] ErfImpIn = new double[5] { -0.0005690799360109496, 0.00016949854037376225, 5.184723545811009E-05, 3.8281931223192885E-06, 8.249899312818944E-08 };

		private static readonly double[] ErfImpId = new double[6] { 1.0, 0.33963725005113937, 0.04347264787031066, 0.002485493352246371, 5.356333053371529E-05, -1.1749094440545958E-13 };

		private static readonly double[] ErfImpJn = new double[5] { -0.00024131359948399134, 5.742249752025015E-05, 1.1599896292738377E-05, 5.817621344025938E-07, 8.539715550856736E-09 };

		private static readonly double[] ErfImpJd = new double[5] { 1.0, 0.23304413829968784, 0.02041869405464403, 0.0007971856475643983, 1.1701928167017232E-05 };

		private static readonly double[] ErfImpKn = new double[5] { -0.00014667469927776036, 1.6266655211228053E-05, 2.6911624850916523E-06, 9.79584479468092E-08, 1.0199464762572346E-09 };

		private static readonly double[] ErfImpKd = new double[5] { 1.0, 0.16590781294484722, 0.010336171619150588, 0.0002865930263738684, 2.9840157084090034E-06 };

		private static readonly double[] ErfImpLn = new double[5] { -5.839057976297718E-05, 4.125103251054962E-06, 4.3179092242025094E-07, 9.933651555900132E-09, 6.534805100201047E-11 };

		private static readonly double[] ErfImpLd = new double[5] { 1.0, 0.10507708607203992, 0.004142784286754756, 7.263387546445238E-05, 4.778184710473988E-07 };

		private static readonly double[] ErfImpMn = new double[4] { -1.9645779760922958E-05, 1.572438876668007E-06, 5.439025111927009E-08, 3.174724923691177E-10 };

		private static readonly double[] ErfImpMd = new double[5] { 1.0, 0.05280398924095763, 0.0009268760691517533, 5.410117232266303E-06, 5.350938458036424E-16 };

		private static readonly double[] ErfImpNn = new double[4] { -7.892247039787227E-06, 6.22088451660987E-07, 1.457284456768824E-08, 6.037155055427153E-11 };

		private static readonly double[] ErfImpNd = new double[4] { 1.0, 0.03753288463562937, 0.0004679195359746253, 1.9384703927584565E-06 };

		private static readonly double[] ErvInvImpAn = new double[8] { -0.0005087819496582806, -0.008368748197417368, 0.03348066254097446, -0.012692614766297404, -0.03656379714117627, 0.02198786811111689, 0.008226878746769157, -0.005387729650712429 };

		private static readonly double[] ErvInvImpAd = new double[10] { 1.0, -0.9700050433032906, -1.5657455823417585, 1.5622155839842302, 0.662328840472003, -0.7122890234154284, -0.05273963823400997, 0.07952836873415717, -0.0023339375937419, 0.0008862163904564247 };

		private static readonly double[] ErvInvImpBn = new double[9] { -0.20243350835593876, 0.10526468069939171, 8.3705032834312, 17.644729840837403, -18.851064805871424, -44.6382324441787, 17.445385985570866, 21.12946554483405, -3.6719225470772936 };

		private static readonly double[] ErvInvImpBd = new double[9] { 1.0, 6.242641248542475, 3.971343795334387, -28.66081804998, -20.14326346804852, 48.560921310873994, 10.826866735546016, -22.643693341313973, 1.7211476576120028 };

		private static readonly double[] ErvInvImpCn = new double[11]
		{
			-0.1311027816799519, -0.16379404719331705, 0.11703015634199525, 0.38707973897260434, 0.3377855389120359, 0.14286953440815717, 0.029015791000532906, 0.0021455899538880526, -6.794655751811263E-07, 2.8522533178221704E-08,
			-6.81149956853777E-10
		};

		private static readonly double[] ErvInvImpCd = new double[8] { 1.0, 3.4662540724256723, 5.381683457070069, 4.778465929458438, 2.5930192162362027, 0.848854343457902, 0.15226433829533179, 0.011059242293464892 };

		private static readonly double[] ErvInvImpDn = new double[9] { -0.0350353787183178, -0.0022242652921344794, 0.018557330651423107, 0.009508047013259196, 0.0018712349281955923, 0.00015754461742496055, 4.60469890584318E-06, -2.304047769118826E-10, 2.6633922742578204E-12 };

		private static readonly double[] ErvInvImpDd = new double[7] { 1.0, 1.3653349817554064, 0.7620591645536234, 0.22009110576413124, 0.03415891436709477, 0.00263861676657016, 7.646752923027944E-05 };

		private static readonly double[] ErvInvImpEn = new double[9] { -0.016743100507663373, -0.0011295143874558028, 0.001056288621524929, 0.00020938631748758808, 1.4962478375834237E-05, 4.4969678992770644E-07, 4.625961635228786E-09, -2.811287356288318E-14, 9.905570997331033E-17 };

		private static readonly double[] ErvInvImpEd = new double[7] { 1.0, 0.5914293448864175, 0.1381518657490833, 0.016074608709367652, 0.0009640118070051656, 2.7533547476472603E-05, 2.82243172016108E-07 };

		private static readonly double[] ErvInvImpFn = new double[8] { -0.002497821279189813, -7.79190719229054E-06, 2.5472303741302746E-05, 1.6239777734251093E-06, 3.963410113048012E-08, 4.116328311909442E-10, 1.4559628671867504E-12, -1.1676501239718427E-18 };

		private static readonly double[] ErvInvImpFd = new double[7] { 1.0, 0.2071231122144225, 0.01694108381209759, 0.0006905382656226846, 1.4500735981823264E-05, 1.4443775662814415E-07, 5.097612765997785E-10 };

		private static readonly double[] ErvInvImpGn = new double[8] { -0.0005390429110190785, -2.8398759004727723E-07, 8.994651148922914E-07, 2.2934585926592085E-08, 2.2556144486350015E-10, 9.478466275030226E-13, 1.3588013010892486E-15, -3.4889039339994887E-22 };

		private static readonly double[] ErvInvImpGd = new double[7] { 1.0, 0.08457462340018994, 0.002820929847262647, 4.682929219408942E-05, 3.999688121938621E-07, 1.6180929088790448E-09, 2.315586083102596E-12 };

		private static readonly double[] _factorialCache = new double[171]
		{
			1.0, 1.0, 2.0, 6.0, 24.0, 120.0, 720.0, 5040.0, 40320.0, 362880.0,
			3628800.0, 39916800.0, 479001600.0, 6227020800.0, 87178291200.0, 1307674368000.0, 20922789888000.0, 355687428096000.0, 6402373705728000.0, 1.21645100408832E+17,
			2.43290200817664E+18, 5.109094217170944E+19, 1.1240007277776077E+21, 2.585201673888498E+22, 6.204484017332394E+23, 1.5511210043330986E+25, 4.0329146112660565E+26, 1.0888869450418352E+28, 3.0488834461171384E+29, 8.841761993739701E+30,
			2.6525285981219103E+32, 8.222838654177922E+33, 2.631308369336935E+35, 8.683317618811886E+36, 2.9523279903960412E+38, 1.0333147966386144E+40, 3.719933267899012E+41, 1.3763753091226343E+43, 5.23022617466601E+44, 2.0397882081197442E+46,
			8.159152832478977E+47, 3.3452526613163803E+49, 1.4050061177528798E+51, 6.041526306337383E+52, 2.6582715747884485E+54, 1.1962222086548019E+56, 5.5026221598120885E+57, 2.5862324151116818E+59, 1.2413915592536073E+61, 6.082818640342675E+62,
			3.0414093201713376E+64, 1.5511187532873822E+66, 8.065817517094388E+67, 4.2748832840600255E+69, 2.308436973392414E+71, 1.2696403353658276E+73, 7.109985878048635E+74, 4.052691950487722E+76, 2.350561331282879E+78, 1.3868311854568986E+80,
			8.320987112741392E+81, 5.075802138772248E+83, 3.146997326038794E+85, 1.98260831540444E+87, 1.2688693218588417E+89, 8.247650592082472E+90, 5.443449390774431E+92, 3.647111091818868E+94, 2.4800355424368305E+96, 1.711224524281413E+98,
			1.197857166996989E+100, 8.504785885678622E+101, 6.123445837688608E+103, 4.4701154615126834E+105, 3.3078854415193856E+107, 2.480914081139539E+109, 1.8854947016660498E+111, 1.4518309202828584E+113, 1.1324281178206295E+115, 8.946182130782973E+116,
			7.156945704626378E+118, 5.797126020747366E+120, 4.75364333701284E+122, 3.945523969720657E+124, 3.314240134565352E+126, 2.8171041143805494E+128, 2.4227095383672724E+130, 2.107757298379527E+132, 1.8548264225739836E+134, 1.6507955160908452E+136,
			1.4857159644817607E+138, 1.3520015276784023E+140, 1.24384140546413E+142, 1.1567725070816409E+144, 1.0873661566567424E+146, 1.0329978488239052E+148, 9.916779348709491E+149, 9.619275968248206E+151, 9.426890448883242E+153, 9.33262154439441E+155,
			9.33262154439441E+157, 9.425947759838354E+159, 9.614466715035121E+161, 9.902900716486175E+163, 1.0299016745145622E+166, 1.0813967582402903E+168, 1.1462805637347078E+170, 1.2265202031961373E+172, 1.3246418194518284E+174, 1.4438595832024928E+176,
			1.5882455415227421E+178, 1.7629525510902437E+180, 1.9745068572210728E+182, 2.2311927486598123E+184, 2.543559733472186E+186, 2.925093693493014E+188, 3.3931086844518965E+190, 3.969937160808719E+192, 4.6845258497542883E+194, 5.574585761207603E+196,
			6.689502913449124E+198, 8.09429852527344E+200, 9.875044200833598E+202, 1.2146304367025325E+205, 1.5061417415111404E+207, 1.8826771768889254E+209, 2.372173242880046E+211, 3.012660018457658E+213, 3.8562048236258025E+215, 4.9745042224772855E+217,
			6.466855489220472E+219, 8.471580690878817E+221, 1.118248651196004E+224, 1.4872707060906852E+226, 1.992942746161518E+228, 2.6904727073180495E+230, 3.659042881952547E+232, 5.01288874827499E+234, 6.917786472619486E+236, 9.615723196941086E+238,
			1.346201247571752E+241, 1.89814375907617E+243, 2.6953641378881614E+245, 3.8543707171800706E+247, 5.550293832739301E+249, 8.047926057471987E+251, 1.17499720439091E+254, 1.7272458904546376E+256, 2.5563239178728637E+258, 3.808922637630567E+260,
			5.7133839564458505E+262, 8.627209774233235E+264, 1.3113358856834518E+267, 2.006343905095681E+269, 3.089769613847349E+271, 4.789142901463391E+273, 7.47106292628289E+275, 1.1729568794264138E+278, 1.8532718694937338E+280, 2.946702272495037E+282,
			4.714723635992059E+284, 7.590705053947215E+286, 1.2296942187394488E+289, 2.0044015765453015E+291, 3.2872185855342945E+293, 5.423910666131586E+295, 9.003691705778433E+297, 1.5036165148649983E+300, 2.526075744973197E+302, 4.2690680090047027E+304,
			7.257415615307994E+306
		};

		private const int GammaN = 10;

		private const double GammaR = 10.900511;

		private static readonly double[] GammaDk = new double[11]
		{
			2.4857408913875355E-05, 1.0514237858172197, -3.4568709722201625, 4.512277094668948, -2.9828522532357664, 1.056397115771267, -0.19542877319164587, 0.01709705434044412, -0.0005719261174043057, 4.633994733599057E-06,
			-2.7199490848860772E-09
		};

		private static readonly double[] BesselI0A = new double[30]
		{
			-4.4153416464793395E-18, 3.3307945188222384E-17, -2.431279846547955E-16, 1.715391285555133E-15, -1.1685332877993451E-14, 7.676185498604936E-14, -4.856446783111929E-13, 2.95505266312964E-12, -1.726826291441556E-11, 9.675809035373237E-11,
			-5.189795601635263E-10, 2.6598237246823866E-09, -1.300025009986248E-08, 6.046995022541919E-08, -2.670793853940612E-07, 1.1173875391201037E-06, -4.4167383584587505E-06, 1.6448448070728896E-05, -5.754195010082104E-05, 0.00018850288509584165,
			-0.0005763755745385824, 0.0016394756169413357, -0.004324309995050576, 0.010546460394594998, -0.02373741480589947, 0.04930528423967071, -0.09490109704804764, 0.17162090152220877, -0.3046826723431984, 0.6767952744094761
		};

		private static readonly double[] BesselI0B = new double[25]
		{
			-7.233180487874754E-18, -4.830504485944182E-18, 4.46562142029676E-17, 3.461222867697461E-17, -2.8276239805165836E-16, -3.425485619677219E-16, 1.7725601330565263E-15, 3.8116806693526224E-15, -9.554846698828307E-15, -4.150569347287222E-14,
			1.54008621752141E-14, 3.8527783827421426E-13, 7.180124451383666E-13, -1.7941785315068062E-12, -1.3215811840447713E-11, -3.1499165279632416E-11, 1.1889147107846439E-11, 4.94060238822497E-10, 3.3962320257083865E-09, 2.266668990498178E-08,
			2.0489185894690638E-07, 2.8913705208347567E-06, 6.889758346916825E-05, 0.0033691164782556943, 0.8044904110141088
		};

		private static readonly double[] BesselI1A = new double[29]
		{
			2.7779141127610464E-18, -2.111421214358166E-17, 1.5536319577362005E-16, -1.1055969477353862E-15, 7.600684294735408E-15, -5.042185504727912E-14, 3.223793365945575E-13, -1.9839743977649436E-12, 1.1736186298890901E-11, -6.663489723502027E-11,
			3.625590281552117E-10, -1.8872497517228294E-09, 9.381537386495773E-09, -4.445059128796328E-08, 2.0032947535521353E-07, -8.568720264695455E-07, 3.4702513081376785E-06, -1.3273163656039436E-05, 4.781565107550054E-05, -0.00016176081582589674,
			0.0005122859561685758, -0.0015135724506312532, 0.004156422944312888, -0.010564084894626197, 0.024726449030626516, -0.05294598120809499, 0.1026436586898471, -0.17641651835783406, 0.25258718644363365
		};

		private static readonly double[] BesselI1B = new double[25]
		{
			7.517296310842105E-18, 4.414348323071708E-18, -4.6503053684893586E-17, -3.209525921993424E-17, 2.96262899764595E-16, 3.3082023109209285E-16, -1.8803547755107825E-15, -3.8144030724370075E-15, 1.0420276984128802E-14, 4.272440016711951E-14,
			-2.1015418427726643E-14, -4.0835511110921974E-13, -7.198551776245908E-13, 2.0356285441470896E-12, 1.4125807436613782E-11, 3.2526035830154884E-11, -1.8974958123505413E-11, -5.589743462196584E-10, -3.835380385964237E-09, -2.6314688468895196E-08,
			-2.512236237870209E-07, -3.882564808877691E-06, -0.00011058893876262371, -0.009761097491361469, 0.7785762350182801
		};

		private static readonly double[] BesselK0A = new double[10] { 1.374465435613523E-16, 4.25981614279661E-14, 1.0349695257633842E-11, 1.904516377220209E-09, 2.5347910790261494E-07, 2.286212103119452E-05, 0.001264615411446926, 0.0359799365153615, 0.3442898999246285, -0.5353273932339028 };

		private static readonly double[] BesselK0B = new double[25]
		{
			5.300433772686263E-18, -1.6475804301524212E-17, 5.2103915050390274E-17, -1.678231096805412E-16, 5.512055978524319E-16, -1.848593377343779E-15, 6.3400764774050706E-15, -2.2275133269916698E-14, 8.032890775363575E-14, -2.9800969231727303E-13,
			1.140340588208475E-12, -4.514597883373944E-12, 1.8559491149547177E-11, -7.957489244477107E-11, 3.577397281400301E-10, -1.69753450938906E-09, 8.574034017414225E-09, -4.660489897687948E-08, 2.766813639445015E-07, -1.8317555227191195E-06,
			1.39498137188765E-05, -0.00012849549581627802, 0.0015698838857300533, -0.0314481013119645, 2.4403030820659555
		};

		private static readonly double[] BesselK1A = new double[11]
		{
			-7.023863479386288E-18, -2.427449850519366E-15, -6.666901694199329E-13, -1.4114883926335278E-10, -2.213387630734726E-08, -2.4334061415659684E-06, -0.0001730288957513052, -0.006975723859639864, -0.12261118082265715, -0.3531559607765449,
			1.5253002273389478
		};

		private static readonly double[] BesselK1B = new double[25]
		{
			-5.756744483665017E-18, 1.7940508731475592E-17, -5.689462558442859E-17, 1.838093544366639E-16, -6.057047248373319E-16, 2.038703165624334E-15, -7.019837090418314E-15, 2.4771544244813043E-14, -8.976705182324994E-14, 3.3484196660784293E-13,
			-1.2891739609510289E-12, 5.13963967348173E-12, -2.1299678384275683E-11, 9.218315187605006E-11, -4.1903547593418965E-10, 2.015049755197033E-09, -1.0345762465678097E-08, 5.7410841254500495E-08, -3.5019606030878126E-07, 2.406484947837217E-06,
			-1.936197974166083E-05, 0.00019521551847135162, -0.002857816859622779, 0.10392373657681724, 2.7206261904844427
		};

		public static Complex AiryAi(Complex z)
		{
			return Amos.Cairy(z);
		}

		public static Complex AiryAiScaled(Complex z)
		{
			return Amos.ScaledCairy(z);
		}

		public static double AiryAi(double z)
		{
			return AiryAi(new Complex(z, 0.0)).Real;
		}

		public static double AiryAiScaled(double z)
		{
			return Amos.ScaledCairy(z);
		}

		public static Complex AiryAiPrime(Complex z)
		{
			return Amos.CairyPrime(z);
		}

		public static Complex AiryAiPrimeScaled(Complex z)
		{
			return Amos.ScaledCairyPrime(z);
		}

		public static double AiryAiPrime(double z)
		{
			return AiryAiPrime(new Complex(z, 0.0)).Real;
		}

		public static double AiryAiPrimeScaled(double z)
		{
			return Amos.ScaledCairyPrime(z);
		}

		public static Complex AiryBi(Complex z)
		{
			return Amos.Cbiry(z);
		}

		public static Complex AiryBiScaled(Complex z)
		{
			return Amos.ScaledCbiry(z);
		}

		public static double AiryBi(double z)
		{
			return AiryBi(new Complex(z, 0.0)).Real;
		}

		public static double AiryBiScaled(double z)
		{
			return AiryBiScaled(new Complex(z, 0.0)).Real;
		}

		public static Complex AiryBiPrime(Complex z)
		{
			return Amos.CbiryPrime(z);
		}

		public static Complex AiryBiPrimeScaled(Complex z)
		{
			return Amos.ScaledCbiryPrime(z);
		}

		public static double AiryBiPrime(double z)
		{
			return AiryBiPrime(new Complex(z, 0.0)).Real;
		}

		public static double AiryBiPrimeScaled(double z)
		{
			return AiryBiPrimeScaled(new Complex(z, 0.0)).Real;
		}

		public static Complex BesselJ(double n, Complex z)
		{
			return Amos.Cbesj(n, z);
		}

		public static Complex BesselJScaled(double n, Complex z)
		{
			return Amos.ScaledCbesj(n, z);
		}

		public static double BesselJ(double n, double z)
		{
			return Amos.Cbesj(n, z);
		}

		public static double BesselJScaled(double n, double z)
		{
			return Amos.ScaledCbesj(n, z);
		}

		public static Complex BesselY(double n, Complex z)
		{
			return Amos.Cbesy(n, z);
		}

		public static Complex BesselYScaled(double n, Complex z)
		{
			return Amos.ScaledCbesy(n, z);
		}

		public static double BesselY(double n, double z)
		{
			return Amos.Cbesy(n, z);
		}

		public static double BesselYScaled(double n, double z)
		{
			return Amos.ScaledCbesy(n, z);
		}

		public static Complex BesselI(double n, Complex z)
		{
			return Amos.Cbesi(n, z);
		}

		public static Complex BesselIScaled(double n, Complex z)
		{
			return Amos.ScaledCbesi(n, z);
		}

		public static double BesselI(double n, double z)
		{
			return BesselI(n, new Complex(z, 0.0)).Real;
		}

		public static double BesselIScaled(double n, double z)
		{
			return Amos.ScaledCbesi(n, z);
		}

		public static Complex BesselK(double n, Complex z)
		{
			return Amos.Cbesk(n, z);
		}

		public static Complex BesselKScaled(double n, Complex z)
		{
			return Amos.ScaledCbesk(n, z);
		}

		public static double BesselK(double n, double z)
		{
			return Amos.Cbesk(n, z);
		}

		public static double BesselKScaled(double n, double z)
		{
			return Amos.ScaledCbesk(n, z);
		}

		public static double BetaLn(double z, double w)
		{
			if (z <= 0.0)
			{
				throw new ArgumentException("Value must be positive.", "z");
			}
			if (w <= 0.0)
			{
				throw new ArgumentException("Value must be positive.", "w");
			}
			return GammaLn(z) + GammaLn(w) - GammaLn(z + w);
		}

		public static double Beta(double z, double w)
		{
			return Math.Exp(BetaLn(z, w));
		}

		public static double BetaIncomplete(double a, double b, double x)
		{
			return BetaRegularized(a, b, x) * Beta(a, b);
		}

		public static double BetaRegularized(double a, double b, double x)
		{
			if (a < 0.0)
			{
				throw new ArgumentOutOfRangeException("a", "Value must not be negative (zero is ok).");
			}
			if (b < 0.0)
			{
				throw new ArgumentOutOfRangeException("b", "Value must not be negative (zero is ok).");
			}
			if (x < 0.0 || x > 1.0)
			{
				throw new ArgumentOutOfRangeException("x", "Value is expected to be between 0.0 and 1.0 (including 0.0 and 1.0).");
			}
			double num = ((x == 0.0 || x == 1.0) ? 0.0 : Math.Exp(GammaLn(a + b) - GammaLn(a) - GammaLn(b) + a * Math.Log(x) + b * Math.Log(1.0 - x)));
			bool flag = x >= (a + 1.0) / (a + b + 2.0);
			double doublePrecision = Precision.DoublePrecision;
			double num2 = 0.0.Increment() / doublePrecision;
			if (flag)
			{
				x = 1.0 - x;
				double num3 = b;
				b = a;
				a = num3;
			}
			double num4 = a + b;
			double num5 = a + 1.0;
			double num6 = a - 1.0;
			double num7 = 1.0;
			double num8 = 1.0 - num4 * x / num5;
			if (Math.Abs(num8) < num2)
			{
				num8 = num2;
			}
			num8 = 1.0 / num8;
			double num9 = num8;
			int num10 = 1;
			int num11 = 2;
			while (num10 <= 50000)
			{
				double num12 = (double)num10 * (b - (double)num10) * x / ((num6 + (double)num11) * (a + (double)num11));
				num8 = 1.0 + num12 * num8;
				if (Math.Abs(num8) < num2)
				{
					num8 = num2;
				}
				num7 = 1.0 + num12 / num7;
				if (Math.Abs(num7) < num2)
				{
					num7 = num2;
				}
				num8 = 1.0 / num8;
				num9 *= num8 * num7;
				num12 = (0.0 - (a + (double)num10)) * (num4 + (double)num10) * x / ((a + (double)num11) * (num5 + (double)num11));
				num8 = 1.0 + num12 * num8;
				if (Math.Abs(num8) < num2)
				{
					num8 = num2;
				}
				num7 = 1.0 + num12 / num7;
				if (Math.Abs(num7) < num2)
				{
					num7 = num2;
				}
				num8 = 1.0 / num8;
				double num13 = num8 * num7;
				num9 *= num13;
				if (Math.Abs(num13 - 1.0) <= doublePrecision)
				{
					if (!flag)
					{
						return num * num9 / a;
					}
					return 1.0 - num * num9 / a;
				}
				num10++;
				num11 += 2;
			}
			if (!flag)
			{
				return num * num9 / a;
			}
			return 1.0 - num * num9 / a;
		}

		public static double Erf(double x)
		{
			if (x == 0.0)
			{
				return 0.0;
			}
			if (double.IsPositiveInfinity(x))
			{
				return 1.0;
			}
			if (double.IsNegativeInfinity(x))
			{
				return -1.0;
			}
			if (double.IsNaN(x))
			{
				return double.NaN;
			}
			return ErfImp(x, invert: false);
		}

		public static double Erfc(double x)
		{
			if (x == 0.0)
			{
				return 1.0;
			}
			if (double.IsPositiveInfinity(x))
			{
				return 0.0;
			}
			if (double.IsNegativeInfinity(x))
			{
				return 2.0;
			}
			if (double.IsNaN(x))
			{
				return double.NaN;
			}
			return ErfImp(x, invert: true);
		}

		public static double ErfInv(double z)
		{
			if (z == 0.0)
			{
				return 0.0;
			}
			if (z >= 1.0)
			{
				return double.PositiveInfinity;
			}
			if (z <= -1.0)
			{
				return double.NegativeInfinity;
			}
			double num;
			double q;
			double s;
			if (z < 0.0)
			{
				num = 0.0 - z;
				q = 1.0 - num;
				s = -1.0;
			}
			else
			{
				num = z;
				q = 1.0 - z;
				s = 1.0;
			}
			return ErfInvImpl(num, q, s);
		}

		private static double ErfImp(double z, bool invert)
		{
			if (z < 0.0)
			{
				if (!invert)
				{
					return 0.0 - ErfImp(0.0 - z, invert: false);
				}
				if (z < -0.5)
				{
					return 2.0 - ErfImp(0.0 - z, invert: true);
				}
				return 1.0 + ErfImp(0.0 - z, invert: false);
			}
			double num;
			if (z < 0.5)
			{
				num = ((!(z < 1E-10)) ? (z * 1.125 + z * Polynomial.Evaluate(z, ErfImpAn) / Polynomial.Evaluate(z, ErfImpAd)) : (z * 1.125 + z * 0.0033791670955125737));
			}
			else if (z < 110.0)
			{
				invert = !invert;
				double num2;
				double num3;
				if (z < 0.75)
				{
					num2 = Polynomial.Evaluate(z - 0.5, ErfImpBn) / Polynomial.Evaluate(z - 0.5, ErfImpBd);
					num3 = 0.3440242111682892;
				}
				else if (z < 1.25)
				{
					num2 = Polynomial.Evaluate(z - 0.75, ErfImpCn) / Polynomial.Evaluate(z - 0.75, ErfImpCd);
					num3 = 0.4199909269809723;
				}
				else if (z < 2.25)
				{
					num2 = Polynomial.Evaluate(z - 1.25, ErfImpDn) / Polynomial.Evaluate(z - 1.25, ErfImpDd);
					num3 = 0.48986250162124634;
				}
				else if (z < 3.5)
				{
					num2 = Polynomial.Evaluate(z - 2.25, ErfImpEn) / Polynomial.Evaluate(z - 2.25, ErfImpEd);
					num3 = 0.5317370891571045;
				}
				else if (z < 5.25)
				{
					num2 = Polynomial.Evaluate(z - 3.5, ErfImpFn) / Polynomial.Evaluate(z - 3.5, ErfImpFd);
					num3 = 0.5489973425865173;
				}
				else if (z < 8.0)
				{
					num2 = Polynomial.Evaluate(z - 5.25, ErfImpGn) / Polynomial.Evaluate(z - 5.25, ErfImpGd);
					num3 = 0.5571740865707397;
				}
				else if (z < 11.5)
				{
					num2 = Polynomial.Evaluate(z - 8.0, ErfImpHn) / Polynomial.Evaluate(z - 8.0, ErfImpHd);
					num3 = 0.5609807968139648;
				}
				else if (z < 17.0)
				{
					num2 = Polynomial.Evaluate(z - 11.5, ErfImpIn) / Polynomial.Evaluate(z - 11.5, ErfImpId);
					num3 = 0.5626493692398071;
				}
				else if (z < 24.0)
				{
					num2 = Polynomial.Evaluate(z - 17.0, ErfImpJn) / Polynomial.Evaluate(z - 17.0, ErfImpJd);
					num3 = 0.5634598135948181;
				}
				else if (z < 38.0)
				{
					num2 = Polynomial.Evaluate(z - 24.0, ErfImpKn) / Polynomial.Evaluate(z - 24.0, ErfImpKd);
					num3 = 0.5638477802276611;
				}
				else if (z < 60.0)
				{
					num2 = Polynomial.Evaluate(z - 38.0, ErfImpLn) / Polynomial.Evaluate(z - 38.0, ErfImpLd);
					num3 = 0.5640528202056885;
				}
				else if (z < 85.0)
				{
					num2 = Polynomial.Evaluate(z - 60.0, ErfImpMn) / Polynomial.Evaluate(z - 60.0, ErfImpMd);
					num3 = 0.5641309022903442;
				}
				else
				{
					num2 = Polynomial.Evaluate(z - 85.0, ErfImpNn) / Polynomial.Evaluate(z - 85.0, ErfImpNd);
					num3 = 0.5641584396362305;
				}
				double num4 = Math.Exp((0.0 - z) * z) / z;
				num = num4 * num3 + num4 * num2;
			}
			else
			{
				num = 0.0;
				invert = !invert;
			}
			if (invert)
			{
				num = 1.0 - num;
			}
			return num;
		}

		public static double ErfcInv(double z)
		{
			if (z <= 0.0)
			{
				return double.PositiveInfinity;
			}
			if (z >= 2.0)
			{
				return double.NegativeInfinity;
			}
			double num;
			double p;
			double s;
			if (z > 1.0)
			{
				num = 2.0 - z;
				p = 1.0 - num;
				s = -1.0;
			}
			else
			{
				p = 1.0 - z;
				num = z;
				s = 1.0;
			}
			return ErfInvImpl(p, num, s);
		}

		private static double ErfInvImpl(double p, double q, double s)
		{
			double num3;
			if (p <= 0.5)
			{
				double num = p * (p + 10.0);
				double num2 = Polynomial.Evaluate(p, ErvInvImpAn) / Polynomial.Evaluate(p, ErvInvImpAd);
				num3 = num * 0.08913147449493408 + num * num2;
			}
			else if (q >= 0.25)
			{
				double num4 = Math.Sqrt(-2.0 * Math.Log(q));
				double z = q - 0.25;
				double num5 = Polynomial.Evaluate(z, ErvInvImpBn) / Polynomial.Evaluate(z, ErvInvImpBd);
				num3 = num4 / (2.249481201171875 + num5);
			}
			else
			{
				double num6 = Math.Sqrt(0.0 - Math.Log(q));
				if (num6 < 3.0)
				{
					double z2 = num6 - 1.125;
					double num7 = Polynomial.Evaluate(z2, ErvInvImpCn) / Polynomial.Evaluate(z2, ErvInvImpCd);
					num3 = 0.807220458984375 * num6 + num7 * num6;
				}
				else if (num6 < 6.0)
				{
					double z3 = num6 - 3.0;
					double num8 = Polynomial.Evaluate(z3, ErvInvImpDn) / Polynomial.Evaluate(z3, ErvInvImpDd);
					num3 = 0.9399557113647461 * num6 + num8 * num6;
				}
				else if (num6 < 18.0)
				{
					double z4 = num6 - 6.0;
					double num9 = Polynomial.Evaluate(z4, ErvInvImpEn) / Polynomial.Evaluate(z4, ErvInvImpEd);
					num3 = 0.9836282730102539 * num6 + num9 * num6;
				}
				else if (num6 < 44.0)
				{
					double z5 = num6 - 18.0;
					double num10 = Polynomial.Evaluate(z5, ErvInvImpFn) / Polynomial.Evaluate(z5, ErvInvImpFd);
					num3 = 0.9971456527709961 * num6 + num10 * num6;
				}
				else
				{
					double z6 = num6 - 44.0;
					double num11 = Polynomial.Evaluate(z6, ErvInvImpGn) / Polynomial.Evaluate(z6, ErvInvImpGd);
					num3 = 0.9994134902954102 * num6 + num11 * num6;
				}
			}
			return s * num3;
		}

		public static double Expm1(double power)
		{
			double num = Math.Abs(power);
			if (num > 0.1)
			{
				return Math.Exp(power) - 1.0;
			}
			if (num < num.PositiveEpsilonOf())
			{
				return num;
			}
			int k = 0;
			double term = 1.0;
			return Series.Evaluate(delegate
			{
				k++;
				term *= power;
				term /= k;
				return term;
			});
		}

		[Obsolete("Use Expm1 instead")]
		public static double ExponentialMinusOne(double power)
		{
			return Expm1(power);
		}

		public static double ExponentialIntegral(double x, int n)
		{
			if (n < 0 || x < 0.0)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"x and n must be positive: x={x}, n={n}"));
			}
			int num = 100;
			double num2 = n;
			double num3 = 1E-100;
			double num4 = 1.0;
			if (n == 0)
			{
				return Math.Exp(-1.0 * x) / x;
			}
			if (x == 0.0)
			{
				return 1.0 / (num2 - 1.0);
			}
			if (x > 1.0)
			{
				double num5 = x + (double)n;
				double num6 = 1.0 / num3;
				double num7 = 1.0 / num5;
				double num8 = num7;
				for (int i = 1; i <= num; i++)
				{
					double num9 = -1.0 * (double)i * (num2 - 1.0 + (double)i);
					num5 += 2.0;
					num7 = 1.0 / (num9 * num7 + num5);
					num6 = num5 + num9 / num6;
					double num10 = num6 * num7;
					num8 *= num10;
					if (Math.Abs(num10 - 1.0) < 1E-17)
					{
						return num8 * Math.Exp(0.0 - x);
					}
				}
				throw new ArithmeticException(FormattableString.Invariant($"Continued fraction failed to converge for x={x}, n={n})"));
			}
			double num11 = ((num2 - 1.0 != 0.0) ? (1.0 / (num2 - 1.0)) : (-1.0 * Math.Log(x) - 0.5772156649015329));
			for (int i = 1; i <= num; i++)
			{
				num4 *= -1.0 * x / (double)i;
				double num10;
				if ((double)i != num2 - 1.0)
				{
					num10 = (0.0 - num4) / ((double)i - (num2 - 1.0));
				}
				else
				{
					double num12 = -0.5772156649015329;
					for (int j = 1; (double)j <= num2 - 1.0; j++)
					{
						num12 += 1.0 / (double)j;
					}
					num10 = num4 * (-1.0 * Math.Log(x) + num12);
				}
				num11 += num10;
				if (Math.Abs(num10) < Math.Abs(num11) * 1E-17)
				{
					return num11;
				}
			}
			throw new ArithmeticException(FormattableString.Invariant($"Series failed to converge for x={x}, n={n})"));
		}

		public static double Factorial(int x)
		{
			if (x < 0)
			{
				throw new ArgumentOutOfRangeException("x", "Value must be positive (and not zero).");
			}
			if (x < _factorialCache.Length)
			{
				return _factorialCache[x];
			}
			return double.PositiveInfinity;
		}

		public static BigInteger Factorial(BigInteger x)
		{
			if (x < 0L)
			{
				throw new ArgumentOutOfRangeException("x", "Value must be positive (and not zero).");
			}
			if (x == 0L)
			{
				return BigInteger.One;
			}
			BigInteger result = x;
			while (--x > 1L)
			{
				result *= x;
			}
			return result;
		}

		public static double FactorialLn(int x)
		{
			if (x < 0)
			{
				throw new ArgumentOutOfRangeException("x", "Value must be positive (and not zero).");
			}
			if (x <= 1)
			{
				return 0.0;
			}
			if (x < _factorialCache.Length)
			{
				return Math.Log(_factorialCache[x]);
			}
			return GammaLn((double)x + 1.0);
		}

		public static double Binomial(int n, int k)
		{
			if (k < 0 || n < 0 || k > n)
			{
				return 0.0;
			}
			return Math.Floor(0.5 + Math.Exp(FactorialLn(n) - FactorialLn(k) - FactorialLn(n - k)));
		}

		public static double BinomialLn(int n, int k)
		{
			if (k < 0 || n < 0 || k > n)
			{
				return double.NegativeInfinity;
			}
			return FactorialLn(n) - FactorialLn(k) - FactorialLn(n - k);
		}

		public static double Multinomial(int n, int[] ni)
		{
			if (n < 0)
			{
				throw new ArgumentException("Value must be positive.", "n");
			}
			if (ni == null)
			{
				throw new ArgumentNullException("ni");
			}
			int num = 0;
			double num2 = FactorialLn(n);
			for (int i = 0; i < ni.Length; i++)
			{
				if (ni[i] < 0)
				{
					throw new ArgumentException("Value must be positive.", "ni[" + i + "]");
				}
				num2 -= FactorialLn(ni[i]);
				num += ni[i];
			}
			if (num != n)
			{
				throw new ArgumentException("The chosen parameter set is invalid (probably some value is out of range).", "ni");
			}
			return Math.Floor(0.5 + Math.Exp(num2));
		}

		public static double GammaLn(double z)
		{
			if (z < 0.5)
			{
				double num = GammaDk[0];
				for (int i = 1; i <= 10; i++)
				{
					num += GammaDk[i] / ((double)i - z);
				}
				return 1.1447298858494002 - Math.Log(Math.Sin(Math.PI * z)) - Math.Log(num) - 0.6207822376352452 - (0.5 - z) * Math.Log((0.5 - z + 10.900511) / Math.E);
			}
			double num2 = GammaDk[0];
			for (int j = 1; j <= 10; j++)
			{
				num2 += GammaDk[j] / (z + (double)j - 1.0);
			}
			return Math.Log(num2) + 0.6207822376352452 + (z - 0.5) * Math.Log((z - 0.5 + 10.900511) / Math.E);
		}

		public static double Gamma(double z)
		{
			if (z < 0.5)
			{
				double num = GammaDk[0];
				for (int i = 1; i <= 10; i++)
				{
					num += GammaDk[i] / ((double)i - z);
				}
				return Math.PI / (Math.Sin(Math.PI * z) * num * 1.8603827342052657 * Math.Pow((0.5 - z + 10.900511) / Math.E, 0.5 - z));
			}
			double num2 = GammaDk[0];
			for (int j = 1; j <= 10; j++)
			{
				num2 += GammaDk[j] / (z + (double)j - 1.0);
			}
			return num2 * 1.8603827342052657 * Math.Pow((z - 0.5 + 10.900511) / Math.E, z - 0.5);
		}

		public static double GammaUpperRegularized(double a, double x)
		{
			if (x < 1.0 || x <= a)
			{
				return 1.0 - GammaLowerRegularized(a, x);
			}
			double num = a * Math.Log(x) - x - GammaLn(a);
			if (num < -709.782712893384)
			{
				if (!(a < x))
				{
					return 1.0;
				}
				return 0.0;
			}
			num = Math.Exp(num);
			double num2 = 1.0 - a;
			double num3 = x + num2 + 1.0;
			double num4 = 0.0;
			double num5 = 1.0;
			double num6 = x;
			double num7 = x + 1.0;
			double num8 = num3 * x;
			double num9 = num7 / num8;
			double num14;
			do
			{
				num4 += 1.0;
				num2 += 1.0;
				num3 += 2.0;
				double num10 = num2 * num4;
				double num11 = num7 * num3 - num5 * num10;
				double num12 = num8 * num3 - num6 * num10;
				if (num12 != 0.0)
				{
					double num13 = num11 / num12;
					num14 = Math.Abs((num9 - num13) / num13);
					num9 = num13;
				}
				else
				{
					num14 = 1.0;
				}
				num5 = num7;
				num7 = num11;
				num6 = num8;
				num8 = num12;
				if (Math.Abs(num11) > 4503599627370496.0)
				{
					num5 *= 2.220446049250313E-16;
					num7 *= 2.220446049250313E-16;
					num6 *= 2.220446049250313E-16;
					num8 *= 2.220446049250313E-16;
				}
			}
			while (num14 > 1E-15);
			return num9 * num;
		}

		public static double GammaUpperIncomplete(double a, double x)
		{
			return GammaUpperRegularized(a, x) * Gamma(a);
		}

		public static double GammaLowerIncomplete(double a, double x)
		{
			return GammaLowerRegularized(a, x) * Gamma(a);
		}

		public static double GammaLowerRegularized(double a, double x)
		{
			if (a < 0.0)
			{
				throw new ArgumentOutOfRangeException("a", "Value must not be negative (zero is ok).");
			}
			if (x < 0.0)
			{
				throw new ArgumentOutOfRangeException("x", "Value must not be negative (zero is ok).");
			}
			if (a.AlmostEqual(0.0))
			{
				x.AlmostEqual(0.0);
				return 1.0;
			}
			if (x.AlmostEqual(0.0))
			{
				return 0.0;
			}
			double num = a * Math.Log(x) - x - GammaLn(a);
			if (num < -709.782712893384)
			{
				if (!(a < x))
				{
					return 0.0;
				}
				return 1.0;
			}
			if (x <= 1.0 || x <= a)
			{
				double num2 = a;
				double num3 = 1.0;
				double num4 = 1.0;
				do
				{
					num2 += 1.0;
					num3 = num3 * x / num2;
					num4 += num3;
				}
				while (num3 / num4 > 1E-15);
				return Math.Exp(num) * num4 / a;
			}
			int num5 = 0;
			double num6 = 1.0 - a;
			double num7 = x + num6 + 1.0;
			double num8 = 1.0;
			double num9 = x;
			double num10 = x + 1.0;
			double num11 = num7 * x;
			double num12 = num10 / num11;
			double num17;
			do
			{
				num5++;
				num6 += 1.0;
				num7 += 2.0;
				double num13 = num6 * (double)num5;
				double num14 = num10 * num7 - num8 * num13;
				double num15 = num11 * num7 - num9 * num13;
				if (num15 != 0.0)
				{
					double num16 = num14 / num15;
					num17 = Math.Abs((num12 - num16) / num16);
					num12 = num16;
				}
				else
				{
					num17 = 1.0;
				}
				num8 = num10;
				num10 = num14;
				num9 = num11;
				num11 = num15;
				if (Math.Abs(num14) > 4503599627370496.0)
				{
					num8 *= 2.220446049250313E-16;
					num10 *= 2.220446049250313E-16;
					num9 *= 2.220446049250313E-16;
					num11 *= 2.220446049250313E-16;
				}
			}
			while (num17 > 1E-15);
			return 1.0 - Math.Exp(num) * num12;
		}

		public static double GammaLowerRegularizedInv(double a, double y0)
		{
			if (double.IsNaN(a) || double.IsNaN(y0))
			{
				return double.NaN;
			}
			if (a < 0.0 || a.AlmostEqual(0.0))
			{
				throw new ArgumentOutOfRangeException("a");
			}
			if (y0 < 0.0 || y0 > 1.0)
			{
				throw new ArgumentOutOfRangeException("y0");
			}
			if (y0.AlmostEqual(0.0))
			{
				return 0.0;
			}
			if (y0.AlmostEqual(1.0))
			{
				return double.PositiveInfinity;
			}
			y0 = 1.0 - y0;
			double num = 4503599627370496.0;
			double num2 = 0.0;
			double num3 = 1.0;
			double num4 = 0.0;
			double num5 = 1.0 / (9.0 * a);
			double num6 = 1.0 - num5 - 1.3859292911256331 * ErfInv(2.0 * y0 - 1.0) * Math.Sqrt(num5);
			double num7 = a * num6 * num6 * num6;
			double num8 = GammaLn(a);
			for (int i = 0; i < 20; i++)
			{
				if (num7 < num2 || num7 > num)
				{
					num5 = 0.0625;
					break;
				}
				num6 = 1.0 - GammaLowerRegularized(a, num7);
				if (num6 < num4 || num6 > num3)
				{
					num5 = 0.0625;
					break;
				}
				if (num6 < y0)
				{
					num = num7;
					num4 = num6;
				}
				else
				{
					num2 = num7;
					num3 = num6;
				}
				num5 = (a - 1.0) * Math.Log(num7) - num7 - num8;
				if (num5 < -709.782712893384)
				{
					num5 = 0.0625;
					break;
				}
				num5 = 0.0 - Math.Exp(num5);
				num5 = (num6 - y0) / num5;
				if (Math.Abs(num5 / num7) < 1E-15)
				{
					return num7;
				}
				if (num5 > num7 / 4.0 && y0 < 0.05)
				{
					num5 = num7 / 10.0;
				}
				num7 -= num5;
			}
			if (num == 4503599627370496.0)
			{
				if (num7 <= 0.0)
				{
					num7 = 1.0;
				}
				while (num == 4503599627370496.0)
				{
					num7 = (1.0 + num5) * num7;
					num6 = 1.0 - GammaLowerRegularized(a, num7);
					if (num6 < y0)
					{
						num = num7;
						num4 = num6;
						break;
					}
					num5 += num5;
				}
			}
			int num9 = 0;
			num5 = 0.5;
			for (int j = 0; j < 400; j++)
			{
				num7 = num2 + num5 * (num - num2);
				num6 = 1.0 - GammaLowerRegularized(a, num7);
				num8 = (num - num2) / (num2 + num);
				if (Math.Abs(num8) < 5.000000000000001E-15)
				{
					return num7;
				}
				num8 = (num6 - y0) / y0;
				if (Math.Abs(num8) < 5.000000000000001E-15)
				{
					return num7;
				}
				if (num7 <= 0.0)
				{
					return 0.0;
				}
				if (num6 >= y0)
				{
					num2 = num7;
					num3 = num6;
					if (num9 >= 0)
					{
						num5 = ((num9 <= 1) ? ((y0 - num4) / (num3 - num4)) : (0.5 * num5 + 0.5));
					}
					else
					{
						num9 = 0;
						num5 = 0.5;
					}
					num9++;
				}
				else
				{
					num = num7;
					num4 = num6;
					if (num9 <= 0)
					{
						num5 = ((num9 >= -1) ? ((y0 - num4) / (num3 - num4)) : (0.5 * num5));
					}
					else
					{
						num9 = 0;
						num5 = 0.5;
					}
					num9--;
				}
			}
			return num7;
		}

		public static double DiGamma(double x)
		{
			if (double.IsNegativeInfinity(x) || double.IsNaN(x))
			{
				return double.NaN;
			}
			if (x <= 0.0 && Math.Floor(x) == x)
			{
				return double.NegativeInfinity;
			}
			if (x < 0.0)
			{
				return DiGamma(1.0 - x) + Math.PI / Math.Tan(-Math.PI * x);
			}
			if (x <= 1E-06)
			{
				return -0.5772156649015329 - 1.0 / x + 1.6449340668482264 * x;
			}
			double num = 0.0;
			while (x < 12.0)
			{
				num -= 1.0 / x;
				x += 1.0;
			}
			if (x >= 12.0)
			{
				double num2 = 1.0 / x;
				num += Math.Log(x) - 0.5 * num2;
				num2 *= num2;
				num -= num2 * (1.0 / 12.0 - num2 * (1.0 / 120.0 - num2 * (1.0 / 252.0 - num2 * (1.0 / 240.0 - num2 * (1.0 / 132.0)))));
			}
			return num;
		}

		public static double DiGammaInv(double p)
		{
			if (double.IsNaN(p))
			{
				return double.NaN;
			}
			if (double.IsNegativeInfinity(p))
			{
				return 0.0;
			}
			if (double.IsPositiveInfinity(p))
			{
				return double.PositiveInfinity;
			}
			double num = Math.Exp(p);
			for (double num2 = 1.0; num2 > 1E-15; num2 /= 2.0)
			{
				num += num2 * (double)Math.Sign(p - DiGamma(num));
			}
			return num;
		}

		public static double RisingFactorial(double x, int n)
		{
			double num = 1.0;
			for (int i = 0; i < n; i++)
			{
				num *= x + (double)i;
			}
			return num;
		}

		public static double FallingFactorial(double x, int n)
		{
			double num = 1.0;
			for (int i = 0; i < n; i++)
			{
				num *= x - (double)i;
			}
			return num;
		}

		public static double GeneralizedHypergeometric(double[] a, double[] b, int z)
		{
			double num = 0.0;
			int num2 = 0;
			double num3;
			do
			{
				num3 = HGIncrement(a, b, z, num2);
				num += num3;
				num2++;
			}
			while (Math.Abs(num3) > 1E-15 && Math.Abs(num3) > 0.0 && num3.IsFinite());
			return num;
		}

		private static double HGIncrement(double[] a, double[] b, int z, int currentN)
		{
			double num = 1.0;
			double num2 = 1.0;
			double[] array = new double[a.Length];
			double[] array2 = new double[b.Length];
			for (int i = 0; i < a.Length; i++)
			{
				num *= RisingFactorial(a[i], currentN);
				array[i] = RisingFactorial(a[i], currentN);
			}
			for (int j = 0; j < b.Length; j++)
			{
				num2 *= RisingFactorial(b[j], currentN);
				array2[j] = RisingFactorial(b[j], currentN);
			}
			double num3 = array.Where((double x) => x == 0.0).Count();
			double num4 = array2.Where((double x) => x == 0.0).Count();
			if (num3 > 0.0 && num3 >= num4)
			{
				return 0.0;
			}
			if (num4 > 0.0 && num4 > num3)
			{
				return double.PositiveInfinity;
			}
			return num / num2 * Math.Pow(z, currentN) / Factorial(currentN);
		}

		public static Complex HankelH1(double n, Complex z)
		{
			return Amos.Cbesh1(n, z);
		}

		public static Complex HankelH1Scaled(double n, Complex z)
		{
			return Amos.ScaledCbesh1(n, z);
		}

		public static Complex HankelH2(double n, Complex z)
		{
			return Amos.Cbesh2(n, z);
		}

		public static Complex HankelH2Scaled(double n, Complex z)
		{
			return Amos.ScaledCbesh2(n, z);
		}

		public static double Harmonic(int t)
		{
			return 0.5772156649015329 + DiGamma((double)t + 1.0);
		}

		public static double GeneralHarmonic(int n, double m)
		{
			double num = 0.0;
			for (int i = 0; i < n; i++)
			{
				num += Math.Pow(i + 1, 0.0 - m);
			}
			return num;
		}

		public static Complex KelvinBe(double nu, double x)
		{
			Complex complex = new Complex(-0.7071067811865476, 0.7071067811865476);
			return BesselJ(nu, complex * x);
		}

		public static double KelvinBer(double nu, double x)
		{
			return KelvinBe(nu, x).Real;
		}

		public static double KelvinBer(double x)
		{
			return KelvinBe(0.0, x).Real;
		}

		public static double KelvinBei(double nu, double x)
		{
			return KelvinBe(nu, x).Imaginary;
		}

		public static double KelvinBei(double x)
		{
			return KelvinBe(0.0, x).Imaginary;
		}

		public static double KelvinBerPrime(double nu, double x)
		{
			return 0.3535533905932738 * (0.0 - KelvinBer(nu - 1.0, x) + KelvinBer(nu + 1.0, x) - KelvinBei(nu - 1.0, x) + KelvinBei(nu + 1.0, x));
		}

		public static double KelvinBerPrime(double x)
		{
			return KelvinBerPrime(0.0, x);
		}

		public static double KelvinBeiPrime(double nu, double x)
		{
			return 0.3535533905932738 * (KelvinBer(nu - 1.0, x) - KelvinBer(nu + 1.0, x) - KelvinBei(nu - 1.0, x) + KelvinBei(nu + 1.0, x));
		}

		public static double KelvinBeiPrime(double x)
		{
			return KelvinBeiPrime(0.0, x);
		}

		public static Complex KelvinKe(double nu, double x)
		{
			Complex complex = new Complex(0.0, Math.PI / 2.0);
			Complex complex2 = new Complex(0.7071067811865476, 0.7071067811865476);
			return Complex.Exp((0.0 - nu) * complex) * BesselK(nu, complex2 * x);
		}

		public static double KelvinKer(double nu, double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKe(nu, x).Real;
		}

		public static double KelvinKer(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKe(0.0, x).Real;
		}

		public static double KelvinKei(double nu, double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKe(nu, x).Imaginary;
		}

		public static double KelvinKei(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKe(0.0, x).Imaginary;
		}

		public static double KelvinKerPrime(double nu, double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return 0.3535533905932738 * (0.0 - KelvinKer(nu - 1.0, x) + KelvinKer(nu + 1.0, x) - KelvinKei(nu - 1.0, x) + KelvinKei(nu + 1.0, x));
		}

		public static double KelvinKerPrime(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKerPrime(0.0, x);
		}

		public static double KelvinKeiPrime(double nu, double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return 0.3535533905932738 * (KelvinKer(nu - 1.0, x) - KelvinKer(nu + 1.0, x) - KelvinKei(nu - 1.0, x) + KelvinKei(nu + 1.0, x));
		}

		public static double KelvinKeiPrime(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			return KelvinKeiPrime(0.0, x);
		}

		public static double Log1p(double x)
		{
			double num = Math.Log(1.0 + x);
			if (-0.2928 < x && x < 0.4142)
			{
				double num2 = num;
				if (num2 == 0.0)
				{
					num2 = 1.0;
				}
				else if (num2 < -0.69 || num2 > 0.4)
				{
					num2 = (Math.Exp(num2) - 1.0) / num2;
				}
				else
				{
					double num3 = num2 / 2.0;
					num2 = Math.Exp(num3) * Math.Sinh(num3) / num3;
				}
				double num4 = num * num2;
				double num5 = (num4 - x) / (num4 + 1.0);
				num -= num5 * (6.0 - num5) / (6.0 - 4.0 * num5);
			}
			return num;
		}

		public static double Logistic(double p)
		{
			return 1.0 / (Math.Exp(0.0 - p) + 1.0);
		}

		public static double Logit(double p)
		{
			if (p < 0.0 || p > 1.0)
			{
				throw new ArgumentOutOfRangeException("p", "The argument must be between 0 and 1.");
			}
			return Math.Log(p / (1.0 - p));
		}

		public static double MarcumQ(double nu, double a, double b)
		{
			MarcumQFunction.Marcum(nu, a, b, out var _, out var q, out var _);
			return q;
		}

		public static double MarcumQ(double nu, double a, double b, out int err)
		{
			MarcumQFunction.Marcum(nu, a, b, out var _, out var q, out err);
			return q;
		}

		public static double MittagLefflerE(double alpha, double x)
		{
			return MittagLefflerE(alpha, 1.0, 1.0, new Complex(x, 0.0)).Real;
		}

		public static double MittagLefflerE(double alpha, double beta, double x)
		{
			return MittagLefflerE(alpha, beta, 1.0, new Complex(x, 0.0)).Real;
		}

		public static double MittagLefflerE(double alpha, double beta, double gamma, double x)
		{
			return MittagLefflerE(alpha, beta, gamma, new Complex(x, 0.0)).Real;
		}

		public static Complex MittagLefflerE(double alpha, Complex z)
		{
			return MittagLefflerE(alpha, 1.0, 1.0, z);
		}

		public static Complex MittagLefflerE(double alpha, double beta, Complex z)
		{
			return MittagLefflerE(alpha, beta, 1.0, z);
		}

		public static Complex MittagLefflerE(double alpha, double beta, double gamma, Complex z)
		{
			if (alpha <= 0.0)
			{
				throw new ArgumentOutOfRangeException("alpha", "alpha must be positive.");
			}
			if (gamma <= 0.0)
			{
				throw new ArgumentOutOfRangeException("gamma", "gamma must be positive.");
			}
			if (Math.Abs(gamma - 1.0) > 2.220446049250313E-16)
			{
				if (alpha > 1.0)
				{
					throw new ArgumentOutOfRangeException("alpha", "alpha must satisfy 0 < alpha < 1.");
				}
				if (Math.Abs(z.Phase) <= alpha * Math.PI)
				{
					throw new NotSupportedException("This works only when |Arg(z)| > alpha*PI.");
				}
			}
			double log_epsilon = Math.Log(1E-15);
			if (!(z.Magnitude < 1E-15))
			{
				return LTInversion(1.0, z, alpha, beta, gamma, log_epsilon);
			}
			return 1.0 / Gamma(beta);
		}

		private static Complex LTInversion(double t, Complex lambda, double alpha, double beta, double gamma, double log_epsilon)
		{
			Complex I = Complex.ImaginaryOne;
			double theta = lambda.Phase;
			double num = Math.Ceiling((0.0 - alpha) / 2.0 - theta / (Math.PI * 2.0));
			double num2 = Math.Floor(alpha / 2.0 - theta / (Math.PI * 2.0));
			double[] source = ((num < num2) ? Generate.LinearRange((int)num, (int)num2) : ((num != num2) ? Array.Empty<double>() : new double[1] { num }));
			Complex[] s_star = source.Select((double v) => Math.Pow(lambda.Magnitude, 1.0 / alpha) * Complex.Exp(I * (theta + Math.PI * 2.0 * v) / alpha)).ToArray();
			double[] phi_s_star = s_star.Select((Complex v) => (v.Real + v.Magnitude) / 2.0).ToArray();
			int[] array = Enumerable.Range(0, phi_s_star.Length).ToArray();
			Sorting.Sort(phi_s_star, array);
			s_star = array.Select((int v) => s_star[v]).ToArray();
			IEnumerable<int> source2 = from v in phi_s_star.Select((double v, int i) => (v: v, i: i))
				where v.v > 1E-15
				select v.i;
			s_star = source2.Select((int v) => s_star[v]).ToArray();
			phi_s_star = source2.Select((int v) => phi_s_star[v]).ToArray();
			s_star = new Complex[1] { Complex.Zero }.Concat(s_star).ToArray();
			phi_s_star = new double[1].Concat(phi_s_star).ToArray();
			int num3 = s_star.Length;
			int count = num3 - 1;
			double[] array2 = new double[1] { Math.Max(0.0, -2.0 * (alpha * gamma - beta + 1.0)) }.Concat(Enumerable.Repeat(gamma, count)).ToArray();
			double[] array3 = Enumerable.Repeat(gamma, count).Concat(new double[1] { double.PositiveInfinity }).ToArray();
			phi_s_star = phi_s_star.Concat(new double[1] { double.PositiveInfinity }).ToArray();
			IEnumerable<double> first = phi_s_star.Take(phi_s_star.Length - 1);
			IEnumerable<double> second = phi_s_star.Skip(1);
			int[] array4 = first.Zip(second, (double v1, double v2) => (v1: v1, v2: v2)).Where(((double v1, double v2) v, int i) => v.v1 < (log_epsilon - Math.Log(2.220446049250313E-16)) / t && v.v1 < v.v2).Select(((double v1, double v2) v, int i) => i)
				.ToArray();
			int count2 = array4.Length;
			double[] array5 = Enumerable.Repeat(double.PositiveInfinity, count2).ToArray();
			double[] array6 = Enumerable.Repeat(double.PositiveInfinity, count2).ToArray();
			double[] array7 = Enumerable.Repeat(double.PositiveInfinity, count2).ToArray();
			bool flag = false;
			while (!flag)
			{
				int[] array8 = array4;
				foreach (int num5 in array8)
				{
					double num6;
					double num7;
					double num8;
					if (num5 + 1 >= num3)
					{
						(num6, num7, num8) = OptimalParametersInRightUnboundedRegion(t, phi_s_star[num5], array2[num5], log_epsilon);
					}
					else
					{
						(num6, num7, num8) = OptimalParametersInRightBoundedRegion(t, phi_s_star[num5], phi_s_star[num5 + 1], array2[num5], array3[num5], log_epsilon);
					}
					array5[num5] = num6;
					array7[num5] = num7;
					array6[num5] = num8;
				}
				if (array6.Min() > 200.0)
				{
					log_epsilon += 2.302585092994046;
				}
				else
				{
					flag = true;
				}
			}
			int num9 = (int)array6.Min();
			int num10 = Array.IndexOf(array6, num9);
			double num11 = array5[num10];
			double num12 = array7[num10];
			Complex zero = Complex.Zero;
			for (int num13 = -num9; num13 <= num9; num13++)
			{
				double num14 = num12 * (double)num13;
				Complex complex = num11 * Complex.Pow(I * num14 + 1, 2.0);
				Complex complex2 = 2.0 * num11 * (I - num14);
				Complex complex3 = Complex.Pow(complex, alpha * gamma - beta) / Complex.Pow(Complex.Pow(complex, alpha) - lambda, gamma) * complex2;
				zero += complex3 * Complex.Exp(complex * t);
			}
			zero *= num12 / (Math.PI * 2.0) / I;
			Complex zero2 = Complex.Zero;
			for (int num15 = num10 + 1; num15 < s_star.Length; num15++)
			{
				zero2 += 1.0 / alpha * Complex.Pow(s_star[num15], 1.0 - beta) * Complex.Exp(t * s_star[num15]);
			}
			Complex result = zero + zero2;
			if (lambda.Imaginary == 0.0)
			{
				result = new Complex(result.Real, 0.0);
			}
			return result;
		}

		private static (double muj, double hj, double Nj) OptimalParametersInRightBoundedRegion(double t, double phi_s_star_j, double phi_s_star_j1, double pj, double qj, double log_epsilon)
		{
			bool flag = true;
			double num = Math.Exp(log_epsilon - -36.04365338911715);
			double num2 = Math.Sqrt(phi_s_star_j);
			double num3 = 2.0 * Math.Sqrt((log_epsilon - -36.04365338911715) / t);
			double num4 = Math.Min(Math.Sqrt(phi_s_star_j1), num3 - num2);
			double num5 = 0.0;
			double num6 = 0.0;
			bool flag2 = false;
			if (pj < 1E-14 && qj < 1E-14)
			{
				num5 = num2;
				num6 = num4;
				flag2 = true;
			}
			double num7 = 0.0;
			if (pj < 1E-14 && qj >= 1E-14)
			{
				num5 = num2;
				double num8 = ((num2 > 0.0) ? (1.01 * Math.Pow(num2 / (num4 - num2), qj)) : 1.01);
				if (num8 < num)
				{
					num7 = num8 + num8 / num * (num - num8);
					double num9 = Math.Pow(num7, -1.0 / qj);
					num6 = (2.0 * num4 - num9 * num2) / (2.0 + num9);
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
			}
			if (pj >= 1E-14 && qj < 1E-14)
			{
				num6 = num4;
				double num10 = 1.01 * Math.Pow(num4 / (num4 - num2), pj);
				if (num10 < num)
				{
					num7 = num10 + num10 / num * (num - num10);
					double num11 = Math.Pow(num7, -1.0 / pj);
					num5 = (2.0 * num2 + num11 * num4) / (2.0 - num11);
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
			}
			if (pj >= 1E-14 && qj >= 1E-14)
			{
				double num12 = 1.01 * (num2 + num4) / Math.Pow(num4 - num2, Math.Max(pj, qj));
				if (num12 < num)
				{
					num12 = Math.Max(num12, 1.5);
					num7 = num12 + num12 / num * (num - num12);
					double num13 = Math.Pow(num7, -1.0 / pj);
					double num14 = Math.Pow(num7, -1.0 / qj);
					double num15 = (flag ? (-2.0 * phi_s_star_j1 * t / (log_epsilon - phi_s_star_j1 * t)) : ((0.0 - phi_s_star_j1) * t / log_epsilon));
					double num16 = 2.0 + num15 - (1.0 + num15) * num13 + num14;
					num5 = ((2.0 + num15 + num14) * num2 + num13 * num4) / num16;
					num6 = ((0.0 - (1.0 + num15)) * num14 * num2 + (2.0 + num15 - (1.0 + num15) * num13) * num4) / num16;
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
			}
			double num17 = 0.0;
			double num18 = 0.0;
			double item = double.PositiveInfinity;
			if (flag2)
			{
				log_epsilon -= Math.Log(num7);
				double num19 = (flag ? (-2.0 * Math.Pow(num6, 2.0) * t / (log_epsilon - Math.Pow(num6, 2.0) * t)) : ((0.0 - Math.Pow(num6, 2.0)) * t / log_epsilon));
				num17 = Math.Pow(((1.0 + num19) * num5 + num6) / (2.0 + num19), 2.0);
				num18 = Math.PI * -2.0 / log_epsilon * (num6 - num5) / ((1.0 + num19) * num5 + num6);
				item = Math.Ceiling(Math.Sqrt(1.0 - log_epsilon / t / num17) / num18);
			}
			return (muj: num17, hj: num18, Nj: item);
		}

		private static (double muj, double hj, double Nj) OptimalParametersInRightUnboundedRegion(double t, double phi_s_star_j, double pj, double log_epsilon)
		{
			double num = Math.Sqrt(phi_s_star_j);
			double num2 = ((phi_s_star_j > 0.0) ? (phi_s_star_j * 1.01) : 0.01);
			double num3 = Math.Sqrt(num2);
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			bool flag = false;
			while (!flag)
			{
				double num7 = num2 * t;
				double num8 = log_epsilon / num7;
				num6 = Math.Ceiling(num7 / Math.PI * (1.0 - 3.0 * num8 / 2.0 + Math.Sqrt(1.0 - 2.0 * num8)));
				num4 = Math.PI * num6 / num7;
				num5 = num3 * Math.Abs(4.0 - num4) / Math.Abs(7.0 - Math.Sqrt(1.0 + 12.0 * num4));
				double num9 = Math.Pow((num3 - num) / num5, 0.0 - pj);
				flag = pj < 1E-14 || (1.0 < num9 && num9 < 10.0);
				if (!flag)
				{
					num3 = Math.Pow(5.0, -1.0 / pj) * num5 + num;
					num2 = Math.Pow(num3, 2.0);
				}
			}
			double num10 = Math.Pow(num5, 2.0);
			double item = (-3.0 * num4 - 2.0 + 2.0 * Math.Sqrt(1.0 + 12.0 * num4)) / (4.0 - num4) / num6;
			double num11 = Math.Log(2.220446049250313E-16);
			double num12 = (log_epsilon - num11) / t;
			if (num10 > num12)
			{
				num2 = Math.Pow(((Math.Abs(pj) < 1E-14) ? 0.0 : (Math.Pow(5.0, -1.0 / pj) * Math.Sqrt(num10))) + Math.Sqrt(phi_s_star_j), 2.0);
				if (num2 < num12)
				{
					double num13 = Math.Sqrt(num11 / (num11 - log_epsilon));
					double num14 = Math.Sqrt((0.0 - num2) * t / num11);
					num10 = num12;
					num6 = Math.Ceiling(num13 * log_epsilon / (Math.PI * 2.0) / (num14 * num13 - 1.0));
					item = Math.Sqrt(num11 / (num11 - log_epsilon)) / num6;
				}
				else
				{
					num6 = double.PositiveInfinity;
					item = 0.0;
				}
			}
			return (muj: num10, hj: item, Nj: num6);
		}

		public static double BesselI0(double x)
		{
			if (x < 0.0)
			{
				x = 0.0 - x;
			}
			if (x <= 8.0)
			{
				double x2 = x / 2.0 - 2.0;
				return Math.Exp(x) * Evaluate.ChebyshevA(BesselI0A, x2);
			}
			double x3 = 32.0 / x - 2.0;
			return Math.Exp(x) * Evaluate.ChebyshevA(BesselI0B, x3) / Math.Sqrt(x);
		}

		public static double BesselI1(double x)
		{
			double num = Math.Abs(x);
			if (num <= 8.0)
			{
				double x2 = num / 2.0 - 2.0;
				num = Evaluate.ChebyshevA(BesselI1A, x2) * num * Math.Exp(num);
			}
			else
			{
				double x3 = 32.0 / num - 2.0;
				num = Math.Exp(num) * Evaluate.ChebyshevA(BesselI1B, x3) / Math.Sqrt(num);
			}
			if (x < 0.0)
			{
				num = 0.0 - num;
			}
			return num;
		}

		public static double BesselK0(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			if (x <= 2.0)
			{
				double x2 = x * x - 2.0;
				return Evaluate.ChebyshevA(BesselK0A, x2) - Math.Log(0.5 * x) * BesselI0(x);
			}
			double x3 = 8.0 / x - 2.0;
			return Math.Exp(0.0 - x) * Evaluate.ChebyshevA(BesselK0B, x3) / Math.Sqrt(x);
		}

		public static double BesselK0e(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			if (x <= 2.0)
			{
				double x2 = x * x - 2.0;
				return Evaluate.ChebyshevA(BesselK0A, x2) - Math.Log(0.5 * x) * BesselI0(x) * Math.Exp(x);
			}
			double x3 = 8.0 / x - 2.0;
			return Evaluate.ChebyshevA(BesselK0B, x3) / Math.Sqrt(x);
		}

		public static double BesselK1(double x)
		{
			double num = 0.5 * x;
			if (num <= 0.0)
			{
				throw new ArithmeticException();
			}
			if (x <= 2.0)
			{
				double x2 = x * x - 2.0;
				return Math.Log(num) * BesselI1(x) + Evaluate.ChebyshevA(BesselK1A, x2) / x;
			}
			double x3 = 8.0 / x - 2.0;
			return Math.Exp(0.0 - x) * Evaluate.ChebyshevA(BesselK1B, x3) / Math.Sqrt(x);
		}

		public static double BesselK1e(double x)
		{
			if (x <= 0.0)
			{
				throw new ArithmeticException();
			}
			if (x <= 2.0)
			{
				double x2 = x * x - 2.0;
				return Math.Log(0.5 * x) * BesselI1(x) + Evaluate.ChebyshevA(BesselK1A, x2) / x * Math.Exp(x);
			}
			double x3 = 8.0 / x - 2.0;
			return Evaluate.ChebyshevA(BesselK1B, x3) / Math.Sqrt(x);
		}

		public static double StruveL0(double x)
		{
			if (x < 0.0)
			{
				return 0.0 - StruveL0(0.0 - x);
			}
			double[] coefficients = new double[28]
			{
				0.42127458349979924, -0.3385953639122061, 0.21898994812710715, -0.12349482820713185, 0.06214209793866959, -0.028178060281095475, 0.011574196766380912, -0.004316585743069212, 0.0014614234990729833, -0.0004479421180546148,
				0.00012364746105943762, -3.049028334797044E-05, 6.63941401521146E-06, -1.25538357703889E-06, 2.0073446451228E-07, -2.588260170637E-08, 2.41143742758E-09, -1.0159674352E-10, -1.202430736E-11, 2.62906137E-12,
				-1.531319E-13, -1.57476E-14, 3.15635E-15, -4.096E-17, -3.62E-17, 2.39E-18, 3.6E-19, -4E-20
			};
			double[] coefficients2 = new double[16]
			{
				2.008613082356059, 0.004037379665004385, -0.00025199480286580266, 1.605736682811176E-05, -1.03692182473444E-06, 6.765578876305E-08, -4.44999906756E-09, 2.9468889228E-10, -1.962180522E-11, 1.31330306E-12,
				-8.81919E-14, 5.95376E-15, -4.0389E-16, 2.651E-17, -2.08E-18, 1.1E-19
			};
			double[] coefficients3 = new double[24]
			{
				2.0032651024116066, 0.0019520685157649207, 0.0003823952356990833, 7.534280817054436E-05, 1.495957655897078E-05, 2.99940531210557E-06, 6.0769604822459E-07, 1.2399495544506E-07, 2.523262552649E-08, 5.04634857332E-09,
				9.791323623E-10, 1.8389115241E-10, 3.376309278E-11, 6.11179703E-12, 1.08472972E-12, 1.8861271E-13, 3.280345E-14, 5.65647E-15, 9.33E-16, 1.5881E-16,
				2.791E-17, 3.89E-18, 7E-19, 1.6E-19
			};
			if (x <= 16.0)
			{
				if (x < 4.4703484E-08)
				{
					return 2.0 / Math.PI * x;
				}
				double x2 = (4.0 * x - 24.0) / (x + 24.0);
				return 2.0 / Math.PI * x * Evaluate.ChebyshevSum(25, coefficients, x2) * Math.Exp(x);
			}
			double d;
			if (x > 2.5220158E+17)
			{
				d = 1.0;
			}
			else
			{
				double x3 = (x - 28.0) / (4.0 - x);
				d = Evaluate.ChebyshevSum(14, coefficients2, x3);
			}
			double num;
			if (x > 519823030.0)
			{
				num = 1.0;
			}
			else
			{
				double num2 = x * x;
				double x4 = (800.0 - num2) / (288.0 + num2);
				num = Evaluate.ChebyshevSum(21, coefficients3, x4);
			}
			double num3 = Math.Log(d) - 0.9189385332046728 - Math.Log(x) / 2.0 + x;
			if (num3 > Math.Log(1.797693E+308))
			{
				throw new ArithmeticException("ERROR IN MISCFUN FUNCTION STRVL0: ARGUMENT CAUSES OVERFLOW");
			}
			return Math.Exp(num3) - 2.0 / Math.PI * num / x;
		}

		public static double StruveL1(double x)
		{
			if (x < 0.0)
			{
				return StruveL1(0.0 - x);
			}
			double[] coefficients = new double[27]
			{
				0.3899602735122954, -0.3365809610197575, 0.23012467912501647, -0.13121594007960832, 0.06425922289912847, -0.02750032950616636, 0.01040234148637209, -0.003505322949363881, 0.001057484984214397, -0.00028609426403666555,
				6.925708785942208E-05, -1.489693951122717E-05, 2.81035582597128E-06, -4.5503879297776E-07, 6.09017156177E-08, -6.23543724808E-09, 3.8430012067E-10, 7.90543916E-12, -4.89824083E-12, 4.6356884E-13,
				6.84205E-15, -5.69748E-15, 3.5324E-16, 4.244E-17, -6.44E-18, -2.1E-19, 9E-20
			};
			double[] coefficients2 = new double[17]
			{
				1.9754037844165235, -0.011951305550882942, 0.00033639485269196045, -1.009115655481549E-05, 3.0638951321998E-07, -9.53704370396E-09, 2.9524735558E-10, -9.51078318E-12, 2.8203667E-13, -1.134175E-14,
				1.47E-18, -6.232E-17, -7.51E-18, -1.7E-19, 5.1E-19, 2.3E-19, 5E-20
			};
			double[] coefficients3 = new double[26]
			{
				1.9967936189678914, -0.0019066326140968614, -0.0003609462241017448, -6.84184730459982E-05, -1.299008228509426E-05, -2.47152188705765E-06, -4.7147839691972E-07, -9.020819982592E-08, -1.730458637504E-08, -3.32323670159E-09,
				-6.3736421735E-10, -1.2180239756E-10, -2.317346832E-11, -4.39068833E-12, -8.284711E-13, -1.5562249E-13, -2.913112E-14, -5.43965E-15, -1.01177E-15, -1.8767E-16,
				-3.484E-17, -6.43E-18, -1.18E-18, -2.2E-19, -4E-20, -1E-20
			};
			if (x <= 16.0)
			{
				if (x <= 3.3354714E-154)
				{
					return 0.0;
				}
				double num = x * x;
				if (x < 5.7711949E-08)
				{
					return num / 4.71238898038469;
				}
				double x2 = (4.0 * x - 24.0) / (x + 24.0);
				return num * Evaluate.ChebyshevSum(24, coefficients, x2) * Math.Exp(x) / 4.71238898038469;
			}
			double d;
			if (x > 2.7021597E+17)
			{
				d = 1.0;
			}
			else
			{
				double x3 = (x - 30.0) / (2.0 - x);
				d = Evaluate.ChebyshevSum(13, coefficients2, x3);
			}
			double num2;
			if (x > 519823025.0)
			{
				num2 = 1.0;
			}
			else
			{
				double num3 = x * x;
				double x4 = (800.0 - num3) / (288.0 + num3);
				num2 = Evaluate.ChebyshevSum(22, coefficients3, x4);
			}
			double num4 = Math.Log(d) - 0.9189385332046728 - Math.Log(x) / 2.0 + x;
			if (num4 > Math.Log(1.797693E+308))
			{
				throw new ArithmeticException("ERROR IN MISCFUN FUNCTION STRVL1: ARGUMENT CAUSES OVERFLOW");
			}
			return Math.Exp(num4) - 2.0 / Math.PI * num2;
		}

		public static double BesselI0MStruveL0(double x)
		{
			return BesselI0(x) - StruveL0(x);
		}

		public static double BesselI1MStruveL1(double x)
		{
			return BesselI1(x) - StruveL1(x);
		}

		public static Complex SphericalBesselJ(double n, Complex z)
		{
			if (double.IsNaN(n) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
			{
				return new Complex(double.NaN, double.NaN);
			}
			if (double.IsInfinity(z.Real))
			{
				if (z.Imaginary != 0.0)
				{
					return new Complex(double.PositiveInfinity, double.PositiveInfinity);
				}
				return Complex.Zero;
			}
			if (z.Real == 0.0 && z.Imaginary == 0.0)
			{
				return (n == 0.0) ? 1 : 0;
			}
			return 1.2533141373155003 * BesselJ(n + 0.5, z) / Complex.Sqrt(z);
		}

		public static double SphericalBesselJ(double n, double z)
		{
			if (double.IsNaN(n) || double.IsNaN(z))
			{
				return double.NaN;
			}
			if (n < 0.0)
			{
				return double.NaN;
			}
			if (double.IsInfinity(z))
			{
				return 0.0;
			}
			if (z == 0.0)
			{
				return (n == 0.0) ? 1 : 0;
			}
			return 1.2533141373155003 * BesselJ(n + 0.5, z) / Math.Sqrt(z);
		}

		public static Complex SphericalBesselY(double n, Complex z)
		{
			if (double.IsNaN(n) || double.IsNaN(z.Real) || double.IsNaN(z.Imaginary))
			{
				return new Complex(double.NaN, double.NaN);
			}
			if (double.IsInfinity(z.Real))
			{
				if (z.Imaginary != 0.0)
				{
					return new Complex(double.PositiveInfinity, double.PositiveInfinity);
				}
				return Complex.Zero;
			}
			if (z.Real == 0.0 && z.Imaginary == 0.0)
			{
				return new Complex(double.NaN, double.NaN);
			}
			return 1.2533141373155003 * BesselY(n + 0.5, z) / Complex.Sqrt(z);
		}

		public static double SphericalBesselY(double n, double z)
		{
			if (double.IsNaN(n) || double.IsNaN(z))
			{
				return double.NaN;
			}
			if (n < 0.0)
			{
				return double.NaN;
			}
			if (double.IsInfinity(z))
			{
				return 0.0;
			}
			if (z == 0.0)
			{
				return double.NegativeInfinity;
			}
			return 1.2533141373155003 * BesselY(n + 0.5, z) / Math.Sqrt(z);
		}

		public static Complex Hypotenuse(Complex a, Complex b)
		{
			if (a.Magnitude > b.Magnitude)
			{
				double num = b.Magnitude / a.Magnitude;
				return a.Magnitude * Math.Sqrt(1.0 + num * num);
			}
			if (b != 0.0)
			{
				double num2 = a.Magnitude / b.Magnitude;
				return b.Magnitude * Math.Sqrt(1.0 + num2 * num2);
			}
			return 0.0;
		}

		public static Complex32 Hypotenuse(Complex32 a, Complex32 b)
		{
			if (a.Magnitude > b.Magnitude)
			{
				float num = b.Magnitude / a.Magnitude;
				return a.Magnitude * (float)Math.Sqrt(1f + num * num);
			}
			if (b != 0f)
			{
				float num2 = a.Magnitude / b.Magnitude;
				return b.Magnitude * (float)Math.Sqrt(1f + num2 * num2);
			}
			return 0f;
		}

		public static double Hypotenuse(double a, double b)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return double.NaN;
			}
			if (Math.Abs(a) > Math.Abs(b))
			{
				double num = b / a;
				return Math.Abs(a) * Math.Sqrt(1.0 + num * num);
			}
			if (b != 0.0)
			{
				double num2 = a / b;
				return Math.Abs(b) * Math.Sqrt(1.0 + num2 * num2);
			}
			return 0.0;
		}

		public static float Hypotenuse(float a, float b)
		{
			if (Math.Abs(a) > Math.Abs(b))
			{
				float num = b / a;
				return Math.Abs(a) * (float)Math.Sqrt(1f + num * num);
			}
			if ((double)b != 0.0)
			{
				float num2 = a / b;
				return Math.Abs(b) * (float)Math.Sqrt(1f + num2 * num2);
			}
			return 0f;
		}
	}
}
