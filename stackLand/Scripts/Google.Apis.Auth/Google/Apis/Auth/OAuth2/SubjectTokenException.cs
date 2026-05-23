using System;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2
{
	public class SubjectTokenException : Exception
	{
		internal SubjectTokenException(ExternalAccountCredential credential, Exception innerException)
			: base("An error occurred while attempting to obtain the subject token for " + credential.ThrowIfNull("credential").GetType().Name, innerException)
		{
		}
	}
}
