namespace JWT
{
	public class ValidationParameters
	{
		public bool ValidateSignature { get; set; }

		public bool ValidateExpirationTime { get; set; }

		public bool ValidateIssuedTime { get; set; }

		public int TimeMargin { get; set; }

		public static ValidationParameters Default => null;

		public static ValidationParameters None => null;
	}
}
