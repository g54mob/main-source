using System;
using System.Collections.Generic;

namespace NSubstitute.Core.Arguments
{
	public class DefaultChecker : IDefaultChecker
	{
		public DefaultChecker(IDefaultForType defaultForType)
		{
			_003CdefaultForType_003EP = defaultForType;
			base._002Ector();
		}

		public bool IsDefault(object? value, Type forType)
		{
			return EqualityComparer<object>.Default.Equals(value, _003CdefaultForType_003EP.GetDefaultFor(forType));
		}
	}
}
