using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public static class BfgsSolver
	{
		private const double GradientTolerance = 1E-05;

		private const int MaxIterations = 100000;

		public static Vector<double> Solve(Vector initialGuess, Func<Vector<double>, double> functionValue, Func<Vector<double>, Vector<double>> functionGradient)
		{
			IObjectiveFunction objectiveFunction = ObjectiveFunction.Gradient(functionValue, functionGradient);
			objectiveFunction.EvaluateAt(initialGuess);
			int count = initialGuess.Count;
			int num = 0;
			Matrix<double> matrix = DenseMatrix.CreateIdentity(count);
			Vector<double> vector = initialGuess;
			Vector<double> vector2 = vector;
			WolfeLineSearch wolfeLineSearch = new WeakWolfeLineSearch(0.0001, 0.9, 1E-05, 200);
			Vector<double> gradient;
			do
			{
				gradient = objectiveFunction.Gradient;
				Vector<double> vector3 = -1.0 * matrix * gradient;
				double finalStep = wolfeLineSearch.FindConformingStep(objectiveFunction, vector3, 1.0).FinalStep;
				vector += finalStep * vector3;
				Vector<double> vector4 = gradient;
				objectiveFunction.EvaluateAt(vector);
				gradient = objectiveFunction.Gradient;
				Vector<double> vector5 = vector - vector2;
				Vector<double> vector6 = gradient - vector4;
				double num2 = 1.0 / (vector6 * vector5);
				if (num == 0)
				{
					matrix = vector6 * vector5 / (vector6 * vector6) * DenseMatrix.CreateIdentity(count);
				}
				Matrix<double> matrix2 = vector5.ToColumnMatrix();
				Matrix<double> matrix3 = vector6.ToColumnMatrix();
				matrix = matrix - num2 * (matrix2 * matrix3.TransposeThisAndMultiply(matrix) + (matrix * matrix3).TransposeAndMultiply(matrix2)) + num2 * num2 * (vector6.DotProduct(matrix * vector6) + 1.0 / num2) * matrix2.TransposeAndMultiply(matrix2);
				vector2 = vector;
				num++;
			}
			while (gradient.InfinityNorm() > 1E-05 && num < 100000);
			return vector;
		}
	}
}
