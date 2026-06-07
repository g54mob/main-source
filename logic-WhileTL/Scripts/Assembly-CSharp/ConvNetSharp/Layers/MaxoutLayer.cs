using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class MaxoutLayer : LayerBase
	{
		[DataMember]
		private int[] switches;

		[DataMember]
		public int GroupSize { get; set; }

		public MaxoutLayer()
		{
			GroupSize = 2;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			int outputDepth = base.OutputDepth;
			Volume volume = new Volume(base.OutputWidth, base.OutputHeight, base.OutputDepth, 0.0);
			if (base.OutputWidth == 1 && base.OutputHeight == 1)
			{
				for (int i = 0; i < outputDepth; i++)
				{
					int num = i * GroupSize;
					double num2 = input.Weights[num];
					int num3 = 0;
					for (int j = 1; j < GroupSize; j++)
					{
						double num4 = input.Weights[num + j];
						if (num4 > num2)
						{
							num2 = num4;
							num3 = j;
						}
					}
					volume.Weights[i] = num2;
					switches[i] = num + num3;
				}
			}
			else
			{
				int num5 = 0;
				for (int k = 0; k < input.Width; k++)
				{
					for (int l = 0; l < input.Height; l++)
					{
						for (int m = 0; m < outputDepth; m++)
						{
							int num6 = m * GroupSize;
							double num7 = input.Get(k, l, num6);
							int num8 = 0;
							for (int n = 1; n < GroupSize; n++)
							{
								double num9 = input.Get(k, l, num6 + n);
								if (num9 > num7)
								{
									num7 = num9;
									num8 = n;
								}
							}
							volume.Set(k, l, m, num7);
							switches[num5] = num6 + num8;
							num5++;
						}
					}
				}
			}
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			Volume inputActivation = base.InputActivation;
			Volume outputActivation = base.OutputActivation;
			int outputDepth = base.OutputDepth;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			if (base.OutputWidth == 1 && base.OutputHeight == 1)
			{
				for (int i = 0; i < outputDepth; i++)
				{
					double num = outputActivation.WeightGradients[i];
					inputActivation.WeightGradients[switches[i]] = num;
				}
				return;
			}
			int num2 = 0;
			for (int j = 0; j < outputActivation.Width; j++)
			{
				for (int k = 0; k < outputActivation.Height; k++)
				{
					for (int l = 0; l < outputDepth; l++)
					{
						double gradient = outputActivation.GetGradient(j, k, l);
						inputActivation.SetGradient(j, k, switches[num2], gradient);
						num2++;
					}
				}
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = (int)Math.Floor((double)inputDepth / (double)GroupSize);
			base.OutputWidth = inputWidth;
			base.OutputHeight = inputHeight;
			switches = new int[base.OutputWidth * base.OutputHeight * base.OutputDepth];
		}
	}
}
