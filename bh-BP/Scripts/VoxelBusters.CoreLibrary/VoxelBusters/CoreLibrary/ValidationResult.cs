namespace VoxelBusters.CoreLibrary
{
	public class ValidationResult
	{
		public static ValidationResult Success { get; private set; }

		public bool IsValid { get; private set; }

		public Error Error { get; private set; }

		static ValidationResult()
		{
		}

		private ValidationResult(bool isValid, Error error = null)
		{
		}

		public static ValidationResult CreateError(Error error)
		{
			return null;
		}

		public static ValidationResult CreateError(string domain = null, int code = -1, string description = "")
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
