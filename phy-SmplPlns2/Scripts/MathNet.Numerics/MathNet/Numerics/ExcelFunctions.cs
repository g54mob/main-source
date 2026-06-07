using System;
using System.Runtime;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics
{
	public static class ExcelFunctions
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double NormSDist(double z)
		{
			return Normal.CDF(0.0, 1.0, z);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double NormSInv(double probability)
		{
			return Normal.InvCDF(0.0, 1.0, probability);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double NormDist(double x, double mean, double standardDev, bool cumulative)
		{
			if (!cumulative)
			{
				return Normal.PDF(mean, standardDev, x);
			}
			return Normal.CDF(mean, standardDev, x);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double NormInv(double probability, double mean, double standardDev)
		{
			return Normal.InvCDF(mean, standardDev, probability);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double TDist(double x, int degreesFreedom, int tails)
		{
			return tails switch
			{
				1 => 1.0 - StudentT.CDF(0.0, 1.0, degreesFreedom, x), 
				2 => 1.0 - StudentT.CDF(0.0, 1.0, degreesFreedom, x) + StudentT.CDF(0.0, 1.0, degreesFreedom, 0.0 - x), 
				_ => throw new ArgumentOutOfRangeException("tails"), 
			};
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double TInv(double probability, int degreesFreedom)
		{
			return 0.0 - StudentT.InvCDF(0.0, 1.0, degreesFreedom, probability / 2.0);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double FDist(double x, int degreesFreedom1, int degreesFreedom2)
		{
			return 1.0 - FisherSnedecor.CDF(degreesFreedom1, degreesFreedom2, x);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double FInv(double probability, int degreesFreedom1, int degreesFreedom2)
		{
			return FisherSnedecor.InvCDF(degreesFreedom1, degreesFreedom2, 1.0 - probability);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double BetaDist(double x, double alpha, double beta)
		{
			return Beta.CDF(alpha, beta, x);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double BetaInv(double probability, double alpha, double beta)
		{
			return Beta.InvCDF(alpha, beta, probability);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double GammaDist(double x, double alpha, double beta, bool cumulative)
		{
			if (!cumulative)
			{
				return Gamma.PDF(alpha, 1.0 / beta, x);
			}
			return Gamma.CDF(alpha, 1.0 / beta, x);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double GammaInv(double probability, double alpha, double beta)
		{
			return Gamma.InvCDF(alpha, 1.0 / beta, probability);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double Quartile(double[] array, int quant)
		{
			return quant switch
			{
				0 => ArrayStatistics.Minimum(array), 
				1 => array.QuantileCustom(0.25, QuantileDefinition.R7), 
				2 => array.QuantileCustom(0.5, QuantileDefinition.R7), 
				3 => array.QuantileCustom(0.75, QuantileDefinition.R7), 
				4 => ArrayStatistics.Maximum(array), 
				_ => throw new ArgumentOutOfRangeException("quant"), 
			};
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double Percentile(double[] array, double k)
		{
			return array.QuantileCustom(k, QuantileDefinition.R7);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double PercentRank(double[] array, double x)
		{
			return array.QuantileRank(x, RankDefinition.Min);
		}
	}
}
