using System;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Expressions.SpecialFunctions
{
	internal class SmoothFunction
	{
		private static MethodInfo _method;

		private Func<double> _deltaTime;

		private double? _lastValue;

		private SmoothFunction(Func<double> delta)
		{
			_deltaTime = delta;
		}

		public static (MethodInfo, object) Create(Func<double> deltaFunc)
		{
			SmoothFunction item = new SmoothFunction(deltaFunc);
			if (_method == null)
			{
				_method = typeof(SmoothFunction).GetMethod("Evaluate", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (_method, item);
		}

		private double Evaluate(double value, double maxRate)
		{
			double num = value;
			if (_lastValue.HasValue)
			{
				num = Mathd.MoveTowards(_lastValue.Value, value, maxRate * _deltaTime());
			}
			_lastValue = num;
			return num;
		}
	}
}
