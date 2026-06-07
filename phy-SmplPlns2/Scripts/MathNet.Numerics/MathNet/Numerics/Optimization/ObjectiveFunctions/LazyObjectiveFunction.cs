using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class LazyObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private readonly Func<Vector<double>, double> _function;

		private readonly Func<Vector<double>, Vector<double>> _gradient;

		private readonly Func<Vector<double>, Matrix<double>> _hessian;

		private Vector<double> _point;

		private bool _hasFunctionValue;

		private double _functionValue;

		private bool _hasGradientValue;

		private Vector<double> _gradientValue;

		private bool _hasHessianValue;

		private Matrix<double> _hessianValue;

		public bool IsGradientSupported { get; }

		public bool IsHessianSupported { get; }

		public Vector<double> Point => _point;

		public double Value
		{
			get
			{
				if (!_hasFunctionValue)
				{
					_functionValue = _function(_point);
					_hasFunctionValue = true;
				}
				return _functionValue;
			}
		}

		public Vector<double> Gradient
		{
			get
			{
				if (!_hasGradientValue)
				{
					_gradientValue = _gradient(_point);
					_hasGradientValue = true;
				}
				return _gradientValue;
			}
		}

		public Matrix<double> Hessian
		{
			get
			{
				if (!_hasHessianValue)
				{
					_hessianValue = _hessian(_point);
					_hasHessianValue = true;
				}
				return _hessianValue;
			}
		}

		public LazyObjectiveFunction(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient = null, Func<Vector<double>, Matrix<double>> hessian = null)
		{
			_function = function;
			_gradient = gradient;
			_hessian = hessian;
			IsGradientSupported = gradient != null;
			IsHessianSupported = hessian != null;
		}

		public IObjectiveFunction CreateNew()
		{
			return new LazyObjectiveFunction(_function, _gradient, _hessian);
		}

		public IObjectiveFunction Fork()
		{
			return new LazyObjectiveFunction(_function, _gradient, _hessian)
			{
				_point = _point,
				_hasFunctionValue = _hasFunctionValue,
				_functionValue = _functionValue,
				_hasGradientValue = _hasGradientValue,
				_gradientValue = _gradientValue,
				_hasHessianValue = _hasHessianValue,
				_hessianValue = _hessianValue
			};
		}

		public void EvaluateAt(Vector<double> point)
		{
			_point = point;
			_hasFunctionValue = false;
			_hasGradientValue = false;
			_hasHessianValue = false;
			_gradientValue = null;
			_hessianValue = null;
		}
	}
}
