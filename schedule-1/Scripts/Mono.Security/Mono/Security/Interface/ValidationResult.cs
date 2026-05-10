namespace Mono.Security.Interface
{
	public class ValidationResult
	{
		private bool trusted;

		private bool user_denied;

		private int error_code;

		private MonoSslPolicyErrors? policy_errors;

		public bool Trusted => false;

		public bool UserDenied => false;

		public ValidationResult(bool trusted, bool user_denied, int error_code, MonoSslPolicyErrors? policy_errors)
		{
		}
	}
}
