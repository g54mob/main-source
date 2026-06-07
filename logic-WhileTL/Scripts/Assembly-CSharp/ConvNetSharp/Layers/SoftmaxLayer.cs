using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class SoftmaxLayer : LayerBase, ILastLayer, IClassificationLayer
	{
		[DataMember]
		private double[] es;

		[DataMember]
		public int ClassCount { get; set; }

		public SoftmaxLayer(int classCount)
		{
			ClassCount = classCount;
		}

		public double Backward(double y)
		{
			int num = (int)y;
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			for (int i = 0; i < base.OutputDepth; i++)
			{
				double num2 = 0.0 - (((i == num) ? 1.0 : 0.0) - es[i]);
				inputActivation.WeightGradients[i] = num2;
			}
			return 0.0 - Math.Log(es[num]);
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
			Volume volume = new Volume(1, 1, base.OutputDepth, 0.0);
			double[] weights = input.Weights;
			double num = input.Weights[0];
			for (int i = 1; i < base.OutputDepth; i++)
			{
				if (weights[i] > num)
				{
					num = weights[i];
				}
			}
			double[] array = new double[base.OutputDepth];
			double num2 = 0.0;
			for (int j = 0; j < base.OutputDepth; j++)
			{
				double num3 = Math.Exp(weights[j] - num);
				num2 += num3;
				array[j] = num3;
			}
			for (int k = 0; k < base.OutputDepth; k++)
			{
				array[k] /= num2;
				volume.Weights[k] = array[k];
			}
			es = array;
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			throw new NotImplementedException();
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			int outputDepth = inputWidth * inputHeight * inputDepth;
			base.OutputDepth = outputDepth;
			base.OutputWidth = 1;
			base.OutputHeight = 1;
		}
	}
}
