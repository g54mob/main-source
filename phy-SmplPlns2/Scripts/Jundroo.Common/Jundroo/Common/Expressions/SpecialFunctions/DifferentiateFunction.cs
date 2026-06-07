using System;
using System.Reflection;

namespace Jundroo.Common.Expressions.SpecialFunctions
{
	public class DifferentiateFunction
	{
		private static MethodInfo _method;

		private Func<float> _deltaTime;

		private float? _lastValue;

		private DifferentiateFunction(Func<float> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo Method, object Instance) Create(Func<float> deltaFunc)
		{
			DifferentiateFunction item = new DifferentiateFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(DifferentiateFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (Method: _method, Instance: item);
		}

		private float Evaluate(float value)
		{
			if (_lastValue.HasValue)
			{
				float result = (value - _lastValue.Value) / _deltaTime();
				_lastValue = value;
				return result;
			}
			_lastValue = value;
			return 0f;
		}
	}
}
