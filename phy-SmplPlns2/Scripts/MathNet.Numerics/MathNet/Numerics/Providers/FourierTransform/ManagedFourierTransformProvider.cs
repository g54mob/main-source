using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Providers.FourierTransform
{
	public sealed class ManagedFourierTransformProvider : IFourierTransformProvider
	{
		private const int BluesteinSequenceLengthThreshold = 46341;

		public static ManagedFourierTransformProvider Instance { get; } = new ManagedFourierTransformProvider();

		private static Complex32[] BluesteinSequence32(int n)
		{
			double num = Math.PI / (double)n;
			Complex32[] array = new Complex32[n];
			if (n > 46341)
			{
				for (int i = 0; i < array.Length; i++)
				{
					double num2 = num * (double)i * (double)i;
					array[i] = new Complex32((float)Math.Cos(num2), (float)Math.Sin(num2));
				}
			}
			else
			{
				for (int j = 0; j < array.Length; j++)
				{
					double num3 = num * (double)(j * j);
					array[j] = new Complex32((float)Math.Cos(num3), (float)Math.Sin(num3));
				}
			}
			return array;
		}

		private static Complex[] BluesteinSequence(int n)
		{
			double num = Math.PI / (double)n;
			Complex[] array = new Complex[n];
			if (n > 46341)
			{
				for (int i = 0; i < array.Length; i++)
				{
					double num2 = num * (double)i * (double)i;
					array[i] = new Complex(Math.Cos(num2), Math.Sin(num2));
				}
			}
			else
			{
				for (int j = 0; j < array.Length; j++)
				{
					double num3 = num * (double)(j * j);
					array[j] = new Complex(Math.Cos(num3), Math.Sin(num3));
				}
			}
			return array;
		}

		private static void BluesteinConvolutionParallel(Complex32[] samples)
		{
			int n = samples.Length;
			Complex32[] sequence = BluesteinSequence32(n);
			int m = ((n << 1) - 1).CeilingToPowerOfTwo();
			Complex32[] b = new Complex32[m];
			Complex32[] a = new Complex32[m];
			CommonParallel.Invoke(delegate
			{
				for (int i = 0; i < n; i++)
				{
					b[i] = sequence[i];
				}
				for (int j = m - n + 1; j < b.Length; j++)
				{
					b[j] = sequence[m - j];
				}
				Radix2Forward(b);
			}, delegate
			{
				for (int i = 0; i < samples.Length; i++)
				{
					a[i] = sequence[i].Conjugate() * samples[i];
				}
				Radix2Forward(a);
			});
			for (int num = 0; num < a.Length; num++)
			{
				a[num] *= b[num];
			}
			Radix2InverseParallel(a);
			float num2 = 1f / (float)m;
			for (int num3 = 0; num3 < samples.Length; num3++)
			{
				samples[num3] = num2 * sequence[num3].Conjugate() * a[num3];
			}
		}

		private static void BluesteinConvolutionParallel(Complex[] samples)
		{
			int n = samples.Length;
			Complex[] sequence = BluesteinSequence(n);
			int m = ((n << 1) - 1).CeilingToPowerOfTwo();
			Complex[] b = new Complex[m];
			Complex[] a = new Complex[m];
			CommonParallel.Invoke(delegate
			{
				for (int i = 0; i < n; i++)
				{
					b[i] = sequence[i];
				}
				for (int j = m - n + 1; j < b.Length; j++)
				{
					b[j] = sequence[m - j];
				}
				Radix2Forward(b);
			}, delegate
			{
				for (int i = 0; i < samples.Length; i++)
				{
					a[i] = sequence[i].Conjugate() * samples[i];
				}
				Radix2Forward(a);
			});
			for (int num = 0; num < a.Length; num++)
			{
				a[num] *= b[num];
			}
			Radix2InverseParallel(a);
			double num2 = 1.0 / (double)m;
			for (int num3 = 0; num3 < samples.Length; num3++)
			{
				samples[num3] = num2 * sequence[num3].Conjugate() * a[num3];
			}
		}

		private static void SwapRealImaginary(Complex32[] samples)
		{
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] = new Complex32(samples[i].Imaginary, samples[i].Real);
			}
		}

		private static void SwapRealImaginary(Complex[] samples)
		{
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] = new Complex(samples[i].Imaginary, samples[i].Real);
			}
		}

		private static void BluesteinForward(Complex[] samples)
		{
			BluesteinConvolutionParallel(samples);
		}

		private static void BluesteinInverse(Complex[] spectrum)
		{
			SwapRealImaginary(spectrum);
			BluesteinConvolutionParallel(spectrum);
			SwapRealImaginary(spectrum);
		}

		private static void BluesteinForward(Complex32[] samples)
		{
			BluesteinConvolutionParallel(samples);
		}

		private static void BluesteinInverse(Complex32[] spectrum)
		{
			SwapRealImaginary(spectrum);
			BluesteinConvolutionParallel(spectrum);
			SwapRealImaginary(spectrum);
		}

		public bool IsAvailable()
		{
			return true;
		}

		public void InitializeVerify()
		{
		}

		public void FreeResources()
		{
		}

		public override string ToString()
		{
			return "Managed";
		}

		public void Forward(Complex32[] samples, FourierTransformScaling scaling)
		{
			if (samples.Length.IsPowerOfTwo())
			{
				if (samples.Length >= 1024)
				{
					Radix2ForwardParallel(samples);
				}
				else
				{
					Radix2Forward(samples);
				}
			}
			else
			{
				BluesteinForward(samples);
			}
			switch (scaling)
			{
			case FourierTransformScaling.SymmetricScaling:
				HalfRescale(samples);
				break;
			case FourierTransformScaling.ForwardScaling:
				FullRescale(samples);
				break;
			}
		}

		public void Forward(Complex[] samples, FourierTransformScaling scaling)
		{
			if (samples.Length.IsPowerOfTwo())
			{
				if (samples.Length >= 1024)
				{
					Radix2ForwardParallel(samples);
				}
				else
				{
					Radix2Forward(samples);
				}
			}
			else
			{
				BluesteinForward(samples);
			}
			switch (scaling)
			{
			case FourierTransformScaling.SymmetricScaling:
				HalfRescale(samples);
				break;
			case FourierTransformScaling.ForwardScaling:
				FullRescale(samples);
				break;
			}
		}

		public void Backward(Complex32[] spectrum, FourierTransformScaling scaling)
		{
			if (spectrum.Length.IsPowerOfTwo())
			{
				if (spectrum.Length >= 1024)
				{
					Radix2InverseParallel(spectrum);
				}
				else
				{
					Radix2Inverse(spectrum);
				}
			}
			else
			{
				BluesteinInverse(spectrum);
			}
			switch (scaling)
			{
			case FourierTransformScaling.SymmetricScaling:
				HalfRescale(spectrum);
				break;
			case FourierTransformScaling.BackwardScaling:
				FullRescale(spectrum);
				break;
			}
		}

		public void Backward(Complex[] spectrum, FourierTransformScaling scaling)
		{
			if (spectrum.Length.IsPowerOfTwo())
			{
				if (spectrum.Length >= 1024)
				{
					Radix2InverseParallel(spectrum);
				}
				else
				{
					Radix2Inverse(spectrum);
				}
			}
			else
			{
				BluesteinInverse(spectrum);
			}
			switch (scaling)
			{
			case FourierTransformScaling.SymmetricScaling:
				HalfRescale(spectrum);
				break;
			case FourierTransformScaling.BackwardScaling:
				FullRescale(spectrum);
				break;
			}
		}

		public void ForwardReal(float[] samples, int n, FourierTransformScaling scaling)
		{
			Complex32[] array = new Complex32[n];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex32(samples[i], 0f);
			}
			Forward(array, scaling);
			samples[0] = array[0].Real;
			samples[1] = 0f;
			int j = 1;
			int num = 2;
			for (; j < array.Length / 2; j++)
			{
				samples[num++] = array[j].Real;
				samples[num++] = array[j].Imaginary;
			}
			if (n.IsEven())
			{
				samples[n] = array[array.Length / 2].Real;
				samples[n + 1] = 0f;
			}
			else
			{
				samples[n - 1] = array[array.Length / 2].Real;
				samples[n] = array[array.Length / 2].Imaginary;
			}
		}

		public void ForwardReal(double[] samples, int n, FourierTransformScaling scaling)
		{
			Complex[] array = new Complex[n];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex(samples[i], 0.0);
			}
			Forward(array, scaling);
			samples[0] = array[0].Real;
			samples[1] = 0.0;
			int j = 1;
			int num = 2;
			for (; j < array.Length / 2; j++)
			{
				samples[num++] = array[j].Real;
				samples[num++] = array[j].Imaginary;
			}
			if (n.IsEven())
			{
				samples[n] = array[array.Length / 2].Real;
				samples[n + 1] = 0.0;
			}
			else
			{
				samples[n - 1] = array[array.Length / 2].Real;
				samples[n] = array[array.Length / 2].Imaginary;
			}
		}

		public void BackwardReal(float[] spectrum, int n, FourierTransformScaling scaling)
		{
			Complex32[] array = new Complex32[n];
			array[0] = new Complex32(spectrum[0], 0f);
			int i = 1;
			int num = 2;
			for (; i < array.Length / 2; i++)
			{
				array[i] = new Complex32(spectrum[num++], spectrum[num++]);
				array[^i] = array[i].Conjugate();
			}
			if (n.IsEven())
			{
				array[array.Length / 2] = new Complex32(spectrum[n], 0f);
			}
			else
			{
				array[array.Length / 2] = new Complex32(spectrum[n - 1], spectrum[n]);
				array[array.Length / 2 + 1] = array[array.Length / 2].Conjugate();
			}
			Backward(array, scaling);
			for (int j = 0; j < array.Length; j++)
			{
				spectrum[j] = array[j].Real;
			}
			spectrum[n] = 0f;
		}

		public void BackwardReal(double[] spectrum, int n, FourierTransformScaling scaling)
		{
			Complex[] array = new Complex[n];
			array[0] = new Complex(spectrum[0], 0.0);
			int i = 1;
			int num = 2;
			for (; i < array.Length / 2; i++)
			{
				array[i] = new Complex(spectrum[num++], spectrum[num++]);
				array[^i] = array[i].Conjugate();
			}
			if (n.IsEven())
			{
				array[array.Length / 2] = new Complex(spectrum[n], 0.0);
			}
			else
			{
				array[array.Length / 2] = new Complex(spectrum[n - 1], spectrum[n]);
				array[array.Length / 2 + 1] = array[array.Length / 2].Conjugate();
			}
			Backward(array, scaling);
			for (int j = 0; j < array.Length; j++)
			{
				spectrum[j] = array[j].Real;
			}
			spectrum[n] = 0.0;
		}

		public void ForwardMultidim(Complex32[] samples, int[] dimensions, FourierTransformScaling scaling)
		{
			throw new NotSupportedException();
		}

		public void ForwardMultidim(Complex[] samples, int[] dimensions, FourierTransformScaling scaling)
		{
			throw new NotSupportedException();
		}

		public void BackwardMultidim(Complex32[] spectrum, int[] dimensions, FourierTransformScaling scaling)
		{
			throw new NotSupportedException();
		}

		public void BackwardMultidim(Complex[] spectrum, int[] dimensions, FourierTransformScaling scaling)
		{
			throw new NotSupportedException();
		}

		private static void Radix2Reorder<T>(T[] samples)
		{
			int num = 0;
			for (int i = 0; i < samples.Length - 1; i++)
			{
				if (i < num)
				{
					int num2 = i;
					int num3 = num;
					T val = samples[num];
					T val2 = samples[i];
					samples[num2] = val;
					samples[num3] = val2;
				}
				int num4 = samples.Length;
				do
				{
					num4 >>= 1;
					num ^= num4;
				}
				while ((num & num4) == 0);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Radix2Step(Complex32[] samples, int exponentSign, int levelSize, int k)
		{
			double num = (double)(exponentSign * k) * Math.PI / (double)levelSize;
			Complex32 complex = new Complex32((float)Math.Cos(num), (float)Math.Sin(num));
			int num2 = levelSize << 1;
			for (int i = k; i < samples.Length; i += num2)
			{
				Complex32 complex2 = samples[i];
				Complex32 complex3 = complex * samples[i + levelSize];
				samples[i] = complex2 + complex3;
				samples[i + levelSize] = complex2 - complex3;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Radix2Step(Complex[] samples, int exponentSign, int levelSize, int k)
		{
			double num = (double)(exponentSign * k) * Math.PI / (double)levelSize;
			Complex complex = new Complex(Math.Cos(num), Math.Sin(num));
			int num2 = levelSize << 1;
			for (int i = k; i < samples.Length; i += num2)
			{
				Complex complex2 = samples[i];
				Complex complex3 = complex * samples[i + levelSize];
				samples[i] = complex2 + complex3;
				samples[i + levelSize] = complex2 - complex3;
			}
		}

		private static void Radix2Forward(Complex32[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				for (int i = 0; i < num; i++)
				{
					Radix2Step(data, -1, num, i);
				}
			}
		}

		private static void Radix2Forward(Complex[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				for (int i = 0; i < num; i++)
				{
					Radix2Step(data, -1, num, i);
				}
			}
		}

		private static void Radix2Inverse(Complex32[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				for (int i = 0; i < num; i++)
				{
					Radix2Step(data, 1, num, i);
				}
			}
		}

		private static void Radix2Inverse(Complex[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				for (int i = 0; i < num; i++)
				{
					Radix2Step(data, 1, num, i);
				}
			}
		}

		private static void Radix2ForwardParallel(Complex32[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				int size = num;
				CommonParallel.For(0, size, 64, delegate(int u, int v)
				{
					for (int i = u; i < v; i++)
					{
						Radix2Step(data, -1, size, i);
					}
				});
			}
		}

		private static void Radix2ForwardParallel(Complex[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				int size = num;
				CommonParallel.For(0, size, 64, delegate(int u, int v)
				{
					for (int i = u; i < v; i++)
					{
						Radix2Step(data, -1, size, i);
					}
				});
			}
		}

		private static void Radix2InverseParallel(Complex32[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				int size = num;
				CommonParallel.For(0, size, 64, delegate(int u, int v)
				{
					for (int i = u; i < v; i++)
					{
						Radix2Step(data, 1, size, i);
					}
				});
			}
		}

		private static void Radix2InverseParallel(Complex[] data)
		{
			Radix2Reorder(data);
			for (int num = 1; num < data.Length; num *= 2)
			{
				int size = num;
				CommonParallel.For(0, size, 64, delegate(int u, int v)
				{
					for (int i = u; i < v; i++)
					{
						Radix2Step(data, 1, size, i);
					}
				});
			}
		}

		private static void FullRescale(Complex32[] samples)
		{
			float num = 1f / (float)samples.Length;
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] *= num;
			}
		}

		private static void FullRescale(Complex[] samples)
		{
			double num = 1.0 / (double)samples.Length;
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] *= (Complex)num;
			}
		}

		private static void HalfRescale(Complex32[] samples)
		{
			float num = (float)Math.Sqrt(1.0 / (double)samples.Length);
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] *= num;
			}
		}

		private static void HalfRescale(Complex[] samples)
		{
			double num = Math.Sqrt(1.0 / (double)samples.Length);
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i] *= (Complex)num;
			}
		}
	}
}
