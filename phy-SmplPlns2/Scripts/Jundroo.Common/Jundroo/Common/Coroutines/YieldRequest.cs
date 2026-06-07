using System;

namespace Jundroo.Common.Coroutines
{
	public class YieldRequest<T>
	{
		public Action<YieldRequest<T>> Callback { get; set; }

		public T Data { get; private set; }

		public bool Done { get; private set; }

		public string ErrorMessage { get; private set; }

		public bool Success { get; private set; }

		public void Complete(T data)
		{
			Data = data;
			Success = true;
			Done = true;
			Callback?.Invoke(this);
		}

		public void Error(string errorMessage)
		{
			ErrorMessage = errorMessage;
			Success = false;
			Done = true;
			Callback?.Invoke(this);
		}
	}
}
