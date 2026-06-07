using System;
using System.Reflection;

namespace Assets.Scripts.Expressions.SpecialFunctions
{
	internal class DifferentiateFunction
	{
		private static MethodInfo _method;

		private Func<double> _deltaTime;

		private double? _lastValue;

		private DifferentiateFunction(Func<double> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo, object) Create(Func<double> deltaFunc)
		{
			DifferentiateFunction item = new DifferentiateFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(DifferentiateFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (_method, item);
		}

		private double Evaluate(double value)
		{
			if (_lastValue.HasValue)
			{
				double result = (value - _lastValue.Value) / _deltaTime();
				_lastValue = value;
				return result;
			}
			_lastValue = value;
			return 0.0;
		}
	}
}
