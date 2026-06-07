using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;

namespace MathNet.Numerics
{
	public static class FindMinimum
	{
		public static double OfScalarFunctionConstrained(Func<double, double> function, double lowerBound, double upperBound, double tolerance = 1E-05, int maxIterations = 1000)
		{
			return GoldenSectionMinimizer.Minimum(ObjectiveFunction.ScalarValue(function), lowerBound, upperBound, tolerance, maxIterations).MinimizingPoint;
		}

		public static double OfScalarFunction(Func<double, double> function, double initialGuess, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return NelderMeadSimplex.Minimum(ObjectiveFunction.Value((Vector<double> v) => function(v[0])), CreateVector.Dense(new double[1] { initialGuess }), tolerance, maxIterations).MinimizingPoint[0];
		}

		public static (double P0, double P1) OfFunction(Func<double, double, double> function, double initialGuess0, double initialGuess1, double tolerance = 1E-08, int maxIterations = 1000)
		{
			MinimizationResult minimizationResult = NelderMeadSimplex.Minimum(ObjectiveFunction.Value((Vector<double> v) => function(v[0], v[1])), CreateVector.Dense(new double[2] { initialGuess0, initialGuess1 }), tolerance, maxIterations);
			return (P0: minimizationResult.MinimizingPoint[0], P1: minimizationResult.MinimizingPoint[1]);
		}

		public static (double P0, double P1, double P2) OfFunction(Func<double, double, double, double> function, double initialGuess0, double initialGuess1, double initialGuess2, double tolerance = 1E-08, int maxIterations = 1000)
		{
			MinimizationResult minimizationResult = NelderMeadSimplex.Minimum(ObjectiveFunction.Value((Vector<double> v) => function(v[0], v[1], v[2])), CreateVector.Dense(new double[3] { initialGuess0, initialGuess1, initialGuess2 }), tolerance, maxIterations);
			return (P0: minimizationResult.MinimizingPoint[0], P1: minimizationResult.MinimizingPoint[1], P2: minimizationResult.MinimizingPoint[2]);
		}

		public static (double P0, double P1, double P2, double P3) OfFunction(Func<double, double, double, double, double> function, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double tolerance = 1E-08, int maxIterations = 1000)
		{
			MinimizationResult minimizationResult = NelderMeadSimplex.Minimum(ObjectiveFunction.Value((Vector<double> v) => function(v[0], v[1], v[2], v[3])), CreateVector.Dense(new double[4] { initialGuess0, initialGuess1, initialGuess2, initialGuess3 }), tolerance, maxIterations);
			return (P0: minimizationResult.MinimizingPoint[0], P1: minimizationResult.MinimizingPoint[1], P2: minimizationResult.MinimizingPoint[2], P3: minimizationResult.MinimizingPoint[3]);
		}

		public static (double P0, double P1, double P2, double P3, double P4) OfFunction(Func<double, double, double, double, double, double> function, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double initialGuess4, double tolerance = 1E-08, int maxIterations = 1000)
		{
			MinimizationResult minimizationResult = NelderMeadSimplex.Minimum(ObjectiveFunction.Value((Vector<double> v) => function(v[0], v[1], v[2], v[3], v[4])), CreateVector.Dense(new double[5] { initialGuess0, initialGuess1, initialGuess2, initialGuess3, initialGuess4 }), tolerance, maxIterations);
			return (P0: minimizationResult.MinimizingPoint[0], P1: minimizationResult.MinimizingPoint[1], P2: minimizationResult.MinimizingPoint[2], P3: minimizationResult.MinimizingPoint[3], P4: minimizationResult.MinimizingPoint[4]);
		}

		public static Vector<double> OfFunction(Func<Vector<double>, double> function, Vector<double> initialGuess, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return NelderMeadSimplex.Minimum(ObjectiveFunction.Value(function), initialGuess, tolerance, maxIterations).MinimizingPoint;
		}

		public static Vector<double> OfFunctionConstrained(Func<Vector<double>, double> function, Vector<double> lowerBound, Vector<double> upperBound, Vector<double> initialGuess, double gradientTolerance = 1E-05, double parameterTolerance = 1E-05, double functionProgressTolerance = 1E-05, int maxIterations = 1000)
		{
			ForwardDifferenceGradientObjectiveFunction objective = new ForwardDifferenceGradientObjectiveFunction(ObjectiveFunction.Value(function), lowerBound, upperBound);
			return new BfgsBMinimizer(gradientTolerance, parameterTolerance, functionProgressTolerance, maxIterations).FindMinimum(objective, lowerBound, upperBound, initialGuess).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradient(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient, Vector<double> initialGuess, double gradientTolerance = 1E-05, double parameterTolerance = 1E-05, double functionProgressTolerance = 1E-05, int maxIterations = 1000)
		{
			IObjectiveFunction objective = ObjectiveFunction.Gradient(function, gradient);
			return new BfgsMinimizer(gradientTolerance, parameterTolerance, functionProgressTolerance, maxIterations).FindMinimum(objective, initialGuess).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradient(Func<Vector<double>, (double, Vector<double>)> functionGradient, Vector<double> initialGuess, double gradientTolerance = 1E-05, double parameterTolerance = 1E-05, double functionProgressTolerance = 1E-05, int maxIterations = 1000)
		{
			IObjectiveFunction objective = ObjectiveFunction.Gradient(functionGradient);
			return new BfgsMinimizer(gradientTolerance, parameterTolerance, functionProgressTolerance, maxIterations).FindMinimum(objective, initialGuess).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradientConstrained(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient, Vector<double> lowerBound, Vector<double> upperBound, Vector<double> initialGuess, double gradientTolerance = 1E-05, double parameterTolerance = 1E-05, double functionProgressTolerance = 1E-05, int maxIterations = 1000)
		{
			IObjectiveFunction objective = ObjectiveFunction.Gradient(function, gradient);
			return new BfgsBMinimizer(gradientTolerance, parameterTolerance, functionProgressTolerance, maxIterations).FindMinimum(objective, lowerBound, upperBound, initialGuess).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradientConstrained(Func<Vector<double>, (double, Vector<double>)> functionGradient, Vector<double> lowerBound, Vector<double> upperBound, Vector<double> initialGuess, double gradientTolerance = 1E-05, double parameterTolerance = 1E-05, double functionProgressTolerance = 1E-05, int maxIterations = 1000)
		{
			IObjectiveFunction objective = ObjectiveFunction.Gradient(functionGradient);
			return new BfgsBMinimizer(gradientTolerance, parameterTolerance, functionProgressTolerance, maxIterations).FindMinimum(objective, lowerBound, upperBound, initialGuess).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradientHessian(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient, Func<Vector<double>, Matrix<double>> hessian, Vector<double> initialGuess, double gradientTolerance = 1E-08, int maxIterations = 1000)
		{
			return NewtonMinimizer.Minimum(ObjectiveFunction.GradientHessian(function, gradient, hessian), initialGuess, gradientTolerance, maxIterations).MinimizingPoint;
		}

		public static Vector<double> OfFunctionGradientHessian(Func<Vector<double>, (double, Vector<double>, Matrix<double>)> functionGradientHessian, Vector<double> initialGuess, double gradientTolerance = 1E-08, int maxIterations = 1000)
		{
			return NewtonMinimizer.Minimum(ObjectiveFunction.GradientHessian(functionGradientHessian), initialGuess, gradientTolerance, maxIterations).MinimizingPoint;
		}
	}
}
