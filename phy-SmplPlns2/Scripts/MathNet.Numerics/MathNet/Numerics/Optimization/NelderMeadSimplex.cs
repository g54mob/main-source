using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathNet.Numerics.Optimization
{
	public sealed class NelderMeadSimplex : IUnconstrainedMinimizer
	{
		private sealed class SimplexConstant
		{
			public double Value { get; }

			public double InitialPerturbation { get; }

			private SimplexConstant(double value, double initialPerturbation)
			{
				Value = value;
				InitialPerturbation = initialPerturbation;
			}

			public static SimplexConstant[] CreateSimplexConstantsFromVectors(Vector<double> initialGuess, Vector<double> initialPertubation)
			{
				SimplexConstant[] array = new SimplexConstant[initialGuess.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new SimplexConstant(initialGuess[i], initialPertubation[i]);
				}
				return array;
			}
		}

		private sealed class ErrorProfile
		{
			public int HighestIndex { get; set; }

			public int NextHighestIndex { get; set; }

			public int LowestIndex { get; set; }
		}

		private static readonly double JITTER = 1E-10;

		public double ConvergenceTolerance { get; set; }

		public int MaximumIterations { get; set; }

		public NelderMeadSimplex(double convergenceTolerance, int maximumIterations)
		{
			ConvergenceTolerance = convergenceTolerance;
			MaximumIterations = maximumIterations;
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objectiveFunction, Vector<double> initialGuess)
		{
			return Minimum(objectiveFunction, initialGuess, ConvergenceTolerance, MaximumIterations);
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objectiveFunction, Vector<double> initialGuess, Vector<double> initalPertubation)
		{
			return Minimum(objectiveFunction, initialGuess, initalPertubation, ConvergenceTolerance, MaximumIterations);
		}

		public static MinimizationResult Minimum(IObjectiveFunction objectiveFunction, Vector<double> initialGuess, double convergenceTolerance = 1E-08, int maximumIterations = 1000)
		{
			DenseVector denseVector = new DenseVector(initialGuess.Count);
			for (int i = 0; i < initialGuess.Count; i++)
			{
				denseVector[i] = ((initialGuess[i] == 0.0) ? 0.00025 : (initialGuess[i] * 0.05));
			}
			return Minimum(objectiveFunction, initialGuess, denseVector, convergenceTolerance, maximumIterations);
		}

		public static MinimizationResult Minimum(IObjectiveFunction objectiveFunction, Vector<double> initialGuess, Vector<double> initalPertubation, double convergenceTolerance = 1E-08, int maximumIterations = 1000)
		{
			if (objectiveFunction == null)
			{
				throw new ArgumentNullException("objectiveFunction", "ObjectiveFunction must be set to a valid ObjectiveFunctionDelegate");
			}
			if (initialGuess == null)
			{
				throw new ArgumentNullException("initialGuess", "initialGuess must be initialized");
			}
			if (initalPertubation == null)
			{
				throw new ArgumentNullException("initalPertubation", "initalPertubation must be initialized, if unknown use overloaded version of FindMinimum()");
			}
			SimplexConstant[] array = SimplexConstant.CreateSimplexConstantsFromVectors(initialGuess, initalPertubation);
			int num = array.Length + 1;
			Vector<double>[] array2 = InitializeVertices(array);
			int num2 = 0;
			double[] array3 = InitializeErrorValues(array2, objectiveFunction);
			int num3 = 0;
			do
			{
				ErrorProfile errorProfile = EvaluateSimplex(array3);
				num3 = (HasConverged(convergenceTolerance, errorProfile, array3) ? (num3 + 1) : 0);
				if (num3 == 2)
				{
					ExitCondition reasonForExit = ExitCondition.Converged;
					objectiveFunction.EvaluateAt(array2[errorProfile.LowestIndex]);
					return new MinimizationResult(objectiveFunction, num2, reasonForExit);
				}
				double num4 = TryToScaleSimplex(-1.0, ref errorProfile, array2, array3, objectiveFunction);
				num2++;
				if (num4 <= array3[errorProfile.LowestIndex])
				{
					TryToScaleSimplex(2.0, ref errorProfile, array2, array3, objectiveFunction);
					num2++;
				}
				else if (num4 >= array3[errorProfile.NextHighestIndex])
				{
					double num5 = array3[errorProfile.HighestIndex];
					double num6 = TryToScaleSimplex(0.5, ref errorProfile, array2, array3, objectiveFunction);
					num2++;
					if (num6 >= num5)
					{
						ShrinkSimplex(errorProfile, array2, array3, objectiveFunction);
						num2 += num;
					}
				}
			}
			while (num2 < maximumIterations);
			throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({maximumIterations}) reached."));
		}

		private static double[] InitializeErrorValues(Vector<double>[] vertices, IObjectiveFunction objectiveFunction)
		{
			double[] array = new double[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				objectiveFunction.EvaluateAt(vertices[i]);
				array[i] = objectiveFunction.Value;
			}
			return array;
		}

		private static bool HasConverged(double convergenceTolerance, ErrorProfile errorProfile, double[] errorValues)
		{
			return 2.0 * Math.Abs(errorValues[errorProfile.HighestIndex] - errorValues[errorProfile.LowestIndex]) / (Math.Abs(errorValues[errorProfile.HighestIndex]) + Math.Abs(errorValues[errorProfile.LowestIndex]) + JITTER) < convergenceTolerance;
		}

		private static ErrorProfile EvaluateSimplex(double[] errorValues)
		{
			ErrorProfile errorProfile = new ErrorProfile();
			if (errorValues[0] > errorValues[1])
			{
				errorProfile.HighestIndex = 0;
				errorProfile.NextHighestIndex = 1;
			}
			else
			{
				errorProfile.HighestIndex = 1;
				errorProfile.NextHighestIndex = 0;
			}
			for (int i = 0; i < errorValues.Length; i++)
			{
				double num = errorValues[i];
				if (num <= errorValues[errorProfile.LowestIndex])
				{
					errorProfile.LowestIndex = i;
				}
				if (num > errorValues[errorProfile.HighestIndex])
				{
					errorProfile.NextHighestIndex = errorProfile.HighestIndex;
					errorProfile.HighestIndex = i;
				}
				else if (num > errorValues[errorProfile.NextHighestIndex] && i != errorProfile.HighestIndex)
				{
					errorProfile.NextHighestIndex = i;
				}
			}
			return errorProfile;
		}

		private static Vector<double>[] InitializeVertices(SimplexConstant[] simplexConstants)
		{
			int num = simplexConstants.Length;
			Vector<double>[] array = new Vector<double>[num + 1];
			DenseVector denseVector = new DenseVector(num);
			for (int i = 0; i < num; i++)
			{
				denseVector[i] = simplexConstants[i].Value;
			}
			array[0] = denseVector;
			for (int j = 0; j < num; j++)
			{
				double initialPerturbation = simplexConstants[j].InitialPerturbation;
				Vector<double> vector = new DenseVector(num);
				vector[j] = 1.0;
				array[j + 1] = denseVector.Add(vector.Multiply(initialPerturbation));
			}
			return array;
		}

		private static double TryToScaleSimplex(double scaleFactor, ref ErrorProfile errorProfile, Vector<double>[] vertices, double[] errorValues, IObjectiveFunction objectiveFunction)
		{
			Vector<double> other = ComputeCentroid(vertices, errorProfile);
			Vector<double> vector = vertices[errorProfile.HighestIndex].Subtract(other).Multiply(scaleFactor).Add(other);
			objectiveFunction.EvaluateAt(vector);
			double value = objectiveFunction.Value;
			if (value < errorValues[errorProfile.HighestIndex])
			{
				vertices[errorProfile.HighestIndex] = vector;
				errorValues[errorProfile.HighestIndex] = value;
			}
			return value;
		}

		private static void ShrinkSimplex(ErrorProfile errorProfile, Vector<double>[] vertices, double[] errorValues, IObjectiveFunction objectiveFunction)
		{
			Vector<double> other = vertices[errorProfile.LowestIndex];
			for (int i = 0; i < vertices.Length; i++)
			{
				if (i != errorProfile.LowestIndex)
				{
					vertices[i] = vertices[i].Add(other).Multiply(0.5);
					objectiveFunction.EvaluateAt(vertices[i]);
					errorValues[i] = objectiveFunction.Value;
				}
			}
		}

		private static Vector<double> ComputeCentroid(Vector<double>[] vertices, ErrorProfile errorProfile)
		{
			int num = vertices.Length;
			Vector<double> vector = new DenseVector(num - 1);
			for (int i = 0; i < num; i++)
			{
				if (i != errorProfile.HighestIndex)
				{
					vector = vector.Add(vertices[i]);
				}
			}
			return vector.Multiply(1.0 / (double)(num - 1));
		}
	}
}
