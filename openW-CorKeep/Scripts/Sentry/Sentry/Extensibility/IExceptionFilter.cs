using System;

namespace Sentry.Extensibility
{
	public interface IExceptionFilter
	{
		bool Filter(Exception ex);
	}
}
