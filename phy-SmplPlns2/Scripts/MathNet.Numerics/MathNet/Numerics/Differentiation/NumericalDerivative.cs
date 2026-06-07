using System;
using System.Linq;

namespace MathNet.Numerics.Differentiation
{
	public class NumericalDerivative
	{
		private readonly int _points;

		private int _center;

		private double _stepSize = Math.Pow(2.0, -10.0);

		private double _epsilon = Precision.PositiveMachineEpsilon;

		private double _baseStepSize = Math.Pow(2.0, -26.0);

		private readonly FiniteDifferenceCoefficients _coefficients;

		public double StepSize
		{
			get
			{
				return _stepSize;
			}
			set
			{
				double a = Math.Log(Math.Abs(value)) / Math.Log(2.0);
				_stepSize = Math.Pow(2.0, Math.Round(a));
			}
		}

		public double BaseStepSize
		{
			get
			{
				return _baseStepSize;
			}
			set
			{
				double a = Math.Log(Math.Abs(value)) / Math.Log(2.0);
				_baseStepSize = Math.Pow(2.0, Math.Round(a));
			}
		}

		public double Epsilon
		{
			get
			{
				return _epsilon;
			}
			set
			{
				double a = Math.Log(Math.Abs(value)) / Math.Log(2.0);
				_epsilon = Math.Pow(2.0, Math.Round(a));
			}
		}

		public int Center
		{
			get
			{
				return _center;
			}
			set
			{
				if (value >= _points || value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Center must lie between 0 and points -1");
				}
				_center = value;
			}
		}

		public int Evaluations { get; private set; }

		public StepType StepType { get; set; } = StepType.Relative;

		public NumericalDerivative()
			: this(3, 1)
		{
		}

		public NumericalDerivative(int points, int center)
		{
			if (points < 2)
			{
				throw new ArgumentOutOfRangeException("points", "Points must be two or greater.");
			}
			_center = center;
			_points = points;
			Center = center;
			_coefficients = new FiniteDifferenceCoefficients(points);
		}

		public double EvaluateDerivative(double[] points, int order, double stepSize)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (order >= _points || order < 0)
			{
				throw new ArgumentOutOfRangeException("order", "Order must be between zero and points-1.");
			}
			return _coefficients.GetCoefficients(Center, order).Select((double t, int i) => t * points[i]).Sum() / Math.Pow(stepSize, order);
		}

		public double EvaluateDerivative(Func<double, double> f, double x, int order, double? currentValue = null)
		{
			double[] coefficients = _coefficients.GetCoefficients(Center, order);
			double num = CalculateStepSize(_points, x, order);
			double[] array = new double[_points];
			for (int i = 0; i < _points; i++)
			{
				if (i == Center && currentValue.HasValue)
				{
					array[i] = currentValue.Value;
				}
				else if (coefficients[i] != 0.0)
				{
					array[i] = f(x + (double)(i - Center) * num);
					Evaluations++;
				}
			}
			return EvaluateDerivative(array, order, num);
		}

		public Func<double, double> CreateDerivativeFunctionHandle(Func<double, double> f, int order)
		{
			return (double x) => EvaluateDerivative(f, x, order);
		}

		public double EvaluatePartialDerivative(Func<double[], double> f, double[] x, int parameterIndex, int order, double? currentValue = null)
		{
			double num = x[parameterIndex];
			double[] coefficients = _coefficients.GetCoefficients(Center, order);
			double num2 = CalculateStepSize(_points, x[parameterIndex], order);
			double[] array = new double[_points];
			for (int i = 0; i < _points; i++)
			{
				if (i == Center && currentValue.HasValue)
				{
					array[i] = currentValue.Value;
				}
				else if (coefficients[i] != 0.0)
				{
					x[parameterIndex] = num + (double)(i - Center) * num2;
					array[i] = f(x);
					Evaluations++;
				}
			}
			x[parameterIndex] = num;
			return EvaluateDerivative(array, order, num2);
		}

