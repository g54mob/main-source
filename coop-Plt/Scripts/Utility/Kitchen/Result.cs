namespace Kitchen
{
	public class Result
	{
		public bool Success;

		public static Result Succeed()
		{
			return new Result
			{
				Success = true
			};
		}

		public static Result Fail()
		{
			return new Result
			{
				Success = false
			};
		}

		public static Result From(bool result)
		{
			return new Result
			{
				Success = result
			};
		}

		public static Result<T> Succeed<T>(T result)
		{
			return new Result<T>
			{
				Value = result,
				Success = true
			};
		}

		public static Result<T> Fail<T>()
		{
			return new Result<T>
			{
				Value = default(T),
				Success = false
			};
		}

		public static Result<T> Fail<T>(T result)
		{
			return new Result<T>
			{
				Value = result,
				Success = false
			};
		}
	}
	public struct Result<T>
	{
		public T Value;

		public bool Success;

		public static Result<T> Succeed(T result)
		{
			return new Result<T>
			{
				Value = result,
				Success = true
			};
		}

		public static Result<T> Fail()
		{
			return new Result<T>
			{
				Value = default(T),
				Success = false
			};
		}

		public static implicit operator Result<T>(T value)
		{
			return Result.Succeed(value);
		}
	}
}
