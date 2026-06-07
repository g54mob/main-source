using System;
using System.Runtime.InteropServices;
using ModApi.Packages;
using ModApi.Packages.FastNoise;

namespace Assets.Scripts.Noise
{
	public class FastNoiseNative : IFastNoise, INoiseGenerator, IDisposable
	{
		private static class NativeMethods
		{
			private const string DllImport = "SR2Native";

			[DllImport("SR2Native", EntryPoint = "FastNoise_Dispose")]
			public static extern void Dispose(UIntPtr fastNoise);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GetCraterNoise")]
			public static extern double GetCraterNoise(UIntPtr nativePointer, double x, double y, double z);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GetNoise")]
			public static extern double GetNoise(UIntPtr fastNoise, double x, double y, double z);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GetNoise2D")]
			public static extern double GetNoise2D(UIntPtr fastNoise, double x, double y);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GetSeed")]
			public static extern int GetSeed(UIntPtr fastNoise);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GradientPerturb")]
			public static extern void GradientPerturb(UIntPtr fastNoise, [In][Out] ref double x, [In][Out] ref double y, [In][Out] ref double z);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GradientPerturb2D")]
			public static extern void GradientPerturb2D(UIntPtr fastNoise, [In][Out] ref double x, [In][Out] ref double y);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GradientPerturbFractal")]
			public static extern void GradientPerturbFractal(UIntPtr fastNoise, [In][Out] ref double x, [In][Out] ref double y, [In][Out] ref double z);

			[DllImport("SR2Native", EntryPoint = "FastNoise_GradientPerturbFractal2D")]
			public static extern void GradientPerturbFractal2D(UIntPtr fastNoise, [In][Out] ref double x, [In][Out] ref double y);

			[DllImport("SR2Native", EntryPoint = "FastNoise_Initialize")]
			public static extern UIntPtr Initialize(int seed);

			[DllImport("SR2Native", EntryPoint = "FastNoise_InitializeCraterNoise")]
			public static extern void InitializeCraterNoise(UIntPtr nativePointer, double randomness);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetCellularDistanceFunction")]
			public static extern void SetCellularDistanceFunction(UIntPtr fastNoise, CellularDistanceFunction distanceFunction);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetCellularReturnType")]
			public static extern void SetCellularReturnType(UIntPtr fastNoise, CellularReturnType returnType);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalAmplitudes")]
			public static extern void SetFractalAmplitudes(UIntPtr fastNoise, double[] fractalAmplitudes);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalGain")]
			public static extern void SetFractalGain(UIntPtr fastNoise, double gain);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalLacunarities")]
			public static extern void SetFractalLacunarities(UIntPtr fastNoise, double[] lacunarity);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalLacunarity")]
			public static extern void SetFractalLacunarity(UIntPtr fastNoise, double lacunarity);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalOctaves")]
			public static extern void SetFractalOctaves(UIntPtr fastNoise, int octaves);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalOctaveSkipCount")]
			public static extern void SetFractalOctaveSkipCount(UIntPtr fastNoise, int octaveSkipCount);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalPowerExponent")]
			public static extern void SetFractalPowerExponent(UIntPtr fastNoise, double powerExponent);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalType")]
			public static extern void SetFractalType(UIntPtr fastNoise, FractalType fractalType);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFractalWithDerivativeType")]
			public static extern void SetFractalWithDerivativeType(UIntPtr fastNoise, FractalWithDerivativeType fractalType);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetFrequency")]
			public static extern void SetFrequency(UIntPtr fastNoise, double frequency);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetGradientPerturbAmp")]
			public static extern void SetGradientPerturbAmp(UIntPtr fastNoise, double gradientPerturbAmp);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetInterpolation")]
			public static extern void SetInterpolation(UIntPtr fastNoise, Interpolation interpolation);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetNoiseType")]
			public static extern void SetNoiseType(UIntPtr fastNoise, NoiseType noiseType);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetSeed")]
			public static extern void SetSeed(UIntPtr fastNoise, int seed);

			[DllImport("SR2Native", EntryPoint = "FastNoise_SetSlopeErosionStrength")]
			public static extern void SetSlopeErosionStrength(UIntPtr fastNoise, double slopeErosionStrength);
		}

		public const bool Supported = true;

		private bool _disposed;

		private UIntPtr _nativePointer;

