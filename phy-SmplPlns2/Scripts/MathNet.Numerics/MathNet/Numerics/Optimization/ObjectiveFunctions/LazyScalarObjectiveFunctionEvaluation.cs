namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class LazyScalarObjectiveFunctionEvaluation : IScalarObjectiveFunctionEvaluation
	{
		private double? _value;

		private double? _derivative;

		private double? _secondDerivative;

		private readonly ScalarObjectiveFunction _objectiveObject;

		private readonly double _point;

		public double Point => _point;

		public double Value => _value ?? SetValue();

		public double Derivative => _derivative ?? SetDerivative();

		public double SecondDerivative => _secondDerivative ?? SetSecondDerivative();

		public LazyScalarObjectiveFunctionEvaluation(ScalarObjectiveFunction f, double point)
		{
			_objectiveObject = f;
			_point = point;
		}

		private double SetValue()
		{
			_value = _objectiveObject.Objective(_point);
			return _value.Value;
		}

		private double SetDerivative()
		{
			_derivative = _objectiveObject.Derivative(_point);
			return _derivative.Value;
		}

		private double SetSecondDerivative()
		{
			_secondDerivative = _objectiveObject.SecondDerivative(_point);
			return _secondDerivative.Value;
		}
	}
}
