using System;

namespace ConvNetSharp.Layers
{
	public class DuelingDQNLayer : LayerBase, ILastLayer
	{
		private FullyConnLayer stateValueLayer;

		private FullyConnLayer actionValueLayer;

		private readonly int actionsCount;

		public DuelingDQNLayer(int actionsCount)
		{
			this.actionsCount = actionsCount;
		}

		public double Backward(double y)
		{
			throw new NotImplementedException();
		}

		public double Backward(double[] y)
		{
			Volume inputActivation = base.InputActivation;
			double num = 0.0;
			stateValueLayer.OutputActivation.WeightGradients[0] = 0.0;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				double num2 = base.OutputActivation.Weights[i] - y[i];
				num += 0.5 * num2 * num2;
				stateValueLayer.OutputActivation.WeightGradients[0] += num2;
				actionValueLayer.OutputActivation.WeightGradients[i] = num2;
			}
			stateValueLayer.Backward();
			double[] array = (double[])stateValueLayer.InputActivation.WeightGradients.Clone();
			actionValueLayer.Backward();
			for (int j = 0; j < inputActivation.WeightGradients.Length; j++)
			{
				inputActivation.WeightGradients[j] = array[j] + actionValueLayer.InputActivation.WeightGradients[j];
			}
			return num;
		}

		public double Backward(ystr y)
		{
			throw new NotImplementedException();
		}

		public override void Backward()
		{
			throw new NotImplementedException();
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			Volume volume = stateValueLayer.Forward(input, isTraining);
			Volume volume2 = actionValueLayer.Forward(input, isTraining);
			for (int i = 0; i < actionsCount; i++)
			{
				base.OutputActivation.Weights[i] = volume.Weights[0] + volume2.Weights[i];
			}
			return base.OutputActivation;
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			stateValueLayer = new FullyConnLayer(1);
			stateValueLayer.Init(inputWidth, inputHeight, inputDepth);
			actionValueLayer = new FullyConnLayer(actionsCount);
			actionValueLayer.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = actionsCount;
			base.OutputWidth = 1;
			base.OutputHeight = 1;
		}
	}
}
