using System;
using System.Reflection;

namespace Assets.Scripts.Expressions.SpecialFunctions
{
	internal class PIDFunction
	{
		private static MethodInfo _method;

		private Func<double> _deltaTime;

		private double? _lastValue;

		private double _errorSum;

		private PIDFunction(Func<double> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo, object) Create(Func<double> deltaFunc)
		{
			PIDFunction item = new PIDFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(PIDFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (_method, item);
		}

		private double Evaluate(double target, double current, double p, double i, double d)
		{
			double num = target - current;
			double num2 = _deltaTime();
			double num3 = ((!_lastValue.HasValue) ? 0.0 : ((_lastValue.Value - current) / num2));
			_lastValue = current;
			_errorSum += num * num2;
			return p * num + i * _errorSum + d * num3;
		}
	}
}
