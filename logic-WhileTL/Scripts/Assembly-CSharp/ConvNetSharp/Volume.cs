using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace ConvNetSharp
{
	[DataContract]
	public class Volume
	{
		[DataMember]
		public int Depth;

		[DataMember]
		public int Height;

		[DataMember]
		public double[] WeightGradients;

		[DataMember]
		public double[] Weights;

		[DataMember]
		public int Width;

		public Volume(int width, int height, int depth)
		{
			Width = width;
			Height = height;
			Depth = depth;
			int num = width * height * depth;
			Weights = new double[num];
			WeightGradients = new double[num];
			double std = Math.Sqrt(1.0 / (double)(width * height * depth));
			for (int i = 0; i < num; i++)
			{
				Weights[i] = RandomUtilities.Randn(0.0, std);
			}
		}

		public Volume(int width, int height, int depth, double c)
		{
			Width = width;
			Height = height;
			Depth = depth;
			int num = width * height * depth;
			Weights = new double[num];
			WeightGradients = new double[num];
			if (c != 0.0)
			{
				for (int i = 0; i < num; i++)
				{
					Weights[i] = c;
				}
			}
		}

		public Volume(IList<double> weights)
		{
			Width = 1;
			Height = 1;
			Depth = weights.Count;
			Weights = new double[Depth];
			WeightGradients = new double[Depth];
			for (int i = 0; i < Depth; i++)
			{
				Weights[i] = weights[i];
			}
		}

		public double Get(int x, int y, int d)
		{
			int num = (Width * y + x) * Depth + d;
			return Weights[num];
		}

		public void Set(int x, int y, int d, double v)
		{
			int num = (Width * y + x) * Depth + d;
			Weights[num] = v;
		}

		public void Add(int x, int y, int d, double v)
		{
			int num = (Width * y + x) * Depth + d;
			Weights[num] += v;
		}

		public double GetGradient(int x, int y, int d)
		{
			int num = (Width * y + x) * Depth + d;
			return WeightGradients[num];
		}

		public void SetGradient(int x, int y, int d, double v)
		{
			int num = (Width * y + x) * Depth + d;
			WeightGradients[num] = v;
		}

		public void AddGradient(int x, int y, int d, double v)
		{
			int num = (Width * y + x) * Depth + d;
			WeightGradients[num] += v;
		}

		public Volume CloneAndZero()
		{
			return new Volume(Width, Height, Depth, 0.0);
		}

		public Volume Clone()
		{
			Volume volume = new Volume(Width, Height, Depth, 0.0);
			int num = Weights.Length;
			for (int i = 0; i < num; i++)
			{
				volume.Weights[i] = Weights[i];
			}
			return volume;
		}

		public void AddFrom(Volume volume)
		{
			for (int i = 0; i < Weights.Length; i++)
			{
				Weights[i] += volume.Weights[i];
			}
		}

		public void AddGradientFrom(Volume volume)
		{
			for (int i = 0; i < WeightGradients.Length; i++)
			{
				WeightGradients[i] += volume.WeightGradients[i];
			}
		}

		public void AddFromScaled(Volume volume, double a)
		{
			for (int i = 0; i < Weights.Length; i++)
			{
				Weights[i] += a * volume.Weights[i];
			}
		}

		public void SetConst(double c)
		{
			for (int i = 0; i < Weights.Length; i++)
			{
				Weights[i] += c;
			}
		}

		protected static byte[] DoubleToByte(double[] data)
		{
			return new byte[5];
		}

		protected static double[] ByteToDouble(byte[] data)
		{
			return new double[5];
		}

		public void Save(BinaryWriter binWriter)
		{
			binWriter.Write(Width);
			binWriter.Write(Height);
			binWriter.Write(Depth);
			byte[] buffer = DoubleToByte(Weights);
			binWriter.Write(buffer);
			buffer = DoubleToByte(WeightGradients);
			binWriter.Write(buffer);
		}

		public void Save(string name)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter);
		}

		public void Load(BinaryReader binReader)
		{
			Width = binReader.ReadInt32();
			Height = binReader.ReadInt32();
			Depth = binReader.ReadInt32();
			int count = Width * Height * Depth * 8;
			Weights = ByteToDouble(binReader.ReadBytes(count));
			WeightGradients = ByteToDouble(binReader.ReadBytes(count));
		}

		public bool Load(string name)
		{
			if (!File.Exists(name))
			{
				return false;
			}
			using (BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open)))
			{
				Load(binReader);
			}
			return true;
		}
	}
}