		public double[] EvaluatePartialDerivative(Func<double[], double>[] f, double[] x, int parameterIndex, int order, double?[] currentValue = null)
		{
			double[] array = new double[f.Length];
			for (int i = 0; i < f.Length; i++)
			{
				if (currentValue != null && currentValue[i].HasValue)
				{
					array[i] = EvaluatePartialDerivative(f[i], x, parameterIndex, order, currentValue[i].Value);
				}
				else
				{
					array[i] = EvaluatePartialDerivative(f[i], x, parameterIndex, order);
				}
			}
			return array;
		}

		public Func<double[], double> CreatePartialDerivativeFunctionHandle(Func<double[], double> f, int parameterIndex, int order)
		{
			return (double[] x) => EvaluatePartialDerivative(f, x, parameterIndex, order);
		}

		public Func<double[], double[]> CreatePartialDerivativeFunctionHandle(Func<double[], double>[] f, int parameterIndex, int order)
		{
			return (double[] x) => EvaluatePartialDerivative(f, x, parameterIndex, order);
		}

		public double EvaluateMixedPartialDerivative(Func<double[], double> f, double[] x, int[] parameterIndex, int order, double? currentValue = null)
		{
			if (parameterIndex.Length != order)
			{
				throw new ArgumentOutOfRangeException("parameterIndex", "The number of parameters must match derivative order.");
			}
			if (order == 1)
			{
				return EvaluatePartialDerivative(f, x, parameterIndex[0], order, currentValue);
			}
			int num = order - 1;
			int[] array = new int[num];
			Array.Copy(parameterIndex, 0, array, 0, num);
			double[] array2 = new double[_points];
			int num2 = parameterIndex[order - 1];
			double num3 = CalculateStepSize(_points, x[num2], order);
			double num4 = x[num2];
			for (int i = 0; i < _points; i++)
			{
				x[num2] = num4 + (double)(i - Center) * num3;
				array2[i] = EvaluateMixedPartialDerivative(f, x, array, num);
			}
			x[num2] = num4;
			return EvaluateDerivative(array2, 1, num3);
		}

		public double[] EvaluateMixedPartialDerivative(Func<double[], double>[] f, double[] x, int[] parameterIndex, int order, double?[] currentValue = null)
		{
			double[] array = new double[f.Length];
			for (int i = 0; i < f.Length; i++)
			{
				if (currentValue != null && currentValue[i].HasValue)
				{
					array[i] = EvaluateMixedPartialDerivative(f[i], x, parameterIndex, order, currentValue[i].Value);
				}
				else
				{
					array[i] = EvaluateMixedPartialDerivative(f[i], x, parameterIndex, order);
				}
			}
			return array;
		}

		public Func<double[], double> CreateMixedPartialDerivativeFunctionHandle(Func<double[], double> f, int[] parameterIndex, int order)
		{
			return (double[] x) => EvaluateMixedPartialDerivative(f, x, parameterIndex, order);
		}

		public Func<double[], double[]> CreateMixedPartialDerivativeFunctionHandle(Func<double[], double>[] f, int[] parameterIndex, int order)
		{
			return (double[] x) => EvaluateMixedPartialDerivative(f, x, parameterIndex, order);
		}

		public void ResetEvaluations()
		{
			Evaluations = 0;
		}

		private double CalculateStepSize(int points, double x, double order)
		{
			if (StepType == StepType.RelativeX)
			{
				StepSize = BaseStepSize * (1.0 + Math.Abs(x));
			}
			else if (StepType == StepType.Relative)
			{
				double num = (double)points - order;
				BaseStepSize = Math.Pow(Epsilon, 1.0 / (num + order));
				StepSize = BaseStepSize * (1.0 + Math.Abs(x));
			}
			return StepSize;
		}
	}
}
