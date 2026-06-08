namespace Amazon.Runtime
{
	public class CredentialRequestCallbackArgs
	{
		public string ProfileName { get; internal set; }

		public string UserIdentity { get; internal set; }

		public object CustomState { get; internal set; }

		public bool PreviousAuthenticationFailed { get; internal set; }
	}
}
