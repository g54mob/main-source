namespace Amazon.Runtime
{
	public class TryResponse<T>
	{
		public bool Success { get; set; }

		public T Value { get; set; }

		public static TryResponse<T> Failure => new TryResponse<T>
		{
			Success = false
		};
	}
}
