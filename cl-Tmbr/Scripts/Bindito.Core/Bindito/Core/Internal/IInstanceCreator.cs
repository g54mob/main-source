using System;

namespace Bindito.Core.Internal
{
	public interface IInstanceCreator
	{
		object CreateInstance(Type type);
	}
}
