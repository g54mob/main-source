using System;
using System.Collections.Generic;
using ConvNetSharp.Layers;

namespace ConvNetSharp.Training
{
	public class AdadeltaTrainer : TrainerBase
	{
		private readonly List<double[]> gsum = new List<double[]>();

		private readonly List<double[]> xsum = new List<double[]>();

		public double L1Decay { get; set; }

		public double L2Decay { get; set; }

		public double L2DecayLoss { get; private set; }

		public double L1DecayLoss { get; private set; }

		public double Ro { get; set; }

		public double Eps { get; set; }

		public AdadeltaTrainer(Net net)
			: base(net)
		{
			Ro = 0.95;
			Eps = 1E-06;
		}

		protected override void TrainImplem()
		{
			K++;
			if (K % base.BatchSize != 0)
			{
				return;
			}
			List<ParametersAndGradients> parametersAndGradients = Net.GetParametersAndGradients();
			if (gsum.Count == 0)
			{
				foreach (ParametersAndGradients item in parametersAndGradients)
				{
					gsum.Add(new double[item.Parameters.Length]);
					xsum.Add(new double[item.Parameters.Length]);
				}
			}
			for (int i = 0; i < parametersAndGradients.Count; i++)
			{
				ParametersAndGradients parametersAndGradients2 = parametersAndGradients[i];
				double[] parameters = parametersAndGradients2.Parameters;
				double[] gradients = parametersAndGradients2.Gradients;
				double num = parametersAndGradients2.L2DecayMul ?? 1.0;
				double num2 = parametersAndGradients2.L1DecayMul ?? 1.0;
				double num3 = L2Decay * num;
				double num4 = L1Decay * num2;
				int num5 = parameters.Length;
				for (int j = 0; j < num5; j++)
				{
					L2DecayLoss += num3 * parameters[j] * parameters[j] / 2.0;
					L1DecayLoss += num4 * Math.Abs(parameters[j]);
					double num6 = num4 * (double)((parameters[j] > 0.0) ? 1 : (-1));
					double num7 = (num3 * parameters[j] + num6 + gradients[j]) / (double)base.BatchSize;
					double[] array = null;
					if (gsum.Count > 0)
					{
						array = gsum[i];
					}
					double[] array2 = null;
					if (xsum.Count > 0)
					{
						array2 = xsum[i];
					}
					array[j] = Ro * array[j] + (1.0 - Ro) * num7 * num7;
					double num8 = (0.0 - Math.Sqrt((array2[j] + Eps) / (array[j] + Eps))) * num7;
					array2[j] = Ro * array2[j] + (1.0 - Ro) * num8 * num8;
					parameters[j] += num8;
					gradients[j] = 0.0;
				}
			}
		}

		protected override double Backward(double y)
		{
			L2DecayLoss = 0.0;
			L1DecayLoss = 0.0;
			return base.Backward(y);
		}

		protected override double Backward(double[] y)
		{
			L2DecayLoss = 0.0;
			L1DecayLoss = 0.0;
			return base.Backward(y);
		}
	}
}
