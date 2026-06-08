using System;

namespace Bindito.Core.Internal
{
	public interface IMultiBindingService
	{
		bool IsMultiBound(Type parameterType, out Type multiBoundType);
	}
}
