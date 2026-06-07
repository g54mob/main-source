using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

namespace R3
{
	public readonly struct Result
	{
		public static Result Success => default(Result);

		public Exception? Exception { get; }

		[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(false, "Exception")]
		public bool IsSuccess
		{
			[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(false, "Exception")]
			get
			{
				return Exception == null;
			}
		}

		[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Exception")]
		public bool IsFailure
		{
			[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Exception")]
			get
			{
				return Exception != null;
			}
		}

		public static Result Failure(Exception exception)
		{
			return new Result(exception);
		}

		public Result(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			Exception = exception;
		}

		public void TryThrow()
		{
			if (IsFailure)
			{
				ExceptionDispatchInfo.Capture(Exception).Throw();
			}
		}

		public override string ToString()
		{
			if (IsSuccess)
			{
				return "Success";
			}
			return "Failure{" + Exception.Message + "}";
		}
	}
}
