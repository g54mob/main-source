using System;
using System.Runtime.InteropServices;

namespace R3
{
	[StructLayout(LayoutKind.Auto)]
	public readonly struct Notification<T>
	{
		private readonly NotificationKind kind;

		private readonly T? value;

		private readonly Exception? errorOrResultFailure;

		public NotificationKind Kind => kind;

		public T Value => value;

		public Exception Error => errorOrResultFailure;

		public Result Result
		{
			get
			{
				if (errorOrResultFailure != null)
				{
					return Result.Failure(errorOrResultFailure);
				}
				return Result.Success;
			}
		}

		public Notification(T value)
		{
			kind = NotificationKind.OnNext;
			this.value = value;
			errorOrResultFailure = null;
		}

		public Notification(Exception error)
		{
			kind = NotificationKind.OnErrorResume;
			value = default(T);
			errorOrResultFailure = error;
		}

		public Notification(Result result)
		{
			kind = NotificationKind.OnCompleted;
			value = default(T);
			errorOrResultFailure = result.Exception;
		}

		public override string? ToString()
		{
			return kind switch
			{
				NotificationKind.OnNext => value.ToString(), 
				NotificationKind.OnErrorResume => Error.ToString(), 
				NotificationKind.OnCompleted => Result.ToString(), 
				_ => "", 
			};
		}
	}
}
