using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.FourierTransform;

namespace MathNet.Numerics.IntegralTransforms
{
	public static class Fourier
	{
		public static void Forward(Complex32[] samples)
		{
			FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.SymmetricScaling);
		}

		public static void Forward(Complex[] samples)
		{
			FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.SymmetricScaling);
		}

		public static void Forward(Complex32[] samples, FourierOptions options)
		{
			switch (options)
			{
			case FourierOptions.AsymmetricScaling:
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.Backward(samples, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.Backward(samples, FourierTransformScaling.NoScaling);
				break;
			default:
				FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Forward(Complex[] samples, FourierOptions options)
		{
			switch (options)
			{
			case FourierOptions.AsymmetricScaling:
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.Backward(samples, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.Backward(samples, FourierTransformScaling.NoScaling);
				break;
			default:
				FourierTransformControl.Provider.Forward(samples, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Forward(float[] real, float[] imaginary, FourierOptions options = FourierOptions.Default)
		{
			if (real.Length != imaginary.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.");
			}
			Complex32[] array = new Complex32[real.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex32(real[i], imaginary[i]);
			}
			Forward(array, options);
			for (int j = 0; j < array.Length; j++)
			{
				real[j] = array[j].Real;
				imaginary[j] = array[j].Imaginary;
			}
		}

		public static void Forward(double[] real, double[] imaginary, FourierOptions options = FourierOptions.Default)
		{
			if (real.Length != imaginary.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.");
			}
			Complex[] array = new Complex[real.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex(real[i], imaginary[i]);
			}
			Forward(array, options);
			for (int j = 0; j < array.Length; j++)
			{
				real[j] = array[j].Real;
				imaginary[j] = array[j].Imaginary;
			}
		}

		public static void ForwardReal(float[] data, int n, FourierOptions options = FourierOptions.Default)
		{
			int num = (n.IsEven() ? (n + 2) : (n + 1));
			if (data.Length < num)
			{
				throw new ArgumentException($"The given array is too small. It must be at least {num} long.");
			}
			if ((options & FourierOptions.InverseExponent) == FourierOptions.InverseExponent)
			{
				throw new NotSupportedException();
			}
			if (options == FourierOptions.AsymmetricScaling || options == FourierOptions.NoScaling)
			{
				FourierTransformControl.Provider.ForwardReal(data, n, FourierTransformScaling.NoScaling);
			}
			else
			{
				FourierTransformControl.Provider.ForwardReal(data, n, FourierTransformScaling.SymmetricScaling);
			}
		}

		public static void ForwardReal(double[] data, int n, FourierOptions options = FourierOptions.Default)
		{
			int num = (n.IsEven() ? (n + 2) : (n + 1));
			if (data.Length < num)
			{
				throw new ArgumentException($"The given array is too small. It must be at least {num} long.");
			}
			if ((options & FourierOptions.InverseExponent) == FourierOptions.InverseExponent)
			{
				throw new NotSupportedException();
			}
			if (options == FourierOptions.AsymmetricScaling || options == FourierOptions.NoScaling)
			{
				FourierTransformControl.Provider.ForwardReal(data, n, FourierTransformScaling.NoScaling);
			}
			else
			{
				FourierTransformControl.Provider.ForwardReal(data, n, FourierTransformScaling.SymmetricScaling);
			}
		}

		public static void ForwardMultiDim(Complex32[] samples, int[] dimensions, FourierOptions options = FourierOptions.Default)
		{
			switch (options)
			{
			case FourierOptions.AsymmetricScaling:
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.ForwardMultidim(samples, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.BackwardMultidim(samples, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.BackwardMultidim(samples, dimensions, FourierTransformScaling.NoScaling);
				break;
			default:
				FourierTransformControl.Provider.ForwardMultidim(samples, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void ForwardMultiDim(Complex[] samples, int[] dimensions, FourierOptions options = FourierOptions.Default)
		{
			switch (options)
			{
			case FourierOptions.AsymmetricScaling:
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.ForwardMultidim(samples, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.BackwardMultidim(samples, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.BackwardMultidim(samples, dimensions, FourierTransformScaling.NoScaling);
				break;
			default:
				FourierTransformControl.Provider.ForwardMultidim(samples, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Forward2D(Complex32[] samplesRowWise, int rows, int columns, FourierOptions options = FourierOptions.Default)
		{
			ForwardMultiDim(samplesRowWise, new int[2] { rows, columns }, options);
		}

		public static void Forward2D(Complex[] samplesRowWise, int rows, int columns, FourierOptions options = FourierOptions.Default)
		{
			ForwardMultiDim(samplesRowWise, new int[2] { rows, columns }, options);
		}

		public static void Forward2D(Matrix<Complex32> samples, FourierOptions options = FourierOptions.Default)
		{
			Complex32[] array = samples.AsRowMajorArray();
			if (array != null)
			{
				ForwardMultiDim(array, new int[2] { samples.RowCount, samples.ColumnCount }, options);
				return;
			}
			Complex32[] array2 = samples.AsColumnMajorArray();
			if (array2 != null)
			{
				ForwardMultiDim(array2, new int[2] { samples.ColumnCount, samples.RowCount }, options);
			}
			else
			{
				array2 = samples.ToColumnMajorArray();
				ForwardMultiDim(array2, new int[2] { samples.ColumnCount, samples.RowCount }, options);
				new DenseColumnMajorMatrixStorage<Complex32>(samples.RowCount, samples.ColumnCount, array2).CopyToUnchecked(samples.Storage, ExistingData.Clear);
			}
		}

		public static void Forward2D(Matrix<Complex> samples, FourierOptions options = FourierOptions.Default)
		{
			Complex[] array = samples.AsRowMajorArray();
			if (array != null)
			{
				ForwardMultiDim(array, new int[2] { samples.RowCount, samples.ColumnCount }, options);
				return;
			}
			Complex[] array2 = samples.AsColumnMajorArray();
			if (array2 != null)
			{
				ForwardMultiDim(array2, new int[2] { samples.ColumnCount, samples.RowCount }, options);
			}
			else
			{
				array2 = samples.ToColumnMajorArray();
				ForwardMultiDim(array2, new int[2] { samples.ColumnCount, samples.RowCount }, options);
				new DenseColumnMajorMatrixStorage<Complex>(samples.RowCount, samples.ColumnCount, array2).CopyToUnchecked(samples.Storage, ExistingData.Clear);
			}
		}

		public static void Inverse(Complex32[] spectrum)
		{
			FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.SymmetricScaling);
		}

		public static void Inverse(Complex[] spectrum)
		{
			FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.SymmetricScaling);
		}

		public static void Inverse(Complex32[] spectrum, FourierOptions options)
		{
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.BackwardScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.ForwardScaling);
				break;
			default:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Inverse(Complex[] spectrum, FourierOptions options)
		{
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.BackwardScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.Forward(spectrum, FourierTransformScaling.ForwardScaling);
				break;
			default:
				FourierTransformControl.Provider.Backward(spectrum, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Inverse(float[] real, float[] imaginary, FourierOptions options = FourierOptions.Default)
		{
			if (real.Length != imaginary.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.");
			}
			Complex32[] array = new Complex32[real.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex32(real[i], imaginary[i]);
			}
			Inverse(array, options);
			for (int j = 0; j < array.Length; j++)
			{
				real[j] = array[j].Real;
				imaginary[j] = array[j].Imaginary;
			}
		}

		public static void Inverse(double[] real, double[] imaginary, FourierOptions options = FourierOptions.Default)
		{
			if (real.Length != imaginary.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.");
			}
			Complex[] array = new Complex[real.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Complex(real[i], imaginary[i]);
			}
			Inverse(array, options);
			for (int j = 0; j < array.Length; j++)
			{
				real[j] = array[j].Real;
				imaginary[j] = array[j].Imaginary;
			}
		}

		public static void InverseReal(float[] data, int n, FourierOptions options = FourierOptions.Default)
		{
			int num = (n.IsEven() ? (n + 2) : (n + 1));
			if (data.Length < num)
			{
				throw new ArgumentException($"The given array is too small. It must be at least {num} long.");
			}
			if ((options & FourierOptions.InverseExponent) == FourierOptions.InverseExponent)
			{
				throw new NotSupportedException();
			}
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.BackwardScaling);
				break;
			default:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void InverseReal(double[] data, int n, FourierOptions options = FourierOptions.Default)
		{
			int num = (n.IsEven() ? (n + 2) : (n + 1));
			if (data.Length < num)
			{
				throw new ArgumentException($"The given array is too small. It must be at least {num} long.");
			}
			if ((options & FourierOptions.InverseExponent) == FourierOptions.InverseExponent)
			{
				throw new NotSupportedException();
			}
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.BackwardScaling);
				break;
			default:
				FourierTransformControl.Provider.BackwardReal(data, n, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void InverseMultiDim(Complex32[] spectrum, int[] dimensions, FourierOptions options = FourierOptions.Default)
		{
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.BackwardScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.ForwardScaling);
				break;
			default:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void InverseMultiDim(Complex[] spectrum, int[] dimensions, FourierOptions options = FourierOptions.Default)
		{
			switch (options)
			{
			case FourierOptions.NoScaling:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.BackwardScaling);
				break;
			case FourierOptions.InverseExponent:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			case FourierOptions.NumericalRecipes:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.NoScaling);
				break;
			case FourierOptions.InverseExponent | FourierOptions.AsymmetricScaling:
				FourierTransformControl.Provider.ForwardMultidim(spectrum, dimensions, FourierTransformScaling.ForwardScaling);
				break;
			default:
				FourierTransformControl.Provider.BackwardMultidim(spectrum, dimensions, FourierTransformScaling.SymmetricScaling);
				break;
			}
		}

		public static void Inverse2D(Complex32[] spectrumRowWise, int rows, int columns, FourierOptions options = FourierOptions.Default)
		{
			InverseMultiDim(spectrumRowWise, new int[2] { rows, columns }, options);
		}

		public static void Inverse2D(Complex[] spectrumRowWise, int rows, int columns, FourierOptions options = FourierOptions.Default)
		{
			InverseMultiDim(spectrumRowWise, new int[2] { rows, columns }, options);
		}

		public static void Inverse2D(Matrix<Complex32> spectrum, FourierOptions options = FourierOptions.Default)
		{
			Complex32[] array = spectrum.AsRowMajorArray();
			if (array != null)
			{
				InverseMultiDim(array, new int[2] { spectrum.RowCount, spectrum.ColumnCount }, options);
				return;
			}
			Complex32[] array2 = spectrum.AsColumnMajorArray();
			if (array2 != null)
			{
				InverseMultiDim(array2, new int[2] { spectrum.ColumnCount, spectrum.RowCount }, options);
			}
			else
			{
				array2 = spectrum.ToColumnMajorArray();
				InverseMultiDim(array2, new int[2] { spectrum.ColumnCount, spectrum.RowCount }, options);
				new DenseColumnMajorMatrixStorage<Complex32>(spectrum.RowCount, spectrum.ColumnCount, array2).CopyToUnchecked(spectrum.Storage, ExistingData.Clear);
			}
		}

		public static void Inverse2D(Matrix<Complex> spectrum, FourierOptions options = FourierOptions.Default)
		{
			Complex[] array = spectrum.AsRowMajorArray();
			if (array != null)
			{
				InverseMultiDim(array, new int[2] { spectrum.RowCount, spectrum.ColumnCount }, options);
				return;
			}
			Complex[] array2 = spectrum.AsColumnMajorArray();
			if (array2 != null)
			{
				InverseMultiDim(array2, new int[2] { spectrum.ColumnCount, spectrum.RowCount }, options);
			}
			else
			{
				array2 = spectrum.ToColumnMajorArray();
				InverseMultiDim(array2, new int[2] { spectrum.ColumnCount, spectrum.RowCount }, options);
				new DenseColumnMajorMatrixStorage<Complex>(spectrum.RowCount, spectrum.ColumnCount, array2).CopyToUnchecked(spectrum.Storage, ExistingData.Clear);
			}
		}

		public static double[] FrequencyScale(int length, double sampleRate)
		{
			double[] array = new double[length];
			double num = 0.0;
			double num2 = sampleRate / (double)length;
			int num3 = (length >> 1) + 1;
			for (int i = 0; i < num3; i++)
			{
				array[i] = num;
				num += num2;
			}
			num = (0.0 - num2) * (double)(num3 - 2);
			for (int j = num3; j < length; j++)
			{
				array[j] = num;
				num += num2;
			}
			return array;
		}
	}
}
