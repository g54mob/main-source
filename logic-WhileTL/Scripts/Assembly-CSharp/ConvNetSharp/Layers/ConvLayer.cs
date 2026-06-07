using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class ConvLayer : LayerBase, IDotProductLayer
	{
		[DataMember]
		public int Width { get; private set; }

		[DataMember]
		public int Height { get; private set; }

		[DataMember]
		public Volume Biases { get; private set; }

		[DataMember]
		public List<Volume> Filters { get; private set; }

		[DataMember]
		public int FilterCount { get; private set; }

		[DataMember]
		public double L1DecayMul { get; set; }

		[DataMember]
		public double L2DecayMul { get; set; }

		[DataMember]
		public int Stride { get; set; }

		[DataMember]
		public int Pad { get; set; }

		[DataMember]
		public double BiasPref { get; set; }

		[DataMember]
		public Activation Activation { get; set; }

		[DataMember]
		public int GroupSize { get; private set; }

		public ConvLayer(int width, int height, int filterCount)
		{
			GroupSize = 2;
			L1DecayMul = 0.0;
			L2DecayMul = 1.0;
			Stride = 1;
			Pad = 0;
			FilterCount = filterCount;
			Width = width;
			Height = height;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = new Volume(base.OutputWidth, base.OutputHeight, base.OutputDepth, 0.0);
			int width = input.Width;
			int height = input.Height;
			int stride = Stride;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				Volume volume2 = Filters[i];
				int num = -Pad;
				for (int j = 0; j < base.OutputHeight; j++)
				{
					int num2 = -Pad;
					for (int k = 0; k < base.OutputWidth; k++)
					{
						double num3 = 0.0;
						for (int l = 0; l < volume2.Height; l++)
						{
							int num4 = num + l;
							for (int m = 0; m < volume2.Width; m++)
							{
								int num5 = num2 + m;
								if (num4 >= 0 && num4 < height && num5 >= 0 && num5 < width)
								{
									for (int n = 0; n < volume2.Depth; n++)
									{
										num3 += volume2.Weights[(volume2.Width * l + m) * volume2.Depth + n] * input.Weights[(width * num4 + num5) * input.Depth + n];
									}
								}
							}
						}
						num3 += Biases.Weights[i];
						volume.Set(k, j, i, num3);
						num2 += stride;
					}
					num += stride;
				}
			}
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			int width = inputActivation.Width;
			int height = inputActivation.Height;
			int stride = Stride;
			Volume volume = inputActivation;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				Volume volume2 = Filters[i];
				int num = -Pad;
				for (int j = 0; j < base.OutputHeight; j++)
				{
					int num2 = -Pad;
					for (int k = 0; k < base.OutputWidth; k++)
					{
						double gradient = base.OutputActivation.GetGradient(k, j, i);
						for (int l = 0; l < volume2.Height; l++)
						{
							int num3 = num + l;
							for (int m = 0; m < volume2.Width; m++)
							{
								int num4 = num2 + m;
								if (num3 >= 0 && num3 < height && num4 >= 0 && num4 < width)
								{
									for (int n = 0; n < volume2.Depth; n++)
									{
										volume2.AddGradient(m, l, n, inputActivation.Get(num4, num3, n) * gradient);
										volume.AddGradient(num4, num3, n, volume2.Get(m, l, n) * gradient);
									}
								}
							}
						}
						Biases.WeightGradients[i] += gradient;
						num2 += stride;
					}
					num += stride;
				}
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = FilterCount;
			base.OutputWidth = (int)Math.Floor((double)(base.InputWidth + Pad * 2 - Width) / (double)Stride + 1.0);
			base.OutputHeight = (int)Math.Floor((double)(base.InputHeight + Pad * 2 - Height) / (double)Stride + 1.0);
			double biasPref = BiasPref;
			Filters = new List<Volume>();
			for (int i = 0; i < base.OutputDepth; i++)
			{
				Filters.Add(new Volume(Width, Height, base.InputDepth));
			}
			Biases = new Volume(1, 1, base.OutputDepth, biasPref);
		}

		public override List<ParametersAndGradients> GetParametersAndGradients()
		{
			List<ParametersAndGradients> list = new List<ParametersAndGradients>();
			for (int i = 0; i < base.OutputDepth; i++)
			{
				list.Add(new ParametersAndGradients
				{
					Parameters = Filters[i].Weights,
					Gradients = Filters[i].WeightGradients,
					L2DecayMul = L2DecayMul,
					L1DecayMul = L1DecayMul
				});
			}
			list.Add(new ParametersAndGradients
			{
				Parameters = Biases.Weights,
				Gradients = Biases.WeightGradients,
				L1DecayMul = 0.0,
				L2DecayMul = 0.0
			});
			return list;
		}

		public override void Save(string name)
		{
			BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			try
			{
				base.Save(binWriter);
				binWriter.Write(GroupSize);
				binWriter.Write(L1DecayMul);
				binWriter.Write(L2DecayMul);
				binWriter.Write(Stride);
				binWriter.Write(Pad);
				binWriter.Write(Width);
				binWriter.Write(Height);
				Filters.ForEach(delegate(Volume x)
				{
					x.Save(binWriter);
				});
				Biases.Save(binWriter);
			}
			finally
			{
				if (binWriter != null)
				{
					((IDisposable)binWriter).Dispose();
				}
			}
		}

		public override bool Load(string name)
		{
			if (!File.Exists(name))
			{
				return false;
			}
			using (BinaryReader binaryReader = new BinaryReader(File.Open(name, FileMode.Open)))
			{
				base.Load(binaryReader);
				GroupSize = binaryReader.ReadInt32();
				L1DecayMul = binaryReader.ReadDouble();
				L2DecayMul = binaryReader.ReadDouble();
				Stride = binaryReader.ReadInt32();
				Pad = binaryReader.ReadInt32();
				FilterCount = base.OutputDepth;
				Width = binaryReader.ReadInt32();
				Height = binaryReader.ReadInt32();
				Filters = new List<Volume>(FilterCount);
				for (int i = 0; i < FilterCount; i++)
				{
					Filters.Add(new Volume(1, 1, 1));
					Filters[i].Load(binaryReader);
				}
				Biases.Load(binaryReader);
			}
			return true;
		}
	}
}
