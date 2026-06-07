using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics
{
	public static class Generate
	{
		public static T[] Map<TA, T>(TA[] points, Func<TA, T> map)
		{
			T[] array = new T[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				array[i] = map(points[i]);
			}
			return array;
		}

		public static IEnumerable<T> MapSequence<TA, T>(IEnumerable<TA> points, Func<TA, T> map)
		{
			return points.Select(map);
		}

		public static T[] Map2<TA, TB, T>(TA[] pointsA, TB[] pointsB, Func<TA, TB, T> map)
		{
			if (pointsA.Length != pointsB.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.", "pointsB");
			}
			T[] array = new T[pointsA.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = map(pointsA[i], pointsB[i]);
			}
			return array;
		}

		public static IEnumerable<T> Map2Sequence<TA, TB, T>(IEnumerable<TA> pointsA, IEnumerable<TB> pointsB, Func<TA, TB, T> map)
		{
			return pointsA.Zip(pointsB, map);
		}

		public static double[] LinearSpaced(int length, double start, double stop)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			switch (length)
			{
			case 0:
				return Array.Empty<double>();
			case 1:
				return new double[1] { stop };
			default:
			{
				double num = (stop - start) / (double)(length - 1);
				double[] array = new double[length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = start + (double)i * num;
				}
				array[^1] = stop;
				return array;
			}
			}
		}

		public static T[] LinearSpacedMap<T>(int length, double start, double stop, Func<double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			switch (length)
			{
			case 0:
				return Array.Empty<T>();
			case 1:
				return new T[1] { map(stop) };
			default:
			{
				double num = (stop - start) / (double)(length - 1);
				T[] array = new T[length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = map(start + (double)i * num);
				}
				array[^1] = map(stop);
				return array;
			}
			}
		}

		public static double[] LogSpaced(int length, double startExponent, double stopExponent)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			switch (length)
			{
			case 0:
				return Array.Empty<double>();
			case 1:
				return new double[1] { Math.Pow(10.0, stopExponent) };
			default:
			{
				double num = (stopExponent - startExponent) / (double)(length - 1);
				double[] array = new double[length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Math.Pow(10.0, startExponent + (double)i * num);
				}
				array[^1] = Math.Pow(10.0, stopExponent);
				return array;
			}
			}
		}

		public static T[] LogSpacedMap<T>(int length, double startExponent, double stopExponent, Func<double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			switch (length)
			{
			case 0:
				return Array.Empty<T>();
			case 1:
				return new T[1] { map(Math.Pow(10.0, stopExponent)) };
			default:
			{
				double num = (stopExponent - startExponent) / (double)(length - 1);
				T[] array = new T[length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = map(Math.Pow(10.0, startExponent + (double)i * num));
				}
				array[^1] = map(Math.Pow(10.0, stopExponent));
				return array;
			}
			}
		}

		public static double[] LinearRange(int start, int stop)
		{
			if (start == stop)
			{
				return new double[1] { start };
			}
			if (start < stop)
			{
				double[] array = new double[stop - start + 1];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = start + i;
				}
				return array;
			}
			double[] array2 = new double[start - stop + 1];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = start - j;
			}
			return array2;
		}

		public static int[] LinearRangeInt32(int start, int stop)
		{
			if (start == stop)
			{
				return new int[1] { start };
			}
			if (start < stop)
			{
				int[] array = new int[stop - start + 1];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = start + i;
				}
				return array;
			}
			int[] array2 = new int[start - stop + 1];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = start - j;
			}
			return array2;
		}

		public static double[] LinearRange(int start, int step, int stop)
		{
			if (start == stop)
			{
				return new double[1] { start };
			}
			if ((start < stop && step < 0) || (start > stop && step > 0) || (double)step == 0.0)
			{
				return Array.Empty<double>();
			}
			double[] array = new double[(stop - start) / step + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = start + i * step;
			}
			return array;
		}

		public static int[] LinearRangeInt32(int start, int step, int stop)
		{
			if (start == stop)
			{
				return new int[1] { start };
			}
			if ((start < stop && step < 0) || (start > stop && step > 0) || (double)step == 0.0)
			{
				return Array.Empty<int>();
			}
			int[] array = new int[(stop - start) / step + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = start + i * step;
			}
			return array;
		}

		public static double[] LinearRange(double start, double step, double stop)
		{
			if (start == stop)
			{
				return new double[1] { start };
			}
			if ((start < stop && step < 0.0) || (start > stop && step > 0.0) || step == 0.0)
			{
				return Array.Empty<double>();
			}
			double[] array = new double[(int)Math.Floor((stop - start) / step + 1.0)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = start + (double)i * step;
			}
			return array;
		}

		public static T[] LinearRangeMap<T>(double start, double step, double stop, Func<double, T> map)
		{
			if (start == stop)
			{
				return new T[1] { map(start) };
			}
			if ((start < stop && step < 0.0) || (start > stop && step > 0.0) || step == 0.0)
			{
				return Array.Empty<T>();
			}
			T[] array = new T[(int)Math.Floor((stop - start) / step + 1.0)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = map(start + (double)i * step);
			}
			return array;
		}

		public static double[] Periodic(int length, double samplingRate, double frequency, double amplitude = 1.0, double phase = 0.0, int delay = 0)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double num = frequency / samplingRate * amplitude;
			phase = Euclid.Modulus(phase - (double)delay * num, amplitude);
			double[] array = new double[length];
			int num2 = 0;
			int num3 = 0;
			while (num2 < array.Length)
			{
				double num4 = phase + (double)num3 * num;
				if (num4 >= amplitude)
				{
					num4 %= amplitude;
					phase = num4;
					num3 = 0;
				}
				array[num2] = num4;
				num2++;
				num3++;
			}
			return array;
		}

		public static T[] PeriodicMap<T>(int length, Func<double, T> map, double samplingRate, double frequency, double amplitude = 1.0, double phase = 0.0, int delay = 0)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double num = frequency / samplingRate * amplitude;
			phase = Euclid.Modulus(phase - (double)delay * num, amplitude);
			T[] array = new T[length];
			int num2 = 0;
			int num3 = 0;
			while (num2 < array.Length)
			{
				double num4 = phase + (double)num3 * num;
				if (num4 >= amplitude)
				{
					num4 %= amplitude;
					phase = num4;
					num3 = 0;
				}
				array[num2] = map(num4);
				num2++;
				num3++;
			}
			return array;
		}

		public static IEnumerable<double> PeriodicSequence(double samplingRate, double frequency, double amplitude = 1.0, double phase = 0.0, int delay = 0)
		{
			double step = frequency / samplingRate * amplitude;
			phase = Euclid.Modulus(phase - (double)delay * step, amplitude);
			int k = 0;
			while (true)
			{
				double num = phase + (double)k++ * step;
				if (num >= amplitude)
				{
					num %= amplitude;
					phase = num;
					k = 1;
				}
				yield return num;
			}
		}

		public static IEnumerable<T> PeriodicMapSequence<T>(Func<double, T> map, double samplingRate, double frequency, double amplitude = 1.0, double phase = 0.0, int delay = 0)
		{
			double step = frequency / samplingRate * amplitude;
			phase = Euclid.Modulus(phase - (double)delay * step, amplitude);
			int k = 0;
			while (true)
			{
				double num = phase + (double)k++ * step;
				if (num >= amplitude)
				{
					num %= amplitude;
					phase = num;
					k = 1;
				}
				yield return map(num);
			}
		}

		public static double[] Sinusoidal(int length, double samplingRate, double frequency, double amplitude, double mean = 0.0, double phase = 0.0, int delay = 0)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double num = frequency / samplingRate * (Math.PI * 2.0);
			phase = (phase - (double)delay * num) % (Math.PI * 2.0);
			double[] array = new double[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = mean + amplitude * Math.Sin(phase + (double)i * num);
			}
			return array;
		}

		public static IEnumerable<double> SinusoidalSequence(double samplingRate, double frequency, double amplitude, double mean = 0.0, double phase = 0.0, int delay = 0)
		{
			double step = frequency / samplingRate * (Math.PI * 2.0);
			phase = (phase - (double)delay * step) % (Math.PI * 2.0);
			while (true)
			{
				for (int i = 0; i < 1000; i++)
				{
					yield return mean + amplitude * Math.Sin(phase + (double)i * step);
				}
				phase = (phase + 1000.0 * step) % (Math.PI * 2.0);
			}
		}

		public static double[] Square(int length, int highDuration, int lowDuration, double lowValue, double highValue, int delay = 0)
		{
			int num = highDuration + lowDuration;
			return PeriodicMap(length, (double x) => (!(x < (double)highDuration)) ? lowValue : highValue, 1.0, 1.0 / (double)num, num, 0.0, delay);
		}

		public static IEnumerable<double> SquareSequence(int highDuration, int lowDuration, double lowValue, double highValue, int delay = 0)
		{
			int num = highDuration + lowDuration;
			return PeriodicMapSequence((double x) => (!(x < (double)highDuration)) ? lowValue : highValue, 1.0, 1.0 / (double)num, num, 0.0, delay);
		}

		public static double[] Triangle(int length, int raiseDuration, int fallDuration, double lowValue, double highValue, int delay = 0)
		{
			int num = raiseDuration + fallDuration;
			double num2 = highValue - lowValue;
			double raise = num2 / (double)raiseDuration;
			double fall = num2 / (double)fallDuration;
			return PeriodicMap(length, (double x) => (!(x < (double)raiseDuration)) ? (highValue - (x - (double)raiseDuration) * fall) : (lowValue + x * raise), 1.0, 1.0 / (double)num, num, 0.0, delay);
		}

		public static IEnumerable<double> TriangleSequence(int raiseDuration, int fallDuration, double lowValue, double highValue, int delay = 0)
		{
			int num = raiseDuration + fallDuration;
			double num2 = highValue - lowValue;
			double raise = num2 / (double)raiseDuration;
			double fall = num2 / (double)fallDuration;
			return PeriodicMapSequence((double x) => (!(x < (double)raiseDuration)) ? (highValue - (x - (double)raiseDuration) * fall) : (lowValue + x * raise), 1.0, 1.0 / (double)num, num, 0.0, delay);
		}

		public static double[] Sawtooth(int length, int period, double lowValue, double highValue, int delay = 0)
		{
			double num = highValue - lowValue;
			return PeriodicMap(length, (double x) => x + lowValue, 1.0, 1.0 / (double)period, num * (double)period / (double)(period - 1), 0.0, delay);
		}

		public static IEnumerable<double> SawtoothSequence(int period, double lowValue, double highValue, int delay = 0)
		{
			double num = highValue - lowValue;
			return PeriodicMapSequence((double x) => x + lowValue, 1.0, 1.0 / (double)period, num * (double)period / (double)(period - 1), 0.0, delay);
		}

		public static T[] Repeat<T>(int length, T value)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			T[] data = new T[length];
			CommonParallel.For(0, data.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					data[i] = value;
				}
			});
			return data;
		}

		public static IEnumerable<T> RepeatSequence<T>(T value)
		{
			while (true)
			{
				yield return value;
			}
		}

		public static double[] Step(int length, double amplitude, int delay)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			for (int i = Math.Max(0, delay); i < array.Length; i++)
			{
				array[i] = amplitude;
			}
			return array;
		}

		public static IEnumerable<double> StepSequence(double amplitude, int delay)
		{
			for (int i = 0; i < delay; i++)
			{
				yield return 0.0;
			}
			while (true)
			{
				yield return amplitude;
			}
		}

		public static double[] Impulse(int length, double amplitude, int delay)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			if (delay >= 0 && delay < length)
			{
				array[delay] = amplitude;
			}
			return array;
		}

		public static IEnumerable<double> ImpulseSequence(double amplitude, int delay)
		{
			if (delay >= 0)
			{
				for (int i = 0; i < delay; i++)
				{
					yield return 0.0;
				}
				yield return amplitude;
			}
			while (true)
			{
				yield return 0.0;
			}
		}

		public static double[] PeriodicImpulse(int length, int period, double amplitude, int delay)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			for (delay = Euclid.Modulus(delay, period); delay < length; delay += period)
			{
				array[delay] = amplitude;
			}
			return array;
		}

		public static IEnumerable<double> PeriodicImpulseSequence(int period, double amplitude, int delay)
		{
			delay = Euclid.Modulus(delay, period);
			for (int i = 0; i < delay; i++)
			{
				yield return 0.0;
			}
			while (true)
			{
				yield return amplitude;
				for (int i = 1; i < period; i++)
				{
					yield return 0.0;
				}
			}
		}

		public static T[] Unfold<T, TState>(int length, Func<TState, Tuple<T, TState>> f, TState state)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			T[] array = new T[length];
			for (int i = 0; i < array.Length; i++)
			{
				int num = i;
				f(state).Deconstruct(out var item, out var item2);
				array[num] = item;
				state = item2;
			}
			return array;
		}

		public static T[] Unfold<T, TState>(int length, Func<TState, (T, TState)> f, TState state)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			T[] array = new T[length];
			for (int i = 0; i < array.Length; i++)
			{
				int num = i;
				(T, TState) tuple = f(state);
				array[num] = tuple.Item1;
				state = tuple.Item2;
			}
			return array;
		}

		public static IEnumerable<T> UnfoldSequence<T, TState>(Func<TState, Tuple<T, TState>> f, TState state)
		{
			while (true)
			{
				f(state).Deconstruct(out var item, out var item2);
				T val = item;
				TState val2 = item2;
				state = val2;
				yield return val;
			}
		}

		public static IEnumerable<T> UnfoldSequence<T, TState>(Func<TState, (T, TState)> f, TState state)
		{
			while (true)
			{
				(T, TState) tuple = f(state);
				T item = tuple.Item1;
				TState item2 = tuple.Item2;
				state = item2;
				yield return item;
			}
		}

		public static BigInteger[] Fibonacci(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			BigInteger[] array = new BigInteger[length];
			if (array.Length != 0)
			{
				array[0] = BigInteger.Zero;
			}
			if (array.Length > 1)
			{
				array[1] = BigInteger.One;
			}
			for (int i = 2; i < array.Length; i++)
			{
				array[i] = array[i - 1] + array[i - 2];
			}
			return array;
		}

		public static IEnumerable<BigInteger> FibonacciSequence()
		{
			BigInteger a = BigInteger.Zero;
			yield return a;
			BigInteger b = BigInteger.One;
			yield return b;
			while (true)
			{
				a += b;
				yield return a;
				b = a + b;
				yield return b;
			}
		}

		public static double[] Uniform(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return SystemRandomSource.FastDoubles(length);
		}

		public static IEnumerable<double> UniformSequence()
		{
			return SystemRandomSource.DoubleSequence();
		}

		public static T[] UniformMap<T>(int length, Func<double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return Map(SystemRandomSource.FastDoubles(length), map);
		}

		public static IEnumerable<T> UniformMapSequence<T>(Func<double, T> map)
		{
			return SystemRandomSource.DoubleSequence().Select(map);
		}

		public static T[] UniformMap2<T>(int length, Func<double, double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] pointsA = SystemRandomSource.FastDoubles(length);
			double[] pointsB = SystemRandomSource.FastDoubles(length);
			return Map2(pointsA, pointsB, map);
		}

		public static IEnumerable<T> UniformMap2Sequence<T>(Func<double, double, T> map)
		{
			SystemRandomSource rnd1 = SystemRandomSource.Default;
			for (int i = 0; i < 128; i++)
			{
				yield return map(rnd1.NextDouble(), rnd1.NextDouble());
			}
			System.Random rnd2 = new System.Random(RandomSeed.Robust());
			while (true)
			{
				yield return map(rnd2.NextDouble(), rnd2.NextDouble());
			}
		}

		public static double[] Standard(int length)
		{
			return Normal(length, 0.0, 1.0);
		}

		public static IEnumerable<double> StandardSequence()
		{
			return NormalSequence(0.0, 1.0);
		}

		public static double[] Normal(int length, double mean, double standardDeviation)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			MathNet.Numerics.Distributions.Normal.Samples(SystemRandomSource.Default, array, mean, standardDeviation);
			return array;
		}

		public static IEnumerable<double> NormalSequence(double mean, double standardDeviation)
		{
			return MathNet.Numerics.Distributions.Normal.Samples(SystemRandomSource.Default, mean, standardDeviation);
		}

		public static double[] Random(int length, IContinuousDistribution distribution)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			distribution.Samples(array);
			return array;
		}

		public static IEnumerable<double> Random(IContinuousDistribution distribution)
		{
			return distribution.Samples();
		}

		public static float[] RandomSingle(int length, IContinuousDistribution distribution)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			distribution.Samples(array);
			return Map(array, (double v) => (float)v);
		}

		public static IEnumerable<float> RandomSingle(IContinuousDistribution distribution)
		{
			return from v in distribution.Samples()
				select (float)v;
		}

		public static Complex[] RandomComplex(int length, IContinuousDistribution distribution)
		{
			return RandomMap2(length, distribution, (double r, double i) => new Complex(r, i));
		}

		public static IEnumerable<Complex> RandomComplex(IContinuousDistribution distribution)
		{
			return RandomMap2Sequence(distribution, (double r, double i) => new Complex(r, i));
		}

		public static Complex32[] RandomComplex32(int length, IContinuousDistribution distribution)
		{
			return RandomMap2(length, distribution, (double r, double i) => new Complex32((float)r, (float)i));
		}

		public static IEnumerable<Complex32> RandomComplex32(IContinuousDistribution distribution)
		{
			return RandomMap2Sequence(distribution, (double r, double i) => new Complex32((float)r, (float)i));
		}

		public static T[] RandomMap<T>(int length, IContinuousDistribution distribution, Func<double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			distribution.Samples(array);
			return Map(array, map);
		}

		public static IEnumerable<T> RandomMapSequence<T>(IContinuousDistribution distribution, Func<double, T> map)
		{
			return distribution.Samples().Select(map);
		}

		public static T[] RandomMap2<T>(int length, IContinuousDistribution distribution, Func<double, double, T> map)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			double[] array = new double[length];
			double[] array2 = new double[length];
			distribution.Samples(array);
			distribution.Samples(array2);
			return Map2(array, array2, map);
		}

		public static IEnumerable<T> RandomMap2Sequence<T>(IContinuousDistribution distribution, Func<double, double, T> map)
		{
			return distribution.Samples().Zip(distribution.Samples(), map);
		}
	}
}
