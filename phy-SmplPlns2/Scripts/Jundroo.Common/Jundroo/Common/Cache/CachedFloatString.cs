using System;
using UnityEngine;

namespace Jundroo.Common.Cache
{
	public class CachedFloatString
	{
		private float _epsilon;

		private Func<float, string> _getStringFunction;

		private string _previousResult;

		private float _previousValue;

		public CachedFloatString(float epsilon, Func<float, string> getStringFunction)
		{
			_previousValue = float.MinValue;
			_previousResult = string.Empty;
			_epsilon = epsilon;
			_getStringFunction = getStringFunction;
		}

		public CachedFloatString(float initialValue, string initialResult, float epsilon, Func<float, string> getStringFunction)
		{
			_previousValue = initialValue;
			_previousResult = initialResult;
			_epsilon = epsilon;
			_getStringFunction = getStringFunction;
		}

		public string Update(float currentValue)
		{
			if (Mathf.Abs(_previousValue - currentValue) >= _epsilon)
			{
				_previousValue = currentValue;
				_previousResult = _getStringFunction(currentValue);
			}
			return _previousResult;
		}
	}
}
