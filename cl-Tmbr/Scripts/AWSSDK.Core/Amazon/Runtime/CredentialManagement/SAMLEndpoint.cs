using System;

namespace Amazon.Runtime.CredentialManagement
{
	public class SAMLEndpoint
	{
		private SAMLAuthenticationType DefaultAuthenticationType = SAMLAuthenticationType.Kerberos;

		public string Name { get; private set; }

		public Uri EndpointUri { get; private set; }

		public SAMLAuthenticationType AuthenticationType { get; private set; }

		internal SAMLEndpoint(string name, string endpointUri, string authenticationType)
		{
			Uri endpointUri2 = new Uri(endpointUri, UriKind.RelativeOrAbsolute);
			SAMLAuthenticationType authenticationType2 = DefaultAuthenticationType;
			if (!string.IsNullOrEmpty(authenticationType))
			{
				authenticationType2 = (SAMLAuthenticationType)Enum.Parse(typeof(SAMLAuthenticationType), authenticationType);
			}
			SetProperties(name, endpointUri2, authenticationType2);
		}

		public SAMLEndpoint(string name, Uri endpointUri)
		{
			SetProperties(name, endpointUri, DefaultAuthenticationType);
		}

		public SAMLEndpoint(string name, Uri endpointUri, SAMLAuthenticationType authenticationType)
		{
			SetProperties(name, endpointUri, authenticationType);
		}

		private void SetProperties(string name, Uri endpointUri, SAMLAuthenticationType authenticationType)
		{
			if (!string.Equals(endpointUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
			{
				throw new ArgumentException("EndpointUri is not Https protocol.");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name is null or empty.");
			}
			Name = name;
			EndpointUri = endpointUri;
			AuthenticationType = authenticationType;
		}
	}
}
