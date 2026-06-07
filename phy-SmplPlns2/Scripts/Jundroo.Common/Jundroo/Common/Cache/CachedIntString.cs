using System;

namespace Jundroo.Common.Cache
{
	public class CachedIntString
	{
		private Func<int, string> _getStringFunction;

		private string _previousResult;

		private int _previousValue;

		public CachedIntString(Func<int, string> getStringFunction)
		{
			_previousValue = int.MinValue;
			_previousResult = string.Empty;
			_getStringFunction = getStringFunction;
		}

		public CachedIntString(int initialValue, string initialResult, Func<int, string> getStringFunction)
		{
			_previousValue = initialValue;
			_previousResult = initialResult;
			_getStringFunction = getStringFunction;
		}

		public string Update(int currentValue)
		{
			if (_previousValue != currentValue)
			{
				_previousValue = currentValue;
				_previousResult = _getStringFunction(currentValue);
			}
			return _previousResult;
		}
	}
}
