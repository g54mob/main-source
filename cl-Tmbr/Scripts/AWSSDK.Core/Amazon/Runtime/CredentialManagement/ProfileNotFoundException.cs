using System;

namespace Amazon.Runtime.CredentialManagement
{
	public class ProfileNotFoundException : AmazonClientException
	{
		public ProfileNotFoundException(string message)
			: base(message)
		{
		}

		public ProfileNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
