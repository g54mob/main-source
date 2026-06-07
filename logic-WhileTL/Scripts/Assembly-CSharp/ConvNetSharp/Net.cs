using System;
using System.Collections.Generic;
using ConvNetSharp.Layers;
using Newtonsoft.ExtensionMethods;
using UnityEngine;

namespace ConvNetSharp
{
	public class Net
	{
		private readonly List<LayerBase> layers = new List<LayerBase>();

		public List<LayerBase> Layers => layers;

		public void AddLayer(LayerBase layer)
		{
			int inputWidth = 0;
			int inputHeight = 0;
			int inputDepth = 0;
			if (layers.Count > 0)
			{
				inputWidth = layers[layers.Count - 1].OutputWidth;
				inputHeight = layers[layers.Count - 1].OutputHeight;
				inputDepth = layers[layers.Count - 1].OutputDepth;
			}
			if (layer is IClassificationLayer classificationLayer)
			{
				FullyConnLayer fullyConnLayer = new FullyConnLayer(classificationLayer.ClassCount);
				fullyConnLayer.Init(inputWidth, inputHeight, inputDepth);
				inputWidth = fullyConnLayer.OutputWidth;
				inputHeight = fullyConnLayer.OutputHeight;
				inputDepth = fullyConnLayer.OutputDepth;
				layers.Add(fullyConnLayer);
			}
			if (layer is RegressionLayer regressionLayer)
			{
				FullyConnLayer fullyConnLayer2 = new FullyConnLayer(regressionLayer.NeuronCount);
				fullyConnLayer2.Init(inputWidth, inputHeight, inputDepth);
				inputWidth = fullyConnLayer2.OutputWidth;
				inputHeight = fullyConnLayer2.OutputHeight;
				inputDepth = fullyConnLayer2.OutputDepth;
				layers.Add(fullyConnLayer2);
			}
			IDotProductLayer dotProductLayer = layer as IDotProductLayer;
			if (dotProductLayer != null && dotProductLayer.Activation == Activation.Relu)
			{
				dotProductLayer.BiasPref = 0.1;
			}
			if (layers.Count > 0)
			{
				layer.Init(inputWidth, inputHeight, inputDepth);
			}
			layers.Add(layer);
			if (dotProductLayer != null)
			{
				switch (dotProductLayer.Activation)
				{
				case Activation.Relu:
				{
					ReluLayer reluLayer = new ReluLayer();
					reluLayer.Init(layer.OutputWidth, layer.OutputHeight, layer.OutputDepth);
					layers.Add(reluLayer);
					break;
				}
				case Activation.Sigmoid:
				{
					SigmoidLayer sigmoidLayer = new SigmoidLayer();
					sigmoidLayer.Init(layer.OutputWidth, layer.OutputHeight, layer.OutputDepth);
					layers.Add(sigmoidLayer);
					break;
				}
				case Activation.Tanh:
				{
					TanhLayer tanhLayer = new TanhLayer();
					tanhLayer.Init(layer.OutputWidth, layer.OutputHeight, layer.OutputDepth);
					layers.Add(tanhLayer);
					break;
				}
				case Activation.Maxout:
				{
					MaxoutLayer maxoutLayer = new MaxoutLayer
					{
						GroupSize = dotProductLayer.GroupSize
					};
					maxoutLayer.Init(layer.OutputWidth, layer.OutputHeight, layer.OutputDepth);
					layers.Add(maxoutLayer);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
				case Activation.Undefined:
					break;
				}
			}
			LayerBase layerBase = layers[layers.Count - 1];
			if (!(layer is DropOutLayer) && layer.DropProb.HasValue)
			{
				DropOutLayer dropOutLayer = new DropOutLayer(layer.DropProb.Value);
				dropOutLayer.Init(layerBase.OutputWidth, layerBase.OutputHeight, layerBase.OutputDepth);
				layers.Add(dropOutLayer);
			}
		}

		public Volume Forward(Volume volume, bool isTraining = false)
		{
			Volume volume2 = layers[0].Forward(volume, isTraining);
			for (int i = 1; i < layers.Count; i++)
			{
				volume2 = layers[i].Forward(volume2, isTraining);
			}
			return volume2;
		}

		public double GetCostLoss(Volume volume, double y)
		{
			Forward(volume);
			if (layers[layers.Count - 1] is ILastLayer lastLayer)
			{
				return lastLayer.Backward(y);
			}
			throw new Exception("Last layer doesnt implement ILastLayer interface");
		}

		public double GetCostLoss(Volume volume, double[] y)
		{
			Forward(volume);
			if (layers[layers.Count - 1] is ILastLayer lastLayer)
			{
				return lastLayer.Backward(y);
			}
			throw new Exception("Last layer doesnt implement ILastLayer interface");
		}

		public double Backward(double y)
		{
			int count = layers.Count;
			if (layers[count - 1] is ILastLayer lastLayer)
			{
				double result = lastLayer.Backward(y);
				for (int num = count - 2; num >= 0; num--)
				{
					layers[num].Backward();
				}
				return result;
			}
			throw new Exception("Last layer doesnt implement ILastLayer interface");
		}

		public double Backward(double[] y)
		{
			int count = layers.Count;
			if (layers[count - 1] is ILastLayer lastLayer)
			{
				double result = lastLayer.Backward(y);
				for (int num = count - 2; num >= 0; num--)
				{
					layers[num].Backward();
				}
				return result;
			}
			throw new Exception("Last layer doesnt implement ILastLayer interface");
		}

		public double Backward(ystr y)
		{
			int count = layers.Count;
			if (layers[count - 1] is ILastLayer lastLayer)
			{
				double result = lastLayer.Backward(y);
				for (int num = count - 2; num >= 0; num--)
				{
					layers[num].Backward();
				}
				return result;
			}
			throw new Exception("Last layer doesnt implement ILastLayer interface");
		}

		public int GetPrediction()
		{
			double[] weights = ((layers[layers.Count - 1] as SoftmaxLayer) ?? throw new Exception("GetPrediction function assumes softmax as last layer of the net!")).OutputActivation.Weights;
			double num = weights[0];
			int result = 0;
			for (int i = 1; i < weights.Length; i++)
			{
				if (weights[i] > num)
				{
					num = weights[i];
					result = i;
				}
			}
			return result;
		}

		public List<ParametersAndGradients> GetParametersAndGradients()
		{
			List<ParametersAndGradients> list = new List<ParametersAndGradients>();
			foreach (LayerBase layer in layers)
			{
				List<ParametersAndGradients> parametersAndGradients = layer.GetParametersAndGradients();
				list.AddRange(parametersAndGradients);
			}
			return list;
		}

		public void Save(string name)
		{
			PlayerPrefs.SetString(name + ".WasSaved", "t");
			PlayerPrefs.SetInt(name + ".layers.Count", layers.Count);
			for (int i = 0; i < layers.Count; i++)
			{
				layers[i].Save(name + ".layers[" + i + "]");
			}
		}

		public bool Load(string name)
		{
			if (PlayerPrefs.HasKey(name + ".WasSaved") && PlayerPrefs.GetString(name + ".WasSaved") == "t")
			{
				int num = PlayerPrefs.GetInt(name + ".layers.Count");
				for (int i = 0; i < num; i++)
				{
					if (!layers[i].Load(name + ".layers[" + i + "]"))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void DeleteSave(string name)
		{
			PlayerPrefs.SetString(name + ".WasSaved", "f");
		}

		public void CopyWeights(Net otherNet)
		{
			for (int i = 0; i < Layers.Count; i++)
			{
				if (Layers[i] is FullyConnLayer fullyConnLayer)
				{
					FullyConnLayer fullyConnLayer2 = otherNet.Layers[i] as FullyConnLayer;
					fullyConnLayer2.Biases.Weights = (double[])fullyConnLayer.Biases.Weights.Clone();
					for (int j = 0; j < fullyConnLayer.Filters.Count; j++)
					{
						fullyConnLayer2.Filters[j].Weights = (double[])fullyConnLayer.Filters[j].Weights.Clone();
					}
				}
			}
		}

		public double[][] GetWeights()
		{
			double[][] res = new double[Layers.Count][];
			int id = 0;
			Layers.ForEach(delegate(LayerBase layer)
			{
				FullyConnLayer fcLayer = layer as FullyConnLayer;
				if (fcLayer != null)
				{
					res[id] = new double[fcLayer.OutputDepth * (fcLayer.InputWidth * fcLayer.InputHeight * fcLayer.InputDepth + 1)];
					int offset = 0;
					ArraySegment<double> segment = new ArraySegment<double>(res[id], offset, fcLayer.OutputDepth);
					segment.SetSegment(fcLayer.Biases.Weights);
					offset += fcLayer.OutputDepth;
					fcLayer.Filters.ForEach(delegate(Volume x)
					{
						int num = fcLayer.InputWidth * fcLayer.InputHeight * fcLayer.InputDepth;
						segment = new ArraySegment<double>(res[id], offset, num);
						segment.SetSegment(x.Weights);
						offset += num;
					});
				}
			});
			return res;
		}

		public void LoadWeights(double[][] weights)
		{
			int id = -1;
			Layers.ForEach(delegate(LayerBase layer)
			{
				FullyConnLayer fcLayer = layer as FullyConnLayer;
				if (fcLayer != null)
				{
					double[] curWeights = weights[++id];
					int offset = 0;
					ArraySegment<double> segment = new ArraySegment<double>(curWeights, offset, fcLayer.OutputDepth);
					fcLayer.Biases.Weights = segment.ToArray();
					offset += fcLayer.OutputDepth;
					fcLayer.Filters.ForEach(delegate(Volume x)
					{
						int num = fcLayer.InputWidth * fcLayer.InputHeight * fcLayer.InputDepth;
						segment = new ArraySegment<double>(curWeights, offset, num);
						x.Weights = segment.ToArray();
						offset += num;
					});
				}
			});
		}
	}
}
