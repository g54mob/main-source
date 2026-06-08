using System;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public abstract class ExceptionHandler<T> : IExceptionHandler<T>, IExceptionHandler where T : Exception
	{
		private ILogger _logger;

		protected ILogger Logger => _logger;

		protected ExceptionHandler(ILogger logger)
		{
			_logger = logger;
		}

		public bool Handle(IExecutionContext executionContext, Exception exception)
		{
			return HandleException(executionContext, exception as T);
		}

		public abstract bool HandleException(IExecutionContext executionContext, T exception);

		public async Task<bool> HandleAsync(IExecutionContext executionContext, Exception exception)
		{
			return await HandleExceptionAsync(executionContext, exception as T).ConfigureAwait(continueOnCapturedContext: false);
		}

		public abstract Task<bool> HandleExceptionAsync(IExecutionContext executionContext, T exception);
	}
}
