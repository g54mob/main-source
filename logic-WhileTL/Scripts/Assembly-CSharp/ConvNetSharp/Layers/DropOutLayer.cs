using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class DropOutLayer : LayerBase
	{
		private static readonly Random Random = new Random(RandomUtilities.Seed);

		[DataMember]
		private bool[] dropped;

		public DropOutLayer(double dropProb = 0.5)
		{
			base.DropProb = dropProb;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = input.Clone();
			int num = input.Weights.Length;
			if (isTraining)
			{
				for (int i = 0; i < num; i++)
				{
					if (Random.NextDouble() < base.DropProb.Value)
					{
						volume.Weights[i] = 0.0;
						dropped[i] = true;
					}
					else
					{
						dropped[i] = false;
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					volume.Weights[j] *= base.DropProb.Value;
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
				if (!dropped[i])
				{
					inputActivation.WeightGradients[i] = outputActivation.WeightGradients[i];
				}
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputWidth = inputWidth;
			base.OutputHeight = inputHeight;
			base.OutputDepth = inputDepth;
			dropped = new bool[base.OutputWidth * base.OutputHeight * base.OutputDepth];
		}
	}
}
