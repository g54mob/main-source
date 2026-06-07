using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	public abstract class ObjectiveFunctionBase : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		public bool IsGradientSupported { get; }

		public bool IsHessianSupported { get; }

		public Vector<double> Point { get; private set; }

		public double Value { get; protected set; }

		public Vector<double> Gradient { get; protected set; }

		public Matrix<double> Hessian { get; protected set; }

		protected ObjectiveFunctionBase(bool isGradientSupported, bool isHessianSupported)
		{
			IsGradientSupported = isGradientSupported;
			IsHessianSupported = isHessianSupported;
		}

		public abstract IObjectiveFunction CreateNew();

		public virtual IObjectiveFunction Fork()
		{
			ObjectiveFunctionBase obj = (ObjectiveFunctionBase)CreateNew();
			obj.Point = ((Point == null) ? null : Point.Clone());
			obj.Value = Value;
			obj.Gradient = ((Gradient == null) ? null : Gradient.Clone());
			obj.Hessian = ((Hessian == null) ? null : Hessian.Clone());
			return obj;
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			Evaluate();
		}

		protected abstract void Evaluate();
	}
}
