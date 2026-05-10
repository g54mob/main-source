using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ookii.Dialogs
{
	[Serializable]
	public class CredentialException : Win32Exception
	{
		public CredentialException()
		{
		}

		public CredentialException(int error)
		{
		}

		public CredentialException(string message)
		{
		}

		public CredentialException(int error, string message)
		{
		}

		public CredentialException(string message, Exception innerException)
		{
		}

		protected CredentialException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
