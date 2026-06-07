using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	public abstract class LazyObjectiveFunctionBase : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private Vector<double> _point;

		protected bool HasFunctionValue { get; set; }

		protected double FunctionValue { get; set; }

		protected bool HasGradientValue { get; set; }

		protected Vector<double> GradientValue { get; set; }

		protected bool HasHessianValue { get; set; }

		protected Matrix<double> HessianValue { get; set; }

		public bool IsGradientSupported { get; }

		public bool IsHessianSupported { get; }

		public Vector<double> Point => _point;

		public double Value
		{
			get
			{
				if (!HasFunctionValue)
				{
					EvaluateValue();
				}
				return FunctionValue;
			}
			protected set
			{
				FunctionValue = value;
				HasFunctionValue = true;
			}
		}

		public Vector<double> Gradient
		{
			get
			{
				if (!HasGradientValue)
				{
					EvaluateGradient();
				}
				return GradientValue;
			}
			protected set
			{
				GradientValue = value;
				HasGradientValue = true;
			}
		}

		public Matrix<double> Hessian
		{
			get
			{
				if (!HasHessianValue)
				{
					EvaluateHessian();
				}
				return HessianValue;
			}
			protected set
			{
				HessianValue = value;
				HasHessianValue = true;
			}
		}

		protected LazyObjectiveFunctionBase(bool gradientSupported, bool hessianSupported)
		{
			IsGradientSupported = gradientSupported;
			IsHessianSupported = hessianSupported;
		}

		public abstract IObjectiveFunction CreateNew();

		public virtual IObjectiveFunction Fork()
		{
			LazyObjectiveFunctionBase obj = (LazyObjectiveFunctionBase)CreateNew();
			obj._point = _point?.Clone();
			obj.HasFunctionValue = HasFunctionValue;
			obj.FunctionValue = FunctionValue;
			obj.HasGradientValue = HasGradientValue;
			obj.GradientValue = GradientValue?.Clone();
			obj.HasHessianValue = HasHessianValue;
			obj.HessianValue = HessianValue?.Clone();
			return obj;
		}

		public void EvaluateAt(Vector<double> point)
		{
			_point = point;
			HasFunctionValue = false;
			HasGradientValue = false;
			HasHessianValue = false;
		}

		protected abstract void EvaluateValue();

		protected virtual void EvaluateGradient()
		{
			Gradient = null;
		}

		protected virtual void EvaluateHessian()
		{
			Hessian = null;
		}
	}
}
