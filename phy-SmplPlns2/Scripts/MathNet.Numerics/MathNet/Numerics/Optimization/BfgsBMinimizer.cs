using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public class BfgsBMinimizer : BfgsMinimizerBase
	{
		private Vector<double> _lowerBound;

		private Vector<double> _upperBound;

		public BfgsBMinimizer(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int maximumIterations = 1000)
			: base(gradientTolerance, parameterTolerance, functionProgressTolerance, maximumIterations)
		{
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objective, Vector<double> lowerBound, Vector<double> upperBound, Vector<double> initialGuess)
		{
			_lowerBound = lowerBound;
			_upperBound = upperBound;
			if (!objective.IsGradientSupported)
			{
				throw new IncompatibleObjectiveException("Gradient not supported in objective function, but required for BFGS minimization.");
			}
			if (lowerBound.Count != upperBound.Count || lowerBound.Count != initialGuess.Count)
			{
				throw new ArgumentException("Dimensions of bounds and/or initial guess do not match.");
			}
			for (int i = 0; i < initialGuess.Count; i++)
			{
				if (initialGuess[i] < lowerBound[i] || initialGuess[i] > upperBound[i])
				{
					throw new ArgumentException("Initial guess is not in the feasible region");
				}
			}
			objective.EvaluateAt(initialGuess);
			ValidateGradientAndObjective(objective);
			ExitCondition exitCondition = ExitCriteriaSatisfied(objective, null, 0);
			if (exitCondition != ExitCondition.None)
			{
				return new MinimizationResult(objective, 0, exitCondition);
			}
			StrongWolfeLineSearch strongWolfeLineSearch = new StrongWolfeLineSearch(0.0001, 0.9, Math.Max(base.ParameterTolerance, 1E-05), 1000);
			Matrix<double> inversePseudoHessian = CreateMatrix.DiagonalIdentity<double>(initialGuess.Count);
			QuadraticGradientProjectionSearch.GradientProjectionResult gradientProjectionResult = QuadraticGradientProjectionSearch.Search(objective.Point, objective.Gradient, inversePseudoHessian, lowerBound, upperBound);
			Vector<double> cauchyPoint = gradientProjectionResult.CauchyPoint;
			int fixedCount = gradientProjectionResult.FixedCount;
			List<bool> isFixed = gradientProjectionResult.IsFixed;
			int num = lowerBound.Count - fixedCount;
			Vector<double> vector3;
			if (num > 0)
			{
				Vector<double> vector = new DenseVector(num);
				Matrix<double> matrix = new DenseMatrix(num, num);
				List<int> reducedMap = new List<int>(num);
				Vector<double> vector2 = new DenseVector(num);
				Vector<double> reducedCauchyPoint = new DenseVector(num);
				CreateReducedData(objective.Point, cauchyPoint, isFixed, lowerBound, upperBound, objective.Gradient, inversePseudoHessian, vector2, reducedCauchyPoint, vector, matrix, reducedMap);
				Vector<double> reducedVector = vector2 + matrix.Cholesky().Solve(-vector);
				vector3 = ReducedToFull(reducedMap, reducedVector, cauchyPoint);
			}
			else
			{
				vector3 = cauchyPoint;
			}
			Vector<double> vector4 = vector3 - cauchyPoint;
			double val = FindMaxStep(cauchyPoint, vector4, lowerBound, upperBound);
			Vector<double> lineSearchDirection = cauchyPoint + Math.Min(val, 1.0) * vector4 - objective.Point;
			double num2 = FindMaxStep(objective.Point, lineSearchDirection, lowerBound, upperBound);
			double initialStep = Math.Min(Math.Max(-objective.Gradient * lineSearchDirection / (lineSearchDirection * inversePseudoHessian * lineSearchDirection), 1.0), num2);
			LineSearchResult lineSearchResult;
			try
			{
				lineSearchResult = strongWolfeLineSearch.FindConformingStep(objective, lineSearchDirection, initialStep, num2);
			}
			catch (Exception innerException)
			{
				throw new InnerOptimizationException("Line search failed.", innerException);
			}
			IObjectiveFunction previousPoint = objective.Fork();
			IObjectiveFunction candidate = lineSearchResult.FunctionInfoAtMinimum;
			ValidateGradientAndObjective(candidate);
			exitCondition = ExitCriteriaSatisfied(candidate, previousPoint, 0);
			if (exitCondition != ExitCondition.None)
			{
				return new MinimizationResult(candidate, 0, exitCondition);
			}
			Vector<double> step = candidate.Point - initialGuess;
			int totalLineSearchSteps = lineSearchResult.Iterations;
			int iterationsWithNontrivialLineSearch = ((lineSearchResult.Iterations <= 0) ? 1 : 0);
			int num3 = DoBfgsUpdate(ref exitCondition, strongWolfeLineSearch, ref inversePseudoHessian, ref lineSearchDirection, ref previousPoint, ref lineSearchResult, ref candidate, ref step, ref totalLineSearchSteps, ref iterationsWithNontrivialLineSearch);
			if (num3 == base.MaximumIterations && exitCondition == ExitCondition.None)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({base.MaximumIterations}) reached."));
			}
			return new MinimizationWithLineSearchResult(candidate, num3, exitCondition, totalLineSearchSteps, iterationsWithNontrivialLineSearch);
		}

		protected override Vector<double> CalculateSearchDirection(ref Matrix<double> pseudoHessian, out double maxLineSearchStep, out double startingStepSize, IObjectiveFunction previousPoint, IObjectiveFunction candidatePoint, Vector<double> step)
		{
			Vector<double> vector = candidatePoint.Gradient - previousPoint.Gradient;
			double num = step * vector;
			if (num > 0.0)
			{
				Vector<double> vector2 = pseudoHessian * step;
				double num2 = step * pseudoHessian * step;
				pseudoHessian = pseudoHessian + vector.OuterProduct(vector) * (1.0 / num) - vector2.OuterProduct(vector2) * (1.0 / num2);
			}
			QuadraticGradientProjectionSearch.GradientProjectionResult gradientProjectionResult = QuadraticGradientProjectionSearch.Search(candidatePoint.Point, candidatePoint.Gradient, pseudoHessian, _lowerBound, _upperBound);
			Vector<double> cauchyPoint = gradientProjectionResult.CauchyPoint;
			int fixedCount = gradientProjectionResult.FixedCount;
			List<bool> isFixed = gradientProjectionResult.IsFixed;
			int num3 = _lowerBound.Count - fixedCount;
			Vector<double> vector3;
			if (num3 > 0)
			{
				DenseVector denseVector = new DenseVector(num3);
				DenseMatrix denseMatrix = new DenseMatrix(num3, num3);
				List<int> reducedMap = new List<int>(num3);
				DenseVector denseVector2 = new DenseVector(num3);
				DenseVector reducedCauchyPoint = new DenseVector(num3);
				CreateReducedData(candidatePoint.Point, cauchyPoint, isFixed, _lowerBound, _upperBound, candidatePoint.Gradient, pseudoHessian, denseVector2, reducedCauchyPoint, denseVector, denseMatrix, reducedMap);
				Vector<double> reducedVector = denseVector2 + denseMatrix.Cholesky().Solve(-denseVector);
				vector3 = ReducedToFull(reducedMap, reducedVector, cauchyPoint);
			}
			else
			{
				vector3 = cauchyPoint;
			}
			Vector<double> vector4 = vector3 - cauchyPoint;
			double val = FindMaxStep(cauchyPoint, vector4, _lowerBound, _upperBound);
			Vector<double> vector5 = cauchyPoint + Math.Min(val, 1.0) * vector4 - candidatePoint.Point;
			maxLineSearchStep = FindMaxStep(candidatePoint.Point, vector5, _lowerBound, _upperBound);
			if (maxLineSearchStep == 0.0)
			{
				vector5 = cauchyPoint - candidatePoint.Point;
				maxLineSearchStep = FindMaxStep(candidatePoint.Point, vector5, _lowerBound, _upperBound);
			}
			double val2 = -candidatePoint.Gradient * vector5 / (vector5 * pseudoHessian * vector5);
			startingStepSize = Math.Min(Math.Max(val2, 1.0), maxLineSearchStep);
			return vector5;
		}

		private static Vector<double> ReducedToFull(List<int> reducedMap, Vector<double> reducedVector, Vector<double> fullVector)
		{
			Vector<double> vector = fullVector.Clone();
			for (int i = 0; i < reducedMap.Count; i++)
			{
				vector[reducedMap[i]] = reducedVector[i];
			}
			return vector;
		}

		private static double FindMaxStep(Vector<double> startingPoint, Vector<double> searchDirection, Vector<double> lowerBound, Vector<double> upperBound)
		{
			double num = double.PositiveInfinity;
			for (int i = 0; i < startingPoint.Count; i++)
			{
				double num2 = ((searchDirection[i] > 0.0) ? ((upperBound[i] - startingPoint[i]) / searchDirection[i]) : ((!(searchDirection[i] < 0.0)) ? double.PositiveInfinity : ((startingPoint[i] - lowerBound[i]) / (0.0 - searchDirection[i]))));
				if (num2 < num)
				{
					num = num2;
				}
			}
			return num;
		}

		private static void CreateReducedData(Vector<double> initialPoint, Vector<double> cauchyPoint, List<bool> isFixed, Vector<double> lowerBound, Vector<double> upperBound, Vector<double> gradient, Matrix<double> pseudoHessian, Vector<double> reducedInitialPoint, Vector<double> reducedCauchyPoint, Vector<double> reducedGradient, Matrix<double> reducedHessian, List<int> reducedMap)
		{
			int num = 0;
			for (int i = 0; i < lowerBound.Count; i++)
			{
				if (isFixed[i])
				{
					continue;
				}
				int num2 = 0;
				for (int j = 0; j < lowerBound.Count; j++)
				{
					if (!isFixed[j])
					{
						reducedHessian[num, num2++] = pseudoHessian[i, j];
					}
				}
				reducedInitialPoint[num] = initialPoint[i];
				reducedCauchyPoint[num] = cauchyPoint[i];
				reducedGradient[num] = gradient[i];
				num++;
				reducedMap.Add(i);
			}
		}

		protected override double GetProjectedGradient(IObjectiveFunctionEvaluation candidatePoint, int ii)
		{
			bool flag = candidatePoint.Point[ii] - _lowerBound[ii] < 1E-15;
			bool flag2 = _upperBound[ii] - candidatePoint.Point[ii] < 1E-15;
			if (flag && flag2)
			{
				return 0.0;
			}
			if (flag)
			{
				return Math.Min(candidatePoint.Gradient[ii], 0.0);
			}
			if (flag2)
			{
				return Math.Max(candidatePoint.Gradient[ii], 0.0);
			}
			return base.GetProjectedGradient(candidatePoint, ii);
		}
	}
}
