using System;
using System.Diagnostics;
using ConvNetSharp.Layers;

namespace ConvNetSharp.Training
{
	public abstract class TrainerBase
	{
		protected readonly Net Net;

		protected int K;

		public TimeSpan BackwardTime { get; private set; }

		public double CostLoss { get; private set; }

		public TimeSpan ForwardTime { get; private set; }

		public int BatchSize { get; set; }

		public virtual double Loss => CostLoss;

		protected TrainerBase(Net net)
		{
			Net = net;
			BatchSize = 1;
		}

		public double Train(Volume x, double y)
		{
			Forward(x);
			double result = Backward(y);
			TrainImplem();
			return result;
		}

		public double Train(Volume x, double[] y)
		{
			Forward(x);
			double result = Backward(y);
			TrainImplem();
			return result;
		}

		public double Train(Volume x, ystr y)
		{
			Forward(x);
			double result = Backward(y);
			TrainImplem();
			return result;
		}

		protected abstract void TrainImplem();

		protected virtual double Backward(double y)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			CostLoss = Net.Backward(y);
			BackwardTime = stopwatch.Elapsed;
			return CostLoss;
		}

		protected virtual double Backward(double[] y)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			CostLoss = Net.Backward(y);
			BackwardTime = stopwatch.Elapsed;
			return CostLoss;
		}

		protected virtual double Backward(ystr y)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			CostLoss = Net.Backward(y);
			BackwardTime = stopwatch.Elapsed;
			return CostLoss;
		}

		private void Forward(Volume x)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			Net.Forward(x, isTraining: true);
			ForwardTime = stopwatch.Elapsed;
		}
	}
}
