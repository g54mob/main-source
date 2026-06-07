using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class SvmLayer : LayerBase, ILastLayer, IClassificationLayer
	{
		[DataMember]
		public int ClassCount { get; set; }

		public double Backward(double yd)
		{
			int num = (int)yd;
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			double num2 = inputActivation.Weights[num];
			double num3 = 0.0;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				if (num != i)
				{
					double num4 = 0.0 - num2 + inputActivation.Weights[i] + 1.0;
					if (num4 > 0.0)
					{
						inputActivation.WeightGradients[i] += 1.0;
						inputActivation.WeightGradients[num] -= 1.0;
						num3 += num4;
					}
				}
			}
			return num3;
		}

		public double Backward(double[] y)
		{
			throw new NotImplementedException();
		}

		public double Backward(ystr y)
		{
			throw new NotImplementedException();
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			base.OutputActivation = input;
			return input;
		}

		public override void Backward()
		{
			throw new NotImplementedException();
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = inputWidth * inputHeight * inputDepth;
			base.OutputWidth = 1;
			base.OutputHeight = 1;
		}
	}
}
