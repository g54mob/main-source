using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathNet.Numerics.Statistics
{
	public static class Statistics
	{
		public static double Minimum(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.Minimum(data);
			}
			return ArrayStatistics.Minimum(data2);
		}

		public static float Minimum(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.Minimum(data);
			}
			return ArrayStatistics.Minimum(data2);
		}

		public static double Minimum(this IEnumerable<double?> data)
		{
			return StreamingStatistics.Minimum(from d in data
				where d.HasValue
				select d.Value);
		}

		public static double Maximum(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.Maximum(data);
			}
			return ArrayStatistics.Maximum(data2);
		}

		public static float Maximum(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.Maximum(data);
			}
			return ArrayStatistics.Maximum(data2);
		}

		public static double Maximum(this IEnumerable<double?> data)
		{
			return StreamingStatistics.Maximum(from d in data
				where d.HasValue
				select d.Value);
		}

		public static double MinimumAbsolute(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.MinimumAbsolute(data);
			}
			return ArrayStatistics.MinimumAbsolute(data2);
		}

		public static float MinimumAbsolute(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.MinimumAbsolute(data);
			}
			return ArrayStatistics.MinimumAbsolute(data2);
		}

		public static double MaximumAbsolute(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.MaximumAbsolute(data);
			}
			return ArrayStatistics.MaximumAbsolute(data2);
		}

		public static float MaximumAbsolute(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.MaximumAbsolute(data);
			}
			return ArrayStatistics.MaximumAbsolute(data2);
		}

		public static Complex MinimumMagnitudePhase(this IEnumerable<Complex> data)
		{
			if (!(data is Complex[] data2))
			{
				return StreamingStatistics.MinimumMagnitudePhase(data);
			}
			return ArrayStatistics.MinimumMagnitudePhase(data2);
		}

		public static Complex32 MinimumMagnitudePhase(this IEnumerable<Complex32> data)
		{
			if (!(data is Complex32[] data2))
			{
				return StreamingStatistics.MinimumMagnitudePhase(data);
			}
			return ArrayStatistics.MinimumMagnitudePhase(data2);
		}

		public static Complex MaximumMagnitudePhase(this IEnumerable<Complex> data)
		{
			if (!(data is Complex[] data2))
			{
				return StreamingStatistics.MaximumMagnitudePhase(data);
			}
			return ArrayStatistics.MaximumMagnitudePhase(data2);
		}

		public static Complex32 MaximumMagnitudePhase(this IEnumerable<Complex32> data)
		{
			if (!(data is Complex32[] data2))
			{
				return StreamingStatistics.MaximumMagnitudePhase(data);
			}
			return ArrayStatistics.MaximumMagnitudePhase(data2);
		}

		public static double Mean(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.Mean(data);
			}
			return ArrayStatistics.Mean(data2);
		}

		public static double Mean(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.Mean(data);
			}
			return ArrayStatistics.Mean(data2);
		}

		public static double Mean(this IEnumerable<double?> data)
		{
			return StreamingStatistics.Mean(from d in data
				where d.HasValue
				select d.Value);
		}

		public static double GeometricMean(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.GeometricMean(data);
			}
			return ArrayStatistics.GeometricMean(data2);
		}

		public static double GeometricMean(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.GeometricMean(data);
			}
			return ArrayStatistics.GeometricMean(data2);
		}

		public static double HarmonicMean(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.HarmonicMean(data);
			}
			return ArrayStatistics.HarmonicMean(data2);
		}

		public static double HarmonicMean(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.HarmonicMean(data);
			}
			return ArrayStatistics.HarmonicMean(data2);
		}

		public static double Variance(this IEnumerable<double> samples)
		{
			if (!(samples is double[] samples2))
			{
				return StreamingStatistics.Variance(samples);
			}
			return ArrayStatistics.Variance(samples2);
		}

		public static double Variance(this IEnumerable<float> samples)
		{
			if (!(samples is float[] samples2))
			{
				return StreamingStatistics.Variance(samples);
			}
			return ArrayStatistics.Variance(samples2);
		}

		public static double Variance(this IEnumerable<double?> samples)
		{
			return StreamingStatistics.Variance(from d in samples
				where d.HasValue
				select d.Value);
		}

		public static double PopulationVariance(this IEnumerable<double> population)
		{
			if (!(population is double[] population2))
			{
				return StreamingStatistics.PopulationVariance(population);
			}
			return ArrayStatistics.PopulationVariance(population2);
		}

		public static double PopulationVariance(this IEnumerable<float> population)
		{
			if (!(population is float[] population2))
			{
				return StreamingStatistics.PopulationVariance(population);
			}
			return ArrayStatistics.PopulationVariance(population2);
		}

		public static double PopulationVariance(this IEnumerable<double?> population)
		{
			return StreamingStatistics.PopulationVariance(from d in population
				where d.HasValue
				select d.Value);
		}

		public static double StandardDeviation(this IEnumerable<double> samples)
		{
			if (!(samples is double[] samples2))
			{
				return StreamingStatistics.StandardDeviation(samples);
			}
			return ArrayStatistics.StandardDeviation(samples2);
		}

		public static double StandardDeviation(this IEnumerable<float> samples)
		{
			if (!(samples is float[] samples2))
			{
				return StreamingStatistics.StandardDeviation(samples);
			}
			return ArrayStatistics.StandardDeviation(samples2);
		}

		public static double StandardDeviation(this IEnumerable<double?> samples)
		{
			return StreamingStatistics.StandardDeviation(from d in samples
				where d.HasValue
				select d.Value);
		}

		public static double PopulationStandardDeviation(this IEnumerable<double> population)
		{
			if (!(population is double[] population2))
			{
				return StreamingStatistics.PopulationStandardDeviation(population);
			}
			return ArrayStatistics.PopulationStandardDeviation(population2);
		}

		public static double PopulationStandardDeviation(this IEnumerable<float> population)
		{
			if (!(population is float[] population2))
			{
				return StreamingStatistics.PopulationStandardDeviation(population);
			}
			return ArrayStatistics.PopulationStandardDeviation(population2);
		}

		public static double PopulationStandardDeviation(this IEnumerable<double?> population)
		{
			return StreamingStatistics.PopulationStandardDeviation(from d in population
				where d.HasValue
				select d.Value);
		}

		public static double Skewness(this IEnumerable<double> samples)
		{
			return new RunningStatistics(samples).Skewness;
		}

		public static double Skewness(this IEnumerable<double?> samples)
		{
			return new RunningStatistics(from d in samples
				where d.HasValue
				select d.Value).Skewness;
		}

		public static double PopulationSkewness(this IEnumerable<double> population)
		{
			return new RunningStatistics(population).PopulationSkewness;
		}

		public static double PopulationSkewness(this IEnumerable<double?> population)
		{
			return new RunningStatistics(from d in population
				where d.HasValue
				select d.Value).PopulationSkewness;
		}

		public static double Kurtosis(this IEnumerable<double> samples)
		{
			return new RunningStatistics(samples).Kurtosis;
		}

		public static double Kurtosis(this IEnumerable<double?> samples)
		{
			return new RunningStatistics(from d in samples
				where d.HasValue
				select d.Value).Kurtosis;
		}

		public static double PopulationKurtosis(this IEnumerable<double> population)
		{
			return new RunningStatistics(population).PopulationKurtosis;
		}

		public static double PopulationKurtosis(this IEnumerable<double?> population)
		{
			return new RunningStatistics(from d in population
				where d.HasValue
				select d.Value).PopulationKurtosis;
		}

		public static (double Mean, double Variance) MeanVariance(this IEnumerable<double> samples)
		{
			if (!(samples is double[] samples2))
			{
				return StreamingStatistics.MeanVariance(samples);
			}
			return ArrayStatistics.MeanVariance(samples2);
		}

		public static (double Mean, double Variance) MeanVariance(this IEnumerable<float> samples)
		{
			if (!(samples is float[] samples2))
			{
				return StreamingStatistics.MeanVariance(samples);
			}
			return ArrayStatistics.MeanVariance(samples2);
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(this IEnumerable<double> samples)
		{
			if (!(samples is double[] samples2))
			{
				return StreamingStatistics.MeanStandardDeviation(samples);
			}
			return ArrayStatistics.MeanStandardDeviation(samples2);
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(this IEnumerable<float> samples)
		{
			if (!(samples is float[] samples2))
			{
				return StreamingStatistics.MeanStandardDeviation(samples);
			}
			return ArrayStatistics.MeanStandardDeviation(samples2);
		}

		public static (double Skewness, double Kurtosis) SkewnessKurtosis(this IEnumerable<double> samples)
		{
			RunningStatistics runningStatistics = new RunningStatistics(samples);
			return (Skewness: runningStatistics.Skewness, Kurtosis: runningStatistics.Kurtosis);
		}

		public static (double Skewness, double Kurtosis) PopulationSkewnessKurtosis(this IEnumerable<double> population)
		{
			RunningStatistics runningStatistics = new RunningStatistics(population);
			return (Skewness: runningStatistics.PopulationSkewness, Kurtosis: runningStatistics.PopulationKurtosis);
		}

		public static double Covariance(this IEnumerable<double> samples1, IEnumerable<double> samples2)
		{
			if (!(samples1 is double[] samples3) || !(samples2 is double[] samples4))
			{
				return StreamingStatistics.Covariance(samples1, samples2);
			}
			return ArrayStatistics.Covariance(samples3, samples4);
		}

		public static double Covariance(this IEnumerable<float> samples1, IEnumerable<float> samples2)
		{
			if (!(samples1 is float[] samples3) || !(samples2 is float[] samples4))
			{
				return StreamingStatistics.Covariance(samples1, samples2);
			}
			return ArrayStatistics.Covariance(samples3, samples4);
		}

		public static double Covariance(this IEnumerable<double?> samples1, IEnumerable<double?> samples2)
		{
			return StreamingStatistics.Covariance(from d in samples1
				where d.HasValue
				select d.Value, from d in samples2
				where d.HasValue
				select d.Value);
		}

		public static double PopulationCovariance(this IEnumerable<double> population1, IEnumerable<double> population2)
		{
			if (!(population1 is double[] population3) || !(population2 is double[] population4))
			{
				return StreamingStatistics.PopulationCovariance(population1, population2);
			}
			return ArrayStatistics.PopulationCovariance(population3, population4);
		}

		public static double PopulationCovariance(this IEnumerable<float> population1, IEnumerable<float> population2)
		{
			if (!(population1 is float[] population3) || !(population2 is float[] population4))
			{
				return StreamingStatistics.PopulationCovariance(population1, population2);
			}
			return ArrayStatistics.PopulationCovariance(population3, population4);
		}

		public static double PopulationCovariance(this IEnumerable<double?> population1, IEnumerable<double?> population2)
		{
			return StreamingStatistics.PopulationCovariance(from d in population1
				where d.HasValue
				select d.Value, from d in population2
				where d.HasValue
				select d.Value);
		}

		public static double RootMeanSquare(this IEnumerable<double> data)
		{
			if (!(data is double[] data2))
			{
				return StreamingStatistics.RootMeanSquare(data);
			}
			return ArrayStatistics.RootMeanSquare(data2);
		}

		public static double RootMeanSquare(this IEnumerable<float> data)
		{
			if (!(data is float[] data2))
			{
				return StreamingStatistics.RootMeanSquare(data);
			}
			return ArrayStatistics.RootMeanSquare(data2);
		}

		public static double RootMeanSquare(this IEnumerable<double?> data)
		{
			return StreamingStatistics.RootMeanSquare(from d in data
				where d.HasValue
				select d.Value);
		}

		public static double Median(this IEnumerable<double> data)
		{
			return ArrayStatistics.MedianInplace(data.ToArray());
		}

		public static float Median(this IEnumerable<float> data)
		{
			return ArrayStatistics.MedianInplace(data.ToArray());
		}

		public static double Median(this IEnumerable<double?> data)
		{
			return ArrayStatistics.MedianInplace((from d in data
				where d.HasValue
				select d.Value).ToArray());
		}

		public static double Quantile(this IEnumerable<double> data, double tau)
		{
			return ArrayStatistics.QuantileInplace(data.ToArray(), tau);
		}

		public static float Quantile(this IEnumerable<float> data, double tau)
		{
			return ArrayStatistics.QuantileInplace(data.ToArray(), tau);
		}

		public static double Quantile(this IEnumerable<double?> data, double tau)
		{
			return ArrayStatistics.QuantileInplace((from d in data
				where d.HasValue
				select d.Value).ToArray(), tau);
		}

		public static Func<double, double> QuantileFunc(this IEnumerable<double> data)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.Quantile(array, tau);
		}

		public static Func<float, float> QuantileFunc(this IEnumerable<float> data)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (float tau) => SortedArrayStatistics.Quantile(array, tau);
		}

		public static Func<double, double> QuantileFunc(this IEnumerable<double?> data)
		{
			double[] array = (from d in data
				where d.HasValue
				select d.Value).ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.Quantile(array, tau);
		}

		public static double QuantileCustom(this IEnumerable<double> data, double tau, QuantileDefinition definition)
		{
			return ArrayStatistics.QuantileCustomInplace(data.ToArray(), tau, definition);
		}

		public static float QuantileCustom(this IEnumerable<float> data, double tau, QuantileDefinition definition)
		{
			return ArrayStatistics.QuantileCustomInplace(data.ToArray(), tau, definition);
		}

		public static double QuantileCustom(this IEnumerable<double?> data, double tau, QuantileDefinition definition)
		{
			return ArrayStatistics.QuantileCustomInplace((from d in data
				where d.HasValue
				select d.Value).ToArray(), tau, definition);
		}

		public static Func<double, double> QuantileCustomFunc(this IEnumerable<double> data, QuantileDefinition definition)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.QuantileCustom(array, tau, definition);
		}

		public static Func<float, float> QuantileCustomFunc(this IEnumerable<float> data, QuantileDefinition definition)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (float tau) => SortedArrayStatistics.QuantileCustom(array, tau, definition);
		}

		public static Func<double, double> QuantileCustomFunc(this IEnumerable<double?> data, QuantileDefinition definition)
		{
			double[] array = (from d in data
				where d.HasValue
				select d.Value).ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.QuantileCustom(array, tau, definition);
		}

		public static double Percentile(this IEnumerable<double> data, int p)
		{
			return ArrayStatistics.PercentileInplace(data.ToArray(), p);
		}

		public static float Percentile(this IEnumerable<float> data, int p)
		{
			return ArrayStatistics.PercentileInplace(data.ToArray(), p);
		}

		public static double Percentile(this IEnumerable<double?> data, int p)
		{
			return ArrayStatistics.PercentileInplace((from d in data
				where d.HasValue
				select d.Value).ToArray(), p);
		}

		public static Func<int, double> PercentileFunc(this IEnumerable<double> data)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (int p) => SortedArrayStatistics.Percentile(array, p);
		}

		public static Func<int, float> PercentileFunc(this IEnumerable<float> data)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (int p) => SortedArrayStatistics.Percentile(array, p);
		}

		public static Func<int, double> PercentileFunc(this IEnumerable<double?> data)
		{
			double[] array = (from d in data
				where d.HasValue
				select d.Value).ToArray();
			Array.Sort(array);
			return (int p) => SortedArrayStatistics.Percentile(array, p);
		}

		public static double LowerQuartile(this IEnumerable<double> data)
		{
			return ArrayStatistics.LowerQuartileInplace(data.ToArray());
		}

		public static float LowerQuartile(this IEnumerable<float> data)
		{
			return ArrayStatistics.LowerQuartileInplace(data.ToArray());
		}

		public static double LowerQuartile(this IEnumerable<double?> data)
		{
			return ArrayStatistics.LowerQuartileInplace((from d in data
				where d.HasValue
				select d.Value).ToArray());
		}

		public static double UpperQuartile(this IEnumerable<double> data)
		{
			return ArrayStatistics.UpperQuartileInplace(data.ToArray());
		}

		public static float UpperQuartile(this IEnumerable<float> data)
		{
			return ArrayStatistics.UpperQuartileInplace(data.ToArray());
		}

		public static double UpperQuartile(this IEnumerable<double?> data)
		{
			return ArrayStatistics.UpperQuartileInplace((from d in data
				where d.HasValue
				select d.Value).ToArray());
		}

		public static double InterquartileRange(this IEnumerable<double> data)
		{
			return ArrayStatistics.InterquartileRangeInplace(data.ToArray());
		}

		public static float InterquartileRange(this IEnumerable<float> data)
		{
			return ArrayStatistics.InterquartileRangeInplace(data.ToArray());
		}

		public static double InterquartileRange(this IEnumerable<double?> data)
		{
			return ArrayStatistics.InterquartileRangeInplace((from d in data
				where d.HasValue
				select d.Value).ToArray());
		}

		public static double[] FiveNumberSummary(this IEnumerable<double> data)
		{
			return ArrayStatistics.FiveNumberSummaryInplace(data.ToArray());
		}

		public static float[] FiveNumberSummary(this IEnumerable<float> data)
		{
			return ArrayStatistics.FiveNumberSummaryInplace(data.ToArray());
		}

		public static double[] FiveNumberSummary(this IEnumerable<double?> data)
		{
			return ArrayStatistics.FiveNumberSummaryInplace((from d in data
				where d.HasValue
				select d.Value).ToArray());
		}

		public static double OrderStatistic(IEnumerable<double> data, int order)
		{
			return ArrayStatistics.OrderStatisticInplace(data.ToArray(), order);
		}

		public static float OrderStatistic(IEnumerable<float> data, int order)
		{
			return ArrayStatistics.OrderStatisticInplace(data.ToArray(), order);
		}

		public static Func<int, double> OrderStatisticFunc(IEnumerable<double> data)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (int order) => SortedArrayStatistics.OrderStatistic(array, order);
		}

		public static Func<int, float> OrderStatisticFunc(IEnumerable<float> data)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (int order) => SortedArrayStatistics.OrderStatistic(array, order);
		}

		public static double[] Ranks(this IEnumerable<double> data, RankDefinition definition = RankDefinition.Average)
		{
			return ArrayStatistics.RanksInplace(data.ToArray(), definition);
		}

		public static float[] Ranks(this IEnumerable<float> data, RankDefinition definition = RankDefinition.Average)
		{
			return ArrayStatistics.RanksInplace(data.ToArray(), definition);
		}

		public static double[] Ranks(this IEnumerable<double?> data, RankDefinition definition = RankDefinition.Average)
		{
			return (from d in data
				where d.HasValue
				select d.Value).Ranks(definition);
		}

		public static double QuantileRank(this IEnumerable<double> data, double x, RankDefinition definition = RankDefinition.Average)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return SortedArrayStatistics.QuantileRank(array, x, definition);
		}

		public static double QuantileRank(this IEnumerable<float> data, float x, RankDefinition definition = RankDefinition.Average)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return SortedArrayStatistics.QuantileRank(array, x, definition);
		}

		public static double QuantileRank(this IEnumerable<double?> data, double x, RankDefinition definition = RankDefinition.Average)
		{
			return (from d in data
				where d.HasValue
				select d.Value).QuantileRank(x, definition);
		}

		public static Func<double, double> QuantileRankFunc(this IEnumerable<double> data, RankDefinition definition = RankDefinition.Average)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (double x) => SortedArrayStatistics.QuantileRank(array, x, definition);
		}

		public static Func<float, double> QuantileRankFunc(this IEnumerable<float> data, RankDefinition definition = RankDefinition.Average)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (float x) => SortedArrayStatistics.QuantileRank(array, x, definition);
		}

		public static Func<double, double> QuantileRankFunc(this IEnumerable<double?> data, RankDefinition definition = RankDefinition.Average)
		{
			return (from d in data
				where d.HasValue
				select d.Value).QuantileRankFunc(definition);
		}

		public static double EmpiricalCDF(this IEnumerable<double> data, double x)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return SortedArrayStatistics.EmpiricalCDF(array, x);
		}

		public static double EmpiricalCDF(this IEnumerable<float> data, float x)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return SortedArrayStatistics.EmpiricalCDF(array, x);
		}

		public static double EmpiricalCDF(this IEnumerable<double?> data, double x)
		{
			return (from d in data
				where d.HasValue
				select d.Value).EmpiricalCDF(x);
		}

		public static Func<double, double> EmpiricalCDFFunc(this IEnumerable<double> data)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (double x) => SortedArrayStatistics.EmpiricalCDF(array, x);
		}

		public static Func<float, double> EmpiricalCDFFunc(this IEnumerable<float> data)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (float x) => SortedArrayStatistics.EmpiricalCDF(array, x);
		}

		public static Func<double, double> EmpiricalCDFFunc(this IEnumerable<double?> data)
		{
			return (from d in data
				where d.HasValue
				select d.Value).EmpiricalCDFFunc();
		}

		public static double EmpiricalInvCDF(this IEnumerable<double> data, double tau)
		{
			return ArrayStatistics.QuantileCustomInplace(data.ToArray(), tau, QuantileDefinition.R1);
		}

		public static float EmpiricalInvCDF(this IEnumerable<float> data, double tau)
		{
			return ArrayStatistics.QuantileCustomInplace(data.ToArray(), tau, QuantileDefinition.R1);
		}

		public static double EmpiricalInvCDF(this IEnumerable<double?> data, double tau)
		{
			return (from d in data
				where d.HasValue
				select d.Value).EmpiricalInvCDF(tau);
		}

		public static Func<double, double> EmpiricalInvCDFFunc(this IEnumerable<double> data)
		{
			double[] array = data.ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.QuantileCustom(array, tau, QuantileDefinition.R1);
		}

		public static Func<double, float> EmpiricalInvCDFFunc(this IEnumerable<float> data)
		{
			float[] array = data.ToArray();
			Array.Sort(array);
			return (double tau) => SortedArrayStatistics.QuantileCustom(array, tau, QuantileDefinition.R1);
		}

		public static Func<double, double> EmpiricalInvCDFFunc(this IEnumerable<double?> data)
		{
			return (from d in data
				where d.HasValue
				select d.Value).EmpiricalInvCDFFunc();
		}

		public static double Entropy(IEnumerable<double> data)
		{
			return StreamingStatistics.Entropy(data);
		}

		public static double Entropy(IEnumerable<double?> data)
		{
			return StreamingStatistics.Entropy(from d in data
				where d.HasValue
				select d.Value);
		}

		public static IEnumerable<double> MovingAverage(this IEnumerable<double> samples, int windowSize)
		{
			MovingStatistics movingStatistics = new MovingStatistics(windowSize);
			return samples.Select(delegate(double sample)
			{
				movingStatistics.Push(sample);
				return movingStatistics.Mean;
			});
		}
	}
}
