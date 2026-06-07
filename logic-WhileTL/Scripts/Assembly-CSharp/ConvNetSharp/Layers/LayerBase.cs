using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[KnownType(typeof(ConvLayer))]
	[KnownType(typeof(DropOutLayer))]
	[KnownType(typeof(FullyConnLayer))]
	[KnownType(typeof(InputLayer))]
	[KnownType(typeof(MaxoutLayer))]
	[KnownType(typeof(PoolLayer))]
	[KnownType(typeof(RegressionLayer))]
	[KnownType(typeof(ReluLayer))]
	[KnownType(typeof(SigmoidLayer))]
	[KnownType(typeof(SoftmaxLayer))]
	[KnownType(typeof(SvmLayer))]
	[KnownType(typeof(TanhLayer))]
	[DataContract]
	public abstract class LayerBase
	{
		public Volume InputActivation { get; protected set; }

		public Volume OutputActivation { get; protected set; }

		[DataMember]
		public int OutputDepth { get; protected set; }

		[DataMember]
		public int OutputWidth { get; protected set; }

		[DataMember]
		public int OutputHeight { get; protected set; }

		[DataMember]
		public int InputDepth { get; protected set; }

		[DataMember]
		public int InputWidth { get; protected set; }

		[DataMember]
		public int InputHeight { get; protected set; }

		[DataMember]
		public double? DropProb { get; protected set; }

		public abstract Volume Forward(Volume input, bool isTraining = false);

		public abstract void Backward();

		public virtual void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			InputWidth = inputWidth;
			InputHeight = inputHeight;
			InputDepth = inputDepth;
		}

		public virtual List<ParametersAndGradients> GetParametersAndGradients()
		{
			return new List<ParametersAndGradients>();
		}

		public virtual void Save(BinaryWriter binWriter)
		{
			binWriter.Write(InputWidth);
			binWriter.Write(InputHeight);
			binWriter.Write(InputDepth);
			binWriter.Write(OutputWidth);
			binWriter.Write(OutputHeight);
			binWriter.Write(OutputDepth);
		}

		public virtual void Load(BinaryReader binReader)
		{
			InputWidth = binReader.ReadInt32();
			InputHeight = binReader.ReadInt32();
			InputDepth = binReader.ReadInt32();
			OutputWidth = binReader.ReadInt32();
			OutputHeight = binReader.ReadInt32();
			OutputDepth = binReader.ReadInt32();
		}

		public virtual void Save(string name)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter);
		}

		public virtual bool Load(string name)
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
