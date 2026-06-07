using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public class RegressionLayer : LayerBase, ILastLayer
	{
		[DataMember]
		public int NeuronCount { get; private set; }

		public RegressionLayer(int neuronCount)
		{
			NeuronCount = neuronCount;
		}

		public double Backward(double y)
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			double num = 0.0;
			double num2 = inputActivation.Weights[0] - y;
			inputActivation.WeightGradients[0] = num2;
			return num + 0.5 * num2 * num2;
		}

		public double Backward(double[] y)
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			double num = 0.0;
			for (int i = 0; i < base.OutputDepth; i++)
			{
				double num2 = inputActivation.Weights[i] - y[i];
				inputActivation.WeightGradients[i] = num2;
				num += 0.5 * num2 * num2;
			}
			return num;
		}

		public double Backward(ystr y)
		{
			Volume inputActivation = base.InputActivation;
			inputActivation.WeightGradients = new double[inputActivation.Weights.Length];
			double num = 0.0;
			int dim = y.dim;
			double val = y.val;
			double num2 = inputActivation.Weights[dim] - val;
			inputActivation.WeightGradients[dim] = num2;
			return num + 0.5 * num2 * num2;
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
			int outputDepth = inputWidth * inputHeight * inputDepth;
			base.OutputDepth = outputDepth;
			base.OutputWidth = 1;
			base.OutputHeight = 1;
		}

		public override void Save(string name)
		{
			PlayerPrefs.SetString(name + ".WasSaved", "t");
			PlayerPrefs.SetInt(name + ".NeuronCount", NeuronCount);
			PlayerPrefs.SetInt(name + ".OutputDepth", base.OutputDepth);
			PlayerPrefs.SetInt(name + ".OutputHeight", base.OutputHeight);
			PlayerPrefs.SetInt(name + ".OutputWidth", base.OutputWidth);
		}

		public override bool Load(string name)
		{
			if (PlayerPrefs.HasKey(name + ".WasSaved") && PlayerPrefs.GetString(name + ".WasSaved") == "t")
			{
				NeuronCount = PlayerPrefs.GetInt(name + ".NeuronCount");
				base.OutputDepth = PlayerPrefs.GetInt(name + ".OutputDepth");
				base.OutputHeight = PlayerPrefs.GetInt(name + ".OutputHeight");
				base.OutputWidth = PlayerPrefs.GetInt(name + ".OutputWidth");
				return true;
			}
			return false;
		}
	}
}
