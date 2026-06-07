using System;
using System.Reflection;

namespace Jundroo.Common.Expressions.SpecialFunctions
{
	public class PIDFunction
	{
		private static MethodInfo _method;

		private Func<float> _deltaTime;

		private float _errorSum;

		private float? _lastValue;

		private PIDFunction(Func<float> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo Method, object Instance) Create(Func<float> deltaFunc)
		{
			PIDFunction item = new PIDFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(PIDFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (Method: _method, Instance: item);
		}

		private float Evaluate(float target, float current, float p, float i, float d)
		{
			float num = target - current;
			float num2 = _deltaTime();
			float num3 = ((!_lastValue.HasValue) ? 0f : ((_lastValue.Value - current) / num2));
			_lastValue = current;
			_errorSum += num * num2;
			return p * num + i * _errorSum + d * num3;
		}
	}
}
