using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class TanhLayer : LayerBase
	{
		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = input.CloneAndZero();
			int num = input.Weights.Length;
			for (int i = 0; i < num; i++)
			{
				volume.Weights[i] = Math.Tanh(input.Weights[i]);
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
				double num2 = outputActivation.Weights[i];
				inputActivation.WeightGradients[i] = (1.0 - num2 * num2) * outputActivation.WeightGradients[i];
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
