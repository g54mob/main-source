using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	public class ForwardDifferenceGradientObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private Vector<double> _gradient;

		public IObjectiveFunction InnerObjectiveFunction { get; protected set; }

		protected Vector<double> LowerBound { get; set; }

		protected Vector<double> UpperBound { get; set; }

		protected bool ValueEvaluated { get; set; }

		protected bool GradientEvaluated { get; set; }

		public double MinimumIncrement { get; set; }

		public double RelativeIncrement { get; set; }

		public Vector<double> Gradient
		{
			get
			{
				if (!GradientEvaluated)
				{
					EvaluateGradient();
				}
				return _gradient;
			}
			protected set
			{
				_gradient = value;
			}
		}

		public Matrix<double> Hessian
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsGradientSupported => true;

		public bool IsHessianSupported => false;

		public Vector<double> Point { get; protected set; }

		public double Value
		{
			get
			{
				if (!ValueEvaluated)
				{
					EvaluateValue();
				}
				return InnerObjectiveFunction.Value;
			}
		}

		public ForwardDifferenceGradientObjectiveFunction(IObjectiveFunction valueOnlyObj, Vector<double> lowerBound, Vector<double> upperBound, double relativeIncrement = 1E-05, double minimumIncrement = 1E-08)
		{
			InnerObjectiveFunction = valueOnlyObj;
			LowerBound = lowerBound;
			UpperBound = upperBound;
			_gradient = new DenseVector(LowerBound.Count);
			RelativeIncrement = relativeIncrement;
			MinimumIncrement = minimumIncrement;
		}

		protected void EvaluateValue()
		{
			ValueEvaluated = true;
		}

		protected void EvaluateGradient()
		{
			if (!ValueEvaluated)
			{
				EvaluateValue();
			}
			Vector<double> vector = Point.Clone();
			IObjectiveFunction objectiveFunction = InnerObjectiveFunction.CreateNew();
			for (int i = 0; i < _gradient.Count; i++)
			{
				double num = vector[i];
				double num2 = Math.Max(num * RelativeIncrement, MinimumIncrement);
				int num3 = 1;
				if (num + num2 > UpperBound[i])
				{
					num3 = -1;
				}
				vector[i] = num + (double)num3 * num2;
				objectiveFunction.EvaluateAt(vector);
				double value = objectiveFunction.Value;
				_gradient[i] = ((double)num3 * value - (double)num3 * InnerObjectiveFunction.Value) / num2;
				vector[i] = num;
			}
			GradientEvaluated = true;
		}

		public IObjectiveFunction CreateNew()
		{
			return new ForwardDifferenceGradientObjectiveFunction(InnerObjectiveFunction.CreateNew(), LowerBound, UpperBound, RelativeIncrement, MinimumIncrement);
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			ValueEvaluated = false;
			GradientEvaluated = false;
			InnerObjectiveFunction.EvaluateAt(point);
		}

		public IObjectiveFunction Fork()
		{
			return new ForwardDifferenceGradientObjectiveFunction(InnerObjectiveFunction.Fork(), LowerBound, UpperBound, RelativeIncrement, MinimumIncrement)
			{
				Point = Point?.Clone(),
				GradientEvaluated = GradientEvaluated,
				ValueEvaluated = ValueEvaluated,
				_gradient = _gradient?.Clone()
			};
		}
	}
}
