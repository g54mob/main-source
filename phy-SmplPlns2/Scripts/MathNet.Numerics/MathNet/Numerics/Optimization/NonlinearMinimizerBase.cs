using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public abstract class NonlinearMinimizerBase
	{
		public double FunctionTolerance { get; set; }

		public double StepTolerance { get; set; }

		public double GradientTolerance { get; set; }

		public int MaximumIterations { get; set; }

		public Vector<double> LowerBound { get; private set; }

		public Vector<double> UpperBound { get; private set; }

		public Vector<double> Scales { get; private set; }

		private bool IsBounded
		{
			get
			{
				if (LowerBound == null && UpperBound == null)
				{
					return Scales != null;
				}
				return true;
			}
		}

		protected NonlinearMinimizerBase(double gradientTolerance = 1E-18, double stepTolerance = 1E-18, double functionTolerance = 1E-18, int maximumIterations = -1)
		{
			GradientTolerance = gradientTolerance;
			StepTolerance = stepTolerance;
			FunctionTolerance = functionTolerance;
			MaximumIterations = maximumIterations;
		}

		protected void ValidateBounds(Vector<double> parameters, Vector<double> lowerBound = null, Vector<double> upperBound = null, Vector<double> scales = null)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (lowerBound != null && lowerBound.Count((double x) => double.IsInfinity(x) || double.IsNaN(x)) > 0)
			{
				throw new ArgumentException("The lower bounds must be finite.");
			}
			if (lowerBound != null && lowerBound.Count != parameters.Count)
			{
				throw new ArgumentException("The lower bounds can't have different size from the parameters.");
			}
			LowerBound = lowerBound;
			if (upperBound != null && upperBound.Count((double x) => double.IsInfinity(x) || double.IsNaN(x)) > 0)
			{
				throw new ArgumentException("The upper bounds must be finite.");
			}
			if (upperBound != null && upperBound.Count != parameters.Count)
			{
				throw new ArgumentException("The upper bounds can't have different size from the parameters.");
			}
			UpperBound = upperBound;
			if (scales != null && scales.Count((double x) => double.IsInfinity(x) || double.IsNaN(x) || x == 0.0) > 0)
			{
				throw new ArgumentException("The scales must be finite.");
			}
			if (scales != null && scales.Count != parameters.Count)
			{
				throw new ArgumentException("The scales can't have different size from the parameters.");
			}
			if (scales != null && scales.Count((double x) => x < 0.0) > 0)
			{
				scales.PointwiseAbs();
			}
			Scales = scales;
		}

		protected double EvaluateFunction(IObjectiveModel objective, Vector<double> Pint)
		{
			Vector<double> parameters = ProjectToExternalParameters(Pint);
			objective.EvaluateAt(parameters);
			return objective.Value;
		}

		protected (Vector<double> Gradient, Matrix<double> Hessian) EvaluateJacobian(IObjectiveModel objective, Vector<double> Pint)
		{
			Vector<double> gradient = objective.Gradient;
			Matrix<double> hessian = objective.Hessian;
			if (IsBounded)
			{
				Vector<double> vector = ScaleFactorsOfJacobian(Pint);
				for (int i = 0; i < gradient.Count; i++)
				{
					gradient[i] *= vector[i];
				}
				for (int j = 0; j < hessian.RowCount; j++)
				{
					for (int k = 0; k < hessian.ColumnCount; k++)
					{
						hessian[j, k] = hessian[j, k] * vector[j] * vector[k];
					}
				}
			}
			return (Gradient: gradient, Hessian: hessian);
		}

		protected Vector<double> ProjectToInternalParameters(Vector<double> Pext)
		{
			Vector<double> vector = Pext.Clone();
			if (LowerBound != null && UpperBound != null)
			{
				for (int i = 0; i < Pext.Count; i++)
				{
					vector[i] = Math.Asin(2.0 * (Pext[i] - LowerBound[i]) / (UpperBound[i] - LowerBound[i]) - 1.0);
				}
				return vector;
			}
			if (LowerBound != null && UpperBound == null)
			{
				for (int j = 0; j < Pext.Count; j++)
				{
					vector[j] = ((Scales == null) ? Math.Sqrt(Math.Pow(Pext[j] - LowerBound[j] + 1.0, 2.0) - 1.0) : Math.Sqrt(Math.Pow((Pext[j] - LowerBound[j]) / Scales[j] + 1.0, 2.0) - 1.0));
				}
				return vector;
			}
			if (LowerBound == null && UpperBound != null)
			{
				for (int k = 0; k < Pext.Count; k++)
				{
					vector[k] = ((Scales == null) ? Math.Sqrt(Math.Pow(UpperBound[k] - Pext[k] + 1.0, 2.0) - 1.0) : Math.Sqrt(Math.Pow((UpperBound[k] - Pext[k]) / Scales[k] + 1.0, 2.0) - 1.0));
				}
				return vector;
			}
			if (Scales != null)
			{
				for (int l = 0; l < Pext.Count; l++)
				{
					vector[l] = Pext[l] / Scales[l];
				}
				return vector;
			}
			return vector;
		}

		protected Vector<double> ProjectToExternalParameters(Vector<double> Pint)
		{
			Vector<double> vector = Pint.Clone();
			if (LowerBound != null && UpperBound != null)
			{
				for (int i = 0; i < Pint.Count; i++)
				{
					vector[i] = LowerBound[i] + (UpperBound[i] / 2.0 - LowerBound[i] / 2.0) * (Math.Sin(Pint[i]) + 1.0);
				}
				return vector;
			}
			if (LowerBound != null && UpperBound == null)
			{
				for (int j = 0; j < Pint.Count; j++)
				{
					vector[j] = ((Scales == null) ? (LowerBound[j] + Math.Sqrt(Pint[j] * Pint[j] + 1.0) - 1.0) : (LowerBound[j] + Scales[j] * (Math.Sqrt(Pint[j] * Pint[j] + 1.0) - 1.0)));
				}
				return vector;
			}
			if (LowerBound == null && UpperBound != null)
			{
				for (int k = 0; k < Pint.Count; k++)
				{
					vector[k] = ((Scales == null) ? (UpperBound[k] - Math.Sqrt(Pint[k] * Pint[k] + 1.0) + 1.0) : (UpperBound[k] - Scales[k] * (Math.Sqrt(Pint[k] * Pint[k] + 1.0) - 1.0)));
				}
				return vector;
			}
			if (Scales != null)
			{
				for (int l = 0; l < Pint.Count; l++)
				{
					vector[l] = Pint[l] * Scales[l];
				}
				return vector;
			}
			return vector;
		}

		protected Vector<double> ScaleFactorsOfJacobian(Vector<double> Pint)
		{
			Vector<double> vector = Vector<double>.Build.Dense(Pint.Count, 1.0);
			if (LowerBound != null && UpperBound != null)
			{
				for (int i = 0; i < Pint.Count; i++)
				{
					vector[i] = (UpperBound[i] - LowerBound[i]) / 2.0 * Math.Cos(Pint[i]);
				}
				return vector;
			}
			if (LowerBound != null && UpperBound == null)
			{
				for (int j = 0; j < Pint.Count; j++)
				{
					vector[j] = ((Scales == null) ? (Pint[j] / Math.Sqrt(Pint[j] * Pint[j] + 1.0)) : (Scales[j] * Pint[j] / Math.Sqrt(Pint[j] * Pint[j] + 1.0)));
				}
				return vector;
			}
			if (LowerBound == null && UpperBound != null)
			{
				for (int k = 0; k < Pint.Count; k++)
				{
					vector[k] = ((Scales == null) ? ((0.0 - Pint[k]) / Math.Sqrt(Pint[k] * Pint[k] + 1.0)) : ((0.0 - Scales[k]) * Pint[k] / Math.Sqrt(Pint[k] * Pint[k] + 1.0)));
				}
				return vector;
			}
			if (Scales != null)
			{
				return Scales;
			}
			return vector;
		}
	}
}
