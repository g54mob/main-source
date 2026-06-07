using System;
using System.Reflection;

namespace Jundroo.Common.Expressions.SpecialFunctions
{
	public class IntegrateFunction
	{
		private static MethodInfo _method;

		private Func<float> _deltaTime;

		private float _value;

		private IntegrateFunction(Func<float> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo Method, object Instance) Create(Func<float> deltaFunc)
		{
			IntegrateFunction item = new IntegrateFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(IntegrateFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (Method: _method, Instance: item);
		}

		private float Evaluate(float value)
		{
			return _value += value * _deltaTime();
		}
	}
}
