using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class MultiBindingService : IMultiBindingService
	{
		private static readonly Type TypeOfIEnumerable = typeof(IEnumerable<object>);

		public bool IsMultiBound(Type parameterType, out Type multiBoundType)
		{
			if (TypeOfIEnumerable.IsAssignableFrom(parameterType))
			{
				multiBoundType = parameterType.GenericTypeArguments[0];
				return true;
			}
			multiBoundType = null;
			return false;
		}
	}
}
