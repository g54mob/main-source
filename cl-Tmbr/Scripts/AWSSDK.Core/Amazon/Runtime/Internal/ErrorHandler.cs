using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class ErrorHandler : PipelineHandler
	{
		private IDictionary<Type, IExceptionHandler> _exceptionHandlers;

		public IDictionary<Type, IExceptionHandler> ExceptionHandlers => _exceptionHandlers;

		public ErrorHandler(ILogger logger)
		{
			Logger = logger;
			_exceptionHandlers = new Dictionary<Type, IExceptionHandler> { 
			{
				typeof(HttpErrorResponseException),
				new HttpErrorResponseExceptionHandler(Logger)
			} };
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				DisposeReponse(executionContext.ResponseContext);
				if (ProcessException(executionContext, exception))
				{
					throw;
				}
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				DisposeReponse(executionContext.ResponseContext);
				if (await ProcessExceptionAsync(executionContext, exception).ConfigureAwait(continueOnCapturedContext: false))
				{
					throw;
				}
			}
			if (executionContext.ResponseContext != null && executionContext.ResponseContext.Response != null)
			{
				return executionContext.ResponseContext.Response as T;
			}
			return null;
		}

		private static void DisposeReponse(IResponseContext responseContext)
		{
			if (responseContext.HttpResponse != null && responseContext.HttpResponse.ResponseBody != null)
			{
				responseContext.HttpResponse.ResponseBody.Dispose();
			}
		}

		private bool ProcessException(IExecutionContext executionContext, Exception exception)
		{
			Logger.Error(exception, "An exception of type {0} was handled in ErrorHandler.", exception.GetType().Name);
			executionContext.RequestContext.Metrics.AddProperty(Metric.Exception, exception);
			Type type = exception.GetType();
			do
			{
				IExceptionHandler value = null;
				if (ExceptionHandlers.TryGetValue(type, out value))
				{
					return value.Handle(executionContext, exception);
				}
				type = type.BaseType;
			}
			while (type != typeof(Exception) && type != typeof(object));
			return true;
		}

		private async Task<bool> ProcessExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			Logger.Error(exception, "An exception of type {0} was handled in ErrorHandler.", exception.GetType().Name);
			executionContext.RequestContext.Metrics.AddProperty(Metric.Exception, exception);
			Type type = exception.GetType();
			do
			{
				IExceptionHandler value = null;
				if (ExceptionHandlers.TryGetValue(type, out value))
				{
					return await value.HandleAsync(executionContext, exception).ConfigureAwait(continueOnCapturedContext: false);
				}
				type = type.BaseType;
			}
			while (type != typeof(Exception) && type != typeof(object));
			return true;
		}
	}
}
