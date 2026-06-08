using System;

namespace Castle.Core
{
	public interface IServiceProviderEx : IServiceProvider
	{
		T GetService<T>() where T : class;
	}
}
