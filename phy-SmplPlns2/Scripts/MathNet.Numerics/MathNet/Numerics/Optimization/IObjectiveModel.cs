using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public interface IObjectiveModel : IObjectiveModelEvaluation
	{
		void SetParameters(Vector<double> initialGuess, List<bool> isFixed = null);

		void EvaluateAt(Vector<double> parameters);

		IObjectiveModel Fork();

		IObjectiveFunction ToObjectiveFunction();
	}
}
