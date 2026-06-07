using System;
using System.Reflection;

namespace Assets.Scripts.Expressions.SpecialFunctions
{
	internal class IntegrateFunction
	{
		private static MethodInfo _method;

		private Func<double> _deltaTime;

		private double _value;

		private IntegrateFunction(Func<double> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo, object) Create(Func<double> deltaFunc)
		{
			IntegrateFunction item = new IntegrateFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(IntegrateFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (_method, item);
		}

		private double Evaluate(double value)
		{
			return _value += value * _deltaTime();
		}
	}
}
