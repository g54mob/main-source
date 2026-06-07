using System;

namespace ModApi.Packages.FastNoise
{
	public interface IFastNoise : INoiseGenerator, IDisposable
	{
		double GetCraterNoise(double x, double y, double z);

		int GetSeed();

		void GradientPerturb(ref double x, ref double y, ref double z);

		void GradientPerturb(ref double x, ref double y);

		void GradientPerturbFractal(ref double x, ref double y, ref double z);

		void GradientPerturbFractal(ref double x, ref double y);

		void InitializeCraterNoise(double randomness);

		void SetCellularDistanceFunction(CellularDistanceFunction distanceFunction);

		void SetCellularReturnType(CellularReturnType returnType);

		void SetFractalAmplitudes(double[] fractalAmplitudes);

		void SetFractalGain(double gain);

		void SetFractalLacunarities(double[] lacunarity);

		void SetFractalLacunarity(double lacunarity);

		void SetFractalOctaves(int octaves);

		void SetFractalOctaveSkipCount(int octaveSkipCount);

		void SetFractalPowerExponent(double powerExponent);

		void SetFractalType(FractalType fractalType);

		void SetFractalWithDerivativeType(FractalWithDerivativeType fractalWithDerivativeType);

		void SetFrequency(double frequency);

		void SetGradientPerturbAmp(double gradientPerturbAmp);

		void SetInterpolation(Interpolation interpolation);

		void SetNoiseType(NoiseType noiseType);

		void SetSeed(int seed);

		void SetSlopeErosionStrength(double slopeErosionStrength);
	}
}
