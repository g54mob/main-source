using System;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public class RejectionSampler<T> : McmcSampler<T>
	{
		private readonly Density<T> _pdfP;

		private readonly Density<T> _pdfQ;

		private readonly GlobalProposalSampler<T> _proposal;

		public RejectionSampler(Density<T> pdfP, Density<T> pdfQ, GlobalProposalSampler<T> proposal)
		{
			_pdfP = pdfP;
			_pdfQ = pdfQ;
			_proposal = proposal;
		}

		public override T Sample()
		{
			T val;
			double num2;
			double num3;
			do
			{
				val = _proposal();
				double num = _pdfQ(val);
				num2 = _pdfP(val);
				num3 = base.RandomSource.NextDouble() * num;
				Samples++;
				if (num < num2)
				{
					throw new ArgumentException("The sampler's proposal distribution is not upper bounding the target density.");
				}
			}
			while (!(num3 < num2));
			Accepts++;
			return val;
		}
	}
}
