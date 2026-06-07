using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class ReluLayer : LayerBase
	{
		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = input.Clone();
			int num = input.Weights.Length;
			double[] weights = volume.Weights;
			for (int i = 0; i < num; i++)
			{
				if (weights[i] < 0.0)
				{
					weights[i] = 0.0;
				}
			}
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			Volume inputActivation = base.InputActivation;
			Volume outputActivation = base.OutputActivation;
			int num = inputActivation.Weights.Length;
			inputActivation.WeightGradients = new double[num];
			for (int i = 0; i < num; i++)
			{
				if (outputActivation.Weights[i] <= 0.0)
				{
					inputActivation.WeightGradients[i] = 0.0;
				}
				else
				{
					inputActivation.WeightGradients[i] = outputActivation.WeightGradients[i];
				}
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = inputDepth;
			base.OutputWidth = inputWidth;
			base.OutputHeight = inputHeight;
		}
	}
}
