using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class NonlinearObjectiveFunction : IObjectiveModel, IObjectiveModelEvaluation
	{
		private readonly Func<Vector<double>, Vector<double>, Vector<double>> _userFunction;

		private readonly Func<Vector<double>, Vector<double>, Matrix<double>> _userDerivative;

		private readonly int _accuracyOrder;

		private Vector<double> _coefficients;

		private bool _hasFunctionValue;

		private double _functionValue;

		private Vector<double> _residuals;

		private bool _hasJacobianValue;

		private Matrix<double> _jacobianValue;

		private Vector<double> _gradientValue;

		private Matrix<double> _hessianValue;

		private Vector<double> L;

		public Vector<double> ObservedX { get; private set; }

		public Vector<double> ObservedY { get; private set; }

		public Matrix<double> Weights { get; private set; }

		public List<bool> IsFixed { get; private set; }

		public int NumberOfObservations => ObservedY?.Count ?? 0;

		public int NumberOfParameters => Point?.Count ?? 0;

		public int DegreeOfFreedom
		{
			get
			{
				int num = NumberOfObservations - NumberOfParameters;
				if (IsFixed != null)
				{
					num += IsFixed.Count((bool p) => p);
				}
				return num;
			}
		}

		public int FunctionEvaluations { get; set; }

		public int JacobianEvaluations { get; set; }

		public Vector<double> Point => _coefficients;

		public Vector<double> ModelValues { get; private set; }

		public double Value
		{
			get
			{
				if (!_hasFunctionValue)
				{
					EvaluateFunction();
					_hasFunctionValue = true;
				}
				return _functionValue;
			}
		}

		public Vector<double> Gradient
		{
			get
			{
				if (!_hasJacobianValue)
				{
					EvaluateJacobian();
					_hasJacobianValue = true;
				}
				return _gradientValue;
			}
		}

		public Matrix<double> Hessian
		{
			get
			{
				if (!_hasJacobianValue)
				{
					EvaluateJacobian();
					_hasJacobianValue = true;
				}
				return _hessianValue;
			}
		}

		public bool IsGradientSupported => true;

		public bool IsHessianSupported => true;

		public NonlinearObjectiveFunction(Func<Vector<double>, Vector<double>, Vector<double>> function, Func<Vector<double>, Vector<double>, Matrix<double>> derivative = null, int accuracyOrder = 2)
		{
			_userFunction = function;
			_userDerivative = derivative;
			_accuracyOrder = Math.Min(6, Math.Max(1, accuracyOrder));
		}

		public IObjectiveModel Fork()
		{
			return new NonlinearObjectiveFunction(_userFunction, _userDerivative, _accuracyOrder)
			{
				ObservedX = ObservedX,
				ObservedY = ObservedY,
				Weights = Weights,
				_coefficients = _coefficients,
				_hasFunctionValue = _hasFunctionValue,
				_functionValue = _functionValue,
				_hasJacobianValue = _hasJacobianValue,
				_jacobianValue = _jacobianValue,
				_gradientValue = _gradientValue,
				_hessianValue = _hessianValue
			};
		}

		public IObjectiveModel CreateNew()
		{
			return new NonlinearObjectiveFunction(_userFunction, _userDerivative, _accuracyOrder);
		}

		public void SetObserved(Vector<double> observedX, Vector<double> observedY, Vector<double> weights = null)
		{
			if (observedX == null || observedY == null)
			{
				throw new ArgumentNullException("The data set can't be null.");
			}
			if (observedX.Count != observedY.Count)
			{
				throw new ArgumentException("The observed x data can't have different from observed y data.");
			}
			ObservedX = observedX;
			ObservedY = observedY;
			if (weights != null && weights.Count != observedY.Count)
			{
				throw new ArgumentException("The weightings can't have different from observations.");
			}
			if (weights != null && weights.Count((double x) => double.IsInfinity(x) || double.IsNaN(x)) > 0)
			{
				throw new ArgumentException("The weightings are not well-defined.");
			}
			if (weights != null && weights.Count((double x) => x == 0.0) == weights.Count)
			{
				throw new ArgumentException("All the weightings can't be zero.");
			}
			if (weights != null && weights.Count((double x) => x < 0.0) > 0)
			{
				weights = weights.PointwiseAbs();
			}
			Weights = ((weights == null) ? null : Matrix<double>.Build.DenseOfDiagonalVector(weights));
			L = ((weights == null) ? null : Weights.Diagonal().PointwiseSqrt());
		}

		public void SetParameters(Vector<double> initialGuess, List<bool> isFixed = null)
		{
			_coefficients = initialGuess ?? throw new ArgumentNullException("initialGuess");
			if (isFixed != null && isFixed.Count != initialGuess.Count)
			{
				throw new ArgumentException("The isFixed can't have different size from the initial guess.");
			}
			if (isFixed != null && isFixed.Count((bool p) => p) == isFixed.Count)
			{
				throw new ArgumentException("All the parameters can't be fixed.");
			}
			IsFixed = isFixed;
		}

		public void EvaluateAt(Vector<double> parameters)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (parameters.Count((double p) => double.IsNaN(p) || double.IsInfinity(p)) > 0)
			{
				throw new ArgumentException("The parameters must be finite.");
			}
			_coefficients = parameters;
			_hasFunctionValue = false;
			_hasJacobianValue = false;
			_jacobianValue = null;
			_gradientValue = null;
			_hessianValue = null;
		}

		public IObjectiveFunction ToObjectiveFunction()
		{
			return new GradientHessianObjectiveFunction(Function);
			(double, Vector<double>, Matrix<double>) Function(Vector<double> point)
			{
				EvaluateAt(point);
				return (Value, Gradient, Hessian);
			}
		}

		private void EvaluateFunction()
		{
			if (ModelValues == null)
			{
				ModelValues = Vector<double>.Build.Dense(NumberOfObservations);
			}
			ModelValues = _userFunction(Point, ObservedX);
			FunctionEvaluations++;
			_residuals = ((Weights == null) ? (ObservedY - ModelValues) : (ObservedY - ModelValues).PointwiseMultiply(L));
			_functionValue = _residuals.DotProduct(_residuals);
		}

		private void EvaluateJacobian()
		{
			if (_userDerivative != null)
			{
				_jacobianValue = _userDerivative(Point, ObservedX);
				JacobianEvaluations++;
			}
			else
			{
				_jacobianValue = NumericalJacobian(Point, ModelValues, _accuracyOrder);
				FunctionEvaluations += _accuracyOrder;
			}
			for (int i = 0; i < NumberOfObservations; i++)
			{
				for (int j = 0; j < NumberOfParameters; j++)
				{
					if (IsFixed != null && IsFixed[j])
					{
						_jacobianValue[i, j] = 0.0;
					}
					else if (Weights != null)
					{
						_jacobianValue[i, j] *= L[i];
					}
				}
			}
			_gradientValue = -_jacobianValue.Transpose() * _residuals;
			_hessianValue = _jacobianValue.Transpose() * _jacobianValue;
		}

		private Matrix<double> NumericalJacobian(Vector<double> parameters, Vector<double> currentValues, int accuracyOrder = 2)
		{
			Matrix<double> matrix = Matrix<double>.Build.Dense(NumberOfObservations, NumberOfParameters);
			Vector<double> vector = 3E-06 * parameters.PointwiseAbs().PointwiseMaximum(1.4901161193847656E-08);
			Vector<double> vector2 = Vector<double>.Build.Dense(NumberOfParameters);
			for (int i = 0; i < NumberOfParameters; i++)
			{
				vector2[i] = vector[i];
				if (accuracyOrder >= 6)
				{
					Vector<double> vector3 = _userFunction(parameters - 3.0 * vector2, ObservedX);
					Vector<double> vector4 = _userFunction(parameters - 2.0 * vector2, ObservedX);
					Vector<double> vector5 = _userFunction(parameters - vector2, ObservedX);
					Vector<double> vector6 = _userFunction(parameters + vector2, ObservedX);
					Vector<double> vector7 = _userFunction(parameters + 2.0 * vector2, ObservedX);
					Vector<double> vector8 = _userFunction(parameters + 3.0 * vector2, ObservedX);
					Vector<double> column = (-vector3 + 9.0 * vector4 - 45.0 * vector5 + 45.0 * vector6 - 9.0 * vector7 + vector8) / (60.0 * vector2[i]);
					matrix.SetColumn(i, column);
				}
				else
				{
					switch (accuracyOrder)
					{
					case 5:
					{
						Vector<double> vector19 = _userFunction(parameters + vector2, ObservedX);
						Vector<double> vector20 = _userFunction(parameters + 2.0 * vector2, ObservedX);
						Vector<double> vector21 = _userFunction(parameters + 3.0 * vector2, ObservedX);
						Vector<double> vector22 = _userFunction(parameters + 4.0 * vector2, ObservedX);
						Vector<double> vector23 = _userFunction(parameters + 5.0 * vector2, ObservedX);
						Vector<double> column6 = (-137.0 * currentValues + 300.0 * vector19 - 300.0 * vector20 + 200.0 * vector21 - 75.0 * vector22 + 12.0 * vector23) / (60.0 * vector2[i]);
						matrix.SetColumn(i, column6);
						break;
					}
					case 4:
					{
						Vector<double> vector15 = _userFunction(parameters - 2.0 * vector2, ObservedX);
						Vector<double> vector16 = _userFunction(parameters - vector2, ObservedX);
						Vector<double> vector17 = _userFunction(parameters + vector2, ObservedX);
						Vector<double> vector18 = _userFunction(parameters + 2.0 * vector2, ObservedX);
						Vector<double> column5 = (vector15 - 8.0 * vector16 + 8.0 * vector17 - vector18) / (12.0 * vector2[i]);
						matrix.SetColumn(i, column5);
						break;
					}
					case 3:
					{
						Vector<double> vector12 = _userFunction(parameters + vector2, ObservedX);
						Vector<double> vector13 = _userFunction(parameters + 2.0 * vector2, ObservedX);
						Vector<double> vector14 = _userFunction(parameters + 3.0 * vector2, ObservedX);
						Vector<double> column4 = (-11.0 * currentValues + 18.0 * vector12 - 9.0 * vector13 + 2.0 * vector14) / (6.0 * vector2[i]);
						matrix.SetColumn(i, column4);
						break;
					}
					case 2:
					{
						Vector<double> vector10 = _userFunction(parameters + vector2, ObservedX);
						Vector<double> vector11 = _userFunction(parameters - vector2, ObservedX);
						Vector<double> column3 = (vector10 - vector11) / (2.0 * vector2[i]);
						matrix.SetColumn(i, column3);
						break;
					}
					default:
					{
						Vector<double> vector9 = _userFunction(parameters + vector2, ObservedX);
						Vector<double> column2 = (-currentValues + vector9) / vector2[i];
						matrix.SetColumn(i, column2);
						break;
					}
					}
				}
				vector2[i] = 0.0;
			}
			return matrix;
		}
	}
}
