using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class FullyConnLayer : LayerBase, IDotProductLayer
	{
		[DataMember]
		private int inputCount;

		[DataMember]
		public Volume Biases { get; private set; }

		[DataMember]
		public List<Volume> Filters { get; private set; }

		[DataMember]
		public double L1DecayMul { get; set; }

		[DataMember]
		public double L2DecayMul { get; set; }

		[DataMember]
		public int NeuronCount { get; private set; }

		[DataMember]
		public int GroupSize { get; set; }

		[DataMember]
		public Activation Activation { get; private set; }

		[DataMember]
		public double BiasPref { get; set; }

		public FullyConnLayer(int neuronCount, Activation activation = Activation.Undefined)
		{
			NeuronCount = neuronCount;
			Activation = activation;
			L1DecayMul = 0.0;
			L2DecayMul = 1.0;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			Volume volume = new Volume(1, 1, base.OutputDepth, 0.0);
			double[] weights = input.Weights;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				double num = 0.0;
				double[] weights2 = Filters[i].Weights;
				for (int j = 0; j < inputCount; j++)
				{
					num += weights[j] * weights2[j];
				}
				num += Biases.Weights[i];
				volume.Weights[i] = num;
			}
			base.OutputActivation = volume;
			return base.OutputActivation;
		}

		public override void Backward()
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			double[] weightGradients = inputActivation.WeightGradients;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				Volume volume = Filters[i];
				double num = base.OutputActivation.WeightGradients[i];
				for (int j = 0; j < inputCount; j++)
				{
					weightGradients[j] += volume.Weights[j] * num;
					volume.WeightGradients[j] += inputActivation.Weights[j] * num;
				}
				Biases.WeightGradients[i] += num;
			}
		}

		public override void Init(int inputWidth, int inputHeight, int inputDepth)
		{
			base.Init(inputWidth, inputHeight, inputDepth);
			base.OutputDepth = NeuronCount;
			inputCount = inputWidth * inputHeight * inputDepth;
			base.OutputWidth = 1;
			base.OutputHeight = 1;
			double biasPref = BiasPref;
			Filters = new List<Volume>();
			for (int i = 0; i < base.OutputDepth; i++)
			{
				Filters.Add(new Volume(1, 1, inputCount));
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
				binWriter.Write(L1DecayMul);
				binWriter.Write(L2DecayMul);
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
				NeuronCount = base.OutputDepth;
				inputCount = base.InputWidth * base.InputHeight * base.InputDepth;
				L1DecayMul = binaryReader.ReadDouble();
				L2DecayMul = binaryReader.ReadDouble();
				Filters = new List<Volume>(base.OutputDepth);
				for (int i = 0; i < base.OutputDepth; i++)
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
