namespace BrewGame.SaveSystem.Core
{
	public static class SaveIntegrityChecker
	{
		public struct ValidationResult
		{
			public bool IsValid;

			public string Message;

			public string ExpectedChecksum;

			public string ActualChecksum;
		}

		private static bool _showDebugLogs;

		public static string ComputeChecksum(string json)
		{
			return null;
		}

		public static ValidationResult ValidateChecksum(string json, string expectedChecksum)
		{
			return default(ValidationResult);
		}

		private static string RemoveChecksumFromJson(string json)
		{
			return null;
		}

		public static ValidationResult ValidateFromBytes(byte[] data)
		{
			return default(ValidationResult);
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
