using System;

namespace Castle.Core
{
	public interface IServiceEnabledComponent
	{
		void Service(IServiceProvider provider);
	}
}