		public FastNoiseNative(int seed)
		{
			_nativePointer = NativeMethods.Initialize(seed);
		}

		~FastNoiseNative()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public double GetCraterNoise(double x, double y, double z)
		{
			return NativeMethods.GetCraterNoise(_nativePointer, x, y, z);
		}

		public double GetNoise(double x, double y, double z)
		{
			return NativeMethods.GetNoise(_nativePointer, x, y, z);
		}

		public double GetNoise(double x, double y)
		{
			return NativeMethods.GetNoise2D(_nativePointer, x, y);
		}

		public int GetSeed()
		{
			return NativeMethods.GetSeed(_nativePointer);
		}

		public void GradientPerturb(ref double x, ref double y, ref double z)
		{
			NativeMethods.GradientPerturb(_nativePointer, ref x, ref y, ref z);
		}

		public void GradientPerturb(ref double x, ref double y)
		{
			NativeMethods.GradientPerturb2D(_nativePointer, ref x, ref y);
		}

		public void GradientPerturbFractal(ref double x, ref double y, ref double z)
		{
			NativeMethods.GradientPerturbFractal(_nativePointer, ref x, ref y, ref z);
		}

		public void GradientPerturbFractal(ref double x, ref double y)
		{
			NativeMethods.GradientPerturbFractal2D(_nativePointer, ref x, ref y);
		}

		public void InitializeCraterNoise(double randomness)
		{
			NativeMethods.InitializeCraterNoise(_nativePointer, randomness);
		}

		public void SetCellularDistanceFunction(CellularDistanceFunction distanceFunction)
		{
			NativeMethods.SetCellularDistanceFunction(_nativePointer, distanceFunction);
		}

		public void SetCellularReturnType(CellularReturnType returnType)
		{
			NativeMethods.SetCellularReturnType(_nativePointer, returnType);
		}

		public void SetFractalAmplitudes(double[] fractalAmplitudes)
		{
			NativeMethods.SetFractalAmplitudes(_nativePointer, fractalAmplitudes);
		}

		public void SetFractalGain(double gain)
		{
			NativeMethods.SetFractalGain(_nativePointer, gain);
		}

		public void SetFractalLacunarities(double[] lacunarity)
		{
			NativeMethods.SetFractalLacunarities(_nativePointer, lacunarity);
		}

		public void SetFractalLacunarity(double lacunarity)
		{
			NativeMethods.SetFractalLacunarity(_nativePointer, lacunarity);
		}

		public void SetFractalOctaves(int octaves)
		{
			NativeMethods.SetFractalOctaves(_nativePointer, octaves);
		}

		public void SetFractalOctaveSkipCount(int octaveSkipCount)
		{
			NativeMethods.SetFractalOctaveSkipCount(_nativePointer, octaveSkipCount);
		}

		public void SetFractalPowerExponent(double powerExponent)
		{
			NativeMethods.SetFractalPowerExponent(_nativePointer, powerExponent);
		}

		public void SetFractalType(FractalType fractalType)
		{
			NativeMethods.SetFractalType(_nativePointer, fractalType);
		}

		public void SetFractalWithDerivativeType(FractalWithDerivativeType fractalWithDerivativeType)
		{
			NativeMethods.SetFractalWithDerivativeType(_nativePointer, fractalWithDerivativeType);
		}

		public void SetFrequency(double frequency)
		{
			NativeMethods.SetFrequency(_nativePointer, frequency);
		}

		public void SetGradientPerturbAmp(double gradientPerturbAmp)
		{
			NativeMethods.SetGradientPerturbAmp(_nativePointer, gradientPerturbAmp);
		}

		public void SetInterpolation(Interpolation interpolation)
		{
			NativeMethods.SetInterpolation(_nativePointer, interpolation);
		}

		public void SetNoiseType(NoiseType noiseType)
		{
			NativeMethods.SetNoiseType(_nativePointer, noiseType);
		}

		public void SetSeed(int seed)
		{
			NativeMethods.SetSeed(_nativePointer, seed);
		}

		public void SetSlopeErosionStrength(double slopeErosionStrength)
		{
			NativeMethods.SetSlopeErosionStrength(_nativePointer, slopeErosionStrength);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (_nativePointer != UIntPtr.Zero)
				{
					NativeMethods.Dispose(_nativePointer);
					_nativePointer = UIntPtr.Zero;
				}
				_disposed = true;
			}
		}
	}
}
