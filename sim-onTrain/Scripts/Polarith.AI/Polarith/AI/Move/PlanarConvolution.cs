using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarConvolution : MoveBehaviour
	{
		private class GaussianKernel
		{
			public delegate double Function(double x);

			private double twoSigmaQuadrat;

			private int i;

			private int j;

			public List<float> GetKernel(int kernelSize, float sigma)
			{
				if (!CheckSettings(sigma, kernelSize))
				{
					return new List<float>(new float[0]);
				}
				List<float> list = new List<float>(new float[kernelSize]);
				int num = kernelSize / 2 + 1;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				List<double> list2 = new List<double>();
				if (list.Count != kernelSize)
				{
					Collections.ResizeList(list, kernelSize);
				}
				twoSigmaQuadrat = 2.0 * (double)sigma * (double)sigma;
				Function f = Evaluate;
				for (i = 0; i < num; i++)
				{
					num2 = 0.0 - (double)kernelSize / 2.0;
					num2 += (double)i;
					num3 = num2 + 1.0;
					list2.Add(IntegrateBySimpsonsRule(num2, num3, 1000, f));
					num4 += list2[i];
				}
				for (i = num; i < kernelSize; i++)
				{
					list2.Add(list2[kernelSize - 1 - i]);
					num4 += list2[i];
				}
				for (i = 0; i < list2.Count; i++)
				{
					list[i] = (float)(Math.Floor(list2[i] / num4 * Math.Pow(10.0, 5.0)) / Math.Pow(10.0, 5.0));
				}
				return list;
			}

			private double IntegrateBySimpsonsRule(double from, double to, int numberOfSubAreas, Function f)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = Math.Abs((from - to) / (double)numberOfSubAreas);
				double num5 = (to - from) / (double)numberOfSubAreas;
				for (j = 0; j <= numberOfSubAreas; j++)
				{
					num2 = from + (double)j * num4;
					num3 = f(num2);
					if (j == 0 || j == numberOfSubAreas)
					{
						num += num5 * num3;
					}
					else if (j % 2 == 0)
					{
						num += num5 * 2.0 * num3;
					}
					else if (j % 2 == 1)
					{
						num += num5 * 4.0 * num3;
					}
				}
				return num;
			}

			private double Evaluate(double x)
			{
				return Math.Exp((0.0 - x) * x / twoSigmaQuadrat) / Math.Sqrt(twoSigmaQuadrat * Math.PI);
			}

			private bool CheckSettings(float sigma, int kernelSize)
			{
				if (sigma < 1E-06f || kernelSize < 3 || kernelSize % 2 == 0)
				{
					return false;
				}
				return true;
			}
		}

		[Tooltip("The entries of this list determines the 'Objectives' in 'Context' which are modified.")]
		[SerializeField]
		[TargetObjective(false)]
		public List<int> TargetObjectives = new List<int>();

		[SerializeField]
		private List<float> kernel = new List<float>();

		private readonly List<float> buffer = new List<float>();

		private readonly GaussianKernel gaussian = new GaussianKernel();

		private IProblem<float> problem;

		private PlanarSensor sensor;

		private float weightedValue;

		private int tmpNeighbourId;

		private int i;

		private int j;

		private int k;

		public List<float> Kernel
		{
			get
			{
				return new List<float>(kernel);
			}
			set
			{
				if (value.Count >= 3 && value.Count % 2 != 0)
				{
					kernel = value;
				}
			}
		}

		public override void Behave()
		{
			problem = Context.Problem;
			sensor = (PlanarSensor)Context.Sensor;
			if (sensor == null || kernel.Count < 3 || kernel.Count % 2 == 0)
			{
				return;
			}
			if (buffer.Count != problem.ValueCount)
			{
				Collections.ResizeList(buffer, problem.ValueCount);
			}
			for (i = 0; i < TargetObjectives.Count; i++)
			{
				if (TargetObjectives[i] >= 0 && TargetObjectives[i] < problem.ObjectiveCount)
				{
					for (j = 0; j < sensor.ReceptorCount; j++)
					{
						weightedValue = 0f;
						for (k = -kernel.Count / 2; k <= kernel.Count / 2; k++)
						{
							tmpNeighbourId = sensor.GetNeighbourID(j, k);
							if (tmpNeighbourId == -1)
							{
								tmpNeighbourId = j;
							}
							weightedValue += kernel[k + kernel.Count / 2] * problem.GetObjective(TargetObjectives[i])[tmpNeighbourId];
						}
						buffer[j] = weightedValue;
					}
					for (j = 0; j < buffer.Count; j++)
					{
						problem.SetValue(TargetObjectives[i], j, buffer[j]);
					}
				}
			}
		}

		public void ComputeGaussianKernel(int kernelSize, float sigma)
		{
			kernel = gaussian.GetKernel(kernelSize, sigma);
		}
	}
}
