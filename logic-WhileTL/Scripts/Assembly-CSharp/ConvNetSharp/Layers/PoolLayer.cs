using System;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class PoolLayer : LayerBase
	{
		[DataMember]
		private int[] switchx;

		[DataMember]
		private int[] switchy;

		[DataMember]
		public int Width { get; private set; }

		[DataMember]
		public int Height { get; private set; }

		[DataMember]
		public int Pad { get; set; }

		[DataMember]
		public int Stride { get; set; }

		public PoolLayer(int width, int height)
		{
			Width = width;
			Height = height;
			Stride = 2;
			Pad = 0;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = new Volume(base.OutputWidth, base.OutputHeight, base.OutputDepth, 0.0);
			for (int i = 0; i < base.OutputDepth; i++)
			{
				int num = i * base.OutputWidth * base.OutputHeight;
				int num2 = -Pad;
				for (int j = 0; j < base.OutputWidth; j++)
				{
					int num3 = -Pad;
					for (int k = 0; k < base.OutputHeight; k++)
					{
						double num4 = double.MinValue;
						int num5 = -1;
						int num6 = -1;
						for (int l = 0; l < Width; l++)
						{
							for (int m = 0; m < Height; m++)
							{
								int num7 = num3 + m;
								int num8 = num2 + l;
								if (num7 >= 0 && num7 < input.Height && num8 >= 0 && num8 < input.Width)
								{
									double num9 = input.Get(num8, num7, i);
									if (num9 > num4)
									{
										num4 = num9;
										num5 = num8;
										num6 = num7;
									}
								}
							}
						}
						switchx[num] = num5;
						switchy[num] = num6;
						num++;
						volume.Set(j, k, i, num4);
						num3 += Stride;
					}
					num2 += Stride;
				}
			}
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			for (int i = 0; i < base.OutputDepth; i++)
			{
				int num = i * base.OutputWidth * base.OutputHeight;
				for (int j = 0; j < base.OutputWidth; j++)
				{
					for (int k = 0; k < base.OutputHeight; k++)
					{
						double gradient = base.OutputActivation.GetGradient(j, k, i);
						inputActivation.AddGradient(switchx[num], switchy[num], i, gradient);
						num++;
					}
				}
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = base.InputDepth;
			base.OutputWidth = (int)Math.Floor((double)(base.InputWidth + Pad * 2 - Width) / (double)Stride + 1.0);
			base.OutputHeight = (int)Math.Floor((double)(base.InputHeight + Pad * 2 - Height) / (double)Stride + 1.0);
			switchx = new int[base.OutputWidth * base.OutputHeight * base.OutputDepth];
			switchy = new int[base.OutputWidth * base.OutputHeight * base.OutputDepth];
		}
	}
}
