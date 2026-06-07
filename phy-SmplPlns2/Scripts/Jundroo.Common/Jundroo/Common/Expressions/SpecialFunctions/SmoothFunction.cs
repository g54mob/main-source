using System;
using System.Reflection;
using UnityEngine;

namespace Jundroo.Common.Expressions.SpecialFunctions
{
	public class SmoothFunction
	{
		private static MethodInfo _method;

		private Func<float> _deltaTime;

		private float? _lastValue;

		private SmoothFunction(Func<float> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo Method, object Instance) Create(Func<float> deltaFunc)
		{
			SmoothFunction item = new SmoothFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(SmoothFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (Method: _method, Instance: item);
		}

		private float Evaluate(float value, float maxRate)
		{
			float num = value;
			if (_lastValue.HasValue)
			{
				num = Mathf.MoveTowards(_lastValue.Value, value, maxRate * _deltaTime());
			}
			_lastValue = num;
			return num;
		}
	}
}
